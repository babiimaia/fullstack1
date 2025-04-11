using Estudo1.Repositorio;
using Estudo1.Servico;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Serviços
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Swagger funcionando

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("AlunosDB"));

builder.Services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
builder.Services.AddScoped<IAlunoServico, AlunoServico>();
builder.Services.AddControllers();

var app = builder.Build();

// Ativa o Swagger na aplicação
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS redirecionamento (opcional, mas recomendado)
app.UseHttpsRedirection();

// Mapeamento automático de controllers (mais moderno)
app.MapControllers();

app.Run();
