using Application.Features.HospitalDepartments.Constants;
using Application.Features.HospitalDepartments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.HospitalDepartments.Constants.HospitalDepartmentsOperationClaims;

namespace Application.Features.HospitalDepartments.Commands.Update;

public class UpdateHospitalDepartmentCommand : IRequest<UpdatedHospitalDepartmentResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public required int HospitalID { get; set; }
    public required int DepartmentID { get; set; }

    public string[] Roles => [Admin, Write, HospitalDepartmentsOperationClaims.Update];

    public class UpdateHospitalDepartmentCommandHandler : IRequestHandler<UpdateHospitalDepartmentCommand, UpdatedHospitalDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHospitalDepartmentRepository _hospitalDepartmentRepository;
        private readonly HospitalDepartmentBusinessRules _hospitalDepartmentBusinessRules;

        public UpdateHospitalDepartmentCommandHandler(IMapper mapper, IHospitalDepartmentRepository hospitalDepartmentRepository,
                                         HospitalDepartmentBusinessRules hospitalDepartmentBusinessRules)
        {
            _mapper = mapper;
            _hospitalDepartmentRepository = hospitalDepartmentRepository;
            _hospitalDepartmentBusinessRules = hospitalDepartmentBusinessRules;
        }

        public async Task<UpdatedHospitalDepartmentResponse> Handle(UpdateHospitalDepartmentCommand request, CancellationToken cancellationToken)
        {
            Hospital_Department? hospitalDepartment = await _hospitalDepartmentRepository.GetAsync(predicate: hd => hd.Id == request.Id, cancellationToken: cancellationToken);
            await _hospitalDepartmentBusinessRules.HospitalDepartmentShouldExistWhenSelected(hospitalDepartment);
            hospitalDepartment = _mapper.Map(request, hospitalDepartment);

            await _hospitalDepartmentRepository.UpdateAsync(hospitalDepartment!);

            UpdatedHospitalDepartmentResponse response = _mapper.Map<UpdatedHospitalDepartmentResponse>(hospitalDepartment);
            return response;
        }
    }
}