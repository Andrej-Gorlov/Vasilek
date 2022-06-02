using Vasilek.Services.Email.Messages;

namespace Vasilek.Services.Email.Repository
{
    public interface IEmailRepository
    {
        Task SendAndLogEmail(UpdatePaymentResultMessage message);
    }
}
