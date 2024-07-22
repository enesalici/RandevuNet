using Application.Features.DoctorScheduleSlots.Constants;
using Application.Features.DoctorScheduleSlots.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.DoctorScheduleSlots.Constants.DoctorScheduleSlotsOperationClaims;

namespace Application.Features.DoctorScheduleSlots.Queries.GetById;

public class GetByIdDoctorScheduleSlotQuery : IRequest<GetByIdDoctorScheduleSlotResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdDoctorScheduleSlotQueryHandler : IRequestHandler<GetByIdDoctorScheduleSlotQuery, GetByIdDoctorScheduleSlotResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDoctorScheduleSlotRepository _doctorScheduleSlotRepository;
        private readonly DoctorScheduleSlotBusinessRules _doctorScheduleSlotBusinessRules;

        public GetByIdDoctorScheduleSlotQueryHandler(IMapper mapper, IDoctorScheduleSlotRepository doctorScheduleSlotRepository, DoctorScheduleSlotBusinessRules doctorScheduleSlotBusinessRules)
        {
            _mapper = mapper;
            _doctorScheduleSlotRepository = doctorScheduleSlotRepository;
            _doctorScheduleSlotBusinessRules = doctorScheduleSlotBusinessRules;
        }

        public async Task<GetByIdDoctorScheduleSlotResponse> Handle(GetByIdDoctorScheduleSlotQuery request, CancellationToken cancellationToken)
        {
            DoctorScheduleSlot? doctorScheduleSlot = await _doctorScheduleSlotRepository.GetAsync(predicate: dss => dss.Id == request.Id, cancellationToken: cancellationToken);
            await _doctorScheduleSlotBusinessRules.DoctorScheduleSlotShouldExistWhenSelected(doctorScheduleSlot);

            GetByIdDoctorScheduleSlotResponse response = _mapper.Map<GetByIdDoctorScheduleSlotResponse>(doctorScheduleSlot);
            return response;
        }
    }
}