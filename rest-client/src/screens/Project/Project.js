import React, { Component } from 'react';
import Alert from 'react-s-alert';

import 'react-s-alert/dist/s-alert-default.css';
import 'react-s-alert/dist/s-alert-css-effects/scale.css';
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
  
  save()
  {
    Alert.success(<h1>Alterações salvas com sucesso!</h1>, {
      position: 'bottom-right',
      effect: 'scale',
      timeout: 3000
    })
  }
  
  render()
  {
    return (
      <div>
        <div className="project-title">
          <input type="text" className="form-control" defaultValue="Project Title"/>
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
          <button type="button" className="btn btn-primary" onClick={ this.save }>
              Salvar Alterações
          </button>
          <button type="button" className="btn btn-danger"> Excluir </button>
        </div>
        
        <Alert stack={{ limit: 3 }}/>
      </div>
    )
  }
}

export default Project;
