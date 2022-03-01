using System;

namespace GameClient
{
	// Token: 0x020012F9 RID: 4857
	public class StrengthenTicketMaterialMergeModel
	{
		// Token: 0x0600BC52 RID: 48210 RVA: 0x002BE9BA File Offset: 0x002BCDBA
		public StrengthenTicketMaterialMergeModel()
		{
			this.Clear();
		}

		// Token: 0x0600BC53 RID: 48211 RVA: 0x002BE9D3 File Offset: 0x002BCDD3
		public void Clear()
		{
			if (this.needMaterialModel != null)
			{
				this.needMaterialModel.Clear();
			}
		}

		// Token: 0x040069EC RID: 27116
		public int mergeTableId;

		// Token: 0x040069ED RID: 27117
		public string name;

		// Token: 0x040069EE RID: 27118
		public int strengthenLevel;

		// Token: 0x040069EF RID: 27119
		public bool isBind;

		// Token: 0x040069F0 RID: 27120
		public int increaseLevel;

		// Token: 0x040069F1 RID: 27121
		public int previewMinPercent;

		// Token: 0x040069F2 RID: 27122
		public int previewMaxPercent;

		// Token: 0x040069F3 RID: 27123
		public int displayItemTableId;

		// Token: 0x040069F4 RID: 27124
		public bool bDisplay;

		// Token: 0x040069F5 RID: 27125
		public StrengthenTicketMergeMaterial needMaterialModel = new StrengthenTicketMergeMaterial();
	}
}
