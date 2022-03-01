using System;
using System.Collections.Generic;
using ActivityLimitTime;
using FashionLimitTimeBuy;
using MobileBind;
using _Settings;

namespace GameClient
{
	// Token: 0x020012CA RID: 4810
	public class PlayerDataManager : Singleton<PlayerDataManager>, IDataManager
	{
		// Token: 0x0600BA66 RID: 47718 RVA: 0x002B0994 File Offset: 0x002AED94
		public override void Init()
		{
			base.Init();
			this._AddDataManager(DataManager<PlayerBaseData>.GetInstance());
			this._AddDataManager(DataManager<BattleDataManager>.GetInstance());
			this._AddDataManager(DataManager<AchievementGroupDataManager>.GetInstance());
			this._AddDataManager(DataManager<ActivityNoticeDataManager>.GetInstance());
			this._AddDataManager(DataManager<AnnouncementManager>.GetInstance());
			this._AddDataManager(DataManager<AuctionDataManager>.GetInstance());
			this._AddDataManager(DataManager<CostItemManager>.GetInstance());
			this._AddDataManager(DataManager<CountDataManager>.GetInstance());
			this._AddDataManager(DataManager<EquipSuitDataManager>.GetInstance());
			this._AddDataManager(DataManager<EquipMasterDataManager>.GetInstance());
			this._AddDataManager(DataManager<EquipForgeDataManager>.GetInstance());
			this._AddDataManager(DataManager<EquipRecoveryDataManager>.GetInstance());
			this._AddDataManager(DataManager<GuildDataManager>.GetInstance());
			this._AddDataManager(DataManager<ItemDataManager>.GetInstance());
			this._AddDataManager(DataManager<ItemSourceInfoTableManager>.GetInstance());
			this._AddDataManager(DataManager<ItemTipManager>.GetInstance());
			this._AddDataManager(DataManager<MagicBoxDataManager>.GetInstance());
			this._AddDataManager(DataManager<JarDataManager>.GetInstance());
			this._AddDataManager(DataManager<MallDataManager>.GetInstance());
			this._AddDataManager(DataManager<MoneyRewardsDataManager>.GetInstance());
			this._AddDataManager(DataManager<NewMessageNoticeManager>.GetInstance());
			this._AddDataManager(DataManager<SeasonDataManager>.GetInstance());
			this._AddDataManager(DataManager<PetDataManager>.GetInstance());
			this._AddDataManager(DataManager<Pk3v3DataManager>.GetInstance());
			this._AddDataManager(DataManager<RedPackDataManager>.GetInstance());
			this._AddDataManager(DataManager<RedPointDataManager>.GetInstance());
			this._AddDataManager(DataManager<SkillDataManager>.GetInstance());
			this._AddDataManager(DataManager<SwitchWeaponDataManager>.GetInstance());
			this._AddDataManager(DataManager<TAPDataManager>.GetInstance());
			this._AddDataManager(DataManager<TeamDataManager>.GetInstance());
			this._AddDataManager(DataManager<WaitNetMessageManager>.GetInstance());
			this._AddDataManager(DataManager<ActivityDungeonDataManager>.GetInstance());
			this._AddDataManager(DataManager<OPPOPrivilegeDataManager>.GetInstance());
			this._AddDataManager(DataManager<ChapterBuffDrugManager>.GetInstance());
			this._AddDataManager(DataManager<EquipHandbookDataManager>.GetInstance());
			this._AddDataManager(DataManager<FashionLimitTimeBuyManager>.GetInstance());
			this._AddDataManager(DataManager<ActivityLimitTimeCombineManager>.GetInstance());
			this._AddDataManager(DataManager<MobileBindManager>.GetInstance());
			this._AddDataManager(DataManager<OnlineServiceManager>.GetInstance());
			this._AddDataManager(DataManager<ActivityTreasureLotteryDataManager>.GetInstance());
			this._AddDataManager(DataManager<RelationDataManager>.GetInstance());
			this._AddDataManager(DataManager<RoleInfoSettingManager>.GetInstance());
			this._AddDataManager(DataManager<ShopDataManager>.GetInstance());
			this._AddDataManager(DataManager<StrengthenDataManager>.GetInstance());
			this._AddDataManager(DataManager<ActiveManager>.GetInstance());
			this._AddDataManager(DataManager<BeadCardManager>.GetInstance());
			this._AddDataManager(DataManager<BudoManager>.GetInstance());
			this._AddDataManager(DataManager<ChatManager>.GetInstance());
			this._AddDataManager(DataManager<ChatRecordManager>.GetInstance());
			this._AddDataManager(DataManager<DevelopGuidanceManager>.GetInstance());
			this._AddDataManager(DataManager<EnchantmentsCardManager>.GetInstance());
			this._AddDataManager(DataManager<FashionAttributeSelectManager>.GetInstance());
			this._AddDataManager(DataManager<FashionMergeManager>.GetInstance());
			this._AddDataManager(DataManager<LinkManager>.GetInstance());
			this._AddDataManager(DataManager<MissionManager>.GetInstance());
			this._AddDataManager(DataManager<NpcRelationMissionManager>.GetInstance());
			this._AddDataManager(DataManager<OtherPlayerInfoManager>.GetInstance());
			this._AddDataManager(DataManager<SystemConfigManager>.GetInstance());
			this._AddDataManager(DataManager<TimeManager>.GetInstance());
			this._AddDataManager(DataManager<TittleBookManager>.GetInstance());
			this._AddDataManager(DataManager<FinancialPlanDataManager>.GetInstance());
			this._AddDataManager(DataManager<PackageDataManager>.GetInstance());
			this._AddDataManager(DataManager<GiftPackDataManager>.GetInstance());
			this._AddDataManager(DataManager<ServerSceneFuncSwitchManager>.GetInstance());
			this._AddDataManager(DataManager<ActivityDataManager>.GetInstance());
			this._AddDataManager(DataManager<ActivityManager>.GetInstance());
			this._AddDataManager(DataManager<AttackCityMonsterDataManager>.GetInstance());
			this._AddDataManager(DataManager<Pk3v3CrossDataManager>.GetInstance());
			this._AddDataManager(DataManager<DailyChargeRaffleDataManager>.GetInstance());
			this._AddDataManager(DataManager<TAPNewDataManager>.GetInstance());
			this._AddDataManager(DataManager<RandomTreasureDataManager>.GetInstance());
			this._AddDataManager(DataManager<MallNewDataManager>.GetInstance());
			this._AddDataManager(DataManager<ShopNewDataManager>.GetInstance());
			this._AddDataManager(DataManager<HorseGamblingDataManager>.GetInstance());
			this._AddDataManager(DataManager<SecurityLockDataManager>.GetInstance());
			this._AddDataManager(DataManager<StrengthenTicketMergeDataManager>.GetInstance());
			this._AddDataManager(DataManager<AdventureTeamDataManager>.GetInstance());
			this._AddDataManager(DataManager<AuctionNewDataManager>.GetInstance());
			this._AddDataManager(DataManager<AccountShopDataManager>.GetInstance());
			this._AddDataManager(DataManager<ArtifactDataManager>.GetInstance());
			this._AddDataManager(DataManager<BlackMarketMerchantDataManager>.GetInstance());
			this._AddDataManager(DataManager<EquipUpgradeDataManager>.GetInstance());
			this._AddDataManager(DataManager<TopUpPushDataManager>.GetInstance());
			this._AddDataManager(DataManager<ChijiDataManager>.GetInstance());
			this._AddDataManager(DataManager<MailDataManager>.GetInstance());
			this._AddDataManager(DataManager<FollowingOpenQueueManager>.GetInstance());
			this._AddDataManager(DataManager<WeekSignInDataManager>.GetInstance());
			this._AddDataManager(DataManager<HeadPortraitFrameDataManager>.GetInstance());
			this._AddDataManager(DataManager<TitleDataManager>.GetInstance());
			this._AddDataManager(DataManager<MagicCardMergeDataManager>.GetInstance());
			this._AddDataManager(DataManager<MonthCardRewardLockersDataManager>.GetInstance());
			this._AddDataManager(DataManager<TeamDuplicationDataManager>.GetInstance());
			this._AddDataManager(DataManager<FairDuelDataManager>.GetInstance());
			this._AddDataManager(DataManager<EquipGrowthDataManager>.GetInstance());
			this._AddDataManager(DataManager<DailyTodoDataManager>.GetInstance());
			this._AddDataManager(DataManager<BaseWebViewManager>.GetInstance());
			this._AddDataManager(DataManager<BattleEasyChatDataManager>.GetInstance());
			this._AddDataManager(DataManager<DeadLineReminderDataManager>.GetInstance());
			this._AddDataManager(DataManager<InscriptionMosaicDataManager>.GetInstance());
			this._AddDataManager(DataManager<AdventurerPassCardDataManager>.GetInstance());
			this._AddDataManager(DataManager<Pk2v2CrossDataManager>.GetInstance());
			this._AddDataManager(DataManager<EquipPlanDataManager>.GetInstance());
			this._AddDataManager(DataManager<HonorSystemDataManager>.GetInstance());
			this._AddDataManager(DataManager<EpicEquipmentTransformationDataManager>.GetInstance());
			this._AddDataManager(DataManager<ChijiShopDataManager>.GetInstance());
			this._AddDataManager(DataManager<WarriorRecruitDataManager>.GetInstance());
			this._AddDataManager(DataManager<StorageDataManager>.GetInstance());
			this._AddDataManager(DataManager<SceneSettingDataManager>.GetInstance());
			this._AddDataManager(DataManager<ChampionshipDataManager>.GetInstance());
			this._AddDataManager(DataManager<CoinDealDataManager>.GetInstance());
			this._AddDataManager(DataManager<ZillionaireGameDataManager>.GetInstance());
		}

