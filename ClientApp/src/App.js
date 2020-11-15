import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { LoginForm } from './components/forms/LoginForm';
import { AddFilm } from './components/forms/AddFilm';
import { AddBook } from './components/forms/AddBook';
import { AddMusic } from './components/forms/AddMusic';
import { AddRole } from './components/forms/AddRole';
import { AddUserForm } from './components/forms/AddUserForm';
import { ViewIventory } from './components/forms/ViewInventory';
import { UsersList } from './components/views/UsersList';
import { Cart } from './components/forms/Cart';
import { Payment } from './components/forms/Payment';
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
        <Route path='/users' component={UsersList} />
      </Layout>
    );
  }
}
