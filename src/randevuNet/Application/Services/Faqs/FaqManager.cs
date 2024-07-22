using Application.Features.Faqs.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Faqs;

public class FaqManager : IFaqService
{
    private readonly IFaqRepository _faqRepository;
    private readonly FaqBusinessRules _faqBusinessRules;

    public FaqManager(IFaqRepository faqRepository, FaqBusinessRules faqBusinessRules)
    {
        _faqRepository = faqRepository;
        _faqBusinessRules = faqBusinessRules;
    }

    public async Task<Faq?> GetAsync(
        Expression<Func<Faq, bool>> predicate,
        Func<IQueryable<Faq>, IIncludableQueryable<Faq, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Faq? faq = await _faqRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return faq;
    }

    public async Task<IPaginate<Faq>?> GetListAsync(
        Expression<Func<Faq, bool>>? predicate = null,
        Func<IQueryable<Faq>, IOrderedQueryable<Faq>>? orderBy = null,
        Func<IQueryable<Faq>, IIncludableQueryable<Faq, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Faq> faqList = await _faqRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return faqList;
    }

    public async Task<Faq> AddAsync(Faq faq)
    {
        Faq addedFaq = await _faqRepository.AddAsync(faq);

        return addedFaq;
    }

    public async Task<Faq> UpdateAsync(Faq faq)
    {
        Faq updatedFaq = await _faqRepository.UpdateAsync(faq);

        return updatedFaq;
    }

    public async Task<Faq> DeleteAsync(Faq faq, bool permanent = false)
    {
        Faq deletedFaq = await _faqRepository.DeleteAsync(faq);

        return deletedFaq;
    }
}
