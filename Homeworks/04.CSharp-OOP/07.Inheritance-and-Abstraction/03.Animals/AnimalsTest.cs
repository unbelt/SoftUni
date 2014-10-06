namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /* Create an abstract class Animal holding name, age and gender.
        • Create a hierarchy with classes Dog, Frog, Cat, Kitten and Tomcat. Dogs, frogs and cats are animals.
          Kittens are female cats and Tomcats are male cats. Define useful constructors and methods. 
        • Define an interface ISound which implements the method ProduceSound(). All animals should implement this interface.
          The ProduceSound() method should produce a specific sound according to the animal (e.g. the dog should bark).
        • Create arrays of different kinds of animals and calculate the average age of each kind of animal using LINQ. */

    public class AnimalsTest
    {
        public static void Main()
        {
            var animals = new List<Animal>()
            {
                new Dog("Sharo", 12, Gender.Male),
                new Frog("Lilly", 52, Gender.Female),
                new Tomcat("Tommy", 2),
                new Kitten("Pepi", 3)
            };

            foreach (var animal in animals)
            {
                animal.ProduceSound();
            }

            // Get average animal age
            Console.WriteLine(Environment.NewLine + "Average age: {0}",
                (from a in animals select (decimal)a.Age).Average());
        }
    }
}