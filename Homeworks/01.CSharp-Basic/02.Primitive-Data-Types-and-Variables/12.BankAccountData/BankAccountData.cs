using System;

/* Bank Account Data
 *  A bank account has a holder name (first name, middle name and last name), available amount of money (balance),
 *  bank name, IBAN, 3 credit card numbers associated with the account. Declare the variables needed to keep
 *  the information for a single bank account using the appropriate data types and descriptive names.
 */

public class BankAccountData
{
    public static void Main()
    {
        string firstName = "Pesho";
        string middleName = "Ivanov";
        string lastName = "Petrov";

        decimal balance = 200.22m; // deciaml for working with money!

        string bankName = "TBI BANK";
        string iban = "BG80 BNBG 9661 1020 3456 78";

        ulong cardNumberOne = 947443242294183;
        ulong cardNumberTwo = 544715318332002;
        ulong cardNumberThree = 340121672891069;

        Console.WriteLine("First Name: {0} \r\n Middle Name: {1} \r\n Last Name: {2} \r\n Balance: {3:C} \r\n Bank Name: {4} \r\n IBAN: {5}",
                           firstName, middleName, lastName, balance, bankName, iban + Environment.NewLine);

        Console.WriteLine("Credit Cards Info:");
        Console.WriteLine(" First Card: {0} \r\n Second Card: {1} \r\n Third Card: {2}",
                            cardNumberOne, cardNumberTwo, cardNumberThree + Environment.NewLine);

        // Console.WriteLine(Bank.BankAccount());
    }
}