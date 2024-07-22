using Application.Features.Patients.Constants;
using Application.Features.Patients.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Patients.Constants.PatientsOperationClaims;
using NArchitecture.Core.Security.Hashing;
using System.Collections;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Application.Services.UserOperationClaims;

namespace Application.Features.Patients.Commands.Create;

public class CreatePatientCommand : IRequest<CreatedPatientResponse>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ProfilePhoto { get; set; }
    public required int UserRoleID { get; set; }


    //public string[] Roles => [Admin, Write, PatientsOperationClaims.Create];

    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, CreatedPatientResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;
        private readonly PatientBusinessRules _patientBusinessRules;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public CreatePatientCommandHandler(IMapper mapper, IPatientRepository patientRepository,
                                         PatientBusinessRules patientBusinessRules, IUserOperationClaimService userOperationClaimService)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
            _patientBusinessRules = patientBusinessRules;
            _userOperationClaimService = userOperationClaimService;
        }

        public async Task<CreatedPatientResponse> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            HashingHelper.CreatePasswordHash(
                request.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
                );

            Patient patient = _mapper.Map<Patient>(request);

            patient.PasswordHash = passwordHash;
            patient.PasswordSalt = passwordSalt;

            await _patientRepository.AddAsync(patient);

            ICollection<UserOperationClaim> uoc =
                    [
                    new UserOperationClaim(){UserId=patient.Id, OperationClaimId = 19},
                    new UserOperationClaim(){UserId=patient.Id, OperationClaimId = 25},
                new UserOperationClaim(){UserId=patient.Id, OperationClaimId = 27},
                new UserOperationClaim(){UserId=patient.Id, OperationClaimId = 29},
                new UserOperationClaim(){UserId=patient.Id, OperationClaimId = 31},
                new UserOperationClaim(){UserId=patient.Id, OperationClaimId = 49},
                new UserOperationClaim(){UserId=patient.Id, OperationClaimId = 75},
                new UserOperationClaim(){UserId=patient.Id, OperationClaimId = 77},
                new UserOperationClaim(){UserId=patient.Id, OperationClaimId = 79},
                new UserOperationClaim(){UserId=patient.Id, OperationClaimId = 109},
                new UserOperationClaim(){UserId=patient.Id, OperationClaimId = 120},
                new UserOperationClaim(){UserId=patient.Id, OperationClaimId = 121},
                new UserOperationClaim(){UserId=patient.Id, OperationClaimId = 122},
                new UserOperationClaim(){UserId=patient.Id, OperationClaimId = 123},
                new UserOperationClaim(){UserId=patient.Id, OperationClaimId = 128},
                ];

            await _userOperationClaimService.AddRangeAsync(uoc);

            CreatedPatientResponse response = _mapper.Map<CreatedPatientResponse>(patient);
            return response;
        }
    }
}