namespace oc.TSB.Infrastructure;

public interface IQueryUnitOfWork : Faraz.Persistance.IQueryUnitOfWork
{
    public Features.Logs.Repositories.ILogQueryRepository Logs { get; }
}
