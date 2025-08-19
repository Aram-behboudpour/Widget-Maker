using oc.TSB.Core.Features.CamundaProcesses;
using System;

namespace oc.TSB.Infrastructure.Features.Processes.Repositories;

public class ProcessQueryRepository:
      Faraz.Persistance.QueryRepository<Process,Guid>, IProcessQueryRepository
{
    public ProcessQueryRepository(QueryDatabaseContext databaseContext) : base(databaseContext)
    {
    }
}
