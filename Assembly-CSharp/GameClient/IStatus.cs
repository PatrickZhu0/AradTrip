using System;

namespace GameClient
{
	// Token: 0x02004749 RID: 18249
	public class IStatus
	{
		// Token: 0x17002258 RID: 8792
		// (get) Token: 0x0601A385 RID: 107397 RVA: 0x00825293 File Offset: 0x00823693
		public IStatus.IStatusFuntion StatusFuntion
		{
			get
			{
				return this.m_eIStatusFuntion;
			}
		}

		// Token: 0x0601A386 RID: 107398 RVA: 0x0082529B File Offset: 0x0082369B
		public virtual void DoStatus()
		{
		}

		// Token: 0x040126AF RID: 75439
		protected IStatus.IStatusFuntion m_eIStatusFuntion = IStatus.IStatusFuntion.ISF_INVALID;

		// Token: 0x0200474A RID: 18250
		public enum IStatusFuntion
		{
			// Token: 0x040126B1 RID: 75441
			ISF_INVALID = -1,
			// Token: 0x040126B2 RID: 75442
			ISF_POSITION,
			// Token: 0x040126B3 RID: 75443
			ISF_VISIBLE
		}
	}
}
