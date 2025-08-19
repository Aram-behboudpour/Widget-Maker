namespace oc.TSB.Application.Features.Processes.Commands;

public class ProcessDragAndDropCommand:object,
         Faraz.Mediator.IRequest<Microsoft.AspNetCore.Mvc.Rendering.SelectList>
{
    public ProcessDragAndDropCommand():base()
    {           
    }
    public System.Guid? ProcessId { get; set; }
}
