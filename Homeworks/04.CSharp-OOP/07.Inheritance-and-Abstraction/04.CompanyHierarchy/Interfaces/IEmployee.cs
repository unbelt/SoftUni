namespace CompanyHierarchy.Interfaces
{
    public interface IEmployee : IPerson
    {
        double Salary { get; set; }

        Department Department { get; set; }
    }
}