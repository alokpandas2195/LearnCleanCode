public class NotificationService
{
    private readonly INotificationChannel myNotificationChannel;

    public NotificationService(INotificationChannel notificationChannel)
    {
        myNotificationChannel = notificationChannel;
    }

    public void SendNotification(MessageContent theMessage)
    {
        myNotificationChannel.SendNotification(theMessage);
    }
}

public interface INotifier
{
    void NotifySubscribers(object message);
}

public interface INotificationChannel
{
    void SendNotification(MessageContent message);
}

public struct MessageContent
{
    string Message;
    object Attachments;
}

public class SmsNotificationChannel : INotificationChannel
{
    private INotifier myNotifier;
    public SmsNotificationChannel(INotifier theNotifier)
    {
        myNotifier = theNotifier;
    }
    public void SendNotification(MessageContent message)
    {
        if (string.IsNullOrEmpty(message))
        {
            return;
        }

        var aMessage = message.Message.Substring(0, 160);
        SendMessage(aMessage);
    }

    private void SendMessage(MessageContent attachments)
    {
        myNotifier.NotifySubscribers(attachments)
    }
}

public class EmailNotificationChannel : INotificationChannel
{
    private INotifier myNotifier;
    public EmailNotificationChannel(INotifier theNotifier)
    {
        myNotifier = theNotifier;

    }

    public void SendNotification(MessageContent message)
    {
        message.Message; //Convert it to html
        message.Attachments; // attach the attachment to the email data
        SendMessage(formattedMessage);
    }

    private void SendMessage(object attachments)
    {
        myNotifier.NotifySubscribers(attachments)
    }
}

public class PushNotificationChannel : INotificationChannel
{
    private INotifier myNotifier;
    public PushNotificationChannel(INotifier theNotifier)
    {
        myNotifier = theNotifier;

    }

    public void SendNotification(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            return;
        }

        var aMessage = message.Message.Substring(0, 50); // make it as link or actions
        SendMessage(aMessage);
    }

    private void SendMessage(object attachments)
    {
        myNotifier.NotifySubscribers(attachments)
    }
}
