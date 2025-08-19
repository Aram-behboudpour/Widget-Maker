using Infrastructure;

namespace Pages.Errors;

public class Error500Model(MediatR.IMediator mediator) : BasePageModel(mediator: mediator)
{
    public System.Threading.Tasks.Task OnGetAsync()
    {
        return System.Threading.Tasks.Task.CompletedTask;
    }
}