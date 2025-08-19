using Infrastructure;

namespace Server.Pages;

public class IndexModel(MediatR.IMediator mediator) : BasePageModel(mediator: mediator)
{
    public void OnGet()
    {
    }
}
