using Application.Features.HospitalDepartments.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.HospitalDepartments.Constants.HospitalDepartmentsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.HospitalDepartments.Queries.GetList;

public class GetListHospitalDepartmentQuery : IRequest<GetListResponse<GetListHospitalDepartmentListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListHospitalDepartmentQueryHandler : IRequestHandler<GetListHospitalDepartmentQuery, GetListResponse<GetListHospitalDepartmentListItemDto>>
    {
        private readonly IHospitalDepartmentRepository _hospitalDepartmentRepository;
        private readonly IMapper _mapper;

        public GetListHospitalDepartmentQueryHandler(IHospitalDepartmentRepository hospitalDepartmentRepository, IMapper mapper)
        {
            _hospitalDepartmentRepository = hospitalDepartmentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListHospitalDepartmentListItemDto>> Handle(GetListHospitalDepartmentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Hospital_Department> hospitalDepartments = await _hospitalDepartmentRepository.GetListAsync(
                include: hd => hd.Include(hd => hd.Hospital).Include(hd => hd.Department),
                orderBy: hd => hd.OrderBy(hd => hd.Department.Name).OrderBy(hd => hd.Hospital.Name),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListHospitalDepartmentListItemDto> response = _mapper.Map<GetListResponse<GetListHospitalDepartmentListItemDto>>(hospitalDepartments);
            return response;
        }
    }
}