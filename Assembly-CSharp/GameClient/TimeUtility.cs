using System;

namespace GameClient
{
	// Token: 0x02000E5C RID: 3676
	public static class TimeUtility
	{
		// Token: 0x06009200 RID: 37376 RVA: 0x001B0F3C File Offset: 0x001AF33C
		public static bool IsInSameMinuteOfTwoTimeStamp(ulong beginTime, ulong endTime)
		{
			if (endTime == beginTime)
			{
				return true;
			}
			if (endTime < beginTime)
			{
				return false;
			}
			if (endTime - beginTime > 60UL)
			{
				return false;
			}
			DateTime dateTimeByTimeStamp = TimeUtility.GetDateTimeByTimeStamp((int)beginTime);
			DateTime dateTimeByTimeStamp2 = TimeUtility.GetDateTimeByTimeStamp((int)endTime);
			return dateTimeByTimeStamp.Minute == dateTimeByTimeStamp2.Minute;
		}

		// Token: 0x06009201 RID: 37377 RVA: 0x001B0F90 File Offset: 0x001AF390
		public static bool IsInSameDayOfTwoTimeStamp(ulong firstTimeStamp, ulong secondTimeStamp)
		{
			if (firstTimeStamp == secondTimeStamp)
			{
				return true;
			}
			if (firstTimeStamp > secondTimeStamp && firstTimeStamp - secondTimeStamp >= 86400UL)
			{
				return false;
			}
			if (secondTimeStamp > firstTimeStamp && secondTimeStamp - firstTimeStamp >= 86400UL)
			{
				return false;
			}
			DateTime dateTimeByTimeStamp = TimeUtility.GetDateTimeByTimeStamp((int)firstTimeStamp);
			DateTime dateTimeByTimeStamp2 = TimeUtility.GetDateTimeByTimeStamp((int)secondTimeStamp);
			return dateTimeByTimeStamp.Day == dateTimeByTimeStamp2.Day;
		}

		// Token: 0x06009202 RID: 37378 RVA: 0x001B0FFC File Offset: 0x001AF3FC
		public static bool IsSameDayOfTwoTime(ulong beginTime, ulong endTime)
		{
			if (endTime <= beginTime)
			{
				return true;
			}
			DateTime dateTimeByTimeStamp = TimeUtility.GetDateTimeByTimeStamp((int)beginTime);
			DateTime dateTimeByTimeStamp2 = TimeUtility.GetDateTimeByTimeStamp((int)endTime);
			return dateTimeByTimeStamp.ToString("yyyy-MM-dd") == dateTimeByTimeStamp2.ToString("yyyy-MM-dd");
		}

		// Token: 0x06009203 RID: 37379 RVA: 0x001B1040 File Offset: 0x001AF440
		public static int GetWeekNumberBetweenTime(ulong beginTime, ulong endTime)
		{
			if (endTime <= beginTime)
			{
				return 0;
			}
			int num = 0;
			DateTime t = TimeUtility.GetDateTimeByTimeStamp((int)beginTime);
			DateTime dateTimeByTimeStamp = TimeUtility.GetDateTimeByTimeStamp((int)endTime);
			while (t < dateTimeByTimeStamp)
			{
				if (t.DayOfWeek == DayOfWeek.Sunday)
				{
					num++;
				}
				t = t.AddDays(1.0);
			}
			if (dateTimeByTimeStamp.DayOfWeek != DayOfWeek.Sunday)
			{
				num++;
			}
			return num;
		}

		// Token: 0x06009204 RID: 37380 RVA: 0x001B10AC File Offset: 0x001AF4AC
		public static DateTime GetDateTimeByTimeStamp(int time)
		{
			return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds((double)time);
		}

		// Token: 0x06009205 RID: 37381 RVA: 0x001B10DC File Offset: 0x001AF4DC
		public static int GetTodayTimeInWeekDay()
		{
			switch (Function.GetTodayZeroTime().DayOfWeek)
			{
			case DayOfWeek.Sunday:
				return 7;
			case DayOfWeek.Monday:
				return 1;
			case DayOfWeek.Tuesday:
				return 2;
			case DayOfWeek.Wednesday:
				return 3;
			case DayOfWeek.Thursday:
				return 4;
			case DayOfWeek.Friday:
				return 5;
			case DayOfWeek.Saturday:
				return 6;
			default:
				return 7;
			}
		}

		// Token: 0x06009206 RID: 37382 RVA: 0x001B1130 File Offset: 0x001AF530
		public static int GetYesterdayTimeInWeekDay()
		{
			int todayTimeInWeekDay = TimeUtility.GetTodayTimeInWeekDay();
			if (todayTimeInWeekDay == 1)
			{
				return 7;
			}
			return todayTimeInWeekDay - 1;
		}

		// Token: 0x06009207 RID: 37383 RVA: 0x001B1150 File Offset: 0x001AF550
		public static string GetTimeFormatByYearMonthDay(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}年{1}月{2}日{3:HH:mm}", new object[]
			{
				dateTime.Year,
				dateTime.Month,
				dateTime.Day,
				dateTime
			});
		}

		// Token: 0x06009208 RID: 37384 RVA: 0x001B11C8 File Offset: 0x001AF5C8
		public static string GetTimeFormatByYearMonthDayAndHour(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}年{1}月{2}日{3}点", new object[]
			{
				dateTime.Year,
				dateTime.Month,
				dateTime.Day,
				dateTime.Hour
			});
		}

		// Token: 0x06009209 RID: 37385 RVA: 0x001B1244 File Offset: 0x001AF644
		public static string GetTimeFormatByMonthDay(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}月{1}日", dateTime.Month, dateTime.Day);
		}

		// Token: 0x0600920A RID: 37386 RVA: 0x001B1298 File Offset: 0x001AF698
		public static string GetTimeFormatByMonthDayWithCommonFormat(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}/{1}/{2}", dateTime.Year, dateTime.Month, dateTime.Day);
		}

		// Token: 0x0600920B RID: 37387 RVA: 0x001B12F8 File Offset: 0x001AF6F8
		public static string GetTimeFormatByYearMonthDayHourAndMinuteWithCommonFormat(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}/{1}/{2} {3:HH:mm}", new object[]
			{
				dateTime.Year,
				dateTime.Month,
				dateTime.Day,
				dateTime
			});
		}

		// Token: 0x0600920C RID: 37388 RVA: 0x001B1370 File Offset: 0x001AF770
		public static string GetTimeFormatByHourMinute(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0:HH:mm}", dateTime);
		}

		// Token: 0x0600920D RID: 37389 RVA: 0x001B13B0 File Offset: 0x001AF7B0
		public static string GetTimeFormatByMonthDayHourMinute(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}-{1} {2:HH:mm}", dateTime.Month, dateTime.Day, dateTime);
		}

		// Token: 0x0600920E RID: 37390 RVA: 0x001B1408 File Offset: 0x001AF808
		public static string GetTimeFormatByMonthDayHourMinuteWithCommonFormat(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}/{1} {2:HH:mm}", dateTime.Month, dateTime.Day, dateTime);
		}

		// Token: 0x0600920F RID: 37391 RVA: 0x001B1460 File Offset: 0x001AF860
		public static string GetTimeFormatByCommonMonthDayHourMinute(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}月{1}日{2:HH:mm}", dateTime.Month, dateTime.Day, dateTime);
		}

		// Token: 0x06009210 RID: 37392 RVA: 0x001B14B8 File Offset: 0x001AF8B8
		public static int GetTimeHourByCurrentTimeStamp(uint timeStamp)
		{
			return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp).Hour;
		}
	}
}
