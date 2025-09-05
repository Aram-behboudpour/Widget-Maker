using oc.TSB.Application.Features.Components.Commands;
using oc.TSB.Infrastructure.Features.Components.ViewModels;
using System.Collections.Generic;

namespace oc.TSB.Application.Features.Components.CommandsHandler;

public class GetAllComponentsCommandHandler: object,
         Faraz.Mediator.IRequestHandler<GetAllComponentsCommand,
                     List<ComponentViewModel>>
{
    public GetAllComponentsCommandHandler(Infrastructure.IUnitOfWork unitOfWork) : base()
    {
        UnitOfWork = unitOfWork;
    }

    protected Infrastructure.IUnitOfWork UnitOfWork { get; }

    public
      async
         System.Threading.Tasks.Task
          <FluentResults.Result<List<ComponentViewModel>>>
      Handle(GetAllComponentsCommand request,
                         System.Threading.CancellationToken cancellationToken)
    {
        // **************************************************
        var result = new
                      FluentResults.Result<List<ComponentViewModel>>();
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
                (errorMessage:"UnExpected Error!");
        }

        return result;
    }
}
