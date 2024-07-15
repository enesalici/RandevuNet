using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class District : Entity<int>
{
    public string Name { get; set; }

    public int CityID { get; set; }

    public virtual City City { get; set; }
    public virtual ICollection<Quarter> Quarters { get; set; }
}
