using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JS_SQL_Database.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Class> ListOfClasses { get; set; }
    }
}