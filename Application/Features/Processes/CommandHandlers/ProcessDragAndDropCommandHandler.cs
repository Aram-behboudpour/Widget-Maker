using oc.TSB.Application.Features.Processes.Commands;
using System.Threading.Tasks;

namespace oc.TSB.Application.Features.Processes.CommandHandlers;

public class ProcessDragAndDropCommandHandler: object,
      Faraz.Mediator.IRequestHandler<ProcessDragAndDropCommand,
       Microsoft.AspNetCore.Mvc.Rendering.SelectList>
{
    public ProcessDragAndDropCommandHandler(Infrastructure.IUnitOfWork unitOfWork) : base()
    {
        UnitOfWork = unitOfWork;
    }

    protected Infrastructure.IUnitOfWork UnitOfWork { get; }

    public
        async
         Task
         <FluentResults.Result
            <Microsoft.AspNetCore.Mvc.Rendering.SelectList>>
             
        Handle(ProcessDragAndDropCommand request,
                   System.Threading.CancellationToken cancellationToken)
    {
        // **************************************************
        var result = new
                      FluentResults.Result<Microsoft.AspNetCore.Mvc.Rendering.SelectList>();
        // **************************************************
        try
        {
            var processSelectList =
              await
              UnitOfWork.Processes
              .GetProcessSelectListAsync()
              ;
            // **************************************************

            result.WithValue(value: processSelectList);

        }
        catch (System.Exception ex)
        {
            // Logger.LogError(exception: ex, message: ex.Message);

            result.WithError
                (errorMessage:"Unexpected Error!");
        }

        return result;
    }
}
