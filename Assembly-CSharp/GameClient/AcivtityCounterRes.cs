using System;

namespace GameClient
{
	// Token: 0x020011A8 RID: 4520
	public class AcivtityCounterRes
	{
		// Token: 0x0600AD5E RID: 44382 RVA: 0x0025B5E8 File Offset: 0x002599E8
		public AcivtityCounterRes(uint counterID, uint counterValue)
		{
			this.CounterId = counterID;
			this.CounterValue = counterValue;
		}

		// Token: 0x04006114 RID: 24852
		public uint CounterId;

		// Token: 0x04006115 RID: 24853
		public uint CounterValue;
	}
}
