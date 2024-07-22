using Application.Features.UserRoles.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.UserRoles.Constants.UserRolesOperationClaims;

namespace Application.Features.UserRoles.Queries.GetList;

public class GetListUserRoleQuery : IRequest<GetListResponse<GetListUserRoleListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListUserRoleQueryHandler : IRequestHandler<GetListUserRoleQuery, GetListResponse<GetListUserRoleListItemDto>>
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;

        public GetListUserRoleQueryHandler(IUserRoleRepository userRoleRepository, IMapper mapper)
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserRoleListItemDto>> Handle(GetListUserRoleQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserRole> userRoles = await _userRoleRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserRoleListItemDto> response = _mapper.Map<GetListResponse<GetListUserRoleListItemDto>>(userRoles);
            return response;
        }
    }
}