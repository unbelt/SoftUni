namespace SoftUni
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public partial class Employee
    {
        public static void InsertEmployee(Employee employee)
        {
            using (var db = new SoftUniEntities())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        public static void ModifyEmployee(
            Employee employee,
            string FirstName = null,
            string MiddleName = null,
            string LastName = null,
            string JobTitle = null,
            int? DepartmentID = null,
            int? ManagerID = null,
            DateTime? HireDate = null,
            decimal? Salary = null,
            int? AddressID = null
            )
        {

            using (var db = new SoftUniEntities())
            {
                var emp = db.Employees.Find(employee.EmployeeID);

                if (FirstName != null)
                {
                    emp.FirstName = FirstName;
                }
                if (MiddleName != null)
                {
                    emp.MiddleName = MiddleName;
                }
                if (LastName != null)
                {
                    emp.LastName = LastName;
                }
                if (JobTitle != null)
                {
                    emp.JobTitle = JobTitle;
                }
                if (DepartmentID != null)
                {
                    emp.DepartmentID = (int)DepartmentID;
                }
                if (ManagerID != null)
                {
                    emp.ManagerID = ManagerID;
                }
                if (HireDate != null)
                {
                    emp.HireDate = (DateTime)HireDate;
                }
                if (Salary != null)
                {
                    emp.Salary = (decimal)Salary;
                }
                if (AddressID != null)
                {
                    emp.AddressID = AddressID;
                }

                db.SaveChanges();
            }
        }

        public static void DeleteEmployee(int employeeId)
        {
            using (var db = new SoftUniEntities())
            {
                db.Employees.Remove(db.Employees.Find(employeeId));
                db.SaveChanges();
            }
        }

        public static IEnumerable FindAllEmployeesWithProjectsAfter(int year)
        {
            using (var db = new SoftUniEntities())
            {
                var employees = db.Employees.Where(p => p.Projects.All(q => q.StartDate.Year >= year)).ToList();

                return employees;
            }
        }

        public static IEnumerable FindAllEmplooyeesWithProjectsSql()
        {
            var query = @"SELECT *
                              FROM [SoftUni].[dbo].[Employees] e
                              JOIN EmployeesProjects ep
                              ON e.EmployeeID = ep.EmployeeID
                              JOIN Projects p
                              ON p.ProjectID = ep.ProjectID
                              WHERE YEAR(p.StartDate) >= 2002";

            using (var db = new SoftUniEntities())
            {
                var emoloyeesWithProjects = db.Database.SqlQuery<Employee>(query).ToList();
                var employees = new Dictionary<int, string>();

                foreach (var employee in emoloyeesWithProjects)
                {
                    if (!employees.ContainsKey(employee.EmployeeID))
                    {
                        employees.Add(employee.EmployeeID, String.Format("{0} {1}", employee.FirstName, employee.LastName));
                    }
                }

                return employees;
            }
        }

        public static string EntityObjectToString(object obj)
        {
            var output = new StringBuilder();
            foreach (var prop in obj.GetType().GetProperties())
            {
                output.AppendFormat("{0}  {1}\r\n",
                  prop.Name,
                  prop.GetValue(obj, null));
            }

            return output.ToString();
        }

        public static ICollection EmployeesByDepartmentAndManager(string departmentName, string managerFirstName, string managerLastName)
        {
            using (var db = new SoftUniEntities())
            {
                var employees = db.Employees.Where(p => p.Departments.All(q => q.Name == departmentName)
                    && p.FirstName == managerFirstName && p.LastName == managerLastName).ToList();
                return employees;
            }
        }


    }
}