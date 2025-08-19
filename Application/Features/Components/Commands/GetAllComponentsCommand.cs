using oc.TSB.Core.Features.CamundaProcesses;
using System.Collections.Generic;

namespace oc.TSB.Application.Features.Components.Commands;

public class GetAllComponentsCommand:object,
     Faraz.Mediator.IRequest<List<Component>>
{
    public GetAllComponentsCommand():base()
    {         
    }
}
