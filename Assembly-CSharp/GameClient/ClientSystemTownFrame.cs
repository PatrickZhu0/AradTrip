using System;
using System.Collections;
using System.Collections.Generic;
using ActivityLimitTime;
using AdsPush;
using DG.Tweening;
using GameClient.ActivityTreasureLottery;
using LimitTimeGift;
using MobileBind;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001754 RID: 5972
	internal class ClientSystemTownFrame : ClientFrame
	{
		// Token: 0x0600EAA5 RID: 60069 RVA: 0x003E3AC1 File Offset: 0x003E1EC1
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MainFrameTown/MainTownFrame";
		}

		// Token: 0x0600EAA6 RID: 60070 RVA: 0x003E3AC8 File Offset: 0x003E1EC8
		protected sealed override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this.InitData();
			this.InitJoystick();
			this.InitTalk();
			this.InitFilters();
			if (null != this.comFuntion)
			{
				this.comFuntion.Initialize();
			}
			this.BindUIEvent();
			this.InitTAPGraduationEffect();
			this.isTownSceneLoadFinish = false;
			DataManager<SkillDataManager>.GetInstance().ClearChijiSkill();
			this.CheckItemCountInAutoFightTest();
		}

		// Token: 0x0600EAA7 RID: 60071 RVA: 0x003E3B34 File Offset: 0x003E1F34
		protected sealed override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
			this.UnloadInput();
			this.ClearData();
			this.InitTAPGraduationEffect();
			if (null != this.comFuntion)
			{
				this.comFuntion.UnInitialize();
				this.comFuntion = null;
			}
			base._OnCloseFrame();
			InvokeMethod.RemovePerFrameCall(this);
			this.unlockEffectList.Clear();
			this._ClearAdventureTeamFuncUnlockCoroutine();
			this._ClearAdventurePassSeasonFuncUnlockCoroutine();
			ClientSystemTownFrame.IsShowSkillTips = false;
			ClientSystemTownFrame.IsShowGuildTips = false;
			ClientSystemTownFrame.IsShowEquipHandBookTips = false;
			this.isTownSceneLoadFinish = false;
			InvokeMethod.RemoveInvokeCall(new UnityAction(this.PlayAdventurePassSeasonFuncUnlockAnim));
		}

		// Token: 0x0600EAA8 RID: 60072 RVA: 0x003E3BCC File Offset: 0x003E1FCC
		protected void ClearData()
		{
			this.mLastJoyStickFizzyCheck = false;
			this.mLastJoyStickPosition = Vector2.zero;
			this.mIsStopMoveFunction = false;
			this.DayOnlineInterval = 0f;
			this.TimeFreshInterval = 0f;
			this.BatteryFreshInterval = 0f;
			this.PrivateCustomBubbleTime = 0f;
			if (this._inputManager != null)
			{
				this._inputManager = null;
			}
			if (this.m_miniTalk != null)
			{
				ComTalk.Recycle();
				this.m_miniTalk = null;
			}
			this.ChangeJobSelectID = 0;
			this.bNeedSwitchToChijiPrepare = false;
			if (this.mBtEquipForge != null)
			{
				DOTweenAnimation component = this.mBtEquipForge.GetComponent<DOTweenAnimation>();
				if (component != null && component.onComplete != null)
				{
					component.onComplete.RemoveAllListeners();
				}
			}
			this._ClearTownMap();
		}

		// Token: 0x0600EAA9 RID: 60073 RVA: 0x003E3CA0 File Offset: 0x003E20A0
		public void SceneLoadFinish()
		{
			this.OnSceneLoadFinish();
		}

		// Token: 0x0600EAAA RID: 60074 RVA: 0x003E3CA8 File Offset: 0x003E20A8
		protected sealed override void OnSceneLoadFinish()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				Logger.LogErrorFormat("排查主界面角色信息未初始化原因1", new object[0]);
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("排查主界面角色信息未初始化原因2--CurrentSceneID = {0}", new object[]
				{
					clientSystemTown.CurrentSceneID
				});
				return;
			}
			clientSystemTown.AddVoiceListenerForAllNpc();
			Singleton<ClientSystemManager>.GetInstance().bIsInPkWaitingRoom = false;
			if (tableItem.SceneType == CitySceneTable.eSceneType.PK_PREPARE)
			{
				if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.TRADITION)
				{
					this.UpdatePkWaitingRoom(tableItem);
				}
				else if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.BUDO)
				{
					this.UpdateBudo(tableItem);
				}
				else if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.MoneyRewards)
				{
					MoneyRewardsMainFrame.CommandOpen(new MoneyRewardsMainFrameData
					{
						citySceneItem = tableItem,
						CurrentSceneID = tableItem.ID,
						TargetTownSceneID = tableItem.BirthCity
					});
				}
				else if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.GuildBattle || tableItem.SceneSubType == CitySceneTable.eSceneSubType.CrossGuildBattle)
				{
					this.UpdateGuildBattle();
				}
				else if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.Pk3v3)
				{
					this.UpdatePk3v3WaitingRoom(tableItem);
				}
				else if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.CrossPk3v3)
				{
					this.UpdatePk3v3CrossWaitingRoom(tableItem);
				}
				else if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.FairDuelPrepare)
				{
					this.UpdateFairBattleWaitingRoom(tableItem);
					this.mIsCanShowGiftFrame = false;
				}
				else if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.Melee2v2Cross)
				{
					this.UpdatePk2v2CrossWaitingRoom(tableItem);
				}
				this.InitializeMainUI();
			}
			else if (tableItem.SceneType == CitySceneTable.eSceneType.TEAMDUPLICATION)
			{
				if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationBuid)
				{
					this.UpdateTeamDuplicationBuildFrame(tableItem);
				}
				else if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationFight)
				{
					this.UpdateTeamDuplicationFightFrame(tableItem);
				}
				this.mIsCanShowGiftFrame = false;
				this.InitializeMainUI();
			}
			else if (tableItem.SceneType == CitySceneTable.eSceneType.CHAMPIONSHIP)
			{
				base.SetForbidFadeIn(true);
				if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChampionshipMainFrame>(null))
				{
					ChampionshipUtility.OnOpenChampionshipMainFrame();
				}
				this.mIsCanShowGiftFrame = false;
				this.InitializeMainUI();
			}
			else if (tableItem.SceneType == CitySceneTable.eSceneType.NORMAL && tableItem.SceneSubType == CitySceneTable.eSceneSubType.Guild)
			{
				this.UpdateGuildArenaFrame(tableItem);
				this.InitializeMainUI();
			}
			else if (tableItem.SceneType == CitySceneTable.eSceneType.BATTLEPEPARE)
			{
				this.bNeedSwitchToChijiPrepare = true;
			}
			else
			{
				base.SetForbidFadeIn(false);
				base.FadeInSpecial(true);
				this.InitializeMainUI();
				if (Singleton<ClientSystemManager>.GetInstance().PreSystemType == typeof(ClientSystemLogin))
				{
					Singleton<LoginPushManager>.GetInstance().Callback = new LoginPushManager.FinishCallBack(this._StartOpenFollowingQueue);
					Singleton<LoginPushManager>.GetInstance().TryOpenLoginPushFrame();
				}
				if (Singleton<ClientSystemManager>.GetInstance().PreSystemType == typeof(ClientSystemBattle))
				{
					Singleton<MonthCardTipManager>.instance.TryOpenMonthCardTipFrameByCond(DataManager<PlayerBaseData>.GetInstance().RoleID);
				}
			}
			this._OnMailListReq();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SkillLvUpNoticeUpdate, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FinancialPlanButtonUpdateByLogin, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SecurityLockApplyStateButton, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildDungeonAuctionStateUpdate, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildDungeonWorldAuctionStateUpdate, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildDungeonAuctionAddNewItem, null, null, null, null);
			Utility.SetInitTownSystemState();
			DataManager<ActivityManager>.GetInstance().RequestGiftDatas();
			if (Singleton<ClientSystemManager>.GetInstance().PreSystemType == typeof(ClientSystemLogin))
			{
				Singleton<SDKVoiceManager>.GetInstance().LoginVoice(Singleton<SDKVoiceManager>.GetInstance().localPlayerVoiceId, ClientApplication.playerinfo.openuid, string.Empty);
			}
			if (Singleton<ClientSystemManager>.GetInstance().PreSystemType == typeof(ClientSystemLogin) && !DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_SECURITY_LOCK))
			{
				DataManager<SecurityLockDataManager>.GetInstance().SendWorldSecurityLockDataReq();
			}
			if (DataManager<ChijiDataManager>.GetInstance().SwitchingPrepareToTown)
			{
				DataManager<PlayerBaseData>.GetInstance().bLevelUpChange = false;
				DataManager<ChijiDataManager>.GetInstance().SwitchingPrepareToTown = false;
			}
			this.mIsCanShowGiftFrame = true;
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager != null && DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.PetPushFrameIsOpen)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.OpenLimitTimePetGiftFrame(DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.GetPetPushItemInfo());
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.PetPushFrameIsOpen = false;
			}
			DataManager<TopUpPushDataManager>.GetInstance().SendWorldGetRechargePushItemsReq();
			DataManager<HeadPortraitFrameDataManager>.GetInstance().OnSendSceneHeadFrameReq();
			DataManager<MonthCardRewardLockersDataManager>.GetInstance().ReqMonthCardRewardLockersItems();
			if (DataManager<AdventureTeamDataManager>.GetInstance().BFuncOpened)
			{
				DataManager<AdventureTeamDataManager>.GetInstance().ReqExpeditionAllMapInfo();
				DataManager<AdventureTeamDataManager>.GetInstance().ReqGetAllExpeditionMaps();
			}
			DataManager<DailyTodoDataManager>.GetInstance().ReqDailyTodoFunctionState();
			DataManager<GuildDataManager>.GetInstance().RequestGuildReceiveMergeRequest();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TimeLessItemsChanged, null, null, null, null);
			DataManager<ActivityDataManager>.GetInstance().SendMonthlySignInQuery();
			if (Singleton<LoginPushManager>.GetInstance().IsFirstLogin())
			{
				DataManager<DeadLineReminderDataManager>.GetInstance().CheckCurrencyDeadlineStatus();
			}
			DataManager<AdventurerPassCardDataManager>.GetInstance().SendWorldAventurePassStatusReq();
			DataManager<AdventurerPassCardDataManager>.GetInstance().SendWorldAventurePassExpPackReq(0);
			DataManager<WarriorRecruitDataManager>.GetInstance().SendWorldQueryHireCoinReq();
			DataManager<WarriorRecruitDataManager>.GetInstance().SendWorldQueryHirePushReq(0);
			DataManager<ZillionaireGameDataManager>.GetInstance().OnSendWorldMonopolyCoinReq();
			DataManager<ZillionaireGameDataManager>.GetInstance().OnSendWorldMonopolyStatusReq();
			DataManager<ZillionaireGameDataManager>.GetInstance().OnSendWorldMonopolyCardListReq();
			this.isTownSceneLoadFinish = true;
		}

		// Token: 0x0600EAAB RID: 60075 RVA: 0x003E41CA File Offset: 0x003E25CA
		public void SetJoystickAfterSetting()
		{
			if (this._inputManager == null)
			{
				return;
			}
			if (this._inputManager.joystickMode != Singleton<SettingManager>.GetInstance().GetJoystickMode())
			{
				this.ReloadJoystick();
			}
		}

		// Token: 0x0600EAAC RID: 60076 RVA: 0x003E41F8 File Offset: 0x003E25F8
		private void InitData()
		{
			this.mLastJoyStickPosition = Vector2.zero;
			this.mLastJoyStickFizzyCheck = false;
			this.mIsStopMoveFunction = false;
		}

		// Token: 0x0600EAAD RID: 60077 RVA: 0x003E4214 File Offset: 0x003E2614
		private void InitJoystick()
		{
			this._inputManager = new InputManager();
			this._inputManager.LoadJoystick(Singleton<SettingManager>.GetInstance().GetJoystickMode());
			GameObject joyStick = this._inputManager.GetJoyStick();
			if (joyStick != null)
			{
				Utility.AttachTo(joyStick, Singleton<ClientSystemManager>.instance.BottomLayer, false);
				joyStick.transform.SetAsFirstSibling();
			}
			this._inputManager.SetJoyStickMoveCallback(new UnityAction<Vector2>(this._OnJoyStickMove));
			this._inputManager.SetJoyStickMoveEndCallback(new UnityAction(this._OnJoyStickStop));
		}

		// Token: 0x0600EAAE RID: 60078 RVA: 0x003E42A3 File Offset: 0x003E26A3
		public void StopMainPlayerMoveAndStopFizzyCheck()
		{
			this._OnJoyStickStop();
			this.mLastJoyStickFizzyCheck = false;
			this.mIsStopMoveFunction = true;
		}

		// Token: 0x0600EAAF RID: 60079 RVA: 0x003E42B9 File Offset: 0x003E26B9
		public void StartFizzyCheckAndResumeJoystickMove()
		{
			this.mIsStopMoveFunction = false;
			this.mLastJoyStickFizzyCheck = true;
		}

		// Token: 0x0600EAB0 RID: 60080 RVA: 0x003E42C9 File Offset: 0x003E26C9
		private void ReloadJoystick()
		{
			this.UnloadInput();
			this.InitJoystick();
		}

		// Token: 0x0600EAB1 RID: 60081 RVA: 0x003E42D7 File Offset: 0x003E26D7
		private void InitTalk()
		{
			this.m_miniTalk = ComTalk.Create(this.mTalkRoot);
		}

		// Token: 0x0600EAB2 RID: 60082 RVA: 0x003E42EC File Offset: 0x003E26EC
		private void InitFilters()
		{
			string[] array = new string[]
			{
				"bottommiddle/Tabs/TabC",
				string.Empty,
				string.Empty,
				"bottommiddle/Tabs/TabB",
				"bottommiddle/Tabs/TabA",
				"bottommiddle/Tabs/TabD",
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty
			};
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]))
				{
					Toggle toggle = Utility.FindComponent<Toggle>(this.frame, array[i], true);
					toggle.isOn = DataManager<SystemConfigManager>.GetInstance().IsChatToggleOn((ChatType)i);
					ChatType eChatType = (ChatType)i;
					GameObject goCheckMark = Utility.FindChild(toggle.gameObject, "CheckMark");
					goCheckMark.CustomActive(toggle.isOn);
					toggle.onValueChanged.AddListener(delegate(bool bValue)
					{
						DataManager<SystemConfigManager>.GetInstance().SetChatToggle(eChatType, bValue);
						goCheckMark.CustomActive(bValue);
					});
				}
			}
		}

		// Token: 0x0600EAB3 RID: 60083 RVA: 0x003E43FC File Offset: 0x003E27FC
		private void InitializeMainUI()
		{
			this.UpdateShowButton();
			this.UpdateBeStrongExpand(false);
			this.UpdateMainRoleInfo();
			this.UpdateUplevelGiftText();
			this.UpdateDayOnlineGiftText();
			this.UpdateDuelLockTip();
			this.UpdateDuelOrChangeJobBtn();
			this.UpdateChallengeButton();
			this.UpdateLocalTime();
			this.UpdateBattery();
			this.InitRedPoint();
			this.InitActiveBubble();
			EGuildBattleState guildBattleState = DataManager<GuildDataManager>.GetInstance().GetGuildBattleState();
			this.UpdateGuildBattle(guildBattleState, guildBattleState);
			this.UpdatePay(false);
			this._InitTownMap();
			this._InitActivityJar();
			this._InitMagicJar();
			this.UpdateMallGiftNotice();
			this.InitMainTownFrameCommonButtonControl();
			this.UpdateSDKBindPhoneBtn();
			this.InitLimitTimeActivity();
			this.InitHaveGoodsRecommend();
			this.InitTreasureLotteryActivityUI();
			this.InitHorseGambling();
			this._InitRandomTreasure();
			this._InitSDKIcon();
			this._InitStrengthenTicketMerge();
			this._InitDailyTodoRoot();
			this._InitAdventureTeamShow();
			this.InitOnlineServiceBtn();
			this.UpdateShowOppoLoginButton();
			this.UpdateShowChannelRankListButton();
			this.InitShowOperateAdsButton();
			this.UpdateNewYearRedPackButton();
			this.UpdateChijiButton();
			this.UpdateTreasureConnvertButton();
			this.UpdateAdventurePassCardButton();
			this.InitQuestionnaireBtn();
			if (Singleton<GeGraphicSetting>.instance.isModified)
			{
				SystemNotifyManager.SystemNotify(8523, string.Empty);
				Singleton<GeGraphicSetting>.instance.isModified = false;
			}
			this._RefreshHaveLevelPermenentBtn();
			this.UpdateTopRightState(DataManager<PlayerBaseData>.GetInstance().IsExpand);
			this.UpdateFashionMergeBtnState();
			if (this.mTimePlayBtn != null)
			{
				this.mTimePlayBtn.InitializeMainUI();
			}
		}

		// Token: 0x0600EAB4 RID: 60084 RVA: 0x003E4560 File Offset: 0x003E2960
		private void InitQuestionnaireBtn()
		{
			bool bActive = DataManager<BaseWebViewManager>.GetInstance().CanUnlockQuestionnaire();
			this.QuestionnaireBtn.gameObject.CustomActive(bActive);
		}

		// Token: 0x0600EAB5 RID: 60085 RVA: 0x003E4598 File Offset: 0x003E2998
		private void InitMainTownFrameCommonButtonControl()
		{
			if (this.mMainTownFrameCommonButtonControl != null)
			{
				this.mMainTownFrameCommonButtonControl.UpdateMainTownFrameCommonButtonControl();
			}
		}

		// Token: 0x0600EAB6 RID: 60086 RVA: 0x003E45B8 File Offset: 0x003E29B8
		private void InitRedPoint()
		{
			if (DataManager<ItemDataManager>.GetInstance().IsPackageFull(EPackageType.Invalid))
			{
				this.mPackageFull.gameObject.SetActive(true);
				this.mPackageAnim.DORestart(false);
			}
			else
			{
				this.mPackageFull.gameObject.SetActive(false);
				this.mPackageAnim.DOPause();
				this.mPackageAnim.gameObject.transform.localRotation = Quaternion.identity;
			}
			this._CheckFriendRedPoint();
			this.mPackageRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.PackageMain));
			this.mGuildRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildMain));
			this.mSkillRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.Skill));
			this.mEquipForgeRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.EquipForge));
			this.mActivityLimitTimeRedPoint.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.ActivityLimitTime));
			this.mJarRedPoint.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.Jar));
			this.mEquipRecoveryRedPoint.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.EquipRecovery));
			this.mAdventureTeamRedPoint.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.AdventureTeam));
			this.UpdateMissionRedPoint();
			this.UpdateRedPacket();
			this._updateDailyRedPoint();
		}

		// Token: 0x0600EAB7 RID: 60087 RVA: 0x003E4720 File Offset: 0x003E2B20
		private void InitActiveBubble()
		{
			List<string> list = new List<string>();
			string activeBubbleInfo = DataManager<ActivityDataManager>.GetInstance().GetActiveBubbleInfo(ActivityLimitTimeFactory.EActivityType.OAT_MAGICALJOURENYACTIVITY);
			if (activeBubbleInfo != string.Empty)
			{
				list.Add(activeBubbleInfo);
			}
			activeBubbleInfo = DataManager<ActivityDataManager>.GetInstance().GetActiveBubbleInfo(ActivityLimitTimeFactory.EActivityType.OAT_GOBLIN_SHOP_ACT);
			if (activeBubbleInfo != string.Empty)
			{
				list.Add(activeBubbleInfo);
			}
			if (list.Count > 0)
			{
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.PlayActiveBubble(list));
			}
		}

		// Token: 0x0600EAB8 RID: 60088 RVA: 0x003E47A0 File Offset: 0x003E2BA0
		private IEnumerator PlayActiveBubble(List<string> strList)
		{
			for (int i = 0; i < strList.Count; i++)
			{
				string str = strList[i];
				if (this.mActiveBubbleControl != null)
				{
					this.mActiveBubbleControl.SetUp(str);
				}
				yield return Yielders.GetWaitForSeconds(15f);
			}
			yield break;
		}

		// Token: 0x0600EAB9 RID: 60089 RVA: 0x003E47C4 File Offset: 0x003E2BC4
		private void UpdateShowOppoLoginButton()
		{
			bool bActive = this._IsOppoLogin();
			this.mOppoRoot.CustomActive(bActive);
			this.mOppo2Root.CustomActive(false);
			if (SDKInterface.instance.IsOppoPlatform())
			{
				this.mOppoImg.CustomActive(true);
				this.mOppoText.CustomActive(true);
				this.mVivoImg.CustomActive(false);
				this.mVivoText.CustomActive(false);
				if (this.mOPPORepoint != null)
				{
					bool bActive2 = DataManager<OPPOPrivilegeDataManager>.GetInstance()._CheckDail() || DataManager<OPPOPrivilegeDataManager>.GetInstance()._CheckPrivilrge(12000) || DataManager<OPPOPrivilegeDataManager>.GetInstance()._CheckLuckyGuy() || DataManager<OPPOPrivilegeDataManager>.GetInstance()._CheckAmberGiftBag() || DataManager<OPPOPrivilegeDataManager>.GetInstance()._CheckAmberPrivilege() || DataManager<OPPOPrivilegeDataManager>.GetInstance()._CheckOPPOGrowthHaoLi();
					this.mOPPORepoint.CustomActive(bActive2);
				}
				if (!DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_OPPO_COMMUNITY))
				{
					this.mOppo2Root.CustomActive(true);
				}
			}
			else if (SDKInterface.instance.IsVivoPlatForm())
			{
				this.mOppoImg.CustomActive(false);
				this.mOppoText.CustomActive(false);
				this.mVivoImg.CustomActive(true);
				this.mVivoText.CustomActive(true);
				if (this.mOPPORepoint != null)
				{
					this.mOPPORepoint.CustomActive(DataManager<OPPOPrivilegeDataManager>.GetInstance()._CheckPrivilrge(23000));
				}
				if (!DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_VIVO_COMMUNITY))
				{
					this.mOppo2Root.CustomActive(true);
				}
			}
		}

		// Token: 0x0600EABA RID: 60090 RVA: 0x003E4953 File Offset: 0x003E2D53
		private void UpdateShowChannelRankListButton()
		{
			this.mRankallRoot.CustomActive(this._isChanneRankBtn());
		}

		// Token: 0x0600EABB RID: 60091 RVA: 0x003E4968 File Offset: 0x003E2D68
		private void InitShowOperateAdsButton()
		{
			if (this.mOperateAdsText)
			{
				this.mOperateAdsText.text = ((!Singleton<PluginManager>.GetInstance().IsMGSDKChannel()) ? TR.Value("operateAds_community") : TR.Value("operateAds_website"));
			}
			this.UpdateShowOperateAdsButton();
		}

		// Token: 0x0600EABC RID: 60092 RVA: 0x003E49BE File Offset: 0x003E2DBE
		private void UpdateShowOperateAdsButton()
		{
			if (this.mOperateAdsRoot)
			{
				this.mOperateAdsRoot.CustomActive(this.IsOperateAdsBtnShow());
			}
		}

		// Token: 0x0600EABD RID: 60093 RVA: 0x003E49E1 File Offset: 0x003E2DE1
		private void UpdateNewYearRedPackButton()
		{
			this.mRedPackRankListObj.CustomActive(DataManager<RedPackDataManager>.GetInstance().CheckNewYearActivityOpen());
		}

		// Token: 0x0600EABE RID: 60094 RVA: 0x003E49F8 File Offset: 0x003E2DF8
		private void UpdateChijiButton()
		{
			this.mChiji.CustomActive(DataManager<ChijiDataManager>.GetInstance().MainFrameChijiButtonIsShow());
		}

		// Token: 0x0600EABF RID: 60095 RVA: 0x003E4A0F File Offset: 0x003E2E0F
		private void UpdateTreasureConnvertButton()
		{
			this.mTreasureConversion.CustomActive(DataManager<BeadCardManager>.GetInstance().CheckTreasureConvertActivityOpon());
		}

		// Token: 0x0600EAC0 RID: 60096 RVA: 0x003E4A26 File Offset: 0x003E2E26
		private void UpdateAdventurePassCardButton()
		{
			this.adventurerPassCard.CustomActive(DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv > 0U);
		}

		// Token: 0x0600EAC1 RID: 60097 RVA: 0x003E4A40 File Offset: 0x003E2E40
		private void _updateDailyRedPoint()
		{
			this.mDailyRedPoint.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.ActivityDungeon));
			this.mDailyRedPointCount.text = this._getDailyRedPointCountString();
		}

		// Token: 0x0600EAC2 RID: 60098 RVA: 0x003E4A70 File Offset: 0x003E2E70
		private string _getDailyRedPointCountString()
		{
			int num = 0;
			num += MissionDailyFrame.GetRedPointCount();
			num += DataManager<ActivityDungeonDataManager>.GetInstance().GetRedCountByActivityType(ActivityDungeonTable.eActivityType.TimeLimit);
			return (num + DataManager<ActivityDungeonDataManager>.GetInstance().GetRedCountByActivityType(ActivityDungeonTable.eActivityType.Daily)).ToString();
		}

		// Token: 0x0600EAC3 RID: 60099 RVA: 0x003E4AB0 File Offset: 0x003E2EB0
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SceneChangedFinish, new ClientEventSystem.UIEventHandler(this.OnSceneChangedFinish));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SwitchToMainScene, new ClientEventSystem.UIEventHandler(this.OnSwitchToMainScene));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SystemChanged, new ClientEventSystem.UIEventHandler(this.OnSystemSwitchFinished));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this.OnRedPointChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FatigueChanged, new ClientEventSystem.UIEventHandler(this.OnFatigueChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.OnLevelChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ExpChanged, new ClientEventSystem.UIEventHandler(this.OnExpChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerVipLvChanged, new ClientEventSystem.UIEventHandler(this.OnVipLvChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.JobIDChanged, new ClientEventSystem.UIEventHandler(this.OnJobIDChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.JobIDReset, new ClientEventSystem.UIEventHandler(this.OnJobIDReset));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateUnlockFunc, new ClientEventSystem.UIEventHandler(this.OnUpdateUnlockFunc));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NewFuncUnlock, new ClientEventSystem.UIEventHandler(this.OnNewFuncUnlock));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NewAccountFuncUnlock, new ClientEventSystem.UIEventHandler(this.OnNewAccountFuncUnlock));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NextFuncOpen, new ClientEventSystem.UIEventHandler(this.OnNextFuncOpen));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRefreshInviteList, new ClientEventSystem.UIEventHandler(this.OnNotifyFriendInvite));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnNewPupilApplyRecieved, new ClientEventSystem.UIEventHandler(this.OnNotifyFriendInvite));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRecvPrivateChat, new ClientEventSystem.UIEventHandler(this.OnRecvPrivateChat));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RoleChatDirtyChanged, new ClientEventSystem.UIEventHandler(this.OnPrivateChat));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PackageFull, new ClientEventSystem.UIEventHandler(this.OnPackageFullUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PackageNotFull, new ClientEventSystem.UIEventHandler(this.OnPackageFullUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPacketOpenSuccess, new ClientEventSystem.UIEventHandler(this.OnRedPacketOpenSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPacketGet, new ClientEventSystem.UIEventHandler(this.OnNewRedPacketGet));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPacketDelete, new ClientEventSystem.UIEventHandler(this.OnDeleteRedPacket));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPayResultNotify, new ClientEventSystem.UIEventHandler(this.OnPay));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildBattleStateChanged, new ClientEventSystem.UIEventHandler(this.OnGuildBattleStateChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.WelfareFrameClose, new ClientEventSystem.UIEventHandler(this.OnUpdateUplevelGift));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UplevelFrameClose, new ClientEventSystem.UIEventHandler(this.OnSkillLearnTips));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FadeOutOver, new ClientEventSystem.UIEventHandler(this.OnFadeOutOver));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMonthCardUpdate, new ClientEventSystem.UIEventHandler(this.OnMonthCardUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChangeJobSelectDialog, new ClientEventSystem.UIEventHandler(this.OnChangeJobSelectDialog));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SDKBindPhoneFinished, new ClientEventSystem.UIEventHandler(this.OnSDKBindPhoneFinished));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ShowLimitTimeActivityBtn, new ClientEventSystem.UIEventHandler(this.ShowLimitTimeActivity));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuankaFrameOpen, new ClientEventSystem.UIEventHandler(this.OnGunakaFrameOpen));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildMainFrameClose, new ClientEventSystem.UIEventHandler(this.OnCloseGuildMainFrame));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this.OnRelationChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTAPRedPointUpdate, new ClientEventSystem.UIEventHandler(this.OnRelationChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRecOnlineServiceNewNote, new ClientEventSystem.UIEventHandler(this.OnRecOnlineServiceNewNote));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MakeShowOnlineService, new ClientEventSystem.UIEventHandler(this.MakeShowOnlineService));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GoodsRecommend, new ClientEventSystem.UIEventHandler(this.OnPrivateOrderingNoticeUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideStart));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeUpdate, new ClientEventSystem.UIEventHandler(this.OnUpdateActivityLimitTimeState));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeTaskUpdate, new ClientEventSystem.UIEventHandler(this.OnUpdateActivityLimitTimeState));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TreasureLotterySyncDraw, new ClientEventSystem.UIEventHandler(this.OnUpdateActivityTreasureLottery));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TreasureLotteryStatusChange, new ClientEventSystem.UIEventHandler(this.OnUpdateActivityTreasureLottery));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RightLowerBubblePlayAnimation, new ClientEventSystem.UIEventHandler(this.mRightLowerBubblePlayAnimation));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPlayerFunctionUnlockAnimation, new ClientEventSystem.UIEventHandler(this.OnPlayerFunctionUnlockAnimation));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HorseGamblingStateUpdate, new ClientEventSystem.UIEventHandler(this.OnUpdateHorseGambling));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnApplyPupilListChanged, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnApplyTeacherListChanged, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTAPApplyToggleRedPointUpdate, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTAPOpenSearchFrame, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTreasureFuncSwitch, new ClientEventSystem.UIEventHandler(this._OnRandomTreasureFuncChange));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTAPGraduationSuccess, new ClientEventSystem.UIEventHandler(this._OnTAPGraduationSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnStrengthenTicketMergeStateUpdate, new ClientEventSystem.UIEventHandler(this._OnStrengthTicketMergeStateUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamFuncChanged, new ClientEventSystem.UIEventHandler(this._OnAdventureTeamFuncChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnFashionMergeSwich, new ClientEventSystem.UIEventHandler(this._OnFashionMergeSwitchFunc));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonSyncActivityState, new ClientEventSystem.UIEventHandler(this._OnSyncActivityState));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TopUpPushButoonOpen, new ClientEventSystem.UIEventHandler(this._OnTopUpPushButoonOpen));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TopUpPushButtonClose, new ClientEventSystem.UIEventHandler(this._OnTopUpPushButoonClose));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGuildDungeonAuctionStateUpdate, new ClientEventSystem.UIEventHandler(this._OnGuildDungeonAuctionStateUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGuildDungeonWorldAuctionStateUpdate, new ClientEventSystem.UIEventHandler(this._OnGuildDungeonWorldAuctionStateUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGuildDungeonAuctionAddNewItem, new ClientEventSystem.UIEventHandler(this._OnGuildDungeonAuctionAddNewItem));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UseHeadPortraitFrameSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateHeadPortraitFrame));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HeadPortraitFrameChange, new ClientEventSystem.UIEventHandler(this._OnHeadPortraitFrameChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NotifyShowAdventureTeamUnlockAnim, new ClientEventSystem.UIEventHandler(this._OnNotifyShowAdventureTeamUnlockAnim));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NotifyShowAdventurePassSeasonUnlockAnim, new ClientEventSystem.UIEventHandler(this._OnNotifyShowAdventurePassSeasonUnlockAnim));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NotifyOpenWelfareFrame, new ClientEventSystem.UIEventHandler(this._OnNotifyOpenWelfareFrame));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateAventurePassStatus, new ClientEventSystem.UIEventHandler(this._OnUpdateAventurePassStatus));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateAventurePassButtonRedPoint, new ClientEventSystem.UIEventHandler(this._OnUpdateAventurePassButtonRedPoint));
			this.onFadeInEnd = (ClientFrame.OnFadeInEnd)Delegate.Combine(this.onFadeInEnd, new ClientFrame.OnFadeInEnd(this.FuncUnlockNotify));
			this.onFadeInEnd = (ClientFrame.OnFadeInEnd)Delegate.Combine(this.onFadeInEnd, new ClientFrame.OnFadeInEnd(this.OpenComTalk));
			SystemConfigManager instance = DataManager<SystemConfigManager>.GetInstance();
			instance.onChatFilterChanged = (SystemConfigManager.OnChatFilterChanged)Delegate.Combine(instance.onChatFilterChanged, new SystemConfigManager.OnChatFilterChanged(this.OnChatFilterChanged));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance2.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Combine(instance3.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddNewMission));
			MissionManager instance4 = DataManager<MissionManager>.GetInstance();
			instance4.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance4.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateMission));
			MissionManager instance5 = DataManager<MissionManager>.GetInstance();
			instance5.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Combine(instance5.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnDeleteMission));
			MissionManager instance6 = DataManager<MissionManager>.GetInstance();
			instance6.missionChangedDelegate = (MissionManager.OnMissionChanged)Delegate.Combine(instance6.missionChangedDelegate, new MissionManager.OnMissionChanged(this.OnMissionChanged));
			MissionManager instance7 = DataManager<MissionManager>.GetInstance();
			instance7.onChestIdsChanged = (MissionManager.OnChestIdsChanged)Delegate.Combine(instance7.onChestIdsChanged, new MissionManager.OnChestIdsChanged(this._OnChestIdsChanged));
			ActiveManager instance8 = DataManager<ActiveManager>.GetInstance();
			instance8.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Combine(instance8.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
		}

		// Token: 0x0600EAC4 RID: 60100 RVA: 0x003E5384 File Offset: 0x003E3784
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SceneChangedFinish, new ClientEventSystem.UIEventHandler(this.OnSceneChangedFinish));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SwitchToMainScene, new ClientEventSystem.UIEventHandler(this.OnSwitchToMainScene));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SystemChanged, new ClientEventSystem.UIEventHandler(this.OnSystemSwitchFinished));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this.OnRedPointChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FatigueChanged, new ClientEventSystem.UIEventHandler(this.OnFatigueChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.OnLevelChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ExpChanged, new ClientEventSystem.UIEventHandler(this.OnExpChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerVipLvChanged, new ClientEventSystem.UIEventHandler(this.OnVipLvChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.JobIDChanged, new ClientEventSystem.UIEventHandler(this.OnJobIDChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.JobIDReset, new ClientEventSystem.UIEventHandler(this.OnJobIDReset));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateUnlockFunc, new ClientEventSystem.UIEventHandler(this.OnUpdateUnlockFunc));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NewFuncUnlock, new ClientEventSystem.UIEventHandler(this.OnNewFuncUnlock));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NewAccountFuncUnlock, new ClientEventSystem.UIEventHandler(this.OnNewAccountFuncUnlock));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NextFuncOpen, new ClientEventSystem.UIEventHandler(this.OnNextFuncOpen));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRefreshInviteList, new ClientEventSystem.UIEventHandler(this.OnNotifyFriendInvite));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnNewPupilApplyRecieved, new ClientEventSystem.UIEventHandler(this.OnNotifyFriendInvite));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRecvPrivateChat, new ClientEventSystem.UIEventHandler(this.OnRecvPrivateChat));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RoleChatDirtyChanged, new ClientEventSystem.UIEventHandler(this.OnPrivateChat));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PackageFull, new ClientEventSystem.UIEventHandler(this.OnPackageFullUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PackageNotFull, new ClientEventSystem.UIEventHandler(this.OnPackageFullUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPacketOpenSuccess, new ClientEventSystem.UIEventHandler(this.OnRedPacketOpenSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPacketGet, new ClientEventSystem.UIEventHandler(this.OnNewRedPacketGet));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPacketDelete, new ClientEventSystem.UIEventHandler(this.OnDeleteRedPacket));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPayResultNotify, new ClientEventSystem.UIEventHandler(this.OnPay));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildBattleStateChanged, new ClientEventSystem.UIEventHandler(this.OnGuildBattleStateChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.WelfareFrameClose, new ClientEventSystem.UIEventHandler(this.OnUpdateUplevelGift));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UplevelFrameClose, new ClientEventSystem.UIEventHandler(this.OnSkillLearnTips));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FadeOutOver, new ClientEventSystem.UIEventHandler(this.OnFadeOutOver));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMonthCardUpdate, new ClientEventSystem.UIEventHandler(this.OnMonthCardUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChangeJobSelectDialog, new ClientEventSystem.UIEventHandler(this.OnChangeJobSelectDialog));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SDKBindPhoneFinished, new ClientEventSystem.UIEventHandler(this.OnSDKBindPhoneFinished));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ShowLimitTimeActivityBtn, new ClientEventSystem.UIEventHandler(this.ShowLimitTimeActivity));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuankaFrameOpen, new ClientEventSystem.UIEventHandler(this.OnGunakaFrameOpen));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildMainFrameClose, new ClientEventSystem.UIEventHandler(this.OnCloseGuildMainFrame));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this.OnRelationChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTAPRedPointUpdate, new ClientEventSystem.UIEventHandler(this.OnRelationChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRecOnlineServiceNewNote, new ClientEventSystem.UIEventHandler(this.OnRecOnlineServiceNewNote));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MakeShowOnlineService, new ClientEventSystem.UIEventHandler(this.MakeShowOnlineService));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GoodsRecommend, new ClientEventSystem.UIEventHandler(this.OnPrivateOrderingNoticeUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnNewbieGuideStart));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeUpdate, new ClientEventSystem.UIEventHandler(this.OnUpdateActivityLimitTimeState));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeTaskUpdate, new ClientEventSystem.UIEventHandler(this.OnUpdateActivityLimitTimeState));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TreasureLotterySyncDraw, new ClientEventSystem.UIEventHandler(this.OnUpdateActivityTreasureLottery));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TreasureLotteryStatusChange, new ClientEventSystem.UIEventHandler(this.OnUpdateActivityTreasureLottery));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RightLowerBubblePlayAnimation, new ClientEventSystem.UIEventHandler(this.mRightLowerBubblePlayAnimation));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPlayerFunctionUnlockAnimation, new ClientEventSystem.UIEventHandler(this.OnPlayerFunctionUnlockAnimation));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HorseGamblingStateUpdate, new ClientEventSystem.UIEventHandler(this.OnUpdateHorseGambling));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnApplyPupilListChanged, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnApplyTeacherListChanged, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTAPApplyToggleRedPointUpdate, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTAPOpenSearchFrame, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTreasureFuncSwitch, new ClientEventSystem.UIEventHandler(this._OnRandomTreasureFuncChange));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTAPGraduationSuccess, new ClientEventSystem.UIEventHandler(this._OnTAPGraduationSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnStrengthenTicketMergeStateUpdate, new ClientEventSystem.UIEventHandler(this._OnStrengthTicketMergeStateUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamFuncChanged, new ClientEventSystem.UIEventHandler(this._OnAdventureTeamFuncChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnFashionMergeSwich, new ClientEventSystem.UIEventHandler(this._OnFashionMergeSwitchFunc));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonSyncActivityState, new ClientEventSystem.UIEventHandler(this._OnSyncActivityState));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TopUpPushButoonOpen, new ClientEventSystem.UIEventHandler(this._OnTopUpPushButoonOpen));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TopUpPushButtonClose, new ClientEventSystem.UIEventHandler(this._OnTopUpPushButoonClose));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGuildDungeonAuctionStateUpdate, new ClientEventSystem.UIEventHandler(this._OnGuildDungeonAuctionStateUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGuildDungeonWorldAuctionStateUpdate, new ClientEventSystem.UIEventHandler(this._OnGuildDungeonWorldAuctionStateUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGuildDungeonAuctionAddNewItem, new ClientEventSystem.UIEventHandler(this._OnGuildDungeonAuctionAddNewItem));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UseHeadPortraitFrameSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateHeadPortraitFrame));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HeadPortraitFrameChange, new ClientEventSystem.UIEventHandler(this._OnHeadPortraitFrameChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NotifyShowAdventureTeamUnlockAnim, new ClientEventSystem.UIEventHandler(this._OnNotifyShowAdventureTeamUnlockAnim));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NotifyShowAdventurePassSeasonUnlockAnim, new ClientEventSystem.UIEventHandler(this._OnNotifyShowAdventurePassSeasonUnlockAnim));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NotifyOpenWelfareFrame, new ClientEventSystem.UIEventHandler(this._OnNotifyOpenWelfareFrame));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateAventurePassStatus, new ClientEventSystem.UIEventHandler(this._OnUpdateAventurePassStatus));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateAventurePassButtonRedPoint, new ClientEventSystem.UIEventHandler(this._OnUpdateAventurePassButtonRedPoint));
			this.onFadeInEnd = (ClientFrame.OnFadeInEnd)Delegate.Remove(this.onFadeInEnd, new ClientFrame.OnFadeInEnd(this.FuncUnlockNotify));
			this.onFadeInEnd = (ClientFrame.OnFadeInEnd)Delegate.Remove(this.onFadeInEnd, new ClientFrame.OnFadeInEnd(this.OpenComTalk));
			SystemConfigManager instance = DataManager<SystemConfigManager>.GetInstance();
			instance.onChatFilterChanged = (SystemConfigManager.OnChatFilterChanged)Delegate.Remove(instance.onChatFilterChanged, new SystemConfigManager.OnChatFilterChanged(this.OnChatFilterChanged));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance2.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(instance3.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddNewMission));
			MissionManager instance4 = DataManager<MissionManager>.GetInstance();
			instance4.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance4.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateMission));
			MissionManager instance5 = DataManager<MissionManager>.GetInstance();
			instance5.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Remove(instance5.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnDeleteMission));
			MissionManager instance6 = DataManager<MissionManager>.GetInstance();
			instance6.missionChangedDelegate = (MissionManager.OnMissionChanged)Delegate.Remove(instance6.missionChangedDelegate, new MissionManager.OnMissionChanged(this.OnMissionChanged));
			MissionManager instance7 = DataManager<MissionManager>.GetInstance();
			instance7.onChestIdsChanged = (MissionManager.OnChestIdsChanged)Delegate.Remove(instance7.onChestIdsChanged, new MissionManager.OnChestIdsChanged(this._OnChestIdsChanged));
			ActiveManager instance8 = DataManager<ActiveManager>.GetInstance();
			instance8.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Remove(instance8.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
		}

		// Token: 0x0600EAC5 RID: 60101 RVA: 0x003E5C55 File Offset: 0x003E4055
		private void UnloadInput()
		{
			if (this._inputManager != null)
			{
				this._inputManager.Unload();
				this._inputManager = null;
			}
		}

		// Token: 0x0600EAC6 RID: 60102 RVA: 0x003E5C74 File Offset: 0x003E4074
		private void ReloadInput()
		{
			this.UnloadInput();
			this.InitJoystick();
		}

		// Token: 0x0600EAC7 RID: 60103 RVA: 0x003E5C84 File Offset: 0x003E4084
		private void OnSceneChangedFinish(UIEvent iEvent)
		{
			this.UpdateBeStrongExpand(false);
			this.UpdateRedPacket();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NewMailNotify, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityNoticeUpdate, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamNewInviteNoticeUpdate, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SkillLvUpNoticeUpdate, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FriendRequestNoticeUpdate, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildInviteNoticeUpdate, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FinancialPlanButtonUpdateBySceneChanged, null, null, null, null);
			byte b = (byte)DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatus();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PK3V3CrossButton, b, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HasLimitTimeGiftToBuy, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3InviteRoomListUpdate, 1, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3InviteRoomListUpdate, 3, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsStatusChanged, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TimeLessItemsChanged, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SecurityLockApplyStateButton, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationOwnerNewRequesterMessage, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationOwnerNewTeamInviteMessage, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAchievementScoreChanged, DataManager<PlayerBaseData>.GetInstance().AchievementScore, DataManager<PlayerBaseData>.GetInstance().AchievementScore, null, null);
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				Singleton<SDKVoiceManager>.GetInstance().LeaveSceneChannel();
				if (tableItem.SceneType == CitySceneTable.eSceneType.NORMAL || tableItem.SceneType == CitySceneTable.eSceneType.PK_PREPARE)
				{
					Singleton<SDKVoiceManager>.GetInstance().JoinSceneChannel();
				}
			}
		}

		// Token: 0x0600EAC8 RID: 60104 RVA: 0x003E5E7D File Offset: 0x003E427D
		private void OnSwitchToMainScene(UIEvent iEvent)
		{
			this.UpdateGuildEffect();
			this.UpdateGuildTips();
		}

		// Token: 0x0600EAC9 RID: 60105 RVA: 0x003E5E8B File Offset: 0x003E428B
		private void OnSystemSwitchFinished(UIEvent iEvent)
		{
			if (this.bNeedSwitchToChijiPrepare)
			{
				this.bNeedSwitchToChijiPrepare = false;
				DataManager<ChijiDataManager>.GetInstance().SwitchingTownToPrepare = true;
				Utility.SwitchToChijiWaittingRoom();
			}
		}

		// Token: 0x0600EACA RID: 60106 RVA: 0x003E5EB0 File Offset: 0x003E42B0
		private void OnRedPointChanged(UIEvent a_event)
		{
			ERedPoint eredPoint = (ERedPoint)a_event.Param1;
			if (eredPoint != ERedPoint.ChapterReward)
			{
				if (eredPoint == ERedPoint.Skill)
				{
					this.mSkillRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.Skill));
				}
				else if (eredPoint == ERedPoint.ActivityDungeon)
				{
					this._updateDailyRedPoint();
				}
				else if (eredPoint == ERedPoint.EquipRecovery)
				{
					this.mEquipRecoveryRedPoint.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.EquipRecovery));
				}
				else if (eredPoint == ERedPoint.AdventureTeam)
				{
					this.mAdventureTeamRedPoint.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.AdventureTeam));
				}
				else if (eredPoint >= ERedPoint.GuildMain && eredPoint < ERedPoint.Skill)
				{
					this.mGuildRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildMain));
				}
				else if (eredPoint == ERedPoint.PackageMain)
				{
					this.mPackageRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.PackageMain));
				}
				else if (eredPoint == ERedPoint.EquipForge)
				{
					this.mEquipForgeRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.EquipForge));
				}
				else if (eredPoint == ERedPoint.Jar)
				{
					this.mJarRedPoint.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.Jar));
				}
				else if (this.mSDKBindPhoneBtnRedPoint)
				{
					this.mSDKBindPhoneBtnRedPoint.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.SDKBindPhone));
				}
			}
		}

		// Token: 0x0600EACB RID: 60107 RVA: 0x003E604C File Offset: 0x003E444C
		private void OnFatigueChanged(UIEvent uiEvent)
		{
			this.UpdateFatigue();
		}

		// Token: 0x0600EACC RID: 60108 RVA: 0x003E6054 File Offset: 0x003E4454
		private void OnLevelChanged(UIEvent uiEvent)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			this.mPlayerLevel.text = DataManager<PlayerBaseData>.GetInstance().Level.ToString();
			this.UpdateExp(false);
			if (clientSystemTown.MainPlayer != null)
			{
				clientSystemTown.MainPlayer.SetPlayerRoleLv(DataManager<PlayerBaseData>.GetInstance().Level);
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.Battle || tableItem.SceneSubType == CitySceneTable.eSceneSubType.BattlePrepare)
			{
				return;
			}
			this.UpdateDuelLockTip();
			this.UpdateDuelOrChangeJobBtn();
			this.UpdateChallengeButton();
			this._UpdateActivityJar();
			this.UpdateShowOppoLoginButton();
			this.UpdateShowChannelRankListButton();
			this.UpdateShowOperateAdsButton();
			this.UpdateNewYearRedPackButton();
			this.UpdateTreasureConnvertButton();
			this.UpdateSDKBindPhoneBtn();
			this.InitLimitTimeActivity();
			this._UpdateRandomTreasure();
			this.InitHorseGambling();
			this._UpdateStrengthenTicketMerge();
			SDKInterface.instance.UpdateRoleInfo(2, ClientApplication.adminServer.id, ClientApplication.adminServer.name, DataManager<PlayerBaseData>.GetInstance().RoleID.ToString(), DataManager<PlayerBaseData>.GetInstance().Name, DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)DataManager<PlayerBaseData>.GetInstance().Level, DataManager<PlayerBaseData>.GetInstance().VipLevel, (int)DataManager<PlayerBaseData>.GetInstance().Ticket);
			this.mPackageRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.PackageMain));
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv)
			{
				DataManager<ActivityManager>.GetInstance().UpdateFlyingGiftPackActivity(5004U);
			}
			int num = 0;
			int.TryParse(TR.Value("ConsumeRebateLimitPlayerGrade"), out num);
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= num)
			{
				DataManager<ActivityManager>.GetInstance().UpdateConsumeRebateActivity(1540U);
			}
			int num2 = 0;
			int.TryParse(TR.Value("SpringFestivalRedEnvelopeRainLimitPlayerGrade"), out num2);
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= num2)
			{
				DataManager<ActivityManager>.GetInstance().UpdateSpringFestivalRedEnvelopeRainActivity(1585U);
			}
		}

		// Token: 0x0600EACD RID: 60109 RVA: 0x003E626B File Offset: 0x003E466B
		private void OnExpChanged(UIEvent uiEvent)
		{
			this.UpdateExp(false);
		}

		// Token: 0x0600EACE RID: 60110 RVA: 0x003E6274 File Offset: 0x003E4674
		private void OnVipLvChanged(UIEvent iEvent)
		{
			this.UpdateVipLevel();
		}

		// Token: 0x0600EACF RID: 60111 RVA: 0x003E627C File Offset: 0x003E467C
		private void OnJobIDChanged(UIEvent uiEvent)
		{
			this.UpdatePlayerIcon();
			this._OnShowChangeJobDialog();
			this.UpdateDuelOrChangeJobBtn();
		}

		// Token: 0x0600EAD0 RID: 60112 RVA: 0x003E6290 File Offset: 0x003E4690
		private void OnJobIDReset(UIEvent uiEvent)
		{
			this.UpdatePlayerIcon();
		}

		// Token: 0x0600EAD1 RID: 60113 RVA: 0x003E6298 File Offset: 0x003E4698
		private void OnUpdateUnlockFunc(UIEvent iEvent)
		{
		}

		// Token: 0x0600EAD2 RID: 60114 RVA: 0x003E629C File Offset: 0x003E469C
		private void OnNewFuncUnlock(UIEvent iEvent)
		{
			byte id = (byte)iEvent.Param1;
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>((int)id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.TargetBtnPos == string.Empty || tableItem.TargetBtnPos == "-")
			{
				return;
			}
			GameObject gameObject = Utility.FindGameObject(this.frame, tableItem.TargetBtnPos, true);
			if (gameObject == null)
			{
				return;
			}
			if (tableItem.ExpandType == FunctionUnLock.eExpandType.ET_TopRight)
			{
				ComTopButtonExpandController component = this.mBtShowHide.GetComponent<ComTopButtonExpandController>();
				if (component == null)
				{
					return;
				}
				if (!component.IsExpand())
				{
					component.MainButtonState();
					return;
				}
			}
			GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/UI/Prefab/EffUI_xinxiaoxi", true, 0U);
			if (gameObject2 != null)
			{
				Utility.AttachTo(gameObject2, gameObject, false);
			}
			if (tableItem.FuncType == FunctionUnLock.eFuncType.FashionMerge)
			{
				if (!DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_FASHION_MERGO))
				{
					gameObject.SetActive(true);
				}
				else
				{
					gameObject.SetActive(false);
				}
			}
			else
			{
				gameObject.SetActive(true);
			}
		}

		// Token: 0x0600EAD3 RID: 60115 RVA: 0x003E63C0 File Offset: 0x003E47C0
		private void OnPlayerFunctionUnlockAnimation(UIEvent iEvent)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<FunctionUnlockFrame>(null))
			{
				return;
			}
			if (!Global.Settings.isAnimationInto)
			{
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance().IsFlyUpState)
			{
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._NewFuncUnlockPlayStart());
		}

		// Token: 0x0600EAD4 RID: 60116 RVA: 0x003E6410 File Offset: 0x003E4810
		private bool SevenDaysButtonIsShow()
		{
			bool result = false;
			List<ActiveMainTable> type2Templates = DataManager<ActiveManager>.GetInstance().GetType2Templates(9388);
			int num = 0;
			while (type2Templates != null && num < type2Templates.Count)
			{
				if (DataManager<ActiveManager>.GetInstance().ActiveDictionary.ContainsKey(type2Templates[num].ID))
				{
					ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().ActiveDictionary[type2Templates[num].ID];
					if (activeData != null)
					{
						if (activeData.mainInfo != null && activeData.mainInfo.state != 0)
						{
							result = true;
							break;
						}
					}
				}
				num++;
			}
			return result;
		}

		// Token: 0x0600EAD5 RID: 60117 RVA: 0x003E64BC File Offset: 0x003E48BC
		private IEnumerator _NewFuncUnlockPlayStart()
		{
			if (DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.Count <= 0)
			{
				yield break;
			}
			FunctionUnLock FunctionUnLockData = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList[0], string.Empty, string.Empty);
			if (FunctionUnLockData.FuncType == FunctionUnLock.eFuncType.ActivitySevenDays && (!Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.ActivitySevenDays) || !this.SevenDaysButtonIsShow()))
			{
				DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.RemoveAt(0);
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._NewFuncUnlockPlayStart());
				yield break;
			}
			if (FunctionUnLockData.bPlayAnim == 0)
			{
				DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.RemoveAt(0);
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._NewFuncUnlockPlayStart());
				yield break;
			}
			if (FunctionUnLockData.TargetBtnPos == string.Empty || FunctionUnLockData.TargetBtnPos == "-")
			{
				DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.RemoveAt(0);
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._NewFuncUnlockPlayStart());
				yield break;
			}
			GameObject buttonObj = Utility.FindGameObject(this.frame, FunctionUnLockData.TargetBtnPos, true);
			if (buttonObj == null)
			{
				DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.RemoveAt(0);
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._NewFuncUnlockPlayStart());
				yield break;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NewFuncFrameOpen, null, null, null, null);
			if (FunctionUnLockData.bShowBtn == 0)
			{
				Image[] componentsInChildren = buttonObj.GetComponentsInChildren<Image>(true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					Color color = componentsInChildren[i].color;
					color.a = 0f;
					componentsInChildren[i].color = color;
				}
				Text[] componentsInChildren2 = buttonObj.GetComponentsInChildren<Text>();
				for (int j = 0; j < componentsInChildren2.Length; j++)
				{
					componentsInChildren2[j].enabled = false;
				}
			}
			buttonObj.SetActive(true);
			yield return new WaitForEndOfFrame();
			UnlockData data = default(UnlockData);
			data.FuncUnlockID = DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList[0];
			data.pos = buttonObj.transform.position;
			FunctionUnlockFrame UnlockFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<FunctionUnlockFrame>(FrameLayer.Top, data, string.Empty) as FunctionUnlockFrame;
			UnlockFrame.ResPlayEnd = new FunctionUnlockFrame.PlayEnd(this._NewFuncUnlockPlayEnd);
			yield break;
		}

		// Token: 0x0600EAD6 RID: 60118 RVA: 0x003E64D8 File Offset: 0x003E48D8
		private void _NewFuncUnlockPlayEnd()
		{
			if (DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.Count <= 0)
			{
				return;
			}
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList[0], string.Empty, string.Empty);
			if (tableItem.TargetBtnPos == string.Empty || tableItem.TargetBtnPos == "-")
			{
				DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.RemoveAt(0);
				return;
			}
			GameObject gameObject = Utility.FindGameObject(this.frame, tableItem.TargetBtnPos, true);
			if (gameObject == null)
			{
				DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.RemoveAt(0);
				return;
			}
			Image[] componentsInChildren = gameObject.GetComponentsInChildren<Image>(true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (!(componentsInChildren[i].name == gameObject.name))
				{
					Color color = componentsInChildren[i].color;
					color.a = 255f;
					componentsInChildren[i].color = color;
				}
			}
			Text[] componentsInChildren2 = gameObject.GetComponentsInChildren<Text>(true);
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				componentsInChildren2[j].enabled = true;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<FunctionUnlockFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<FunctionUnlockFrame>(null, false);
			}
			DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.RemoveAt(0);
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._NewFuncUnlockPlayStart());
		}

		// Token: 0x0600EAD7 RID: 60119 RVA: 0x003E6650 File Offset: 0x003E4A50
		private void OnNextFuncOpen(UIEvent uiEvent)
		{
			FunctionUnLock FunctionUnLockData = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>((int)DataManager<PlayerBaseData>.GetInstance().NextUnlockFunc, string.Empty, string.Empty);
			if (FunctionUnLockData == null)
			{
				this.mNextopen.gameObject.SetActive(false);
				return;
			}
			this.mNextopen.gameObject.SetActive(true);
			this.mNextOpenName.text = FunctionUnLockData.Name;
			this.mNextOpenLv.text = string.Format("{0}级", FunctionUnLockData.FinishLevel);
			if (FunctionUnLockData.IconPath != string.Empty && FunctionUnLockData.IconPath != "-")
			{
				Sprite Icon = Singleton<AssetLoader>.instance.LoadRes(FunctionUnLockData.IconPath, typeof(Sprite), true, 0U).obj as Sprite;
				if (Icon != null)
				{
					ETCImageLoader.LoadSprite(ref this.mNextOpenIcon, FunctionUnLockData.IconPath, true);
					this.mNextopen.onClick.RemoveAllListeners();
					this.mNextopen.onClick.AddListener(delegate()
					{
						ContentUI userData = new ContentUI
						{
							bNeedWait = false,
							title = this.mNextOpenLv.text,
							icon = Icon,
							material = this.mNextOpenIcon.material,
							name = FunctionUnLockData.Name,
							explannation = FunctionUnLockData.Explanation
						};
						if (Singleton<ClientSystemManager>.instance.IsFrameOpen<NextOpenShowFrame>(null))
						{
							Singleton<ClientSystemManager>.instance.CloseFrame<NextOpenShowFrame>(null, false);
						}
						Singleton<ClientSystemManager>.instance.OpenFrame<NextOpenShowFrame>(FrameLayer.Middle, userData, string.Empty);
					});
				}
			}
		}

		// Token: 0x0600EAD8 RID: 60120 RVA: 0x003E67BE File Offset: 0x003E4BBE
		private void OnNotifyFriendInvite(UIEvent uiEvent)
		{
			this._CheckFriendRedPoint();
		}

		// Token: 0x0600EAD9 RID: 60121 RVA: 0x003E67C6 File Offset: 0x003E4BC6
		private void OnRecvPrivateChat(UIEvent uiEvent)
		{
			this._CheckFriendRedPoint();
		}

		// Token: 0x0600EADA RID: 60122 RVA: 0x003E67CE File Offset: 0x003E4BCE
		private void _OnRefreshInviteList(UIEvent uiEvent)
		{
			this._CheckFriendRedPoint();
		}

		// Token: 0x0600EADB RID: 60123 RVA: 0x003E67D6 File Offset: 0x003E4BD6
		private void OnPrivateChat(UIEvent iEvent)
		{
			this._CheckFriendRedPoint();
		}

		// Token: 0x0600EADC RID: 60124 RVA: 0x003E67DE File Offset: 0x003E4BDE
		private void _OnTAPGraduationSuccess(UIEvent uiEvent)
		{
			if (this.mTAPGraduationEffUI != null)
			{
				this.mTAPGraduationEffUI.CustomActive(true);
				base.StartCoroutine(this.StopEffect());
			}
		}

		// Token: 0x0600EADD RID: 60125 RVA: 0x003E680C File Offset: 0x003E4C0C
		private IEnumerator StopEffect()
		{
			if (this.mTAPGraduationEffUI != null)
			{
				int time = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(458, string.Empty, string.Empty).Value;
				float timeFloat = (float)time * 1f / 1000f;
				yield return new WaitForSeconds(timeFloat);
				this.mTAPGraduationEffUI.CustomActive(false);
			}
			yield break;
		}

		// Token: 0x0600EADE RID: 60126 RVA: 0x003E6827 File Offset: 0x003E4C27
		private void InitTAPGraduationEffect()
		{
			if (this.mTAPGraduationEffUI != null)
			{
				this.mTAPGraduationEffUI.CustomActive(false);
			}
		}

		// Token: 0x0600EADF RID: 60127 RVA: 0x003E6848 File Offset: 0x003E4C48
		private void _CheckFriendRedPoint()
		{
			List<InviteFriendData> inviteFriendData = DataManager<RelationDataManager>.GetInstance().GetInviteFriendData();
			bool flag = false;
			bool flag2 = DataManager<TAPNewDataManager>.GetInstance().HaveApplyRedPoint();
			bool flag3 = DataManager<TAPNewDataManager>.GetInstance().HaveTAPDailyRedPoint();
			if (DataManager<TAPDataManager>.GetInstance().CheckTapRedPointIsShow())
			{
				flag = DataManager<TAPNewDataManager>.GetInstance().HaveSearchRedPoint();
			}
			if ((inviteFriendData != null && inviteFriendData.Count > 0) || flag2 || flag3 || flag)
			{
				this.mFriendRedPoint.CustomActive(true);
			}
			else
			{
				this.mFriendRedPoint.CustomActive(false);
			}
			if (DataManager<RelationDataManager>.GetInstance().GetPriDirty() || DataManager<RelationDataManager>.GetInstance().GetFriendPriDirty())
			{
				this.mPrivateChatBubble.CustomActive(true);
			}
			else
			{
				this.mPrivateChatBubble.CustomActive(false);
			}
		}

		// Token: 0x0600EAE0 RID: 60128 RVA: 0x003E6914 File Offset: 0x003E4D14
		private void OnPackageFullUpdate(UIEvent a_event)
		{
			if (DataManager<ItemDataManager>.GetInstance().IsPackageFull(EPackageType.Invalid))
			{
				this.mPackageFull.gameObject.SetActive(true);
				this.mPackageAnim.DORestart(false);
			}
			else
			{
				this.mPackageFull.gameObject.SetActive(false);
				this.mPackageAnim.DOPause();
				this.mPackageAnim.gameObject.transform.localRotation = Quaternion.identity;
			}
		}

		// Token: 0x0600EAE1 RID: 60129 RVA: 0x003E6989 File Offset: 0x003E4D89
		private void OnRedPacketOpenSuccess(UIEvent a_event)
		{
			this.UpdateRedPacket();
		}

		// Token: 0x0600EAE2 RID: 60130 RVA: 0x003E6991 File Offset: 0x003E4D91
		private void OnNewRedPacketGet(UIEvent a_event)
		{
			this.UpdateRedPacket();
		}

		// Token: 0x0600EAE3 RID: 60131 RVA: 0x003E6999 File Offset: 0x003E4D99
		private void OnDeleteRedPacket(UIEvent a_event)
		{
			this.UpdateRedPacket();
		}

		// Token: 0x0600EAE4 RID: 60132 RVA: 0x003E69A4 File Offset: 0x003E4DA4
		public void OnPay(UIEvent iEvent)
		{
			bool needOpenWindow = (string)iEvent.Param1 != "10";
			this.UpdatePay(needOpenWindow);
		}

		// Token: 0x0600EAE5 RID: 60133 RVA: 0x003E69CE File Offset: 0x003E4DCE
		private void OnGuildBattleStateChanged(UIEvent iEvent)
		{
			this.UpdateGuildBattle((EGuildBattleState)iEvent.Param1, (EGuildBattleState)iEvent.Param2);
		}

		// Token: 0x0600EAE6 RID: 60134 RVA: 0x003E69EC File Offset: 0x003E4DEC
		private void OnUpdateUplevelGift(UIEvent iEvent)
		{
			this.UpdateUplevelGiftText();
			this.UpdateDayOnlineGiftText();
			this.UpdateGuildEffect();
			this.UpdateGuildTips();
			this.UpdateSkillTipsState();
			if (DataManager<EquipHandbookDataManager>.GetInstance().OnLoginFlag)
			{
				this.OnSceneUpdateEquipHandBookTips();
				if (DataManager<JarDataManager>.GetInstance().ShowJarTips())
				{
					this._showJarTip();
				}
				DataManager<EquipHandbookDataManager>.GetInstance().OnLoginFlag = false;
			}
			DataManager<FollowingOpenQueueManager>.GetInstance().NotifyCurrentOrderClosed();
		}

		// Token: 0x0600EAE7 RID: 60135 RVA: 0x003E6A58 File Offset: 0x003E4E58
		private void OnActivityUpdate(UIEvent a_event)
		{
			this._UpdateActivityJar();
			this.UpdateNewYearRedPackButton();
			this.UpdateTreasureConnvertButton();
			uint item = (uint)a_event.Param1;
			List<int> list = DataManager<ChijiDataManager>.GetInstance().ChijiActivityIDs.ToList<int>();
			if (list != null && list.Contains((int)item))
			{
				this.UpdateChijiButton();
			}
		}

		// Token: 0x0600EAE8 RID: 60136 RVA: 0x003E6AAB File Offset: 0x003E4EAB
		private void OnSkillLearnTips(UIEvent a_event)
		{
			this.UpdateSkillLearnTips();
			this.UpdateEquipHandBookTips();
		}

		// Token: 0x0600EAE9 RID: 60137 RVA: 0x003E6AB9 File Offset: 0x003E4EB9
		private void OnFadeOutOver(UIEvent a_event)
		{
			if ((string)a_event.Param1 != "ClientSystemTownFrame")
			{
				return;
			}
			this._SetSkillTipActive(false);
			this._SetGuildTipActive(false);
			this._SetEquipHandBookTipActive(false);
		}

		// Token: 0x0600EAEA RID: 60138 RVA: 0x003E6AEC File Offset: 0x003E4EEC
		private void OnSDKBindPhoneFinished(UIEvent uiEvent)
		{
			try
			{
				bool bActive = (bool)uiEvent.Param1;
				if (!DataManager<MobileBindManager>.GetInstance().IsMobileBindFuncEnable())
				{
					bActive = false;
				}
				if (this.mSDKBindPhoneBtn)
				{
					this.mSDKBindPhoneBtn.gameObject.CustomActive(bActive);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("bind phone send notify param is error :" + ex.ToString());
			}
		}

		// Token: 0x0600EAEB RID: 60139 RVA: 0x003E6B68 File Offset: 0x003E4F68
		private void OnMonthCardUpdate(UIEvent a_event)
		{
			Singleton<MonthCardTipManager>.instance.SetTrueConfig(DataManager<PlayerBaseData>.GetInstance().RoleID);
			DataManager<MonthCardRewardLockersDataManager>.GetInstance().RefreshRedPoint();
		}

		// Token: 0x0600EAEC RID: 60140 RVA: 0x003E6B88 File Offset: 0x003E4F88
		private void OnChangeJobSelectDialog(UIEvent a_event)
		{
			this.ChangeJobSelectID = (int)a_event.Param1;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID, string.Empty, string.Empty);
			if (tableItem != null && tableItem.PreJobDialogID.Count >= 2)
			{
				if (this.ChangeJobSelectID == DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID)
				{
					DataManager<MissionManager>.GetInstance().CreateDialogFrame(tableItem.PreJobDialogID[0], 0, null);
				}
				else
				{
					DataManager<MissionManager>.GetInstance().CreateDialogFrame(tableItem.PreJobDialogID[1], 0, new TaskDialogFrame.OnDialogOver().AddListener(new UnityAction(this._OpenChangeJobSelNextDialog)));
				}
			}
		}

		// Token: 0x0600EAED RID: 60141 RVA: 0x003E6C3D File Offset: 0x003E503D
		private void OnCloseGuildMainFrame(UIEvent a_event)
		{
			this.UpdateGuildEffect();
			this.UpdateGuildTips();
		}

		// Token: 0x0600EAEE RID: 60142 RVA: 0x003E6C4C File Offset: 0x003E504C
		private void _OpenChangeJobSelNextDialog()
		{
			JobTable CurJobData = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.ChangeJobSelectID, string.Empty, string.Empty);
			if (CurJobData != null && CurJobData.PreJobDialogID.Count >= 2)
			{
				InvokeMethod.Invoke(this, 1f, delegate()
				{
					DataManager<MissionManager>.GetInstance().CreateDialogFrame(CurJobData.PreJobDialogID[0], 0, null);
				});
			}
		}

		// Token: 0x0600EAEF RID: 60143 RVA: 0x003E6CB7 File Offset: 0x003E50B7
		private void FuncUnlockNotify()
		{
		}

		// Token: 0x0600EAF0 RID: 60144 RVA: 0x003E6CB9 File Offset: 0x003E50B9
		private void OpenComTalk()
		{
			if (this.m_state == EFrameState.FadeIn || this.m_state == EFrameState.Open)
			{
				this.InitTalk();
			}
		}

		// Token: 0x0600EAF1 RID: 60145 RVA: 0x003E6CD9 File Offset: 0x003E50D9
		private void OnChatFilterChanged(List<bool> chatFilters)
		{
			if (ComTalk.ms_comTalk == this.m_miniTalk)
			{
				this.m_miniTalk.OnChatFilterChanged(chatFilters);
			}
		}

		// Token: 0x0600EAF2 RID: 60146 RVA: 0x003E6CFC File Offset: 0x003E50FC
		private void OnAddNewItem(List<Item> items)
		{
			for (int i = 0; i < items.Count; i++)
			{
			}
		}

		// Token: 0x0600EAF3 RID: 60147 RVA: 0x003E6D20 File Offset: 0x003E5120
		private void OnAddNewMission(uint taskID)
		{
			this.UpdateMissionRedPoint();
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.ChapterReward);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.ActivityDungeon);
			if (DataManager<MissionManager>.GetInstance().IsChangeJobMainMission((int)taskID))
			{
				ClientSystemTown._OpenChangeJobTip();
			}
		}

		// Token: 0x0600EAF4 RID: 60148 RVA: 0x003E6D5B File Offset: 0x003E515B
		private void OnUpdateMission(uint taskID)
		{
			if (DataManager<MissionManager>.GetInstance().IsChangeJobMainMission((int)taskID))
			{
				ClientSystemTown._OpenChangeJobTip();
			}
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.ChapterReward);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.ActivityDungeon);
			this.UpdateMissionRedPoint();
		}

		// Token: 0x0600EAF5 RID: 60149 RVA: 0x003E6D98 File Offset: 0x003E5198
		private void OnDeleteMission(uint taskID)
		{
			if (DataManager<MissionManager>.GetInstance().IsFinishingAwakeMission((int)taskID))
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
				if (clientSystemTown != null)
				{
					if (clientSystemTown.MainPlayer != null)
					{
						clientSystemTown.MainPlayer.SetPlayerAwakeState(true);
					}
					DataManager<PlayerBaseData>.GetInstance().bNeedShowAwakeFrame = true;
					if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LevelUpNotify>(null))
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<AwakeFrame>(FrameLayer.Middle, null, string.Empty);
					}
				}
			}
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.ChapterReward);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.ActivityDungeon);
			this.UpdateMissionRedPoint();
		}

		// Token: 0x0600EAF6 RID: 60150 RVA: 0x003E6E33 File Offset: 0x003E5233
		private void OnMissionChanged()
		{
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.ChapterReward);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.ActivityDungeon);
			this.UpdateMissionRedPoint();
		}

		// Token: 0x0600EAF7 RID: 60151 RVA: 0x003E6E59 File Offset: 0x003E5259
		private void _OnChestIdsChanged()
		{
			this._updateDailyRedPoint();
		}

		// Token: 0x0600EAF8 RID: 60152 RVA: 0x003E6E61 File Offset: 0x003E5261
		private void _OnActivityUpdate(ActiveManager.ActivityData data, ActiveManager.ActivityUpdateType EActivityUpdateType)
		{
			this.UpdateDayOnlineGiftText();
			this.UpdateUplevelGiftText();
			this.UpdateShowOppoLoginButton();
			this.UpdateShowChannelRankListButton();
			this.UpdateNewYearRedPackButton();
			this.UpdateTreasureConnvertButton();
		}

		// Token: 0x0600EAF9 RID: 60153 RVA: 0x003E6E88 File Offset: 0x003E5288
		private void _OnDumpAssetInfo()
		{
			List<string> list = new List<string>();
			Singleton<AssetPackageManager>.instance.DumpAssetPackageInfo(ref list);
			string text = string.Empty;
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				text += list[i];
				text += "\n";
				i++;
			}
			Debug.LogError(text);
			text = string.Empty;
			list.Clear();
			int j = 0;
			int count2 = list.Count;
			while (j < count2)
			{
				text += list[j];
				text += "\n";
				j++;
			}
			Debug.LogError(text);
		}

		// Token: 0x0600EAFA RID: 60154 RVA: 0x003E6F34 File Offset: 0x003E5334
		private void UpdatePkWaitingRoom(CitySceneTable TownTableData)
		{
			Singleton<ClientSystemManager>.GetInstance().bIsInPkWaitingRoom = true;
			base.SetForbidFadeIn(true);
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PkWaitingRoom>(null))
			{
				PkWaitingRoomData userData = new PkWaitingRoomData
				{
					SceneSubType = TownTableData.SceneSubType,
					CurrentSceneID = TownTableData.ID,
					TargetTownSceneID = TownTableData.BirthCity
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkWaitingRoom>(FrameLayer.Bottom, userData, string.Empty);
			}
		}

		// Token: 0x0600EAFB RID: 60155 RVA: 0x003E6FA4 File Offset: 0x003E53A4
		private void UpdateBudo(CitySceneTable TownTableData)
		{
			BudoArenaFrameData data = new BudoArenaFrameData
			{
				CurrentSceneID = TownTableData.ID,
				TargetTownSceneID = TownTableData.BirthCity
			};
			BudoArenaFrame.Open(data);
		}

		// Token: 0x0600EAFC RID: 60156 RVA: 0x003E6FD7 File Offset: 0x003E53D7
		private void UpdateGuildBattle()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildBattleFrame>(FrameLayer.Bottom, null, string.Empty);
		}

		// Token: 0x0600EAFD RID: 60157 RVA: 0x003E6FEC File Offset: 0x003E53EC
		private void UpdatePk3v3WaitingRoom(CitySceneTable TownTableData)
		{
			base.SetForbidFadeIn(true);
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3WaitingRoom>(null))
			{
				PkWaitingRoomData userData = new PkWaitingRoomData
				{
					SceneSubType = TownTableData.SceneSubType,
					CurrentSceneID = TownTableData.ID,
					TargetTownSceneID = TownTableData.BirthCity
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3WaitingRoom>(FrameLayer.Bottom, userData, string.Empty);
			}
		}

		// Token: 0x0600EAFE RID: 60158 RVA: 0x003E7050 File Offset: 0x003E5450
		private void UpdatePk3v3CrossWaitingRoom(CitySceneTable TownTableData)
		{
			base.SetForbidFadeIn(true);
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3CrossWaitingRoom>(null))
			{
				PkWaitingRoomData userData = new PkWaitingRoomData
				{
					SceneSubType = TownTableData.SceneSubType,
					CurrentSceneID = TownTableData.ID,
					TargetTownSceneID = TownTableData.BirthCity
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossWaitingRoom>(FrameLayer.Bottom, userData, string.Empty);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossTeamMainFrame>(FrameLayer.Bottom, null, string.Empty);
				Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(Pk3v3CrossTeamMainFrame)).GetFrame().CustomActive(true);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CrossUpdateMyTeamFrame, null, null, null, null);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossTeamMainMenuFrame>(FrameLayer.Bottom, null, string.Empty);
				Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(Pk3v3CrossTeamMainMenuFrame)).GetFrame().CustomActive(true);
				if (DataManager<Pk3v3CrossDataManager>.GetInstance().HasTeam())
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossMyTeamFrame>(FrameLayer.Middle, null, string.Empty);
					Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(Pk3v3CrossMyTeamFrame)).GetFrame().CustomActive(true);
				}
			}
		}

		// Token: 0x0600EAFF RID: 60159 RVA: 0x003E7168 File Offset: 0x003E5568
		private void UpdatePk2v2CrossWaitingRoom(CitySceneTable TownTableData)
		{
			base.SetForbidFadeIn(true);
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk2v2CrossWaitingRoomFrame>(null))
			{
				PkWaitingRoomData userData = new PkWaitingRoomData
				{
					SceneSubType = TownTableData.SceneSubType,
					CurrentSceneID = TownTableData.ID,
					TargetTownSceneID = TownTableData.BirthCity
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk2v2CrossWaitingRoomFrame>(FrameLayer.Bottom, userData, string.Empty);
			}
		}

		// Token: 0x0600EB00 RID: 60160 RVA: 0x003E71CC File Offset: 0x003E55CC
		private void UpdateFairBattleWaitingRoom(CitySceneTable TownTableData)
		{
			base.SetForbidFadeIn(true);
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<FairDuelWaitingRoomFrame>(null))
			{
				FairDueliRoomData userData = new FairDueliRoomData
				{
					SceneSubType = TownTableData.SceneSubType,
					CurrentSceneID = TownTableData.ID,
					TargetTownSceneID = TownTableData.TraditionSceneID
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<FairDuelWaitingRoomFrame>(FrameLayer.Bottom, userData, string.Empty);
			}
		}

		// Token: 0x0600EB01 RID: 60161 RVA: 0x003E7230 File Offset: 0x003E5630
		private void UpdateGuildArenaFrame(CitySceneTable TownTableData)
		{
			base.SetForbidFadeIn(true);
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<GuildArenaFrame>(null))
			{
				GuildArenaData userData = new GuildArenaData
				{
					SceneSubType = TownTableData.SceneSubType,
					CurrentSceneID = TownTableData.ID,
					TargetTownSceneID = TownTableData.TraditionSceneID
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildArenaFrame>(FrameLayer.Bottom, userData, string.Empty);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildDungeonShowFireworks, null, null, null, null);
		}

		// Token: 0x0600EB02 RID: 60162 RVA: 0x003E72A5 File Offset: 0x003E56A5
		private void UpdateTeamDuplicationBuildFrame(CitySceneTable townTableData)
		{
			base.SetForbidFadeIn(true);
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationMainBuildFrame>(null))
			{
				TeamDuplicationUtility.OnOpenTeamDuplicationMainBuildFrame();
			}
		}

		// Token: 0x0600EB03 RID: 60163 RVA: 0x003E72C3 File Offset: 0x003E56C3
		private void UpdateTeamDuplicationFightFrame(CitySceneTable townTableData)
		{
			base.SetForbidFadeIn(true);
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDuplicationMainFightFrame>(null))
			{
				TeamDuplicationUtility.OnOpenTeamDuplicationMainFightFrame();
			}
		}

		// Token: 0x0600EB04 RID: 60164 RVA: 0x003E72E1 File Offset: 0x003E56E1
		private void UpdateMainRoleInfo()
		{
			this.UpdatePlayerIcon();
			this.UpdatePlayerLevel();
			this.UpdateFatigue();
			this.UpdateExp(true);
			this.UpdateVipLevel();
			this.UpdatePlayerHeadPortraitFrame();
		}

		// Token: 0x0600EB05 RID: 60165 RVA: 0x003E7308 File Offset: 0x003E5708
		private void UpdatePlayerHeadPortraitFrame()
		{
			if (this.mReplaceHeadPortraitFrame != null)
			{
				if (HeadPortraitFrameDataManager.WearHeadPortraitFrameID != 0)
				{
					this.mReplaceHeadPortraitFrame.ReplacePhotoFrame(HeadPortraitFrameDataManager.WearHeadPortraitFrameID);
				}
				else
				{
					this.mReplaceHeadPortraitFrame.ReplacePhotoFrame(HeadPortraitFrameDataManager.iDefaultHeadPortraitID);
				}
			}
		}

		// Token: 0x0600EB06 RID: 60166 RVA: 0x003E7358 File Offset: 0x003E5758
		private void UpdatePlayerIcon()
		{
			string path = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					path = tableItem2.IconPath;
				}
			}
			if (this.mHeadIcon != null)
			{
				Image component = this.mHeadIcon.gameObject.GetComponent<Image>();
				if (component != null)
				{
					ETCImageLoader.LoadSprite(ref component, path, true);
				}
			}
		}

		// Token: 0x0600EB07 RID: 60167 RVA: 0x003E73F0 File Offset: 0x003E57F0
		private void UpdatePlayerLevel()
		{
			this.mPlayerLevel.text = DataManager<PlayerBaseData>.GetInstance().Level.ToString();
		}

		// Token: 0x0600EB08 RID: 60168 RVA: 0x003E7420 File Offset: 0x003E5820
		private void UpdateFatigue()
		{
			this.mFatigueText.text = DataManager<PlayerBaseData>.GetInstance().fatigue.ToString() + "/" + DataManager<PlayerBaseData>.GetInstance().MaxFatigue.ToString();
		}

		// Token: 0x0600EB09 RID: 60169 RVA: 0x003E746C File Offset: 0x003E586C
		private void UpdateExp(bool force = true)
		{
			this.DrawExpBar(force);
		}

		// Token: 0x0600EB0A RID: 60170 RVA: 0x003E7475 File Offset: 0x003E5875
		private void UpdateVipLevel()
		{
			this.mVipText.text = "贵" + DataManager<PlayerBaseData>.GetInstance().VipLevel;
		}

		// Token: 0x0600EB0B RID: 60171 RVA: 0x003E749B File Offset: 0x003E589B
		private void UpdateLocalTime()
		{
			this.mLocalTime.text = Singleton<PluginManager>.GetInstance().GetSystemTime_HHMM();
		}

		// Token: 0x0600EB0C RID: 60172 RVA: 0x003E74B2 File Offset: 0x003E58B2
		private void UpdateBattery()
		{
			this.mBattery.value = Singleton<PluginManager>.GetInstance().GetBatteryPower();
		}

		// Token: 0x0600EB0D RID: 60173 RVA: 0x003E74CC File Offset: 0x003E58CC
		private void UpdateRedPacket()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SceneType == CitySceneTable.eSceneType.NORMAL || tableItem.SceneType == CitySceneTable.eSceneType.SINGLE || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TRADITION || tableItem.SceneSubType == CitySceneTable.eSceneSubType.Pk3v3)
			{
				int waitOpenCount = DataManager<RedPackDataManager>.GetInstance().GetWaitOpenCount();
				this.mLabRedPacketCount.text = waitOpenCount.ToString();
				this.mRedPacket.gameObject.CustomActive(waitOpenCount > 0);
				this.mLabRedPacketCount.gameObject.CustomActive(waitOpenCount > 1);
			}
			else
			{
				this.mRedPacket.gameObject.CustomActive(false);
				this.mLabRedPacketCount.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600EB0E RID: 60174 RVA: 0x003E75B8 File Offset: 0x003E59B8
		private void UpdateUplevelGiftText()
		{
			ComTopButtonExpandController component = this.mBtShowHide.GetComponent<ComTopButtonExpandController>();
			if (component == null)
			{
				return;
			}
			this.mUpLevelGiftObj.SetActive(this.HaveLevelGift() && component.IsExpand());
		}

		// Token: 0x0600EB0F RID: 60175 RVA: 0x003E7600 File Offset: 0x003E5A00
		private bool HaveLevelGift()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(194, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			int value = tableItem.Value;
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(4000);
			if (activeData == null)
			{
				return false;
			}
			if (activeData.akChildItems == null)
			{
				return false;
			}
			int num = -1;
			int num2 = -1;
			Utility.CalShowUplevelGiftIndex(activeData, ref num, ref num2);
			int index;
			if (num != -1)
			{
				index = num;
			}
			else
			{
				if (num2 == -1)
				{
					return false;
				}
				index = num2;
			}
			if (activeData.akChildItems[index].activeItem.LevelLimit <= value)
			{
				this.mUplevelGiftText.text = string.Format("{0}级礼包", activeData.akChildItems[index].activeItem.LevelLimit);
				return true;
			}
			return false;
		}

		// Token: 0x0600EB10 RID: 60176 RVA: 0x003E76E8 File Offset: 0x003E5AE8
		private void UpdateDayOnlineGiftText()
		{
			if (this.mOnLineGift != null && this.mOnLineGift.gameObject.transform.parent != null)
			{
				this.mOnLineGift.gameObject.transform.parent.gameObject.CustomActive(this.HaveOnlineGift());
			}
		}

		// Token: 0x0600EB11 RID: 60177 RVA: 0x003E774C File Offset: 0x003E5B4C
		private bool HaveOnlineGift()
		{
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(5000);
			if (activeData == null)
			{
				return false;
			}
			if (activeData.akChildItems == null)
			{
				return false;
			}
			int num = -1;
			int num2 = -1;
			Utility.CalShowUplevelGiftIndex(activeData, ref num, ref num2);
			int index;
			if (num != -1)
			{
				index = num;
			}
			else
			{
				if (num2 == -1)
				{
					return false;
				}
				index = num2;
			}
			if (activeData.akChildItems[index].activeItem.Param0 == string.Empty)
			{
				return false;
			}
			int num3 = int.Parse(activeData.akChildItems[index].activeItem.Param0);
			int dayOnLineTime = Utility.GetDayOnLineTime();
			if (dayOnLineTime < num3 * 60)
			{
				this.mOnlIneGiftText.text = string.Format("{0}", Function.GetLeftTime(num3 * 60, dayOnLineTime, ShowtimeType.OnlineGift));
			}
			else
			{
				this.mOnlIneGiftText.text = "可领取";
			}
			return true;
		}

		// Token: 0x0600EB12 RID: 60178 RVA: 0x003E7844 File Offset: 0x003E5C44
		private void UpdateDuelOrChangeJobBtn()
		{
			if (DataManager<PlayerBaseData>.GetInstance().Level <= 15 && this.IsJobChangeAfter())
			{
				this.mBtnChangeJob.gameObject.CustomActive(true);
				this.mDuel.gameObject.CustomActive(false);
			}
			else
			{
				this.mBtnChangeJob.gameObject.CustomActive(false);
				this.mDuel.gameObject.CustomActive(true);
			}
		}

		// Token: 0x0600EB13 RID: 60179 RVA: 0x003E78B8 File Offset: 0x003E5CB8
		private void UpdateChallengeButton()
		{
			if (this.mChallenge != null)
			{
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level < DataManager<ChallengeDataManager>.GetInstance().ChallengeOpenLevel)
				{
					this.mChallenge.gameObject.CustomActive(false);
				}
				else
				{
					this.mChallenge.gameObject.CustomActive(true);
				}
			}
		}

		// Token: 0x0600EB14 RID: 60180 RVA: 0x003E7916 File Offset: 0x003E5D16
		private void UpdateDuelLockTip()
		{
			if (Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Duel))
			{
				this.mDuelTipRoot.SetActive(false);
			}
			else
			{
				this.mDuelTipRoot.SetActive(true);
			}
		}

		// Token: 0x0600EB15 RID: 60181 RVA: 0x003E7940 File Offset: 0x003E5D40
		private void UpdateSkillLearnTips()
		{
			bool flag = !DataManager<SkillDataManager>.GetInstance().IsSkillBarFull(SkillConfigType.SKILL_CONFIG_PVE) || !DataManager<SkillDataManager>.GetInstance().IsSkillBarFull(SkillConfigType.SKILL_CONFIG_PVP);
			if (DataManager<SkillDataManager>.GetInstance().IsShowSkillButton() && (flag || DataManager<SkillDataManager>.GetInstance().HasSkillLvCanUp()))
			{
				if (flag)
				{
					this.mBeStrongTipsText.text = TR.Value("skill point03");
				}
				else
				{
					this.mBeStrongTipsText.text = TR.Value("skill point02");
				}
				this.mRightLowerBubbleShowOrder.AddAnimation(BubbleShowType.Skill);
				ClientSystemTownFrame.IsShowSkillTips = true;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TipsAniStart, null, null, null, null);
			}
			else
			{
				this._SetSkillTipActive(false);
			}
		}

		// Token: 0x0600EB16 RID: 60182 RVA: 0x003E79FC File Offset: 0x003E5DFC
		private void OnSceneUpdateEquipHandBookTips()
		{
			bool flag = DataManager<EquipHandbookDataManager>.GetInstance().BIsHintEquipmentGuide() && Utility.IsUnLockFunc(70);
			if (flag)
			{
				this.mEquipHandBookTipsText.text = TR.Value("equiphandbookhint");
				this.mRightLowerBubbleShowOrder.AddAnimation(BubbleShowType.EquipHandBook);
				ClientSystemTownFrame.IsShowEquipHandBookTips = true;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TipsAniStart, null, null, null, null);
			}
			else
			{
				this._SetEquipHandBookTipActive(false);
			}
		}

		// Token: 0x0600EB17 RID: 60183 RVA: 0x003E7A70 File Offset: 0x003E5E70
		private void UpdateEquipHandBookTips()
		{
			bool flag = DataManager<EquipHandbookDataManager>.GetInstance().bIsHintEquipmentGuide();
			if (flag)
			{
				this.mEquipHandBookTipsText.text = TR.Value("equiphandbookhint");
				this.mRightLowerBubbleShowOrder.AddAnimation(BubbleShowType.EquipHandBook);
				ClientSystemTownFrame.IsShowEquipHandBookTips = true;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TipsAniStart, null, null, null, null);
			}
			else
			{
				this._SetEquipHandBookTipActive(false);
			}
		}

		// Token: 0x0600EB18 RID: 60184 RVA: 0x003E7AD4 File Offset: 0x003E5ED4
		private void UpdateGuildTips()
		{
			EGuildBattleState guildBattleState = DataManager<GuildDataManager>.GetInstance().GetGuildBattleState();
			if (guildBattleState < EGuildBattleState.Signup || guildBattleState > EGuildBattleState.LuckyDraw)
			{
				this._SetGuildTipActive(false);
				return;
			}
			if (guildBattleState == EGuildBattleState.Signup && DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() != GuildBattleType.GBT_CHALLENGE)
			{
				this._SetGuildTipActive(false);
				return;
			}
			if (guildBattleState >= EGuildBattleState.Preparing && guildBattleState <= EGuildBattleState.Firing && !DataManager<GuildDataManager>.GetInstance().HasTargetManor())
			{
				this._SetGuildTipActive(false);
				return;
			}
			if (guildBattleState == EGuildBattleState.LuckyDraw && DataManager<GuildDataManager>.GetInstance().HasGuildBattleLotteryed())
			{
				this._SetGuildTipActive(false);
				return;
			}
			this._SetSkillTipActive(false);
			this.mRightLowerBubbleShowOrder.AddAnimation(BubbleShowType.Guild);
			if (guildBattleState == EGuildBattleState.Signup)
			{
				this.mGuildTipsText.text = TR.Value("guild_battle_challenge");
			}
			else if (guildBattleState == EGuildBattleState.Preparing)
			{
				this.mGuildTipsText.text = TR.Value("guild_battle_prepare");
			}
			else if (guildBattleState == EGuildBattleState.Firing)
			{
				this.mGuildTipsText.text = TR.Value("guild_battle_fire");
			}
			else
			{
				this.mGuildTipsText.text = TR.Value("guild_battle_lottery");
			}
		}

		// Token: 0x0600EB19 RID: 60185 RVA: 0x003E7BF0 File Offset: 0x003E5FF0
		private void UpdateGuildEffect()
		{
			if (this.mGuildBattleEffect == null)
			{
				return;
			}
			bool flag = DataManager<GuildDataManager>.GetInstance().IsGuildDungeonActivityOpen();
			EGuildBattleState guildBattleState = DataManager<GuildDataManager>.GetInstance().GetGuildBattleState();
			bool flag2 = false;
			if (guildBattleState >= EGuildBattleState.Preparing && guildBattleState <= EGuildBattleState.Firing && DataManager<GuildDataManager>.GetInstance().HasTargetManor())
			{
				flag2 = true;
			}
			if (flag2 || flag)
			{
				this.mGuildBattleEffect.gameObject.CustomActive(true);
				this.mGuildBattleEffect.gameObject.CustomActive(true);
			}
			else
			{
				this.mGuildBattleEffect.gameObject.CustomActive(false);
				this.mGuildBattleEffect.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600EB1A RID: 60186 RVA: 0x003E7C9B File Offset: 0x003E609B
		private void OnSkillTipsAniComplete()
		{
			ClientSystemTownFrame.IsShowSkillTips = false;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TipsAniEnd, null, null, null, null);
		}

		// Token: 0x0600EB1B RID: 60187 RVA: 0x003E7CB6 File Offset: 0x003E60B6
		private void OnGuildTipsAniComPlete()
		{
			ClientSystemTownFrame.IsShowGuildTips = false;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TipsAniEnd, null, null, null, null);
		}

		// Token: 0x0600EB1C RID: 60188 RVA: 0x003E7CD1 File Offset: 0x003E60D1
		private void OnEquipHandBookAniComPlete()
		{
			ClientSystemTownFrame.IsShowEquipHandBookTips = false;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TipsAniEnd, null, null, null, null);
		}

		// Token: 0x0600EB1D RID: 60189 RVA: 0x003E7CEC File Offset: 0x003E60EC
		private void UpdateShowButton()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<FunctionUnLock>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				FunctionUnLock functionUnLock = keyValuePair.Value as FunctionUnLock;
				if (!(functionUnLock.TargetBtnPos == string.Empty) && !(functionUnLock.TargetBtnPos == "-") && functionUnLock.bShowBtn != 1)
				{
					if (functionUnLock.FuncType != FunctionUnLock.eFuncType.AdventurePassSeason)
					{
						GameObject gameObject = Utility.FindGameObject(this.frame, functionUnLock.TargetBtnPos, true);
						if (!(gameObject == null))
						{
							bool flag = false;
							for (int i = 0; i < DataManager<PlayerBaseData>.GetInstance().UnlockFuncList.Count; i++)
							{
								if (functionUnLock.ID == DataManager<PlayerBaseData>.GetInstance().UnlockFuncList[i])
								{
									flag = true;
									break;
								}
							}
							if (functionUnLock.FuncType == FunctionUnLock.eFuncType.Duel)
							{
								flag = true;
							}
							if (flag)
							{
								gameObject.SetActive(true);
							}
							else
							{
								gameObject.SetActive(false);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600EB1E RID: 60190 RVA: 0x003E7E20 File Offset: 0x003E6220
		public void UpdateBeStrongExpand(bool bExpand)
		{
			if (this.mBeStrong != null)
			{
				ComExpandController component = this.mBeStrong.GetComponent<ComExpandController>();
				if (component == null)
				{
					return;
				}
				component.UpdateExpand(bExpand);
			}
		}

		// Token: 0x0600EB1F RID: 60191 RVA: 0x003E7E5E File Offset: 0x003E625E
		private void UpdateChangeJobSelBtnShow()
		{
		}

		// Token: 0x0600EB20 RID: 60192 RVA: 0x003E7E60 File Offset: 0x003E6260
		private void UpdateChangeJobTaskBtnShow()
		{
			if (this.mChangeJobTask == null)
			{
				return;
			}
			if (!Utility.CheckShowChangeJobTaskBtn() || Singleton<ClientSystemManager>.GetInstance().bIsInPkWaitingRoom)
			{
				this.mChangeJobTask.gameObject.SetActive(false);
			}
			else
			{
				this.mChangeJobTask.gameObject.SetActive(true);
			}
		}

		// Token: 0x0600EB21 RID: 60193 RVA: 0x003E7EC0 File Offset: 0x003E62C0
		public void UpdatePay(bool needOpenWindow = true)
		{
			if (Singleton<PayManager>.GetInstance().HasFirstPay() || Singleton<PayManager>.GetInstance().HasConsumePay())
			{
				this.mFirstRecharge.gameObject.SetActive(true);
				this.mFirstRechargeRedPoint.gameObject.SetActive(Singleton<PayManager>.GetInstance().CanGetRewards(0));
			}
			else
			{
				this.mFirstRecharge.gameObject.SetActive(false);
			}
			if (needOpenWindow && Singleton<PayManager>.GetInstance().HasNewActivityFinish())
			{
				this._onFirstRechargeButtonClick();
			}
		}

		// Token: 0x0600EB22 RID: 60194 RVA: 0x003E7F48 File Offset: 0x003E6348
		private void UpdateGuildBattle(EGuildBattleState a_eOldState, EGuildBattleState a_eNewState)
		{
			NotifyInfo a_info = new NotifyInfo
			{
				type = 1U
			};
			if (a_eNewState == EGuildBattleState.Preparing || a_eNewState == EGuildBattleState.Firing)
			{
				DataManager<ActivityNoticeDataManager>.GetInstance().AddActivityNotice(a_info);
				DataManager<DeadLineReminderDataManager>.GetInstance().AddActivityNotice(a_info);
			}
			else
			{
				DataManager<ActivityNoticeDataManager>.GetInstance().DeleteActivityNotice(a_info);
				DataManager<DeadLineReminderDataManager>.GetInstance().DeleteActivityNotice(a_info);
			}
			CitySceneTable.eSceneSubType eSceneSubType;
			ClientSystemTown.GetCurrentSceneSubType(out eSceneSubType);
			if (eSceneSubType != CitySceneTable.eSceneSubType.GuildBattle && eSceneSubType != CitySceneTable.eSceneSubType.CrossGuildBattle)
			{
				if (!DataManager<GuildDataManager>.GetInstance().isBattleNotifyInited || a_eOldState != a_eNewState)
				{
					if (a_eNewState == EGuildBattleState.Preparing || a_eNewState == EGuildBattleState.Firing)
					{
					}
					DataManager<GuildDataManager>.GetInstance().isBattleNotifyInited = true;
				}
			}
			else
			{
				DataManager<GuildDataManager>.GetInstance().isBattleNotifyInited = true;
			}
			this.UpdateGuildEffect();
			this.UpdateGuildTips();
		}

		// Token: 0x0600EB23 RID: 60195 RVA: 0x003E8004 File Offset: 0x003E6404
		private void UpdateMissionRedPoint()
		{
			if (this.frame == null)
			{
				return;
			}
			int num = 0;
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(4, string.Empty, string.Empty);
			if (tableItem != null)
			{
				num = tableItem.FinishLevel;
			}
			bool flag = (int)DataManager<PlayerBaseData>.GetInstance().Level >= num;
			num = 0;
			tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(10, string.Empty, string.Empty);
			if (tableItem != null)
			{
				num = tableItem.FinishLevel;
			}
			bool flag2 = (int)DataManager<PlayerBaseData>.GetInstance().Level >= num;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			List<MissionManager.SingleMissionInfo> list = DataManager<MissionManager>.GetInstance().taskGroup.Values.ToList<MissionManager.SingleMissionInfo>();
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] != null && list[i].missionItem != null)
				{
					if (list[i].status == 2)
					{
						if (!flag5 && (list[i].missionItem.TaskType == MissionTable.eTaskType.TT_BRANCH || list[i].missionItem.TaskType == MissionTable.eTaskType.TT_MAIN || list[i].missionItem.TaskType == MissionTable.eTaskType.TT_CYCLE))
						{
							flag5 = true;
						}
						if (!flag3 && flag2 && list[i].missionItem.TaskType == MissionTable.eTaskType.TT_DIALY && list[i].missionItem.SubType == MissionTable.eSubType.Daily_Task)
						{
							flag3 = true;
						}
						if (!flag4 && flag && list[i].missionItem.TaskType == MissionTable.eTaskType.TT_ACHIEVEMENT && list[i].missionItem.SubType == MissionTable.eSubType.Daily_Null)
						{
							flag4 = true;
						}
					}
				}
			}
			bool flag6 = flag4 || flag5;
		}

		// Token: 0x0600EB24 RID: 60196 RVA: 0x003E81F3 File Offset: 0x003E65F3
		private void UpdateSkillTipsState()
		{
			if (DataManager<SkillDataManager>.GetInstance().bNoticeSkillLvUp)
			{
				this.UpdateSkillLearnTips();
				DataManager<SkillDataManager>.GetInstance().bNoticeSkillLvUp = false;
			}
		}

		// Token: 0x0600EB25 RID: 60197 RVA: 0x003E8218 File Offset: 0x003E6618
		private void UpdateMallGiftNotice()
		{
			if (DataManager<ChijiDataManager>.GetInstance().SwitchingPrepareToTown)
			{
				return;
			}
			if (!this.mIsCanShowGiftFrame)
			{
				return;
			}
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance() != null && DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager != null)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.SendReqLimitGiftData();
			}
			if (Singleton<LimitTimeGiftFrameManager>.GetInstance() != null)
			{
				Singleton<LimitTimeGiftFrameManager>.GetInstance().WaitToShowLimitTimeGiftFrame();
			}
		}

		// Token: 0x0600EB26 RID: 60198 RVA: 0x003E827D File Offset: 0x003E667D
		public sealed override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600EB27 RID: 60199 RVA: 0x003E8280 File Offset: 0x003E6680
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			if (this._inputManager != null)
			{
				this._inputManager.SingleUpdate(0);
			}
			this.CheckLevelUp();
			this._UpdateTownMap();
			this.DayOnlineInterval += timeElapsed;
			this.TimeFreshInterval += timeElapsed;
			this.BatteryFreshInterval += timeElapsed;
			if (this.DayOnlineInterval > 1f)
			{
				this.DayOnlineInterval = 0f;
				this.UpdateDayOnlineGiftText();
				this.UpdateMainPlayerLevel();
			}
			if (this.TimeFreshInterval > 30f)
			{
				this.TimeFreshInterval = 0f;
				this.UpdateLocalTime();
			}
			if (this.BatteryFreshInterval > 180f)
			{
				this.BatteryFreshInterval = 0f;
				this.UpdateBattery();
			}
			if (this.mPrivateCustomBubbles != null && this.mPrivateCustomBubbles.gameObject.activeInHierarchy)
			{
				if (this.mPrivateCustomBubbles.gameObject.activeSelf)
				{
					this.mPrivateCustomBubbles.gameObject.CustomActive(false);
				}
				this.PrivateCustomBubbleTime += timeElapsed;
				if (this.PrivateCustomBubbleTime >= 60f)
				{
					this.mPrivateCustomBubbles.gameObject.CustomActive(false);
					base.StartCoroutine(this.mPrivateCustomShowOrHide(300f));
					this.PrivateCustomBubbleTime = 0f;
				}
			}
			this.UpdateCheckFPS(timeElapsed);
			DataManager<OnlineServiceManager>.GetInstance().UpdateReqOfflineInfos(timeElapsed);
		}

		// Token: 0x0600EB28 RID: 60200 RVA: 0x003E83F0 File Offset: 0x003E67F0
		private void UpdateMainPlayerLevel()
		{
			if (this.mPlayerLevel != null)
			{
				this.mPlayerLevel.text = DataManager<PlayerBaseData>.GetInstance().Level.ToString();
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null && clientSystemTown.MainPlayer != null && clientSystemTown.MainPlayer.GraphicActor != null)
			{
				clientSystemTown.MainPlayer.GraphicActor.OnLevelChanged((int)DataManager<PlayerBaseData>.GetInstance().Level);
			}
		}

		// Token: 0x0600EB29 RID: 60201 RVA: 0x003E847C File Offset: 0x003E687C
		protected void UpdateCheckFPS(float delta)
		{
			this.fpsAcc += delta;
			if (this.fpsAcc >= (float)MonoSingleton<ComponentFPS>.instance.watchFrames)
			{
				this.fpsAcc -= (float)MonoSingleton<ComponentFPS>.instance.watchFrames;
				Singleton<GeGraphicSetting>.instance.CheckTownFPS();
			}
		}

		// Token: 0x0600EB2A RID: 60202 RVA: 0x003E84D0 File Offset: 0x003E68D0
		private void ShowGraphicTip()
		{
			if (this.mGraphicTips.gameObject.activeSelf)
			{
				return;
			}
			this.mGraphicTipsText.text = TR.Value("graphic_set_tip");
			DOTweenAnimation[] components = this.mGraphicTips.GetComponents<DOTweenAnimation>();
			DOTweenAnimation[] components2 = this.mGraphicTipsText.GetComponents<DOTweenAnimation>();
			if (components != null && components2 != null)
			{
				for (int i = 0; i < components.Length; i++)
				{
					if (components[i] != null)
					{
						components[i].DORestart(false);
						components[i].onComplete.RemoveAllListeners();
						if (i == 2)
						{
							components[i].onComplete.AddListener(new UnityAction(this._onGraphicTipsButtonClick));
						}
					}
					if (i < components2.Length && components2[i] != null)
					{
						components2[i].DORestart(false);
					}
				}
			}
			this.mGraphicTips.gameObject.CustomActive(true);
		}

		// Token: 0x0600EB2B RID: 60203 RVA: 0x003E85B8 File Offset: 0x003E69B8
		private IEnumerator mPrivateCustomShowOrHide(float waitTime)
		{
			yield return Yielders.GetWaitForSeconds(waitTime);
			this.mPrivateCustomBubbles.gameObject.CustomActive(false);
			yield break;
		}

		// Token: 0x0600EB2C RID: 60204 RVA: 0x003E85DA File Offset: 0x003E69DA
		protected void _OnMailListReq()
		{
			MailDataManager.OnSendMailListReq();
		}

		// Token: 0x0600EB2D RID: 60205 RVA: 0x003E85E4 File Offset: 0x003E69E4
		[MessageHandle(601503U, false, 0)]
		protected void _OnWorldMailListRes(MsgDATA msg)
		{
			WorldMailListRet worldMailListRet = new WorldMailListRet();
			worldMailListRet.decode(msg.bytes);
			DataManager<PlayerBaseData>.GetInstance().mails.mailList.Clear();
			DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList.Clear();
			for (int i = 0; i < worldMailListRet.mails.Length; i++)
			{
				if (worldMailListRet.mails[i].type == 2)
				{
					DataManager<PlayerBaseData>.GetInstance().mails.mailList.Add(worldMailListRet.mails[i]);
				}
				else
				{
					DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList.Add(worldMailListRet.mails[i]);
				}
			}
			DataManager<PlayerBaseData>.GetInstance().mails.SortMailList();
			DataManager<PlayerBaseData>.GetInstance().mails.UpdateOneKeyNum();
			DataManager<PlayerBaseData>.GetInstance().mails.SortRewardMailList();
			DataManager<PlayerBaseData>.GetInstance().mails.UpdateOneKeyRewardNum();
		}

		// Token: 0x0600EB2E RID: 60206 RVA: 0x003E86D0 File Offset: 0x003E6AD0
		private void _StartOpenFollowingQueue()
		{
			DataManager<FollowingOpenQueueManager>.GetInstance().StartOpenFollowingQueue();
		}

		// Token: 0x0600EB2F RID: 60207 RVA: 0x003E86DC File Offset: 0x003E6ADC
		private void _TryOpenActiveFrame(FollowingOpenTrigger trigger)
		{
			if (Singleton<ClientSystemManager>.GetInstance().PreSystemType != typeof(ClientSystemLogin))
			{
				return;
			}
			if (!Singleton<LoginPushManager>.GetInstance().IsFirstLogin())
			{
				return;
			}
			int[] array = new int[]
			{
				8100,
				3000
			};
			int[] array2 = new int[]
			{
				9,
				9
			};
			bool flag = false;
			for (int i = 0; i < array.Length; i++)
			{
				ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(array[i]);
				if (activeData != null)
				{
					if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= array2[i])
					{
						ActiveManager.ActivityData activityData = activeData.akChildItems.Find((ActiveManager.ActivityData x) => x.status == 2);
						if (activityData != null)
						{
							DataManager<ActiveManager>.GetInstance().OpenActiveFrame(activeData.mainItem.ActiveTypeID, array[i]);
							flag = true;
							break;
						}
					}
				}
			}
			if (!flag)
			{
				this.UpdateGuildEffect();
				this.UpdateGuildTips();
				this.UpdateSkillTipsState();
			}
			else if (trigger != null)
			{
				trigger.triggerType = FollowingOpenTriggerType.Normal;
			}
		}

		// Token: 0x0600EB30 RID: 60208 RVA: 0x003E8800 File Offset: 0x003E6C00
		private void CheckLevelUp()
		{
			if (!DataManager<PlayerBaseData>.GetInstance().bLevelUpChange || ClientSystemTownFrame.bGuardForNotify)
			{
				return;
			}
			if (!ClientSystem.IsCurrentSystemStart())
			{
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance().Level < 5)
			{
				return;
			}
			if (Singleton<NewbieGuideManager>.GetInstance().IsGuidingControl())
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TaskDialogFrame>(null) || Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AwakeFrame>(null))
			{
				return;
			}
			ClientSystemTownFrame.bGuardForNotify = true;
			InvokeMethod.Invoke(MonoSingleton<LeanTween>.instance.LevelUpNotifyDelay, delegate()
			{
				DataManager<PlayerBaseData>.GetInstance().bLevelUpChange = false;
				ClientSystemTownFrame.bGuardForNotify = false;
				if ((DataManager<SkillDataManager>.GetInstance().HasNewSkillorSkillCanUp() || Utility.HasNewFunc()) && DataManager<PlayerBaseData>.GetInstance().Level >= 5)
				{
					this.frameMgr.OpenFrame<LevelUpNotify>(FrameLayer.Middle, null, string.Empty);
				}
				else
				{
					UIEvent uiEvent = new UIEvent
					{
						EventID = EUIEventID.CheckAllNewbieGuide
					};
					GlobalEventSystem.GetInstance().SendUIEvent(uiEvent);
				}
			});
		}

		// Token: 0x0600EB31 RID: 60209 RVA: 0x003E8895 File Offset: 0x003E6C95
		private void DrawExpBar(bool force = true)
		{
			this.mExpBar.SetExp(DataManager<PlayerBaseData>.GetInstance().Exp, force, (ulong exp) => Singleton<TableManager>.instance.GetCurRoleExp(exp));
		}

		// Token: 0x0600EB32 RID: 60210 RVA: 0x003E88CC File Offset: 0x003E6CCC
		private void _OnShowChangeJobDialog()
		{
			if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown))
			{
				return;
			}
			IList<int> nextJobsIDByCurJobID = Singleton<TableManager>.GetInstance().GetNextJobsIDByCurJobID(DataManager<PlayerBaseData>.GetInstance().JobTableID);
			if (nextJobsIDByCurJobID != null)
			{
				return;
			}
			if (ClientSystemTown.ChangeJobEnd)
			{
				return;
			}
			this._JobChangeSuccessFrame();
			ClientSystemTown.ChangeJobEnd = true;
		}

		// Token: 0x0600EB33 RID: 60211 RVA: 0x003E8924 File Offset: 0x003E6D24
		private void _JobChangeSuccessFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChangeJobTaskProPanel>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChangeJobTaskProPanel>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChangeJobFinish>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChangeJobFinish>(null, false);
			}
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle != null)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChangeJobFinish>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600EB34 RID: 60212 RVA: 0x003E8992 File Offset: 0x003E6D92
		private void _SetSkillTipActive(bool bActive)
		{
			this.mBeStrongTips.CustomActive(bActive);
		}

		// Token: 0x0600EB35 RID: 60213 RVA: 0x003E89A0 File Offset: 0x003E6DA0
		private void _SetEquipHandBookTipActive(bool bActive)
		{
			if (bActive)
			{
				this.mEquipHandBookTips.gameObject.CustomActive(true);
			}
			else
			{
				this.mEquipHandBookTips.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600EB36 RID: 60214 RVA: 0x003E89CF File Offset: 0x003E6DCF
		private void _setJarTipsActive(bool bActive)
		{
			if (bActive)
			{
				this.mJarTips.gameObject.CustomActive(true);
			}
			else
			{
				this.mJarTips.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600EB37 RID: 60215 RVA: 0x003E8A00 File Offset: 0x003E6E00
		private void _SetGuildTipActive(bool bActive)
		{
			if (bActive)
			{
				if (this.mGuildTips != null)
				{
					this.mGuildTips.gameObject.CustomActive(true);
				}
			}
			else if (this.mGuildTips != null)
			{
				this.mGuildTips.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600EB38 RID: 60216 RVA: 0x003E8A5C File Offset: 0x003E6E5C
		private void _OnJoyStickStop()
		{
			this.mIsStopMoveFunction = false;
			this.mLastJoyStickFizzyCheck = false;
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null && clientSystemTown.MainPlayer != null)
			{
				if (clientSystemTown.MainPlayer.MoveState == BeTownPlayerMain.EMoveState.AutoMoving)
				{
					return;
				}
				clientSystemTown.MainPlayer.CommandStopMove();
			}
		}

		// Token: 0x0600EB39 RID: 60217 RVA: 0x003E8AB8 File Offset: 0x003E6EB8
		private void _OnJoyStickMove(Vector2 pos)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown.MainPlayer == null)
			{
				return;
			}
			if (pos == Vector2.zero)
			{
				return;
			}
			if (this.mLastJoyStickFizzyCheck)
			{
				if ((this.mLastJoyStickPosition - pos).magnitude < 0.438f)
				{
					return;
				}
				this.mLastJoyStickFizzyCheck = false;
			}
			this.mLastJoyStickPosition = pos;
			if (this.mIsStopMoveFunction)
			{
				return;
			}
			Vector2 normalized = pos.normalized;
			if (normalized.x > this.m_sin60)
			{
				normalized.x = 1f;
				normalized.y = 0f;
			}
			else if (normalized.x > this.m_sin30 && normalized.x <= this.m_sin60)
			{
				normalized.x = this.m_sin45;
				if (normalized.y > 0f)
				{
					normalized.y = this.m_sin45;
				}
				else
				{
					normalized.y = -this.m_sin45;
				}
			}
			else if (normalized.x > -this.m_sin30 && normalized.x <= this.m_sin30)
			{
				normalized.x = 0f;
				if (normalized.y > 0f)
				{
					normalized.y = 1f;
				}
				else
				{
					normalized.y = -1f;
				}
			}
			else if (normalized.x > -this.m_sin60 && normalized.x <= -this.m_sin30)
			{
				normalized.x = -this.m_sin45;
				if (normalized.y > 0f)
				{
					normalized.y = this.m_sin45;
				}
				else
				{
					normalized.y = -this.m_sin45;
				}
			}
			else if (normalized.x <= -this.m_sin60)
			{
				normalized.x = -1f;
				normalized.y = 0f;
			}
			Vector3 vector;
			vector..ctor(normalized.x, 0f, normalized.y);
			if (clientSystemTown.MainPlayer.ActorData.MoveData.TargetDirection != vector)
			{
				clientSystemTown.MainPlayer.CommandMoveForward(vector);
			}
		}

		// Token: 0x0600EB3A RID: 60218 RVA: 0x003E8D14 File Offset: 0x003E7114
		private bool _IsOppoLogin()
		{
			if (!SDKInterface.instance.IsOppoPlatform() && !SDKInterface.instance.IsVivoPlatForm())
			{
				return false;
			}
			if (!DataManager<OPPOPrivilegeDataManager>.GetInstance()._ActiveIsOpen())
			{
				return false;
			}
			if (SDKInterface.instance.IsOppoPlatform())
			{
				Singleton<GameStatisticManager>.GetInstance().DoStartOPPO(StartOPPOType.OPPOICON, string.Empty);
			}
			else if (SDKInterface.instance.IsVivoPlatForm())
			{
				Singleton<GameStatisticManager>.GetInstance().DoStartVIVO(StartVIVOType.VIVOICON);
			}
			return true;
		}

		// Token: 0x0600EB3B RID: 60219 RVA: 0x003E8D94 File Offset: 0x003E7194
		private bool _isChanneRankBtn()
		{
			int currVersionApi = Singleton<PluginManager>.instance.GetCurrVersionApi();
			if (currVersionApi <= 19)
			{
				return false;
			}
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(21100);
			ActiveManager.ActiveData activeData2 = DataManager<ActiveManager>.GetInstance().GetActiveData(21200);
			ActiveManager.ActiveData activeData3 = DataManager<ActiveManager>.GetInstance().GetActiveData(21300);
			ActiveManager.ActiveData activeData4 = DataManager<ActiveManager>.GetInstance().GetActiveData(21400);
			ActiveManager.ActiveData activeData5 = DataManager<ActiveManager>.GetInstance().GetActiveData(21500);
			return (activeData != null && SDKInterface.instance.CheckPlatformBySDKChannel(SDKChannel.HuaWei)) || (activeData2 != null && SDKInterface.instance.CheckPlatformBySDKChannel(SDKChannel.OPPO)) || (activeData3 != null && SDKInterface.instance.CheckPlatformBySDKChannel(SDKChannel.VIVO)) || (activeData4 != null && SDKInterface.instance.CheckPlatformBySDKChannel(SDKChannel.XiaoMi)) || (activeData5 != null && SDKInterface.instance.CheckPlatformBySDKChannel(SDKChannel.MeiZu));
		}

		// Token: 0x0600EB3C RID: 60220 RVA: 0x003E8E88 File Offset: 0x003E7288
		private bool IsOperateAdsBtnShow()
		{
			if (!Singleton<PluginManager>.instance.IsSDKEnableSystemVersion(SDKInterface.FuncSDKType.FSDK_UniWebView))
			{
				return false;
			}
			if (string.IsNullOrEmpty(ClientApplication.operateAdsServer))
			{
				return false;
			}
			string s = TR.Value("operateAds_unlock_level");
			int num = 10;
			return !int.TryParse(s, out num) || num <= (int)DataManager<PlayerBaseData>.GetInstance().Level;
		}

		// Token: 0x0600EB3D RID: 60221 RVA: 0x003E8EE8 File Offset: 0x003E72E8
		private void _showJarTip()
		{
			DOTweenAnimation[] components = this.mJarTips.GetComponents<DOTweenAnimation>();
			DOTweenAnimation[] components2 = this.mJarTipsText.GetComponents<DOTweenAnimation>();
			if (components != null && components2 != null)
			{
				for (int i = 0; i < components.Length; i++)
				{
					if (components[i] != null)
					{
						components[i].DORestart(false);
					}
					if (i < components2.Length && components2[i] != null)
					{
						components2[i].DORestart(false);
					}
				}
			}
			this._setJarTipsActive(true);
		}

		// Token: 0x0600EB3E RID: 60222 RVA: 0x003E8F6C File Offset: 0x003E736C
		protected sealed override void _bindExUI()
		{
			this.mHeadIcon = this.mBind.GetCom<Button>("HeadIcon");
			this.mHeadIcon.onClick.AddListener(new UnityAction(this._onHeadIconButtonClick));
			this.mVipText = this.mBind.GetCom<Text>("VipText");
			this.mTalkRoot = this.mBind.GetGameObject("TalkRoot");
			this.mPlayerLevel = this.mBind.GetCom<Text>("PlayerLevel");
			this.mExpBar = this.mBind.GetCom<ComExpBar>("ExpBar");
			this.mFatigueText = this.mBind.GetCom<Text>("FatigueText");
			this.mPackage = this.mBind.GetCom<Button>("Package");
			this.mPackage.onClick.AddListener(new UnityAction(this._onPackageButtonClick));
			this.mFriend = this.mBind.GetCom<Button>("Friend");
			this.mFriend.onClick.AddListener(new UnityAction(this._onFriendButtonClick));
			this.mGuild = this.mBind.GetCom<Button>("Guild");
			this.mGuild.onClick.AddListener(new UnityAction(this._onGuildButtonClick));
			this.mMall = this.mBind.GetCom<Button>("Mall");
			this.mMall.onClick.AddListener(new UnityAction(this._onMallButtonClick));
			this.mAuction = this.mBind.GetCom<Button>("Auction");
			this.mAuction.onClick.AddListener(new UnityAction(this._onAuctionButtonClick));
			this.mRankList = this.mBind.GetCom<Button>("RankList");
			this.mRankList.onClick.AddListener(new UnityAction(this._onRankListButtonClick));
			this.mNextOpenIcon = this.mBind.GetCom<Image>("NextOpenIcon");
			this.mNextopen = this.mBind.GetCom<Button>("nextopen");
			this.mNextopen.onClick.AddListener(new UnityAction(this._onNextopenButtonClick));
			this.mNextOpenLv = this.mBind.GetCom<Text>("NextOpenLv");
			this.mNextOpenName = this.mBind.GetCom<Text>("NextOpenName");
			this.mChangeJob = this.mBind.GetCom<Button>("ChangeJob");
			this.mChangeJob.onClick.AddListener(new UnityAction(this._onChangeJobButtonClick));
			this.mChangeJobTask = this.mBind.GetCom<Button>("ChangeJobTask");
			this.mChangeJobTask.onClick.AddListener(new UnityAction(this._onChangeJobTaskButtonClick));
			this.mDuel = this.mBind.GetCom<Button>("Duel");
			this.mDuel.onClick.AddListener(new UnityAction(this._onDuelButtonClick));
			this.mVipLevel = this.mBind.GetCom<Button>("VipLevel");
			this.mVipLevel.onClick.AddListener(new UnityAction(this._onVipLevelButtonClick));
			this.mBtVip = this.mBind.GetCom<Button>("BtVip");
			this.mBtVip.onClick.AddListener(new UnityAction(this._onBtVipButtonClick));
			this.mFirstRecharge = this.mBind.GetCom<Button>("FirstRecharge");
			this.mFirstRecharge.onClick.AddListener(new UnityAction(this._onFirstRechargeButtonClick));
			this.mWelFare = this.mBind.GetCom<Button>("WelFare");
			this.mWelFare.onClick.AddListener(new UnityAction(this._onWelFareButtonClick));
			this.mJar = this.mBind.GetCom<Button>("Jar");
			this.mJar.onClick.AddListener(new UnityAction(this._onJarButtonClick));
			this.mDaily = this.mBind.GetCom<Button>("Daily");
			this.mDaily.onClick.AddListener(new UnityAction(this._onDailyButtonClick));
			this.mBeStrong = this.mBind.GetCom<Button>("BeStrong");
			this.mBeStrong.onClick.AddListener(new UnityAction(this._onBeStrongButtonClick));
			this.mRedPacket = this.mBind.GetCom<Button>("RedPacket");
			this.mRedPacket.onClick.AddListener(new UnityAction(this._onRedPacketButtonClick));
			this.mLabRedPacketCount = this.mBind.GetCom<Text>("labRedPacketCount");
			this.mFriendRedPoint = this.mBind.GetCom<Image>("FriendRedPoint");
			this.mPackageFull = this.mBind.GetCom<Image>("PackageFull");
			this.mPackageAnim = this.mBind.GetCom<DOTweenAnimation>("PackageAnim");
			this.mGuildRedPoint = this.mBind.GetCom<Image>("GuildRedPoint");
			this.mPackageRedPoint = this.mBind.GetCom<Image>("PackageRedPoint");
			this.mDuelRedPoint = this.mBind.GetCom<Image>("DuelRedPoint");
			this.mFirstRechargeRedPoint = this.mBind.GetCom<Image>("FirstRechargeRedPoint");
			this.mBtSkill = this.mBind.GetCom<Button>("BtSkill");
			this.mBtSkill.onClick.AddListener(new UnityAction(this._onBtSkillButtonClick));
			this.mBtForge = this.mBind.GetCom<Button>("BtForge");
			this.mBtForge.onClick.AddListener(new UnityAction(this._onBtForgeButtonClick));
			this.mBtFashionMerge = this.mBind.GetCom<Button>("BtFashionMerge");
			this.mBtFashionMerge.onClick.AddListener(new UnityAction(this._onBtFashionMergeButtonClick));
			this.mBtTitleBook = this.mBind.GetCom<Button>("BtTitleBook");
			this.mBtTitleBook.onClick.AddListener(new UnityAction(this._onBtTitleBookButtonClick));
			this.mBtEquipForge = this.mBind.GetCom<Button>("BtEquipForge");
			this.mBtEquipForge.onClick.AddListener(new UnityAction(this._onBtEquipForgeButtonClick));
			this.mWantStrong = this.mBind.GetCom<Button>("WantStrong");
			this.mWantStrong.onClick.AddListener(new UnityAction(this._onWantStrongButtonClick));
			this.mSkillRedPoint = this.mBind.GetCom<Image>("SkillRedPoint");
			this.mEquipForgeRedPoint = this.mBind.GetCom<Image>("EquipForgeRedPoint");
			this.mJarsRedPoint = this.mBind.GetCom<Image>("JarsRedPoint");
			this.mForgeRedPoint = this.mBind.GetCom<Image>("ForgeRedPoint");
			this.mJarRedPoint = this.mBind.GetGameObject("JarRedPoint");
			this.mUpLevelGiftObj = this.mBind.GetGameObject("UpLevelGiftObj");
			this.mBtUpLevelGift = this.mBind.GetCom<Button>("BtUpLevelGift");
			this.mBtUpLevelGift.onClick.AddListener(new UnityAction(this._onBtUpLevelGiftButtonClick));
			this.mUplevelGiftText = this.mBind.GetCom<Text>("UplevelGiftText");
			this.mDuelTipRoot = this.mBind.GetGameObject("DuelTipRoot");
			this.mDailyRedPoint = this.mBind.GetGameObject("DailyRedPoint");
			this.mDailyRedPointCount = this.mBind.GetCom<Text>("DailyRedPointCount");
			this.mLocalTime = this.mBind.GetCom<Text>("LocalTime");
			this.mBattery = this.mBind.GetCom<Slider>("Battery");
			this.mOnLineGift = this.mBind.GetCom<Button>("OnLineGift");
			this.mOnLineGift.onClick.AddListener(new UnityAction(this._onOnLineGiftButtonClick));
			this.mOnlIneGiftText = this.mBind.GetCom<Text>("OnlIneGiftText");
			this.mBeStrongTips = this.mBind.GetCom<Button>("BeStrongTips");
			this.mBeStrongTips.onClick.AddListener(new UnityAction(this._onBeStrongTipsButtonClick));
			this.mBeStrongTipsText = this.mBind.GetCom<Text>("BeStrongTipsText");
			this.mBtPet = this.mBind.GetCom<Button>("btPet");
			this.mBtPet.onClick.AddListener(new UnityAction(this._onBtPetButtonClick));
			this.mGuildBattleEffect = this.mBind.GetGameObject("GuildBattleEffect");
			this.mGuildBattleEffectQ = this.mBind.GetGameObject("GuildBattleEffectQ");
			this.onlineServiceBtn = this.mBind.GetCom<Button>("onlineServiceBtn");
			this.onlineServiceBtn.onClick.AddListener(new UnityAction(this._OnOnlineServiceClicked));
			this.onlineServiceNote = this.mBind.GetGameObject("onlineServiceNote");
			this.mSDKBindPhoneBtn = this.mBind.GetCom<Button>("BindPhoneBtn");
			this.mSDKBindPhoneBtn.onClick.AddListener(new UnityAction(this._onSDKBindPhoneBtnClick));
			this.mSDKBindPhoneBtnRedPoint = this.mBind.GetGameObject("SDKBindPhoneBtnRedPoint");
			this.mGuildTips = this.mBind.GetCom<Button>("GuildTips");
			this.mGuildTips.onClick.AddListener(new UnityAction(this._onGuildTipsButtonClick));
			this.mGuildTipsText = this.mBind.GetCom<Text>("GuildTipsText");
			this.mpayText = this.mBind.GetCom<Text>("payText");
			this.mPrivateCustomBubbles = this.mBind.GetCom<RectTransform>("PrivateCustomBubble");
			this.mActivityLimitTimtFrame = this.mBind.GetCom<Button>("activityLimitTimtFrame");
			this.mActivityLimitTimtFrame.onClick.AddListener(new UnityAction(this._onActivityLimitFrame));
			this.mOppoLoginAward = this.mBind.GetCom<Button>("OppoLoginAward");
			this.mOppoLoginAward.onClick.AddListener(new UnityAction(this._onOppoLoginAwardButtonClick));
			this.mOppoRoot = this.mBind.GetGameObject("OppoRoot");
			this.mOPPORepoint = this.mBind.GetGameObject("OPPORePoint");
			this.mRankallBtn = this.mBind.GetCom<Button>("RankallBtn");
			this.mRankallBtn.onClick.AddListener(new UnityAction(this._onRankallBtnButtonClick));
			this.mRankallRoot = this.mBind.GetGameObject("RankallRoot");
			this.mRedPackRankListObj = this.mBind.GetGameObject("RedPackRankListObj");
			this.mBtRedPackRankList = this.mBind.GetCom<Button>("btRedPackRankList");
			this.mBtRedPackRankList.onClick.AddListener(new UnityAction(this._onBtRedPackRankListButtonClick));
			this.mBtShowHide = this.mBind.GetCom<Button>("ShowHideBtn");
			this.mBtShowHide.onClick.AddListener(new UnityAction(this._OnShowHideBtnClick));
			this.mBtnChangeJob = this.mBind.GetCom<Button>("ChangeJobButton");
			this.mBtnChangeJob.onClick.AddListener(new UnityAction(this._OnChangeJobClick));
			this.mOperateAdsRoot = this.mBind.GetGameObject("OperateAdsRoot");
			this.mOperateAdsButton = this.mBind.GetCom<Button>("OperateAdsButton");
			this.mOperateAdsButton.onClick.AddListener(new UnityAction(this._onOperateAdsButtonClick));
			this.mOperateAdsText = this.mBind.GetCom<Text>("OperateAdsText");
			this.mVivoImg = this.mBind.GetGameObject("VivoImg");
			this.mOppoImg = this.mBind.GetGameObject("OppoImg");
			this.mVivoText = this.mBind.GetGameObject("VivoText");
			this.mOppoText = this.mBind.GetGameObject("OppoText");
			this.mEquipHandBookBtn = this.mBind.GetCom<Button>("EquipHandBookBtn");
			this.mEquipHandBookBtn.onClick.AddListener(new UnityAction(this._onEquipHandBookBtnButtonClick));
			this.mButtonTreasureLotteryActivity = this.mBind.GetCom<Button>("ButtonTreasureLotteryActivity");
			this.mButtonTreasureLotteryActivity.onClick.AddListener(new UnityAction(this._onButtonTreasureLotteryActivityButtonClick));
			this.mButtonHorseGambling = this.mBind.GetCom<Button>("HorseGambling");
			this.mButtonHorseGambling.onClick.AddListener(new UnityAction(this._onButtonHorseGamblingClick));
			this.mEquipRecovery = this.mBind.GetCom<Button>("EquipRecovery");
			this.mEquipRecovery.onClick.AddListener(new UnityAction(this._onEquipRecoveryButtonClick));
			this.mEquipHandBookTips = this.mBind.GetCom<Button>("equipHandBooktips");
			this.mEquipHandBookTips.onClick.AddListener(new UnityAction(this._onEquipHandBookButtonClick));
			this.mEquipHandBookTipsText = this.mBind.GetCom<Text>("equipHandBookTipsText");
			this.mRightLowerBubbleShowOrder = this.mBind.GetCom<RightLowerBubbleShowsOrder>("rightLowerBubbleShowOrder");
			this.mJarTips = this.mBind.GetCom<Button>("jarTips");
			this.mJarTips.onClick.AddListener(new UnityAction(this._onJarTipsButtonClick));
			this.mJarTipsText = this.mBind.GetCom<Text>("jarTipsText");
			this.mActivityLimitTimeRedPoint = this.mBind.GetGameObject("ActivityLimitTimeRedPoint");
			this.mEquipRecoveryRedPoint = this.mBind.GetGameObject("EquipRecoveryRedPoint");
			this.mPrivateChatBubble = this.mBind.GetGameObject("PrivateChatBubble");
			this.mRandomtreasure = this.mBind.GetCom<Button>("Randomtreasure");
			if (null != this.mRandomtreasure)
			{
				this.mRandomtreasure.onClick.AddListener(new UnityAction(this._onRandomtreasureButtonClick));
			}
			this.mOppo2Root = this.mBind.GetGameObject("oppo2Root");
			this.mOppo2Btn = this.mBind.GetCom<Button>("oppo2Btn");
			if (null != this.mOppo2Btn)
			{
				this.mOppo2Btn.onClick.AddListener(new UnityAction(this._onOppo2BtnButtonClick));
			}
			this.mOppo2sdk = this.mBind.GetCom<ComSdkChannelIcon>("oppo2sdk");
			this.mTAPGraduationEffUI = this.mBind.GetGameObject("TAPGraduationEffUI");
			this.mStrengthenTicketMerge = this.mBind.GetCom<Button>("strengthenTicketMerge");
			if (null != this.mStrengthenTicketMerge)
			{
				this.mStrengthenTicketMerge.onClick.AddListener(new UnityAction(this._onStrengthenTicketMergeButtonClick));
			}
			this.mWeaponLease = this.mBind.GetCom<Button>("WeaponLease");
			this.mWeaponLease.onClick.AddListener(new UnityAction(this._onWeaponLeaseButtonClick));
			this.mAdventureTeamRoot = this.mBind.GetGameObject("AdventureTeamRoot");
			this.mAdventureTeamBtn = this.mBind.GetCom<Button>("AdventureTeamBtn");
			if (null != this.mAdventureTeamBtn)
			{
				this.mAdventureTeamBtn.onClick.AddListener(new UnityAction(this._onAdventureTeamBtnButtonClick));
			}
			this.mChiji = this.mBind.GetCom<Button>("Chiji");
			if (null != this.mChiji)
			{
				this.mChiji.onClick.AddListener(new UnityAction(this._onChijiButtonClick));
			}
			this.mChallenge = this.mBind.GetCom<Button>("challenge");
			if (this.mChallenge != null)
			{
				this.mChallenge.onClick.AddListener(new UnityAction(this.OnChallengeButtonClick));
			}
			this.mAdventureTeamRedPoint = this.mBind.GetGameObject("AdventureTeamRedPoint");
			this.mAdventureTeamDOTweenBind = this.mBind.GetCom<MainTownFrameButtonDOTweenBind>("AdventureTeamDOTweenBind");
			this.mOnLineTips = this.mBind.GetGameObject("OnLineTips");
			this.mExclusivPreferentialBtn = this.mBind.GetCom<Button>("ExclusivPreferential");
			if (this.mExclusivPreferentialBtn != null)
			{
				this.mExclusivPreferentialBtn.onClick.AddListener(new UnityAction(this.OnExclusivPreferentialButtonClick));
			}
			this.guildDungeonWorldAuction = this.mBind.GetCom<Button>("guildDungeonWorldAuction");
			this.guildDungeonWorldAuction.SafeAddOnClickListener(delegate
			{
			});
			this.guildDungeonAuction = this.mBind.GetCom<Button>("guildDungeonAuction");
			this.guildDungeonAuction.SafeAddOnClickListener(delegate
			{
				if (!DataManager<GuildDataManager>.GetInstance().IsGuildAuctionOpen)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildDungeonAuctionFrame>(FrameLayer.Middle, GuildDungeonAuctionFrame.FrameType.WorldAuction, string.Empty);
				}
				else
				{
					DataManager<GuildDataManager>.GetInstance().SendWorldGuildAuctionItemReq(GuildAuctionType.G_AUCTION_GUILD);
				}
				this.guildDungeonAuctionRedPoint.CustomActive(false);
				DataManager<GuildDataManager>.GetInstance().HaveNewGuildAuctonItem = false;
				DataManager<GuildDataManager>.GetInstance().HaveNewWorldAuctonItem = false;
			});
			this.PVETrainDamageBtn = this.mBind.GetCom<Button>("PVETrainDamage");
			this.PVETrainDamageBtn.onClick.AddListener(new UnityAction(this._onPVETrainDamageBtnButtonClick));
			this.mReplaceHeadPortraitFrame = this.mBind.GetCom<ReplaceHeadPortraitFrame>("ReplaceHeadPortraitFrame");
			this.mMainTownFrameCommonButtonControl = this.mBind.GetCom<MainTownFrameCommonButtonControl>("MainTownFrameCommonButtonControl");
			this.guildDungeonAuctionRedPoint = this.mBind.GetGameObject("guildDungeonAuctionRedPoint");
			this.mDailyTodoBtn = this.mBind.GetCom<Button>("DailyTodoBtn");
			if (null != this.mDailyTodoBtn)
			{
				this.mDailyTodoBtn.onClick.AddListener(new UnityAction(this._onDailyTodoBtnButtonClick));
			}
			this.mDailyTodoRoot = this.mBind.GetGameObject("DailyTodoRoot");
			this.btnMagicCard = this.mBind.GetCom<Button>("btnMagicCard");
			this.btnMagicCard.SafeSetOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<EnchantmentsBookFrame>(FrameLayer.Middle, null, string.Empty);
				Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("MagicCardBook_1");
			});
			this.btnTitleBook = this.mBind.GetCom<Button>("btnTitleBook");
			this.btnTitleBook.SafeSetOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TitleBookFrame>(FrameLayer.Middle, null, string.Empty);
				Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("TitleBook");
			});
			this.mBtnDownload = this.mBind.GetCom<Button>("btnDownload");
			if (this.mBtnDownload != null)
			{
				this.mBtnDownload.onClick.AddListener(new UnityAction(this._onBtnDownloadButtonClick));
				if (SDKInterface.instance.IsSmallPackage() && !SDKInterface.instance.IsResourceDownloadFinished())
				{
					this.mBtnDownload.gameObject.CustomActive(true);
				}
			}
			this.adventurerPassCard = this.mBind.GetCom<Button>("adventurerPassCard");
			this.adventurerPassCard.SafeSetOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdventurerPassCardFrame>(FrameLayer.Middle, null, string.Empty);
				bool bActive = AdventurerPassCardFrame.CanOneKeyGetAwards() || DataManager<AdventurerPassCardDataManager>.GetInstance().GetExpPackState() == AdventurerPassCardDataManager.ExpPackState.CanGet;
				this.mAdventurerPassCardRedPoint.CustomActive(bActive);
			});
			this.mTimePlayBtn = this.mBind.GetCom<TimePlayButton>("TimePlayBtn");
			this.mAdventurerPassCardRedPoint = this.mBind.GetGameObject("adventurerPassCardRedPoint");
			this.QuestionnaireBtn = this.mBind.GetCom<Button>("btnQuestionnaire");
			this.QuestionnaireBtn.onClick.AddListener(new UnityAction(this._onQuestionnaireBtnClick));
			this.mTreasureConversion = this.mBind.GetCom<Button>("TreasureConversion");
			if (this.mTreasureConversion != null)
			{
				this.mTreasureConversion.onClick.AddListener(new UnityAction(this._onTreasureConversionBtnClick));
			}
			this.mActiveBubbleControl = this.mBind.GetCom<ActiveBubbleControl>("ActiveBubbleControl");
		}

		// Token: 0x0600EB3F RID: 60223 RVA: 0x003EA27C File Offset: 0x003E867C
		protected sealed override void _unbindExUI()
		{
			this.mHeadIcon.onClick.RemoveListener(new UnityAction(this._onHeadIconButtonClick));
			this.mHeadIcon = null;
			this.mVipText = null;
			this.mTalkRoot = null;
			this.mPlayerLevel = null;
			this.mExpBar = null;
			this.mFatigueText = null;
			this.mPackage.onClick.RemoveListener(new UnityAction(this._onPackageButtonClick));
			this.mPackage = null;
			this.mFriend.onClick.RemoveListener(new UnityAction(this._onFriendButtonClick));
			this.mFriend = null;
			this.mGuild.onClick.RemoveListener(new UnityAction(this._onGuildButtonClick));
			this.mGuild = null;
			this.mMall.onClick.RemoveListener(new UnityAction(this._onMallButtonClick));
			this.mMall = null;
			this.mAuction.onClick.RemoveListener(new UnityAction(this._onAuctionButtonClick));
			this.mAuction = null;
			this.mRankList.onClick.RemoveListener(new UnityAction(this._onRankListButtonClick));
			this.mRankList = null;
			this.mNextOpenIcon = null;
			this.mNextopen.onClick.RemoveListener(new UnityAction(this._onNextopenButtonClick));
			this.mNextopen = null;
			this.mNextOpenLv = null;
			this.mNextOpenName = null;
			this.mChangeJob.onClick.RemoveListener(new UnityAction(this._onChangeJobButtonClick));
			this.mChangeJob = null;
			this.mChangeJobTask.onClick.RemoveListener(new UnityAction(this._onChangeJobTaskButtonClick));
			this.mChangeJobTask = null;
			this.mDuel.onClick.RemoveListener(new UnityAction(this._onDuelButtonClick));
			this.mDuel = null;
			this.mVipLevel.onClick.RemoveListener(new UnityAction(this._onVipLevelButtonClick));
			this.mVipLevel = null;
			this.mBtVip.onClick.RemoveListener(new UnityAction(this._onBtVipButtonClick));
			this.mBtVip = null;
			this.mFirstRecharge.onClick.RemoveListener(new UnityAction(this._onFirstRechargeButtonClick));
			this.mFirstRecharge = null;
			this.mWelFare.onClick.RemoveListener(new UnityAction(this._onWelFareButtonClick));
			this.mWelFare = null;
			this.mJar.onClick.RemoveListener(new UnityAction(this._onJarButtonClick));
			this.mJar = null;
			this.mDaily.onClick.RemoveListener(new UnityAction(this._onDailyButtonClick));
			this.mDaily = null;
			this.mBeStrong.onClick.RemoveListener(new UnityAction(this._onBeStrongButtonClick));
			this.mBeStrong = null;
			this.mRedPacket.onClick.RemoveListener(new UnityAction(this._onRedPacketButtonClick));
			this.mRedPacket = null;
			this.mLabRedPacketCount = null;
			this.mFriendRedPoint = null;
			this.mPackageFull = null;
			this.mPackageAnim = null;
			this.mGuildRedPoint = null;
			this.mPackageRedPoint = null;
			this.mDuelRedPoint = null;
			this.mFirstRechargeRedPoint = null;
			this.mBtSkill.onClick.RemoveListener(new UnityAction(this._onBtSkillButtonClick));
			this.mBtSkill = null;
			this.mBtForge.onClick.RemoveListener(new UnityAction(this._onBtForgeButtonClick));
			this.mBtForge = null;
			this.mBtFashionMerge.onClick.RemoveListener(new UnityAction(this._onBtFashionMergeButtonClick));
			this.mBtFashionMerge = null;
			this.mBtTitleBook.onClick.RemoveListener(new UnityAction(this._onBtTitleBookButtonClick));
			this.mBtTitleBook = null;
			this.mBtEquipForge.onClick.RemoveListener(new UnityAction(this._onBtEquipForgeButtonClick));
			this.mBtEquipForge = null;
			this.mWantStrong.onClick.RemoveListener(new UnityAction(this._onWantStrongButtonClick));
			this.mWantStrong = null;
			this.mSkillRedPoint = null;
			this.mEquipForgeRedPoint = null;
			this.mJarsRedPoint = null;
			this.mForgeRedPoint = null;
			this.mJarRedPoint = null;
			this.mUpLevelGiftObj = null;
			this.mBtUpLevelGift.onClick.RemoveListener(new UnityAction(this._onBtUpLevelGiftButtonClick));
			this.mBtUpLevelGift = null;
			this.mUplevelGiftText = null;
			this.mDuelTipRoot = null;
			this.mDailyRedPoint = null;
			this.mDailyRedPointCount = null;
			this.mLocalTime = null;
			this.mBattery = null;
			this.mOnLineGift.onClick.RemoveListener(new UnityAction(this._onOnLineGiftButtonClick));
			this.mOnLineGift = null;
			this.mOnlIneGiftText = null;
			this.mBeStrongTips.onClick.RemoveListener(new UnityAction(this._onBeStrongTipsButtonClick));
			this.mBeStrongTips = null;
			this.mBeStrongTipsText = null;
			this.mBtPet.onClick.RemoveListener(new UnityAction(this._onBtPetButtonClick));
			this.mBtPet = null;
			this.mGuildBattleEffect = null;
			this.mGuildBattleEffectQ = null;
			this.onlineServiceBtn.onClick.RemoveListener(new UnityAction(this._OnOnlineServiceClicked));
			this.onlineServiceBtn = null;
			this.onlineServiceNote = null;
			this.mSDKBindPhoneBtn.onClick.RemoveListener(new UnityAction(this._onSDKBindPhoneBtnClick));
			this.mSDKBindPhoneBtn = null;
			this.mSDKBindPhoneBtnRedPoint = null;
			this.mGuildTips.onClick.RemoveListener(new UnityAction(this._onGuildTipsButtonClick));
			this.mGuildTips = null;
			this.mGuildTipsText = null;
			this.mpayText = null;
			this.mPrivateCustomBubbles = null;
			this.mActivityLimitTimtFrame.onClick.RemoveListener(new UnityAction(this._onActivityLimitFrame));
			this.mActivityLimitTimtFrame = null;
			this.mOppoLoginAward.onClick.RemoveListener(new UnityAction(this._onOppoLoginAwardButtonClick));
			this.mOppoLoginAward = null;
			this.mOppoRoot = null;
			this.mOPPORepoint = null;
			this.mRankallBtn.onClick.RemoveListener(new UnityAction(this._onRankallBtnButtonClick));
			this.mRankallBtn = null;
			this.mRankallRoot = null;
			this.mRedPackRankListObj = null;
			this.mBtRedPackRankList.onClick.RemoveListener(new UnityAction(this._onBtRedPackRankListButtonClick));
			this.mBtRedPackRankList = null;
			this.mBtShowHide.onClick.RemoveListener(new UnityAction(this._OnShowHideBtnClick));
			this.mBtShowHide = null;
			this.mBtnChangeJob.onClick.RemoveListener(new UnityAction(this._OnChangeJobClick));
			this.mBtnChangeJob = null;
			this.mOperateAdsRoot = null;
			this.mOperateAdsButton.onClick.RemoveListener(new UnityAction(this._onOperateAdsButtonClick));
			this.mOperateAdsButton = null;
			this.mOperateAdsText = null;
			this.mVivoImg = this.mBind.GetGameObject("VivoImg");
			this.mOppoImg = this.mBind.GetGameObject("OppoImg");
			this.mVivoText = this.mBind.GetGameObject("VivoText");
			this.mOppoText = this.mBind.GetGameObject("OppoText");
			this.mEquipHandBookBtn.onClick.RemoveListener(new UnityAction(this._onEquipHandBookBtnButtonClick));
			this.mEquipHandBookBtn = null;
			this.mEquipRecovery.onClick.RemoveListener(new UnityAction(this._onEquipRecoveryButtonClick));
			this.mEquipRecovery = null;
			this.mEquipHandBookTips.onClick.RemoveListener(new UnityAction(this._onEquipHandBookButtonClick));
			this.mEquipHandBookTips = null;
			this.mEquipHandBookTipsText = null;
			this.mRightLowerBubbleShowOrder = null;
			this.mJarTips.onClick.RemoveListener(new UnityAction(this._onJarTipsButtonClick));
			this.mJarTips = null;
			this.mJarTipsText = null;
			this.mActivityLimitTimeRedPoint = null;
			this.mEquipRecoveryRedPoint = null;
			this.mPrivateChatBubble = null;
			this.mButtonHorseGambling.onClick.RemoveListener(new UnityAction(this._onButtonHorseGamblingClick));
			this.mButtonHorseGambling = null;
			if (this.mRandomtreasure)
			{
				this.mRandomtreasure.onClick.RemoveListener(new UnityAction(this._onRandomtreasureButtonClick));
			}
			this.mRandomtreasure = null;
			this.mOppo2Root = null;
			if (this.mOppo2Btn)
			{
				this.mOppo2Btn.onClick.RemoveListener(new UnityAction(this._onOppo2BtnButtonClick));
			}
			this.mOppo2Btn = null;
			this.mOppo2sdk = null;
			this.mTAPGraduationEffUI = null;
			if (null != this.mStrengthenTicketMerge)
			{
				this.mStrengthenTicketMerge.onClick.RemoveListener(new UnityAction(this._onStrengthenTicketMergeButtonClick));
			}
			this.mStrengthenTicketMerge = null;
			this.mWeaponLease.onClick.RemoveListener(new UnityAction(this._onWeaponLeaseButtonClick));
			this.mWeaponLease = null;
			this.mAdventureTeamRoot = null;
			if (null != this.mAdventureTeamBtn)
			{
				this.mAdventureTeamBtn.onClick.RemoveListener(new UnityAction(this._onAdventureTeamBtnButtonClick));
			}
			this.mAdventureTeamBtn = null;
			if (null != this.mChiji)
			{
				this.mChiji.onClick.RemoveListener(new UnityAction(this._onChijiButtonClick));
			}
			this.mChiji = null;
			if (this.mChallenge != null)
			{
				this.mChallenge.onClick.RemoveAllListeners();
				this.mChallenge = null;
			}
			this.mAdventureTeamRedPoint = null;
			this.mAdventureTeamDOTweenBind = null;
			this.mOnLineTips = null;
			if (this.mExclusivPreferentialBtn != null)
			{
				this.mExclusivPreferentialBtn.onClick.RemoveListener(new UnityAction(this.OnExclusivPreferentialButtonClick));
			}
			this.mExclusivPreferentialBtn = null;
			this.guildDungeonWorldAuction = null;
			this.guildDungeonAuction = null;
			this.PVETrainDamageBtn.onClick.RemoveListener(new UnityAction(this._onPVETrainDamageBtnButtonClick));
			this.PVETrainDamageBtn = null;
			this.mReplaceHeadPortraitFrame = null;
			this.mMainTownFrameCommonButtonControl = null;
			this.guildDungeonAuctionRedPoint = null;
			if (null != this.mDailyTodoBtn)
			{
				this.mDailyTodoBtn.onClick.RemoveListener(new UnityAction(this._onDailyTodoBtnButtonClick));
			}
			this.mDailyTodoBtn = null;
			this.mDailyTodoRoot = null;
			this.btnMagicCard = null;
			this.btnTitleBook = null;
			if (this.mBtnDownload != null)
			{
				this.mBtnDownload.onClick.RemoveListener(new UnityAction(this._onBtnDownloadButtonClick));
				this.mBtnDownload = null;
			}
			this.adventurerPassCard = null;
			this.mTimePlayBtn = null;
			this.mAdventurerPassCardRedPoint = null;
			this.QuestionnaireBtn.onClick.RemoveListener(new UnityAction(this._onQuestionnaireBtnClick));
			this.QuestionnaireBtn = null;
			if (this.mTreasureConversion != null)
			{
				this.mTreasureConversion.onClick.RemoveListener(new UnityAction(this._onTreasureConversionBtnClick));
			}
			this.mTreasureConversion = null;
			this.mActiveBubbleControl = null;
		}

		// Token: 0x0600EB40 RID: 60224 RVA: 0x003EAD24 File Offset: 0x003E9124
		private void _onBtnDownloadButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SmallPackageDownloadFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600EB41 RID: 60225 RVA: 0x003EAD38 File Offset: 0x003E9138
		private void _onBtRedPackRankListButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<RedPackRankListFrame>(FrameLayer.Middle, null, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("RedPackRankList");
		}

		// Token: 0x0600EB42 RID: 60226 RVA: 0x003EAD5B File Offset: 0x003E915B
		private void _onRankallBtnButtonClick()
		{
			this.frameMgr.OpenFrame<ChannelRanklistFrame>(FrameLayer.TopMoreMost, ClientApplication.channelRankListServer, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Rankall");
		}

		// Token: 0x0600EB43 RID: 60227 RVA: 0x003EAD84 File Offset: 0x003E9184
		private void _onOperateAdsButtonClick()
		{
			string name = string.Empty;
			if (this.mOperateAdsText)
			{
				name = this.mOperateAdsText.text;
			}
			this.frameMgr.OpenFrame<OperateAdsBoardFrame>(FrameLayer.TopMoreMost, ClientApplication.operateAdsServer, name);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("OperateAds");
		}

		// Token: 0x0600EB44 RID: 60228 RVA: 0x003EADD5 File Offset: 0x003E91D5
		private void _onHeadIconButtonClick()
		{
			this.frameMgr.OpenFrame<SettingFrame>(FrameLayer.Middle, null, string.Empty);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("HeadIcon");
		}

		// Token: 0x0600EB45 RID: 60229 RVA: 0x003EAE00 File Offset: 0x003E9200
		private void _onPackageButtonClick()
		{
			this.frameMgr.OpenFrame<PackageNewFrame>(FrameLayer.Middle, null, string.Empty);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Package");
		}

		// Token: 0x0600EB46 RID: 60230 RVA: 0x003EAE2B File Offset: 0x003E922B
		private void _onFriendButtonClick()
		{
			RelationFrameNew.CommandOpen(null);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Friend");
		}

		// Token: 0x0600EB47 RID: 60231 RVA: 0x003EAE4C File Offset: 0x003E924C
		private void _onGuildButtonClick()
		{
			this._SetGuildTipActive(false);
			if (DataManager<GuildDataManager>.GetInstance().myGuild != null)
			{
				EGuildBattleState guildBattleState = DataManager<GuildDataManager>.GetInstance().GetGuildBattleState();
				if (guildBattleState == EGuildBattleState.Signup)
				{
					if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CHALLENGE)
					{
						GuildMyMainFrame.OpenLinkFrame("8");
						return;
					}
				}
				else
				{
					if (guildBattleState >= EGuildBattleState.Preparing && guildBattleState <= EGuildBattleState.Firing)
					{
						if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS)
						{
							GuildMyMainFrame.OpenLinkFrame("10");
						}
						else
						{
							GuildMyMainFrame.OpenLinkFrame("8");
						}
						return;
					}
					if (guildBattleState == EGuildBattleState.LuckyDraw && !DataManager<GuildDataManager>.GetInstance().HasGuildBattleLotteryed())
					{
						GuildMyMainFrame.OpenLinkFrame("9");
						return;
					}
				}
				GuildMyMainFrame.OpenLinkFrame("0");
			}
			else
			{
				this.frameMgr.OpenFrame<GuildListFrame>(FrameLayer.Middle, null, string.Empty);
			}
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Guild");
		}

		// Token: 0x0600EB48 RID: 60232 RVA: 0x003EAF32 File Offset: 0x003E9332
		private void _onMallButtonClick()
		{
			this.frameMgr.OpenFrame<MallNewFrame>(FrameLayer.Middle, null, string.Empty);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Mall");
		}

		// Token: 0x0600EB49 RID: 60233 RVA: 0x003EAF5D File Offset: 0x003E935D
		private void _onAuctionButtonClick()
		{
			this.frameMgr.OpenFrame<AuctionNewFrame>(FrameLayer.Middle, null, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Auction");
		}

		// Token: 0x0600EB4A RID: 60234 RVA: 0x003EAF81 File Offset: 0x003E9381
		private void _onRankListButtonClick()
		{
			this.frameMgr.OpenFrame<RanklistFrame>(FrameLayer.Middle, null, string.Empty);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("RankList");
		}

		// Token: 0x0600EB4B RID: 60235 RVA: 0x003EAFAC File Offset: 0x003E93AC
		private void _onNextopenButtonClick()
		{
		}

		// Token: 0x0600EB4C RID: 60236 RVA: 0x003EAFAE File Offset: 0x003E93AE
		private void _onChangeJobButtonClick()
		{
			ChangeJobSelectFrame.Create(DataManager<PlayerBaseData>.GetInstance().JobTableID, true);
		}

		// Token: 0x0600EB4D RID: 60237 RVA: 0x003EAFC0 File Offset: 0x003E93C0
		private void _onChangeJobTaskButtonClick()
		{
			if (this.frameMgr.IsFrameOpen<ChangeJobTaskProPanel>(null))
			{
				this.frameMgr.CloseFrame<ChangeJobTaskProPanel>(null, false);
			}
			this.UpdateBeStrongExpand(false);
			this.frameMgr.OpenFrame<ChangeJobTaskProPanel>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600EB4E RID: 60238 RVA: 0x003EAFFC File Offset: 0x003E93FC
		private bool IsJobChangeAfter()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			return tableItem != null && tableItem.JobType == 0;
		}

		// Token: 0x0600EB4F RID: 60239 RVA: 0x003EB03E File Offset: 0x003E943E
		private void _OnChangeJobClick()
		{
			this._onDuelButtonClick();
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("ChangeJob");
		}

		// Token: 0x0600EB50 RID: 60240 RVA: 0x003EB05C File Offset: 0x003E945C
		private void _onDuelButtonClick()
		{
			if (!Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Duel))
			{
				if (this.frameMgr.IsFrameOpen<DuelOpenTipFrame>(null))
				{
					this.frameMgr.CloseFrame<DuelOpenTipFrame>(null, false);
				}
				if (DataManager<PlayerBaseData>.GetInstance().Level <= 15 && this.IsJobChangeAfter())
				{
					this.frameMgr.OpenFrame<DuelOpenTipFrame>(FrameLayer.Middle, OpenType.changejobbefore, string.Empty);
				}
				else
				{
					this.frameMgr.OpenFrame<DuelOpenTipFrame>(FrameLayer.Middle, OpenType.changejobbeafter, string.Empty);
				}
				return;
			}
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SystemNotify(1104, string.Empty);
				Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Duel");
				return;
			}
			Utility.SwitchToPkWaitingRoom(PkRoomType.TraditionPk);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Duel");
		}

		// Token: 0x0600EB51 RID: 60241 RVA: 0x003EB128 File Offset: 0x003E9528
		private void _onVipLevelButtonClick()
		{
			if (this.frameMgr.IsFrameOpen<VipFrame>(null))
			{
				this.frameMgr.CloseFrame<VipFrame>(null, false);
			}
			this.frameMgr.OpenFrame<VipFrame>(FrameLayer.Middle, null, string.Empty);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("VIPLevel");
		}

		// Token: 0x0600EB52 RID: 60242 RVA: 0x003EB17C File Offset: 0x003E957C
		private void _onBtVipButtonClick()
		{
			if (this.frameMgr.IsFrameOpen<VipFrame>(null))
			{
				this.frameMgr.CloseFrame<VipFrame>(null, false);
			}
			VipFrame vipFrame = this.frameMgr.OpenFrame<VipFrame>(FrameLayer.Middle, null, string.Empty) as VipFrame;
			vipFrame.OpenPayTab();
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("VIP");
		}

		// Token: 0x0600EB53 RID: 60243 RVA: 0x003EB1D4 File Offset: 0x003E95D4
		private void _onFirstRechargeButtonClick()
		{
			bool flag = Singleton<PayManager>.GetInstance().HasFirstPay();
			bool flag2 = Singleton<PayManager>.GetInstance().HasConsumePay();
			if (flag)
			{
				this.frameMgr.OpenFrame<FirstPayFrame>(FrameLayer.Middle, null, string.Empty);
			}
			else if (flag2)
			{
				this.frameMgr.OpenFrame<SecondPayFrame>(FrameLayer.Middle, flag2, string.Empty);
			}
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("FirstRecharge");
		}

		// Token: 0x0600EB54 RID: 60244 RVA: 0x003EB249 File Offset: 0x003E9649
		private void _onWelFareButtonClick()
		{
		}

		// Token: 0x0600EB55 RID: 60245 RVA: 0x003EB24B File Offset: 0x003E964B
		private void _onJarButtonClick()
		{
			this.frameMgr.OpenFrame<PocketJarFrame>(FrameLayer.Middle, null, string.Empty);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Jar");
		}

		// Token: 0x0600EB56 RID: 60246 RVA: 0x003EB276 File Offset: 0x003E9676
		private void _onDailyButtonClick()
		{
			ClientFrame.OpenTargetFrame<ActivityDungeonFrame>(FrameLayer.Middle, null);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Daily");
		}

		// Token: 0x0600EB57 RID: 60247 RVA: 0x003EB298 File Offset: 0x003E9698
		private void UpdateTopRightState(bool BExpand)
		{
			ComTopButtonExpandController component = this.mBtShowHide.GetComponent<ComTopButtonExpandController>();
			if (component == null)
			{
				return;
			}
			component.UpdateTopRightState(BExpand);
		}

		// Token: 0x0600EB58 RID: 60248 RVA: 0x003EB2C8 File Offset: 0x003E96C8
		public void _RefreshHaveLevelPermenentBtn()
		{
			ComTopButtonExpandController component = this.mBtShowHide.GetComponent<ComTopButtonExpandController>();
			if (component == null)
			{
				return;
			}
			component.RefreshPermenentTwoLevelButton();
		}

		// Token: 0x0600EB59 RID: 60249 RVA: 0x003EB2F4 File Offset: 0x003E96F4
		public void ExtendTopRightBtn()
		{
			ComTopButtonExpandController component = this.mBtShowHide.GetComponent<ComTopButtonExpandController>();
			if (component == null)
			{
				return;
			}
			DataManager<PlayerBaseData>.GetInstance().IsExpand = false;
			component.StartExpand(DataManager<PlayerBaseData>.GetInstance().IsExpand);
		}

		// Token: 0x0600EB5A RID: 60250 RVA: 0x003EB338 File Offset: 0x003E9738
		private void _OnShowHideBtnClick()
		{
			ComTopButtonExpandController component = this.mBtShowHide.GetComponent<ComTopButtonExpandController>();
			if (component == null)
			{
				return;
			}
			component.StartExpand(!component.bExpanding);
			if (this.mBtShowHide != null)
			{
				this.mBtShowHide.enabled = false;
				InvokeMethod.Invoke(this, 0.3f, delegate()
				{
					this.mBtShowHide.enabled = true;
				});
			}
			DataManager<PlayerBaseData>.GetInstance().IsExpand = component.bExpanding;
		}

		// Token: 0x0600EB5B RID: 60251 RVA: 0x003EB3B4 File Offset: 0x003E97B4
		private void _onBeStrongButtonClick()
		{
			ComExpandController component = this.mBeStrong.GetComponent<ComExpandController>();
			if (component == null)
			{
				return;
			}
			this._SetSkillTipActive(false);
			this._SetEquipHandBookTipActive(false);
			this.UpdateBeStrongExpand(!component.bExpanding);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Strong_1");
		}

		// Token: 0x0600EB5C RID: 60252 RVA: 0x003EB408 File Offset: 0x003E9808
		private void _onRedPacketButtonClick()
		{
			RedPacketBaseEntry firstRedPacketToOpen = DataManager<RedPackDataManager>.GetInstance().GetFirstRedPacketToOpen();
			if (firstRedPacketToOpen != null)
			{
				DataManager<RedPackDataManager>.GetInstance().OpenRedPacket(firstRedPacketToOpen.id);
			}
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("RedPacket");
		}

		// Token: 0x0600EB5D RID: 60253 RVA: 0x003EB44C File Offset: 0x003E984C
		private void _onBtSkillButtonClick()
		{
			this.frameMgr.OpenFrame<SkillTreeFrame>(FrameLayer.Middle, null, string.Empty);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Skill");
		}

		// Token: 0x0600EB5E RID: 60254 RVA: 0x003EB477 File Offset: 0x003E9877
		private void _onBtForgeButtonClick()
		{
			DataManager<PlayerBaseData>.GetInstance().IsSelectedPerfectWashingRollTab = false;
			Singleton<ClientSystemManager>.instance.OpenFrame<SmithShopNewFrame>(FrameLayer.Middle, null, string.Empty);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Forge_1");
		}

		// Token: 0x0600EB5F RID: 60255 RVA: 0x003EB4AC File Offset: 0x003E98AC
		private void _onBtFashionMergeButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<FashionMergeNewFrame>(null, false);
			FashionMergeNewFrame.OpenLinkFrame(string.Format("1|0|{0}|{1}|{2}", (int)DataManager<FashionMergeManager>.GetInstance().FashionType, (int)DataManager<FashionMergeManager>.GetInstance().FashionPart, 0));
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("FashionMerge_1");
		}

		// Token: 0x0600EB60 RID: 60256 RVA: 0x003EB510 File Offset: 0x003E9910
		private void _onBtTitleBookButtonClick()
		{
			FashionMergeNewFrame.OpenLinkFrame(string.Format("1|1|{0}|{1}|{2}", 10000, (int)DataManager<FashionMergeManager>.GetInstance().FashionPart, 0));
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("TitleBook");
		}

		// Token: 0x0600EB61 RID: 60257 RVA: 0x003EB561 File Offset: 0x003E9961
		private void _onBtEquipForgeButtonClick()
		{
			this.frameMgr.OpenFrame<EquipForgeFrame>(FrameLayer.Middle, null, string.Empty);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("EquipForge");
		}

		// Token: 0x0600EB62 RID: 60258 RVA: 0x003EB58C File Offset: 0x003E998C
		private void _onWantStrongButtonClick()
		{
			this.frameMgr.OpenFrame<DevelopGuidanceMainFrame>(FrameLayer.Middle, null, string.Empty);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("WantStrong");
		}

		// Token: 0x0600EB63 RID: 60259 RVA: 0x003EB5B7 File Offset: 0x003E99B7
		private void _onBtUpLevelGiftButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<LevelGiftFrame>(FrameLayer.Middle, null, string.Empty);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("UpLevelGift");
		}

		// Token: 0x0600EB64 RID: 60260 RVA: 0x003EB5E1 File Offset: 0x003E99E1
		private void _onOnLineGiftButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<OnlineGiftFrame>(FrameLayer.Middle, null, string.Empty);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("OnLineGift");
		}

		// Token: 0x0600EB65 RID: 60261 RVA: 0x003EB60B File Offset: 0x003E9A0B
		private void _onBeStrongTipsButtonClick()
		{
			this._SetSkillTipActive(false);
			ClientSystemTownFrame.IsShowSkillTips = false;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RightLowerBubbleStopAnimation, BubbleShowType.Skill, null, null, null);
		}

		// Token: 0x0600EB66 RID: 60262 RVA: 0x003EB632 File Offset: 0x003E9A32
		private void _onEquipHandBookButtonClick()
		{
			this._SetEquipHandBookTipActive(false);
			ClientSystemTownFrame.IsShowEquipHandBookTips = false;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RightLowerBubbleStopAnimation, BubbleShowType.EquipHandBook, null, null, null);
		}

		// Token: 0x0600EB67 RID: 60263 RVA: 0x003EB659 File Offset: 0x003E9A59
		private void _onJarTipsButtonClick()
		{
			this._setJarTipsActive(false);
		}

		// Token: 0x0600EB68 RID: 60264 RVA: 0x003EB662 File Offset: 0x003E9A62
		private void _onBtPetButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PetPacketFrame>(FrameLayer.Middle, null, string.Empty);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Pet");
		}

		// Token: 0x0600EB69 RID: 60265 RVA: 0x003EB68C File Offset: 0x003E9A8C
		private void _onSDKBindPhoneBtnClick()
		{
			this.frameMgr.OpenFrame<MobileBindFrame>(FrameLayer.Middle, null, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("PhoneGiftBag");
		}

		// Token: 0x0600EB6A RID: 60266 RVA: 0x003EB6B0 File Offset: 0x003E9AB0
		private void _onGraphicTipsButtonClick()
		{
			this.mGraphicTips.gameObject.CustomActive(false);
			Singleton<GeGraphicSetting>.instance.needPromoted = false;
		}

		// Token: 0x0600EB6B RID: 60267 RVA: 0x003EB6CE File Offset: 0x003E9ACE
		private void _onGuildTipsButtonClick()
		{
			this._SetGuildTipActive(false);
			ClientSystemTownFrame.IsShowGuildTips = false;
		}

		// Token: 0x0600EB6C RID: 60268 RVA: 0x003EB6DD File Offset: 0x003E9ADD
		private void _onActivityLimitFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<LimitTimeActivityFrame>(FrameLayer.Middle, null, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("ActivityLimit");
		}

		// Token: 0x0600EB6D RID: 60269 RVA: 0x003EB700 File Offset: 0x003E9B00
		private void _onOppoLoginAwardButtonClick()
		{
			if (SDKInterface.instance.IsOppoPlatform())
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<OPPOPrivilegeFrame>(FrameLayer.Middle, null, string.Empty);
				Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("OPPOPrivilege");
			}
			else if (SDKInterface.instance.IsVivoPlatForm())
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<VIVOPrivilegeFrame>(FrameLayer.Middle, null, string.Empty);
				Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("VIVOPrivilege");
			}
			this.UpdateBeStrongExpand(false);
		}

		// Token: 0x0600EB6E RID: 60270 RVA: 0x003EB779 File Offset: 0x003E9B79
		private void _onEquipHandBookBtnButtonClick()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<EquipHandbookFrame>(FrameLayer.Middle, null, string.Empty);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("EquipHandBook_1");
		}

		// Token: 0x0600EB6F RID: 60271 RVA: 0x003EB7A3 File Offset: 0x003E9BA3
		private void _onButtonTreasureLotteryActivityButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActivityTreasureLotteryFrame>(FrameLayer.Middle, null, string.Empty);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("TreasureLotteryActivity");
		}

		// Token: 0x0600EB70 RID: 60272 RVA: 0x003EB7CD File Offset: 0x003E9BCD
		private void _onButtonHorseGamblingClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<HorseGamblingFrame>(FrameLayer.Middle, null, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("HorseGambling");
		}

		// Token: 0x0600EB71 RID: 60273 RVA: 0x003EB7F0 File Offset: 0x003E9BF0
		private void _onEquipRecoveryButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<EquipRecoveryFrame>(FrameLayer.Middle, null, string.Empty);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("EquipRecovery_1");
		}

		// Token: 0x0600EB72 RID: 60274 RVA: 0x003EB81A File Offset: 0x003E9C1A
		private void _onRandomtreasureButtonClick()
		{
			DataManager<RandomTreasureDataManager>.GetInstance().OpenRandomTreasureFrame();
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("RandomTreasure");
		}

		// Token: 0x0600EB73 RID: 60275 RVA: 0x003EB835 File Offset: 0x003E9C35
		private void _onOppo2BtnButtonClick()
		{
			SDKInterface.instance.GotoSDKChannelCommunity();
		}

		// Token: 0x0600EB74 RID: 60276 RVA: 0x003EB841 File Offset: 0x003E9C41
		private void _onStrengthenTicketMergeButtonClick()
		{
			DataManager<StrengthenTicketMergeDataManager>.GetInstance().OpenStrengthenTicketMergeFrame();
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("StrengthenTicketMerge");
		}

		// Token: 0x0600EB75 RID: 60277 RVA: 0x003EB85C File Offset: 0x003E9C5C
		private void _onWeaponLeaseButtonClick()
		{
			WeaponLeaseShopFrame.OpenLinkFrame("26");
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("WeaponLease_1");
		}

		// Token: 0x0600EB76 RID: 60278 RVA: 0x003EB87E File Offset: 0x003E9C7E
		private void _onAdventureTeamBtnButtonClick()
		{
			DataManager<AdventureTeamDataManager>.GetInstance().OpenAdventureTeamInfoFrame(AdventureTeamMainTabType.BaseInformation);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("AdventureTeam_1");
		}

		// Token: 0x0600EB77 RID: 60279 RVA: 0x003EB8A1 File Offset: 0x003E9CA1
		private void _onChijiButtonClick()
		{
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("Chiji_has_team"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiEntranceFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600EB78 RID: 60280 RVA: 0x003EB8D5 File Offset: 0x003E9CD5
		private void OnChallengeButtonClick()
		{
			ChallengeUtility.OnOpenChallengeMapFrame(DungeonModelTable.eType.DeepModel, 0, 0);
		}

		// Token: 0x0600EB79 RID: 60281 RVA: 0x003EB8DF File Offset: 0x003E9CDF
		private void OnExclusivPreferentialButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TopUpPushFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600EB7A RID: 60282 RVA: 0x003EB8F4 File Offset: 0x003E9CF4
		private void _onPVETrainDamageBtnButtonClick()
		{
			SkillDamageFrame skillDamageFrame = Singleton<ClientSystemManager>.instance.OpenFrame<SkillDamageFrame>(FrameLayer.Middle, null, string.Empty) as SkillDamageFrame;
			if (skillDamageFrame != null)
			{
				skillDamageFrame.InitData(true);
			}
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("PVETrainDamage_1");
		}

		// Token: 0x0600EB7B RID: 60283 RVA: 0x003EB934 File Offset: 0x003E9D34
		private void _onDailyTodoBtnButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<DailyTodoFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600EB7C RID: 60284 RVA: 0x003EB948 File Offset: 0x003E9D48
		private void _onQuestionnaireBtnClick()
		{
			if (DataManager<BaseWebViewManager>.GetInstance().CanOpenQuestionnaire())
			{
				BaseWebViewParams baseWebViewParams = new BaseWebViewParams();
				baseWebViewParams.fullUrl = DataManager<BaseWebViewManager>.GetInstance().GetQuestionnaireUrl();
				baseWebViewParams.type = BaseWebViewType.Questionnaire;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<BaseWebViewFrame>(FrameLayer.TopMoreMost, baseWebViewParams, string.Empty);
			}
		}

		// Token: 0x0600EB7D RID: 60285 RVA: 0x003EB993 File Offset: 0x003E9D93
		private void _onOpenmAutoFightTestBtn()
		{
		}

		// Token: 0x0600EB7E RID: 60286 RVA: 0x003EB995 File Offset: 0x003E9D95
		protected void CheckItemCountInAutoFightTest()
		{
		}

		// Token: 0x0600EB7F RID: 60287 RVA: 0x003EB997 File Offset: 0x003E9D97
		private void _onTreasureConversionBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TreasureConversionFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600EB80 RID: 60288 RVA: 0x003EB9AC File Offset: 0x003E9DAC
		protected void _InitTownMap()
		{
			this.m_mapFrame = (this.frameMgr.OpenFrame<TownMapFrame>(this.m_mapViewContent, null, string.Empty) as TownMapFrame);
			this.m_mapFrame.SetScale(new Vector2(0.8f, 0.8f));
			this.m_mapViewContent.GetComponent<RectTransform>().sizeDelta = this.m_mapFrame.GetSize();
			this._UpdateTownMap();
		}

		// Token: 0x0600EB81 RID: 60289 RVA: 0x003EBA18 File Offset: 0x003E9E18
		protected void _UpdateTownMap()
		{
			if (this.m_mapFrame != null && this.m_mapScrollRect != null)
			{
				Vector2 playerMainPos = this.m_mapFrame.GetPlayerMainPos();
				Vector2 size = this.m_mapFrame.GetSize();
				Vector2 size2 = this.m_mapScrollRect.viewport.rect.size;
				this.m_mapScrollRect.normalizedPosition = new Vector2((playerMainPos.x - size2.x * 0.5f) / (size.x - size2.x), (playerMainPos.y - size2.y * 0.5f) / (size.y - size2.y));
				this.m_labMapTitle.text = this.m_mapFrame.GetCurrentSceneName();
			}
		}

		// Token: 0x0600EB82 RID: 60290 RVA: 0x003EBAE4 File Offset: 0x003E9EE4
		protected void _ClearTownMap()
		{
			this.frameMgr.CloseFrame<TownMapFrame>(null, false);
			if (this.m_mapViewContent != null)
			{
				this.m_mapViewContent = null;
			}
			if (this.m_mapFrame != null)
			{
				this.m_mapFrame = null;
			}
			if (this.m_mapScrollRect != null)
			{
				this.m_mapScrollRect = null;
			}
		}

		// Token: 0x0600EB83 RID: 60291 RVA: 0x003EBB40 File Offset: 0x003E9F40
		[UIEventHandle("minimap/FullMap")]
		private void _OnFullMapClicked()
		{
			if (Singleton<NewbieGuideManager>.GetInstance().IsGuidingControl())
			{
				return;
			}
			this.frameMgr.OpenFrame<TownFullMapFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600EB84 RID: 60292 RVA: 0x003EBB65 File Offset: 0x003E9F65
		private void _InitActivityJar()
		{
			this.m_objActivityJar.SetActive(DataManager<JarDataManager>.GetInstance().HasActivityJar() && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.ActivityJar));
		}

		// Token: 0x0600EB85 RID: 60293 RVA: 0x003EBB8C File Offset: 0x003E9F8C
		private void _UpdateActivityJar()
		{
			ComTopButtonExpandController component = this.mBtShowHide.GetComponent<ComTopButtonExpandController>();
			if (component == null)
			{
				return;
			}
			this.m_objActivityJar.SetActive(DataManager<JarDataManager>.GetInstance().HasActivityJar() && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.ActivityJar) && component.IsExpand());
		}

		// Token: 0x0600EB86 RID: 60294 RVA: 0x003EBBE1 File Offset: 0x003E9FE1
		[UIEventHandle("topright/activityJar")]
		private void _OnActivityJarClicked()
		{
			this.frameMgr.OpenFrame<ActivityJarFrame>(FrameLayer.Middle, null, string.Empty);
			this.UpdateBeStrongExpand(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("ActivityJar");
		}

		// Token: 0x0600EB87 RID: 60295 RVA: 0x003EBC0C File Offset: 0x003EA00C
		[UIEventHandle("topright2/artifactJar")]
		private void _OnArtifactJarClicked()
		{
			if (ArtifactFrame.IsArtifactJarDiscountActivityOpen())
			{
				if (ActivityJarFrame.IsHaveGotArtifactJarDiscount())
				{
					this.frameMgr.OpenFrame<ArtifactFrame>(FrameLayer.Middle, null, string.Empty);
				}
				else
				{
					DataManager<ArtifactDataManager>.GetInstance().SendGetDiscount();
				}
			}
			else if (ArtifactFrame.IsArtifactJarShowActivityOpen())
			{
				this.frameMgr.OpenFrame<ArtifactFrame>(FrameLayer.Middle, null, string.Empty);
			}
			else if (ArtifactFrame.IsArtifactJarRewardActivityOpen())
			{
				this.frameMgr.OpenFrame<ArtifactFrame>(FrameLayer.Middle, null, string.Empty);
			}
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("ArtifactJar");
		}

		// Token: 0x0600EB88 RID: 60296 RVA: 0x003EBCA2 File Offset: 0x003EA0A2
		private void _InitMagicJar()
		{
		}

		// Token: 0x0600EB89 RID: 60297 RVA: 0x003EBCA4 File Offset: 0x003EA0A4
		private void UpdateSDKBindPhoneBtn()
		{
			ComTopButtonExpandController component = this.mBtShowHide.GetComponent<ComTopButtonExpandController>();
			if (component == null)
			{
				return;
			}
			if (this.mSDKBindPhoneBtn)
			{
				this.mSDKBindPhoneBtn.gameObject.CustomActive(DataManager<MobileBindManager>.GetInstance().IsMobileBindFuncEnable() && component.IsExpand());
			}
		}

		// Token: 0x0600EB8A RID: 60298 RVA: 0x003EBD02 File Offset: 0x003EA102
		private void InitHorseGambling()
		{
			if (DataManager<HorseGamblingDataManager>.GetInstance().IsOpen)
			{
				this.mButtonHorseGambling.CustomActive(true);
			}
			else
			{
				this.mButtonHorseGambling.CustomActive(false);
			}
		}

		// Token: 0x0600EB8B RID: 60299 RVA: 0x003EBD30 File Offset: 0x003EA130
		private void InitTreasureLotteryActivityUI()
		{
			ETreasureLotterState state = DataManager<ActivityTreasureLotteryDataManager>.GetInstance().GetState();
			if (state == ETreasureLotterState.Open || state == ETreasureLotterState.Prepare)
			{
				this.mButtonTreasureLotteryActivity.CustomActive(true);
			}
			else
			{
				this.mButtonTreasureLotteryActivity.CustomActive(false);
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ActivityTreasureLotteryFrame>(null, false);
			}
			if (DataManager<ActivityTreasureLotteryDataManager>.GetInstance().GetDrawLotteryCount() > 0)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActivityTreasureLotteryTipFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600EB8C RID: 60300 RVA: 0x003EBDA4 File Offset: 0x003EA1A4
		private void InitHaveGoodsRecommend()
		{
			bool haveGoodsRecommendReq = DataManager<MallDataManager>.GetInstance().HaveGoodsRecommendReq;
			if (haveGoodsRecommendReq)
			{
				DataManager<MallDataManager>.GetInstance().SendGoodsRecommendReq();
			}
		}

		// Token: 0x0600EB8D RID: 60301 RVA: 0x003EBDCC File Offset: 0x003EA1CC
		private void ShowLimitTimeActivity(UIEvent mEvent)
		{
			this.InitLimitTimeActivity();
		}

		// Token: 0x0600EB8E RID: 60302 RVA: 0x003EBDD4 File Offset: 0x003EA1D4
		private void InitOnlineServiceBtn()
		{
			bool bActive;
			if (!Singleton<PluginManager>.instance.IsSDKEnableSystemVersion(SDKInterface.FuncSDKType.FSDK_UniWebView))
			{
				bActive = false;
				if (this.onlineServiceNote)
				{
					this.onlineServiceNote.CustomActive(false);
				}
				if (this.mOnLineTips)
				{
					this.mOnLineTips.CustomActive(false);
				}
			}
			else
			{
				bActive = DataManager<OnlineServiceManager>.GetInstance().TryReqOnlineServiceOpen();
			}
			if (this.onlineServiceBtn)
			{
				this.onlineServiceBtn.gameObject.CustomActive(bActive);
			}
		}

		// Token: 0x0600EB8F RID: 60303 RVA: 0x003EBE60 File Offset: 0x003EA260
		private void InitLimitTimeActivity()
		{
			if (DataManager<ActivityManager>.GetInstance().IsHaveAnyActivity())
			{
				this.mActivityLimitTimtFrame.transform.parent.gameObject.CustomActive(true);
			}
			else
			{
				this.mActivityLimitTimtFrame.transform.parent.gameObject.CustomActive(false);
			}
			this.mActivityLimitTimeRedPoint.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.ActivityLimitTime));
		}

		// Token: 0x0600EB90 RID: 60304 RVA: 0x003EBED1 File Offset: 0x003EA2D1
		private void _OnOnlineServiceClicked()
		{
			DataManager<OnlineServiceManager>.GetInstance().TryReqOnlineServiceSign();
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("OnLineService");
		}

		// Token: 0x0600EB91 RID: 60305 RVA: 0x003EBEEC File Offset: 0x003EA2EC
		private void OnGunakaFrameOpen(UIEvent mEvent)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<OnlineServiceFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<OnlineServiceFrame>(null, false);
			}
		}

		// Token: 0x0600EB92 RID: 60306 RVA: 0x003EBF0C File Offset: 0x003EA30C
		private void MakeShowOnlineService(UIEvent mEvent)
		{
			if (this.onlineServiceBtn)
			{
				bool isOnlineServiceOpen = DataManager<OnlineServiceManager>.GetInstance().IsOnlineServiceOpen;
				this.onlineServiceBtn.gameObject.CustomActive(isOnlineServiceOpen);
				if (this.onlineServiceNote)
				{
					this.onlineServiceNote.CustomActive(false);
				}
				if (this.mOnLineTips)
				{
					this.mOnLineTips.CustomActive(false);
				}
				if (!isOnlineServiceOpen && Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<OnlineServiceFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<OnlineServiceFrame>(null, false);
				}
			}
		}

		// Token: 0x0600EB93 RID: 60307 RVA: 0x003EBFA0 File Offset: 0x003EA3A0
		private void OnPrivateOrderingNoticeUpdate(UIEvent iEvent)
		{
			if ((int)iEvent.Param1 == 1 && (bool)iEvent.Param3)
			{
				this.mPrivateCustomBubbles.gameObject.CustomActive(false);
			}
			else if ((int)iEvent.Param1 == 2)
			{
				this.mPrivateCustomBubbles.gameObject.CustomActive(false);
			}
			this.CheckIsHidePrivateCustomShow(this.mPrivateCustomBubbles.gameObject);
		}

		// Token: 0x0600EB94 RID: 60308 RVA: 0x003EC018 File Offset: 0x003EA418
		private void OnNewbieGuideStart(UIEvent iEvent)
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<TownFullMapFrame>(null, false);
		}

		// Token: 0x0600EB95 RID: 60309 RVA: 0x003EC026 File Offset: 0x003EA426
		private void OnUpdateActivityLimitTimeState(UIEvent iEvent)
		{
			this.InitLimitTimeActivity();
		}

		// Token: 0x0600EB96 RID: 60310 RVA: 0x003EC030 File Offset: 0x003EA430
		private bool IsShowGuildSkillEquipTips()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PkWaitingRoom>(null))
			{
				return false;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.SceneSubType != CitySceneTable.eSceneSubType.NULL)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600EB97 RID: 60311 RVA: 0x003EC094 File Offset: 0x003EA494
		private void mRightLowerBubblePlayAnimation(UIEvent uiEvent)
		{
			BubbleShowType bubbleShowType = (BubbleShowType)uiEvent.Param1;
			if (bubbleShowType != BubbleShowType.Guild)
			{
				if (bubbleShowType != BubbleShowType.Skill)
				{
					if (bubbleShowType == BubbleShowType.EquipHandBook)
					{
						DOTweenAnimation[] components = this.mEquipHandBookTips.GetComponents<DOTweenAnimation>();
						DOTweenAnimation[] components2 = this.mEquipHandBookTipsText.GetComponents<DOTweenAnimation>();
						if (components != null && components2 != null)
						{
							for (int i = 0; i < components.Length; i++)
							{
								if (components[i] != null)
								{
									components[i].DORestart(false);
									if (i == 1)
									{
										components[i].onStepComplete.AddListener(new UnityAction(this.OnEquipHandBookAniComPlete));
									}
								}
								if (i < components2.Length && components2[i] != null)
								{
									components2[i].DORestart(false);
								}
							}
						}
						if (this.IsShowGuildSkillEquipTips())
						{
							this._SetEquipHandBookTipActive(true);
						}
					}
				}
				else
				{
					DOTweenAnimation[] components3 = this.mBeStrongTips.GetComponents<DOTweenAnimation>();
					DOTweenAnimation[] components4 = this.mBeStrongTipsText.GetComponents<DOTweenAnimation>();
					if (components3 != null && components4 != null)
					{
						for (int j = 0; j < components3.Length; j++)
						{
							if (components3[j] != null)
							{
								components3[j].DORestart(false);
								if (j == 1)
								{
									components3[j].onStepComplete.AddListener(new UnityAction(this.OnSkillTipsAniComplete));
								}
							}
							if (j < components4.Length && components4[j] != null)
							{
								components4[j].DORestart(false);
							}
						}
					}
					if (this.IsShowGuildSkillEquipTips())
					{
						this._SetSkillTipActive(true);
					}
				}
			}
			else
			{
				DOTweenAnimation[] components5 = this.mGuildTips.GetComponents<DOTweenAnimation>();
				DOTweenAnimation[] components6 = this.mGuildTipsText.GetComponents<DOTweenAnimation>();
				if (components5 != null && components6 != null)
				{
					for (int k = 0; k < components5.Length; k++)
					{
						if (components5[k] != null)
						{
							components5[k].DORestart(false);
							if (k == 1)
							{
								components5[k].onStepComplete.AddListener(new UnityAction(this.OnGuildTipsAniComPlete));
							}
						}
						if (k < components6.Length && components6[k] != null)
						{
							components6[k].DORestart(false);
						}
					}
				}
				if (this.IsShowGuildSkillEquipTips())
				{
					this._SetGuildTipActive(true);
				}
			}
		}

		// Token: 0x0600EB98 RID: 60312 RVA: 0x003EC2E4 File Offset: 0x003EA6E4
		private void OnUpdateActivityTreasureLottery(UIEvent iEvent)
		{
			this.InitTreasureLotteryActivityUI();
		}

		// Token: 0x0600EB99 RID: 60313 RVA: 0x003EC2EC File Offset: 0x003EA6EC
		private void OnUpdateHorseGambling(UIEvent iEvent)
		{
			this.InitHorseGambling();
		}

		// Token: 0x0600EB9A RID: 60314 RVA: 0x003EC2F4 File Offset: 0x003EA6F4
		private void OnRecOnlineServiceNewNote(UIEvent mEvent)
		{
			bool bActive = (bool)mEvent.Param1;
			if (this.onlineServiceNote)
			{
				this.onlineServiceNote.CustomActive(bActive);
			}
			if (this.mOnLineTips)
			{
				this.mOnLineTips.CustomActive(bActive);
			}
		}

		// Token: 0x0600EB9B RID: 60315 RVA: 0x003EC345 File Offset: 0x003EA745
		private void OnRelationChanged(UIEvent mEvent)
		{
			this._CheckFriendRedPoint();
		}

		// Token: 0x0600EB9C RID: 60316 RVA: 0x003EC34D File Offset: 0x003EA74D
		private void _OnRandomTreasureFuncChange(UIEvent uiEvent)
		{
			this._UpdateRandomTreasure();
		}

		// Token: 0x0600EB9D RID: 60317 RVA: 0x003EC355 File Offset: 0x003EA755
		private void _OnStrengthTicketMergeStateUpdate(UIEvent uiEvent)
		{
			this._UpdateStrengthenTicketMerge();
		}

		// Token: 0x0600EB9E RID: 60318 RVA: 0x003EC35D File Offset: 0x003EA75D
		private void _OnAdventureTeamFuncChanged(UIEvent uiEvent)
		{
			this._UpdateAdventureTeamShow();
		}

		// Token: 0x0600EB9F RID: 60319 RVA: 0x003EC365 File Offset: 0x003EA765
		private void _OnFashionMergeSwitchFunc(UIEvent uiEvent)
		{
			this.UpdateFashionMergeBtnState();
		}

		// Token: 0x0600EBA0 RID: 60320 RVA: 0x003EC36D File Offset: 0x003EA76D
		private void _OnSyncActivityState(UIEvent uiEvent)
		{
			this.UpdateGuildEffect();
		}

		// Token: 0x0600EBA1 RID: 60321 RVA: 0x003EC378 File Offset: 0x003EA778
		private void UpdateFashionMergeBtnState()
		{
			bool bActive = !DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_FASHION_MERGO) && Utility.IsUnLockFunc(45);
			if (this.mBtFashionMerge)
			{
				this.mBtFashionMerge.CustomActive(bActive);
			}
		}

		// Token: 0x0600EBA2 RID: 60322 RVA: 0x003EC3C0 File Offset: 0x003EA7C0
		private void _OnTopUpPushButoonOpen(UIEvent uiEvent)
		{
			this.mExclusivPreferentialBtn.CustomActive(true);
		}

		// Token: 0x0600EBA3 RID: 60323 RVA: 0x003EC3CE File Offset: 0x003EA7CE
		private void _OnTopUpPushButoonClose(UIEvent uiEvent)
		{
			this.mExclusivPreferentialBtn.CustomActive(false);
		}

		// Token: 0x0600EBA4 RID: 60324 RVA: 0x003EC3DC File Offset: 0x003EA7DC
		private void _OnGuildDungeonAuctionStateUpdate(UIEvent uiEvent)
		{
			this.guildDungeonAuction.CustomActive(DataManager<GuildDataManager>.GetInstance().IsGuildAuctionOpen || DataManager<GuildDataManager>.GetInstance().IsGuildWorldAuctionOpen);
		}

		// Token: 0x0600EBA5 RID: 60325 RVA: 0x003EC405 File Offset: 0x003EA805
		private void _OnGuildDungeonWorldAuctionStateUpdate(UIEvent uiEvent)
		{
		}

		// Token: 0x0600EBA6 RID: 60326 RVA: 0x003EC407 File Offset: 0x003EA807
		private void _OnGuildDungeonAuctionAddNewItem(UIEvent uiEvent)
		{
			this.guildDungeonAuctionRedPoint.CustomActive(DataManager<GuildDataManager>.GetInstance().HaveNewWorldAuctonItem || DataManager<GuildDataManager>.GetInstance().HaveNewGuildAuctonItem);
		}

		// Token: 0x0600EBA7 RID: 60327 RVA: 0x003EC430 File Offset: 0x003EA830
		private void _OnUpdateHeadPortraitFrame(UIEvent uiEvent)
		{
			this.UpdatePlayerHeadPortraitFrame();
		}

		// Token: 0x0600EBA8 RID: 60328 RVA: 0x003EC438 File Offset: 0x003EA838
		private void _OnHeadPortraitFrameChanged(UIEvent uiEvent)
		{
			this.UpdatePlayerHeadPortraitFrame();
		}

		// Token: 0x0600EBA9 RID: 60329 RVA: 0x003EC440 File Offset: 0x003EA840
		private void _OnNotifyShowAdventurePassSeasonUnlockAnim(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			FollowingOpenTrigger followingOpenTrigger = uiEvent.Param1 as FollowingOpenTrigger;
			if (followingOpenTrigger == null)
			{
				return;
			}
			this._TryPlayAdventurePassSeasonFuncUnlockAnim(followingOpenTrigger);
		}

		// Token: 0x0600EBAA RID: 60330 RVA: 0x003EC47C File Offset: 0x003EA87C
		private void _OnNotifyShowAdventureTeamUnlockAnim(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			FollowingOpenTrigger followingOpenTrigger = uiEvent.Param1 as FollowingOpenTrigger;
			if (followingOpenTrigger == null)
			{
				return;
			}
			this._TryPlayAdventureTeamFuncUnlockAnim(followingOpenTrigger);
		}

		// Token: 0x0600EBAB RID: 60331 RVA: 0x003EC4B8 File Offset: 0x003EA8B8
		private void _OnUpdateAventurePassButtonRedPoint(UIEvent uiEvent)
		{
			if (uiEvent != null)
			{
				if (uiEvent.Param1 != null)
				{
					bool bActive = (bool)uiEvent.Param1;
					this.mAdventurerPassCardRedPoint.CustomActive(bActive);
				}
				else
				{
					bool bActive2 = AdventurerPassCardFrame.CanOneKeyGetAwards() || DataManager<AdventurerPassCardDataManager>.GetInstance().GetExpPackState() == AdventurerPassCardDataManager.ExpPackState.CanGet;
					this.mAdventurerPassCardRedPoint.CustomActive(bActive2);
				}
			}
		}

		// Token: 0x0600EBAC RID: 60332 RVA: 0x003EC51A File Offset: 0x003EA91A
		private void _OnUpdateAventurePassStatus(UIEvent uiEvent)
		{
			this.UpdateAdventurePassCardButton();
		}

		// Token: 0x0600EBAD RID: 60333 RVA: 0x003EC524 File Offset: 0x003EA924
		private void _OnNotifyOpenWelfareFrame(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			FollowingOpenTrigger followingOpenTrigger = uiEvent.Param1 as FollowingOpenTrigger;
			if (followingOpenTrigger == null)
			{
				return;
			}
			this._TryOpenActiveFrame(followingOpenTrigger);
		}

		// Token: 0x0600EBAE RID: 60334 RVA: 0x003EC560 File Offset: 0x003EA960
		private void OnNewAccountFuncUnlock(UIEvent iEvent)
		{
			byte id = (byte)iEvent.Param1;
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>((int)id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.TargetBtnPos == string.Empty || tableItem.TargetBtnPos == "-")
			{
				return;
			}
			GameObject gameObject = Utility.FindGameObject(this.frame, tableItem.TargetBtnPos, true);
			if (gameObject == null)
			{
				return;
			}
			if (tableItem.ExpandType == FunctionUnLock.eExpandType.ET_TopRight)
			{
				ComTopButtonExpandController component = this.mBtShowHide.GetComponent<ComTopButtonExpandController>();
				if (component == null)
				{
					return;
				}
				if (!component.IsExpand())
				{
					component.MainButtonState();
					return;
				}
			}
			GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/UI/Prefab/EffUI_xinxiaoxi", true, 0U);
			if (gameObject2 != null)
			{
				Utility.AttachTo(gameObject2, gameObject, false);
				this.unlockEffectList.Add(gameObject2);
			}
			if (tableItem.FuncType == FunctionUnLock.eFuncType.AdventureTeam)
			{
				gameObject.SetActive(DataManager<AdventureTeamDataManager>.GetInstance().BFuncOpened);
			}
			if (tableItem.FuncType == FunctionUnLock.eFuncType.AdventurePassSeason)
			{
				gameObject.CustomActive(true);
			}
			if (tableItem.FuncType == FunctionUnLock.eFuncType.AdventurePassSeason && this.isTownSceneLoadFinish)
			{
				InvokeMethod.RemoveInvokeCall(new UnityAction(this.PlayAdventurePassSeasonFuncUnlockAnim));
				InvokeMethod.Invoke(1f, new UnityAction(this.PlayAdventurePassSeasonFuncUnlockAnim));
			}
		}

		// Token: 0x0600EBAF RID: 60335 RVA: 0x003EC6C0 File Offset: 0x003EAAC0
		private void PlayAdventurePassSeasonFuncUnlockAnim()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<FunctionUnlockFrame>(null))
			{
				return;
			}
			this._PlaySelectNewFuncUnlockAnim(FunctionUnLock.eFuncType.AdventurePassSeason, delegate
			{
			}, delegate
			{
			});
		}

		// Token: 0x0600EBB0 RID: 60336 RVA: 0x003EC720 File Offset: 0x003EAB20
		private void _InitRandomTreasure()
		{
			bool flag = DataManager<RandomTreasureDataManager>.GetInstance().IsServerSwitchFuncOn();
			if (this.mRandomtreasure)
			{
				this.mRandomtreasure.CustomActive(flag && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.RandomTreasure));
			}
		}

		// Token: 0x0600EBB1 RID: 60337 RVA: 0x003EC764 File Offset: 0x003EAB64
		private void _UpdateRandomTreasure()
		{
			bool flag = DataManager<RandomTreasureDataManager>.GetInstance().IsServerSwitchFuncOn();
			ComTopButtonExpandController component = this.mBtShowHide.GetComponent<ComTopButtonExpandController>();
			if (component == null)
			{
				return;
			}
			if (this.mRandomtreasure)
			{
				this.mRandomtreasure.CustomActive(flag && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.RandomTreasure) && component.IsExpand());
			}
		}

		// Token: 0x0600EBB2 RID: 60338 RVA: 0x003EC7CB File Offset: 0x003EABCB
		private void _InitSDKIcon()
		{
			if (this.mOppo2sdk != null)
			{
				this.mOppo2sdk.UpdateShow();
			}
		}

		// Token: 0x0600EBB3 RID: 60339 RVA: 0x003EC7EC File Offset: 0x003EABEC
		private void _InitStrengthenTicketMerge()
		{
			bool bfuncOpen = DataManager<StrengthenTicketMergeDataManager>.GetInstance().BFuncOpen;
			if (this.mStrengthenTicketMerge)
			{
				this.mStrengthenTicketMerge.CustomActive(bfuncOpen);
			}
		}

		// Token: 0x0600EBB4 RID: 60340 RVA: 0x003EC820 File Offset: 0x003EAC20
		private void _UpdateStrengthenTicketMerge()
		{
			bool bfuncOpen = DataManager<StrengthenTicketMergeDataManager>.GetInstance().BFuncOpen;
			ComTopButtonExpandController component = this.mBtShowHide.GetComponent<ComTopButtonExpandController>();
			if (component == null)
			{
				return;
			}
			if (this.mStrengthenTicketMerge)
			{
				this.mStrengthenTicketMerge.CustomActive(bfuncOpen && component.IsExpand());
			}
		}

		// Token: 0x0600EBB5 RID: 60341 RVA: 0x003EC87B File Offset: 0x003EAC7B
		private void _InitDailyTodoRoot()
		{
			if (this.mDailyTodoRoot)
			{
				this.mDailyTodoRoot.CustomActive(DataManager<DailyTodoDataManager>.GetInstance().BFuncOpen);
			}
		}

		// Token: 0x0600EBB6 RID: 60342 RVA: 0x003EC8A4 File Offset: 0x003EACA4
		private void _InitAdventureTeamShow()
		{
			bool bfuncOpened = DataManager<AdventureTeamDataManager>.GetInstance().BFuncOpened;
			this.mAdventureTeamRoot.CustomActive(bfuncOpened);
		}

		// Token: 0x0600EBB7 RID: 60343 RVA: 0x003EC8C8 File Offset: 0x003EACC8
		private void _UpdateAdventureTeamShow()
		{
			bool bfuncOpened = DataManager<AdventureTeamDataManager>.GetInstance().BFuncOpened;
			this.mAdventureTeamRoot.CustomActive(bfuncOpened);
		}

		// Token: 0x0600EBB8 RID: 60344 RVA: 0x003EC8EC File Offset: 0x003EACEC
		private void _TryPlayAdventurePassSeasonFuncUnlockAnim(FollowingOpenTrigger trigger)
		{
			if (DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv == 0U)
			{
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList == null)
			{
				return;
			}
			if (!DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.Contains(93))
			{
				return;
			}
			if (this.waitToPlayAdventurePassSeasonFuncUnlock != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToPlayAdventurePassSeasonFuncUnlock);
			}
			this.waitToPlayAdventurePassSeasonFuncUnlock = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._WaitToPlayAdventurePassSeasonFuncUnlockAnim());
			if (this.isPlayAdventurePassSeasonSuccess && trigger != null)
			{
				trigger.triggerType = FollowingOpenTriggerType.Normal;
			}
		}

		// Token: 0x0600EBB9 RID: 60345 RVA: 0x003EC97C File Offset: 0x003EAD7C
		private void _TryPlayAdventureTeamFuncUnlockAnim(FollowingOpenTrigger trigger)
		{
			if (!DataManager<AdventureTeamDataManager>.GetInstance().BFuncOpened)
			{
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList == null)
			{
				return;
			}
			if (!DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.Contains(86))
			{
				return;
			}
			if (this.waitToPlayAdventureTeamFuncUnlock != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToPlayAdventureTeamFuncUnlock);
			}
			this.waitToPlayAdventureTeamFuncUnlock = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._WaitToPlayAdventureTeamFuncUnlockAnim());
			if (this.isPlayAdventureTeamSuccess && trigger != null)
			{
				trigger.triggerType = FollowingOpenTriggerType.Normal;
			}
		}

		// Token: 0x0600EBBA RID: 60346 RVA: 0x003ECA0C File Offset: 0x003EAE0C
		private IEnumerator _WaitToPlayAdventurePassSeasonFuncUnlockAnim()
		{
			float delayTime = 1f;
			yield return Yielders.GetWaitForSeconds(delayTime);
			this._PlaySelectNewFuncUnlockAnim(FunctionUnLock.eFuncType.AdventurePassSeason, delegate
			{
				this.isPlayAdventurePassSeasonSuccess = true;
			}, delegate
			{
				DataManager<FollowingOpenQueueManager>.GetInstance().NotifyCurrentOrderClosed();
			});
			yield break;
		}

		// Token: 0x0600EBBB RID: 60347 RVA: 0x003ECA28 File Offset: 0x003EAE28
		private IEnumerator _WaitToPlayAdventureTeamFuncUnlockAnim()
		{
			float delayTime = 1f;
			if (this.mAdventureTeamDOTweenBind != null)
			{
				delayTime = this.mAdventureTeamDOTweenBind.doTweeningDelayTime;
			}
			yield return Yielders.GetWaitForSeconds(delayTime);
			this._PlaySelectNewFuncUnlockAnim(FunctionUnLock.eFuncType.AdventureTeam, delegate
			{
				this.isPlayAdventureTeamSuccess = true;
			}, delegate
			{
				DataManager<FollowingOpenQueueManager>.GetInstance().NotifyCurrentOrderClosed();
			});
			yield break;
		}

		// Token: 0x0600EBBC RID: 60348 RVA: 0x003ECA43 File Offset: 0x003EAE43
		private void _ClearAdventurePassSeasonFuncUnlockCoroutine()
		{
			if (this.waitToPlayAdventurePassSeasonFuncUnlock != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToPlayAdventurePassSeasonFuncUnlock);
				this.waitToPlayAdventurePassSeasonFuncUnlock = null;
			}
			this.isPlayAdventurePassSeasonSuccess = false;
		}

		// Token: 0x0600EBBD RID: 60349 RVA: 0x003ECA6E File Offset: 0x003EAE6E
		private void _ClearAdventureTeamFuncUnlockCoroutine()
		{
			if (this.waitToPlayAdventureTeamFuncUnlock != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToPlayAdventureTeamFuncUnlock);
				this.waitToPlayAdventureTeamFuncUnlock = null;
			}
			this.isPlayAdventureTeamSuccess = false;
		}

		// Token: 0x0600EBBE RID: 60350 RVA: 0x003ECA9C File Offset: 0x003EAE9C
		private void _PlaySelectNewFuncUnlockAnim(FunctionUnLock.eFuncType funcType, Action onPlayStartHandler = null, Action onPlayEndHandler = null)
		{
			if (DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList == null)
			{
				return;
			}
			if (!DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.Contains((int)funcType))
			{
				return;
			}
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>((int)funcType, string.Empty, string.Empty);
			if (tableItem.bPlayAnim == 0)
			{
				return;
			}
			if (tableItem.TargetBtnPos == string.Empty || tableItem.TargetBtnPos == "-")
			{
				return;
			}
			GameObject gameObject = Utility.FindGameObject(this.frame, tableItem.TargetBtnPos, true);
			if (gameObject == null)
			{
				return;
			}
			UnlockData unlockData = default(UnlockData);
			unlockData.FuncUnlockID = (int)funcType;
			unlockData.pos = gameObject.transform.position;
			FunctionUnlockFrame functionUnlockFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<FunctionUnlockFrame>(FrameLayer.Top, unlockData, string.Empty) as FunctionUnlockFrame;
			if (functionUnlockFrame != null && onPlayStartHandler != null)
			{
				onPlayStartHandler();
			}
			functionUnlockFrame.ResPlayEnd = delegate()
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<FunctionUnlockFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<FunctionUnlockFrame>(null, false);
				}
				if (onPlayEndHandler != null)
				{
					onPlayEndHandler();
				}
			};
			DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.Remove((int)funcType);
		}

		// Token: 0x0600EBBF RID: 60351 RVA: 0x003ECBC0 File Offset: 0x003EAFC0
		private bool CheckIsFunctionClose(FunctionUnLock funcData)
		{
			if (funcData == null)
			{
				return false;
			}
			int num = 32;
			if (funcData.ID == num && Singleton<IOSFunctionSwitchManager>.GetInstance().IsFunctionClosed(IOSFuncSwitchTable.eType.SEVEN_AWARDS))
			{
				return true;
			}
			if (funcData.FuncType == FunctionUnLock.eFuncType.ActivityJar)
			{
				if (Singleton<IOSFunctionSwitchManager>.GetInstance().IsFunctionClosed(IOSFuncSwitchTable.eType.LIMITTIME_JAR))
				{
					return true;
				}
			}
			else if (funcData.FuncType == FunctionUnLock.eFuncType.Ranklist)
			{
				if (Singleton<IOSFunctionSwitchManager>.GetInstance().IsFunctionClosed(IOSFuncSwitchTable.eType.SHARE_TEXT_CHANGE))
				{
					return true;
				}
			}
			else if (funcData.FuncType == FunctionUnLock.eFuncType.ActivityLimitTime)
			{
				if (Singleton<IOSFunctionSwitchManager>.GetInstance().IsFunctionClosed(IOSFuncSwitchTable.eType.SHARE_TEXT_CHANGE))
				{
					return true;
				}
			}
			else if (funcData.FuncType == FunctionUnLock.eFuncType.FestivalActivity && Singleton<IOSFunctionSwitchManager>.GetInstance().IsFunctionClosed(IOSFuncSwitchTable.eType.LIMITTIME_ACTIVITY))
			{
				return true;
			}
			return false;
		}

		// Token: 0x0600EBC0 RID: 60352 RVA: 0x003ECC84 File Offset: 0x003EB084
		private void TryHideRankListAtFirst()
		{
			if (Singleton<IOSFunctionSwitchManager>.GetInstance().IsFunctionClosed(IOSFuncSwitchTable.eType.SHARE_TEXT_CHANGE) && this.mRankList)
			{
				this.mRankList.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600EBC1 RID: 60353 RVA: 0x003ECCB8 File Offset: 0x003EB0B8
		private bool CheckIsHidePrivateCustomShow(GameObject privateCustomBubbles)
		{
			if (Singleton<IOSFunctionSwitchManager>.GetInstance().IsFunctionClosed(IOSFuncSwitchTable.eType.LIMITTIME_GIFT) && privateCustomBubbles)
			{
				privateCustomBubbles.CustomActive(false);
				return true;
			}
			return false;
		}

		// Token: 0x04008E52 RID: 36434
		private bool mIsStopMoveFunction;

		// Token: 0x04008E53 RID: 36435
		private bool mLastJoyStickFizzyCheck;

		// Token: 0x04008E54 RID: 36436
		private Vector2 mLastJoyStickPosition = Vector2.zero;

		// Token: 0x04008E55 RID: 36437
		private float m_sin60 = 0.8660254f;

		// Token: 0x04008E56 RID: 36438
		private float m_sin45 = 0.7071067f;

		// Token: 0x04008E57 RID: 36439
		private float m_sin30 = 0.5f;

		// Token: 0x04008E58 RID: 36440
		public static bool IsShowSkillTips;

		// Token: 0x04008E59 RID: 36441
		public static bool IsShowGuildTips;

		// Token: 0x04008E5A RID: 36442
		public static bool IsShowEquipHandBookTips;

		// Token: 0x04008E5B RID: 36443
		private static bool bGuardForNotify;

		// Token: 0x04008E5C RID: 36444
		private float DayOnlineInterval;

		// Token: 0x04008E5D RID: 36445
		private float TimeFreshInterval;

		// Token: 0x04008E5E RID: 36446
		private float BatteryFreshInterval;

		// Token: 0x04008E5F RID: 36447
		private float PrivateCustomBubbleTime;

		// Token: 0x04008E60 RID: 36448
		private bool isTownSceneLoadFinish;

		// Token: 0x04008E61 RID: 36449
		private InputManager _inputManager;

		// Token: 0x04008E62 RID: 36450
		private ComTalk m_miniTalk;

		// Token: 0x04008E63 RID: 36451
		private int ChangeJobSelectID;

		// Token: 0x04008E64 RID: 36452
		public const int oppoPrivilegeID = 12000;

		// Token: 0x04008E65 RID: 36453
		public const int vivoPrivilegeID = 23000;

		// Token: 0x04008E66 RID: 36454
		public const int huawei = 21100;

		// Token: 0x04008E67 RID: 36455
		public const int oppo = 21200;

		// Token: 0x04008E68 RID: 36456
		public const int vivo = 21300;

		// Token: 0x04008E69 RID: 36457
		public const int xiaomi = 21400;

		// Token: 0x04008E6A RID: 36458
		public const int meizu = 21500;

		// Token: 0x04008E6B RID: 36459
		public const string unLockEffect = "Effects/UI/Prefab/EffUI_xinxiaoxi";

		// Token: 0x04008E6C RID: 36460
		private List<GameObject> unlockEffectList = new List<GameObject>();

		// Token: 0x04008E6D RID: 36461
		private bool bNeedSwitchToChijiPrepare;

		// Token: 0x04008E6E RID: 36462
		[UIControl("left", typeof(ComFunction), 0)]
		private ComFunction comFuntion;

		// Token: 0x04008E6F RID: 36463
		private bool mIsCanShowGiftFrame = true;

		// Token: 0x04008E70 RID: 36464
		protected float fpsAcc;

		// Token: 0x04008E71 RID: 36465
		private Button mHeadIcon;

		// Token: 0x04008E72 RID: 36466
		private Text mVipText;

		// Token: 0x04008E73 RID: 36467
		private GameObject mTalkRoot;

		// Token: 0x04008E74 RID: 36468
		private Text mPlayerLevel;

		// Token: 0x04008E75 RID: 36469
		private ComExpBar mExpBar;

		// Token: 0x04008E76 RID: 36470
		private Text mFatigueText;

		// Token: 0x04008E77 RID: 36471
		private Button mPackage;

		// Token: 0x04008E78 RID: 36472
		private Button mFriend;

		// Token: 0x04008E79 RID: 36473
		private Button mGuild;

		// Token: 0x04008E7A RID: 36474
		private Button mMall;

		// Token: 0x04008E7B RID: 36475
		private Button mAuction;

		// Token: 0x04008E7C RID: 36476
		private Button mRankList;

		// Token: 0x04008E7D RID: 36477
		private Image mNextOpenIcon;

		// Token: 0x04008E7E RID: 36478
		private Button mNextopen;

		// Token: 0x04008E7F RID: 36479
		private Text mNextOpenLv;

		// Token: 0x04008E80 RID: 36480
		private Text mNextOpenName;

		// Token: 0x04008E81 RID: 36481
		private Button mChangeJob;

		// Token: 0x04008E82 RID: 36482
		private Button mChangeJobTask;

		// Token: 0x04008E83 RID: 36483
		private Button mDuel;

		// Token: 0x04008E84 RID: 36484
		private Button mVipLevel;

		// Token: 0x04008E85 RID: 36485
		private Button mBtVip;

		// Token: 0x04008E86 RID: 36486
		private Button mFirstRecharge;

		// Token: 0x04008E87 RID: 36487
		private Button mWelFare;

		// Token: 0x04008E88 RID: 36488
		private Button mJar;

		// Token: 0x04008E89 RID: 36489
		private Button mDaily;

		// Token: 0x04008E8A RID: 36490
		private Button mBeStrong;

		// Token: 0x04008E8B RID: 36491
		private Button mRedPacket;

		// Token: 0x04008E8C RID: 36492
		private Text mLabRedPacketCount;

		// Token: 0x04008E8D RID: 36493
		private Image mFriendRedPoint;

		// Token: 0x04008E8E RID: 36494
		private Image mPackageFull;

		// Token: 0x04008E8F RID: 36495
		private DOTweenAnimation mPackageAnim;

		// Token: 0x04008E90 RID: 36496
		private Image mGuildRedPoint;

		// Token: 0x04008E91 RID: 36497
		private Image mPackageRedPoint;

		// Token: 0x04008E92 RID: 36498
		private Image mDuelRedPoint;

		// Token: 0x04008E93 RID: 36499
		private Image mFirstRechargeRedPoint;

		// Token: 0x04008E94 RID: 36500
		private Button mBtSkill;

		// Token: 0x04008E95 RID: 36501
		private Button mBtForge;

		// Token: 0x04008E96 RID: 36502
		private Button mBtFashionMerge;

		// Token: 0x04008E97 RID: 36503
		private Button mBtTitleBook;

		// Token: 0x04008E98 RID: 36504
		private Button mBtEquipForge;

		// Token: 0x04008E99 RID: 36505
		private Button mWantStrong;

		// Token: 0x04008E9A RID: 36506
		private Image mSkillRedPoint;

		// Token: 0x04008E9B RID: 36507
		private Image mEquipForgeRedPoint;

		// Token: 0x04008E9C RID: 36508
		private Image mJarsRedPoint;

		// Token: 0x04008E9D RID: 36509
		private Image mForgeRedPoint;

		// Token: 0x04008E9E RID: 36510
		private GameObject mJarRedPoint;

		// Token: 0x04008E9F RID: 36511
		private GameObject mUpLevelGiftObj;

		// Token: 0x04008EA0 RID: 36512
		private Button mBtUpLevelGift;

		// Token: 0x04008EA1 RID: 36513
		private Text mUplevelGiftText;

		// Token: 0x04008EA2 RID: 36514
		private GameObject mDuelTipRoot;

		// Token: 0x04008EA3 RID: 36515
		private GameObject mDailyRedPoint;

		// Token: 0x04008EA4 RID: 36516
		private Text mDailyRedPointCount;

		// Token: 0x04008EA5 RID: 36517
		private Text mLocalTime;

		// Token: 0x04008EA6 RID: 36518
		private Slider mBattery;

		// Token: 0x04008EA7 RID: 36519
		private Button mOnLineGift;

		// Token: 0x04008EA8 RID: 36520
		private Text mOnlIneGiftText;

		// Token: 0x04008EA9 RID: 36521
		private Button mBeStrongTips;

		// Token: 0x04008EAA RID: 36522
		private Text mBeStrongTipsText;

		// Token: 0x04008EAB RID: 36523
		private Button mBtPet;

		// Token: 0x04008EAC RID: 36524
		private Button mSDKBindPhoneBtn;

		// Token: 0x04008EAD RID: 36525
		private GameObject mSDKBindPhoneBtnRedPoint;

		// Token: 0x04008EAE RID: 36526
		private Button mGraphicTips;

		// Token: 0x04008EAF RID: 36527
		private Text mGraphicTipsText;

		// Token: 0x04008EB0 RID: 36528
		private GameObject mGuildBattleEffect;

		// Token: 0x04008EB1 RID: 36529
		private GameObject mGuildBattleEffectQ;

		// Token: 0x04008EB2 RID: 36530
		private Button onlineServiceBtn;

		// Token: 0x04008EB3 RID: 36531
		private GameObject onlineServiceNote;

		// Token: 0x04008EB4 RID: 36532
		private Button mGuildTips;

		// Token: 0x04008EB5 RID: 36533
		private Text mGuildTipsText;

		// Token: 0x04008EB6 RID: 36534
		private Text mpayText;

		// Token: 0x04008EB7 RID: 36535
		private RectTransform mPrivateCustomBubbles;

		// Token: 0x04008EB8 RID: 36536
		private Button mActivityLimitTimtFrame;

		// Token: 0x04008EB9 RID: 36537
		private Button mOppoLoginAward;

		// Token: 0x04008EBA RID: 36538
		private GameObject mOppoRoot;

		// Token: 0x04008EBB RID: 36539
		private GameObject mOPPORepoint;

		// Token: 0x04008EBC RID: 36540
		private Button mRankallBtn;

		// Token: 0x04008EBD RID: 36541
		private GameObject mRankallRoot;

		// Token: 0x04008EBE RID: 36542
		private GameObject mRedPackRankListObj;

		// Token: 0x04008EBF RID: 36543
		private Button mBtRedPackRankList;

		// Token: 0x04008EC0 RID: 36544
		private Button mBtShowHide;

		// Token: 0x04008EC1 RID: 36545
		private Button mBtnChangeJob;

		// Token: 0x04008EC2 RID: 36546
		private GameObject mOperateAdsRoot;

		// Token: 0x04008EC3 RID: 36547
		private Button mOperateAdsButton;

		// Token: 0x04008EC4 RID: 36548
		private Text mOperateAdsText;

		// Token: 0x04008EC5 RID: 36549
		private GameObject mVivoImg;

		// Token: 0x04008EC6 RID: 36550
		private GameObject mOppoImg;

		// Token: 0x04008EC7 RID: 36551
		private GameObject mVivoText;

		// Token: 0x04008EC8 RID: 36552
		private GameObject mOppoText;

		// Token: 0x04008EC9 RID: 36553
		private Button mEquipHandBookBtn;

		// Token: 0x04008ECA RID: 36554
		private Button mButtonTreasureLotteryActivity;

		// Token: 0x04008ECB RID: 36555
		private Button mButtonHorseGambling;

		// Token: 0x04008ECC RID: 36556
		private Button mEquipRecovery;

		// Token: 0x04008ECD RID: 36557
		private Button mEquipHandBookTips;

		// Token: 0x04008ECE RID: 36558
		private Text mEquipHandBookTipsText;

		// Token: 0x04008ECF RID: 36559
		private RightLowerBubbleShowsOrder mRightLowerBubbleShowOrder;

		// Token: 0x04008ED0 RID: 36560
		private Button mJarTips;

		// Token: 0x04008ED1 RID: 36561
		private Text mJarTipsText;

		// Token: 0x04008ED2 RID: 36562
		private GameObject mActivityLimitTimeRedPoint;

		// Token: 0x04008ED3 RID: 36563
		private GameObject mEquipRecoveryRedPoint;

		// Token: 0x04008ED4 RID: 36564
		private GameObject mPrivateChatBubble;

		// Token: 0x04008ED5 RID: 36565
		private Button mRandomtreasure;

		// Token: 0x04008ED6 RID: 36566
		private GameObject mOppo2Root;

		// Token: 0x04008ED7 RID: 36567
		private Button mOppo2Btn;

		// Token: 0x04008ED8 RID: 36568
		private ComSdkChannelIcon mOppo2sdk;

		// Token: 0x04008ED9 RID: 36569
		private GameObject mTAPGraduationEffUI;

		// Token: 0x04008EDA RID: 36570
		private Button mStrengthenTicketMerge;

		// Token: 0x04008EDB RID: 36571
		private Button mWeaponLease;

		// Token: 0x04008EDC RID: 36572
		private GameObject mAdventureTeamRoot;

		// Token: 0x04008EDD RID: 36573
		private Button mAdventureTeamBtn;

		// Token: 0x04008EDE RID: 36574
		private Button mChiji;

		// Token: 0x04008EDF RID: 36575
		private Button mChallenge;

		// Token: 0x04008EE0 RID: 36576
		private GameObject mAdventureTeamRedPoint;

		// Token: 0x04008EE1 RID: 36577
		private MainTownFrameButtonDOTweenBind mAdventureTeamDOTweenBind;

		// Token: 0x04008EE2 RID: 36578
		private GameObject mOnLineTips;

		// Token: 0x04008EE3 RID: 36579
		private Button mExclusivPreferentialBtn;

		// Token: 0x04008EE4 RID: 36580
		private Button guildDungeonWorldAuction;

		// Token: 0x04008EE5 RID: 36581
		private Button guildDungeonAuction;

		// Token: 0x04008EE6 RID: 36582
		private Button PVETrainDamageBtn;

		// Token: 0x04008EE7 RID: 36583
		private ReplaceHeadPortraitFrame mReplaceHeadPortraitFrame;

		// Token: 0x04008EE8 RID: 36584
		private MainTownFrameCommonButtonControl mMainTownFrameCommonButtonControl;

		// Token: 0x04008EE9 RID: 36585
		private GameObject guildDungeonAuctionRedPoint;

		// Token: 0x04008EEA RID: 36586
		private Button mDailyTodoBtn;

		// Token: 0x04008EEB RID: 36587
		private GameObject mDailyTodoRoot;

		// Token: 0x04008EEC RID: 36588
		private Button btnMagicCard;

		// Token: 0x04008EED RID: 36589
		private Button btnTitleBook;

		// Token: 0x04008EEE RID: 36590
		private Button mBtnDownload;

		// Token: 0x04008EEF RID: 36591
		private Button adventurerPassCard;

		// Token: 0x04008EF0 RID: 36592
		private TimePlayButton mTimePlayBtn;

		// Token: 0x04008EF1 RID: 36593
		private GameObject mAdventurerPassCardRedPoint;

		// Token: 0x04008EF2 RID: 36594
		private Button QuestionnaireBtn;

		// Token: 0x04008EF3 RID: 36595
		private Button mAutoFightTestBtn;

		// Token: 0x04008EF4 RID: 36596
		private Button mTreasureConversion;

		// Token: 0x04008EF5 RID: 36597
		private ActiveBubbleControl mActiveBubbleControl;

		// Token: 0x04008EF6 RID: 36598
		[UIObject("minimap/scrollRect/viewport/content")]
		private GameObject m_mapViewContent;

		// Token: 0x04008EF7 RID: 36599
		[UIControl("minimap/scrollRect", null, 0)]
		private ScrollRect m_mapScrollRect;

		// Token: 0x04008EF8 RID: 36600
		[UIControl("minimap/title/Text", null, 0)]
		private Text m_labMapTitle;

		// Token: 0x04008EF9 RID: 36601
		private TownMapFrame m_mapFrame;

		// Token: 0x04008EFA RID: 36602
		[UIObject("topright/activityJar")]
		private GameObject m_objActivityJar;

		// Token: 0x04008EFB RID: 36603
		private Coroutine waitToPlayAdventureTeamFuncUnlock;

		// Token: 0x04008EFC RID: 36604
		private bool isPlayAdventureTeamSuccess;

		// Token: 0x04008EFD RID: 36605
		private Coroutine waitToPlayAdventurePassSeasonFuncUnlock;

		// Token: 0x04008EFE RID: 36606
		private bool isPlayAdventurePassSeasonSuccess;
	}
}
