using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001508 RID: 5384
	public class ChampionshipMainButtonControl : MonoBehaviour
	{
		// Token: 0x0600D10C RID: 53516 RVA: 0x00339614 File Offset: 0x00337A14
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600D10D RID: 53517 RVA: 0x0033961C File Offset: 0x00337A1C
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600D10E RID: 53518 RVA: 0x0033962C File Offset: 0x00337A2C
		private void BindUiEvents()
		{
			if (this.backButton != null)
			{
				this.backButton.onClick.RemoveAllListeners();
				this.backButton.onClick.AddListener(new UnityAction(this.OnBackButtonClick));
			}
			if (this.packageButton != null)
			{
				this.packageButton.onClick.RemoveAllListeners();
				this.packageButton.onClick.AddListener(new UnityAction(this.OnPackageButtonClick));
			}
			if (this.skillButton != null)
			{
				this.skillButton.onClick.RemoveAllListeners();
				this.skillButton.onClick.AddListener(new UnityAction(this.OnSkillButtonClick));
			}
			if (this.menuButton != null)
			{
				this.menuButton.onClick.RemoveAllListeners();
				this.menuButton.onClick.AddListener(new UnityAction(this.OnMenuButtonClick));
			}
			if (this.reliveButton != null)
			{
				this.reliveButton.onClick.RemoveAllListeners();
				this.reliveButton.onClick.AddListener(new UnityAction(this.OnReliveButtonClick));
			}
			if (this.fightWatchButton != null)
			{
				this.fightWatchButton.onClick.RemoveAllListeners();
				this.fightWatchButton.onClick.AddListener(new UnityAction(this.OnFightWatchButtonClick));
			}
		}

		// Token: 0x0600D10F RID: 53519 RVA: 0x003397A8 File Offset: 0x00337BA8
		private void UnBindUiEvents()
		{
			if (this.backButton != null)
			{
				this.backButton.onClick.RemoveAllListeners();
			}
			if (this.packageButton != null)
			{
				this.packageButton.onClick.RemoveAllListeners();
			}
			if (this.skillButton != null)
			{
				this.skillButton.onClick.RemoveAllListeners();
			}
			if (this.menuButton != null)
			{
				this.menuButton.onClick.RemoveAllListeners();
			}
			if (this.reliveButton != null)
			{
				this.reliveButton.onClick.RemoveAllListeners();
			}
			if (this.fightWatchButton != null)
			{
				this.fightWatchButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600D110 RID: 53520 RVA: 0x0033987B File Offset: 0x00337C7B
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipSelfSeaFightResultMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipSelfSeaFightResultMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this.OnReceiveRedPointChangedMessage));
		}

		// Token: 0x0600D111 RID: 53521 RVA: 0x003398B0 File Offset: 0x00337CB0
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipSelfSeaFightResultMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipSelfSeaFightResultMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this.OnReceiveRedPointChangedMessage));
		}

		// Token: 0x0600D112 RID: 53522 RVA: 0x003398E5 File Offset: 0x00337CE5
		private void ClearData()
		{
			this._scheduleTable = null;
			this._reliveStatus = ChampionshipReliveStatus.NotNeedRelive;
		}

		// Token: 0x0600D113 RID: 53523 RVA: 0x003398F5 File Offset: 0x00337CF5
		public void InitControl(ChampionshipScheduleTable scheduleTable)
		{
			if (scheduleTable == null)
			{
				return;
			}
			this._scheduleTable = scheduleTable;
			this.UpdateButtonVisible();
			this.UpdatePackageRedPoint();
			this.UpdateSkillRedPoint();
		}

		// Token: 0x0600D114 RID: 53524 RVA: 0x00339917 File Offset: 0x00337D17
		private void UpdateButtonVisible()
		{
			this.UpdateReliveButtonVisible();
			this.UpdateFightWatchButtonVisible();
		}

		// Token: 0x0600D115 RID: 53525 RVA: 0x00339928 File Offset: 0x00337D28
		private void UpdateReliveButtonVisible()
		{
			if (this.reliveButton == null)
			{
				return;
			}
			if (this._scheduleTable.ScheduleType != ChampionshipScheduleTable.eScheduleType.Sea_Select)
			{
				CommonUtility.UpdateButtonVisible(this.reliveButton, false);
			}
			else
			{
				this._reliveStatus = ChampionshipUtility.GetChampionshipReliveStatus();
				if (this._reliveStatus == ChampionshipReliveStatus.CanRelive)
				{
					CommonUtility.UpdateButtonVisible(this.reliveButton, true);
				}
				else
				{
					CommonUtility.UpdateButtonVisible(this.reliveButton, false);
				}
			}
		}

		// Token: 0x0600D116 RID: 53526 RVA: 0x003399A0 File Offset: 0x00337DA0
		private void UpdateFightWatchButtonVisible()
		{
			if (this.fightWatchButton == null)
			{
				return;
			}
			CommonUtility.UpdateButtonVisible(this.fightWatchButton, false);
			if (this._scheduleTable == null)
			{
				return;
			}
			if (this._scheduleTable.ScheduleType >= ChampionshipScheduleTable.eScheduleType.Eight_Select)
			{
				CommonUtility.UpdateButtonVisible(this.fightWatchButton, true);
			}
		}

		// Token: 0x0600D117 RID: 53527 RVA: 0x003399F4 File Offset: 0x00337DF4
		private void OnReceiveChampionshipSelfSeaFightResultMessage(UIEvent uiEvent)
		{
			this.UpdateReliveButtonVisible();
		}

		// Token: 0x0600D118 RID: 53528 RVA: 0x003399FC File Offset: 0x00337DFC
		private void OnReliveButtonClick()
		{
			if (this._reliveStatus == ChampionshipReliveStatus.NotNeedRelive)
			{
				return;
			}
			if (this._reliveStatus == ChampionshipReliveStatus.AlreadyRelive)
			{
				return;
			}
			ChampionshipUtility.OnOpenChampionshipSeaReliveFrame();
		}

		// Token: 0x0600D119 RID: 53529 RVA: 0x00339A1C File Offset: 0x00337E1C
		private void OnFightWatchButtonClick()
		{
			ChampionshipUtility.OnOpenChampionshipFightRaceFrame(this._scheduleTable.ID);
		}

		// Token: 0x0600D11A RID: 53530 RVA: 0x00339A2E File Offset: 0x00337E2E
		private void OnBackButtonClick()
		{
			ChampionshipUtility.SwitchToBirthCitySceneInClientSystemTown(false);
		}

		// Token: 0x0600D11B RID: 53531 RVA: 0x00339A36 File Offset: 0x00337E36
		private void OnPackageButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PackageNewFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600D11C RID: 53532 RVA: 0x00339A4A File Offset: 0x00337E4A
		private void OnSkillButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SkillTreeFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600D11D RID: 53533 RVA: 0x00339A5E File Offset: 0x00337E5E
		private void OnMenuButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkMenuFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600D11E RID: 53534 RVA: 0x00339A74 File Offset: 0x00337E74
		private void OnReceiveRedPointChangedMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			ERedPoint eredPoint = (ERedPoint)uiEvent.Param1;
			if (eredPoint == ERedPoint.Skill)
			{
				this.UpdateSkillRedPoint();
			}
			else if (eredPoint == ERedPoint.PackageMain)
			{
				this.UpdatePackageRedPoint();
			}
		}

		// Token: 0x0600D11F RID: 53535 RVA: 0x00339AC4 File Offset: 0x00337EC4
		private void UpdatePackageRedPoint()
		{
			bool flag = DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.PackageMain);
			CommonUtility.UpdateGameObjectVisible(this.packageRedPoint, flag);
		}

		// Token: 0x0600D120 RID: 53536 RVA: 0x00339AEC File Offset: 0x00337EEC
		private void UpdateSkillRedPoint()
		{
			bool flag = DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.Skill);
			CommonUtility.UpdateGameObjectVisible(this.skillRedPoint, flag);
		}

		// Token: 0x04007A66 RID: 31334
		private ChampionshipScheduleTable _scheduleTable;

		// Token: 0x04007A67 RID: 31335
		private ChampionshipReliveStatus _reliveStatus;

		// Token: 0x04007A68 RID: 31336
		[Space(10f)]
		[Header("CommonButton")]
		[Space(10f)]
		[SerializeField]
		private Button backButton;

		// Token: 0x04007A69 RID: 31337
		[SerializeField]
		private Button packageButton;

		// Token: 0x04007A6A RID: 31338
		[SerializeField]
		private Button skillButton;

		// Token: 0x04007A6B RID: 31339
		[SerializeField]
		private Button menuButton;

		// Token: 0x04007A6C RID: 31340
		[Space(10f)]
		[Header("RedPoint")]
		[Space(10f)]
		[SerializeField]
		private GameObject packageRedPoint;

		// Token: 0x04007A6D RID: 31341
		[SerializeField]
		private GameObject skillRedPoint;

		// Token: 0x04007A6E RID: 31342
		[Space(10f)]
		[Header("ReliveButton")]
		[Space(10f)]
		[SerializeField]
		private Button reliveButton;

		// Token: 0x04007A6F RID: 31343
		[Space(10f)]
		[Header("FightWatch")]
		[Space(10f)]
		[SerializeField]
		private Button fightWatchButton;
	}
}
