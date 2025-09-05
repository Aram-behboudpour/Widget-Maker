using oc.TSB.Infrastructure.Features.Components.ViewModels;

namespace oc.TSB.Application.Features.Components.Commands;

public class GetComponentDetailsByIdCommand : object,
     Faraz.Mediator.IRequest<ComponentDetailsViewModel>
{
    public GetComponentDetailsByIdCommand() : base()
    {
    }

    public System.Guid ComponentId { get; set; }
}
