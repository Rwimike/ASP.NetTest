using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Data.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department> // Departamento -> Department
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("departments"); // departamentos -> departments
            
            // Primary Key
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).ValueGeneratedOnAdd();
            
            // Property Configurations
            builder.Property(d => d.Name) // Nombre -> Name
                .HasMaxLength(50)
                .IsRequired();
                
            builder.Property(d => d.Description) // Descripcion -> Description
                .HasMaxLength(200);
                
            // Indexes
            builder.HasIndex(d => d.Name).IsUnique();
        }
    }
}