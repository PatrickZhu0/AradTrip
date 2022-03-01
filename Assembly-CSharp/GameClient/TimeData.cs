using System;

namespace GameClient
{
	// Token: 0x02001340 RID: 4928
	public struct TimeData : ITimeData
	{
		// Token: 0x0600BF58 RID: 48984 RVA: 0x002D08AE File Offset: 0x002CECAE
		public TimeData(long startTime, long endTime)
		{
			this._startTime = startTime;
			this._endTime = endTime;
		}

		// Token: 0x17001B98 RID: 7064
		// (get) Token: 0x0600BF59 RID: 48985 RVA: 0x002D08BE File Offset: 0x002CECBE
		public long EndTime
		{
			get
			{
				return this._endTime;
			}
		}

		// Token: 0x17001B99 RID: 7065
		// (get) Token: 0x0600BF5A RID: 48986 RVA: 0x002D08C6 File Offset: 0x002CECC6
		public long StartTime
		{
			get
			{
				return this._startTime;
			}
		}

		// Token: 0x04006BF3 RID: 27635
		private long _startTime;

		// Token: 0x04006BF4 RID: 27636
		private long _endTime;
	}
}
