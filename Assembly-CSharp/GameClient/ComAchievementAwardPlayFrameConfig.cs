using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020013CE RID: 5070
	public class ComAchievementAwardPlayFrameConfig : MonoBehaviour
	{
		// Token: 0x0600C4A9 RID: 50345 RVA: 0x002F3B70 File Offset: 0x002F1F70
		public void SetAwards(int iId)
		{
			AchievementLevelInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AchievementLevelInfoTable>(iId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.AwardID.Count != tableItem.AwardCount.Count)
			{
				return;
			}
			int count = tableItem.AwardID.Count;
			if (this.comItems.Count == 0)
			{
				for (int i = 0; i < this.goParents.Length; i++)
				{
					this.comItems.Add(ComItemManager.Create(this.goParents[i]));
				}
			}
			for (int j = 0; j < this.goParents.Length; j++)
			{
				this.goParents[j].CustomActive(false);
				if (this.comItems != null && j < this.comItems.Count && j < count)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableItem.AwardID[j], 100, 0);
					if (itemData != null)
					{
						itemData.Count = tableItem.AwardCount[j];
					}
					if (null != this.comItems[j])
					{
						this.comItems[j].Setup(itemData, null);
					}
					if (j < this.comEffectProcess.Length)
					{
						this.comEffectProcess[j].Play();
					}
				}
			}
		}

		// Token: 0x0600C4AA RID: 50346 RVA: 0x002F3CC4 File Offset: 0x002F20C4
		public void DestroyComItems()
		{
			for (int i = 0; i < this.comItems.Count; i++)
			{
				if (null != this.comItems[i])
				{
					ComItemManager.Destroy(this.comItems[i]);
				}
			}
			this.comItems.Clear();
		}

		// Token: 0x0600C4AB RID: 50347 RVA: 0x002F3D20 File Offset: 0x002F2120
		private void OnDestroy()
		{
			this.DestroyComItems();
		}

		// Token: 0x04006FFE RID: 28670
		public GameObject[] goParents = new GameObject[0];

		// Token: 0x04006FFF RID: 28671
		private List<ComItem> comItems = new List<ComItem>(4);

		// Token: 0x04007000 RID: 28672
		public ComEffectPrcess[] comEffectProcess = new ComEffectPrcess[0];
	}
}
