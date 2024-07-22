using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Persistence.Repositories;

namespace Persistence.EntityConfigurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.Status).HasColumnName("Status").IsRequired();
        builder.Property(a => a.PatientId).HasColumnName("PatientId").IsRequired();
        builder.Property(a => a.DoctorScheduleSlotId).HasColumnName("DoctorScheduleSlotId").IsRequired();
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

        //builder.HasIndex(a => a.DoctorScheduleSlotId).IsUnique();

        builder.HasOne(a => a.DoctorScheduleSlot)
            .WithOne(dss => dss.Appointment)
            .HasForeignKey<Appointment>(a => a.DoctorScheduleSlotId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}