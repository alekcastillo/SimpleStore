import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { LoginForm } from './components/formularios/LoginForm';
import { AddFilm } from './components/formularios/AddFilm';
import { AddBook } from './components/formularios/AddBook';
import { AddMusic } from './components/formularios/AddMusic';
import { AddRole } from './components/formularios/AddRole';
import { AddUserForm } from './components/formularios/AddUserForm';
import { ViewIventory } from './components/formularios/ViewInventory';
import { Cart } from './components/formularios/Cart';
import { Payment } from './components/formularios/Payment';
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/login' component={LoginForm} />
        <Route path='/counter' component={Counter} />
        <Route path='/add-movie' component={AddFilm} />
        <Route path='/add-book' component={AddBook}/>
        <Route path='/add-music' component={AddMusic}/>
        <Route path='/add-role' component={AddRole} />
        <Route path='/add-user' component={AddUserForm} />
        <Route path='/inventory' component={ViewIventory}/>
        <Route path='/cart' component={Cart}/>
        <Route path='/payment' component={Payment} />
        <Route path='/fetch' component={FetchData} />
      </Layout>
    );
  }
}
