using Application.Features.Patients.Constants;
using Application.Features.Patients.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Patients.Constants.PatientsOperationClaims;

namespace Application.Features.Patients.Queries.GetById;

public class GetByIdPatientQuery : IRequest<GetByIdPatientResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdPatientQueryHandler : IRequestHandler<GetByIdPatientQuery, GetByIdPatientResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;
        private readonly PatientBusinessRules _patientBusinessRules;

        public GetByIdPatientQueryHandler(IMapper mapper, IPatientRepository patientRepository, PatientBusinessRules patientBusinessRules)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
            _patientBusinessRules = patientBusinessRules;
        }

        public async Task<GetByIdPatientResponse> Handle(GetByIdPatientQuery request, CancellationToken cancellationToken)
        {
            Patient? patient = await _patientRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _patientBusinessRules.PatientShouldExistWhenSelected(patient);

            GetByIdPatientResponse response = _mapper.Map<GetByIdPatientResponse>(patient);
            return response;
        }
    }
}