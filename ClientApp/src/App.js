import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { LoginForm } from './components/forms/LoginForm';
import { AddFilm } from './components/forms/AddFilm';
import { BooksLists } from './components/views/BooksLists';
import { SongsLists } from './components/views/SongsLists';
import { AddRole } from './components/forms/AddRole';
import { AddUserForm } from './components/forms/AddUserForm';
import { ViewIventory } from './components/forms/ViewInventory';
import { UsersList } from './components/views/UsersList';
import { BookSubjectList } from './components/views/BookSubjectList';
import { MovieActorList } from './components/views/MovieActorList';
import { MovieGenreList } from './components/views/MovieGenreList';
import { SongGenreList } from './components/views/SongGenreList';
import { UserRoleList } from './components/views/UserRoleList';
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
        <Route path='/add-book' component={BooksLists}/>
            <Route path='/add-music' component={SongsLists}/>
        <Route path='/add-role' component={AddRole} />
        <Route path='/add-user' component={AddUserForm} />
        <Route path='/inventory' component={ViewIventory}/>
        <Route path='/cart' component={Cart}/>
        <Route path='/payment' component={Payment} />
        <Route path='/fetch' component={FetchData} />
        <Route path='/users' component={UsersList} />
        <Route path='/ProductBookSubjects' component={BookSubjectList} />
        <Route path='/ProductMovieActors' component={MovieActorList} />
        <Route path='/ProductMovieGenres' component={MovieGenreList} />
        <Route path='/ProductSongGenres' component={SongGenreList} />
        <Route path='/UserRoles' component={UserRoleList} />
      </Layout>
    );
  }
}
