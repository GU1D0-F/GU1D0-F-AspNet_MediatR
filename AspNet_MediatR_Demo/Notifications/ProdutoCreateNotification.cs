using MediatR;

namespace AspNet_MediatR_Demo.Notifications
{
    public class ProdutoCreateNotification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
