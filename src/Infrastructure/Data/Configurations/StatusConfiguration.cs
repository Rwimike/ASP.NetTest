using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Data.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status> // Estado -> Status
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("statuses"); // estados -> statuses
            
            // Primary Key
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            
            // Property Configurations
            builder.Property(s => s.Name) // Nombre -> Name
                .HasMaxLength(20)
                .IsRequired();
                
            // Indexes
            builder.HasIndex(s => s.Name).IsUnique();
        }
    }
}