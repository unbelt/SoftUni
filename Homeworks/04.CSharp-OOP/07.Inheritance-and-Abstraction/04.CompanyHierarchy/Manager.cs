namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Manager : Employee, Interfaces.IManager
    {
        private readonly List<Employee> employees;

        public Manager(string firstName, string lastName, int id, double salary, Department department)
            : base(firstName, lastName, id, salary, department)
        {
            this.employees = new List<Employee>();
        }

        public Manager AddSlaves(params Employee[] emploees)
        {
            foreach (var employee in emploees)
            {
                this.employees.Add(employee);
            }

            return this;
        }

        public override string ToString()
        {
            var print = new StringBuilder(this.GetType().Name + Environment.NewLine + base.ToString() + Environment.NewLine);

            if (this.employees.Count > 0)
            {  // have employees
                print.AppendFormat("\r\n{0} workers:\r\n", this.FirstName);
            }

            foreach (var slave in this.employees)
            {
                print.AppendLine(slave.ToString());
            }

            return print.ToString();
        }
    }
}