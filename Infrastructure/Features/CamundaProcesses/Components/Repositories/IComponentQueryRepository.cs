using oc.TSB.Core.Features.CamundaProcesses;
using System;

namespace oc.TSB.Infrastructure.Features.CamundaProcesses.Components.Repositories;

public interface IComponentQueryRepository: Faraz.Persistance.IQueryRepository<Component,Guid>
{
}
