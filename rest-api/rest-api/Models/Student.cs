using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rest_api.Models
{
    public class Student
    {
        public int RA { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }

        public Student(int ra, String name, String email)
        {
            this.RA = ra;
            this.Name = name;
            this.Email = email;
        }
    }
}