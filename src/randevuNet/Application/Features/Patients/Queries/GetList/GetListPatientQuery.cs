using Application.Features.Patients.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Patients.Constants.PatientsOperationClaims;

namespace Application.Features.Patients.Queries.GetList;

public class GetListPatientQuery : IRequest<GetListResponse<GetListPatientListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListPatientQueryHandler : IRequestHandler<GetListPatientQuery, GetListResponse<GetListPatientListItemDto>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public GetListPatientQueryHandler(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPatientListItemDto>> Handle(GetListPatientQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Patient> patients = await _patientRepository.GetListAsync(
                orderBy: p => p.OrderBy(p => p.FirstName).OrderBy(p => p.LastName),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPatientListItemDto> response = _mapper.Map<GetListResponse<GetListPatientListItemDto>>(patients);
            return response;
        }
    }
}