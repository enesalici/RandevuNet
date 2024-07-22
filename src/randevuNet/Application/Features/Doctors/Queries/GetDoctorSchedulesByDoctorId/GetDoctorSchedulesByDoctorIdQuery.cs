using Application.Features.Doctors.Constants;
using Application.Features.Doctors.Rules;
using AutoMapper;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Doctors.Constants.DoctorsOperationClaims;
using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Features.Doctors.Queries.GetDoctorSchedulesByDoctorId;

public class GetDoctorSchedulesByDoctorIdQuery : IRequest<List<GetDoctorSchedulesByDoctorIdResponse>>, ISecuredRequest
{
    public Guid DoctorID { get; set; }

    public string[] Roles => [Admin, Read, DoctorsOperationClaims.GetDoctorSchedulesByDoctorId];
    
    public class GetDoctorSchedulesByDoctorIdQueryHandler : IRequestHandler<GetDoctorSchedulesByDoctorIdQuery, List<GetDoctorSchedulesByDoctorIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly DoctorBusinessRules _doctorBusinessRules;
        private readonly IDoctorScheduleSlotRepository _doctorScheduleSlotRepository;
        public GetDoctorSchedulesByDoctorIdQueryHandler(IMapper mapper, DoctorBusinessRules doctorBusinessRules, IDoctorScheduleSlotRepository doctorScheduleSlotRepository)
        {
            _mapper = mapper;
            _doctorBusinessRules = doctorBusinessRules;
            _doctorScheduleSlotRepository = doctorScheduleSlotRepository;
        }

        public async Task<List<GetDoctorSchedulesByDoctorIdResponse>> Handle(GetDoctorSchedulesByDoctorIdQuery request, CancellationToken cancellationToken)
        {
            List<DoctorScheduleSlot> schedules = await _doctorScheduleSlotRepository.GetDoctorSchedulesByDoctorIdAsync(request.DoctorID);
            List<GetDoctorSchedulesByDoctorIdResponse> response = _mapper.Map<List<GetDoctorSchedulesByDoctorIdResponse>>(schedules);
            return response; ;
        }
    }
}
