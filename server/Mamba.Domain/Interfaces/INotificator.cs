using Mamba.Domain.Notifications;
using System.Collections.Generic;

namespace Mamba.Domain.Interfaces
{
    public interface INotificator
    {
        bool HasNotification();
        void Handle(Notification notification);
        IList<Notification> GetNotifications();
    }
}
