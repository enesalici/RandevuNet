using Application.Features.Doctors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Doctors.Constants.DoctorsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Doctors.Queries.GetList;

public class GetListDoctorQuery : IRequest<GetListResponse<GetListDoctorListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListDoctorQueryHandler : IRequestHandler<GetListDoctorQuery, GetListResponse<GetListDoctorListItemDto>>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public GetListDoctorQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDoctorListItemDto>> Handle(GetListDoctorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Doctor> doctors = await _doctorRepository.GetListAsync(
                include: d=> d.Include(d=>d.Hospital_Department)
                .Include(d=>d.Hospital_Department.Department).Include(d=>d.Hospital_Department.Hospital).Include(d=>d.DoctorTitle),
                orderBy: d => d.OrderBy(d => d.FirstName).OrderBy(d => d.LastName),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDoctorListItemDto> response = _mapper.Map<GetListResponse<GetListDoctorListItemDto>>(doctors);
            return response;
        }
    }
}