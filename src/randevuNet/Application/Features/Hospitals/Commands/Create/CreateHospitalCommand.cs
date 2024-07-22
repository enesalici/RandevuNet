using Application.Features.Hospitals.Constants;
using Application.Features.Hospitals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Hospitals.Constants.HospitalsOperationClaims;

namespace Application.Features.Hospitals.Commands.Create;

public class CreateHospitalCommand : IRequest<CreatedHospitalResponse>, ISecuredRequest
{
    public required string Name { get; set; }

    public string[] Roles => [Admin, Write, HospitalsOperationClaims.Create];

    public class CreateHospitalCommandHandler : IRequestHandler<CreateHospitalCommand, CreatedHospitalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHospitalRepository _hospitalRepository;
        private readonly HospitalBusinessRules _hospitalBusinessRules;

        public CreateHospitalCommandHandler(IMapper mapper, IHospitalRepository hospitalRepository,
                                         HospitalBusinessRules hospitalBusinessRules)
        {
            _mapper = mapper;
            _hospitalRepository = hospitalRepository;
            _hospitalBusinessRules = hospitalBusinessRules;
        }

        public async Task<CreatedHospitalResponse> Handle(CreateHospitalCommand request, CancellationToken cancellationToken)
        {
            Hospital hospital = _mapper.Map<Hospital>(request);

            await _hospitalRepository.AddAsync(hospital);

            CreatedHospitalResponse response = _mapper.Map<CreatedHospitalResponse>(hospital);
            return response;
        }
    }
}