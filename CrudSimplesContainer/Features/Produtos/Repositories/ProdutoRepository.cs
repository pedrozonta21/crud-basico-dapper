using CrudSimplesContainer.Connection.Interfaces;
using CrudSimplesContainer.Features.Produtos.Models;
using CrudSimplesContainer.Features.Produtos.Repositories.Interfaces;
using Dapper;

namespace CrudSimplesContainer.Features.Produtos.Services;

public class ProdutoRepository : IProdutoRepository
{
    private readonly IFabricaDeConexao _fabricaDeConexao;

    public ProdutoRepository(IFabricaDeConexao fabricaDeConexao) => _fabricaDeConexao = fabricaDeConexao;

    public async Task<IEnumerable<ProdutoModel>> ListarProdutos()
    {
        using var dbConnection = _fabricaDeConexao.RetornarNovaConexao();
        return await dbConnection.QueryAsync<ProdutoModel>(@"SELECT * FROM produtos");
    }

    public async Task<ProdutoModel> RetornarProduto(int id)
    {
        using var dbConnection = _fabricaDeConexao.RetornarNovaConexao();
        return await dbConnection.QuerySingleAsync<ProdutoModel>(
            @"SELECT * FROM produtos WHERE id = @id",
            new { id });
    }

    public async Task<int> CadastrarProduto(ProdutoModel produtoModel)
    {
        using var dbConnection = _fabricaDeConexao.RetornarNovaConexao();
        dbConnection.Open();
        var dbTransaction = dbConnection.BeginTransaction();
        var codigoProduto = await dbTransaction.Connection.ExecuteScalarAsync<int>(
            @"INSERT INTO produtos (Nome, ValorUn, Qtde) VALUES (@Nome, @ValorUn, @Qtde) RETURNING id;", 
            produtoModel, 
            dbTransaction);
        dbTransaction.Commit();
        return codigoProduto;
    }

    public async Task RemoverProduto(int id)
    {
        using var dbConnection = _fabricaDeConexao.RetornarNovaConexao();
        dbConnection.Open();
        var dbTransaction = dbConnection.BeginTransaction();
        var codigoProduto = await dbTransaction.Connection.ExecuteAsync(
            @"DELETE FROM produtos WHERE id = @id;", 
            new { id }, 
            dbTransaction);
        dbTransaction.Commit();
    }

    public async Task AtualizarProduto(ProdutoModel produtoModel)
    {
        using var dbConnection = _fabricaDeConexao.RetornarNovaConexao();
        dbConnection.Open();
        var dbTransaction = dbConnection.BeginTransaction();
        var codigoProduto = await dbTransaction.Connection.ExecuteScalarAsync<int>(
            @"UPDATE produtos SET Nome = @Nome, ValorUn = @ValorUn, Qtde = @Qtde
            WHERE id = @id;",
            produtoModel,
            dbTransaction);
        dbTransaction.Commit();
    }
}
