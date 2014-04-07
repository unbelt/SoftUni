using System;
using System.DirectoryServices.AccountManagement;

/* Print First and Last Name
 *  Create console application that prints your first and last name, each at a separate line.
*/

class PrintFirstAndLastName
{
    static void Main()
    {
        // Get first and last name and splitting by space
        string[] fullName = UserPrincipal.Current.DisplayName.Split(' ');

        // Print First name
        Console.WriteLine(fullName[0]);

        // Print Last name
        Console.WriteLine(fullName[1]);
    }
}