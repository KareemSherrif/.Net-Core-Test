using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTest.Models.Entities
{
    public class ProjectSeeder
    {
        private readonly ProjectDbContext projectDb;
        private readonly UserManager<Employee> _userManager;

        public ProjectSeeder(ProjectDbContext db, UserManager<Employee> userManager)
        {
            projectDb = db;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            projectDb.Database.EnsureCreated();

            Employee emp = await _userManager.FindByEmailAsync("k.sherrif95@gmail.com");
            if(emp == null)
            {
                emp = new Employee()
                {
                    Name = "Kareem",
                    Address = "Semouha",
                    Email = "K.sherrif95@gmail.com",
                    UserName = "K.sherrif95@gmail.com"
                };

                var result = await _userManager.CreateAsync(emp, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                    throw new Exception("Could not create new user in Seeder");
            }

            if (!projectDb.Departments.Any())
            {
            Department dep = new Department()
                {
                    Name = "IT"
                };
                                
                projectDb.Departments.Add(dep);

            }
            
            if (!projectDb.Product.Any())
            {
            Product product = new Product()
                {
                    Name = "ProductA"
                    
                };
                product.Employee = emp;
                projectDb.Product.Add(product);

            }


            projectDb.SaveChanges();
            
        }
    }
}
