using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Data.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position> // Cargo -> Position
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("positions"); // cargos -> positions
            
            // Primary Key
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            
            // Property Configurations
            builder.Property(p => p.Name) // Nombre -> Name
                .HasMaxLength(50)
                .IsRequired();
                
            builder.Property(p => p.Description) // Descripcion -> Description
                .HasMaxLength(200);
                
            // Indexes
            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}