using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessManager.Domain.Entities;

namespace ProcessManager.Infrastructure.Data.Mappings;

public class ProcessMap : IEntityTypeConfiguration<Process>
{
    public void Configure(EntityTypeBuilder<Process> builder)
    {
        builder.ToTable("Processes");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(p => p.SubProcesses)
            .WithOne()
            .HasForeignKey(p => p.ParentProcessId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
