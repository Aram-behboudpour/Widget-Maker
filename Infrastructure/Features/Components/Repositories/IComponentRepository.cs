using oc.TSB.Core.Features.CamundaProcesses;
using oc.TSB.Infrastructure.Features.Components.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oc.TSB.Infrastructure.Features.Components.Repositories;

public interface IComponentRepository : Faraz.Persistance.IRepository<Component,Guid>
{
    System.Threading.Tasks.Task
  <BaseSearch.BaseSerachResponse<ComponentResultViewModel>>
     GetComponentsByIdsAsync(Guid? userTaskId);

    Task<List<Component>> GetByIdsAsync(List<Guid> ids);

    Task<Component> GetByIdAsync(Guid id);

    Task<List<Component>> GetAllComponentsAsync();
}
