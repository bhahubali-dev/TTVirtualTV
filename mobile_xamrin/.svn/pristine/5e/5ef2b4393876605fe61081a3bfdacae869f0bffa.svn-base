using System;

using Android.App;
using Android.Content;
using Firebase.Messaging;
using Android.Media;
using Newtonsoft.Json;
using VirtualEvent.BusinessLayer.Notification;

namespace VirtualEvent.Droid.Controllers.PushNotification
{
	[Service]
	[IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
	public class MyFirebaseMessagingService : FirebaseMessagingService
	{
		const string TAG = "MyFirebaseMsgService";

		public override void OnMessageReceived(RemoteMessage message)
		{
			Android.Util.Log.Debug(TAG, "From: " + message.From);
			Android.Util.Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);
			SendNotification(message.GetNotification().Body);
		}

		void SendNotification(string messageBody)
		{
			try
			{
				var response = JsonConvert.DeserializeObject<PushNotificationRequest>(messageBody);

				var intent = new Intent(this, typeof(EventDetailActivity));
				intent.PutExtra("eventId", response.EventId);

				// intent.AddFlags(ActivityFlags.ClearTop);
				var pendingIntent = PendingIntent.GetActivity(this, 0 /* Request code */, intent, PendingIntentFlags.OneShot);

				var defaultSoundUri = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
				var notificationBuilder = new Android.Support.V4.App.NotificationCompat.Builder(this)
					.SetContentTitle(response.EventTitle)
					.SetContentText(response.Question)
					.SetAutoCancel(true)
					.SetSound(defaultSoundUri)
					.SetContentIntent(pendingIntent);

				var notificationManager = NotificationManager.FromContext(this);

				notificationManager.Notify(0, notificationBuilder.Build());
			}
			catch (Exception ex) { }
		}
	}
}