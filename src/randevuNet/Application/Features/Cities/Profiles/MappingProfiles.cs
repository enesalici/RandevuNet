using Application.Features.Cities.Commands.Create;
using Application.Features.Cities.Commands.Delete;
using Application.Features.Cities.Commands.Update;
using Application.Features.Cities.Queries.GetById;
using Application.Features.Cities.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Countries.Queries.GetCitiesByCountryId;
using Application.Features.Cities.Queries.GetDistrictsByCityId;

namespace Application.Features.Cities.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCityCommand, City>();
        CreateMap<City, CreatedCityResponse>();

        CreateMap<UpdateCityCommand, City>();
        CreateMap<City, UpdatedCityResponse>();

        CreateMap<DeleteCityCommand, City>();
        CreateMap<City, DeletedCityResponse>();

        CreateMap<City, GetByIdCityResponse>()
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));


        CreateMap<City, GetListCityListItemDto>()
                   .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));
        CreateMap<IPaginate<City>, GetListResponse<GetListCityListItemDto>>();

        CreateMap<District, GetDistrictsByCityIdListItemDto>()
           .ForMember(dest => dest.CityID, opt => opt.MapFrom(src => src.CityID))
           .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
           .ForMember(dest => dest.CountryID, opt => opt.MapFrom(src => src.City.CountryID))
           .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.City.Country.Name));

        CreateMap<IPaginate<District>, GetListResponse<GetDistrictsByCityIdListItemDto>>();

    }
}