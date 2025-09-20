using oc.TSB.Application.Features.Components.Commands;
using oc.TSB.Infrastructure.BaseSearch;
using oc.TSB.Infrastructure.Features.CamundaProcesses.Components.ViewModels;

namespace oc.TSB.Application.Features.Components.CommandsHandler;

public class ComponentIndexCommandHandler : object,
         Faraz.Mediator.IRequestHandler<ComponentIndexCommand,
                     BaseSerachResponse<ComponentResultViewModel>>
{
    public ComponentIndexCommandHandler(Infrastructure.IUnitOfWork unitOfWork) : base()
    {
        UnitOfWork = unitOfWork;
    }

    protected Infrastructure.IUnitOfWork UnitOfWork { get; }

    public
      async
      System.Threading.Tasks.Task
      <FluentResults.Result<BaseSerachResponse<ComponentResultViewModel>>>
      Handle(ComponentIndexCommand request,
                         System.Threading.CancellationToken cancellationToken)
    {
        // **************************************************
        var result = new
                      FluentResults.Result<BaseSerachResponse<ComponentResultViewModel>>();

        var response = new BaseSerachResponse<ComponentResultViewModel>();
        // **************************************************
        try
        {
            var componentsList =
              await
              UnitOfWork.Components
              .GetComponentsByIdsAsync(userTaskId: request.UserTaskId)
              ;

            var pageCount = componentsList.PageCount;
            // **************************************************
            // **************************************************
            response.List = componentsList.List;
            response.PageCount = pageCount;
            response.PageIndex = componentsList.PageIndex;
            response.RecordCount = componentsList.RecordCount;
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
