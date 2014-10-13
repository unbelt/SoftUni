namespace Bank
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Bank
    {
        private readonly IList<Account> accounts;
        private string name;

        public Bank(string name)
        {
            this.Name = name;
            this.accounts = new List<Account>();
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
                    throw new ArgumentNullException(this.GetType().Name + " name cannot be null or white space!");
                }

                this.name = value;
            }
        }

        public override string ToString()
        {
            var print = new StringBuilder();

            print.AppendLine("Bank: " + this.Name);

            foreach (var account in this.accounts)
            {
                print.AppendLine(account.ToString());
            }

            return print.ToString();
        }

        internal Bank AddAccounts(params Account[] accounts)
        {
            foreach (Account account in accounts)
            {
                this.accounts.Add(account);
            }

            return this;
        }
    }
}