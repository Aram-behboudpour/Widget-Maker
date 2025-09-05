using oc.TSB.Core.Features.CamundaProcesses;
using oc.TSB.Infrastructure.Features.UserTaskes.ViewModels;
using System;
using System.Threading.Tasks;

namespace oc.TSB.Infrastructure.Features.UserTaskes.Repositories;

public interface IUserTaskRepository : Faraz.Persistance.IRepository<UserTask,Guid>
{
    Task
      <BaseSearch.BaseSerachResponse<UserTaskResultViewModel>>
   GetUserTasksByProcessIdAsync(Guid? processId);

    Task
       <Microsoft.AspNetCore.Mvc.Rendering.SelectList>
      GetUserTaskSelectListAsync(object? selectedValue = null);
    Task<UserTask> CreateByProcessIdAsync(string title, string name, Guid processId);
    Task<UserTask?> GetUserTaskByIdAsync(Guid id);
}
