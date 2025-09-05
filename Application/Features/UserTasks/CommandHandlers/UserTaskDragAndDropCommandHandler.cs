using oc.TSB.Application.Features.UserTasks.Commands;

namespace oc.TSB.Application.Features.UserTasks.CommandHandlers;

public class UserTaskDragAndDropCommandHandler: object,
      Faraz.Mediator.IRequestHandler<UserTaskDragAndDropCommand,
       Microsoft.AspNetCore.Mvc.Rendering.SelectList>
{
    public UserTaskDragAndDropCommandHandler(Infrastructure.IUnitOfWork unitOfWork) : base()
    {
        UnitOfWork = unitOfWork;
    }
    protected Infrastructure.IUnitOfWork UnitOfWork { get; }

    public
        async
         System.Threading.Tasks.Task
         <FluentResults.Result
            <Microsoft.AspNetCore.Mvc.Rendering.SelectList>>

        Handle(UserTaskDragAndDropCommand request,
                   System.Threading.CancellationToken cancellationToken)
    {
        // **************************************************
        var result = new
                      FluentResults.Result<Microsoft.AspNetCore.Mvc.Rendering.SelectList>();
        // **************************************************
        try
        {
            var userTasksSelectList =
              await
              UnitOfWork.UserTaskes
              .GetUserTaskSelectListAsync()
              ;

            // **************************************************

            result.WithValue(value: userTasksSelectList);

        }
        catch (System.Exception ex)
        {
            // Logger.LogError(exception: ex, message: ex.Message);

            result.WithError
                (errorMessage: ex.Message);
        }

        return result;
    }
}
