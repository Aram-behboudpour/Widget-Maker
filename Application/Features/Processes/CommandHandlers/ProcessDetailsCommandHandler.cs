using oc.TSB.Application.Features.Processes.Commands;
using oc.TSB.Infrastructure.Features.Processes.ViewModels;

namespace oc.TSB.Application.Features.Processes.CommandHandlers;

public class ProcessDetailsCommandHandler : object,
         Faraz.Mediator.IRequestHandler<ProcessDetailsCommand, DetailsOrDeleteViewModel>
{
    public ProcessDetailsCommandHandler(Infrastructure.IUnitOfWork unitOfWork) : base()
    {
        UnitOfWork = unitOfWork;
    }

    protected Infrastructure.IUnitOfWork UnitOfWork { get; }

    public
    async
    System.Threading.Tasks.Task
              <FluentResults.Result<DetailsOrDeleteViewModel>>
    Handle(ProcessDetailsCommand request,
                       System.Threading.CancellationToken cancellationToken)
    {
        // **************************************************
        var result = new
                      FluentResults.Result<DetailsOrDeleteViewModel>();
        // **************************************************
        try
        {
            var deletedProcess =
              await
              UnitOfWork.Processes
              .GetDetailsProcessAsync(id: request.id)
              ;
            // **************************************************
            // **************************************************
     
            result.WithValue(value: deletedProcess!);

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
