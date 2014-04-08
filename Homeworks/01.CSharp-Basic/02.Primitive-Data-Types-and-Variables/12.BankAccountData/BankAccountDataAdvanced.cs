using System;
using System.Text;

/* Bank Account Data Advanced - This is the ADVANCED version of the task!
 *  A bank account has a holder name (first name, middle name and last name), available amount of money (balance),
 *  bank name, IBAN, 3 credit card numbers associated with the account. Declare the variables needed to keep
 *  the information for a single bank account using the appropriate data types and descriptive names.
 */

public class Bank
{
    // Private fields
    private string firstName;
    private string middleName;
    private string lastName;

    private decimal balance;

    private string bankName;
    private string iban;

    private ulong cardNumberOne;
    private ulong cardNumberTwo;
    private ulong cardNumberThree;

    // Constructor
    public Bank(string first, string middle, string last, decimal balance, string bank,
                string iban, ulong cardOne, ulong cardTwo, ulong cardThree)
    {
        this.firstName = first;
        this.middleName = middle;
        this.lastName = last;
        this.balance = balance;
        this.bankName = bank;
        this.iban = iban;
        this.cardNumberOne = cardOne;
        this.cardNumberTwo = cardTwo;
        this.cardNumberThree = cardThree;
    }

    public static Bank BankAccount()
    {
        // Making instance of the Bank, with random values
        Bank account = new Bank("Pesho", "Ivanov", "Petrov", 200.22m, "TBI BANK", "BG80 BNBG 9661 1020 3456 78",
                                 347443242294183, 344715318332002, 340121672891069);
        return account;
    }

    // Overriding ToString() method to print the data
    public override string ToString()
    {
        // Using StringBuilder() for faster building of the strings
        var output = new StringBuilder();

        // Appending data in a printable format
        output.AppendFormat("First Name: {0} \r\n Middle Name: {1} \r\n Last Name: {2} \r\n Balance: {3:C} \r\n Bank Name: {4} \r\n IBAN: {5} \r\n",
                             this.firstName, this.middleName, this.lastName, this.balance, this.bankName, this.iban + Environment.NewLine);

        output.AppendLine("Credit Cards Info:");
        output.AppendFormat(" First Card: {0} \r\n Second Card: {1} \r\n Third Card: {2} \r\n",
                              this.cardNumberOne, this.cardNumberTwo, this.cardNumberThree + Environment.NewLine);

        return output.ToString();
    }
}