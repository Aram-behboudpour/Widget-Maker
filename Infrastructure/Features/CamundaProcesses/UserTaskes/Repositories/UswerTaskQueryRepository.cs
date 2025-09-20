using oc.TSB.Core.Features.CamundaProcesses;
using System;

namespace oc.TSB.Infrastructure.Features.CamundaProcesses.UserTaskes.Repositories;

public class UswerTaskQueryRepository:
     Faraz.Persistance.QueryRepository<UserTask,Guid>, IUserTaskQueryRepository
{
    public UswerTaskQueryRepository(QueryDatabaseContext databaseContext) : base(databaseContext)
    {
    }
}
