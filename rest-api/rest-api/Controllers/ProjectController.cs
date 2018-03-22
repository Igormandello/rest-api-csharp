using Newtonsoft.Json;
using rest_api.DB;
using rest_api.DB.DAOs;
using rest_api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Web.Http;
using System.Web.Http.Cors;

namespace rest_api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/project")]
    public class ProjectController : ApiController
    {
        private ProjectDAO dao = new ProjectDAO();

        [AcceptVerbs("GET")]
        [Route("")]
        public List<Project> SelectAll()
        {
            try
            {
                return dao.GetAll();
            }
            catch
            {
                return null;
            }
        }

        [AcceptVerbs("GET")]
        [Route("{key}")]
        public Project Select(object key)
        {
            
            if (key.GetType().Equals(Type.GetType("int")))
            {
                int id = (int)key;

                try
                {
                    return dao.GetByID(id);
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                string name = (string)key;

                try
                {
                    return dao.GetByName(name);
                }
                catch
                {
                    return null;
                }
            }
                

        }

        [AcceptVerbs("POST")]
        [Route("create")]
        public String Create(Project project)
        {
            try
            {
                dao.Insert(project);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "";
        }

        [AcceptVerbs("DELETE")]
        [Route("{id}/delete")]
        public String Delete(int id)
        {
            try
            {
                dao.Delete(id);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "";
        }

        [AcceptVerbs("PUT")]
        [Route("{id}/update")]
        public String Update(Project project)
        {
            try
            {
                dao.Update(project);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "";
        }
    }
}
