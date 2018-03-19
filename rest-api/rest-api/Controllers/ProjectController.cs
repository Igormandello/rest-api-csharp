using Newtonsoft.Json;
using rest_api.DB;
using rest_api.DB.DAOs;
using rest_api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Web.Http;

namespace rest_api.Controllers
{
    [AllowCrossSite]
    [RoutePrefix("api/project")]
    public class ProjectController : ApiController
    {
        private ProjectDAO dao = new ProjectDAO();

        [AcceptVerbs("GET")]
        [Route("")]
        public String SelectAll()
        {
            StringWriter sw = new StringWriter();
            JsonSerializer serializer = new JsonSerializer();

            try
            {
                serializer.Serialize(sw, dao.GetAll());
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return sw.ToString();
        }

        [AcceptVerbs("GET")]
        [Route("{id}")]
        public String Select(int id)
        {
            StringWriter sw = new StringWriter();
            JsonSerializer serializer = new JsonSerializer();

            try
            {
                serializer.Serialize(sw, dao.GetByID(id));
            }
            catch (Exception e)
            {
                return e.Message;
            }

            String result = sw.ToString();
            if (result == "null")
                return "{}";

            return result;
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
