using oc.TSB.Application.Features.Processes.Commands;
using oc.TSB.Core.Features.CamundaProcesses;

namespace oc.TSB.Application.Features.Processes.CommandHandlers;

public class ProcessCreateCommandHandler : object,
         Faraz.Mediator.IRequestHandler<ProcessCreateCommand,Process>
{
    public ProcessCreateCommandHandler(Infrastructure.IUnitOfWork unitOfWork) : base()
    {
        UnitOfWork = unitOfWork;
    }
    protected Infrastructure.IUnitOfWork UnitOfWork { get; }

    public
        async
        System.Threading.Tasks.Task
        <FluentResults.Result<Process>>
        Handle(ProcessCreateCommand request,
                           System.Threading.CancellationToken cancellationToken)
    {
        // **************************************************
        var result = new
                      FluentResults.Result<Process>();
        // **************************************************
        try
        {
            var process =
              await
              UnitOfWork.Processes
              .CreateProcessAsync(viewmodel: request.viewModel)
              ;
            // **************************************************

            result.WithValue(value: process);

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
