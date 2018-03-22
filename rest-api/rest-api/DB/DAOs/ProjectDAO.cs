using rest_api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace rest_api.DB.DAOs
{
    public class ProjectDAO : IRepository<Project>
    {
        public List<Project> GetAll()
        {
            SqlDataReader rdr = null;
            rdr = DBConnection.ExecuteReader("select * from Project");

            List<Project> projs = new List<Project>();
            while (rdr.Read())
                projs.Add(new Project(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3)));

            rdr.Close();
            return projs;
        }

        public Project GetByID(int id)
        {
            SqlDataReader rdr = null;
            rdr = DBConnection.ExecuteReader("select * from Project where Id = " + id);

            Project p = null;
            if (rdr.Read())
                p = new Project(id, rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3));
            rdr.Close();

            return p;
        }

        public Project GetByName(string name)
        {
            SqlDataReader rdr = null;
            rdr = DBConnection.ExecuteReader("select * from Project where Name = '" + name +"'");

            Project p = null;
            if (rdr.Read())
                p = new Project(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3));
            rdr.Close();

            return p;
        }

        public void Insert(Project item)
        {
            DBConnection.ExecuteNonQuery("exec InsertProject '" + item.Name + "', '" + item.Description + "', " + item.Year);
        }

        public void Delete(int id)
        {
            DBConnection.ExecuteNonQuery("delete from Project where Id = " + id);
        }

        public void Update(Project item)
        {
            DBConnection.ExecuteNonQuery("update Project set Name = '" + item.Name + "', Description = '" + item.Description + "', Year = " + item.Year + " where Id = " + item.Id);
        }
    }
}