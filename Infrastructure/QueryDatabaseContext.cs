using Microsoft.EntityFrameworkCore;

namespace oc.TSB.Infrastructure;

public class QueryDatabaseContext : Microsoft.EntityFrameworkCore.DbContext
{
    public QueryDatabaseContext
        (Microsoft.EntityFrameworkCore.DbContextOptions<QueryDatabaseContext> options) : base(options: options)
    {
        Database.EnsureCreated();
    }

    //**********
    private MediatR.IMediator Mediator { get; }
    //**********
    public Microsoft.EntityFrameworkCore.DbSet<Core.Features.Logs.Log> Logs { get; set; }
    //**********

    #region CamundaProcesses

    public Microsoft.EntityFrameworkCore.DbSet<Core.Features.CamundaProcesses.Process> Processes { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Core.Features.CamundaProcesses.UserTask> UserTasks { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Core.Features.CamundaProcesses.Component> Components { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Core.Features.CamundaProcesses.ComponentTree> ComponentTrees { get; set; }

    #endregion /CamundaProcesses

    #region Identity
    public Microsoft.EntityFrameworkCore.DbSet<Core.Features.Identity.User> Users { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Core.Features.Identity.LoginLog> LoginLogs { get; set; }
    #endregion /Identity

    #region Common Feature
    public Microsoft.EntityFrameworkCore.DbSet<Core.Features.Common.BaseTable> BaseTables { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Core.Features.Common.BaseTableItem> BaseTableItems { get; set; }
    #endregion /Common Feature

    //**********
    protected override void OnModelCreating
        (Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly
            (assembly: typeof(QueryDatabaseContext).Assembly);

        modelBuilder.Entity<Core.Features.CamundaProcesses.Process>().ToTable("Processes", schema: Core.Features.CamundaProcesses.Schema.Name);
        modelBuilder.Entity<Core.Features.CamundaProcesses.UserTask>().ToTable("UserTasks", schema: Core.Features.CamundaProcesses.Schema.Name);
        modelBuilder.Entity<Core.Features.CamundaProcesses.Component>().ToTable("Components", schema: Core.Features.CamundaProcesses.Schema.Name);

        base.OnModelCreating(modelBuilder);
    }
}
