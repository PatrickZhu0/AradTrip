using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x0200474D RID: 18253
	[Serializable]
	public class StatusGroup
	{
		// Token: 0x0601A38C RID: 107404 RVA: 0x00825310 File Offset: 0x00823710
		public void DoStatus()
		{
			int num = 0;
			while (this.m_akPostions != null && num < this.m_akPostions.Count)
			{
				this.m_akPostions[num].DoStatus();
				num++;
			}
			int num2 = 0;
			while (this.m_akVisibles != null && num2 < this.m_akVisibles.Count)
			{
				this.m_akVisibles[num2].DoStatus();
				num2++;
			}
		}

		// Token: 0x040126B8 RID: 75448
		public int iTag;

		// Token: 0x040126B9 RID: 75449
		public List<PositionStatus> m_akPostions;

		// Token: 0x040126BA RID: 75450
		public List<VisibleStatus> m_akVisibles;
	}
}
