namespace Faraz.Persistance;

public interface IRepository<T, TIdentity> : IQueryRepository<T, TIdentity> where T : Domain.IEntity<TIdentity>
{
    System.Threading.Tasks.Task InsertAsync(T entity);

    System.Threading.Tasks.Task UpdateAsync(T entity);

    System.Threading.Tasks.Task DeleteAsync(T entity);

    System.Threading.Tasks.Task<bool> DeleteByIdAsync(int id);
}
