using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020016B0 RID: 5808
	public class EquipSuitObj
	{
		// Token: 0x0600E3D8 RID: 58328 RVA: 0x003ADAE4 File Offset: 0x003ABEE4
		public bool IsSuitEquipActive(ItemData suitEquip)
		{
			if (suitEquip == null)
			{
				return false;
			}
			if (this.wearedEquipIDs.Contains(suitEquip.TableID))
			{
				return true;
			}
			if (suitEquip.Type == ItemTable.eType.FASHION)
			{
				for (int i = 0; i < this.wearedEquipIDs.Count; i++)
				{
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.wearedEquipIDs[i]);
					if (commonItemTableDataByID.Type == ItemTable.eType.FASHION && commonItemTableDataByID.FashionWearSlotType == suitEquip.FashionWearSlotType)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600E3D9 RID: 58329 RVA: 0x003ADB70 File Offset: 0x003ABF70
		public bool IsEquipActive(ItemData a_equip)
		{
			if (this.wearedEquipIDs.Contains(a_equip.TableID))
			{
				return true;
			}
			for (int i = 0; i < this.wearedEquipIDs.Count; i++)
			{
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.wearedEquipIDs[i]);
				if (commonItemTableDataByID.IsWearSoltEqual(a_equip))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x040088CF RID: 35023
		public List<int> wearedEquipIDs;

		// Token: 0x040088D0 RID: 35024
		public EquipSuitRes equipSuitRes;
	}
}
