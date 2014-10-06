namespace CompanyHierarchy
{
    using System;
    using System.Text;

    public class Sale
    {
        private string name;
        private double price;

        public Sale(string name, DateTime date, double price)
        {
            this.Name = name;
            this.Date = date;
            this.Price = price;
        }

        public double Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The price cannot be less than zero!");
                }

                this.price = value;
            }
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
                    throw new ArgumentNullException("The name cannot be null or white space!");
                }

                this.name = value;
            }
        }

        public DateTime Date { get; private set; }

        public override string ToString()
        {
            var print = new StringBuilder();

            print.AppendFormat("\r\nName: {0} \r\nDate: {1} \r\nPrice: {2}", this.name, this.Date, this.price.ToString("C"));

            return print.ToString();
        }
    }
}