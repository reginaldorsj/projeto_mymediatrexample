using MediatR;
using MyMediatRExample.Domain.Enums;

namespace MyMediatRExample.Application.Notifications
{
    public class Notification<T> : INotification
    {
        public Operacao Operacao { get; set; }
        public T Data { get; set; }
    }
}
