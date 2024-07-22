using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class QuarterConfiguration : IEntityTypeConfiguration<Quarter>
{
    public void Configure(EntityTypeBuilder<Quarter> builder)
    {
        builder.ToTable("Quarters").HasKey(q => q.Id);

        builder.Property(q => q.Id).HasColumnName("Id").IsRequired();
        builder.Property(q => q.Name).HasColumnName("Name").IsRequired();
        builder.Property(q => q.DistrictID).HasColumnName("DistrictID").IsRequired();
        builder.Property(q => q.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(q => q.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(q => q.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(q => !q.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }

    private IEnumerable<Quarter> _seeds
    {
        get
        {
            yield return new() { Id = 1, Name = "Fenerbahçe", DistrictID = 1 };
            yield return new() { Id = 2, Name = "Çakmak", DistrictID = 2 };
            yield return new() { Id = 3, Name = "Mimar Sinan", DistrictID = 3 };

            yield return new() { Id = 4, Name = "Ortaköy", DistrictID = 4 };
            yield return new() { Id = 5, Name = "Güneþli", DistrictID = 5 };
            yield return new() { Id = 6, Name = "Bademlik", DistrictID = 6 };
        }
    }
}