using System;

namespace GameClient
{
	// Token: 0x02000EA6 RID: 3750
	public class ComControlData
	{
		// Token: 0x0600941B RID: 37915 RVA: 0x001BC093 File Offset: 0x001BA493
		public ComControlData()
		{
		}

		// Token: 0x0600941C RID: 37916 RVA: 0x001BC09B File Offset: 0x001BA49B
		public ComControlData(int index, int id, string name, bool isSelected)
		{
			this.Index = index;
			this.Id = id;
			this.Name = name;
			this.IsSelected = isSelected;
		}

		// Token: 0x04004AF9 RID: 19193
		public int Index;

		// Token: 0x04004AFA RID: 19194
		public int Id;

		// Token: 0x04004AFB RID: 19195
		public string Name;

		// Token: 0x04004AFC RID: 19196
		public bool IsSelected;
	}
}
