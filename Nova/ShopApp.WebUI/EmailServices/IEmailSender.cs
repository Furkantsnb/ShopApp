namespace ShopApp.WebUI.EmailServices
{
    public interface IEmailSender
    {
        // smtp => gmail, hotmail
        // api  => sendgrid

        Task SendEmailAsync(string email, string subject, string htmlMessage);

    }
}
