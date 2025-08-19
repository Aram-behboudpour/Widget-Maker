using oc.TSB.Application.Features.Processes.Commands;

namespace oc.TSB.Application.Features.Processes.CommandHandlers;

public class ProcessUpdateCommandHandler : object,
         Faraz.Mediator.IRequestHandler<ProcessUpdateCommand, bool>
{
    public ProcessUpdateCommandHandler(Infrastructure.IUnitOfWork unitOfWork) : base()
    {
        UnitOfWork = unitOfWork;
    }

    protected Infrastructure.IUnitOfWork UnitOfWork { get; }

    public
         async
         System.Threading.Tasks.Task
                   <FluentResults.Result<bool>>
           Handle(ProcessUpdateCommand request,
                    System.Threading.CancellationToken cancellationToken)
    {
        // **************************************************
        var result = new
                      FluentResults.Result<bool>();
        // **************************************************
        try
        {
            var foundedItem =
             await
             UnitOfWork.Processes
             .UpdateProcessAsync(viewmodel: request.viewModel);
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