		// Token: 0x0600BA67 RID: 47719 RVA: 0x002B0E6C File Offset: 0x002AF26C
		public EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600BA68 RID: 47720 RVA: 0x002B0E70 File Offset: 0x002AF270
		public void BindEnterGameMsg(List<uint> a_msgEvent)
		{
			for (int i = 0; i < this.m_arrDataManagers.Count; i++)
			{
				this.m_arrDataManagers[i].BindEnterGameMsg(a_msgEvent);
			}
		}

		// Token: 0x0600BA69 RID: 47721 RVA: 0x002B0EAC File Offset: 0x002AF2AC
		public void InitiallizeSystem()
		{
			for (int i = 0; i < this.m_arrDataManagers.Count; i++)
			{
				this.m_arrDataManagers[i].InitiallizeSystem();
			}
		}

		// Token: 0x0600BA6A RID: 47722 RVA: 0x002B0EE8 File Offset: 0x002AF2E8
		public void ProcessInitNetMessage(WaitNetMessageManager.NetMessages a_msgEvent)
		{
			for (int i = 0; i < this.m_arrDataManagers.Count; i++)
			{
				this.m_arrDataManagers[i].ProcessInitNetMessage(a_msgEvent);
			}
		}

		// Token: 0x0600BA6B RID: 47723 RVA: 0x002B0F24 File Offset: 0x002AF324
		public void ClearAll()
		{
			for (int i = 0; i < this.m_arrDataManagers.Count; i++)
			{
				this.m_arrDataManagers[i].ClearAll();
			}
			LoginToggleMsgBoxOKCancelFrame.Reset();
		}

