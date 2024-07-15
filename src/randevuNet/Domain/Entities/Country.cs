using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Country : Entity<int>
{
    public string Name { get; set; }

    public virtual ICollection<City> Cities { get; set; }
}
