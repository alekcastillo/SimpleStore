import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { AddFilm } from './components/formularios/AddFilm';
import { AddBook } from './components/formularios/AddBook';
import { AddMusic } from './components/formularios/AddMusic';
import { AddRole } from './components/formularios/AddRole';
import { ViewIventory } from './components/formularios/ViewInventory';
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/add-movie' component={AddFilm} />
        <Route path='/add-book' component={AddBook}/>
        <Route path='/add-music' component={AddMusic}/>
        <Route path='/add-role' component={AddRole}/>
        <Route path='/inventory' component={ViewIventory}/>
      </Layout>
    );
  }
}
