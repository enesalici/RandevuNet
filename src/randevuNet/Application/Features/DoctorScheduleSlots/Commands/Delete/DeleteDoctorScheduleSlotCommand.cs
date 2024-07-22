using Application.Features.DoctorScheduleSlots.Constants;
using Application.Features.DoctorScheduleSlots.Constants;
using Application.Features.DoctorScheduleSlots.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.DoctorScheduleSlots.Constants.DoctorScheduleSlotsOperationClaims;

namespace Application.Features.DoctorScheduleSlots.Commands.Delete;

public class DeleteDoctorScheduleSlotCommand : IRequest<DeletedDoctorScheduleSlotResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, DoctorScheduleSlotsOperationClaims.Delete];

    public class DeleteDoctorScheduleSlotCommandHandler : IRequestHandler<DeleteDoctorScheduleSlotCommand, DeletedDoctorScheduleSlotResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDoctorScheduleSlotRepository _doctorScheduleSlotRepository;
        private readonly DoctorScheduleSlotBusinessRules _doctorScheduleSlotBusinessRules;

        public DeleteDoctorScheduleSlotCommandHandler(IMapper mapper, IDoctorScheduleSlotRepository doctorScheduleSlotRepository,
                                         DoctorScheduleSlotBusinessRules doctorScheduleSlotBusinessRules)
        {
            _mapper = mapper;
            _doctorScheduleSlotRepository = doctorScheduleSlotRepository;
            _doctorScheduleSlotBusinessRules = doctorScheduleSlotBusinessRules;
        }

        public async Task<DeletedDoctorScheduleSlotResponse> Handle(DeleteDoctorScheduleSlotCommand request, CancellationToken cancellationToken)
        {
            DoctorScheduleSlot? doctorScheduleSlot = await _doctorScheduleSlotRepository.GetAsync(predicate: dss => dss.Id == request.Id, cancellationToken: cancellationToken);
            await _doctorScheduleSlotBusinessRules.DoctorScheduleSlotShouldExistWhenSelected(doctorScheduleSlot);

            await _doctorScheduleSlotRepository.DeleteAsync(doctorScheduleSlot!);

            DeletedDoctorScheduleSlotResponse response = _mapper.Map<DeletedDoctorScheduleSlotResponse>(doctorScheduleSlot);
            return response;
        }
    }
}