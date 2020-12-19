import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import MaterialTable from "material-table";
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Alert } from 'reactstrap'

export class SystemConfigurationList extends Component {
    static baseUrl = 'api/systemconfigurations/';
    static displayName = SystemConfigurationList.name;
    static emptyRow = {
        booksSavePath: '',
        bookPreviewsSavePath: '',
        songsSavePath: '',
        songPreviewsSavePath: '',
        moviesSavePath: '',
        moviePreviewsSavePath: '',
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
        return Object.assign({}, SystemConfigurationList.emptyRow);
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
        await fetch(SystemConfigurationList.baseUrl, {
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
        await fetch(SystemConfigurationList.baseUrl + this.state.currentRow.id, {
            method: 'PUT',
            body: JSON.stringify(this.state.currentRow),
            headers: {
                'content-type': 'application/json'
            }
        }).then(response => {
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
        for (const [key, value] of Object.entries(SystemConfigurationList.emptyRow)) {
            if (this.state.currentRow[key] == value) {
                this.showAlert('Todos los campos deben ser llenados!', 'danger');
                this.toggleEditModal();
                return;
            }
        }
        if (this.state.currentRow.id) {
            await this.editRow();
        } else {
            await this.addRow();
        }
    }

    async deleteRow() {
        // We call the backend to delete the row
        await fetch(SystemConfigurationList.baseUrl + this.state.currentRow.id, {
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
                    title="Configuraciones"
                    tableRef={this.tableRef}
                    options={{
                        search: false,
                        actionsColumnIndex: -1,
                        initialPage: 0,
                    }}
                    columns={[
                        {
                            title: "ID",
                            field: "id",
                        },
                        {
                            title: "Ruta de libros",
                            field: "booksSavePath",
                        },
                        {
                            title: "Ruta de previews de libros",
                            field: "bookPreviewsSavePath",
                        },
                        {
                            title: "Ruta de canciones",
                            field: "songsSavePath",
                        },
                        {
                            title: "Ruta de previews de canciones",
                            field: "songPreviewsSavePath",
                        },
                        {
                            title: "Ruta de peliculas",
                            field: "moviesSavePath",
                        },
                        {
                            title: "Ruta de previews de peliculas",
                            field: "moviePreviewsSavePath",
                        },
                    ]}
                    data={query =>
                        // We make the request to gather the table data
                        new Promise((resolve, reject) => {
                            console.log(query);
                            fetch(SystemConfigurationList.baseUrl)
                                .then(response => response.json())
                                .then(result => {
                                    // Here we do the pagination using the query passed
                                    // by the table. We have no backend pagination
                                    let initialIndex = query.pageSize * query.page;
                                    let finalIndex = query.pageSize * (query.page + 1);
                                    resolve({
                                        data: result.slice(initialIndex, finalIndex),
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
                    <ModalHeader>Usuario</ModalHeader>
                    <ModalBody>
                        <div className="form-group">
                            <div className="form-group row">
                                <label htmlFor="booksSavePath" className="col-sm-2 col-form-label">Ruta de libros</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="booksSavePath"
                                        name="booksSavePath"
                                        value={this.state.currentRow.booksSavePath}
                                        onChange={this.handleChange}
                                    />
                                </div>
                            </div>
                            <div className="form-group row">
                                <label htmlFor="bookPreviewsSavePath" className="col-sm-2 col-form-label">Ruta de previews de libros</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="bookPreviewsSavePath"
                                        name="bookPreviewsSavePath"
                                        value={this.state.currentRow.bookPreviewsSavePath}
                                        onChange={this.handleChange}
                                    />
                                </div>
                            </div>
                            <div className="form-group row">
                                <label htmlFor="songsSavePath" className="col-sm-2 col-form-label">Ruta de canciones</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="songsSavePath"
                                        name="songsSavePath"
                                        value={this.state.currentRow.songsSavePath}
                                        onChange={this.handleChange}
                                    />
                                </div>
                            </div>
                            <div className="form-group row">
                                <label htmlFor="songPreviewsSavePath" className="col-sm-2 col-form-label">Ruta de previews de canciones</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="songPreviewsSavePath"
                                        name="songPreviewsSavePath"
                                        value={this.state.currentRow.songPreviewsSavePath}
                                        onChange={this.handleChange}
                                    />
                                </div>
                            </div>
                            <div className="form-group row">
                                <label htmlFor="moviesSavePath" className="col-sm-2 col-form-label">Ruta de peliculas</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="moviesSavePath"
                                        name="moviesSavePath"
                                        value={this.state.currentRow.moviesSavePath}
                                        onChange={this.handleChange}
                                    />
                                </div>
                            </div>
                            <div className="form-group row">
                                <label htmlFor="moviePreviewsSavePath" className="col-sm-2 col-form-label">Ruta de previews de peliculas</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="moviePreviewsSavePath"
                                        name="moviePreviewsSavePath"
                                        value={this.state.currentRow.moviePreviewsSavePath}
                                        onChange={this.handleChange}
                                    />
                                </div>
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
                    <ModalHeader>Consecutivo</ModalHeader>
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