using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityTest.Models;
using IdentityTest.Models.Entities;
using IdentityTest.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IdentityTest.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeeController : ControllerBase
    {
        private readonly IProjectRepository repo;
        private readonly ILogger<EmployeeController> logger;

        public EmployeeController(IProjectRepository repo, ILogger<EmployeeController> logger)
        {
            this.repo = repo;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
            return Ok(repo.GetEmployees());
            }
            catch
            {
                return BadRequest("not working");
            }
        }


    }
}