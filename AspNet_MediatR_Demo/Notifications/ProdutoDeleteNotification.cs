using MediatR;

namespace AspNet_MediatR_Demo.Notifications
{
    public class ProdutoDeleteNotification : INotification
    {
        public int Id { get; set; }
        public bool IsConcluido { get; set; }
    }
}
