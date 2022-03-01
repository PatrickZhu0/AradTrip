using System;
using System.Reflection;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001766 RID: 5990
	public class TimePlayButton : MonoBehaviour
	{
		// Token: 0x0600EC73 RID: 60531 RVA: 0x003F17B5 File Offset: 0x003EFBB5
		private void Awake()
		{
			this.BindUIEvent();
			this.BindButtonEvent();
		}

		// Token: 0x0600EC74 RID: 60532 RVA: 0x003F17C3 File Offset: 0x003EFBC3
		private void OnDestroy()
		{
			this.UnBindUIEvent();
			this.UnBindButtonEvent();
		}

		// Token: 0x0600EC75 RID: 60533 RVA: 0x003F17D4 File Offset: 0x003EFBD4
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildBattleStateChanged, new ClientEventSystem.UIEventHandler(this.GuildBattleStateChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsStatusChanged, new ClientEventSystem.UIEventHandler(this.OnMoneyRewardsStatusChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PK3V3CrossButton, new ClientEventSystem.UIEventHandler(this.Update3V3PointRaceBtn));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpdateFairDuelEntryState, new ClientEventSystem.UIEventHandler(this.OnUpdateFairDuelEntryState));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityDungeonUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityDungeonUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PK2V2CrossButton, new ClientEventSystem.UIEventHandler(this.Update2V2PointRaceBtn));
			BudoManager instance = DataManager<BudoManager>.GetInstance();
			instance.onBudoInfoChanged = (BudoManager.OnBudoInfoChanged)Delegate.Combine(instance.onBudoInfoChanged, new BudoManager.OnBudoInfoChanged(this.OnBudoInfoChanged));
		}

		// Token: 0x0600EC76 RID: 60534 RVA: 0x003F18AC File Offset: 0x003EFCAC
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildBattleStateChanged, new ClientEventSystem.UIEventHandler(this.GuildBattleStateChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsStatusChanged, new ClientEventSystem.UIEventHandler(this.OnMoneyRewardsStatusChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PK3V3CrossButton, new ClientEventSystem.UIEventHandler(this.Update3V3PointRaceBtn));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpdateFairDuelEntryState, new ClientEventSystem.UIEventHandler(this.OnUpdateFairDuelEntryState));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityDungeonUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityDungeonUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PK2V2CrossButton, new ClientEventSystem.UIEventHandler(this.Update2V2PointRaceBtn));
			BudoManager instance = DataManager<BudoManager>.GetInstance();
			instance.onBudoInfoChanged = (BudoManager.OnBudoInfoChanged)Delegate.Remove(instance.onBudoInfoChanged, new BudoManager.OnBudoInfoChanged(this.OnBudoInfoChanged));
		}

		// Token: 0x0600EC77 RID: 60535 RVA: 0x003F1984 File Offset: 0x003EFD84
		private void BindButtonEvent()
		{
			if (this.mGuildBattleBtn != null)
			{
				this.mGuildBattleBtn.onClick.RemoveAllListeners();
				this.mGuildBattleBtn.onClick.AddListener(new UnityAction(this.OnGuildBattleBtnClick));
			}
			if (this.mBattleMasterBtn != null)
			{
				this.mBattleMasterBtn.onClick.RemoveAllListeners();
				this.mBattleMasterBtn.onClick.AddListener(new UnityAction(this.OnBattleMasterBtnClick));
			}
			if (this.mRewardBattleMasterBtn != null)
			{
				this.mRewardBattleMasterBtn.onClick.RemoveAllListeners();
				this.mRewardBattleMasterBtn.onClick.AddListener(new UnityAction(this.OnRewardBattleMasterBtnClick));
			}
			if (this.mFinalEightVSTableBtn != null)
			{
				this.mFinalEightVSTableBtn.onClick.RemoveAllListeners();
				this.mFinalEightVSTableBtn.onClick.AddListener(new UnityAction(this.OnFinalEightVSTableBtnClick));
			}
			if (this.m3V3PointRaceBtn != null)
			{
				this.m3V3PointRaceBtn.onClick.RemoveAllListeners();
				this.m3V3PointRaceBtn.onClick.AddListener(new UnityAction(this.On3V3PointRaceBtnClick));
			}
			if (this.mGuildDungeonBtn != null)
			{
				this.mGuildDungeonBtn.onClick.RemoveAllListeners();
				this.mGuildDungeonBtn.onClick.AddListener(new UnityAction(this.OnGuildDungeonBtnClick));
			}
			if (this.mCrossServeGuildBattleBtn != null)
			{
				this.mCrossServeGuildBattleBtn.onClick.RemoveAllListeners();
				this.mCrossServeGuildBattleBtn.onClick.AddListener(new UnityAction(this.OnCrossServeGuildBattleBtnClick));
			}
			if (this.mLevelPlayingFieldBtn != null)
			{
				this.mLevelPlayingFieldBtn.onClick.RemoveAllListeners();
				this.mLevelPlayingFieldBtn.onClick.AddListener(new UnityAction(this.OnLevelPlayingFieldBtnClick));
			}
			this.m2V2PointRaceBtn.SafeSetOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<JoinPk2v2CrossFrame>(FrameLayer.Middle, null, string.Empty);
			});
		}

		// Token: 0x0600EC78 RID: 60536 RVA: 0x003F1BA4 File Offset: 0x003EFFA4
		private void UnBindButtonEvent()
		{
			if (this.mGuildBattleBtn != null)
			{
				this.mGuildBattleBtn.onClick.RemoveListener(new UnityAction(this.OnGuildBattleBtnClick));
			}
			if (this.mBattleMasterBtn != null)
			{
				this.mBattleMasterBtn.onClick.RemoveListener(new UnityAction(this.OnBattleMasterBtnClick));
			}
			if (this.mRewardBattleMasterBtn != null)
			{
				this.mRewardBattleMasterBtn.onClick.RemoveListener(new UnityAction(this.OnRewardBattleMasterBtnClick));
			}
			if (this.mFinalEightVSTableBtn != null)
			{
				this.mFinalEightVSTableBtn.onClick.RemoveListener(new UnityAction(this.OnFinalEightVSTableBtnClick));
			}
			if (this.m3V3PointRaceBtn != null)
			{
				this.m3V3PointRaceBtn.onClick.RemoveListener(new UnityAction(this.On3V3PointRaceBtnClick));
			}
			if (this.mGuildDungeonBtn != null)
			{
				this.mGuildDungeonBtn.onClick.RemoveListener(new UnityAction(this.OnGuildDungeonBtnClick));
			}
			if (this.mCrossServeGuildBattleBtn != null)
			{
				this.mCrossServeGuildBattleBtn.onClick.RemoveListener(new UnityAction(this.OnCrossServeGuildBattleBtnClick));
			}
			if (this.mLevelPlayingFieldBtn != null)
			{
				this.mLevelPlayingFieldBtn.onClick.RemoveListener(new UnityAction(this.OnLevelPlayingFieldBtnClick));
			}
			this.m2V2PointRaceBtn = null;
		}

		// Token: 0x0600EC79 RID: 60537 RVA: 0x003F1D20 File Offset: 0x003F0120
		public void InitializeMainUI()
		{
			this.UpdateGuildBattleBtn();
			this.UpdateBattleMasterBtn();
			this.UpdateRewardBattleMasterBtn();
			this.UpdateFinalEightVSTableBtn();
			this.UpdateGuildDungeonBtn();
			this.UpdateCrossServeGuildBattleBtn();
			this.Update3V3PointRaceBtn(new UIEvent
			{
				Param1 = (byte)DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatus()
			});
			this.Update2V2PointRaceBtn(new UIEvent
			{
				Param1 = (byte)DataManager<Pk2v2CrossDataManager>.GetInstance().Get2v2CrossWarStatus()
			});
			this.UpdateLevelPlayingFieldBtn();
		}

		// Token: 0x0600EC7A RID: 60538 RVA: 0x003F1D9D File Offset: 0x003F019D
		private void UpdateGuildBattleBtn()
		{
			this.mGuildBattleBtn.CustomActive(DataManager<GuildDataManager>.GetInstance().IsInGuildBattle());
		}

		// Token: 0x0600EC7B RID: 60539 RVA: 0x003F1DB4 File Offset: 0x003F01B4
		private void UpdateBattleMasterBtn()
		{
			ActivityDungeonSub subByActivityDungeonID = DataManager<ActivityDungeonDataManager>.GetInstance().GetSubByActivityDungeonID(8);
			if (subByActivityDungeonID == null)
			{
				return;
			}
			if (subByActivityDungeonID.activityInfo != null)
			{
				eActivityDungeonState state = subByActivityDungeonID.activityInfo.state;
				this.mBattleMasterBtn.CustomActive(state == eActivityDungeonState.Start);
			}
		}

		// Token: 0x0600EC7C RID: 60540 RVA: 0x003F1DFC File Offset: 0x003F01FC
		private void UpdateRewardBattleMasterBtn()
		{
			ActivityDungeonSub subByActivityDungeonID = DataManager<ActivityDungeonDataManager>.GetInstance().GetSubByActivityDungeonID(20);
			if (subByActivityDungeonID == null)
			{
				return;
			}
			if (subByActivityDungeonID.activityInfo != null)
			{
				eActivityDungeonState state = subByActivityDungeonID.activityInfo.state;
				this.mRewardBattleMasterBtn.CustomActive(state == eActivityDungeonState.Start);
			}
		}

		// Token: 0x0600EC7D RID: 60541 RVA: 0x003F1E43 File Offset: 0x003F0243
		private void UpdateFinalEightVSTableBtn()
		{
			this.mFinalEightVSTableBtn.CustomActive(DataManager<MoneyRewardsDataManager>.GetInstance().Status > PremiumLeagueStatus.PLS_PRELIMINAY);
		}

		// Token: 0x0600EC7E RID: 60542 RVA: 0x003F1E5D File Offset: 0x003F025D
		private void UpdateGuildDungeonBtn()
		{
			this.mGuildDungeonBtn.CustomActive(ActivityDungeonFrame.GetGuildDungeonActivityState() == eActivityDungeonState.Start);
		}

		// Token: 0x0600EC7F RID: 60543 RVA: 0x003F1E72 File Offset: 0x003F0272
		private void UpdateCrossServeGuildBattleBtn()
		{
			this.mCrossServeGuildBattleBtn.CustomActive(ActivityDungeonFrame.GetGuildCrossBattleActivityState() == eActivityDungeonState.Start);
		}

		// Token: 0x0600EC80 RID: 60544 RVA: 0x003F1E87 File Offset: 0x003F0287
		private void UpdateLevelPlayingFieldBtn()
		{
			this.mLevelPlayingFieldBtn.CustomActive(DataManager<FairDuelDataManager>.GetInstance().IsShowFairDuelEnterBtn());
		}

		// Token: 0x0600EC81 RID: 60545 RVA: 0x003F1EA0 File Offset: 0x003F02A0
		private void Update3V3PointRaceBtn(UIEvent uiEvent)
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(450, string.Empty, string.Empty);
			if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.Value)
			{
				this.m3V3PointRaceBtn.CustomActive(false);
				return;
			}
			byte b = (byte)uiEvent.Param1;
			bool bActive = b >= 1 && b < 3;
			this.m3V3PointRaceBtn.CustomActive(bActive);
		}

		// Token: 0x0600EC82 RID: 60546 RVA: 0x003F1F20 File Offset: 0x003F0320
		private void Update2V2PointRaceBtn(UIEvent uiEvent)
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(638, string.Empty, string.Empty);
			if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.Value)
			{
				this.m2V2PointRaceBtn.CustomActive(false);
				return;
			}
			byte b = (byte)uiEvent.Param1;
			bool bActive = b >= 1 && b < 3;
			this.m2V2PointRaceBtn.CustomActive(bActive);
		}

		// Token: 0x0600EC83 RID: 60547 RVA: 0x003F1FA0 File Offset: 0x003F03A0
		private void OnUpdateFairDuelEntryState(UIEvent uiEvent)
		{
			bool bActive = (bool)uiEvent.Param1;
			this.mLevelPlayingFieldBtn.CustomActive(bActive);
		}

		// Token: 0x0600EC84 RID: 60548 RVA: 0x003F1FC5 File Offset: 0x003F03C5
		private void OnActivityDungeonUpdate(UIEvent uiEvent)
		{
			this.UpdateGuildDungeonBtn();
			this.UpdateCrossServeGuildBattleBtn();
			this.UpdateRewardBattleMasterBtn();
			this.UpdateBattleMasterBtn();
		}

		// Token: 0x0600EC85 RID: 60549 RVA: 0x003F1FDF File Offset: 0x003F03DF
		private void GuildBattleStateChanged(UIEvent uiEvent)
		{
			this.UpdateGuildBattleBtn();
		}

		// Token: 0x0600EC86 RID: 60550 RVA: 0x003F1FE7 File Offset: 0x003F03E7
		private void OnMoneyRewardsStatusChanged(UIEvent uiEvent)
		{
			this.UpdateRewardBattleMasterBtn();
			this.UpdateFinalEightVSTableBtn();
		}

		// Token: 0x0600EC87 RID: 60551 RVA: 0x003F1FF5 File Offset: 0x003F03F5
		private void OnBudoInfoChanged()
		{
			this.UpdateBattleMasterBtn();
		}

		// Token: 0x0600EC88 RID: 60552 RVA: 0x003F2000 File Offset: 0x003F0400
		private void OnGuildBattleBtnClick()
		{
			if (DataManager<GuildDataManager>.GetInstance().myGuild != null)
			{
				EGuildBattleState guildBattleState = DataManager<GuildDataManager>.GetInstance().GetGuildBattleState();
				if (guildBattleState >= EGuildBattleState.Preparing && guildBattleState <= EGuildBattleState.Firing)
				{
					if (DataManager<GuildDataManager>.GetInstance().HasTargetManor())
					{
						if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS)
						{
							Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildCrossManorFrame>(FrameLayer.Middle, null, string.Empty);
						}
						else
						{
							Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildManorFrame>(FrameLayer.Middle, null, string.Empty);
						}
					}
					else if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS)
					{
						GuildMyMainFrame.OpenLinkFrame("10");
					}
					else
					{
						GuildMyMainFrame.OpenLinkFrame("8");
					}
					return;
				}
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildListFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600EC89 RID: 60553 RVA: 0x003F20C3 File Offset: 0x003F04C3
		private void OnBattleMasterBtnClick()
		{
			if (!Utility.EnterBudo())
			{
				return;
			}
		}

		// Token: 0x0600EC8A RID: 60554 RVA: 0x003F20D0 File Offset: 0x003F04D0
		private void OnRewardBattleMasterBtnClick()
		{
			MoneyRewardsEnterFrame.CommandOpen(null);
		}

		// Token: 0x0600EC8B RID: 60555 RVA: 0x003F20D8 File Offset: 0x003F04D8
		private void OnFinalEightVSTableBtnClick()
		{
			Type type = typeof(ClientFrame).Assembly.GetType("GameClient.MoneyRewardsResultFrame");
			if (type == null)
			{
				return;
			}
			MethodInfo method = type.GetMethod("CommandOpen");
			if (method == null)
			{
				return;
			}
			method.Invoke(null, new object[1]);
		}

		// Token: 0x0600EC8C RID: 60556 RVA: 0x003F2127 File Offset: 0x003F0527
		private void On3V3PointRaceBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<JoinPK3v3CrossFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600EC8D RID: 60557 RVA: 0x003F213B File Offset: 0x003F053B
		private void OnGuildDungeonBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600EC8E RID: 60558 RVA: 0x003F214F File Offset: 0x003F054F
		private void OnCrossServeGuildBattleBtnClick()
		{
			GuildMyMainFrame.OpenLinkFrame("14");
		}

		// Token: 0x0600EC8F RID: 60559 RVA: 0x003F215C File Offset: 0x003F055C
		private void OnLevelPlayingFieldBtnClick()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			PkWaitingRoomData userData = new PkWaitingRoomData
			{
				CurrentSceneID = clientSystemTown.CurrentSceneID,
				TargetTownSceneID = 6033,
				SceneSubType = CitySceneTable.eSceneSubType.FairDuelPrepare
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FairDuelEntranceFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x04008FC6 RID: 36806
		[SerializeField]
		private Button mGuildBattleBtn;

		// Token: 0x04008FC7 RID: 36807
		[SerializeField]
		private Button mBattleMasterBtn;

		// Token: 0x04008FC8 RID: 36808
		[SerializeField]
		private Button mRewardBattleMasterBtn;

		// Token: 0x04008FC9 RID: 36809
		[SerializeField]
		private Button mFinalEightVSTableBtn;

		// Token: 0x04008FCA RID: 36810
		[SerializeField]
		private Button mGuildDungeonBtn;

		// Token: 0x04008FCB RID: 36811
		[SerializeField]
		private Button mCrossServeGuildBattleBtn;

		// Token: 0x04008FCC RID: 36812
		[SerializeField]
		private Button m3V3PointRaceBtn;

		// Token: 0x04008FCD RID: 36813
		[SerializeField]
		private Button mLevelPlayingFieldBtn;

		// Token: 0x04008FCE RID: 36814
		[SerializeField]
		private Button m2V2PointRaceBtn;
	}
}
