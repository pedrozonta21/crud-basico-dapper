using System.Data;
using CrudSimplesContainer.Connection.Interfaces;
using MySql.Data.MySqlClient;

namespace CrudSimplesContainer.Connection;

public class ConexaoMySql : IFabricaDeConexao
{
    private readonly IConfiguration _configuration;

    public ConexaoMySql(IConfiguration configuration) => _configuration = configuration;

    public IDbConnection RetornarNovaConexao() 
        => new MySqlConnection(_configuration.GetConnectionString("MySql"));
}