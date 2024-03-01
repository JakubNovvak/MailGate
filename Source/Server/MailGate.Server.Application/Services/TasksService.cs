using AutoMapper;
using MailGate.Server.Application.Dtos;
using MailGate.Server.Domain;
using MailGate.Server.Domain.Entities;
using MailGate.Server.Infrastructure.Repositories;
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

        public TasksService(IMapper mapper, IRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public ReadEmailEntryDto CreateEmailEntry(CreateEmailEntryDto emailEntryToCreate)
        {
            if (emailEntryToCreate == null)
                throw new ArgumentNullException();

            var dbEntryEmail = _mapper.Map<DbEntryEmail>(emailEntryToCreate);
            dbEntryEmail.WhenSubmitted = DateTime.Now.ToUniversalTime();

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
