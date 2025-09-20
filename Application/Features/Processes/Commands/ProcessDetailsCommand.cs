using oc.TSB.Infrastructure.Features.CamundaProcesses.Processes.ViewModels;

namespace oc.TSB.Application.Features.Processes.Commands;

public class ProcessDetailsCommand :object,
    Faraz.Mediator.IRequest<DetailsOrDeleteViewModel>
{
    public ProcessDetailsCommand():base()
    {
    }
    //**********
    public System.Guid? id { get; set; }
    //**********

    //**********
}
