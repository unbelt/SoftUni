namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SalesEmployee : Employee, Interfaces.IEmployee
    {
        private readonly List<Sale> sales;

        public SalesEmployee(string firstName, string lastName, int id, double salary, Department department = Department.Sales)
            : base(firstName, lastName, id, salary, department)
        {
            this.sales = new List<Sale>();
        }

        public SalesEmployee AddSales(params Sale[] sales)
        {
            foreach (var sale in sales)
            {
                this.sales.Add(sale);
            }

            return this;
        }

        public override string ToString()
        {
            var print = new StringBuilder(this.GetType().Name + Environment.NewLine + base.ToString() + Environment.NewLine);

            if (this.sales.Count > 0)
            {  // have sales
                print.AppendFormat("\r\n{0} sales", this.FirstName);
            }

            foreach (var sale in this.sales)
            {
                print.AppendLine(sale.ToString());
            }

            return print.ToString();
        }
    }
}