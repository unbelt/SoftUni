using System;

/* Print Company Information
 *  A company has name, address, phone number, fax number, web site and manager.
 *  The manager has first name, last name, age and a phone number.
 *  Write a program that reads the information about a company and its manager and prints it back on the console.
 */

class PrintCompanyInformation
{
    static void Main()
    {
        #region User Input
        // Company info
        Console.Write("Company name: ");
        string companyName = Console.ReadLine();

        Console.Write("Company address: ");
        string companyAddress = Console.ReadLine();

        Console.Write("Phone number: ");
        string companyPhoneNumber = Console.ReadLine();

        Console.Write("Fax number: ");
        string companyFaxNumber = Console.ReadLine();

        Console.Write("Web site: ");
        string companyWebSite = Console.ReadLine();


        // Manager's info
        Console.Write("Manager first name: ");
        string managerFirstName = Console.ReadLine();

        Console.Write("Manager last name: ");
        string managerLastName = Console.ReadLine();

        Console.Write("Manager age: ");
        int? managerAge = byte.Parse(Console.ReadLine());

        Console.Write("Manager phone: ");
        string managerPhoneNumber = Console.ReadLine();
        #endregion

        Console.WriteLine(@"
                {0}
                Address: {1}
                Tel. {2}
                Fax: {3}
                Web site: {4}
                Manager: {5} {6} (age: {7}, tel. {8})" + Environment.NewLine,
        companyName,
        companyAddress,
        string.IsNullOrWhiteSpace(companyPhoneNumber) ? "(no phone)" : companyPhoneNumber,
        string.IsNullOrWhiteSpace(companyFaxNumber) ? "(no fax)" : companyFaxNumber,
        string.IsNullOrWhiteSpace(companyWebSite) ? "(no web site)" : companyWebSite,
        managerFirstName,
        managerLastName,
        managerAge,
        string.IsNullOrWhiteSpace(managerPhoneNumber) ? "(no phone)" : managerPhoneNumber);

        // Testing PrintCompanyInformation-Advanced
        Company SoftUni = new Company("Software University", "+359 899 55 55 92", "26 V. Kanchev, Sofia", website: "http://softuni.bg");
        Manager Nakov = new Manager("Svetlin", "Nakov", 25, "+359 2 981 981");

        // Console.WriteLine("{0} {1}", SoftUni, Nakov);
    }
}