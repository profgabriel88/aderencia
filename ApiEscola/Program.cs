using ApiEscola.Data;
using ApiEscola.Interfaces;
using ApiEscola.Services;
using EntityFramework.Exceptions.Sqlite;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApiContext>(o =>
{
    o.UseSqlite(builder.Configuration.GetConnectionString("Default")).UseExceptionProcessor();
});

builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IRelatorioService, RelatorioService>();

QuestPDF.Settings.License = LicenseType.Community;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => 
    x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.MapControllers();

app.Run();
