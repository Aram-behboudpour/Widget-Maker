using oc.TSB.Core.Features.CamundaProcesses;
using oc.TSB.Infrastructure.Features.Processes.ViewModels;

namespace oc.TSB.Application.Features.Processes.Commands;

public class ProcessCreateCommand : object,
    Faraz.Mediator.IRequest<Process?>
{
    public ProcessCreateCommand() : base()
    {
        viewModel = new();
    }
    //**********
    public CreateViewModel viewModel { get; set; }
    //**********

    //**********
}
