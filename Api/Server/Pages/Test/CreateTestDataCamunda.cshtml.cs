using Infrastructure;
using oc.TSB.Core.Features.CamundaProcesses.Enums;

namespace Server.Pages.Test;

public class CreateTestDataCamundaModel(MediatR.IMediator mediator,
  oc.TSB.Infrastructure.IUnitOfWork unitOfWork) : BasePageModelWithUnitOfWork(mediator: mediator, unitOfWork: unitOfWork)
{

    #region Methods

    #region OnGetAsync()
    public async System.Threading.Tasks.Task OnGetAsync()
    {
        await CreateTestDataForCamundaAsync();
    }
    #endregion /OnGetAsync()

    #region CreateTestDataForCamundaAsync()
    private async System.Threading.Tasks.Task CreateTestDataForCamundaAsync()
    {
        // **************************************************
        // **************************************************
        // **************************************************
        // **************************************************
        var processTitle1 = "Main Crad Transfer";
        var processName1 = " کارت به کارت";
        var processVersion1 = 1;
        // **************************************************

        // **************************************************
        var process1 =
        new oc.TSB.Core.Features.CamundaProcesses.Process
        {
            Title = processTitle1,
            Name = processName1,
            IsActive = true,
            Ordering = 10_000,
            Version = processVersion1,
            IsTestData = true,
        };

        await UnitOfWork.Processes.InsertAsync(process1);
        await UnitOfWork.SaveAsync();

        // **************************************************
        // **************************************************
        // **************************************************
        var processTitle2 = "Active Crad";
        var processName2 = "فعالسازی کارت";
        var processVersion2 = 1;
        // **************************************************

        // **************************************************
        var process2 =
        new oc.TSB.Core.Features.CamundaProcesses.Process
        {
            Title = processTitle2,
            Name = processName2,
            IsActive = true,
            Ordering = 20_000,
            Version = processVersion2,
            IsTestData = true,
        };

        await UnitOfWork.Processes.InsertAsync(process2);
        await UnitOfWork.SaveAsync();

        // **************************************************
        // **************************************************
        // **************************************************
        var processTitle3 = "DeactivateHamoon";
        var processName3 = " غیر فعالسازی هامون";
        var processVersion3 = 1;
        // **************************************************

        // **************************************************
        var process3 =
       new oc.TSB.Core.Features.CamundaProcesses.Process
       {
           Title = processTitle3,
           Name = processName3,
           IsActive = true,
           Ordering = 30_000,
           Version = processVersion3,
           IsTestData = true,
       };

        await UnitOfWork.Processes.InsertAsync(process3);
        await UnitOfWork.SaveAsync();

        // **************************************************
        // **************************************************
        // **************************************************
        var userTaskTitle1 = "GetTransferInfo";
        var userTaskName1 = "ثبت اطلاعات انتقال";

        var userTask1 =
                new oc.TSB.Core.Features.CamundaProcesses.UserTask
                {
                    Title = userTaskTitle1,
                    Name = userTaskName1,
                    IsActive = true,
                    Ordering = 10_000,
                    ProcessId = process1.Id,
                    IsTestData = true,
                };

        await UnitOfWork.UserTaskes.InsertAsync(userTask1);
        // **************************************************
        var userTaskTitle2 = "ChooseCard";
        var userTaskName2 = "انتخاب کارت";

        var userTask2 =
                new oc.TSB.Core.Features.CamundaProcesses.UserTask
                {
                    Title = userTaskTitle2,
                    Name = userTaskName2,   
                    IsActive = true,
                    Ordering = 20_000,
                    ProcessId = process1.Id,
                    IsTestData = true,
                };

        await UnitOfWork.UserTaskes.InsertAsync(userTask2);
        // **************************************************
        var userTaskTitle3 = "RegistrCardInfo";
        var userTaskName3 = "ثبت اطلاعات کارت";

        var userTask3 =
                new oc.TSB.Core.Features.CamundaProcesses.UserTask
                {
                    Title = userTaskTitle3,
                    Name = userTaskName3,
                    IsActive = true,
                    Ordering = 30_000,
                    ProcessId = process1.Id,
                    IsTestData = true,
                };

        await UnitOfWork.UserTaskes.InsertAsync(userTask3);
        // **************************************************
        var userTaskTitle4 = "Confirmation";
        var userTaskName4 = "نتیجه";

        var userTask4=
                new oc.TSB.Core.Features.CamundaProcesses.UserTask
                {
                    Title = userTaskTitle4,
                    Name = userTaskName4,
                    IsActive = true,
                    Ordering = 40_000,
                    ProcessId = process1.Id,
                    IsTestData = true,
                };

        await UnitOfWork.UserTaskes.InsertAsync(userTask4);

        await UnitOfWork.SaveAsync();
        // **************************************************
        var userTaskTitle5 = "Error";
        var userTaskName5 = "خطا";

        var userTask5 =
                new oc.TSB.Core.Features.CamundaProcesses.UserTask
                {
                    Title = userTaskTitle5,
                    Name = userTaskName5,
                    IsActive = true,
                    Ordering = 50_000,
                    ProcessId = process3.Id,
                    IsTestData = true,
                };

        await UnitOfWork.UserTaskes.InsertAsync(userTask5);

        await UnitOfWork.SaveAsync();
        // **************************************************
        // **************************************************
        var userTaskTitle6 = "Result";
        var userTaskName6 = "نتیجه";

        var userTask6 =
                new oc.TSB.Core.Features.CamundaProcesses.UserTask
                {
                    Title = userTaskTitle6,
                    Name = userTaskName6,
                    IsActive = true,
                    Ordering = 60_000,
                    ProcessId = process3.Id,
                    IsTestData = true,
                };

        await UnitOfWork.UserTaskes.InsertAsync(userTask6);

        await UnitOfWork.SaveAsync();
        // **************************************************
        // **************************************************
        var componentTitle1 = "SourcePAN";
        var componentTitle2 = "Amount";
        var componentTitle3 = "DestinationType";
        var componentTitle4 = "DestinationPAN";
        var componentTitle5 = "MobileNumber";
        var componentTitle6 = "DestinationMobileNumber";
        var componentTitle7 = "Space";
        var componentTitle8 = "Button";

        var componentName1 = "شماره کارت مبدا";
        var componentName2 = "مبلغ";
        var componentName3 = "نوع کارت مقصد";
        var componentName4 = " شماره کارت مقصد";
        var componentName5 = "شماره موبایل"; 
        var componentName6 = "شماره موبایل مقصد";
        var componentName7 = "فاصله";
        var componentName8 = "دکمه Submit";

        var component1 =
            new oc.TSB.Core.Features.CamundaProcesses.Component
            {
                Title = componentTitle1,
                Name= componentName1,
                ComponentType = ComponentType.SourcePan,
                IsActive = true,
                Ordering = 10_000,
                UserTaskId = userTask1.Id,
                ParentComponentId = null,
                IsTestData = true,
            };

        await UnitOfWork.Components.InsertAsync(component1);
        // **************************************************
        var component2 =
            new oc.TSB.Core.Features.CamundaProcesses.Component
            {
                Title = componentTitle2,
                Name = componentName2,
                ComponentType = ComponentType.Amount,
                IsActive = true,
                Ordering = 20_000,
                UserTaskId = userTask1.Id,
                ParentComponentId = null,
                IsTestData = true,
            };

        await UnitOfWork.Components.InsertAsync(component2);
        // **************************************************
        var component3 =
           new oc.TSB.Core.Features.CamundaProcesses.Component
           {
               Title = componentTitle3,
               Name = componentName3,
               ComponentType = ComponentType.DestinationType,
               IsActive = true,
               Ordering = 30_000,
               UserTaskId = userTask1.Id,
               ParentComponentId = null,
               IsTestData = true,
           };

        await UnitOfWork.Components.InsertAsync(component3);
        // **************************************************
        var component4 =
           new oc.TSB.Core.Features.CamundaProcesses.Component
           {
               Title = componentTitle4,
               Name = componentName4,
               ComponentType = ComponentType.DestinationPan,
               IsActive = true,
               Ordering = 40_000,
               UserTaskId = userTask1.Id,
               ParentComponentId = null,
               IsTestData = true,
           };

        await UnitOfWork.Components.InsertAsync(component4);
        // **************************************************
        var component5 =
           new oc.TSB.Core.Features.CamundaProcesses.Component
           {
               Title = componentTitle5,
               Name = componentName5,
               ComponentType = ComponentType.MobileNumber,
               IsActive = true,
               Ordering = 50_000,
               UserTaskId = userTask1.Id,
               ParentComponentId = null,
               IsTestData = true,
           };

        await UnitOfWork.Components.InsertAsync(component5);
        // **************************************************
        var component6 =
           new oc.TSB.Core.Features.CamundaProcesses.Component
           {
               Title = componentTitle6,
               Name = componentName6,
               ComponentType = ComponentType.DestinationMobileNumber,
               IsActive = true,
               Ordering = 60_000,
               UserTaskId = userTask1.Id,
               ParentComponentId = null,
               IsTestData = true,
           };

        await UnitOfWork.Components.InsertAsync(component6);
        await UnitOfWork.SaveAsync();
        // **************************************************
        var component7 =
           new oc.TSB.Core.Features.CamundaProcesses.Component
           {
               Title = componentTitle7,
               Name = componentName7,
               ComponentType= ComponentType.Space,
               IsActive = true,
               Ordering = 70_000,
               UserTaskId = userTask5.Id,
               ParentComponentId = null,
               IsTestData = true,
           };

        await UnitOfWork.Components.InsertAsync(component7);
        await UnitOfWork.SaveAsync();
        // **************************************************
        // **************************************************
        var component8 =
           new oc.TSB.Core.Features.CamundaProcesses.Component
           {
               Title = componentTitle8,
               Name = componentName8,
               ComponentType = ComponentType.Button,
               IsActive = true,
               Ordering = 80_000,
               UserTaskId = userTask5.Id,
               ParentComponentId = null,
               IsTestData = true,
           };

        await UnitOfWork.Components.InsertAsync(component8);
        await UnitOfWork.SaveAsync();
        // **************************************************
        // **************************************************
        // **************************************************

    }
}
#endregion /CreateTestDataForCamundaAsync()

#endregion /Methods

