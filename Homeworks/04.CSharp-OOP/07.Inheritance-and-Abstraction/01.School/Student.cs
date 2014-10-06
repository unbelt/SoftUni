namespace School
{
    using System.Text;

    public class Student : People
    {
        public Student(string name,  int id, string details = "") : base(name, details)
        {
            this.UniqueNumber = id;
        }

        public int UniqueNumber { get; private set; }

        public override string ToString()
        {
            var print = new StringBuilder(base.ToString());

            print.AppendFormat("Unique number: {0}", this.UniqueNumber);

            return print.ToString();
        }
    }
}