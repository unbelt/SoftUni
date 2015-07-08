namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using StudentSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true; // For testing purpose only!
        }

        protected override void Seed(StudentSystemContext context)
        {
            SeedCoursesAndResources(context);
            SeedStudentsAndHomeworks(context);
        }

        private static void SeedCoursesAndResources(StudentSystemContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            context.Courses.Add(new Course
            {
                Name = "Database Applications",
                Description =
                    "The course \"Database Applications\" introduces the ORM frameworks (Object-Relational Mapping), XML, JSON, non-relational database access (like MongoDB and Redis) and other technologies and tools for simplifying the practical data access and building database applications in high-level programming languages (like C#, Java and PHP).",
                StartDate = DateTime.Now,
                EndDate = new DateTime(2015, 03, 29),
                Price = 0.0m,
                Resourceses = new List<Resource>
                {
                    new Resource
                    {
                        Name = "Database Applications Videos",
                        Link = "https://softuni.bg/trainings/21/Database-Applications-Mar-2015",
                        ResourceTypes = ResourceType.Video
                    }
                }
            });
        }

        private static void SeedStudentsAndHomeworks(StudentSystemContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            context.Students.Add(new Student
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1990, 03, 07),
                PhoneNumber = "0881231234",
                RegistrationDate = DateTime.Now,
                Homeworks = new List<Homework>
                        {
                            new Homework
                            {
                                FileType = FileType.Zip,
                                Date = DateTime.Now,
                                ContentUrl = "https://softuni.bg/trainings/homeworks/downloadhomework/1633"
                            }
                        }
            });
        }
    }
}