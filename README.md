# Employee Management System - API Documentation

## Overview
This is an employee management system built with ASP.NET Core 8.0, Entity Framework Core, and PostgreSQL. The system manages employees, departments, positions, education levels, and employment statuses.

## Architecture

### Layers
- **Domain**: Core entities and business models
- **Infrastructure**: Data access, repositories, and services
- **API**: REST endpoints (not included in provided code)

### Technology Stack
- .NET 8.0
- Entity Framework Core 8.0
- PostgreSQL (via Npgsql)
- ASP.NET Core Identity

---

## Domain Entities

### Employee
Main entity representing an employee in the system.

**Properties:**
- `Document` (string, PK): Employee identification document
- `FirstNames` (string): First name(s)
- `LastNames` (string): Last name(s)
- `DateOfBirth` (DateTime): Birth date
- `Address` (string): Physical address
- `PhoneNumber` (string): Contact phone
- `Email` (string): Email address
- `PositionId` (int, FK): Reference to Position
- `Salary` (decimal): Current salary
- `HireDate` (DateTime): Date of hire
- `StatusId` (int, FK): Reference to Status
- `EducationLevelId` (int, FK): Reference to EducationLevel
- `ProfessionalProfile` (string): Professional description
- `DepartmentId` (int, FK): Reference to Department
- `UserId` (string, nullable): Link to Identity user
- `CreatedAt` (DateTime): Record creation date
- `UpdatedAt` (DateTime?, nullable): Last update date
- `IsDeleted` (bool): Soft delete flag

### Department
Organizational units within the company.

**Properties:**
- `Id` (int, PK): Department identifier
- `Name` (string): Department name
- `Description` (string?): Optional description
- `CreatedAt` (DateTime): Record creation date
- `Employees` (ICollection<Employee>): Related employees

### Position
Job positions/roles in the company.

**Properties:**
- `Id` (int, PK): Position identifier
- `Name` (string): Position name
- `Description` (string?): Optional description
- `CreatedAt` (DateTime): Record creation date
- `Employees` (ICollection<Employee>): Related employees

### Status
Employment status (Active, Inactive, On Vacation).

**Properties:**
- `Id` (int, PK): Status identifier
- `Name` (string): Status name
- `CreatedAt` (DateTime): Record creation date
- `Employees` (ICollection<Employee>): Related employees

### EducationLevel
Academic/educational qualifications.

**Properties:**
- `Id` (int, PK): Education level identifier
- `Name` (string): Level name
- `Description` (string?): Optional description
- `CreatedAt` (DateTime): Record creation date
- `Employees` (ICollection<Employee>): Related employees

---

## Services

### IEmployeeService
Manages employee operations.

**Methods:**

```csharp
// Get single employee by document
Task<EmployeeDTO> GetEmployeeAsync(string document);

// Get all employees (non-deleted)
Task<List<EmployeeDTO>> GetAllEmployeesAsync();

// Create new employee
Task<EmployeeDTO> CreateEmployeeAsync(CreateEmployeeDTO dto);

// Update existing employee
Task<bool> UpdateEmployeeAsync(string document, UpdateEmployeeDTO dto);

// Soft delete employee
Task<bool> DeleteEmployeeAsync(string document);

// Get total employee count
Task<int> GetTotalEmployeesAsync();

// Get employees by status name
Task<int> GetEmployeesByStatusAsync(string statusName);
```

### IDepartmentService
Manages department operations.

**Methods:**

```csharp
// Get all departments with employee count
Task<List<DepartmentDTO>> GetAllDepartmentsAsync();
```

### IDashboardService
Provides dashboard statistics and query processing.

**Methods:**

```csharp
// Get dashboard statistics
Task<DashboardStatsDTO> GetDashboardStatsAsync();

// Process natural language queries (hardcoded responses)
Task<string> ProcessQueryAsync(string query);
```

### IAuthService
Handles employee authentication.

**Methods:**

```csharp
// Login employee with document and email
Task<string> LoginEmployeeAsync(string document, string email);
```

---

## DTOs (Data Transfer Objects)

### CreateEmployeeDTO
**Required Fields:**
- `Document` (string)
- `FirstNames` (string)
- `LastNames` (string)
- `Email` (string)
- `PhoneNumber` (string)
- `DepartmentId` (int)

**Optional Fields:**
- `DateOfBirth` (DateTime?)
- `Address` (string?)
- `PositionId` (int?)
- `Salary` (decimal?)
- `HireDate` (DateTime?)
- `StatusId` (int?)
- `EducationLevelId` (int?)
- `ProfessionalProfile` (string?)

