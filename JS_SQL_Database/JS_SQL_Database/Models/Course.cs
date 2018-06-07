using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JS_SQL_Database.Models
{
    public class Course : SchoolData
    {
        [Key]
        public int Id { get; set; }
        public string CourseId { get; set; }
        public string Name { get; set; }
        public Teacher Teaching { get; set; }

        public List<Student> StudentsAttending { get; set; }
        public List<Assignment> Assignments { get; set; }


        public Course()
        {

        }


        public Course(string _id, string _name, Teacher _teaching, List<Assignment> _assignments)
        {
            CourseId = _id;
            Name = _name;
            Teaching = _teaching;
            StudentsAttending = new List<Student>();
            Assignments = _assignments;
        }

        public Course(string _id, string _name)
        {
            CourseId = _id;
            Name = _name;
            Teaching = new Teacher();
            StudentsAttending = new List<Student>();
            Assignments = new List<Assignment>();
        }

    }
}