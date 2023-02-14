﻿using AspNet_MediatR_Demo.Domain.Command;
using AspNet_MediatR_Demo.Domain.Entity;
using AspNet_MediatR_Demo.Notifications;
using AspNet_MediatR_Demo.Repository;
using MediatR;

namespace AspNet_MediatR_Demo.Domain.Handler
{
    public class ProdutoUpdateCommandHandler : IRequestHandler<ProdutoUpdateCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;
        public ProdutoUpdateCommandHandler(IMediator mediator, IRepository<Produto> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }
        public async Task<string> Handle(ProdutoUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var produto = new Produto
            {
                Id = request.Id,
                Nome = request.Nome,
                Preco = request.Preco
            };
            try
            {
                await _repository.Edit(produto);
                await _mediator.Publish(new ProdutoUpdateNotification
                { Id = produto.Id, Nome = produto.Nome, Preco = produto.Preco });
                return await Task.FromResult("Produto alterado com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ProdutoUpdateNotification
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco
                });

                await _mediator.Publish(new ErroNotification
                {
                    Erro = ex.Message,
                    PilhaErro = ex.StackTrace
                });
                return await Task.FromResult("Ocorreu um erro no momento da alteração");
            }
        }
    }
}
