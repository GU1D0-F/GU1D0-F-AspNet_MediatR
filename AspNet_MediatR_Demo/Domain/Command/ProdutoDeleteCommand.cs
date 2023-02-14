using MediatR;

namespace AspNet_MediatR_Demo.Domain.Command
{
    public class ProdutoDeleteCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
