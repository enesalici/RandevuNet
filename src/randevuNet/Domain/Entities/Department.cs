using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Department : Entity<int>
{
    public string Name { get; set; }

    public virtual ICollection<Hospital_Department> HospitalDepartments { get; set; }
}
