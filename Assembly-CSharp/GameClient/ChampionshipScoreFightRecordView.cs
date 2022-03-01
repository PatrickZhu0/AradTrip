using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001513 RID: 5395
	public class ChampionshipScoreFightRecordView : MonoBehaviour
	{
		// Token: 0x0600D185 RID: 53637 RVA: 0x0033AF78 File Offset: 0x00339378
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600D186 RID: 53638 RVA: 0x0033AF80 File Offset: 0x00339380
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600D187 RID: 53639 RVA: 0x0033AF8E File Offset: 0x0033938E
		private void OnEnable()
		{
			this.BindUiMessages();
		}

		// Token: 0x0600D188 RID: 53640 RVA: 0x0033AF96 File Offset: 0x00339396
		private void OnDisable()
		{
			this.UnBindUiMessages();
		}

		// Token: 0x0600D189 RID: 53641 RVA: 0x0033AF9E File Offset: 0x0033939E
		private void BindUiMessages()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipScoreFightRecordMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipScoreFightRecordMessage));
		}

		// Token: 0x0600D18A RID: 53642 RVA: 0x0033AFBB File Offset: 0x003393BB
		private void UnBindUiMessages()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipScoreFightRecordMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipScoreFightRecordMessage));
		}

		// Token: 0x0600D18B RID: 53643 RVA: 0x0033AFD8 File Offset: 0x003393D8
		private void BindUiEvents()
		{
			if (this.fightRecordItemListEx != null)
			{
				this.fightRecordItemListEx.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.fightRecordItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnFightRecordItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.fightRecordItemListEx;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnFightRecordItemRecycle));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.selfRelationButton != null)
			{
				this.selfRelationButton.onClick.RemoveAllListeners();
				this.selfRelationButton.onClick.AddListener(new UnityAction(this.OnSelfRelationButtonClick));
			}
		}

		// Token: 0x0600D18C RID: 53644 RVA: 0x0033B0CC File Offset: 0x003394CC
		private void UnBindUiEvents()
		{
			if (this.fightRecordItemListEx != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.fightRecordItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnFightRecordItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.fightRecordItemListEx;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnFightRecordItemRecycle));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.selfRelationButton != null)
			{
				this.selfRelationButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600D18D RID: 53645 RVA: 0x0033B17A File Offset: 0x0033957A
		private void ClearData()
		{
			this._scoreFightRecordDataModelList = null;
			this._isSelfFightRecord = false;
		}

		// Token: 0x0600D18E RID: 53646 RVA: 0x0033B18A File Offset: 0x0033958A
		public void InitView()
		{
			DataManager<ChampionshipDataManager>.GetInstance().OnSendSceneChampionScoreFightRecordReq();
			this.InitBaseView();
			this.UpdateSelfButtonFlag();
		}

		// Token: 0x0600D18F RID: 53647 RVA: 0x0033B1A4 File Offset: 0x003395A4
		private void InitBaseView()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = TR.Value("Championship_Fight_Record_Title_Text");
			}
			if (this.descriptionLabel != null)
			{
				this.descriptionLabel.text = TR.Value("Championship_Fight_Record_Description_Text");
			}
		}

		// Token: 0x0600D190 RID: 53648 RVA: 0x0033B1FD File Offset: 0x003395FD
		private void UpdateSelfButtonFlag()
		{
			CommonUtility.UpdateGameObjectVisible(this.selfRelationFlag, this._isSelfFightRecord);
		}

		// Token: 0x0600D191 RID: 53649 RVA: 0x0033B210 File Offset: 0x00339610
		private void UpdateFightRecordItemList()
		{
			if (this.fightRecordItemListEx == null)
			{
				return;
			}
			if (this._isSelfFightRecord)
			{
				this._scoreFightRecordDataModelList = ChampionshipUtility.GetChampionshipSelfScoreFightRecordList();
			}
			else
			{
				this._scoreFightRecordDataModelList = ChampionshipUtility.GetChampionshipAllScoreFightRecordList();
			}
			int elementAmount = 0;
			if (this._scoreFightRecordDataModelList != null)
			{
				elementAmount = this._scoreFightRecordDataModelList.Count;
			}
			this.fightRecordItemListEx.ResetComUiListScriptEx();
			this.fightRecordItemListEx.SetElementAmount(elementAmount);
		}

		// Token: 0x0600D192 RID: 53650 RVA: 0x0033B285 File Offset: 0x00339685
		private void OnSelfRelationButtonClick()
		{
			this._isSelfFightRecord = !this._isSelfFightRecord;
			this.UpdateSelfButtonFlag();
			this.UpdateFightRecordItemList();
		}

		// Token: 0x0600D193 RID: 53651 RVA: 0x0033B2A4 File Offset: 0x003396A4
		private void OnFightRecordItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._scoreFightRecordDataModelList == null || this._scoreFightRecordDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._scoreFightRecordDataModelList.Count)
			{
				return;
			}
			ChampionshipScoreFightRecordDataModel championshipScoreFightRecordDataModel = this._scoreFightRecordDataModelList[item.m_index];
			ChampionshipScoreFightRecordItem component = item.GetComponent<ChampionshipScoreFightRecordItem>();
			if (component != null && championshipScoreFightRecordDataModel != null)
			{
				component.Init(championshipScoreFightRecordDataModel);
			}
		}

		// Token: 0x0600D194 RID: 53652 RVA: 0x0033B330 File Offset: 0x00339730
		private void OnFightRecordItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ChampionshipScoreFightRecordItem component = item.GetComponent<ChampionshipScoreFightRecordItem>();
			if (component != null)
			{
				component.RecycleItem();
			}
		}

		// Token: 0x0600D195 RID: 53653 RVA: 0x0033B363 File Offset: 0x00339763
		private void OnCloseButtonClick()
		{
			ChampionshipUtility.OnCloseChampionshipScoreFightRecordFrame();
		}

		// Token: 0x0600D196 RID: 53654 RVA: 0x0033B36A File Offset: 0x0033976A
		private void OnReceiveChampionshipScoreFightRecordMessage(UIEvent uiEvent)
		{
			this.UpdateFightRecordItemList();
		}

		// Token: 0x04007A9D RID: 31389
		private bool _isSelfFightRecord;

		// Token: 0x04007A9E RID: 31390
		private List<ChampionshipScoreFightRecordDataModel> _scoreFightRecordDataModelList;

		// Token: 0x04007A9F RID: 31391
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x04007AA0 RID: 31392
		[SerializeField]
		private Text descriptionLabel;

		// Token: 0x04007AA1 RID: 31393
		[Space(10f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx fightRecordItemListEx;

		// Token: 0x04007AA2 RID: 31394
		[Space(10f)]
		[Header("SelfButton")]
		[Space(10f)]
		[SerializeField]
		private Button selfRelationButton;

		// Token: 0x04007AA3 RID: 31395
		[SerializeField]
		private GameObject selfRelationFlag;

		// Token: 0x04007AA4 RID: 31396
		[Space(10f)]
		[Header("Close")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;
	}
}
