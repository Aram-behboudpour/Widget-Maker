using Microsoft.EntityFrameworkCore;

namespace Faraz.Persistance;

public abstract class Repository<T, TIdentity> :
    object, IRepository<T, TIdentity> where T : class, Domain.IEntity<TIdentity>
{
    protected internal Repository(Microsoft.EntityFrameworkCore.DbContext databaseContext) : base()
    {
        DatabaseContext =
         databaseContext ??
         throw new System.ArgumentNullException(paramName: nameof(databaseContext));

        Dbset = DatabaseContext.Set<T>();
    }
    //**********
    public Microsoft.EntityFrameworkCore.DbSet<T> Dbset { get; }
    //**********

    //**********
    public Microsoft.EntityFrameworkCore.DbContext DatabaseContext { get; }
    //**********
    public virtual async System.Threading.Tasks.Task InsertAsync(T entity)
    {
        if (entity == null)
        {
            throw new System.ArgumentNullException(paramName: nameof(entity));
        }

        await Dbset.AddAsync(entity);
    }

    protected virtual void Update(T entity)
    {
        if (entity == null)
        {
            throw new System.ArgumentNullException(paramName: nameof(entity));
        }

        Dbset.Update(entity);
    }

    public virtual async System.Threading.Tasks.Task UpdateAsync(T entity)
    {
        if (entity == null)
        {
            throw new System.ArgumentNullException(paramName: nameof(entity));
        }

        await System.Threading.Tasks.Task.Run(() =>
        {
            Dbset.Update(entity);
        });
    }

    public virtual async System.Threading.Tasks.Task DeleteAsync(T entity)
    {
        if (entity == null)
        {
            throw new System.ArgumentNullException(paramName: nameof(entity));
        }

        await System.Threading.Tasks.Task.Run(() =>
        {
            Dbset.Remove(entity);
        });
    }

    public virtual async System.Threading.Tasks.Task<T> GetByIdAsync(int id)
    {
        return await Dbset.FindAsync(keyValues: id);
    }

    public virtual async System.Threading.Tasks.Task<bool> DeleteByIdAsync(int id)
    {
        T entity =
            await GetByIdAsync(id);

        if (entity == null)
        {
            return false;
        }

        await DeleteAsync(entity);

        return true;
    }

    public virtual async System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync()
    {
        var result =
            await
            Dbset.ToListAsync()
            ;

        return result;
    }
}