using AcessoConta.Api.Common.Notifications.Model;
using AcessoConta.Api.Common.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Common.Messages.Response
{
    public abstract class BaseResponse : ValidatorBase
    {
        public bool Success { get; set; } = true;

        public NotificationModel Error { get; set; } = null;
    }
}
