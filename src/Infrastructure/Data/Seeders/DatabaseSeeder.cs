using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System; // Required for DateTime.UtcNow

namespace Infrastructure.Data.Seeders
{
    public static class DatabaseSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Statuses (Estados)
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Name = "Active", CreatedAt = DateTime.UtcNow }, // Activo
                new Status { Id = 2, Name = "Inactive", CreatedAt = DateTime.UtcNow }, // Inactivo
                new Status { Id = 3, Name = "On Vacation", CreatedAt = DateTime.UtcNow } // Vacaciones
            );
            
            // Education Levels (Niveles Educativos)
            modelBuilder.Entity<EducationLevel>().HasData(
                new EducationLevel { Id = 1, Name = "Professional Degree", CreatedAt = DateTime.UtcNow }, // Profesional
                new EducationLevel { Id = 2, Name = "Technologist", CreatedAt = DateTime.UtcNow }, // Tecnólogo
                new EducationLevel { Id = 3, Name = "Master's Degree", CreatedAt = DateTime.UtcNow }, // Maestría
                new EducationLevel { Id = 4, Name = "Technical Degree", CreatedAt = DateTime.UtcNow }, // Técnico
                new EducationLevel { Id = 5, Name = "Specialization", CreatedAt = DateTime.UtcNow } // Especialización
            );
            
            // Departments (Departamentos)
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Logistics", CreatedAt = DateTime.UtcNow },
                new Department { Id = 2, Name = "Marketing", CreatedAt = DateTime.UtcNow },
                new Department { Id = 3, Name = "Human Resources", CreatedAt = DateTime.UtcNow }, // Recursos Humanos
                new Department { Id = 4, Name = "Operations", CreatedAt = DateTime.UtcNow }, // Operaciones
                new Department { Id = 5, Name = "Sales", CreatedAt = DateTime.UtcNow }, // Ventas
                new Department { Id = 6, Name = "Technology", CreatedAt = DateTime.UtcNow }, // Tecnología
                new Department { Id = 7, Name = "Accounting", CreatedAt = DateTime.UtcNow } // Contabilidad
            );
            
            // Positions (Cargos)
            modelBuilder.Entity<Position>().HasData(
                new Position { Id = 1, Name = "Engineer", CreatedAt = DateTime.UtcNow }, // Ingeniero
                new Position { Id = 2, Name = "Technical Support", CreatedAt = DateTime.UtcNow }, // Soporte Técnico
                new Position { Id = 3, Name = "Analyst", CreatedAt = DateTime.UtcNow }, // Analista
                new Position { Id = 4, Name = "Coordinator", CreatedAt = DateTime.UtcNow }, // Coordinador
                new Position { Id = 5, Name = "Developer", CreatedAt = DateTime.UtcNow }, // Desarrollador
                new Position { Id = 6, Name = "Assistant", CreatedAt = DateTime.UtcNow }, // Auxiliar
                new Position { Id = 7, Name = "Administrator", CreatedAt = DateTime.UtcNow } // Administrador
            );
        }
    }
}