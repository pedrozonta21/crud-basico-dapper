using CrudSimplesContainer.Features.Produtos.Models;
using CrudSimplesContainer.Features.Produtos.Repositories.Interfaces;

namespace CrudSimplesContainer.Features.Produtos.EndPoints;

public class ProdutoEndPoints
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoEndPoints(IProdutoRepository produtoRepository) => _produtoRepository = produtoRepository;

    public void RegistrarRotas(IEndpointRouteBuilder app)
    {
        app.MapGet("/listarProdutos", async() =>
        {
            try
            {
                var produtos = await _produtoRepository.ListarProdutos();
                return Results.Ok(produtos);
            }
            catch (Exception exception)
            {
                return Results.Problem(detail: exception.Message);
            }
        });

        app.MapGet("/listarProduto/{id}", async (int id) =>
        {
            try
            {
                var produto = await _produtoRepository.RetornarProduto(id);
                return Results.Ok(produto);
            }
            catch (Exception exception)
            {
                return Results.Problem(detail: exception.Message);
            }
        });

        app.MapPost("/cadastrarProduto", async (ProdutoModel produto) =>
        {
            try
            {
                var codigoProduto = await _produtoRepository.CadastrarProduto(produto);
                return Results.Created($"/listarProduto/{codigoProduto}", codigoProduto);
            }
            catch(Exception exception)
            {
                return Results.Problem(detail: exception.Message);
            }
        });

        app.MapPut("/atualizarProduto", async (ProdutoModel produto) => 
        {
            try
            {
                await _produtoRepository.AtualizarProduto(produto);
                return Results.Ok();
            }
            catch (Exception exception)
            {
                return Results.Problem(detail: exception.Message);
            }
        });

        app.MapDelete("/removerProduto/{id}", async (int id) =>
        {
            try
            {
                await _produtoRepository.RemoverProduto(id);
                return Results.Ok();
            }
            catch (Exception exception)
            {
                return Results.Problem(detail: exception.Message);
            }
        });
    }
}
