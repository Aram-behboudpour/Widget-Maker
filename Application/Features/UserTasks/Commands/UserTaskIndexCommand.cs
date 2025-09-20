using oc.TSB.Infrastructure.Features.CamundaProcesses.UserTaskes.ViewModels;

namespace oc.TSB.Application.Features.UserTasks.Commands;

public class UserTaskIndexCommand : object,
    Faraz.Mediator.IRequest<Infrastructure.BaseSearch.BaseSerachResponse
                       <UserTaskResultViewModel>>
{
    public UserTaskIndexCommand()
    {          
    }
    //**********
    public System.Guid? ProcessId { get; set; }
    //**********

    //**********
}
