namespace StudentSystem.Data
{
    using System.Diagnostics;
    using System.Data.Entity;

    using Migrations;
    using Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("StudentSystemContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
            Database.Log = s => Debug.WriteLine(s);
            // For testing purpose only!
            //Database.SetInitializer(new DropCreateDatabaseAlways<StudentSystemContext>()); 
            //Database.Initialize(true); // Always initialize database
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Homework> Homeworks { get; set; }
    }
}