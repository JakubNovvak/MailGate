using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailGate.Server.Domain.Entities;

namespace MailGate.Server.Infrastructure.Presistence
{
    public static class PrepDatabase
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProduction)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                if (isProduction)
                    SeedDataProduction(serviceScope.ServiceProvider.GetService<AppDbContext>());
                else
                    SeedDataDevelopment(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedDataDevelopment(AppDbContext? dbContext)
        {
            if (dbContext == null || dbContext.dbEntryEmails == null)
                throw new NullReferenceException();

            if (!dbContext.dbEntryEmails.Any())
            {
                dbContext.dbEntryEmails.Add(
                    new DbEntryEmail()
                    {
                        Id = 1,
                        WasSuccessfullySent = true,
                        WhenSubmitted = DateTime.Now.ToUniversalTime(),
                        TargetEmail = "test@test.net",
                        MessageSubject = "Hello World!",
                        MessageContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit," +
                        " sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                    }
                    );
            }
            else
                Console.WriteLine(">[DbSeed] Database already has data in it.");

            dbContext.SaveChanges();
        }

        //TODO: Implement with SQL Server
        private static void SeedDataProduction(AppDbContext? dbContext)
        {
            throw new NotImplementedException();
        }
    }
}
