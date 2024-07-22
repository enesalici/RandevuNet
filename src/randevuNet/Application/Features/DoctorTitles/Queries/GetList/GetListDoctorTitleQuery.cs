using Application.Features.DoctorTitles.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.DoctorTitles.Constants.DoctorTitlesOperationClaims;

namespace Application.Features.DoctorTitles.Queries.GetList;

public class GetListDoctorTitleQuery : IRequest<GetListResponse<GetListDoctorTitleListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    //public string[] Roles => [Admin, Read];

    public class GetListDoctorTitleQueryHandler : IRequestHandler<GetListDoctorTitleQuery, GetListResponse<GetListDoctorTitleListItemDto>>
    {
        private readonly IDoctorTitleRepository _doctorTitleRepository;
        private readonly IMapper _mapper;

        public GetListDoctorTitleQueryHandler(IDoctorTitleRepository doctorTitleRepository, IMapper mapper)
        {
            _doctorTitleRepository = doctorTitleRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDoctorTitleListItemDto>> Handle(GetListDoctorTitleQuery request, CancellationToken cancellationToken)
        {
            IPaginate<DoctorTitle> doctorTitles = await _doctorTitleRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDoctorTitleListItemDto> response = _mapper.Map<GetListResponse<GetListDoctorTitleListItemDto>>(doctorTitles);
            return response;
        }
    }
}