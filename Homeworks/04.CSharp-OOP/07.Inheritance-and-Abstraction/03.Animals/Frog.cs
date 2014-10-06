namespace Animals
{
    using System;

    public class Frog : Animal
    {
        public Frog(string name, byte age, Gender gender)
            : base(name, age, gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0} make: KVAK!", this.GetType().Name);
        }
    }
}
