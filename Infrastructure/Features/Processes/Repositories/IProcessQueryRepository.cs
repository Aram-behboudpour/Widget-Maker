using oc.TSB.Core.Features.CamundaProcesses;
using System;

namespace oc.TSB.Infrastructure.Features.Processes.Repositories;

public interface IProcessQueryRepository: Faraz.Persistance.IQueryRepository<Process,Guid>
{
}
