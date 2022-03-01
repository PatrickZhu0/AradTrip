using System;

namespace GameClient
{
	// Token: 0x0200133D RID: 4925
	public abstract class TimeModel : ITimeModel
	{
		// Token: 0x17001B94 RID: 7060
		// (get) Token: 0x0600BF4C RID: 48972 RVA: 0x002D07E3 File Offset: 0x002CEBE3
		public float RemainTime
		{
			get
			{
				return this._remainTime;
			}
		}

		// Token: 0x0600BF4D RID: 48973 RVA: 0x002D07EB File Offset: 0x002CEBEB
		public string GetRemainString()
		{
			return Function.GetShortTimeString((double)this._remainTime);
		}

		// Token: 0x0600BF4E RID: 48974 RVA: 0x002D07F9 File Offset: 0x002CEBF9
		public float GetRemainTime()
		{
			return this._remainTime;
		}

		// Token: 0x0600BF4F RID: 48975
		public abstract void Update(float delta);

		// Token: 0x0600BF50 RID: 48976 RVA: 0x002D0801 File Offset: 0x002CEC01
		protected void UpdateRemainTime(float delta)
		{
			this._remainTime -= delta;
			if (this._remainTime <= 0f)
			{
				this._remainTime = 0f;
			}
		}

		// Token: 0x04006BF1 RID: 27633
		protected float _remainTime;
	}
}
