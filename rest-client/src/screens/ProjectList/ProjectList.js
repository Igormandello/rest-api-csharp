import React, { Component } from 'react';
import $ from 'jquery';

import './ProjectList.css';

class ProjectList extends Component
{
  componentDidMount()
  {
    this.requestProjects()
  }
  
  state =
  {
    projects: [],
    loaded: false
  }
  
  requestProjects()
  {
    let settings =
    {
      url: "http://localhost:59674/api/project/",
      method: 'get'
    }
    
    //let query = $("input")[0];
    //if (query != "")
    //  settings.url += query
      
    $.ajax(settings).then(res =>
    {
      this.setState({ projects: res, loaded: true })
    })
  }
  
  printProjects()
  {
    let projDivs = []
    if (this.state.projects != null)
      this.state.projects.forEach(proj => 
      {
        projDivs.push(this.createProjectBox(proj));
      });
    
    return projDivs;
  }

  createProjectBox(project)
  {
    console.log(project)
    return (
      <div className="projectBox">
        <h2> { project.Name } - { project.Year } </h2>
        
        { project.Description }
        
        <hr/>
        
        <div>
          <a href={"./" + project.Id }><button type="button" className="btn btn-primary">Veja mais</button></a>
        </div>
      </div>
    )
  }
  
  render()
  {
    return (
      <div>
        <input type="text" className="form-control" placeholder="Pesquisar nome ou código"/>
        { !this.state.loaded && <div className="loader"></div> }
        { this.state.loaded && this.printProjects() }
      </div>
    )
  }
}

export default ProjectList;
