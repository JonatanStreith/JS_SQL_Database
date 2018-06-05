using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JS_SQL_Database.Models
{
    public class Teacher : SchoolData
    {
        public int Id { get; set; }
        public string Name { get; set; }


    }
}