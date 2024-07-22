using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Hospital_Department : Entity<int>
{
    public int HospitalID { get; set; }
    public int DepartmentID { get; set; }

    public virtual Hospital Hospital { get; set; }
    public virtual Department Department { get; set; }
    public virtual ICollection<Doctor> Doctors { get; set; }

}
