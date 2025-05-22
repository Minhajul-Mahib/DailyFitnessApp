using Unity.Notifications.Android;
using UnityEngine;

public static class NotificationManager
{
    const string CHANNEL_ID = "daily_reminder";

    public static void Initialize()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = CHANNEL_ID,
            Name = "Daily Reminders",
            Importance = Importance.Default,
            Description = "Daily challenge reminders"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public static void ScheduleDaily(string title, string text, int hour = 9, int minute = 0)
    {
        CancelAll();

        var notif = new AndroidNotification()
        {
            Title = title,
            Text = text,
            FireTime = System.DateTime.Today.AddHours(hour).AddMinutes(minute).AddDays(1),
            SmallIcon = "icon_0",
            LargeIcon = "icon_1",
        };
        AndroidNotificationCenter.SendNotification(notif, CHANNEL_ID);
    }

    public static void CancelAll()
    {
        AndroidNotificationCenter.CancelAllScheduledNotifications();
    }
}
