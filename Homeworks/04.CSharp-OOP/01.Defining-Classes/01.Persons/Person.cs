using System;
using System.Text;

public class Person
{
    private string name;
    private int age;
    private string email;

    public Person(string name, int age, string email = null)
    {
        this.Name = name;
        this.Age = age;
        this.Email = email;
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("value", "The name cannot be null or empty!");
            }

            this.name = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }

        set
        {
            if (value < 1 || value > 100)
            {
                throw new ArgumentOutOfRangeException("value", "The age must be between 1 and 100!");
            }

            this.age = value;
        }
    }

    public string Email
    {

        get
        {
            return this.email;
        }
        set
        {
            if (value != null && !value.Contains("@"))
            {
                throw new ArgumentException("value", "The email is invalid!");
            }

            this.email = value;
        }
    }

    public override string ToString()
    {
        var print = new StringBuilder();

        print.AppendFormat("Name: {0}; Age: {1}{2}",
            this.Name, this.Age, this.Email == null ? string.Empty : "; Email: " + this.Email);

        return print.ToString();
    }
}