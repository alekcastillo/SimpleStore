import React, { Component } from 'react';

export class Payment extends Component {
    static displayName = Payment.name;

    render() {
        return (
            <div>
                <form class="form-horizontal">
                    <legend font-weight-bold>Agregar tarjeta de crédito</legend>
                    <div class="float-right mx-auto my-3">
                        <button id="clear" name="clear" class="btn btn-link">Selecciona una tarjeta</button>
                    </div>
                    <hr class="sidebar-divider" />
                    <div class="form-group">
                        <label for="nombre">Nombre del titular: </label>
                        <input required type="text" placeholder="Nombre" class="form-control" name="nombre" id="nombre" />
                    </div>
                    <div class="form-group">
                        <label for="cardnumber">Número de la tarjeta: </label>
                        <input required type="password" placeholder="Inserte el número" class="form-control" name="cardnumber" id="cardnumber" />
                    </div>
                   
                    <div class="form-row">
                        <div class="col">
                            <label for="expdate">Fecha de expiración: </label>
                            <input required type="date" class="form-control" name="expdate" id="expdate" />
                        </div>
                        <div class="col">
                            <label for="cvv">CVV: </label>
                            <input required type="text" placeholder="CVV" class="form-control" name="cvv" id="cvv" />
                        </div>
                    </div>
                    
                    <div class="my-3">
                    <button id="save" name="save" class="btn btn-success">Pagar</button>
                        <button id="cancel" name="cancel" class="btn btn-link">Cancelar</button>
                    </div>
                </form>
            </div>
        );
    }
}
