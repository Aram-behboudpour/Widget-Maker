namespace oc.TSB.Infrastructure.Features.UserTaskes.ViewModels;

public class UserTaskResultViewModel : object
{
    public UserTaskResultViewModel() : base()
    {
    }
    //**********
    public System.Guid Id { get; set; }
    //**********

    //**********
    public System.Guid? ProcessId { get; set; }
    //**********

    //**********
    public string? Title { get; set; }
    //**********

    //**********
    public string? Name { get; set; }
    //**********

    //**********
    public string? ProcessName { get; set; }
    //**********

    //**********
    public bool IsActive { get; set; }
    //**********

    //**********
    public bool Version { get; set; }
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
