using oc.TSB.Application.Features.UserTasks.Commands;
using oc.TSB.Infrastructure.BaseSearch;
using oc.TSB.Infrastructure.Features.CamundaProcesses.UserTaskes.ViewModels;

namespace oc.TSB.Application.Features.UserTasks.CommandHandlers;

public class UserTaskIndexCommandHandler : object,
         Faraz.Mediator.IRequestHandler<UserTaskIndexCommand,
                     BaseSerachResponse<UserTaskResultViewModel>>
{
    public UserTaskIndexCommandHandler(Infrastructure.IUnitOfWork unitOfWork) : base()
    {
        UnitOfWork = unitOfWork;
    }

    protected Infrastructure.IUnitOfWork UnitOfWork { get; }

    public
        async
        System.Threading.Tasks.Task
        <FluentResults.Result<BaseSerachResponse<UserTaskResultViewModel>>>
        Handle(UserTaskIndexCommand request,
                           System.Threading.CancellationToken cancellationToken)
    {
        // **************************************************
        var result = new
                      FluentResults.Result<BaseSerachResponse<UserTaskResultViewModel>>();

        var response = new BaseSerachResponse<UserTaskResultViewModel>();
        // **************************************************
        try
        {
            var userTasksList =
              await
              UnitOfWork.UserTaskes
              .GetUserTasksByProcessIdAsync(processId:request.ProcessId)
              ;

            var pageCount = userTasksList.PageCount;
            // **************************************************
            // **************************************************
            response.List = userTasksList.List;
            response.PageCount = pageCount;
            response.PageIndex = userTasksList.PageIndex;
            response.RecordCount = userTasksList.RecordCount;
            // **************************************************

            result.WithValue(value: response);

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
