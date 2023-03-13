using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectoryApp.Models;

public partial class EmployeeDirectoryContext : DbContext
{
    public EmployeeDirectoryContext()
    {
    }

    public EmployeeDirectoryContext(DbContextOptions<EmployeeDirectoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-9RQ7QCJR;Database=EmployeeDirectory;Trusted_Connection=True;Trust Server Certificate = True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Email);

            entity.ToTable("Employee");

            entity.Property(e => e.Email)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Departmet)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Image).HasColumnType("image");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Office)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PhoneNumber).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.PrefferedName)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.SkypeId)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
