using GingerTurtle.Design.Types;

namespace GingerTurtle.Design.Models;

public class Notification(Guid id, string title, string message, NotificationType type)
{
    public Guid Id { get; } = id;
    public string Title { get; } = title;
    public string Message { get; } = message;
    public NotificationType Type { get; } = type;

    public Notification(string title, string message, NotificationType type) : this(Guid.NewGuid(), title, message, type)
    {
    }
    
}