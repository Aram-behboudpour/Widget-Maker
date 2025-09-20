namespace oc.TSB.Infrastructure.Features.Common.Configuration;

internal sealed class BaseTableItemConfiguration : object, Microsoft
    .EntityFrameworkCore.IEntityTypeConfiguration<Core.Features.Common.BaseTableItem>
{
    public BaseTableItemConfiguration() : base()
    {
    }

    public void Configure(Microsoft.EntityFrameworkCore.Metadata
        .Builders.EntityTypeBuilder<Core.Features.Common.BaseTableItem> builder)
    {
        // **************************************************
        // **************************************************
        // **************************************************
        ////using Microsoft.EntityFrameworkCore;
        //builder.ToTable(nameof(DatabaseContext.BaseTableItems),
        //	schema: Domain.Features.Common.Schema.Name);
        // **************************************************
        // **************************************************
        // **************************************************

        // **************************************************
        // **************************************************
        // **************************************************
        builder
            .Property(current => current.KeyName)
            .IsUnicode(unicode: false)
            ;

        builder
            .HasIndex(current => new { current.BaseTableId, current.KeyName })
            .IsUnique(unique: true)
            ;
        // **************************************************

        // **************************************************
        builder
            .HasIndex(current => new { current.BaseTableId, current.Code })
            .IsUnique(unique: true)
            ;
        // **************************************************
        // **************************************************
        // **************************************************

        // **************************************************
        // **************************************************
        // **************************************************
        builder
            .HasMany(current => current.Users_Role)
            .WithOne(other => other.Role)
            // Note: Is Not Required!
            .IsRequired(required: false)
            .HasForeignKey(other => other.RoleId)
            .OnDelete(deleteBehavior:
                Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
            ;
        // **************************************************

        // **************************************************
        builder
            .HasMany(current => current.Users_Gender)
            .WithOne(other => other.Gender)
            // Note: Is Not Required!
            .IsRequired(required: false)
            .HasForeignKey(other => other.GenderId)
            .OnDelete(deleteBehavior:
                Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
            ;
        // **************************************************

        // **************************************************
    }
}
