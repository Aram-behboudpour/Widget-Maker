using Infrastructure;
using oc.TSB.Application.Features.Processes.Commands;
using oc.TSB.Infrastructure.Features.CamundaProcesses.Processes.ViewModels;

namespace Server.Pages.Features.Processes;

public class CreateModel : BasePageModel
{
    public CreateModel(MediatR.IMediator mediator) : base(mediator: mediator)
    {
        ViewModel = new();
    }

    #region Properties

    [Microsoft.AspNetCore.Mvc.BindProperty]
    public CreateViewModel ViewModel { get; set; }

    #endregion /Properties

    #region Methods

    #region OnGetAsync()
    public async System.Threading.Tasks.Task OnGetAsync()
    {
        await System.Threading.Tasks.Task.CompletedTask;
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
        //var userId =
        //    AuthenticatedUserService.UserId;

        //if (userId is null)
        //{
        //    return RedirectToPage(pageName:
        //        Constants.CommonRouting.Logout);
        //}
        // **************************************************

        // **************************************************
        var request = new
             ProcessCreateCommand
        {
            viewModel = ViewModel,
        };

        var result =
            await Mediator.Send(request);

        //return FluentResult(result: result);
        // **************************************************
        var successMessage = string.Format
            (oc.TSB.Resources.Messages.Successes.SuccessInsert,
          oc.TSB.Resources.DataDictionary.Process);

        AddToastSuccess(message: successMessage);
        // **************************************************
        return RedirectToPage(pageName:
           oc.TSB.Core.Constants.CommonRouting.CurrentIndex);

    }
    #endregion /OnPostAsync()

    #endregion /Methods
}
