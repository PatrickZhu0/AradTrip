using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001954 RID: 6484
	public class PayReturnSpeacialItem
	{
		// Token: 0x0600FC0C RID: 64524 RVA: 0x00452C6C File Offset: 0x0045106C
		public void Clear()
		{
			this.payReturnActivityId = -1;
			if (this.resPaths != null)
			{
				for (int i = 0; i < this.resPaths.Count; i++)
				{
					this.resPaths[i].Clear();
				}
				this.resPaths.Clear();
			}
			this.bSplit = false;
		}

		// Token: 0x04009DCC RID: 40396
		public int payReturnActivityId;

		// Token: 0x04009DCD RID: 40397
		public List<PayReturnSpeacialItem.ResPath> resPaths = new List<PayReturnSpeacialItem.ResPath>();

		// Token: 0x04009DCE RID: 40398
		public bool bSplit;

		// Token: 0x02001955 RID: 6485
		public class ResPath
		{
			// Token: 0x0600FC0E RID: 64526 RVA: 0x00452CD2 File Offset: 0x004510D2
			public void Clear()
			{
				this.iconPath = string.Empty;
				this.modelPath = string.Empty;
				this.awardItemId = -1;
			}

			// Token: 0x04009DCF RID: 40399
			public string iconPath;

			// Token: 0x04009DD0 RID: 40400
			public string modelPath;

			// Token: 0x04009DD1 RID: 40401
			public int awardItemId;
		}
	}
}
