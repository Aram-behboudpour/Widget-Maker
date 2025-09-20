using Infrastructure;
using oc.TSB.Application.Features.Processes.Commands;
using oc.TSB.Infrastructure.Features.CamundaProcesses.Processes.ViewModels;

namespace Server.Pages.Features.Processes;

public class UpdateModel : BasePageModel
{
    public UpdateModel(MediatR.IMediator mediator) : base(mediator: mediator)
    {
        ViewModel = new();
    }
    #region Properties

    [Microsoft.AspNetCore.Mvc.BindProperty]
    public UpdateViewModel ViewModel { get; set; }

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
        <Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid == false)
        {
            return Page();
        }
        // **************************************************

        // **************************************************
        var request = new
             ProcessUpdateCommand
        {
            viewModel = ViewModel,
        };

        var result =
            await Mediator.Send(request);
        // **************************************************
        var successMessage = string.Format
            (oc.TSB.Resources.Messages.Successes.SuccessUpdate,
          oc.TSB.Resources.DataDictionary.Process);

        AddToastSuccess(message: successMessage);
        // **************************************************
        return RedirectToPage(pageName:
           oc.TSB.Core.Constants.CommonRouting.CurrentIndex);

    }
    #endregion /OnPostAsync()

    #endregion /Methods
}
