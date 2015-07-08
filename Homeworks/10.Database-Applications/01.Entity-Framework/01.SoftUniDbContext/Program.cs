namespace SoftUni
{
    using System;

    public class Program
    {
        public static void Main()
        {
            using (var db = new SoftUniEntities())
            {
                //var employee = db.Employees.Find(1);
                //Employee.ModifyEmployee(employee, FirstName: "Gay");

                // TEST
                //Console.WriteLine(db.Employees.Find(1).FirstName);

                // TEST
                //Console.WriteLine(Employee.EntityObjectToString(employee));

                //var emoloyeesWithProjects = Employee.FindAllEmployeesWithProjectsAfter(2002);
                //var emoloyeesWithProjects = Employee.FindAllEmplooyeesWithProjectsSql();


                //foreach (var emp in emoloyeesWithProjects)
                //{
                    // TEST
                    //Console.WriteLine(emp);
                //}

                // TEST
                //Employee.EmployeesByDepartmentAndManager("", "", "")

                // TEST
                //Project.AddNewProject("Nina", DateTime.Now, employeesId: new []{1, 2, 3});

                var projects = Project.GetAllProjectsForGivenEmployee("Gay", "Gilbert");

                foreach (Project project in projects)
                {
                    Console.WriteLine("Name: {0}; Description: {1}; Start Date: {2}; End Date: {3}",
                        project.Name, project.Description ?? "None", project.StartDate, project.EndDate);
                }
            }
        }
    }
}