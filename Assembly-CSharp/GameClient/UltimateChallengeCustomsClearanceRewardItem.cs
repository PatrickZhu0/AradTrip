using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013B4 RID: 5044
	public class UltimateChallengeCustomsClearanceRewardItem : MonoBehaviour
	{
		// Token: 0x0600C3BF RID: 50111 RVA: 0x002EE707 File Offset: 0x002ECB07
		private void Awake()
		{
			if (this.boxBtn != null)
			{
				this.boxBtn.onClick.RemoveAllListeners();
				this.boxBtn.onClick.AddListener(new UnityAction(this.OnBoxBtnClick));
			}
		}

		// Token: 0x0600C3C0 RID: 50112 RVA: 0x002EE746 File Offset: 0x002ECB46
		private void OnDestroy()
		{
			if (this.boxBtn != null)
			{
				this.boxBtn.onClick.RemoveListener(new UnityAction(this.OnBoxBtnClick));
			}
			this.ultimateChallengeCustomsClearanceRewardItemData = null;
		}

		// Token: 0x0600C3C1 RID: 50113 RVA: 0x002EE77C File Offset: 0x002ECB7C
		private void OnBoxBtnClick()
		{
			if (this.ultimateChallengeCustomsClearanceRewardItemData == null)
			{
				return;
			}
			if (this.ultimateChallengeCustomsClearanceRewardItemData.rewardItems != null && this.ultimateChallengeCustomsClearanceRewardItemData.rewardItems.Count > 0)
			{
				CommonSplitDataModel commonSplitDataModel = this.ultimateChallengeCustomsClearanceRewardItemData.rewardItems[0];
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(commonSplitDataModel.FirstNumber, 100, 0);
				itemData.Count = commonSplitDataModel.SecondNumber;
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x0600C3C2 RID: 50114 RVA: 0x002EE7F8 File Offset: 0x002ECBF8
		public void OnItemVisiable(UltimateChallengeCustomsClearanceRewardItemData ultimateChallengeCustomsClearanceRewardItemData)
		{
			if (ultimateChallengeCustomsClearanceRewardItemData == null)
			{
				return;
			}
			this.ultimateChallengeCustomsClearanceRewardItemData = ultimateChallengeCustomsClearanceRewardItemData;
			if (ultimateChallengeCustomsClearanceRewardItemData.minDays == ultimateChallengeCustomsClearanceRewardItemData.maxDays)
			{
				if (this.title != null)
				{
					this.title.text = string.Format(this.titleDesc2, ultimateChallengeCustomsClearanceRewardItemData.minDays);
				}
			}
			else if (this.title != null)
			{
				this.title.text = string.Format(this.titleDesc, ultimateChallengeCustomsClearanceRewardItemData.minDays, ultimateChallengeCustomsClearanceRewardItemData.maxDays);
			}
			if (this.boxIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.boxIcon, ultimateChallengeCustomsClearanceRewardItemData.iconPath, true);
			}
		}

		// Token: 0x04006F43 RID: 28483
		[SerializeField]
		private Text title;

		// Token: 0x04006F44 RID: 28484
		[SerializeField]
		private GameObject itemParent;

		// Token: 0x04006F45 RID: 28485
		[SerializeField]
		private Image boxIcon;

		// Token: 0x04006F46 RID: 28486
		[SerializeField]
		private Button boxBtn;

		// Token: 0x04006F47 RID: 28487
		[SerializeField]
		private string titleDesc = "{0}~{1}天可领";

		// Token: 0x04006F48 RID: 28488
		[SerializeField]
		private string titleDesc2 = "{0}天可领";

		// Token: 0x04006F49 RID: 28489
		private UltimateChallengeCustomsClearanceRewardItemData ultimateChallengeCustomsClearanceRewardItemData;
	}
}
