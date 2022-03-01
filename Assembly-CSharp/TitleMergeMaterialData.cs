using System;
using GameClient;
using ProtoTable;

// Token: 0x020045D8 RID: 17880
internal class TitleMergeMaterialData
{
	// Token: 0x06019217 RID: 102935 RVA: 0x007EF9EC File Offset: 0x007EDDEC
	public string getColorName()
	{
		ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.id, string.Empty, string.Empty);
		if (tableItem != null)
		{
			ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo(tableItem.Color, tableItem.Color2 == 1, false);
			if (qualityInfo != null)
			{
				return string.Format("<color={0}>{1}</color>", qualityInfo.ColStr, tableItem.Name);
			}
		}
		return string.Empty;
	}

	// Token: 0x06019218 RID: 102936 RVA: 0x007EFA54 File Offset: 0x007EDE54
	public string getDescString()
	{
		int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.id, true);
		bool flag = ownedItemCount >= this.count;
		if (flag)
		{
			return string.Format(TitleMergeMaterialData.ms_enough_desc, ownedItemCount, this.count);
		}
		return string.Format(TitleMergeMaterialData.ms_not_enough_desc, ownedItemCount, this.count);
	}

	// Token: 0x170020AC RID: 8364
	// (get) Token: 0x06019219 RID: 102937 RVA: 0x007EFABD File Offset: 0x007EDEBD
	public bool hasOwned
	{
		get
		{
			return true;
		}
	}

	// Token: 0x0401202E RID: 73774
	public int id;

	// Token: 0x0401202F RID: 73775
	public int count;

	// Token: 0x04012030 RID: 73776
	private static string ms_enough_desc = "<color=#00ff00>{0}</color>/{1}";

	// Token: 0x04012031 RID: 73777
	private static string ms_not_enough_desc = "<color=#ff0000>{0}</color>/{1}";
}
