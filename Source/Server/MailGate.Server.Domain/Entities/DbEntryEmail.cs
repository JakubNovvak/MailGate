using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailGate.Server.Domain.Entities
{
    public class DbEntryEmail
    {
        int Id { get; set; }
        bool WasSuccessfullySent { get; set; }
        DateTime WhenSubmitted { get; set; }
        public string TargetEmail { get; set; } = null!;
        public string MessageSubject { get; set; } = null!;
        public string MessageContent { get; set; } = null!;
    }
}
