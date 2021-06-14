import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import NewLocal from './components/Locals/New';
import EditLocal from './components/Locals/Edit';
import Locals from './components/Locals/Locals';
import Menu from './components/Locals/Menu';
import NewMenuItem from "./components/Locals/NewMenuItem";
import EditMenuItem from "./components/Locals/EditMenuItem";
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
          <Route exact path='/' component={Home} />
          <AuthorizeRoute path='/orders' exact component={Locals} />
          <AuthorizeRoute exact path='/orders/:id/edit' component={EditLocal} />
          <AuthorizeRoute exact path='/orders/new' component={NewLocal} />
          <AuthorizeRoute path='/locals' exact component={Locals} />
          <AuthorizeRoute exact path='/locals/:id/edit' component={EditLocal} />
          <AuthorizeRoute exact path='/locals/:id/menu' component={Menu} />
          <AuthorizeRoute exact path='/locals/:id/menu/items/new' component={NewMenuItem} />
          <AuthorizeRoute exact path='/locals/:id/menu/items/:itemId/edit' component={EditMenuItem} />
          <AuthorizeRoute exact path='/locals/new' component={NewLocal} />
          <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
      </Layout>
    );
  }
}
