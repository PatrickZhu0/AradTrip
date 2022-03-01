using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200150D RID: 5389
	public class ChampionshipMainScheduleScoreView : MonoBehaviour
	{
		// Token: 0x0600D14B RID: 53579 RVA: 0x0033A4B8 File Offset: 0x003388B8
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600D14C RID: 53580 RVA: 0x0033A4C0 File Offset: 0x003388C0
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600D14D RID: 53581 RVA: 0x0033A4D0 File Offset: 0x003388D0
		private void BindUiEvents()
		{
			if (this.scoreItemListEx != null)
			{
				this.scoreItemListEx.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.scoreItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnScoreRankItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.scoreItemListEx;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnScoreRankItemRecycle));
			}
			if (this.scoreRankButton != null)
			{
				this.scoreRankButton.onClick.RemoveAllListeners();
				this.scoreRankButton.onClick.AddListener(new UnityAction(this.OnScoreRankButtonClick));
			}
			if (this.scoreFightRecordButton != null)
			{
				this.scoreFightRecordButton.onClick.RemoveAllListeners();
				this.scoreFightRecordButton.onClick.AddListener(new UnityAction(this.OnScoreFightRecordButtonClick));
			}
		}

		// Token: 0x0600D14E RID: 53582 RVA: 0x0033A5C4 File Offset: 0x003389C4
		private void UnBindUiEvents()
		{
			if (this.scoreItemListEx != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.scoreItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnScoreRankItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.scoreItemListEx;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnScoreRankItemRecycle));
			}
			if (this.scoreRankButton != null)
			{
				this.scoreRankButton.onClick.RemoveAllListeners();
			}
			if (this.scoreFightRecordButton != null)
			{
				this.scoreFightRecordButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600D14F RID: 53583 RVA: 0x0033A672 File Offset: 0x00338A72
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipGroupIdSyncMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipGroupIdSyncMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipTopScoreRankSyncMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipTopScoreRankSyncMessage));
		}

		// Token: 0x0600D150 RID: 53584 RVA: 0x0033A6AA File Offset: 0x00338AAA
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipGroupIdSyncMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipGroupIdSyncMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipTopScoreRankSyncMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipTopScoreRankSyncMessage));
		}

		// Token: 0x0600D151 RID: 53585 RVA: 0x0033A6E2 File Offset: 0x00338AE2
		private void ClearData()
		{
			this._scheduleTable = null;
			this._topScoreRankDataModelList = null;
		}

		// Token: 0x0600D152 RID: 53586 RVA: 0x0033A6F2 File Offset: 0x00338AF2
		public void InitView(ChampionshipScheduleTable scheduleTable)
		{
			this._scheduleTable = scheduleTable;
			if (this._scheduleTable == null)
			{
				return;
			}
			this.InitBaseContent();
			this.UpdateTopScoreRankItemList();
		}

		// Token: 0x0600D153 RID: 53587 RVA: 0x0033A713 File Offset: 0x00338B13
		private void InitBaseContent()
		{
			if (this.helpNewAssistant != null)
			{
				this.helpNewAssistant.HelpId = this._scheduleTable.CommonHelpId;
			}
			this.UpdateTitleLabel();
		}

		// Token: 0x0600D154 RID: 53588 RVA: 0x0033A744 File Offset: 0x00338B44
		private void UpdateTitleLabel()
		{
			if (this.titleLabel != null)
			{
				int championshipScoreFightGroupId = DataManager<ChampionshipDataManager>.GetInstance().ChampionshipScoreFightGroupId;
				string str = string.Empty;
				if (championshipScoreFightGroupId > 0)
				{
					str = TR.Value("Championship_Fight_Group_Format", championshipScoreFightGroupId);
				}
				this.titleLabel.text = this._scheduleTable.ScheduleName + str;
			}
		}

		// Token: 0x0600D155 RID: 53589 RVA: 0x0033A7A8 File Offset: 0x00338BA8
		private void UpdateTopScoreRankItemList()
		{
			this._topScoreRankDataModelList = DataManager<ChampionshipDataManager>.GetInstance().TopScoreRankDataModelList;
			int elementAmount = 0;
			if (this._topScoreRankDataModelList != null && this._topScoreRankDataModelList.Count > 0)
			{
				elementAmount = this._topScoreRankDataModelList.Count;
			}
			if (this.scoreItemListEx != null)
			{
				this.scoreItemListEx.SetElementAmount(elementAmount);
			}
		}

		// Token: 0x0600D156 RID: 53590 RVA: 0x0033A80C File Offset: 0x00338C0C
		private void OnScoreRankItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._topScoreRankDataModelList == null || this._topScoreRankDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._topScoreRankDataModelList.Count)
			{
				return;
			}
			ChampionshipScoreRankDataModel championshipScoreRankDataModel = this._topScoreRankDataModelList[item.m_index];
			ChampionshipScoreRankItem component = item.GetComponent<ChampionshipScoreRankItem>();
			if (component != null && championshipScoreRankDataModel != null)
			{
				component.Init(championshipScoreRankDataModel, true);
			}
		}

		// Token: 0x0600D157 RID: 53591 RVA: 0x0033A89C File Offset: 0x00338C9C
		private void OnScoreRankItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ChampionshipScoreRankItem component = item.GetComponent<ChampionshipScoreRankItem>();
			if (component != null)
			{
				component.Reset();
			}
		}

		// Token: 0x0600D158 RID: 53592 RVA: 0x0033A8CF File Offset: 0x00338CCF
		private void OnScoreRankButtonClick()
		{
			if (this._scheduleTable == null)
			{
				return;
			}
			ChampionshipUtility.OnOpenChampionshipScoreRankFrame(this._scheduleTable.ID, false);
		}

		// Token: 0x0600D159 RID: 53593 RVA: 0x0033A8EE File Offset: 0x00338CEE
		private void OnScoreFightRecordButtonClick()
		{
			ChampionshipUtility.OnOpenChampionshipScoreFightRecordFrame();
		}

		// Token: 0x0600D15A RID: 53594 RVA: 0x0033A8F5 File Offset: 0x00338CF5
		private void OnReceiveChampionshipTopScoreRankSyncMessage(UIEvent uiEvent)
		{
			this.UpdateTopScoreRankItemList();
		}

		// Token: 0x0600D15B RID: 53595 RVA: 0x0033A8FD File Offset: 0x00338CFD
		private void OnReceiveChampionshipGroupIdSyncMessage(UIEvent uiEvent)
		{
			this.UpdateTitleLabel();
		}

		// Token: 0x04007A87 RID: 31367
		private ChampionshipScheduleTable _scheduleTable;

		// Token: 0x04007A88 RID: 31368
		private List<ChampionshipScoreRankDataModel> _topScoreRankDataModelList;

		// Token: 0x04007A89 RID: 31369
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x04007A8A RID: 31370
		[SerializeField]
		private CommonHelpNewAssistant helpNewAssistant;

		// Token: 0x04007A8B RID: 31371
		[Space(10f)]
		[Header("ScoreItem")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx scoreItemListEx;

		// Token: 0x04007A8C RID: 31372
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button scoreRankButton;

		// Token: 0x04007A8D RID: 31373
		[SerializeField]
		private Button scoreFightRecordButton;
	}
}
