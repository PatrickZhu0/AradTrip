using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C8E RID: 7310
	public class TeamDuplicationFightStagePointItem : MonoBehaviour
	{
		// Token: 0x06011EBB RID: 73403 RVA: 0x0053DC95 File Offset: 0x0053C095
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011EBC RID: 73404 RVA: 0x0053DC9D File Offset: 0x0053C09D
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011EBD RID: 73405 RVA: 0x0053DCAC File Offset: 0x0053C0AC
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightPointBossDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightPointBossDataMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightPointUnlockRateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightPointUnlockRateMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightPointEnergyAccumulationTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightPointEnergyAccumulationTimeMessage));
		}

		// Token: 0x06011EBE RID: 73406 RVA: 0x0053DD0C File Offset: 0x0053C10C
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightPointBossDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightPointBossDataMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightPointUnlockRateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightPointUnlockRateMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightPointEnergyAccumulationTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightPointEnergyAccumulationTimeMessage));
		}

		// Token: 0x06011EBF RID: 73407 RVA: 0x0053DD6A File Offset: 0x0053C16A
		private void BindUiEvents()
		{
			if (this.fightPointButton != null)
			{
				this.fightPointButton.onClick.RemoveAllListeners();
				this.fightPointButton.onClick.AddListener(new UnityAction(this.OnFightPointButtonClick));
			}
		}

		// Token: 0x06011EC0 RID: 73408 RVA: 0x0053DDA9 File Offset: 0x0053C1A9
		private void UnBindUiEvents()
		{
			if (this.fightPointButton != null)
			{
				this.fightPointButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011EC1 RID: 73409 RVA: 0x0053DDCC File Offset: 0x0053C1CC
		private void ClearData()
		{
			this._fightPointDataModel = null;
			this._onFightPointButtonClickAction = null;
			this._teamCopyFieldTable = null;
			this._isTeamDuplicationFightPointStatusChanged = false;
			this._isTeamDuplicationFightPointIdChanged = false;
			this._fightPointRebornStatusControl = null;
			this._fightPointUrgentStatusGameObject = null;
			this._fightPointUnlockStatusControl = null;
			this._fightPointEnergyAccumulationStatusControl = null;
			this._fightPointCurrentBossPhase = 0;
			if (this.teamAndNumberControl != null)
			{
				this.teamAndNumberControl.ClearControl();
			}
		}

		// Token: 0x06011EC2 RID: 73410 RVA: 0x0053DE3C File Offset: 0x0053C23C
		public void Init(TeamDuplicationFightPointDataModel fightPointDataModel, OnFightPointButtonClickAction fightPointButtonClickAction = null)
		{
			this.InitFightPointStatusChange(fightPointDataModel);
			this.InitFightPointIdChange(fightPointDataModel);
			this._fightPointDataModel = fightPointDataModel;
			this._onFightPointButtonClickAction = fightPointButtonClickAction;
			if (this._fightPointDataModel == null)
			{
				Logger.LogError("FightPointDataModel is null");
				return;
			}
			this._teamCopyFieldTable = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyFieldTable>(this._fightPointDataModel.FightPointId, string.Empty, string.Empty);
			if (this._teamCopyFieldTable == null)
			{
				Logger.LogErrorFormat("TeamCopyFieldTable is null and pointId is {0}", new object[]
				{
					this._fightPointDataModel.FightPointId
				});
				return;
			}
			this.InitItem();
		}

		// Token: 0x06011EC3 RID: 73411 RVA: 0x0053DED5 File Offset: 0x0053C2D5
		private void InitFightPointIdChange(TeamDuplicationFightPointDataModel fightPointDataModel)
		{
			this._isTeamDuplicationFightPointIdChanged = true;
			if (fightPointDataModel == null)
			{
				return;
			}
			if (this._fightPointDataModel == null)
			{
				return;
			}
			if (this._fightPointDataModel.FightPointId == fightPointDataModel.FightPointId)
			{
				this._isTeamDuplicationFightPointIdChanged = false;
			}
		}

		// Token: 0x06011EC4 RID: 73412 RVA: 0x0053DF10 File Offset: 0x0053C310
		private void InitFightPointStatusChange(TeamDuplicationFightPointDataModel fightPointDataModel)
		{
			this._isTeamDuplicationFightPointStatusChanged = false;
			if (fightPointDataModel == null)
			{
				return;
			}
			if (this._fightPointDataModel == null)
			{
				this._isTeamDuplicationFightPointStatusChanged = true;
				return;
			}
			if (this._fightPointDataModel.FightPointId != fightPointDataModel.FightPointId)
			{
				this._isTeamDuplicationFightPointStatusChanged = true;
				return;
			}
			if (this._fightPointDataModel.FightPointStatusType != fightPointDataModel.FightPointStatusType)
			{
				this._isTeamDuplicationFightPointStatusChanged = true;
				return;
			}
		}

		// Token: 0x06011EC5 RID: 73413 RVA: 0x0053DF7A File Offset: 0x0053C37A
		private void InitItem()
		{
			this.InitCommonView();
			this.UpdateFightPointStatusView();
			this.UpdateFightPointBossItemView();
			this.UpdateFightPointTeamItem();
			this.UpdateFightPointFightNumberItem();
		}

		// Token: 0x06011EC6 RID: 73414 RVA: 0x0053DF9C File Offset: 0x0053C39C
		private void InitCommonView()
		{
			if (this._isTeamDuplicationFightPointIdChanged)
			{
				this.InitFightPointName();
				if (this._teamCopyFieldTable.PresentedType == TeamCopyFieldTable.ePresentedType.BossFightPoint)
				{
					this.UpdateFightPointIcon(false);
				}
				else
				{
					this.UpdateFightPointIcon(true);
					if (this.normalIcon != null)
					{
						ETCImageLoader.LoadSprite(ref this.normalIcon, this._teamCopyFieldTable.NormalIconPath, true);
					}
					if (this.selectedIcon != null)
					{
						ETCImageLoader.LoadSprite(ref this.selectedIcon, this._teamCopyFieldTable.SelectedIconPath, true);
					}
				}
			}
		}

		// Token: 0x06011EC7 RID: 73415 RVA: 0x0053E030 File Offset: 0x0053C430
		private void InitFightPointName()
		{
			if (this._teamCopyFieldTable == null)
			{
				return;
			}
			if (this.fightPointNormalNameText != null)
			{
				string text = string.Format(TR.Value("team_duplication_fight_point_normal_name"), this._teamCopyFieldTable.Name);
				this.fightPointNormalNameText.text = text;
			}
			if (this.fightPointSelectedNameText != null)
			{
				string text2 = string.Format(TR.Value("team_duplication_fight_point_selected_name"), this._teamCopyFieldTable.Name);
				this.fightPointSelectedNameText.text = text2;
			}
		}

		// Token: 0x06011EC8 RID: 73416 RVA: 0x0053E0BC File Offset: 0x0053C4BC
		public void UpdateFightPointStatusView()
		{
			CommonUtility.UpdateGameObjectVisible(this.urgentStatusRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.rebornStatusRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.unlockStatusRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.energyAccumulationStatusRoot, false);
			if (this._fightPointDataModel.FightPointStatusType == TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_REBORN)
			{
				if (this._fightPointRebornStatusControl == null)
				{
					this._fightPointRebornStatusControl = this.LoadFightPointRebornStatusView(this.rebornStatusRoot);
				}
				if (this._fightPointRebornStatusControl != null && (long)this._fightPointDataModel.FightPointRebornTime > (long)((ulong)DataManager<TimeManager>.GetInstance().GetServerTime()))
				{
					int totalCountDownTime = this._fightPointDataModel.FightPointRebornTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
					this._fightPointRebornStatusControl.Init(totalCountDownTime);
					CommonUtility.UpdateGameObjectVisible(this.rebornStatusRoot, true);
				}
			}
			else if (this._fightPointDataModel.FightPointStatusType == TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_URGENT)
			{
				if (this._isTeamDuplicationFightPointStatusChanged)
				{
					MonoSingleton<AudioManager>.instance.PlaySound(5064);
				}
				if (this._fightPointUrgentStatusGameObject == null)
				{
					this._fightPointUrgentStatusGameObject = this.LoadFightPointUrgentStatusView(this.urgentStatusRoot);
				}
				if (this._fightPointUrgentStatusGameObject != null)
				{
					CommonUtility.UpdateGameObjectVisible(this.urgentStatusRoot, true);
					CommonUtility.UpdateGameObjectVisible(this._fightPointUrgentStatusGameObject, true);
				}
			}
			else if (this._fightPointDataModel.FightPointStatusType == TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_UNLOCKING)
			{
				int unlockRate;
				if (this._teamCopyFieldTable != null && this._teamCopyFieldTable.PreFieldPointId > 0)
				{
					unlockRate = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationFightPointUnlockRateByPreFightPointId(this._teamCopyFieldTable.PreFieldPointId);
				}
				else
				{
					unlockRate = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationFightPointUnlockRateByFightPointId(this._fightPointDataModel.FightPointId);
				}
				if (this._fightPointUnlockStatusControl == null)
				{
					this._fightPointUnlockStatusControl = this.LoadFightPointUnlockStatusView(this.unlockStatusRoot);
				}
				if (this._fightPointUnlockStatusControl != null)
				{
					CommonUtility.UpdateGameObjectVisible(this.unlockStatusRoot, true);
					this._fightPointUnlockStatusControl.UpdateUnlockRate(unlockRate);
				}
			}
			else if (this._fightPointDataModel.FightPointStatusType == TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_ENERGY_REVIVE)
			{
				if (this._fightPointEnergyAccumulationStatusControl == null)
				{
					this._fightPointEnergyAccumulationStatusControl = this.LoadFightPointEnergyAccumulationStatusView(this.energyAccumulationStatusRoot);
				}
				if (this._fightPointEnergyAccumulationStatusControl != null)
				{
					this._fightPointEnergyAccumulationStatusControl.Init(this._fightPointDataModel.FightPointEnergyAccumulationStartTime);
					CommonUtility.UpdateGameObjectVisible(this.energyAccumulationStatusRoot, true);
				}
			}
		}

		// Token: 0x06011EC9 RID: 73417 RVA: 0x0053E323 File Offset: 0x0053C723
		public void UpdateFightPointBossItemView()
		{
			CommonUtility.UpdateGameObjectVisible(this.bossBloodStatusRoot, false);
			if (this._teamCopyFieldTable.PresentedType != TeamCopyFieldTable.ePresentedType.BossFightPoint)
			{
				return;
			}
			if (DataManager<TeamDuplicationDataManager>.GetInstance().BossPhase <= 0)
			{
				return;
			}
			this.UpdateFightPointBossItemIcon();
			this.UpdateFightPointBossBlood();
		}

		// Token: 0x06011ECA RID: 73418 RVA: 0x0053E360 File Offset: 0x0053C760
		private void UpdateFightPointBossBlood()
		{
			if (this._fightPointBossBloodControl == null)
			{
				this._fightPointBossBloodControl = this.LoadFightPointBossBloodView(this.bossBloodStatusRoot);
			}
			if (this._fightPointBossBloodControl != null)
			{
				int bossBloodRate = DataManager<TeamDuplicationDataManager>.GetInstance().BossBloodRate;
				this._fightPointBossBloodControl.UpdateBossBloodRate(bossBloodRate);
				if (bossBloodRate > 0)
				{
					CommonUtility.UpdateGameObjectVisible(this.bossBloodStatusRoot, true);
				}
			}
		}

		// Token: 0x06011ECB RID: 73419 RVA: 0x0053E3CC File Offset: 0x0053C7CC
		private void UpdateFightPointBossItemIcon()
		{
			if (this._fightPointCurrentBossPhase == DataManager<TeamDuplicationDataManager>.GetInstance().BossPhase)
			{
				return;
			}
			this._fightPointCurrentBossPhase = DataManager<TeamDuplicationDataManager>.GetInstance().BossPhase;
			string path = this._teamCopyFieldTable.NormalIconPath;
			string path2 = this._teamCopyFieldTable.SelectedIconPath;
			if (this._fightPointCurrentBossPhase == 2)
			{
				path = this._teamCopyFieldTable.BossSecondStageNormalIconPath;
				path2 = this._teamCopyFieldTable.BossSecondStageSelectedIconPath;
			}
			else if (this._fightPointCurrentBossPhase == 3)
			{
				path = this._teamCopyFieldTable.BossThirdStageNormalIconPath;
				path2 = this._teamCopyFieldTable.BossThirdStageSelectedIconPath;
			}
			if (this.bossNormalIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.bossNormalIcon, path, true);
			}
			if (this.bossSelectedIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.bossSelectedIcon, path2, true);
			}
		}

		// Token: 0x06011ECC RID: 73420 RVA: 0x0053E4A2 File Offset: 0x0053C8A2
		private void UpdateFightPointIcon(bool isNormalFightPoint)
		{
			CommonUtility.UpdateGameObjectVisible(this.normalBg, isNormalFightPoint);
			CommonUtility.UpdateGameObjectVisible(this.selectedBg, isNormalFightPoint);
			CommonUtility.UpdateImageVisible(this.bossNormalIcon, !isNormalFightPoint);
			CommonUtility.UpdateImageVisible(this.bossSelectedIcon, !isNormalFightPoint);
		}

		// Token: 0x06011ECD RID: 73421 RVA: 0x0053E4DA File Offset: 0x0053C8DA
		private void UpdateFightPointTeamItem()
		{
			if (this.teamAndNumberControl != null)
			{
				this.teamAndNumberControl.UpdateFightPointTeamItemList(this._fightPointDataModel.FightPointTeamList);
			}
		}

		// Token: 0x06011ECE RID: 73422 RVA: 0x0053E504 File Offset: 0x0053C904
		private void UpdateFightPointFightNumberItem()
		{
			int num = this._fightPointDataModel.FightPointTotalFightNumber - this._fightPointDataModel.FightPointLeftFightNumber;
			if (num < 0)
			{
				num = 0;
			}
			if (this.teamAndNumberControl != null)
			{
				this.teamAndNumberControl.UpdateFightPointFightNumberItemList(num, this._fightPointDataModel.FightPointTotalFightNumber);
			}
		}

		// Token: 0x06011ECF RID: 73423 RVA: 0x0053E55A File Offset: 0x0053C95A
		private void OnFightPointButtonClick()
		{
			if (this._onFightPointButtonClickAction != null && this._fightPointDataModel != null)
			{
				this.UpdateFightPointSelectedView(true);
				this._onFightPointButtonClickAction(this._fightPointDataModel);
			}
		}

		// Token: 0x06011ED0 RID: 73424 RVA: 0x0053E58A File Offset: 0x0053C98A
		public void UpdateFightPointSelectedView(bool flag)
		{
			this.UpdateFightPointName(flag);
			if (this.fightPointSelectedRoot == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.fightPointSelectedRoot, flag);
		}

		// Token: 0x06011ED1 RID: 73425 RVA: 0x0053E5B1 File Offset: 0x0053C9B1
		private void UpdateFightPointName(bool isSelected = false)
		{
			CommonUtility.UpdateTextVisible(this.fightPointNormalNameText, !isSelected);
		}

		// Token: 0x06011ED2 RID: 73426 RVA: 0x0053E5C2 File Offset: 0x0053C9C2
		public TeamDuplicationFightPointDataModel GetFightPointDataModel()
		{
			return this._fightPointDataModel;
		}

		// Token: 0x06011ED3 RID: 73427 RVA: 0x0053E5CC File Offset: 0x0053C9CC
		private TeamDuplicationFightPointRebornStatusControl LoadFightPointRebornStatusView(GameObject contentRoot)
		{
			GameObject gameObject = CommonUtility.LoadGameObject(contentRoot);
			if (gameObject == null)
			{
				return null;
			}
			return gameObject.GetComponent<TeamDuplicationFightPointRebornStatusControl>();
		}

		// Token: 0x06011ED4 RID: 73428 RVA: 0x0053E5F8 File Offset: 0x0053C9F8
		private TeamDuplicationFightPointEnergyAccumulationStatusControl LoadFightPointEnergyAccumulationStatusView(GameObject contentRoot)
		{
			GameObject gameObject = CommonUtility.LoadGameObject(contentRoot);
			if (gameObject == null)
			{
				return null;
			}
			return gameObject.GetComponent<TeamDuplicationFightPointEnergyAccumulationStatusControl>();
		}

		// Token: 0x06011ED5 RID: 73429 RVA: 0x0053E624 File Offset: 0x0053CA24
		private GameObject LoadFightPointUrgentStatusView(GameObject contentRoot)
		{
			return CommonUtility.LoadGameObject(contentRoot);
		}

		// Token: 0x06011ED6 RID: 73430 RVA: 0x0053E63C File Offset: 0x0053CA3C
		private TeamDuplicationFightPointUnlockStatusControl LoadFightPointUnlockStatusView(GameObject contentRoot)
		{
			GameObject gameObject = CommonUtility.LoadGameObject(contentRoot);
			if (gameObject == null)
			{
				return null;
			}
			return gameObject.GetComponent<TeamDuplicationFightPointUnlockStatusControl>();
		}

		// Token: 0x06011ED7 RID: 73431 RVA: 0x0053E668 File Offset: 0x0053CA68
		private TeamDuplicationFightPointBossBloodControl LoadFightPointBossBloodView(GameObject bossBloodRoot)
		{
			GameObject gameObject = CommonUtility.LoadGameObject(bossBloodRoot);
			if (gameObject == null)
			{
				return null;
			}
			return gameObject.GetComponent<TeamDuplicationFightPointBossBloodControl>();
		}

		// Token: 0x06011ED8 RID: 73432 RVA: 0x0053E694 File Offset: 0x0053CA94
		private void OnReceiveTeamDuplicationFightPointEnergyAccumulationTimeMessage(UIEvent uiEvent)
		{
			if (this._fightPointDataModel == null)
			{
				return;
			}
			if (this._teamCopyFieldTable == null)
			{
				return;
			}
			if (this._fightPointDataModel.FightPointStatusType != TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_ENERGY_REVIVE)
			{
				return;
			}
			if (this._fightPointEnergyAccumulationStatusControl != null)
			{
				this._fightPointEnergyAccumulationStatusControl.UpdateStatusView();
			}
		}

		// Token: 0x06011ED9 RID: 73433 RVA: 0x0053E6E7 File Offset: 0x0053CAE7
		private void OnReceiveTeamDuplicationFightPointBossDataMessage(UIEvent uiEvent)
		{
			if (this._fightPointDataModel == null)
			{
				return;
			}
			if (this._teamCopyFieldTable == null)
			{
				return;
			}
			if (this._teamCopyFieldTable.PresentedType != TeamCopyFieldTable.ePresentedType.BossFightPoint)
			{
				return;
			}
			this.UpdateFightPointBossItemView();
		}

		// Token: 0x06011EDA RID: 73434 RVA: 0x0053E71C File Offset: 0x0053CB1C
		private void OnReceiveTeamDuplicationFightPointUnlockRateMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			int fightPointId = (int)uiEvent.Param1;
			this.UpdateFightPointUnlockRateByFightPointId(fightPointId);
		}

		// Token: 0x06011EDB RID: 73435 RVA: 0x0053E74E File Offset: 0x0053CB4E
		private void UpdateFightPointUnlockRateByFightPointId(int fightPointId)
		{
			if (this._fightPointDataModel == null)
			{
				return;
			}
			if (this._fightPointDataModel.FightPointId != fightPointId)
			{
				return;
			}
			if (this._fightPointDataModel.FightPointStatusType != TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_UNLOCKING)
			{
				return;
			}
			this.UpdateFightPointStatusView();
		}

		// Token: 0x0400BAC1 RID: 47809
		private bool _isTeamDuplicationFightPointStatusChanged;

		// Token: 0x0400BAC2 RID: 47810
		private bool _isTeamDuplicationFightPointIdChanged;

		// Token: 0x0400BAC3 RID: 47811
		private TeamDuplicationFightPointDataModel _fightPointDataModel;

		// Token: 0x0400BAC4 RID: 47812
		private TeamCopyFieldTable _teamCopyFieldTable;

		// Token: 0x0400BAC5 RID: 47813
		private int _fightPointCurrentBossPhase;

		// Token: 0x0400BAC6 RID: 47814
		private OnFightPointButtonClickAction _onFightPointButtonClickAction;

		// Token: 0x0400BAC7 RID: 47815
		private TeamDuplicationFightPointRebornStatusControl _fightPointRebornStatusControl;

		// Token: 0x0400BAC8 RID: 47816
		private GameObject _fightPointUrgentStatusGameObject;

		// Token: 0x0400BAC9 RID: 47817
		private TeamDuplicationFightPointUnlockStatusControl _fightPointUnlockStatusControl;

		// Token: 0x0400BACA RID: 47818
		private TeamDuplicationFightPointEnergyAccumulationStatusControl _fightPointEnergyAccumulationStatusControl;

		// Token: 0x0400BACB RID: 47819
		private TeamDuplicationFightPointBossBloodControl _fightPointBossBloodControl;

		// Token: 0x0400BACC RID: 47820
		[Space(10f)]
		[Header("Normal")]
		[Space(5f)]
		[SerializeField]
		private Text fightPointNormalNameText;

		// Token: 0x0400BACD RID: 47821
		[SerializeField]
		private Text fightPointSelectedNameText;

		// Token: 0x0400BACE RID: 47822
		[SerializeField]
		private Button fightPointButton;

		// Token: 0x0400BACF RID: 47823
		[SerializeField]
		private GameObject fightPointSelectedRoot;

		// Token: 0x0400BAD0 RID: 47824
		[Space(15f)]
		[Header("NormalFightPoint")]
		[Space(15f)]
		[SerializeField]
		private GameObject normalBg;

		// Token: 0x0400BAD1 RID: 47825
		[SerializeField]
		private Image normalIcon;

		// Token: 0x0400BAD2 RID: 47826
		[SerializeField]
		private GameObject selectedBg;

		// Token: 0x0400BAD3 RID: 47827
		[SerializeField]
		private Image selectedIcon;

		// Token: 0x0400BAD4 RID: 47828
		[Space(15f)]
		[Header("BossFightPoint")]
		[Space(15f)]
		[SerializeField]
		private Image bossNormalIcon;

		// Token: 0x0400BAD5 RID: 47829
		[SerializeField]
		private Image bossSelectedIcon;

		// Token: 0x0400BAD6 RID: 47830
		[Space(10f)]
		[Header("TeamAndNumberControl")]
		[Space(5f)]
		[SerializeField]
		private TeamDuplicationFightPointTeamAndNumberControl teamAndNumberControl;

		// Token: 0x0400BAD7 RID: 47831
		[Space(10f)]
		[Header("Status")]
		[Space(5f)]
		[SerializeField]
		private GameObject rebornStatusRoot;

		// Token: 0x0400BAD8 RID: 47832
		[SerializeField]
		private GameObject urgentStatusRoot;

		// Token: 0x0400BAD9 RID: 47833
		[SerializeField]
		private GameObject unlockStatusRoot;

		// Token: 0x0400BADA RID: 47834
		[SerializeField]
		private GameObject energyAccumulationStatusRoot;

		// Token: 0x0400BADB RID: 47835
		[Space(10f)]
		[Header("BossPoint")]
		[Space(5f)]
		[SerializeField]
		private GameObject bossBloodStatusRoot;
	}
}
