using MailGate.Server.Infrastructure.Presistence;
using MailGate.Server.Infrastructure.Repositories;
using MailGate.Server.Infrastructure.ApiService;
using MailGate.Server.Application.Services;
using Microsoft.EntityFrameworkCore;
using MailGate.Server.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Services Related Configuration

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins(["http://192.168.0.112:5173", "http://localhost:5173", "https://localhost:5173"])
        .AllowAnyHeader()
        .AllowAnyMethod()
        );
});

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

builder.Services.AddTransient<IGmailServiceClient, GmailServiceClient>();
builder.Services.AddScoped<ITasksService, TasksService>();
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

app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion