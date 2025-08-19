using Infrastructure;
using Infrastructure.Helper;
using Microsoft.AspNetCore.Mvc;
using oc.TSB.Application.Features.Components.Commands;
using oc.TSB.Application.Features.Processes.Commands;
using oc.TSB.Application.Features.UserTasks.Commands;
using oc.TSB.Core.Features.CamundaProcesses;
using oc.TSB.Infrastructure.Features.Components.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Server.Pages.Features.Components;

public class DragAndDropModel : BasePageModel
{
    #region Constructor
    public DragAndDropModel(MediatR.IMediator mediator) : base(mediator: mediator)
    {
        ViewModel = new();
        AllComponents = new List<Component>();
    }
    #endregion /Constructor

    #region Properties

    [BindProperty]

    public oc.TSB.Infrastructure.Shared.DragAndDropViewModel ViewModel { get; set; }
    public Microsoft.AspNetCore.Mvc.Rendering.SelectList? ProcessesSelectList { get; set; }
    public Microsoft.AspNetCore.Mvc.Rendering.SelectList? UserTasksSelectList { get; set; }
    public IList<Component> AllComponents { get; set; }
    public IList<ComponentViewModel> Newcomponents { get; set; }

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

    //public async Task<IActionResult> OnPostSaveTreeAsync([FromBody] List<ComponentTreeItem> tree)
    //{
    //    if (tree == null || !tree.Any())
    //        return BadRequest();

    //    var allComponentIds = tree.Select(x => x.Id).ToList();
    //    var components = await _unitOfWork.Components.GetByIdsAsync(allComponentIds);

    //    foreach (var item in tree)
    //    {
    //        var comp = components.FirstOrDefault(c => c.Id == item.Id);
    //        if (comp != null)
    //        {
    //            comp.ParentComponentId = item.ParentId;
    //        }
    //    }

    //    await _unitOfWork.SaveAsync();
    //    return new JsonResult(new { success = true });
    //}

    //public async Task<IActionResult> OnGetDetailsAsync(Guid id)
    //{
    //    var component = await _unitOfWork.Components.GetByIdAsync(id);

    //    if (component == null)
    //        return Content("کامپوننت یافت نشد");

    //    // می‌تونی از Partial View استفاده کنی یا مستقیم HTML بسازی
    //    var html = $@"
    //            <strong>نام:</strong> {component.Name}<br/>
    //            <strong>عنوان:</strong> {component.Title}<br/>
    //            <strong>پدر:</strong> {(component.ParentComponentId.HasValue ? component.ParentComponentId.ToString() : "ندارد")}
    //        ";

    //    return Content(html, "text/html");
    //}

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

    //public class ComponentTreeItem
    //{
    //    public Guid Id { get; set; }
    //    public Guid? ParentId { get; set; }
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
        <Microsoft.AspNetCore.Mvc.IActionResult> OnPostComponentLoadingAsync()
    {
        // **************************************************
        var request = new
           GetAllComponentsCommand();

        var result = await Mediator.Send(request);

        AllComponents = result.Value;
        // **************************************************
        await UpdateProcessSelectListAsync(ProcessId: null);

        await UpdateUserTasksSelectListAsync(UserTaskId: null);
        // **************************************************
        string xmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "xml", "sampleXmlFile.xml");

        if (!System.IO.File.Exists(xmlFilePath))
        {
            return Page();
        }
        // **************************************************
        var xmlContent = System.IO.File.ReadAllText(xmlFilePath);

        Newcomponents = XmlHelper.GetComponentsForUserTask(xmlContent, "Activity_03ffu17");

        return Page();
    }

    #endregion /OnPostComponentLoadingAsync()
}










