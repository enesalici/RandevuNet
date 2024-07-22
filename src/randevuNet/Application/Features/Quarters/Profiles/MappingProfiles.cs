using Application.Features.Quarters.Commands.Create;
using Application.Features.Quarters.Commands.Delete;
using Application.Features.Quarters.Commands.Update;
using Application.Features.Quarters.Queries.GetById;
using Application.Features.Quarters.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Quarters.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateQuarterCommand, Quarter>();
        CreateMap<Quarter, CreatedQuarterResponse>();

        CreateMap<UpdateQuarterCommand, Quarter>();
        CreateMap<Quarter, UpdatedQuarterResponse>();

        CreateMap<DeleteQuarterCommand, Quarter>();
        CreateMap<Quarter, DeletedQuarterResponse>();

        CreateMap<Quarter, GetByIdQuarterResponse>()
            .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District.Name))
            .ForMember(dest => dest.CityID, opt => opt.MapFrom(src => src.District.CityID))
            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.District.City.Name))
            .ForMember(dest => dest.CountryID, opt => opt.MapFrom(src => src.District.City.CountryID))
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.District.City.Country.Name));

        CreateMap<Quarter, GetListQuarterListItemDto>()
            .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District.Name))
            .ForMember(dest => dest.CityID, opt => opt.MapFrom(src => src.District.CityID))
            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.District.City.Name))
            .ForMember(dest => dest.CountryID, opt => opt.MapFrom(src => src.District.City.CountryID))
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.District.City.Country.Name));

        CreateMap<IPaginate<Quarter>, GetListResponse<GetListQuarterListItemDto>>();
    }
}