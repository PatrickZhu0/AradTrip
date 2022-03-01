using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001516 RID: 5398
	public class ChampionshipScoreRankView : MonoBehaviour
	{
		// Token: 0x0600D1A6 RID: 53670 RVA: 0x0033B6E6 File Offset: 0x00339AE6
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600D1A7 RID: 53671 RVA: 0x0033B6EE File Offset: 0x00339AEE
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600D1A8 RID: 53672 RVA: 0x0033B6FC File Offset: 0x00339AFC
		private void OnEnable()
		{
			this.BindUiMessages();
		}

		// Token: 0x0600D1A9 RID: 53673 RVA: 0x0033B704 File Offset: 0x00339B04
		private void OnDisable()
		{
			this.UnBindUiMessages();
		}

		// Token: 0x0600D1AA RID: 53674 RVA: 0x0033B70C File Offset: 0x00339B0C
		private void BindUiMessages()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipGroupScoreRankResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipGroupRankMessage));
		}

		// Token: 0x0600D1AB RID: 53675 RVA: 0x0033B729 File Offset: 0x00339B29
		private void UnBindUiMessages()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipGroupScoreRankResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipGroupRankMessage));
		}

		// Token: 0x0600D1AC RID: 53676 RVA: 0x0033B748 File Offset: 0x00339B48
		private void BindUiEvents()
		{
			if (this.pointRankItemListEx != null)
			{
				this.pointRankItemListEx.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.pointRankItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnPointRankItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.pointRankItemListEx;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnPointRankItemRecycle));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.refreshButtonWithCd != null)
			{
				this.refreshButtonWithCd.ResetButtonListener();
				this.refreshButtonWithCd.SetButtonListener(new Action(this.OnRefreshButtonClick));
				this.refreshButtonWithCd.SetCountDownTimeDescription(TR.Value("common_refresh_label"), TR.Value("common_refresh_count_time_label"));
			}
		}

		// Token: 0x0600D1AD RID: 53677 RVA: 0x0033B850 File Offset: 0x00339C50
		private void UnBindUiEvents()
		{
			if (this.pointRankItemListEx != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.pointRankItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnPointRankItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.pointRankItemListEx;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnPointRankItemRecycle));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.refreshButtonWithCd != null)
			{
				this.refreshButtonWithCd.ResetButtonListener();
			}
		}

		// Token: 0x0600D1AE RID: 53678 RVA: 0x0033B8F9 File Offset: 0x00339CF9
		private void ClearData()
		{
			this._selfPointRankDataModel = null;
			this._groupPointRankDataModelList = null;
			this._scheduleId = 0;
			this._topWin = 0;
			this._isShowInClientSystemTown = false;
		}

		// Token: 0x0600D1AF RID: 53679 RVA: 0x0033B920 File Offset: 0x00339D20
		public void InitView(int scheduleId, bool isShowInClientSystemTown = false)
		{
			this._scheduleId = scheduleId;
			this._isShowInClientSystemTown = isShowInClientSystemTown;
			this.InitBaseView();
			if (this._isShowInClientSystemTown)
			{
				if (this.refreshButtonWithCd != null)
				{
					this.refreshButtonWithCd.UpdateButtonState(false);
				}
				this.UpdateScoreRankContent();
			}
			else
			{
				DataManager<ChampionshipDataManager>.GetInstance().OnSendSceneChampionGroupRankReq();
			}
		}

		// Token: 0x0600D1B0 RID: 53680 RVA: 0x0033B980 File Offset: 0x00339D80
		private void InitBaseView()
		{
			if (this.pointRankTitleLabel != null)
			{
				this.pointRankTitleLabel.text = TR.Value("Championship_Point_Ranking_Title");
			}
			this._topWin = 4;
			ChampionshipScheduleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChampionshipScheduleTable>(this._scheduleId, string.Empty, string.Empty);
			if (tableItem != null && (tableItem.ScheduleType == ChampionshipScheduleTable.eScheduleType.SixtyFour_Select || tableItem.ScheduleType == ChampionshipScheduleTable.eScheduleType.Sixteen_Select))
			{
				this._topWin = 2;
			}
			if (this.pointRankDescriptionLabel != null)
			{
				this.pointRankDescriptionLabel.text = TR.Value("Championship_Point_Ranking_Description", this._topWin);
			}
		}

		// Token: 0x0600D1B1 RID: 53681 RVA: 0x0033BA2C File Offset: 0x00339E2C
		private void UpdateScoreRankContent()
		{
			this._selfPointRankDataModel = DataManager<ChampionshipDataManager>.GetInstance().SelfScoreRankDataModel;
			this._groupPointRankDataModelList = DataManager<ChampionshipDataManager>.GetInstance().GroupScoreRankDataModelList;
			if (this.ownerPointRankItem != null && this._selfPointRankDataModel != null)
			{
				this.ownerPointRankItem.Init(this._selfPointRankDataModel, false);
			}
			int elementAmount = 0;
			if (this._groupPointRankDataModelList != null)
			{
				elementAmount = this._groupPointRankDataModelList.Count;
			}
			if (this.pointRankItemListEx != null)
			{
				this.pointRankItemListEx.SetElementAmount(elementAmount);
				this.pointRankItemListEx.ResetComUiListScriptEx();
			}
		}

		// Token: 0x0600D1B2 RID: 53682 RVA: 0x0033BAC8 File Offset: 0x00339EC8
		private void OnRefreshButtonClick()
		{
			DataManager<ChampionshipDataManager>.GetInstance().OnSendSceneChampionGroupRankReq();
		}

		// Token: 0x0600D1B3 RID: 53683 RVA: 0x0033BAD4 File Offset: 0x00339ED4
		private void OnPointRankItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.pointRankItemListEx == null)
			{
				return;
			}
			if (this._groupPointRankDataModelList == null || this._groupPointRankDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._groupPointRankDataModelList.Count)
			{
				return;
			}
			ChampionshipScoreRankItem component = item.GetComponent<ChampionshipScoreRankItem>();
			ChampionshipScoreRankDataModel championshipScoreRankDataModel = this._groupPointRankDataModelList[item.m_index];
			if (component != null && championshipScoreRankDataModel != null)
			{
				component.Init(championshipScoreRankDataModel, false);
				component.UpdateSpecialContent(this._topWin);
			}
		}

		// Token: 0x0600D1B4 RID: 53684 RVA: 0x0033BB80 File Offset: 0x00339F80
		private void OnPointRankItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ChampionshipScoreRankItem component = item.GetComponent<ChampionshipScoreRankItem>();
			if (component == null)
			{
				return;
			}
			component.Reset();
		}

		// Token: 0x0600D1B5 RID: 53685 RVA: 0x0033BBB4 File Offset: 0x00339FB4
		private void OnCloseButtonClick()
		{
			ChampionshipUtility.OnCloseChampionshipScoreRankFrame();
		}

		// Token: 0x0600D1B6 RID: 53686 RVA: 0x0033BBBB File Offset: 0x00339FBB
		private void OnReceiveChampionshipGroupRankMessage(UIEvent uiEvent)
		{
			this.UpdateScoreRankContent();
		}

		// Token: 0x04007AAD RID: 31405
		private ChampionshipScoreRankDataModel _selfPointRankDataModel;

		// Token: 0x04007AAE RID: 31406
		private List<ChampionshipScoreRankDataModel> _groupPointRankDataModelList;

		// Token: 0x04007AAF RID: 31407
		private int _scheduleId;

		// Token: 0x04007AB0 RID: 31408
		private int _topWin;

		// Token: 0x04007AB1 RID: 31409
		private bool _isShowInClientSystemTown;

		// Token: 0x04007AB2 RID: 31410
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text pointRankTitleLabel;

		// Token: 0x04007AB3 RID: 31411
		[SerializeField]
		private Text pointRankDescriptionLabel;

		// Token: 0x04007AB4 RID: 31412
		[Space(10f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipScoreRankItem ownerPointRankItem;

		// Token: 0x04007AB5 RID: 31413
		[SerializeField]
		private ComUIListScriptEx pointRankItemListEx;

		// Token: 0x04007AB6 RID: 31414
		[SerializeField]
		private ComButtonWithCd refreshButtonWithCd;

		// Token: 0x04007AB7 RID: 31415
		[Space(10f)]
		[Header("Close")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;
	}
}
