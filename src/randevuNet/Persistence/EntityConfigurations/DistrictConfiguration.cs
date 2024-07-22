using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.ToTable("Districts").HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.Name).HasColumnName("Name").IsRequired();
        builder.Property(d => d.CityID).HasColumnName("CityID").IsRequired();
        builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(d => d.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(d => !d.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }

    private IEnumerable<District> _seeds
    {
        get
        {
            yield return new() { Id = 1, Name = "Kadýköy", CityID = 1 };
            yield return new() { Id = 2, Name = "Ümraniye", CityID = 1 };
            yield return new() { Id = 3, Name = "Üsküdar", CityID = 1 };

            yield return new() { Id = 4, Name = "Beþiktaþ", CityID = 2 };
            yield return new() { Id = 5, Name = "Baðcýlar", CityID = 2 };

            yield return new() { Id = 6, Name = "Keçiören", CityID = 3 };
        }
    }
}