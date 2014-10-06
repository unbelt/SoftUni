namespace Animals
{
    using System;

    public class Kitten : Cat
    {
        public Kitten(string name, byte age, Gender gender = Gender.Female)
            : base(name, age, gender)
        {
            this.Name = name;
            this.Age = age;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0} make: Meeeww..", this.GetType().Name);
        }
    }
}
