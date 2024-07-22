using Application.Features.HospitalDepartments.Constants;
using Application.Features.HospitalDepartments.Constants;
using Application.Features.HospitalDepartments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.HospitalDepartments.Constants.HospitalDepartmentsOperationClaims;

namespace Application.Features.HospitalDepartments.Commands.Delete;

public class DeleteHospitalDepartmentCommand : IRequest<DeletedHospitalDepartmentResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, HospitalDepartmentsOperationClaims.Delete];

    public class DeleteHospitalDepartmentCommandHandler : IRequestHandler<DeleteHospitalDepartmentCommand, DeletedHospitalDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHospitalDepartmentRepository _hospitalDepartmentRepository;
        private readonly HospitalDepartmentBusinessRules _hospitalDepartmentBusinessRules;

        public DeleteHospitalDepartmentCommandHandler(IMapper mapper, IHospitalDepartmentRepository hospitalDepartmentRepository,
                                         HospitalDepartmentBusinessRules hospitalDepartmentBusinessRules)
        {
            _mapper = mapper;
            _hospitalDepartmentRepository = hospitalDepartmentRepository;
            _hospitalDepartmentBusinessRules = hospitalDepartmentBusinessRules;
        }

        public async Task<DeletedHospitalDepartmentResponse> Handle(DeleteHospitalDepartmentCommand request, CancellationToken cancellationToken)
        {
            Hospital_Department? hospitalDepartment = await _hospitalDepartmentRepository.GetAsync(predicate: hd => hd.Id == request.Id, cancellationToken: cancellationToken);
            await _hospitalDepartmentBusinessRules.HospitalDepartmentShouldExistWhenSelected(hospitalDepartment);

            await _hospitalDepartmentRepository.DeleteAsync(hospitalDepartment!);

            DeletedHospitalDepartmentResponse response = _mapper.Map<DeletedHospitalDepartmentResponse>(hospitalDepartment);
            return response;
        }
    }
}