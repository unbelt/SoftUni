namespace Bank
{
    public abstract class Customer : Bank
    {
        public Customer(string name)
            : base(name)
        {
        }

        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }
    }
}