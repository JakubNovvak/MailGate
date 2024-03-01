using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailGate.Server.Application.Dtos
{
    public class CreateEmailEntryDto
    {
        public string TargetEmail { get; set; } = null!;
        public string MessageSubject { get; set; } = null!;
        public string MessageContent { get; set; } = null!;
    }
}
