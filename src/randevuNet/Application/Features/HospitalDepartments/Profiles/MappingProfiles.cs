using Application.Features.HospitalDepartments.Commands.Create;
using Application.Features.HospitalDepartments.Commands.Delete;
using Application.Features.HospitalDepartments.Commands.Update;
using Application.Features.HospitalDepartments.Queries.GetById;
using Application.Features.HospitalDepartments.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.HospitalDepartments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateHospitalDepartmentCommand, Hospital_Department>();
        CreateMap<Hospital_Department, CreatedHospitalDepartmentResponse>();

        CreateMap<UpdateHospitalDepartmentCommand, Hospital_Department>();
        CreateMap<Hospital_Department, UpdatedHospitalDepartmentResponse>();

        CreateMap<DeleteHospitalDepartmentCommand, Hospital_Department>();
        CreateMap<Hospital_Department, DeletedHospitalDepartmentResponse>();

        CreateMap<Hospital_Department, GetByIdHospitalDepartmentResponse>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
            .ForMember(dest => dest.HospitalName, opt => opt.MapFrom(src => src.Hospital.Name));

        CreateMap<Hospital_Department, GetListHospitalDepartmentListItemDto>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
            .ForMember(dest => dest.HospitalName, opt => opt.MapFrom(src => src.Hospital.Name));

        CreateMap<IPaginate<Hospital_Department>, GetListResponse<GetListHospitalDepartmentListItemDto>>();
    }
}