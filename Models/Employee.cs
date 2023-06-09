﻿using System;
using System.Collections.Generic;

namespace EmployeeDirectoryApp.Models;

public partial class Employee
{
    public Guid EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PrefferedName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int JobTitleId { get; set; }

    public int OfficeId { get; set; }

    public int DepartmentId { get; set; }

    public decimal PhoneNumber { get; set; }

    public string SkypeId { get; set; } = null!;

    public string Image { get; set; } = null!;
}
