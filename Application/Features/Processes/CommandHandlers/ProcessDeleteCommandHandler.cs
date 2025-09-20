using oc.TSB.Application.Features.Processes.Commands;
using oc.TSB.Infrastructure.Features.CamundaProcesses.Processes.ViewModels;

namespace oc.TSB.Application.Features.Processes.CommandHandlers;

public class ProcessDeleteCommandHandler : object,
         Faraz.Mediator.IRequestHandler<ProcessDeleteCommand, bool>
{
    public ProcessDeleteCommandHandler(Infrastructure.IUnitOfWork unitOfWork) : base()
    {
        UnitOfWork = unitOfWork;
    }

    protected Infrastructure.IUnitOfWork UnitOfWork { get; }

    public
         async
         System.Threading.Tasks.Task
                   <FluentResults.Result<bool>>
           Handle(ProcessDeleteCommand request,
                    System.Threading.CancellationToken cancellationToken)
    {
        // **************************************************
        var result = new
                      FluentResults.Result<bool>();
        // **************************************************
        try
        {
            var hasAnyChildren =
             await
             UnitOfWork.UserTaskes
             .GetUserTasksByProcessIdAsync(processId: request.id)
             ;

            if (hasAnyChildren.RecordCount > 0)
            {
                return false;
            }
            // **************************************************
            var foundedItem =
             await
             UnitOfWork.Processes
             .DeleteProcessAsync(id: request.id)
             ;
            // **************************************************

            result.WithValue(value: foundedItem);

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
