using Application.Features.Hospitals.Commands.Create;
using Application.Features.Hospitals.Commands.Delete;
using Application.Features.Hospitals.Commands.Update;
using Application.Features.Hospitals.Queries.GetById;
using Application.Features.Hospitals.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Hospitals.Queries.GetDepartmentsByHospitalId;

namespace Application.Features.Hospitals.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateHospitalCommand, Hospital>();
        CreateMap<Hospital, CreatedHospitalResponse>();

        CreateMap<UpdateHospitalCommand, Hospital>();
        CreateMap<Hospital, UpdatedHospitalResponse>();

        CreateMap<DeleteHospitalCommand, Hospital>();
        CreateMap<Hospital, DeletedHospitalResponse>();

        CreateMap<Hospital, GetByIdHospitalResponse>();

        CreateMap<Hospital, GetListHospitalListItemDto>();
        CreateMap<IPaginate<Hospital>, GetListResponse<GetListHospitalListItemDto>>();

        CreateMap<IPaginate<Hospital_Department>, GetListResponse<GetDepartmentsByHospitalIdListItemDto>>();
        CreateMap<Hospital_Department, GetDepartmentsByHospitalIdListItemDto>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
    }
}