﻿using AspNet_MediatR_Demo.Notifications;
using MediatR;

namespace AspNet_MediatR_Demo.EventsHandlers
{
    public class LogEventHandler :
                            INotificationHandler<ProdutoCreateNotification>,
                            INotificationHandler<ProdutoUpdateNotification>,
                            INotificationHandler<ProdutoDeleteNotification>,
                            INotificationHandler<ErroNotification>
    {
        public Task Handle(ProdutoCreateNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} " +
                    $"- {notification.Nome} - {notification.Preco}'");
            });
        }

        public Task Handle(ProdutoUpdateNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ALTERACAO: '{notification.Id} - {notification.Nome} " +
                    $"- {notification.Preco} - {notification.IsConcluido}'");
            });
        }
        public Task Handle(ProdutoDeleteNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"EXCLUSAO: '{notification.Id} " +
                    $"- {notification.IsConcluido}'");
            });
        }

        public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERRO: '{notification.Erro} \n {notification.PilhaErro}'");
            });
        }
    }
}
