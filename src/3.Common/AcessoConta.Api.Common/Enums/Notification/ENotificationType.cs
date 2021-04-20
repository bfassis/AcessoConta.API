using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Common.Enums.Notification
{
    public enum ENotificationType : byte
    {
        Default = 0,
        InternalServerError = 1,
        BusinessRules = 2,
        NotFoundResult = 3,
    }
}
