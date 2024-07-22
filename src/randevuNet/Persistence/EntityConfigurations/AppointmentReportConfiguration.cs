using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AppointmentReportConfiguration : IEntityTypeConfiguration<AppointmentReport>
{
    public void Configure(EntityTypeBuilder<AppointmentReport> builder)
    {
        builder.ToTable("AppointmentReports").HasKey(ar => ar.Id);

        builder.Property(ar => ar.Id).HasColumnName("Id").IsRequired();
        builder.Property(ar => ar.Title).HasColumnName("Title").IsRequired();
        builder.Property(ar => ar.Detail).HasColumnName("Detail").IsRequired();
        builder.Property(ar => ar.AppointmentID).HasColumnName("AppointmentID").IsRequired();
        builder.Property(ar => ar.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ar => ar.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ar => ar.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ar => !ar.DeletedDate.HasValue);
    }
}