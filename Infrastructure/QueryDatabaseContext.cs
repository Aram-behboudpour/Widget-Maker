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

    #endregion /CamundaProcesses

    #region Identity Feature
    //public Microsoft.EntityFrameworkCore.DbSet<Core.Features.Identity.User> Users { get; set; }
    #endregion /Identity Feature

    //**********
    protected override void OnModelCreating
        (Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
