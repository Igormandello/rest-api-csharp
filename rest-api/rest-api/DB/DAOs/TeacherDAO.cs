using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using rest_api.Models;

namespace rest_api.DB.DAOs
{
    public class TeacherDAO : IRepository<Teacher>
    {
        public List<Teacher> GetAll()
        {
            SqlDataReader rdr = null;
            rdr = DBConnection.ExecuteReader("select * from Teacher");

            List<Teacher> teachers = new List<Teacher>();
            while (rdr.Read())
                teachers.Add(new Teacher(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2)));

            rdr.Close();
            return teachers;
        }

        public Teacher GetByID(int id)
        {
            SqlDataReader rdr = null;
            rdr = DBConnection.ExecuteReader("select * from Teacher where Id = " + id);

            Teacher p = null;
            if (rdr.Read())
                p = new Teacher(id, rdr.GetString(1), rdr.GetString(2));
            rdr.Close();

            return p;
        }

        public void Insert(Teacher item)
        {
            DBConnection.ExecuteNonQuery("insert into Teacher values ('" + item.Name + "', '" + item.Email + "')");
        }

        public void Delete(int id)
        {
            DBConnection.ExecuteNonQuery("delete from Teacher where Id = " + id);
        }

        public void Update(Teacher item)
        {
            DBConnection.ExecuteNonQuery("update Teacher set Name = '" + item.Name + "', Email = '" + item.Email + "' where Id = " + item.Id);
        }

        public List<Teacher> GetByProjectID(int id)
        {
            SqlDataReader rdr = null;
            rdr = DBConnection.ExecuteReader("select * from ProjectTeacher where ProjectId = " + id);

            List<Teacher> teachers = new List<Teacher>();

            while (rdr.Read())
                teachers.Add(GetByID(rdr.GetInt32(2)));

            rdr.Close();
            return teachers;
        }
    }
}