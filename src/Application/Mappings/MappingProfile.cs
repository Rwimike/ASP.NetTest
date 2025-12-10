using AutoMapper;
using Application.DTOs.Employees;
using Application.DTOs.Departments;
using Application.DTOs.Positions;
using Application.DTOs.Status;
using Application.DTOs.EducationLevels;
using Domain.Entities;

namespace Application.Mappings
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
            CreateMap<EducationLevel, EducationLevelDto>()
                .ForMember(dest => dest.EmployeeCount, opt => opt.MapFrom(src => src.Employees.Count));
        }
    }
}