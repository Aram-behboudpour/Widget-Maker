using Infrastructure;
using Infrastructure.Helper;
using Microsoft.AspNetCore.Mvc;
using oc.TSB.Application.Features.Components.Commands;
using oc.TSB.Application.Features.Processes.Commands;
using oc.TSB.Application.Features.UserTasks.Commands;
using oc.TSB.Infrastructure.Features.CamundaProcesses.Components.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Pages.Features.Components;

public class DragAndDropModel : BasePageModel
{
    #region Constructor
    public DragAndDropModel(MediatR.IMediator mediator) : base(mediator: mediator)
    {
        ViewModel = new();

        SearchedComponents = new
            List<ComponentViewModel>();

        AllComponents = new
            List<ComponentViewModel>();
    }
    #endregion /Constructor

    #region Properties

    [BindProperty]

    public oc.TSB.Infrastructure.Shared.DragAndDropViewModel ViewModel { get; set; }
    public Microsoft.AspNetCore.Mvc.Rendering.SelectList? ProcessesSelectList { get; set; }
    public Microsoft.AspNetCore.Mvc.Rendering.SelectList? UserTasksSelectList { get; set; }
    public IList<ComponentViewModel> AllComponents { get; set; }
    public IList<ComponentViewModel> SearchedComponents { get; set; }

    #endregion /Properties

    public async Task<IActionResult> OnGetAsync()
    {

        var request = new
            GetAllComponentsCommand();

        var result = await Mediator.Send(request);

        AllComponents = result.Value;

        await UpdateProcessSelectListAsync(ProcessId: null);

        await UpdateUserTasksSelectListAsync(UserTaskId: null);

        return Page();
    }

    #region OnPostSaveTreeAsync
    public async Task<IActionResult> OnPostSaveTreeAsync
        ([FromBody]
        SaveTreeRequest request)
    {
        if (request.Tree == null || !request.Tree.Any())
            return BadRequest();

        var command = new
           SaveTreeCommand
        {
            Tree = request.Tree,
            ProcessId = request.ProcessId,
            UserTaskId = request.UserTaskId,
        };

        var result =
            await Mediator.Send(command);

        return new JsonResult(new { success = true });
    }

    #endregion /OnPostSaveTreeAsync

    #region OnGetDetailsAsync(Guid id)
    public async Task<IActionResult> OnGetDetailsAsync(Guid? id)
    {
        if (!id.HasValue)
        {
            return BadRequest();
        }

        var request = new
           GetComponentDetailsByIdCommand
        {
            ComponentId = id.Value,
        };

        var result = await Mediator.Send(request);


        if (result == null)
            return Content("کامپوننت یافت نشد");

        var name = System.Net.WebUtility.HtmlEncode(result.Value.Name);
        var title = System.Net.WebUtility.HtmlEncode(result.Value.Title);
        var parent = result.Value.ParentComponentId.HasValue
            ? result.Value.ParentComponentId.ToString()
            : "ندارد";

        var html = $@"
        <strong>نام:</strong> {name}<br/>
        <strong>عنوان:</strong> {title}<br/>
        <strong>پدر:</strong> {parent}
    ";

        return Content(html, "text/html");
    }

    #endregion /OnGetDetailsAsync(Guid id)

    //[IgnoreAntiforgeryToken]
    //public async Task<IActionResult> OnPostUnlinkAsync([FromBody] Guid id)
    //{
    //    var component = await _unitOfWork.Components.GetByIdAsync(id);
    //    if (component == null)
    //        return NotFound();

    //    // پیدا کردن همه کامپوننت‌ها برای جستجوی فرزندان تو‌در‌تو
    //    var allComponents = await _unitOfWork.Components.GetAllAsync();

    //    // تابع بازگشتی برای گرفتن همه فرزندان تو‌در‌تو
    //    List<Component> GetAllDescendants(Guid parentId)
    //    {
    //        var directChildren = allComponents.Where(c => c.ParentComponentId == parentId).ToList();
    //        var all = new List<Component>(directChildren);

    //        foreach (var child in directChildren)
    //        {
    //            all.AddRange(GetAllDescendants(child.Id));
    //        }

    //        return all;
    //    }

    //    // حذف رابطه پدر خود کامپوننت
    //    component.ParentComponentId = null;

    //    // حذف رابطه پدر تمام فرزندانش
    //    var descendants = GetAllDescendants(component.Id);
    //    foreach (var child in descendants)
    //    {
    //        child.ParentComponentId = null;
    //    }

    //    await _unitOfWork.SaveAsync();

    //    return new JsonResult(new { success = true });
    //}

    #region UpdateProcessSelectListAsync()
    public async Task UpdateProcessSelectListAsync(Guid? ProcessId)

    {
        var request = new
             ProcessDragAndDropCommand();

        var result = await Mediator.Send(request);

        ProcessesSelectList = result.Value;
    }
    #endregion /UpdateProcessSelectListAsync()

    #region UpdateUserTasksSelectListAsync()
    public async Task UpdateUserTasksSelectListAsync(Guid? UserTaskId)
    {
        var request = new
             UserTaskDragAndDropCommand();

        var result = await Mediator.Send(request);

        UserTasksSelectList = result.Value;
    }
    #endregion /UpdateUserTasksSelectListAsync()

    #region OnPostComponentLoadingAsync()
    public async System.Threading.Tasks.Task
        <Microsoft.AspNetCore.Mvc.IActionResult> OnPostComponentsLoadingAsync()
    {
        // **************************************************
        var userTaskId = ViewModel.UserTaskId;

        var request = new
           GetAllComponentsCommand();

        var result = await Mediator.Send(request);

        AllComponents = result.Value;
        // **************************************************
        await UpdateProcessSelectListAsync(ProcessId: null);

        await UpdateUserTasksSelectListAsync(UserTaskId: userTaskId);
        // **************************************************
        string xmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "xml", "sampleXmlFile.xml");

        if (!System.IO.File.Exists(xmlFilePath))
        {
            return Page();
        }
        // **************************************************
        var xmlContent = System.IO.File.ReadAllText(xmlFilePath);

        SearchedComponents = XmlHelper.GetComponentsForUserTask(xmlContent, "Activity_03ffu17");

        return Page();
    }

    #endregion /OnPostComponentLoadingAsync()
}










