using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DTOs.Employees;
using Infrastructure.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // CREATE
        public async Task<EmployeeDTO> CreateEmployeeAsync(CreateEmployeeDTO dto)
        {
            // Validar que el documento no exista
            var exists = await _context.Employees
                .AnyAsync(e => e.Document == dto.Document);
            
            if (exists)
                throw new Exception($"Empleado con documento {dto.Document} ya existe");
            
            // Crear empleado
            var employee = new Employee
            {
                Document = dto.Document,
                FirstNames = dto.FirstNames,
                LastNames = dto.LastNames,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                DateOfBirth = dto.DateOfBirth ?? new DateTime(1990, 1, 1),
                Address = dto.Address ?? "Por definir",
                PositionId = dto.PositionId ?? 1,
                Salary = dto.Salary ?? 1000000,
                HireDate = dto.HireDate ?? DateTime.Now,
                StatusId = dto.StatusId ?? 1,
                EducationLevelId = dto.EducationLevelId ?? 1,
                ProfessionalProfile = dto.ProfessionalProfile ?? string.Empty,
                DepartmentId = dto.DepartmentId,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            };
            
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            
            return await GetEmployeeAsync(employee.Document);
        }
        
        // READ (One)
        public async Task<EmployeeDTO> GetEmployeeAsync(string document)
        {
            var employee = await _context.Employees
                .Include(e => e.Position)
                .Include(e => e.Status)
                .Include(e => e.EducationLevel)
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Document == document && !e.IsDeleted);
            
            if (employee == null) return null;
            
            return MapToDTO(employee);
        }
        
        // READ (All)
        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees
                .Include(e => e.Position)
                .Include(e => e.Status)
                .Include(e => e.EducationLevel)
                .Include(e => e.Department)
                .Where(e => !e.IsDeleted)
                .OrderBy(e => e.LastNames)
                .ThenBy(e => e.FirstNames)
                .ToListAsync();
            
            return employees.Select(MapToDTO).ToList();
        }
        
        // UPDATE
        public async Task<bool> UpdateEmployeeAsync(string document, UpdateEmployeeDTO dto)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Document == document && !e.IsDeleted);
            
            if (employee == null) return false;
            
            // Actualizar campos
            if (!string.IsNullOrEmpty(dto.FirstNames))
                employee.FirstNames = dto.FirstNames;
            
            if (!string.IsNullOrEmpty(dto.LastNames))
                employee.LastNames = dto.LastNames;
            
            if (!string.IsNullOrEmpty(dto.Email))
                employee.Email = dto.Email;
            
            if (!string.IsNullOrEmpty(dto.PhoneNumber))
                employee.PhoneNumber = dto.PhoneNumber;
            
            if (dto.DateOfBirth.HasValue)
                employee.DateOfBirth = dto.DateOfBirth.Value;
            
            if (!string.IsNullOrEmpty(dto.Address))
                employee.Address = dto.Address;
            
            if (dto.PositionId.HasValue)
                employee.PositionId = dto.PositionId.Value;
            
            if (dto.Salary.HasValue)
                employee.Salary = dto.Salary.Value;
            
            if (dto.StatusId.HasValue)
                employee.StatusId = dto.StatusId.Value;
            
            if (dto.EducationLevelId.HasValue)
                employee.EducationLevelId = dto.EducationLevelId.Value;
            
            if (!string.IsNullOrEmpty(dto.ProfessionalProfile))
                employee.ProfessionalProfile = dto.ProfessionalProfile;
            
            if (dto.DepartmentId.HasValue)
                employee.DepartmentId = dto.DepartmentId.Value;
            
            employee.UpdatedAt = DateTime.UtcNow;
            
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            
            return true;
        }
        
        // DELETE (soft delete)
        public async Task<bool> DeleteEmployeeAsync(string document)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Document == document && !e.IsDeleted);
            
            if (employee == null) return false;
            
            employee.IsDeleted = true;
            employee.UpdatedAt = DateTime.UtcNow;
            
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            
            return true;
        }
        
        // Dashboard methods
        public async Task<int> GetTotalEmployeesAsync()
        {
            return await _context.Employees
                .CountAsync(e => !e.IsDeleted);
        }
        
        public async Task<int> GetEmployeesByStatusAsync(string statusName)
        {
            return await _context.Employees
                .Include(e => e.Status)
                .CountAsync(e => !e.IsDeleted && e.Status.Name == statusName);
        }
        
        // Helper method: Map Entity to DTO
        private EmployeeDTO MapToDTO(Employee employee)
        {
            return new EmployeeDTO
            {
                Document = employee.Document,
                FirstNames = employee.FirstNames,
                LastNames = employee.LastNames,
                DateOfBirth = employee.DateOfBirth,
                Address = employee.Address,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                PositionId = employee.PositionId,
                PositionName = employee.Position?.Name ?? string.Empty,
                Salary = employee.Salary,
                HireDate = employee.HireDate,
                StatusId = employee.StatusId,
                StatusName = employee.Status?.Name ?? string.Empty,
                EducationLevelId = employee.EducationLevelId,
                EducationLevelName = employee.EducationLevel?.Name ?? string.Empty,
                ProfessionalProfile = employee.ProfessionalProfile,
                DepartmentId = employee.DepartmentId,
                DepartmentName = employee.Department?.Name ?? string.Empty,
                CreatedAt = employee.CreatedAt,
                UpdatedAt = employee.UpdatedAt
            };
        }
    }
}