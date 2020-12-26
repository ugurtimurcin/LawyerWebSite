using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.EmailService
{
    public interface IEmailReceiver
    {
        Task EmailReceiverAsync(string email, string subject, string htmlMessage);
    }
}
