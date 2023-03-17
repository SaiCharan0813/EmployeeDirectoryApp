﻿namespace EmployeeDirectoryApp.DTO
{
    public class EmployeeDTO
    {
        public Guid EmployeeId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PrefferedName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string JobTitleId { get; set; }

        public string OfficeId { get; set; }

        public string DepartmentId { get; set; }

        public decimal PhoneNumber { get; set; }

        public string SkypeId { get; set; } = null!;

        public string Image { get; set; } = null!;
    }
}
