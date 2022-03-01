using System;

namespace GameClient
{
	// Token: 0x02000F32 RID: 3890
	public class ComControlDataEx
	{
		// Token: 0x060097A0 RID: 38816 RVA: 0x001D0BD5 File Offset: 0x001CEFD5
		public ComControlDataEx()
		{
		}

		// Token: 0x060097A1 RID: 38817 RVA: 0x001D0BDD File Offset: 0x001CEFDD
		public ComControlDataEx(int index, int id, string name, bool isSelected, bool isToggleDisabled)
		{
			this.Index = index;
			this.Id = id;
			this.Name = name;
			this.IsSelected = isSelected;
			this.IsToggleDisabled = isToggleDisabled;
		}

		// Token: 0x04004E37 RID: 20023
		public int Index;

		// Token: 0x04004E38 RID: 20024
		public int Id;

		// Token: 0x04004E39 RID: 20025
		public string Name;

		// Token: 0x04004E3A RID: 20026
		public bool IsSelected;

		// Token: 0x04004E3B RID: 20027
		public bool IsToggleDisabled;
	}
}
