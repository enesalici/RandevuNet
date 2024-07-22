using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DoctorScheduleSlotConfiguration : IEntityTypeConfiguration<DoctorScheduleSlot>
{
    public void Configure(EntityTypeBuilder<DoctorScheduleSlot> builder)
    {
        builder.ToTable("DoctorScheduleSlots").HasKey(dss => dss.Id);

        builder.Property(dss => dss.Id).HasColumnName("Id").IsRequired();
        builder.Property(dss => dss.Date).HasColumnName("Date").IsRequired();
        builder.Property(dss => dss.StartTime).HasColumnName("StartTime").IsRequired();
        builder.Property(dss => dss.EndTime).HasColumnName("EndTime").IsRequired();
        builder.Property(dss => dss.DoctorID).HasColumnName("DoctorID").IsRequired();
        builder.Property(dss => dss.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(dss => dss.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(dss => dss.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(dss => !dss.DeletedDate.HasValue);
    }
}