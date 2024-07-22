using Application.Features.DoctorTitles.Constants;
using Application.Features.DoctorTitles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.DoctorTitles.Constants.DoctorTitlesOperationClaims;

namespace Application.Features.DoctorTitles.Commands.Update;

public class UpdateDoctorTitleCommand : IRequest<UpdatedDoctorTitleResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LevelIndex { get; set; }


    public string[] Roles => [Admin, Write, DoctorTitlesOperationClaims.Update];

    public class UpdateDoctorTitleCommandHandler : IRequestHandler<UpdateDoctorTitleCommand, UpdatedDoctorTitleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDoctorTitleRepository _doctorTitleRepository;
        private readonly DoctorTitleBusinessRules _doctorTitleBusinessRules;

        public UpdateDoctorTitleCommandHandler(IMapper mapper, IDoctorTitleRepository doctorTitleRepository,
                                         DoctorTitleBusinessRules doctorTitleBusinessRules)
        {
            _mapper = mapper;
            _doctorTitleRepository = doctorTitleRepository;
            _doctorTitleBusinessRules = doctorTitleBusinessRules;
        }

        public async Task<UpdatedDoctorTitleResponse> Handle(UpdateDoctorTitleCommand request, CancellationToken cancellationToken)
        {
            DoctorTitle? doctorTitle = await _doctorTitleRepository.GetAsync(predicate: dt => dt.Id == request.Id, cancellationToken: cancellationToken);
            await _doctorTitleBusinessRules.DoctorTitleShouldExistWhenSelected(doctorTitle);
            doctorTitle = _mapper.Map(request, doctorTitle);

            await _doctorTitleRepository.UpdateAsync(doctorTitle!);

            UpdatedDoctorTitleResponse response = _mapper.Map<UpdatedDoctorTitleResponse>(doctorTitle);
            return response;
        }
    }
}