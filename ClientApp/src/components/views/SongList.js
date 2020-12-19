import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import MaterialTable from "material-table";
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Alert, Row } from 'reactstrap'

export class SongList extends Component {
    static baseUrl = 'api/ProductSongs/';
    static productUrl = 'api/Products/';
    static displayName = SongList.name;
    static emptyRow = {
        title: '',
        price: '',
        releaseYear: '',
        language: '',
        genreId: '',
        filePath: '',
        previewFilePath: '',
        artist: '',
        album: '',
        country: '',
        label: '',
    }



    constructor(props) {
        super(props);
        this.state = {
            // We use these to show/hide the modals
            editModal: false,
            deleteModal: false,
            // Current row holds the current data in the edit/create modal's form
            currentRow: this.copyEmptyRow(),
        };
        this.toggleEditModal = this.toggleEditModal.bind(this);
        this.toggleDeleteModal = this.toggleDeleteModal.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.handleSave = this.handleSave.bind(this);
        // We create a reference to the table
        this.tableRef = React.createRef();
    }

    showAlert(message, type) {
        // We add an alert to the DOM via the alerts div
        const element = (
            <Alert color={type}>
                {message}
            </Alert>
        )
        ReactDOM.render(element, document.getElementById('alerts'));
    }

    copyEmptyRow() {
        return JSON.parse(JSON.stringify(SongList.emptyRow));
    }

    flattenData(data) {
        let flatData = [];
        for (let rowData of data) {
            console.log(rowData);
            flatData.push({
                code: rowData.code,
                title: rowData.product.title,
                price: rowData.product.price,
                releaseYear: rowData.product.releaseYear,
                language: rowData.product.language,
                genreId: rowData.genre.id,
                id: rowData.product.id,
                filePath: rowData.product.filePath,
                previewFilePath: rowData.product.previewFilePath,
                artist: rowData.artist,
                album: rowData.album,
                country: rowData.country,
                label: rowData.label,
            })
        }
        return flatData;
    }

    toggleEditModal(rowData) {
        // If the method is called with row data, 'Edit' was clicked, we set the currentRow to it
        // If not, it means 'New' or 'Cancel' was clicked, so we set it to an empty row
        let currentRow = (rowData ? rowData : this.copyEmptyRow())
        this.setState({
            editModal: !this.state.editModal,
            currentRow: currentRow,
        })
    }

    toggleDeleteModal(rowData) {
        // If the method is called with row data, 'Edit' was clicked, we set the currentRow to it
        // If not, it means 'New' or 'Cancel' was clicked, so we set it to an empty row
        let currentRow = (rowData ? rowData : this.copyEmptyRow())
        this.setState({
            deleteModal: !this.state.deleteModal,
            currentRow: currentRow,
        })
    }

    handleChange(e) {
        // We update the currentRow each time a value in the form changes
        const { name, value } = e.target;
        this.setState(prevState => ({
            currentRow: {
                ...prevState.currentRow, [name]: value
            }
        }));
    }

    async addRow() {
        // We call the backend to add the new row
        await fetch(SongList.baseUrl, {
            method: 'POST',
            body: JSON.stringify(this.state.currentRow),
            headers: {
                'content-type': 'application/json'
            }
        }).then(response => {
            this.toggleEditModal();
            this.showAlert('Registro añadido con exito', 'success');
            // We reload the table
            this.tableRef.current.onQueryChange();
        }).catch(error => {
            this.showAlert('Ha ocurrido un error!', 'danger');
            console.log(error)
        });
    }

    async editRow() {
        // We call the backend to edit the row
        await fetch(SongList.baseUrl + this.state.currentRow.code, {
            method: 'PUT',
            body: JSON.stringify(this.state.currentRow),
            headers: {
                'content-type': 'application/json'
            }

        }).then(fetch('api/Products/' + this.state.currentRow.id, {
            method: 'PUT',
            body: JSON.stringify(this.state.currentRow),
            headers: {
                'content-type': 'application/json'
            }
        })).then(response => {
            this.toggleEditModal();
            this.showAlert('Registro actualizado con exito', 'success');
            // We reload the table
            this.tableRef.current.onQueryChange();
        }).catch(error => {
            this.showAlert('Ha ocurrido un error!', 'danger');
            console.log(error)
        });
    }

