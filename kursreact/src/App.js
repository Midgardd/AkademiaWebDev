import React, { Component } from 'react';
import Loadable from 'react-loadable';
import './App.css';
import '../node_modules/material-icons/iconfont/material-icons.css';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';

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
        <Router>
            <Switch>
                <Route exact path="/" component={LoadableLink} />
                <Route path="/edit/:hash" component={EditFormPage} />
                <Route path="/add" component={EditFormPage} />
            </Switch>
        </Router>
    );
    }
}

export default App;