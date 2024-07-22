using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IFaqRepository : IAsyncRepository<Faq, int>, IRepository<Faq, int>
{
}