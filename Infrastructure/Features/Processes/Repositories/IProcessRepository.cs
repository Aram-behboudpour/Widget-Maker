using oc.TSB.Core.Features.CamundaProcesses;
using oc.TSB.Infrastructure.Features.Processes.ViewModels;
using System;

namespace oc.TSB.Infrastructure.Features.Processes.Repositories;

public interface IProcessRepository : Faraz.Persistance.IRepository<Process,Guid>
{
    System.Threading.Tasks.Task
        <BaseSearch.BaseSerachResponse<ProcessResultViewModel>>
    GetByPageAsync(int page);

    System.Threading.Tasks.Task
        <Microsoft.AspNetCore.Mvc.Rendering.SelectList>
    GetProcessSelectListAsync(object? selectedValue = null);

    System.Threading.Tasks.Task
      <Process> CreateProcessAsync(CreateViewModel viewmodel);

    System.Threading.Tasks.Task
       <DetailsOrDeleteViewModel?> GetDetailsProcessAsync(Guid? id);

    System.Threading.Tasks.Task
           <bool> DeleteProcessAsync(Guid? id);

    System.Threading.Tasks.Task
         <bool> UpdateProcessAsync(UpdateViewModel viewmodel);
}
