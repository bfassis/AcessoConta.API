using AcessoConta.Api.Common.Enums.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Common.Notifications.Model
{
    public class NotificationModel
    {
        public Guid NotificationId { get; private set; }
        public string Key { get; private set; }
        public string Message { get; private set; }
        public ENotificationType NotificationType { get; set; }

        public NotificationModel(string key, string message, ENotificationType notificationType = ENotificationType.BusinessRules)
        {
            NotificationId = Guid.NewGuid();
            Key = key;
            Message = message;
            NotificationType = notificationType;
        }
    }
}
