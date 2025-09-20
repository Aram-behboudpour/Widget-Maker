using System;

namespace oc.TSB.Infrastructure.Features.CamundaProcesses.Components.ViewModels;

public class ComponentDetailsViewModel : object
{
    public ComponentDetailsViewModel() : base()
    {
    }
    //**********
    public Guid? Id { get; set; }
    //**********

    //**********
    public string? Name { get; set; }
    //**********

    //**********
    public string? Title { get; set; }
    //**********

    //**********
    public Guid? ParentComponentId { get; set; }
    //**********

    //**********
}
