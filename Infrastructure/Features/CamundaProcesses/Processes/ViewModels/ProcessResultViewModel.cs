namespace oc.TSB.Infrastructure.Features.CamundaProcesses.Processes.ViewModels;

public class ProcessResultViewModel:object
{
    public ProcessResultViewModel() : base()
    {
    }
    //**********
    public System.Guid Id { get; set; }
    //**********

    //**********
    public string? Title { get; set; }
    //**********

    //**********
    public string? Name { get; set; }
    //**********

    //**********
    public bool IsActive { get; set; }
    //**********

    //**********
    public int? Version { get; set; }
    //**********

    //**********
    public int Ordering { get; set; }
    //**********

    //**********
    public bool IsTestData { get; set; }
    //**********

    //**********
    public System.DateTimeOffset InsertDateTime { get; set; }
    //**********

    //**********
    public System.DateTimeOffset? UpdateDateTime { get; set; }
    //**********

    //**********
}
