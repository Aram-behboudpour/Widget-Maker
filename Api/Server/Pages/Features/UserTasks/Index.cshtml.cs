using FluentResults;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using oc.TSB.Application.Features.UserTasks.Commands;
using oc.TSB.Infrastructure.BaseSearch;
using oc.TSB.Infrastructure.Features.UserTaskes.ViewModels;
using System;
using System.Threading.Tasks;

namespace Server.Pages.Features.UserTasks;

public class IndexModel : BasePageModel
{
    public IndexModel(MediatR.IMediator mediator) : base(mediator: mediator)
    {
        ViewModel = new();
        DisplayViewModel = new();
    }

    [BindProperty]
    public Result<BaseSerachResponse<UserTaskResultViewModel>> ViewModel { get; set; }

    public BaseSerachResponse<UserTaskResultViewModel> DisplayViewModel { get; set; }

    #region OnGetAsync()
    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        var request = new
            UserTaskIndexCommand
        {
            ProcessId = id,
        };

        var result = await Mediator.Send(request);

        ViewModel = result;

        if (result.IsSuccess)
        {
            DisplayViewModel = result.ValueOrDefault;
        }
        else
        {
            DisplayViewModel = new BaseSerachResponse<UserTaskResultViewModel>();
        }

        return Page();
    }
    #endregion /OnGetAsync()
}
