using System;

namespace GameClient
{
	// Token: 0x020016C9 RID: 5833
	public class MapIndex : Attribute
	{
		// Token: 0x0600E459 RID: 58457 RVA: 0x003B1653 File Offset: 0x003AFA53
		public MapIndex(int index)
		{
			this.Index = index;
		}

		// Token: 0x040089D9 RID: 35289
		public int Index;
	}
}
