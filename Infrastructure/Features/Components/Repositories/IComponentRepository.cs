using oc.TSB.Core.Features.CamundaProcesses;
using oc.TSB.Core.Features.CamundaProcesses.Enums;
using oc.TSB.Infrastructure.BaseSearch;
using oc.TSB.Infrastructure.Features.Components.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oc.TSB.Infrastructure.Features.Components.Repositories;

public interface IComponentRepository : Faraz.Persistance.IRepository<Component,Guid>
{
    Task<BaseSerachResponse<ComponentResultViewModel>>
        GetComponentsByIdsAsync(Guid? userTaskId);
    Task<List<Component>> GetByIdsAsync(List<Guid> ids);

    Task<Component?> GetByIdAsync(Guid id);

    Task<List<ComponentViewModel>> GetAllComponentsAsync();

    Task<ComponentDetailsViewModel> GetComponentDetailsByIdAsync(Guid id);
    Task<List<Guid>> GetAllComponentIdsAsync(List<ComponentViewModel> tree);
    Task<List<ComponentType>> GetAllComponentTypesAsync(List<ComponentViewModel> tree);
    Task<Guid> GetComponentIdByTypeAsync(ComponentType componentType);
    Task<bool> SaveTreeAsync(List<ComponentViewModel> tree,Guid userTaskId);
}
