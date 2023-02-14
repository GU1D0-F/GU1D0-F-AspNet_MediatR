using AspNet_MediatR_Demo.Domain.Entity;

namespace AspNet_MediatR_Demo.Repository
{
    public class ProdutoRepository : IRepository<Produto>
    {
        private static Dictionary<int, Produto> produtos = new()
        {
            {1, new Produto { Id = 1, Nome = "Caneta", Preco = 3.45m }},
            {2, new Produto { Id = 2, Nome = "Caderno", Preco = 7.65m }},
            {3, new Produto {Id = 3, Nome = "Borracha", Preco = 1.20m}}
        };

        public async Task<IEnumerable<Produto>> GetAll() =>
            await Task.Run(() => produtos.Values.ToList());

        public async Task<Produto> Get(int id) =>
            await Task.Run(() => produtos.GetValueOrDefault(id));

        public async Task Add(Produto produto) =>
            await Task.Run(() => produtos.Add(produto.Id, produto));

        public async Task Edit(Produto produto)
        {
            await Task.Run(() =>
            {
                produtos.Remove(produto.Id);
                produtos.Add(produto.Id, produto);
            });
        }

        public async Task Delete(int id) => 
            await Task.Run(() => produtos.Remove(id));       
    }
}
