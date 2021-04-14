using AcessoConta.Api.Common.Notifications.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Common.Messages.Response
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; } = true;

        public NotificationModel Error { get; set; } = null;
    }
}
