using Microsoft.EntityFrameworkCore;
using oc.TSB.Core.Features.CamundaProcesses;
using oc.TSB.Infrastructure.Features.CamundaProcesses.UserTaskes.ViewModels;
using oc.TSB.Infrastructure.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace oc.TSB.Infrastructure.Features.CamundaProcesses.UserTaskes.Repositories;

public class UserTaskRepository :
      Faraz.Persistance.Repository<UserTask, Guid>, IUserTaskRepository
{
    protected internal UserTaskRepository
       (DbContext databaseContext) : base(databaseContext: databaseContext)
    {
    }

    #region  GetUserTasksByProcessIdAsync(Guid? processId)
    public
        async
        Task
         <BaseSearch.BaseSerachResponse<UserTaskResultViewModel>>

        GetUserTasksByProcessIdAsync(Guid? processId)
    {
        //***********************************
        int page = 1;
        int pageCount = 0;
        var pageSize = 10;

        var result = new
          BaseSearch.BaseSerachResponse<UserTaskResultViewModel>();
        //***********************************
        try
        {
            var data =
              Dbset
              .AsQueryable();

            if (processId is not null)
            {
                data = data.Where(current => current.ProcessId == processId);
            }
            var recordCount = data.Count();

            var List =
                await
                data
                .OrderByDescending(current => current.InsertDateTime)
                .Select(current => new UserTaskResultViewModel
                {
                    Id = current.Id,
                    ProcessId = current.ProcessId,
                    IsActive = current.IsActive,
                    Title = current.Title,
                    Name = current.Name,
                    ProcessName = current.Process!.Name,
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
              new BaseSearch.BaseSerachResponse<UserTaskResultViewModel>
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

    #endregion /GetUserTasksByProcessIdAsync(Guid? processId)

    #region GetUserTaskSelectListAsync()
    public async Task
        <Microsoft.AspNetCore.Mvc.Rendering.SelectList> GetUserTaskSelectListAsync
        (object? selectedValue = null)
    {
        var list =
            await
             Dbset

            .OrderBy(current => current.Ordering)

            .Select(current => new IdNameViewModel<Guid?>
            {
                Id = current.Id,
                KeyName = current.Title,
            })
            .ToListAsync()
            ;

        // **************************************************
        var emptyItem =
            new IdNameViewModel<Guid?>
            (id: null, keyName: Resources.DataDictionary.SelectAnItem);

        list.Insert(index: 0, item: emptyItem);
        // **************************************************

        var result =
            new Microsoft.AspNetCore.Mvc.Rendering
            .SelectList(items: list, selectedValue: selectedValue,
            dataTextField: IdNameViewModel<int>.DataTextField,
            dataValueField: IdNameViewModel<int>.DataValueField);

        return result;
    }

    #endregion /GetUserTaskSelectListAsync()

    #region CreateByProcessIdAsync
    public async Task
              <UserTask> CreateByProcessIdAsync(string title, string name, Guid processId)
    {
        UserTask newEntity = new(title: string.Empty, name: string.Empty);
        try
        {
            newEntity =
          new UserTask(title: title, name: name)
          {
              Title = title,
              Name = name,
              IsActive = true,
              ProcessId = processId,
          };

            var entityEntry =
                await
                DatabaseContext.AddAsync(entity: newEntity);

            var affectedRows =
                await
                DatabaseContext.SaveChangesAsync();
        }
        catch (Exception)
        {
        }

        return newEntity;
    }
    #endregion /CreateByProcessIdAsync

    #region GetUserTaskByIdAsync
    public async Task
              <UserTask?> GetUserTaskByIdAsync(Guid id)
    {
        var userTask = new UserTask(title: string.Empty, name: string.Empty);
        try
        {
            userTask =
                await
                Dbset
                .Where(current => current.Id == id)
                .FirstOrDefaultAsync();

            if (userTask == null)
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
        return userTask;
    }
    #endregion /GetUserTaskByIdAsync
}
