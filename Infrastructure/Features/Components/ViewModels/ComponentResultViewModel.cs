namespace oc.TSB.Infrastructure.Features.Components.ViewModels;

public class ComponentResultViewModel : object
{
    public ComponentResultViewModel() : base()
    {
    }
    //**********
    public System.Guid Id { get; set; }
    //**********

    //**********
    public System.Guid? UserTaskId { get; set; }
    //**********

    //**********
    public System.Guid? ParentComponentId { get; set; }
    //**********

    //**********
    public string? Title { get; set; }
    //**********

    //**********
    public string? Name { get; set; }
    //**********

    //**********
    public string? UserTaskName { get; set; }
    //**********

    //**********
    public bool IsActive { get; set; }
    //**********

    //**********
    public string? ParentComponentName { get; set; }
    //**********

    //**********
    public int Ordering { get; set; }
    //**********

    //**********
    public System.DateTimeOffset InsertDateTime { get; set; }
    //**********

    //**********
    public System.DateTimeOffset? UpdateDateTime { get; set; }
    //**********

    //**********
}
