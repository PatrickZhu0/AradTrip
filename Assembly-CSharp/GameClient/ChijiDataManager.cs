using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001139 RID: 4409
	public class ChijiDataManager : DataManager<ChijiDataManager>
	{
		// Token: 0x170019C8 RID: 6600
		// (get) Token: 0x0600A767 RID: 42855 RVA: 0x0022E9F6 File Offset: 0x0022CDF6
		// (set) Token: 0x0600A768 RID: 42856 RVA: 0x0022E9FE File Offset: 0x0022CDFE
		public int PrepareScenePlayerNum
		{
			get
			{
				return this.m_PrepareScenePlayerNum;
			}
			set
			{
				this.m_PrepareScenePlayerNum = value;
			}
		}

		// Token: 0x170019C9 RID: 6601
		// (get) Token: 0x0600A769 RID: 42857 RVA: 0x0022EA07 File Offset: 0x0022CE07
		public int PrepareSceneMaxPlayerNum
		{
			get
			{
				return this.m_PrepareSceneMaxPlayerNum;
			}
		}

		// Token: 0x170019CA RID: 6602
		// (get) Token: 0x0600A76A RID: 42858 RVA: 0x0022EA0F File Offset: 0x0022CE0F
		// (set) Token: 0x0600A76B RID: 42859 RVA: 0x0022EA17 File Offset: 0x0022CE17
		public bool SwitchingTownToPrepare
		{
			get
			{
				return this.m_SwitchingTownToPrepare;
			}
			set
			{
				this.m_SwitchingTownToPrepare = value;
			}
		}

		// Token: 0x170019CB RID: 6603
		// (get) Token: 0x0600A76C RID: 42860 RVA: 0x0022EA20 File Offset: 0x0022CE20
		// (set) Token: 0x0600A76D RID: 42861 RVA: 0x0022EA28 File Offset: 0x0022CE28
		public bool SwitchingPrepareToTown
		{
			get
			{
				return this.m_SwitchingPrepareToTown;
			}
			set
			{
				this.m_SwitchingPrepareToTown = value;
			}
		}

		// Token: 0x170019CC RID: 6604
		// (get) Token: 0x0600A76E RID: 42862 RVA: 0x0022EA31 File Offset: 0x0022CE31
		// (set) Token: 0x0600A76F RID: 42863 RVA: 0x0022EA39 File Offset: 0x0022CE39
		public bool SwitchingPrepareToChijiScene
		{
			get
			{
				return this.m_SwitchingPrepareToChijiScene;
			}
			set
			{
				this.m_SwitchingPrepareToChijiScene = value;
			}
		}

		// Token: 0x170019CD RID: 6605
		// (get) Token: 0x0600A770 RID: 42864 RVA: 0x0022EA42 File Offset: 0x0022CE42
		// (set) Token: 0x0600A771 RID: 42865 RVA: 0x0022EA4A File Offset: 0x0022CE4A
		public bool SwitchingChijiSceneToPrepare
		{
			get
			{
				return this.m_SwitchingChijiSceneToPrepare;
			}
			set
			{
				this.m_SwitchingChijiSceneToPrepare = value;
			}
		}

		// Token: 0x170019CE RID: 6606
		// (get) Token: 0x0600A772 RID: 42866 RVA: 0x0022EA53 File Offset: 0x0022CE53
		public List<ulong> OtherDeadPlayers
		{
			get
			{
				return this.m_otherPlayerDead;
			}
		}

		// Token: 0x170019CF RID: 6607
		// (get) Token: 0x0600A773 RID: 42867 RVA: 0x0022EA5B File Offset: 0x0022CE5B
		public uint ChijiBattleID
		{
			get
			{
				return this.m_ChijiBattleID;
			}
		}

		// Token: 0x170019D0 RID: 6608
		// (get) Token: 0x0600A774 RID: 42868 RVA: 0x0022EA63 File Offset: 0x0022CE63
		public ChiJiTimeTable.eBattleStage CurBattleStage
		{
			get
			{
				return this.m_CurBattleStage;
			}
		}

		// Token: 0x170019D1 RID: 6609
		// (get) Token: 0x0600A775 RID: 42869 RVA: 0x0022EA6B File Offset: 0x0022CE6B
		public uint[] StageStartTimeList
		{
			get
			{
				return this.m_StageStartTimeList;
			}
		}

		// Token: 0x170019D2 RID: 6610
		// (get) Token: 0x0600A776 RID: 42870 RVA: 0x0022EA73 File Offset: 0x0022CE73
		// (set) Token: 0x0600A777 RID: 42871 RVA: 0x0022EA7B File Offset: 0x0022CE7B
		public SettlementInfo Settlementinfo
		{
			get
			{
				return this.m_Settlementinfo;
			}
			set
			{
				this.m_Settlementinfo = value;
			}
		}

		// Token: 0x170019D3 RID: 6611
		// (get) Token: 0x0600A778 RID: 42872 RVA: 0x0022EA84 File Offset: 0x0022CE84
		// (set) Token: 0x0600A779 RID: 42873 RVA: 0x0022EA8C File Offset: 0x0022CE8C
		public bool GuardForSettlement
		{
			get
			{
				return this.m_bGuardForSettlement;
			}
			set
			{
				this.m_bGuardForSettlement = value;
			}
		}

		// Token: 0x170019D4 RID: 6612
		// (get) Token: 0x0600A77A RID: 42874 RVA: 0x0022EA95 File Offset: 0x0022CE95
		// (set) Token: 0x0600A77B RID: 42875 RVA: 0x0022EA9D File Offset: 0x0022CE9D
		public bool GuardForPickUpOtherPlayerItems
		{
			get
			{
				return this.m_bGuardForPickUpOtherPlayerItems;
			}
			set
			{
				this.m_bGuardForPickUpOtherPlayerItems = value;
			}
		}

		// Token: 0x170019D5 RID: 6613
		// (get) Token: 0x0600A77C RID: 42876 RVA: 0x0022EAA6 File Offset: 0x0022CEA6
		public ChijiOtherPlayerItems OtherPlayerItems
		{
			get
			{
				return this.m_OtherPlayerItems;
			}
		}

		// Token: 0x170019D6 RID: 6614
		// (get) Token: 0x0600A77D RID: 42877 RVA: 0x0022EAAE File Offset: 0x0022CEAE
		public int SurvivePlayerNum
		{
			get
			{
				return this.m_SurvivePlayerNum;
			}
		}

		// Token: 0x170019D7 RID: 6615
		// (get) Token: 0x0600A77E RID: 42878 RVA: 0x0022EAB6 File Offset: 0x0022CEB6
		// (set) Token: 0x0600A77F RID: 42879 RVA: 0x0022EABE File Offset: 0x0022CEBE
		public uint BattleDungeonId
		{
			get
			{
				return this.m_BattleDungeonId;
			}
			set
			{
				this.m_BattleDungeonId = value;
			}
		}

		// Token: 0x170019D8 RID: 6616
		// (get) Token: 0x0600A780 RID: 42880 RVA: 0x0022EAC7 File Offset: 0x0022CEC7
		// (set) Token: 0x0600A781 RID: 42881 RVA: 0x0022EACF File Offset: 0x0022CECF
		public byte BattleRaceType
		{
			get
			{
				return this.m_BattleRaceType;
			}
			set
			{
				this.m_BattleRaceType = value;
			}
		}

		// Token: 0x170019D9 RID: 6617
		// (get) Token: 0x0600A782 RID: 42882 RVA: 0x0022EAD8 File Offset: 0x0022CED8
		// (set) Token: 0x0600A783 RID: 42883 RVA: 0x0022EAE0 File Offset: 0x0022CEE0
		public ulong BattleFlag
		{
			get
			{
				return this.m_BattleFlag;
			}
			set
			{
				this.m_BattleFlag = value;
			}
		}

		// Token: 0x170019DA RID: 6618
		// (get) Token: 0x0600A784 RID: 42884 RVA: 0x0022EAE9 File Offset: 0x0022CEE9
		// (set) Token: 0x0600A785 RID: 42885 RVA: 0x0022EAF1 File Offset: 0x0022CEF1
		public ulong RecentKillPlayerID
		{
			get
			{
				return this.m_RecentKillPlayerID;
			}
			set
			{
				this.m_RecentKillPlayerID = value;
			}
		}

		// Token: 0x170019DB RID: 6619
		// (get) Token: 0x0600A786 RID: 42886 RVA: 0x0022EAFA File Offset: 0x0022CEFA
		// (set) Token: 0x0600A787 RID: 42887 RVA: 0x0022EB02 File Offset: 0x0022CF02
		public ulong SessionId
		{
			get
			{
				return this.m_SessionId;
			}
			set
			{
				this.m_SessionId = value;
			}
		}

		// Token: 0x170019DC RID: 6620
		// (get) Token: 0x0600A788 RID: 42888 RVA: 0x0022EB0B File Offset: 0x0022CF0B
		public PoisonRingInfo PoisonRing
		{
			get
			{
				return this.m_poisonRing;
			}
		}

		// Token: 0x170019DD RID: 6621
		// (get) Token: 0x0600A789 RID: 42889 RVA: 0x0022EB13 File Offset: 0x0022CF13
		public bool IsMainPlayerDead
		{
			get
			{
				return this.m_isMainPlayerDead;
			}
		}

		// Token: 0x170019DE RID: 6622
		// (get) Token: 0x0600A78A RID: 42890 RVA: 0x0022EB1B File Offset: 0x0022CF1B
		public List<JoinPlayerInfo> JoinPlayerInfoList
		{
			get
			{
				return this.m_JoinPlayerInfoList;
			}
		}

		// Token: 0x170019DF RID: 6623
		// (get) Token: 0x0600A78B RID: 42891 RVA: 0x0022EB23 File Offset: 0x0022CF23
		public List<PlayerDeathReason> ShowDeathPlayerList
		{
			get
			{
				return this.m_ShowDeathPlayerList;
			}
		}

		// Token: 0x170019E0 RID: 6624
		// (get) Token: 0x0600A78C RID: 42892 RVA: 0x0022EB2B File Offset: 0x0022CF2B
		public List<BattleNpc> NpcDataList
		{
			get
			{
				return this.m_NpcDataList;
			}
		}

		// Token: 0x170019E1 RID: 6625
		// (get) Token: 0x0600A78D RID: 42893 RVA: 0x0022EB33 File Offset: 0x0022CF33
		// (set) Token: 0x0600A78E RID: 42894 RVA: 0x0022EB3B File Offset: 0x0022CF3B
		public SceneMatchPkRaceEnd PkEndData
		{
			get
			{
				return this.m_pkEndData;
			}
			set
			{
				this.m_pkEndData = value;
			}
		}

		// Token: 0x170019E2 RID: 6626
		// (get) Token: 0x0600A78F RID: 42895 RVA: 0x0022EB44 File Offset: 0x0022CF44
		// (set) Token: 0x0600A790 RID: 42896 RVA: 0x0022EB4C File Offset: 0x0022CF4C
		public bool GuardForPkEndData
		{
			get
			{
				return this.m_bGuardForPkEndData;
			}
			set
			{
				this.m_bGuardForPkEndData = value;
			}
		}

		// Token: 0x170019E3 RID: 6627
		// (get) Token: 0x0600A791 RID: 42897 RVA: 0x0022EB55 File Offset: 0x0022CF55
		// (set) Token: 0x0600A792 RID: 42898 RVA: 0x0022EB5D File Offset: 0x0022CF5D
		public bool IsMatching
		{
			get
			{
				return this.m_IsMatching;
			}
			set
			{
				this.m_IsMatching = value;
			}
		}

		// Token: 0x170019E4 RID: 6628
		// (get) Token: 0x0600A793 RID: 42899 RVA: 0x0022EB66 File Offset: 0x0022CF66
		// (set) Token: 0x0600A794 RID: 42900 RVA: 0x0022EB6E File Offset: 0x0022CF6E
		public bool IsToPrepareScene
		{
			get
			{
				return this.m_IsToPrepareScene;
			}
			set
			{
				this.m_IsToPrepareScene = value;
			}
		}

		// Token: 0x170019E5 RID: 6629
		// (get) Token: 0x0600A795 RID: 42901 RVA: 0x0022EB77 File Offset: 0x0022CF77
		public uint KillNum
		{
			get
			{
				return this.m_KillNum;
			}
		}

		// Token: 0x170019E6 RID: 6630
		// (get) Token: 0x0600A796 RID: 42902 RVA: 0x0022EB7F File Offset: 0x0022CF7F
		public uint SceneNodeId
		{
			get
			{
				return this.m_SceneNodeID;
			}
		}

		// Token: 0x170019E7 RID: 6631
		// (get) Token: 0x0600A797 RID: 42903 RVA: 0x0022EB87 File Offset: 0x0022CF87
		// (set) Token: 0x0600A798 RID: 42904 RVA: 0x0022EB8F File Offset: 0x0022CF8F
		public bool IsReadyPk
		{
			get
			{
				return this.m_IsReadyPk;
			}
			set
			{
				this.m_IsReadyPk = value;
			}
		}

		// Token: 0x170019E8 RID: 6632
		// (get) Token: 0x0600A799 RID: 42905 RVA: 0x0022EB98 File Offset: 0x0022CF98
		// (set) Token: 0x0600A79A RID: 42906 RVA: 0x0022EBA0 File Offset: 0x0022CFA0
		public int BestRank
		{
			get
			{
				return this.m_BestRank;
			}
			set
			{
				this.m_BestRank = value;
			}
		}

		// Token: 0x170019E9 RID: 6633
		// (get) Token: 0x0600A79B RID: 42907 RVA: 0x0022EBA9 File Offset: 0x0022CFA9
		// (set) Token: 0x0600A79C RID: 42908 RVA: 0x0022EBB1 File Offset: 0x0022CFB1
		public int CurrentUseDrugId { get; set; }

		// Token: 0x170019EA RID: 6634
		// (get) Token: 0x0600A79D RID: 42909 RVA: 0x0022EBBA File Offset: 0x0022CFBA
		// (set) Token: 0x0600A79E RID: 42910 RVA: 0x0022EBC2 File Offset: 0x0022CFC2
		public ISceneData sceneData { get; set; }

		// Token: 0x170019EB RID: 6635
		// (get) Token: 0x0600A79F RID: 42911 RVA: 0x0022EBCB File Offset: 0x0022CFCB
		public float MainRoleSyncPosInterval
		{
			get
			{
				return this.m_mainRolePosSyncInterval;
			}
		}

		// Token: 0x0600A7A0 RID: 42912 RVA: 0x0022EBD3 File Offset: 0x0022CFD3
		public void DoDead()
		{
			this.m_isMainPlayerDead = true;
		}

		// Token: 0x0600A7A1 RID: 42913 RVA: 0x0022EBDC File Offset: 0x0022CFDC
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600A7A2 RID: 42914 RVA: 0x0022EBE0 File Offset: 0x0022CFE0
		public override void Initialize()
		{
			this.Clear();
			this._BindNetMsg();
			this._BindUIEvent();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ChiJiTimeTable>();
			if (table != null && this.m_StageStartTimeList == null)
			{
				this.m_StageStartTimeList = new uint[table.Count];
			}
			ActivityDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActivityDungeonTable>(24, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.ChijiActivityIDs = new int[tableItem.ActivityID.Length];
				for (int i = 0; i < tableItem.ActivityID.Length; i++)
				{
					this.ChijiActivityIDs[i] = tableItem.ActivityID[i];
				}
			}
		}

		// Token: 0x0600A7A3 RID: 42915 RVA: 0x0022EC8F File Offset: 0x0022D08F
		public override void Clear()
		{
			this._UnBindNetMsg();
			this._UnBindUIEvent();
			this.ClearChijiSceneData();
			this.ClearPrepareSceneData();
		}

		// Token: 0x0600A7A4 RID: 42916 RVA: 0x0022ECA9 File Offset: 0x0022D0A9
		public void ClearBattleData()
		{
			this.m_BattleDungeonId = 0U;
			this.m_BattleRaceType = 0;
			this.m_BattleFlag = 0UL;
			if (this.m_pkEndData != null)
			{
				this.m_pkEndData = null;
			}
			this.m_bGuardForPkEndData = false;
			this.m_SessionId = 0UL;
			this.m_IsReadyPk = false;
		}

		// Token: 0x0600A7A5 RID: 42917 RVA: 0x0022ECEC File Offset: 0x0022D0EC
		public void ClearChijiSceneData()
		{
			this.ClearBattleData();
			this.m_mainRolePosSyncInterval = 0.05f;
			this.m_ChijiBattleID = 0U;
			this.m_otherPlayerDead.Clear();
			this.m_isMainPlayerDead = false;
			DataManager<PlayerBaseData>.GetInstance().BuffMgr.Clear();
			this.m_CurBattleStage = ChiJiTimeTable.eBattleStage.BS_NONE;
			this.m_SurvivePlayerNum = 0;
			this.m_poisonRing.Reset();
			if (this.m_StageStartTimeList != null)
			{
				for (int i = 0; i < this.m_StageStartTimeList.Length; i++)
				{
					this.m_StageStartTimeList[i] = 0U;
				}
			}
			this.m_bGuardForPickUpOtherPlayerItems = false;
			this.m_OtherPlayerItems.ClearData();
			this.m_JoinPlayerInfoList.Clear();
			this.m_ShowDeathPlayerList.Clear();
			this.m_NpcDataList.Clear();
			this.m_RecentKillPlayerID = 0UL;
			this.m_KillNum = 0U;
			this.m_IsMatching = false;
			this.m_IsReadyPk = false;
		}

		// Token: 0x0600A7A6 RID: 42918 RVA: 0x0022EDC8 File Offset: 0x0022D1C8
		public void ClearAllRelatedSystemData()
		{
			this.ClearChijiSceneData();
			DataManager<BattleDataManager>.GetInstance().PkRaceType = RaceType.Dungeon;
			DataManager<PlayerBaseData>.GetInstance().ClearChijiData();
			DataManager<ItemDataManager>.GetInstance().ClearChijiData();
			DataManager<SkillDataManager>.GetInstance().ClearChijiSkill();
			DataManager<PetDataManager>.GetInstance().ClearChijiPetData();
			SystemNotifyManager.Clear();
		}

		// Token: 0x0600A7A7 RID: 42919 RVA: 0x0022EE08 File Offset: 0x0022D208
		public void ClearPrepareSceneData()
		{
			this.m_PrepareScenePlayerNum = 0;
			this.m_PrepareSceneMaxPlayerNum = 0;
			this.m_IsToPrepareScene = false;
			this.m_BestRank = 0;
			this.sceneData = null;
		}

		// Token: 0x0600A7A8 RID: 42920 RVA: 0x0022EE2D File Offset: 0x0022D22D
		public void ClearPlayerIntrinsicData()
		{
			DataManager<ItemDataManager>.GetInstance().ClearChijiData();
			DataManager<SkillDataManager>.GetInstance().ClearChijiSkill();
			DataManager<PetDataManager>.GetInstance().ClearChijiPetData();
			SystemNotifyManager.Clear();
		}

		// Token: 0x0600A7A9 RID: 42921 RVA: 0x0022EE54 File Offset: 0x0022D254
		private void _BindNetMsg()
		{
			if (!this.m_bNetBind)
			{
				NetProcess.AddMsgHandler(2200009U, new Action<MsgDATA>(this._OnNotifyChijiPrepareInfo));
				NetProcess.AddMsgHandler(2200006U, new Action<MsgDATA>(this._OnBattleEnrollRes));
				NetProcess.AddMsgHandler(508906U, new Action<MsgDATA>(this._OnSceneBattleMatchSync));
				NetProcess.AddMsgHandler(508948U, new Action<MsgDATA>(this._OnOccuListRes));
				NetProcess.AddMsgHandler(508914U, new Action<MsgDATA>(this._OnRecvSelectOccuRes));
				NetProcess.AddMsgHandler(508917U, new Action<MsgDATA>(this._OnRecvBirthTransfer));
				NetProcess.AddMsgHandler(508910U, new Action<MsgDATA>(this._OnRecvPoisionRing));
				NetProcess.AddMsgHandler(508902U, new Action<MsgDATA>(this._OnPickUpBuffItemRes));
				NetProcess.AddMsgHandler(500626U, new Action<MsgDATA>(this._OnSyncSceneItemAdd));
				NetProcess.AddMsgHandler(500627U, new Action<MsgDATA>(this._OnSyncSceneItemDel));
				NetProcess.AddMsgHandler(508918U, new Action<MsgDATA>(this._OnSyncBattleWaveInfo));
				NetProcess.AddMsgHandler(508905U, new Action<MsgDATA>(this._OnBattleBalanceEnd));
				NetProcess.AddMsgHandler(508921U, new Action<MsgDATA>(this._OnBattleThrowSomeOne));
				NetProcess.AddMsgHandler(508919U, new Action<MsgDATA>(this._OnBattleSomeOneDead));
				NetProcess.AddMsgHandler(508915U, new Action<MsgDATA>(this._OnPickUpOthersItem));
				NetProcess.AddMsgHandler(508912U, new Action<MsgDATA>(this._OnPickUpSpoilsRes));
				NetProcess.AddMsgHandler(2200008U, new Action<MsgDATA>(this._OnPkSomeOneRes));
				NetProcess.AddMsgHandler(508929U, new Action<MsgDATA>(this._OnNpcNotify));
				NetProcess.AddMsgHandler(508931U, new Action<MsgDATA>(this._OnNpcTradeRes));
				NetProcess.AddMsgHandler(508936U, new Action<MsgDATA>(this._OnOpenBoxRes));
				NetProcess.AddMsgHandler(508934U, new Action<MsgDATA>(this._OnTrapPlaced));
				NetProcess.AddMsgHandler(508932U, new Action<MsgDATA>(this._OnTrapTriggered));
				NetProcess.AddMsgHandler(508937U, new Action<MsgDATA>(this._OnNotifyBestRank));
				NetProcess.AddMsgHandler(508939U, new Action<MsgDATA>(this._OnNotifySkillChoiceList));
				NetProcess.AddMsgHandler(508941U, new Action<MsgDATA>(this._OnChoiceSkillRes));
				NetProcess.AddMsgHandler(508949U, new Action<MsgDATA>(this._OnEquipChoiceListRes));
				NetProcess.AddMsgHandler(508951U, new Action<MsgDATA>(this._OnChoiceEquipRes));
				NetProcess.AddMsgHandler(508942U, new Action<MsgDATA>(this._OnNotifyNoWarOption));
				NetProcess.AddMsgHandler(508946U, new Action<MsgDATA>(this._OnNotifyNoWarWait));
				NetProcess.AddMsgHandler(508944U, new Action<MsgDATA>(this._OnNotifyNoWarChoiceRes));
				NetProcess.AddMsgHandler(508945U, new Action<MsgDATA>(this._OnNoWarNotify));
				NetProcess.AddMsgHandler(2200022U, new Action<MsgDATA>(this._onSyncMainRolePosInterval));
				this.m_bNetBind = true;
			}
		}

		// Token: 0x0600A7AA RID: 42922 RVA: 0x0022F134 File Offset: 0x0022D534
		private void _UnBindNetMsg()
		{
			NetProcess.RemoveMsgHandler(2200009U, new Action<MsgDATA>(this._OnNotifyChijiPrepareInfo));
			NetProcess.RemoveMsgHandler(2200006U, new Action<MsgDATA>(this._OnBattleEnrollRes));
			NetProcess.RemoveMsgHandler(508906U, new Action<MsgDATA>(this._OnSceneBattleMatchSync));
			NetProcess.RemoveMsgHandler(508948U, new Action<MsgDATA>(this._OnOccuListRes));
			NetProcess.RemoveMsgHandler(508914U, new Action<MsgDATA>(this._OnRecvSelectOccuRes));
			NetProcess.RemoveMsgHandler(508917U, new Action<MsgDATA>(this._OnRecvBirthTransfer));
			NetProcess.RemoveMsgHandler(508910U, new Action<MsgDATA>(this._OnRecvPoisionRing));
			NetProcess.RemoveMsgHandler(508902U, new Action<MsgDATA>(this._OnPickUpBuffItemRes));
			NetProcess.RemoveMsgHandler(500626U, new Action<MsgDATA>(this._OnSyncSceneItemAdd));
			NetProcess.RemoveMsgHandler(500627U, new Action<MsgDATA>(this._OnSyncSceneItemDel));
			NetProcess.RemoveMsgHandler(508918U, new Action<MsgDATA>(this._OnSyncBattleWaveInfo));
			NetProcess.RemoveMsgHandler(508905U, new Action<MsgDATA>(this._OnBattleBalanceEnd));
			NetProcess.RemoveMsgHandler(508921U, new Action<MsgDATA>(this._OnBattleThrowSomeOne));
			NetProcess.RemoveMsgHandler(508919U, new Action<MsgDATA>(this._OnBattleSomeOneDead));
			NetProcess.RemoveMsgHandler(508915U, new Action<MsgDATA>(this._OnPickUpOthersItem));
			NetProcess.RemoveMsgHandler(508912U, new Action<MsgDATA>(this._OnPickUpSpoilsRes));
			NetProcess.RemoveMsgHandler(2200008U, new Action<MsgDATA>(this._OnPkSomeOneRes));
			NetProcess.RemoveMsgHandler(508929U, new Action<MsgDATA>(this._OnNpcNotify));
			NetProcess.RemoveMsgHandler(508931U, new Action<MsgDATA>(this._OnNpcTradeRes));
			NetProcess.RemoveMsgHandler(508936U, new Action<MsgDATA>(this._OnOpenBoxRes));
			NetProcess.RemoveMsgHandler(508934U, new Action<MsgDATA>(this._OnTrapPlaced));
			NetProcess.RemoveMsgHandler(508932U, new Action<MsgDATA>(this._OnTrapTriggered));
			NetProcess.RemoveMsgHandler(508937U, new Action<MsgDATA>(this._OnNotifyBestRank));
			NetProcess.RemoveMsgHandler(508939U, new Action<MsgDATA>(this._OnNotifySkillChoiceList));
			NetProcess.RemoveMsgHandler(508941U, new Action<MsgDATA>(this._OnChoiceSkillRes));
			NetProcess.RemoveMsgHandler(508949U, new Action<MsgDATA>(this._OnEquipChoiceListRes));
			NetProcess.RemoveMsgHandler(508951U, new Action<MsgDATA>(this._OnChoiceEquipRes));
			NetProcess.RemoveMsgHandler(508942U, new Action<MsgDATA>(this._OnNotifyNoWarOption));
			NetProcess.RemoveMsgHandler(508946U, new Action<MsgDATA>(this._OnNotifyNoWarWait));
			NetProcess.RemoveMsgHandler(508944U, new Action<MsgDATA>(this._OnNotifyNoWarChoiceRes));
			NetProcess.RemoveMsgHandler(508945U, new Action<MsgDATA>(this._OnNoWarNotify));
			NetProcess.RemoveMsgHandler(2200022U, new Action<MsgDATA>(this._onSyncMainRolePosInterval));
			this.m_bNetBind = false;
		}

		// Token: 0x0600A7AB RID: 42923 RVA: 0x0022F408 File Offset: 0x0022D808
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChijiPkReadyFinish, new ClientEventSystem.UIEventHandler(this._OnChijiPkReadyFinish));
		}

		// Token: 0x0600A7AC RID: 42924 RVA: 0x0022F425 File Offset: 0x0022D825
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChijiPkReadyFinish, new ClientEventSystem.UIEventHandler(this._OnChijiPkReadyFinish));
		}

		// Token: 0x0600A7AD RID: 42925 RVA: 0x0022F444 File Offset: 0x0022D844
		private void _OnTrapPlaced(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnTrapPlaced ==>> msg is nil");
				return;
			}
			SceneBattlePlaceTrapsRes sceneBattlePlaceTrapsRes = new SceneBattlePlaceTrapsRes();
			sceneBattlePlaceTrapsRes.decode(msg.bytes);
			if (sceneBattlePlaceTrapsRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneBattlePlaceTrapsRes.retCode, string.Empty);
				return;
			}
		}

		// Token: 0x0600A7AE RID: 42926 RVA: 0x0022F490 File Offset: 0x0022D890
		private void _OnTrapTriggered(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnTrapTriggered ==>> msg is nil");
				return;
			}
			SceneBattleNotifyBeTraped res = new SceneBattleNotifyBeTraped();
			res.decode(msg.bytes);
			if (res.battleID != this.m_ChijiBattleID)
			{
				Logger.LogErrorFormat(string.Format("吃鸡battleid不一致，Cur ChijiBattleID = {0}, msgData.battleID = {1},协议:[SceneItemAdd]", this.m_ChijiBattleID, res.battleID), new object[0]);
				return;
			}
			if (res.ownerID == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				JoinPlayerInfo joinPlayerInfo = this.m_JoinPlayerInfoList.Find((JoinPlayerInfo x) => x.playerId == res.playerID);
				if (joinPlayerInfo != null)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(string.Format("{0}踩中了你的陷阱，受到当前血量30%伤害并定身", joinPlayerInfo.playerName), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
			}
			else
			{
				JoinPlayerInfo joinPlayerInfo2 = this.m_JoinPlayerInfoList.Find((JoinPlayerInfo x) => x.playerId == res.ownerID);
				if (joinPlayerInfo2 != null)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(string.Format("你踩中了{0}的陷阱，受到当前血量30%伤害并定身", joinPlayerInfo2.playerName), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
			}
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
			if (clientSystemGameBattle == null)
			{
				return;
			}
			clientSystemGameBattle.DoTrapEffect(res.x, res.y);
		}

		// Token: 0x0600A7AF RID: 42927 RVA: 0x0022F5D4 File Offset: 0x0022D9D4
		private void _OnPickUpBuffItemRes(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnPickUpItemRes ==>> msg is nil");
				return;
			}
			SceneBattleUseItemRes sceneBattleUseItemRes = new SceneBattleUseItemRes();
			sceneBattleUseItemRes.decode(msg.bytes);
			if (sceneBattleUseItemRes.code != 0U)
			{
				Logger.LogErrorFormat("[SceneBattleUseItemRes] error,error code= {0}", new object[]
				{
					sceneBattleUseItemRes.code
				});
			}
		}

		// Token: 0x0600A7B0 RID: 42928 RVA: 0x0022F630 File Offset: 0x0022DA30
		private void _OnSyncSceneItemAdd(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnSyncSceneItemAdd ==>> msg is nil");
				return;
			}
			SceneItemAdd sceneItemAdd = new SceneItemAdd();
			sceneItemAdd.decode(msg.bytes);
			if (sceneItemAdd.battleID != this.m_ChijiBattleID)
			{
				Logger.LogErrorFormat(string.Format("吃鸡battleid不一致，Cur ChijiBattleID = {0}, msgData.battleID = {1},协议:[SceneItemAdd]", this.m_ChijiBattleID, sceneItemAdd.battleID), new object[0]);
				return;
			}
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
			if (clientSystemGameBattle == null)
			{
				return;
			}
			clientSystemGameBattle.OnRecvSyncSceneItemAdd(sceneItemAdd);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NearItemsChanged, null, null, null, null);
		}

		// Token: 0x0600A7B1 RID: 42929 RVA: 0x0022F6D0 File Offset: 0x0022DAD0
		private void _OnSyncSceneItemDel(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnSyncSceneItemAdd ==>> msg is nil");
				return;
			}
			SceneItemDel sceneItemDel = new SceneItemDel();
			sceneItemDel.decode(msg.bytes);
			if (sceneItemDel.battleID != this.m_ChijiBattleID)
			{
				Logger.LogErrorFormat(string.Format("吃鸡battleid不一致，Cur ChijiBattleID = {0}, msgData.battleID = {1},协议:[SceneItemDel]", this.m_ChijiBattleID, sceneItemDel.battleID), new object[0]);
				return;
			}
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
			if (clientSystemGameBattle == null)
			{
				return;
			}
			clientSystemGameBattle.OnRecvSceneItemDel(sceneItemDel);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NearItemsChanged, null, null, null, null);
		}

		// Token: 0x0600A7B2 RID: 42930 RVA: 0x0022F770 File Offset: 0x0022DB70
		private void _OnNotifyChijiPrepareInfo(MsgDATA msg)
		{
			BattleNotifyPrepareInfo battleNotifyPrepareInfo = new BattleNotifyPrepareInfo();
			battleNotifyPrepareInfo.decode(msg.bytes);
			this.m_PrepareScenePlayerNum = (int)battleNotifyPrepareInfo.playerNum;
			this.m_PrepareSceneMaxPlayerNum = (int)battleNotifyPrepareInfo.totalNum;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateChijiPrepareScenePlayerNum, null, null, null, null);
		}

		// Token: 0x0600A7B3 RID: 42931 RVA: 0x0022F7BC File Offset: 0x0022DBBC
		private void _OnBattleEnrollRes(MsgDATA msg)
		{
			BattleEnrollRes battleEnrollRes = new BattleEnrollRes();
			battleEnrollRes.decode(msg.bytes);
			if (battleEnrollRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)battleEnrollRes.retCode, string.Empty);
				return;
			}
			if (battleEnrollRes.isMatch != 0U)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiSeekWaitingFrame>(FrameLayer.Middle, null, string.Empty);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiSeekWaitingFrame>(null, false);
			}
		}

		// Token: 0x0600A7B4 RID: 42932 RVA: 0x0022F828 File Offset: 0x0022DC28
		private void _OnOccuListRes(MsgDATA msg)
		{
			SceneBattleOccuListRes sceneBattleOccuListRes = new SceneBattleOccuListRes();
			sceneBattleOccuListRes.decode(msg.bytes);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SelectOccupationFrame>(FrameLayer.Middle, sceneBattleOccuListRes.occuList, string.Empty);
		}

		// Token: 0x0600A7B5 RID: 42933 RVA: 0x0022F860 File Offset: 0x0022DC60
		private void _OnRecvSelectOccuRes(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("onRecvSelectOccuRes ==>> msg is nil");
				return;
			}
			SceneBattleSelectOccuRes sceneBattleSelectOccuRes = new SceneBattleSelectOccuRes();
			sceneBattleSelectOccuRes.decode(msg.bytes);
			if (sceneBattleSelectOccuRes.retCode != 0U)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(string.Format("[onRecvSelectOccuRes] error Code: {0}", sceneBattleSelectOccuRes.retCode), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			SystemNotifyManager.SysNotifyFloatingEffect("选择职业成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600A7B6 RID: 42934 RVA: 0x0022F8C4 File Offset: 0x0022DCC4
		private void _OnRecvBirthTransfer(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("onRecvBirthTransfer ==>> msg is nil");
				return;
			}
			SceneBattleBirthTransferNotify sceneBattleBirthTransferNotify = new SceneBattleBirthTransferNotify();
			sceneBattleBirthTransferNotify.decode(msg.bytes);
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
			if (clientSystemGameBattle == null)
			{
				return;
			}
			if (clientSystemGameBattle.MainPlayer == null)
			{
				return;
			}
			float axisScale = DataManager<PlayerBaseData>.GetInstance().AxisScale;
			Vector3 vector;
			vector..ctor(sceneBattleBirthTransferNotify.birthPosX / axisScale, 0f, sceneBattleBirthTransferNotify.birthPosY / axisScale);
			if (sceneBattleBirthTransferNotify.playerID == clientSystemGameBattle.MainPlayer.ActorData.GUID)
			{
				DataManager<PlayerBaseData>.GetInstance().Pos = vector;
				clientSystemGameBattle.MainPlayer.ActorData.MoveData.ServerPosition = DataManager<PlayerBaseData>.GetInstance().Pos;
				SystemNotifyManager.SysNotifyFloatingEffect("传送成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				BeFighter fighter = clientSystemGameBattle.OtherFighters.GetFighter(sceneBattleBirthTransferNotify.playerID);
				if (fighter != null)
				{
					fighter.ActorData.MoveData.ServerPosition = vector;
				}
			}
		}

		// Token: 0x0600A7B7 RID: 42935 RVA: 0x0022F9C4 File Offset: 0x0022DDC4
		private void _OnRecvPoisionRing(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("onRecvPoisionRing ==>> msg is nil");
				return;
			}
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
			if (clientSystemGameBattle == null)
			{
				return;
			}
			SceneBattleSyncPoisonRing sceneBattleSyncPoisonRing = new SceneBattleSyncPoisonRing();
			sceneBattleSyncPoisonRing.decode(msg.bytes);
			if (sceneBattleSyncPoisonRing.battleID != this.m_ChijiBattleID)
			{
				return;
			}
			Vector2 vector;
			vector..ctor(sceneBattleSyncPoisonRing.x / clientSystemGameBattle.AxisScale, sceneBattleSyncPoisonRing.y / clientSystemGameBattle.AxisScale);
			Vector2 nextStageCenter;
			nextStageCenter..ctor(sceneBattleSyncPoisonRing.x1 / clientSystemGameBattle.AxisScale, sceneBattleSyncPoisonRing.y1 / clientSystemGameBattle.AxisScale);
			float nextStageRadius = sceneBattleSyncPoisonRing.radius1 / clientSystemGameBattle.AxisScale;
			this.m_poisonRing.lastCenter = this.m_poisonRing.center;
			this.m_poisonRing.lastRadius = this.m_poisonRing.radius;
			this.m_poisonRing.center = vector;
			this.m_poisonRing.durTime = sceneBattleSyncPoisonRing.beginTimestamp;
			this.m_poisonRing.radius = sceneBattleSyncPoisonRing.radius / clientSystemGameBattle.AxisScale;
			this.m_poisonRing.shrinkTime = sceneBattleSyncPoisonRing.interval;
			this.m_poisonRing.nextStageCenter = nextStageCenter;
			this.m_poisonRing.nextStageRadius = nextStageRadius;
			Logger.LogErrorFormat("_OnRecvPoisionRing Posison Ring x {0} y {1} radius {2} timeStamp {3} durTime {4} nextStage x {5} y {6} nextRadius {7}", new object[]
			{
				sceneBattleSyncPoisonRing.x,
				sceneBattleSyncPoisonRing.y,
				sceneBattleSyncPoisonRing.radius,
				sceneBattleSyncPoisonRing.beginTimestamp,
				sceneBattleSyncPoisonRing.interval,
				sceneBattleSyncPoisonRing.x1,
				sceneBattleSyncPoisonRing.y1,
				sceneBattleSyncPoisonRing.radius1
			});
			clientSystemGameBattle.SetPoisonRing((int)sceneBattleSyncPoisonRing.x, (int)sceneBattleSyncPoisonRing.y, (int)sceneBattleSyncPoisonRing.radius, sceneBattleSyncPoisonRing.beginTimestamp, (int)sceneBattleSyncPoisonRing.interval, this.m_poisonRing.lastCenter, this.m_poisonRing.lastRadius);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BlueCircleChange, vector, sceneBattleSyncPoisonRing.radius / clientSystemGameBattle.AxisScale, sceneBattleSyncPoisonRing.beginTimestamp, sceneBattleSyncPoisonRing.interval);
		}

		// Token: 0x0600A7B8 RID: 42936 RVA: 0x0022FC08 File Offset: 0x0022E008
		private void _OnSceneBattleMatchSync(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnBattleMatchSync ==>> msg is nil");
				return;
			}
			SceneBattleMatchSync sceneBattleMatchSync = new SceneBattleMatchSync();
			sceneBattleMatchSync.decode(msg.bytes);
			this.m_ChijiBattleID = sceneBattleMatchSync.battleID;
			this.m_SurvivePlayerNum = (int)sceneBattleMatchSync.suvivalNum;
			this.m_SceneNodeID = sceneBattleMatchSync.sceneNodeID;
			this.m_JoinPlayerInfoList.Clear();
			for (int i = 0; i < sceneBattleMatchSync.players.Length; i++)
			{
				JoinPlayerInfo joinPlayerInfo = new JoinPlayerInfo();
				joinPlayerInfo.accId = sceneBattleMatchSync.players[i].accId;
				joinPlayerInfo.playerId = sceneBattleMatchSync.players[i].playerId;
				joinPlayerInfo.playerName = sceneBattleMatchSync.players[i].playerName;
				joinPlayerInfo.occu = sceneBattleMatchSync.players[i].occu;
				this.m_JoinPlayerInfoList.Add(joinPlayerInfo);
			}
			Utility.SwitchToChiJiRoom();
		}

		// Token: 0x0600A7B9 RID: 42937 RVA: 0x0022FCE4 File Offset: 0x0022E0E4
		private void _OnSyncBattleWaveInfo(MsgDATA msg)
		{
			SceneBattleNotifyWaveInfo sceneBattleNotifyWaveInfo = new SceneBattleNotifyWaveInfo();
			sceneBattleNotifyWaveInfo.decode(msg.bytes);
			if (sceneBattleNotifyWaveInfo.battleID != this.m_ChijiBattleID)
			{
				Logger.LogErrorFormat(string.Format("吃鸡battleid不一致，Cur ChijiBattleID = {0}, msgData.battleID = {1},协议:[SceneBattleNotifyWaveInfo]", this.m_ChijiBattleID, sceneBattleNotifyWaveInfo.battleID), new object[0]);
				return;
			}
			this.m_CurBattleStage = (ChiJiTimeTable.eBattleStage)sceneBattleNotifyWaveInfo.waveID;
			if (this.m_StageStartTimeList != null && this.m_CurBattleStage < (ChiJiTimeTable.eBattleStage)this.m_StageStartTimeList.Length)
			{
				this.m_StageStartTimeList[(int)this.m_CurBattleStage] = DataManager<TimeManager>.GetInstance().GetServerTime();
			}
			if (this.m_CurBattleStage == ChiJiTimeTable.eBattleStage.BS_PREPARE_TIME)
			{
				SystemNotifyManager.SystemNotify(11000, string.Empty);
			}
			else if (this.m_CurBattleStage == ChiJiTimeTable.eBattleStage.BS_START_PK)
			{
				SystemNotifyManager.SystemNotify(11002, string.Empty);
			}
			else if (this.m_CurBattleStage == ChiJiTimeTable.eBattleStage.BS_PUT_ITEM_1 || this.m_CurBattleStage == ChiJiTimeTable.eBattleStage.BS_PUT_ITEM_2 || this.m_CurBattleStage == ChiJiTimeTable.eBattleStage.BS_PUT_ITEM_3)
			{
				SystemNotifyManager.SystemNotify(11001, string.Empty);
			}
			else if (this.m_CurBattleStage == ChiJiTimeTable.eBattleStage.BS_SAFE_AREA_1 || this.m_CurBattleStage == ChiJiTimeTable.eBattleStage.BS_SAFE_AREA_2 || this.m_CurBattleStage == ChiJiTimeTable.eBattleStage.BS_SAFE_AREA_3)
			{
				SystemNotifyManager.SystemNotify(11003, string.Empty);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChijiBattleStageChanged, null, null, null, null);
		}

		// Token: 0x0600A7BA RID: 42938 RVA: 0x0022FE44 File Offset: 0x0022E244
		private void _OnBattleBalanceEnd(MsgDATA msg)
		{
			SceneBattleBalanceEnd sceneBattleBalanceEnd = new SceneBattleBalanceEnd();
			sceneBattleBalanceEnd.decode(msg.bytes);
			if (sceneBattleBalanceEnd.battleID != this.m_ChijiBattleID && this.m_ChijiBattleID != 0U)
			{
				Logger.LogErrorFormat("吃鸡时序测试----收到服务器结算消息ID不一致 battleID {0} ChijiBattleID {1}", new object[]
				{
					sceneBattleBalanceEnd.battleID,
					this.m_ChijiBattleID
				});
				return;
			}
			this.m_Settlementinfo.ClearData();
			this.m_Settlementinfo.rank = sceneBattleBalanceEnd.rank;
			this.m_Settlementinfo.playerNum = sceneBattleBalanceEnd.playerNum;
			this.m_Settlementinfo.kills = sceneBattleBalanceEnd.kills;
			this.m_Settlementinfo.survivalTime = sceneBattleBalanceEnd.survivalTime;
			this.m_Settlementinfo.score = sceneBattleBalanceEnd.score;
			this.m_Settlementinfo.glory = sceneBattleBalanceEnd.getHonor;
			bool flag = false;
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
			if (clientSystemGameBattle != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemGameBattle.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.SceneSubType == CitySceneTable.eSceneSubType.Battle)
				{
					flag = true;
				}
			}
			if (flag && !this.SwitchingChijiSceneToPrepare)
			{
				this.OpenSettlementFrame();
			}
			else
			{
				this.m_bGuardForSettlement = true;
			}
		}

		// Token: 0x0600A7BB RID: 42939 RVA: 0x0022FF88 File Offset: 0x0022E388
		private void _OnBattleThrowSomeOne(MsgDATA msg)
		{
			SceneBattleThrowSomeoneItemRes sceneBattleThrowSomeoneItemRes = new SceneBattleThrowSomeoneItemRes();
			sceneBattleThrowSomeoneItemRes.decode(msg.bytes);
			if (sceneBattleThrowSomeoneItemRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneBattleThrowSomeoneItemRes.retCode, string.Empty);
				return;
			}
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle == null)
			{
				return;
			}
			if (clientSystemGameBattle.MainPlayer != null && clientSystemGameBattle.MainPlayer.ActorData.GUID == sceneBattleThrowSomeoneItemRes.attackID)
			{
				ChijiItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChijiItemTable>((int)sceneBattleThrowSomeoneItemRes.itemDataID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					string msgContent = string.Empty;
					if (tableItem.SubType == ChijiItemTable.eSubType.ChijiGrenade)
					{
						msgContent = TR.Value("Chiji_UseHandGrenades", sceneBattleThrowSomeoneItemRes.targetName, sceneBattleThrowSomeoneItemRes.param);
					}
					else if (tableItem.SubType == ChijiItemTable.eSubType.ChijiMoveSpeed)
					{
						msgContent = TR.Value("Chiji_UsePoisonDart", sceneBattleThrowSomeoneItemRes.targetName, sceneBattleThrowSomeoneItemRes.param);
					}
					SystemNotifyManager.SysNotifyTextAnimation(msgContent, CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				return;
			}
			BeFighter player = clientSystemGameBattle.GetPlayer(sceneBattleThrowSomeoneItemRes.targetID);
			BeFighter player2 = clientSystemGameBattle.GetPlayer(sceneBattleThrowSomeoneItemRes.attackID);
			if (player2 != null)
			{
				player2.CreateBullet(sceneBattleThrowSomeoneItemRes.targetID, (int)sceneBattleThrowSomeoneItemRes.itemDataID);
			}
		}

		// Token: 0x0600A7BC RID: 42940 RVA: 0x002300BC File Offset: 0x0022E4BC
		private void _OnBattleSomeOneDead(MsgDATA msg)
		{
			SceneBattleNotifySomeoneDead res = new SceneBattleNotifySomeoneDead();
			res.decode(msg.bytes);
			if (this.SwitchingChijiSceneToPrepare)
			{
				Logger.LogErrorFormat(string.Format("正在SwitchingChijiSceneToPrepare, 没有刷新m_SurvivePlayerNum，res.suvivalNum = {0}, m_SurvivePlayerNum = {1}", res.suvivalNum, this.m_SurvivePlayerNum), new object[0]);
				return;
			}
			if (res.battleID != this.m_ChijiBattleID || this.m_ChijiBattleID == 0U)
			{
				Logger.LogErrorFormat(string.Format("吃鸡SomeDead battleid不一致，Cur ChijiBattleID = {0}, msgData.battleID = {1},协议:[SceneBattleNotifySomeoneDead]", this.m_ChijiBattleID, res.battleID), new object[0]);
				return;
			}
			this.m_SurvivePlayerNum = (int)res.suvivalNum;
			if (res.reason == 1U || res.reason == 2U)
			{
				if (DataManager<PlayerBaseData>.GetInstance().RoleID == res.playerID)
				{
					this.m_isMainPlayerDead = true;
				}
				else
				{
					this.m_otherPlayerDead.Add(res.playerID);
				}
				ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
				if (clientSystemGameBattle != null)
				{
					BeFighter player = clientSystemGameBattle.GetPlayer(res.playerID);
					if (player != null)
					{
						player.SetDead();
					}
				}
				if (res.killerID == DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					this.m_RecentKillPlayerID = res.playerID;
					this.m_KillNum = res.kills;
				}
				PlayerDeathReason playerDeathReason = new PlayerDeathReason();
				playerDeathReason.playerID = res.playerID;
				playerDeathReason.killerID = res.killerID;
				playerDeathReason.reason = res.reason;
				playerDeathReason.kills = res.kills;
				if (this.m_ShowDeathPlayerList.Count >= 3)
				{
					this.m_ShowDeathPlayerList.RemoveAt(0);
				}
				this.m_ShowDeathPlayerList.Add(playerDeathReason);
			}
			else if (res.reason == 0U)
			{
				JoinPlayerInfo joinPlayerInfo = this.JoinPlayerInfoList.Find((JoinPlayerInfo x) => x.playerId == res.playerID);
				if (joinPlayerInfo != null)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(string.Format("玩家{0}已掉线", joinPlayerInfo.playerName), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
			}
			else if (res.reason == 4U)
			{
				JoinPlayerInfo joinPlayerInfo2 = this.JoinPlayerInfoList.Find((JoinPlayerInfo x) => x.playerId == res.playerID);
				if (joinPlayerInfo2 != null)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(string.Format("玩家{0}连接超时", joinPlayerInfo2.playerName), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
			}
			else if (res.reason == 3U)
			{
				JoinPlayerInfo joinPlayerInfo3 = this.JoinPlayerInfoList.Find((JoinPlayerInfo x) => x.playerId == res.playerID);
				if (joinPlayerInfo3 != null)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(string.Format("玩家{0}已结算", joinPlayerInfo3.playerName), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChijiPlayerDead, null, null, null, null);
		}

		// Token: 0x0600A7BD RID: 42941 RVA: 0x002303C8 File Offset: 0x0022E7C8
		private void _OnPickUpOthersItem(MsgDATA msg)
		{
			SceneBattleNotifySpoilsItem sceneBattleNotifySpoilsItem = new SceneBattleNotifySpoilsItem();
			sceneBattleNotifySpoilsItem.decode(msg.bytes);
			if (sceneBattleNotifySpoilsItem.battleID != this.m_ChijiBattleID)
			{
				SystemNotifyManager.SysNotifyMsgBoxOK(string.Format("吃鸡battleid不一致，Cur ChijiBattleID = {0}, msgData.battleID = {1}, 协议名: [SceneBattleNotifySpoilsItem]", this.m_ChijiBattleID, sceneBattleNotifySpoilsItem.battleID), null, string.Empty, false);
				return;
			}
			this.m_OtherPlayerItems.battleID = sceneBattleNotifySpoilsItem.battleID;
			this.m_OtherPlayerItems.playerID = sceneBattleNotifySpoilsItem.playerID;
			this.m_OtherPlayerItems.detailItems.Clear();
			if (sceneBattleNotifySpoilsItem.detailItems.Length > 0)
			{
				for (int i = 0; i < sceneBattleNotifySpoilsItem.detailItems.Length; i++)
				{
					OtherPlayerDetailItem otherPlayerDetailItem = new OtherPlayerDetailItem();
					otherPlayerDetailItem.guid = sceneBattleNotifySpoilsItem.detailItems[i].guid;
					otherPlayerDetailItem.itemTypeId = sceneBattleNotifySpoilsItem.detailItems[i].itemTypeId;
					otherPlayerDetailItem.num = sceneBattleNotifySpoilsItem.detailItems[i].num;
					this.m_OtherPlayerItems.detailItems.Add(otherPlayerDetailItem);
				}
				bool flag = false;
				ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
				if (clientSystemGameBattle != null)
				{
					CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemGameBattle.CurrentSceneID, string.Empty, string.Empty);
					if (tableItem != null && tableItem.SceneSubType == CitySceneTable.eSceneSubType.Battle)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					this.m_bGuardForPickUpOtherPlayerItems = true;
				}
				else
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<PlayerItemFrame>(FrameLayer.Middle, null, string.Empty);
				}
			}
		}

		// Token: 0x0600A7BE RID: 42942 RVA: 0x00230540 File Offset: 0x0022E940
		private void _OnPickUpSpoilsRes(MsgDATA msg)
		{
			SceneBattlePickUpSpoilsRes sceneBattlePickUpSpoilsRes = new SceneBattlePickUpSpoilsRes();
			sceneBattlePickUpSpoilsRes.decode(msg.bytes);
			if (sceneBattlePickUpSpoilsRes.retCode != 0U)
			{
				Logger.LogErrorFormat("[SceneBattlePickUpSpoilsRes] error, msgData.retCode = {0}", new object[]
				{
					sceneBattlePickUpSpoilsRes.retCode
				});
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PickUpLoserItem, sceneBattlePickUpSpoilsRes.itemGuid, null, null, null);
		}

		// Token: 0x0600A7BF RID: 42943 RVA: 0x002305A8 File Offset: 0x0022E9A8
		private void _OnPkSomeOneRes(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnPkSomeOneRes ==>> msg is nil");
				return;
			}
			BattlePkSomeOneRes battlePkSomeOneRes = new BattlePkSomeOneRes();
			battlePkSomeOneRes.decode(msg.bytes);
			if (battlePkSomeOneRes.retCode == 0U)
			{
				return;
			}
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle == null)
			{
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemGameBattle.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SceneType != CitySceneTable.eSceneType.BATTLE)
			{
				return;
			}
			if (battlePkSomeOneRes.retCode == 4200002U)
			{
				SystemNotifyManager.SystemNotify(4200002, string.Empty);
			}
			else if (battlePkSomeOneRes.retCode == 4200003U)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("对方处于无敌保护状态，你无法发起挑战", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else if (battlePkSomeOneRes.retCode == 4200004U)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("对方正在pk中，你无法发起挑战", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else if (battlePkSomeOneRes.retCode == 4200005U)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("自己处于无敌状态，你无法发起挑战", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else if (battlePkSomeOneRes.retCode == 4200006U)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("自己正在pk中，你无法发起挑战", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else if (battlePkSomeOneRes.retCode == 4200012U)
			{
				SystemNotifyManager.SystemNotify(4200012, string.Empty);
			}
			else if (battlePkSomeOneRes.retCode == 4200013U)
			{
				SystemNotifyManager.SystemNotify(4200013, string.Empty);
				this.IsReadyPk = false;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChijiPKButtonChange, null, null, null, null);
			}
			else
			{
				Logger.LogErrorFormat("_OnPkSomeOneRes Error, error id = {0}", new object[]
				{
					battlePkSomeOneRes.retCode
				});
			}
		}

		// Token: 0x0600A7C0 RID: 42944 RVA: 0x00230754 File Offset: 0x0022EB54
		private void _OnNpcNotify(MsgDATA msg)
		{
			ChijiDataManager.<_OnNpcNotify>c__AnonStorey2 <_OnNpcNotify>c__AnonStorey = new ChijiDataManager.<_OnNpcNotify>c__AnonStorey2();
			<_OnNpcNotify>c__AnonStorey.msgData = new SceneBattleNpcNotify();
			<_OnNpcNotify>c__AnonStorey.msgData.decode(msg.bytes);
			int i;
			for (i = 0; i < <_OnNpcNotify>c__AnonStorey.msgData.battleNpcList.Length; i++)
			{
				int num = this.m_NpcDataList.FindIndex((BattleNpc x) => <_OnNpcNotify>c__AnonStorey.msgData.battleNpcList[i].npcGuid == x.npcGuid);
				if (num >= 0)
				{
					this.m_NpcDataList[num] = <_OnNpcNotify>c__AnonStorey.msgData.battleNpcList[i];
				}
				else if (<_OnNpcNotify>c__AnonStorey.msgData.battleNpcList[i].opType == 1U)
				{
					this.m_NpcDataList.Add(<_OnNpcNotify>c__AnonStorey.msgData.battleNpcList[i]);
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateChijiNpcData, null, null, null, null);
		}

		// Token: 0x0600A7C1 RID: 42945 RVA: 0x00230854 File Offset: 0x0022EC54
		private void _OnNpcTradeRes(MsgDATA msg)
		{
			SceneBattleNpcTradeRes sceneBattleNpcTradeRes = new SceneBattleNpcTradeRes();
			sceneBattleNpcTradeRes.decode(msg.bytes);
			if (sceneBattleNpcTradeRes.retCode != 0U)
			{
				if (sceneBattleNpcTradeRes.retCode == 4200008U)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("出手慢了，已被其他人击败！", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else
				{
					SystemNotifyManager.SystemNotify((int)sceneBattleNpcTradeRes.retCode, string.Empty);
				}
				return;
			}
			NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>((int)sceneBattleNpcTradeRes.npcId, string.Empty, string.Empty);
			if (tableItem != null && tableItem.SubType == NpcTable.eSubType.ShopNpc)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("兑换成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ExchangeSuccess, null, null, null, null);
		}

		// Token: 0x0600A7C2 RID: 42946 RVA: 0x002308FC File Offset: 0x0022ECFC
		private void _OnOpenBoxRes(MsgDATA msg)
		{
			SceneBattleOpenBoxRes sceneBattleOpenBoxRes = new SceneBattleOpenBoxRes();
			sceneBattleOpenBoxRes.decode(msg.bytes);
			if (sceneBattleOpenBoxRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneBattleOpenBoxRes.retCode, string.Empty);
				return;
			}
			if (sceneBattleOpenBoxRes.param == 1U)
			{
				ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
				if (clientSystemGameBattle == null)
				{
					return;
				}
				if (clientSystemGameBattle.MainPlayer == null)
				{
					return;
				}
				int num = 0;
				List<BeItem> list = clientSystemGameBattle.MainPlayer.FindNearestTownItems();
				if (list != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].ActorData.GUID == sceneBattleOpenBoxRes.itemGuid)
						{
							ChijiItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChijiItemTable>(list[i].ItemID, string.Empty, string.Empty);
							if (tableItem != null)
							{
								num = tableItem.TimeLeft;
								break;
							}
						}
					}
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.StartOpenChijiItem, sceneBattleOpenBoxRes.openTime, num, null, null);
			}
			else if (sceneBattleOpenBoxRes.param == 2U)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.CancelOpenChijiItem, null, null, null, null);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FinishOpenChijiItem, null, null, null, null);
			}
		}

		// Token: 0x0600A7C3 RID: 42947 RVA: 0x00230A54 File Offset: 0x0022EE54
		private void _OnNotifyBestRank(MsgDATA msg)
		{
			BattleNotifyBestRank battleNotifyBestRank = new BattleNotifyBestRank();
			battleNotifyBestRank.decode(msg.bytes);
			this.m_BestRank = (int)battleNotifyBestRank.rank;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChijiBestRank, null, null, null, null);
		}

		// Token: 0x0600A7C4 RID: 42948 RVA: 0x00230A94 File Offset: 0x0022EE94
		private void _OnNotifySkillChoiceList(MsgDATA msg)
		{
			BattleSkillChoiceListNotify battleSkillChoiceListNotify = new BattleSkillChoiceListNotify();
			battleSkillChoiceListNotify.decode(msg.bytes);
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
			if (clientSystemGameBattle != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemGameBattle.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.SceneType == CitySceneTable.eSceneType.BATTLE && tableItem.SceneSubType == CitySceneTable.eSceneSubType.Battle)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OpenChijiSkillChooseFrame, PickUpType.PickUpSkill, battleSkillChoiceListNotify.skillList, null, null);
				}
			}
		}

		// Token: 0x0600A7C5 RID: 42949 RVA: 0x00230B20 File Offset: 0x0022EF20
		private void _OnChoiceSkillRes(MsgDATA msg)
		{
			BattleChoiceSkillRes battleChoiceSkillRes = new BattleChoiceSkillRes();
			battleChoiceSkillRes.decode(msg.bytes);
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)battleChoiceSkillRes.skillId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			SystemNotifyManager.SysNotifyFloatingEffect(string.Format("捡取技能 [{0}] Lv.{1}", tableItem.Name, battleChoiceSkillRes.skillLvl), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600A7C6 RID: 42950 RVA: 0x00230B84 File Offset: 0x0022EF84
		private void _OnEquipChoiceListRes(MsgDATA msg)
		{
			BattleEquipChoiceListNotify battleEquipChoiceListNotify = new BattleEquipChoiceListNotify();
			battleEquipChoiceListNotify.decode(msg.bytes);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OpenChijiSkillChooseFrame, PickUpType.PickUpItem, battleEquipChoiceListNotify.equipList, null, null);
		}

		// Token: 0x0600A7C7 RID: 42951 RVA: 0x00230BC0 File Offset: 0x0022EFC0
		private void _OnChoiceEquipRes(MsgDATA msg)
		{
			BattleChoiceEquipRes battleChoiceEquipRes = new BattleChoiceEquipRes();
			battleChoiceEquipRes.decode(msg.bytes);
			if (battleChoiceEquipRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)battleChoiceEquipRes.retCode, string.Empty);
				return;
			}
		}

		// Token: 0x0600A7C8 RID: 42952 RVA: 0x00230BFC File Offset: 0x0022EFFC
		private void _OnNotifyNoWarOption(MsgDATA msg)
		{
			SceneBattleNoWarOption sceneBattleNoWarOption = new SceneBattleNoWarOption();
			sceneBattleNoWarOption.decode(msg.bytes);
			object[] args = new object[]
			{
				sceneBattleNoWarOption.enemyName
			};
			SystemNotifyManager.SystemNotify(6004, new UnityAction(this._OnClickAgree), new UnityAction(this._OnClickReject), 10f, args);
		}

		// Token: 0x0600A7C9 RID: 42953 RVA: 0x00230C54 File Offset: 0x0022F054
		private void _OnNotifyNoWarWait(MsgDATA msg)
		{
			SceneBattleNoWarWait stream = new SceneBattleNoWarWait();
			stream.decode(msg.bytes);
			SystemNotifyManager.SysNotifyFloatingEffect("发起挑战成功，请等待对手接受挑战!", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			this.IsReadyPk = false;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChijiPKButtonChange, null, null, null, null);
		}

		// Token: 0x0600A7CA RID: 42954 RVA: 0x00230C9C File Offset: 0x0022F09C
		private void _OnClickAgree()
		{
			SceneBattleNoWarChoiceReq sceneBattleNoWarChoiceReq = new SceneBattleNoWarChoiceReq();
			sceneBattleNoWarChoiceReq.isNoWar = 1U;
			NetManager.Instance().SendCommand<SceneBattleNoWarChoiceReq>(ServerType.GATE_SERVER, sceneBattleNoWarChoiceReq);
		}

		// Token: 0x0600A7CB RID: 42955 RVA: 0x00230CC4 File Offset: 0x0022F0C4
		private void _OnClickReject()
		{
			SceneBattleNoWarChoiceReq sceneBattleNoWarChoiceReq = new SceneBattleNoWarChoiceReq();
			sceneBattleNoWarChoiceReq.isNoWar = 0U;
			NetManager.Instance().SendCommand<SceneBattleNoWarChoiceReq>(ServerType.GATE_SERVER, sceneBattleNoWarChoiceReq);
		}

		// Token: 0x0600A7CC RID: 42956 RVA: 0x00230CEC File Offset: 0x0022F0EC
		private void _OnNotifyNoWarChoiceRes(MsgDATA msg)
		{
			SceneBattleNoWarChoiceRes sceneBattleNoWarChoiceRes = new SceneBattleNoWarChoiceRes();
			sceneBattleNoWarChoiceRes.decode(msg.bytes);
			if (sceneBattleNoWarChoiceRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneBattleNoWarChoiceRes.retCode, string.Empty);
				return;
			}
		}

		// Token: 0x0600A7CD RID: 42957 RVA: 0x00230D28 File Offset: 0x0022F128
		private void _OnNoWarNotify(MsgDATA msg)
		{
			SceneBattleNoWarNotify stream = new SceneBattleNoWarNotify();
			stream.decode(msg.bytes);
			SystemNotifyManager.SysNotifyFloatingEffect("对方使用了免战令，30秒内无法对其发起挑战", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600A7CE RID: 42958 RVA: 0x00230D54 File Offset: 0x0022F154
		private void _OnChijiPkReadyFinish(UIEvent iEvent)
		{
			BattleMain.OpenBattle(BattleType.ChijiPVP, eDungeonMode.SyncFrame, (int)this.m_BattleDungeonId, this.m_SessionId.ToString());
			BaseBattle baseBattle = BattleMain.instance.GetBattle() as BaseBattle;
			if (baseBattle != null)
			{
				baseBattle.PkRaceType = (int)this.m_BattleRaceType;
				baseBattle.SetBattleFlag(this.m_BattleFlag);
			}
			if (Singleton<ReplayServer>.GetInstance().IsLiveShow())
			{
				Singleton<ReplayServer>.GetInstance().SetBattle(BattleMain.instance.GetBattle() as PVPBattle);
			}
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle != null)
			{
				this.sceneData = clientSystemGameBattle.LevelData;
			}
			Singleton<ClientSystemManager>.GetInstance().SwitchSystem<ClientSystemBattle>(null, null, false);
			this.m_BattleDungeonId = 0U;
			this.m_BattleRaceType = 0;
			this.m_BattleFlag = 0UL;
			this.m_SessionId = 0UL;
		}

		// Token: 0x0600A7CF RID: 42959 RVA: 0x00230E24 File Offset: 0x0022F224
		public void CreateBullet(ulong itemGuid, int itemID, ulong targetId)
		{
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle == null)
			{
				return;
			}
			if (clientSystemGameBattle.MainPlayer == null)
			{
				return;
			}
			SceneBattleThrowSomeoneItemReq cmd = new SceneBattleThrowSomeoneItemReq
			{
				battleID = this.m_ChijiBattleID,
				targetID = targetId,
				itemGuid = itemGuid
			};
			NetManager.Instance().SendCommand<SceneBattleThrowSomeoneItemReq>(ServerType.GATE_SERVER, cmd);
			clientSystemGameBattle.MainPlayer.CreateBullet(targetId, itemID);
		}

		// Token: 0x0600A7D0 RID: 42960 RVA: 0x00230E90 File Offset: 0x0022F290
		public void SendChijiBattleID()
		{
			SceneItemSync sceneItemSync = new SceneItemSync();
			sceneItemSync.battleID = this.m_ChijiBattleID;
			Logger.LogError("SendChijiBattleID");
			NetManager.Instance().SendCommand<SceneItemSync>(ServerType.GATE_SERVER, sceneItemSync);
		}

		// Token: 0x0600A7D1 RID: 42961 RVA: 0x00230EC8 File Offset: 0x0022F2C8
		public void SendSelectJobId(int jobid)
		{
			SceneBattleSelectOccuReq sceneBattleSelectOccuReq = new SceneBattleSelectOccuReq();
			sceneBattleSelectOccuReq.occu = (byte)jobid;
			NetManager.Instance().SendCommand<SceneBattleSelectOccuReq>(ServerType.GATE_SERVER, sceneBattleSelectOccuReq);
		}

		// Token: 0x0600A7D2 RID: 42962 RVA: 0x00230EF0 File Offset: 0x0022F2F0
		public void SendSelectAreaId(int areaID)
		{
			SceneBattleBirthTransfer sceneBattleBirthTransfer = new SceneBattleBirthTransfer();
			sceneBattleBirthTransfer.regionID = (uint)areaID;
			sceneBattleBirthTransfer.battleID = this.m_ChijiBattleID;
			NetManager.Instance().SendCommand<SceneBattleBirthTransfer>(ServerType.GATE_SERVER, sceneBattleBirthTransfer);
		}

		// Token: 0x0600A7D3 RID: 42963 RVA: 0x00230F24 File Offset: 0x0022F324
		public void SendPickUpBuffItems(ulong guid)
		{
			SceneBattleUseItemReq sceneBattleUseItemReq = new SceneBattleUseItemReq();
			sceneBattleUseItemReq.battleID = this.m_ChijiBattleID;
			sceneBattleUseItemReq.uid = guid;
			NetManager.Instance().SendCommand<SceneBattleUseItemReq>(ServerType.GATE_SERVER, sceneBattleUseItemReq);
		}

		// Token: 0x0600A7D4 RID: 42964 RVA: 0x00230F58 File Offset: 0x0022F358
		public void SendPickUpMapBoxs(ulong guid)
		{
			SceneBattleOpenBoxReq sceneBattleOpenBoxReq = new SceneBattleOpenBoxReq();
			sceneBattleOpenBoxReq.itemGuid = guid;
			sceneBattleOpenBoxReq.param = 1U;
			NetManager.Instance().SendCommand<SceneBattleOpenBoxReq>(ServerType.GATE_SERVER, sceneBattleOpenBoxReq);
		}

		// Token: 0x0600A7D5 RID: 42965 RVA: 0x00230F88 File Offset: 0x0022F388
		public void SendPickUpOtherPlayerItems(ulong guid, ulong playerID)
		{
			SceneBattlePickUpSpoilsReq sceneBattlePickUpSpoilsReq = new SceneBattlePickUpSpoilsReq();
			sceneBattlePickUpSpoilsReq.battleID = this.m_ChijiBattleID;
			sceneBattlePickUpSpoilsReq.playerID = playerID;
			sceneBattlePickUpSpoilsReq.itemGuid = guid;
			NetManager.Instance().SendCommand<SceneBattlePickUpSpoilsReq>(ServerType.GATE_SERVER, sceneBattlePickUpSpoilsReq);
		}

		// Token: 0x0600A7D6 RID: 42966 RVA: 0x00230FC4 File Offset: 0x0022F3C4
		public void SendBattleLockSomeOneReq(ulong dstRoleID)
		{
			BattleLockSomeOneReq battleLockSomeOneReq = new BattleLockSomeOneReq();
			battleLockSomeOneReq.battleID = this.m_ChijiBattleID;
			battleLockSomeOneReq.roleId = DataManager<PlayerBaseData>.GetInstance().RoleID;
			battleLockSomeOneReq.dstId = dstRoleID;
			NetManager.Instance().SendCommand<BattleLockSomeOneReq>(ServerType.GATE_SERVER, battleLockSomeOneReq);
		}

		// Token: 0x0600A7D7 RID: 42967 RVA: 0x00231008 File Offset: 0x0022F408
		public void SendBattlePkSomeOneReq(ulong dstRoleID, int dungeonId)
		{
			BattlePkSomeOneReq battlePkSomeOneReq = new BattlePkSomeOneReq();
			battlePkSomeOneReq.battleID = this.m_ChijiBattleID;
			battlePkSomeOneReq.roleId = DataManager<PlayerBaseData>.GetInstance().RoleID;
			battlePkSomeOneReq.dstId = dstRoleID;
			battlePkSomeOneReq.dungeonID = (uint)dungeonId;
			NetManager.Instance().SendCommand<BattlePkSomeOneReq>(ServerType.GATE_SERVER, battlePkSomeOneReq);
		}

		// Token: 0x0600A7D8 RID: 42968 RVA: 0x00231054 File Offset: 0x0022F454
		public void SendDelItemReq(ulong itemguid)
		{
			SceneBattleDelItemReq sceneBattleDelItemReq = new SceneBattleDelItemReq();
			sceneBattleDelItemReq.itemGuid = itemguid;
			NetManager.Instance().SendCommand<SceneBattleDelItemReq>(ServerType.GATE_SERVER, sceneBattleDelItemReq);
		}

		// Token: 0x0600A7D9 RID: 42969 RVA: 0x0023107C File Offset: 0x0022F47C
		public void SendNpcTradeReq(uint npcId, ulong npcGuid, List<ulong> paramVec = null)
		{
			SceneBattleNpcTradeReq sceneBattleNpcTradeReq = new SceneBattleNpcTradeReq();
			sceneBattleNpcTradeReq.npcGuid = npcGuid;
			sceneBattleNpcTradeReq.npcId = npcId;
			if (paramVec != null)
			{
				sceneBattleNpcTradeReq.paramVec = new ulong[paramVec.Count];
				for (int i = 0; i < paramVec.Count; i++)
				{
					sceneBattleNpcTradeReq.paramVec[i] = paramVec[i];
				}
			}
			NetManager.Instance().SendCommand<SceneBattleNpcTradeReq>(ServerType.GATE_SERVER, sceneBattleNpcTradeReq);
		}

		// Token: 0x0600A7DA RID: 42970 RVA: 0x002310E8 File Offset: 0x0022F4E8
		public void SendSelectSkillReq(uint skillid)
		{
			BattleChoiceSkillReq battleChoiceSkillReq = new BattleChoiceSkillReq();
			battleChoiceSkillReq.skillId = skillid;
			NetManager.Instance().SendCommand<BattleChoiceSkillReq>(ServerType.GATE_SERVER, battleChoiceSkillReq);
		}

		// Token: 0x0600A7DB RID: 42971 RVA: 0x00231110 File Offset: 0x0022F510
		public void SendSelectItemReq(uint itemid)
		{
			BattleChoiceEquipReq battleChoiceEquipReq = new BattleChoiceEquipReq();
			battleChoiceEquipReq.equipId = itemid;
			NetManager.Instance().SendCommand<BattleChoiceEquipReq>(ServerType.GATE_SERVER, battleChoiceEquipReq);
		}

		// Token: 0x0600A7DC RID: 42972 RVA: 0x00231137 File Offset: 0x0022F537
		public int GetPrepareScenePlayerNum()
		{
			return this.m_PrepareScenePlayerNum;
		}

		// Token: 0x0600A7DD RID: 42973 RVA: 0x0023113F File Offset: 0x0022F53F
		public bool IsHonorBattleFieldStr(string judgeStr)
		{
			return !string.IsNullOrEmpty(judgeStr) && judgeStr == "HonorBattleField";
		}

		// Token: 0x0600A7DE RID: 42974 RVA: 0x00231164 File Offset: 0x0022F564
		public bool MainFrameChijiButtonIsShow()
		{
			bool result = false;
			if (this.ChijiActivityIDs != null)
			{
				for (int i = 0; i < this.ChijiActivityIDs.Length; i++)
				{
					int key = this.ChijiActivityIDs[i];
					if (DataManager<ActiveManager>.GetInstance().allActivities.ContainsKey(key))
					{
						ActivityInfo activityInfo = DataManager<ActiveManager>.GetInstance().allActivities[key];
						if (activityInfo.state == 1)
						{
							result = true;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600A7DF RID: 42975 RVA: 0x002311DC File Offset: 0x0022F5DC
		public int GetChijiOpenLevel()
		{
			for (int i = 0; i < this.ChijiActivityIDs.Length; i++)
			{
				int key = this.ChijiActivityIDs[i];
				if (DataManager<ActiveManager>.GetInstance().allActivities.ContainsKey(key))
				{
					ActivityInfo activityInfo = DataManager<ActiveManager>.GetInstance().allActivities[key];
					if (activityInfo.state == 1)
					{
						return (int)activityInfo.level;
					}
				}
			}
			return 0;
		}

		// Token: 0x0600A7E0 RID: 42976 RVA: 0x0023124C File Offset: 0x0022F64C
		public void OpenSettlementFrame()
		{
			SettlementInfo settlementinfo = DataManager<ChijiDataManager>.GetInstance().Settlementinfo;
			if (settlementinfo.rank == 1U)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiSettlementFrame>(FrameLayer.Middle, null, string.Empty);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiSettlementLoseFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600A7E1 RID: 42977 RVA: 0x0023129C File Offset: 0x0022F69C
		public void ResponseBattleEnd()
		{
			this.IsToPrepareScene = false;
			this.SwitchingChijiSceneToPrepare = false;
			if (this.m_pkEndData.result == 1)
			{
				this.ClearBattleData();
				Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemGameBattle>(null, null, false);
			}
			else
			{
				this.ClearAllRelatedSystemData();
				this.IsToPrepareScene = true;
				this.SwitchingChijiSceneToPrepare = true;
				Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemGameBattle>(null, null, false);
			}
		}

		// Token: 0x0600A7E2 RID: 42978 RVA: 0x00231304 File Offset: 0x0022F704
		public bool CheckCurrentSystemIsClientSystemGameBattle()
		{
			return Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() is ClientSystemGameBattle;
		}

		// Token: 0x0600A7E3 RID: 42979 RVA: 0x0023132C File Offset: 0x0022F72C
		public void SendOccuListReq()
		{
			SceneBattleOccuListReq cmd = new SceneBattleOccuListReq();
			NetManager.Instance().SendCommand<SceneBattleOccuListReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600A7E4 RID: 42980 RVA: 0x0023134C File Offset: 0x0022F74C
		public int _GetWeeklyTotalGlory()
		{
			int result = 0;
			if (DataManager<CountDataManager>.GetInstance() != null)
			{
				result = DataManager<CountDataManager>.GetInstance().GetCount("chi_ji_honor");
			}
			return result;
		}

		// Token: 0x0600A7E5 RID: 42981 RVA: 0x00231378 File Offset: 0x0022F778
		public int _GetWeeklyMaxPVPGlory()
		{
			int result = 0;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(659, string.Empty, string.Empty);
			if (tableItem != null)
			{
				result = tableItem.Value;
			}
			return result;
		}

		// Token: 0x0600A7E6 RID: 42982 RVA: 0x002313B0 File Offset: 0x0022F7B0
		private void _onSyncMainRolePosInterval(MsgDATA msg)
		{
			BattleNotifyChijiMisc battleNotifyChijiMisc = new BattleNotifyChijiMisc();
			battleNotifyChijiMisc.decode(msg.bytes);
			this.m_mainRolePosSyncInterval = battleNotifyChijiMisc.moveIntervalMs / 1000f;
		}

		// Token: 0x04005DC0 RID: 24000
		private bool m_bNetBind;

		// Token: 0x04005DC1 RID: 24001
		private int m_PrepareScenePlayerNum;

		// Token: 0x04005DC2 RID: 24002
		private int m_PrepareSceneMaxPlayerNum;

		// Token: 0x04005DC3 RID: 24003
		private uint m_ChijiBattleID;

		// Token: 0x04005DC4 RID: 24004
		private ChiJiTimeTable.eBattleStage m_CurBattleStage;

		// Token: 0x04005DC5 RID: 24005
		private uint[] m_StageStartTimeList;

		// Token: 0x04005DC6 RID: 24006
		private SettlementInfo m_Settlementinfo = new SettlementInfo();

		// Token: 0x04005DC7 RID: 24007
		private bool m_bGuardForSettlement;

		// Token: 0x04005DC8 RID: 24008
		private bool m_bGuardForPickUpOtherPlayerItems;

		// Token: 0x04005DC9 RID: 24009
		private bool m_bGuardForPkEndData;

		// Token: 0x04005DCA RID: 24010
		private List<ulong> m_otherPlayerDead = new List<ulong>();

		// Token: 0x04005DCB RID: 24011
		private ChijiOtherPlayerItems m_OtherPlayerItems = new ChijiOtherPlayerItems();

		// Token: 0x04005DCC RID: 24012
		private int m_SurvivePlayerNum;

		// Token: 0x04005DCD RID: 24013
		private uint m_SceneNodeID;

		// Token: 0x04005DCE RID: 24014
		private PoisonRingInfo m_poisonRing = new PoisonRingInfo();

		// Token: 0x04005DCF RID: 24015
		private uint m_BattleDungeonId;

		// Token: 0x04005DD0 RID: 24016
		private byte m_BattleRaceType;

		// Token: 0x04005DD1 RID: 24017
		private ulong m_BattleFlag;

		// Token: 0x04005DD2 RID: 24018
		private ulong m_SessionId;

		// Token: 0x04005DD3 RID: 24019
		private bool m_isMainPlayerDead;

		// Token: 0x04005DD4 RID: 24020
		private List<JoinPlayerInfo> m_JoinPlayerInfoList = new List<JoinPlayerInfo>();

		// Token: 0x04005DD5 RID: 24021
		private List<PlayerDeathReason> m_ShowDeathPlayerList = new List<PlayerDeathReason>();

		// Token: 0x04005DD6 RID: 24022
		private List<BattleNpc> m_NpcDataList = new List<BattleNpc>();

		// Token: 0x04005DD7 RID: 24023
		private PlayerDeathReason m_KillInfo = new PlayerDeathReason();

		// Token: 0x04005DD8 RID: 24024
		private ulong m_RecentKillPlayerID;

		// Token: 0x04005DD9 RID: 24025
		private uint m_KillNum;

		// Token: 0x04005DDA RID: 24026
		private SceneMatchPkRaceEnd m_pkEndData;

		// Token: 0x04005DDB RID: 24027
		private bool m_IsMatching;

		// Token: 0x04005DDC RID: 24028
		private bool m_IsToPrepareScene;

		// Token: 0x04005DDD RID: 24029
		private bool m_SwitchingTownToPrepare;

		// Token: 0x04005DDE RID: 24030
		private bool m_SwitchingPrepareToTown;

		// Token: 0x04005DDF RID: 24031
		private bool m_SwitchingPrepareToChijiScene;

		// Token: 0x04005DE0 RID: 24032
		private bool m_SwitchingChijiSceneToPrepare;

		// Token: 0x04005DE1 RID: 24033
		private bool m_IsReadyPk;

		// Token: 0x04005DE2 RID: 24034
		private int m_BestRank;

		// Token: 0x04005DE3 RID: 24035
		private float m_mainRolePosSyncInterval = 0.05f;

		// Token: 0x04005DE4 RID: 24036
		private const string HonorBattleFieldStr = "HonorBattleField";

		// Token: 0x04005DE5 RID: 24037
		public int[] ChijiActivityIDs;
	}
}
