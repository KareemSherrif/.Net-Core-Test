using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTest.Models.Entities
{
    public class Employee : IdentityUser
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
