namespace Animals
{
    using System;

    public abstract class Cat : Animal
    {
        public Cat(string name, byte age, Gender gender)
            : base(name, age, gender)
        {
            if (this.GetType().Name == "Tomcat")
            {
                this.Gender = Gender.Male;
            }
            else
            {
                this.Gender = Gender.Female;
            }
        }
    }
}