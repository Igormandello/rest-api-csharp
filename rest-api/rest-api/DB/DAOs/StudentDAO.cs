using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using rest_api.Models;

namespace rest_api.DB.DAOs
{
    public class StudentDAO : IRepository<Student>
    {
        public List<Student> GetAll()
        {
            SqlDataReader rdr = null;
            rdr = DBConnection.ExecuteReader("select * from Student");

            List<Student> studs = new List<Student>();
            while (rdr.Read())
                studs.Add(new Student(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2)));

            rdr.Close();
            return studs;
        }

        public Student GetByID(int ra)
        {
            SqlDataReader rdr = null;
            rdr = DBConnection.ExecuteReader("select * from Student where RA = " + ra);

            Student p = null;
            if (rdr.Read())
                p = new Student(ra, rdr.GetString(1), rdr.GetString(2));
            rdr.Close();

            return p;
        }

        public void Insert(Student item)
        {
            DBConnection.ExecuteNonQuery("insert into Student values ('" + item.Name + "', '" + item.Email + "')");
        }

        public void Delete(int ra)
        {
            DBConnection.ExecuteNonQuery("delete from Student where RA = " + ra);
        }

        public void Update(Student item)
        {
            DBConnection.ExecuteNonQuery("update Student set Name = '" + item.Name + "', Email = '" + item.Email + "' where RA = " + item.RA);
        }

        public List<Student> GetByProjectID(int id)
        {
            SqlDataReader rdr = null;
            rdr = DBConnection.ExecuteReader("select * from ProjectStudent where ProjectId = " + id);

            List<Student> studs = new List<Student>();

            while (rdr.Read())
                studs.Add(GetByID(rdr.GetInt32(2)));

            rdr.Close();
            return studs;
        }
    }
}