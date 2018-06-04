﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JS_SQL_Database.Models
{
    public class Class
    {
        public string ClassId { get; set; }
        public string Name { get; set; }
        public Teacher Teaching { get; set; }

        public List<Student> StudentsAttending { get; set; }
    }
}