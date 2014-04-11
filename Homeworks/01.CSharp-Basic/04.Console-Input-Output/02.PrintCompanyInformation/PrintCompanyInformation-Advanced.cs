using System;
using System.Text;

/* Print Company Information - ADVANCED
 *  A company has name, address, phone number, fax number, web site and manager.
 *  The manager has first name, last name, age and a phone number.
 *  Write a program that reads the information about a company and its manager and prints it back on the console.
 */

public class Company
{
    // using public constructor with some default values
    public Company(string name, string phone = "(no phone)", string address = null,
                   string fax = "(no fax)", string website = "(no website)")
    {
        this.Name = name;
        this.Address = address;
        this.Tel = phone;
        this.Fax = fax;
        this.Website = website;
    }

    #region Properties
    public string Name { get; set; }

    public string Address { get; set; }

    public string Tel { get; set; }

    public string Fax { get; set; }

    public string Website { get; set; }
    #endregion

    // using ToString() method to print the data
    public override string ToString()
    {
        // using StringBuilder() class for better performance
        var print = new StringBuilder();

        print.AppendFormat(" {0} \r\n Address: {1} \r\n Tel. {2} \r\n Fax: {3} \r\n Web site: {4} \r\n",
            this.Name, this.Address, this.Tel, this.Fax, this.Website);

        return print.ToString();
    }
}

public class Manager : Company // Class that inherit Company
{
    // Constructor
    public Manager(string name, string lastName, int age, string phone)
        : base(name, phone) // Reusing some of the base constructor implementations
    {
        this.LastName = lastName;
        this.Age = age;
    }

    #region Properties
    public string LastName { get; set; }

    public int Age { get; set; }
    #endregion
    
    // ToString() method overriding the base one
    public override string ToString()
    {
        var print = new StringBuilder();

        print.AppendFormat("{0}: {1} {2} (age: {3}, tel. {4})",
            GetType().Name, this.Name, this.LastName, this.Age, this.Tel);

        return print.ToString();
    }
}