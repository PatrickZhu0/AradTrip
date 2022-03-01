using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001341 RID: 4929
	public class TimeDataManager : DataManager<TimeDataManager>
	{
		// Token: 0x0600BF5C RID: 48988 RVA: 0x002D08E4 File Offset: 0x002CECE4
		public int CalcRemainTimeByUnix(ITimeData time)
		{
			int num = (int)(time.EndTime - (long)((ulong)DataManager<TimeManager>.GetInstance().GetServerTime()));
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600BF5D RID: 48989 RVA: 0x002D0910 File Offset: 0x002CED10
		public int CalcDuration(ITimeData time)
		{
			DateTime d = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			double totalSeconds = (DateTime.Now - d).TotalSeconds;
			return (int)totalSeconds;
		}

		// Token: 0x0600BF5E RID: 48990 RVA: 0x002D094A File Offset: 0x002CED4A
		public void Register(UnixTimeModel data)
		{
			this._unixDataList.Add(data);
		}

		// Token: 0x0600BF5F RID: 48991 RVA: 0x002D0958 File Offset: 0x002CED58
		public void Unregister(UnixTimeModel data)
		{
			if (this._unixDataList.Contains(data))
			{
				this._unixDataList.Remove(data);
			}
		}

		// Token: 0x0600BF60 RID: 48992 RVA: 0x002D0978 File Offset: 0x002CED78
		public override void Update(float delta)
		{
			for (int i = this._unixDataList.Count - 1; i >= 0; i--)
			{
				this._unixDataList[i].Update(delta);
			}
		}

		// Token: 0x0600BF61 RID: 48993 RVA: 0x002D09B5 File Offset: 0x002CEDB5
		public override void Initialize()
		{
		}

		// Token: 0x0600BF62 RID: 48994 RVA: 0x002D09B7 File Offset: 0x002CEDB7
		public override void Clear()
		{
			this._unixDataList.Clear();
		}

		// Token: 0x0600BF63 RID: 48995 RVA: 0x002D09C4 File Offset: 0x002CEDC4
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.TimeDataManager;
		}

		// Token: 0x04006BF5 RID: 27637
		private List<TimeModel> _unixDataList = new List<TimeModel>();
	}
}
