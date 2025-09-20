namespace oc.TSB.Infrastructure.Features.Common.Configuration;

internal sealed class BaseTableConfiguration : object, Microsoft
    .EntityFrameworkCore.IEntityTypeConfiguration<Core.Features.Common.BaseTable>
{
    public BaseTableConfiguration() : base()
    {
    }

    public void Configure(Microsoft.EntityFrameworkCore.Metadata
        .Builders.EntityTypeBuilder<Core.Features.Common.BaseTable> builder)
    {
        // **************************************************
        // **************************************************
        // **************************************************
        ////using Microsoft.EntityFrameworkCore;
        //builder.ToTable(nameof(DatabaseContext.BaseTables),
        //	schema: Domain.Features.Common.Schema.Name);
        // **************************************************
        // **************************************************
        // **************************************************

        // **************************************************
        // **************************************************
        // **************************************************
        builder
            .HasIndex(current => new { current.Code })
            .IsUnique(unique: true)
            ;
        // **************************************************
        // **************************************************
        // **************************************************

        // **************************************************
        // **************************************************
        // **************************************************
        builder
            .HasMany(current => current.BaseTableItems)
            .WithOne(other => other.BaseTable)
            .IsRequired(required: true)
            .HasForeignKey(other => other.BaseTableId)
            .OnDelete(deleteBehavior:
                Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
            ;
        // **************************************************
        // **************************************************
        // **************************************************
    }
}