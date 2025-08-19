namespace Faraz.Persistance;

public interface IUnitOfWork : IQueryUnitOfWork
{
    System.Threading.Tasks.Task SaveAsync();
}
