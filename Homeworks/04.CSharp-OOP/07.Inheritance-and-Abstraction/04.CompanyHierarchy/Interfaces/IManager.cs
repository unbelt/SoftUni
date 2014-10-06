namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;

    public interface IManager : IEmployee
    {
        Manager AddSlaves(params Employee[] employees);
    }
}