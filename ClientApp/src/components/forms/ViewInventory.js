import React, { Component } from 'react';

export class ViewIventory extends Component {
    static displayName = ViewIventory.name;

    render() {
        return (
            <div class="mt-5">
                <table class="table table table-hover table-sm">
                    <thead class="thead-light">
                        <tr>
                            <th scope="col">Consecutivo</th>
                            <th scope="col">Tipo</th>
                            <th scope="col">Nombre</th>
                            <th scope="col">Interprete</th>
                            <th scope="col">Precio USD</th>
                            <th scope="col">Cantidad en inventario</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th scope="row">1</th>
                            <td>Película</td>
                            <td>The Shawshank Redemption</td>
                            <td>Tim Robbins; Morgan Freeman</td>
                            <td>20</td>
                            <td>70</td>
                        </tr>
                        <tr>
                            <th scope="row">2</th>
                            <td>Música</td>
                            <td>Highway to Hell</td>
                            <td>AC/DC</td>
                            <td>10</td>
                            <td>70</td>
                        </tr>
                        <tr>
                            <th scope="row">3</th>
                            <td>Libro</td>
                            <td>The Unberable Lightness of Being</td>
                            <td>Milan Kundera</td>
                            <td>15</td>
                            <td>70</td>
                        </tr>
                    </tbody>
                </table>
                <div>
                    <h4>Botones que se mostraran al hacer click</h4>
                    <button id="edit" name="edit" class="btn btn-primary">Editar</button>
                    <button id="remove" name="remove" class="btn btn-danger">Eliminar</button>
                </div>
            </div>
        );
    }
}
