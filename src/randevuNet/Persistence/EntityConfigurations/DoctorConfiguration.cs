using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Hashing;

namespace Persistence.EntityConfigurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctors");
            //.HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(d => d.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(d => d.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(d => d.About).HasColumnName("About");
        builder.Property(d => d.Education).HasColumnName("Education");
        builder.Property(d => d.ProfilePhoto).HasColumnName("ProfilePhoto");
        builder.Property(d => d.DoctorTitleID).HasColumnName("DoctorTitleID").IsRequired();
        builder.Property(d => d.Hospital_DepartmentID).HasColumnName("Hospital_DepartmentID").IsRequired();
        //builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        //builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        //builder.Property(d => d.DeletedDate).HasColumnName("DeletedDate");

        //builder.HasQueryFilter(d => !d.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }


    private IEnumerable<Doctor> _seeds
    {
        get
        {
            HashingHelper.CreatePasswordHash(
                password: "Doctor123!",
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );

            yield return new()
            {
                Id = Guid.NewGuid(),
                FirstName = "Nagihan",
                LastName = "Akkuþ",
                Email = "nagi@demo.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Hospital_DepartmentID = 3,
                DoctorTitleID = 1,
                UserRoleID = 2,
            };

            yield return new()
            {
                Id = Guid.NewGuid(),
                FirstName = "Ahmet",
                LastName = "Yýlmaz",
                Email = "ahmet@demo.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Hospital_DepartmentID = 3,
                DoctorTitleID = 2,
                UserRoleID = 2,
            };

            yield return new()
            {
                Id = Guid.NewGuid(),
                FirstName = "Mehmet",
                LastName = "Yýldýz",
                Email = "mehmet@demo.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Hospital_DepartmentID = 1,
                DoctorTitleID = 3,
                UserRoleID = 2,

            };

            yield return new()
            {
                Id = Guid.NewGuid(),
                FirstName = "Enes B.",
                LastName = "Halaç",
                Email = "enes.b@demo.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Hospital_DepartmentID = 6,
                DoctorTitleID = 2,
                UserRoleID = 2,

            };

            yield return new()
            {
                Id = Guid.NewGuid(),
                FirstName = "Enes A.",
                LastName = "Alýcý",
                Email = "enes.a@demo.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Hospital_DepartmentID = 9,
                DoctorTitleID = 3,
                UserRoleID = 2,

            };

        }
    }
}