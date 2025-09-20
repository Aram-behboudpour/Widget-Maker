using oc.TSB.Application.Features.Processes.Commands;
using oc.TSB.Infrastructure.BaseSearch;
using oc.TSB.Infrastructure.Features.CamundaProcesses.Processes.ViewModels;

namespace oc.TSB.Application.Features.Processes.CommandHandlers;

public class ProcessIndexCommandHandler:object,
         Faraz.Mediator.IRequestHandler<ProcessIndexCommand,
                     BaseSerachResponse<ProcessResultViewModel>>
{
    public ProcessIndexCommandHandler(Infrastructure.IUnitOfWork unitOfWork) :base()
    {
        UnitOfWork = unitOfWork;
    }

    protected Infrastructure.IUnitOfWork UnitOfWork { get; }

    public
    async
    System.Threading.Tasks.Task
   <FluentResults.Result<BaseSerachResponse<ProcessResultViewModel>>>
    Handle(ProcessIndexCommand request,
                       System.Threading.CancellationToken cancellationToken)
    {
        // **************************************************
        var result = new
                      FluentResults.Result<BaseSerachResponse<ProcessResultViewModel>>();

        var response = new BaseSerachResponse<ProcessResultViewModel>();
        // **************************************************
        try
        {
            var processList =
              await
              UnitOfWork.Processes
              .GetByPageAsync(page: 1)
              ;

            var pageCount = processList.PageCount;
            // **************************************************
            // **************************************************
            response.List = processList.List;
            response.PageCount = pageCount;
            response.PageIndex = processList.PageIndex;
            response.RecordCount = processList.RecordCount;
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
