using Application.Features.DoctorTitles.Commands.Create;
using Application.Features.DoctorTitles.Commands.Delete;
using Application.Features.DoctorTitles.Commands.Update;
using Application.Features.DoctorTitles.Queries.GetById;
using Application.Features.DoctorTitles.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.DoctorTitles.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDoctorTitleCommand, DoctorTitle>();
        CreateMap<DoctorTitle, CreatedDoctorTitleResponse>();

        CreateMap<UpdateDoctorTitleCommand, DoctorTitle>();
        CreateMap<DoctorTitle, UpdatedDoctorTitleResponse>();

        CreateMap<DeleteDoctorTitleCommand, DoctorTitle>();
        CreateMap<DoctorTitle, DeletedDoctorTitleResponse>();

        CreateMap<DoctorTitle, GetByIdDoctorTitleResponse>();

        CreateMap<DoctorTitle, GetListDoctorTitleListItemDto>();
        CreateMap<IPaginate<DoctorTitle>, GetListResponse<GetListDoctorTitleListItemDto>>();
    }
}