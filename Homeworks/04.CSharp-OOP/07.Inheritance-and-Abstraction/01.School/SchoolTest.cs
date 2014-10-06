namespace School
{
    using System;

    /* We are given a school. In the school, there are classes of students. 
        • Each class has a set of teachers. 
        • Each teacher teaches a set of disciplines. 
        • Students have name and unique class number. Classes have unique text identifier.
        • Teachers have name. Disciplines have name, number of lectures and students.
        • Both teachers and students are people.
        • Students, classes, teachers and disciplines have details (optional field).
     * Your task is to identify the classes (in terms of OOP) and their members,
     * encapsulate their fields, define the class hierarchy (inherit shared data and functionality)
     * and create a class diagram with Visual Studio. */

    public class SchoolTest
    {
        public static void Main()
        {
            Console.WriteLine(
                new School("Vasil Levski", "National High School of Mathematics")
                .AddClass(new Class("12b", "Wild wild west")
                .AddTeacher(new Teacher("Ivan Petrov", "Math Guru")
                .AddDiscipline(new Discipline("Math", 4)
                .AddStudent(new Student("Pesho Petrov", 12, "Lazy Bast***"))))));

            try
            {
                new School(string.Empty, null);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message + Environment.NewLine);
            }
        }
    }
}