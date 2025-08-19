namespace Faraz.Domain;

public interface IEntityHasUpdateDateTime
{
    System.DateTimeOffset UpdateDateTime { get; }

    void SetUpdateDateTime();
}
