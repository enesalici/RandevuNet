using Application.Features.Hospitals.Constants;
using Application.Features.Hospitals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Hospitals.Constants.HospitalsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Hospitals.Queries.GetById;

public class GetByIdHospitalQuery : IRequest<GetByIdHospitalResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdHospitalQueryHandler : IRequestHandler<GetByIdHospitalQuery, GetByIdHospitalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHospitalRepository _hospitalRepository;
        private readonly HospitalBusinessRules _hospitalBusinessRules;

        public GetByIdHospitalQueryHandler(IMapper mapper, IHospitalRepository hospitalRepository, HospitalBusinessRules hospitalBusinessRules)
        {
            _mapper = mapper;
            _hospitalRepository = hospitalRepository;
            _hospitalBusinessRules = hospitalBusinessRules;
        }

        public async Task<GetByIdHospitalResponse> Handle(GetByIdHospitalQuery request, CancellationToken cancellationToken)
        {
            Hospital? hospital = await _hospitalRepository.GetAsync(predicate: h => h.Id == request.Id, cancellationToken: cancellationToken);
            await _hospitalBusinessRules.HospitalShouldExistWhenSelected(hospital);

            GetByIdHospitalResponse response = _mapper.Map<GetByIdHospitalResponse>(hospital);
            return response;
        }
    }
}