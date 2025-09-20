using Infrastructure;
using oc.TSB.Application.Features.Processes.Commands;
using oc.TSB.Infrastructure.Features.CamundaProcesses.Processes.ViewModels;

namespace Server.Pages.Features.Processes;

public class DeleteModel : BasePageModel
{
    public DeleteModel(MediatR.IMediator mediator) : base(mediator: mediator)
    {
        ViewModel = new();
    }

    #region Properties

    [Microsoft.AspNetCore.Mvc.BindProperty]
    public DetailsOrDeleteViewModel ViewModel { get; set; }

    #endregion /Properties
    #region Methods

    #region OnGetAsync()
    public async System.Threading.Tasks.Task
        <Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
    {
        if (id is null)
        {
            return RedirectToPage(pageName:
               oc.TSB.Core.Constants.CommonRouting.BadRequest);
        }
        // **************************************************
        var request = new
            ProcessDetailsCommand
        {
            id = id,
        };

        var result =
            await Mediator.Send(request);
        // **************************************************

        if (result is null)
        {
            return RedirectToPage(pageName:
               oc.TSB.Core.Constants.CommonRouting.NotFound);
        }

        if (result.IsSuccess)
        {
            ViewModel = result.ValueOrDefault;
        }
        else
        {
            ViewModel = new DetailsOrDeleteViewModel();
        }
        // **************************************************
        return Page();       
    }
    #endregion /OnGetAsync()

    #region OnPostAsync()
    public async System.Threading.Tasks.Task
        <Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync(System.Guid? id)
    {
        if (id is null)
        {
            return RedirectToPage(pageName:
               oc.TSB.Core.Constants.CommonRouting.BadRequest);
        }

        // **************************************************
        var request = new
          ProcessDeleteCommand
        {
            id = id,
        };

        var result =
           await Mediator.Send(request);
        // **************************************************

        // **************************************************
        if (result.Value)
        {
            var successMessage = string.Format
            (format: oc.TSB.Resources.Messages.Successes.SuccessDelete,
            arg0: oc.TSB.Resources.DataDictionary.Process);

            AddToastSuccess(message: successMessage);
        }
        else
        {
            var errorMessage = string.Format
                (format: oc.TSB.Resources.Messages.Errors.CascadeDelete,
                arg0: oc.TSB.Resources.DataDictionary.Process);

            AddToastError(message: errorMessage);
        }
        // **************************************************

        return RedirectToPage(pageName:
           oc.TSB.Core.Constants.CommonRouting.CurrentIndex);
    }
    #endregion /OnPostAsync()

    #endregion /Methods
}
