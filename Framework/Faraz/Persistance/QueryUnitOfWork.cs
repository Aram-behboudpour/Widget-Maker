using Microsoft.EntityFrameworkCore;

namespace Faraz.Persistance;

public abstract class QueryUnitOfWork<T> :
    object, IQueryUnitOfWork where T : Microsoft.EntityFrameworkCore.DbContext
{
    public QueryUnitOfWork(Options options) : base()
    {
        Options = options;
    }

    //**********
    protected Options Options { get; set; }
    //**********

    //**********
    private T _databaseContext;
    //**********

    //**********
    protected T ApplicationDbContext
    {
        get
        {
            if (_databaseContext == null)
            {
                var optionsBuilder =
                    new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<T>();

                switch (Options.Provider)
                {
                    case Enums.Provider.SqlServer:
                        {
                            optionsBuilder.UseSqlServer
                                (connectionString: Options.ConnectionString);

                            break;
                        }

                    case Enums.Provider.MySql:
                        {
                            //optionsBuilder.UseMySql
                            //    (connectionString: Options.ConnectionString);

                            break;
                        }

                    case Enums.Provider.Oracle:
                        {
                            //optionsBuilder.UseOracle
                            //    (connectionString: Options.ConnectionString);

                            break;
                        }

                    case Enums.Provider.PostgreSQL:
                        {
                            //optionsBuilder.UsePostgreSQL
                            //    (connectionString: Options.ConnectionString);

                            break;
                        }

                    case Enums.Provider.InMemory:
                        {
                            //optionsBuilder.UseInMemoryDatabase
                            //    (connectionString: Options.ConnectionString);

                            break;
                        }

                    default:
                        {
                            break;
                        }

                }

                _databaseContext =
                    (T)System.Activator.CreateInstance
                    (type: typeof(T), args: optionsBuilder.Options);
            }

            return _databaseContext;
        }
    }
    //**********

    //**********
    public bool IsDisposed { get; protected set; }
    //**********

    //**********

    public void Dispose()
    {
        Dispose(true);

        System.GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (IsDisposed)
        {
            return;
        }

        if (disposing)
        {
            if (_databaseContext != null)
            {
                _databaseContext.Dispose();
                //_databaseContext = null;
            }
        }

        IsDisposed = true;
    }

    ~QueryUnitOfWork()
    {
        Dispose(false);
    }
}
