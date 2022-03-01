using System;
using UnityEngine;

namespace Assets.SimpleAndroidNotifications
{
	// Token: 0x02004982 RID: 18818
	public class NotificationExample : MonoBehaviour
	{
		// Token: 0x0601B06C RID: 110700 RVA: 0x0085149B File Offset: 0x0084F89B
		public void ScheduleSimple()
		{
			NotificationManager.Send(TimeSpan.FromSeconds(5.0), "Simple notification", "Customize icon and color", new Color(1f, 0.3f, 0.15f), NotificationIcon.Bell);
		}

		// Token: 0x0601B06D RID: 110701 RVA: 0x008514D0 File Offset: 0x0084F8D0
		public void ScheduleNormal()
		{
			NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(5.0), "Notification", "Notification with app icon", new Color(0f, 0.6f, 1f), NotificationIcon.Message);
		}

		// Token: 0x0601B06E RID: 110702 RVA: 0x00851508 File Offset: 0x0084F908
		public void ScheduleCustom()
		{
			NotificationParams notificationParams = new NotificationParams
			{
				Id = Random.Range(0, int.MaxValue),
				Delay = TimeSpan.FromSeconds(5.0),
				Title = "Custom notification",
				Message = "Message",
				Ticker = "Ticker",
				Sound = true,
				Vibrate = true,
				Light = true,
				SmallIcon = NotificationIcon.Heart,
				SmallIconColor = new Color(0f, 0.5f, 0f),
				LargeIcon = "app_icon"
			};
			NotificationManager.SendCustom(notificationParams);
		}

		// Token: 0x0601B06F RID: 110703 RVA: 0x008515AB File Offset: 0x0084F9AB
		public void CancelAll()
		{
			NotificationManager.CancelAll();
		}
	}
}
