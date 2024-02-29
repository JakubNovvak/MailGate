using AutoMapper;
using MailGate.Server.Application.Dtos;
using MailGate.Server.Domain.Entities;
using MailGate.Server.Infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace MailGate.Server.Infrastructure.Repositories
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _dbContext;        

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateEmailEntry(DbEntryEmail emailEntryToCreate)
        {
            if (emailEntryToCreate == null)
                throw new ArgumentNullException();

            _dbContext.Add(emailEntryToCreate);
            SaveChanges();
        }

        public bool DoesEmailExist(int emailId)
        {
            if (_dbContext.dbEntryEmails.FirstOrDefault(email => email.Id == emailId) == null)
                return false;

            return true;
        }

        public IEnumerable<DbEntryEmail> GetAllEmailEntries()
        {
            var allDbEntryEmails = _dbContext.dbEntryEmails.ToList();

            return allDbEntryEmails;
        }

        public DbEntryEmail? GetEmailEntry(int emailId)
        {
            return _dbContext.dbEntryEmails.FirstOrDefault(email => email.Id == emailId);
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() == 0 ? false : true;
        }



        //TODO: Implement following functions
        public IEnumerable<DbEntryEmail> GetAllEmailsByEmailAddress(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public bool WasEmailAddressUsed(string emailAddress)
        {
            throw new NotImplementedException();
        }
    }
}
