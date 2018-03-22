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
    [RoutePrefix("api/teacher")]
    public class TeacherController : ApiController
    {
        private TeacherDAO dao = new TeacherDAO();

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
    }
}