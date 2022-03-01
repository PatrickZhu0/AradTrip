using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C57 RID: 7255
	public class TeamDuplicationFightStagePanelView : MonoBehaviour
	{
		// Token: 0x06011CF8 RID: 72952 RVA: 0x005363F5 File Offset: 0x005347F5
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011CF9 RID: 72953 RVA: 0x005363FD File Offset: 0x005347FD
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011CFA RID: 72954 RVA: 0x0053640C File Offset: 0x0053480C
		private void BindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.startFightButton != null)
			{
				this.startFightButton.ResetButtonListener();
				this.startFightButton.SetButtonListener(new Action(this.OnStartFightButtonClick));
			}
		}

		// Token: 0x06011CFB RID: 72955 RVA: 0x00536489 File Offset: 0x00534889
		private void UnBindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.startFightButton != null)
			{
				this.startFightButton.ResetButtonListener();
			}
		}

		// Token: 0x06011CFC RID: 72956 RVA: 0x005364C8 File Offset: 0x005348C8
		private void ClearData()
		{
			this._fightStageId = 0;
			this._fightStageTable = null;
			this._fightGoalDataModelList = null;
			this._selectedFightPointDataModel = null;
			this._teamDuplicationFightStagePointItemDic.Clear();
			this._tempAddNewTeamDuplicationFightStagePointItemDic.Clear();
			this._curStageFightPointItemWithPositionList = null;
		}

		// Token: 0x06011CFD RID: 72957 RVA: 0x00536503 File Offset: 0x00534903
		private void OnEnable()
		{
			this.BindUiMessage();
		}

		// Token: 0x06011CFE RID: 72958 RVA: 0x0053650B File Offset: 0x0053490B
		private void OnDisable()
		{
			this.UnBindUiMessage();
		}

		// Token: 0x06011CFF RID: 72959 RVA: 0x00536514 File Offset: 0x00534914
		private void BindUiMessage()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightPointNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightPointNotifyMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightGoalNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightGoalNotifyMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightCaptainGoalChangeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightCaptainGoalChangeMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightPointEnergyAccumulationTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightPointEnergyAccumulationTimeMessage));
		}

		// Token: 0x06011D00 RID: 72960 RVA: 0x005365A8 File Offset: 0x005349A8
		private void UnBindUiMessage()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightPointNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightPointNotifyMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightGoalNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightGoalNotifyMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightCaptainGoalChangeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightCaptainGoalChangeMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightPointEnergyAccumulationTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightPointEnergyAccumulationTimeMessage));
		}

		// Token: 0x06011D01 RID: 72961 RVA: 0x0053663C File Offset: 0x00534A3C
		public void Init(int fightStageId)
		{
			this._fightStageId = fightStageId;
			this._fightStageTable = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyStageTable>(this._fightStageId, string.Empty, string.Empty);
			if (this._fightStageTable == null)
			{
				return;
			}
			this._curStageFightPointItemWithPositionList = this.firstStageFightPointItemWithPositionList;
			if (this._fightStageId == 2)
			{
				this._curStageFightPointItemWithPositionList = this.secondStageFightPointItemWithPositionList;
			}
			this.InitView();
		}

		// Token: 0x06011D02 RID: 72962 RVA: 0x005366A6 File Offset: 0x00534AA6
		private void InitView()
		{
			this.InitCommonView();
			this.InitFightPointItemPosition();
			this.InitFightPanelContent();
		}

		// Token: 0x06011D03 RID: 72963 RVA: 0x005366BC File Offset: 0x00534ABC
		private void InitCommonView()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = this._fightStageTable.Description;
			}
			if (this.normalBackgroundImage != null)
			{
				ETCImageLoader.LoadSprite(ref this.normalBackgroundImage, this._fightStageTable.NormalBackgroundPath, true);
			}
			if (this.extraBackgroundImage != null)
			{
				if (string.IsNullOrEmpty(this._fightStageTable.ExtraBackgroundPath))
				{
					CommonUtility.UpdateImageVisible(this.extraBackgroundImage, false);
				}
				else
				{
					CommonUtility.UpdateImageVisible(this.extraBackgroundImage, true);
					ETCImageLoader.LoadSprite(ref this.extraBackgroundImage, this._fightStageTable.ExtraBackgroundPath, true);
				}
			}
		}

		// Token: 0x06011D04 RID: 72964 RVA: 0x00536774 File Offset: 0x00534B74
		private void InitFightPointItemPosition()
		{
			if (this.fightPointItemTemplate != null)
			{
				this.fightPointItemTemplate.CustomActive(false);
			}
			if (this._curStageFightPointItemWithPositionList == null || this._curStageFightPointItemWithPositionList.Count <= 0)
			{
				return;
			}
			if (this._teamDuplicationFightStagePointItemDic == null)
			{
				return;
			}
			this._teamDuplicationFightStagePointItemDic.Clear();
			for (int i = 0; i < this._curStageFightPointItemWithPositionList.Count; i++)
			{
				TeamDuplicationFightPointItemWithPosition teamDuplicationFightPointItemWithPosition = this._curStageFightPointItemWithPositionList[i];
				if (teamDuplicationFightPointItemWithPosition != null)
				{
					int positionIndex = teamDuplicationFightPointItemWithPosition.PositionIndex;
					this._teamDuplicationFightStagePointItemDic[positionIndex] = null;
				}
			}
		}

		// Token: 0x06011D05 RID: 72965 RVA: 0x0053681C File Offset: 0x00534C1C
		private void UpdateFightPointItemList()
		{
			List<TeamDuplicationFightPointDataModel> teamDuplicationFightPointDataModelList = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightPointDataModelList;
			this._tempAddNewTeamDuplicationFightStagePointItemDic.Clear();
			foreach (KeyValuePair<int, TeamDuplicationFightStagePointItem> keyValuePair in this._teamDuplicationFightStagePointItemDic)
			{
				int key = keyValuePair.Key;
				TeamDuplicationFightStagePointItem teamDuplicationFightStagePointItem = keyValuePair.Value;
				bool flag = false;
				TeamDuplicationFightPointDataModel fightPointDataModel = null;
				if (teamDuplicationFightPointDataModelList != null)
				{
					for (int i = 0; i < teamDuplicationFightPointDataModelList.Count; i++)
					{
						TeamDuplicationFightPointDataModel teamDuplicationFightPointDataModel = teamDuplicationFightPointDataModelList[i];
						if (teamDuplicationFightPointDataModel != null)
						{
							if (teamDuplicationFightPointDataModel.FightPointPosition == key)
							{
								flag = true;
								fightPointDataModel = teamDuplicationFightPointDataModel;
								break;
							}
						}
					}
				}
				if (!flag)
				{
					if (teamDuplicationFightStagePointItem != null)
					{
						CommonUtility.UpdateGameObjectVisible(teamDuplicationFightStagePointItem.gameObject, false);
					}
				}
				else if (TeamDuplicationUtility.IsFightPointShowInFightPanel(fightPointDataModel))
				{
					if (teamDuplicationFightStagePointItem == null)
					{
						teamDuplicationFightStagePointItem = this.LoadFightPointItem(key);
						this._tempAddNewTeamDuplicationFightStagePointItemDic[key] = teamDuplicationFightStagePointItem;
					}
					if (teamDuplicationFightStagePointItem != null)
					{
						CommonUtility.UpdateGameObjectVisible(teamDuplicationFightStagePointItem.gameObject, true);
						teamDuplicationFightStagePointItem.Init(fightPointDataModel, new OnFightPointButtonClickAction(this.OnFightPointButtonClick));
					}
				}
				else if (teamDuplicationFightStagePointItem != null)
				{
					CommonUtility.UpdateGameObjectVisible(teamDuplicationFightStagePointItem.gameObject, false);
				}
			}
			foreach (KeyValuePair<int, TeamDuplicationFightStagePointItem> keyValuePair2 in this._tempAddNewTeamDuplicationFightStagePointItemDic)
			{
				int key2 = keyValuePair2.Key;
				TeamDuplicationFightStagePointItem value = keyValuePair2.Value;
				if (value != null)
				{
					this._teamDuplicationFightStagePointItemDic[key2] = value;
				}
			}
			this._tempAddNewTeamDuplicationFightStagePointItemDic.Clear();
		}

		// Token: 0x06011D06 RID: 72966 RVA: 0x00536A2C File Offset: 0x00534E2C
		private void InitFightPanelContent()
		{
			this.UpdateFightPointItemList();
			this._selectedFightPointDataModel = TeamDuplicationUtility.GetDefaultSelectedFightPointDataModel();
			this.UpdateFightPointItemSelectedState();
			this.UpdateFightPanelButton();
			this.InitFightGoalControl();
		}

		// Token: 0x06011D07 RID: 72967 RVA: 0x00536A54 File Offset: 0x00534E54
		private void OnFightPointButtonClick(TeamDuplicationFightPointDataModel fightPointDataModel)
		{
			if (fightPointDataModel == null)
			{
				return;
			}
			if (this._selectedFightPointDataModel != null && this._selectedFightPointDataModel.FightPointId == fightPointDataModel.FightPointId)
			{
				return;
			}
			this._selectedFightPointDataModel = fightPointDataModel;
			this.UpdateFightPointItemSelectedState();
			this.UpdateFightPanelButton();
			this.UpdateFightPointDescriptionView(this._selectedFightPointDataModel);
		}

		// Token: 0x06011D08 RID: 72968 RVA: 0x00536AA9 File Offset: 0x00534EA9
		private void UpdateFightPanelButton()
		{
			this.UpdateFightStartButton();
		}

		// Token: 0x06011D09 RID: 72969 RVA: 0x00536AB4 File Offset: 0x00534EB4
		private void UpdateFightStartButton()
		{
			if (this.startFightButton == null)
			{
				return;
			}
			if (this._selectedFightPointDataModel == null)
			{
				CommonUtility.UpdateGameObjectVisible(this.startFightButton.gameObject, false);
				return;
			}
			if (!TeamDuplicationUtility.IsSelfPlayerIsCaptainInTeamDuplication())
			{
				CommonUtility.UpdateGameObjectVisible(this.startFightButton.gameObject, false);
				return;
			}
			if (this._selectedFightPointDataModel.FightPointStatusType == TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_REBORN)
			{
				CommonUtility.UpdateGameObjectVisible(this.startFightButton.gameObject, false);
				return;
			}
			if (this._selectedFightPointDataModel.FightPointStatusType == TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_UNLOCKING)
			{
				this.startFightButton.StopCountDown();
				CommonUtility.UpdateGameObjectVisible(this.startFightButton.gameObject, true);
				this.startFightButton.UpdateButtonState(false);
				CommonUtility.UpdateUIGrayVisible(this.startFightButtonUIGray, true);
				CommonUtility.UpdateGameObjectVisible(this.startButtonEffectRoot, false);
				return;
			}
			if (this._selectedFightPointDataModel.FightPointStatusType == TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_ENERGY_REVIVE)
			{
				this.UpdateFightPointStartButtonByEnergyAccumulationStatus();
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.startFightButton.gameObject, true);
			this.startFightButton.Reset();
			CommonUtility.UpdateUIGrayVisible(this.startFightButtonUIGray, false);
			CommonUtility.UpdateGameObjectVisible(this.startButtonEffectRoot, true);
		}

		// Token: 0x06011D0A RID: 72970 RVA: 0x00536BD0 File Offset: 0x00534FD0
		private void UpdateFightPointStartButtonByEnergyAccumulationStatus()
		{
			if ((ulong)DataManager<TimeManager>.GetInstance().GetServerTime() - (ulong)((long)this._selectedFightPointDataModel.FightPointEnergyAccumulationStartTime) > 50UL)
			{
				CommonUtility.UpdateGameObjectVisible(this.startFightButton.gameObject, true);
				this.startFightButton.Reset();
				CommonUtility.UpdateUIGrayVisible(this.startFightButtonUIGray, false);
				CommonUtility.UpdateGameObjectVisible(this.startButtonEffectRoot, true);
			}
			else
			{
				this.startFightButton.StopCountDown();
				CommonUtility.UpdateGameObjectVisible(this.startFightButton.gameObject, true);
				this.startFightButton.UpdateButtonState(false);
				CommonUtility.UpdateUIGrayVisible(this.startFightButtonUIGray, true);
				CommonUtility.UpdateGameObjectVisible(this.startButtonEffectRoot, false);
			}
		}

		// Token: 0x06011D0B RID: 72971 RVA: 0x00536C78 File Offset: 0x00535078
		private void UpdateFightPointItemSelectedState()
		{
			TeamDuplicationFightPointDataModel selectedFightPointDataModel = this._selectedFightPointDataModel;
			foreach (KeyValuePair<int, TeamDuplicationFightStagePointItem> keyValuePair in this._teamDuplicationFightStagePointItemDic)
			{
				TeamDuplicationFightStagePointItem value = keyValuePair.Value;
				if (!(value == null))
				{
					TeamDuplicationFightPointDataModel fightPointDataModel = value.GetFightPointDataModel();
					if (fightPointDataModel != null)
					{
						if (selectedFightPointDataModel == null)
						{
							value.UpdateFightPointSelectedView(false);
						}
						else if (fightPointDataModel.FightPointId == selectedFightPointDataModel.FightPointId)
						{
							value.UpdateFightPointSelectedView(true);
						}
						else
						{
							value.UpdateFightPointSelectedView(false);
						}
					}
				}
			}
		}

		// Token: 0x06011D0C RID: 72972 RVA: 0x00536D38 File Offset: 0x00535138
		private void InitFightGoalControl()
		{
			this._fightGoalDataModelList = TeamDuplicationUtility.GetFightGoalDataModelList(this._selectedFightPointDataModel);
			if (this.fightStageGoalControl != null)
			{
				this.fightStageGoalControl.Init(this._fightGoalDataModelList);
			}
		}

		// Token: 0x06011D0D RID: 72973 RVA: 0x00536D6D File Offset: 0x0053516D
		private void UpdateFightGoalView()
		{
			if (this.fightStageGoalControl != null)
			{
				this.fightStageGoalControl.UpdateFightStageGoalView();
			}
		}

		// Token: 0x06011D0E RID: 72974 RVA: 0x00536D8B File Offset: 0x0053518B
		private void UpdateFightPointDescriptionView(TeamDuplicationFightPointDataModel selectedFightPointDataModel)
		{
			if (selectedFightPointDataModel == null)
			{
				return;
			}
			if (this.fightStageGoalControl != null)
			{
				this.fightStageGoalControl.UpdateFightStageFightPointDescriptionView(selectedFightPointDataModel);
			}
		}

		// Token: 0x06011D0F RID: 72975 RVA: 0x00536DB4 File Offset: 0x005351B4
		private void OnReceiveTeamDuplicationFightPointNotifyMessage(UIEvent uiEvent)
		{
			this.UpdateFightPointItemList();
			if (this._selectedFightPointDataModel == null || (this._selectedFightPointDataModel != null && !TeamDuplicationUtility.IsSelectFightPointInFightPointList(this._selectedFightPointDataModel.FightPointId)))
			{
				this._selectedFightPointDataModel = TeamDuplicationUtility.GetDefaultSelectedFightPointDataModel();
				this.UpdateFightPointItemSelectedState();
				this.UpdateFightPanelButton();
				this.UpdateFightPointDescriptionView(this._selectedFightPointDataModel);
			}
			else
			{
				this.UpdateFightPanelButton();
			}
		}

		// Token: 0x06011D10 RID: 72976 RVA: 0x00536E20 File Offset: 0x00535220
		private void OnReceiveTeamDuplicationFightGoalNotifyMessage(UIEvent uiEvent)
		{
			this.UpdateFightGoalView();
		}

		// Token: 0x06011D11 RID: 72977 RVA: 0x00536E28 File Offset: 0x00535228
		private void OnReceiveTeamDuplicationFightCaptainGoalChangeMessage(UIEvent uiEvent)
		{
			if (this._selectedFightPointDataModel == null)
			{
				this._selectedFightPointDataModel = TeamDuplicationUtility.GetDefaultSelectedFightPointDataModel();
				this.UpdateFightPointItemSelectedState();
				this.UpdateFightPanelButton();
				this.UpdateFightPointDescriptionView(this._selectedFightPointDataModel);
			}
		}

		// Token: 0x06011D12 RID: 72978 RVA: 0x00536E58 File Offset: 0x00535258
		private void OnReceiveTeamDuplicationTeamDataMessage(UIEvent uiEvent)
		{
			this.UpdateFightPanelButton();
		}

		// Token: 0x06011D13 RID: 72979 RVA: 0x00536E60 File Offset: 0x00535260
		private void OnReceiveTeamDuplicationFightPointEnergyAccumulationTimeMessage(UIEvent uiEvent)
		{
			if (this._selectedFightPointDataModel == null)
			{
				return;
			}
			if (this._selectedFightPointDataModel.FightPointStatusType != TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_ENERGY_REVIVE)
			{
				return;
			}
			this.UpdateFightPanelButton();
		}

		// Token: 0x06011D14 RID: 72980 RVA: 0x00536E86 File Offset: 0x00535286
		private void OnCloseButtonClick()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationFightStagePanelFrame();
		}

		// Token: 0x06011D15 RID: 72981 RVA: 0x00536E8D File Offset: 0x0053528D
		private void OnStartFightButtonClick()
		{
			if (this._selectedFightPointDataModel == null)
			{
				return;
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyStartChallengeReq(this._selectedFightPointDataModel.FightPointId);
		}

		// Token: 0x06011D16 RID: 72982 RVA: 0x00536EB0 File Offset: 0x005352B0
		private TeamDuplicationFightStagePointItem LoadFightPointItem(int fightPointIndex)
		{
			if (this.fightPointItemTemplate == null)
			{
				return null;
			}
			TeamDuplicationFightPointItemWithPosition teamDuplicationFightPointItemWithPosition = null;
			for (int i = 0; i < this._curStageFightPointItemWithPositionList.Count; i++)
			{
				TeamDuplicationFightPointItemWithPosition teamDuplicationFightPointItemWithPosition2 = this._curStageFightPointItemWithPositionList[i];
				if (teamDuplicationFightPointItemWithPosition2 != null && teamDuplicationFightPointItemWithPosition2.PositionIndex == fightPointIndex)
				{
					teamDuplicationFightPointItemWithPosition = teamDuplicationFightPointItemWithPosition2;
					break;
				}
			}
			if (teamDuplicationFightPointItemWithPosition == null || teamDuplicationFightPointItemWithPosition.FightPointItemRoot == null)
			{
				return null;
			}
			GameObject gameObject = Object.Instantiate<GameObject>(this.fightPointItemTemplate);
			if (gameObject == null)
			{
				return null;
			}
			gameObject.transform.name = gameObject.transform.name + "_" + fightPointIndex;
			gameObject.transform.SetParent(teamDuplicationFightPointItemWithPosition.FightPointItemRoot.transform, false);
			TeamDuplicationFightStagePointItem component = gameObject.GetComponent<TeamDuplicationFightStagePointItem>();
			if (component == null)
			{
				return null;
			}
			return component;
		}

		// Token: 0x0400B984 RID: 47492
		private int _fightStageId;

		// Token: 0x0400B985 RID: 47493
		private TeamCopyStageTable _fightStageTable;

		// Token: 0x0400B986 RID: 47494
		private List<ComControlData> _fightGoalDataModelList;

		// Token: 0x0400B987 RID: 47495
		private TeamDuplicationFightPointDataModel _selectedFightPointDataModel;

		// Token: 0x0400B988 RID: 47496
		private Dictionary<int, TeamDuplicationFightStagePointItem> _teamDuplicationFightStagePointItemDic = new Dictionary<int, TeamDuplicationFightStagePointItem>();

		// Token: 0x0400B989 RID: 47497
		private Dictionary<int, TeamDuplicationFightStagePointItem> _tempAddNewTeamDuplicationFightStagePointItemDic = new Dictionary<int, TeamDuplicationFightStagePointItem>();

		// Token: 0x0400B98A RID: 47498
		private List<TeamDuplicationFightPointItemWithPosition> _curStageFightPointItemWithPositionList;

		// Token: 0x0400B98B RID: 47499
		[Space(25f)]
		[Header("Background")]
		[Space(10f)]
		[SerializeField]
		private Image normalBackgroundImage;

		// Token: 0x0400B98C RID: 47500
		[SerializeField]
		private Image extraBackgroundImage;

		// Token: 0x0400B98D RID: 47501
		[Space(25f)]
		[Header("Normal")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x0400B98E RID: 47502
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400B98F RID: 47503
		[SerializeField]
		private ComButtonWithCd startFightButton;

		// Token: 0x0400B990 RID: 47504
		[SerializeField]
		private UIGray startFightButtonUIGray;

		// Token: 0x0400B991 RID: 47505
		[SerializeField]
		private GameObject startButtonEffectRoot;

		// Token: 0x0400B992 RID: 47506
		[Space(25f)]
		[Header("FightPointItem")]
		[Space(10f)]
		[SerializeField]
		private GameObject fightPointItemTemplate;

		// Token: 0x0400B993 RID: 47507
		[Space(5f)]
		[Header("FirstStageFightPointItemPositionList")]
		[Space(5f)]
		[SerializeField]
		private List<TeamDuplicationFightPointItemWithPosition> firstStageFightPointItemWithPositionList = new List<TeamDuplicationFightPointItemWithPosition>();

		// Token: 0x0400B994 RID: 47508
		[Space(5f)]
		[Header("SecondStageFightPointItemPositionList")]
		[Space(5f)]
		[SerializeField]
		private List<TeamDuplicationFightPointItemWithPosition> secondStageFightPointItemWithPositionList = new List<TeamDuplicationFightPointItemWithPosition>();

		// Token: 0x0400B995 RID: 47509
		[Space(25f)]
		[Header("FightStageGoalControl")]
		[Space(10f)]
		[SerializeField]
		private TeamDuplicationFightStageGoalControl fightStageGoalControl;
	}
}
