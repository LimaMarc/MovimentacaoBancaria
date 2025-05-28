using FluentAssertions.Common;
using IdempotentAPI.Cache.DistributedCache.Extensions.DependencyInjection;
using IdempotentAPI.Extensions.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Questao5.Application.DomainServices.Interfaces;
using Questao5.Application.DomainServices.Services;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Database.Context;
using Questao5.Infrastructure.Database.Repositories;
using Questao5.Infrastructure.Sqlite;
using Questao5.Utils;
using System.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<DbContextConfig>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(DbContextConfig).Assembly.FullName)));

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


builder.Services.AddScoped<IMovimentoRepository, MovimentoRepository>();
builder.Services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
builder.Services.AddScoped<IIdempotenciaRepository, IdempotenciaRepository>();
builder.Services.AddScoped<IMovimentoService, MovimentoService>();
builder.Services.AddScoped<IContaCorrenteService, ContaCorrenteService>();
builder.Services.AddScoped<IIdempotenciaService, IdempotenciaService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c=>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Operações Bancárias",
        Description = "Funcionalidades básicas de operações bancárias para integração",
        Contact = new OpenApiContact() { Name = "AmCom", Url = new Uri("https://amcom.com.br/") },
        License = new OpenApiLicense() { Name = "MIT License", Url = new Uri("https://opensource.org/licenses/MIT") }
    });
    c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "DemoSwaggerAnnotation.xml"));
    c.OperationFilter<HeaderParameter>();
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// sqlite
#pragma warning disable CS8602 // Dereference of a possibly null reference.
//app.Services.GetService<IDatabaseBootstrap>().Setup();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

app.Run();

// Informações úteis:
// Tipos do Sqlite - https://www.sqlite.org/datatype3.html


