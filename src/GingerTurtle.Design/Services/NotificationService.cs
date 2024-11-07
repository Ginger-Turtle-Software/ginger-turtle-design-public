using System.Timers;
using GingerTurtle.Design.Contracts;
using GingerTurtle.Design.Models;
using GingerTurtle.Design.Types;
using Timer = System.Timers.Timer;

namespace GingerTurtle.Design.Services;

public sealed class NotificationService : INotificationService, IDisposable
{
    public event Action<Notification> AddNotification;
    public event Action DismissNotification;
    private Timer _countdown;
    private const int NotificationTime = 123000;
    public void ShowNotification(NotificationType type, string title, string message)
    {
        var notification = new Notification(title, message, type);
        AddNotification?.Invoke(notification);
        StartCountdown();
    }

    public void ClearAllNotifications() =>
        DismissAllNotifications();


    private void StartCountdown()
    {
        SetCountdown();
        
        if (_countdown.Enabled)
        {
            _countdown.Stop();
            _countdown.Start();
        }
        else
        {
            _countdown.Start();
        }
    }

    private void SetCountdown()
    {
        if (_countdown != null) 
            return;
        
        _countdown = new Timer(NotificationTime);
        _countdown.Elapsed += Dismiss;
        _countdown.AutoReset = false;
    }

    public void DismissAllNotifications() =>
        DismissNotification?.Invoke();
    
    private void Dismiss(object source, ElapsedEventArgs args) =>
        DismissNotification?.Invoke();
    

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);

    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            _countdown?.Dispose();
        }
    }
}