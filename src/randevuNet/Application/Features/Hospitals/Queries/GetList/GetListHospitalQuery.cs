using Application.Features.Hospitals.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Hospitals.Constants.HospitalsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Hospitals.Queries.GetList;

public class GetListHospitalQuery : IRequest<GetListResponse<GetListHospitalListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    //public string[] Roles => [Admin, Read];

    public class GetListHospitalQueryHandler : IRequestHandler<GetListHospitalQuery, GetListResponse<GetListHospitalListItemDto>>
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IMapper _mapper;

        public GetListHospitalQueryHandler(IHospitalRepository hospitalRepository, IMapper mapper)
        {
            _hospitalRepository = hospitalRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListHospitalListItemDto>> Handle(GetListHospitalQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Hospital> hospitals = await _hospitalRepository.GetListAsync(
                orderBy: h => h.OrderBy(h => h.Name),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListHospitalListItemDto> response = _mapper.Map<GetListResponse<GetListHospitalListItemDto>>(hospitals);
            return response;
        }
    }
}