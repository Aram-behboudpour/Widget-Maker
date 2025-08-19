using oc.TSB.Core.Features.CamundaProcesses;
using oc.TSB.Infrastructure.Features.UserTaskes.ViewModels;
using System;

namespace oc.TSB.Infrastructure.Features.UserTaskes.Repositories;

public interface IUserTaskRepository : Faraz.Persistance.IRepository<UserTask,Guid>
{
    System.Threading.Tasks.Task
      <BaseSearch.BaseSerachResponse<UserTaskResultViewModel>>
   GetUserTasksByProcessIdAsync(Guid? processId);

    System.Threading.Tasks.Task
       <Microsoft.AspNetCore.Mvc.Rendering.SelectList>
      GetUserTaskSelectListAsync(object? selectedValue = null);
}
