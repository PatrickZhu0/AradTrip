using System;

namespace GameClient
{
	// Token: 0x02001353 RID: 4947
	public class DailyChargeCounter
	{
		// Token: 0x0600BFC7 RID: 49095 RVA: 0x002D2792 File Offset: 0x002D0B92
		public DailyChargeCounter(uint activityId, uint counterId, uint counterValue)
		{
			this.dailyChargeActivityId = activityId;
			this.activityCounter = new AcivtityCounterRes(counterId, counterValue);
		}

		// Token: 0x04006C3A RID: 27706
		public uint dailyChargeActivityId;

		// Token: 0x04006C3B RID: 27707
		public AcivtityCounterRes activityCounter;
	}
}
