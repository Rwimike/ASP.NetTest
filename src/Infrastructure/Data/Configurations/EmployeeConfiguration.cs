using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees"); // Table name in lowercase plural is common convention
            
            // Primary Key: Documento -> Document
            builder.HasKey(e => e.Document);
            
            // Property Configurations
            builder.Property(e => e.Document)
                .HasMaxLength(20)
                .IsRequired();
                
            builder.Property(e => e.FirstNames) // Nombres -> FirstNames
                .HasMaxLength(100)
                .IsRequired();
                
            builder.Property(e => e.LastNames) // Apellidos -> LastNames
                .HasMaxLength(100)
                .IsRequired();
                
            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsRequired();
                
            builder.Property(e => e.PhoneNumber) // Telefono -> PhoneNumber
                .HasMaxLength(20);
                
            builder.Property(e => e.Address) // Direccion -> Address
                .HasMaxLength(200);
                
            builder.Property(e => e.Salary) // Salario -> Salary
                .HasPrecision(12, 2);
                
            builder.Property(e => e.ProfessionalProfile) // PerfilProfesional -> ProfessionalProfile
                .HasColumnType("text");
                
            // Relationships
            
            // Cargo -> Position (Many Employees belong to one Position)
            builder.HasOne(e => e.Position) // Cargo -> Position
                .WithMany(c => c.Employees) // Empleados -> Employees
                .HasForeignKey(e => e.PositionId) // CargoId -> PositionId
                .OnDelete(DeleteBehavior.Restrict);
                
            // Departamento -> Department
            builder.HasOne(e => e.Department) // Departamento -> Department
                .WithMany(d => d.Employees) // Empleados -> Employees
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Estado -> Status
            builder.HasOne(e => e.Status) // Estado -> Status
                .WithMany(es => es.Employees) // Empleados -> Employees
                .HasForeignKey(e => e.StatusId) // EstadoId -> StatusId
                .OnDelete(DeleteBehavior.Restrict);
                
            // NivelEducativo -> EducationLevel
            builder.HasOne(e => e.EducationLevel) // NivelEducativo -> EducationLevel
                .WithMany(ne => ne.Employees) // Empleados -> Employees
                .HasForeignKey(e => e.EducationLevelId) // NivelEducativoId -> EducationLevelId
                .OnDelete(DeleteBehavior.Restrict);
                
            // Indexes
            builder.HasIndex(e => e.Email).IsUnique();
            builder.HasIndex(e => e.DepartmentId);
            builder.HasIndex(e => e.StatusId);
            builder.HasIndex(e => e.CreatedAt);
        }
    }
}