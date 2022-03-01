using System;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014C2 RID: 5314
	public class ChallengeDungeonRewardView : MonoBehaviour
	{
		// Token: 0x0600CE03 RID: 52739 RVA: 0x0032BF13 File Offset: 0x0032A313
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CE04 RID: 52740 RVA: 0x0032BF1B File Offset: 0x0032A31B
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CE05 RID: 52741 RVA: 0x0032BF2C File Offset: 0x0032A32C
		private void BindEvents()
		{
			if (this.okButton != null)
			{
				this.okButton.onClick.RemoveAllListeners();
				this.okButton.onClick.AddListener(new UnityAction(this.OnOkButtonClick));
			}
			if (this.rewardItemList != null)
			{
				this.rewardItemList.Initialize();
				ComUIListScript comUIListScript = this.rewardItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnRewardItemVisible));
				ComUIListScript comUIListScript2 = this.rewardItemList;
				comUIListScript2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnRewardItemRecycle));
			}
		}

		// Token: 0x0600CE06 RID: 52742 RVA: 0x0032BFE0 File Offset: 0x0032A3E0
		private void UnBindEvents()
		{
			if (this.okButton != null)
			{
				this.okButton.onClick.RemoveAllListeners();
			}
			if (this.rewardItemList != null)
			{
				ComUIListScript comUIListScript = this.rewardItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnRewardItemVisible));
				ComUIListScript comUIListScript2 = this.rewardItemList;
				comUIListScript2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScript2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnRewardItemRecycle));
			}
		}

		// Token: 0x0600CE07 RID: 52743 RVA: 0x0032C06D File Offset: 0x0032A46D
		private void ClearData()
		{
			this._rewardDataModel = null;
		}

		// Token: 0x0600CE08 RID: 52744 RVA: 0x0032C076 File Offset: 0x0032A476
		public void InitRewardView(ChallengeDungeonRewardDataModel rewardDataModel)
		{
			this._rewardDataModel = rewardDataModel;
			if (this._rewardDataModel == null)
			{
				Logger.LogErrorFormat("RewardDataModel is null", new object[0]);
				return;
			}
			this.InitContent();
		}

		// Token: 0x0600CE09 RID: 52745 RVA: 0x0032C0A4 File Offset: 0x0032A4A4
		private void InitContent()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = TR.Value("challenge_pass_reward_title");
			}
			if (this.contentLabel != null)
			{
				this.contentLabel.text = string.Format(TR.Value("challenge_pass_number_to_get_reward"), this._rewardDataModel.TotalNumber);
			}
			bool flag = this._rewardDataModel.ChallengeNumber >= this._rewardDataModel.TotalNumber;
			if (this.okButton != null)
			{
				this.okButton.enabled = flag;
			}
			if (this.okButtonGray != null)
			{
				this.okButtonGray.enabled = !flag;
			}
			this.InitRewardItemList();
		}

		// Token: 0x0600CE0A RID: 52746 RVA: 0x0032C174 File Offset: 0x0032A574
		private void InitRewardItemList()
		{
			if (this.rewardItemList == null)
			{
				return;
			}
			int num = 0;
			if (this._rewardDataModel.AwardItemDataList != null)
			{
				num = this._rewardDataModel.AwardItemDataList.Count;
			}
			this.rewardItemList.SetElementAmount(num);
			if (this.rewardItemListRoot != null)
			{
				Vector3 localPosition = this.rewardItemListRoot.gameObject.transform.localPosition;
				if (num <= 1)
				{
					if (this.oneItemPos != null)
					{
						this.rewardItemListRoot.gameObject.transform.localPosition = new Vector3(this.oneItemPos.transform.localPosition.x, localPosition.x, localPosition.y);
					}
				}
				else if (num == 2)
				{
					if (this.twoItemPos != null)
					{
						this.rewardItemListRoot.gameObject.transform.localPosition = new Vector3(this.twoItemPos.transform.localPosition.x, localPosition.x, localPosition.y);
					}
				}
				else if (this.moreItemPos != null)
				{
					this.rewardItemListRoot.gameObject.transform.localPosition = new Vector3(this.moreItemPos.transform.localPosition.x, localPosition.x, localPosition.y);
				}
			}
		}

		// Token: 0x0600CE0B RID: 52747 RVA: 0x0032C2F8 File Offset: 0x0032A6F8
		private void OnOkButtonClick()
		{
			if (this._rewardDataModel == null)
			{
				return;
			}
			Logger.LogErrorFormat("OnOkButtonClick and cur number is {0}, totalNumber is {1}", new object[]
			{
				this._rewardDataModel.ChallengeNumber,
				this._rewardDataModel.TotalNumber
			});
		}

		// Token: 0x0600CE0C RID: 52748 RVA: 0x0032C348 File Offset: 0x0032A748
		private void OnRewardItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._rewardDataModel == null)
			{
				return;
			}
			if (this._rewardDataModel.AwardItemDataList == null || this._rewardDataModel.AwardItemDataList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._rewardDataModel.AwardItemDataList.Count)
			{
				return;
			}
			AwardItemData awardItemData = this._rewardDataModel.AwardItemDataList[item.m_index];
			ChallengeDungeonRewardItem component = item.GetComponent<ChallengeDungeonRewardItem>();
			if (awardItemData != null && component != null)
			{
				component.InitItem(awardItemData);
			}
		}

		// Token: 0x0600CE0D RID: 52749 RVA: 0x0032C3F4 File Offset: 0x0032A7F4
		private void OnRewardItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ChallengeDungeonRewardItem component = item.GetComponent<ChallengeDungeonRewardItem>();
			if (component != null)
			{
				component.OnItemRecycle();
			}
		}

		// Token: 0x04007847 RID: 30791
		private ChallengeDungeonRewardDataModel _rewardDataModel;

		// Token: 0x04007848 RID: 30792
		[Space(20f)]
		[Header("Title")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x04007849 RID: 30793
		[Space(20f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button okButton;

		// Token: 0x0400784A RID: 30794
		[SerializeField]
		private UIGray okButtonGray;

		// Token: 0x0400784B RID: 30795
		[Space(20f)]
		[Header("content")]
		[Space(10f)]
		[SerializeField]
		private Text contentLabel;

		// Token: 0x0400784C RID: 30796
		[SerializeField]
		private ComUIListScript rewardItemList;

		// Token: 0x0400784D RID: 30797
		[SerializeField]
		private GameObject rewardItemListRoot;

		// Token: 0x0400784E RID: 30798
		[SerializeField]
		private GameObject oneItemPos;

		// Token: 0x0400784F RID: 30799
		[SerializeField]
		private GameObject twoItemPos;

		// Token: 0x04007850 RID: 30800
		[SerializeField]
		private GameObject moreItemPos;
	}
}
