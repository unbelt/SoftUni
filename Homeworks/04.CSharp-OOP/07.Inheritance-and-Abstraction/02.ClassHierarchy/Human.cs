namespace ClassHierarchy
{
    using System;
    using System.Text;

    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First Name cannot be null or white space!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last Name cannot be null or white space!");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            var print = new StringBuilder();

            print.AppendLine(this.firstName + " " + this.lastName);

            return print.ToString();
        }
    }
}