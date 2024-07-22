using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nest;

namespace Persistence.EntityConfigurations;

public class DoctorTitleConfiguration : IEntityTypeConfiguration<DoctorTitle>
{
    public void Configure(EntityTypeBuilder<DoctorTitle> builder)
    {
        builder.ToTable("DoctorTitles").HasKey(dt => dt.Id);

        builder.Property(dt => dt.Id).HasColumnName("Id").IsRequired();
        builder.Property(dt => dt.Name).HasColumnName("Name").IsRequired();
        builder.Property(dt => dt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(dt => dt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(dt => dt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(dt => !dt.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }

    private IEnumerable<DoctorTitle> _seeds
    {
        get
        {
            yield return new() { Id = 1, Name = "Prof.Dr.", LevelIndex = 100 };
            yield return new() { Id = 2, Name = "Doç.Dr.", LevelIndex = 200 };
            yield return new() { Id = 3, Name = "Yrd.Doç.Dr.", LevelIndex = 300 };
            yield return new() { Id = 4, Name = "Dr.Öðr.Üyesi", LevelIndex = 400 };
            yield return new() { Id = 5, Name = "Op.Dr.", LevelIndex = 500 };
            yield return new() { Id = 6, Name = "Uzm.Dr.", LevelIndex = 600 };
            yield return new() { Id = 7, Name = "Dr.", LevelIndex = 700 };
           
        }
    }
}