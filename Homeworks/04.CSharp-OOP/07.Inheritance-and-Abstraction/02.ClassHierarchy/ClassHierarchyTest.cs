namespace ClassHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /* Define an abstract class Human holding a first name and a last name.
        • Define a class Student derived from Human that has a field faulty number (5-10 digits / letters).
        • Define a class Worker derived from Human with fields WeekSalary and WorkHoursPerDay
          and method MoneyPerHour() that returns the payment earned by hour by the worker. 
        • Define the proper constructors and properties for the classes in your class hierarchy.
        • Initialize a list of 10 students and sort them by faculty number in ascending order (use LINQ or OrderBy() extension method).
          Initialize a list of 10 workers and sort them by payment per hour in descending order.
        • Merge the lists and then sort them by first name and last name. */

    public class ClassHierarchyTest
    {
        public static void Main()
        {
            Console.WriteLine("Sorted students (by faculty number) \r\n---------------");
            var students = new List<Student>()
        {
                new Student("Pesho", "Petrov", "883728440"),
                new Student("Gosho", "Georgiev", "459375483"),
                new Student("Sasho", "Ivanov", "504763749"),
                new Student("Ginka", "Ilieva", "288105043"),
                new Student("Marijka", "Petkova", "294767438"),
                new Student("Asen", "Asenov", "680293007"),
                new Student("Petja", "Ivanova", "682288250"),
                new Student("Maria", "Dankova", "190300869"),
                new Student("Lili", "Ivanova", "422980102"),
                new Student("Marin", "Marinov", "258956381"),
        };
            students.OrderBy(student => student.FacultyNumber).Print();

            Console.WriteLine("\r\nSorted workers (by money per hour) \r\n---------------");

            var workers = new List<Worker>()
        {
                new Worker("Dancho", "Dimotorv", 650, 8),
                new Worker("Petko", "Iliev", 1650, 12),
                new Worker("Barak", "Obama", 123700, 2),
                new Worker("Ivan", "Petrov", 5906, 5),
                new Worker("Petar", "Ivanov", 3601, 5),
                new Worker("Gosho", "Goshev", 7957, 4),
                new Worker("Kaka", "Lili", 1436, 1),
                new Worker("Bate", "Sasho", 9906, 6),
                new Worker("Lelq", "Kuna", 4848, 5),
                new Worker("Baba", "Ginka", 7495, 2),
        };

            workers.OrderByDescending(worker => worker.MoneyPerHour()).Print();

            var peoples = new List<Human>();
            peoples.AddRange(students);
            peoples.AddRange(workers);

            Console.WriteLine("\r\nSort all by names\r\n---------------");
            var sortedPeoples = peoples.OrderBy(people => people.FirstName).ThenBy(people => people.LastName);

            foreach (var people in sortedPeoples)
            {
                Console.WriteLine("{0} {1}", people.FirstName, people.LastName);
            }
        }
    }
}