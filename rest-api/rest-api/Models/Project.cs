using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rest_api.Models
{
    public class Project
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int Year { get; set; }


        public Project(int id, String name, String desc, int year)
        {
            this.Id = id;
            this.Name = name;
            this.Description = desc;
            this.Year = year;
        }
    }
}