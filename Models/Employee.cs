using System;
using System.Collections.Generic;

namespace EmployeeDirectoryApp.Models;

public partial class Employee
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PrefferedName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public string Office { get; set; } = null!;

    public string Departmet { get; set; } = null!;

    public decimal PhoneNumber { get; set; }

    public string SkypeId { get; set; } = null!;

    public byte[] Image { get; set; } = null!;
}
