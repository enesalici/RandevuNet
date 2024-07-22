using Application.Features.Doctors.Commands.Create;
using Application.Features.Doctors.Commands.Delete;
using Application.Features.Doctors.Commands.Update;
using Application.Features.Doctors.Queries.GetById;
using Application.Features.Doctors.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Doctors.Queries.GetDoctorSchedulesByDoctorId;

namespace Application.Features.Doctors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDoctorCommand, Doctor>()
            .ForMember(dest => dest.Hospital_DepartmentID, opt => opt.MapFrom(src => src.HospitalDepartmentID));
        CreateMap<Doctor, CreatedDoctorResponse>();

        CreateMap<UpdateDoctorCommand, Doctor>()
             .ForMember(dest => dest.Hospital_DepartmentID, opt => opt.MapFrom(src => src.HospitalDepartmentID));
        CreateMap<Doctor, UpdatedDoctorResponse>()
             .ForMember(dest => dest.HospitalDepartmentID, opt => opt.MapFrom(src => src.Hospital_DepartmentID));

        CreateMap<DeleteDoctorCommand, Doctor>();
        CreateMap<Doctor, DeletedDoctorResponse>();

        CreateMap<Doctor, GetByIdDoctorResponse>();

        CreateMap<Doctor, GetListDoctorListItemDto>()
             .ForMember(dest => dest.HospitalDepartmentID, opt => opt.MapFrom(src => src.Hospital_DepartmentID))
             .ForMember(dest => dest.HospitalName, opt => opt.MapFrom(src => src.Hospital_Department.Hospital.Name))
             .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Hospital_Department.Department.Name));

        CreateMap<IPaginate<Doctor>, GetListResponse<GetListDoctorListItemDto>>();

        CreateMap<DoctorScheduleSlot, GetDoctorSchedulesByDoctorIdQuery>().ReverseMap();
        CreateMap<DoctorScheduleSlot, GetDoctorSchedulesByDoctorIdResponse>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Doctor.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Doctor.LastName))
            .ForMember(dest => dest.DoctorTitleID, opt => opt.MapFrom(src => src.Doctor.DoctorTitleID))
            .ForMember(dest => dest.DoctorTitleName, opt => opt.MapFrom(src => src.Doctor.DoctorTitle.Name));

    }
}