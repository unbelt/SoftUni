namespace CompanyHierarchy
{
    using System;
    using System.Text;

    public class Project
    {
        private string name;
        private string details;
        private bool state = true;

        public Project(string name, DateTime startDate, string details)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.Details = details;

            if (this.state)
            {
                this.State = "open";
            }
            else
            {
                this.State = "closed";
            }
        }

        #region Properties

        public string Details
        {
            get
            {
                return this.details;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Project Details cannot be null or white space!");
                }

                this.details = value;
            }
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
                    throw new ArgumentNullException("The Project Name cannot be null or white space!");
                }

                this.name = value;
            }
        }

        public string State { get; private set; }

        public DateTime StartDate { get; private set; }

        #endregion

        public void CloseProject()
        {
            this.state = false;
        }

        public void OpenProject()
        {
            this.state = true;
        }

        public override string ToString()
        {
            var print = new StringBuilder();

            print.AppendFormat("\r\nName: {0} \r\nStart date: {1} \r\nDetails: {2} \r\nState: {3}", this.name, this.StartDate, this.details, this.State);

            return print.ToString();
        }
    }
}