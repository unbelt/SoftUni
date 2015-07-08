namespace StudentSystem.ConsoleClient
{
    using System;
    using Data;
    using Models;

    public class StudentSystem
    {
        public static void Main()
        {
            ListAllCourses();
            ListAllStudents();
        }

        public static void AddStudent(string firstName, string lastName,
            DateTime birthDate, string phoneNumber = null)
        {
            using (var db = new StudentSystemContext())
            {
                db.Students.Add(new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = birthDate,
                    PhoneNumber = phoneNumber,
                    RegistrationDate = DateTime.Now
                });

                db.SaveChanges();
            }
        }

        public static void AddHomework(string contentUrl, FileType fileType, DateTime date)
        {
            using (var db = new StudentSystemContext())
            {
                db.Homeworks.Add(new Homework
                {
                    ContentUrl = contentUrl,
                    FileType = fileType,
                    Date = date
                });

                db.SaveChanges();
            }
        }

        public static void AddCourse(string name, string desctiption, DateTime startDate, DateTime endDate, decimal price = 0.0m)
        {
            using (var db = new StudentSystemContext())
            {
                db.Courses.Add(new Course
                {
                    Name = name,
                    Description = desctiption,
                    StartDate = startDate,
                    EndDate = endDate,
                    Price = price
                });

                db.SaveChanges();
            }
        }

        public static void AddResource(string name, string link, ResourceType resourceType = ResourceType.Other)
        {
            using (var db = new StudentSystemContext())
            {
                db.Resources.Add(new Resource
                {
                    Name = name,
                    Link = link,
                    ResourceTypes = resourceType
                });

                db.SaveChanges();
            }
        }

        public static void ListAllCourses()
        {
            using (var db = new StudentSystemContext())
            {
                var courses = db.Courses;

                foreach (var course in courses)
                {
                    Console.WriteLine("{0} - {1}; Length {2} - {3}; Price: {4}", course.Name, course.Description,
                    course.StartDate, course.EndDate, course.Price);
                }
            }
        }

        public static void ListAllStudents()
        {
            using (var db = new StudentSystemContext())
            {
                var students = db.Students;

                foreach (var student in students)
                {
                    Console.WriteLine("{0} {1} - Birth Date: {2}; Phone Number: {3}; Reg Date: {4}", student.FirstName,
                    student.LastName, student.BirthDate, student.PhoneNumber, student.RegistrationDate);
                }
            }
        }
    }
}