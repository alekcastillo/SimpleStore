import React, { Component } from 'react';

export class LoginForm extends Component {
    static displayName = LoginForm.name;

    render() {
        return (
            <div>
                <form class="form-horizontal">
                    <legend font-weight-bold>Iniciar sesion</legend>
                    <hr class="sidebar-divider" />
                    <div class="form-group my-3">
                        <label for="email">Correo</label>
                        <input required type="text" placeholder="Inserte el correo del usuario" class="form-control" name="email" id="email" />
                    </div>
                    <div class="form-group my-3">
                        <label for="nombre">Contraseña</label>
                        <input required type="password" placeholder="Inserte la contraseña del usuario" class="form-control" name="password1" id="password1" />
                    </div>
                    <div>
                        <button id="save" name="save" class="btn btn-primary">Ingresar</button>
                        <button id="cancel" name="cancel" class="btn btn-default">Cancelar</button>
                    </div>
                </form>
                <br />
                <div class="border-top pt-3">
                    <small class="text-muted">
                        No tienes una cuenta? <a class="ml-2" href="./add-user">Crea una ahora!</a>
                    </small>
                </div>
            </div>
        );
    }
}
