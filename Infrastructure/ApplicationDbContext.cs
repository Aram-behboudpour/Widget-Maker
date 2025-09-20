using Microsoft.EntityFrameworkCore;

namespace oc.TSB.Infrastructure;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    //public ApplicationDbContext
    //    (Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext> options,
    //    MediatR.IMediator mediator) : base(options: options)

    public ApplicationDbContext
       (Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext> options) : base(options: options)
    //(Microsoft.EntityFrameworkCore.DbContextOptions options, MediatR.IMediator mediator) : base(options: options)
    {
        //Mediator = mediator;

        Database.EnsureCreated();
    }
    //**********
    private MediatR.IMediator Mediator { get; }
    public Microsoft.EntityFrameworkCore.DbSet<Core.Features.Logs.Log> Logs { get; set; }
    //**********

    #region CamundaProcess
    public Microsoft.EntityFrameworkCore.DbSet<Core.Features.CamundaProcesses.Process> Processes { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Core.Features.CamundaProcesses.UserTask> UserTasks { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Core.Features.CamundaProcesses.Component> Components { get; set; }

    #endregion /CamundaProcess

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
        modelBuilder.ApplyConfigurationsFromAssembly
            (assembly: typeof(ApplicationDbContext).Assembly);

        modelBuilder.Entity<Core.Features.CamundaProcesses.Process>().ToTable("Processes", schema: Core.Features.CamundaProcesses.Schema.Name);
        modelBuilder.Entity<Core.Features.CamundaProcesses.UserTask>().ToTable("UserTasks", schema: Core.Features.CamundaProcesses.Schema.Name);
        modelBuilder.Entity<Core.Features.CamundaProcesses.Component>().ToTable("Components", schema: Core.Features.CamundaProcesses.Schema.Name);

        base.OnModelCreating(modelBuilder);
    }
}
