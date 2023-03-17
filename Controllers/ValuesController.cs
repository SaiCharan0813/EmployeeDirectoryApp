using EmployeeDirectoryApp.Context;
using EmployeeDirectoryApp.DTO;
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
        [Route("api/[controller]")]
        public List<EmployeeDTO> Get()
        {
            User user = new User(_dbContext);
            return user.GetAllEmployees();
        }
        [HttpGet]
        [Route("{Email}")]
        public Employee Get(string EmailId)
        {
            User user = new User(_dbContext);
            return user.GetEmployee(EmailId);
        }
        [HttpPost]
        public Employee Post(EmployeeDTO employee)
        {
            User user = new User(_dbContext);
            return user.Post(employee);
        }

        [HttpPut]
        public Employee Put([FromQuery]Guid EmployeeId ,[FromBody]EmployeeDTO employee)
        { 
            User user = new User(_dbContext);
            return user.Put(EmployeeId, employee);
        }
        [HttpDelete]
        public void DeleteEmployee(string EmailId)
        {
            User user = new User(_dbContext);
            user.DeleteEmployee(EmailId);
        }
        [HttpGet]
        [Route("Department/{Department}")]
        public List<Employee> GetEmployeeByDepartment(int DepartmentId)
        {
            User user = new User(_dbContext);
            return user.GetEmployeesByDepartment(DepartmentId);
        }
        [HttpGet]
        [Route("Office/{Office}")]
        public List<Employee> GetEmployeeByOffice(int OfficeId)
        {
            User user = new User(_dbContext);
            return user.GetEmployeesByOffice(OfficeId);
        }
        [HttpGet]
        [Route("JobTitle/{JobTitle}")]
        public List<Employee> GetEmployeeByJobTitle(int JobTitleId)
        {
            User user = new User(_dbContext);
            return user.GetEmployeesByJobTitle(JobTitleId);
        }
        [HttpGet]
        [Route("api/[controller]/EmployeesDepartment")]
        public Dictionary<string, int> GetEmployeesCountByDepartment()
        {
            User user = new User(_dbContext);
            return user.GetEmployeesCountByDepartment();
        }
        [HttpGet]
        [Route("api/[controller]/EmployeesOffice")]
        public Dictionary<string, int> GetEmployeesCountByOffice()
        {
            User user = new User(_dbContext);
            return user.GetEmployeesCountByOffice();
        }
        [HttpGet]
        [Route("api/[controller]/EmployeesJobTitle")]
        public Dictionary<string, int> GetEmployeesCountByJobTitle()
        {
            User user = new User(_dbContext);
            return user.GetEmployeesCountByJobTitle();
        }
    }
}
