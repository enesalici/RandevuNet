using Application.Features.Districts.Commands.Create;
using Application.Features.Districts.Commands.Delete;
using Application.Features.Districts.Commands.Update;
using Application.Features.Districts.Queries.GetById;
using Application.Features.Districts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Cities.Queries.GetDistrictsByCityId;
using Application.Features.Districts.Queries.GetQuartersByDistrictId;

namespace Application.Features.Districts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDistrictCommand, District>();
        CreateMap<District, CreatedDistrictResponse>();

        CreateMap<UpdateDistrictCommand, District>();
        CreateMap<District, UpdatedDistrictResponse>();

        CreateMap<DeleteDistrictCommand, District>();
        CreateMap<District, DeletedDistrictResponse>();

        CreateMap<District, GetByIdDistrictResponse>()
            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
            .ForMember(dest => dest.CountryID, opt => opt.MapFrom(src => src.City.CountryID))
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.City.Country.Name));


        CreateMap<District, GetListDistrictListItemDto>()
            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
            .ForMember(dest => dest.CountryID, opt => opt.MapFrom(src => src.City.CountryID))
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.City.Country.Name));

        CreateMap<IPaginate<District>, GetListResponse<GetListDistrictListItemDto>>();

        CreateMap<Quarter, GetQuartersByDistrictIdListItemDto>()
            .ForMember(dest => dest.DistrictID, opt => opt.MapFrom(src => src.DistrictID))
            .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District.Name))
            .ForMember(dest => dest.CityID, opt => opt.MapFrom(src => src.District.CityID))
            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.District.City.Name))
            .ForMember(dest => dest.CountryID, opt => opt.MapFrom(src => src.District.City.CountryID))
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.District.City.Country.Name));

        CreateMap<IPaginate<Quarter>, GetListResponse<GetQuartersByDistrictIdListItemDto>>();
    }
}