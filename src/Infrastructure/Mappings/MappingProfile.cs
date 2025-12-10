using AutoMapper;
using Infrastructure.DTOs.Employees;
using Infrastructure.DTOs.Departments;
using Infrastructure.DTOs.Positions;
using Infrastructure.DTOs.Status;
using Infrastructure.DTOs.EducationLevels;
using Domain.Entities;

namespace Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Employee mappings
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position.Name))
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.Name))
                .ForMember(dest => dest.EducationLevelName, opt => opt.MapFrom(src => src.EducationLevel.Name))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
            
            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<UpdateEmployeeDTO, Employee>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            
            // Department mappings
            CreateMap<Department, DepartmentDTO>()
                .ForMember(dest => dest.EmployeeCount, opt => opt.MapFrom(src => src.Employees.Count));
            
            CreateMap<CreateDepartmentDTO, Department>();
            
            // Position mappings
            CreateMap<Position, PositionDTO>()
                .ForMember(dest => dest.EmployeeCount, opt => opt.MapFrom(src => src.Employees.Count));
            
            // Status mappings
            CreateMap<Status, StatusDTO>()
                .ForMember(dest => dest.EmployeeCount, opt => opt.MapFrom(src => src.Employees.Count));
            
            // EducationLevel mappings
            CreateMap<EducationLevel, EducationLevelDTO>()
                .ForMember(dest => dest.EmployeeCount, opt => opt.MapFrom(src => src.Employees.Count));
        }
    }
}