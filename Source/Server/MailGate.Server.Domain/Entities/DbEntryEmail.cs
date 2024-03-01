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
        public int Id { get; set; }
        public bool WasSuccessfullySent { get; set; }
        public DateTime WhenSubmitted { get; set; }
        public string TargetEmail { get; set; } = null!;
        public string MessageSubject { get; set; } = null!;
        public string MessageContent { get; set; } = null!;
    }
}
