using System;

/* Employee Data
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

public class EmployeeData
{
    public static void Main()
    {
        string firstName = "Pesho";
        string lastName = "Petrov";
        byte age = 23;
        ulong personalID = 8306112507;
        uint uniqueNumber = 27569999;
        string gender = "Male";

        Console.WriteLine(" First Name: {0} \r\n Last Name: {1} \r\n Age: {2} \r\n Personal ID: {3} \r\n Unique Number: {4} \r\n Gender: {5}",
                            firstName, lastName, age, personalID, uniqueNumber, gender + Environment.NewLine);

        // Console.WriteLine(Employee.EmployeeData());
    }
}
