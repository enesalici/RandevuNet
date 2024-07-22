using Application.Features.DoctorScheduleSlots.Constants;
using Application.Features.DoctorScheduleSlots.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.DoctorScheduleSlots.Constants.DoctorScheduleSlotsOperationClaims;

namespace Application.Features.DoctorScheduleSlots.Commands.Update;

public class UpdateDoctorScheduleSlotCommand : IRequest<UpdatedDoctorScheduleSlotResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public required DateOnly Date { get; set; }
    public required TimeOnly StartTime { get; set; }
    public required TimeOnly EndTime { get; set; }
    public required Guid DoctorID { get; set; }

    public string[] Roles => [Admin, Write, DoctorScheduleSlotsOperationClaims.Update];

    public class UpdateDoctorScheduleSlotCommandHandler : IRequestHandler<UpdateDoctorScheduleSlotCommand, UpdatedDoctorScheduleSlotResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDoctorScheduleSlotRepository _doctorScheduleSlotRepository;
        private readonly DoctorScheduleSlotBusinessRules _doctorScheduleSlotBusinessRules;

        public UpdateDoctorScheduleSlotCommandHandler(IMapper mapper, IDoctorScheduleSlotRepository doctorScheduleSlotRepository,
                                         DoctorScheduleSlotBusinessRules doctorScheduleSlotBusinessRules)
        {
            _mapper = mapper;
            _doctorScheduleSlotRepository = doctorScheduleSlotRepository;
            _doctorScheduleSlotBusinessRules = doctorScheduleSlotBusinessRules;
        }

        public async Task<UpdatedDoctorScheduleSlotResponse> Handle(UpdateDoctorScheduleSlotCommand request, CancellationToken cancellationToken)
        {
            DoctorScheduleSlot? doctorScheduleSlot = await _doctorScheduleSlotRepository.GetAsync(predicate: dss => dss.Id == request.Id, cancellationToken: cancellationToken);
            await _doctorScheduleSlotBusinessRules.DoctorScheduleSlotShouldExistWhenSelected(doctorScheduleSlot);
            doctorScheduleSlot = _mapper.Map(request, doctorScheduleSlot);

            await _doctorScheduleSlotRepository.UpdateAsync(doctorScheduleSlot!);

            UpdatedDoctorScheduleSlotResponse response = _mapper.Map<UpdatedDoctorScheduleSlotResponse>(doctorScheduleSlot);
            return response;
        }
    }
}