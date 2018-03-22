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
        public Project Select(string key)
        {
            if (Int32.TryParse(key, out int id))
                try
                {
                    return dao.GetByID(id);
                }
                catch
                {
                    return null;
                }
            else
                try
                {
                    return dao.GetByName(key);
                }
                catch
                {
                    return null;
                }
        }

        [AcceptVerbs("POST")]
        [Route("")]
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
        [Route("{id}")]
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
        [Route("{id}")]
        public String Update(int id, Project project)
        {
            try
            {
                project.Id = id;
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
