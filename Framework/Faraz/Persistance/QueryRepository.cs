using Microsoft.EntityFrameworkCore;

namespace Faraz.Persistance;

public abstract class QueryRepository<TEntity, TIdentity> :
    object, IQueryRepository<TEntity, TIdentity> where TEntity : class, Domain.IEntity<TIdentity>
{
    protected QueryRepository
        (Microsoft.EntityFrameworkCore.DbContext databaseaCaontext) : base()
    {
        DatabaseContext =
            databaseaCaontext ??
            throw new System.ArgumentNullException(paramName: nameof(databaseaCaontext));

        Dbset = DatabaseContext.Set<TEntity>();
    }

    //**********
    public Microsoft.EntityFrameworkCore.DbSet<TEntity> Dbset { get; }
    //**********

    //**********
    public Microsoft.EntityFrameworkCore.DbContext DatabaseContext { get; }
    //**********

    public virtual async System.Threading.Tasks.Task<TEntity> GetByIdAsync(int id)
    {
        return await Dbset.FindAsync(keyValues: id);
    }

    public virtual async System.Threading.Tasks.Task<System.Collections.Generic.IList<TEntity>> GetAllAsync()
    {
        var result =
            await
            Dbset.ToListAsync()
            ;

        return result;
    }
}