### UpdateEmployeeDTO
All fields are optional:
- `FirstNames` (string?, max 100 chars)
- `LastNames` (string?, max 100 chars)
- `DateOfBirth` (DateTime?)
- `Address` (string?, max 200 chars)
- `PhoneNumber` (string?, max 20 chars)
- `Email` (string?, email format, max 100 chars)
- `PositionId` (int?)
- `Salary` (decimal?, >= 0)
- `StatusId` (int?)
- `EducationLevelId` (int?)
- `ProfessionalProfile` (string?, max 500 chars)
- `DepartmentId` (int?)

### EmployeeDTO
Complete employee information:
- All employee properties
- Related entity names (PositionName, StatusName, etc.)
- Audit fields (CreatedAt, UpdatedAt)

### DashboardStatsDTO
Dashboard statistics:
- `TotalEmployees` (int)
- `ActiveEmployees` (int)
- `OnVacationEmployees` (int)

---

## Database Seeding

### Default Statuses
1. Active
2. Inactive
3. On Vacation

### Default Education Levels
1. Professional Degree
2. Technologist
3. Master's Degree
4. Technical Degree
5. Specialization

### Default Departments
1. Logistics
2. Marketing
3. Human Resources
4. Operations
5. Sales
6. Technology
7. Accounting

### Default Positions
1. Engineer
2. Technical Support
3. Analyst
4. Coordinator
5. Developer
6. Assistant
7. Administrator

---

## Usage Examples

### Create Employee
```csharp
var createDto = new CreateEmployeeDTO
{
    Document = "123456789",
    FirstNames = "John",
    LastNames = "Doe",
    Email = "john.doe@company.com",
    PhoneNumber = "+1234567890",
    DepartmentId = 6, // Technology
    PositionId = 5,   // Developer
    Salary = 5000.00m,
    HireDate = DateTime.Now,
    StatusId = 1,     // Active
    EducationLevelId = 1 // Professional Degree
};

var employee = await employeeService.CreateEmployeeAsync(createDto);
```

### Update Employee
```csharp
var updateDto = new UpdateEmployeeDTO
{
    Salary = 5500.00m,
    PositionId = 4 // Promoted to Coordinator
};

var success = await employeeService.UpdateEmployeeAsync("123456789", updateDto);
```

### Get Dashboard Stats
```csharp
var stats = await dashboardService.GetDashboardStatsAsync();
// stats.TotalEmployees
// stats.ActiveEmployees
// stats.OnVacationEmployees
```

### Authentication
```csharp
var token = await authService.LoginEmployeeAsync("123456789", "john.doe@company.com");
// Returns JWT token for authenticated sessions
```

---

## Database Configuration

### Connection String Format
```
Host=localhost;Database=TalentoPlusDB;Username=postgres;Password=yourpassword
```

### Apply Migrations
```bash
dotnet ef migrations add InitialCreate --project src/Infrastructure
dotnet ef database update --project src/Infrastructure
```

---

## Key Features

✅ **Soft Delete**: Employees are marked as deleted, not removed from database  
✅ **Audit Trail**: CreatedAt and UpdatedAt timestamps  
✅ **Validation**: Data annotations on DTOs  
✅ **Repository Pattern**: Abstraction layer for data access  
✅ **Service Layer**: Business logic separation  
✅ **Entity Framework Core**: ORM with PostgreSQL  
✅ **ASP.NET Core Identity**: User management integration  
✅ **JWT Authentication**: Token-based authentication

---

## Error Handling

### Common Scenarios

**Employee Already Exists:**
```csharp
throw new Exception($"Empleado con documento {dto.Document} ya existe");
```

**Employee Not Found:**
```csharp
return null; // or throw NotFoundException
```

**Validation Errors:**
- Handled by data annotations on DTOs
- EntityFramework enforces database constraints

---

## Best Practices

1. **Always use DTOs** for API contracts
2. **Validate input** before processing
3. **Use transactions** for multi-step operations
4. **Log exceptions** for debugging
5. **Return appropriate HTTP status codes**
6. **Implement pagination** for large datasets
7. **Cache frequently accessed data**
8. **Use async/await** consistently

---

## Security Considerations

- Passwords should be hashed (using ASP.NET Core Identity)
- JWT tokens should have appropriate expiration
- Validate all user input
- Use HTTPS in production
- Implement rate limiting
- Sanitize SQL inputs (EF Core handles this)

---

## Next Steps

To implement the API layer:

1. Create Controllers for each entity
2. Add authentication middleware
3. Implement authorization policies
4. Add API versioning
5. Document with Swagger/OpenAPI
6. Add unit and integration tests
7. Implement logging (Serilog recommended)
8. Add health checks

---

## Support

For issues or questions:
- Review the code documentation
- Check Entity Framework Core logs
- Validate database connectivity
- Ensure all migrations are applied

---

**Version**: 1.0.0  
**Last Updated**: December 2025  
**Framework**: .NET 8.0