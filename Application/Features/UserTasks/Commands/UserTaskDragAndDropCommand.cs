namespace oc.TSB.Application.Features.UserTasks.Commands;

public class UserTaskDragAndDropCommand: object,
         Faraz.Mediator.IRequest<Microsoft.AspNetCore.Mvc.Rendering.SelectList>
{
    public UserTaskDragAndDropCommand():base()
    {           
    }
    public System.Guid? UserTaskId { get; set; }
}
