using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001ACB RID: 6859
	public class BeadPickModel
	{
		// Token: 0x06010D7A RID: 68986 RVA: 0x004CD630 File Offset: 0x004CBA30
		public BeadPickModel(PrecBead mPrecBead, ItemData mEquipItemData)
		{
			this.mPrecBead = mPrecBead;
			this.mEquipItemData = mEquipItemData;
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(this.mPrecBead.preciousBeadId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("[BeadPickFrame]  BeadPickModel 构造函数中beadItemDate.TableID为空", new object[0]);
			}
			this.mBeadPickItemList = DataManager<BeadCardManager>.GetInstance().GetBeadExpendItemModel(tableItem.Color, tableItem.Level, tableItem.BeadType);
		}

		// Token: 0x0400ACB6 RID: 44214
		public PrecBead mPrecBead;

		// Token: 0x0400ACB7 RID: 44215
		public ItemData mEquipItemData;

		// Token: 0x0400ACB8 RID: 44216
		public List<BeadPickItemModel> mBeadPickItemList;
	}
}
