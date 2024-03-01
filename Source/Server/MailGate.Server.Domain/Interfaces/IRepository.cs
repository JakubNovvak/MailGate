using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailGate.Server.Domain.Entities;

namespace MailGate.Server.Domain.Interfaces
{
    public interface IRepository
    {
        bool SaveChanges();

        void CreateEmailEntry(DbEntryEmail emailEntryToCreate);
        IEnumerable<DbEntryEmail> GetAllEmailEntries();
        DbEntryEmail? GetEmailEntry(int emailId);
        bool DoesEmailExist(int emailId);


        //TODO: Implement Additional Functions
        IEnumerable<DbEntryEmail> GetAllEmailsByEmailAddress(string emailAddress);
        bool WasEmailAddressUsed(string emailAddress);
    }
}
