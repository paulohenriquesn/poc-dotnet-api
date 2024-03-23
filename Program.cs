using Microsoft.EntityFrameworkCore;
using MinhaApi.Application.UseCases.Produtos;
using MinhaApi.Domain;
using MinhaApi.Infra.Databases;
using MinhaApi.Infra.Repositories;
using MinhaApi.MinhaApi.Domain.UseCases.Produtos;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();

string PgConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(PgConnection));

builder.Services.AddSingleton<IRetrieveAll, RetrieveAll>();
builder.Services.AddSingleton<IProdutoRepository, ProdutoPgRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
