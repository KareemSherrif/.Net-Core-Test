using IdentityTest.Models.Entities;
using System.Collections.Generic;

namespace IdentityTest.Models
{
    public interface IProjectRepository
    {
        IEnumerable<Department> GetDepartments();
        IEnumerable<Employee> GetEmployees();

        bool SaveAll();
    }
}