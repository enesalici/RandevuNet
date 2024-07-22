using Application.Features.Doctors.Constants;
using Application.Features.Doctors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Doctors.Constants.DoctorsOperationClaims;
using NArchitecture.Core.Security.Hashing;
using Application.Services.UserOperationClaims;
using static Nest.JoinField;

namespace Application.Features.Doctors.Commands.Create;

public class CreateDoctorCommand : IRequest<CreatedDoctorResponse>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? PhoneNumber { get; set; }
    public string? About { get; set; }
    public string? Education { get; set; }
    public string? ProfilePhoto { get; set; }
    public required int DoctorTitleID { get; set; }
    public required int HospitalDepartmentID { get; set; }
    public required int UserRoleID { get; set; }

    //public string[] Roles => [Admin, Write, DoctorsOperationClaims.Create];

    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, CreatedDoctorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _doctorRepository;
        private readonly DoctorBusinessRules _doctorBusinessRules;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public CreateDoctorCommandHandler(IMapper mapper, IDoctorRepository doctorRepository,
                                         DoctorBusinessRules doctorBusinessRules, IUserOperationClaimService userOperationClaimService)
        {
            _mapper = mapper;
            _doctorRepository = doctorRepository;
            _doctorBusinessRules = doctorBusinessRules;
            _userOperationClaimService = userOperationClaimService;
        }

        public async Task<CreatedDoctorResponse> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            HashingHelper.CreatePasswordHash(
                request.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
                );

            Doctor doctor = _mapper.Map<Doctor>(request);
            doctor.PasswordHash = passwordHash;
            doctor.PasswordSalt = passwordSalt;


            await _doctorRepository.AddAsync(doctor);
            ICollection<UserOperationClaim> uoc =
            [
                new UserOperationClaim(){UserId=doctor.Id, OperationClaimId = 19},
                new UserOperationClaim(){UserId=doctor.Id, OperationClaimId = 24},
                new UserOperationClaim(){UserId=doctor.Id, OperationClaimId = 30},
                new UserOperationClaim(){UserId=doctor.Id, OperationClaimId = 49},
                new UserOperationClaim(){UserId=doctor.Id, OperationClaimId = 60},
                new UserOperationClaim(){UserId=doctor.Id, OperationClaimId = 79},
                new UserOperationClaim(){UserId=doctor.Id, OperationClaimId = 109},
                new UserOperationClaim(){UserId=doctor.Id, OperationClaimId = 120},
                new UserOperationClaim(){UserId=doctor.Id, OperationClaimId = 121},
                new UserOperationClaim(){UserId=doctor.Id, OperationClaimId = 122},
                new UserOperationClaim(){UserId=doctor.Id, OperationClaimId = 123},
                new UserOperationClaim(){UserId=doctor.Id, OperationClaimId = 128},
            ];

            await _userOperationClaimService.AddRangeAsync(uoc);

            CreatedDoctorResponse response = _mapper.Map<CreatedDoctorResponse>(doctor);
            return response;
        }
    }
}