using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using MailGate.Server.Domain.Interfaces;
using MailGate.Server.Domain.Helpers;

namespace MailGate.Server.Infrastructure.ApiService
{
    public class GmailServiceClient : IGmailServiceClient
    {
        public Task SendEmailAsync(string targetEmail, string messageSubject, string messageContent)
        {
            var smtpCredentials = ReadCredentialsFromConfig();

            var smtpGmailClient = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = smtpCredentials
            };

            return smtpGmailClient.SendMailAsync(
                new MailMessage(from: smtpCredentials.UserName,
                                to: targetEmail,
                                messageSubject,
                                messageContent
                                ));
        }

        //WARNING: This is only Development-wise solution - on real host, should be solved with secrets middleware
        private NetworkCredential ReadCredentialsFromConfig()
        {
            string apiConfigurationJsonFile = Path.GetDirectoryName(Directory.GetParent(Directory.GetCurrentDirectory())
                ?.FullName) + "\\Configs\\apiconfig.json";

            if (!File.Exists(apiConfigurationJsonFile))
                throw new FileNotFoundException();

            if (new FileInfo(apiConfigurationJsonFile).Length == 0)
                throw new FileLoadException();

            var apiConfigurationJsonContent = File.ReadAllText(apiConfigurationJsonFile);
            var apiConfigurationData = JsonSerializer.Deserialize<CredentialTemplate>(apiConfigurationJsonContent);

            if(apiConfigurationData == null)
                throw new NullReferenceException();

            return new NetworkCredential(apiConfigurationData.userName, apiConfigurationData.AppPassword);
        }
    }
}
