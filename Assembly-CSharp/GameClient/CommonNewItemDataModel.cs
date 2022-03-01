using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000E03 RID: 3587
	public class CommonNewItemDataModel
	{
		// Token: 0x06008FCE RID: 36814 RVA: 0x001A9448 File Offset: 0x001A7848
		public string GetItemColorName()
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.ItemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return CommonUtility.GetItemColorName(tableItem);
			}
			return string.Empty;
		}

		// Token: 0x04004759 RID: 18265
		public int ItemId;

		// Token: 0x0400475A RID: 18266
		public int ItemCount;

		// Token: 0x0400475B RID: 18267
		public int ItemStrengthenLevel;
	}
}
