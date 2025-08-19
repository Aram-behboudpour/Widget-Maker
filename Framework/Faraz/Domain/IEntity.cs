namespace Faraz.Domain;

public interface IEntity<TIdentity>
{
    public TIdentity Id { get; }

    public System.DateTimeOffset InsertDateTime { get; }
}