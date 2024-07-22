using Application.Features.Patients.Constants;
using Application.Features.Patients.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Patients.Constants.PatientsOperationClaims;

namespace Application.Features.Patients.Commands.Update;

public class UpdatePatientCommand : IRequest<UpdatedPatientResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ProfilePhoto { get; set; }

    public string[] Roles => [Admin, Write, PatientsOperationClaims.Update];

    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, UpdatedPatientResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;
        private readonly PatientBusinessRules _patientBusinessRules;

        public UpdatePatientCommandHandler(IMapper mapper, IPatientRepository patientRepository,
                                         PatientBusinessRules patientBusinessRules)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
            _patientBusinessRules = patientBusinessRules;
        }

        public async Task<UpdatedPatientResponse> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            Patient? patient = await _patientRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _patientBusinessRules.PatientShouldExistWhenSelected(patient);
            patient = _mapper.Map(request, patient);

            await _patientRepository.UpdateAsync(patient!);

            UpdatedPatientResponse response = _mapper.Map<UpdatedPatientResponse>(patient);
            return response;
        }
    }
}