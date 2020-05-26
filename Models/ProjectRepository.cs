using IdentityTest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTest.Models
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectDbContext projectDbContext;

        public ProjectRepository(ProjectDbContext db)
        {
            this.projectDbContext = db;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return projectDbContext.Employees.OrderBy(e => e.Name).ToList();
        }
        public IEnumerable<Department> GetDepartments()
        {
            return projectDbContext.Departments.OrderBy(e => e.Name).ToList();
        }
        
        public IEnumerable<Product> GetProducts()
        {
            return projectDbContext.Product.OrderBy(e => e.Name).ToList();
        }

        public bool SaveAll()
        {
            return projectDbContext.SaveChanges() > 0;
        }
    }
}
