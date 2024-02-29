using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailGate.Server.Application.Dtos
{
    public class ReadEmailEntryDto
    {
        int Id { get; set; }
        bool WasSuccessfullySent { get; set; }
        string WhenSubmitted { get; set; } = null!;
        public string TargetEmail { get; set; } = null!;
        public string MessageSubject { get; set; } = null!;
        public string MessageContent { get; set; } = null!;
    }
}
