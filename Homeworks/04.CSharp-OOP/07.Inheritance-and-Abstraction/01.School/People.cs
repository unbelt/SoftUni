namespace School
{
    using System;
    using System.Text;

    public abstract class People : ICommentable
    {
        private string name;
        private string details;

        public People(string name, string details = "")
        {
            this.Name = name;
            this.Details = details;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name cannot be null or white space!");
                }

                this.name = value;
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The name cannot be null!");
                }

                this.details = value;
            }
        }

        public override string ToString()
        {
            var print = new StringBuilder();

            print.AppendFormat("{0} name: {1} {2}\r\n", this.GetType().Name, this.name, this.details != string.Empty ? "\r\nDetails: " + this.details : string.Empty);

            return print.ToString();
        }
    }
}