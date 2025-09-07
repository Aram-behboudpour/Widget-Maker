using oc.TSB.Core.Features.CamundaProcesses;
using oc.TSB.Infrastructure.Features.Processes.ViewModels;
using System;
using System.Threading.Tasks;

namespace oc.TSB.Infrastructure.Features.Processes.Repositories;

public interface IProcessRepository : Faraz.Persistance.IRepository<Process,Guid>
{
    Task<BaseSearch.BaseSerachResponse<ProcessResultViewModel>>GetByPageAsync(int page);
    Task<Microsoft.AspNetCore.Mvc.Rendering.SelectList>
    GetProcessSelectListAsync(object? selectedValue = null);
    Task<Process?> CreateProcessAsync(CreateViewModel viewmodel);
    Task<DetailsOrDeleteViewModel?> GetDetailsProcessAsync(Guid? id);
    Task<bool> DeleteProcessAsync(Guid? id);
    Task<bool> UpdateProcessAsync(UpdateViewModel viewmodel);
    Task<int> GetLatestVersionProcessAsync(string title);
    Task<Process?> GetProcessByIdAsync(Guid id);
}
