import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (

      <div>
        <h3>Bienvenido a Kame House</h3>
        <div class="my-5">
          <div>        
            <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRPaLAGntXjiPac0t-epkSRk3OPeCo8V-iBYxSkJXLCFFYMqvkd" width="100px" height="100px" />
            <a href="/">The Shashank Redemption</a></div>
          <div><a href="/">Agregar al carrito</a></div>

        </div>
        <div class="my-5">
          <div>        
            <img src="https://indiehoy.com/wp-content/uploads/2019/07/acdc-highway-to-hell.jpg" width="100px" height="100px" />
            <a href="/">Highway to Hell</a></div>
          <div><a href="/">Agregar al carrito</a></div>

        </div>
      </div>

    );
  }
}
