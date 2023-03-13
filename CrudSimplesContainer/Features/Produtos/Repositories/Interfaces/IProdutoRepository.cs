using CrudSimplesContainer.Features.Produtos.Models;

namespace CrudSimplesContainer.Features.Produtos.Repositories.Interfaces;

public interface IProdutoRepository
{
    Task<IEnumerable<ProdutoModel>> ListarProdutos();
    Task<ProdutoModel> RetornarProduto(int id);
    Task<int> CadastrarProduto(ProdutoModel produtoModel);
    Task RemoverProduto(int id);
    Task AtualizarProduto(ProdutoModel produtoModel);
}
