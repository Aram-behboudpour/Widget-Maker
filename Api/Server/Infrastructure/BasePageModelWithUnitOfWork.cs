using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure;

public abstract class BasePageModelWithUnitOfWork :
    Microsoft.AspNetCore.Mvc.RazorPages.PageModel, Messages.IMessageHandler
{
    public BasePageModelWithUnitOfWork(MediatR.IMediator mediator,
        oc.TSB.Infrastructure.IUnitOfWork unitOfWork) : base()
    {
        Mediator = mediator;
        UnitOfWork = unitOfWork;
    }

    protected MediatR.IMediator Mediator { get; }
    protected oc.TSB.Infrastructure.IUnitOfWork UnitOfWork { get; }

    public IActionResult FluentResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
            return new OkObjectResult(result);
        else
            return new BadRequestObjectResult(result.ToResult());
    }

    public IActionResult FluentResult(Result result)
    {
        if (result.IsSuccess)
            return new OkObjectResult(result);
        else
            return new BadRequestObjectResult(result.ToResult());
    }
    public bool AddPageError(string? message)
    {
        return AddMessage
            (type: Messages.MessageType.PageError, message: message);
    }

    public bool AddPageWarning(string? message)
    {
        return AddMessage
            (type: Messages.MessageType.PageWarning, message: message);
    }

    public bool AddPageSuccess(string? message)
    {
        return AddMessage
            (type: Messages.MessageType.PageSuccess, message: message);
    }

    public bool AddToastError(string? message)
    {
        return AddMessage
            (type: Messages.MessageType.ToastError, message: message);
    }

    public bool AddToastWarning(string? message)
    {
        return AddMessage
            (type: Messages.MessageType.ToastWarning, message: message);
    }

    public bool AddToastSuccess(string? message)
    {
        return AddMessage
            (type: Messages.MessageType.ToastSuccess, message: message);
    }

    public bool AddMessage(Messages.MessageType type, string? message)
    {
        return Messages.Utility.AddMessage
            (tempData: TempData, type: type, message: message);
    }

    protected string SetReturnUrl(string? returnUrl)
    {
        if (string.IsNullOrWhiteSpace(value: returnUrl))
        {
            returnUrl = "./Index";
        }

        return returnUrl;
    }
}
