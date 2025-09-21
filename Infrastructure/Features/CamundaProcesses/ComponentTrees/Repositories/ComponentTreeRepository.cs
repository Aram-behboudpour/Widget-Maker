using Microsoft.EntityFrameworkCore;
using oc.TSB.Core.Features.CamundaProcesses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace oc.TSB.Infrastructure.Features.CamundaProcesses.ComponentTrees.Repositories;

public class ComponentTreeRepository :
      Faraz.Persistance.Repository<ComponentTree, Guid>, IComponentTreeRepository
{
    public ComponentTreeRepository(DbContext databaseContext) : base(databaseContext)
    {
    }

    #region SaveTreeJsonAsync
    public async Task SaveTreeJsonAsync(Guid userTaskId, string treeJson)
    {
        var newEntity = new ComponentTree
        {
            IsActive = true,    
            UserTaskId = userTaskId,
            TreeJson = treeJson,
            Version = await GetLatestVersionUserTaskAsync(userTaskId)+1, // می‌توانید نسخه‌بندی هم داشته باشید
        };


        var entityEntry =
              await
              DatabaseContext.AddAsync(entity: newEntity);

        var affectedRows =
            await
            DatabaseContext.SaveChangesAsync();
    }

    #endregion /SaveTreeJsonAsync

    #region GetLatestVersionUserTaskAsync
    public async Task
              <int> GetLatestVersionUserTaskAsync(Guid userTaskId)
    {
        try
        {
            var version =
            await
              Dbset
            .Where(current => current.UserTaskId == userTaskId)
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
    #endregion /GetLatestVersionUserTaskAsync
}
