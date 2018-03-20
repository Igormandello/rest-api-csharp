import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import './bootstrap.css';
import './index.css';

import Project from './screens/Project/Project';
import ProjectList from './screens/ProjectList/ProjectList';
import registerServiceWorker from './registerServiceWorker';

class Main extends Component
{
  render()
  {
    return (
      <div className="app">
        <header>
         <h1>
           <a href="./">
             Projetos
           </a>
         </h1>
        </header>

        <div className="content">
          <Router>
            <Switch>
              <Route exact path="/" component={ ProjectList } />
              <Route path="/:page" component={ Project } />
            </Switch>
          </Router>
        </div>
      </div>
    )
  }
}

ReactDOM.render(<Main/>, document.getElementById('root'));
registerServiceWorker();
