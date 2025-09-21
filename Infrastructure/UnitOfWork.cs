using oc.TSB.Infrastructure.Features.CamundaProcesses.Components.Repositories;
using oc.TSB.Infrastructure.Features.CamundaProcesses.ComponentTrees.Repositories;
using oc.TSB.Infrastructure.Features.CamundaProcesses.Processes.Repositories;
using oc.TSB.Infrastructure.Features.CamundaProcesses.UserTaskes.Repositories;

namespace oc.TSB.Infrastructure;

public class UnitOfWork :
    Faraz.Persistance.UnitOfWork<ApplicationDbContext>, IUnitOfWork
{
    public UnitOfWork
        (Faraz.Persistance.Options options) : base(options: options)
    {
    }

    // **************************************************
    private Features.Logs.Repositories.ILogRepository _logs;

    public Features.Logs.Repositories.ILogRepository Logs
    {
        get
        {
            if (_logs == null)
            {
                _logs =
                    new Features.Logs.Repositories.LogRepository(databaseContext: ApplicationDbContext);
            }

            return _logs;
        }
    }

    // **************************************************
    private IProcessRepository _processes;

    public IProcessRepository Processes
    {
        get
        {
            if (_processes == null)
            {
                _processes =
                    new ProcessRepository(databaseContext: ApplicationDbContext);
            }

            return _processes;
        }
    }

    // **************************************************
    private IUserTaskRepository _userTaskes;

    public IUserTaskRepository UserTaskes
    {
        get
        {
            if (_userTaskes == null)
            {
                _userTaskes =
                    new UserTaskRepository(databaseContext: ApplicationDbContext);
            }

            return _userTaskes;
        }
    }

    // **************************************************
    private IComponentRepository _components;

    public IComponentRepository Components
    {
        get
        {
            if (_components == null)
            {
                _components =
                    new ComponentRepository(databaseContext: ApplicationDbContext);
            }

            return _components;
        }
    }
    // **************************************************
    private IComponentTreeRepository _componentTrees;
    public IComponentTreeRepository ComponentTrees
    {
        get
        {
            if (_componentTrees == null)
            {
                _componentTrees =
                    new ComponentTreeRepository(databaseContext: ApplicationDbContext);
            }

            return _componentTrees;
        }
    }
    // **************************************************
}
