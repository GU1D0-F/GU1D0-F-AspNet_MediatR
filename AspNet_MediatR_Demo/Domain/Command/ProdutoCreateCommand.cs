using MediatR;

namespace AspNet_MediatR_Demo.Domain.Command
{
    public class ProdutoCreateCommand : IRequest<string>
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
