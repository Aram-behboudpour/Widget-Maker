using Faraz;
using Microsoft.EntityFrameworkCore;
using oc.TSB.Core.Features.CamundaProcesses;
using oc.TSB.Infrastructure.Features.Processes.ViewModels;
using oc.TSB.Infrastructure.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace oc.TSB.Infrastructure.Features.Processes.Repositories;

public class ProcessRepository :
     Faraz.Persistance.Repository<Process, Guid>, IProcessRepository
{
    protected internal ProcessRepository
        (DbContext databaseContext) : base(databaseContext: databaseContext)
    {
    }

    #region  GetByPageAsync(int page)
    public
        async
        Task
        <BaseSearch.BaseSerachResponse<ProcessResultViewModel>>

        GetByPageAsync(int page)
    {
        //***********************************
        int pageCount = 0;
        var pageSize = 10;

        var result = new
          BaseSearch.BaseSerachResponse<ProcessResultViewModel>();
        //***********************************
        try
        {
            var data =
          Dbset
          .AsQueryable();

            var recordCount = data.Count();

            var List =
                await
                data
                .OrderByDescending(current => current.InsertDateTime)
                .Select(current => new ProcessResultViewModel
                {
                    Id = current.Id,
                    IsActive = current.IsActive,
                    Title = current.Title,
                    IsTestData = current.IsTestData,
                    Name = current.Name,
                    Version = current.Version,
                    Ordering = current.Ordering,
                    InsertDateTime = current.InsertDateTime,
                    UpdateDateTime = current.UpdateDateTime,

                })
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync()
                ;

            if (recordCount >= pageSize)
            {
                pageCount =
                 recordCount / pageSize;
            }
            else pageCount = 1;

            result =
              new BaseSearch.BaseSerachResponse<ProcessResultViewModel>
              {
                  List = List,
                  PageCount = pageCount,
                  RecordCount = recordCount,
              };
        }
        catch (Exception ex)
        {
            //logger
            var inner = ex.InnerException?.Message;
            throw new Exception($"Outer: {ex.Message}, Inner: {inner}", ex);
        }
        return result;
    }

    #endregion /GetByPageAsync(int page)

    #region GetProcessSelectListAsync()
    public async Task
        <Microsoft.AspNetCore.Mvc.Rendering.SelectList> GetProcessSelectListAsync
        (object? selectedValue = null)
    {
        var list =
            await
             Dbset
            .OrderByDescending(current => current.InsertDateTime)
            .Select(current => new IdNameViewModel<Guid?>
            {
                Id = current.Id,
                KeyName = current.Title,
            })
            .ToListAsync()
            ;

        // **************************************************
        var emptyItem =
            new IdNameViewModel<System.Guid?>
            (id: null, keyName: oc.TSB.Resources.DataDictionary.SelectAnItem);

        list.Insert(index: 0, item: emptyItem);
        // **************************************************

        var result =
            new Microsoft.AspNetCore.Mvc.Rendering
            .SelectList(items: list, selectedValue: selectedValue,
            dataTextField: IdNameViewModel<int>.DataTextField,
            dataValueField: IdNameViewModel<int>.DataValueField);

        return result;
    }

    #endregion /GetProcessSelectListAsync()

    #region CreateProcessAsync
    public async Task
      <Process?> CreateProcessAsync(CreateViewModel viewmodel)
    {
        var newEntity = new Process(title:string.Empty,name:string.Empty);
        try
        {
            var foundedItem =
               await
               Dbset
               .Where(current => current.Title == viewmodel.Title.Trim())
               .Where(current => current.Version == viewmodel.Version)
               .Where(current => current.IsTestData == false)
               .FirstOrDefaultAsync();

            if (foundedItem != null)
            {
                return null;
            }

            newEntity =
               new Process(title: viewmodel.Title, name: viewmodel.Name)
               {
                   //Title = viewmodel.Title,
                   //Name = viewmodel.Name,
                   IsActive = true,
                   Version = viewmodel.Version,
                   Ordering = viewmodel.Ordering,
               };

            var entityEntry =
                await
                DatabaseContext.AddAsync(entity: newEntity);

            var affectedRows =
                await
                DatabaseContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return null;
        }

        return newEntity;
    }
    #endregion /CreateProcessAsync

    #region GetDetailsProcessAsync
    public async Task
            <DetailsOrDeleteViewModel?> GetDetailsProcessAsync(Guid? id)
    {
        try
        {
            var result =
           await
             Dbset
           .Where(current => current.Id == id.Value)
           .Select(current => new DetailsOrDeleteViewModel
           {
               Id = current.Id,

               Title = current.Title,
               IsActive = current.IsActive,
               Ordering = current.Ordering,
               Name = current.Name,
               Version = current.Version,
               InsertDateTime = current.InsertDateTime,
               UpdateDateTime = current.UpdateDateTime,
           })
           .FirstOrDefaultAsync();

            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    #endregion /GetDetailsProcessAsync

    #region DeleteProcessAsync
    public async Task
              <bool> DeleteProcessAsync(Guid? id)
    {
        try
        {
            var foundedItem =
            await
              Dbset
            .Where(current => current.Id == id.Value)
            .FirstOrDefaultAsync();

            if (foundedItem is null)
            {
                return false;
            }
            // **************************************************

            // **************************************************    
            var entityEntry =
                DatabaseContext.Remove(entity: foundedItem);

            var affectedRows =
                await
                DatabaseContext.SaveChangesAsync();
            // **************************************************

            // **************************************************
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
    #endregion /DeleteProcessAsync

    #region UpdateProcessAsync
    public async Task
              <bool> UpdateProcessAsync(UpdateViewModel viewmodel)
    {
        try
        {
            var foundedItem =
           await
             Dbset
           .Where(current => current.Id == viewmodel.Id)
           .FirstOrDefaultAsync();

            if (foundedItem is null)
            {
                return false;
            }
            // **************************************************
            //var userId =
            //AuthenticatedUserService.UserId;

            //if (userId is null)
            //{
            //    return RedirectToPage(pageName:
            //        Constants.CommonRouting.NotFound);
            //}
            // **************************************************
            var title =
               viewmodel.Title.Fix()!;

            var isTitleFound =
                await
                Dbset

                .Where(current => current.Id != viewmodel.Id)
                .Where(current => current.Title.ToLower() == title.ToLower())

                .AnyAsync();

            if (isTitleFound)
            {
                return false;

                //var errorMessage = string.Format
                //    (Resources.Messages.Errors.AlreadyExists,
                //    Resources.DataDictionary.Title);

                //AddPageError(message: errorMessage);
            }
            // **************************************************
            foundedItem.SetUpdateDateTime();
            foundedItem.Title = title;
            foundedItem.Name = viewmodel.Name;
            foundedItem.Version = viewmodel.Version;
            foundedItem.Ordering = viewmodel.Ordering;
            //foundedItem.UpdateUserId = userId;
            foundedItem.IsActive = viewmodel.IsActive;
            // **************************************************

            await DatabaseContext.SaveChangesAsync();

            // **************************************************
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    #endregion /UpdateProcessAsync

    #region GetLatestVersionProcessAsync
    public async Task
              <int> GetLatestVersionProcessAsync(string title)
    {
        try
        {
           var version =
           await
             Dbset
           .Where(current => current.Title.Trim().ToLower() == title.Trim().ToLower())
           .OrderByDescending(current => current.Version)
           .Select(current => current.Version)
           .FirstOrDefaultAsync();

            return version;
        }
        catch (Exception ex)
        {
            return 0;
        }     
    }
    #endregion /GetLatestVersionProcessAsync

    #region GetProcessByIdAsync
    public async Task
              <Process?> GetProcessByIdAsync(Guid id)
    {
        var process= new Process(title: string.Empty, name: string.Empty);
        try
        {
             process =
           await
             Dbset
           .Where(current => current.Id == id)
           .FirstOrDefaultAsync();

            if (process is null)
            {
                var errorMessage =
                    $"Process With Id:{id} Not Found!";

                return null;
            }
            return process;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    #endregion /GetProcessByIdAsync
}
