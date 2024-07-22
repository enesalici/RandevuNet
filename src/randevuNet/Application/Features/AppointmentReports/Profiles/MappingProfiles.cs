using Application.Features.AppointmentReports.Commands.Create;
using Application.Features.AppointmentReports.Commands.Delete;
using Application.Features.AppointmentReports.Commands.Update;
using Application.Features.AppointmentReports.Queries.GetById;
using Application.Features.AppointmentReports.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AppointmentReports.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAppointmentReportCommand, AppointmentReport>();
        CreateMap<AppointmentReport, CreatedAppointmentReportResponse>();

        CreateMap<UpdateAppointmentReportCommand, AppointmentReport>();
        CreateMap<AppointmentReport, UpdatedAppointmentReportResponse>();

        CreateMap<DeleteAppointmentReportCommand, AppointmentReport>();
        CreateMap<AppointmentReport, DeletedAppointmentReportResponse>();

        CreateMap<AppointmentReport, GetByIdAppointmentReportResponse>();

        CreateMap<AppointmentReport, GetListAppointmentReportListItemDto>();
        CreateMap<IPaginate<AppointmentReport>, GetListResponse<GetListAppointmentReportListItemDto>>();
    }
}