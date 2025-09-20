using oc.TSB.Core.Features.CamundaProcesses;
using System;

namespace oc.TSB.Infrastructure.Features.CamundaProcesses.Components.Repositories;

public class ComponentQueryRepository:
     Faraz.Persistance.QueryRepository<Component,Guid>, IComponentQueryRepository
{
    public ComponentQueryRepository(QueryDatabaseContext databaseContext) : base(databaseContext)
    {
    }
}
