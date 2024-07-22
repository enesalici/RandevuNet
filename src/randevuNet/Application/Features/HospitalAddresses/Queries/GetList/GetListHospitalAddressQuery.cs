using Application.Features.HospitalAddresses.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.HospitalAddresses.Constants.HospitalAddressesOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.HospitalAddresses.Queries.GetList;

public class GetListHospitalAddressQuery : IRequest<GetListResponse<GetListHospitalAddressListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListHospitalAddressQueryHandler : IRequestHandler<GetListHospitalAddressQuery, GetListResponse<GetListHospitalAddressListItemDto>>
    {
        private readonly IHospitalAddressRepository _hospitalAddressRepository;
        private readonly IMapper _mapper;

        public GetListHospitalAddressQueryHandler(IHospitalAddressRepository hospitalAddressRepository, IMapper mapper)
        {
            _hospitalAddressRepository = hospitalAddressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListHospitalAddressListItemDto>> Handle(GetListHospitalAddressQuery request, CancellationToken cancellationToken)
        {
            IPaginate<HospitalAddress> hospitalAddresses = await _hospitalAddressRepository.GetListAsync(
                orderBy: ha => ha.OrderBy(ha => ha.Quarter.Name),
                include: ha => ha.Include(ha => ha.Quarter).Include(ha => ha.Quarter.District).Include(ha => ha.Quarter.District.City).Include(ha => ha.Quarter.District.City.Country),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListHospitalAddressListItemDto> response = _mapper.Map<GetListResponse<GetListHospitalAddressListItemDto>>(hospitalAddresses);
            return response;
        }
    }
}