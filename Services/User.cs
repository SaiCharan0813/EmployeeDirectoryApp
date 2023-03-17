using EmployeeDirectoryApp.Context;
using EmployeeDirectoryApp.DTO;
using EmployeeDirectoryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmployeeDirectoryApp.Services
{
    public class User
    {
        private readonly EmployeeDirectoryContext _dbContext;
        public User(EmployeeDirectoryContext dbContext) : base()
        {
            _dbContext = dbContext;
        }
        public List<EmployeeDTO> GetAllEmployees()
        {
            var res=_dbContext.Employees.ToList();
            List<EmployeeDTO> emp=new List<EmployeeDTO>();
            foreach(var employee in res)
            {
                EmployeeDTO employeeDTO = new EmployeeDTO {EmployeeId=employee.EmployeeId, FirstName=employee.FirstName.Trim(),LastName=employee.LastName.Trim(),PrefferedName=employee.PrefferedName.Trim(),Email=employee.Email.Trim(),PhoneNumber=employee.PhoneNumber,SkypeId=employee.SkypeId.Trim(),Image=employee.Image};
                employeeDTO.DepartmentId=GetDepartmentNameId(employee.DepartmentId).Trim();
                employeeDTO.OfficeId=GetOfficeNameId(employee.OfficeId).Trim();
                employeeDTO.JobTitleId=GetJobTitleNameId(employee.JobTitleId).Trim();
                emp.Add(employeeDTO);
            }
            return emp;
            
        }
        public Employee GetEmployee(string EmailId)
        {
            return _dbContext.Employees.FirstOrDefault(x => x.Email == EmailId)!;
        }
        public Employee Post([FromBody] EmployeeDTO employee)
        {
            if (employee == null || employee.Email == "" || _dbContext.Employees.FirstOrDefault(e => e.Email == employee.Email) != null)
            {
                return null;
            }
            Employee emp = new Employee { FirstName=employee.FirstName,LastName=employee.LastName,PrefferedName=employee.PrefferedName,Email=employee.Email,PhoneNumber=employee.PhoneNumber,SkypeId=employee.SkypeId,Image=employee.Image};
            emp.DepartmentId = GetDepartmentId(employee.DepartmentId);
            emp.OfficeId = GetOfficeId(employee.OfficeId);
            emp.JobTitleId = GetJobTitleId(employee.JobTitleId);
            _dbContext.Employees.Add(emp);
            _dbContext.SaveChanges();
            return emp;

        }

        public Employee Put(Guid EmployeeId, EmployeeDTO employee)
        {

            var employeeDetails = _dbContext.Employees.FirstOrDefault(e => e.EmployeeId == EmployeeId);
            employeeDetails.FirstName = employee.FirstName;
            employeeDetails.LastName = employee.LastName;
            employeeDetails.PrefferedName = employee.PrefferedName;
            employeeDetails.Email = employee.Email;
            employeeDetails.JobTitleId =GetJobTitleId(employee.JobTitleId);
            employeeDetails.OfficeId = GetOfficeId(employee.OfficeId);
            employeeDetails.DepartmentId = GetDepartmentId(employee.DepartmentId);
            employeeDetails.PhoneNumber = employee.PhoneNumber;
            employeeDetails.SkypeId = employee.SkypeId;
            employeeDetails.Image = employee.Image;
            _dbContext.SaveChanges();
            return employeeDetails;
        }
        public void DeleteEmployee(string EmailId)
        {
            _dbContext.Employees.Remove(_dbContext.Employees.FirstOrDefault(e => e.Email == EmailId));
            _dbContext.SaveChanges();

        }
       public List<Employee> GetEmployeesByDepartment(int DepartmentId)
        {
            var result = _dbContext.Employees.Where(e => e.DepartmentId == DepartmentId);
            return result.ToList();
        }
        
        public List<Employee> GetEmployeesByOffice(int OfficeId)
        {
            var result = _dbContext.Employees.Where(e => e.OfficeId == OfficeId);
            return result.ToList();
        }
        
        public List<Employee> GetEmployeesByJobTitle(int JobTitleId)
        {
            var result = _dbContext.Employees.Where(e => e.JobTitleId == JobTitleId);
            return result.ToList();
        }
        public int GetDepartmentId(string Department) 
        {
        var result = _dbContext.Departments.FirstOrDefault(e => e.DepartmentName == Department);
            return result!.DepartmentId;
        }
        public int GetOfficeId(string Office)
        {
            var result = _dbContext.Offices.FirstOrDefault(e => e.OfficeName == Office);
            return result!.OfficeId;
        }
        public int GetJobTitleId(string JobTitle)
        {
            var result = _dbContext.JobTitles.FirstOrDefault(e => e.JobTitleName == JobTitle);
            return result!.JobTitleId;
        }
        public string GetDepartmentNameId(int DepartmentId)
        {
            var result = _dbContext.Departments.FirstOrDefault(e => e.DepartmentId == DepartmentId);
            return result!.DepartmentName;
        }
        public string GetOfficeNameId(int OfficeId)
        {
            var result = _dbContext.Offices.FirstOrDefault(e => e.OfficeId == OfficeId);
            return result!.OfficeName;
        }
        public string GetJobTitleNameId(int JobTitleId)
        {
            var result = _dbContext.JobTitles.FirstOrDefault(e => e.JobTitleId == JobTitleId);
            return result!.JobTitleName;
        }
       public Dictionary<string,int> GetEmployeesCountByDepartment()
        {
            var results = (from emp in _dbContext.Employees
                           join dep in _dbContext.Departments on emp.DepartmentId equals dep.DepartmentId
                           group emp by new { dep.DepartmentName } into grouped
                           select new
                           {
                               DepartmentName=grouped.Key.DepartmentName.ToString(),
                               Count = grouped.Count()
                           }).ToDictionary(x => x.DepartmentName.Trim(),x=>x.Count);
                       
            return results;

        }
        public Dictionary<string, int> GetEmployeesCountByOffice()
        {
            var results = (from emp in _dbContext.Employees
                           join ofc in _dbContext.Offices on emp.OfficeId equals ofc.OfficeId
                           group emp by new { ofc.OfficeName} into grouped
                           select new
                           {
                               OfficeName = grouped.Key.OfficeName.ToString(),
                               Count = grouped.Count()
                           }).ToDictionary(x => x.OfficeName.Trim(), x => x.Count);

            return results;

        }
        public Dictionary<string, int> GetEmployeesCountByJobTitle()
        {
            var results = (from emp in _dbContext.Employees
                           join jbt in _dbContext.JobTitles on emp.JobTitleId equals jbt.JobTitleId
                           group emp by new { jbt.JobTitleName } into grouped
                           select new
                           {
                               JobTitleName = grouped.Key.JobTitleName.ToString(),
                               Count = grouped.Count()
                           }).ToDictionary(x => x.JobTitleName.Trim(), x => x.Count);

            return results;

        }

    }
    /*
     *  public Dictionary<string,int> GetEmployeesCountByDepartment()
        {
            var results = (from emp in _dbContext.Employees
                           join dep in _dbContext.Departments on emp.DepartmentId equals dep.DepartmentId
                           group emp by new { dep.DepartmentName } into grouped
                           select new
                           {
                               k=grouped.Key.ToString(),
                               v = grouped.Count()
                           }).ToDictionary(x => x.k,x=>x.v);
                       
            return results;

        }
     * 
     * 
     * from emp in (_dbContext.Employees.GroupBy(Department => Department.DepartmentId)).Select(Department=>new {DepartmentId=Department.Key,DepartmentCount=Department.Count()})  join s in _dbContext.Departments on emp.DepartmentId equals s.DepartmentId select new Dictionary<string, int>().Add ( s.DepartmentName, emp.DepartmentCount )  ;*/
}
