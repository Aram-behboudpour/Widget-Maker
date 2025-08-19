using oc.TSB.Application.Features.Components.Commands;
using oc.TSB.Core.Features.CamundaProcesses;
using oc.TSB.Infrastructure.BaseSearch;
using oc.TSB.Infrastructure.Features.Components.ViewModels;
using System.Collections.Generic;

namespace oc.TSB.Application.Features.Components.CommandsHandler;

public class GetAllComponentsCommandHandler: object,
         Faraz.Mediator.IRequestHandler<GetAllComponentsCommand,
                     List<Component>>
{
    public GetAllComponentsCommandHandler(Infrastructure.IUnitOfWork unitOfWork) : base()
    {
        UnitOfWork = unitOfWork;
    }

    protected Infrastructure.IUnitOfWork UnitOfWork { get; }

    public
      async
         System.Threading.Tasks.Task
          <FluentResults.Result<List<Component>>>
      Handle(GetAllComponentsCommand request,
                         System.Threading.CancellationToken cancellationToken)
    {
        // **************************************************
        var result = new
                      FluentResults.Result<List<Component>>();

        var response = new BaseSerachResponse<ComponentResultViewModel>();
        // **************************************************
        try
        {
            var componentsList =
              await
              UnitOfWork.Components
              .GetAllComponentsAsync()
              ;

            // **************************************************

            result.WithValue(value: componentsList);

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
