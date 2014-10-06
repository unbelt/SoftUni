namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Discipline : School
    {
        private List<Student> students;

        public Discipline(string id, int lectures, string details = "")
            : base(id, details)
        {
            this.NumberOfLecture = lectures;
            this.students = new List<Student>();
        }

        public int NumberOfLecture { get; private set; }

        public Discipline AddStudent(params Student[] students)
        {
            foreach (var student in students)
            {
                this.students.Add(student);
            }

            return this;
        }

        public override string ToString()
        {
            var print = new StringBuilder(base.ToString());

            print.AppendFormat("Number of lectures: {0}\r\n\r\n{1} Class Students\r\n", this.NumberOfLecture, this.Id);

            foreach (var student in this.students)
            {
                print.AppendLine(student.ToString() + Environment.NewLine);
            }

            return print.ToString();
        }
    }
}