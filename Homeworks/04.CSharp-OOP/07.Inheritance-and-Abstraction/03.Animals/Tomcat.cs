namespace Animals
{
    using System;

    public class Tomcat : Cat
    {
        public Tomcat(string name, byte age, Gender gender = Gender.Male)
            : base(name, age, gender)
        {
            this.Name = name;
            this.Age = age;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0} make: MQU!", this.GetType().Name);
        }
    }
}