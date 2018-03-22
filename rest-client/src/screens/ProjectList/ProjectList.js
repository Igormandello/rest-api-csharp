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
      method: 'GET'
    }
    
    let query = document.getElementById("query").value;
    if (query !== "" && query !== undefined)
      settings.url += query
      
    $.ajax(settings).then(res =>
    {
      this.setState({ projects: res, loaded: true })
    })
  }
  
  printProjects()
  {
    let projDivs = []
    if (this.state.projects != null)
      if (Array.isArray(this.state.projects))
        this.state.projects.forEach(proj => 
        {
          projDivs.push(this.createProjectBox(proj));
        });
      else
        projDivs.push(this.createProjectBox(this.state.projects));
    
    return projDivs;
  }

  createProjectBox(project)
  { 
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
        <input id="query" type="text" className="form-control" onChange={() => this.requestProjects()} placeholder="Pesquisar nome ou código"/>
        { !this.state.loaded && <div className="loader"></div> }
        { this.state.loaded && this.printProjects() }
      </div>
    )
  }
}

export default ProjectList;
