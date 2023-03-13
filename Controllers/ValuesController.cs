using EmployeeDirectoryApp.Models;
using EmployeeDirectoryApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly EmployeeDirectoryContext _dbContext;
        public ValuesController(EmployeeDirectoryContext dbContext) : base()
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public Employee Get(string EmailId)
        {
            User user = new User(_dbContext);
            return user.GetEmployee(EmailId);
        }
        [HttpPost]
        public Employee Post(Employee employee)
        {
            User user = new User(_dbContext);
            return user.Post(employee);
        }

        [HttpPut]
        public Employee Put(string EmailId ,Employee employee)
        { 
            User user = new User(_dbContext);
            return user.Put(EmailId, employee);
        }
        [HttpDelete]
        public void DeleteEmployee(string EmailId)
        {
            User user = new User(_dbContext);
            user.DeleteEmployee(EmailId);
        }
    }
}
