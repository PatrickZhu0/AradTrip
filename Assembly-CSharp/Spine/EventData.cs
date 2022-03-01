using System;

namespace Spine
{
	// Token: 0x020049BF RID: 18879
	public class EventData
	{
		// Token: 0x0601B297 RID: 111255 RVA: 0x00858F1C File Offset: 0x0085731C
		public EventData(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "name cannot be null.");
			}
			this.name = name;
		}

		// Token: 0x1700237F RID: 9087
		// (get) Token: 0x0601B298 RID: 111256 RVA: 0x00858F41 File Offset: 0x00857341
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x17002380 RID: 9088
		// (get) Token: 0x0601B299 RID: 111257 RVA: 0x00858F49 File Offset: 0x00857349
		// (set) Token: 0x0601B29A RID: 111258 RVA: 0x00858F51 File Offset: 0x00857351
		public int Int { get; set; }

		// Token: 0x17002381 RID: 9089
		// (get) Token: 0x0601B29B RID: 111259 RVA: 0x00858F5A File Offset: 0x0085735A
		// (set) Token: 0x0601B29C RID: 111260 RVA: 0x00858F62 File Offset: 0x00857362
		public float Float { get; set; }

		// Token: 0x17002382 RID: 9090
		// (get) Token: 0x0601B29D RID: 111261 RVA: 0x00858F6B File Offset: 0x0085736B
		// (set) Token: 0x0601B29E RID: 111262 RVA: 0x00858F73 File Offset: 0x00857373
		public string String { get; set; }

		// Token: 0x0601B29F RID: 111263 RVA: 0x00858F7C File Offset: 0x0085737C
		public override string ToString()
		{
			return this.Name;
		}

		// Token: 0x04012F20 RID: 77600
		internal string name;
	}
}
