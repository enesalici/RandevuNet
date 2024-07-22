using Application.Features.UserRoles.Constants;
using Application.Features.UserRoles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.UserRoles.Constants.UserRolesOperationClaims;

namespace Application.Features.UserRoles.Commands.Create;

public class CreateUserRoleCommand : IRequest<CreatedUserRoleResponse>, ISecuredRequest
{
    public required string Name { get; set; }

    public string[] Roles => [Admin, Write, UserRolesOperationClaims.Create];

    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, CreatedUserRoleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly UserRoleBusinessRules _userRoleBusinessRules;

        public CreateUserRoleCommandHandler(IMapper mapper, IUserRoleRepository userRoleRepository,
                                         UserRoleBusinessRules userRoleBusinessRules)
        {
            _mapper = mapper;
            _userRoleRepository = userRoleRepository;
            _userRoleBusinessRules = userRoleBusinessRules;
        }

        public async Task<CreatedUserRoleResponse> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            UserRole userRole = _mapper.Map<UserRole>(request);

            await _userRoleRepository.AddAsync(userRole);

            CreatedUserRoleResponse response = _mapper.Map<CreatedUserRoleResponse>(userRole);
            return response;
        }
    }
}