using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;

// Token: 0x020045D9 RID: 17881
internal class TitleMergeData
{
	// Token: 0x0601921C RID: 102940 RVA: 0x007EFAF4 File Offset: 0x007EDEF4
	public int getMoneyId()
	{
		if (this.moneyItem == null)
		{
			this.getMoneyIcon();
		}
		if (this.moneyItem != null)
		{
			return this.moneyItem.ID;
		}
		return 0;
	}

	// Token: 0x0601921D RID: 102941 RVA: 0x007EFB20 File Offset: 0x007EDF20
	public string getMoneyIcon()
	{
		if (this.forgeItem != null)
		{
			if (this.moneyItem == null && this.forgeItem.Price.Count > 0)
			{
				string[] array = this.forgeItem.Price[0].Split(new char[]
				{
					'_'
				});
				if (array != null && array.Length == 2)
				{
					int id = 0;
					int num = 0;
					if (int.TryParse(array[0], out id) && int.TryParse(array[1], out num))
					{
						this.moneyItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
						this.moneyCount = num;
					}
				}
			}
			if (this.moneyItem != null)
			{
				return this.moneyItem.Icon;
			}
		}
		return string.Empty;
	}

	// Token: 0x0601921E RID: 102942 RVA: 0x007EFBEA File Offset: 0x007EDFEA
	public int getMoneyCount()
	{
		if (this.moneyItem == null)
		{
			this.getMoneyIcon();
		}
		return this.moneyCount;
	}

	// Token: 0x0601921F RID: 102943 RVA: 0x007EFC04 File Offset: 0x007EE004
	public int getOwnedMoneyCount()
	{
		return DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.getMoneyId(), true);
	}

	// Token: 0x04012032 RID: 73778
	public EquipForgeTable forgeItem;

	// Token: 0x04012033 RID: 73779
	public ItemTable item;

	// Token: 0x04012034 RID: 73780
	public List<TitleMergeMaterialData> materials = new List<TitleMergeMaterialData>();

	// Token: 0x04012035 RID: 73781
	public List<TitleMergeMaterialData> moneys = new List<TitleMergeMaterialData>();

	// Token: 0x04012036 RID: 73782
	private ItemTable moneyItem;

	// Token: 0x04012037 RID: 73783
	private int moneyCount;
}
