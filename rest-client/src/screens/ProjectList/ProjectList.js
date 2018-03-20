import React, { Component } from 'react';
import './ProjectList.css';

class ProjectList extends Component
{
  componentDidMount()
  {
    this.requestProjects()
  }
  
  state =
  {
    projects: []
  }
  
  requestProjects()
  {
    let projs = []
    
    projs.push(this.createProjectBox())
    this.setState({ projects: projs })
  }
  
  createProjectBox(project)
  {
    return (
      <div className="projectBox">
        <h2> Project title - 2018 </h2>
        
        Project description
        
        <hr/>
        
        <div>
          <button type="button" className="btn btn-primary"> Veja mais </button>
        </div>
      </div>
    )
  }
  
  render()
  {
    return (
      <div>
        <input type="text" class="form-control" placeholder="Pesquisar nome ou codigo"/>
        {
          this.state.projects
        }
      </div>
    )
  }
}

export default ProjectList;
