using oc.TSB.Infrastructure.Features.CamundaProcesses.Components.ViewModels;
using System.Collections.Generic;

namespace oc.TSB.Application.Features.Components.Commands;

public class GetAllComponentsCommand:object,
     Faraz.Mediator.IRequest<List<ComponentViewModel>>
{
    public GetAllComponentsCommand():base()
    {         
    }
}
