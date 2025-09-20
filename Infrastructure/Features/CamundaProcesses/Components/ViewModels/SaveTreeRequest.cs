using System;
using System.Collections.Generic;

namespace oc.TSB.Infrastructure.Features.CamundaProcesses.Components.ViewModels;

public class SaveTreeRequest : object
{
    public SaveTreeRequest() : base()
    {
        Tree = new();
    }
    //**********
    public Guid UserTaskId { get; set; }
    //**********

    //**********
    public Guid ProcessId { get; set; }
    //**********

    //**********
    public List<ComponentViewModel> Tree { get; set; }
    //**********

    //**********
}
