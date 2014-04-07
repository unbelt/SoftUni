using System;
using System.DirectoryServices.AccountManagement;

/* Print Your Name
 *  Modify the previous application to print your name. Ensure you have named the application well (e.g. “PrintMyName”).
 *  You should submit a separate project Visual Studio project holding the PrintMyName class as part of your homework.
*/

class PrintMyName
{
    static void Main()
    {
        // Get currnet user name by using 'AccountManagement' Reference
        string[] name = UserPrincipal.Current.DisplayName.Split(' ');

        // Print First name
        Console.WriteLine("Hello, " + name[0]);
    }
}