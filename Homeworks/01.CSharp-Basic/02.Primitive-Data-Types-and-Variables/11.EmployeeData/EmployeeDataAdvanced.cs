using System;
using System.Text;

/* Employee Data Advanced - This is the ADVANCED version of the task!
 *  A marketing company wants to keep record of its employees. Each record would have the following characteristics:
 *      • First name
 *      • Last name
 *      • Age (0...100)
 *      • Gender (m or f)
 *      • Personal ID number (e.g. 8306112507)
 *      • Unique employee number (27560000…27569999)
 *  Declare the variables needed to keep the information for a single employee using appropriate primitive data types.
 *  Use descriptive names. Print the data at the console.
 */

public struct Employee // Using Structure for keeping the data
{
    // Structure fields
    public bool IsMale;
    public string FirstName;
    public string LastName;
    public byte Age;
    public ulong PersonalID;
    public uint UniqueNumber;

    public static Employee EmployeeData()
    {
        Employee employee = new Employee();
        employee.FirstName = "Pesho";
        employee.LastName = "Petrov";
        employee.Age = 23;
        employee.PersonalID = 8306112507;
        employee.UniqueNumber = 27569999;
        employee.IsMale = true;

        return employee;
    }

    // Overriding ToString() method to print the data
    public override string ToString()
    {
        // Using StringBuilder() for faster building of the strings
        var output = new StringBuilder();

        // Appending data in a printable format
        output.AppendFormat(" First Name: {0} \r\n Last Name: {1} \r\n Age: {2} \r\n Personal ID: {3} \r\n Unique Number: {4} \r\n Gender: {5}",
                              this.FirstName, this.LastName, this.Age, this.PersonalID, this.UniqueNumber, this.IsMale ? "Male" : "Female");

        return output.ToString();
    }
}