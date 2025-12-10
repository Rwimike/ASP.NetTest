using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Data.Configurations
{
    public class EducationLevelConfiguration : IEntityTypeConfiguration<EducationLevel> // NivelEducativo -> EducationLevel
    {
        public void Configure(EntityTypeBuilder<EducationLevel> builder)
        {
            builder.ToTable("education_levels"); // niveles_educativos -> education_levels
            
            // Primary Key
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            
            // Property Configurations
            builder.Property(e => e.Name) // Nombre -> Name
                .HasMaxLength(30)
                .IsRequired();
                
            builder.Property(e => e.Description) // Descripcion -> Description
                .HasMaxLength(200);
                
            // Indexes
            builder.HasIndex(e => e.Name).IsUnique();
        }
    }
}