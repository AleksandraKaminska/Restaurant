import React, { useState } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { LoginMenu } from './api-authorization/LoginMenu';
import './NavMenu.css';

const NavMenu: React.FC<{}> = () => {
    const [collapsed, setCollapsed] = useState<boolean>(true);

    const toggleNavbar = () => setCollapsed(!collapsed)

    return (
        <header>
            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom mb-3" light>
                <Container>
                    <NavbarBrand tag={Link} to="/"><b>Restaurant</b> POS</NavbarBrand>
                    <NavbarToggler onClick={toggleNavbar} className="mr-2" />
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsed} navbar>
                        <ul className="navbar-nav flex-grow">
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/orders">Orders</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/locals">Locals</NavLink>
                            </NavItem>
                            <LoginMenu/>
                        </ul>
                    </Collapse>
                </Container>
            </Navbar>
        </header>
    )
}

export default NavMenu
