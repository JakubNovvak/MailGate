using MailGate.Server.Infrastructure.Presistence;
using MailGate.Server.Infrastructure.Repositories;
using MailGate.Server.Application.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Services Related Configuration

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsProduction())
{
    //TODO: SQL Server implementation
}
else
{
    Console.WriteLine($">[DBInit] {builder.Environment.EnvironmentName} Mode - initializing In Memory Database...");

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("In Memory database")
    );
}

builder.Services.AddScoped<ITasksService, ITasksService>();
builder.Services.AddScoped<IRepository, Repository>();

#endregion

var app = builder.Build();

#region Application Related Configuration

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Database Preperation
PrepDatabase.PrepPopulation(app, builder.Environment.IsProduction());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion