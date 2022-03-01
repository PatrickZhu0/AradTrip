using System;

namespace GameClient
{
	// Token: 0x0200133E RID: 4926
	public class UnixTimeModel : TimeModel, IDisposable
	{
		// Token: 0x0600BF51 RID: 48977 RVA: 0x002D082C File Offset: 0x002CEC2C
		public UnixTimeModel(ITimeData progressTime)
		{
			this._progressTime = progressTime;
			this._remainTime = (float)DataManager<TimeDataManager>.GetInstance().CalcRemainTimeByUnix(progressTime);
			base.UpdateRemainTime(0f);
			DataManager<TimeDataManager>.GetInstance().Register(this);
		}

		// Token: 0x17001B95 RID: 7061
		// (get) Token: 0x0600BF52 RID: 48978 RVA: 0x002D0863 File Offset: 0x002CEC63
		public ITimeData Data
		{
			get
			{
				return this._progressTime;
			}
		}

		// Token: 0x0600BF53 RID: 48979 RVA: 0x002D086B File Offset: 0x002CEC6B
		public void Dispose()
		{
			DataManager<TimeDataManager>.GetInstance().Unregister(this);
		}

		// Token: 0x0600BF54 RID: 48980 RVA: 0x002D0878 File Offset: 0x002CEC78
		public int GetDuration()
		{
			return DataManager<TimeDataManager>.GetInstance().CalcDuration(this._progressTime);
		}

		// Token: 0x0600BF55 RID: 48981 RVA: 0x002D088A File Offset: 0x002CEC8A
		public override void Update(float delta)
		{
			base.UpdateRemainTime(delta);
			if (this._remainTime <= 0f)
			{
				DataManager<TimeDataManager>.GetInstance().Unregister(this);
			}
		}

		// Token: 0x04006BF2 RID: 27634
		private ITimeData _progressTime;
	}
}
