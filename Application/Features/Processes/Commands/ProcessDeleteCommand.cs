namespace oc.TSB.Application.Features.Processes.Commands;

public class ProcessDeleteCommand: object,
    Faraz.Mediator.IRequest<bool>
{
    public ProcessDeleteCommand():base()
    {         
    }
    //**********
    public System.Guid? id { get; set; }
    //**********

    //**********
}
