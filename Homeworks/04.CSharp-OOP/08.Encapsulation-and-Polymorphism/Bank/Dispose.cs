namespace Bank
{
    using System;
    using System.Text;

    public class Dispose : Account, IDisposable
    {
        public Dispose(Customer customer, decimal balance, decimal interest)
            : base(customer, balance, interest)
        {
        }

        public override decimal GetInterest(decimal months)
        {
            if (this.Balance < 0 && this.Balance < 1000)
            {
                return 0;
            }

            return base.GetInterest(months);
        }

        public Account Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(null, "The withdrawing amount cannot be negative number!");
            }

            this.Balance -= amount;

            return this;
        }
    }
}