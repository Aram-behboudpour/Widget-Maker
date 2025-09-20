using oc.TSB.Application.Features.Components.Commands;
using oc.TSB.Infrastructure.BaseSearch;
using oc.TSB.Infrastructure.Features.CamundaProcesses.Components.ViewModels;

namespace oc.TSB.Application.Features.Components.CommandsHandler;

public class GetComponentDetailsByIdCommandHandler: object,
         Faraz.Mediator.IRequestHandler<GetComponentDetailsByIdCommand,
                     ComponentDetailsViewModel>
{
    public GetComponentDetailsByIdCommandHandler(Infrastructure.IUnitOfWork unitOfWork) : base()
    {
        UnitOfWork = unitOfWork;
    }

    protected Infrastructure.IUnitOfWork UnitOfWork { get; }

    public
  async
     System.Threading.Tasks.Task
      <FluentResults.Result<ComponentDetailsViewModel>>
  Handle(GetComponentDetailsByIdCommand request,
                     System.Threading.CancellationToken cancellationToken)
    {
        // **************************************************
        var result = new
                      FluentResults.Result<ComponentDetailsViewModel>();

        var response = new BaseSerachResponse<ComponentDetailsViewModel>();
        // **************************************************
        try
        {
            var componentDetails =
                await
               UnitOfWork.Components.GetComponentDetailsByIdAsync(id:request.ComponentId);

            // **************************************************

            result.WithValue(value: componentDetails);

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
