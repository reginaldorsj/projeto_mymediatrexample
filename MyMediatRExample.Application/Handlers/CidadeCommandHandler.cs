using MediatR;
using MyMediatRExample.Application.Commands;
using MyMediatRExample.Application.Models;
using MyMediatRExample.Application.Notifications;
using MyMediatRExample.Domain.Enums;
using MyMediatRExample.Infrastructure.Access;
using MyMediatRExample.OR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyMediatRExample.Application.Handlers
{
    public class CidadeCommandHandler : IRequestHandler<Command<Cidade>, ResponseModel>
    {
        private readonly IMediator mediator;
        public CidadeCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<ResponseModel> Handle(Command<Cidade> request, CancellationToken cancellationToken)
        {
            Cidade cidade = request.Data;
            try
            {
                switch (request.Action)
                {
                    case Operacao.Inclusão:
                        cidade = BOAccess.getBOFactory().CidadeBO().InserirAlterar(cidade, Regisoft.Operacao.Incluir);
                        break;
                    case Operacao.Alteração:
                        cidade = BOAccess.getBOFactory().CidadeBO().InserirAlterar(cidade, Regisoft.Operacao.Alterar);
                        break;
                    case Operacao.Exclusão:
                        BOAccess.getBOFactory().CidadeBO().Excluir(cidade);
                        break;
                }

                await mediator.Publish(new Notification<Cidade> { Operacao = request.Action, Data = cidade });
                return await Task.FromResult(new ResponseModel()
                {
                    Message = "Operação realizada com sucesso.",
                    StatusCode = 200,
                });
            }
            catch (Exception ex)
            {
                await mediator.Publish(new ErroNotification { Message = ex.Message, StackTrace = ex.StackTrace });
                throw;
            }
        }
    }
}
