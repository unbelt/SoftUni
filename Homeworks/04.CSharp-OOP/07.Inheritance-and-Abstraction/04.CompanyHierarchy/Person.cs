namespace CompanyHierarchy
{
    using System;
    using System.Text;

    public abstract class Person : Interfaces.IPerson
    {
        private string firstName;
        private string lastName;
        private int id;

        public Person(string firstName, string lastName, int id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public string FirstName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The First Name cannot be null or empty!");
                }

                this.lastName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The Last Name cannot be null or empty!");
                }

                this.firstName = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("The ID cannot be less than zero!");
                }

                this.id = value;
            }
        }

        public override string ToString()
        {
            var print = new StringBuilder();

            print.AppendLine(this.lastName + " " + this.firstName);

            return print.ToString();
        }
    }
}