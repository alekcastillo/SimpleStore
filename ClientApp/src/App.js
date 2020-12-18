import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';

import { BookList } from './components/views/BookList';
import { MovieList } from './components/views/MovieList';
import { SongList } from './components/views/SongList';
import { UserList } from './components/views/UserList';

import { BookSubjectList } from './components/views/BookSubjectList';
import { MovieActorList } from './components/views/MovieActorList';
import { MovieGenreList } from './components/views/MovieGenreList';
import { SongGenreList } from './components/views/SongGenreList';
import { UserRoleList } from './components/views/UserRoleList';

import { TableConsecutiveList } from './components/views/TableConsecutiveList';
import { SystemConfigurationList } from './components/views/SystemConfigurationList';
import { ChangeLogList } from './components/views/ChangeLogList';

import { LoginForm } from './components/forms/LoginForm';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/Login' component={LoginForm} />

                <Route path='/ProductBooks' component={BookList} />
                <Route path='/ProductMovies' component={MovieList} />
                <Route path='/ProductSongs' component={SongList} />
                <Route path='/Users' component={UserList} />

                <Route path='/ProductBookSubjects' component={BookSubjectList} />
                <Route path='/ProductMovieActors' component={MovieActorList} />
                <Route path='/ProductMovieGenres' component={MovieGenreList} />
                <Route path='/ProductSongGenres' component={SongGenreList} />
                <Route path='/UserRoles' component={UserRoleList} />

                <Route path='/TableConsecutives' component={TableConsecutiveList} />
                <Route path='/SystemConfigurations' component={SystemConfigurationList} />
                <Route path='/ChangeLogs' component={ChangeLogList} />
            </Layout>
        );
    }
}
