import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, Media, NavbarToggler, NavItem, NavLink, Dropdown, DropdownItem, DropdownToggle, DropdownMenu, Nav, UncontrolledDropdown } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';


export class NavMenu extends Component {



  static displayName = NavMenu.name;

  constructor(props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };

  }

  

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }



  render() {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3 navbar-dark bg-dark" light>
          <Container>
          <a href="#"> <img src="http://www.noticiasdot.com/wp2/wp-content/uploads/2011/10/db.png" width="50" height="50"/></a>
            <NavbarBrand tag={Link} to="/">Kame House</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} className="text-light" to="/">Home</NavLink>
                </NavItem>
            
                <NavItem>
                  <NavLink tag={Link} className="text-light" to="/add-movie">Agregar pelicula</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-light" to="/add-book">Agregar libro</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-light" to="/add-music">Agregar música</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-light" to="/add-role">Agregar rol de empleado</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-light" to="/inventory">Inventario</NavLink>
                </NavItem>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
