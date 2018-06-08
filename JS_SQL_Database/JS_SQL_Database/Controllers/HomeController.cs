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
        public ActionResult RequestData(string pressedButton, string studentId, string courseId)
        {


            if (pressedButton == "All students")
            {
                return PartialView("PV_Students", context.Students.ToList());
            }

            else if (pressedButton == "All teachers")
            {
                return PartialView("PV_Teachers", context.Teachers.ToList());
            }

            else if (pressedButton == "All assignments")
            {
                return PartialView("PV_Assignments", context.Assignments.ToList());
            }

            else if (pressedButton == "All courses")
            {
                return PartialView("PV_Courses", context.Courses.Include("Teaching").ToList());
            }







            else if (pressedButton == "Student assignments")
            {
                var stu = context.Students.Include("ListOfAssignments").ToList();
                int sid;
                bool result = Int32.TryParse(studentId, out sid);




                if (result == true)// is a number
                {

                    if (stu.Exists(x => x.Id.Equals(sid)))
                    {
                        return PartialView("PV_SpecificStudentAssignments", stu.Find(x => x.Id.Equals(sid)));
                    }
                    else
                    {
                        return PartialView("DataNotFound");
                    }
                }
                else
                {

                    if (stu.Exists(x => x.Name.Equals(studentId)))
                    {
                        return PartialView("PV_SpecificStudentAssignments", stu.Find(x => x.Name.Equals(studentId)));
                    }
                    else
                    {
                        return PartialView("DataNotFound");
                    }


                }
            }

            else if (pressedButton == "Student courses")
            {
                var stu = context.Students.Include("ListOfCourses").ToList();
                int sid;
                bool result = Int32.TryParse(studentId, out sid);


                if (result == true)// is a number
                {

                    if (stu.Exists(x => x.Id.Equals(sid)))
                    {
                        return PartialView("PV_SpecificStudentCourses", stu.Find(x => x.Id.Equals(sid)));
                    }
                    else
                    {
                        return PartialView("DataNotFound");
                    }
                }
                else
                {
                    if (stu.Exists(x => x.Name.Equals(studentId)))
                    {
                        return PartialView("PV_SpecificStudentCourses", stu.Find(x => x.Name.Equals(studentId)));
                    }
                    else
                    {
                        return PartialView("DataNotFound");
                    }



                }
            }

            else if (pressedButton == "Students attending")
            {

                var cour = context.Courses.Include("StudentsAttending").ToList();
                int cid;
                bool result = Int32.TryParse(courseId, out cid);


                if (result == true)//courseId is a number
                {
                    if (cour.Exists(x => x.Id.Equals(cid)))
                    {
                        return PartialView("PV_SpecificCourseStudents", cour.Find(x => x.Id.Equals(cid)));
                    }
                    else
                    {
                        return PartialView("DataNotFound");
                    }
                }
                else //courseId is not a number, maybe a word
                {

                    if (cour.Exists(x => x.Name.Equals(courseId)))
                    {
                        return PartialView("PV_SpecificCourseStudents", cour.Find(x => x.Name.Equals(courseId)));
                    }
                    else
                    {
                        return PartialView("DataNotFound");
                    }





                }
            }

            else if (pressedButton == "Required assignments")
            {

                var cour = context.Courses.Include("Assignments").ToList();
                int cid;
                bool result = Int32.TryParse(courseId, out cid);


                if (result == true)//courseId is a number
                {
                    if (cour.Exists(x => x.Id.Equals(cid)))
                    {
                        return PartialView("PV_SpecificCourseAssignments", cour.FirstOrDefault(x => x.Id.Equals(cid)));
                    }
                    else
                    {
                        return PartialView("DataNotFound");
                    }
                }
                else          //courseId is not a number, maybe a word
                {
                    if (cour.Exists(x => x.Name.Equals(courseId)))
                    {
                        return PartialView("PV_SpecificCourseAssignments", cour.FirstOrDefault(x => x.Name.Equals(courseId)));
                    }
                    else
                    {
                        return PartialView("DataNotFound");
                    }

                }
            }


            else
            {
                return PartialView("DataNotFound");
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
            context.Courses.Add(new Course(courseid, name));

            context.SaveChanges();

            return View("EnterData");
        }

        [HttpPost]
        public ActionResult AddAssignment(string name, string field)
        {
            context.Assignments.Add(new Assignment { Name = name, Field = field });

            context.SaveChanges();

            return View("EnterData");
        }



        [HttpPost]
        public ActionResult AssignStudentToCourse(string student, string course)
        {
            var stu = context.Students.Include("ListOfCourses").Include("ListOfAssignments").ToList().Find(x => x.Id.Equals(Convert.ToInt32(student)));

            var cour = context.Courses.Include("StudentsAttending").Include("Assignments").ToList().Find(x => x.Id.Equals(Convert.ToInt32(course)));


            stu.ListOfCourses.Add(cour); //This adds the course to the student's ListOfCourses


            //if (cour.Assignments != null)
            //{
            stu.ListOfAssignments.AddRange(cour.Assignments);
            //}

            cour.StudentsAttending.Add(stu); //This adds the student to the course's StudentsAttending



            context.SaveChanges();

            return View("EnterData");

        }


    }
}