using Application.Features.HospitalAddresses.Commands.Create;
using Application.Features.HospitalAddresses.Commands.Delete;
using Application.Features.HospitalAddresses.Commands.Update;
using Application.Features.HospitalAddresses.Queries.GetById;
using Application.Features.HospitalAddresses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.HospitalAddresses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateHospitalAddressCommand, HospitalAddress>();
        CreateMap<HospitalAddress, CreatedHospitalAddressResponse>();

        CreateMap<UpdateHospitalAddressCommand, HospitalAddress>();
        CreateMap<HospitalAddress, UpdatedHospitalAddressResponse>();

        CreateMap<DeleteHospitalAddressCommand, HospitalAddress>();
        CreateMap<HospitalAddress, DeletedHospitalAddressResponse>();

        CreateMap<HospitalAddress, GetByIdHospitalAddressResponse>()
            .ForMember(dest => dest.HospitalName, opt => opt.MapFrom(src => src.Hospital.Name))
            .ForMember(dest => dest.QuarterName, opt => opt.MapFrom(src => src.Quarter.Name))
            .ForMember(dest => dest.DistrictID, opt => opt.MapFrom(src => src.Quarter.DistrictID))
            .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.Quarter.District.Name))
            .ForMember(dest => dest.CityID, opt => opt.MapFrom(src => src.Quarter.District.CityID))
            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Quarter.District.City.Name))
            .ForMember(dest => dest.CountryID, opt => opt.MapFrom(src => src.Quarter.District.City.CountryID))
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Quarter.District.City.Country.Name));

        CreateMap<HospitalAddress, GetListHospitalAddressListItemDto>()
            .ForMember(dest => dest.QuarterName, opt => opt.MapFrom(src => src.Quarter.Name))
            .ForMember(dest => dest.DistrictID, opt => opt.MapFrom(src => src.Quarter.DistrictID))
            .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.Quarter.District.Name))
            .ForMember(dest => dest.CityID, opt => opt.MapFrom(src => src.Quarter.District.CityID))
            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Quarter.District.City.Name))
            .ForMember(dest => dest.CountryID, opt => opt.MapFrom(src => src.Quarter.District.City.CountryID))
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Quarter.District.City.Country.Name));
        CreateMap<IPaginate<HospitalAddress>, GetListResponse<GetListHospitalAddressListItemDto>>();
    }
}