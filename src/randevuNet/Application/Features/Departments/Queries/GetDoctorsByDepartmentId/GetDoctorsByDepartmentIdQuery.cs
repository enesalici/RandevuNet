using Application.Features.Departments.Constants;
using Application.Features.Departments.Rules;
using AutoMapper;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Departments.Constants.DepartmentsOperationClaims;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Application.Requests;
using Application.Features.Hospitals.Queries.GetDepartmentsByHospitalId;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Departments.Queries.GetDoctorsByDepartmentId;

public class GetDoctorsByDepartmentIdQuery : IRequest<GetListResponse<GetDoctorsByDepartmentIdListItemDto>>, ISecuredRequest
{
    public int DepartmentID { get; set; }
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read, DepartmentsOperationClaims.GetDoctorsByDepartmentId];
    
    public class GetDoctorsByDepartmentIdQueryHandler : IRequestHandler<GetDoctorsByDepartmentIdQuery, GetListResponse<GetDoctorsByDepartmentIdListItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _doctorRepository;

        private readonly DepartmentBusinessRules _departmentBusinessRules;

        public GetDoctorsByDepartmentIdQueryHandler(IMapper mapper, DepartmentBusinessRules departmentBusinessRules, IDoctorRepository doctorRepository)
        {
            _mapper = mapper;
            _departmentBusinessRules = departmentBusinessRules;
            _doctorRepository = doctorRepository;
        }

        public async Task<GetListResponse<GetDoctorsByDepartmentIdListItemDto>> Handle(GetDoctorsByDepartmentIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Doctor> doctors = await _doctorRepository.GetListAsync(
                predicate: d => d.Hospital_Department.DepartmentID == request.DepartmentID,
                include: d => d.Include(d => d.Hospital_Department).Include(d => d.DoctorTitle),
                orderBy: d => d.OrderBy(d => d.DoctorTitle.LevelIndex)
                .OrderBy(d => d.FirstName)
                .OrderBy(d => d.LastName),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetDoctorsByDepartmentIdListItemDto> response = _mapper.Map<GetListResponse<GetDoctorsByDepartmentIdListItemDto>>(doctors);
            return response;

        }
    }
}
