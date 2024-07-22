using Application.Features.Countries.Commands.Create;
using Application.Features.Countries.Commands.Delete;
using Application.Features.Countries.Commands.Update;
using Application.Features.Countries.Queries.GetById;
using Application.Features.Countries.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Countries.Queries.GetCitiesByCountryId;

namespace Application.Features.Countries.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCountryCommand, Country>();
        CreateMap<Country, CreatedCountryResponse>();

        CreateMap<UpdateCountryCommand, Country>();
        CreateMap<Country, UpdatedCountryResponse>();

        CreateMap<DeleteCountryCommand, Country>();
        CreateMap<Country, DeletedCountryResponse>();

        CreateMap<Country, GetByIdCountryResponse>();

        CreateMap<Country, GetListCountryListItemDto>();
        CreateMap<IPaginate<Country>, GetListResponse<GetListCountryListItemDto>>();


        CreateMap<City, GetCitiesByCountryIdListItemDto>()
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));

        CreateMap<IPaginate<City>, GetListResponse<GetCitiesByCountryIdListItemDto>>();
    }
}