using Application.Features.DoctorScheduleSlots.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.DoctorScheduleSlots.Constants.DoctorScheduleSlotsOperationClaims;

namespace Application.Features.DoctorScheduleSlots.Queries.GetList;

public class GetListDoctorScheduleSlotQuery : IRequest<GetListResponse<GetListDoctorScheduleSlotListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListDoctorScheduleSlotQueryHandler : IRequestHandler<GetListDoctorScheduleSlotQuery, GetListResponse<GetListDoctorScheduleSlotListItemDto>>
    {
        private readonly IDoctorScheduleSlotRepository _doctorScheduleSlotRepository;
        private readonly IMapper _mapper;

        public GetListDoctorScheduleSlotQueryHandler(IDoctorScheduleSlotRepository doctorScheduleSlotRepository, IMapper mapper)
        {
            _doctorScheduleSlotRepository = doctorScheduleSlotRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDoctorScheduleSlotListItemDto>> Handle(GetListDoctorScheduleSlotQuery request, CancellationToken cancellationToken)
        {
            IPaginate<DoctorScheduleSlot> doctorScheduleSlots = await _doctorScheduleSlotRepository.GetListAsync(
                orderBy: c => c.OrderBy(c => c.Date),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDoctorScheduleSlotListItemDto> response = _mapper.Map<GetListResponse<GetListDoctorScheduleSlotListItemDto>>(doctorScheduleSlots);
            return response;
        }
    }
}