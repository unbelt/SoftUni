namespace Bank
{
    using System;

    public class Mortgage : Account
    {
        public Mortgage(Customer customer, decimal ballance, decimal interest)
            : base(customer, ballance, interest)
        {
        }

        public override decimal GetInterest(decimal months)
        {
            if (this.Customer is IndividualCustomer)
            {
                return base.GetInterest(months - 6);
            }

            if (this.Customer is CompanyCustomer && months < 13)
            {
                return base.GetInterest(months);
            }

            return base.GetInterest(months);
        }
    }
}