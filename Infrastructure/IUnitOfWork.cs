using oc.TSB.Infrastructure.Features.CamundaProcesses.Components.Repositories;
using oc.TSB.Infrastructure.Features.CamundaProcesses.ComponentTrees.Repositories;
using oc.TSB.Infrastructure.Features.CamundaProcesses.Processes.Repositories;
using oc.TSB.Infrastructure.Features.CamundaProcesses.UserTaskes.Repositories;

namespace oc.TSB.Infrastructure;

public interface IUnitOfWork : Faraz.Persistance.IUnitOfWork
{
    public Features.Logs.Repositories.ILogRepository Logs { get; }

    public IProcessRepository Processes { get; }
    public IUserTaskRepository UserTaskes { get; }
    public IComponentRepository Components { get; }
    public IComponentTreeRepository ComponentTrees { get; }
}
