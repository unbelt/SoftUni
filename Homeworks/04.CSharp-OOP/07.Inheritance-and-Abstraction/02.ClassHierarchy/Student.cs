namespace ClassHierarchy
{
    using System;
    using System.Text;

    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.facultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Faculty Number cannot be null or white space!");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            var print = new StringBuilder(base.ToString());

            print.AppendFormat("Faculty number: {0}", this.facultyNumber);

            return print.ToString();
        }
    }
}