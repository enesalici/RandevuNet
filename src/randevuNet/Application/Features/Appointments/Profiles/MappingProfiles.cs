using Application.Features.Appointments.Commands.Create;
using Application.Features.Appointments.Commands.Delete;
using Application.Features.Appointments.Commands.Update;
using Application.Features.Appointments.Queries.GetById;
using Application.Features.Appointments.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Appointments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAppointmentCommand, Appointment>();
        CreateMap<Appointment, CreatedAppointmentResponse>()
            .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.Id))
            .ForMember(dest => dest.DoctorTitle, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.DoctorTitle.Name))
            .ForMember(dest => dest.DoctorFirstName, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.FirstName))
            .ForMember(dest => dest.DoctorLastName, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.LastName))
            .ForMember(dest => dest.PatientFirstName, opt => opt.MapFrom(src => src.Patient.FirstName))
            .ForMember(dest => dest.PatientLastName, opt => opt.MapFrom(src => src.Patient.LastName))
            .ForMember(dest => dest.PatientEmail, opt => opt.MapFrom(src => src.Patient.Email))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Date))
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.DoctorScheduleSlot.StartTime))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.DoctorScheduleSlot.EndTime))
            .ForMember(dest => dest.HospitalName, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.Hospital_Department.Hospital.Name))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.Hospital_Department.Department.Name));

        CreateMap<UpdateAppointmentCommand, Appointment>();
        CreateMap<Appointment, UpdatedAppointmentResponse>();

        CreateMap<DeleteAppointmentCommand, Appointment>();
        CreateMap<Appointment, DeletedAppointmentResponse>();

        CreateMap<Appointment, GetByIdAppointmentResponse>()
           .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.Id))
            .ForMember(dest => dest.DoctorTitle, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.DoctorTitle.Name))
            .ForMember(dest => dest.DoctorFirstName, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.FirstName))
            .ForMember(dest => dest.DoctorLastName, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.LastName))
            .ForMember(dest => dest.PatientFirstName, opt => opt.MapFrom(src => src.Patient.FirstName))
            .ForMember(dest => dest.PatientLastName, opt => opt.MapFrom(src => src.Patient.LastName))
            .ForMember(dest => dest.PatientEmail, opt => opt.MapFrom(src => src.Patient.Email))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Date))
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.DoctorScheduleSlot.StartTime))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.DoctorScheduleSlot.EndTime))
            .ForMember(dest => dest.HospitalName, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.Hospital_Department.Hospital.Name))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.Hospital_Department.Department.Name));


        CreateMap<Appointment, GetListAppointmentListItemDto>()
            .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.Id))
            .ForMember(dest => dest.DoctorTitle, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.DoctorTitle.Name))
            .ForMember(dest => dest.DoctorFirstName, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.FirstName))
            .ForMember(dest => dest.DoctorLastName, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.LastName))
            .ForMember(dest => dest.PatientFirstName, opt => opt.MapFrom(src => src.Patient.FirstName))
            .ForMember(dest => dest.PatientLastName, opt => opt.MapFrom(src => src.Patient.LastName))
            .ForMember(dest => dest.PatientEmail, opt => opt.MapFrom(src => src.Patient.Email))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Date))
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.DoctorScheduleSlot.StartTime))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.DoctorScheduleSlot.EndTime))
            .ForMember(dest => dest.HospitalName, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.Hospital_Department.Hospital.Name))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.DoctorScheduleSlot.Doctor.Hospital_Department.Department.Name));
        CreateMap<IPaginate<Appointment>, GetListResponse<GetListAppointmentListItemDto>>();
    }
}