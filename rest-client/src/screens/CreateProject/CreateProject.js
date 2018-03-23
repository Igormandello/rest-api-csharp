import React, { Component } from 'react';
import Alert from 'react-s-alert';
import $ from 'jquery';

import './CreateProject.css';

class Project extends Component
{
  componentDidMount()
  {
    this.create = this.create.bind(this)
    
    let settings =
    {
      async: true,
      crossDomain: true,
      url: "http://localhost:59674/api/teacher/",
      method: 'GET'
    }
    
    $.ajax(settings).then(res =>
    {
      settings.url = "http://localhost:59674/api/student/"

      $.ajax(settings).then(res2 => this.setState({ teachers: res, students: res2, loaded: true }))
    })
  }
  
  state =
  {
    loaded: false,
    students: [],
    teachers: [],
  }
  
  openModal = () => this.setState({ modalOpen: true })

  closeModal = () => this.setState({ modalOpen: false })
  
  create()
  {
    let name = document.getElementById("projTitle").value,
        year = document.getElementById("projYear").value,
        desc = document.getElementById("projDesc").value,
    
        teacher1 = this.state.teachers[document.getElementById("teacher1").selectedIndex],
        teacher2 = document.getElementById("teacher2").selectedIndex - 1,
        
        student1 = this.state.students[document.getElementById("student1").selectedIndex],
        student2 = document.getElementById("student2").selectedIndex - 1,
        student3 = document.getElementById("student3").selectedIndex - 1
    
    if (teacher2 > 0)
      teacher2 = this.state.teachers[teacher2]
      
    if (student2 > 0)
      student2 = this.state.students[student2]
      
    if (student3 > 0)
      student3 = this.state.students[student3]
      
    if (!Number.isInteger(parseInt(year)))
      this.createErrorMessage("O ano deve ser um número!")
        
    let settings =
    {
      async: true,
      crossDomain: true,
      url: "http://localhost:59674/api/project/",
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        "Cache-Control": "no-cache",
      },
      data: "{ Name: \"" + name + "\", Description: \"" + desc + "\", Year: " + year + " }"
    }
    
    $.ajax(settings).done(res =>
    {
      let id = res
      console.log(id)
    })
  }

  createErrorMessage(str)
  {
    Alert.error(<h1>{ str }</h1>, {
      position: 'bottom-right',
      effect: 'scale',
      timeout: 3000
    })
  }
  
  teacherOptions()
  {
    let options = []
    this.state.teachers.forEach(obj =>
    {
      options.push(<option>{ obj.Name }</option>)
    })
    
    return options
  }

  studentOptions()
  {
    let options = []
    this.state.students.forEach(obj =>
    {
      options.push(<option>{ obj.Name }</option>)
    })
    
    return options
  }

  render()
  {
    return (
      <div>
        { !this.state.loaded && <div className="loader"></div> }
        
        {
          this.state.loaded &&
          <div>
            <div className="project-title">
              <input id="projTitle" type="text" className="form-control" placeholder="Título"/>
            </div>

            <div className="project-year">
              <input id="projYear" type="text" className="form-control" placeholder="Ano"/>
            </div>
            
            <div className="project-desc">
              <textarea id="projDesc" className="form-control" placeholder="Descrição"/>
            </div>
           
            <div className="project-members">
              <label>Professor Orientador:</label>
              <select id="teacher1" className="form-control">
                { this.teacherOptions() }
              </select>

              <br/>
              
              <label>Professor Co-Orientador:</label>
              <select id="teacher2" className="form-control">
                <option>Nenhum</option>
                { this.teacherOptions() }
              </select>
              
              <br/><br/>

              <label>Aluno 1:</label>
              <select id="student1" className="form-control">
                { this.studentOptions() }
              </select>

              <br/>

              <label>Aluno 2:</label>
              <select id="student2" className="form-control">
                <option>Nenhum</option>
                { this.studentOptions() }
              </select>

              <br/>

              <label>Aluno 3:</label>
              <select id="student3" className="form-control">
                <option>Nenhum</option>
                { this.studentOptions() }
              </select>
            </div>

            <br/><br/>

            <div className="project-options">
              <button type="button" className="btn btn-success" onClick={ this.create }>
                  Criar Projeto
              </button>
            </div>
          </div>
        }
        
        <Alert stack={{ limit: 3 }}/>
      </div>
    )
  }
}

export default Project;
