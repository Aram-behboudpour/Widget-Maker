using Microsoft.EntityFrameworkCore;

namespace oc.TSB.Infrastructure.Features.CamundaProcesses.UserTaskes.Configuration;

internal class UserTaskConfiguration : object,
    IEntityTypeConfiguration<Core.Features.CamundaProcesses.UserTask>
{
    public UserTaskConfiguration() : base()
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
           .IsClustered(clustered: false)
           ;
        // **************************************************

        // **************************************************
        builder
           .Property(current => current.Title)
           .IsUnicode(unicode: false)
           ;
        // **************************************************

        // **************************************************
        builder
         .HasMany(current => current.Components)
         .WithOne(other => other.UserTask!)
          .IsRequired(required: true)
          .HasForeignKey(other => other.UserTaskId)
          .OnDelete(deleteBehavior:
          DeleteBehavior.NoAction)
         ;
        // **************************************************

        // **************************************************
        builder
            .HasMany(current => current.ComponentTrees)
            .WithOne(other => other.UserTask!)
             .IsRequired(required: true)
             .HasForeignKey(other => other.UserTaskId)
             .OnDelete(deleteBehavior:
             DeleteBehavior.NoAction)
            ;
        // **************************************************

        // **************************************************
    }
}
