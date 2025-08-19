namespace Faraz.Persistance;

public interface IQueryUnitOfWork : System.IDisposable
{
    bool IsDisposed { get; }
}
