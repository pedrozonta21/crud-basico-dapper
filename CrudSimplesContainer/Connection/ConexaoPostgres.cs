using CrudSimplesContainer.Connection.Interfaces;
using Npgsql;
using System.Data;

namespace CrudSimplesContainer.Connection;

public class ConexaoPostgres : IFabricaDeConexao
{
    private readonly IConfiguration _configuration;

    public ConexaoPostgres(IConfiguration configuration) => _configuration = configuration;

    public IDbConnection RetornarNovaConexao() 
        => new NpgsqlConnection(_configuration.GetConnectionString("Postgres"));
}
