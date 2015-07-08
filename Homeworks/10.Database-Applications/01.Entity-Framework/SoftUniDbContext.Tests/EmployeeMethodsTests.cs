using System.Linq;

namespace SoftUniDbContext.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SoftUni;

    [TestClass]
    public class EmployeeMethodsTests
    {

        private SoftUniEntities db;
        private Employee employee;

        [TestInitialize]
        public void Initialize()
        {
            this.db = new SoftUniEntities();
            this.employee = new Employee
            {
                EmployeeID = int.MaxValue,
                FirstName = "Test",
                MiddleName = "User",
                LastName = "Name",
                DepartmentID = 1,
                JobTitle = "CCleaner",
                HireDate = new DateTime(2000, 03, 07),
                Salary = 2000.50m
            };
        }


        [TestMethod]
        public void TestAddEditDeleteEmployee()
        {
            Employee.InsertEmployee(employee);

            try
            {
                var savedEmployee = db.Employees.First(e => e.FirstName == "Test");

                Assert.AreEqual(savedEmployee.FirstName, employee.FirstName);
                Assert.AreEqual(savedEmployee.MiddleName, employee.MiddleName);
                Assert.AreEqual(savedEmployee.LastName, employee.LastName);
                Assert.AreEqual(savedEmployee.DepartmentID, employee.DepartmentID);
                Assert.AreEqual(savedEmployee.JobTitle, employee.JobTitle);
                Assert.AreEqual(savedEmployee.HireDate, employee.HireDate);
                Assert.AreEqual(savedEmployee.Salary, employee.Salary);
            }
            finally
            {
                Employee.DeleteEmployee(employee.EmployeeID);
            }
        }

        [TestMethod]
        public void TestEditEmployee()
        {
            Employee.InsertEmployee(employee);

            try
            {
                Employee.ModifyEmployee(employee, LastName: "Last");

                var modifiedEmployee = db.Employees.First(e => e.LastName == "Last");
                Assert.AreEqual(modifiedEmployee.LastName, "Last");
            }
            finally
            {
                Employee.DeleteEmployee(employee.EmployeeID);
            }
        }
    }
}