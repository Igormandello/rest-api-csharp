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
            List<Student> studs = null;
            if (Int32.TryParse(key, out int id))
                studs = StudentController.dao.GetByProjectID(id);
            else
                studs = StudentController.dao.GetByProjectID(dao.GetByName(key).Id);

            return studs;
        }

        [AcceptVerbs("GET")]
        [Route("{key}/Teachers")]
        public List<Teacher> SelectTeachers(string key)
        {
            List<Teacher> teachers = null;
            if (Int32.TryParse(key, out int id))
                teachers = TeacherController.dao.GetByProjectID(id);
            else
                teachers = TeacherController.dao.GetByProjectID(dao.GetByName(key).Id);

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
                throw e;
            }
        }

        [AcceptVerbs("DELETE")]
        [Route("{key}")]
        public void Delete(string key)
        {
            try
            {
                if (Int32.TryParse(key, out int id))
                    TeacherController.dao.ExitProject(id);
                else
                    TeacherController.dao.ExitProject((dao.GetByName(key).Id));

                if (Int32.TryParse(key, out id))
                    StudentController.dao.ExitProject(id);
                else
                    StudentController.dao.ExitProject((dao.GetByName(key).Id));

                dao.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [AcceptVerbs("PUT")]
        [Route("{key}")]
        public void Update(string key, Project project)
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
                throw e;
            }
        }

        [AcceptVerbs("PUT")]
        [Route("{key}/linkTeachers")]
        public void linkTeachers(string key, List<Teacher> teachers)
        {
            if (Int32.TryParse(key, out int id))
                TeacherController.dao.ExitProject(id);
            else
                TeacherController.dao.ExitProject((dao.GetByName(key).Id));

            try
            {
                foreach (Teacher t in teachers)
                {
                    if (Int32.TryParse(key, out id))
                        dao.linkTeacher(id, t.Id);
                    else
                        dao.linkTeacher(dao.GetByName(key).Id, t.Id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [AcceptVerbs("PUT")]
        [Route("{key}/linkStudents")]
        public void linkStudents(string key, List<Student> students)
        {
            if (Int32.TryParse(key, out int id))
                StudentController.dao.ExitProject(id);
            else
                StudentController.dao.ExitProject((dao.GetByName(key).Id));

            try
            {
                foreach (Student t in students)
                {
                    if (Int32.TryParse(key, out id))
                        dao.linkStudent(id, t.RA);
                    else
                        dao.linkStudent(dao.GetByName(key).Id, t.RA);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
