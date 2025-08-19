using FluentResults;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using oc.TSB.Application.Features.Components.Commands;
using oc.TSB.Infrastructure.BaseSearch;
using oc.TSB.Infrastructure.Features.Components.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Pages.Features.Components;

public class IndexModel : BasePageModel
{
    #region Constructor
    public IndexModel(MediatR.IMediator mediator) : base(mediator: mediator)
    {
        ViewModel = new();
        DisplayViewModel = new();
    }

    #endregion /Constructor

    [BindProperty]
    public Result<BaseSerachResponse<ComponentResultViewModel>> ViewModel { get; set; }

    public BaseSerachResponse<ComponentResultViewModel> DisplayViewModel { get; set; }

    //[BindProperty]
    //public List<int>? Dropped { get; set; }

    #region OnGetAsync()
    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        var request = new
            ComponentIndexCommand
        {
            UserTaskId = id
        };

        var result = await Mediator.Send(request);

        ViewModel = result;

        if (result.IsSuccess)
        {
            DisplayViewModel = result.ValueOrDefault;
        }
        else
        {
            DisplayViewModel = new BaseSerachResponse<ComponentResultViewModel>();
        }

        return Page();
    }
    #endregion /OnGetAsync()

    #region OnPostSaveAsync

    //public async Task<IActionResult> OnPostSaveAsync([FromBody] List<int> ids)
    //{
    //    // ذخیره در دیتابیس یا منبع داده‌ای
    //    // مثال: ذخیره در Console
    //    Console.WriteLine("دریافت شده: " + string.Join(",", ids));
    //    return new JsonResult(new { success = true });
    //}

    #endregion /OnPostSaveAsync
}
