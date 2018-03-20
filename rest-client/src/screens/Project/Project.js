import React, { Component } from 'react';
import './Project.css';

class Project extends Component
{
  componentDidMount()
  {
    
  }
  
  state =
  {
    actualProject: {},
    students: [],
    teachers: [],
  }
  
  render()
  {
    return (
      <div>
        <div className="project-title">
          Project Title
        </div>
        
        <div className="project-year">
          2018
        </div>
        
        <div className="project-members">
          <label>Professor Orientador:</label>
          <select className="form-control">
            <option>Professor</option>
          </select>
          
          <br/><br/>
          
          <label>Aluno 1:</label>
          <select className="form-control">
            <option>Student 1</option>
          </select>
          
          <br/>
          
          <label>Aluno 2:</label>
          <select className="form-control">
            <option>Student 2</option>
          </select>
          
          <br/>
          
          <label>Aluno 3:</label>
          <select className="form-control">
            <option>Student 3</option>
          </select>
        </div>
        
        <br/><br/>
        
        <div className="project-options">
          <button type="button" className="btn btn-primary"> Salvar Alterações </button>
          <button type="button" className="btn btn-danger"> Excluir </button>
        </div>
      </div>
    )
  }
}

export default Project;
