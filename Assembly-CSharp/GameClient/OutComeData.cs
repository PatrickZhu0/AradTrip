using System;

namespace GameClient
{
	// Token: 0x02001799 RID: 6041
	[Serializable]
	public struct OutComeData
	{
		// Token: 0x0600EE64 RID: 61028 RVA: 0x003FFE68 File Offset: 0x003FE268
		public void ClearData()
		{
			this.MainTab = MallType.TicketMall;
			this.SubTab = 0;
			this.ThirdTab = 0;
		}

		// Token: 0x040091CA RID: 37322
		public MallType MainTab;

		// Token: 0x040091CB RID: 37323
		public int SubTab;

		// Token: 0x040091CC RID: 37324
		public int ThirdTab;
	}
}
