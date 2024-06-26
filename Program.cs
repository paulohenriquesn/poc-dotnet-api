using Microsoft.EntityFrameworkCore;
using MinhaApi;
using MinhaApi.Application;
using MinhaApi.Application.UseCases.Produtos;
using MinhaApi.Domain;
using MinhaApi.Infra;
using MinhaApi.Infra.Databases;
using MinhaApi.Infra.Repositories;
using MinhaApi.MinhaApi.Domain.UseCases.Produtos;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();
builder.Services.AddAutoMapper(typeof(Program));

string PgConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(PgConnection));
builder.Services.AddScoped<IRetrieveAll, RetrieveAll>();
builder.Services.AddScoped<IRetrieveById, RetrieveById>();
builder.Services.AddScoped<ICreateProduct, CreateProduct>();
builder.Services.AddScoped<IDeleteProduct, DeleteProduct>();
builder.Services.AddScoped<IUpdateProduct, UpdateProduct>();
builder.Services.AddScoped<IProdutoRepository, ProdutoPgRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
