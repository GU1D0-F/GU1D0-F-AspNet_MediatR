using AspNet_MediatR_Demo.Domain.Entity;
using AspNet_MediatR_Demo.Domain.Queries;
using AspNet_MediatR_Demo.Repository;
using AspNet_MediatR_Demo.ViewModels;
using MediatR;

namespace AspNet_MediatR_Demo.Domain.Handler
{
    public class ProdutoGetByIdQueryHandler : IRequestHandler<ProdutoGetByIdQuery, BuscaProdutoResponse>
    {
        private readonly IRepository<Produto> _repository;

        public ProdutoGetByIdQueryHandler(IRepository<Produto> repository)
        {
            _repository = repository;
        }

        protected Task<Produto> GetByKeyAsync(ProdutoGetByIdQuery request) => Task.Run(() => _repository.Get(request.Id));

        public Task<BuscaProdutoResponse> Handle(ProdutoGetByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = GetByKeyAsync(request).Result;
            if (entity == null) throw new Exception($"Recurso {typeof(Produto).Name} não encontrado.");
            return Task.Run(() => new BuscaProdutoResponse(entity));
        }
    }
}
