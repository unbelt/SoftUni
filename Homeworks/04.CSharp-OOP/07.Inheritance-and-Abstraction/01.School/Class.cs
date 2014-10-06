namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Class : School
    {
        private readonly List<Teacher> teachers;

        public Class(string id, string details = "") : base(id, details)
        {
            this.teachers = new List<Teacher>();
        }

        public Class AddTeacher(params Teacher[] teachers)
        {
            foreach (var teacher in teachers)
            {
                this.teachers.Add(teacher);
            }

            return this;
        }

        public override string ToString()
        {
            var print = new StringBuilder(base.ToString() + Environment.NewLine + this.Id + " Teachers\r\n");

            foreach (var teacher in this.teachers)
            {
                print.AppendLine(teacher.ToString() + Environment.NewLine);
            }

            return print.ToString();
        }
    }
}