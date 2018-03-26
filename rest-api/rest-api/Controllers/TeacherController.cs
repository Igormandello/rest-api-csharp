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
        public readonly static TeacherDAO dao = new TeacherDAO();

        [AcceptVerbs("GET")]
        [Route("")]
        public List<Teacher> SelectAll()
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
        [Route("{id}")]
        public Teacher Select(int id)
        {
            try
            {
                return dao.GetByID(id);
            }
            catch
            {
                return null;
            }
        }
    }
}