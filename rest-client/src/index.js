import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import './bootstrap.min.css';
import './index.css';

import Project from './screens/Project/Project';
import CreateProject from './screens/CreateProject/CreateProject';
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
              <Route path="/create" component={ CreateProject } />
              <Route path="/:id" component={ Project } />
            </Switch>
          </Router>
        </div>
      </div>
    )
  }
}

ReactDOM.render(<Main/>, document.getElementById('root'));
registerServiceWorker();
