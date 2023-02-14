namespace AspNet_MediatR_Demo.Domain.Entity
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }


        public void Update(string newName, decimal newPrice)
        {
            Nome = newName;
            Preco = newPrice;
        }
    }
}
