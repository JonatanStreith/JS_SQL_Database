using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JS_SQL_Database.Models
{
    public class Assignment
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Field { get; set; }
    }
}