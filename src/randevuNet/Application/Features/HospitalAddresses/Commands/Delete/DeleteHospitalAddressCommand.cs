using Application.Features.HospitalAddresses.Constants;
using Application.Features.HospitalAddresses.Constants;
using Application.Features.HospitalAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.HospitalAddresses.Constants.HospitalAddressesOperationClaims;

namespace Application.Features.HospitalAddresses.Commands.Delete;

public class DeleteHospitalAddressCommand : IRequest<DeletedHospitalAddressResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, HospitalAddressesOperationClaims.Delete];

    public class DeleteHospitalAddressCommandHandler : IRequestHandler<DeleteHospitalAddressCommand, DeletedHospitalAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHospitalAddressRepository _hospitalAddressRepository;
        private readonly HospitalAddressBusinessRules _hospitalAddressBusinessRules;

        public DeleteHospitalAddressCommandHandler(IMapper mapper, IHospitalAddressRepository hospitalAddressRepository,
                                         HospitalAddressBusinessRules hospitalAddressBusinessRules)
        {
            _mapper = mapper;
            _hospitalAddressRepository = hospitalAddressRepository;
            _hospitalAddressBusinessRules = hospitalAddressBusinessRules;
        }

        public async Task<DeletedHospitalAddressResponse> Handle(DeleteHospitalAddressCommand request, CancellationToken cancellationToken)
        {
            HospitalAddress? hospitalAddress = await _hospitalAddressRepository.GetAsync(predicate: ha => ha.Id == request.Id, cancellationToken: cancellationToken);
            await _hospitalAddressBusinessRules.HospitalAddressShouldExistWhenSelected(hospitalAddress);

            await _hospitalAddressRepository.DeleteAsync(hospitalAddress!);

            DeletedHospitalAddressResponse response = _mapper.Map<DeletedHospitalAddressResponse>(hospitalAddress);
            return response;
        }
    }
}