using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments").HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.Name).HasColumnName("Name").IsRequired();
        builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(d => d.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(d => !d.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }

    private IEnumerable<Department> _seeds
    {
        get
        {
            yield return new() { Id = 1, Name = "Kardioloji" };
            yield return new() { Id = 2, Name = "KBB" };
            yield return new() { Id = 3, Name = "Beyin ve Sinir Cerrahisi" };
            yield return new() { Id = 4, Name = "Göz Hastalýklarý" };
            yield return new() { Id = 5, Name = "Dermatoloji" };
        }
    }
}