using oc.TSB.Infrastructure.Features.Processes.ViewModels;

namespace oc.TSB.Application.Features.Processes.Commands;

public class ProcessUpdateCommand : object,
     Faraz.Mediator.IRequest<bool>
{
    public ProcessUpdateCommand() : base()
    {
        viewModel = new();
    }
    //**********
    public UpdateViewModel viewModel { get; set; }
    //**********

    //**********
}