    async handleSave(e) {
        for (const [key, value] of Object.entries(SongList.emptyRow)) {
            if (this.state.currentRow[key] == value) {
                this.showAlert('Todos los campos deben ser llenados!', 'danger');
                this.toggleEditModal();
                return;
            }
        }
        if (this.state.currentRow.code) {
            await this.editRow();
        } else {
            await this.addRow();
        }
    }

    async deleteRow() {
        // We call the backend to delete the row
        await fetch(SongList.baseUrl + this.state.currentRow.code, {
            method: 'DELETE',
        });
        fetch(SongList.productUrl + this.state.currentRow.id, {
            method: 'DELETE',
        }).then(response => {
            this.toggleDeleteModal();
            this.showAlert('Registro eliminado con exito', 'success');
            // We reload the table
            this.tableRef.current.onQueryChange();
        }).catch(error => {
            this.showAlert('Ha ocurrido un error!', 'danger');
            console.log(error)
        });
    }

    async handleDelete(e) {
        if (this.state.currentRow.id) {
            await this.deleteRow();
        }
    }


    render() {
        return (
            <div style={{ maxWidth: '100%' }}>
                <div id="alerts"></div>
                <MaterialTable
                    title="Musica"
                    tableRef={this.tableRef}
                    options={{
                        search: false,
                        actionsColumnIndex: -1,
                        initialPage: 0,
                    }}
                    columns={[
                        {
                            title: "Code",
                            field: "code",
                        },
                        {
                            title: "Titulo",
                            field: "title",
                        },
                        {
                            title: "Producto",
                            field: "id",
                        },
                        {
                            title: "Precio",
                            field: "price",
                        },
                        {
                            title: "Año de publicacion",
                            field: "releaseYear",
                        },
                        {
                            title: "Idioma",
                            field: "language",
                        },
                        {
                            title: "Genero",
                            field: "genreId",
                        },
                        {
                            title: "File Path",
                            field: "filePath",
                        },
                        {
                            title: "File Preview",
                            field: "previewFilePath",
                        },
                        {
                            title: "Artista",
                            field: "artist",
                        },
                        {
                            title: "Album",
                            field: "album",
                        },
                        {
                            title: "Pais",
                            field: "country",
                        },
                        {
                            title: "Label",
                            field: "label",
                        },
                    ]}
                    data={query =>
                        // We make the request to gather the table data
                        new Promise((resolve, reject) => {
                            console.log(query);
                            fetch(SongList.baseUrl)
                                .then(response => response.json())
                                .then(result => {
                                    // Here we do the pagination using the query passed
                                    // by the table. We have no backend pagination
                                    let initialIndex = query.pageSize * query.page;
                                    let finalIndex = query.pageSize * (query.page + 1);
                                    let flatResult = this.flattenData(result);
                                    resolve({
                                        data: flatResult.slice(initialIndex, finalIndex),
                                        page: query.page,
                                        totalCount: result.length,
                                    })
                                })
                        })
                    }
                    actions={[
                        // We have an edit & delete action for each row
                        {
                            icon: 'edit',
                            tooltip: 'Editar',
                            onClick: (event, rowData) => this.toggleEditModal(rowData),
                        },
                        {
                            icon: 'delete',
                            tooltip: 'Eliminar',
                            onClick: (event, rowData) => this.toggleDeleteModal(rowData),
                        },
                        // We have an add action that is independent to any row
                        {
                            icon: 'add',
                            tooltip: 'Nuevo',
                            onClick: () => this.toggleEditModal(),
                            isFreeAction: true,
                        }
                    ]}
                    // We override the Actions header
                    localization={{
                        header: {
                            actions: 'Acciones'
                        },
                    }}
                />
                {/* Create / Edit Modal */}
                <Modal isOpen={this.state.editModal}>
                    <ModalHeader>Libro</ModalHeader>
                    <ModalBody>
                        <div className="form-group">
                            <div className="form-group row">
                                <label htmlFor="title" className="col-sm-2 col-form-label">Titulo</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="title"
                                        name="title"
                                        value={this.state.currentRow.title}
                                        onChange={this.handleChange}
                                    />
                                </div>
                            </div>
                            <div className="form-group row">
                                <label htmlFor="genreId" className="col-sm-2 col-form-label">Genero</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="genreId"
                                        name="genreId"
                                        value={this.state.currentRow.genere}
                                        onChange={this.handleChange}
                                    />
                                </div>
                            </div>
                            <div className="form-group row">
                                <label htmlFor="artist" className="col-sm-2 col-form-label">Artista</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="artist"
                                        name="artist"
                                        value={this.state.currentRow.artist}
                                        onChange={this.handleChange}
                                    /></div>
                            </div>
                            
                            

                            <div className="form-group row">
                                <label htmlFor="country" className="col-sm-2 col-form-label">Pais</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="country"
                                        name="country"
                                        value={this.state.currentRow.country}
                                        onChange={this.handleChange}
                                    /></div>
                            </div>
                            <div className="form-group row">
                                <label htmlFor="price" className="col-sm-2 col-form-label">Precio</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="price"
                                        name="price"
                                        value={this.state.currentRow.price}
                                        onChange={this.handleChange}
                                    /></div>
                            </div>
                            <div className="form-group row">
                                <label htmlFor="album" className="col-sm-2 col-form-label">Album</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="album"
                                        name="album"
                                        value={this.state.currentRow.album}
                                        onChange={this.handleChange}
                                    /></div>
                            </div>  
                            <div className="form-group row">
                                <label htmlFor="releaseYear" className="col-sm-2 col-form-label">Año de publicación</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="releaseYear"
                                        name="releaseYear"
                                        value={this.state.currentRow.releaseYear}
                                        onChange={this.handleChange}
                                    /></div>
                            </div>  
                            <div className="form-group row">
                                <label htmlFor="language" className="col-sm-2 col-form-label">Idioma</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="language"
                                        name="language"
                                        value={this.state.currentRow.language}
                                        onChange={this.handleChange}
                                    /></div>
                            </div>
                            <div className="form-group row">
                                <label htmlFor="label" className="col-sm-2 col-form-label">Label</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="label"
                                        name="label"
                                        value={this.state.currentRow.label}
                                        onChange={this.handleChange}
                                    /></div>
                            </div>
                            <div className="form-group row">
                                <label htmlFor="filePath" className="col-sm-2 col-form-label">File Path</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="filePath"
                                        name="filePath"
                                        value={this.state.currentRow.filePath}
                                        onChange={this.handleChange}
                                    /></div>
                            </div>
                            <div className="form-group row">
                                <label htmlFor="previewFilePath" className="col-sm-2 col-form-label">Preview path</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="previewFilePath"
                                        name="previewFilePath"
                                        value={this.state.currentRow.previewFilePath}
                                        onChange={this.handleChange}
                                    /></div>
                            </div>
                        </div>
                    </ModalBody>
                    <ModalFooter>
                        <Button color="secondary" onClick={() => this.toggleEditModal()}>Cancelar</Button>{' '}
                        <Button color="primary" onClick={() => this.handleSave()}>Guardar</Button>
                    </ModalFooter>
                </Modal>
                {/* Delete Modal */}
                <Modal isOpen={this.state.deleteModal}>
                    <ModalHeader>Usuario</ModalHeader>
                    <ModalBody>
                        Estás seguro de que quieres eliminar el registro {this.state.currentRow.id}?
                    </ModalBody>
                    <ModalFooter>
                        <Button color="secondary" onClick={() => this.toggleDeleteModal()}>Cancelar</Button>{' '}
                        <Button color="danger" onClick={() => this.handleDelete()}>Borrar</Button>
                    </ModalFooter>
                </Modal>
            </div>
        )
    }
}