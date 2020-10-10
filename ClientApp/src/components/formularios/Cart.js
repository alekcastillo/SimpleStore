import React, { Component } from 'react';

import { Button } from 'reactstrap';
import { Link } from 'react-router-dom';


export class Cart extends Component {
    static displayName = Cart.name;

    render() {
        return (
            <div class="mt-5">
                <table class="table table table-hover table-sm">
                    <thead class="thead-light">
                        <tr>
                            <th scope="col">Producto</th>
                            <th scope="col">Nombre</th>
                            <th scope="col">Precio</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td><img src="https://indiehoy.com/wp-content/uploads/2019/07/acdc-highway-to-hell.jpg" width="50px" height="50px" /></td>
                            <td>Highway to Hell</td>
                            <td>15</td>
                        </tr>
                        <tr>
                            <td><img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRPaLAGntXjiPac0t-epkSRk3OPeCo8V-iBYxSkJXLCFFYMqvkd" width="50px" height="50px" /></td>
                            <td>The Shawshank Redemption</td>
                            <td>20</td>
                        </tr>
                    </tbody>
                </table>
                <div class="float-right" width="25%">
                    <table class="table table-sm">
                        <tbody>
                            <tr>
                                <td>Impuestos</td>
                                <td>$3.00</td>
                            </tr>
                            <tr>
                                <td>Total</td>
                                <td>$38.00</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <hr class="sidebar-divider mb-5" />
                <div class="float-left">
                    <Button id="edit" name="edit" className="btn btn-success" tag={Link} to="/payment">Pagar</Button>
                </div>
                <div class="float-left"> <button id="remove" name="remove" class="btn btn-link">Remover</button></div>
            </div>
        );
    }
}
