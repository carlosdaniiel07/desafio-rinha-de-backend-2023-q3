using DesafioBackEnd.Application.UseCases;
using DesafioBackEnd.Infrastructure.Data;
using DesafioBackEnd.Infrastructure.Services;
using DesafioBackEnd.Interfaces.Repositories;
using DesafioBackEnd.Interfaces.Services;
using DesafioBackEnd.Interfaces.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<ICreatePessoaUseCase, CreatePessoaUseCase>();
builder.Services.AddSingleton<IGetPessoaByIdUseCase, GetPessoaByIdUseCase>();
builder.Services.AddSingleton<ISearchPessoasUseCase, SearchPessoasUseCase>();
builder.Services.AddSingleton<ICountPessoasUseCase, CountPessoasUseCase>();
builder.Services.AddSingleton<IPessoaRepository, PessoaRepository>();
builder.Services.AddSingleton<ICacheService, RedisService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
