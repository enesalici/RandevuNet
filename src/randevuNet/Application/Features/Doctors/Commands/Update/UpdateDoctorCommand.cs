using Application.Features.Doctors.Constants;
using Application.Features.Doctors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Doctors.Constants.DoctorsOperationClaims;

namespace Application.Features.Doctors.Commands.Update;

public class UpdateDoctorCommand : IRequest<UpdatedDoctorResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? About { get; set; }
    public string? Education { get; set; }
    public string? ProfilePhoto { get; set; }
    public required int DoctorTitleID { get; set; }
    public required int HospitalDepartmentID { get; set; }




    public string[] Roles => [Admin, Write, DoctorsOperationClaims.Update];

    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, UpdatedDoctorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _doctorRepository;
        private readonly DoctorBusinessRules _doctorBusinessRules;

        public UpdateDoctorCommandHandler(IMapper mapper, IDoctorRepository doctorRepository,
                                         DoctorBusinessRules doctorBusinessRules)
        {
            _mapper = mapper;
            _doctorRepository = doctorRepository;
            _doctorBusinessRules = doctorBusinessRules;
        }

        public async Task<UpdatedDoctorResponse> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            Doctor? doctor = await _doctorRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _doctorBusinessRules.DoctorShouldExistWhenSelected(doctor);
            doctor = _mapper.Map(request, doctor);

            await _doctorRepository.UpdateAsync(doctor!);

            UpdatedDoctorResponse response = _mapper.Map<UpdatedDoctorResponse>(doctor);
            return response;
        }
    }
}