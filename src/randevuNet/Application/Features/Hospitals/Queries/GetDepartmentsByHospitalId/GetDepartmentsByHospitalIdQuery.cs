using Application.Features.Hospitals.Constants;
using Application.Features.Hospitals.Rules;
using AutoMapper;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Hospitals.Constants.HospitalsOperationClaims;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Hospitals.Queries.GetDepartmentsByHospitalId;

public class GetDepartmentsByHospitalIdQuery : IRequest<GetListResponse<GetDepartmentsByHospitalIdListItemDto>>
{
    public int HospitalID { get; set; }
    public PageRequest PageRequest { get; set; }

    //public string[] Roles => [Admin, Read, HospitalsOperationClaims.GetDepartmentsByHospitalId];

    public class GetDepartmentsByHospitalIdQueryHandler : IRequestHandler<GetDepartmentsByHospitalIdQuery, GetListResponse<GetDepartmentsByHospitalIdListItemDto>>
    {
        private readonly IHospitalDepartmentRepository _hospitalDepartmentRepository;
        private readonly IMapper _mapper;
        private readonly HospitalBusinessRules _hospitalBusinessRules;

        public GetDepartmentsByHospitalIdQueryHandler(IHospitalDepartmentRepository hospitalDepartmentRepository, IMapper mapper, HospitalBusinessRules hospitalBusinessRules)
        {
            _hospitalDepartmentRepository = hospitalDepartmentRepository;
            _mapper = mapper;
            _hospitalBusinessRules = hospitalBusinessRules;
        }


        public async Task<GetListResponse<GetDepartmentsByHospitalIdListItemDto>> Handle(GetDepartmentsByHospitalIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Hospital_Department> hospitalDepartments = await _hospitalDepartmentRepository.GetListAsync(
                predicate: hd => hd.HospitalID == request.HospitalID,
                orderBy: c => c.OrderBy(c => c.Department.Name),
                include: hd => hd.Include(hd => hd.Department),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetDepartmentsByHospitalIdListItemDto> response = _mapper.Map<GetListResponse<GetDepartmentsByHospitalIdListItemDto>>(hospitalDepartments);
            return response;
        }

    }
}
