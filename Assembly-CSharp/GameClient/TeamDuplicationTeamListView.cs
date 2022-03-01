using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C30 RID: 7216
	public class TeamDuplicationTeamListView : MonoBehaviour
	{
		// Token: 0x06011B3F RID: 72511 RVA: 0x0052F9C5 File Offset: 0x0052DDC5
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011B40 RID: 72512 RVA: 0x0052F9CD File Offset: 0x0052DDCD
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011B41 RID: 72513 RVA: 0x0052F9DB File Offset: 0x0052DDDB
		private void ClearData()
		{
			this._teamListDataModelList = null;
			this._curPageNumber = 1;
			this._totalPageNumber = 1;
			this._teamTypeDataList = null;
			this._teamDuplicationTeamModelType = 0;
			this._isIn65LevelTeamDuplication = false;
		}

		// Token: 0x06011B42 RID: 72514 RVA: 0x0052FA08 File Offset: 0x0052DE08
		private void BindUiEvents()
		{
			if (this.teamListItemList != null)
			{
				this.teamListItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.teamListItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.teamListItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.buildTeamButton != null)
			{
				this.buildTeamButton.onClick.RemoveAllListeners();
				this.buildTeamButton.onClick.AddListener(new UnityAction(this.OnBuildTeamButtonClick));
			}
			if (this.inviteButton != null)
			{
				this.inviteButton.onClick.RemoveAllListeners();
				this.inviteButton.onClick.AddListener(new UnityAction(this.OnTeamInviteButtonClick));
			}
			if (this.goldSelectedButtonWithCd != null)
			{
				this.goldSelectedButtonWithCd.ResetButtonListener();
				this.goldSelectedButtonWithCd.SetButtonListener(new Action(this.OnGoldSelectedButtonClick));
			}
			if (this.prePageButton != null)
			{
				this.prePageButton.onClick.RemoveAllListeners();
				this.prePageButton.onClick.AddListener(new UnityAction(this.OnPrePageButtonClick));
			}
			if (this.nextPageButton != null)
			{
				this.nextPageButton.onClick.RemoveAllListeners();
				this.nextPageButton.onClick.AddListener(new UnityAction(this.OnNextPageButtonClick));
			}
		}

		// Token: 0x06011B43 RID: 72515 RVA: 0x0052FBE4 File Offset: 0x0052DFE4
		private void UnBindUiEvents()
		{
			if (this.teamListItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.teamListItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.teamListItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.buildTeamButton != null)
			{
				this.buildTeamButton.onClick.RemoveAllListeners();
			}
			if (this.inviteButton != null)
			{
				this.inviteButton.onClick.RemoveAllListeners();
			}
			if (this.goldSelectedButtonWithCd != null)
			{
				this.goldSelectedButtonWithCd.ResetButtonListener();
			}
			if (this.prePageButton != null)
			{
				this.prePageButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011B44 RID: 72516 RVA: 0x0052FCF0 File Offset: 0x0052E0F0
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationRefreshTeamListMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationRefreshTeamListMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamListRes, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamListRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationOwnerNewTeamInviteMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationOwnerNewInviteMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamLeaderRefuseJoinInMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamLeaderRefuseJoinInMessage));
		}

		// Token: 0x06011B45 RID: 72517 RVA: 0x0052FD6C File Offset: 0x0052E16C
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationRefreshTeamListMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationRefreshTeamListMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamListRes, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamListRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationOwnerNewTeamInviteMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationOwnerNewInviteMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamLeaderRefuseJoinInMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamLeaderRefuseJoinInMessage));
		}

		// Token: 0x06011B46 RID: 72518 RVA: 0x0052FDE8 File Offset: 0x0052E1E8
		public void Init()
		{
			this._isIn65LevelTeamDuplication = TeamDuplicationUtility.IsIn65LevelTeamDuplication();
			this._curPageNumber = 1;
			this._totalPageNumber = 1;
			this._teamTypeDataList = TeamDuplicationUtility.GetTeamDuplicationTeamTypeDataList();
			this._teamDuplicationTeamModelType = 0;
			if (DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationGoldOwner)
			{
				this._teamDuplicationTeamModelType = 2;
			}
			this.InitView();
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamListReq(this._curPageNumber, this._teamDuplicationTeamModelType);
		}

		// Token: 0x06011B47 RID: 72519 RVA: 0x0052FE52 File Offset: 0x0052E252
		private void InitView()
		{
			this.InitCommonView();
			this.UpdateFightNumber();
			this.UpdateGoldSelectedFlag();
			this.InitTeamTypeDropDownControl();
			this.UpdateInviteButtonRedPoint();
		}

		// Token: 0x06011B48 RID: 72520 RVA: 0x0052FE74 File Offset: 0x0052E274
		private void InitCommonView()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = TR.Value("team_duplication_team_list_title");
			}
			if (this.todayLabel != null)
			{
				this.todayLabel.text = TR.Value("team_duplication_team_today_label");
			}
			if (this.weekLabel != null)
			{
				this.weekLabel.text = TR.Value("team_duplication_team_week_label");
			}
			if (this.hardLevelLabel != null)
			{
				if (this._isIn65LevelTeamDuplication)
				{
					CommonUtility.UpdateTextVisible(this.hardLevelLabel, false);
				}
				else
				{
					CommonUtility.UpdateTextVisible(this.hardLevelLabel, true);
					this.hardLevelLabel.text = TR.Value("team_duplication_hard_level_label");
				}
			}
		}

		// Token: 0x06011B49 RID: 72521 RVA: 0x0052FF44 File Offset: 0x0052E344
		private void UpdateFightNumber()
		{
			TeamDuplicationPlayerInformationDataModel playerInformationDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetPlayerInformationDataModel();
			if (this.todayValueText != null)
			{
				if (playerInformationDataModel.DayAlreadyFightNumber >= playerInformationDataModel.DayTotalFightNumber)
				{
					this.todayValueText.text = string.Format(TR.Value("team_duplication_team_fight_number_full_type"), playerInformationDataModel.DayAlreadyFightNumber, playerInformationDataModel.DayTotalFightNumber);
				}
				else
				{
					this.todayValueText.text = string.Format(TR.Value("team_duplication_team_fight_number_normal_type"), playerInformationDataModel.DayAlreadyFightNumber, playerInformationDataModel.DayTotalFightNumber);
				}
			}
			if (this.weekValueText != null)
			{
				if (playerInformationDataModel.WeekAlreadyFightNumber >= playerInformationDataModel.WeekTotalFightNumber)
				{
					this.weekValueText.text = string.Format(TR.Value("team_duplication_team_fight_number_full_type"), playerInformationDataModel.WeekAlreadyFightNumber, playerInformationDataModel.WeekTotalFightNumber);
				}
				else
				{
					this.weekValueText.text = string.Format(TR.Value("team_duplication_team_fight_number_normal_type"), playerInformationDataModel.WeekAlreadyFightNumber, playerInformationDataModel.WeekTotalFightNumber);
				}
			}
			if (this.hardLevelValueText != null)
			{
				if (this._isIn65LevelTeamDuplication)
				{
					CommonUtility.UpdateTextVisible(this.hardLevelValueText, false);
				}
				else
				{
					CommonUtility.UpdateTextVisible(this.hardLevelValueText, true);
					if (playerInformationDataModel.HardLevelAlreadyFightNumber >= playerInformationDataModel.HardLevelTotalFightNumber)
					{
						this.hardLevelValueText.text = string.Format(TR.Value("team_duplication_team_fight_number_full_type"), playerInformationDataModel.HardLevelAlreadyFightNumber, playerInformationDataModel.HardLevelTotalFightNumber);
					}
					else
					{
						this.hardLevelValueText.text = string.Format(TR.Value("team_duplication_team_fight_number_normal_type"), playerInformationDataModel.HardLevelAlreadyFightNumber, playerInformationDataModel.HardLevelTotalFightNumber);
					}
				}
			}
		}

		// Token: 0x06011B4A RID: 72522 RVA: 0x0053011C File Offset: 0x0052E51C
		private void InitTeamTypeDropDownControl()
		{
			ComControlData comControlData = this._teamTypeDataList[0];
			if (DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationGoldOwner)
			{
				comControlData = this.GetGoldTeamModel();
			}
			if (this.teamTypeDropDownControl)
			{
				this.teamTypeDropDownControl.InitComDropDownControl(comControlData, this._teamTypeDataList, new OnCommonNewDropDownItemButtonClick(this.OnTeamTypeDropDownItemSelected), null);
			}
			this.UpdateTeamTypeDropDownBeforeCover();
		}

		// Token: 0x06011B4B RID: 72523 RVA: 0x00530181 File Offset: 0x0052E581
		private void UpdateTeamTypeDropDownBeforeCover()
		{
			if (this.teamTypeDropDownBeforeCover == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.teamTypeDropDownBeforeCover, DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationGoldOwner);
		}

		// Token: 0x06011B4C RID: 72524 RVA: 0x005301AC File Offset: 0x0052E5AC
		private void UpdateTeamListData()
		{
			this._curPageNumber = DataManager<TeamDuplicationDataManager>.GetInstance().TeamListCurrentPage;
			this._totalPageNumber = DataManager<TeamDuplicationDataManager>.GetInstance().TeamListTotalPage;
			if (this._totalPageNumber < 1)
			{
				this._totalPageNumber = 1;
			}
			if (this._curPageNumber < 1)
			{
				this._curPageNumber = 1;
			}
			if (this._curPageNumber > this._totalPageNumber)
			{
				this._curPageNumber = this._totalPageNumber;
			}
			this._teamListDataModelList = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamListDataModelList();
		}

		// Token: 0x06011B4D RID: 72525 RVA: 0x0053022C File Offset: 0x0052E62C
		private void UpdatePageView()
		{
			if (this.pageValue != null)
			{
				this.pageValue.text = string.Format(TR.Value("team_duplication_team_list_page_number"), this._curPageNumber, this._totalPageNumber);
			}
			if (this._curPageNumber <= 1)
			{
				if (this._totalPageNumber <= 1)
				{
					CommonUtility.UpdateButtonState(this.prePageButton, this.prePageGray, false);
					CommonUtility.UpdateButtonState(this.nextPageButton, this.nextPageGray, false);
				}
				else
				{
					CommonUtility.UpdateButtonState(this.prePageButton, this.prePageGray, false);
					CommonUtility.UpdateButtonState(this.nextPageButton, this.nextPageGray, true);
				}
			}
			else if (this._curPageNumber >= this._totalPageNumber)
			{
				CommonUtility.UpdateButtonState(this.prePageButton, this.prePageGray, true);
				CommonUtility.UpdateButtonState(this.nextPageButton, this.nextPageGray, false);
			}
			else
			{
				CommonUtility.UpdateButtonState(this.prePageButton, this.prePageGray, true);
				CommonUtility.UpdateButtonState(this.nextPageButton, this.nextPageGray, true);
			}
		}

		// Token: 0x06011B4E RID: 72526 RVA: 0x00530344 File Offset: 0x0052E744
		private void UpdateTeamListView()
		{
			if (this.teamListItemList != null)
			{
				this.teamListItemList.ResetComUiListScriptEx();
				if (this._teamListDataModelList == null || this._teamListDataModelList.Count <= 0)
				{
					this.teamListItemList.SetElementAmount(0);
				}
				else
				{
					this.teamListItemList.SetElementAmount(this._teamListDataModelList.Count);
				}
			}
		}

		// Token: 0x06011B4F RID: 72527 RVA: 0x005303B0 File Offset: 0x0052E7B0
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._teamListDataModelList == null || this._teamListDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index >= this._teamListDataModelList.Count)
			{
				return;
			}
			TeamDuplicationTeamListDataModel teamDuplicationTeamListDataModel = this._teamListDataModelList[item.m_index];
			TeamDuplicationTeamListItem component = item.GetComponent<TeamDuplicationTeamListItem>();
			if (teamDuplicationTeamListDataModel != null && component != null)
			{
				component.Init(teamDuplicationTeamListDataModel);
			}
		}

		// Token: 0x06011B50 RID: 72528 RVA: 0x00530430 File Offset: 0x0052E830
		private void OnItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.teamListItemList == null)
			{
				return;
			}
			TeamDuplicationTeamListItem component = item.GetComponent<TeamDuplicationTeamListItem>();
			if (component != null)
			{
				component.Reset();
			}
		}

		// Token: 0x06011B51 RID: 72529 RVA: 0x00530475 File Offset: 0x0052E875
		private void OnPrePageButtonClick()
		{
			if (this._curPageNumber <= 1)
			{
				return;
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamListReq(this._curPageNumber - 1, this._teamDuplicationTeamModelType);
		}

		// Token: 0x06011B52 RID: 72530 RVA: 0x0053049C File Offset: 0x0052E89C
		private void OnNextPageButtonClick()
		{
			if (this._curPageNumber >= this._totalPageNumber)
			{
				return;
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamListReq(this._curPageNumber + 1, this._teamDuplicationTeamModelType);
		}

		// Token: 0x06011B53 RID: 72531 RVA: 0x005304C8 File Offset: 0x0052E8C8
		private void OnBuildTeamButtonClick()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamListFrame();
			TeamDuplicationUtility.OnOpenTeamDuplicationTeamBuildFrame();
		}

		// Token: 0x06011B54 RID: 72532 RVA: 0x005304D4 File Offset: 0x0052E8D4
		private void OnTeamTypeDropDownItemSelected(ComControlData comControlData)
		{
			if (comControlData == null)
			{
				return;
			}
			this._teamDuplicationTeamModelType = comControlData.Id;
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamListReq(this._curPageNumber, this._teamDuplicationTeamModelType);
		}

		// Token: 0x06011B55 RID: 72533 RVA: 0x00530500 File Offset: 0x0052E900
		private void UpdateTeamTypeDropDownItemList()
		{
			if (DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationGoldOwner)
			{
				if (this.teamTypeDropDownControl == null)
				{
					return;
				}
				if (this._teamTypeDataList == null || this._teamTypeDataList.Count <= 0)
				{
					return;
				}
				ComControlData goldTeamModel = this.GetGoldTeamModel();
				this._teamDuplicationTeamModelType = goldTeamModel.Id;
				this.teamTypeDropDownControl.UpdateCommonNewDropDownSelectedItem(goldTeamModel);
				DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamListReq(this._curPageNumber, this._teamDuplicationTeamModelType);
			}
			else
			{
				if (this.teamTypeDropDownControl == null)
				{
					return;
				}
				if (this._teamTypeDataList == null || this._teamTypeDataList.Count <= 0)
				{
					return;
				}
				ComControlData allTeamModel = this.GetAllTeamModel();
				this._teamDuplicationTeamModelType = allTeamModel.Id;
				this.teamTypeDropDownControl.UpdateCommonNewDropDownSelectedItem(allTeamModel);
				DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamListReq(this._curPageNumber, this._teamDuplicationTeamModelType);
			}
			this.UpdateTeamTypeDropDownBeforeCover();
		}

		// Token: 0x06011B56 RID: 72534 RVA: 0x005305F0 File Offset: 0x0052E9F0
		private ComControlData GetGoldTeamModel()
		{
			if (this._teamTypeDataList == null || this._teamTypeDataList.Count <= 0)
			{
				return null;
			}
			ComControlData result = this._teamTypeDataList[0];
			for (int i = 1; i < this._teamTypeDataList.Count; i++)
			{
				if (this._teamTypeDataList[i].Id == 2)
				{
					result = this._teamTypeDataList[i];
					break;
				}
			}
			return result;
		}

		// Token: 0x06011B57 RID: 72535 RVA: 0x00530670 File Offset: 0x0052EA70
		private ComControlData GetAllTeamModel()
		{
			if (this._teamTypeDataList == null || this._teamTypeDataList.Count <= 0)
			{
				return null;
			}
			ComControlData result = this._teamTypeDataList[0];
			for (int i = 1; i < this._teamTypeDataList.Count; i++)
			{
				if (this._teamTypeDataList[i].Id == 0)
				{
					result = this._teamTypeDataList[i];
					break;
				}
			}
			return result;
		}

		// Token: 0x06011B58 RID: 72536 RVA: 0x005306ED File Offset: 0x0052EAED
		private void OnTeamInviteButtonClick()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationTeamInviteListFrame();
		}

		// Token: 0x06011B59 RID: 72537 RVA: 0x005306F4 File Offset: 0x0052EAF4
		private void OnGoldSelectedButtonClick()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationGoldOwner = !DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationGoldOwner;
			this.UpdateGoldSelectedFlag();
			this.UpdateTeamTypeDropDownItemList();
		}

		// Token: 0x06011B5A RID: 72538 RVA: 0x00530719 File Offset: 0x0052EB19
		private void UpdateGoldSelectedFlag()
		{
			CommonUtility.UpdateGameObjectVisible(this.goldSelectedFlag.gameObject, DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationGoldOwner);
		}

		// Token: 0x06011B5B RID: 72539 RVA: 0x00530735 File Offset: 0x0052EB35
		private void OnCloseButtonClick()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamListFrame();
		}

		// Token: 0x06011B5C RID: 72540 RVA: 0x0053073C File Offset: 0x0052EB3C
		private void UpdateInviteButtonRedPoint()
		{
			CommonUtility.UpdateGameObjectVisible(this.inviteButtonRedPoint, DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerNewInvite);
		}

		// Token: 0x06011B5D RID: 72541 RVA: 0x00530753 File Offset: 0x0052EB53
		private void OnReceiveTeamDuplicationTeamListRes(UIEvent uiEvent)
		{
			this.UpdateTeamListData();
			this.UpdatePageView();
			this.UpdateTeamListView();
		}

		// Token: 0x06011B5E RID: 72542 RVA: 0x00530767 File Offset: 0x0052EB67
		private void OnReceiveTeamDuplicationOwnerNewInviteMessage(UIEvent uiEvent)
		{
			this.UpdateInviteButtonRedPoint();
		}

		// Token: 0x06011B5F RID: 72543 RVA: 0x0053076F File Offset: 0x0052EB6F
		private void OnReceiveTeamDuplicationRefreshTeamListMessage(UIEvent uiEvent)
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamListReq(this._curPageNumber, this._teamDuplicationTeamModelType);
		}

		// Token: 0x06011B60 RID: 72544 RVA: 0x00530788 File Offset: 0x0052EB88
		private void OnReceiveTeamDuplicationTeamLeaderRefuseJoinInMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			string arg = (string)uiEvent.Param1;
			string msgContent = string.Format(TR.Value("team_duplication_team_leader_refuse_join_in"), arg);
			SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0400B882 RID: 47234
		private bool _isIn65LevelTeamDuplication;

		// Token: 0x0400B883 RID: 47235
		private List<TeamDuplicationTeamListDataModel> _teamListDataModelList;

		// Token: 0x0400B884 RID: 47236
		private int _curPageNumber;

		// Token: 0x0400B885 RID: 47237
		private int _totalPageNumber;

		// Token: 0x0400B886 RID: 47238
		private int _teamDuplicationTeamModelType;

		// Token: 0x0400B887 RID: 47239
		private List<ComControlData> _teamTypeDataList;

		// Token: 0x0400B888 RID: 47240
		[Space(15f)]
		[Header("Text")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x0400B889 RID: 47241
		[Space(15f)]
		[Header("Number")]
		[Space(10f)]
		[SerializeField]
		private Text todayLabel;

		// Token: 0x0400B88A RID: 47242
		[SerializeField]
		private Text todayValueText;

		// Token: 0x0400B88B RID: 47243
		[SerializeField]
		private Text weekLabel;

		// Token: 0x0400B88C RID: 47244
		[SerializeField]
		private Text weekValueText;

		// Token: 0x0400B88D RID: 47245
		[SerializeField]
		private Text hardLevelLabel;

		// Token: 0x0400B88E RID: 47246
		[SerializeField]
		private Text hardLevelValueText;

		// Token: 0x0400B88F RID: 47247
		[Space(15f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400B890 RID: 47248
		[SerializeField]
		private Button buildTeamButton;

		// Token: 0x0400B891 RID: 47249
		[SerializeField]
		private Button inviteButton;

		// Token: 0x0400B892 RID: 47250
		[SerializeField]
		private GameObject inviteButtonRedPoint;

		// Token: 0x0400B893 RID: 47251
		[Space(15f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button prePageButton;

		// Token: 0x0400B894 RID: 47252
		[SerializeField]
		private UIGray prePageGray;

		// Token: 0x0400B895 RID: 47253
		[SerializeField]
		private Button nextPageButton;

		// Token: 0x0400B896 RID: 47254
		[SerializeField]
		private UIGray nextPageGray;

		// Token: 0x0400B897 RID: 47255
		[SerializeField]
		private Text pageValue;

		// Token: 0x0400B898 RID: 47256
		[Space(15f)]
		[Header("Gold")]
		[Space(10f)]
		[SerializeField]
		private ComButtonWithCd goldSelectedButtonWithCd;

		// Token: 0x0400B899 RID: 47257
		[SerializeField]
		private Image goldSelectedFlag;

		// Token: 0x0400B89A RID: 47258
		[Space(20f)]
		[Header("TeamTypeDropDown")]
		[Space(20f)]
		[SerializeField]
		private CommonNewDropDownControl teamTypeDropDownControl;

		// Token: 0x0400B89B RID: 47259
		[SerializeField]
		private GameObject teamTypeDropDownBeforeCover;

		// Token: 0x0400B89C RID: 47260
		[Space(15f)]
		[Header("Control")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx teamListItemList;
	}
}
