using Microsoft.EntityFrameworkCore;
using oc.TSB.Core.Features.CamundaProcesses;
using oc.TSB.Core.Features.CamundaProcesses.Enums;
using oc.TSB.Infrastructure.Features.Components.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oc.TSB.Infrastructure.Features.Components.Repositories;

public class ComponentRepository :
     Faraz.Persistance.Repository<Component, Guid>, IComponentRepository
{
    protected internal ComponentRepository
    (DbContext databaseContext) : base(databaseContext: databaseContext)
    {
    }

    #region  GetComponentsByIdsAsync(Guid? parentComponentId, Guid? userTaskId)
    public
        async
        System.Threading.Tasks.Task
         <BaseSearch.BaseSerachResponse<ComponentResultViewModel>>

        GetComponentsByIdsAsync(Guid? userTaskId)
    {
        //***********************************
        int page = 1;
        int pageCount = 0;
        var pageSize = 10;

        var result = new
          BaseSearch.BaseSerachResponse<ComponentResultViewModel>();
        //***********************************
        try
        {
            var data =
              Dbset
              .AsQueryable();

            if (userTaskId is not null)
            {
                data = data.Where(current => current.UserTaskId == userTaskId);
            }

            var recordCount = data.Count();

            var List =
                await
                data
                .OrderByDescending(current => current.InsertDateTime)
                .Select(current => new ComponentResultViewModel
                {
                    Id = current.Id,
                    UserTaskId = current.UserTaskId,
                    ParentComponentId = current.ParentComponentId,
                    IsActive = current.IsActive,
                    Title = current.Title,
                    Name = current.Name,
                    UserTaskName = current.UserTask!.Name,
                    ParentComponentName = current.ParentComponent!.Name,
                    Ordering = current.Ordering,
                    InsertDateTime = current.InsertDateTime,
                    UpdateDateTime = current.UpdateDateTime,

                })
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync()
                ;

            if (recordCount >= pageSize)
            {
                pageCount =
                 recordCount / pageSize;
            }
            else pageCount = 1;

            result =
              new BaseSearch.BaseSerachResponse<ComponentResultViewModel>
              {
                  List = List,
                  PageCount = pageCount,
                  RecordCount = recordCount,
              };
        }
        catch (Exception ex)
        {
        }
        return result;
    }

    #endregion /GetComponentsByIdsAsync(Guid? parentComponentId, Guid? userTaskId)

    #region GetByIdsAsync(List<Guid> ids)

    public async Task<List<Component>> GetByIdsAsync(List<Guid> ids)
    {
        return await Dbset.Where(c => ids.Contains(c.Id)).ToListAsync();
    }

    #endregion /GetByIdsAsync(List<Guid> ids)

    #region GetByIdAsync(Guid id)
    public async Task<Component> GetByIdAsync(Guid id)
    {
        var component =
            await
            Dbset.Where(current => current.Id == id)
            .FirstOrDefaultAsync();

        return component;
    }
    #endregion /GetByIdAsync(Guid id)

    #region GetAllComponentsAsync()
    public async Task<List<ComponentViewModel>> GetAllComponentsAsync()
    {
        var List =
               await
               Dbset
               .Where(current => current.IsTestData == true)
               .OrderByDescending(current => current.InsertDateTime)
               .Select(current => new ComponentViewModel
               {
                   ComponentId = current.Id,
                   ParentComponentId = current.ParentComponentId,
                   ComponentType = current.ComponentType,
                   Type = current.ComponentType.ToString(),

               })
               .ToListAsync()
               ;

        return List;
    }
    #endregion /GetAllComponentsAsync()

    #region GetComponentDetailsByIdAsync(Guid id)
    public async Task<ComponentDetailsViewModel> GetComponentDetailsByIdAsync(Guid id)
    {
        var component =
            await
            Dbset.FirstOrDefaultAsync(current => current.Id == id);

        if (component == null)
        {
            return null;
        }

        return new ComponentDetailsViewModel
        {
            Id = component.Id,
            Name = component.Name,
            Title = component.Title,
            ParentComponentId = component.ParentComponentId
        };
    }
    #endregion /GetComponentDetailsByIdAsync(Guid id)

    #region GetAllComponentsAsync()
    public Task<List<Guid>> GetAllComponentIdsAsync(List<ComponentViewModel> tree)
    {
        var allComponentIds =
            tree.Select(x => x.ComponentId).ToList();

        return Task.FromResult(allComponentIds);
    }

    #endregion /GetAllComponentsAsync()

    #region GetAllComponentTypesAsync()
    public Task<List<ComponentType>> GetAllComponentTypesAsync(List<ComponentViewModel> tree)
    {
        var allComponentTypes =
            tree.Select(x => x.ComponentType).ToList();

        return Task.FromResult(allComponentTypes);
    }

    #endregion /GetAllComponentTypesAsync()

    #region GetComponentIdByTypeAsync()
    public async Task<Guid> GetComponentIdByTypeAsync(ComponentType componentType)
    {
        var ListItem =
               await
               Dbset
               .Where(current => current.ComponentType == componentType)
               .OrderByDescending(current => current.InsertDateTime)
               .FirstOrDefaultAsync()
               ;

        return ListItem!.Id;
    }

    #endregion /GetComponentIdByTypeAsync()

    #region SaveTreeAsync()
    public async Task<bool> SaveTreeAsync(List<ComponentViewModel> tree, Guid userTaskId)
    {
        try
        {
            foreach (var item in tree)
            {
                switch (item.Type)
                {
                    case "Space":
                        item.ComponentType = ComponentType.Space;
                        break;

                    case "CheckBox":
                        item.ComponentType = ComponentType.CheckBox;
                        break;

                    case "Amount":
                        item.ComponentType = ComponentType.Amount;
                        break;

                    case "Button":
                        item.ComponentType = ComponentType.Button;
                        break;

                    case "SourcePan":
                        item.ComponentType = ComponentType.SourcePan;
                        break;

                    case "SearchList":
                        item.ComponentType = ComponentType.SearchList;
                        break;

                    case "MobileNumber":
                        item.ComponentType = ComponentType.MobileNumber;
                        break;

                    case "DestinationMobileNumber":
                        item.ComponentType = ComponentType.DestinationMobileNumber;
                        break;

                    case "DestinationType":
                        item.ComponentType = ComponentType.DestinationType;
                        break;

                    case "DestinationPan":
                        item.ComponentType = ComponentType.DestinationPan;
                        break;

                    case "RadioGroup":
                        item.ComponentType = ComponentType.RadioGroup;
                        break;

                    case "TextInput":
                        item.ComponentType = ComponentType.TextInput;
                        break;
                }

                var component = new Component
                {
                    IsActive = true,
                    IsTestData = false,
                    Name = item.Type,
                    Title = item.Type,
                    ComponentType = item.ComponentType,
                    UserTaskId = userTaskId,
                    Ordering= item.Order,
                };

                if (item.ParentComponentId is not null)
                {
                    var ListItem =
                      await
                      Dbset
                      .Where(current => current.ComponentType == item.ComponentType)
                      .OrderByDescending(current => current.InsertDateTime)
                      .FirstOrDefaultAsync()
                      ;

                    component.ParentComponentId = ListItem!.Id;
                }

                var entityEntry =
                    await
                    DatabaseContext.AddAsync(entity: component);
            }

            var affectedRows =
                await
                DatabaseContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    #endregion /SaveTreeAsync()
}
