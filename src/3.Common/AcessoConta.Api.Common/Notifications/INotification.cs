using AcessoConta.Api.Common.Enums.Notification;
using AcessoConta.Api.Common.Notifications.Model;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoConta.Api.Common.Notifications
{
    public interface INotification
    {
        IReadOnlyCollection<NotificationModel> Notifications { get; }
        bool HasNotifications { get; }
        void AddNotification(string key, string message, ENotificationType notificationType);
        void AddNotification(string key, string message);
        void AddNotifications(IReadOnlyCollection<NotificationModel> notifications);
        void AddNotifications(IList<NotificationModel> notifications);
        void AddNotifications(ValidationResult validationResult);
    }
}
