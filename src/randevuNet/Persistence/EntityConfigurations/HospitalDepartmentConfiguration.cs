using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class HospitalDepartmentConfiguration : IEntityTypeConfiguration<Hospital_Department>
{
    public void Configure(EntityTypeBuilder<Hospital_Department> builder)
    {
        builder.ToTable("HospitalDepartments").HasKey(hd => hd.Id);

        builder.Property(hd => hd.Id).HasColumnName("Id").IsRequired();
        builder.Property(hd => hd.HospitalID).HasColumnName("HospitalID").IsRequired();
        builder.Property(hd => hd.DepartmentID).HasColumnName("DepartmentID").IsRequired();
        builder.Property(hd => hd.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(hd => hd.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(hd => hd.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(hd => !hd.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }

    private IEnumerable<Hospital_Department> _seeds
    {
        get
        {
            yield return new() { Id = 1, HospitalID = 1, DepartmentID = 1 };
            yield return new() { Id = 2, HospitalID = 1, DepartmentID = 2 };
            yield return new() { Id = 3, HospitalID = 1, DepartmentID = 3 };
            yield return new() { Id = 4, HospitalID = 1, DepartmentID = 4 };
            yield return new() { Id = 5, HospitalID = 1, DepartmentID = 5 };

            yield return new() { Id = 6, HospitalID = 2, DepartmentID = 1 };
            yield return new() { Id = 7, HospitalID = 2, DepartmentID = 4 };
            yield return new() { Id = 8, HospitalID = 2, DepartmentID = 5 };

            yield return new() { Id = 9, HospitalID = 3, DepartmentID = 2 };
            yield return new() { Id = 10, HospitalID = 3, DepartmentID = 4 };
        }
    }
}