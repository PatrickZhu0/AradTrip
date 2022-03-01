using System;
using UnityEngine;

namespace Assets.SimpleAndroidNotifications
{
	// Token: 0x02004984 RID: 18820
	public static class NotificationManager
	{
		// Token: 0x0601B070 RID: 110704 RVA: 0x008515B4 File Offset: 0x0084F9B4
		public static int Send(TimeSpan delay, string title, string message, Color smallIconColor, NotificationIcon smallIcon = NotificationIcon.Bell)
		{
			return NotificationManager.SendCustom2(new NotificationParams
			{
				Id = Random.Range(0, int.MaxValue),
				Delay = delay,
				Title = title,
				Message = message,
				Ticker = message,
				Sound = true,
				Vibrate = true,
				Light = true,
				SmallIcon = smallIcon,
				SmallIconColor = smallIconColor,
				LargeIcon = string.Empty
			});
		}

		// Token: 0x0601B071 RID: 110705 RVA: 0x0085162C File Offset: 0x0084FA2C
		public static int SendWithAppIcon(TimeSpan delay, string title, string message, Color smallIconColor, NotificationIcon smallIcon = NotificationIcon.Bell)
		{
			return NotificationManager.SendCustom(new NotificationParams
			{
				Id = Random.Range(0, int.MaxValue),
				Delay = delay,
				Title = title,
				Message = message,
				Ticker = message,
				Sound = true,
				Vibrate = true,
				Light = true,
				SmallIcon = smallIcon,
				SmallIconColor = smallIconColor,
				LargeIcon = "app_icon"
			});
		}

		// Token: 0x0601B072 RID: 110706 RVA: 0x008516A4 File Offset: 0x0084FAA4
		public static int SendCustom2(NotificationParams notificationParams)
		{
			long num = (long)notificationParams.Delay.TotalMilliseconds;
			try
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.hippogames.simpleandroidnotifications.Controller");
				if (androidJavaClass != null)
				{
					androidJavaClass.CallStatic("SetNotification", new object[]
					{
						notificationParams.Id,
						num,
						notificationParams.Title,
						notificationParams.Message,
						notificationParams.Ticker,
						(!notificationParams.Sound) ? 0 : 1,
						(!notificationParams.Vibrate) ? 0 : 1,
						(!notificationParams.Light) ? 0 : 1,
						notificationParams.LargeIcon,
						NotificationManager.GetSmallIconName(notificationParams.SmallIcon),
						NotificationManager.ColotToInt(notificationParams.SmallIconColor),
						NotificationManager.MainActivityClassName
					});
				}
			}
			catch (Exception ex)
			{
			}
			return notificationParams.Id;
		}

