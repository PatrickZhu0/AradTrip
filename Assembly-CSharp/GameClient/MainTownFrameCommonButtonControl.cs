using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001763 RID: 5987
	public class MainTownFrameCommonButtonControl : MonoBehaviour
	{
		// Token: 0x0600EC3C RID: 60476 RVA: 0x003F05C7 File Offset: 0x003EE9C7
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600EC3D RID: 60477 RVA: 0x003F05CF File Offset: 0x003EE9CF
		private void OnDestroy()
		{
			this.UnBindEvents();
			this._isInit = false;
			this._championshipBubbleTipView = null;
		}

		// Token: 0x0600EC3E RID: 60478 RVA: 0x003F05E5 File Offset: 0x003EE9E5
		private void OnEnable()
		{
			if (!this._isInit)
			{
				this._isInit = true;
			}
			else
			{
				this.UpdateMainTownFrameCommonButtonControl();
			}
		}

		// Token: 0x0600EC3F RID: 60479 RVA: 0x003F0604 File Offset: 0x003EEA04
		private void BindEvents()
		{
			if (this.activityWeekSignInButton != null)
			{
				this.activityWeekSignInButton.onClick.RemoveAllListeners();
				this.activityWeekSignInButton.onClick.AddListener(new UnityAction(this.OnActivityWeekSignInClick));
			}
			if (this.newPlayerWeekSignInButton != null)
			{
				this.newPlayerWeekSignInButton.onClick.RemoveAllListeners();
				this.newPlayerWeekSignInButton.onClick.AddListener(new UnityAction(this.OnNewPlayerWeekSignInClick));
			}
			if (this.championshipButton != null)
			{
				this.championshipButton.onClick.RemoveAllListeners();
				this.championshipButton.onClick.AddListener(new UnityAction(this.OnChampionshipButtonClick));
			}
			if (this.championshipActivityBtn != null)
			{
				this.championshipActivityBtn.onClick.RemoveAllListeners();
				this.championshipActivityBtn.onClick.AddListener(new UnityAction(this.OnChampionshipActivityBtnClick));
			}
			if (this.coinDealButton != null)
			{
				this.coinDealButton.onClick.RemoveAllListeners();
				this.coinDealButton.onClick.AddListener(new UnityAction(this.OnCoinDealButtonClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnActivityWeekSignInRedPointChanged, new ClientEventSystem.UIEventHandler(this.OnActivityWeekSignInStatusUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnNewPlayerWeekSignInRedPointChanged, new ClientEventSystem.UIEventHandler(this.OnNewPlayerWeekSignInStatusUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationServerFuncSwitchChangeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationServerFuncSwitchChangeMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NewFuncUnlock, new ClientEventSystem.UIEventHandler(this.OnReceiveNewFuncUnLockMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateUnlockFunc, new ClientEventSystem.UIEventHandler(this.OnUpdateUnlockFuncMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipStatusMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipStatusMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipSelfStatusMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipStatusMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityLimitTimeDataUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeTaskDataUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityLimitTimeTaskDataUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.OnPlayerLevelChangeMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealUpdateRedPointMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealUpdateRedPointMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealServerFuncSwitchChangeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealServerFuncSwitchChangeMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityUpdateByActivityName, new ClientEventSystem.UIEventHandler(this.OnReceiveActivityUpdateByActivityNameMessage));
		}

		// Token: 0x0600EC40 RID: 60480 RVA: 0x003F08A0 File Offset: 0x003EECA0
		private void UnBindEvents()
		{
			if (this.activityWeekSignInButton != null)
			{
				this.activityWeekSignInButton.onClick.RemoveAllListeners();
			}
			if (this.newPlayerWeekSignInButton != null)
			{
				this.newPlayerWeekSignInButton.onClick.RemoveAllListeners();
			}
			if (this.championshipButton != null)
			{
				this.championshipButton.onClick.RemoveAllListeners();
			}
			if (this.coinDealButton != null)
			{
				this.coinDealButton.onClick.RemoveAllListeners();
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnActivityWeekSignInRedPointChanged, new ClientEventSystem.UIEventHandler(this.OnActivityWeekSignInStatusUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnNewPlayerWeekSignInRedPointChanged, new ClientEventSystem.UIEventHandler(this.OnNewPlayerWeekSignInStatusUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationServerFuncSwitchChangeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationServerFuncSwitchChangeMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NewFuncUnlock, new ClientEventSystem.UIEventHandler(this.OnReceiveNewFuncUnLockMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateUnlockFunc, new ClientEventSystem.UIEventHandler(this.OnUpdateUnlockFuncMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipStatusMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipStatusMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipSelfStatusMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipStatusMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityLimitTimeDataUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeTaskDataUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityLimitTimeTaskDataUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.OnPlayerLevelChangeMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealUpdateRedPointMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealUpdateRedPointMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealServerFuncSwitchChangeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealServerFuncSwitchChangeMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityUpdateByActivityName, new ClientEventSystem.UIEventHandler(this.OnReceiveActivityUpdateByActivityNameMessage));
		}

		// Token: 0x0600EC41 RID: 60481 RVA: 0x003F0A8D File Offset: 0x003EEE8D
		public void UpdateMainTownFrameCommonButtonControl()
		{
			this.UpdateNewPlayerWeekSignInStatus();
			this.UpdateActivityWeekSignInStatus();
			this.UpdateTeamDuplicationStatus();
			this.UpdateChampionshipStatus();
			this.UpdateChampionshipActivityStatus();
			this.UpdateChampionshipRedPoint();
			this.UpdateCoinDealStatus(false);
		}

		// Token: 0x0600EC42 RID: 60482 RVA: 0x003F0ABA File Offset: 0x003EEEBA
		private void OnActivityWeekSignInStatusUpdate(UIEvent uiEvent)
		{
			this.UpdateActivityWeekSignInStatus();
		}

		// Token: 0x0600EC43 RID: 60483 RVA: 0x003F0AC2 File Offset: 0x003EEEC2
		private void OnNewPlayerWeekSignInStatusUpdate(UIEvent uiEvent)
		{
			this.UpdateNewPlayerWeekSignInStatus();
		}

		// Token: 0x0600EC44 RID: 60484 RVA: 0x003F0ACA File Offset: 0x003EEECA
		private void OnReceiveTeamDuplicationServerFuncSwitchChangeMessage(UIEvent uiEvent)
		{
			this.UpdateTeamDuplicationStatus();
		}

		// Token: 0x0600EC45 RID: 60485 RVA: 0x003F0AD2 File Offset: 0x003EEED2
		private void OnUpdateUnlockFuncMessage(UIEvent uiEvent)
		{
			this.UpdateTeamDuplicationStatus();
		}

		// Token: 0x0600EC46 RID: 60486 RVA: 0x003F0ADC File Offset: 0x003EEEDC
		private void OnReceiveNewFuncUnLockMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			FunctionUnLock.eFuncType eFuncType = (FunctionUnLock.eFuncType)uiEvent.Param2;
			if (eFuncType != FunctionUnLock.eFuncType.TeamCopy)
			{
				return;
			}
			this.UpdateTeamDuplicationStatus();
		}

		// Token: 0x0600EC47 RID: 60487 RVA: 0x003F0B21 File Offset: 0x003EEF21
		private void OnReceiveChampionshipStatusMessage(UIEvent uiEvent)
		{
			this.UpdateChampionshipStatus();
		}

		// Token: 0x0600EC48 RID: 60488 RVA: 0x003F0B2C File Offset: 0x003EEF2C
		private void OnActivityLimitTimeDataUpdate(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			if (num == (uint)DataManager<ActivityDataManager>.GetInstance().GetActiveIdFromType(ActivityLimitTimeFactory.EActivityType.OAT_CHAMPIOSHIPGIFTBAGACTIVITY))
			{
				this.UpdateChampionshipActivityStatus();
			}
		}

		// Token: 0x0600EC49 RID: 60489 RVA: 0x003F0B72 File Offset: 0x003EEF72
		private void OnActivityLimitTimeTaskDataUpdate(UIEvent uiEvent)
		{
			this.UpdateChampionshipRedPoint();
		}

		// Token: 0x0600EC4A RID: 60490 RVA: 0x003F0B7A File Offset: 0x003EEF7A
		private void OnReceiveCoinDealServerFuncSwitchChangeMessage(UIEvent uiEvent)
		{
			this.UpdateCoinDealStatus(true);
		}

		// Token: 0x0600EC4B RID: 60491 RVA: 0x003F0B83 File Offset: 0x003EEF83
		private void OnReceiveCoinDealUpdateRedPointMessage(UIEvent uiEvent)
		{
			this.UpdateCoinDealRedPoint();
		}

		// Token: 0x0600EC4C RID: 60492 RVA: 0x003F0B8C File Offset: 0x003EEF8C
		private void OnReceiveActivityUpdateByActivityNameMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			string text = (string)uiEvent.Param1;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			if (text.Equals("GoldConsignment"))
			{
				this.UpdateCoinDealStatus(true);
			}
		}

		// Token: 0x0600EC4D RID: 60493 RVA: 0x003F0BDC File Offset: 0x003EEFDC
		private void UpdateNewPlayerWeekSignInStatus()
		{
			bool flag = WeekSignInUtility.IsWeekSignInVisibleByWeekSignInType(WeekSignInType.NewPlayerWeekSignIn);
			if (this.newPlayerWeekSignInRoot != null)
			{
				if (flag)
				{
					this.newPlayerWeekSignInRoot.CustomActive(true);
				}
				else
				{
					this.newPlayerWeekSignInRoot.CustomActive(false);
				}
			}
			if (flag)
			{
				this.UpdateNewPlayerWeekSignInRedPoint();
			}
		}

		// Token: 0x0600EC4E RID: 60494 RVA: 0x003F0C30 File Offset: 0x003EF030
		private void UpdateNewPlayerWeekSignInRedPoint()
		{
			if (this.newPlayerWeekSignInRedPoint != null)
			{
				if (WeekSignInUtility.IsWeekSignInRedPointVisibleByWeekSignInType(WeekSignInType.NewPlayerWeekSignIn))
				{
					this.newPlayerWeekSignInRedPoint.CustomActive(true);
				}
				else
				{
					this.newPlayerWeekSignInRedPoint.CustomActive(false);
				}
			}
		}

		// Token: 0x0600EC4F RID: 60495 RVA: 0x003F0C6C File Offset: 0x003EF06C
		private void UpdateActivityWeekSignInStatus()
		{
			bool flag = WeekSignInUtility.IsWeekSignInVisibleByWeekSignInType(WeekSignInType.ActivityWeekSignIn);
			if (this.activityWeekSignInRoot != null)
			{
				if (flag)
				{
					this.activityWeekSignInRoot.CustomActive(true);
				}
				else
				{
					this.activityWeekSignInRoot.CustomActive(false);
				}
			}
			if (flag)
			{
				this.UpdateActivityWeekSignInRedPoint();
			}
		}

		// Token: 0x0600EC50 RID: 60496 RVA: 0x003F0CC0 File Offset: 0x003EF0C0
		private void UpdateActivityWeekSignInRedPoint()
		{
			if (this.activityWeekSignInRedPoint != null)
			{
				if (WeekSignInUtility.IsWeekSignInRedPointVisibleByWeekSignInType(WeekSignInType.ActivityWeekSignIn))
				{
					this.activityWeekSignInRedPoint.CustomActive(true);
				}
				else
				{
					this.activityWeekSignInRedPoint.CustomActive(false);
				}
			}
		}

		// Token: 0x0600EC51 RID: 60497 RVA: 0x003F0CFB File Offset: 0x003EF0FB
		public void UpdateTeamDuplicationStatus()
		{
		}

		// Token: 0x0600EC52 RID: 60498 RVA: 0x003F0D00 File Offset: 0x003EF100
		private void UpdateChampionshipStatus()
		{
			if (this.championshipButtonRoot == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.championshipButtonRoot, false);
			if (DataManager<PlayerBaseData>.GetInstance().Level < 30)
			{
				return;
			}
			int championshipScheduleId = DataManager<ChampionshipDataManager>.GetInstance().ChampionshipScheduleId;
			ChampionshipScheduleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChampionshipScheduleTable>(championshipScheduleId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.championshipButtonRoot, true);
			this.UpdateChampionshipBubbleTipView(tableItem);
		}

		// Token: 0x0600EC53 RID: 60499 RVA: 0x003F0D78 File Offset: 0x003EF178
		private void UpdateChampionshipBubbleTipView(ChampionshipScheduleTable scheduleTable)
		{
			if (this.championshipBubbleTipRoot == null)
			{
				return;
			}
			if (!ChampionshipUtility.IsShowChampionshipBubble())
			{
				if (this._championshipBubbleTipView != null)
				{
					this._championshipBubbleTipView.ResetTipView();
				}
				return;
			}
			uint num = 0U;
			if (DataManager<ChampionshipDataManager>.GetInstance().ChampionshipStatusInfo != null)
			{
				num = DataManager<ChampionshipDataManager>.GetInstance().ChampionshipStatusInfo.status;
			}
			uint championshipBubbleShowScheduleStatus = DataManager<ChampionshipDataManager>.GetInstance().ChampionshipBubbleShowScheduleStatus;
			if (num == championshipBubbleShowScheduleStatus)
			{
				return;
			}
			DataManager<ChampionshipDataManager>.GetInstance().ChampionshipBubbleShowScheduleStatus = num;
			ChampionStatus championStatus = (ChampionStatus)num;
			string tipStr = scheduleTable.ScheduleTitle;
			if (championStatus >= ChampionStatus.CS_PREPARE_BEGIN && championStatus <= ChampionStatus.CS_PREPARE_END)
			{
				tipStr = scheduleTable.SchedulePreTitle;
			}
			if (this._championshipBubbleTipView == null)
			{
				GameObject gameObject = CommonUtility.LoadGameObject(this.championshipBubbleTipRoot);
				if (gameObject != null)
				{
					this._championshipBubbleTipView = gameObject.GetComponent<ChampionshipBubbleTipView>();
				}
			}
			if (this._championshipBubbleTipView != null)
			{
				this._championshipBubbleTipView.InitTipView(tipStr);
			}
		}

		// Token: 0x0600EC54 RID: 60500 RVA: 0x003F0E74 File Offset: 0x003EF274
		private void UpdateChampionshipActivityStatus()
		{
			if (this.championshipActivityBtnRoot == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.championshipActivityBtnRoot, false);
			bool flag = DataManager<ActivityDataManager>.GetInstance().CheckChampionshipActivityIsOpen();
			if (flag)
			{
				CommonUtility.UpdateGameObjectVisible(this.championshipActivityBtnRoot, true);
			}
		}

		// Token: 0x0600EC55 RID: 60501 RVA: 0x003F0EBC File Offset: 0x003EF2BC
		private void UpdateChampionshipRedPoint()
		{
			if (this.championshipActivityRedPoint == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.championshipActivityRedPoint, false);
			bool flag = DataManager<ActivityDataManager>.GetInstance().ChampionshipActivityIsShowRedPoint();
			if (flag)
			{
				CommonUtility.UpdateGameObjectVisible(this.championshipActivityRedPoint, true);
			}
		}

		// Token: 0x0600EC56 RID: 60502 RVA: 0x003F0F04 File Offset: 0x003EF304
		private void UpdateCoinDealStatus(bool isCloseCoinDealRelationFrame = false)
		{
			if (!CoinDealUtility.IsCoinDealOpenByServer())
			{
				CommonUtility.UpdateGameObjectVisible(this.coinDealRoot, false);
				if (isCloseCoinDealRelationFrame)
				{
					CoinDealUtility.OnCloseCoinDealRelationFrameBySwitchClose();
				}
				return;
			}
			ActivityInfo activityInfo = DataManager<ActiveManager>.GetInstance().GetActivityInfo("GoldConsignment");
			if (activityInfo == null || activityInfo.state != 1)
			{
				CommonUtility.UpdateGameObjectVisible(this.coinDealRoot, false);
				if (isCloseCoinDealRelationFrame)
				{
					CoinDealUtility.OnCloseCoinDealRelationFrameBySwitchClose();
				}
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.coinDealRoot, true);
			this.UpdateCoinDealRedPoint();
		}

		// Token: 0x0600EC57 RID: 60503 RVA: 0x003F0F84 File Offset: 0x003EF384
		private void UpdateCoinDealRedPoint()
		{
			if (this.coinDealRedPoint == null)
			{
				return;
			}
			if (!this.coinDealRedPoint.activeInHierarchy)
			{
				return;
			}
			bool isCoinDealShowRedPoint = DataManager<CoinDealDataManager>.GetInstance().IsCoinDealShowRedPoint;
			CommonUtility.UpdateGameObjectVisible(this.coinDealRedPoint, isCoinDealShowRedPoint);
		}

		// Token: 0x0600EC58 RID: 60504 RVA: 0x003F0FCB File Offset: 0x003EF3CB
		private void OnPlayerLevelChangeMessage(UIEvent uiEvent)
		{
			this.UpdateChampionshipStatus();
		}

		// Token: 0x0600EC59 RID: 60505 RVA: 0x003F0FD3 File Offset: 0x003EF3D3
		private void OnActivityWeekSignInClick()
		{
			WeekSignInUtility.OpenActiveFrameByActivityWeekSignIn();
		}

		// Token: 0x0600EC5A RID: 60506 RVA: 0x003F0FDA File Offset: 0x003EF3DA
		private void OnNewPlayerWeekSignInClick()
		{
			WeekSignInUtility.OpenActiveFrameByNewPlayerWeekSignIn();
		}

		// Token: 0x0600EC5B RID: 60507 RVA: 0x003F0FE1 File Offset: 0x003EF3E1
		private void OnChampionshipButtonClick()
		{
			ChampionshipUtility.OnOpenChampionshipEntranceFrame();
		}

		// Token: 0x0600EC5C RID: 60508 RVA: 0x003F0FE8 File Offset: 0x003EF3E8
		private void OnChampionshipActivityBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChampionshipGiftbagActivityFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600EC5D RID: 60509 RVA: 0x003F0FFC File Offset: 0x003EF3FC
		private void OnCoinDealButtonClick()
		{
			CoinDealUtility.OnOpenCoinDealFrame();
		}

		// Token: 0x04008F93 RID: 36755
		private bool _isInit;

		// Token: 0x04008F94 RID: 36756
		private ChampionshipBubbleTipView _championshipBubbleTipView;

		// Token: 0x04008F95 RID: 36757
		[Space(15f)]
		[Header("ActivityWeekSignIn")]
		[Space(15f)]
		[SerializeField]
		private GameObject activityWeekSignInRoot;

		// Token: 0x04008F96 RID: 36758
		[SerializeField]
		private Button activityWeekSignInButton;

		// Token: 0x04008F97 RID: 36759
		[SerializeField]
		private GameObject activityWeekSignInRedPoint;

		// Token: 0x04008F98 RID: 36760
		[Space(15f)]
		[Header("NewPlayerWeekSignIn")]
		[Space(15f)]
		[SerializeField]
		private GameObject newPlayerWeekSignInRoot;

		// Token: 0x04008F99 RID: 36761
		[SerializeField]
		private Button newPlayerWeekSignInButton;

		// Token: 0x04008F9A RID: 36762
		[SerializeField]
		private GameObject newPlayerWeekSignInRedPoint;

		// Token: 0x04008F9B RID: 36763
		[Space(15f)]
		[Header("ChampionButton")]
		[Space(15f)]
		[SerializeField]
		private GameObject championshipButtonRoot;

		// Token: 0x04008F9C RID: 36764
		[SerializeField]
		private Button championshipButton;

		// Token: 0x04008F9D RID: 36765
		[SerializeField]
		private GameObject championshipBubbleTipRoot;

		// Token: 0x04008F9E RID: 36766
		[SerializeField]
		private GameObject championshipActivityBtnRoot;

		// Token: 0x04008F9F RID: 36767
		[SerializeField]
		private Button championshipActivityBtn;

		// Token: 0x04008FA0 RID: 36768
		[SerializeField]
		private GameObject championshipActivityRedPoint;

		// Token: 0x04008FA1 RID: 36769
		[Space(15f)]
		[Header("CoinDeal")]
		[Space(15f)]
		[SerializeField]
		private GameObject coinDealRoot;

		// Token: 0x04008FA2 RID: 36770
		[SerializeField]
		private Button coinDealButton;

		// Token: 0x04008FA3 RID: 36771
		[SerializeField]
		private GameObject coinDealRedPoint;
	}
}
