namespace Animals
{
    using System;

    public enum Gender
    {
        Male,
        Female
    }

    public abstract class Animal : ISound
    {
        private string name;
        private byte age;

        public Animal(string name, byte age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
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
                    throw new ArgumentNullException("The name connot be null or empty!");
                }

                this.name = value;
            }
        }

        public byte Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be set to zero or less");
                }

                this.age = value;
            }
        }

        public Gender Gender { get; set; }

        public abstract void ProduceSound();
    }
}