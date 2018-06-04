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
            using (var context = new SchoolContext())
            {
                context.Students.Add(new Student() { Id = 1, Name = "Steve"  });
                context.Students.Add(new Student() { Id = 2, Name = "Beth" });
                context.Students.Add(new Student() { Id = 3, Name = "Dave" });
                context.Students.Add(new Student() { Id = 4, Name = "Greg" });
                context.Students.Add(new Student() { Id = 5, Name = "Kojiro" });
                context.Students.Add(new Student() { Id = 6, Name = "Fizzlepop" });
                context.Students.Add(new Student() { Id = 7, Name = "Slagathor" });


                context.Teachers.Add(new Teacher() { Id = 1, Name = "Mr Norris" });
                context.Teachers.Add(new Teacher() { Id = 2, Name = "Miss Cheerilee" });
                context.Teachers.Add(new Teacher() { Id = 3, Name = "Hagrid" });
                context.Teachers.Add(new Teacher() { Id = 4, Name = "Onizuka" });
                context.Teachers.Add(new Teacher() { Id = 5, Name = "Dean Bitterman" });


                context.Assignments.Add(new Assignment() { Id = "1", Name = "Complete page 5", Field = "Math" });
                context.Assignments.Add(new Assignment() { Id = "2", Name = "Calculate the weight of the moon", Field = "Geophysics" });
                context.Assignments.Add(new Assignment() { Id = "3", Name = "Essay: The Spanish Inquisition", Field = "History" });
                context.Assignments.Add(new Assignment() { Id = "4", Name = "Eat Creme Brule", Field = "Lunch" });
                context.Assignments.Add(new Assignment() { Id = "5", Name = "Interpretive dance: Watergate", Field = "History" });
                context.Assignments.Add(new Assignment() { Id = "6", Name = "Add two values and then divide them", Field = "Math" });
                context.Assignments.Add(new Assignment() { Id = "7", Name = "Bread and water", Field = "Lunch" });
                context.Assignments.Add(new Assignment() { Id = "8", Name = "Essay: Why mountains are heavy", Field = "Geophysics" });
                context.Assignments.Add(new Assignment() { Id = "9", Name = "Make a dog basket", Field = "Underwater basket weaving" });
                context.Assignments.Add(new Assignment() { Id = "10", Name = "Make an ottoman", Field = "Underwater basket weaving" });

                context.Courses.Add(new Course() { CourseId = "MA101", Name = "Math", Teaching = context.Teachers.FirstOrDefault(x => x.Name.Equals("Miss Cheerilee")), Assignments = context.Assignments.Where(x => x.Field.Equals("Math")).ToList() });
                context.Courses.Add(new Course() { CourseId = "PH503", Name = "Geophysics", Teaching = context.Teachers.FirstOrDefault(x => x.Name.Equals("Mr Norris")), Assignments = context.Assignments.Where(x => x.Field.Equals("Geophysics")).ToList() });
                context.Courses.Add(new Course() { CourseId = "LU101", Name = "Lunch", Teaching = context.Teachers.FirstOrDefault(x => x.Name.Equals("Hagrid")), Assignments = context.Assignments.Where(x => x.Field.Equals("Lunch")).ToList() });
                context.Courses.Add(new Course() { CourseId = "HI101", Name = "History", Teaching = context.Teachers.FirstOrDefault(x => x.Name.Equals("Dean Bitterman")), Assignments = context.Assignments.Where(x => x.Field.Equals("History")).ToList() });
                context.Courses.Add(new Course() { CourseId = "RE306", Name = "Underwater basket weaving", Teaching = context.Teachers.FirstOrDefault(x => x.Name.Equals("Onizuka")), Assignments = context.Assignments.Where(x => x.Field.Equals("Underwater basket weaving")).ToList() });


                foreach (Course c in context.Courses)
                {
                    foreach (Student s in context.Students)
                    {
                        c.StudentsAttending.Add(s);
                        s.ListOfCourses.Add(c);
                    }
                }




            }
        }


    }
}