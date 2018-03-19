using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rest_api.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }

        public Teacher(int id, String name, String email)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
        }
    }
}