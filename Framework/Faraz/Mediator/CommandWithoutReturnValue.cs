namespace Faraz.Mediator;

public class CommandWithoutReturnValue<TValue> :
    object, MediatR.IRequest<TValue>
{
    public CommandWithoutReturnValue() : base()
    {
    }
}
