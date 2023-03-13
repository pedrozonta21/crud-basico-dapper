using System.Data;

namespace CrudSimplesContainer.Connection.Interfaces;

public interface IFabricaDeConexao
{
    IDbConnection RetornarNovaConexao();
}
