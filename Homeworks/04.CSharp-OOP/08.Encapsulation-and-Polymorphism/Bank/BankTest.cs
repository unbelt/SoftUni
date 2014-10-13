namespace Bank
{
    using System;
    using System.Collections.Generic;

    /* A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. 
        • Customers could be individuals or companies.
        • All accounts have customer, balance and interest rate (monthly based). 
        • Deposit accounts are allowed to deposit and withdraw money. Loan and mortgage accounts can only deposit money.
        • All accounts can calculate their interest for a given period (in months) using the formula
          A = money * (1 + interest rate * months) 
        • Loan accounts have no interest for the first 3 months if held by individuals and for the first 2 months if held by a company.
        • Deposit accounts have no interest if their balance is positive and less than 1000.
        • Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the first 6 months for individuals. */

    public class BankTest
    {
        public static void Main()
        {
            Console.WriteLine(new Bank("OBB").AddAccounts(
                new Dispose(new CompanyCustomer("Obama"), 300, 0.02m).Withdraw(150).Deposit(35).Deposit(75),
                new Mortgage(new IndividualCustomer("Pesho"), 500, 0.03m).Deposit(500),
                new Loan(new CompanyCustomer("Osama"), 1000, 0.01m).Deposit(10000)));

            try
            {
                new Mortgage(new IndividualCustomer("Pesho"), 500, 0.03m).Deposit(500).Deposit(-1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            // Interest test
            PrintInterest(new Dispose(new CompanyCustomer("Hulk"), 100, 0.03m), 6);
        }

        public static void PrintInterest(Account acc, decimal months = 6)
        {
            Console.WriteLine("{0} \r\nInterest after {1} months: {2}", acc, months, acc.GetInterest(months).ToString("C"));
        }
    }
}