using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001872 RID: 6258
	public class ArborDayRewardItem : MonoBehaviour
	{
		// Token: 0x0600F52A RID: 62762 RVA: 0x00422248 File Offset: 0x00420648
		private void Awake()
		{
			if (this.rewardItemButton != null)
			{
				this.rewardItemButton.onClick.RemoveAllListeners();
				this.rewardItemButton.onClick.AddListener(new UnityAction(this.OnRewardItemButtonClicked));
			}
			if (this.rewardPreviewButton != null)
			{
				this.rewardPreviewButton.onClick.RemoveAllListeners();
				this.rewardPreviewButton.onClick.AddListener(new UnityAction(this.OnRewardPreviewButtonClicked));
			}
		}

		// Token: 0x0600F52B RID: 62763 RVA: 0x004222D0 File Offset: 0x004206D0
		private void OnDestroy()
		{
			if (this.rewardItemButton != null)
			{
				this.rewardItemButton.onClick.RemoveAllListeners();
			}
			if (this.rewardPreviewButton != null)
			{
				this.rewardPreviewButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600F52C RID: 62764 RVA: 0x0042231F File Offset: 0x0042071F
		private void ClearData()
		{
			this._rewardItemId = 0;
			this._rewardItemTable = null;
			this._activityTaskDataModel = null;
			this._rewardProgressItemIdList.Clear();
			this._rewardProgressItemStrList.Clear();
			this._activityId = 0U;
			this._activityTaskId = 0U;
		}

		// Token: 0x0600F52D RID: 62765 RVA: 0x0042235C File Offset: 0x0042075C
		public void InitItem(ILimitTimeActivityTaskDataModel taskDataModel, uint activityId = 0U)
		{
			this._activityTaskDataModel = taskDataModel;
			this._activityId = activityId;
			if (this._activityTaskDataModel == null)
			{
				return;
			}
			this._activityTaskId = this._activityTaskDataModel.DataId;
			this._rewardItemId = ArborDayUtility.GetRewardItemId(this._activityTaskDataModel);
			this._rewardItemTable = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._rewardItemId, string.Empty, string.Empty);
			if (this._rewardItemTable == null)
			{
				return;
			}
			this.InitView();
		}

		// Token: 0x0600F52E RID: 62766 RVA: 0x004223D7 File Offset: 0x004207D7
		public void UpdateItem(ILimitTimeActivityTaskDataModel taskDataModel)
		{
			this._activityTaskDataModel = taskDataModel;
			this.UpdateRewardState();
		}

		// Token: 0x0600F52F RID: 62767 RVA: 0x004223E6 File Offset: 0x004207E6
		private void InitView()
		{
			this.InitItemBaseView();
			this.UpdateRewardState();
		}

		// Token: 0x0600F530 RID: 62768 RVA: 0x004223F4 File Offset: 0x004207F4
		private void InitItemBaseView()
		{
			if (this.rewardItemNameText != null)
			{
				this.rewardItemNameText.text = CommonUtility.GetItemColorName(this._rewardItemTable);
			}
			if (this.rewardItemRoot != null)
			{
				CommonNewItem commonNewItem = this.rewardItemRoot.GetComponentInChildren<CommonNewItem>();
				if (commonNewItem == null)
				{
					commonNewItem = CommonUtility.CreateCommonNewItem(this.rewardItemRoot);
				}
				if (commonNewItem != null)
				{
					commonNewItem.InitItem(this._rewardItemId, 1);
				}
			}
		}

		// Token: 0x0600F531 RID: 62769 RVA: 0x00422478 File Offset: 0x00420878
		private void UpdateRewardState()
		{
			if (this._activityTaskDataModel == null)
			{
				return;
			}
			OpActTaskState state = this._activityTaskDataModel.State;
			string text = TR.Value("Arbor_Day_Reward_Can_Receive");
			if (state == OpActTaskState.OATS_OVER)
			{
				text = TR.Value("Arbor_Day_Reward_Already_Receive");
				CommonUtility.UpdateButtonVisible(this.rewardItemButton, true);
				CommonUtility.UpdateButtonState(this.rewardItemButton, this.rewardItemButtonGray, false);
				CommonUtility.UpdateButtonVisible(this.rewardPreviewButton, false);
			}
			else if (state == OpActTaskState.OATS_FINISHED)
			{
				CommonUtility.UpdateButtonVisible(this.rewardItemButton, true);
				CommonUtility.UpdateButtonState(this.rewardItemButton, this.rewardItemButtonGray, true);
				CommonUtility.UpdateButtonVisible(this.rewardPreviewButton, false);
			}
			else
			{
				CommonUtility.UpdateButtonVisible(this.rewardItemButton, false);
				CommonUtility.UpdateButtonVisible(this.rewardPreviewButton, true);
			}
			if (this.rewardItemButtonText != null)
			{
				this.rewardItemButtonText.text = text;
			}
		}

		// Token: 0x0600F532 RID: 62770 RVA: 0x00422554 File Offset: 0x00420954
		private void OnRewardItemButtonClicked()
		{
			DataManager<ActivityDataManager>.GetInstance().RequestOnTakeActTask(this._activityId, this._activityTaskId, 0UL);
		}

		// Token: 0x0600F533 RID: 62771 RVA: 0x0042256E File Offset: 0x0042096E
		private void OnRewardPreviewButtonClicked()
		{
			if (this._rewardItemId <= 0)
			{
				return;
			}
			ArborDayUtility.OnOpenRewardReviewFrame(this._rewardItemId, 0);
		}

		// Token: 0x04009657 RID: 38487
		private ILimitTimeActivityTaskDataModel _activityTaskDataModel;

		// Token: 0x04009658 RID: 38488
		private uint _activityId;

		// Token: 0x04009659 RID: 38489
		private uint _activityTaskId;

		// Token: 0x0400965A RID: 38490
		private int _rewardItemId;

		// Token: 0x0400965B RID: 38491
		private ItemTable _rewardItemTable;

		// Token: 0x0400965C RID: 38492
		private List<uint> _rewardProgressItemIdList = new List<uint>();

		// Token: 0x0400965D RID: 38493
		private List<string> _rewardProgressItemStrList = new List<string>();

		// Token: 0x0400965E RID: 38494
		[Space(10f)]
		[Header("TreeRoot")]
		[Space(10f)]
		[SerializeField]
		private Text rewardItemNameText;

		// Token: 0x0400965F RID: 38495
		[SerializeField]
		private GameObject rewardItemRoot;

		// Token: 0x04009660 RID: 38496
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Text rewardItemButtonText;

		// Token: 0x04009661 RID: 38497
		[SerializeField]
		private Button rewardItemButton;

		// Token: 0x04009662 RID: 38498
		[SerializeField]
		private UIGray rewardItemButtonGray;

		// Token: 0x04009663 RID: 38499
		[SerializeField]
		private Button rewardPreviewButton;
	}
}
