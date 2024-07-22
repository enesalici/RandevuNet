using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class DoctorTitle : Entity<int>
{
    public string Name { get; set; }
    public int LevelIndex { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; }
}
