using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JoinTable.Models
{
    public partial class db_EFCoreContext : DbContext
    {
        public db_EFCoreContext()
        {
        }

        public db_EFCoreContext(DbContextOptions<db_EFCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDepartment> TblDepartments { get; set; }
        public virtual DbSet<TblEmployee> TblEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=db_EFCore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblDepartment>(entity =>
            {
                entity.HasKey(e => e.Deptid)
                    .HasName("PK__tbl_depa__BE2C1AEE148A6897");

                entity.ToTable("tbl_department");

                entity.Property(e => e.Deptid).HasColumnName("deptid");

                entity.Property(e => e.DeptAddedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("deptAddedDate");

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("deptName");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.Empid)
                    .HasName("PK__tbl_Empl__AF4CE865F7B9DAB1");

                entity.ToTable("tbl_Employee");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.EmpDept).HasColumnName("empDept");

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("empName");

                entity.Property(e => e.EmpPhone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("empPhone");

                entity.HasOne(d => d.EmpDeptNavigation)
                    .WithMany(p => p.TblEmployees)
                    .HasForeignKey(d => d.EmpDept)
                    .HasConstraintName("FK__tbl_Emplo__empDe__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
