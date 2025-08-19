using oc.TSB.Infrastructure.Features.Components.ViewModels;

namespace oc.TSB.Application.Features.Components.Commands;

public class ComponentIndexCommand : object,
    Faraz.Mediator.IRequest<Infrastructure.BaseSearch.BaseSerachResponse
                       <ComponentResultViewModel>>
{
    public ComponentIndexCommand()
    {
    }
    //**********
    public System.Guid? UserTaskId { get; set; }
    //**********

    //**********
}
