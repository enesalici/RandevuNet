using Application.Features.HospitalAddresses.Constants;
using Application.Features.HospitalAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.HospitalAddresses.Constants.HospitalAddressesOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.HospitalAddresses.Queries.GetById;

public class GetByIdHospitalAddressQuery : IRequest<GetByIdHospitalAddressResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdHospitalAddressQueryHandler : IRequestHandler<GetByIdHospitalAddressQuery, GetByIdHospitalAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHospitalAddressRepository _hospitalAddressRepository;
        private readonly HospitalAddressBusinessRules _hospitalAddressBusinessRules;

        public GetByIdHospitalAddressQueryHandler(IMapper mapper, IHospitalAddressRepository hospitalAddressRepository, HospitalAddressBusinessRules hospitalAddressBusinessRules)
        {
            _mapper = mapper;
            _hospitalAddressRepository = hospitalAddressRepository;
            _hospitalAddressBusinessRules = hospitalAddressBusinessRules;
        }

        public async Task<GetByIdHospitalAddressResponse> Handle(GetByIdHospitalAddressQuery request, CancellationToken cancellationToken)
        {
            HospitalAddress? hospitalAddress = await _hospitalAddressRepository.GetAsync(predicate: ha => ha.Id == request.Id, cancellationToken: cancellationToken,
                 include: ha => ha.Include(ha => ha.Hospital ). Include(ha => ha.Quarter).Include(ha => ha.Quarter.District).Include(ha => ha.Quarter.District.City).Include(ha => ha.Quarter.District.City.Country));
            await _hospitalAddressBusinessRules.HospitalAddressShouldExistWhenSelected(hospitalAddress);

            GetByIdHospitalAddressResponse response = _mapper.Map<GetByIdHospitalAddressResponse>(hospitalAddress);
            return response;
        }
    }
}