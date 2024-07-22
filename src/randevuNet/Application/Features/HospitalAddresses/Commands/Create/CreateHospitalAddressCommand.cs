using Application.Features.HospitalAddresses.Constants;
using Application.Features.HospitalAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.HospitalAddresses.Constants.HospitalAddressesOperationClaims;

namespace Application.Features.HospitalAddresses.Commands.Create;

public class CreateHospitalAddressCommand : IRequest<CreatedHospitalAddressResponse>, ISecuredRequest
{
    public required string Title { get; set; }
    public required string Detail { get; set; }
    public required int HospitalID { get; set; }
    public required int QuarterID { get; set; }

    public string[] Roles => [Admin, Write, HospitalAddressesOperationClaims.Create];

    public class CreateHospitalAddressCommandHandler : IRequestHandler<CreateHospitalAddressCommand, CreatedHospitalAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHospitalAddressRepository _hospitalAddressRepository;
        private readonly HospitalAddressBusinessRules _hospitalAddressBusinessRules;

        public CreateHospitalAddressCommandHandler(IMapper mapper, IHospitalAddressRepository hospitalAddressRepository,
                                         HospitalAddressBusinessRules hospitalAddressBusinessRules)
        {
            _mapper = mapper;
            _hospitalAddressRepository = hospitalAddressRepository;
            _hospitalAddressBusinessRules = hospitalAddressBusinessRules;
        }

        public async Task<CreatedHospitalAddressResponse> Handle(CreateHospitalAddressCommand request, CancellationToken cancellationToken)
        {
            HospitalAddress hospitalAddress = _mapper.Map<HospitalAddress>(request);

            await _hospitalAddressRepository.AddAsync(hospitalAddress);

            CreatedHospitalAddressResponse response = _mapper.Map<CreatedHospitalAddressResponse>(hospitalAddress);
            return response;
        }
    }
}