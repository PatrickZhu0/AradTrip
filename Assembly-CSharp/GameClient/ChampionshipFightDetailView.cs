using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014E9 RID: 5353
	public class ChampionshipFightDetailView : MonoBehaviour
	{
		// Token: 0x0600CFB4 RID: 53172 RVA: 0x0033436D File Offset: 0x0033276D
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600CFB5 RID: 53173 RVA: 0x00334375 File Offset: 0x00332775
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600CFB6 RID: 53174 RVA: 0x00334384 File Offset: 0x00332784
		private void BindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.fightDetailItemList != null)
			{
				this.fightDetailItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.fightDetailItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnFightDetailItemVisible));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipFightRaceSyncGroupMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightRaceSyncGroupMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipFightDetailRecordResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightDetailRecordResMessage));
		}

		// Token: 0x0600CFB7 RID: 53175 RVA: 0x00334448 File Offset: 0x00332848
		private void UnBindUiEvents()
		{
			if (this.fightDetailItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.fightDetailItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnFightDetailItemVisible));
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipFightRaceSyncGroupMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightRaceSyncGroupMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipFightDetailRecordResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightDetailRecordResMessage));
		}

		// Token: 0x0600CFB8 RID: 53176 RVA: 0x003344C3 File Offset: 0x003328C3
		private void ClearData()
		{
			this._fightRaceDataModel = null;
			this._fightDetailRecordDataModelList = null;
			this._firstPlayerGuid = 0UL;
			this._secondPlayerGuid = 0UL;
			this._fightGroupId = 0;
		}

		// Token: 0x0600CFB9 RID: 53177 RVA: 0x003344EC File Offset: 0x003328EC
		public void Init(int fightGroupId)
		{
			this._fightGroupId = fightGroupId;
			if (this._fightGroupId <= 0)
			{
				return;
			}
			this._fightRaceDataModel = ChampionshipUtility.GetFightRaceDataModelByFightRaceId(this._fightGroupId);
			if (this._fightRaceDataModel == null)
			{
				return;
			}
			this.InitFightGroupView();
			if (this._fightRaceDataModel.FightStatus == ChampionshipFightStatus.NotStart)
			{
				DataManager<ChampionshipDataManager>.GetInstance().ResetChampionshipFightDetailRecordDataModelList();
				this.UpdateFightDetailItemList();
			}
			else
			{
				DataManager<ChampionshipDataManager>.GetInstance().OnSendSceneChampionFightDetailRecordReq(this._fightGroupId);
			}
		}

		// Token: 0x0600CFBA RID: 53178 RVA: 0x00334568 File Offset: 0x00332968
		private void InitFightGroupView()
		{
			string text = TR.Value("Championship_Fight_Against_Watching");
			if (this.titleLabel != null)
			{
				this.titleLabel.text = text;
			}
			this._firstPlayerGuid = this._fightRaceDataModel.FirstPlayerGuid;
			this._secondPlayerGuid = this._fightRaceDataModel.SecondPlayerGuid;
			ChampionshipTopPlayerDataModel topPlayerDataModelByPlayerGuid = ChampionshipUtility.GetTopPlayerDataModelByPlayerGuid(this._firstPlayerGuid);
			ChampionshipTopPlayerDataModel topPlayerDataModelByPlayerGuid2 = ChampionshipUtility.GetTopPlayerDataModelByPlayerGuid(this._secondPlayerGuid);
			if (this.firstPlayerItem != null)
			{
				if (topPlayerDataModelByPlayerGuid == null)
				{
					CommonUtility.UpdateGameObjectVisible(this.firstPlayerItem.gameObject, false);
				}
				else
				{
					CommonUtility.UpdateGameObjectVisible(this.secondPlayerItem.gameObject, true);
					this.firstPlayerItem.Init(topPlayerDataModelByPlayerGuid);
				}
			}
			if (this.secondPlayerItem != null)
			{
				if (topPlayerDataModelByPlayerGuid2 == null)
				{
					CommonUtility.UpdateGameObjectVisible(this.secondPlayerItem.gameObject, false);
				}
				else
				{
					CommonUtility.UpdateGameObjectVisible(this.secondPlayerItem.gameObject, true);
					this.secondPlayerItem.Init(topPlayerDataModelByPlayerGuid2);
				}
			}
			this.UpdateFightGroupView();
		}

		// Token: 0x0600CFBB RID: 53179 RVA: 0x00334671 File Offset: 0x00332A71
		private void UpdateFightGroupView()
		{
			if (this.fightRaceStatusControl == null)
			{
				return;
			}
			this.fightRaceStatusControl.Init(this._fightRaceDataModel);
		}

		// Token: 0x0600CFBC RID: 53180 RVA: 0x00334698 File Offset: 0x00332A98
		private void UpdateFightDetailItemList()
		{
			if (this.fightDetailItemList == null)
			{
				return;
			}
			this._fightDetailRecordDataModelList = DataManager<ChampionshipDataManager>.GetInstance().FightDetailRecordDataModelList;
			int elementAmount = 0;
			if (this._fightDetailRecordDataModelList != null)
			{
				elementAmount = this._fightDetailRecordDataModelList.Count;
			}
			this.fightDetailItemList.SetElementAmount(elementAmount);
		}

		// Token: 0x0600CFBD RID: 53181 RVA: 0x003346EC File Offset: 0x00332AEC
		private void OnReceiveChampionshipFightRaceSyncGroupMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			if (num != this._fightGroupId)
			{
				return;
			}
			if (this._fightRaceDataModel == null)
			{
				return;
			}
			this.UpdateFightGroupView();
			DataManager<ChampionshipDataManager>.GetInstance().OnSendSceneChampionFightDetailRecordReq(this._fightGroupId);
		}

		// Token: 0x0600CFBE RID: 53182 RVA: 0x00334746 File Offset: 0x00332B46
		private void OnReceiveChampionshipFightDetailRecordResMessage(UIEvent uiEvent)
		{
			this.UpdateFightDetailItemList();
		}

		// Token: 0x0600CFBF RID: 53183 RVA: 0x00334750 File Offset: 0x00332B50
		private void OnFightDetailItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._fightDetailRecordDataModelList == null || this._fightDetailRecordDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._fightDetailRecordDataModelList.Count)
			{
				return;
			}
			ChampionshipFightStatus raceFightStatus = ChampionshipFightStatus.None;
			if (this._fightRaceDataModel != null)
			{
				raceFightStatus = this._fightRaceDataModel.FightStatus;
			}
			ChampionshipFightDetailItem component = item.GetComponent<ChampionshipFightDetailItem>();
			ChampionshipFightDetailRecordDataModel fightDetailRecordDataModel = this._fightDetailRecordDataModelList[item.m_index];
			if (component != null)
			{
				component.Init(this._fightGroupId, fightDetailRecordDataModel, this._firstPlayerGuid, this._secondPlayerGuid, raceFightStatus);
			}
		}

		// Token: 0x0600CFC0 RID: 53184 RVA: 0x00334802 File Offset: 0x00332C02
		private void OnCloseButtonClick()
		{
			ChampionshipUtility.OnCloseChampionshipFightDetailFrame();
		}

		// Token: 0x04007984 RID: 31108
		private int _fightGroupId;

		// Token: 0x04007985 RID: 31109
		private ChampionshipFightRaceDataModel _fightRaceDataModel;

		// Token: 0x04007986 RID: 31110
		private ulong _firstPlayerGuid;

		// Token: 0x04007987 RID: 31111
		private ulong _secondPlayerGuid;

		// Token: 0x04007988 RID: 31112
		private List<ChampionshipFightDetailRecordDataModel> _fightDetailRecordDataModelList;

		// Token: 0x04007989 RID: 31113
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x0400798A RID: 31114
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400798B RID: 31115
		[Space(10f)]
		[Header("Status")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipPlayerItem firstPlayerItem;

		// Token: 0x0400798C RID: 31116
		[SerializeField]
		private ChampionshipPlayerItem secondPlayerItem;

		// Token: 0x0400798D RID: 31117
		[Space(10f)]
		[Header("Status")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipFightRaceStatusControl fightRaceStatusControl;

		// Token: 0x0400798E RID: 31118
		[Space(10f)]
		[Header("DetailItemList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx fightDetailItemList;
	}
}
