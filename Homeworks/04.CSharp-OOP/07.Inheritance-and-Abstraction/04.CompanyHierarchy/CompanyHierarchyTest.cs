namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;

    /* Create the following OOP class hierarchy:
        • Person – general class for anyone, holding id, first name and last name.
        • Employee – general class for all employees, holding the field salary and department.
          The department can only be one of the following: Production, Accounting, Sales or Marketing.
        • Manager – holds a set of employees under his command.
        • RegularEmployee
        • SalesEmployee – holds a set of sales. A sale holds product name, date and price.
        • Developer – holds a set of projects. A project holds project name, project start date, details and a state (open or closed).
          A project can be closed through the method CloseProject().
        • Customer – holds the net purchase amount (total amount of money the customer has spent).
     * Extract interfaces for each class. (e.g. IPerson, IEmployee, IManager, etc.)
     * The interfaces should hold their public properties and methods (e.g. IPerson should hold id, first name and last name).
     * Each class should implement its respective interface.
     * Define proper constructors. Avoid code duplication through abstraction.
     * Encapsulate all data and validate the input. Throw exceptions where necessary.
     * Override ToString() in all classes to print detailed information about the object.
     * Create several employees of type Manager, SalesEmployee and Developer and add them in a single collection.
     * Finally, print them in a for-each loop. */

    public class CompanyHierarchyTest
    {
        public static void Main()
        {
            var employees = new List<Employee>()
            {
                new Manager("Svetlin", "Nakov", 1, 25000, Department.Production)
                .AddSlaves(
                    new SalesEmployee("Pesho", "Goshev", 12, 900.50)
                        .AddSales(
                            new Sale("Website", DateTime.Now, 2000)
                        ),
                    new SalesEmployee("Ginka", "Pesheva", 13, 400),
                    new Developer("Zombi", "Zombev", 99, 0.50, Department.Production)
                        .AddProjects(
                            new Project("Voting System", DateTime.Now, "Personal voting solution."),
                            new Project("Chess", DateTime.Now, "Aside chess game")
                        ),
                    new Developer("Don", "Emilio", 100, 0.30, Department.Marketing)
                 ),
                new Manager("Ivan", "Ivanov", 2, 2200, Department.Accounting)
            };

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }

            Console.WriteLine(new Customer("Baj", "Ivan", 333, 11));
        }
    }
}