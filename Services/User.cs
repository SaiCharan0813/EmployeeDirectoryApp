using EmployeeDirectoryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectoryApp.Services
{
    public class User
    {
        private readonly EmployeeDirectoryContext _dbContext;
        public User(EmployeeDirectoryContext dbContext) : base()
        {
            _dbContext = dbContext;
        }
        public Employee GetEmployee(string EmailId)
        {
            return _dbContext.Employees.FirstOrDefault(x=>x.Email == EmailId)!;
        }
       public Employee Post([FromBody] Employee employee)
        {

            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return employee;

        }
        public Employee Put(string EmailId,[FromBody] Employee employee)
        {
         
            var employeeDetails = _dbContext.Employees.FirstOrDefault(e => e.Email == EmailId);
            employeeDetails.FirstName = employee.FirstName;
            employeeDetails.LastName = employee.LastName;
            employeeDetails.PrefferedName = employee.PrefferedName;
            employeeDetails.JobTitle = employee.JobTitle;
            employeeDetails.Office = employee.Office;
            employeeDetails.Departmet = employee.Departmet;
            employeeDetails.PhoneNumber = employee.PhoneNumber;
            employeeDetails.SkypeId = employee.SkypeId;
            employeeDetails.Image = employee.Image;
            _dbContext.SaveChanges();
            return employee;
        }
        public void DeleteEmployee(string EmailId)
        {
            _dbContext.Employees.Remove(_dbContext.Employees.FirstOrDefault(e => e.Email == EmailId));
            _dbContext.SaveChanges();
            
        }
      

    }
}
