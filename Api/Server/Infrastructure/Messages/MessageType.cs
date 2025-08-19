namespace Infrastructure.Messages;

public enum MessageType : int
{
    PageError,
    PageWarning,
    PageSuccess,

    ToastError,
    ToastWarning,
    ToastSuccess,
}
