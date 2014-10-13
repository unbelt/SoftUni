namespace Bank
{
    using System;

    public class Loan : Account
    {
        public Loan(Customer customer, decimal ballance, decimal interest)
            : base(customer, ballance, interest)
        {
        }

        public override decimal GetInterest(decimal months)
        {
            if (this.Customer is IndividualCustomer)
            {
                return base.GetInterest(months - 3);
            }

            if (this.Customer is CompanyCustomer)
            {
                return base.GetInterest(months - 2);
            }

            return base.GetInterest(months);
        }
    }
}