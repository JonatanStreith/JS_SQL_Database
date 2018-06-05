using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JS_SQL_Database.Models
{
    public static class DataHandler
    {

        public static void AddData()
        {


            //First, generate lists of objects!

            List<Student> students = new List<Student> {
            new Student() { Id = 1, Name = "Steve" },
            new Student() { Id = 2, Name = "Beth" },
            new Student() { Id = 3, Name = "Dave" },
            new Student() { Id = 4, Name = "Greg" },
            new Student() { Id = 5, Name = "Kojiro" },
            new Student() { Id = 6, Name = "Fizzlepop" },
            new Student() { Id = 7, Name = "Slagathor" }
            };

            List<Teacher> teachers = new List<Teacher> {
            new Teacher() { Id = 1, Name = "Mr Norris" },
            new Teacher() { Id = 2, Name = "Miss Cheerilee" },
            new Teacher() { Id = 3, Name = "Hagrid" },
            new Teacher() { Id = 5, Name = "Dean Bitterman" },
            new Teacher() { Id = 4, Name = "Onizuka" }
        };


            List<Assignment> assignments = new List<Assignment> {
            new Assignment() { Id = "1", Name = "Complete page 5", Field = "Math" },
            new Assignment() { Id = "2", Name = "Calculate the weight of the moon", Field = "Geophysics" },
            new Assignment() { Id = "3", Name = "Essay: The Spanish Inquisition", Field = "History" },
            new Assignment() { Id = "4", Name = "Eat Creme Brule", Field = "Lunch" },
            new Assignment() { Id = "5", Name = "Interpretive dance: Watergate", Field = "History" },
            new Assignment() { Id = "6", Name = "Add two values and then divide them", Field = "Math" },
            new Assignment() { Id = "7", Name = "Bread and water", Field = "Lunch" },
            new Assignment() { Id = "8", Name = "Essay: Why mountains are heavy", Field = "Geophysics" },
            new Assignment() { Id = "9", Name = "Make a dog basket", Field = "Underwater basket weaving" },
            new Assignment() { Id = "10", Name = "Make an ottoman", Field = "Underwater basket weaving" }
        };


            List<Course> courses = new List<Course> {
            new Course("MA101", "Math", teachers.Find(x => x.Name.Equals("Mr Norris"))) ,
            new Course("PH503", "Geophysics", teachers.Find(x => x.Name.Equals("Miss Cheerilee"))),
            new Course("LU101", "Lunch", teachers.Find(x => x.Name.Equals("Hagrid"))),
            new Course("HI101", "History", teachers.Find(x => x.Name.Equals("Dean Bitterman"))),
            new Course("RE306", "Underwater basket weaving", teachers.Find(x => x.Name.Equals("Onizuka")))
            };






            using (var context = new SchoolContext())
            {

                foreach (Student stud in students)
                {
                    context.Students.Add(stud);
                }


                foreach (Teacher teach in teachers)
                {
                    context.Teachers.Add(teach);
                }

                foreach (Assignment ass in assignments)
                {
                    context.Assignments.Add(ass);
                }

                foreach (Course cour in courses)
                {
                    context.Courses.Add(cour);
                }


                context.SaveChanges();


            }



            //using (var context = new SchoolContext())
            //{
            //    context.Students.Add(new Student() { Id = 1, Name = "Steve" });
            //    context.Students.Add(new Student() { Id = 2, Name = "Beth" });
            //    context.Students.Add(new Student() { Id = 3, Name = "Dave" });
            //    context.Students.Add(new Student() { Id = 4, Name = "Greg" });
            //    context.Students.Add(new Student() { Id = 5, Name = "Kojiro" });
            //    context.Students.Add(new Student() { Id = 6, Name = "Fizzlepop" });
            //    context.Students.Add(new Student() { Id = 7, Name = "Slagathor" });

            //    Teacher defaultTeacher = new Teacher() { Id = 0, Name = "Mr Blank" };



            //    context.Teachers.Add(new Teacher() { Id = 1, Name = "Mr Norris" });
            //    context.Teachers.Add(new Teacher() { Id = 2, Name = "Miss Cheerilee" });
            //    context.Teachers.Add(new Teacher() { Id = 3, Name = "Hagrid" });
            //    context.Teachers.Add(new Teacher() { Id = 4, Name = "Onizuka" });
            //    context.Teachers.Add(new Teacher() { Id = 5, Name = "Dean Bitterman" });


            //    context.Assignments.Add(new Assignment() { Id = "1", Name = "Complete page 5", Field = "Math" });
            //    context.Assignments.Add(new Assignment() { Id = "2", Name = "Calculate the weight of the moon", Field = "Geophysics" });
            //    context.Assignments.Add(new Assignment() { Id = "3", Name = "Essay: The Spanish Inquisition", Field = "History" });
            //    context.Assignments.Add(new Assignment() { Id = "4", Name = "Eat Creme Brule", Field = "Lunch" });
            //    context.Assignments.Add(new Assignment() { Id = "5", Name = "Interpretive dance: Watergate", Field = "History" });
            //    context.Assignments.Add(new Assignment() { Id = "6", Name = "Add two values and then divide them", Field = "Math" });
            //    context.Assignments.Add(new Assignment() { Id = "7", Name = "Bread and water", Field = "Lunch" });
            //    context.Assignments.Add(new Assignment() { Id = "8", Name = "Essay: Why mountains are heavy", Field = "Geophysics" });
            //    context.Assignments.Add(new Assignment() { Id = "9", Name = "Make a dog basket", Field = "Underwater basket weaving" });
            //    context.Assignments.Add(new Assignment() { Id = "10", Name = "Make an ottoman", Field = "Underwater basket weaving" });


            //    context.SaveChanges();

            //    Teacher newTeacher = context.Teachers.FirstOrDefault(x => x.Name.Equals("Miss Cheerilee"));

            //    context.Courses.Add(new Course() { CourseId = "MA101", Name = "Math", Teaching = newTeacher, Assignments = context.Assignments.Where(x => x.Field.Equals("Math")).ToList() });
            //    context.Courses.Add(new Course() { CourseId = "PH503", Name = "Geophysics", Teaching = context.Teachers.FirstOrDefault(x => x.Name.Equals("Mr Norris")), Assignments = context.Assignments.Where(x => x.Field.Equals("Geophysics")).ToList() });
            //    context.Courses.Add(new Course() { CourseId = "LU101", Name = "Lunch", Teaching = context.Teachers.FirstOrDefault(x => x.Name.Equals("Hagrid")), Assignments = context.Assignments.Where(x => x.Field.Equals("Lunch")).ToList() });
            //    context.Courses.Add(new Course() { CourseId = "HI101", Name = "History", Teaching = context.Teachers.FirstOrDefault(x => x.Name.Equals("Dean Bitterman")), Assignments = context.Assignments.Where(x => x.Field.Equals("History")).ToList() });
            //    context.Courses.Add(new Course() { CourseId = "RE306", Name = "Underwater basket weaving", Teaching = context.Teachers.FirstOrDefault(x => x.Name.Equals("Onizuka")), Assignments = context.Assignments.Where(x => x.Field.Equals("Underwater basket weaving")).ToList() });


            //    foreach (Course c in context.Courses)
            //    {
            //        foreach (Student s in context.Students)
            //        {
            //            c.StudentsAttending.Add(s);
            //            s.ListOfCourses.Add(c);
            //        }
            //    }

            //    context.SaveChanges();




        
        }

        public static void EmptyData()
        {
            using (var context = new SchoolContext())
            {
                foreach (var entity in context.Students)
                    context.Students.Remove(entity);


                foreach (var entity in context.Teachers)
                    context.Teachers.Remove(entity);

                foreach (var entity in context.Courses)
                    context.Courses.Remove(entity);


                foreach (var entity in context.Assignments)
                    context.Assignments.Remove(entity);



                context.SaveChanges();
            }



        }


        //public static List<object> RetrieveData(string request)
        //{

        //    List<object> output = new List<object>();

        //    using (var context = new SchoolContext())
        //    {

        //        if (request == "Students")
        //        {
        //            output = context.Students.ToList();
        //        }



        //    }

        //    return something;
        //} 


    }
}