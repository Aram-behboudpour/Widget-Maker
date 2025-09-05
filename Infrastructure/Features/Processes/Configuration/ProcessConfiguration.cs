namespace oc.TSB.Infrastructure.Features.Processes.Configuration;

internal class ProcessConfiguration : object,
    Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Core.Features.CamundaProcesses.Process>
{
    public ProcessConfiguration() : base()
    {
    }

    public void Configure
    (Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder
    <Core.Features.CamundaProcesses.Process> builder)
    {
        // **************************************************
        //builder
        //	// using Microsoft.EntityFrameworkCore;
        //	.ToTable(name: "Processes")
        //	;
        // **************************************************

        // **************************************************
        builder
            .HasKey(current => current.Id)
            ;
        // **************************************************

        // **************************************************

        // **************************************************
        builder
     .HasMany(current => current.UserTasks)
     .WithOne(other => other.Process!)
      .IsRequired(required: true)
      .HasForeignKey(other => other.ProcessId)
      .OnDelete(deleteBehavior:
      Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
     ;
        // **************************************************

        // **************************************************
        builder
            .HasIndex(current => new { current.Id, current.Version })
            .IsUnique(unique: true)
            ;
        // **************************************************
        // **************************************************
        // **************************************************
    }
}
