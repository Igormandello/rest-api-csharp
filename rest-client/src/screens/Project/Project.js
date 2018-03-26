import React, { Component } from 'react';
import Modal from 'react-responsive-modal';
import Alert from 'react-s-alert';
import $ from 'jquery';

import 'react-s-alert/dist/s-alert-default.css';
import 'react-s-alert/dist/s-alert-css-effects/scale.css';
import './Project.css';

const contentStyle = {
  modal: {
    color: "white",
    backgroundColor: "#3c6382",
    textAlign: "center",
    padding: "25px 0 25px 0"
  },
  
  closeIcon: {
    fill: "white",
    marginTop: "15px"
  }
}

class Project extends Component
{
  componentDidMount()
  {
    this.save = this.save.bind(this)
    this.deleteProject = this.deleteProject.bind(this)
    
    let settings =
    {
      async: true,
      crossDomain: true,
      url: "http://localhost:59674/api/project/" + this.props.match.params.id,
      method: 'GET'
    }
    
    let attr = {};
    $.ajax(settings).then(res =>
    {
      attr.actualProject = res
      
      let baseUrl = settings.url
      settings.url = baseUrl + "/students"
      $.ajax(settings).then(res =>
      {
        attr.actualProject.students = res
        
        settings.url = baseUrl + "/teachers"
        $.ajax(settings).then(res =>
        {
          attr.actualProject.teachers = res
          
          settings.url = "http://localhost:59674/api/teacher/"
          $.ajax(settings).then(res =>
          {
            attr.teachers = res
            settings.url = "http://localhost:59674/api/student/"

            $.ajax(settings).then(res => this.setState({ actualProject: attr.actualProject, teachers: attr.teachers, students: res, loaded: true }))
          })
        })
      })
    })
  }
  
  state =
  {
    modalOpen: false,
    loaded: false,
    actualProject: {},
    students: [],
    teachers: [],
  }
  
  openModal = () => this.setState({ modalOpen: true })

  closeModal = () => this.setState({ modalOpen: false })
  
  save()
  {
    let name = document.getElementById("projTitle").value
    let settings =
    {
      async: true,
      crossDomain: true,
      url: "http://localhost:59674/api/project/" + this.state.actualProject.Id,
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
        "Cache-Control": "no-cache",
      },
      data: "{ Name: \"" + name + "\", Description: \"" + this.state.actualProject.Description + "\", Year: " + this.state.actualProject.Year + " }"
    }

    $.ajax(settings).done(() => 
      Alert.success(<h1>Alterações salvas com sucesso!</h1>, {
        position: 'bottom-right',
        effect: 'scale',
        timeout: 3000
      })).catch((err) => 
        Alert.error(<h1>{ err.message }</h1>, {
          position: 'bottom-right',
          effect: 'scale',
          timeout: 3000
        }));
  }

  deleteProject()
  {
    let settings =
    {
      async: true,
      crossDomain: true,
      url: "http://localhost:59674/api/project/" + this.state.actualProject.Id,
      method: "DELETE",
    }

    $.ajax(settings).then(() => window.location = "./")
  }
  
  teacherOptions()
  {
    let options = []
    this.state.teachers.forEach(obj => options.push(<option>{ obj.Name }</option>))
    
    return options
  }

  studentOptions()
  {
    let options = []
    this.state.students.forEach(obj => options.push(<option>{ obj.Name }</option>))
      
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
              <input id="projTitle" type="text" className="form-control" defaultValue={ this.state.actualProject.Name } onChange={() => {}}/>
            </div>

            <div className="project-year">
              { this.state.actualProject.Year }
            </div>

            <div className="project-members">
              <label>Professor Orientador:</label>
              <select defaultValue={ (this.state.actualProject.teachers.length > 0 ? this.state.actualProject.teachers[0].Name : "") } className="form-control">
                { this.teacherOptions() }
              </select>
              
              <br/>
              
              <label>Professor Co-Orientador:</label>
              <select id="teacher2" defaultValue={ (this.state.actualProject.teachers.length > 1 ? this.state.actualProject.teachers[1].Name : "") } className="form-control">
                <option>Nenhum</option>
                { this.teacherOptions() }
              </select>

              <br/><br/>

              <label>Aluno 1:</label>
              <select defaultValue={ (this.state.actualProject.students.length > 0 ? this.state.actualProject.students[0].Name : "") } className="form-control">
                { this.studentOptions() }
              </select>

              <br/>

              <label>Aluno 2:</label>
              <select defaultValue={ (this.state.actualProject.students.length > 1 ? this.state.actualProject.students[1].Name : "") } className="form-control">
                <option>Nenhum</option>
                { this.studentOptions() }
              </select>

              <br/>

              <label>Aluno 3:</label>
              <select defaultValue={ (this.state.actualProject.students.length > 2 ? this.state.actualProject.students[2].Name : "") } className="form-control">
                <option>Nenhum</option>
                { this.studentOptions() }
              </select>
            </div>

            <br/><br/>

            <div className="project-options">
              <button type="button" className="btn btn-primary" onClick={ this.save }>
                  Salvar Alterações
              </button>
              <button type="button" className="btn btn-danger" onClick={ this.openModal }> Excluir </button>
            </div>
            
            <Modal open={ this.state.modalOpen } onClose={ this.closeModal } styles={ contentStyle } little>
              <div className="modal">
                <h2>Você deseja realmente excluir este projeto?</h2>
                <br/>
                <button type="button" className="btn btn-danger" onClick={ this.deleteProject }> Sim </button>
                <button type="button" className="btn btn-success" onClick={ this.closeModal }> Não </button>
              </div>
            </Modal>
          </div>
        }
        
        <Alert stack={{ limit: 3 }}/>
      </div>
    )
  }
}

export default Project;
