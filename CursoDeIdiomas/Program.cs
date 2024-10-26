using CursoDeIdiomas.Data;
using CursoDeIdiomas.Models;
using CursoDeIdiomas.Repository;
using CursoDeIdiomas.Repository.Interfaces;
using CursoDeIdiomas.Servces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CursoDeIdiomasContext>
    (options => options.UseSqlServer 
    (builder.Configuration.GetConnectionString("SQLConnection")).LogTo(Console.WriteLine, LogLevel.Information));
    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AlunosRepository>();
builder.Services.AddScoped<TurmasRepository>();
builder.Services.AddScoped<AlunosService>();
builder.Services.AddScoped<TurmasService>();

builder.Services.AddScoped<IBaseRepository<AlunosEntity>, BaseRepository<AlunosEntity>>();
builder.Services.AddScoped<IBaseRepository<TurmasEntity>, BaseRepository<TurmasEntity>>();

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

app.Run();
