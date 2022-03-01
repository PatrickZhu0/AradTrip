using System;

namespace GameClient
{
	// Token: 0x02000FCA RID: 4042
	[Serializable]
	public enum EUIEventID
	{
		// Token: 0x04005082 RID: 20610
		Invalid = -1,
		// Token: 0x04005083 RID: 20611
		DungeonOnFight,
		// Token: 0x04005084 RID: 20612
		DungeonRewardFinish,
		// Token: 0x04005085 RID: 20613
		DungeonAreaChanged,
		// Token: 0x04005086 RID: 20614
		OnConfirmToFashionMerge = 101,
		// Token: 0x04005087 RID: 20615
		JobIDChanged,
		// Token: 0x04005088 RID: 20616
		JobIDReset,
		// Token: 0x04005089 RID: 20617
		GoldChanged,
		// Token: 0x0400508A RID: 20618
		BindGoldChanged,
		// Token: 0x0400508B RID: 20619
		TicketChanged,
		// Token: 0x0400508C RID: 20620
		TicketExChanged,
		// Token: 0x0400508D RID: 20621
		BindTicketChanged,
		// Token: 0x0400508E RID: 20622
		CreditTicketOwnerBySelfChanged,
		// Token: 0x0400508F RID: 20623
		CreditTicketGetInMonthChanged,
		// Token: 0x04005090 RID: 20624
		GoldJarScoreChanged,
		// Token: 0x04005091 RID: 20625
		MagicJarScoreChanged,
		// Token: 0x04005092 RID: 20626
		AliveCoinChanged,
		// Token: 0x04005093 RID: 20627
		FatigueChanged,
		// Token: 0x04005094 RID: 20628
		LevelChanged,
		// Token: 0x04005095 RID: 20629
		SpChanged,
		// Token: 0x04005096 RID: 20630
		NameChanged,
		// Token: 0x04005097 RID: 20631
		ExpChanged,
		// Token: 0x04005098 RID: 20632
		WarriorSoulChanged,
		// Token: 0x04005099 RID: 20633
		FollowPetChanged,
		// Token: 0x0400509A RID: 20634
		TraditionPkWaitingRoom,
		// Token: 0x0400509B RID: 20635
		AwakeChanged,
		// Token: 0x0400509C RID: 20636
		MoveSpeedChanged,
		// Token: 0x0400509D RID: 20637
		RedPointChanged,
		// Token: 0x0400509E RID: 20638
		PlayerDataBaseUpdated,
		// Token: 0x0400509F RID: 20639
		PlayerDataGuildUpdated,
		// Token: 0x040050A0 RID: 20640
		MonthCardChanged,
		// Token: 0x040050A1 RID: 20641
		PlayerVipLvChanged,
		// Token: 0x040050A2 RID: 20642
		CounterChanged,
		// Token: 0x040050A3 RID: 20643
		NewMailNotify,
		// Token: 0x040050A4 RID: 20644
		PlayerDataSeasonUpdated,
		// Token: 0x040050A5 RID: 20645
		TipsAniStart,
		// Token: 0x040050A6 RID: 20646
		TipsAniEnd,
		// Token: 0x040050A7 RID: 20647
		PetChanged,
		// Token: 0x040050A8 RID: 20648
		ChangeJobSelectDialog,
		// Token: 0x040050A9 RID: 20649
		AvatarChanged,
		// Token: 0x040050AA RID: 20650
		OnIsShowFashionWeapon,
		// Token: 0x040050AB RID: 20651
		PetInfoInited,
		// Token: 0x040050AC RID: 20652
		InitNewbieGuideBootData,
		// Token: 0x040050AD RID: 20653
		EndNewbieGuideCover,
		// Token: 0x040050AE RID: 20654
		CheckAllNewbieGuide,
		// Token: 0x040050AF RID: 20655
		CurGuideStart,
		// Token: 0x040050B0 RID: 20656
		CurGuideFinish,
		// Token: 0x040050B1 RID: 20657
		HpChanged,
		// Token: 0x040050B2 RID: 20658
		AddNewMission,
		// Token: 0x040050B3 RID: 20659
		FinishTalkDialog,
		// Token: 0x040050B4 RID: 20660
		TraceBegin,
		// Token: 0x040050B5 RID: 20661
		TraceEnd,
		// Token: 0x040050B6 RID: 20662
		FinancialPlanBuyRes,
		// Token: 0x040050B7 RID: 20663
		FinancialPlanReceivedRes,
		// Token: 0x040050B8 RID: 20664
		FinancialPlanLevelSync,
		// Token: 0x040050B9 RID: 20665
		FinancialPlanRedPointTips,
		// Token: 0x040050BA RID: 20666
		FinancialPlanButtonUpdateByLogin,
		// Token: 0x040050BB RID: 20667
		FinancialPlanButtonUpdateByLevel,
		// Token: 0x040050BC RID: 20668
		FinancialPlanButtonUpdateBySceneChanged,
		// Token: 0x040050BD RID: 20669
		SyncAttackCityMonsterAdd,
		// Token: 0x040050BE RID: 20670
		SyncAttackCityMonsterDel,
		// Token: 0x040050BF RID: 20671
		SyncAttackCityMonsterList,
		// Token: 0x040050C0 RID: 20672
		SyncAttackCityMonsterUpdate,
		// Token: 0x040050C1 RID: 20673
		SkillListChanged,
		// Token: 0x040050C2 RID: 20674
		SkillBarChanged,
		// Token: 0x040050C3 RID: 20675
		SkillSolutionChanged,
		// Token: 0x040050C4 RID: 20676
		UpdateCurUseSkillBar,
		// Token: 0x040050C5 RID: 20677
		SkillLvUpNoticeUpdate,
		// Token: 0x040050C6 RID: 20678
		BuffListChanged,
		// Token: 0x040050C7 RID: 20679
		BuffRemoved,
		// Token: 0x040050C8 RID: 20680
		BuffAdded,
		// Token: 0x040050C9 RID: 20681
		BattleBuffCancel,
		// Token: 0x040050CA RID: 20682
		BattleBuffRemoved,
		// Token: 0x040050CB RID: 20683
		BattleBuffAdded,
		// Token: 0x040050CC RID: 20684
		BattleDataUpdate,
		// Token: 0x040050CD RID: 20685
		ItemUseSuccess,
		// Token: 0x040050CE RID: 20686
		ItemSellSuccess,
		// Token: 0x040050CF RID: 20687
		ItemStoreSuccess,
		// Token: 0x040050D0 RID: 20688
		ItemTakeSuccess,
		// Token: 0x040050D1 RID: 20689
		ItemStrengthenSuccess,
		// Token: 0x040050D2 RID: 20690
		ItemStrengthenFail,
		// Token: 0x040050D3 RID: 20691
		ItemSingleUpdate,
		// Token: 0x040050D4 RID: 20692
		ItemQualityChanged,
		// Token: 0x040050D5 RID: 20693
		ItemNewStateChanged,
		// Token: 0x040050D6 RID: 20694
		ItemNotifyGet,
		// Token: 0x040050D7 RID: 20695
		ItemNotifyRemoved,
		// Token: 0x040050D8 RID: 20696
		ItemCountChanged,
		// Token: 0x040050D9 RID: 20697
		ItemsAttrChanged,
		// Token: 0x040050DA RID: 20698
		TimeLessItemsChanged,
		// Token: 0x040050DB RID: 20699
		ItemRenewalSuccess,
		// Token: 0x040050DC RID: 20700
		SwitchEquipSuccess,
		// Token: 0x040050DD RID: 20701
		ContinueProcessStart,
		// Token: 0x040050DE RID: 20702
		ContinueProcessFinish,
		// Token: 0x040050DF RID: 20703
		ContinueProcessReset,
		// Token: 0x040050E0 RID: 20704
		ItemPropertyChanged,
		// Token: 0x040050E1 RID: 20705
		PackageTypeChanged,
		// Token: 0x040050E2 RID: 20706
		PackageFull,
		// Token: 0x040050E3 RID: 20707
		PackageNotFull,
		// Token: 0x040050E4 RID: 20708
		OnlyUpdateItemList,
		// Token: 0x040050E5 RID: 20709
		PackageSwitch2OneGroup,
		// Token: 0x040050E6 RID: 20710
		StorageLevelUp,
		// Token: 0x040050E7 RID: 20711
		ShopBuyGoodsSuccess,
		// Token: 0x040050E8 RID: 20712
		ShopRefreshSuccess,
		// Token: 0x040050E9 RID: 20713
		ShopMainFrameClose,
		// Token: 0x040050EA RID: 20714
		ShopGuildFrameClose,
		// Token: 0x040050EB RID: 20715
		ShopMallFrameClose,
		// Token: 0x040050EC RID: 20716
		ShopRefreshTimesChanged,
		// Token: 0x040050ED RID: 20717
		GoodsRecommend,
		// Token: 0x040050EE RID: 20718
		ChangeNum,
		// Token: 0x040050EF RID: 20719
		ChangeNum2,
		// Token: 0x040050F0 RID: 20720
		VirtualInputNumberChange,
		// Token: 0x040050F1 RID: 20721
		VirtualInputEnsure,
		// Token: 0x040050F2 RID: 20722
		updateFashionTab,
		// Token: 0x040050F3 RID: 20723
		AccountShopUpdate,
		// Token: 0x040050F4 RID: 20724
		AccountShopItemUpdata,
		// Token: 0x040050F5 RID: 20725
		SpeicialItemUpdate,
		// Token: 0x040050F6 RID: 20726
		AccountSpecialItemUpdate,
		// Token: 0x040050F7 RID: 20727
		AccountShopReqFailed,
		// Token: 0x040050F8 RID: 20728
		AuctionSearchLimitChanged,
		// Token: 0x040050F9 RID: 20729
		AuctionFreezeRemind,
		// Token: 0x040050FA RID: 20730
		ActorShowTabChanged,
		// Token: 0x040050FB RID: 20731
		ShopNewBuyGoodsSuccess,
		// Token: 0x040050FC RID: 20732
		ShopNewRequestChildrenShopDataSucceed,
		// Token: 0x040050FD RID: 20733
		ClientBattleMainFadeInFadeOut,
		// Token: 0x040050FE RID: 20734
		DisplayMissionTips,
		// Token: 0x040050FF RID: 20735
		ActivityUpdate,
		// Token: 0x04005100 RID: 20736
		ActivityAdd,
		// Token: 0x04005101 RID: 20737
		ActivityDelete,
		// Token: 0x04005102 RID: 20738
		ActivityNoticeUpdate,
		// Token: 0x04005103 RID: 20739
		ActivitySpecialRedPointNotify,
		// Token: 0x04005104 RID: 20740
		ActivityInfoReqResult,
		// Token: 0x04005105 RID: 20741
		ActivityUpdateByActivityName,
		// Token: 0x04005106 RID: 20742
		ActivityTabsInfoUpdate,
		// Token: 0x04005107 RID: 20743
		ActivityLimitTimeTaskUpdate,
		// Token: 0x04005108 RID: 20744
		ActivityLimitTimeUpdate,
		// Token: 0x04005109 RID: 20745
		ActivityLimitTimeToggleChange,
		// Token: 0x0400510A RID: 20746
		ActivityLimitTimeTaskDataUpdate,
		// Token: 0x0400510B RID: 20747
		ActivityLimitTimeDataUpdate,
		// Token: 0x0400510C RID: 20748
		ActivtiyLimitTimeAccounterNumUpdate,
		// Token: 0x0400510D RID: 20749
		ActivityLimitTimeMallDataChanged,
		// Token: 0x0400510E RID: 20750
		HorseGamblingStateUpdate,
		// Token: 0x0400510F RID: 20751
		HorseGamblingGameStateUpdate,
		// Token: 0x04005110 RID: 20752
		HorseGamblingUpdate,
		// Token: 0x04005111 RID: 20753
		HorseGamblingGameHistoryUpdate,
		// Token: 0x04005112 RID: 20754
		HorseGamblingRankListUpdate,
		// Token: 0x04005113 RID: 20755
		HorseGamblingOddsUpdate,
		// Token: 0x04005114 RID: 20756
		HorseGamblingShooterHistoryUpdate,
		// Token: 0x04005115 RID: 20757
		HorseGamblingShooterStakeUpdate,
		// Token: 0x04005116 RID: 20758
		HorseGamblingShooterStakeResp,
		// Token: 0x04005117 RID: 20759
		HorseGamblingBuyBulletResponse,
		// Token: 0x04005118 RID: 20760
		ActivityDungeonUpdate,
		// Token: 0x04005119 RID: 20761
		ActivityDungeonStateUpdate,
		// Token: 0x0400511A RID: 20762
		WelfActivityRedPoint,
		// Token: 0x0400511B RID: 20763
		BossExchangeUpdate,
		// Token: 0x0400511C RID: 20764
		BossKillActivityExist,
		// Token: 0x0400511D RID: 20765
		UpdateBossActivityState,
		// Token: 0x0400511E RID: 20766
		UpdateBossActivityData,
		// Token: 0x0400511F RID: 20767
		ActivityDungeonDeadTowerWipeEnd,
		// Token: 0x04005120 RID: 20768
		TreasureLotteryBuyResp,
		// Token: 0x04005121 RID: 20769
		TreasureLotterySyncActivity,
		// Token: 0x04005122 RID: 20770
		TreasureLotterySyncMyLottery,
		// Token: 0x04005123 RID: 20771
		TreasureLotterySyncHistory,
		// Token: 0x04005124 RID: 20772
		TreasureLotterySyncDraw,
		// Token: 0x04005125 RID: 20773
		TreasureLotteryStatusChange,
		// Token: 0x04005126 RID: 20774
		TreasureLotteryShowHistory,
		// Token: 0x04005127 RID: 20775
		TreasureLotteryShowActivity,
		// Token: 0x04005128 RID: 20776
		NewFuncUnlock,
		// Token: 0x04005129 RID: 20777
		NextFuncOpen,
		// Token: 0x0400512A RID: 20778
		NewAreaUnlock,
		// Token: 0x0400512B RID: 20779
		UpdateUnlockFunc,
		// Token: 0x0400512C RID: 20780
		NewFuncFrameOpen,
		// Token: 0x0400512D RID: 20781
		NewFuncFrameClose,
		// Token: 0x0400512E RID: 20782
		NpcRelationMissionChanged,
		// Token: 0x0400512F RID: 20783
		NewAccountFuncUnlock,
		// Token: 0x04005130 RID: 20784
		MenuIdChanged,
		// Token: 0x04005131 RID: 20785
		TaskNpcIdChanged,
		// Token: 0x04005132 RID: 20786
		OnAddNewTask,
		// Token: 0x04005133 RID: 20787
		OnCompleteTask,
		// Token: 0x04005134 RID: 20788
		OnGiveUpTask,
		// Token: 0x04005135 RID: 20789
		MissionIDChanged,
		// Token: 0x04005136 RID: 20790
		TaskTraceDirection,
		// Token: 0x04005137 RID: 20791
		HideGuideArrow,
		// Token: 0x04005138 RID: 20792
		ShowGuideArrow,
		// Token: 0x04005139 RID: 20793
		MissionAccepted,
		// Token: 0x0400513A RID: 20794
		MissionUpdated,
		// Token: 0x0400513B RID: 20795
		MissionSync,
		// Token: 0x0400513C RID: 20796
		Dlg2TaskId,
		// Token: 0x0400513D RID: 20797
		DlgCallBack,
		// Token: 0x0400513E RID: 20798
		InitializeTownSystem,
		// Token: 0x0400513F RID: 20799
		SceneChangedFinish,
		// Token: 0x04005140 RID: 20800
		BattleInitFinished,
		// Token: 0x04005141 RID: 20801
		SceneJumpFinished,
		// Token: 0x04005142 RID: 20802
		SystemLoadingCompelete,
		// Token: 0x04005143 RID: 20803
		SwitchToMainScene,
		// Token: 0x04005144 RID: 20804
		TownSceneInited,
		// Token: 0x04005145 RID: 20805
		SceneChangedLoadingFinish,
		// Token: 0x04005146 RID: 20806
		SystemChanged,
		// Token: 0x04005147 RID: 20807
		FrameOpen,
		// Token: 0x04005148 RID: 20808
		FadeInOver,
		// Token: 0x04005149 RID: 20809
		SwitchToMission,
		// Token: 0x0400514A RID: 20810
		GuankaFrameOpen,
		// Token: 0x0400514B RID: 20811
		DungeonRewardFrameOpen,
		// Token: 0x0400514C RID: 20812
		TaskDialogFrameOpen,
		// Token: 0x0400514D RID: 20813
		ChangeJobSelectFrameOpen,
		// Token: 0x0400514E RID: 20814
		ChangeJobFinishFrameOpen,
		// Token: 0x0400514F RID: 20815
		VipFrameOpen,
		// Token: 0x04005150 RID: 20816
		VipPrivilegeFrameOpen,
		// Token: 0x04005151 RID: 20817
		FirstPayFrameOpen,
		// Token: 0x04005152 RID: 20818
		SecondPayFrameOpen,
		// Token: 0x04005153 RID: 20819
		BlueCircleChange,
		// Token: 0x04005154 RID: 20820
		NotifyOpenWelfareFrame,
		// Token: 0x04005155 RID: 20821
		FrameClose,
		// Token: 0x04005156 RID: 20822
		MiddleFrameClose,
		// Token: 0x04005157 RID: 20823
		FadeOutOver,
		// Token: 0x04005158 RID: 20824
		MailFrameClose,
		// Token: 0x04005159 RID: 20825
		DungeonRewardFrameClose,
		// Token: 0x0400515A RID: 20826
		MissionRewardFrameClose,
		// Token: 0x0400515B RID: 20827
		UplevelFrameClose,
		// Token: 0x0400515C RID: 20828
		OutPkWaitingScene,
		// Token: 0x0400515D RID: 20829
		WelfareFrameClose,
		// Token: 0x0400515E RID: 20830
		SkillPlanClose,
		// Token: 0x0400515F RID: 20831
		GuildMainFrameClose,
		// Token: 0x04005160 RID: 20832
		VipFrameClose,
		// Token: 0x04005161 RID: 20833
		VipPrivilegeFrameClose,
		// Token: 0x04005162 RID: 20834
		FirstPayFrameClose,
		// Token: 0x04005163 RID: 20835
		SecondPayFrameClose,
		// Token: 0x04005164 RID: 20836
		PkMatchScoreChanged,
		// Token: 0x04005165 RID: 20837
		PkCoinChanged,
		// Token: 0x04005166 RID: 20838
		PkCurWinSteak,
		// Token: 0x04005167 RID: 20839
		PkMatchStartSuccess,
		// Token: 0x04005168 RID: 20840
		PkMatchCancelSuccess,
		// Token: 0x04005169 RID: 20841
		PkMatchFailed,
		// Token: 0x0400516A RID: 20842
		PkMatchCancelFailed,
		// Token: 0x0400516B RID: 20843
		PkEndData,
		// Token: 0x0400516C RID: 20844
		pkGuideStart,
		// Token: 0x0400516D RID: 20845
		pkGuideEnd,
		// Token: 0x0400516E RID: 20846
		PKMatched,
		// Token: 0x0400516F RID: 20847
		OnUpdatePk3v3CrossRankScoreList,
		// Token: 0x04005170 RID: 20848
		Pk3v3CrossUpdateMyTeamFrame,
		// Token: 0x04005171 RID: 20849
		Pk3v3CrossPkAwardInfoUpdate,
		// Token: 0x04005172 RID: 20850
		PK3V3CrossButton,
		// Token: 0x04005173 RID: 20851
		SecurityLockApplyStateButton,
		// Token: 0x04005174 RID: 20852
		PK2V2CrossButton,
		// Token: 0x04005175 RID: 20853
		PK2V2CrossStatusUpdate,
		// Token: 0x04005176 RID: 20854
		OnUpdatePk2v2CrossRankScoreList,
		// Token: 0x04005177 RID: 20855
		Pk2v2CrossPkAwardInfoUpdate,
		// Token: 0x04005178 RID: 20856
		Pk2v2CrossBeginMatch,
		// Token: 0x04005179 RID: 20857
		Pk2v2CrossCancelMatch,
		// Token: 0x0400517A RID: 20858
		Pk2v2CrossBeginMatchRes,
		// Token: 0x0400517B RID: 20859
		Pk2v2CrossCancelMatchRes,
		// Token: 0x0400517C RID: 20860
		SceneLoadFinish,
		// Token: 0x0400517D RID: 20861
		DungeonUnlockDiff,
		// Token: 0x0400517E RID: 20862
		DungeonPlayerUseSkill,
		// Token: 0x0400517F RID: 20863
		ChapterNextDungeon,
		// Token: 0x04005180 RID: 20864
		SelectEnterDungeon,
		// Token: 0x04005181 RID: 20865
		DungeonPlayerLoadProgressChanged,
		// Token: 0x04005182 RID: 20866
		DungeonScoreChanged,
		// Token: 0x04005183 RID: 20867
		DungeonPotionSetChanged,
		// Token: 0x04005184 RID: 20868
		DungeonQuickBuyPotionSuccess,
		// Token: 0x04005185 RID: 20869
		DungeonQuickBuyPotionFail,
		// Token: 0x04005186 RID: 20870
		ServerListSelectChanged,
		// Token: 0x04005187 RID: 20871
		ServerQueueCancel,
		// Token: 0x04005188 RID: 20872
		ServerLoginFail,
		// Token: 0x04005189 RID: 20873
		ServerLoginFailWithServerConnect,
		// Token: 0x0400518A RID: 20874
		ServerLoginStart,
		// Token: 0x0400518B RID: 20875
		ServerLoginQueueWait,
		// Token: 0x0400518C RID: 20876
		ServerLoginSuccess,
		// Token: 0x0400518D RID: 20877
		DisConnect,
		// Token: 0x0400518E RID: 20878
		ChapterNormalHalfFrameOpen,
		// Token: 0x0400518F RID: 20879
		ChapterNormalHalfFrameClose,
		// Token: 0x04005190 RID: 20880
		SetDefaultSelectedID,
		// Token: 0x04005191 RID: 20881
		RoleInfoUpdate,
		// Token: 0x04005192 RID: 20882
		RefreshRolePreferenceCount,
		// Token: 0x04005193 RID: 20883
		FunctionFrameUpdate,
		// Token: 0x04005194 RID: 20884
		PurchaseCommanUpdate,
		// Token: 0x04005195 RID: 20885
		TeamCreateSuccess,
		// Token: 0x04005196 RID: 20886
		TeamAddMemberSuccess,
		// Token: 0x04005197 RID: 20887
		TeamJoinSuccess,
		// Token: 0x04005198 RID: 20888
		TeamRemoveMemberSuccess,
		// Token: 0x04005199 RID: 20889
		TeamChangeLeaderSuccess,
		// Token: 0x0400519A RID: 20890
		TeamPosStateChanged,
		// Token: 0x0400519B RID: 20891
		TeamMemberStateChanged,
		// Token: 0x0400519C RID: 20892
		TeamListRequestSuccess,
		// Token: 0x0400519D RID: 20893
		TeamListRequestSuccessForTeamMainUI,
		// Token: 0x0400519E RID: 20894
		TeamChapterIDSelect,
		// Token: 0x0400519F RID: 20895
		TeamDungeonIDSelect,
		// Token: 0x040051A0 RID: 20896
		TeamPasswardChanged,
		// Token: 0x040051A1 RID: 20897
		TeamInfoUpdateSuccess,
		// Token: 0x040051A2 RID: 20898
		TeamNotifyChat,
		// Token: 0x040051A3 RID: 20899
		TeamNotifyChatMsg,
		// Token: 0x040051A4 RID: 20900
		TeamMatchStartSuccess,
		// Token: 0x040051A5 RID: 20901
		TeamMatchCancelSuccess,
		// Token: 0x040051A6 RID: 20902
		TeamNewInviteNoticeUpdate,
		// Token: 0x040051A7 RID: 20903
		TeamListUpdateByHard,
		// Token: 0x040051A8 RID: 20904
		TeamTimeChanged,
		// Token: 0x040051A9 RID: 20905
		OnDecomposeChanged,
		// Token: 0x040051AA RID: 20906
		OnStrengthChanged,
		// Token: 0x040051AB RID: 20907
		DecomposeFinished,
		// Token: 0x040051AC RID: 20908
		OnSpecailStrenghthenStart,
		// Token: 0x040051AD RID: 20909
		OnSpecailStrenghthenCanceled,
		// Token: 0x040051AE RID: 20910
		OnSpecailStrenghthenFailed,
		// Token: 0x040051AF RID: 20911
		OnStrengthenError,
		// Token: 0x040051B0 RID: 20912
		OnUsePerfectWashRoll,
		// Token: 0x040051B1 RID: 20913
		OnRecievChat,
		// Token: 0x040051B2 RID: 20914
		OnRecievRecommendFriend,
		// Token: 0x040051B3 RID: 20915
		OnRefreshFriendList,
		// Token: 0x040051B4 RID: 20916
		OnRefreshInviteList,
		// Token: 0x040051B5 RID: 20917
		OnShowFriendSecMenu,
		// Token: 0x040051B6 RID: 20918
		OnShowFriendChat,
		// Token: 0x040051B7 RID: 20919
		OnRecvPrivateChat,
		// Token: 0x040051B8 RID: 20920
		OnRecvQueryPlayer,
		// Token: 0x040051B9 RID: 20921
		OnQueryIntervalChanged,
		// Token: 0x040051BA RID: 20922
		OnQueryEnd,
		// Token: 0x040051BB RID: 20923
		OnPrivateChat,
		// Token: 0x040051BC RID: 20924
		OnUpdatePrivate,
		// Token: 0x040051BD RID: 20925
		OnDelPrivate,
		// Token: 0x040051BE RID: 20926
		OnPrivateRdChanged,
		// Token: 0x040051BF RID: 20927
		OnRelationChanged,
		// Token: 0x040051C0 RID: 20928
		FriendRequestNoticeUpdate,
		// Token: 0x040051C1 RID: 20929
		OnPlayerOnLineStatusChanged,
		// Token: 0x040051C2 RID: 20930
		OnUpdatePayText,
		// Token: 0x040051C3 RID: 20931
		OnDonateAllSended,
		// Token: 0x040051C4 RID: 20932
		OnEquiptedNew,
		// Token: 0x040051C5 RID: 20933
		BattlePlayerDead,
		// Token: 0x040051C6 RID: 20934
		BattlePlayerAlive,
		// Token: 0x040051C7 RID: 20935
		BattlePlayerBack,
		// Token: 0x040051C8 RID: 20936
		BattlePlayerLeave,
		// Token: 0x040051C9 RID: 20937
		BattlePlayerInfoChange,
		// Token: 0x040051CA RID: 20938
		BattleFrameSyncEnd,
		// Token: 0x040051CB RID: 20939
		OnCloseMenu,
		// Token: 0x040051CC RID: 20940
		UpdateActorShowMenu,
		// Token: 0x040051CD RID: 20941
		OnMergeSuccess,
		// Token: 0x040051CE RID: 20942
		OnAddMagicSuccess,
		// Token: 0x040051CF RID: 20943
		OnOneKeyMergeSuccess,
		// Token: 0x040051D0 RID: 20944
		OnAddSarahSuccess,
		// Token: 0x040051D1 RID: 20945
		MapMoveToNPC,
		// Token: 0x040051D2 RID: 20946
		MapMoveToScene,
		// Token: 0x040051D3 RID: 20947
		LeftSlip,
		// Token: 0x040051D4 RID: 20948
		RightSlip,
		// Token: 0x040051D5 RID: 20949
		PlayerMoveStateChanged,
		// Token: 0x040051D6 RID: 20950
		EnterDungeon,
		// Token: 0x040051D7 RID: 20951
		OnDeadTowerWipeoutTimeChange,
		// Token: 0x040051D8 RID: 20952
		OnCountValueChange,
		// Token: 0x040051D9 RID: 20953
		SetChatTab,
		// Token: 0x040051DA RID: 20954
		BeginContineStrengthen,
		// Token: 0x040051DB RID: 20955
		EndContineStrengthen,
		// Token: 0x040051DC RID: 20956
		IntterruptContineStrengthen,
		// Token: 0x040051DD RID: 20957
		StrengthenContinue,
		// Token: 0x040051DE RID: 20958
		StrengthenDelay,
		// Token: 0x040051DF RID: 20959
		StrengthenCanceled,
		// Token: 0x040051E0 RID: 20960
		ClosePotionSetFrame,
		// Token: 0x040051E1 RID: 20961
		GuildListUpdated,
		// Token: 0x040051E2 RID: 20962
		GuildRequestJoinSuccess,
		// Token: 0x040051E3 RID: 20963
		GuildRequestJoinAllSuccess,
		// Token: 0x040051E4 RID: 20964
		GuildCreateSuccess,
		// Token: 0x040051E5 RID: 20965
		GuildMembersUpdated,
		// Token: 0x040051E6 RID: 20966
		GuildRequestersUpdated,
		// Token: 0x040051E7 RID: 20967
		GuildNewRequester,
		// Token: 0x040051E8 RID: 20968
		GuildKickMemberSuccess,
		// Token: 0x040051E9 RID: 20969
		GuildLeaveGuildSuccess,
		// Token: 0x040051EA RID: 20970
		GuildProcessRequesterSuccess,
		// Token: 0x040051EB RID: 20971
		GuildChangeDutySuccess,
		// Token: 0x040051EC RID: 20972
		GuildSendMailSuccess,
		// Token: 0x040051ED RID: 20973
		GuildChangeDeclarationSuccess,
		// Token: 0x040051EE RID: 20974
		GuildChangeNoticeSuccess,
		// Token: 0x040051EF RID: 20975
		GuildChangeNameSuccess,
		// Token: 0x040051F0 RID: 20976
		GuildRequestDismissSuccess,
		// Token: 0x040051F1 RID: 20977
		GuildRequestCancelDismissSuccess,
		// Token: 0x040051F2 RID: 20978
		GuildCloseMainFrame,
		// Token: 0x040051F3 RID: 20979
		GuildOpenMemberFrame,
		// Token: 0x040051F4 RID: 20980
		GuildOpenBuildingFrame,
		// Token: 0x040051F5 RID: 20981
		GuildOpenShopFrame,
		// Token: 0x040051F6 RID: 20982
		GuildOpenShopRefreshConsumeItem,
		// Token: 0x040051F7 RID: 20983
		GuildOpenStorageFrame,
		// Token: 0x040051F8 RID: 20984
		GuildOpenManorFrame,
		// Token: 0x040051F9 RID: 20985
		GuildOpenCrossManorFrame,
		// Token: 0x040051FA RID: 20986
		GuildOpenRedPacketFrame,
		// Token: 0x040051FB RID: 20987
		GuildUpgradeBuildingSuccess,
		// Token: 0x040051FC RID: 20988
		GuildRequestDonateLogSuccess,
		// Token: 0x040051FD RID: 20989
		GuildDonateSuccess,
		// Token: 0x040051FE RID: 20990
		GuildExchangeSuccess,
		// Token: 0x040051FF RID: 20991
		GuildSkillLevelupSuccess,
		// Token: 0x04005200 RID: 20992
		GuildHasDismissed,
		// Token: 0x04005201 RID: 20993
		GuildLeaderUpdated,
		// Token: 0x04005202 RID: 20994
		GuildWorshipSuccess,
		// Token: 0x04005203 RID: 20995
		GuildAddTableMember,
		// Token: 0x04005204 RID: 20996
		GuildRemoveTableMember,
		// Token: 0x04005205 RID: 20997
		GuildJoinTableSuccess,
		// Token: 0x04005206 RID: 20998
		GuildTableFinished,
		// Token: 0x04005207 RID: 20999
		GuildInspireSuccess,
		// Token: 0x04005208 RID: 21000
		GuildBaseInfoUpdated,
		// Token: 0x04005209 RID: 21001
		GuildSignupSuccess,
		// Token: 0x0400520A RID: 21002
		GuildManorInfoUpdated,
		// Token: 0x0400520B RID: 21003
		GuildManorOwnerUpdated,
		// Token: 0x0400520C RID: 21004
		GuildBattleRecordSync,
		// Token: 0x0400520D RID: 21005
		GuildBattleRewardGetSuccess,
		// Token: 0x0400520E RID: 21006
		GuildBattleStateChanged,
		// Token: 0x0400520F RID: 21007
		GuildBattleRanklistChanged,
		// Token: 0x04005210 RID: 21008
		GuildSelfRankChanged,
		// Token: 0x04005211 RID: 21009
		GuildInviteNoticeUpdate,
		// Token: 0x04005212 RID: 21010
		GuildAttackCityInfoUpdate,
		// Token: 0x04005213 RID: 21011
		GuildInspireInfoUpdate,
		// Token: 0x04005214 RID: 21012
		GuildLotteryResultRes,
		// Token: 0x04005215 RID: 21013
		GuildTownStatueUpdate,
		// Token: 0x04005216 RID: 21014
		GuildJoinLvUpdate,
		// Token: 0x04005217 RID: 21015
		GuildReceiveMergerd,
		// Token: 0x04005218 RID: 21016
		RefuseAllReceive,
		// Token: 0x04005219 RID: 21017
		GuildReceiveMergedList,
		// Token: 0x0400521A RID: 21018
		AgreeMerger,
		// Token: 0x0400521B RID: 21019
		RequestGuildMergerSucess,
		// Token: 0x0400521C RID: 21020
		CanMergerdGuildMemberUpdate,
		// Token: 0x0400521D RID: 21021
		AcceptOtherGuildAgree,
		// Token: 0x0400521E RID: 21022
		GuildDungeonDamageRank,
		// Token: 0x0400521F RID: 21023
		GuildDungeonUpdateActivityData,
		// Token: 0x04005220 RID: 21024
		GuildDungeonUpdateDungeonMapInfo,
		// Token: 0x04005221 RID: 21025
		GuildOpenGuildDungeonTreasureChests,
		// Token: 0x04005222 RID: 21026
		GuildDungeonUpdateDungeonBufInfo,
		// Token: 0x04005223 RID: 21027
		GuildDungeonSyncActivityState,
		// Token: 0x04005224 RID: 21028
		GuildGuardStatueUpdate,
		// Token: 0x04005225 RID: 21029
		GuildDungeonShowFireworks,
		// Token: 0x04005226 RID: 21030
		GuildDungeonSetBossDiff,
		// Token: 0x04005227 RID: 21031
		GuildBossHPRefresh,
		// Token: 0x04005228 RID: 21032
		BattleDoubleBossTips,
		// Token: 0x04005229 RID: 21033
		DungeonRebornFail,
		// Token: 0x0400522A RID: 21034
		DungeonRebornSuccess,
		// Token: 0x0400522B RID: 21035
		DungeonFinishRebornFail,
		// Token: 0x0400522C RID: 21036
		AddRerbornCount,
		// Token: 0x0400522D RID: 21037
		RedPacketSendSuccess,
		// Token: 0x0400522E RID: 21038
		RedPacketOpenSuccess,
		// Token: 0x0400522F RID: 21039
		RedPacketCheckSuccess,
		// Token: 0x04005230 RID: 21040
		RedPacketGet,
		// Token: 0x04005231 RID: 21041
		RedPacketDelete,
		// Token: 0x04005232 RID: 21042
		BudoRewardReturn,
		// Token: 0x04005233 RID: 21043
		OnFashionMergeNotify,
		// Token: 0x04005234 RID: 21044
		OnFashionMergeRedCounChanged,
		// Token: 0x04005235 RID: 21045
		OnFashionMergeSwich,
		// Token: 0x04005236 RID: 21046
		OnPayResultNotify,
		// Token: 0x04005237 RID: 21047
		OnPayRewardReceived,
		// Token: 0x04005238 RID: 21048
		DailyChargeResultNotify,
		// Token: 0x04005239 RID: 21049
		DailyChargeRedPointChanged,
		// Token: 0x0400523A RID: 21050
		DailyChargeCounterChanged,
		// Token: 0x0400523B RID: 21051
		MagicJarUseSuccess,
		// Token: 0x0400523C RID: 21052
		MagicJarUseFail,
		// Token: 0x0400523D RID: 21053
		UpdatePayData,
		// Token: 0x0400523E RID: 21054
		RanklistUpdated,
		// Token: 0x0400523F RID: 21055
		EquipForgeSuccess,
		// Token: 0x04005240 RID: 21056
		EquipForgeFail,
		// Token: 0x04005241 RID: 21057
		FrameCloseCallBack,
		// Token: 0x04005242 RID: 21058
		WaitMessageReopen,
		// Token: 0x04005243 RID: 21059
		RoleRecoveryUpdate,
		// Token: 0x04005244 RID: 21060
		RoleDeleteOk,
		// Token: 0x04005245 RID: 21061
		ServerTimeChanged,
		// Token: 0x04005246 RID: 21062
		RoleIdChanged,
		// Token: 0x04005247 RID: 21063
		RoleChatDirtyChanged,
		// Token: 0x04005248 RID: 21064
		PopChatMsg,
		// Token: 0x04005249 RID: 21065
		OnChatFrameStatusChanged,
		// Token: 0x0400524A RID: 21066
		PKSelfLevelUpdated,
		// Token: 0x0400524B RID: 21067
		PKRankChanged,
		// Token: 0x0400524C RID: 21068
		SeasonStarted,
		// Token: 0x0400524D RID: 21069
		PKMyRecordUpdated,
		// Token: 0x0400524E RID: 21070
		PKPeakRecordUpdated,
		// Token: 0x0400524F RID: 21071
		onSDKLoginSuccess,
		// Token: 0x04005250 RID: 21072
		onSDKLogoutSuccess,
		// Token: 0x04005251 RID: 21073
		onSelectChannelSuccess,
		// Token: 0x04005252 RID: 21074
		JarOpenRecordUpdate,
		// Token: 0x04005253 RID: 21075
		WordChatHorn,
		// Token: 0x04005254 RID: 21076
		RelationTabChanged,
		// Token: 0x04005255 RID: 21077
		RelationAddRecommendFriendMsgSended,
		// Token: 0x04005256 RID: 21078
		MainRelationTabChanged,
		// Token: 0x04005257 RID: 21079
		FriendComMenuRemoveList,
		// Token: 0x04005258 RID: 21080
		JarFreeTimeChanged,
		// Token: 0x04005259 RID: 21081
		PetSlotChanged,
		// Token: 0x0400525A RID: 21082
		PetItemsInfoUpdate,
		// Token: 0x0400525B RID: 21083
		PetFeedSuccess,
		// Token: 0x0400525C RID: 21084
		PetPropertyReselect,
		// Token: 0x0400525D RID: 21085
		EatPetSuccess,
		// Token: 0x0400525E RID: 21086
		PlayActiveFeedPetAction,
		// Token: 0x0400525F RID: 21087
		FollowPetSatietyChanged,
		// Token: 0x04005260 RID: 21088
		UpdatePetFoodNum,
		// Token: 0x04005261 RID: 21089
		PetGoldFeedClick,
		// Token: 0x04005262 RID: 21090
		PetTabClick,
		// Token: 0x04005263 RID: 21091
		OnEnchantCardSelected,
		// Token: 0x04005264 RID: 21092
		OnSarakCardSelected,
		// Token: 0x04005265 RID: 21093
		HasLimitTimeGiftToBuy,
		// Token: 0x04005266 RID: 21094
		OnLimitTimeGiftViewRefresh,
		// Token: 0x04005267 RID: 21095
		OnLimitTimeGiftDataRefresh,
		// Token: 0x04005268 RID: 21096
		OnLimitTimeGiftChecked,
		// Token: 0x04005269 RID: 21097
		GetGiftData,
		// Token: 0x0400526A RID: 21098
		OnMallFrameClosed,
		// Token: 0x0400526B RID: 21099
		OnMonthCardUpdate,
		// Token: 0x0400526C RID: 21100
		SDKBindPhoneFinished,
		// Token: 0x0400526D RID: 21101
		ShowLimitTimeActivityBtn,
		// Token: 0x0400526E RID: 21102
		InitLimitTimeActivityView,
		// Token: 0x0400526F RID: 21103
		RefreshLimitTimeActivityIcon,
		// Token: 0x04005270 RID: 21104
		AutoEnterToRoleSelect,
		// Token: 0x04005271 RID: 21105
		ControlFashionFrame,
		// Token: 0x04005272 RID: 21106
		RefreshActivityLimitTimeBtn,
		// Token: 0x04005273 RID: 21107
		OnGuildHouseItemAdd,
		// Token: 0x04005274 RID: 21108
		OnGuildHouseItemUpdate,
		// Token: 0x04005275 RID: 21109
		OnGuildHouseItemRemoved,
		// Token: 0x04005276 RID: 21110
		OnGuildHouseItemStoreRet,
		// Token: 0x04005277 RID: 21111
		OnGuildHouseItemDeleteRet,
		// Token: 0x04005278 RID: 21112
		OnOpenGuildHouseMain,
		// Token: 0x04005279 RID: 21113
		OnGuildSotrageOperationRecordsChanged,
		// Token: 0x0400527A RID: 21114
		MakeShowOnlineService,
		// Token: 0x0400527B RID: 21115
		OnRecOnlineServiceSign,
		// Token: 0x0400527C RID: 21116
		OnRecOnlineServiceNewNote,
		// Token: 0x0400527D RID: 21117
		OnRecVipOnlineService,
		// Token: 0x0400527E RID: 21118
		OnWebViewLoadStart,
		// Token: 0x0400527F RID: 21119
		OnWebVieewLoadFinish,
		// Token: 0x04005280 RID: 21120
		OnWebViewLoadError,
		// Token: 0x04005281 RID: 21121
		OnShowAskTeacherMenu,
		// Token: 0x04005282 RID: 21122
		OnAskTeacherMsgSended,
		// Token: 0x04005283 RID: 21123
		OnQueryTeacherChanged,
		// Token: 0x04005284 RID: 21124
		OnSearchedTeacherListChanged,
		// Token: 0x04005285 RID: 21125
		OnSearchedPupilListChanged,
		// Token: 0x04005286 RID: 21126
		OnApplyPupilListChanged,
		// Token: 0x04005287 RID: 21127
		OnApplyTeacherListChanged,
		// Token: 0x04005288 RID: 21128
		OnShowPupilRealMenu,
		// Token: 0x04005289 RID: 21129
		OnShowPupilApplyMenu,
		// Token: 0x0400528A RID: 21130
		OnAnnouncementChanged,
		// Token: 0x0400528B RID: 21131
		OnGetPupilSettingChanged,
		// Token: 0x0400528C RID: 21132
		OnWanApplyedPupilChanged,
		// Token: 0x0400528D RID: 21133
		OnNewPupilApplyRecieved,
		// Token: 0x0400528E RID: 21134
		OnNewTeacherApplyRecieved,
		// Token: 0x0400528F RID: 21135
		OnShowTeacherRealMenu,
		// Token: 0x04005290 RID: 21136
		OnSelectedAOPPlyerChanged,
		// Token: 0x04005291 RID: 21137
		OnPayWordsChanged,
		// Token: 0x04005292 RID: 21138
		OnPayListChanged,
		// Token: 0x04005293 RID: 21139
		OnAddOnPaySettingChanged,
		// Token: 0x04005294 RID: 21140
		OnPayRequestTimesChanged,
		// Token: 0x04005295 RID: 21141
		OnDonateSelecteItemChanged,
		// Token: 0x04005296 RID: 21142
		OnRefreshClassmateDic,
		// Token: 0x04005297 RID: 21143
		OnMyPupilMissionUpdate,
		// Token: 0x04005298 RID: 21144
		OnTAPLearningUpdate,
		// Token: 0x04005299 RID: 21145
		OnPupilDataUpdate,
		// Token: 0x0400529A RID: 21146
		OnTeacherDataUpdate,
		// Token: 0x0400529B RID: 21147
		OnUpdateTAPPublishFrame,
		// Token: 0x0400529C RID: 21148
		OnReSelectTAPToggle,
		// Token: 0x0400529D RID: 21149
		OnTAPStartTalk,
		// Token: 0x0400529E RID: 21150
		OnTAPPublishMissionSuccess,
		// Token: 0x0400529F RID: 21151
		OnTAPGraduationScoreChange,
		// Token: 0x040052A0 RID: 21152
		OnTAPTeacherValueChange,
		// Token: 0x040052A1 RID: 21153
		OnTAPApplyToggleRedPointUpdate,
		// Token: 0x040052A2 RID: 21154
		OnTAPOpenSearchFrame,
		// Token: 0x040052A3 RID: 21155
		OnTAPGraduationSuccess,
		// Token: 0x040052A4 RID: 21156
		OnTAPReportTeacherSuccess,
		// Token: 0x040052A5 RID: 21157
		OnTAPSetRedPoint,
		// Token: 0x040052A6 RID: 21158
		OnTAPRedPointUpdate,
		// Token: 0x040052A7 RID: 21159
		OnSwitchPupilSelect,
		// Token: 0x040052A8 RID: 21160
		OnUpdateMissionListBtn,
		// Token: 0x040052A9 RID: 21161
		OnInviteTextChanged,
		// Token: 0x040052AA RID: 21162
		OnRefreshPackageProperty,
		// Token: 0x040052AB RID: 21163
		OnMoneyRewardsStatusChanged,
		// Token: 0x040052AC RID: 21164
		OnMoneyRewardsResultChanged,
		// Token: 0x040052AD RID: 21165
		OnMoneyRewardsPoolsMoneyChanged,
		// Token: 0x040052AE RID: 21166
		OnMoneyRewardsSelfResultChanged,
		// Token: 0x040052AF RID: 21167
		OnMoneyRewardsPlayerCountChanged,
		// Token: 0x040052B0 RID: 21168
		OnMoneyRewardsAwardsChanged,
		// Token: 0x040052B1 RID: 21169
		OnMoneyRewardsRankListChanged,
		// Token: 0x040052B2 RID: 21170
		OnMoneyRewardsRecordsChanged,
		// Token: 0x040052B3 RID: 21171
		OnMoneyRewardsTrySecondMatch,
		// Token: 0x040052B4 RID: 21172
		OnMoneyRewardsBattleInfoChanged,
		// Token: 0x040052B5 RID: 21173
		OnMoneyRewardsAwardListChanged,
		// Token: 0x040052B6 RID: 21174
		OnMoneyRewardsRcdStatusChanged,
		// Token: 0x040052B7 RID: 21175
		OnMoneyRewardsAddPartyTimesChanged,
		// Token: 0x040052B8 RID: 21176
		OnSelectedMergeTitleChanged,
		// Token: 0x040052B9 RID: 21177
		OnPlayerFunctionUnlockAnimation,
		// Token: 0x040052BA RID: 21178
		OnMonopolyRollResSuccessed,
		// Token: 0x040052BB RID: 21179
		OnZillionaireGameInfoChanged,
		// Token: 0x040052BC RID: 21180
		OnBlessingCardChanged,
		// Token: 0x040052BD RID: 21181
		OnAnniversaryPointChanged,
		// Token: 0x040052BE RID: 21182
		UpdateFreeVersion,
		// Token: 0x040052BF RID: 21183
		PK3V3GetRaceEndResult,
		// Token: 0x040052C0 RID: 21184
		PK2V2CrossScoreGetRaceEndResult,
		// Token: 0x040052C1 RID: 21185
		PK3V3GetRoundEndResult,
		// Token: 0x040052C2 RID: 21186
		PK3V3StartRedyFightCount,
		// Token: 0x040052C3 RID: 21187
		PK3V3StartVoteForFight,
		// Token: 0x040052C4 RID: 21188
		PK3V3VoteForFightStatusChanged,
		// Token: 0x040052C5 RID: 21189
		PK3V3FinishVoteForFight,
		// Token: 0x040052C6 RID: 21190
		Pk3v3RoomInfoUpdate,
		// Token: 0x040052C7 RID: 21191
		Pk3v3RoomSimpleInfoUpdate,
		// Token: 0x040052C8 RID: 21192
		Pk3v3RoomSlotInfoUpdate,
		// Token: 0x040052C9 RID: 21193
		Pk3v3InviteRoomListUpdate,
		// Token: 0x040052CA RID: 21194
		Pk3v3KickOut,
		// Token: 0x040052CB RID: 21195
		Pk3v3BeginMatch,
		// Token: 0x040052CC RID: 21196
		Pk3v3CancelMatch,
		// Token: 0x040052CD RID: 21197
		Pk3v3BeginMatchRes,
		// Token: 0x040052CE RID: 21198
		Pk3v3CancelMatchRes,
		// Token: 0x040052CF RID: 21199
		Pk3v3RefuseBeginMatch,
		// Token: 0x040052D0 RID: 21200
		Pk3v3PlayerLeave,
		// Token: 0x040052D1 RID: 21201
		Set3v3RoomName,
		// Token: 0x040052D2 RID: 21202
		Set3v3RoomPassword,
		// Token: 0x040052D3 RID: 21203
		Pk3v3VoteEnterBattle,
		// Token: 0x040052D4 RID: 21204
		Pk3v3RefreshRoomList,
		// Token: 0x040052D5 RID: 21205
		Pk3v3ChangePosition,
		// Token: 0x040052D6 RID: 21206
		OnNormalFashionModeChanged,
		// Token: 0x040052D7 RID: 21207
		OnNormalFashionSelected,
		// Token: 0x040052D8 RID: 21208
		OnFashionSpecialMerged,
		// Token: 0x040052D9 RID: 21209
		OnFashionSpecialFly,
		// Token: 0x040052DA RID: 21210
		OnFashionAutoEquip,
		// Token: 0x040052DB RID: 21211
		OnFashionFastItemBuyFinished,
		// Token: 0x040052DC RID: 21212
		OnFashionTicketBuyFinished,
		// Token: 0x040052DD RID: 21213
		OnFashionNormalItemSelected,
		// Token: 0x040052DE RID: 21214
		RefreshAuctionBuyFrameInfo,
		// Token: 0x040052DF RID: 21215
		OnVoiceChatRecordStart,
		// Token: 0x040052E0 RID: 21216
		OnVoiceChatRecordEnd,
		// Token: 0x040052E1 RID: 21217
		OnVoiceChatRecordFailed,
		// Token: 0x040052E2 RID: 21218
		OnVoiceChatRecording,
		// Token: 0x040052E3 RID: 21219
		OnVoiceChatSendStart,
		// Token: 0x040052E4 RID: 21220
		OnVoiceChatSendEnd,
		// Token: 0x040052E5 RID: 21221
		OnVoiceChatSendFailed,
		// Token: 0x040052E6 RID: 21222
		OnVoiceChatSending,
		// Token: 0x040052E7 RID: 21223
		OnVoiceChatSendSucc,
		// Token: 0x040052E8 RID: 21224
		OnVoiceChatPlayStart,
		// Token: 0x040052E9 RID: 21225
		OnVoiceChatPlayEnd,
		// Token: 0x040052EA RID: 21226
		OnVoiceChatPlayFailed,
		// Token: 0x040052EB RID: 21227
		OnVoiceChatPlaying,
		// Token: 0x040052EC RID: 21228
		OnVoiceChatPlayReset,
		// Token: 0x040052ED RID: 21229
		OnVoiceChatComtalkBtnPressed,
		// Token: 0x040052EE RID: 21230
		OnVoiceChatMicNoAuth,
		// Token: 0x040052EF RID: 21231
		OnVoiceChatGuildJoin,
		// Token: 0x040052F0 RID: 21232
		OnVoiceChatGuildLeave,
		// Token: 0x040052F1 RID: 21233
		OnVoiceChatTeamJoin,
		// Token: 0x040052F2 RID: 21234
		OnVoiceChatTeamLeave,
		// Token: 0x040052F3 RID: 21235
		OnVoiceChatSceneJoin,
		// Token: 0x040052F4 RID: 21236
		OnVoiceChatSceneLeave,
		// Token: 0x040052F5 RID: 21237
		OnVoiceChatDungeonJoin,
		// Token: 0x040052F6 RID: 21238
		OnVoiceChatDungeonLeave,
		// Token: 0x040052F7 RID: 21239
		OnVoiceChatPrivateJoin,
		// Token: 0x040052F8 RID: 21240
		OnVoiceChatPrivateLeave,
		// Token: 0x040052F9 RID: 21241
		VoiceTalkMicSwitch,
		// Token: 0x040052FA RID: 21242
		VoiceTalkPlayerSwitch,
		// Token: 0x040052FB RID: 21243
		VoiceTalkLimitAllNotSpeak,
		// Token: 0x040052FC RID: 21244
		VoiceTalkMicClosedByOther,
		// Token: 0x040052FD RID: 21245
		VoiceTalkChannelChanged,
		// Token: 0x040052FE RID: 21246
		VoiceTalkOtherSpeakInChannel,
		// Token: 0x040052FF RID: 21247
		VoiceTalkJoinChannelAndMicChanged,
		// Token: 0x04005300 RID: 21248
		VoiceTalkLeaveAllChannel,
		// Token: 0x04005301 RID: 21249
		OnDayChargeChanged,
		// Token: 0x04005302 RID: 21250
		OnAchievementGroupSubTabChanged,
		// Token: 0x04005303 RID: 21251
		OnAchievementGroupSubTabChangedRepeated,
		// Token: 0x04005304 RID: 21252
		OnAchievementSecondMenuTabChanged,
		// Token: 0x04005305 RID: 21253
		OnAchievementMaskPropertyChanged,
		// Token: 0x04005306 RID: 21254
		OnShareAchievementItem,
		// Token: 0x04005307 RID: 21255
		OnAchievementScoreChanged,
		// Token: 0x04005308 RID: 21256
		OnAchievementComplete,
		// Token: 0x04005309 RID: 21257
		OnAchievementOver,
		// Token: 0x0400530A RID: 21258
		RefreshLimitTimeState,
		// Token: 0x0400530B RID: 21259
		UpdatePackageTabRedPoint,
		// Token: 0x0400530C RID: 21260
		EquipRecoveryPriceReqSuccess,
		// Token: 0x0400530D RID: 21261
		EquipSubmitSuccess,
		// Token: 0x0400530E RID: 21262
		EquipRedeemSuccess,
		// Token: 0x0400530F RID: 21263
		EquipReturnFail,
		// Token: 0x04005310 RID: 21264
		EquipUpgradeSuccess,
		// Token: 0x04005311 RID: 21265
		EquipRecoveryUpdateTime,
		// Token: 0x04005312 RID: 21266
		EquipJarListUpdate,
		// Token: 0x04005313 RID: 21267
		EquipRecivertDeleteItem,
		// Token: 0x04005314 RID: 21268
		EquipSubmitScore,
		// Token: 0x04005315 RID: 21269
		EquipUpgradeFail,
		// Token: 0x04005316 RID: 21270
		EquipDonatePackageUpdate,
		// Token: 0x04005317 RID: 21271
		RightLowerBubblePlayAnimation,
		// Token: 0x04005318 RID: 21272
		RightLowerBubbleStopAnimation,
		// Token: 0x04005319 RID: 21273
		Count,
		// Token: 0x0400531A RID: 21274
		LockStatuNewMessageNumber,
		// Token: 0x0400531B RID: 21275
		SetNoteNameSuccess,
		// Token: 0x0400531C RID: 21276
		onLiveShowPursueModeChange,
		// Token: 0x0400531D RID: 21277
		OnSyncWorldMallQueryItems,
		// Token: 0x0400531E RID: 21278
		OnSyncMallBatchBuySucceed,
		// Token: 0x0400531F RID: 21279
		OnSyncWorldMallBuySucceed,
		// Token: 0x04005320 RID: 21280
		OnReceiveSceneMallFashionLimitedSuitStatusRes,
		// Token: 0x04005321 RID: 21281
		OnChangeTreasureDigMap,
		// Token: 0x04005322 RID: 21282
		OnChangeTreasureDigSelectMap,
		// Token: 0x04005323 RID: 21283
		OnOpenTreasureDigMap,
		// Token: 0x04005324 RID: 21284
		OnTreasureDigMapOpen,
		// Token: 0x04005325 RID: 21285
		OnTreasureDigMapClose,
		// Token: 0x04005326 RID: 21286
		OnWatchTreasureDigSite,
		// Token: 0x04005327 RID: 21287
		OnWatchRefreshDigSite,
		// Token: 0x04005328 RID: 21288
		OnOpenTreasureDigSite,
		// Token: 0x04005329 RID: 21289
		OnTreasureDigSiteChanged,
		// Token: 0x0400532A RID: 21290
		OnTreasureMapDigReset,
		// Token: 0x0400532B RID: 21291
		OnTreasureMapPlayerNumSync,
		// Token: 0x0400532C RID: 21292
		OnTreasureAtlasInfoSync,
		// Token: 0x0400532D RID: 21293
		OnTreasureRaffleStart,
		// Token: 0x0400532E RID: 21294
		OnTreasureRaffleEnd,
		// Token: 0x0400532F RID: 21295
		OnTreasureRecordInfoChanged,
		// Token: 0x04005330 RID: 21296
		OnTreasureRecordInfoSync,
		// Token: 0x04005331 RID: 21297
		OnTreasureAtlasOpen,
		// Token: 0x04005332 RID: 21298
		OnTreasureAtlasClose,
		// Token: 0x04005333 RID: 21299
		OnTreasureItemBuyRes,
		// Token: 0x04005334 RID: 21300
		OnTreasureFuncSwitch,
		// Token: 0x04005335 RID: 21301
		OnTresureItemCountChanged,
		// Token: 0x04005336 RID: 21302
		OnSyncWorldBuyPetSucceed,
		// Token: 0x04005337 RID: 21303
		RefreshSecurityLockDataUI,
		// Token: 0x04005338 RID: 21304
		RefreshVerifyPwdErrorCount,
		// Token: 0x04005339 RID: 21305
		VanityBonusAnimationEnd,
		// Token: 0x0400533A RID: 21306
		VanityBonusBuffPos,
		// Token: 0x0400533B RID: 21307
		BuffDrugSettingSubmit,
		// Token: 0x0400533C RID: 21308
		OnSelectPickBeadExpendItem,
		// Token: 0x0400533D RID: 21309
		BeadPickSuccess,
		// Token: 0x0400533E RID: 21310
		OnStrengthenTicketMergeStateUpdate,
		// Token: 0x0400533F RID: 21311
		OnStrengthenTicketMergeSelectType,
		// Token: 0x04005340 RID: 21312
		OnStrengthenTicketMergeSelectTicket,
		// Token: 0x04005341 RID: 21313
		OnStrengthenTicketFuseAddTicket,
		// Token: 0x04005342 RID: 21314
		OnStrengthenTicketFuseRemoveTicket,
		// Token: 0x04005343 RID: 21315
		OnStrengthenTicketMergeSuccess,
		// Token: 0x04005344 RID: 21316
		OnStrengthenTicketMergeFailed,
		// Token: 0x04005345 RID: 21317
		OnStrengthenTicketFuseSuccess,
		// Token: 0x04005346 RID: 21318
		OnStrengthenTicketFuseFailed,
		// Token: 0x04005347 RID: 21319
		OnStrengthenTicketFuseCalPercent,
		// Token: 0x04005348 RID: 21320
		OnStrengthenTicketMergeSelectReset,
		// Token: 0x04005349 RID: 21321
		OnStrengthenTicketStartMerge,
		// Token: 0x0400534A RID: 21322
		OnStrengthenTicketMallBuySuccess,
		// Token: 0x0400534B RID: 21323
		OnStrengthenTicketFreshView,
		// Token: 0x0400534C RID: 21324
		OnSelectExpendBeadItem,
		// Token: 0x0400534D RID: 21325
		OnBeadUpgradeSuccess,
		// Token: 0x0400534E RID: 21326
		OnAdventureTeamFuncChanged,
		// Token: 0x0400534F RID: 21327
		OnAdventureTeamLevelUp,
		// Token: 0x04005350 RID: 21328
		OnAdventureTeamCollectionInfoChanged,
		// Token: 0x04005351 RID: 21329
		OnAdventureTeamExpeditionAwardChanged,
		// Token: 0x04005352 RID: 21330
		OnAdventureTeamBaseInfoFrameOpen,
		// Token: 0x04005353 RID: 21331
		OnAdventureTeamRenameSucc,
		// Token: 0x04005354 RID: 21332
		OnAdventureTeamRenameCardBuySucc,
		// Token: 0x04005355 RID: 21333
		OnAdventureTeamExpeditionMapInfoChanged,
		// Token: 0x04005356 RID: 21334
		OnAdventureTeamExpeditionRolesChanged,
		// Token: 0x04005357 RID: 21335
		OnAdventureTeamExpeditionMiniMapChanged,
		// Token: 0x04005358 RID: 21336
		OnAdventureTeamExpeditionRolesSelected,
		// Token: 0x04005359 RID: 21337
		OnAdventureTeamExpeditionDispatch,
		// Token: 0x0400535A RID: 21338
		OnAdventureTeamExpeddtionCancel,
		// Token: 0x0400535B RID: 21339
		OnAdventureTeamExpeditionGetReward,
		// Token: 0x0400535C RID: 21340
		OnAdventureTeamExpeditionTimeChanged,
		// Token: 0x0400535D RID: 21341
		OnAdventureTeamExpeditionIDChanged,
		// Token: 0x0400535E RID: 21342
		OnAdventureTeamExpeditionTimerFinish,
		// Token: 0x0400535F RID: 21343
		OnAdventureTeamBlessCrystalCountChanged,
		// Token: 0x04005360 RID: 21344
		OnAdventureTeamBlessCrystalExpChanged,
		// Token: 0x04005361 RID: 21345
		OnAdventureTeamBountyCountChanged,
		// Token: 0x04005362 RID: 21346
		OnAdventureTeamInheritBlessCountChanged,
		// Token: 0x04005363 RID: 21347
		OnAdventureTeamInheritBlessExpChanged,
		// Token: 0x04005364 RID: 21348
		OnAdventureTeamBaseInfoRes,
		// Token: 0x04005365 RID: 21349
		OnAdventureTeamBlessCrystalInfoRes,
		// Token: 0x04005366 RID: 21350
		OnAdventureTeamInheritBlessInfoRes,
		// Token: 0x04005367 RID: 21351
		OnAdventureTeamCollectionInfoRes,
		// Token: 0x04005368 RID: 21352
		OnAdventureTeamWeeklyTaskChange,
		// Token: 0x04005369 RID: 21353
		OnAdventureTeamWeeklyTaskStatusChanged,
		// Token: 0x0400536A RID: 21354
		NotifyShowAdventureTeamUnlockAnim,
		// Token: 0x0400536B RID: 21355
		NotifyShowAdventurePassSeasonUnlockAnim,
		// Token: 0x0400536C RID: 21356
		OnAdventureTeamExpeditionResultFrameClose,
		// Token: 0x0400536D RID: 21357
		OnItemInPackageRemovedMessage,
		// Token: 0x0400536E RID: 21358
		OnItemInPackageAddedMessage,
		// Token: 0x0400536F RID: 21359
		OnAuctionNewReceiveItemNumResSucceed,
		// Token: 0x04005370 RID: 21360
		OnAuctionNewReceiveItemDetailDataResSucceed,
		// Token: 0x04005371 RID: 21361
		OnAuctionNewBuyShelfResSucceed,
		// Token: 0x04005372 RID: 21362
		OnAuctionNewReceiveSelfListResSucceed,
		// Token: 0x04005373 RID: 21363
		OnAuctionNewNotifyRefreshToRequestDetailItems,
		// Token: 0x04005374 RID: 21364
		OnAuctionNewGetTreasureTransactionRecordSucceed,
		// Token: 0x04005375 RID: 21365
		OnAuctionNewWorldQueryItemPriceResSucceed,
		// Token: 0x04005376 RID: 21366
		OnAuctionNewReceiveNoticeReqSucceed,
		// Token: 0x04005377 RID: 21367
		OnAuctionNewWorldQueryItemPriceListResSucceed,
		// Token: 0x04005378 RID: 21368
		OnAuctionNewWorldQueryItemTransListResSucceed,
		// Token: 0x04005379 RID: 21369
		OnAuctionNewWorldQueryMagicCardOnSaleResSucceed,
		// Token: 0x0400537A RID: 21370
		OnAuctionNewSelectMagicCardStrengthenLevel,
		// Token: 0x0400537B RID: 21371
		OnAuctionNewSelectPositionFilter,
		// Token: 0x0400537C RID: 21372
		OnAuctionNewFrameClosed,
		// Token: 0x0400537D RID: 21373
		BossMissionCompleteFrameClose,
		// Token: 0x0400537E RID: 21374
		OnUploadFileSucc,
		// Token: 0x0400537F RID: 21375
		OnUploadFileClose,
		// Token: 0x04005380 RID: 21376
		ArtifactJarDataUpdate,
		// Token: 0x04005381 RID: 21377
		ArtifactDailyRewardUpdate,
		// Token: 0x04005382 RID: 21378
		ArtifactDailyRecordUpdate,
		// Token: 0x04005383 RID: 21379
		BlackMarketMerchanRetSuccess,
		// Token: 0x04005384 RID: 21380
		BlackMarketMerchantItemUpdate,
		// Token: 0x04005385 RID: 21381
		SyncBlackMarketMerchantNPCType,
		// Token: 0x04005386 RID: 21382
		OnChallengeChapterFrameClose,
		// Token: 0x04005387 RID: 21383
		OnChallengeChapterBeginChange,
		// Token: 0x04005388 RID: 21384
		OnChallengeChapterFinishChange,
		// Token: 0x04005389 RID: 21385
		OnChallengeTeamChatDataUpdate,
		// Token: 0x0400538A RID: 21386
		OnChallengeDungeonRewardUpdate,
		// Token: 0x0400538B RID: 21387
		OnEquipUpgradeSuccess,
		// Token: 0x0400538C RID: 21388
		OnUpdateAvatar,
		// Token: 0x0400538D RID: 21389
		TopUpPushButoonOpen,
		// Token: 0x0400538E RID: 21390
		TopUpPushButtonClose,
		// Token: 0x0400538F RID: 21391
		TopUpPushBuySuccess,
		// Token: 0x04005390 RID: 21392
		UpdateChijiPrepareScenePlayerNum,
		// Token: 0x04005391 RID: 21393
		ChijiHpChanged,
		// Token: 0x04005392 RID: 21394
		ChijiMpChanged,
		// Token: 0x04005393 RID: 21395
		ChijiBattleStageChanged,
		// Token: 0x04005394 RID: 21396
		ChijiPlayerDead,
		// Token: 0x04005395 RID: 21397
		ChijiPkReady,
		// Token: 0x04005396 RID: 21398
		ChijiPkReadyFinish,
		// Token: 0x04005397 RID: 21399
		ChijiPKButtonChange,
		// Token: 0x04005398 RID: 21400
		NearItemsChanged,
		// Token: 0x04005399 RID: 21401
		PoisonStatChange,
		// Token: 0x0400539A RID: 21402
		PoisonNextStage,
		// Token: 0x0400539B RID: 21403
		UpdateChijiNpcData,
		// Token: 0x0400539C RID: 21404
		ExchangeSuccess,
		// Token: 0x0400539D RID: 21405
		StartOpenChijiItem,
		// Token: 0x0400539E RID: 21406
		FinishOpenChijiItem,
		// Token: 0x0400539F RID: 21407
		CancelOpenChijiItem,
		// Token: 0x040053A0 RID: 21408
		OpenChijiSkillChooseFrame,
		// Token: 0x040053A1 RID: 21409
		ChijiBestRank,
		// Token: 0x040053A2 RID: 21410
		TreasureMapSizeChange,
		// Token: 0x040053A3 RID: 21411
		PickUpLoserItem,
		// Token: 0x040053A4 RID: 21412
		OnGuildDungeonAuctionStateUpdate,
		// Token: 0x040053A5 RID: 21413
		OnGuildDungeonWorldAuctionStateUpdate,
		// Token: 0x040053A6 RID: 21414
		OnGuildDungeonAuctionItemsUpdate,
		// Token: 0x040053A7 RID: 21415
		OnGuildDungeonAuctionAddNewItem,
		// Token: 0x040053A8 RID: 21416
		OnCommonKeyBoardInput,
		// Token: 0x040053A9 RID: 21417
		OnMoreAndMoreBtnHandle,
		// Token: 0x040053AA RID: 21418
		OnReadMailResSuccess,
		// Token: 0x040053AB RID: 21419
		UpdateMailStatus,
		// Token: 0x040053AC RID: 21420
		OnMailDeleteSuccess,
		// Token: 0x040053AD RID: 21421
		OnGuildEmblemLevelUp,
		// Token: 0x040053AE RID: 21422
		OnOpenGuildEmblemLevelPage,
		// Token: 0x040053AF RID: 21423
		OnUpdateGuildEmblemLvUpEntry,
		// Token: 0x040053B0 RID: 21424
		OnUpdateGuildEmblemLvUpRedPoint,
		// Token: 0x040053B1 RID: 21425
		OnOpenGuildBenefitsPage,
		// Token: 0x040053B2 RID: 21426
		OnOpenGuildActivityPage,
		// Token: 0x040053B3 RID: 21427
		HeadPortraitFrameChange,
		// Token: 0x040053B4 RID: 21428
		UseHeadPortraitFrameSuccess,
		// Token: 0x040053B5 RID: 21429
		HeadPortraitFrameNotify,
		// Token: 0x040053B6 RID: 21430
		HeadPortraitItemStateChanged,
		// Token: 0x040053B7 RID: 21431
		TitleDataUpdate,
		// Token: 0x040053B8 RID: 21432
		TitleNameUpdate,
		// Token: 0x040053B9 RID: 21433
		TitleGuidUpdate,
		// Token: 0x040053BA RID: 21434
		TitleModeUpdate,
		// Token: 0x040053BB RID: 21435
		TitleBookCloseFrame,
		// Token: 0x040053BC RID: 21436
		OnReceiveGasWeekSignInRecordRes,
		// Token: 0x040053BD RID: 21437
		OnSyncSceneWeekSignInNotify,
		// Token: 0x040053BE RID: 21438
		OnSyncSceneWeekSignBoxNotify,
		// Token: 0x040053BF RID: 21439
		OnActivityWeekSignInRedPointChanged,
		// Token: 0x040053C0 RID: 21440
		OnNewPlayerWeekSignInRedPointChanged,
		// Token: 0x040053C1 RID: 21441
		OnBoxOpenFinished,
		// Token: 0x040053C2 RID: 21442
		OnUpdateGuildRedPacketRecord,
		// Token: 0x040053C3 RID: 21443
		OnSelectGuildRedPackType,
		// Token: 0x040053C4 RID: 21444
		OnUpdateGuildRedPacketSpecInfo,
		// Token: 0x040053C5 RID: 21445
		OnEnchantmentCardUpgradeRetun,
		// Token: 0x040053C6 RID: 21446
		OnMonthCardRewardUpdate,
		// Token: 0x040053C7 RID: 21447
		OnMonthCardRewardAccquired,
		// Token: 0x040053C8 RID: 21448
		OnMonthCardRewardRedPointReset,
		// Token: 0x040053C9 RID: 21449
		OnMonthCardRewardCDUpdate,
		// Token: 0x040053CA RID: 21450
		OnEquipOrDropSkill,
		// Token: 0x040053CB RID: 21451
		OnReceiveTeamDuplicationPlayerInformationNotify,
		// Token: 0x040053CC RID: 21452
		OnReceiveTeamDuplicationTeamListRes,
		// Token: 0x040053CD RID: 21453
		OnReceiveTeamDuplicationRefreshTeamListMessage,
		// Token: 0x040053CE RID: 21454
		OnReceiveTeamDuplicationTeamLeaderRefuseJoinInMessage,
		// Token: 0x040053CF RID: 21455
		OnReceiveTeamDuplicationJoinTeamInCdTimeMessage,
		// Token: 0x040053D0 RID: 21456
		OnReceiveTeamDuplicationDismissMessage,
		// Token: 0x040053D1 RID: 21457
		OnReceiveTeamDuplicationBuildTeamSuccessMessage,
		// Token: 0x040053D2 RID: 21458
		OnReceiveTeamDuplicationTeamDataMessage,
		// Token: 0x040053D3 RID: 21459
		OnReceiveTeamDuplicationTeamStatusNotifyMessage,
		// Token: 0x040053D4 RID: 21460
		OnReceiveTeamDuplicationTeamDetailDataMessage,
		// Token: 0x040053D5 RID: 21461
		OnReceiveTeamDuplicationQuitTeamMessage,
		// Token: 0x040053D6 RID: 21462
		OnReceiveTeamDuplicationCaptainNotifyMessage,
		// Token: 0x040053D7 RID: 21463
		OnReceiveTeamDuplicationOwnerNewTeamInviteMessage,
		// Token: 0x040053D8 RID: 21464
		OnReceiveTeamDuplicationOwnerNewRequesterMessage,
		// Token: 0x040053D9 RID: 21465
		OnReceiveTeamDuplicationTeamMateListMessage,
		// Token: 0x040053DA RID: 21466
		OnReceiveTeamDuplicationTeamInviteListMessage,
		// Token: 0x040053DB RID: 21467
		OnReceiveTeamDuplicationTeamInviteChoiceMessage,
		// Token: 0x040053DC RID: 21468
		OnReceiveTeamDuplicationRequesterListMessage,
		// Token: 0x040053DD RID: 21469
		OnTeamDuplicationForceQuitTeamByDragMessage,
		// Token: 0x040053DE RID: 21470
		OnReceiveTeamDuplicationAutoAgreeGoldMessage,
		// Token: 0x040053DF RID: 21471
		OnReceiveTeamDuplicationFightStartVoteAgreeMessage,
		// Token: 0x040053E0 RID: 21472
		OnReceiveTeamDuplicationStartBattleRefuseMessage,
		// Token: 0x040053E1 RID: 21473
		OnReceiveTeamDuplicationFightEndVoteFlagMessage,
		// Token: 0x040053E2 RID: 21474
		OnReceiveTeamDuplicationFightEndVoteAgreeMessage,
		// Token: 0x040053E3 RID: 21475
		OnReceiveTeamDuplicationFightEndVoteRefuseMessage,
		// Token: 0x040053E4 RID: 21476
		OnReceiveTeamDuplicationFightEndVoteResultSucceedMessage,
		// Token: 0x040053E5 RID: 21477
		OnReceiveTeamDuplicationFightStageNotifyMessage,
		// Token: 0x040053E6 RID: 21478
		OnReceiveTeamDuplicationFightPointNotifyMessage,
		// Token: 0x040053E7 RID: 21479
		OnReceiveTeamDuplicationFightGoalNotifyMessage,
		// Token: 0x040053E8 RID: 21480
		OnReceiveTeamDuplicationFightCaptainGoalChangeMessage,
		// Token: 0x040053E9 RID: 21481
		OnReceiveTeamDuplicationPreFightPointDataUpdateMessage,
		// Token: 0x040053EA RID: 21482
		OnReceiveTeamDuplicationFightPointUnlockRateMessage,
		// Token: 0x040053EB RID: 21483
		OnReceiveTeamDuplicationFightPointBossDataMessage,
		// Token: 0x040053EC RID: 21484
		OnReceiveTeamDuplicationFightPointEnergyAccumulationTimeMessage,
		// Token: 0x040053ED RID: 21485
		OnReceiveTeamDuplicationFightStageRewardEndTimeMessage,
		// Token: 0x040053EE RID: 21486
		OnReceiveTeamDuplicationInBattleMessage,
		// Token: 0x040053EF RID: 21487
		OnReceiveTeamDuplicationFightStageRewardNotify,
		// Token: 0x040053F0 RID: 21488
		OnTeamDuplicationFightStageBeginMessage,
		// Token: 0x040053F1 RID: 21489
		OnTeamDuplicationFightStageEndMessage,
		// Token: 0x040053F2 RID: 21490
		OnReceiveTeamDuplicationFightStageEndNotifyMessage,
		// Token: 0x040053F3 RID: 21491
		OnReceiveTeamDuplicationFightStageEndShowFinishMessage,
		// Token: 0x040053F4 RID: 21492
		OnReceiveTeamDuplicationStageEndDescriptionCloseMessage,
		// Token: 0x040053F5 RID: 21493
		OnReceiveTeamDuplicationMiddleStageRewardCloseMessage,
		// Token: 0x040053F6 RID: 21494
		OnReceiveTeamDuplicationFinalResultCloseMessage,
		// Token: 0x040053F7 RID: 21495
		OnReceiveTeamDuplicationChatContentMessage,
		// Token: 0x040053F8 RID: 21496
		OnReceiveTeamDuplicationServerFuncSwitchChangeMessage,
		// Token: 0x040053F9 RID: 21497
		OnReceiveTeamDuplicationPlayerExpireTimeMessage,
		// Token: 0x040053FA RID: 21498
		OnReceiveTeamDuplicationCloseRelationFrame,
		// Token: 0x040053FB RID: 21499
		OnReceiveTeamDuplicationGridFieldNotifyMessage,
		// Token: 0x040053FC RID: 21500
		OnReceiveTeamDuplicationGridMonsterNotifyMessage,
		// Token: 0x040053FD RID: 21501
		OnReceiveTeamDuplicationGridMonsterRemoveMessage,
		// Token: 0x040053FE RID: 21502
		OnReceiveTeamDuplicationGridOwnerCaptainNotifyMessage,
		// Token: 0x040053FF RID: 21503
		OnReceiveTeamDuplicationGridOtherCaptainNotifyMessage,
		// Token: 0x04005400 RID: 21504
		OnReceiveTeamDuplicationGridMapCaptainMoveMessage,
		// Token: 0x04005401 RID: 21505
		OnReceiveTeamDuplicationGridSquadBattleNotifyMessage,
		// Token: 0x04005402 RID: 21506
		OnReceiveTeamDuplicationGridCountDownTimeMessage,
		// Token: 0x04005403 RID: 21507
		OnReceiveTeamDuplicationGridFightBeginMessage,
		// Token: 0x04005404 RID: 21508
		OnReceiveTeamDuplicationGridFightEndMessage,
		// Token: 0x04005405 RID: 21509
		OnReceiveTeamDuplicationComTalkShowInGridMapMessage,
		// Token: 0x04005406 RID: 21510
		OnReceiveTeamDuplicationComTalkDestroyInGridMapMessage,
		// Token: 0x04005407 RID: 21511
		OnReceiveTeamDuplicationCaptainCdFinishedMessage,
		// Token: 0x04005408 RID: 21512
		OnReceiveTeamDuplicationGridItemDestroyMessage,
		// Token: 0x04005409 RID: 21513
		OnReceiveTeamDuplicationGridMonsterDestroyMessage,
		// Token: 0x0400540A RID: 21514
		OnReceiveTeamDuplicationNearByGridUpdateMessage,
		// Token: 0x0400540B RID: 21515
		OnReceiveTeamDuplicationMonsterNextGridUpdateMessage,
		// Token: 0x0400540C RID: 21516
		OnReceiveTeamDuplicationMonsterNextGridEffectUpdateMessage,
		// Token: 0x0400540D RID: 21517
		OnHardUltimateStart,
		// Token: 0x0400540E RID: 21518
		OnBreathEquipActivationSuccess,
		// Token: 0x0400540F RID: 21519
		OnBreathEquipClearSuccess,
		// Token: 0x04005410 RID: 21520
		OnRedMarkEquipChangedSuccess,
		// Token: 0x04005411 RID: 21521
		OnEquipmentListNoEquipment,
		// Token: 0x04005412 RID: 21522
		OnDailyTodoFuncStateUpdate,
		// Token: 0x04005413 RID: 21523
		OnDailyTodoFuncPlayAnimEnd,
		// Token: 0x04005414 RID: 21524
		OnUpdateFairDuelEntryState,
		// Token: 0x04005415 RID: 21525
		ItemGrowthFail,
		// Token: 0x04005416 RID: 21526
		OnSpecailGrowthFailed,
		// Token: 0x04005417 RID: 21527
		ItemGrowthSuccess,
		// Token: 0x04005418 RID: 21528
		OnUpdateMonthlySignInCountInfo,
		// Token: 0x04005419 RID: 21529
		OnUpdateMonthlySignInItemInfo,
		// Token: 0x0400541A RID: 21530
		OnUpdateAccumulativeSignInItemInfo,
		// Token: 0x0400541B RID: 21531
		OnMonthlySignInRedPointReset,
		// Token: 0x0400541C RID: 21532
		RefreshDungeonBufSuccess,
		// Token: 0x0400541D RID: 21533
		RefreshInspireBufSuccess,
		// Token: 0x0400541E RID: 21534
		OnSendQueryMallItemInfo,
		// Token: 0x0400541F RID: 21535
		OnQueryMallItenInfoSuccess,
		// Token: 0x04005420 RID: 21536
		DeadLineReminderChanged,
		// Token: 0x04005421 RID: 21537
		RefreshChatData,
		// Token: 0x04005422 RID: 21538
		DungeonChatMsgDataUpdate,
		// Token: 0x04005423 RID: 21539
		DungeonChatInputFieldOpen,
		// Token: 0x04005424 RID: 21540
		DungeonChatInputFieldClose,
		// Token: 0x04005425 RID: 21541
		SelectFashionEquipToDecompose,
		// Token: 0x04005426 RID: 21542
		CloseFashionEquipDecompose,
		// Token: 0x04005427 RID: 21543
		OnSelectedInscriptionHole,
		// Token: 0x04005428 RID: 21544
		OnInscriptionHoleOpenHoleSuccess,
		// Token: 0x04005429 RID: 21545
		RefreshInscriptionEquipmentList,
		// Token: 0x0400542A RID: 21546
		OnInscriptionMosaicSuccess,
		// Token: 0x0400542B RID: 21547
		OnCloseSynthesisIncriptionChanged,
		// Token: 0x0400542C RID: 21548
		OnIncriptionSynthesisSuccess,
		// Token: 0x0400542D RID: 21549
		OnItemEquipInscriptionSucceed,
		// Token: 0x0400542E RID: 21550
		UpdateAventurePassStatus,
		// Token: 0x0400542F RID: 21551
		UpdateAventurePassExpPackStatus,
		// Token: 0x04005430 RID: 21552
		OnUpdateAdventureCoin,
		// Token: 0x04005431 RID: 21553
		UpdateAventurePassButtonRedPoint,
		// Token: 0x04005432 RID: 21554
		BuySkillPage2Sucess,
		// Token: 0x04005433 RID: 21555
		UpdateGameOptions,
		// Token: 0x04005434 RID: 21556
		OnUpateRollItem,
		// Token: 0x04005435 RID: 21557
		OnRollItemEnd,
		// Token: 0x04005436 RID: 21558
		OnSelectSkillPage,
		// Token: 0x04005437 RID: 21559
		OnUpdateEquipmentScore,
		// Token: 0x04005438 RID: 21560
		OnUpdatePassiveSkillGray,
		// Token: 0x04005439 RID: 21561
		StopCloseCommonNewMessageBoxView,
		// Token: 0x0400543A RID: 21562
		OnUpdateIntegrationChallengeScore,
		// Token: 0x0400543B RID: 21563
		OnEffectHide,
		// Token: 0x0400543C RID: 21564
		OnEffectShow,
		// Token: 0x0400543D RID: 21565
		OnReceiveEquipPlanSyncMessage,
		// Token: 0x0400543E RID: 21566
		OnReceiveEquipPlanSwitchMessage,
		// Token: 0x0400543F RID: 21567
		OnReceiveEquipPlanItemEndTimeMessage,
		// Token: 0x04005440 RID: 21568
		OnReceiveHonorSystemResMessage,
		// Token: 0x04005441 RID: 21569
		OnReceiveHonorSystemRedPointUpdateMessage,
		// Token: 0x04005442 RID: 21570
		OnTreasureConversionSuccessed,
		// Token: 0x04005443 RID: 21571
		OnEpicEquipmentConversionSuccessed,
		// Token: 0x04005444 RID: 21572
		OnReceiveSceneShopRefreshSucceed,
		// Token: 0x04005445 RID: 21573
		OnReceiveSceneShopQuerySucceed,
		// Token: 0x04005446 RID: 21574
		OnReceiveSceneShopItemBuySucceed,
		// Token: 0x04005447 RID: 21575
		WarriorRecruitQueryTaskSuccessed,
		// Token: 0x04005448 RID: 21576
		WarriorRecruitQueryIdentitySuccessed,
		// Token: 0x04005449 RID: 21577
		WarriorRecruitBindInviteCodeSuccessed,
		// Token: 0x0400544A RID: 21578
		WarriorRecruitReceiveRewardSuccessed,
		// Token: 0x0400544B RID: 21579
		WarriorRecruitQueryHireAlreadyBindSuccessed,
		// Token: 0x0400544C RID: 21580
		OnReceiveRoleStorageChangeNameMessage,
		// Token: 0x0400544D RID: 21581
		OnReceiveRoleStorageUnlockMessage,
		// Token: 0x0400544E RID: 21582
		OnReceiveItemTipFrameOpenMessage,
		// Token: 0x0400544F RID: 21583
		OnReceiveItemTipFrameCloseMessage,
		// Token: 0x04005450 RID: 21584
		OnGASWholeBargainResSuccessed,
		// Token: 0x04005451 RID: 21585
		OnReceiveChampionshipStatusMessage,
		// Token: 0x04005452 RID: 21586
		OnReceiveChampionshipSelfStatusMessage,
		// Token: 0x04005453 RID: 21587
		OnReceiveChampionshipSignUpSucceedMessage,
		// Token: 0x04005454 RID: 21588
		OnReceiveChampionshipJoinInPrepareSucceedMessage,
		// Token: 0x04005455 RID: 21589
		OnReceiveChampionshipPointRankMessage,
		// Token: 0x04005456 RID: 21590
		OnReceiveChampionshipReliveResMessage,
		// Token: 0x04005457 RID: 21591
		OnReceiveChampionshipSelfSeaFightResultMessage,
		// Token: 0x04005458 RID: 21592
		OnReceiveChampionshipGroupScoreRankResMessage,
		// Token: 0x04005459 RID: 21593
		OnReceiveChampionshipTopScoreRankSyncMessage,
		// Token: 0x0400545A RID: 21594
		OnReceiveChampionshipGroupIdSyncMessage,
		// Token: 0x0400545B RID: 21595
		OnReceiveChampionshipScoreFightRecordMessage,
		// Token: 0x0400545C RID: 21596
		OnReceiveChampionshipKnockoutScoreMessage,
		// Token: 0x0400545D RID: 21597
		OnReceiveChampionshipFightCountDownTimeStampMessage,
		// Token: 0x0400545E RID: 21598
		OnReceiveChampionshipNotEnterFightSceneMessage,
		// Token: 0x0400545F RID: 21599
		OnReceiveChampionshipTop16PlayerMessage,
		// Token: 0x04005460 RID: 21600
		OnReceiveChampionshipFightRaceAllGroupMessage,
		// Token: 0x04005461 RID: 21601
		OnReceiveChampionshipFightRaceSyncGroupMessage,
		// Token: 0x04005462 RID: 21602
		OnReceiveChampionshipFightDetailRecordResMessage,
		// Token: 0x04005463 RID: 21603
		OnReceiveChampionshipGuessProjectResMessage,
		// Token: 0x04005464 RID: 21604
		OnReceiveChampionshipBetResMessage,
		// Token: 0x04005465 RID: 21605
		OnReceiveChampionshipAlreadyBetNumberMessage,
		// Token: 0x04005466 RID: 21606
		OnReceiveChampionshipGuessRecordMessage,
		// Token: 0x04005467 RID: 21607
		OnReceiveChampionshipUpdateGuessBetRedPointMessage,
		// Token: 0x04005468 RID: 21608
		OnPullRecordsSuccessed,
		// Token: 0x04005469 RID: 21609
		OnReceiveCoinDealTradeItemMessageRes,
		// Token: 0x0400546A RID: 21610
		OnReceiveCoinDealCloseMarketTimeUpdateMessage,
		// Token: 0x0400546B RID: 21611
		OnReceiveCoinDealAveragePriceUpdateMessage,
		// Token: 0x0400546C RID: 21612
		OnReceiveCoinDealTodayPriceValueUpdateMessage,
		// Token: 0x0400546D RID: 21613
		OnReceiveCoinDealOwnerOrderNumberUpdateMessage,
		// Token: 0x0400546E RID: 21614
		OnReceiveCoinDealRecordMessageRes,
		// Token: 0x0400546F RID: 21615
		OnReceiveCoinDealOwnerOrderMessageRes,
		// Token: 0x04005470 RID: 21616
		OnReceiveCoinDealCancelOrderMessageRes,
		// Token: 0x04005471 RID: 21617
		OnReceiveCoinDealTradeSucceedNotifyMessage,
		// Token: 0x04005472 RID: 21618
		OnReceiveCoinDealRequestTradeItemData,
		// Token: 0x04005473 RID: 21619
		OnReceiveCoinDealRequestMyOrderItemData,
		// Token: 0x04005474 RID: 21620
		OnReceiveCoinDealRequestRecordItemData,
		// Token: 0x04005475 RID: 21621
		OnReceiveCoinDealUpdateRedPointMessage,
		// Token: 0x04005476 RID: 21622
		OnReceiveCoinDealCreditPointRecordDetailMessage,
		// Token: 0x04005477 RID: 21623
		OnReceiveCoinDealCreditPointRecordUpdateMessage,
		// Token: 0x04005478 RID: 21624
		OnReceiveCoinDealServerFuncSwitchChangeMessage,
		// Token: 0x04005479 RID: 21625
		OnReceiveCoinDealSwitchToMyOrderTabMessage,
		// Token: 0x0400547A RID: 21626
		OnReceiveCoinDealRefreshCloseMarketControlMessage,
		// Token: 0x0400547B RID: 21627
		OnTeamMateDropSS,
		// Token: 0x0400547C RID: 21628
		OnShowTownPlayerHalo,
		// Token: 0x0400547D RID: 21629
		OnAnniversaryCounterChange,
		// Token: 0x0400547E RID: 21630
		OnAnniversaryTimeUpdate,
		// Token: 0x0400547F RID: 21631
		OnAnniversaryEnterGame,
		// Token: 0x04005480 RID: 21632
		OnAnnviversaryGameStart,
		// Token: 0x04005481 RID: 21633
		OnHidePauseButton,
		// Token: 0x04005482 RID: 21634
		OnCountDownStart,
		// Token: 0x04005483 RID: 21635
		OnCountDownUpdate
	}
}
