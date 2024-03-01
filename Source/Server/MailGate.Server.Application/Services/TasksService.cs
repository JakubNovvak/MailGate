using AutoMapper;
using MailGate.Server.Application.Dtos;
using MailGate.Server.Domain.Entities;
using MailGate.Server.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailGate.Server.Application.Services
{
    public class TasksService : ITasksService
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repo;
        private readonly IGmailServiceClient _gmailClient;

        public TasksService(IMapper mapper, IRepository repo, IGmailServiceClient gmailClient)
        {
            _mapper = mapper;
            _repo = repo;
            _gmailClient = gmailClient;
        }

        public async Task<ReadEmailEntryDto> CreateEmailEntry(CreateEmailEntryDto emailEntryToCreate)
        {
            if (emailEntryToCreate == null)
                throw new ArgumentNullException();

            var dbEntryEmail = _mapper.Map<DbEntryEmail>(emailEntryToCreate);

            //No need for error handling - the only thing that matter is the delievery status
            bool isSendSuccess;
            try
            {
                await _gmailClient.SendEmailAsync(dbEntryEmail.TargetEmail, dbEntryEmail.MessageSubject, dbEntryEmail.MessageContent);

                isSendSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! The message wasn't delivered because \"{ex.Message}\"");
                isSendSuccess = false;
            }

            //Change needed fields
            dbEntryEmail.WhenSubmitted = DateTime.Now.ToUniversalTime();
            dbEntryEmail.WasSuccessfullySent = isSendSuccess;

            //If DbUpdateException, catch in the Controller
            _repo.CreateEmailEntry(dbEntryEmail);

            return _mapper.Map<ReadEmailEntryDto>(dbEntryEmail);
        }

        public IEnumerable<ReadEmailEntryDto> GetAllEmailEntries()
        {
            var readEmailEntriesDto = _repo.GetAllEmailEntries();

            if (readEmailEntriesDto == null)
                throw new ArgumentNullException();

            if(!readEmailEntriesDto.Any())
                throw new KeyNotFoundException();

            var dBEmailEntries = _mapper.Map<IEnumerable<ReadEmailEntryDto>>(readEmailEntriesDto);

            return dBEmailEntries;
        }

        public ReadEmailEntryDto GetEmailEntry(int emailId)
        {
            if(emailId < 0)
                throw new ArgumentOutOfRangeException();

            if (_repo.GetEmailEntry(emailId) == null)
                throw new KeyNotFoundException();

            var readEmailEntryDto = _mapper.Map<ReadEmailEntryDto>(_repo.GetEmailEntry(emailId));

            return readEmailEntryDto;
        }
    }
}
