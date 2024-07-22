using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class HospitalAddressConfiguration : IEntityTypeConfiguration<HospitalAddress>
{
    public void Configure(EntityTypeBuilder<HospitalAddress> builder)
    {
        builder.ToTable("HospitalAddresses").HasKey(ha => ha.Id);

        builder.Property(ha => ha.Id).HasColumnName("Id").IsRequired();
        builder.Property(ha => ha.Title).HasColumnName("Title").IsRequired();
        builder.Property(ha => ha.Detail).HasColumnName("Detail").IsRequired();
        builder.Property(ha => ha.HospitalID).HasColumnName("HospitalID").IsRequired();
        builder.Property(ha => ha.QuarterID).HasColumnName("QuarterID").IsRequired();
        builder.Property(ha => ha.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ha => ha.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ha => ha.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ha => !ha.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }

    private IEnumerable<HospitalAddress> _seeds
    {
        get
        {
            yield return new() { Id = 1, Title = "Ana Bina", Detail = "Ali Sokak No:2", QuarterID = 1, HospitalID=1};
            yield return new() { Id = 2, Title = "Ana Bina", Detail = "Veli Sokak No:4", QuarterID = 2 ,HospitalID=2 };
            yield return new() { Id = 3, Title = "Ana Bina", Detail = "Zeki Sokak No:6", QuarterID = 3 ,HospitalID=3};
        }
    }
}