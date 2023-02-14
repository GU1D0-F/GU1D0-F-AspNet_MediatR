using AspNet_MediatR_Demo.Domain.Entity;
using AspNet_MediatR_Demo.Domain.Queries;
using AspNet_MediatR_Demo.Repository;
using AspNet_MediatR_Demo.ViewModels;
using MediatR;

namespace AspNet_MediatR_Demo.Domain.Handler
{
    public class ProdutoGetAllQueryHandler : IRequestHandler<ProdutoGetAllQuery, CollectionResponse<BuscaProdutoResponse>>
    {
        private readonly IRepository<Produto> _repository;

        public ProdutoGetAllQueryHandler(IRepository<Produto> repository)
        {
            _repository = repository;
        }

        protected IQueryable<BuscaProdutoResponse> MapToResponse(IQueryable<Produto> query)
                        => query.Select(x => new BuscaProdutoResponse(x));

        public Task<CollectionResponse<BuscaProdutoResponse>> Handle(ProdutoGetAllQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAll().Result.AsQueryable();
            var totalCount = query.Count();

            var items = MapToResponse(query).AsEnumerable();

            return Task.Run(() => new CollectionResponse<BuscaProdutoResponse>(items, totalCount));
        }
    }
}
