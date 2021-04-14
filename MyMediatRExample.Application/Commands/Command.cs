using MediatR;
using MyMediatRExample.Application.Models;
using MyMediatRExample.Domain.Enums;

namespace MyMediatRExample.Application.Commands

{
    public class Command<T> : IRequest<ResponseModel>
    {
        public T Data { get; set; }
        public Operacao Action { get; set; }
    }
}
