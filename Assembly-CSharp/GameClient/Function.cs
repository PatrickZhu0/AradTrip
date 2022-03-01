using System;
using System.Collections.Generic;
using System.Globalization;

namespace GameClient
{
	// Token: 0x02000140 RID: 320
	public static class Function
	{
		// Token: 0x0600092A RID: 2346 RVA: 0x0002FE98 File Offset: 0x0002E298
		public static string GetShortTimeString(double d)
		{
			return Function.ConvertIntDateTime(d).ToString("T", DateTimeFormatInfo.InvariantInfo);
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x0002FEC0 File Offset: 0x0002E2C0
		public static DateTime ConvertIntDateTime(double d)
		{
			DateTime minValue = DateTime.MinValue;
			return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(d);
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x0002FEF4 File Offset: 0x0002E2F4
		public static double ConvertDateTimeInt(DateTime time)
		{
			DateTime d = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			return (time - d).TotalSeconds;
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x0002FF34 File Offset: 0x0002E334
		public static float CalLeftTime(double fBeginTime, double TotalLastsTime)
		{
			DateTime now = DateTime.Now;
			double num = Function.ConvertDateTimeInt(now);
			double num2 = num - fBeginTime;
			return (float)TotalLastsTime - (float)num2;
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x0002FF5C File Offset: 0x0002E35C
		public static float CalLeftTime(float fEndTime)
		{
			DateTime now = DateTime.Now;
			double num = Function.ConvertDateTimeInt(now);
			return fEndTime - (float)num;
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x0002FF7C File Offset: 0x0002E37C
		public static string GetBeginTimeStr(double fBeginTime, ShowtimeType eShowType = ShowtimeType.Normal)
		{
			DateTime dateTime = Function.ConvertIntDateTime(fBeginTime);
			string text = string.Empty;
			if (eShowType != ShowtimeType.Auction)
			{
				text = text + dateTime.Year.ToString() + ".";
				text = text + dateTime.Month.ToString() + ".";
				text += dateTime.Day.ToString();
			}
			return text;
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x00030004 File Offset: 0x0002E404
		public static string GetLeftTimeStr(float fEndTime, ShowtimeType eShowType = ShowtimeType.Normal)
		{
			string text = string.Empty;
			DateTime now = DateTime.Now;
			double num = Function.ConvertDateTimeInt(now);
			double num2 = (double)fEndTime - num;
			int num3 = (int)num2 / 86400;
			num2 -= (double)(num3 * 24 * 60 * 60);
			int num4 = (int)num2 / 3600;
			num2 -= (double)(num4 * 60 * 60);
			int num5 = (int)num2 / 60;
			if (eShowType == ShowtimeType.Auction)
			{
				if (num3 > 0)
				{
					text = string.Format("{0}小时", num3 * 24 + num4);
				}
				else if (num4 > 0)
				{
					text = string.Format("{0}小时", num4);
				}
				else if (num5 > 0)
				{
					text = string.Format("{0}分钟", num5);
				}
				else
				{
					text = "不足1分钟";
				}
			}
			else if (eShowType == ShowtimeType.NewYearRedPack)
			{
				if (num3 > 0)
				{
					text = string.Format("{0}天{1}小时{2}分", num3, num4, num5);
				}
				else if (num4 > 0)
				{
					text = string.Format("{0}小时{1}分", num4, num5);
				}
				else if (num5 > 0)
				{
					text = string.Format("{0}分钟", num5);
				}
				else
				{
					text = "不足1分钟";
				}
			}
			else
			{
				if (num3 < 0)
				{
					text = "<color=#fb0e0e>";
				}
				text += "有效期:";
				if (num3 > 0)
				{
					text += string.Format("{0}天", num3);
				}
				else if (num4 > 0)
				{
					text += string.Format("{0}小时", num4);
				}
				else if (num5 > 0)
				{
					text += string.Format("{0}分钟", num5);
				}
				else
				{
					text += "不足1分钟";
				}
				if (num3 < 0)
				{
					text += "</color>";
				}
			}
			return text;
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x00030204 File Offset: 0x0002E604
		public static string GetLeftTimeStr(double fBeginTime, double TotalLastsTime, ShowtimeType eShowType = ShowtimeType.Normal)
		{
			string text = string.Empty;
			DateTime now = DateTime.Now;
			double num = Function.ConvertDateTimeInt(now);
			double num2 = num - fBeginTime;
			double num3 = TotalLastsTime - num2;
			int num4 = (int)num3 / 86400;
			num3 -= (double)(num4 * 24 * 60 * 60);
			int num5 = (int)num3 / 3600;
			num3 -= (double)(num5 * 60 * 60);
			int num6 = (int)num3 / 60;
			if (eShowType == ShowtimeType.Auction)
			{
				if (num4 > 0)
				{
					text = string.Format("{0}小时", num4 * 24 + num5);
				}
				else if (num5 > 0)
				{
					text = string.Format("{0}小时", num5);
				}
				else if (num6 > 0)
				{
					text = string.Format("{0}分钟", num6);
				}
				else
				{
					text = "不足1分钟";
				}
			}
			else
			{
				if (num4 < 0)
				{
					text = "<color=#fb0e0e>";
				}
				text += "有效期:";
				if (num4 > 0)
				{
					text += string.Format("{0}天", num4);
				}
				else if (num5 > 0)
				{
					text += string.Format("{0}小时", num5);
				}
				else if (num6 > 0)
				{
					text += string.Format("{0}分钟", num6);
				}
				else
				{
					text += "不足1分钟";
				}
				if (num4 < 0)
				{
					text += "</color>";
				}
			}
			return text;
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x0003038C File Offset: 0x0002E78C
		public static List<int> GetTimeForNum(int time)
		{
			List<int> list = new List<int>();
			list.Clear();
			int num = (int)(DataManager<TimeManager>.GetInstance().GetServerTime() - (uint)time);
			if (num < 0)
			{
				num = 0;
			}
			int num2 = num / 24 / 60 / 60;
			if (num2 > 0)
			{
				num -= num2 * 24 * 60 * 60;
			}
			int item = num / 60 / 60;
			int item2 = num / 60 % 60;
			int item3 = num % 60;
			list.Add(num2);
			list.Add(item);
			list.Add(item2);
			list.Add(item3);
			return list;
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x00030410 File Offset: 0x0002E810
		public static string SetShowTime(int NextStartTime)
		{
			string text = string.Empty;
			int num = NextStartTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			if (num <= 0)
			{
				return "0秒";
			}
			int num2 = num / 24 / 60 / 60;
			if (num2 > 0)
			{
				text = num2.ToString() + "天";
				num -= num2 * 24 * 60 * 60;
			}
			int num3 = num / 60 / 60;
			int num4 = num / 60 % 60;
			string arg = num4.ToString().PadLeft(2, '0');
			int num5 = num % 60;
			string arg2 = num5.ToString().PadLeft(2, '0');
			string text2 = string.Empty;
			string text3 = string.Empty;
			string text4 = string.Empty;
			if (num3 != 0)
			{
				text2 = string.Format("{0}小时", num3);
			}
			if (num4 != 0 || num3 != 0)
			{
				text3 = string.Format("{0}分钟", arg);
			}
			if (num5 != 0 || num4 != 0 || num3 != 0)
			{
				text4 = string.Format("{0}秒", arg2);
			}
			return string.Format("{0}{1}{2}{3}", new object[]
			{
				text,
				text2,
				text3,
				text4
			});
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x00030548 File Offset: 0x0002E948
		public static string SetShowTimeMin(int NextStartTime)
		{
			string arg = string.Empty;
			int num = NextStartTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			if (num <= 0)
			{
				num = 0;
			}
			int num2 = num / 24 / 60 / 60;
			if (num2 > 0)
			{
				arg = num2.ToString() + "天";
				num -= num2 * 24 * 60 * 60;
			}
			int num3 = num / 60 / 60;
			int num4 = num / 60 % 60;
			string arg2 = num4.ToString().PadLeft(2, '0');
			string text = (num % 60).ToString().PadLeft(2, '0');
			string arg3 = string.Empty;
			string arg4 = string.Empty;
			string empty = string.Empty;
			if (num3 != 0)
			{
				arg3 = string.Format("{0}小时", num3);
			}
			if (num4 != 0 || num3 != 0)
			{
				arg4 = string.Format("{0}分钟", arg2);
			}
			return string.Format("{0}{1}{2}", arg, arg3, arg4);
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x00030644 File Offset: 0x0002EA44
		public static string SetShowTimeHour(int NextStartTime)
		{
			string arg = string.Empty;
			int num = NextStartTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			if (num < 0)
			{
				return "0秒";
			}
			int num2 = num / 24 / 60 / 60;
			if (num2 > 0)
			{
				arg = num2.ToString() + "天";
				num -= num2 * 24 * 60 * 60;
			}
			int num3 = num / 60 / 60;
			string arg2 = string.Empty;
			if (num3 != 0)
			{
				arg2 = string.Format("{0}小时", num3);
			}
			return string.Format("{0}{1}", arg, arg2);
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x000306DC File Offset: 0x0002EADC
		public static string SetShowTimeDay(int EndTime)
		{
			string result = string.Empty;
			int num = EndTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			if (num < 0)
			{
				return "0秒";
			}
			int num2 = num / 24 / 60 / 60;
			if (num2 > 0)
			{
				result = string.Format("{0}天", num2);
			}
			if (num2 < 1)
			{
				result = "1天";
			}
			return result;
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x0003073C File Offset: 0x0002EB3C
		public static string GetLastsTimeStr(double fCurTime)
		{
			string result = string.Empty;
			int num = (int)fCurTime;
			if (num < 0)
			{
				num = 0;
			}
			int num2 = num / 3600;
			num -= num2 * 60 * 60;
			int num3 = num / 60;
			num -= num3 * 60;
			if (num2 > 0)
			{
				result = string.Format("{0:00}:{1:00}:{2:00}", num2, num3, num);
			}
			else if (num3 > 0)
			{
				result = string.Format("{0:00}:{1:00}", num3, num);
			}
			else
			{
				result = string.Format("00:{0:00}", num);
			}
			return result;
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x000307D8 File Offset: 0x0002EBD8
		public static string GetLeftTime(int fEndTime, int fNowTime, ShowtimeType eShowType = ShowtimeType.Normal)
		{
			string result = string.Empty;
			int num = fEndTime - fNowTime;
			if (num < 0)
			{
				num = 0;
			}
			int num2 = num / 86400;
			num -= num2 * 24 * 60 * 60;
			int num3 = num / 3600;
			num -= num3 * 60 * 60;
			int num4 = num / 60;
			num -= num4 * 60;
			if (eShowType == ShowtimeType.OnlineGift)
			{
				if (num4 >= 0 && num4 <= 9)
				{
					if (num >= 0 && num <= 9)
					{
						result = string.Format("0{0}:0{1}", num4, num);
					}
					else
					{
						result = string.Format("0{0}:{1}", num4, num);
					}
				}
				else if (num >= 0 && num <= 9)
				{
					result = string.Format("{0}:0{1}", num4, num);
				}
				else
				{
					result = string.Format("{0}:{1}", num4, num);
				}
			}
			else if (num2 > 0)
			{
				result = string.Format("{0}小时", num2 * 24 + num3);
			}
			else if (num3 > 0)
			{
				result = string.Format("{0}小时", num3);
			}
			else if (num4 > 0)
			{
				result = string.Format("{0}分{1}秒", num4, num);
			}
			else
			{
				result = string.Format("{0}分{1}秒", num4, num);
			}
			return result;
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x00030954 File Offset: 0x0002ED54
		public static string GetLeftMinutes(int fEndTime, int fNowTime)
		{
			string empty = string.Empty;
			int num = fEndTime - fNowTime;
			int num2 = num / 60;
			num -= num2 * 60;
			return string.Format("{0}分{1}秒", num2, num);
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x00030990 File Offset: 0x0002ED90
		public static bool IsTodayTimeBySpan(long num)
		{
			if (num == 0L)
			{
				return false;
			}
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			DateTime dateTime2 = dateTime.AddSeconds(DataManager<TimeManager>.GetInstance().GetServerTime() - 21600U);
			return dateTime.AddSeconds((double)(num - 21600L)).Date == dateTime2.Date;
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x00030A04 File Offset: 0x0002EE04
		public static string GetDate(int startTime, int endTime)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			DateTime dateTime2 = dateTime.AddSeconds((double)startTime);
			DateTime dateTime3 = dateTime.AddSeconds((double)endTime);
			return dateTime2.ToString("yyyy年MM月dd日") + "到" + dateTime3.ToString("yyyy年MM月dd日");
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x00030A60 File Offset: 0x0002EE60
		public static string GetMonthDate(int startTime, int endTime)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			DateTime dateTime2 = dateTime.AddSeconds((double)startTime);
			DateTime dateTime3 = dateTime.AddSeconds((double)endTime);
			return dateTime2.ToString("MM月dd日") + "到" + dateTime3.ToString("MM月dd日");
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x00030ABC File Offset: 0x0002EEBC
		public static string GetOneData(int time)
		{
			return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds((double)time).ToString("yyyy年MM月dd日");
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x00030AF8 File Offset: 0x0002EEF8
		public static string GetDateTime(int startTime, int endTime)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			DateTime dateTime2 = dateTime.AddSeconds((double)startTime);
			DateTime dateTime3 = dateTime.AddSeconds((double)endTime);
			return dateTime2.ToString("yyyy年MM月dd日HH:mm") + "到" + dateTime3.ToString("yyyy年MM月dd日HH:mm");
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x00030B54 File Offset: 0x0002EF54
		public static string GetDateTimeHMS(int startTime, int endTime)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			DateTime dateTime2 = dateTime.AddSeconds((double)startTime);
			DateTime dateTime3 = dateTime.AddSeconds((double)endTime);
			return dateTime2.ToString("yyyy年MM月dd日HH:mm:ss") + "至" + dateTime3.ToString("yyyy年MM月dd日HH:mm:ss");
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x00030BB0 File Offset: 0x0002EFB0
		public static string GetTime(int time)
		{
			return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds((double)time).ToString("HH:mm");
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x00030BEC File Offset: 0x0002EFEC
		public static string GetDateTime(int time, bool needYear = true)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds((double)time);
			if (needYear)
			{
				return dateTime.ToString("yyyy年MM月dd日 HH:mm");
			}
			return dateTime.ToString("MM月dd日");
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x00030C3C File Offset: 0x0002F03C
		public static string GetDateTimeHaveMonthToSecond(int time)
		{
			return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds((double)time).ToString("MM月dd日 HH:mm");
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x00030C78 File Offset: 0x0002F078
		public static string GetTime(int startTime, int endTime)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			DateTime dateTime2 = dateTime.AddSeconds((double)startTime);
			DateTime dateTime3 = dateTime.AddSeconds((double)endTime);
			return dateTime2.ToString("HH:mm") + "-" + dateTime3.ToString("HH:mm");
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x00030CD4 File Offset: 0x0002F0D4
		public static string GetTimeChinese(int startTime, int endTime)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			DateTime dateTime2 = dateTime.AddSeconds((double)startTime);
			DateTime dateTime3 = dateTime.AddSeconds((double)endTime);
			return dateTime2.ToString("HH时:mm分") + "-" + dateTime3.ToString("HH时:mm分");
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x00030D30 File Offset: 0x0002F130
		public static string GetTimeWithoutYear(int startTime, int endTime)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			DateTime dateTime2 = dateTime.AddSeconds((double)startTime);
			DateTime dateTime3 = dateTime.AddSeconds((double)endTime);
			return dateTime2.ToString("MM月dd日HH:mm") + "~" + dateTime3.ToString("MM月dd日HH:mm");
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x00030D8C File Offset: 0x0002F18C
		public static string GetTimeWithMonthDayHour(int startTime, int endTime)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			DateTime dateTime2 = dateTime.AddSeconds((double)startTime);
			DateTime dateTime3 = dateTime.AddSeconds((double)endTime);
			return dateTime2.ToString("M/d H:mm") + "-" + dateTime3.ToString("M/d H:mm");
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x00030DE8 File Offset: 0x0002F1E8
		public static string GetTimeWithoutYearNoZero(int startTime, int endTime)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			DateTime dateTime2 = dateTime.AddSeconds((double)startTime);
			DateTime dateTime3 = dateTime.AddSeconds((double)endTime);
			return string.Format("{0}月{1}日{2:HH:mm}~{3}月{4}日{5:HH:mm}", new object[]
			{
				dateTime2.Month,
				dateTime2.Day,
				dateTime2,
				dateTime3.Month,
				dateTime3.Day,
				dateTime3
			});
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x00030E80 File Offset: 0x0002F280
		public static string GetTimeWithoutYearMonthDay(int startTime, int endTime)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			DateTime dateTime2 = dateTime.AddSeconds((double)startTime);
			DateTime dateTime3 = dateTime.AddSeconds((double)endTime);
			return string.Format("{0}.{1}.{2}~{3}.{4}.{5}", new object[]
			{
				dateTime2.Year,
				dateTime2.Month,
				dateTime2.Day,
				dateTime3.Year,
				dateTime3.Month,
				dateTime3.Day
			});
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x00030F24 File Offset: 0x0002F324
		public static int GetLeftDay(int nowTime, int endTime)
		{
			int num = endTime - nowTime;
			int num2 = num / 86400;
			return (num2 <= 0) ? 0 : num2;
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x00030F4C File Offset: 0x0002F34C
		public static DateTime GetTodayZeroTime()
		{
			double serverDoubleTime = DataManager<TimeManager>.GetInstance().GetServerDoubleTime();
			DateTime dateTime = Function.ConvertIntDateTime(serverDoubleTime);
			return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x00030F88 File Offset: 0x0002F388
		public static DateTime GetYestodayZeroTime()
		{
			double serverDoubleTime = DataManager<TimeManager>.GetInstance().GetServerDoubleTime();
			DateTime dateTime = Function.ConvertIntDateTime(serverDoubleTime);
			TimeSpan value = new TimeSpan(1, 0, 0, 0);
			DateTime dateTime2 = dateTime.Subtract(value);
			return new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day);
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x00030FD8 File Offset: 0x0002F3D8
		public static DateTime GetDayBeforYestodayZeroTime()
		{
			double serverDoubleTime = DataManager<TimeManager>.GetInstance().GetServerDoubleTime();
			DateTime dateTime = Function.ConvertIntDateTime(serverDoubleTime);
			TimeSpan value = new TimeSpan(2, 0, 0, 0);
			DateTime dateTime2 = dateTime.Subtract(value);
			return new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day);
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x00031028 File Offset: 0x0002F428
		public static DateTime GetTomorrowZeroTime()
		{
			double serverDoubleTime = DataManager<TimeManager>.GetInstance().GetServerDoubleTime();
			DateTime dateTime = Function.ConvertIntDateTime(serverDoubleTime);
			TimeSpan value = new TimeSpan(1, 0, 0, 0);
			DateTime dateTime2 = dateTime.Add(value);
			return new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day);
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x00031078 File Offset: 0x0002F478
		public static DateTime GetTodayGivenHourTime(int hour)
		{
			DateTime todayZeroTime = Function.GetTodayZeroTime();
			TimeSpan value = new TimeSpan(0, hour, 0, 0);
			return todayZeroTime.Add(value);
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x000310A0 File Offset: 0x0002F4A0
		public static DateTime GetTomorrowGivenHourTime(int hour)
		{
			DateTime tomorrowZeroTime = Function.GetTomorrowZeroTime();
			TimeSpan value = new TimeSpan(0, hour, 0, 0);
			return tomorrowZeroTime.Add(value);
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x000310C8 File Offset: 0x0002F4C8
		public static DateTime GetYesterdayGivenHourTime(int hour)
		{
			DateTime yestodayZeroTime = Function.GetYestodayZeroTime();
			TimeSpan value = new TimeSpan(0, hour, 0, 0);
			return yestodayZeroTime.Add(value);
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x000310F0 File Offset: 0x0002F4F0
		public static DateTime GetTodayGivenHourAndMinuteTime(int hour, int minute)
		{
			DateTime todayZeroTime = Function.GetTodayZeroTime();
			TimeSpan value = new TimeSpan(0, hour, minute, 0);
			return todayZeroTime.Add(value);
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x00031118 File Offset: 0x0002F518
		public static double GetTodayGivenHourAndMinuteTimestamp(int hour, int minute)
		{
			DateTime todayGivenHourAndMinuteTime = Function.GetTodayGivenHourAndMinuteTime(hour, minute);
			return Function.ConvertDateTimeInt(todayGivenHourAndMinuteTime);
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x00031138 File Offset: 0x0002F538
		public static int GetTodayWeek()
		{
			return (int)Function.GetTodayZeroTime().DayOfWeek;
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x00031152 File Offset: 0x0002F552
		public static DateTime GetBeforeDaysDateTime(int dayNum, DateTime start)
		{
			start.AddDays((double)(-(double)dayNum));
			return start;
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x00031160 File Offset: 0x0002F560
		public static DateTime GetNextWeekdayDateTime(DateTime start, DayOfWeek week)
		{
			DateTime dateTime = new DateTime(start.Year, start.Month, start.Day);
			int num = (int)start.DayOfWeek;
			if (num == 0)
			{
				num = 7;
			}
			int num2 = (int)week;
			if (num2 == 0)
			{
				num2 = 7;
			}
			int num3 = num2 - num + 7;
			return dateTime.AddDays((double)num3);
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x000311B4 File Offset: 0x0002F5B4
		public static DateTime GetNextWeekdayDateTime(DayOfWeek week)
		{
			DateTime currDateTime = Function.GetCurrDateTime();
			return Function.GetNextWeekdayDateTime(currDateTime, week);
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x000311D0 File Offset: 0x0002F5D0
		public static DateTime GetThisWeekdayDateTime(DateTime start, DayOfWeek week)
		{
			DateTime dateTime = new DateTime(start.Year, start.Month, start.Day);
			int num = (int)start.DayOfWeek;
			if (num == 0)
			{
				num = 7;
			}
			int num2 = (int)week;
			if (num2 == 0)
			{
				num2 = 7;
			}
			int num3 = num2 - num;
			return dateTime.AddDays((double)num3);
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x00031220 File Offset: 0x0002F620
		public static DateTime GetThisWeekdayDateTime(DayOfWeek week)
		{
			DateTime currDateTime = Function.GetCurrDateTime();
			return Function.GetThisWeekdayDateTime(currDateTime, week);
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0003123C File Offset: 0x0002F63C
		public static DateTime GetNextMonthdayDateTime(DateTime start, int monthday)
		{
			DateTime dateTime = new DateTime(start.Year, start.Month, 1);
			dateTime = dateTime.AddMonths(1);
			int num = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
			if (monthday > num)
			{
				monthday = num;
			}
			if (monthday <= 0)
			{
				monthday = 1;
			}
			return dateTime.AddDays((double)(monthday - 1));
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0003129C File Offset: 0x0002F69C
		public static DateTime GetNextMonthdayDateTime(int monthday)
		{
			DateTime currDateTime = Function.GetCurrDateTime();
			return Function.GetNextMonthdayDateTime(currDateTime, monthday);
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x000312B8 File Offset: 0x0002F6B8
		public static DateTime GetThisMonthdayDateTime(DateTime start, int monthday)
		{
			DateTime dateTime = new DateTime(start.Year, start.Month, 1);
			int num = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
			if (monthday > num)
			{
				monthday = num;
			}
			if (monthday <= 0)
			{
				monthday = 1;
			}
			return dateTime.AddDays((double)(monthday - 1));
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x00031310 File Offset: 0x0002F710
		public static DateTime GetThisMonthdayDateTime(int monthday)
		{
			DateTime currDateTime = Function.GetCurrDateTime();
			return Function.GetThisMonthdayDateTime(currDateTime, monthday);
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0003132C File Offset: 0x0002F72C
		public static int[] TransferTimeSplitByColon(string timeWithColon)
		{
			int[] array = new int[3];
			if (!string.IsNullOrEmpty(timeWithColon))
			{
				string[] array2 = timeWithColon.Split(new char[]
				{
					':'
				});
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				if (array2 != null && array2.Length >= 2)
				{
					if (int.TryParse(array2[0], out num))
					{
						array[0] = num;
					}
					if (int.TryParse(array2[1], out num2))
					{
						array[1] = num2;
					}
					if (array2.Length >= 3 && int.TryParse(array2[2], out num3))
					{
						array[2] = num3;
					}
				}
			}
			return array;
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x000313B8 File Offset: 0x0002F7B8
		public static int GetCurrTimeStamp()
		{
			return (int)DataManager<TimeManager>.GetInstance().GetServerTime();
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x000313D4 File Offset: 0x0002F7D4
		public static int GetCurrTimeHour()
		{
			double serverDoubleTime = DataManager<TimeManager>.GetInstance().GetServerDoubleTime();
			return Function.ConvertIntDateTime(serverDoubleTime).Hour;
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x000313FC File Offset: 0x0002F7FC
		public static DateTime GetCurrDateTime()
		{
			double serverDoubleTime = DataManager<TimeManager>.GetInstance().GetServerDoubleTime();
			return Function.ConvertIntDateTime(serverDoubleTime);
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x0003141C File Offset: 0x0002F81C
		public static int GetRefreshHourTimeStamp(int refreshHour)
		{
			int currTimeHour = Function.GetCurrTimeHour();
			DateTime currDateTime = Function.GetCurrDateTime();
			DateTime time;
			if (refreshHour > currTimeHour)
			{
				time = Function.GetYesterdayGivenHourTime(refreshHour);
			}
			else
			{
				time = Function.GetTodayGivenHourTime(refreshHour);
			}
			return Convert.ToInt32(Function.ConvertDateTimeInt(time));
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x00031460 File Offset: 0x0002F860
		public static string _TransTimeStampToStr(uint timeStamp)
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

		// Token: 0x06000963 RID: 2403 RVA: 0x000314D8 File Offset: 0x0002F8D8
		public static DateTime GetDateTime(string timeStamp, string format = "yyyy-MM-dd HH:mm:ss")
		{
			return DateTime.ParseExact(timeStamp, format, CultureInfo.InvariantCulture);
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x000314F4 File Offset: 0x0002F8F4
		public static int GetTimeStamp(DateTime dt)
		{
			DateTime d = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			return Convert.ToInt32((dt - d).TotalSeconds);
		}
	}
}
