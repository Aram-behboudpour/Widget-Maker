using oc.TSB.Infrastructure.Features.Processes.ViewModels;

namespace oc.TSB.Application.Features.Processes.Commands;

public class ProcessIndexCommand: object,
    Faraz.Mediator.IRequest<Infrastructure.BaseSearch.BaseSerachResponse
                       <ProcessResultViewModel>>
{
    public ProcessIndexCommand():base()
    {          
    }
}
