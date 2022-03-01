using System;

namespace GameClient
{
	// Token: 0x020012CE RID: 4814
	public class RandomTreasureUIEvent : UIEvent
	{
		// Token: 0x0600BA78 RID: 47736 RVA: 0x002B1241 File Offset: 0x002AF641
		public RandomTreasureUIEvent(int timeStamp)
		{
			this.excuteTimeStmp = timeStamp;
		}

		// Token: 0x040068CC RID: 26828
		public int excuteTimeStmp;
	}
}
