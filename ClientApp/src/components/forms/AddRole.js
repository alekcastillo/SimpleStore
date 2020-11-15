import React, { Component } from 'react';

export class AddRole extends Component {
    static displayName = AddRole.name;

    render() {
        return (
            <div>
                <form class="form-horizontal">
                    <legend font-weight-bold>Agregar rol de empleado</legend>
                    <div class="float-right mx-auto my-3">
                        <button id="clear" name="clear" class="btn btn-warning">Limpiar todo</button>
                    </div>
                    <hr class="sidebar-divider" />
                    <div class="form-group">
                        <label for="nombre">Nombre del rol: </label>
                        <input required type="text" placeholder="Inserte el nombre del rol" class="form-control" name="nombre" id="nombre" />
                    </div>
                    <div class="form-group">
                        <label for="description">Nombre descripción de las funciones: </label>
                        <input required type="text" placeholder="Inserte descripción" class="form-control" name="description" id="description" />
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
