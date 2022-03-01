using System;

namespace GameClient
{
	// Token: 0x020019E8 RID: 6632
	public class FriendlyDegreesIntervalNameModel
	{
		// Token: 0x060103D8 RID: 66520 RVA: 0x0048B6D8 File Offset: 0x00489AD8
		public FriendlyDegreesIntervalNameModel(int minLevel, int maxLevel, string name)
		{
			this.minLevel = minLevel;
			this.maxLevel = maxLevel;
			this.name = name;
		}

		// Token: 0x17001D37 RID: 7479
		// (get) Token: 0x060103D9 RID: 66521 RVA: 0x0048B6F5 File Offset: 0x00489AF5
		// (set) Token: 0x060103DA RID: 66522 RVA: 0x0048B6FD File Offset: 0x00489AFD
		public int minLevel { get; set; }

		// Token: 0x17001D38 RID: 7480
		// (get) Token: 0x060103DB RID: 66523 RVA: 0x0048B706 File Offset: 0x00489B06
		// (set) Token: 0x060103DC RID: 66524 RVA: 0x0048B70E File Offset: 0x00489B0E
		public int maxLevel { get; set; }

		// Token: 0x17001D39 RID: 7481
		// (get) Token: 0x060103DD RID: 66525 RVA: 0x0048B717 File Offset: 0x00489B17
		// (set) Token: 0x060103DE RID: 66526 RVA: 0x0048B71F File Offset: 0x00489B1F
		public string name { get; set; }
	}
}
