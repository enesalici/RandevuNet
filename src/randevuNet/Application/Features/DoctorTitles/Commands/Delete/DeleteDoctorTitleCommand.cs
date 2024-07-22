using Application.Features.DoctorTitles.Constants;
using Application.Features.DoctorTitles.Constants;
using Application.Features.DoctorTitles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.DoctorTitles.Constants.DoctorTitlesOperationClaims;

namespace Application.Features.DoctorTitles.Commands.Delete;

public class DeleteDoctorTitleCommand : IRequest<DeletedDoctorTitleResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, DoctorTitlesOperationClaims.Delete];

    public class DeleteDoctorTitleCommandHandler : IRequestHandler<DeleteDoctorTitleCommand, DeletedDoctorTitleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDoctorTitleRepository _doctorTitleRepository;
        private readonly DoctorTitleBusinessRules _doctorTitleBusinessRules;

        public DeleteDoctorTitleCommandHandler(IMapper mapper, IDoctorTitleRepository doctorTitleRepository,
                                         DoctorTitleBusinessRules doctorTitleBusinessRules)
        {
            _mapper = mapper;
            _doctorTitleRepository = doctorTitleRepository;
            _doctorTitleBusinessRules = doctorTitleBusinessRules;
        }

        public async Task<DeletedDoctorTitleResponse> Handle(DeleteDoctorTitleCommand request, CancellationToken cancellationToken)
        {
            DoctorTitle? doctorTitle = await _doctorTitleRepository.GetAsync(predicate: dt => dt.Id == request.Id, cancellationToken: cancellationToken);
            await _doctorTitleBusinessRules.DoctorTitleShouldExistWhenSelected(doctorTitle);

            await _doctorTitleRepository.DeleteAsync(doctorTitle!);

            DeletedDoctorTitleResponse response = _mapper.Map<DeletedDoctorTitleResponse>(doctorTitle);
            return response;
        }
    }
}