using CrudSimplesContainer.Connection;
using CrudSimplesContainer.Connection.Interfaces;
using CrudSimplesContainer.Features.Produtos.EndPoints;
using CrudSimplesContainer.Features.Produtos.Repositories.Interfaces;
using CrudSimplesContainer.Features.Produtos.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IFabricaDeConexao, ConexaoPostgres>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ProdutoEndPoints>();

var app = builder.Build();

using (var escopo = app.Services.CreateScope())
{
    escopo.ServiceProvider.GetRequiredService<ProdutoEndPoints>().RegistrarRotas(app);
}

app.Run();