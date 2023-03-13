namespace CrudSimplesContainer.Features.Produtos.Models;

public class ProdutoModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal ValorUn { get; set; }
    public decimal Qtde { get; set; }
    public decimal ValorTotal => ValorUn * Qtde;
}
