using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class HospitalAddress : Entity<int>
{
    public string Title { get; set; }
    public string Detail { get; set; }

    public int HospitalID { get; set; }
    public int QuarterID { get; set; }

    public virtual Quarter Quarter { get; set; }
    public virtual Hospital Hospital { get; set; }
}
