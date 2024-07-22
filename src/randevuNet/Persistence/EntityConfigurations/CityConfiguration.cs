using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired();
        builder.Property(c => c.CountryID).HasColumnName("CountryID").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }

    private IEnumerable<City> _seeds
    {
        get
        {
            yield return new() { Id = 1, Name = "Ýstanbul (Anadolu)", CountryID = 1 };
            yield return new() { Id = 2, Name = "Ýstanbul (Avrupa)", CountryID = 1 };
            yield return new() { Id = 3, Name = "Ankara", CountryID = 1 };
        }
    }
}