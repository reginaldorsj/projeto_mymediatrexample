using MediatR;
using MyMediatRExample.Application.Models;
using MyMediatRExample.Application.Notifications;
using MyMediatRExample.OR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyMediatRExample.Application.EventHandlers
{
    public class LogEventHandler :
                                INotificationHandler<Notification<Cidade>>,
                                INotificationHandler<ErroNotification>
    {
        public Task Handle(Notification<Cidade> notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Cidade ({notification.Operacao}): '{notification.Data.IdCidade} - {notification.Data.Descricao} - {notification.Data.IdUf.Sigla}");
            });
        }

        public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERRO: '{notification.Message} \n {notification.StackTrace}'");
            });
        }
    }
}
