using System;
using System.Collections.Generic;
using EmployeeDirectoryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectoryApp.Context;

public partial class EmployeeDirectoryContext : DbContext
{
    public EmployeeDirectoryContext()
    {
    }

    public EmployeeDirectoryContext(DbContextOptions<EmployeeDirectoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-9RQ7QCJR;Database=EmployeeDirectory;Trusted_Connection=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(25)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .IsFixedLength();
            entity.Property(e => e.PhoneNumber).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.PrefferedName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.SkypeId)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.ToTable("JobTitle");

            entity.Property(e => e.JobTitleName)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.ToTable("Office");

            entity.Property(e => e.OfficeName)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
