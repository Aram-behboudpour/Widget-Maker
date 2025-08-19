namespace oc.TSB.Infrastructure;

public class QueryUnitOfWork :
     Faraz.Persistance.QueryUnitOfWork<QueryDatabaseContext>, IQueryUnitOfWork
{
    public QueryUnitOfWork
        (Faraz.Persistance.Options options) : base(options: options)
    {
    }
    // **************************************************
    private Features.Logs.Repositories.ILogQueryRepository _logs;

    public Features.Logs.Repositories.ILogQueryRepository Logs
    {
        get
        {
            if (_logs == null)
            {
                _logs =
                    new Features.Logs.Repositories.LogQueryRepository(databaseContext: ApplicationDbContext);
            }

            return _logs;
        }
    }
    // **************************************************
}
