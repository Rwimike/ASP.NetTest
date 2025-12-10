using System;

namespace Domain.Entities
{
    public class Employee
    {
        public string Document { get; set; } = string.Empty;
        public string FirstNames { get; set; } = string.Empty;
        public string LastNames { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Relationships
        public int PositionId { get; set; }
        public Position Position { get; set; } = null!;

        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; } = null!;

        public int EducationLevelId { get; set; }
        public EducationLevel EducationLevel { get; set; } = null!;

        public string ProfessionalProfile { get; set; } = string.Empty;

        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        // Identity
        public string? UserId { get; set; }

        // Auditing
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}