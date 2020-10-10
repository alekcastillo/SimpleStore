import React, { Component } from 'react';

export class AddBook extends Component {
    static displayName = AddBook.name;

    render() {
        return (
            <div>
                <form class="form-horizontal">
                    <legend font-weight-bold>Agregar libro</legend>
                    <hr class="sidebar-divider" />
                    <div class="form-group">
                        <label for="nombre">Nombre: </label>
                        <input required type="text" placeholder="Inserte el nombre del libro" class="form-control" name="nombre" id="nombre" />
                    </div>
                    <div class="form-group">
                        <label for="author">Nombre de los autores: </label>
                        <textarea required type="text" placeholder="Inserte el nombre de los autores" class="form-control" name="author" id="author" />
                    </div>
                    <div class="form-group">
                        <label for="isbn">ISBN: </label>
                        <input required type="text" placeholder="Inserte el ISBN del libro" class="form-control" name="isbn" id="isbn" />
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
                            <label for="pages">Páginas: </label>
                            <input required type="number" min="0" placeholder="Cantidad páginas" class="form-control" name="pages" id="pages" />
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
                            <option value='1'>pub</option>
                            <option value='2'>awz</option>
                            <option value='2'>pdf</option>
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
