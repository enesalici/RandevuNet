using Application.Features.Districts.Constants;
using Application.Features.Districts.Constants;
using Application.Features.Districts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Districts.Constants.DistrictsOperationClaims;

namespace Application.Features.Districts.Commands.Delete;

public class DeleteDistrictCommand : IRequest<DeletedDistrictResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, DistrictsOperationClaims.Delete];

    public class DeleteDistrictCommandHandler : IRequestHandler<DeleteDistrictCommand, DeletedDistrictResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDistrictRepository _districtRepository;
        private readonly DistrictBusinessRules _districtBusinessRules;

        public DeleteDistrictCommandHandler(IMapper mapper, IDistrictRepository districtRepository,
                                         DistrictBusinessRules districtBusinessRules)
        {
            _mapper = mapper;
            _districtRepository = districtRepository;
            _districtBusinessRules = districtBusinessRules;
        }

        public async Task<DeletedDistrictResponse> Handle(DeleteDistrictCommand request, CancellationToken cancellationToken)
        {
            District? district = await _districtRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _districtBusinessRules.DistrictShouldExistWhenSelected(district);

            await _districtRepository.DeleteAsync(district!);

            DeletedDistrictResponse response = _mapper.Map<DeletedDistrictResponse>(district);
            return response;
        }
    }
}