using oc.TSB.Core.Features.CamundaProcesses;
using System;

namespace oc.TSB.Infrastructure.Features.CamundaProcesses.UserTaskes.Repositories;

public interface IUserTaskQueryRepository: Faraz.Persistance.IQueryRepository<UserTask,Guid>
{
}
