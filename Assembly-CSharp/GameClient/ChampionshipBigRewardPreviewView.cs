using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014E6 RID: 5350
	public class ChampionshipBigRewardPreviewView : MonoBehaviour
	{
		// Token: 0x0600CF93 RID: 53139 RVA: 0x00333936 File Offset: 0x00331D36
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CF94 RID: 53140 RVA: 0x0033393E File Offset: 0x00331D3E
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CF95 RID: 53141 RVA: 0x0033394C File Offset: 0x00331D4C
		private void ClearData()
		{
			this._bigRewardScheduleId = 0;
			this._splitDataModelList = null;
			this._comControlDataList = null;
		}

		// Token: 0x0600CF96 RID: 53142 RVA: 0x00333964 File Offset: 0x00331D64
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
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
		}

		// Token: 0x0600CF97 RID: 53143 RVA: 0x00333A18 File Offset: 0x00331E18
		private void UnBindEvents()
		{
			if (this.bigRewardItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.bigRewardItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnRewardItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.bigRewardItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnRewardItemRecycle));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CF98 RID: 53144 RVA: 0x00333AA5 File Offset: 0x00331EA5
		public void Init(int scheduleId)
		{
			this._bigRewardScheduleId = scheduleId;
			if (this._bigRewardScheduleId == 0)
			{
				this._bigRewardScheduleId = 1;
			}
			this._comControlDataList = ChampionshipUtility.GetComControlDataInBigRewardPreviewTable();
			this.UpdateComControlData();
			this.InitView();
		}

		// Token: 0x0600CF99 RID: 53145 RVA: 0x00333AD8 File Offset: 0x00331ED8
		private void UpdateComControlData()
		{
			bool flag = false;
			for (int i = 0; i < this._comControlDataList.Count; i++)
			{
				ComControlData comControlData = this._comControlDataList[i];
				if (comControlData != null)
				{
					if (comControlData.Id == this._bigRewardScheduleId && !flag)
					{
						flag = true;
						comControlData.IsSelected = true;
					}
				}
			}
			if (!flag && this._comControlDataList.Count > 0)
			{
				ComControlData comControlData2 = this._comControlDataList[0];
				if (comControlData2 != null)
				{
					comControlData2.IsSelected = true;
					this._bigRewardScheduleId = comControlData2.Id;
				}
			}
		}

		// Token: 0x0600CF9A RID: 53146 RVA: 0x00333B78 File Offset: 0x00331F78
		private void InitView()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = TR.Value("Championship_Big_Reward_Preview_Title");
			}
			this.UpdateBigRewardItemList();
			if (this.comToggleControl != null)
			{
				this.comToggleControl.InitComToggleControl(this._comControlDataList, new OnComToggleClick(this.OnTabClickAction));
				this.comToggleControl.UpdateComTogglePosition();
			}
		}

		// Token: 0x0600CF9B RID: 53147 RVA: 0x00333BEA File Offset: 0x00331FEA
		private void OnTabClickAction(ComControlData comControlData)
		{
			if (comControlData == null)
			{
				return;
			}
			if (comControlData.Id == this._bigRewardScheduleId)
			{
				return;
			}
			this._bigRewardScheduleId = comControlData.Id;
			this.UpdateBigRewardItemList();
		}

		// Token: 0x0600CF9C RID: 53148 RVA: 0x00333C18 File Offset: 0x00332018
		private void UpdateBigRewardItemList()
		{
			this._splitDataModelList = ChampionshipUtility.GetSplitDataModelList(this._bigRewardScheduleId);
			int elementAmount = 0;
			if (this._splitDataModelList != null)
			{
				elementAmount = this._splitDataModelList.Count;
			}
			if (this.bigRewardItemList != null)
			{
				this.bigRewardItemList.ResetComUiListScriptEx();
				this.bigRewardItemList.SetElementAmount(elementAmount);
			}
		}

		// Token: 0x0600CF9D RID: 53149 RVA: 0x00333C78 File Offset: 0x00332078
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

		// Token: 0x0600CF9E RID: 53150 RVA: 0x00333D24 File Offset: 0x00332124
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

		// Token: 0x0600CF9F RID: 53151 RVA: 0x00333D57 File Offset: 0x00332157
		private void OnCloseButtonClick()
		{
			ChampionshipUtility.OnCloseChampionshipBigRewardPreviewFrame();
		}

		// Token: 0x04007966 RID: 31078
		private int _bigRewardScheduleId;

		// Token: 0x04007967 RID: 31079
		private List<ComControlData> _comControlDataList;

		// Token: 0x04007968 RID: 31080
		private List<CommonSplitDataModel> _splitDataModelList;

		// Token: 0x04007969 RID: 31081
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x0400796A RID: 31082
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400796B RID: 31083
		[Space(10f)]
		[Header("ComToggleControl")]
		[Space(10f)]
		[SerializeField]
		private ComToggleControl comToggleControl;

		// Token: 0x0400796C RID: 31084
		[Space(10f)]
		[Header("rewardItemList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx bigRewardItemList;
	}
}
