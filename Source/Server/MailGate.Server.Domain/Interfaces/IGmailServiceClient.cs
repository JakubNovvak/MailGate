using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailGate.Server.Domain.Interfaces
{
    public interface IGmailServiceClient
    {
        public Task SendEmailAsync(string targetEmail, string messageSubject, string messageContent);
    }
}
