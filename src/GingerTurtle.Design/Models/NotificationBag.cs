using GingerTurtle.Design.Types;

namespace GingerTurtle.Design.Models;

public class NotificationBag
{
    public Notification Notification => GetSingleNotification();

    private readonly List<Notification> _notifications = new();

    public void CreateNotification(Notification notification)
    {
        if (notification.Type != NotificationType.Error)
            _notifications.Clear();

        if(_notifications.Exists(n => n.Id == notification.Id))
            return;

        _notifications.Add(notification);
    }
    
    public void DismissAllNotifications() => _notifications.Clear();

    public void DismissNotification(Guid notificationId)
    {
        var notification = _notifications.Find(n => n.Id == notificationId);
        if (notification != null)
        {
            _notifications.Remove(notification);
        }
    }

    private Notification GetSingleNotification()
    {
        if (_notifications.Count <= 1)
            return _notifications.FirstOrDefault();

        var errorNotifications = _notifications.Where(t => t.Type == NotificationType.Error);
        return new Notification($"{errorNotifications.Count()} Errors", "Please resolve all errors in order to proceed", NotificationType.Error);
    }
    
}