using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Hashing;

namespace Persistence.EntityConfigurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles").HasKey(ur => ur.Id);

        builder.Property(ur => ur.Id).HasColumnName("Id").IsRequired();
        builder.Property(ur => ur.Name).HasColumnName("Name").IsRequired();
        builder.Property(ur => ur.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ur => ur.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ur => ur.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ur => !ur.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }


    private IEnumerable<UserRole> _seeds
    {
        get
        {
            yield return new()
            {
                Id = 1,
                Name = "Admin"
            };
            yield return new()
            {
                Id = 2,
                Name = "Doctor"
            };
            yield return new()
            {
                Id = 3,
                Name = "Patient"
            };
        }
    }
}