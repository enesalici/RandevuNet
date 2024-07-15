using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Quarter : Entity<int>
{
    public string Name { get; set; }

    public int DistrictID { get; set; }

    public virtual District District { get; set; }
    public virtual ICollection<HospitalAddress> HospitalAddresses { get; set; }
}
