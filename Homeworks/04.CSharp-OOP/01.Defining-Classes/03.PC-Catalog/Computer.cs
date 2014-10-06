using System;
using System.Collections.Generic;

public class Computer
{
    private string name;
    private List<Component> componets = new List<Component>();
    private decimal price;


    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            Validation.CheckForNullOrEmptyString(value, "name");
            this.name = value;
        }
    }

    public decimal Price
    {
        get
        {
            return this.price;
        }
    }

    public Computer(string name, Component boxPC, Component motherboard, Component hdd, Component procesor, Component graficsCard, Component ram)
    {
        this.Name = name;
        this.componets.Add(boxPC);
        this.componets.Add(motherboard);
        this.componets.Add(hdd);
        this.componets.Add(procesor);
        this.componets.Add(graficsCard);
        this.componets.Add(ram);
        foreach (Component componet in this.componets)
        {
            this.price += componet.Price;
        }
    }

    public Computer(string name, Component boxPC, Component motherboard, Component hdd, Component procesor, Component graficsCard, Component ram, params Component[] componets) :
        this(name, boxPC, motherboard, hdd, procesor, graficsCard, ram)
    {
        this.componets.AddRange(componets);
        foreach (Component componet in componets)
        {
            this.price += componet.Price;
        }
    }

    public void writeToConsole()
    {
        Console.WriteLine("{0} - {1:f2} лв.", this.Name, this.price);
        foreach (var componet in this.componets)
        {
            Console.WriteLine(" - {0} - {1:f2} лв.", componet.Name, componet.Price);
        }
    }
}