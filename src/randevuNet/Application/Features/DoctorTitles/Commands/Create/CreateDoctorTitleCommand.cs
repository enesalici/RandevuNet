using Application.Features.DoctorTitles.Constants;
using Application.Features.DoctorTitles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.DoctorTitles.Constants.DoctorTitlesOperationClaims;

namespace Application.Features.DoctorTitles.Commands.Create;

public class CreateDoctorTitleCommand : IRequest<CreatedDoctorTitleResponse>, ISecuredRequest
{
    public required string Name { get; set; }
    public required int LevelIndex { get; set; }


    public string[] Roles => [Admin, Write, DoctorTitlesOperationClaims.Create];

    public class CreateDoctorTitleCommandHandler : IRequestHandler<CreateDoctorTitleCommand, CreatedDoctorTitleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDoctorTitleRepository _doctorTitleRepository;
        private readonly DoctorTitleBusinessRules _doctorTitleBusinessRules;

        public CreateDoctorTitleCommandHandler(IMapper mapper, IDoctorTitleRepository doctorTitleRepository,
                                         DoctorTitleBusinessRules doctorTitleBusinessRules)
        {
            _mapper = mapper;
            _doctorTitleRepository = doctorTitleRepository;
            _doctorTitleBusinessRules = doctorTitleBusinessRules;
        }

        public async Task<CreatedDoctorTitleResponse> Handle(CreateDoctorTitleCommand request, CancellationToken cancellationToken)
        {
            DoctorTitle doctorTitle = _mapper.Map<DoctorTitle>(request);

            await _doctorTitleRepository.AddAsync(doctorTitle);

            CreatedDoctorTitleResponse response = _mapper.Map<CreatedDoctorTitleResponse>(doctorTitle);
            return response;
        }
    }
}