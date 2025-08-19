namespace oc.TSB.Infrastructure.Features.UserTaskes.Configuration;

internal class UserTaskConfiguration: object,
    Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Core.Features.CamundaProcesses.UserTask>
{
    public UserTaskConfiguration():base()
    {           
    }
    public void Configure
  (Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder
  <Core.Features.CamundaProcesses.UserTask> builder)
    {
        // **************************************************
        //builder
        //	// using Microsoft.EntityFrameworkCore;
        //	.ToTable(name: "UserTasks")
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
     .HasMany(current => current.Components)
     .WithOne(other => other.UserTask!)
      .IsRequired(required: true)
      .HasForeignKey(other => other.UserTaskId)
      .OnDelete(deleteBehavior:
      Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
     ;
        // **************************************************

        // **************************************************
    }
}
