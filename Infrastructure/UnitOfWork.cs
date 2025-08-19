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
    private Features.Processes.Repositories.IProcessRepository _processes;

    public Features.Processes.Repositories.IProcessRepository Processes
    {
        get
        {
            if (_processes == null)
            {
                _processes =
                    new Features.Processes.Repositories.ProcessRepository(databaseContext: ApplicationDbContext);
            }

            return _processes;
        }
    }

    // **************************************************
    private Features.UserTaskes.Repositories.IUserTaskRepository _userTaskes;

    public Features.UserTaskes.Repositories.IUserTaskRepository UserTaskes
    {
        get
        {
            if (_userTaskes == null)
            {
                _userTaskes =
                    new Features.UserTaskes.Repositories.UserTaskRepository(databaseContext: ApplicationDbContext);
            }

            return _userTaskes;
        }
    }

    // **************************************************
    private Features.Components.Repositories.IComponentRepository _components;

    public Features.Components.Repositories.IComponentRepository Components
    {
        get
        {
            if (_components == null)
            {
                _components =
                    new Features.Components.Repositories.ComponentRepository(databaseContext: ApplicationDbContext);
            }

            return _components;
        }
    }

    // **************************************************
}
