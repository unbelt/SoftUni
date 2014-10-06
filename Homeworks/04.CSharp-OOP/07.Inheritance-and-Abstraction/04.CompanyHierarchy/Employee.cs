namespace CompanyHierarchy
{
    using System;
    using System.Text;

    public enum Department
    {
        Production,
        Accounting,
        Sales,
        Marketing
    }

    public abstract class Employee : Person, Interfaces.IEmployee
    {
        private double salary;

        public Employee(string firstName, string lastName, int id, double salary, Department department)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public double Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Do not exploit! The salary cannot be zero or less!");
                }

                this.salary = value;
            }
        }

        public Department Department { get; set; }

        public override string ToString()
        {
            var print = new StringBuilder(base.ToString());

            print.AppendFormat("Salary: {0} \r\nDepartment: {1}", this.salary.ToString("C"), this.Department);

            return print.ToString();
        }
    }
}