using AutoMapper;
using MailGate.Server.Application.Dtos;
using MailGate.Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailGate.Server.Application.Profiles
{
    public class EmailEntryProfile: Profile
    {
        EmailEntryProfile() 
        {
            CreateMap<CreateEmailEntryDto, DbEntryEmail>();
            CreateMap<DbEntryEmail, ReadEmailEntryDto>();
        }
    }
}
