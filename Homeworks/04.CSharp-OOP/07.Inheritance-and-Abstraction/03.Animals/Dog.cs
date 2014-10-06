namespace Animals
{
    using System;

    public class Dog : Animal
    {
        public Dog(string name, byte age, Gender gender)
            : base(name, age, gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0} make: Bau-bau!", this.GetType().Name);
        }
    }
}
