using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JS_SQL_Database.Models
{
    public class Course
    {
        [Key]
        public string CourseId { get; set; }
        public string Name { get; set; }
        public Teacher Teaching { get; set; }

        public List<Student> StudentsAttending { get; set; }
        public List<Assignment> Assignments { get; set; }

        public Course()
        {
            StudentsAttending = new List<Student>();
            Assignments = new List<Assignment>();
        }

    }
}