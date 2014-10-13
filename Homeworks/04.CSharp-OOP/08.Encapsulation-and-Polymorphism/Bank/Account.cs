namespace Bank
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Account
    {
        private decimal balance;
        private decimal interestRate;

        public Account(Customer customer, decimal ballance, decimal interest)
        {
            this.Customer = customer;
            this.Balance = ballance;
            this.InterestRate = interest;
        }

        #region Properties

        public Customer Customer { get; private set; }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            set
            {
                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(null, this.GetType().Name + " interest rate cannot be negative number!");
                }

                this.interestRate = value;
            }
        }
        #endregion

        public Account Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(null, "Deposit amount cannot be negative number!");
            }

            this.Balance += amount;

            return this;
        }

        public virtual decimal GetInterest(decimal months)
        {
            if (months < 0)
            {
                throw new ArgumentOutOfRangeException("The moths cannot be negative number!");
            }

            return this.balance * (1 + (this.interestRate * months));
        }

        public string GetBallance()
        {
            return this.balance.ToString("C");
        }

        public string GetInterestRate()
        {
            return this.interestRate.ToString("P");
        }

        public override string ToString()
        {
            return string.Format("\r\n{0} Account \r\nCustomer: {1} \r\nBalance: {2} \r\nInterest rate: {3}",
                GetType().Name, this.Customer, this.balance.ToString("C"), this.interestRate.ToString("P"));
        }
    }
}