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

    //**********
    protected override void OnModelCreating
        (Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly
            (assembly: typeof(ApplicationDbContext).Assembly);
    }
}
