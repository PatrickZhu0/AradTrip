using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020013A3 RID: 5027
	public class OPPOGrowthHaoLiRewardItem : MonoBehaviour
	{
		// Token: 0x0600C335 RID: 49973 RVA: 0x002E9AC4 File Offset: 0x002E7EC4
		public void OnItemVisiable(AwardItemData awardItemData)
		{
			if (awardItemData == null)
			{
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(awardItemData.ID, 100, 0);
			itemData.Count = awardItemData.Num;
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.mItemRoot);
			}
			ComItem comItem = this.comItem;
			ItemData item = itemData;
			if (OPPOGrowthHaoLiRewardItem.<>f__mg$cache0 == null)
			{
				OPPOGrowthHaoLiRewardItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(item, OPPOGrowthHaoLiRewardItem.<>f__mg$cache0);
		}

		// Token: 0x0600C336 RID: 49974 RVA: 0x002E9B3E File Offset: 0x002E7F3E
		private void OnDestroy()
		{
			this.comItem = null;
		}

		// Token: 0x04006E87 RID: 28295
		[SerializeField]
		private GameObject mItemRoot;

		// Token: 0x04006E88 RID: 28296
		private ComItem comItem;

		// Token: 0x04006E89 RID: 28297
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
