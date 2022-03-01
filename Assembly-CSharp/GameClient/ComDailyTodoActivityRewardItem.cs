using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020015A0 RID: 5536
	public class ComDailyTodoActivityRewardItem : MonoBehaviour
	{
		// Token: 0x0600D88E RID: 55438 RVA: 0x003630CC File Offset: 0x003614CC
		private void OnDestroy()
		{
			this.itemData = null;
			this.UnInit();
		}

		// Token: 0x0600D88F RID: 55439 RVA: 0x003630DC File Offset: 0x003614DC
		public void Init(int rewardItemId)
		{
			this.rewardItem = ComItemManager.Create(base.gameObject);
			this.itemData = ItemDataManager.CreateItemDataFromTable(rewardItemId, 100, 0);
			if (this.rewardItemNeedClick)
			{
				ComItem comItem = this.rewardItem;
				ItemData item = this.itemData;
				if (ComDailyTodoActivityRewardItem.<>f__mg$cache0 == null)
				{
					ComDailyTodoActivityRewardItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(item, ComDailyTodoActivityRewardItem.<>f__mg$cache0);
			}
			else
			{
				this.rewardItem.Setup(this.itemData, null);
			}
		}

		// Token: 0x0600D890 RID: 55440 RVA: 0x00363159 File Offset: 0x00361559
		public void UnInit()
		{
			if (this.rewardItem != null)
			{
				ComItemManager.Destroy(this.rewardItem);
				this.rewardItem = null;
			}
		}

		// Token: 0x04007F28 RID: 32552
		public bool rewardItemNeedClick = true;

		// Token: 0x04007F29 RID: 32553
		private ComItem rewardItem;

		// Token: 0x04007F2A RID: 32554
		private ItemData itemData;

		// Token: 0x04007F2B RID: 32555
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
