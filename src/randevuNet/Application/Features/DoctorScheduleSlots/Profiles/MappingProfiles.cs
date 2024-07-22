using Application.Features.DoctorScheduleSlots.Commands.Create;
using Application.Features.DoctorScheduleSlots.Commands.Delete;
using Application.Features.DoctorScheduleSlots.Commands.Update;
using Application.Features.DoctorScheduleSlots.Queries.GetById;
using Application.Features.DoctorScheduleSlots.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.DoctorScheduleSlots.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDoctorScheduleSlotCommand, DoctorScheduleSlot>();
        CreateMap<DoctorScheduleSlot, CreatedDoctorScheduleSlotResponse>();

        CreateMap<UpdateDoctorScheduleSlotCommand, DoctorScheduleSlot>();
        CreateMap<DoctorScheduleSlot, UpdatedDoctorScheduleSlotResponse>();

        CreateMap<DeleteDoctorScheduleSlotCommand, DoctorScheduleSlot>();
        CreateMap<DoctorScheduleSlot, DeletedDoctorScheduleSlotResponse>();

        CreateMap<DoctorScheduleSlot, GetByIdDoctorScheduleSlotResponse>();

        CreateMap<DoctorScheduleSlot, GetListDoctorScheduleSlotListItemDto>();
        CreateMap<IPaginate<DoctorScheduleSlot>, GetListResponse<GetListDoctorScheduleSlotListItemDto>>();
    }
}