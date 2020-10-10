import React, { Component } from 'react';

export class AddMusic extends Component {
    static displayName = AddMusic.name;

    render() {
        return (
            <div>
                <form class="form-horizontal">
                    <legend font-weight-bold>Agregar música</legend>
                    <hr class="sidebar-divider" />
                    <div class="form-group">
                        <label for="nombre">Nombre de la canción: </label>
                        <input required type="text" placeholder="Inserte el nombre de la canción" class="form-control" name="nombre" id="nombre" />
                    </div>
                    <div class="form-group">
                        <label for="artist">Nombre de los intérpretes: </label>
                        <textarea required type="text" placeholder="Inserte el nombre de los intérpretes" class="form-control" name="artist" id="artist" />
                    </div>
                    <div class="form-group">
                        <label for="album">Nombre del álbum: </label>
                        <input required type="text" placeholder="Inserte el nombre del álbum" class="form-control" name="album" id="album" />
                    </div>
                    <div class="form-row">
                        <div class="col">
                            <div class="form-group">
                                <label for="category">Categoría: </label>
                                <select class="custom-select" required name="category" id="category">
                                    <option selected disabled value='' >Seleccione una categoría</option>
                                    <option value='1'>Metal</option>
                                    <option value='2'>Hard Rock</option>
                                    <option value='3'>Punk</option>
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
                            <input required type="number" min="0" placeholder="Minutos" class="form-control" name="minutes" id="minutes" />
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
                        <label for="fileext">Tipo interpretación: </label>
                        <select class="custom-select" required name="interpret" id="fileinterpretext">
                            <option selected disabled value='' >Seleccione un tipo</option>
                            <option value='1'>Solo</option>
                            <option value='2'>Orqueta</option>
                            <option value='2'>Banda</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="fileext">Formato: </label>
                        <select class="custom-select" required name="fileext" id="fileext">
                            <option selected disabled value='' >Seleccione un formato</option>
                            <option value='1'>mp3</option>
                            <option value='2'>aac</option>
                            <option value='2'>wav</option>
                            <option value='2'>aiff</option>
                            <option value='2'>pcm</option>
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
                        <button id="insertar" name="insertar" class="btn btn-success">Insertar</button>
                        <button id="cancel" name="cancel" class="btn btn-default">Cancelar</button>
                    </div>
                </form>
            </div>
        );
    }
}
