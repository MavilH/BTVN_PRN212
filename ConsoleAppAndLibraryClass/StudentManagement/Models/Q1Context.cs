using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Models.Models;

public partial class Q1Context : DbContext
{
    public Q1Context()
    {
    }

    public Q1Context(DbContextOptions<Q1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ContractEmployee> ContractEmployees { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<JoinProject> JoinProjects { get; set; }

    public virtual DbSet<PermanentEmployee> PermanentEmployees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DBDefault");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContractEmployee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Contract__AFB3EC6D4C04B00B");

            entity.ToTable("Contract Employees");

            entity.Property(e => e.EmpId)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("empID");
            entity.Property(e => e.DailyPay)
                .HasColumnType("money")
                .HasColumnName("dailyPay");
            entity.Property(e => e.NumberOfDays).HasColumnName("numberOfDays");

            entity.HasOne(d => d.Emp).WithOne(p => p.ContractEmployee)
                .HasForeignKey<ContractEmployee>(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contract __empID__3B75D760");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AFB3EC6DC4C7F98F");

            entity.Property(e => e.EmpId)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("empID");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("phone");
        });

        modelBuilder.Entity<JoinProject>(entity =>
        {
            entity.HasKey(e => new { e.EmpId, e.ProjId }).HasName("PK__Join Pro__9C52417F201C3C3A");

            entity.ToTable("Join Project");

            entity.Property(e => e.EmpId)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("empID");
            entity.Property(e => e.ProjId).HasColumnName("projID");
            entity.Property(e => e.StartDate).HasColumnName("startDate");

            entity.HasOne(d => d.Emp).WithMany(p => p.JoinProjects)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Join Proj__empID__403A8C7D");

            entity.HasOne(d => d.Proj).WithMany(p => p.JoinProjects)
                .HasForeignKey(d => d.ProjId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Join Proj__projI__412EB0B6");
        });

        modelBuilder.Entity<PermanentEmployee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Permanen__AFB3EC6D1D6E0AEE");

            entity.Property(e => e.EmpId)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("empID");
            entity.Property(e => e.BaseSalary)
                .HasColumnType("money")
                .HasColumnName("baseSalary");
            entity.Property(e => e.SalaryScale).HasColumnName("salaryScale");

            entity.HasOne(d => d.Emp).WithOne(p => p.PermanentEmployee)
                .HasForeignKey<PermanentEmployee>(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Permanent__empID__38996AB5");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjId).HasName("PK__Projects__3E1AD12219FE7530");

            entity.Property(e => e.ProjId)
                .ValueGeneratedNever()
                .HasColumnName("projID");
            entity.Property(e => e.ProjName)
                .HasMaxLength(200)
                .HasColumnName("projName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
