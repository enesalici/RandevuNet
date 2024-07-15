using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Hospital : Entity<int>
{
    public string Name { get; set; }

    public virtual HospitalAddress HospitalAddress { get; set; }
    public virtual ICollection<Hospital_Department> HospitalDepartments { get; set; }
}
