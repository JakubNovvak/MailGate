using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailGate.Server.Application.Dtos;

namespace MailGate.Server.Application.Services
{
    public interface ITasksService
    {
        IEnumerable<ReadEmailEntryDto> GetAllEmailEntries();
        ReadEmailEntryDto GetEmailEntry(int emailId);
        void CreateEmailEntry(CreateEmailEntryDto emailEntryToCreate);
    }
}