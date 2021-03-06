﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JS_SQL_Database.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> ListOfCourses { get; set; }
        public List<Assignment> ListOfAssignments { get; set; }

        public Student()
        {
            ListOfCourses = new List<Course>();
            ListOfAssignments = new List<Assignment>();
        }
    }
}