using Application.Features.Hospitals.Constants;
using Application.Features.Hospitals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Hospitals.Constants.HospitalsOperationClaims;

namespace Application.Features.Hospitals.Commands.Update;

public class UpdateHospitalCommand : IRequest<UpdatedHospitalResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }


    public string[] Roles => [Admin, Write, HospitalsOperationClaims.Update];

    public class UpdateHospitalCommandHandler : IRequestHandler<UpdateHospitalCommand, UpdatedHospitalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHospitalRepository _hospitalRepository;
        private readonly HospitalBusinessRules _hospitalBusinessRules;

        public UpdateHospitalCommandHandler(IMapper mapper, IHospitalRepository hospitalRepository,
                                         HospitalBusinessRules hospitalBusinessRules)
        {
            _mapper = mapper;
            _hospitalRepository = hospitalRepository;
            _hospitalBusinessRules = hospitalBusinessRules;
        }

        public async Task<UpdatedHospitalResponse> Handle(UpdateHospitalCommand request, CancellationToken cancellationToken)
        {
            Hospital? hospital = await _hospitalRepository.GetAsync(predicate: h => h.Id == request.Id, cancellationToken: cancellationToken);
            await _hospitalBusinessRules.HospitalShouldExistWhenSelected(hospital);
            hospital = _mapper.Map(request, hospital);

            await _hospitalRepository.UpdateAsync(hospital!);

            UpdatedHospitalResponse response = _mapper.Map<UpdatedHospitalResponse>(hospital);
            return response;
        }
    }
}