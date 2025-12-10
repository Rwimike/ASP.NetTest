using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IPositionService, PositionService>();
        services.AddScoped<IStatusService, StatusService>();
        services.AddScoped<IEducationLevelService, EducationLevelService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IDashboardService, DashboardService>();
        
        // Add AutoMapper
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        
        return services;
    }
}

