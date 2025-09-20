using oc.TSB.Infrastructure.Features.CamundaProcesses.Components.ViewModels;
using System;
using System.Collections.Generic;

namespace oc.TSB.Application.Features.Components.Commands;

public class SaveTreeCommand : object,
    Faraz.Mediator.IRequest<string>
{
    public SaveTreeCommand() : base()
    {
        Tree = new();
    }
    public Guid ProcessId { get; set; }
    public Guid UserTaskId { get; set; }
    public List<ComponentViewModel> Tree { get; set; }
}
