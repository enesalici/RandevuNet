using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Feedback : Entity<int>
{
    public string Title { get; set; }
    public string Message { get; set; }

    public Guid UserID { get; set; }

    public virtual User User { get; set; }
}
