using Newtonsoft.Json;
using rest_api.DB;
using rest_api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Web.Http;

namespace rest_api.Controllers
{
    [RoutePrefix("api/project")]
    public class ProjectController : ApiController
    {
        [AcceptVerbs("POST")]
        [Route("create")]
        public String Create(Project project)
        {
            return "";
        }

        [AcceptVerbs("PUT")]
        [Route("{id}/update")]
        public String Update(Project project)
        {
            return "";
        }

        [AcceptVerbs("DELETE")]
        [Route("{id}/delete")]
        public String Delete(int id)
        {
            return "";
        }

        [AcceptVerbs("GET")]
        [Route("{id}")]
        public String Select(int id)
        {
            return "{}";
        }

        [AcceptVerbs("GET")]
        [Route("")]
        public String SelectAll()
        {
            return "{}";
        }
    }
}
