using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014E3 RID: 5347
	public class ChampionshipBigRewardControl : MonoBehaviour
	{
		// Token: 0x0600CF7B RID: 53115 RVA: 0x00333519 File Offset: 0x00331919
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CF7C RID: 53116 RVA: 0x00333521 File Offset: 0x00331921
		private void OnDestroy()
		{
			this.UnBindEvents();
			this._scheduleId = 0;
			this._splitDataModelList = null;
		}

		// Token: 0x0600CF7D RID: 53117 RVA: 0x00333538 File Offset: 0x00331938
		private void BindEvents()
		{
			if (this.bigRewardItemList != null)
			{
				this.bigRewardItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.bigRewardItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnRewardItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.bigRewardItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnRewardItemRecycle));
			}
			if (this.bigRewardPreviewButton != null)
			{
				this.bigRewardPreviewButton.onClick.RemoveAllListeners();
				this.bigRewardPreviewButton.onClick.AddListener(new UnityAction(this.OnBigRewardPreviewButtonClick));
			}
		}

		// Token: 0x0600CF7E RID: 53118 RVA: 0x003335EC File Offset: 0x003319EC
		private void UnBindEvents()
		{
			if (this.bigRewardItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.bigRewardItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnRewardItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.bigRewardItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnRewardItemRecycle));
			}
			if (this.bigRewardPreviewButton != null)
			{
				this.bigRewardPreviewButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CF7F RID: 53119 RVA: 0x00333679 File Offset: 0x00331A79
		public void InitControl()
		{
			this.UpdateBigRewardItemList();
		}

		// Token: 0x0600CF80 RID: 53120 RVA: 0x00333681 File Offset: 0x00331A81
		public void SetScheduleId(int scheduleId)
		{
			this._scheduleId = scheduleId;
		}

		// Token: 0x0600CF81 RID: 53121 RVA: 0x0033368C File Offset: 0x00331A8C
		private void UpdateBigRewardItemList()
		{
			if (this.bigRewardItemList == null)
			{
				return;
			}
			this._splitDataModelList = ChampionshipUtility.GetSplitDataModelList(10);
			int elementAmount = 0;
			if (this._splitDataModelList != null)
			{
				elementAmount = this._splitDataModelList.Count;
			}
			this.bigRewardItemList.ResetComUiListScriptEx();
			this.bigRewardItemList.SetElementAmount(elementAmount);
		}

		// Token: 0x0600CF82 RID: 53122 RVA: 0x003336E8 File Offset: 0x00331AE8
		private void OnRewardItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._splitDataModelList == null || this._splitDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._splitDataModelList.Count)
			{
				return;
			}
			if (this.bigRewardItemList == null)
			{
				return;
			}
			CommonSplitDataModel commonSplitDataModel = this._splitDataModelList[item.m_index];
			ChampionshipBigRewardPreviewItem component = item.GetComponent<ChampionshipBigRewardPreviewItem>();
			if (component != null && commonSplitDataModel != null)
			{
				component.InitRewardItem(commonSplitDataModel.FirstNumber, commonSplitDataModel.SecondNumber);
			}
		}

		// Token: 0x0600CF83 RID: 53123 RVA: 0x00333794 File Offset: 0x00331B94
		private void OnRewardItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ChampionshipBigRewardPreviewItem component = item.GetComponent<ChampionshipBigRewardPreviewItem>();
			if (component != null)
			{
				component.OnRecycleItem();
			}
		}

		// Token: 0x0600CF84 RID: 53124 RVA: 0x003337C7 File Offset: 0x00331BC7
		private void OnBigRewardPreviewButtonClick()
		{
			ChampionshipUtility.OnOpenChampionshipBigRewardPreviewFrame(this._scheduleId);
		}

		// Token: 0x0400795C RID: 31068
		private int _scheduleId;

		// Token: 0x0400795D RID: 31069
		private List<CommonSplitDataModel> _splitDataModelList;

		// Token: 0x0400795E RID: 31070
		private const int BigRewardPreviewTableId = 10;

		// Token: 0x0400795F RID: 31071
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button bigRewardPreviewButton;

		// Token: 0x04007960 RID: 31072
		[Space(10f)]
		[Header("rewardItemList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx bigRewardItemList;
	}
}
