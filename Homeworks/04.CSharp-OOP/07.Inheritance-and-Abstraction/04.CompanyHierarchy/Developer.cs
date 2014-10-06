namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Developer : Employee, Interfaces.IDeveloper
    {
        private readonly List<Project> projects;

        public Developer(string firstName, string lastName, int id, double salary, Department department = Department.Production)
            : base(firstName, lastName, id, salary, department)
        {
            this.projects = new List<Project>();
        }

        public Developer AddProjects(params Project[] projects)
        {
            foreach (var project in projects)
            {
                this.projects.Add(project);
            }

            return this;
        }

        public override string ToString()
        {
            var print = new StringBuilder(this.GetType().Name + Environment.NewLine + base.ToString() + Environment.NewLine);

            if (this.projects.Count > 0)
            {  // have projects
                print.AppendFormat("\r\n{0} projects", this.FirstName);
            }

            foreach (var project in this.projects)
            {
                print.AppendLine(project.ToString());
            }

            return print.ToString();
        }
    }
}