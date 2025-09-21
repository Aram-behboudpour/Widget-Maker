using oc.TSB.Core.Features.CamundaProcesses;
using System;

namespace oc.TSB.Infrastructure.Features.CamundaProcesses.ComponentTrees.Repositories;

public class ComponentTreeQueryRepository :
     Faraz.Persistance.QueryRepository<ComponentTree, Guid>, IComponentTreeQueryRepository
{
    public ComponentTreeQueryRepository(QueryDatabaseContext databaseContext) : base(databaseContext)
    {
    }
}
