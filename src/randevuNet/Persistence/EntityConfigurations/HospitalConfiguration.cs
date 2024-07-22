using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
{
    public void Configure(EntityTypeBuilder<Hospital> builder)
    {
        builder.ToTable("Hospitals").HasKey(h => h.Id);

        builder.Property(h => h.Id).HasColumnName("Id").IsRequired();
        builder.Property(h => h.Name).HasColumnName("Name").IsRequired();
        builder.Property(h => h.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(h => h.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(h => h.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(h => !h.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }

    private IEnumerable<Hospital> _seeds
    {
        get
        {
            yield return new() { Id = 1, Name = "RandevuNet Hastanesi" };
            yield return new() { Id = 2, Name = "SeedData Hastanesi" };
            yield return new() { Id = 3, Name = "Medical Hastanesi" };
        }
    }
}