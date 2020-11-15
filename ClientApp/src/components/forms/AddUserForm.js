import React, { Component } from 'react';

export class AddUserForm extends Component {
    static displayName = AddUserForm.name;

    render() {
        return (
            <div>
                <form class="form-horizontal">
                    <legend font-weight-bold>Agregar usuario</legend>
                    <div class="float-right mx-auto my-3">
                        <button id="clear" name="clear" class="btn btn-warning">Limpiar todo</button>
                    </div>
                    <hr class="sidebar-divider" />
                    <div class="form-group my-3">
                        <label for="first-name">Nombre</label>
                        <input required type="text" placeholder="Inserte el nombre del usuario" class="form-control" name="first-name" id="first-name" />
                    </div>
                    <div class="form-group my-3">
                        <label for="last-name">Apellido</label>
                        <input required type="text" placeholder="Inserte el apellido del usuario" class="form-control" name="last-name" id="last-name" />
                    </div>
                    <div class="form-group my-3">
                        <label for="email">Correo</label>
                        <input required type="text" placeholder="Inserte el correo del usuario" class="form-control" name="email" id="email" />
                    </div>
                    <div class="form-group my-3">
                        <label for="nombre">Contraseña</label>
                        <input required type="password" placeholder="Inserte la contraseña del usuario" class="form-control" name="password1" id="password1" />
                    </div>
                    <div class="form-group my-3">
                        <label for="nombre">Confirmacion de contraseña</label>
                        <input required type="password" placeholder="Inserte denuevo la contraseña del usuario" class="form-control" name="password2" id="password2" />
                    </div>
                    <div class="form-group my-3">
                        <label for="telephone">Número telefónico</label>
                        <input required type="password" placeholder="Inserte el número telefónico del usuario" class="form-control" name="telephone" id="telephone" />
                    </div>
                    <div class="form-group my-3">
                        <label for="birthdate">Fecha de nacimiento</label>
                        <input required type="date" placeholder="Inserte la fecha de nacimiento del usuario" class="form-control" name="birthdate" id="birthdate" />
                    </div>
                    <div class="form-group">
                        <label for="country">Pais</label>
                        <select class="custom-select" required name="country" id="country">
                            <option selected disabled value='' >Seleccione un pais</option>
                            <option value='1'>Costa Rica</option>
                            <option value='2'>Panama</option>
                        </select>
                    </div>
                    {/* TODO: hacer dinamico y revisar si hay mas ids repetidos */}
                    <label for="lang">Roles</label>
                    <div id="lang">
                        <div class="form-group form-check">
                            <div id="lang">
                                <input type="checkbox" class="form-check-input" id="en" />
                                <label class="form-check-label" for="en">Administrador</label>
                            </div>
                        </div>
                        <div class="form-group form-check">
                            <div id="lang">
                                <input type="checkbox" class="form-check-input" id="es" />
                                <label class="form-check-label" for="es">Seguridad</label>
                            </div>
                        </div>
                        <div class="form-group form-check">
                            <div id="lang">
                                <input type="checkbox" class="form-check-input" id="de" />
                                <label class="form-check-label" for="de">Mantenimiento</label>
                            </div>
                        </div>
                        <div class="form-group form-check">
                            <div id="lang">
                                <input type="checkbox" class="form-check-input" id="de" />
                                <label class="form-check-label" for="de">Consultas</label>
                            </div>
                        </div>
                    </div>
                    <div>
                        <button id="save" name="save" class="btn btn-primary">Guardar</button>
                        <button id="cancel" name="cancel" class="btn btn-default">Cancelar</button>
                    </div>
                </form>
            </div>
        );
    }
}
