using AspNet_MediatR_Demo.Domain.Entity;

namespace AspNet_MediatR_Demo.ViewModels
{
    public record BuscaProdutoResponse(int Id, string Nome, decimal Preco)
    {
        public BuscaProdutoResponse(Produto produto) : this(produto.Id, produto.Nome, produto.Preco)
        {
        }
    }
}
