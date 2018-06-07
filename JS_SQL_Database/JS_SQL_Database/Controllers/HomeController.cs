using JS_SQL_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JS_SQL_Database.Controllers
{
    public class HomeController : Controller
    {

        public SchoolContext context = new SchoolContext();

        // GET: Home
        public ActionResult Index()
        {

            return View();
        }





        public ActionResult Cheat()
        {
            return View();
        }
   
        [HttpPost]
        public ActionResult ClearDatabase()
        {
            DataHandler.EmptyData();
            return View("Index");
        }

        [HttpPost]
        public ActionResult RepopulateDatabase()
        {
            DataHandler.AddData();
            return View("Index");
        }








        public ActionResult DisplayData()
        {

            return View();
        }

        [HttpPost]
        public ActionResult RequestData(string pressedButton, string studentId)
        {

            
                if (pressedButton == "Students")
                {
                    return PartialView("PV_Students", context.Students.ToList());
                }

                else if (pressedButton == "Teachers")
                {
                    return PartialView("PV_Teachers", context.Teachers.ToList());
                }
                
                else if (pressedButton == "Assignments")
                {
                    return PartialView("PV_Assignments", context.Assignments.ToList());
                }

                else if (pressedButton == "Courses")
                {
                    return PartialView("PV_Courses", context.Courses.Include("Teaching").ToList());
                }

                else if (pressedButton == "Show Student")
            {



                return PartialView("PV_SpecificStudent", context.Students.Include("ListOfAssignments").ToList().Find(x => x.Id.Equals(Convert.ToInt32(studentId))));
            }



                else
                {
                    return View("DisplayData");
                }
            
        }

















        public ActionResult EnterData()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(string name)
        {
            context.Students.Add(new Student { Name = name });

            context.SaveChanges();

            return View("EnterData");
        }


        [HttpPost]
        public ActionResult AddTeacher(string name)
        {
            context.Teachers.Add(new Teacher { Name = name });

            context.SaveChanges();

            return View("EnterData");
        }

        [HttpPost]
        public ActionResult AddCourse(string courseid, string name)
        {
            context.Courses.Add(new Course(courseid, name) );

            context.SaveChanges();

            return View("EnterData");
        }

        [HttpPost]
        public ActionResult AddAssignment(string name, string field)
        {
            context.Assignments.Add(new Assignment {Name = name, Field = field });

            context.SaveChanges();

            return View("EnterData");
        }



        [HttpPost]
        public ActionResult AssignStudentToCourse(string student, string course)
        {

            context.Students.Find(Convert.ToInt32(student)).ListOfCourses.Add(context.Courses.Find(Convert.ToInt32(course))); //This adds the course to the student's ListOfCourses

            context.Students.Find(Convert.ToInt32(student)).ListOfAssignments.AddRange(context.Courses.Find(Convert.ToInt32(course)).Assignments);

            context.Courses.Find(Convert.ToInt32(course)).StudentsAttending.Add(context.Students.Find(Convert.ToInt32(course))); //This adds the student to the course's StudentsAttending


            return View("EnterData");

        }


    }
}