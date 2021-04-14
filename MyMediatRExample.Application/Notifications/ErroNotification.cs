using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMediatRExample.Application.Notifications
{
    public class ErroNotification : INotification
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
