using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001443 RID: 5187
	public class AttackCityMonsterRewardItem : MonoBehaviour
	{
		// Token: 0x0600C942 RID: 51522 RVA: 0x0030EFEA File Offset: 0x0030D3EA
		public void InitData(RewardItemDataModel rewardItem)
		{
			this._rewardItem = rewardItem;
			this.InitRewardItemContent();
		}

		// Token: 0x0600C943 RID: 51523 RVA: 0x0030EFFC File Offset: 0x0030D3FC
		private void InitRewardItemContent()
		{
			if (this.rewardItemRoot == null)
			{
				return;
			}
			int id = this._rewardItem.Id;
			int number = this._rewardItem.Number;
			if (this._comRewardItem == null)
			{
				this._comRewardItem = ComItemManager.Create(this.rewardItemRoot.gameObject);
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(id, 100, 0);
			if (itemData != null)
			{
				this._comRewardItem.CustomActive(true);
				itemData.Count = number;
				this._comRewardItem.Setup(itemData, new ComItem.OnItemClicked(this.ShowItemTip));
			}
		}

		// Token: 0x0600C944 RID: 51524 RVA: 0x0030F095 File Offset: 0x0030D495
		private void ShowItemTip(GameObject go, ItemData itemData)
		{
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x04007424 RID: 29732
		[SerializeField]
		private GameObject rewardItemRoot;

		// Token: 0x04007425 RID: 29733
		private RewardItemDataModel _rewardItem;

		// Token: 0x04007426 RID: 29734
		private ComItem _comRewardItem;
	}
}
