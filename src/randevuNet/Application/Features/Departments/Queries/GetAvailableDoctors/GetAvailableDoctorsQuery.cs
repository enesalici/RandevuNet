using Application.Features.Departments.Constants;
using Application.Features.Departments.Rules;
using AutoMapper;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Departments.Constants.DepartmentsOperationClaims;
using Application.Features.Departments.Queries.GetDoctorsByDepartmentId;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Application.Requests;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Departments.Queries.GetAvailableDoctors;

public class GetAvailableDoctorsQuery : IRequest<List<GetAvailableDoctorsListItemDto>>, ISecuredRequest
{
    public int DepartmentID { get; set; }

    public Guid? DoctorID { get; set; }

    public DateOnly? Date { get; set; }


    public string[] Roles => [Admin, Read, DepartmentsOperationClaims.GetAvailableDoctors];
    
    public class GetAvailableDoctorsQueryHandler : IRequestHandler<GetAvailableDoctorsQuery, List<GetAvailableDoctorsListItemDto>>
    {

        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        private readonly DepartmentBusinessRules _departmentBusinessRules;

        public GetAvailableDoctorsQueryHandler(IMapper mapper, DepartmentBusinessRules departmentBusinessRules, IDoctorRepository doctorRepository)
        {
            _mapper = mapper;
            _departmentBusinessRules = departmentBusinessRules;
            _doctorRepository = doctorRepository;
        }

        public async Task<List<GetAvailableDoctorsListItemDto>> Handle(GetAvailableDoctorsQuery request, CancellationToken cancellationToken)
        {
            var availableDoctors = await _doctorRepository.GetAvailableDoctorsAsync(
                departmentId: request.DepartmentID,
                doctorID: request.DoctorID,
                date: request.Date);
            
            var response = 
                _mapper.Map<List<GetAvailableDoctorsListItemDto>>(availableDoctors);
            return response;
        }
    }
}
