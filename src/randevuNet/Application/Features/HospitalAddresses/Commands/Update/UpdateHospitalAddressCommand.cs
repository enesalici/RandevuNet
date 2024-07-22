using Application.Features.HospitalAddresses.Constants;
using Application.Features.HospitalAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.HospitalAddresses.Constants.HospitalAddressesOperationClaims;

namespace Application.Features.HospitalAddresses.Commands.Update;

public class UpdateHospitalAddressCommand : IRequest<UpdatedHospitalAddressResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Detail { get; set; }
    public required int HospitalID { get; set; }
    public required int QuarterID { get; set; }

    public string[] Roles => [Admin, Write, HospitalAddressesOperationClaims.Update];

    public class UpdateHospitalAddressCommandHandler : IRequestHandler<UpdateHospitalAddressCommand, UpdatedHospitalAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHospitalAddressRepository _hospitalAddressRepository;
        private readonly HospitalAddressBusinessRules _hospitalAddressBusinessRules;

        public UpdateHospitalAddressCommandHandler(IMapper mapper, IHospitalAddressRepository hospitalAddressRepository,
                                         HospitalAddressBusinessRules hospitalAddressBusinessRules)
        {
            _mapper = mapper;
            _hospitalAddressRepository = hospitalAddressRepository;
            _hospitalAddressBusinessRules = hospitalAddressBusinessRules;
        }

        public async Task<UpdatedHospitalAddressResponse> Handle(UpdateHospitalAddressCommand request, CancellationToken cancellationToken)
        {
            HospitalAddress? hospitalAddress = await _hospitalAddressRepository.GetAsync(predicate: ha => ha.Id == request.Id, cancellationToken: cancellationToken);
            await _hospitalAddressBusinessRules.HospitalAddressShouldExistWhenSelected(hospitalAddress);
            hospitalAddress = _mapper.Map(request, hospitalAddress);

            await _hospitalAddressRepository.UpdateAsync(hospitalAddress!);

            UpdatedHospitalAddressResponse response = _mapper.Map<UpdatedHospitalAddressResponse>(hospitalAddress);
            return response;
        }
    }
}