import React, { Component } from 'react';

export class AddFilm extends Component {
    static displayName = AddFilm.name;

    render() {
        return (
            <div>
                <form class="form-horizontal">
                    <legend font-weight-bold>Agregar película</legend>
                    <div class="float-right mx-auto my-3">
                        <button id="clear" name="clear" class="btn btn-warning">Limpiar todo</button>
                    </div>
                    <hr class="sidebar-divider" />
                    <div class="form-group">
                        <label for="nombre">Nombre: </label>
                        <input required type="text" placeholder="Inserte el nombre de la película" class="form-control" name="nombre" id="nombre" />
                    </div>
                    <div class="form-group">
                        <label for="actor">Nombre de los actores: </label>
                        <textarea required type="text" placeholder="Inserte el nombre de los actores" class="form-control" name="actor" id="actor" />
                    </div>
                    <div class="form-row">
                        <div class="col">
                            <div class="form-group">
                                <label for="category">Categoría: </label>
                                <select class="custom-select" required name="category" id="category">
                                    <option selected disabled value='' >Seleccione una categoría</option>
                                    <option value='1'>Drama</option>
                                    <option value='2'>Comedia</option>
                                    <option value='3'>Terror</option>
                                </select>
                            </div>
                        </div>
                        <div class="col">
                            <label for="id">ID: </label>
                            <input required type="number" min="0" placeholder="ID" class="form-control" name="id" id="id" />
                        </div>
                    </div>


                    <div class="form-group">
                        <label for="production">Productora: </label>
                        <input required type="text" placeholder="Inserte el nombre de la productora" class="form-control" name="production" id="production" />
                    </div>
                    <div class="form-row">
                        <div class="col">
                            <label for="releasedate">Fecha de publicación: </label>
                            <input required type="date" placeholder="Inserte la fecha de publicación" class="form-control" name="releasedate" id="releasedate" />
                        </div>
                        <div class="col">
                            <label for="minutes">Duración (minutos): </label>
                            <input required type="text" placeholder="Minutos" class="form-control" name="minutes" id="minutes" />
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col">
                            <label for="price">Precio: </label>
                            <input required type="text" placeholder="Inserte el precio" class="form-control" name="price" id="price" />
                        </div>
                        <div class="col">
                            <label for="inventory">Inventario: </label>
                            <input required type="number" min="0" placeholder="Cantidad en inventario" class="form-control" name="inventory" id="inventory" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="fileext">Formato: </label>
                        <select class="custom-select" required name="fileext" id="fileext">
                            <option selected disabled value='' >Seleccione un formato</option>
                            <option value='1'>UHD</option>
                            <option value='2'>mp4</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="ruta">Ruta archivo: </label>
                        <input required type="text" placeholder="Inserte la ruta del archivo" class="form-control" name="ruta" id="ruta" />
                    </div>
                    <div id="lang">
                        <div class="form-group form-check">
                            <label for="lang">Idiomas: </label>
                            <div id="lang">
                                <input type="checkbox" class="form-check-input" id="en" />
                                <label class="form-check-label" for="en">Inglés</label>
                            </div>
                        </div>
                        <div class="form-group form-check">
                            <div id="lang">
                                <input type="checkbox" class="form-check-input" id="es" />
                                <label class="form-check-label" for="es">Español</label>
                            </div>
                        </div>
                        <div class="form-group form-check">
                            <div id="lang">
                                <input type="checkbox" class="form-check-input" id="de" />
                                <label class="form-check-label" for="de">Alemán</label>
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
