using Application.Features.Faqs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Faqs.Commands.Create;

public class CreateFaqCommand : IRequest<CreatedFaqResponse>
{
    public required string Question { get; set; }
    public required string Answer { get; set; }

    public class CreateFaqCommandHandler : IRequestHandler<CreateFaqCommand, CreatedFaqResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFaqRepository _faqRepository;
        private readonly FaqBusinessRules _faqBusinessRules;

        public CreateFaqCommandHandler(IMapper mapper, IFaqRepository faqRepository,
                                         FaqBusinessRules faqBusinessRules)
        {
            _mapper = mapper;
            _faqRepository = faqRepository;
            _faqBusinessRules = faqBusinessRules;
        }

        public async Task<CreatedFaqResponse> Handle(CreateFaqCommand request, CancellationToken cancellationToken)
        {
            Faq faq = _mapper.Map<Faq>(request);

            await _faqRepository.AddAsync(faq);

            CreatedFaqResponse response = _mapper.Map<CreatedFaqResponse>(faq);
            return response;
        }
    }
}