namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Teacher : People
    {
        private readonly SortedSet<Discipline> disciplines;

        public Teacher(string name, string details = "")
            : base(name, details)
        {
            this.disciplines = new SortedSet<Discipline>();
        }

        public Teacher AddDiscipline(params Discipline[] disciplines)
        {
            foreach (var discipline in disciplines)
            {
                this.disciplines.Add(discipline);
            }

            return this;
        }

        public override string ToString()
        {
            var print = new StringBuilder(base.ToString());

            foreach (var discipline in this.disciplines)
            {
                print.AppendLine(discipline.ToString() + Environment.NewLine);
            }

            return print.ToString();
        }
    }
}