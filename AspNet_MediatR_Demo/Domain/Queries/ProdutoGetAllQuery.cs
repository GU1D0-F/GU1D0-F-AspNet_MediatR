using AspNet_MediatR_Demo.ViewModels;
using MediatR;

namespace AspNet_MediatR_Demo.Domain.Queries
{
    public class ProdutoGetAllQuery : IRequest<CollectionResponse<BuscaProdutoResponse>>
    {
    }
}