		// Token: 0x0601B073 RID: 110707 RVA: 0x008517BC File Offset: 0x0084FBBC
		public static int SendCustom(NotificationParams notificationParams)
		{
			long num = (long)notificationParams.Delay.TotalMilliseconds;
			long[] array = new long[]
			{
				1000L,
				1000L
			};
			try
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.hippogames.simpleandroidnotifications.Controller");
				if (androidJavaClass != null)
				{
					androidJavaClass.CallStatic("SetNotification", new object[]
					{
						notificationParams.Id,
						num,
						1,
						86400000L,
						notificationParams.Title,
						notificationParams.Message,
						notificationParams.Ticker,
						(!notificationParams.Sound) ? 0 : 1,
						(!notificationParams.Vibrate) ? 0 : 1,
						"1000,1000",
						(!notificationParams.Light) ? 0 : 1,
						3000,
						3000,
						-16711936,
						notificationParams.LargeIcon,
						NotificationManager.GetSmallIconName(notificationParams.SmallIcon),
						NotificationManager.ColotToInt(notificationParams.SmallIconColor),
						1,
						"callback",
						NotificationManager.MainActivityClassName
					});
				}
			}
			catch (Exception ex)
			{
			}
			return notificationParams.Id;
		}

		// Token: 0x0601B074 RID: 110708 RVA: 0x00851958 File Offset: 0x0084FD58
		public static int SendCustom3(NotificationParams notificationParams)
		{
			long[] array = new long[]
			{
				1000L,
				1000L
			};
			try
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.hippogames.simpleandroidnotifications.Controller");
				if (androidJavaClass != null)
				{
					androidJavaClass.CallStatic("SetNotification", new object[]
					{
						notificationParams.Id,
						NotificationManager.GetDelayDurTime(),
						1,
						86400000L,
						notificationParams.Title,
						notificationParams.Message,
						notificationParams.Ticker,
						(!notificationParams.Sound) ? 0 : 1,
						(!notificationParams.Vibrate) ? 0 : 1,
						"1000,1000",
						(!notificationParams.Light) ? 0 : 1,
						3000,
						3000,
						-16711936,
						notificationParams.LargeIcon,
						NotificationManager.GetSmallIconName(notificationParams.SmallIcon),
						NotificationManager.ColotToInt(notificationParams.SmallIconColor),
						1,
						"callback",
						NotificationManager.MainActivityClassName
					});
				}
			}
			catch (Exception ex)
			{
			}
			return notificationParams.Id;
		}

		// Token: 0x0601B075 RID: 110709 RVA: 0x00851AE8 File Offset: 0x0084FEE8
		public static int SendCustomWeekly(NotificationParams notificationParams)
		{
			long[] array = new long[]
			{
				1000L,
				1000L
			};
			try
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.hippogames.simpleandroidnotifications.Controller");
				if (androidJavaClass != null)
				{
					androidJavaClass.CallStatic("SetNotification", new object[]
					{
						notificationParams.Id,
						NotificationManager.GetNearestWeekdayTime(NotificationManager.weekDay, NotificationManager.weekHour, NotificationManager.weekMinute),
						1,
						604800000L,
						notificationParams.Title,
						notificationParams.Message,
						notificationParams.Ticker,
						(!notificationParams.Sound) ? 0 : 1,
						(!notificationParams.Vibrate) ? 0 : 1,
						"1000,1000",
						(!notificationParams.Light) ? 0 : 1,
						3000,
						3000,
						-16711936,
						notificationParams.LargeIcon,
						NotificationManager.GetSmallIconName(notificationParams.SmallIcon),
						NotificationManager.ColotToInt(notificationParams.SmallIconColor),
						1,
						"callback",
						NotificationManager.MainActivityClassName
					});
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat(ex.ToString(), new object[0]);
			}
			return notificationParams.Id;
		}

		// Token: 0x0601B076 RID: 110710 RVA: 0x00851C98 File Offset: 0x00850098
		public static void Cancel(int id)
		{
			try
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.hippogames.simpleandroidnotifications.Controller");
				if (androidJavaClass != null)
				{
					androidJavaClass.CallStatic("CancelNotification", new object[]
					{
						id
					});
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0601B077 RID: 110711 RVA: 0x00851CEC File Offset: 0x008500EC
		public static void CancelAll()
		{
			try
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.hippogames.simpleandroidnotifications.Controller");
				if (androidJavaClass != null)
				{
					androidJavaClass.CallStatic("CancelAllNotifications", new object[0]);
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0601B078 RID: 110712 RVA: 0x00851D38 File Offset: 0x00850138
		private static int ColotToInt(Color color)
		{
			Color32 color2 = color;
			return (int)color2.r * 65536 + (int)color2.g * 256 + (int)color2.b;
		}

		// Token: 0x0601B079 RID: 110713 RVA: 0x00851D6F File Offset: 0x0085016F
		private static string GetSmallIconName(NotificationIcon icon)
		{
			return "anp_" + icon.ToString().ToLower();
		}

		// Token: 0x0601B07A RID: 110714 RVA: 0x00851D90 File Offset: 0x00850190
		private static long GetDelayDurTime()
		{
			int num = DateTime.Now.Hour * 60 * 60 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
			int num2 = NotificationManager.hour * 60 * 60;
			int num3 = num2 - num;
			int num4;
			if (num3 <= 0)
			{
				num4 = 86400 + num3;
			}
			else
			{
				num4 = num3;
			}
			return (long)num4 * 1000L;
		}

		// Token: 0x0601B07B RID: 110715 RVA: 0x00851E08 File Offset: 0x00850208
		private static long GetNearestWeekdayTime(int weekday, int hour, int minute)
		{
			int num = (int)(DateTime.Now.DayOfWeek + 1);
			int num2 = (7 - num + weekday) % 7;
			DateTime dateTime = DateTime.Now.AddDays((double)num2);
			DateTime dateTime2 = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, minute, 0);
			long num3 = (long)dateTime2.Subtract(DateTime.Now).TotalMilliseconds;
			if (num3 < 0L)
			{
				num3 += 604800000L;
			}
			return num3;
		}

		// Token: 0x0601B07C RID: 110716 RVA: 0x00851E8A File Offset: 0x0085028A
		public static void SetCustomHour(int outHour)
		{
			NotificationManager.hour = outHour;
		}

		// Token: 0x0601B07D RID: 110717 RVA: 0x00851E92 File Offset: 0x00850292
		public static void SetCustomWeekly(int outWeekday, int outHour, int outMinute)
		{
			NotificationManager.weekDay = outWeekday;
			NotificationManager.weekHour = outHour;
			NotificationManager.weekMinute = outMinute;
		}

		// Token: 0x0601B07E RID: 110718 RVA: 0x00851EA6 File Offset: 0x008502A6
		public static void SetIntentActivityForSDK(string mainActivityClass)
		{
			NotificationManager.MainActivityClassName = mainActivityClass;
		}

		// Token: 0x04012D94 RID: 77204
		private static string MainActivityClassName = "com.example.administrator.myapplication.BaseActivity";

		// Token: 0x04012D95 RID: 77205
		private const string FullClassName = "com.hippogames.simpleandroidnotifications.Controller";

		// Token: 0x04012D96 RID: 77206
		private static int hour;

		// Token: 0x04012D97 RID: 77207
		private static int weekDay;

		// Token: 0x04012D98 RID: 77208
		private static int weekHour;

		// Token: 0x04012D99 RID: 77209
		private static int weekMinute;
	}
}
