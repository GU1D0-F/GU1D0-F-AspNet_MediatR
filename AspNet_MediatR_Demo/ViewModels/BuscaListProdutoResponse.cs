using MediatR;

namespace AspNet_MediatR_Demo.ViewModels
{
    public class BuscaListProdutoResponse : IRequest<CollectionResponse<BuscaProdutoResponse>>
    {
    }
}
