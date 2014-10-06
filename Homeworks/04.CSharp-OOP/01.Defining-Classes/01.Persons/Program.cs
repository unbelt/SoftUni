using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        var persons = new List<Person> {

            new Person("Gosho", 22, "gosho@abv.bg"),
            new Person("Pesho", 23),
            new Person("Maria", 35, "maria.petrova@mail.bg")
        };

        foreach (var person in persons)
        {
            Console.WriteLine(person.ToString());
        }


        try
        {
            Console.WriteLine(new Person("Ivan", 33, "ivancho"));
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The email is not correct!");
        }
    }
}