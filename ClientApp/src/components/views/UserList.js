import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import MaterialTable from "material-table";
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Alert } from 'reactstrap'

export class UserList extends Component {
    static baseUrl = 'api/users/';
    static displayName = UserList.name;
    static emptyRow = {
        firstName: '',
        lastName1: '',
        lastName2: '',
        password: '',
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
        return Object.assign({}, UserList.emptyRow);
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
        await fetch(UserList.baseUrl, {
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
        await fetch(UserList.baseUrl + this.state.currentRow.id, {
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
        for (const [key, value] of Object.entries(UserList.emptyRow)) {
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
        await fetch(UserList.baseUrl + this.state.currentRow.id, {
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
                    title="Usuarios"
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
                            title: "Correo electronico",
                            field: "email",
                        },
                        {
                            title: "Nombre",
                            field: "firstName",
                        },
                        {
                            title: "Primer apellido",
                            field: "lastName1",
                        },
                        {
                            title: "Segundo apellido",
                            field: "lastName2",
                        },
                        {
                            title: "Contraseña",
                            field: "password",
                        },
                    ]}
                    data={query =>
                        // We make the request to gather the table data
                        new Promise((resolve, reject) => {
                            console.log(query);
                            fetch(UserList.baseUrl)
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
                                <label htmlFor="email" className="col-sm-2 col-form-label">Correo Electronico</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="email"
                                        name="email"
                                        value={this.state.currentRow.email}
                                        onChange={this.handleChange}
                                    />
                                </div>
                            </div>
                            <div className="form-group row">
                                <label htmlFor="firstName" className="col-sm-2 col-form-label">Nombre</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="firstName"
                                        name="firstName"
                                        value={this.state.currentRow.firstName}
                                        onChange={this.handleChange}
                                    /></div>
                            </div>
                            <div className="form-group row">
                                <label htmlFor="lastName1" className="col-sm-2 col-form-label">Primer apellido</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="lastName1"
                                        name="lastName1"
                                        value={this.state.currentRow.lastName1}
                                        onChange={this.handleChange}
                                    /></div>
                            </div>
                            <div className="form-group row">
                                <label htmlFor="lastName2" className="col-sm-2 col-form-label">Segundo apellido</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="lastName2"
                                        name="lastName2"
                                        value={this.state.currentRow.lastName2}
                                        onChange={this.handleChange}
                                    /></div>
                            </div>
                            <div className="form-group row">
                                <label htmlFor="password" className="col-sm-2 col-form-label">Contraseña</label>
                                <div className="col-sm-10">
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="password"
                                        name="password"
                                        value={this.state.currentRow.password}
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