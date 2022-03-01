using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017A8 RID: 6056
	internal class TalkAwardFrame : ClientFrame
	{
		// Token: 0x0600EED1 RID: 61137 RVA: 0x00401EBE File Offset: 0x004002BE
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Mission/TalkAwardFrame";
		}

		// Token: 0x0600EED2 RID: 61138 RVA: 0x00401EC8 File Offset: 0x004002C8
		protected override void _OnOpenFrame()
		{
			string s = this.userData as string;
			int num = 0;
			if (!int.TryParse(s, out num))
			{
				return;
			}
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.Name.text = tableItem.TaskName;
			List<AwardItemData> missionAwards = DataManager<MissionManager>.GetInstance().GetMissionAwards(num, -1);
			for (int i = 0; i < missionAwards.Count; i++)
			{
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(missionAwards[i].ID);
				if (commonItemTableDataByID != null)
				{
					commonItemTableDataByID.Count = missionAwards[i].Num;
					commonItemTableDataByID.StrengthenLevel = missionAwards[i].StrengthenLevel;
					commonItemTableDataByID.EquipType = (EEquipType)missionAwards[i].EquipType;
					ComItem comItem = base.CreateComItem(this.goParent);
					if (comItem != null)
					{
						comItem.Setup(commonItemTableDataByID, delegate(GameObject obj, ItemData item)
						{
							if (item != null)
							{
								DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
							}
						});
					}
				}
			}
		}

		// Token: 0x0600EED3 RID: 61139 RVA: 0x00401FE4 File Offset: 0x004003E4
		protected override void _OnCloseFrame()
		{
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x0400922F RID: 37423
		[UIControl("TaskName", typeof(Text), 0)]
		private Text Name;

		// Token: 0x04009230 RID: 37424
		[UIObject("ItemParent")]
		private GameObject goParent;
	}
}
