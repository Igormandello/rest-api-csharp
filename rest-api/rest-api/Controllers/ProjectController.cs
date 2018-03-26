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
        public readonly static ProjectDAO dao = new ProjectDAO();

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
        [Route("{key}/Students")]
        public List<Student> SelectStudents(string key)
        {
            StudentDAO stDao = new StudentDAO();           //Student DAO
            List<Student> studs = null;
            if (Int32.TryParse(key, out int id))
                studs = stDao.GetByProjectID(id);
            else
                studs = stDao.GetByProjectID(dao.GetByName(key).Id);

            return studs;
        }

        [AcceptVerbs("GET")]
        [Route("{key}/Teachers")]
        public List<Teacher> SelectTeachers(string key)
        {
            TeacherDAO tcDao = new TeacherDAO();           //Teacher DAO
            List<Teacher> teachers = null;
            if (Int32.TryParse(key, out int id))
                teachers = tcDao.GetByProjectID(id);
            else
                teachers = tcDao.GetByProjectID(dao.GetByName(key).Id);

            return teachers;
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
                return dao.GetByName(project.Name).Id + "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [AcceptVerbs("DELETE")]
        [Route("{key}")]
        public String Delete(string key)
        {
            try
            {
                TeacherDAO tcDao = new TeacherDAO();

                if (Int32.TryParse(key, out int id))
                    tcDao.ExitProject(id);
                else
                    tcDao.ExitProject((dao.GetByName(key).Id));

                StudentDAO stDao = new StudentDAO();

                if (Int32.TryParse(key, out id))
                    stDao.ExitProject(id);
                else
                    stDao.ExitProject((dao.GetByName(key).Id));

                dao.Delete(id);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "";
        }

        [AcceptVerbs("PUT")]
        [Route("{key}")]
        public String Update(string key, Project project)
        {
            try
            {
                if (Int32.TryParse(key, out int id))
                    project.Id = id;
                else
                    project.Id = dao.GetByName(key).Id;

                dao.Update(project);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "";
        }

        [AcceptVerbs("PUT")]
        [Route("{key}/linkTeachers")]
        public void linkTeachers(string key, List<Teacher> teachers)
        {
            TeacherDAO tcDao = new TeacherDAO();

            if (Int32.TryParse(key, out int id))
                tcDao.ExitProject(id);
            else
                tcDao.ExitProject((dao.GetByName(key).Id));

            foreach (Teacher t in teachers)
            {
                if (Int32.TryParse(key, out id))
                    dao.linkTeacher(id, t.Id);
                else
                    dao.linkTeacher(dao.GetByName(key).Id, t.Id);
            }
        }

        [AcceptVerbs("PUT")]
        [Route("{key}/linkStudents")]
        public void linkStudents(string key, List<Student> students)
        {
            StudentDAO stDao = new StudentDAO();

            if (Int32.TryParse(key, out int id))
                stDao.ExitProject(id);
            else
                stDao.ExitProject((dao.GetByName(key).Id));

            foreach (Student t in students)
            {
                if (Int32.TryParse(key, out id))
                    dao.linkStudent(id, t.RA);
                else
                    dao.linkStudent(dao.GetByName(key).Id, t.RA);
            }
        }
    }
}
