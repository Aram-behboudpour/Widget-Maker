using Microsoft.EntityFrameworkCore;
using oc.TSB.Core.Features.CamundaProcesses;
using oc.TSB.Infrastructure.Features.Components.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oc.TSB.Infrastructure.Features.Components.Repositories;

public class ComponentRepository :
     Faraz.Persistance.Repository<Component,Guid>, IComponentRepository
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
        var component = await Dbset.FirstOrDefaultAsync(current => current.Id == id);

        if (component == null)
        {
            return null;
        }
        return component;
    }
    #endregion /GetByIdAsync(Guid id)

    #region GetAllComponentsAsync()

    public async Task<List<Component>> GetAllComponentsAsync()
    {
        return await Dbset.ToListAsync();
    }

    #endregion /GetAllComponentsAsync()
}
