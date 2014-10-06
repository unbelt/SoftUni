namespace School
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class School : ICommentable, IEnumerable
    {
        private readonly SortedSet<Class> classes;

        private string id;
        private string details;

        public School(string id, string details = "")
        {
            this.Id = id;
            this.Details = details;
            this.classes = new SortedSet<Class>();
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

        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name cannot be null or white space!");
                }

                this.id = value;
            }
        }

        public School AddClass(params Class[] classes)
        {
            foreach (var _class in classes)
            {
                this.classes.Add(_class);
            }

            return this;
        }

        public IEnumerator GetEnumerator()
        {
            return this.classes.GetEnumerator();
        }

        public override string ToString()
        {
            var print = new StringBuilder();

            print.AppendFormat("{0} name: {1} {2}\r\n", this.GetType().Name, this.id, this.details != string.Empty ? "\r\nDetails: " + this.details : string.Empty);

            foreach (var _class in this.classes)
            {
                print.AppendFormat("\r\n{0}\r\n", _class.ToString());
            }

            return print.ToString();
        }
    }
}