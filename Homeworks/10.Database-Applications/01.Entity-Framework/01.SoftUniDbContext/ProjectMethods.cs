namespace SoftUni
{
    using System;
    using System.Data.Entity.Infrastructure;

    public partial class Project
    {
        public static void AddNewProject(
            string projectName,
            DateTime startDate,
            DateTime? endDate = null,
            string projectDescription = null,
            params int[] employeesId
            )
        {
            var project = new Project
            {
                Name = projectName,
                Description = projectDescription,
                StartDate = startDate,
                EndDate = endDate,
            };

            using (var db = new SoftUniEntities())
            {

                foreach (var id in employeesId)
                {
                    project.Employees.Add(db.Employees.Find(id));
                }

                db.Projects.Add(project);
                db.SaveChanges();
            }
        }

        public static DbRawSqlQuery<Project> GetAllProjectsForGivenEmployee(string firstName, string lastName)
        {
                var db = new SoftUniEntities();
                var projects = db.Database.SqlQuery<Project>("upsGetAllProjectsForGivenEmployee @firstName = {0}, @lastName = {1}", firstName, lastName);

                return projects;
        }
    }
}