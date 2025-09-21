using oc.TSB.Application.Features.Components.Commands;
using oc.TSB.Infrastructure.Features.CamundaProcesses.Processes.ViewModels;
using System;
using System.Transactions;

namespace oc.TSB.Application.Features.Components.CommandsHandler;

public class SaveTreeCommandHandler : object,
         Faraz.Mediator.IRequestHandler<SaveTreeCommand, string>
{
    public SaveTreeCommandHandler(Infrastructure.IUnitOfWork unitOfWork) : base()
    {
        UnitOfWork = unitOfWork;
    }
    protected Infrastructure.IUnitOfWork UnitOfWork { get; }

    public
      async
      System.Threading.Tasks.Task
      <FluentResults.Result<string>>
      Handle(SaveTreeCommand request,
                         System.Threading.CancellationToken cancellationToken)
    {
        // **************************************************
        var result = new
                    FluentResults.Result<string>();
        // **************************************************
        try
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var process =
                               await UnitOfWork.Processes.GetProcessByIdAsync(id: request.ProcessId);

                var userTask =
                    await UnitOfWork.UserTaskes.GetUserTaskByIdAsync(id: request.UserTaskId);

                var version =
                    await UnitOfWork.Processes.GetLatestVersionProcessAsync(title: process!.Title);

                var createViewModel = new CreateViewModel
                {
                    IsActive = true,
                    Title = process.Title,
                    Name = process.Name,
                    Version = version + 1,
                };

                var newProcess =
                      await
                      UnitOfWork.Processes.CreateProcessAsync(createViewModel);

                var newUserTask =
                       await UnitOfWork.UserTaskes.CreateByProcessIdAsync(title: userTask!.Title,
                       name: userTask.Name,
                       processId: newProcess!.Id);

                var resultSaveTree =
                 await UnitOfWork.Components.SaveTreeAsync(tree: request.Tree,
                           userTaskId: newUserTask.Id);
                //*********************************************
                var treeJson = System.Text.Json.JsonSerializer.Serialize(request.Tree);

                await UnitOfWork.ComponentTrees.SaveTreeJsonAsync(userTaskId: newUserTask.Id, treeJson: treeJson);
                //*********************************************
                scope.Complete();

                result.WithSuccess(successMessage: "Success");
            }
        }
        catch (System.Exception ex)
        {
            // Logger.LogError(exception: ex, message: ex.Message);

            result.WithError
               (errorMessage: "UnExpected Error!");
        }

        return result;
    }
}
