import React, { useEffect} from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import NewLocal from './pages/Locals/New';
import EditLocal from './pages/Locals/Edit';
import Locals from './pages/Locals/Locals';
import NewOrder from './pages/Orders/New';
import ShowOrder from './pages/Orders/Show';
import EditOrder from './pages/Orders/Edit';
import Payment from './pages/Orders/Payment';
import Orders from './pages/Orders/Orders';
import NewTable from './pages/Tables/New';
import EditTable from './pages/Tables/Edit';
import Tables from './pages/Tables/Tables';
import Menu from './pages/Menu/Menu';
import NewMenuItem from "./pages/Menu/NewMenuItem";
import EditMenuItem from "./pages/Menu/EditMenuItem";
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import store, { persistor } from './redux/store'
import { Provider } from 'react-redux'
import { PersistGate } from 'redux-persist/integration/react'
import './custom.css'

const App = () => {
    useEffect(() => {
        console.log(store)
    }, [])

    return (
        <Provider store={store}>
            <PersistGate loading={null} persistor={persistor}>
                <Layout>
                    <Route exact path='/' component={Home} />
                    <AuthorizeRoute path='/orders' exact component={Orders} />
                    <AuthorizeRoute exact path='/order/new' component={NewOrder} />
                    <AuthorizeRoute exact path='/orders/:id' component={ShowOrder} />
                    <AuthorizeRoute exact path='/orders/:id/edit' component={EditOrder} />
                    <AuthorizeRoute exact path='/orders/:id/edit/payment' component={Payment} />
                    <AuthorizeRoute path='/tables' exact component={Tables} />
                    <AuthorizeRoute exact path='/tables/:id/edit' component={EditTable} />
                    <AuthorizeRoute exact path='/tables/new' component={NewTable} />
                    <AuthorizeRoute path='/locals' exact component={Locals} />
                    <AuthorizeRoute exact path='/locals/:id/edit' component={EditLocal} />
                    <AuthorizeRoute exact path='/locals/:id/menu' component={Menu} />
                    <AuthorizeRoute exact path='/locals/:id/menu/items/new' component={NewMenuItem} />
                    <AuthorizeRoute exact path='/locals/:id/menu/items/:itemId/edit' component={EditMenuItem} />
                    <AuthorizeRoute exact path='/locals/new' component={NewLocal} />
                    <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
                </Layout>
            </PersistGate>
        </Provider>
    );
}

export default App
