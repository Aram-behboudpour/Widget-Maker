namespace oc.TSB.Infrastructure;

public interface IUnitOfWork : Faraz.Persistance.IUnitOfWork
{
    public Features.Logs.Repositories.ILogRepository Logs { get; }

    public Features.Processes.Repositories.IProcessRepository Processes { get; }
    public Features.UserTaskes.Repositories.IUserTaskRepository UserTaskes { get; }
    public Features.Components.Repositories.IComponentRepository Components { get; }
}
