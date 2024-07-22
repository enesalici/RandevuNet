using Application.Features.DoctorTitles.Constants;
using Application.Features.DoctorTitles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.DoctorTitles.Constants.DoctorTitlesOperationClaims;

namespace Application.Features.DoctorTitles.Queries.GetById;

public class GetByIdDoctorTitleQuery : IRequest<GetByIdDoctorTitleResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdDoctorTitleQueryHandler : IRequestHandler<GetByIdDoctorTitleQuery, GetByIdDoctorTitleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDoctorTitleRepository _doctorTitleRepository;
        private readonly DoctorTitleBusinessRules _doctorTitleBusinessRules;

        public GetByIdDoctorTitleQueryHandler(IMapper mapper, IDoctorTitleRepository doctorTitleRepository, DoctorTitleBusinessRules doctorTitleBusinessRules)
        {
            _mapper = mapper;
            _doctorTitleRepository = doctorTitleRepository;
            _doctorTitleBusinessRules = doctorTitleBusinessRules;
        }

        public async Task<GetByIdDoctorTitleResponse> Handle(GetByIdDoctorTitleQuery request, CancellationToken cancellationToken)
        {
            DoctorTitle? doctorTitle = await _doctorTitleRepository.GetAsync(predicate: dt => dt.Id == request.Id, cancellationToken: cancellationToken);
            await _doctorTitleBusinessRules.DoctorTitleShouldExistWhenSelected(doctorTitle);

            GetByIdDoctorTitleResponse response = _mapper.Map<GetByIdDoctorTitleResponse>(doctorTitle);
            return response;
        }
    }
}