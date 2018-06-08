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

            else if (pressedButton == "All data")
            {
                var cour = context.Courses.Include("Assignments").Include("StudentsAttending").Include("Teaching").ToList();
                int cid;
                bool result = Int32.TryParse(courseId, out cid);



                if (result == true)//courseId is a number
                {
                    if (cour.Exists(x => x.Id.Equals(cid)))
                    {
                        return PartialView("PV_AllData", cour.FirstOrDefault(x => x.Id.Equals(cid)));
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
                        return PartialView("PV_AllData", cour.FirstOrDefault(x => x.Name.Equals(courseId)));
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
        public ActionResult AddFullCourse(string courseid, string name, string teacher)
        {

            int tid;
            bool result = Int32.TryParse(teacher, out tid);


            if (context.Teachers.ToList().Exists(x => x.Name.Equals(teacher)))
            {
                context.Courses.Add(new Course(courseid, name, context.Teachers.ToList().Find(x => x.Name.Equals(teacher)), context.Assignments.ToList().FindAll(x => x.Field.Equals(name))));
            }


            else if (context.Teachers.ToList().Exists(x => x.Id.Equals(tid)))
            {
                context.Courses.Add(new Course(courseid, name, context.Teachers.ToList().Find(x => x.Name.Equals(teacher)), context.Assignments.ToList().FindAll(x => x.Field.Equals(name))));
            }
            else
            {

                return Content("<script language='javascript' type='text/javascript'>alert('Failed!');</script>");
            }


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


            if (cour.Assignments != null)
            {
                stu.ListOfAssignments.AddRange(cour.Assignments);
            }

            cour.StudentsAttending.Add(stu); //This adds the student to the course's StudentsAttending



            context.SaveChanges();

            return View("EnterData");

        }


        [HttpPost]
        public ActionResult AssignAssignmentToCourse(string assignment, string course)
        {
            var ass = context.Assignments.Include("BelongsToCourse").Include("StudentsWorking").ToList().Find(x => x.Id.Equals(Convert.ToInt32(assignment)));

            var cour = context.Courses.Include("StudentsAttending").Include("Assignments").ToList().Find(x => x.Id.Equals(Convert.ToInt32(course)));

            cour.Assignments.Add(ass);
            ass.BelongsToCourse = cour;
            ass.Field = cour.Name;

            foreach (Student stu in cour.StudentsAttending)
            {
                stu.ListOfAssignments.Add(ass);
            }

            context.SaveChanges();

            return View("EnterData");


        }

        [HttpPost]
        public ActionResult AssignTeacherToCourse(string teacher, string course)
        {
            var tea = context.Teachers.ToList().Find(x => x.Id.Equals(Convert.ToInt32(teacher)));
            var cour = context.Courses.Include("Teaching").ToList().Find(x => x.Id.Equals(Convert.ToInt32(course)));

            cour.Teaching = tea;

            context.SaveChanges();

            return View("EnterData");


        }





        public ActionResult RemoveData()
        {


            return View();
        }


        [HttpPost]
        public ActionResult RemoveStudent(int id, string button)
        {
            if (button == "Remove")
            {
                context.Students.Remove(context.Students.Find(id));
            }
            else if (button == "Remove all")
            {
                foreach (Student stu in context.Students)
                {
                    context.Students.Remove(stu);
                }
            }
            else { }

            context.SaveChanges();

            return View("RemoveData");
        }


        [HttpPost]
        public ActionResult RemoveTeacher(int id, string button)
        {
            if (button == "Remove")
            {
                foreach (Course cour in context.Courses.Include("Teaching"))  //Must remove all references to this object
                {
                    if ((cour.Teaching != null) && (cour.Teaching.Id.Equals(id)))
                    {
                        cour.Teaching = null;
                    }

                }


                context.Teachers.Remove(context.Teachers.Find(id));




            }
            else if (button == "Remove all")
            {
                foreach (Teacher tea in context.Teachers)
                {

                    foreach (Course cour in context.Courses.Include("Teaching"))  //Must remove all references to this object
                    {
                        if ((cour.Teaching != null) && (cour.Teaching.Id.Equals(tea.Id)))
                        {
                            cour.Teaching = null;
                        }

                    }





                    context.Teachers.Remove(tea);
                }



            }
            else { }

            context.SaveChanges();

            return View("RemoveData");
        }

        [HttpPost]
        public ActionResult RemoveAssignment(int id, string button)
        {
            if (button == "Remove")
            {
                context.Assignments.Remove(context.Assignments.Find(id));
            }
            else if (button == "Remove all")
            {
                foreach (Assignment ass in context.Assignments)
                {
                    context.Assignments.Remove(ass);
                }
            }
            else { }

            context.SaveChanges();

            return View("RemoveData");
        }


        [HttpPost]
        public ActionResult RemoveCourse(int id, string button)
        {
            if (button == "Remove")
            {
                context.Courses.Remove(context.Courses.Find(id));
            }
            else if (button == "Remove all")
            {
                foreach (Course cour in context.Courses)
                {
                    context.Courses.Remove(cour);
                }
            }
            else { }

            context.SaveChanges();

            return View("RemoveData");
        }








        [HttpPost]
        public ActionResult UnassignStudentFromCourse(string student, string course)
        {

            var stu = context.Students.Include("ListOfCourses").Include("ListOfAssignments").ToList().Find(x => x.Id.Equals(Convert.ToInt32(student)));

            var cour = context.Courses.Include("StudentsAttending").Include("Assignments").ToList().Find(x => x.Id.Equals(Convert.ToInt32(course)));



            if ((stu != null) && (cour != null))
            {
                if (stu.ListOfCourses.Contains(cour))
                {
                    stu.ListOfCourses.Remove(cour);
                }

                if (cour.Assignments != null)
                {
                    for (int i = 0; i < cour.Assignments.Count; i++)
                    {
                        for (int j = 0; j < stu.ListOfAssignments.Count; j++)
                        {
                            if (cour.Assignments[i].Equals(stu.ListOfAssignments[j]))
                            {
                                stu.ListOfAssignments.Remove(stu.ListOfAssignments[j]);
                            }
                        }
                    }
                }

                cour.StudentsAttending.Remove(stu); //This removes the student from the course's StudentsAttending



                context.SaveChanges();



            }
            return View("EnterData");

        }


        [HttpPost]
        public ActionResult UnassignAssignmentFromCourse(string assignment, string course)
        {

            var ass = context.Assignments.Include("BelongsToCourse").Include("StudentsWorking").ToList().Find(x => x.Id.Equals(Convert.ToInt32(assignment)));

            var cour = context.Courses.Include("StudentsAttending").Include("Assignments").ToList().Find(x => x.Id.Equals(Convert.ToInt32(course)));



            if ((ass != null) && (cour != null))
            {

                foreach (Student stu in cour.StudentsAttending)
                {

                    if (stu.ListOfAssignments.Contains(ass))
                    {
                        stu.ListOfAssignments.Remove(ass);
                    }
                }


                if (cour.Assignments.Contains(ass))
                {
                    cour.Assignments.Remove(ass);
                }
                ass.BelongsToCourse = null;
                ass.Field = null;


                context.SaveChanges();
            }
            return View("EnterData");


        }

        [HttpPost]
        public ActionResult UnassignTeacherFromCourse(string course)
        {
            //var tea = context.Teachers.ToList().Find(x => x.Id.Equals(Convert.ToInt32(teacher)));
            var cour = context.Courses.Include("Teaching").ToList().Find(x => x.Id.Equals(Convert.ToInt32(course)));


            if (cour != null)
            {
                cour.Teaching = null;

                context.SaveChanges();
            }

            return View("EnterData");


        }















    }
}