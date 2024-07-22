using Application.Features.HospitalDepartments.Constants;
using Application.Features.HospitalDepartments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.HospitalDepartments.Constants.HospitalDepartmentsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.HospitalDepartments.Queries.GetById;

public class GetByIdHospitalDepartmentQuery : IRequest<GetByIdHospitalDepartmentResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdHospitalDepartmentQueryHandler : IRequestHandler<GetByIdHospitalDepartmentQuery, GetByIdHospitalDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHospitalDepartmentRepository _hospitalDepartmentRepository;
        private readonly HospitalDepartmentBusinessRules _hospitalDepartmentBusinessRules;

        public GetByIdHospitalDepartmentQueryHandler(IMapper mapper, IHospitalDepartmentRepository hospitalDepartmentRepository, HospitalDepartmentBusinessRules hospitalDepartmentBusinessRules)
        {
            _mapper = mapper;
            _hospitalDepartmentRepository = hospitalDepartmentRepository;
            _hospitalDepartmentBusinessRules = hospitalDepartmentBusinessRules;
        }

        public async Task<GetByIdHospitalDepartmentResponse> Handle(GetByIdHospitalDepartmentQuery request, CancellationToken cancellationToken)
        {
            Hospital_Department? hospitalDepartment = await _hospitalDepartmentRepository.GetAsync(predicate: hd => hd.Id == request.Id, cancellationToken: cancellationToken, 
                include: hd => hd.Include(hd => hd.Hospital).Include(hd => hd.Department));
            await _hospitalDepartmentBusinessRules.HospitalDepartmentShouldExistWhenSelected(hospitalDepartment);

            GetByIdHospitalDepartmentResponse response = _mapper.Map<GetByIdHospitalDepartmentResponse>(hospitalDepartment);
            return response;
        }
    }
}