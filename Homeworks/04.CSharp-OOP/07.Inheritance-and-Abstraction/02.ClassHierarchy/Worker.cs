namespace ClassHierarchy
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private const byte WorkDays = 5;
        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("You cannot set working hours to zero or less");
                }

                this.workHoursPerDay = value;
            }
        }

        public double WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value <= 200)
                {
                    throw new ArgumentOutOfRangeException("Do not exploit!");
                }

                this.weekSalary = value;
            }
        }

        public double MoneyPerHour()
        {
            return Math.Round(this.weekSalary / WorkDays / this.workHoursPerDay, 2);
        }

        public override string ToString()
        {
            var print = new StringBuilder(base.ToString());

            print.AppendFormat("Week salary: {0}; Money per hour: {1}", this.weekSalary, this.MoneyPerHour().ToString("C"));

            return print.ToString();
        }
    }
}