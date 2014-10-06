namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;

    public interface IDeveloper : IEmployee
    {
        Developer AddProjects(params Project[] projects);
    }
}