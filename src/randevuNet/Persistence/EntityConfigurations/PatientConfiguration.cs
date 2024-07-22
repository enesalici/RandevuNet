using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Hashing;

namespace Persistence.EntityConfigurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patients");
            //.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(p => p.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(p => p.ProfilePhoto).HasColumnName("ProfilePhoto");
        //builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        //builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        //builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        //builder.HasQueryFilter(p => !p.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }


    private IEnumerable<Patient> _seeds
    {
        get
        {
            HashingHelper.CreatePasswordHash(
                password: "Patient123!",
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );

            yield return new()
            {
                Id = Guid.NewGuid(),
                FirstName = "Ali",
                LastName = "Güneþ",
                Email = "ali@demo.com",
                PhoneNumber = "555 555 55 55",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserRoleID = 3,


            };

            yield return new()
            {
                Id = Guid.NewGuid(),
                FirstName = "Veli",
                LastName = "Yýlmaz",
                Email = "veli@demo.com",
                PhoneNumber = "555 555 55 66",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserRoleID = 3,

            };
        }
    }
}