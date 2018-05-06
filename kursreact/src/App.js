import React, { Component } from 'react';
import Loadable from 'react-loadable';
import './App.css';
import '../node_modules/material-icons/iconfont/material-icons.css';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { createStore } from 'redux'
import { Provider } from 'react-redux';
import reducers from './reducers';


const store = createStore(reducers);

const Loading = () => <div>Loading...</div>;

const LoadableLink = Loadable({
    loader: () => import('./components/Links'),
    loading: Loading
});

const EditFormPage = Loadable({
    loader: () => import('./containers/editForm'),
    loading: Loading
});

class App extends Component {

    render() {
        return (
            <Provider store={store}>
                <Router>
                    <Switch>
                        <Route exact path="/" component={LoadableLink} />
                        <Route path="/edit/:hash" component={EditFormPage} />
                        <Route path="/add" component={EditFormPage} />
                    </Switch>
                </Router>
            </Provider>
        );
    }
}

export default App;