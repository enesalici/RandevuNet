using Application.Features.HospitalDepartments.Constants;
using Application.Features.HospitalDepartments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.HospitalDepartments.Constants.HospitalDepartmentsOperationClaims;

namespace Application.Features.HospitalDepartments.Commands.Create;

public class CreateHospitalDepartmentCommand : IRequest<CreatedHospitalDepartmentResponse>, ISecuredRequest
{
    public required int HospitalID { get; set; }
    public required int DepartmentID { get; set; }

    public string[] Roles => [Admin, Write, HospitalDepartmentsOperationClaims.Create];

    public class CreateHospitalDepartmentCommandHandler : IRequestHandler<CreateHospitalDepartmentCommand, CreatedHospitalDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHospitalDepartmentRepository _hospitalDepartmentRepository;
        private readonly HospitalDepartmentBusinessRules _hospitalDepartmentBusinessRules;

        public CreateHospitalDepartmentCommandHandler(IMapper mapper, IHospitalDepartmentRepository hospitalDepartmentRepository,
                                         HospitalDepartmentBusinessRules hospitalDepartmentBusinessRules)
        {
            _mapper = mapper;
            _hospitalDepartmentRepository = hospitalDepartmentRepository;
            _hospitalDepartmentBusinessRules = hospitalDepartmentBusinessRules;
        }

        public async Task<CreatedHospitalDepartmentResponse> Handle(CreateHospitalDepartmentCommand request, CancellationToken cancellationToken)
        {
            Hospital_Department hospitalDepartment = _mapper.Map<Hospital_Department>(request);

            await _hospitalDepartmentRepository.AddAsync(hospitalDepartment);

            CreatedHospitalDepartmentResponse response = _mapper.Map<CreatedHospitalDepartmentResponse>(hospitalDepartment);
            return response;
        }
    }
}