		// Token: 0x0600BA6C RID: 47724 RVA: 0x002B0F64 File Offset: 0x002AF364
		public void Update(float a_fTime)
		{
			for (int i = 0; i < this.m_arrDataManagers.Count; i++)
			{
				this.m_arrDataManagers[i].Update(a_fTime);
			}
		}

		// Token: 0x0600BA6D RID: 47725 RVA: 0x002B0FA0 File Offset: 0x002AF3A0
		public void OnEnterSystem()
		{
			for (int i = 0; i < this.m_arrDataManagers.Count; i++)
			{
				this.m_arrDataManagers[i].OnEnterSystem();
			}
		}

		// Token: 0x0600BA6E RID: 47726 RVA: 0x002B0FDC File Offset: 0x002AF3DC
		public void OnExitSystem()
		{
			for (int i = 0; i < this.m_arrDataManagers.Count; i++)
			{
				this.m_arrDataManagers[i].OnExitSystem();
			}
		}

		// Token: 0x0600BA6F RID: 47727 RVA: 0x002B1018 File Offset: 0x002AF418
		public void OnApplicationStart()
		{
			for (int i = 0; i < this.m_arrDataManagers.Count; i++)
			{
				this.m_arrDataManagers[i].OnApplicationStart();
			}
		}

		// Token: 0x0600BA70 RID: 47728 RVA: 0x002B1054 File Offset: 0x002AF454
		public void OnApplicationQuit()
		{
			for (int i = 0; i < this.m_arrDataManagers.Count; i++)
			{
				this.m_arrDataManagers[i].OnApplicationQuit();
			}
		}

		// Token: 0x0600BA71 RID: 47729 RVA: 0x002B1090 File Offset: 0x002AF490
		private void _AddDataManager(IDataManager a_dataManager)
		{
			if (a_dataManager == null)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < this.m_arrDataManagers.Count; i++)
			{
				if (this.m_arrDataManagers[i] == a_dataManager)
				{
					return;
				}
				if (a_dataManager.GetOrder() < this.m_arrDataManagers[i].GetOrder())
				{
					this.m_arrDataManagers.Insert(i, a_dataManager);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this.m_arrDataManagers.Add(a_dataManager);
			}
		}

		// Token: 0x040068B6 RID: 26806
		private List<IDataManager> m_arrDataManagers = new List<IDataManager>();
	}
}
