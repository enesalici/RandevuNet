using Application.Features.DoctorScheduleSlots.Constants;
using Application.Features.DoctorScheduleSlots.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.DoctorScheduleSlots.Constants.DoctorScheduleSlotsOperationClaims;

namespace Application.Features.DoctorScheduleSlots.Commands.Create;

public class CreateDoctorScheduleSlotCommand : IRequest<CreatedDoctorScheduleSlotResponse>, ISecuredRequest
{
    public required DateOnly Date { get; set; }
    public required string StartTime { get; set; }
    public required string EndTime { get; set; }
    public required Guid DoctorID { get; set; }

    public string[] Roles => [Admin, Write, DoctorScheduleSlotsOperationClaims.Create];

    public class CreateDoctorScheduleSlotCommandHandler : IRequestHandler<CreateDoctorScheduleSlotCommand, CreatedDoctorScheduleSlotResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDoctorScheduleSlotRepository _doctorScheduleSlotRepository;
        private readonly DoctorScheduleSlotBusinessRules _doctorScheduleSlotBusinessRules;

        public CreateDoctorScheduleSlotCommandHandler(IMapper mapper, IDoctorScheduleSlotRepository doctorScheduleSlotRepository,
                                         DoctorScheduleSlotBusinessRules doctorScheduleSlotBusinessRules)
        {
            _mapper = mapper;
            _doctorScheduleSlotRepository = doctorScheduleSlotRepository;
            _doctorScheduleSlotBusinessRules = doctorScheduleSlotBusinessRules;
        }

        public async Task<CreatedDoctorScheduleSlotResponse> Handle(CreateDoctorScheduleSlotCommand request, CancellationToken cancellationToken)
        {
           
            
            DoctorScheduleSlot doctorScheduleSlot = new DoctorScheduleSlot()
            {
                StartTime = TimeOnly.Parse( request.StartTime),
                EndTime = TimeOnly.Parse( request.EndTime),
                Date = request.Date,
                DoctorID = request.DoctorID,
            };

            await _doctorScheduleSlotRepository.AddAsync(doctorScheduleSlot);

            CreatedDoctorScheduleSlotResponse response = _mapper.Map<CreatedDoctorScheduleSlotResponse>(doctorScheduleSlot);
            return response;
        }
    }
}