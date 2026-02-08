using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessManager.Domain.Entities;

namespace ProcessManager.Infrastructure.Data.Mappings;

public class AreaMap : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder.ToTable("Areas");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(a => a.Processes)
            .WithOne()
            .HasForeignKey(p => p.AreaId);
    }
}
