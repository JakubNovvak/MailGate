using MailGate.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailGate.Server.Infrastructure.Presistence
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<DbEntryEmail> dbEntryEmails { get; set; }
    }
}
