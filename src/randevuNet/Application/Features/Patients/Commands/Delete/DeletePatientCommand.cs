using Application.Features.Patients.Constants;
using Application.Features.Patients.Constants;
using Application.Features.Patients.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Patients.Constants.PatientsOperationClaims;

namespace Application.Features.Patients.Commands.Delete;

public class DeletePatientCommand : IRequest<DeletedPatientResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, PatientsOperationClaims.Delete];

    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, DeletedPatientResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;
        private readonly PatientBusinessRules _patientBusinessRules;

        public DeletePatientCommandHandler(IMapper mapper, IPatientRepository patientRepository,
                                         PatientBusinessRules patientBusinessRules)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
            _patientBusinessRules = patientBusinessRules;
        }

        public async Task<DeletedPatientResponse> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            Patient? patient = await _patientRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _patientBusinessRules.PatientShouldExistWhenSelected(patient);

            await _patientRepository.DeleteAsync(patient!);

            DeletedPatientResponse response = _mapper.Map<DeletedPatientResponse>(patient);
            return response;
        }
    }
}