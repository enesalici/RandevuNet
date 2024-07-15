using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class City : Entity<int>
{
    public string Name { get; set; }

    public int CountryID { get; set; }

    public virtual Country Country { get; set; }
    public virtual ICollection<District> Districts { get; set; }
}
