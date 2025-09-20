using FluentResults;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using oc.TSB.Application.Features.Processes.Commands;
using oc.TSB.Infrastructure.BaseSearch;
using oc.TSB.Infrastructure.Features.CamundaProcesses.Processes.ViewModels;
using System.Threading.Tasks;

namespace Server.Pages.Features.Processes;

public class SubItemsModel : BasePageModel
{
    #region Constructor
    public SubItemsModel(MediatR.IMediator mediator) : base(mediator: mediator)
    {
        ViewModel = new();
        DisplayViewModel = new();
    }

    #endregion /Constructor

    [BindProperty]
    public Result<BaseSerachResponse<ProcessResultViewModel>> ViewModel { get; set; }

    public BaseSerachResponse<ProcessResultViewModel> DisplayViewModel { get; set; }

    #region OnGetAsync()
    public async Task<IActionResult> OnGetAsync()
    {
        var request = new
            ProcessIndexCommand();

        var result = await Mediator.Send(request);

        ViewModel = result;

        if (result.IsSuccess)
        {
            DisplayViewModel = result.ValueOrDefault;
        }
        else
        {
            DisplayViewModel = new BaseSerachResponse<ProcessResultViewModel>();
        }

        return Page();
    }
    #endregion /OnGetAsync()
}
