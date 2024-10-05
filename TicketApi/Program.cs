using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;
using TicketApi.DAL;
using TicketApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConStr = builder.Configuration.GetConnectionString("ConStr");

builder.Services.AddDbContext<Context>(options =>
    options.UseMySql(ConStr, new MySqlServerVersion(new Version(8, 0, 30))));

builder.Services.AddScoped<IGenericService<Prioridades>, PrioridadesService>();
builder.Services.AddScoped<IGenericService<Clientes>, ClientesService>();
builder.Services.AddScoped<IGenericService<Tickets>, TicketsService>();
builder.Services.AddScoped<IGenericService<Sistemas>, SistemasService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(c => c
    .AllowAnyOrigin()
        .AllowAnyMethod()
            .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
