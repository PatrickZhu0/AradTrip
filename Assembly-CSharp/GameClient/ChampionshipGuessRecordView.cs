using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014F5 RID: 5365
	public class ChampionshipGuessRecordView : MonoBehaviour
	{
		// Token: 0x0600D042 RID: 53314 RVA: 0x0033684C File Offset: 0x00334C4C
		private void Awake()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.guessRecordItemList != null)
			{
				this.guessRecordItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.guessRecordItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.guessRecordItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
		}

		// Token: 0x0600D043 RID: 53315 RVA: 0x00336900 File Offset: 0x00334D00
		private void OnDestroy()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.guessRecordItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.guessRecordItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.guessRecordItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
			this.ClearData();
		}

		// Token: 0x0600D044 RID: 53316 RVA: 0x00336993 File Offset: 0x00334D93
		private void ClearData()
		{
			this._selectedTabId = 0;
			this._unOpenRecordDataModelList = null;
			this._bingGoRecordDataModelList = null;
			this._showGuessRecordDataModelList = null;
		}

		// Token: 0x0600D045 RID: 53317 RVA: 0x003369B1 File Offset: 0x00334DB1
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipGuessRecordMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionGuessRecordMessage));
		}

		// Token: 0x0600D046 RID: 53318 RVA: 0x003369CE File Offset: 0x00334DCE
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipGuessRecordMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionGuessRecordMessage));
		}

		// Token: 0x0600D047 RID: 53319 RVA: 0x003369EB File Offset: 0x00334DEB
		public void InitView()
		{
			DataManager<ChampionshipDataManager>.GetInstance().OnSendSceneChampionGuessRecordReq();
			this.InitContent();
		}

		// Token: 0x0600D048 RID: 53320 RVA: 0x00336A00 File Offset: 0x00334E00
		private void InitContent()
		{
			if (this.betRecordTitleLabel != null)
			{
				this.betRecordTitleLabel.text = TR.Value("Championship_Guess_Record_Title");
			}
			this._selectedTabId = 1;
			List<ComControlData> comControlDataInGuessRecord = ChampionshipUtility.GetComControlDataInGuessRecord();
			if (this.toggleControl != null)
			{
				this.toggleControl.InitComToggleControl(comControlDataInGuessRecord, new OnComToggleClick(this.OnComToggleClick));
			}
			this.UpdateGuessRecordContent();
		}

		// Token: 0x0600D049 RID: 53321 RVA: 0x00336A6F File Offset: 0x00334E6F
		private void OnComToggleClick(ComControlData comControlData)
		{
			if (comControlData == null)
			{
				return;
			}
			if (comControlData.Id == this._selectedTabId)
			{
				return;
			}
			this._selectedTabId = comControlData.Id;
			this.UpdateGuessRecordContent();
		}

		// Token: 0x0600D04A RID: 53322 RVA: 0x00336A9C File Offset: 0x00334E9C
		private void UpdateGuessRecordContent()
		{
			ChampionshipGuessRecordTabType selectedTabId = (ChampionshipGuessRecordTabType)this._selectedTabId;
			if (selectedTabId == ChampionshipGuessRecordTabType.NotOpenRecord)
			{
				if (this._unOpenRecordDataModelList == null)
				{
					this._unOpenRecordDataModelList = ChampionshipUtility.GetGuessRecordDataModelListByGuessResultType(ChampionshipGuessResultType.UnOpen);
				}
				this._showGuessRecordDataModelList = this._unOpenRecordDataModelList;
			}
			else if (selectedTabId == ChampionshipGuessRecordTabType.BingGoRecord)
			{
				if (this._bingGoRecordDataModelList == null)
				{
					this._bingGoRecordDataModelList = ChampionshipUtility.GetGuessRecordDataModelListByGuessResultType(ChampionshipGuessResultType.BingGo);
				}
				this._showGuessRecordDataModelList = this._bingGoRecordDataModelList;
			}
			else
			{
				this._showGuessRecordDataModelList = DataManager<ChampionshipDataManager>.GetInstance().GuessRecordDataModelList;
			}
			int elementAmount = 0;
			if (this._showGuessRecordDataModelList != null)
			{
				elementAmount = this._showGuessRecordDataModelList.Count;
			}
			if (this.guessRecordItemList != null)
			{
				this.guessRecordItemList.ResetComUiListScriptEx();
				this.guessRecordItemList.SetElementAmount(elementAmount);
			}
		}

		// Token: 0x0600D04B RID: 53323 RVA: 0x00336B5F File Offset: 0x00334F5F
		private void OnReceiveChampionGuessRecordMessage(UIEvent uiEvent)
		{
			this.UpdateGuessRecordContent();
		}

		// Token: 0x0600D04C RID: 53324 RVA: 0x00336B68 File Offset: 0x00334F68
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.guessRecordItemList == null)
			{
				return;
			}
			if (this._showGuessRecordDataModelList == null || this._showGuessRecordDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._showGuessRecordDataModelList.Count)
			{
				return;
			}
			ChampionshipGuessRecordItem component = item.GetComponent<ChampionshipGuessRecordItem>();
			ChampionshipGuessRecordDataModel championshipGuessRecordDataModel = this._showGuessRecordDataModelList[item.m_index];
			if (component != null && championshipGuessRecordDataModel != null)
			{
				if (!championshipGuessRecordDataModel.IsAlreadyUpdate)
				{
					ChampionshipUtility.UpdateGuessRecordDataModel(championshipGuessRecordDataModel);
				}
				component.InitItem(championshipGuessRecordDataModel);
			}
		}

		// Token: 0x0600D04D RID: 53325 RVA: 0x00336C18 File Offset: 0x00335018
		private void OnItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ChampionshipGuessRecordItem component = item.GetComponent<ChampionshipGuessRecordItem>();
			if (component != null)
			{
				component.RecycleItem();
			}
		}

		// Token: 0x0600D04E RID: 53326 RVA: 0x00336C4B File Offset: 0x0033504B
		private void OnCloseButtonClick()
		{
			ChampionshipUtility.OnCloseChampionshipGuessRecordFrame();
		}

		// Token: 0x040079E7 RID: 31207
		private int _selectedTabId = 1;

		// Token: 0x040079E8 RID: 31208
		private List<ChampionshipGuessRecordDataModel> _unOpenRecordDataModelList;

		// Token: 0x040079E9 RID: 31209
		private List<ChampionshipGuessRecordDataModel> _bingGoRecordDataModelList;

		// Token: 0x040079EA RID: 31210
		private List<ChampionshipGuessRecordDataModel> _showGuessRecordDataModelList;

		// Token: 0x040079EB RID: 31211
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text betRecordTitleLabel;

		// Token: 0x040079EC RID: 31212
		[SerializeField]
		private Button closeButton;

		// Token: 0x040079ED RID: 31213
		[Space(10f)]
		[Header("Tab")]
		[Space(10f)]
		[SerializeField]
		private ComToggleControl toggleControl;

		// Token: 0x040079EE RID: 31214
		[Space(10f)]
		[Header("ItemList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx guessRecordItemList;
	}
}
