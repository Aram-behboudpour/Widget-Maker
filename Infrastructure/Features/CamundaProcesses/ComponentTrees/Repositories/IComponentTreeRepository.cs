using oc.TSB.Core.Features.CamundaProcesses;
using System;
using System.Threading.Tasks;

namespace oc.TSB.Infrastructure.Features.CamundaProcesses.ComponentTrees.Repositories;

public interface IComponentTreeRepository : Faraz.Persistance.IRepository<ComponentTree, Guid>
{
    Task SaveTreeJsonAsync(Guid userTaskId, string treeJson);
    Task<int> GetLatestVersionUserTaskAsync(Guid userTaskId);
}
