using System;

namespace GameClient
{
	// Token: 0x02000E5B RID: 3675
	public static class CountDownTimeUtility
	{
		// Token: 0x060091F9 RID: 37369 RVA: 0x001B0C68 File Offset: 0x001AF068
		public static string GetCountDownTimeByTotalTimeFormat(uint totalTime)
		{
			uint num = 0U;
			uint num2 = 0U;
			if (totalTime <= 0U)
			{
				return string.Format("{0:D2}:{1:D2}", num, num2);
			}
			num = totalTime / 3600U;
			num2 = (totalTime - 3600U * num) / 60U;
			return string.Format("{0:D2}:{1:D2}", num, num2);
		}

		// Token: 0x060091FA RID: 37370 RVA: 0x001B0CC4 File Offset: 0x001AF0C4
		public static string GetCountDownTimeByHourMinute(uint endTime, uint curTime)
		{
			uint num = 0U;
			uint num2 = 0U;
			if (endTime <= curTime)
			{
				return string.Format("{0:D2}:{1:D2}", num, num2);
			}
			uint num3 = endTime - curTime;
			num = num3 / 3600U;
			num2 = (num3 - 3600U * num) / 60U;
			return string.Format("{0:D2}:{1:D2}", num, num2);
		}

		// Token: 0x060091FB RID: 37371 RVA: 0x001B0D24 File Offset: 0x001AF124
		public static string GetCountDownTimeByHourMinuteSecondFormat(uint endTime, uint curTime)
		{
			uint num = 0U;
			uint num2 = 0U;
			uint num3 = 0U;
			if (endTime <= curTime)
			{
				return string.Format("{0:D2}:{1:D2}:{2:D2}", num, num2, num3);
			}
			uint num4 = endTime - curTime;
			num = num4 / 3600U;
			num2 = (num4 - 3600U * num) / 60U;
			num3 = (num4 - 3600U * num) % 60U;
			return string.Format("{0:D2}:{1:D2}:{2:D2}", num, num2, num3);
		}

		// Token: 0x060091FC RID: 37372 RVA: 0x001B0DA4 File Offset: 0x001AF1A4
		public static string GetCountDownTimeByMinuteSecondFormat(uint endTime, uint curTime)
		{
			uint num = 0U;
			uint num2 = 0U;
			if (endTime <= curTime)
			{
				return string.Format("{0:D2}:{1:D2}", num, num2);
			}
			uint num3 = endTime - curTime;
			num = num3 / 60U;
			num2 = num3 - num * 60U;
			return string.Format("{0:D2}:{1:D2}", num, num2);
		}

		// Token: 0x060091FD RID: 37373 RVA: 0x001B0DFC File Offset: 0x001AF1FC
		public static string GetCountDownTimeByDayHourMinuteSecondFormat(uint endTime, uint curTime)
		{
			uint num = 0U;
			uint num2 = 0U;
			uint num3 = 0U;
			uint num4 = 0U;
			if (endTime <= curTime)
			{
				return TR.Value("Count_Down_Time_Day_Hour_Minute_Second_Format", num, num2, num3, num4);
			}
			uint num5 = endTime - curTime;
			num = num5 / 86400U;
			num2 = (num5 - 86400U * num) / 3600U;
			uint num6 = num5 - num * 86400U - num2 * 3600U;
			num3 = num6 / 60U;
			num4 = num6 % 60U;
			return TR.Value("Count_Down_Time_Day_Hour_Minute_Second_Format", num, num2, num3, num4);
		}

		// Token: 0x060091FE RID: 37374 RVA: 0x001B0EA4 File Offset: 0x001AF2A4
		public static string GetCountDownTimeBySecondFormat(uint endTime, uint curTime)
		{
			if (endTime <= curTime)
			{
				return "0";
			}
			return (endTime - curTime).ToString();
		}

		// Token: 0x060091FF RID: 37375 RVA: 0x001B0ED0 File Offset: 0x001AF2D0
		public static string GetCoolDownTimeByDayHour(uint endTime, uint curTime)
		{
			uint num = 0U;
			uint num2 = 0U;
			if (endTime <= curTime)
			{
				return string.Format(TR.Value("auction_new_item_trade_cool_down_time"), num, num2);
			}
			uint num3 = endTime - curTime;
			num = num3 / 86400U;
			num2 = (num3 - 86400U * num) / 3600U;
			return string.Format(TR.Value("auction_new_item_trade_cool_down_time"), num, num2);
		}
	}
}
