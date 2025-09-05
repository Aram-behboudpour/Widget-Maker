using System;

namespace Faraz.Persistance;

public interface IQueryRepository<T,TIdentity> where T : Domain.IEntity<TIdentity>
{
    System.Threading.Tasks.Task<T> GetByIdAsync(int id);

    System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync();
}