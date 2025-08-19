namespace oc.TSB.Infrastructure.Features.Components.Configuration;

internal class ComponentConfiguration : object,
    Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Core.Features.CamundaProcesses.Component>
{
    public ComponentConfiguration() : base()
    {
    }
    public void Configure
(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder
<Core.Features.CamundaProcesses.Component> builder)
    {
        // **************************************************
        //builder
        //	// using Microsoft.EntityFrameworkCore;
        //	.ToTable(name: "Components")
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
     .HasMany(current => current.Children)
     .WithOne(other => other.ParentComponent!)
      .IsRequired(required: false)
      .HasForeignKey(other => other.ParentComponentId)
      .OnDelete(deleteBehavior:
      Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
     ;
        // **************************************************

        // **************************************************
    }
}
