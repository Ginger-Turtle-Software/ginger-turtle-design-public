using GingerTurtle.Design.Types;

namespace GingerTurtle.Design.Contracts;

public interface INotificationService
{
    void ShowNotification(NotificationType type, string title, string message);

    void ClearAllNotifications();
}
