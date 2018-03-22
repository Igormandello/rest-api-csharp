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
    let settings =
    {
      url: "http://localhost:59674/api/project/" + this.props.match.params.id,
      method: 'get'
    }
    
    $.ajax(settings).then(res =>
    {
      this.setState({ actualProject: res, loaded: true })
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
    //Saves the actual data of project//
    ////////////////////////////////////
    ////////////////////////////////////
    
    Alert.success(<h1>Alterações salvas com sucesso!</h1>, {
      position: 'bottom-right',
      effect: 'scale',
      timeout: 3000
    })
  }

  deleteProject()
  {
    //Deletes the actual project//
    //////////////////////////////
    //////////////////////////////
    
    window.location = "./";
  }
  
  render()
  {
    console.log(this.state.actualProject)
    return (
      <div>
        { !this.state.loaded && <div className="loader"></div> }
        
        {
          this.state.loaded &&
          <div>
            <div className="project-title">
              <input type="text" className="form-control" value={ this.state.actualProject.Name } onChange={() => {}}/>
            </div>

            <div className="project-year">
              { this.state.actualProject.Year }
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
              <button type="button" class="btn btn-danger" onClick={ this.openModal }> Excluir </button>
            </div>
            
            <Modal open={ this.state.modalOpen } onClose={ this.closeModal } styles={ contentStyle } little>
              <div className="modal">
                <h2>Você deseja realmente excluir este projeto?</h2>
                <br/>
                <button type="button" class="btn btn-danger" onClick={ this.deleteProject }> Sim </button>
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
