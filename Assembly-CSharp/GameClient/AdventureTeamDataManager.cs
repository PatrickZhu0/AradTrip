using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AdsPush;
using GamePool;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020011D6 RID: 4566
	public class AdventureTeamDataManager : DataManager<AdventureTeamDataManager>
	{
		// Token: 0x17001A9A RID: 6810
		// (get) Token: 0x0600AF07 RID: 44807 RVA: 0x00264253 File Offset: 0x00262653
		public bool BFuncOpened
		{
			get
			{
				return !DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_ADVENTURE_TEAM) && !this.IsAdventureTeamNameEmpty();
			}
		}

		// Token: 0x17001A9B RID: 6811
		// (get) Token: 0x0600AF08 RID: 44808 RVA: 0x00264275 File Offset: 0x00262675
		public int AdventureTeamLevelMinimum
		{
			get
			{
				return this.adventureTeamLevelMinimun;
			}
		}

		// Token: 0x17001A9C RID: 6812
		// (get) Token: 0x0600AF09 RID: 44809 RVA: 0x0026427D File Offset: 0x0026267D
		public int AdventureTeamLevelMaximum
		{
			get
			{
				return this.adventureTeamLevelMaximun;
			}
		}

		// Token: 0x17001A9D RID: 6813
		// (get) Token: 0x0600AF0A RID: 44810 RVA: 0x00264285 File Offset: 0x00262685
		public int RenameLimitCharNum
		{
			get
			{
				return this.renameLimitCharNum;
			}
		}

		// Token: 0x17001A9E RID: 6814
		// (get) Token: 0x0600AF0B RID: 44811 RVA: 0x0026428D File Offset: 0x0026268D
		public int RenameCardTableId
		{
			get
			{
				return this.mRenameCardTableId;
			}
		}

		// Token: 0x17001A9F RID: 6815
		// (get) Token: 0x0600AF0C RID: 44812 RVA: 0x00264295 File Offset: 0x00262695
		public int WeeklyTaskRefreshHour
		{
			get
			{
				return this.weeklyTaskRefreshHour;
			}
		}

		// Token: 0x17001AA0 RID: 6816
		// (get) Token: 0x0600AF0D RID: 44813 RVA: 0x0026429D File Offset: 0x0026269D
		public BlessCrystalModel BlessCrystalModel
		{
			get
			{
				if (this.blessCrystalModel == null)
				{
					this.blessCrystalModel = new BlessCrystalModel();
				}
				return this.blessCrystalModel;
			}
		}

		// Token: 0x17001AA1 RID: 6817
		// (get) Token: 0x0600AF0E RID: 44814 RVA: 0x002642BC File Offset: 0x002626BC
		public ItemTable PassBlessItem
		{
			get
			{
				if (this.mPassBlessItem == null)
				{
					SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(497, string.Empty, string.Empty);
					if (tableItem != null)
					{
						this.mPassBlessItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableItem.Value, string.Empty, string.Empty);
					}
				}
				return this.mPassBlessItem;
			}
		}

		// Token: 0x17001AA2 RID: 6818
		// (get) Token: 0x0600AF0F RID: 44815 RVA: 0x0026431A File Offset: 0x0026271A
		public InheritBlessModel InheritBlessModel
		{
			get
			{
				if (this.inheritBlessModel == null)
				{
					this.inheritBlessModel = new InheritBlessModel();
				}
				return this.inheritBlessModel;
			}
		}

		// Token: 0x17001AA3 RID: 6819
		// (get) Token: 0x0600AF10 RID: 44816 RVA: 0x00264338 File Offset: 0x00262738
		public InheritExpModel InheritExpModel
		{
			get
			{
				if (this.inheritExpModel == null)
				{
					this.inheritExpModel = new InheritExpModel();
				}
				return this.inheritExpModel;
			}
		}

		// Token: 0x17001AA4 RID: 6820
		// (get) Token: 0x0600AF11 RID: 44817 RVA: 0x00264356 File Offset: 0x00262756
		public InheritBlessModel UiTempInheritBlessModel
		{
			get
			{
				return this.uiTempInheritBlessModel;
			}
		}

		// Token: 0x17001AA5 RID: 6821
		// (get) Token: 0x0600AF12 RID: 44818 RVA: 0x0026435E File Offset: 0x0026275E
		public InheritExpModel UiTempInheritExpModel
		{
			get
			{
				return this.uiTempInheritExpModel;
			}
		}

		// Token: 0x17001AA6 RID: 6822
		// (get) Token: 0x0600AF13 RID: 44819 RVA: 0x00264366 File Offset: 0x00262766
		public BountyModle BountyModel
		{
			get
			{
				if (this.bountyModel == null)
				{
					this.bountyModel = new BountyModle();
				}
				return this.bountyModel;
			}
		}

		// Token: 0x17001AA7 RID: 6823
		// (get) Token: 0x0600AF14 RID: 44820 RVA: 0x00264384 File Offset: 0x00262784
		public ExpeditionMapBaseInfo ExpeditionMapBaseInfo
		{
			get
			{
				if (this.mExpeditionMapBaseInfo == null)
				{
					this.mExpeditionMapBaseInfo = new ExpeditionMapBaseInfo();
				}
				return this.mExpeditionMapBaseInfo;
			}
		}

		// Token: 0x17001AA8 RID: 6824
		// (get) Token: 0x0600AF15 RID: 44821 RVA: 0x002643A2 File Offset: 0x002627A2
		public ExpeditionMapNetInfo ExpeditionMapNetInfo
		{
			get
			{
				if (this.mExpeditionMapNetInfo == null)
				{
					this.mExpeditionMapNetInfo = new ExpeditionMapNetInfo(1);
				}
				return this.mExpeditionMapNetInfo;
			}
		}

		// Token: 0x17001AA9 RID: 6825
		// (get) Token: 0x0600AF16 RID: 44822 RVA: 0x002643C1 File Offset: 0x002627C1
		public bool IsChangedExpeditionMap
		{
			get
			{
				return this.mIsChangedExpeditionMap;
			}
		}

		// Token: 0x17001AAA RID: 6826
		// (get) Token: 0x0600AF17 RID: 44823 RVA: 0x002643C9 File Offset: 0x002627C9
		// (set) Token: 0x0600AF18 RID: 44824 RVA: 0x002643D1 File Offset: 0x002627D1
		public bool IsChangeExpeditionTime
		{
			get
			{
				return this.mIsChangedExpeditionTime;
			}
			set
			{
				this.mIsChangedExpeditionTime = value;
			}
		}

		// Token: 0x17001AAB RID: 6827
		// (get) Token: 0x0600AF19 RID: 44825 RVA: 0x002643DA File Offset: 0x002627DA
		// (set) Token: 0x0600AF1A RID: 44826 RVA: 0x002643E2 File Offset: 0x002627E2
		public bool IsChangedExpedtionRoles
		{
			get
			{
				return this.mIsChangedExpeditionRoles;
			}
			set
			{
				this.mIsChangedExpeditionRoles = value;
			}
		}

		// Token: 0x17001AAC RID: 6828
		// (get) Token: 0x0600AF1B RID: 44827 RVA: 0x002643EB File Offset: 0x002627EB
		public List<MissionManager.SingleMissionInfo> ADTMissionList
		{
			get
			{
				return this.m_ADTMissionList;
			}
		}

		// Token: 0x17001AAD RID: 6829
		// (get) Token: 0x0600AF1C RID: 44828 RVA: 0x002643F3 File Offset: 0x002627F3
		public int ADTMissionFinishMaxNum
		{
			get
			{
				return this.m_ADTMissionFinishMaxNum;
			}
		}

		// Token: 0x17001AAE RID: 6830
		// (get) Token: 0x0600AF1D RID: 44829 RVA: 0x002643FB File Offset: 0x002627FB
		// (set) Token: 0x0600AF1E RID: 44830 RVA: 0x00264403 File Offset: 0x00262803
		public bool OnAdventureTeamLevelChangedFlag { get; set; }

		// Token: 0x17001AAF RID: 6831
		// (get) Token: 0x0600AF1F RID: 44831 RVA: 0x0026440C File Offset: 0x0026280C
		// (set) Token: 0x0600AF20 RID: 44832 RVA: 0x00264425 File Offset: 0x00262825
		public bool OnFirstCheckWeeklyTaskFlag
		{
			get
			{
				return this.onFirstCheckWeeklyTaskFlag && !this.hasWeeklyTaskCheckedToday;
			}
			set
			{
				if (!value)
				{
					this.onFirstCheckWeeklyTaskFlag = value;
					this._NotifyWeeklyTaskStatusChanged();
					if (!this.hasWeeklyTaskCheckedToday)
					{
						this._SaveWeeklyTaskCheckTimestamp();
						this.hasWeeklyTaskCheckedToday = this._IsWeeklyTaskCheckedToday();
					}
				}
			}
		}

		// Token: 0x17001AB0 RID: 6832
		// (get) Token: 0x0600AF21 RID: 44833 RVA: 0x00264457 File Offset: 0x00262857
		// (set) Token: 0x0600AF22 RID: 44834 RVA: 0x00264460 File Offset: 0x00262860
		public bool OnFirstCheckPassBlessFlag
		{
			get
			{
				return this.onFirstCheckPassBlessFlag;
			}
			set
			{
				if (!value)
				{
					if (this.isPassBlessOwnCountAddup)
					{
						this.isPassBlessOwnCountAddup = false;
						this._NotifyPassBlessCountChanged();
					}
					if (this.isPassBlessCanUse)
					{
						this.onFirstCheckPassBlessFlag = value;
						this._NotifyPassBlessCountChanged();
					}
					else if (this.isPassBlessEnoughOnFirstLogin)
					{
						this.onFirstCheckPassBlessFlag = value;
						this._NotifyPassBlessCountChanged();
						this._SavePassBlessCheckTimestamp();
						this.hasPassBlessCheckedToday = this._IsPassBlessCheckedToday();
					}
				}
			}
		}

		// Token: 0x0600AF23 RID: 44835 RVA: 0x002644D2 File Offset: 0x002628D2
		public override void Initialize()
		{
			this._BindEvents();
			this._InitTR();
			this._InitLocalData();
		}

		// Token: 0x0600AF24 RID: 44836 RVA: 0x002644E6 File Offset: 0x002628E6
		public override void Clear()
		{
			this._UnBindEvents();
			this._ClearLocalData();
			this._ClearTR();
		}

		// Token: 0x0600AF25 RID: 44837 RVA: 0x002644FC File Offset: 0x002628FC
		private void _BindEvents()
		{
			if (!this.bNetInited)
			{
				NetProcess.AddMsgHandler(308601U, new Action<MsgDATA>(this._OnSyncAdventureTeamInfo));
				NetProcess.AddMsgHandler(608602U, new Action<MsgDATA>(this._OnAdventureTeamRenameRes));
				NetProcess.AddMsgHandler(608702U, new Action<MsgDATA>(this._OnExtensibleRoleFieldUnlockRes));
				NetProcess.AddMsgHandler(608604U, new Action<MsgDATA>(this._OnBlessCrystalInfoRes));
				NetProcess.AddMsgHandler(608606U, new Action<MsgDATA>(this._OnPassBlessInfoRes));
				NetProcess.AddMsgHandler(608608U, new Action<MsgDATA>(this._OnUsePassBlessExpRes));
				NetProcess.AddMsgHandler(608612U, new Action<MsgDATA>(this._OnExpeditionMapInfoRes));
				NetProcess.AddMsgHandler(608614U, new Action<MsgDATA>(this._OnExpeditionRolesRes));
				NetProcess.AddMsgHandler(608616U, new Action<MsgDATA>(this._OnDispatchExpeditionTeamRes));
				NetProcess.AddMsgHandler(608618U, new Action<MsgDATA>(this._OnCancelExpeditionRes));
				NetProcess.AddMsgHandler(608620U, new Action<MsgDATA>(this._OnGetExpeditionRewardsRes));
				NetProcess.AddMsgHandler(608622U, new Action<MsgDATA>(this._OnGetAllExpeditionMaps));
				NetProcess.AddMsgHandler(608628U, new Action<MsgDATA>(this._OnOnceExpeditionDispatchFinish));
				NetProcess.AddMsgHandler(608610U, new Action<MsgDATA>(this._OnAdventureTeamExtraInfoRes));
				NetProcess.AddMsgHandler(600606U, new Action<MsgDATA>(this._OnWorldAccountCounterNotify));
				NetProcess.AddMsgHandler(608624U, new Action<MsgDATA>(this._OnQueryOwnJobRes));
				NetProcess.AddMsgHandler(608625U, new Action<MsgDATA>(this._OnSyncOwnNewJobs));
				DataManager<ServerSceneFuncSwitchManager>.GetInstance().AddServerFuncSwitchListener(ServiceType.SERVICE_ADVENTURE_TEAM, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this._OnServerSwitchFunc));
				this.bNetInited = true;
			}
		}

		// Token: 0x0600AF26 RID: 44838 RVA: 0x002646AC File Offset: 0x00262AAC
		private void _UnBindEvents()
		{
			NetProcess.RemoveMsgHandler(308601U, new Action<MsgDATA>(this._OnSyncAdventureTeamInfo));
			NetProcess.RemoveMsgHandler(608602U, new Action<MsgDATA>(this._OnAdventureTeamRenameRes));
			NetProcess.RemoveMsgHandler(608702U, new Action<MsgDATA>(this._OnExtensibleRoleFieldUnlockRes));
			NetProcess.RemoveMsgHandler(608604U, new Action<MsgDATA>(this._OnBlessCrystalInfoRes));
			NetProcess.RemoveMsgHandler(608606U, new Action<MsgDATA>(this._OnPassBlessInfoRes));
			NetProcess.RemoveMsgHandler(608608U, new Action<MsgDATA>(this._OnUsePassBlessExpRes));
			NetProcess.RemoveMsgHandler(608612U, new Action<MsgDATA>(this._OnExpeditionMapInfoRes));
			NetProcess.RemoveMsgHandler(608614U, new Action<MsgDATA>(this._OnExpeditionRolesRes));
			NetProcess.RemoveMsgHandler(608616U, new Action<MsgDATA>(this._OnDispatchExpeditionTeamRes));
			NetProcess.RemoveMsgHandler(608618U, new Action<MsgDATA>(this._OnCancelExpeditionRes));
			NetProcess.RemoveMsgHandler(608620U, new Action<MsgDATA>(this._OnGetExpeditionRewardsRes));
			NetProcess.RemoveMsgHandler(608622U, new Action<MsgDATA>(this._OnGetAllExpeditionMaps));
			NetProcess.RemoveMsgHandler(608628U, new Action<MsgDATA>(this._OnOnceExpeditionDispatchFinish));
			NetProcess.RemoveMsgHandler(608610U, new Action<MsgDATA>(this._OnAdventureTeamExtraInfoRes));
			NetProcess.RemoveMsgHandler(600606U, new Action<MsgDATA>(this._OnWorldAccountCounterNotify));
			NetProcess.RemoveMsgHandler(608624U, new Action<MsgDATA>(this._OnQueryOwnJobRes));
			NetProcess.RemoveMsgHandler(608625U, new Action<MsgDATA>(this._OnSyncOwnNewJobs));
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().RemoveServerFuncSwitchListener(ServiceType.SERVICE_ADVENTURE_TEAM, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this._OnServerSwitchFunc));
		}

		// Token: 0x0600AF27 RID: 44839 RVA: 0x0026484C File Offset: 0x00262C4C
		private void _InitTR()
		{
			this.tr_rename_content_empty = TR.Value("adventure_team_change_name_no_content");
			this.tr_rename_content_beyond_max = TR.Value("adventure_team_change_name_exceed_upper_limit");
			this.tr_rename_content_illegal = TR.Value("adventure_team_change_name_content_no_law");
			this.tr_rename_content_be_used = TR.Value("adventure_team_change_name_content_used");
			this.tr_rename_content_no_changed = TR.Value("adventure_team_change_name_content_same");
			this.tr_rename_content_failed = TR.Value("adventure_team_change_name_content_change_failed");
			this.tr_rename_content_success = TR.Value("adventure_team_change_name_content_change_succeed");
			this.tr_rename_quick_buy_ask = TR.Value("adventure_team_change_name_ask");
			this.tr_adventure_team_level_up_tip = TR.Value("adventure_team_level_up_succeed_tip");
			this.tr_select_role_extend_succ = TR.Value("select_role_extend_field_num_succ");
			this.tr_select_role_field_reach_max = TR.Value("select_role_field_reach_max");
			this.tr_select_role_field_not_use_total = TR.Value("select_role_field_not_use_total");
			this.tr_select_role_field_extend_failed = TR.Value("select_role_field_extend_failed");
			this.tr_collection_first_tab_name = TR.Value("adventure_team_collection_first_tab");
			this.tr_expedition_dispatch_succeed = TR.Value("adventure_team_expeidtion_dispatch_succeed_tips");
			this.tr_expedition_dispatch_fail = TR.Value("adventure_team_expeidtion_dispatch_fail_tips");
			this.tr_expedition_dispatch_dup = TR.Value("adventure_team_expeidtion_dispatch_dup_tips");
			this.tr_expedition_requires = new Dictionary<int, string>();
			this.tr_expedition_requires.Add(0, TR.Value("adventure_team_expedition_REQUIRE_ANY_OCCU"));
			this.tr_expedition_requires.Add(1, TR.Value("adventure_team_expedition_REQUIRE_ANY_SAME_BASE_OCCU"));
			this.tr_expedition_requires.Add(2, TR.Value("adventure_team_expedition_REQUIRE_ANY_DIFF_BASE_OCCU"));
			this.tr_expedition_requires.Add(3, TR.Value("adventure_team_expedition_REQUIRE_ANY_DIFF_CHANGED_OCCU"));
		}

		// Token: 0x0600AF28 RID: 44840 RVA: 0x002649CC File Offset: 0x00262DCC
		private void _ClearTR()
		{
			this.tr_rename_content_empty = string.Empty;
			this.tr_rename_content_beyond_max = string.Empty;
			this.tr_rename_content_illegal = string.Empty;
			this.tr_rename_content_be_used = string.Empty;
			this.tr_rename_content_no_changed = string.Empty;
			this.tr_rename_content_failed = string.Empty;
			this.tr_rename_content_success = string.Empty;
			this.tr_rename_quick_buy_ask = string.Empty;
			this.tr_adventure_team_level_up_tip = string.Empty;
			this.tr_select_role_extend_succ = string.Empty;
			this.tr_select_role_field_reach_max = string.Empty;
			this.tr_select_role_field_not_use_total = string.Empty;
			this.tr_select_role_field_extend_failed = string.Empty;
			this.tr_collection_first_tab_name = string.Empty;
			this.tr_expedition_dispatch_succeed = string.Empty;
			this.tr_expedition_dispatch_fail = string.Empty;
			this.tr_expedition_dispatch_dup = string.Empty;
			this.tr_expedition_requires.Clear();
		}

		// Token: 0x0600AF29 RID: 44841 RVA: 0x00264AA0 File Offset: 0x00262EA0
		private void _InitLocalData()
		{
			if (this.bLocalDataInited)
			{
				return;
			}
			this.bLocalDataInited = true;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(120, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.renameLimitCharNum = tableItem.Value;
			}
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(596, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				this.weeklyTaskRefreshHour = tableItem2.Value;
			}
			this._InitAdventureTeamTableData();
			this._InitBlessCrystalModel();
			this._InitBountyModel();
			this._InitExpeditionMapLocalData();
			this._InitPassBlessModel();
			this._InitCollectionCharacterModel();
			this._InitWeeklyTaskModel();
		}

		// Token: 0x0600AF2A RID: 44842 RVA: 0x00264B40 File Offset: 0x00262F40
		private void _ClearLocalData()
		{
			this.bLocalDataInited = false;
			this.bNetInited = false;
			if (this.mAdventureTeamUpLevelExpDic != null)
			{
				this.mAdventureTeamUpLevelExpDic.Clear();
			}
			if (this.mCharacterCollectionDic != null)
			{
				foreach (KeyValuePair<int, List<CharacterCollectionModel>> keyValuePair in this.mCharacterCollectionDic)
				{
					List<CharacterCollectionModel> value = keyValuePair.Value;
					if (value != null)
					{
						value.Clear();
					}
				}
				this.mCharacterCollectionDic.Clear();
			}
			if (this.mTotalCharacterCollection != null)
			{
				this.mTotalCharacterCollection.Clear();
			}
			if (this.mBaseJobTableIdWithNameDic != null)
			{
				this.mBaseJobTableIdWithNameDic.Clear();
			}
			this.blessCrystalModel = null;
			this.bountyModel = null;
			this.inheritBlessModel = null;
			this.inheritExpModel = null;
			this.mPassBlessItem = null;
			this.isPassBlessOwnCountAddup = false;
			this.isPassBlessOwnCountInit = false;
			this.isPassBlessCanUse = false;
			this.isPassBlessEnoughOnFirstLogin = false;
			this.hasPassBlessCheckedToday = false;
			this.hasWeeklyTaskCheckedToday = false;
			this.uiTempInheritBlessModel = null;
			this.uiTempInheritExpModel = null;
			this.OnAdventureTeamLevelChangedFlag = false;
			this.onFirstCheckWeeklyTaskFlag = true;
			this.onFirstCheckPassBlessFlag = true;
			if (this.mExpeditionMapBaseInfo != null)
			{
				this.mExpeditionMapBaseInfo.Clear();
			}
			this.mExpeditionRoles = null;
			this.mCanGetReward = false;
			if (this.mExpeditionMapNetInfo != null)
			{
				this.mExpeditionMapNetInfo.Clear();
			}
			this._UnInitWeeklyTaskModel();
		}

		// Token: 0x0600AF2B RID: 44843 RVA: 0x00264C9C File Offset: 0x0026309C
		private void _InitAdventureTeamTableData()
		{
			if (this.mAdventureTeamUpLevelExpDic == null)
			{
				this.mAdventureTeamUpLevelExpDic = new Dictionary<int, ulong>();
			}
			else
			{
				this.mAdventureTeamUpLevelExpDic.Clear();
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<AdventureTeamTable>();
			if (table == null)
			{
				return;
			}
			Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, object> keyValuePair = enumerator.Current;
				AdventureTeamTable adventureTeamTable = keyValuePair.Value as AdventureTeamTable;
				if (adventureTeamTable != null)
				{
					ulong value;
					if (ulong.TryParse(adventureTeamTable.Exp, out value))
					{
						this.mAdventureTeamUpLevelExpDic[adventureTeamTable.ID] = value;
					}
					if (num == 0)
					{
						this.adventureTeamLevelMaximun = (this.adventureTeamLevelMinimun = adventureTeamTable.ID);
					}
					if (adventureTeamTable.ID > this.adventureTeamLevelMaximun)
					{
						this.adventureTeamLevelMaximun = adventureTeamTable.ID;
					}
					else if (adventureTeamTable.ID < this.adventureTeamLevelMinimun)
					{
						this.adventureTeamLevelMinimun = adventureTeamTable.ID;
					}
					num++;
				}
			}
		}

		// Token: 0x0600AF2C RID: 44844 RVA: 0x00264DA4 File Offset: 0x002631A4
		private string _GetAdventureTeamTableIncomeDescByType(int adventureTeamLevel)
		{
			string empty = string.Empty;
			AdventureTeamTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AdventureTeamTable>(adventureTeamLevel, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return empty;
			}
			return tableItem.PropertyIncomeDesc;
		}

		// Token: 0x0600AF2D RID: 44845 RVA: 0x00264DE0 File Offset: 0x002631E0
		private bool _CheckHasUnUsedRoleFields()
		{
			bool result = false;
			if (RecoveryRoleCachedObject.HasOwnedRoles < RecoveryRoleCachedObject.EnabledRoleField)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600AF2E RID: 44846 RVA: 0x00264E04 File Offset: 0x00263204
		private void _InitBlessCrystalModel()
		{
			if (this.blessCrystalModel == null)
			{
				this.blessCrystalModel = new BlessCrystalModel();
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(496, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.blessCrystalModel.itemTableId = (uint)tableItem.Value;
				ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableItem.Value, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					this.blessCrystalModel.itemName = tableItem2.Name;
					this.blessCrystalModel.itemIconPath = tableItem2.Icon;
				}
			}
			SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(483, string.Empty, string.Empty);
			if (tableItem3 != null)
			{
				this.blessCrystalModel.currNumMaximum = tableItem3.Value;
			}
			SystemValueTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(484, string.Empty, string.Empty);
			if (tableItem4 != null)
			{
				this.blessCrystalModel.currExpMaximum = (ulong)((long)tableItem4.Value);
			}
		}

		// Token: 0x0600AF2F RID: 44847 RVA: 0x00264F00 File Offset: 0x00263300
		private void _InitBountyModel()
		{
			if (this.bountyModel == null)
			{
				this.bountyModel = new BountyModle();
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(540, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.bountyModel.itemTableId = (uint)tableItem.Value;
				ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableItem.Value, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					this.bountyModel.itemName = tableItem2.Name;
					this.bountyModel.itemIconPath = tableItem2.Icon;
				}
			}
		}

		// Token: 0x0600AF30 RID: 44848 RVA: 0x00264F98 File Offset: 0x00263398
		private void _InitExpeditionMapLocalData()
		{
			if (this.mExpeditionMapBaseInfo == null)
			{
				this.mExpeditionMapBaseInfo = new ExpeditionMapBaseInfo();
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ExpeditionMapTable>();
			if (table == null)
			{
				return;
			}
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ExpeditionMapTable expeditionMapTable = keyValuePair.Value as ExpeditionMapTable;
				if (expeditionMapTable != null)
				{
					this.mExpeditionMapBaseInfo.expeditionMapDic.Add(expeditionMapTable.ID, new ExpeditionMapModel((byte)expeditionMapTable.ID, expeditionMapTable.MapName, expeditionMapTable.PlayerLevelLimit, expeditionMapTable.AdventureTeamLevelLimit, expeditionMapTable.RolesCapacity, expeditionMapTable.ExpeditionTime, expeditionMapTable.BackgroundPath, expeditionMapTable.MiniMapPath));
				}
			}
			Dictionary<int, object> table2 = Singleton<TableManager>.GetInstance().GetTable<ExpeditionMapRewardTable>();
			if (table == null)
			{
				return;
			}
			foreach (KeyValuePair<int, object> keyValuePair2 in table2)
			{
				ExpeditionMapRewardTable expeditionMapRewardTable = keyValuePair2.Value as ExpeditionMapRewardTable;
				if (expeditionMapRewardTable != null)
				{
					ExpeditionRewardCondition condition = ExpeditionRewardCondition.REQUIRE_ANY_OCCU;
					int num = 0;
					if (expeditionMapRewardTable.RequireAnyOccu != 0)
					{
						num = expeditionMapRewardTable.RequireAnyOccu;
					}
					else if (expeditionMapRewardTable.RequireAnySameBaseOccu != 0)
					{
						num = expeditionMapRewardTable.RequireAnySameBaseOccu;
						condition = ExpeditionRewardCondition.REQUIRE_ANY_SAME_BASE_OCCU;
					}
					else if (expeditionMapRewardTable.RequireAnyDiffBaseOccu != 0)
					{
						num = expeditionMapRewardTable.RequireAnyDiffBaseOccu;
						condition = ExpeditionRewardCondition.REQUIRE_ANY_DIFF_BASE_OCCU;
					}
					else if (expeditionMapRewardTable.RequireAnyDiffChangedOccu != 0)
					{
						num = expeditionMapRewardTable.RequireAnyDiffChangedOccu;
						condition = ExpeditionRewardCondition.REQUIRE_ANY_DIFF_CHANGED_OCCU;
					}
					ExpeditionReward item = new ExpeditionReward(num, condition, expeditionMapRewardTable.Rewards);
					this.mExpeditionMapBaseInfo.expeditionMapDic[expeditionMapRewardTable.ExpeditionMapId].rewardList.Add(item);
				}
			}
		}

		// Token: 0x0600AF31 RID: 44849 RVA: 0x00265148 File Offset: 0x00263548
		private void _InitPassBlessModel()
		{
			if (this.inheritBlessModel == null)
			{
				this.inheritBlessModel = new InheritBlessModel();
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(485, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.inheritBlessModel.inheritBlessMaxNum = (uint)tableItem.Value;
			}
			if (this.inheritExpModel == null)
			{
				this.inheritExpModel = new InheritExpModel();
			}
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(486, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				this.inheritExpModel.inheritBlessMaxExp = (ulong)tableItem2.Value;
			}
			SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(487, string.Empty, string.Empty);
			if (tableItem3 != null)
			{
				this.inheritExpModel.inheritBlessUnitExp = (ulong)tableItem3.Value;
			}
			if (this.mPassBlessItem == null)
			{
				SystemValueTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(497, string.Empty, string.Empty);
				if (tableItem4 != null)
				{
					this.mPassBlessItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableItem4.Value, string.Empty, string.Empty);
				}
			}
			this.hasPassBlessCheckedToday = this._IsPassBlessCheckedToday();
		}

		// Token: 0x0600AF32 RID: 44850 RVA: 0x00265270 File Offset: 0x00263670
		private string _getExpeitionMapIdTime(int mapId)
		{
			string arg = string.Empty;
			string arg2 = string.Empty;
			if (ClientApplication.playerinfo != null)
			{
				arg = ClientApplication.playerinfo.serverID.ToString();
				arg2 = ClientApplication.playerinfo.accid.ToString();
			}
			return TR.Value("adventure_team_expedition_mapid_time_setting", arg, arg2, mapId);
		}

		// Token: 0x0600AF33 RID: 44851 RVA: 0x002652D1 File Offset: 0x002636D1
		private void _SetExpeditionMapIdTime(int mapId, int expeditionDuration)
		{
			PlayerPrefs.SetInt(this._getExpeitionMapIdTime(mapId), expeditionDuration);
		}

		// Token: 0x0600AF34 RID: 44852 RVA: 0x002652E0 File Offset: 0x002636E0
		private uint _GetExpeditionMapIdTime(int mapId)
		{
			return (uint)PlayerPrefs.GetInt(this._getExpeitionMapIdTime(mapId), 1);
		}

		// Token: 0x0600AF35 RID: 44853 RVA: 0x002652F0 File Offset: 0x002636F0
		private void _InitCollectionCharacterModel()
		{
			if (this.mBaseJobTableIdWithNameDic == null)
			{
				this.mBaseJobTableIdWithNameDic = new Dictionary<int, string>();
			}
			this.mBaseJobTableIdWithNameDic.Add(0, this.tr_collection_first_tab_name);
			if (this.mCharacterCollectionDic == null)
			{
				this.mCharacterCollectionDic = new Dictionary<int, List<CharacterCollectionModel>>();
			}
			if (this.mTotalCharacterCollection == null)
			{
				this.mTotalCharacterCollection = new List<CharacterCollectionModel>();
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<JobTable>();
			if (table == null)
			{
				return;
			}
			List<CharacterCollectionModel> list = null;
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				JobTable jobTable = keyValuePair.Value as JobTable;
				if (jobTable != null)
				{
					CharacterCollectionModel characterCollectionModel = new CharacterCollectionModel();
					characterCollectionModel.jobTableId = jobTable.ID;
					characterCollectionModel.isTransfer = (jobTable.JobType == 1);
					characterCollectionModel.isJobOpened = (jobTable.Open == 1);
					if (!characterCollectionModel.isTransfer && characterCollectionModel.isJobOpened)
					{
						int jobTableId = characterCollectionModel.jobTableId;
						if (!this.mBaseJobTableIdWithNameDic.ContainsKey(jobTableId))
						{
							this.mBaseJobTableIdWithNameDic.Add(jobTableId, jobTable.Name);
						}
						else
						{
							this.mBaseJobTableIdWithNameDic[jobTableId] = jobTable.Name;
						}
					}
					else
					{
						characterCollectionModel.jobPhotoPath = jobTable.CharacterCollectionPhoto;
						characterCollectionModel.jobNamePath = jobTable.CharacterCollectionArtLetting;
						if (characterCollectionModel.isJobOpened && !string.IsNullOrEmpty(characterCollectionModel.jobPhotoPath) && !string.IsNullOrEmpty(characterCollectionModel.jobNamePath))
						{
							if (this.mCharacterCollectionDic.TryGetValue(jobTable.prejob, out list))
							{
								if (list == null)
								{
									list = new List<CharacterCollectionModel>();
								}
								list.Add(characterCollectionModel);
							}
							else
							{
								this.mCharacterCollectionDic.Add(jobTable.prejob, new List<CharacterCollectionModel>
								{
									characterCollectionModel
								});
							}
							this.mTotalCharacterCollection.Add(characterCollectionModel);
						}
					}
				}
			}
			CharacterCollectionModel item = new CharacterCollectionModel
			{
				jobTableId = 0,
				isTransfer = true,
				isJobOpened = false,
				jobPhotoPath = string.Empty,
				jobNamePath = string.Empty,
				needPlay = false,
				isOwned = false
			};
			this.mCharacterCollectionDic.Add(32767, new List<CharacterCollectionModel>
			{
				item
			});
			this.mTotalCharacterCollection.Add(item);
		}

		// Token: 0x0600AF36 RID: 44854 RVA: 0x00265574 File Offset: 0x00263974
		private void _OnSyncAdventureTeamInfo(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			AdventureTeamInfoSync adventureTeamInfoSync = new AdventureTeamInfoSync();
			adventureTeamInfoSync.decode(data.bytes);
			if (adventureTeamInfoSync.info != null && ClientApplication.playerinfo != null && ClientApplication.playerinfo.adventureTeamInfo != null)
			{
				int adventureTeamLevel = (int)ClientApplication.playerinfo.adventureTeamInfo.adventureTeamLevel;
				if (string.IsNullOrEmpty(ClientApplication.playerinfo.adventureTeamInfo.adventureTeamName) && !string.IsNullOrEmpty(adventureTeamInfoSync.info.adventureTeamName))
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamFuncChanged, null, null, null, null);
				}
				ClientApplication.playerinfo.adventureTeamInfo = adventureTeamInfoSync.info;
				if ((int)adventureTeamInfoSync.info.adventureTeamLevel != adventureTeamLevel)
				{
					this._NotifyLevelUp();
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(this.tr_adventure_team_level_up_tip, adventureTeamInfoSync.info.adventureTeamLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
					this.OnAdventureTeamLevelChangedFlag = true;
				}
			}
		}

		// Token: 0x0600AF37 RID: 44855 RVA: 0x00265660 File Offset: 0x00263A60
		private void _OnAdventureTeamRenameRes(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			WorldAdventureTeamRenameRes worldAdventureTeamRenameRes = new WorldAdventureTeamRenameRes();
			worldAdventureTeamRenameRes.decode(data.bytes);
			uint resCode = worldAdventureTeamRenameRes.resCode;
			switch (resCode)
			{
			case 4000001U:
				SystemNotifyManager.SysNotifyTextAnimation(this.tr_rename_content_illegal, CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case 4000002U:
				SystemNotifyManager.SysNotifyTextAnimation(this.tr_rename_content_no_changed, CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case 4000003U:
				SystemNotifyManager.SysNotifyTextAnimation(this.tr_rename_content_be_used, CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case 4000004U:
				SystemNotifyManager.SysNotifyTextAnimation(this.tr_rename_content_failed, CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			default:
				if (resCode != 0U)
				{
					SystemNotifyManager.SystemNotify((int)worldAdventureTeamRenameRes.resCode, string.Empty);
				}
				else
				{
					if (ClientApplication.playerinfo != null && ClientApplication.playerinfo.adventureTeamInfo != null)
					{
						ClientApplication.playerinfo.adventureTeamInfo.adventureTeamName = worldAdventureTeamRenameRes.newName;
						SystemNotifyManager.SysNotifyFloatingEffect(this.tr_rename_content_success, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					TitleComponent.OnChangeAdventTeamName(0, worldAdventureTeamRenameRes.newName);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamRenameSucc, null, null, null, null);
				}
				break;
			}
		}

		// Token: 0x0600AF38 RID: 44856 RVA: 0x0026576C File Offset: 0x00263B6C
		private void _OnExtensibleRoleFieldUnlockRes(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			WorldExtensibleRoleFieldUnlockRes worldExtensibleRoleFieldUnlockRes = new WorldExtensibleRoleFieldUnlockRes();
			worldExtensibleRoleFieldUnlockRes.decode(data.bytes);
			if (worldExtensibleRoleFieldUnlockRes.resCode == 0U)
			{
				SystemNotifyManager.SysNotifyTextAnimation(this.tr_select_role_extend_succ, CommonTipsDesc.eShowMode.SI_UNIQUE);
				if (ClientApplication.playerinfo != null)
				{
					ClientApplication.playerinfo.newUnLockExtendRoleFieldNum += 1U;
					ClientApplication.playerinfo.unLockedExtendRoleFieldNum += 1U;
				}
			}
			else if (worldExtensibleRoleFieldUnlockRes.resCode == 200022U)
			{
				SystemNotifyManager.SysNotifyTextAnimation(this.tr_select_role_field_reach_max, CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			else if (worldExtensibleRoleFieldUnlockRes.resCode == 200023U)
			{
				SystemNotifyManager.SysNotifyTextAnimation(this.tr_select_role_field_not_use_total, CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			else if (worldExtensibleRoleFieldUnlockRes.resCode == 200024U)
			{
				SystemNotifyManager.SysNotifyTextAnimation(this.tr_select_role_field_extend_failed, CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
		}

		// Token: 0x0600AF39 RID: 44857 RVA: 0x0026583C File Offset: 0x00263C3C
		private void _OnBlessCrystalInfoRes(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			WorldBlessCrystalInfoRes worldBlessCrystalInfoRes = new WorldBlessCrystalInfoRes();
			worldBlessCrystalInfoRes.decode(data.bytes);
			if (worldBlessCrystalInfoRes.resCode == 0U)
			{
				if (this.blessCrystalModel != null)
				{
					if ((long)this.blessCrystalModel.currOwnCount != (long)((ulong)worldBlessCrystalInfoRes.ownBlessCrystalNum))
					{
						this.blessCrystalModel.currOwnCount = (int)worldBlessCrystalInfoRes.ownBlessCrystalNum;
						this._NotifyBlessCrystalCountChanged();
					}
					if (this.blessCrystalModel.currOwnExp != worldBlessCrystalInfoRes.ownBlessCrystalExp)
					{
						this.blessCrystalModel.currOwnExp = worldBlessCrystalInfoRes.ownBlessCrystalExp;
					}
					this._DebugDataManagerLoggger("_OnBlessCrystalInfoRes", "OnAdventureTeamBlessShopReqBaseInfoSucc");
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamBlessCrystalInfoRes, null, null, null, null);
				}
			}
		}

		// Token: 0x0600AF3A RID: 44858 RVA: 0x002658F8 File Offset: 0x00263CF8
		private void _OnAdventureTeamExtraInfoRes(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			WorldAdventureTeamExtraInfoRes worldAdventureTeamExtraInfoRes = new WorldAdventureTeamExtraInfoRes();
			worldAdventureTeamExtraInfoRes.decode(data.bytes);
			if (worldAdventureTeamExtraInfoRes.resCode == 0U)
			{
				if (ClientApplication.playerinfo != null)
				{
					ClientApplication.playerinfo.adventureTeamInfo = worldAdventureTeamExtraInfoRes.extraInfo;
				}
				this._DebugDataManagerLoggger("_OnAdventureTeamExtraInfoRes", "OnAdventureTeamExtraInfo Succ");
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamBaseInfoRes, null, null, null, null);
			}
		}

		// Token: 0x0600AF3B RID: 44859 RVA: 0x0026596C File Offset: 0x00263D6C
		private void _OnWorldAccountCounterNotify(MsgDATA msg)
		{
			WorldAccountCounterNotify worldAccountCounterNotify = new WorldAccountCounterNotify();
			worldAccountCounterNotify.decode(msg.bytes);
			if (worldAccountCounterNotify == null || worldAccountCounterNotify.accCounterList == null)
			{
				return;
			}
			for (int i = 0; i < worldAccountCounterNotify.accCounterList.Length; i++)
			{
				AccountCounterType type = (AccountCounterType)worldAccountCounterNotify.accCounterList[i].type;
				ulong num = worldAccountCounterNotify.accCounterList[i].num;
				switch (type)
				{
				case AccountCounterType.ACC_COUNTER_BLESS_CRYSTAL:
				{
					int num2 = (int)num;
					if (this.blessCrystalModel != null && this.blessCrystalModel.currOwnCount != num2)
					{
						this.blessCrystalModel.currOwnCount = num2;
						this._NotifyBlessCrystalCountChanged();
					}
					break;
				}
				case AccountCounterType.ACC_COUNTER_BLESS_CRYSTAL_EXP:
					if (this.blessCrystalModel != null && this.blessCrystalModel.currOwnExp != num)
					{
						this.blessCrystalModel.currOwnExp = num;
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamBlessCrystalExpChanged, null, null, null, null);
					}
					break;
				case AccountCounterType.ACC_COUNTER_INHERIT_BLESS:
				{
					uint num3 = (uint)num;
					if (this.inheritBlessModel != null && this.inheritBlessModel.ownInheritBlessNum != num3)
					{
						int num4 = (int)(num3 - this.inheritBlessModel.ownInheritBlessNum);
						this.isPassBlessOwnCountAddup = (num4 > 0 && this.isPassBlessOwnCountInit);
						this.inheritBlessModel.ownInheritBlessNum = (uint)num;
						this._NotifyPassBlessCountChanged();
					}
					this.isPassBlessOwnCountInit = true;
					break;
				}
				case AccountCounterType.ACC_COUNTER_INHERIT_BLESS_EXP:
					if (this.inheritExpModel != null && this.inheritExpModel.ownInheritBlessExp != num)
					{
						this.inheritExpModel.ownInheritBlessExp = num;
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamInheritBlessExpChanged, null, null, null, null);
					}
					break;
				case AccountCounterType.ACC_COUNTER_BOUNTY:
				{
					int num5 = (int)num;
					if (this.bountyModel != null && this.bountyModel.currOwnCount != num5)
					{
						this.bountyModel.currOwnCount = num5;
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamBountyCountChanged, null, null, null, null);
					}
					break;
				}
				}
			}
		}

		// Token: 0x0600AF3C RID: 44860 RVA: 0x00265B68 File Offset: 0x00263F68
		private void _OnQueryOwnJobRes(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			WorldQueryOwnOccupationsRes worldQueryOwnOccupationsRes = new WorldQueryOwnOccupationsRes();
			worldQueryOwnOccupationsRes.decode(data.bytes);
			if (worldQueryOwnOccupationsRes.resCode == 0U)
			{
				this._RestoreCharacterCollectionModels(worldQueryOwnOccupationsRes.occus, false);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamCollectionInfoRes, null, null, null, null);
			}
		}

		// Token: 0x0600AF3D RID: 44861 RVA: 0x00265BC0 File Offset: 0x00263FC0
		private void _OnSyncOwnNewJobs(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			WorldQueryOwnOccupationsSync worldQueryOwnOccupationsSync = new WorldQueryOwnOccupationsSync();
			worldQueryOwnOccupationsSync.decode(data.bytes);
			this._RestoreCharacterCollectionModels(worldQueryOwnOccupationsSync.ownNewOccus, true);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamCollectionInfoRes, null, null, null, null);
		}

		// Token: 0x0600AF3E RID: 44862 RVA: 0x00265C08 File Offset: 0x00264008
		private void _RestoreCharacterCollectionModels(byte[] resJobIds, bool isResJobIdNew)
		{
			if (this.mCharacterCollectionDic == null || this.mTotalCharacterCollection == null)
			{
				return;
			}
			List<CharacterCollectionModel> list = null;
			if (resJobIds == null)
			{
				return;
			}
			foreach (int num in resJobIds)
			{
				int num2 = this._GetBaseJobTableIdByTransferJobId(num);
				if (num2 > 0)
				{
					if (this.mCharacterCollectionDic.TryGetValue(num2, out list))
					{
						if (list != null)
						{
							for (int j = 0; j < list.Count; j++)
							{
								CharacterCollectionModel characterCollectionModel = list[j];
								if (characterCollectionModel != null)
								{
									if (characterCollectionModel.jobTableId == num)
									{
										characterCollectionModel.isOwned = true;
										if (isResJobIdNew)
										{
											this.ChangeSelectJobPlayStatus(characterCollectionModel, true);
										}
										break;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600AF3F RID: 44863 RVA: 0x00265CDC File Offset: 0x002640DC
		private int _GetBaseJobTableIdByTransferJobId(int transferJobId)
		{
			int result = 0;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(transferJobId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return result;
			}
			return tableItem.prejob;
		}

		// Token: 0x0600AF40 RID: 44864 RVA: 0x00265D10 File Offset: 0x00264110
		private void _OnPassBlessInfoRes(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			WorldInheritBlessInfoRes worldInheritBlessInfoRes = new WorldInheritBlessInfoRes();
			worldInheritBlessInfoRes.decode(data.bytes);
			if (worldInheritBlessInfoRes.resCode == 0U)
			{
				if (this.inheritBlessModel == null)
				{
					this.inheritBlessModel = new InheritBlessModel();
				}
				if (this.inheritBlessModel.ownInheritBlessNum != worldInheritBlessInfoRes.ownInheritBlessNum)
				{
					this.inheritBlessModel.ownInheritBlessNum = worldInheritBlessInfoRes.ownInheritBlessNum;
				}
				if (this.inheritExpModel == null)
				{
					this.inheritExpModel = new InheritExpModel();
				}
				if (this.inheritExpModel.ownInheritBlessExp != worldInheritBlessInfoRes.ownInheritBlessExp)
				{
					this.inheritExpModel.ownInheritBlessExp = worldInheritBlessInfoRes.ownInheritBlessExp;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamInheritBlessInfoRes, null, null, null, null);
			}
		}

		// Token: 0x0600AF41 RID: 44865 RVA: 0x00265DD4 File Offset: 0x002641D4
		private void _OnUsePassBlessExpRes(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			WorldInheritExpRes worldInheritExpRes = new WorldInheritExpRes();
			worldInheritExpRes.decode(data.bytes);
			if (worldInheritExpRes.resCode == 0U)
			{
				if (this.inheritBlessModel != null && this.inheritBlessModel.ownInheritBlessNum != worldInheritExpRes.ownInheritBlessNum)
				{
					int num = (int)(worldInheritExpRes.ownInheritBlessNum - this.inheritBlessModel.ownInheritBlessNum);
					this.isPassBlessOwnCountAddup = (num > 0);
					this.inheritBlessModel.ownInheritBlessNum = worldInheritExpRes.ownInheritBlessNum;
					this._NotifyPassBlessCountChanged();
				}
				if (this.inheritExpModel != null && this.inheritExpModel.ownInheritBlessExp != worldInheritExpRes.ownInheritBlessExp)
				{
					this.inheritExpModel.ownInheritBlessExp = worldInheritExpRes.ownInheritBlessExp;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamInheritBlessExpChanged, null, null, null, null);
				}
			}
			else if (worldInheritExpRes.resCode == 4000006U)
			{
			}
		}

		// Token: 0x0600AF42 RID: 44866 RVA: 0x00265EC0 File Offset: 0x002642C0
		private void _OnExpeditionMapInfoRes(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			WorldQueryExpeditionMapRes worldQueryExpeditionMapRes = new WorldQueryExpeditionMapRes();
			worldQueryExpeditionMapRes.decode(data.bytes);
			if (worldQueryExpeditionMapRes.resCode == 0U)
			{
				this._RestoreExpeditionMapsNetInfo(worldQueryExpeditionMapRes.mapId, worldQueryExpeditionMapRes.expeditionStatus, worldQueryExpeditionMapRes.durationOfExpedition, worldQueryExpeditionMapRes.endTimeOfExpedition, worldQueryExpeditionMapRes.members);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamExpeditionMapInfoChanged, new ExpeditionMapNetInfo
				{
					mapId = worldQueryExpeditionMapRes.mapId
				}, null, null, null);
			}
		}

		// Token: 0x0600AF43 RID: 44867 RVA: 0x00265F40 File Offset: 0x00264340
		private void _RestoreExpeditionMapsNetInfo(byte netMapId, byte netExpeditionStatus, uint netDurationOfExpedition, uint netEndTimeOfExpedition, ExpeditionMemberInfo[] netMembers)
		{
			ExpeditionMapNetInfo expeditionMapNetInfo = new ExpeditionMapNetInfo();
			expeditionMapNetInfo.mapId = netMapId;
			expeditionMapNetInfo.mapStatus = (ExpeditionStatus)netExpeditionStatus;
			if (expeditionMapNetInfo.mapStatus == ExpeditionStatus.EXPEDITION_STATUS_PREPARE)
			{
				expeditionMapNetInfo.durationOfExpedition = this._GetExpeditionMapIdTime((int)expeditionMapNetInfo.mapId);
			}
			else
			{
				expeditionMapNetInfo.durationOfExpedition = netDurationOfExpedition;
			}
			expeditionMapNetInfo.endTimeOfExpedition = netEndTimeOfExpedition;
			this.mIsChangedExpeditionRoles = true;
			if (expeditionMapNetInfo.roles == null)
			{
				expeditionMapNetInfo.roles = new List<ExpeditionMemberInfo>();
			}
			else
			{
				expeditionMapNetInfo.roles.Clear();
			}
			if (netMembers != null && netMembers.Length != 0)
			{
				for (int i = 0; i < netMembers.Length; i++)
				{
					expeditionMapNetInfo.roles.Add(netMembers[i]);
				}
			}
			this._UpdateLocalExpeditionMapsNetInfo(expeditionMapNetInfo);
			if (this.mExpeditionMapNetInfo != null && expeditionMapNetInfo.mapId == this.mExpeditionMapNetInfo.mapId && this.mExpeditionMapBaseInfo.expeditionMapDic != null && this.mExpeditionMapBaseInfo.expeditionMapDic.ContainsKey((int)expeditionMapNetInfo.mapId))
			{
				ExpeditionMapModel expeditionMapModel = this.mExpeditionMapBaseInfo.expeditionMapDic[(int)expeditionMapNetInfo.mapId];
				if (expeditionMapModel != null)
				{
					ExpeditionMapNetInfo mapNetInfo = expeditionMapModel.mapNetInfo;
					if (mapNetInfo != null)
					{
						if (this.mExpeditionMapNetInfo.durationOfExpedition != mapNetInfo.durationOfExpedition)
						{
							this.mIsChangedExpeditionTime = true;
						}
						else
						{
							this.mIsChangedExpeditionTime = false;
						}
						this._UpdateExpeditionMapNetInfo(this.mExpeditionMapNetInfo, mapNetInfo);
					}
				}
			}
		}

		// Token: 0x0600AF44 RID: 44868 RVA: 0x002660A8 File Offset: 0x002644A8
		private void _OnExpeditionRolesRes(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			WorldQueryOptionalExpeditionRolesRes worldQueryOptionalExpeditionRolesRes = new WorldQueryOptionalExpeditionRolesRes();
			worldQueryOptionalExpeditionRolesRes.decode(data.bytes);
			if (worldQueryOptionalExpeditionRolesRes.resCode == 0U)
			{
				this.mExpeditionRoles = worldQueryOptionalExpeditionRolesRes.roles;
				this.mIsChangedExpeditionMap = false;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamExpeditionRolesChanged, null, null, null, null);
			}
		}

		// Token: 0x0600AF45 RID: 44869 RVA: 0x00266104 File Offset: 0x00264504
		private void _OnDispatchExpeditionTeamRes(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			WorldDispatchExpeditionTeamRes worldDispatchExpeditionTeamRes = new WorldDispatchExpeditionTeamRes();
			worldDispatchExpeditionTeamRes.decode(data.bytes);
			if (worldDispatchExpeditionTeamRes.resCode == 0U)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(this.tr_expedition_dispatch_succeed, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				this._SetExpeditionMapIdTime((int)worldDispatchExpeditionTeamRes.mapId, (int)worldDispatchExpeditionTeamRes.durationOfExpedition);
				this._RestoreExpeditionMapsNetInfo(worldDispatchExpeditionTeamRes.mapId, worldDispatchExpeditionTeamRes.expeditionStatus, worldDispatchExpeditionTeamRes.durationOfExpedition, worldDispatchExpeditionTeamRes.endTimeOfExpedition, worldDispatchExpeditionTeamRes.members);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamExpeditionDispatch, new ExpeditionMapNetInfo
				{
					mapId = worldDispatchExpeditionTeamRes.mapId
				}, null, null, null);
			}
			else if (worldDispatchExpeditionTeamRes.resCode == 4000012U)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(this.tr_expedition_dispatch_dup, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600AF46 RID: 44870 RVA: 0x002661C0 File Offset: 0x002645C0
		private void _OnCancelExpeditionRes(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			WorldCancelExpeditionRes worldCancelExpeditionRes = new WorldCancelExpeditionRes();
			worldCancelExpeditionRes.decode(data.bytes);
			if (worldCancelExpeditionRes.resCode == 0U)
			{
				this._UpdateLocalExpeditionMapsBaseInfo(worldCancelExpeditionRes.mapId, worldCancelExpeditionRes.expeditionStatus);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamExpeddtionCancel, new ExpeditionMapNetInfo
				{
					mapId = worldCancelExpeditionRes.mapId
				}, null, null, null);
			}
		}

		// Token: 0x0600AF47 RID: 44871 RVA: 0x00266230 File Offset: 0x00264630
		private void _OnGetExpeditionRewardsRes(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			WorldGetExpeditionRewardsRes worldGetExpeditionRewardsRes = new WorldGetExpeditionRewardsRes();
			worldGetExpeditionRewardsRes.decode(data.bytes);
			if (worldGetExpeditionRewardsRes.resCode == 0U)
			{
				this._UpdateLocalExpeditionMapsBaseInfo(worldGetExpeditionRewardsRes.mapId, worldGetExpeditionRewardsRes.expeditionStatus);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamExpeditionGetReward, new ExpeditionMapNetInfo
				{
					mapId = worldGetExpeditionRewardsRes.mapId
				}, null, null, null);
			}
		}

		// Token: 0x0600AF48 RID: 44872 RVA: 0x002662A0 File Offset: 0x002646A0
		private void _OnGetAllExpeditionMaps(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			WorldQueryAllExpeditionMapsRes worldQueryAllExpeditionMapsRes = new WorldQueryAllExpeditionMapsRes();
			worldQueryAllExpeditionMapsRes.decode(data.bytes);
			if (worldQueryAllExpeditionMapsRes.resCode == 0U)
			{
				bool flag = false;
				for (int i = 0; i < worldQueryAllExpeditionMapsRes.mapBaseInfos.Length; i++)
				{
					this._UpdateLocalExpeditionMapsBaseInfo(worldQueryAllExpeditionMapsRes.mapBaseInfos[i]);
					if (!flag && worldQueryAllExpeditionMapsRes.mapBaseInfos[i] != null && worldQueryAllExpeditionMapsRes.mapBaseInfos[i].expeditionStatus == 2)
					{
						flag = true;
						this.mCanGetReward = true;
						this._NotifyExpeditionHasRewardChanged();
					}
				}
				if (!flag)
				{
					this.mCanGetReward = false;
					this._NotifyExpeditionHasRewardChanged();
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamExpeditionMiniMapChanged, worldQueryAllExpeditionMapsRes.mapBaseInfos, null, null, null);
			}
		}

		// Token: 0x0600AF49 RID: 44873 RVA: 0x00266360 File Offset: 0x00264760
		private void _OnOnceExpeditionDispatchFinish(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			WorldAllExpeditionMapsSync worldAllExpeditionMapsSync = new WorldAllExpeditionMapsSync();
			worldAllExpeditionMapsSync.decode(data.bytes);
			if (worldAllExpeditionMapsSync.mapBaseInfos != null)
			{
				bool flag = false;
				for (int i = 0; i < worldAllExpeditionMapsSync.mapBaseInfos.Length; i++)
				{
					this._UpdateLocalExpeditionMapsBaseInfo(worldAllExpeditionMapsSync.mapBaseInfos[i]);
					if (!flag && worldAllExpeditionMapsSync.mapBaseInfos[i] != null && worldAllExpeditionMapsSync.mapBaseInfos[i].expeditionStatus == 2)
					{
						flag = true;
						this.ReqGetAllExpeditionMaps();
						if (this.mExpeditionMapNetInfo != null && worldAllExpeditionMapsSync.mapBaseInfos[i].mapId == this.mExpeditionMapNetInfo.mapId)
						{
							this.ReqExpeditionMapInfo(this.mExpeditionMapNetInfo.mapId);
						}
						this.mCanGetReward = true;
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamExpeditionTimerFinish, null, null, null, null);
						this._NotifyExpeditionHasRewardChanged();
					}
				}
				if (!flag)
				{
					this.mCanGetReward = false;
					this._NotifyExpeditionHasRewardChanged();
				}
			}
		}

		// Token: 0x0600AF4A RID: 44874 RVA: 0x00266454 File Offset: 0x00264854
		private void _UpdateLocalExpeditionMapsBaseInfo(ExpeditionMapBaseInfo mapBaseInfo)
		{
			if (mapBaseInfo == null)
			{
				return;
			}
			this._UpdateLocalExpeditionMapsBaseInfo(mapBaseInfo.mapId, mapBaseInfo.expeditionStatus);
		}

		// Token: 0x0600AF4B RID: 44875 RVA: 0x00266470 File Offset: 0x00264870
		private void _UpdateLocalExpeditionMapsBaseInfo(byte mapId, byte expeditionStatus)
		{
			if (this.mExpeditionMapBaseInfo == null || this.mExpeditionMapBaseInfo.expeditionMapDic == null)
			{
				return;
			}
			foreach (KeyValuePair<int, ExpeditionMapModel> keyValuePair in this.mExpeditionMapBaseInfo.expeditionMapDic)
			{
				int key = keyValuePair.Key;
				Dictionary<int, ExpeditionMapModel>.Enumerator enumerator;
				KeyValuePair<int, ExpeditionMapModel> keyValuePair2 = enumerator.Current;
				ExpeditionMapModel value = keyValuePair2.Value;
				if (key == (int)mapId && value != null && value.mapNetInfo != null)
				{
					value.mapNetInfo.mapStatus = (ExpeditionStatus)expeditionStatus;
					if (value.mapNetInfo.mapStatus != ExpeditionStatus.EXPEDITION_STATUS_IN && value.mapNetInfo.mapStatus != ExpeditionStatus.EXPEDITION_STATUS_OVER)
					{
						if (value.mapNetInfo.roles != null && value.mapNetInfo.roles.Count > 0)
						{
							for (int i = 0; i < value.mapNetInfo.roles.Count; i++)
							{
								ExpeditionMemberInfo expeditionMemberInfo = value.mapNetInfo.roles[i];
								expeditionMemberInfo.expeditionMapId = 0;
							}
							this._ResetSelectedExpedtionRoleInfos(value.mapNetInfo.roles);
							value.mapNetInfo.roles.Clear();
						}
					}
				}
			}
		}

		// Token: 0x0600AF4C RID: 44876 RVA: 0x002665B0 File Offset: 0x002649B0
		private void _UpdateLocalExpeditionMapsNetInfo(ExpeditionMapNetInfo mapNetInfo)
		{
			if (mapNetInfo == null)
			{
				return;
			}
			if (this.mExpeditionMapBaseInfo == null || this.mExpeditionMapBaseInfo.expeditionMapDic == null)
			{
				return;
			}
			foreach (KeyValuePair<int, ExpeditionMapModel> keyValuePair in this.mExpeditionMapBaseInfo.expeditionMapDic)
			{
				int key = keyValuePair.Key;
				Dictionary<int, ExpeditionMapModel>.Enumerator enumerator;
				KeyValuePair<int, ExpeditionMapModel> keyValuePair2 = enumerator.Current;
				ExpeditionMapModel value = keyValuePair2.Value;
				if (key == (int)mapNetInfo.mapId && value != null && value.mapNetInfo != null)
				{
					this._UpdateExpeditionMapNetInfo(value.mapNetInfo, mapNetInfo);
				}
			}
		}

		// Token: 0x0600AF4D RID: 44877 RVA: 0x00266650 File Offset: 0x00264A50
		private void _UpdateExpeditionMapNetInfo(ExpeditionMapNetInfo oldNetInfo, ExpeditionMapNetInfo newNetInfo)
		{
			if (oldNetInfo == null || newNetInfo == null)
			{
				return;
			}
			if (oldNetInfo.mapId != newNetInfo.mapId)
			{
				return;
			}
			oldNetInfo.mapStatus = newNetInfo.mapStatus;
			oldNetInfo.durationOfExpedition = newNetInfo.durationOfExpedition;
			oldNetInfo.endTimeOfExpedition = newNetInfo.endTimeOfExpedition;
			if (oldNetInfo.roles == null)
			{
				oldNetInfo.roles = new List<ExpeditionMemberInfo>();
			}
			else
			{
				oldNetInfo.roles.Clear();
			}
			if (newNetInfo.roles != null && newNetInfo.roles.Count > 0)
			{
				for (int i = 0; i < newNetInfo.roles.Count; i++)
				{
					oldNetInfo.roles.Add(newNetInfo.roles[i]);
				}
			}
		}

		// Token: 0x0600AF4E RID: 44878 RVA: 0x00266715 File Offset: 0x00264B15
		private bool _IsAdventureteamWeeklyMission(MissionManager.SingleMissionInfo value)
		{
			return value != null && value.missionItem != null && value.missionItem.TaskType == MissionTable.eTaskType.TASK_ADVENTURE_TEAM_ACCOUNT_WEEKLY;
		}

		// Token: 0x0600AF4F RID: 44879 RVA: 0x00266740 File Offset: 0x00264B40
		private void OnAddAventureTeamWeeklyMission(uint taskID)
		{
			if (!this._IsAdventureteamWeeklyMission(DataManager<MissionManager>.GetInstance().GetMissionInfo(taskID)))
			{
				return;
			}
			this.m_ADTMissionList.Add(DataManager<MissionManager>.GetInstance().GetMissionInfo(taskID));
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamWeeklyTaskChange, null, null, null, null);
			this.UpdateWeeklyTaskRedPoint();
		}

		// Token: 0x0600AF50 RID: 44880 RVA: 0x00266794 File Offset: 0x00264B94
		private void OnUpdateAventureTeamWeeklyMission(uint taskID)
		{
			if (!this._IsAdventureteamWeeklyMission(DataManager<MissionManager>.GetInstance().GetMissionInfo(taskID)))
			{
				return;
			}
			if (this.m_ADTMissionList != null)
			{
				for (int i = 0; i < this.m_ADTMissionList.Count; i++)
				{
					if (this.m_ADTMissionList[i].taskID == taskID)
					{
						this.m_ADTMissionList[i] = DataManager<MissionManager>.GetInstance().GetMissionInfo(taskID);
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamWeeklyTaskChange, null, null, null, null);
						this.UpdateWeeklyTaskRedPoint();
						break;
					}
				}
			}
		}

		// Token: 0x0600AF51 RID: 44881 RVA: 0x0026682C File Offset: 0x00264C2C
		private void OnDeleteAventureTeamWeeklyMission(uint taskID)
		{
			if (this.m_ADTMissionList != null)
			{
				for (int i = 0; i < this.m_ADTMissionList.Count; i++)
				{
					if (this.m_ADTMissionList[i].taskID == taskID)
					{
						this.m_ADTMissionList.RemoveAt(i);
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamWeeklyTaskChange, null, null, null, null);
						this.UpdateWeeklyTaskRedPoint();
						break;
					}
				}
			}
		}

		// Token: 0x0600AF52 RID: 44882 RVA: 0x002668A1 File Offset: 0x00264CA1
		private void OnMissionListChanged()
		{
			this._GetAdventureTeamMissions(ref this.m_ADTMissionList);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamWeeklyTaskChange, null, null, null, null);
			this.UpdateWeeklyTaskRedPoint();
		}

		// Token: 0x0600AF53 RID: 44883 RVA: 0x002668C8 File Offset: 0x00264CC8
		private void _InitWeeklyTaskModel()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(564, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.m_ADTMissionFinishMaxNum = tableItem.Value;
			}
			this._GetAdventureTeamMissions(ref this.m_ADTMissionList);
			this.UpdateWeeklyTaskRedPoint();
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.missionChangedDelegate = (MissionManager.OnMissionChanged)Delegate.Combine(instance.missionChangedDelegate, new MissionManager.OnMissionChanged(this.OnMissionListChanged));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Combine(instance2.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddAventureTeamWeeklyMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance3.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateAventureTeamWeeklyMission));
			MissionManager instance4 = DataManager<MissionManager>.GetInstance();
			instance4.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Combine(instance4.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnDeleteAventureTeamWeeklyMission));
			this.hasWeeklyTaskCheckedToday = this._IsWeeklyTaskCheckedToday();
		}

		// Token: 0x0600AF54 RID: 44884 RVA: 0x002669B8 File Offset: 0x00264DB8
		private void _UnInitWeeklyTaskModel()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Remove(instance.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnDeleteAventureTeamWeeklyMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateAventureTeamWeeklyMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(instance3.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddAventureTeamWeeklyMission));
			MissionManager instance4 = DataManager<MissionManager>.GetInstance();
			instance4.missionChangedDelegate = (MissionManager.OnMissionChanged)Delegate.Remove(instance4.missionChangedDelegate, new MissionManager.OnMissionChanged(this.OnMissionListChanged));
			this.m_ADTMissionList.Clear();
			this.hasWeeklyTaskReceived = false;
		}

		// Token: 0x0600AF55 RID: 44885 RVA: 0x00266A70 File Offset: 0x00264E70
		private void UpdateWeeklyTaskRedPoint()
		{
			int num = this._GetFinishedWeeklyTaskNum();
			for (int i = 0; i < this.m_ADTMissionList.Count; i++)
			{
				if (this.m_ADTMissionList[i].status == 2 && num < this.ADTMissionFinishMaxNum)
				{
					if (!this.hasWeeklyTaskReceived)
					{
						this.hasWeeklyTaskReceived = true;
						this._NotifyWeeklyTaskStatusChanged();
					}
					return;
				}
			}
			if (this.hasWeeklyTaskReceived)
			{
				this.hasWeeklyTaskReceived = false;
				this._NotifyWeeklyTaskStatusChanged();
			}
		}

		// Token: 0x0600AF56 RID: 44886 RVA: 0x00266AF4 File Offset: 0x00264EF4
		private void _OnServerSwitchFunc(ServerSceneFuncSwitch funcSwitch)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamFuncChanged, null, null, null, null);
		}

		// Token: 0x0600AF57 RID: 44887 RVA: 0x00266B09 File Offset: 0x00264F09
		private bool IsAdventureTeamNameEmpty()
		{
			return ClientApplication.playerinfo == null || ClientApplication.playerinfo.adventureTeamInfo == null || string.IsNullOrEmpty(ClientApplication.playerinfo.adventureTeamInfo.adventureTeamName);
		}

		// Token: 0x0600AF58 RID: 44888 RVA: 0x00266B44 File Offset: 0x00264F44
		public string GetAdventureTeamIncomeDescByLevel(int adventureTeamLevel)
		{
			return this._GetAdventureTeamTableIncomeDescByType(adventureTeamLevel);
		}

		// Token: 0x0600AF59 RID: 44889 RVA: 0x00266B5C File Offset: 0x00264F5C
		public int GetAdventureTeamLevel()
		{
			int result = 1;
			if (ClientApplication.playerinfo != null && ClientApplication.playerinfo.adventureTeamInfo != null)
			{
				result = (int)ClientApplication.playerinfo.adventureTeamInfo.adventureTeamLevel;
			}
			return result;
		}

		// Token: 0x0600AF5A RID: 44890 RVA: 0x00266B98 File Offset: 0x00264F98
		public string GetAdventureTeamName()
		{
			string result = DataManager<PlayerBaseData>.GetInstance().Name;
			if (ClientApplication.playerinfo != null && ClientApplication.playerinfo.adventureTeamInfo != null)
			{
				result = ClientApplication.playerinfo.adventureTeamInfo.adventureTeamName;
			}
			return result;
		}

		// Token: 0x0600AF5B RID: 44891 RVA: 0x00266BDC File Offset: 0x00264FDC
		public string GetColorAdventureTeamName()
		{
			string adventureTeamName = this.GetAdventureTeamName();
			string adventureTeamGrade = this.GetAdventureTeamGrade();
			return AdventureTeamDataManager.ChangeColorByGrade(adventureTeamName, adventureTeamGrade);
		}

		// Token: 0x0600AF5C RID: 44892 RVA: 0x00266C00 File Offset: 0x00265000
		public int GetAdventureTeamCurrExp()
		{
			int result = 0;
			if (ClientApplication.playerinfo != null && ClientApplication.playerinfo.adventureTeamInfo != null)
			{
				result = (int)ClientApplication.playerinfo.adventureTeamInfo.adventureTeamExp;
			}
			return result;
		}

		// Token: 0x0600AF5D RID: 44893 RVA: 0x00266C3C File Offset: 0x0026503C
		public ulong GetAdventureTeamUpLevelExp()
		{
			ulong result = 0UL;
			int adventureTeamLevel = this.GetAdventureTeamLevel();
			if (adventureTeamLevel >= this.adventureTeamLevelMaximun)
			{
				return 0UL;
			}
			if (this.mAdventureTeamUpLevelExpDic != null && this.mAdventureTeamUpLevelExpDic.ContainsKey(adventureTeamLevel))
			{
				result = this.mAdventureTeamUpLevelExpDic[adventureTeamLevel];
			}
			return result;
		}

		// Token: 0x0600AF5E RID: 44894 RVA: 0x00266C8C File Offset: 0x0026508C
		public KeyValuePair<ulong, ulong> GetAdventureTeamCurrExpWithUpLevelExp(ulong currExp)
		{
			return new KeyValuePair<ulong, ulong>(currExp, this.GetAdventureTeamUpLevelExp());
		}

		// Token: 0x0600AF5F RID: 44895 RVA: 0x00266C9C File Offset: 0x0026509C
		public KeyValuePair<ulong, ulong> GetBlessCrystalShopCurrExpWithMaxExp(ulong currExp)
		{
			ulong value = currExp;
			if (this.blessCrystalModel != null)
			{
				value = this.blessCrystalModel.currExpMaximum;
			}
			return new KeyValuePair<ulong, ulong>(currExp, value);
		}

		// Token: 0x0600AF60 RID: 44896 RVA: 0x00266CC9 File Offset: 0x002650C9
		public ulong GetAdventureTeamBlessCrystalCount()
		{
			if (this.blessCrystalModel != null)
			{
				return (ulong)this.blessCrystalModel.currOwnCount;
			}
			return 0UL;
		}

		// Token: 0x0600AF61 RID: 44897 RVA: 0x00266CE5 File Offset: 0x002650E5
		public ulong GetAdventureTeamBountyCount()
		{
			if (this.bountyModel != null)
			{
				return (ulong)this.bountyModel.currOwnCount;
			}
			return 0UL;
		}

		// Token: 0x0600AF62 RID: 44898 RVA: 0x00266D01 File Offset: 0x00265101
		public ulong GetAdventureTeamPassBlessCount()
		{
			if (this.inheritBlessModel != null)
			{
				return (ulong)this.inheritBlessModel.ownInheritBlessNum;
			}
			return 0UL;
		}

		// Token: 0x0600AF63 RID: 44899 RVA: 0x00266D1D File Offset: 0x0026511D
		public ulong GetAdventureTeamPassBlessExp()
		{
			if (this.inheritExpModel != null)
			{
				return this.inheritExpModel.ownInheritBlessExp;
			}
			return 0UL;
		}

		// Token: 0x0600AF64 RID: 44900 RVA: 0x00266D38 File Offset: 0x00265138
		public ulong GetAdventureTeamPassBlessUnitExp()
		{
			if (this.inheritExpModel != null)
			{
				return this.inheritExpModel.inheritBlessUnitExp;
			}
			return 0UL;
		}

		// Token: 0x0600AF65 RID: 44901 RVA: 0x00266D53 File Offset: 0x00265153
		public string GetAdventureTeamGrade()
		{
			if (ClientApplication.playerinfo != null && ClientApplication.playerinfo.adventureTeamInfo != null)
			{
				return ClientApplication.playerinfo.adventureTeamInfo.adventureTeamGrade;
			}
			return string.Empty;
		}

		// Token: 0x0600AF66 RID: 44902 RVA: 0x00266D84 File Offset: 0x00265184
		public string GetColorAdventureTeamGrade()
		{
			string adventureTeamGrade = this.GetAdventureTeamGrade();
			return AdventureTeamDataManager.ChangeColorByGrade(adventureTeamGrade, adventureTeamGrade);
		}

		// Token: 0x0600AF67 RID: 44903 RVA: 0x00266DA0 File Offset: 0x002651A0
		public int GetAdventureTeamGradeTableId()
		{
			string adventureTeamGrade = this.GetAdventureTeamGrade();
			return (int)AdventureTeamDataManager.GetAdventureTeamGradeEnum(adventureTeamGrade);
		}

		// Token: 0x0600AF68 RID: 44904 RVA: 0x00266DBC File Offset: 0x002651BC
		public uint GetAdventureTeamRank()
		{
			if (ClientApplication.playerinfo != null && ClientApplication.playerinfo.adventureTeamInfo != null)
			{
				return ClientApplication.playerinfo.adventureTeamInfo.adventureTeamRanking;
			}
			return 0U;
		}

		// Token: 0x0600AF69 RID: 44905 RVA: 0x00266DE8 File Offset: 0x002651E8
		public uint GetAdventureTeamScore()
		{
			if (ClientApplication.playerinfo != null && ClientApplication.playerinfo.adventureTeamInfo != null)
			{
				return ClientApplication.playerinfo.adventureTeamInfo.adventureTeamRoleTotalScore;
			}
			return 0U;
		}

		// Token: 0x0600AF6A RID: 44906 RVA: 0x00266E14 File Offset: 0x00265214
		public int GetAdventureTeamTitleTableIdByRanking(int ranking)
		{
			if (ranking <= 0)
			{
				return 0;
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<AdventureTeamTitleTypeTable>();
			if (table == null)
			{
				return 0;
			}
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				AdventureTeamTitleTypeTable adventureTeamTitleTypeTable = keyValuePair.Value as AdventureTeamTitleTypeTable;
				if (adventureTeamTitleTypeTable != null)
				{
					if (adventureTeamTitleTypeTable.LimitType == AdventureTeamTitleTypeTable.eLimitType.Ranking)
					{
						if (ranking >= adventureTeamTitleTypeTable.RankingRangeMin && ranking <= adventureTeamTitleTypeTable.RankingRangeMax)
						{
							return adventureTeamTitleTypeTable.TitleTableID;
						}
					}
				}
			}
			return 0;
		}

		// Token: 0x0600AF6B RID: 44907 RVA: 0x00266EA8 File Offset: 0x002652A8
		public string GetAdventureTeamTitleResPathByRanking(int ranking)
		{
			int adventureTeamTitleTableIdByRanking = this.GetAdventureTeamTitleTableIdByRanking(ranking);
			if (adventureTeamTitleTableIdByRanking <= 0)
			{
				return string.Empty;
			}
			NewTitleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewTitleTable>(adventureTeamTitleTableIdByRanking, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			return tableItem.path;
		}

		// Token: 0x0600AF6C RID: 44908 RVA: 0x00266EF4 File Offset: 0x002652F4
		public List<CharacterCollectionModel> GetCharacterCollectionModelsByBaseJobId(int baseJobId)
		{
			if (baseJobId <= 0)
			{
				return this.mTotalCharacterCollection;
			}
			List<CharacterCollectionModel> list = null;
			if (this.mCharacterCollectionDic == null)
			{
				return list;
			}
			if (this.mCharacterCollectionDic.TryGetValue(baseJobId, out list))
			{
				list.Sort((CharacterCollectionModel x, CharacterCollectionModel y) => x.jobTableId.CompareTo(y.jobTableId));
				return list;
			}
			if (list != null && list.Count > 0)
			{
				return new List<CharacterCollectionModel>
				{
					list[0]
				};
			}
			return list;
		}

		// Token: 0x0600AF6D RID: 44909 RVA: 0x00266F80 File Offset: 0x00265380
		public int[] GetTotalBaseJobTabIds()
		{
			int[] array = null;
			if (this.mBaseJobTableIdWithNameDic == null || this.mBaseJobTableIdWithNameDic.Keys == null)
			{
				return array;
			}
			array = new int[this.mBaseJobTableIdWithNameDic.Keys.Count];
			Dictionary<int, string>.KeyCollection.Enumerator enumerator = this.mBaseJobTableIdWithNameDic.Keys.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				int num2 = enumerator.Current;
				array[num] = num2;
				num++;
			}
			return array;
		}

		// Token: 0x0600AF6E RID: 44910 RVA: 0x00266FF8 File Offset: 0x002653F8
		public string[] GetTotalBaseJobNames()
		{
			string[] array = null;
			if (this.mBaseJobTableIdWithNameDic == null || this.mBaseJobTableIdWithNameDic.Values == null)
			{
				return array;
			}
			array = new string[this.mBaseJobTableIdWithNameDic.Values.Count];
			Dictionary<int, string>.ValueCollection.Enumerator enumerator = this.mBaseJobTableIdWithNameDic.Values.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				string text = enumerator.Current;
				array[num] = text;
				num++;
			}
			return array;
		}

		// Token: 0x0600AF6F RID: 44911 RVA: 0x00267070 File Offset: 0x00265470
		public bool[] GetTotalSubJobOwnStatus()
		{
			int[] totalBaseJobTabIds = this.GetTotalBaseJobTabIds();
			if (totalBaseJobTabIds == null || totalBaseJobTabIds.Length == 0)
			{
				return null;
			}
			if (this.mCharacterCollectionDic == null || this.mCharacterCollectionDic.Keys.Count == 0)
			{
				return null;
			}
			bool[] array = new bool[totalBaseJobTabIds.Length];
			for (int i = totalBaseJobTabIds.Length - 1; i > 0; i--)
			{
				int key = totalBaseJobTabIds[i];
				List<CharacterCollectionModel> list = null;
				if (this.mCharacterCollectionDic.TryGetValue(key, out list))
				{
					if (list != null)
					{
						for (int j = 0; j < list.Count; j++)
						{
							CharacterCollectionModel characterCollectionModel = list[j];
							if (characterCollectionModel != null)
							{
								if (characterCollectionModel.needPlay)
								{
									array[i] = true;
									break;
								}
							}
						}
					}
				}
			}
			for (int k = array.Length - 1; k > 0; k--)
			{
				if (array[k])
				{
					array[0] = true;
					break;
				}
			}
			return array;
		}

		// Token: 0x0600AF70 RID: 44912 RVA: 0x00267170 File Offset: 0x00265570
		public int IsAnySameBaseOccu(int[] occuList)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			for (int i = 0; i < occuList.Length; i++)
			{
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(occuList[i], string.Empty, string.Empty);
				int num;
				if (tableItem.JobType == 1)
				{
					num = tableItem.prejob;
				}
				else
				{
					num = tableItem.ID;
				}
				if (dictionary.ContainsKey(num))
				{
					Dictionary<int, int> dictionary2;
					int key;
					(dictionary2 = dictionary)[key = num] = dictionary2[key] + 1;
				}
				else
				{
					dictionary.Add(num, 1);
				}
			}
			int num2 = 0;
			foreach (int num3 in dictionary.Values)
			{
				if (num3 > num2)
				{
					num2 = num3;
				}
			}
			return num2;
		}

		// Token: 0x0600AF71 RID: 44913 RVA: 0x0026725C File Offset: 0x0026565C
		private List<ExpeditionMemberInfo> _GetMaxNumSameBaseOccuInfos(List<ExpeditionMemberInfo> roleInfos)
		{
			List<ExpeditionMemberInfo> result = new List<ExpeditionMemberInfo>();
			if (roleInfos == null || roleInfos.Count <= 0)
			{
				return result;
			}
			Dictionary<int, List<ExpeditionMemberInfo>> dictionary = new Dictionary<int, List<ExpeditionMemberInfo>>();
			for (int i = 0; i < roleInfos.Count; i++)
			{
				ExpeditionMemberInfo expeditionMemberInfo = roleInfos[i];
				if (expeditionMemberInfo != null)
				{
					JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)expeditionMemberInfo.occu, string.Empty, string.Empty);
					if (tableItem != null)
					{
						int key;
						if (tableItem.JobType == 1)
						{
							key = tableItem.prejob;
						}
						else
						{
							key = tableItem.ID;
						}
						if (dictionary.ContainsKey(key) && dictionary[key] != null)
						{
							dictionary[key].Add(expeditionMemberInfo);
						}
						else
						{
							dictionary.Add(key, new List<ExpeditionMemberInfo>
							{
								expeditionMemberInfo
							});
						}
					}
				}
			}
			int num = 0;
			int key2 = 0;
			foreach (KeyValuePair<int, List<ExpeditionMemberInfo>> keyValuePair in dictionary)
			{
				List<ExpeditionMemberInfo> value = keyValuePair.Value;
				if (value != null)
				{
					if (value.Count > num)
					{
						Dictionary<int, List<ExpeditionMemberInfo>>.Enumerator enumerator;
						KeyValuePair<int, List<ExpeditionMemberInfo>> keyValuePair2 = enumerator.Current;
						key2 = keyValuePair2.Key;
						num = value.Count;
					}
				}
			}
			if (dictionary.ContainsKey(key2))
			{
				result = dictionary[key2];
			}
			return result;
		}

		// Token: 0x0600AF72 RID: 44914 RVA: 0x002673C4 File Offset: 0x002657C4
		public int IsAnyDiffBaseOccu(int[] occuList)
		{
			int num = 0;
			List<int> list = new List<int>();
			for (int i = 0; i < occuList.Length; i++)
			{
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(occuList[i], string.Empty, string.Empty);
				int item;
				if (tableItem.JobType == 1)
				{
					item = tableItem.prejob;
				}
				else
				{
					item = tableItem.ID;
				}
				if (!list.Contains(item))
				{
					list.Add(item);
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600AF73 RID: 44915 RVA: 0x00267440 File Offset: 0x00265840
		private List<ExpeditionMemberInfo> _GetMaxNumDiffBaseOccuInfos(List<ExpeditionMemberInfo> roleInfos)
		{
			List<ExpeditionMemberInfo> list = new List<ExpeditionMemberInfo>();
			List<int> list2 = ListPool<int>.Get();
			if (roleInfos == null || roleInfos.Count <= 0)
			{
				return list;
			}
			for (int i = 0; i < roleInfos.Count; i++)
			{
				ExpeditionMemberInfo expeditionMemberInfo = roleInfos[i];
				if (expeditionMemberInfo != null)
				{
					JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)expeditionMemberInfo.occu, string.Empty, string.Empty);
					if (tableItem != null)
					{
						int item;
						if (tableItem.JobType == 1)
						{
							item = tableItem.prejob;
						}
						else
						{
							item = tableItem.ID;
						}
						if (!list2.Contains(item))
						{
							list2.Add(item);
							list.Add(expeditionMemberInfo);
						}
					}
				}
			}
			ListPool<int>.Release(list2);
			return list;
		}

		// Token: 0x0600AF74 RID: 44916 RVA: 0x00267508 File Offset: 0x00265908
		public int IsAnyDiffChangedOccu(int[] occuList)
		{
			int num = 0;
			List<int> list = new List<int>();
			for (int i = 0; i < occuList.Length; i++)
			{
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(occuList[i], string.Empty, string.Empty);
				if (tableItem.JobType != 0)
				{
					if (!list.Contains(occuList[i]))
					{
						list.Add(occuList[i]);
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0600AF75 RID: 44917 RVA: 0x00267578 File Offset: 0x00265978
		private List<ExpeditionMemberInfo> _GetMaxNumDiffChangedOccuInfos(List<ExpeditionMemberInfo> roleInfos)
		{
			List<ExpeditionMemberInfo> list = new List<ExpeditionMemberInfo>();
			List<int> list2 = ListPool<int>.Get();
			if (roleInfos == null || roleInfos.Count <= 0)
			{
				return list;
			}
			for (int i = 0; i < roleInfos.Count; i++)
			{
				ExpeditionMemberInfo expeditionMemberInfo = roleInfos[i];
				if (expeditionMemberInfo != null)
				{
					JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)expeditionMemberInfo.occu, string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (tableItem.JobType != 0)
						{
							if (!list2.Contains((int)expeditionMemberInfo.occu))
							{
								list2.Add((int)expeditionMemberInfo.occu);
								list.Add(expeditionMemberInfo);
							}
						}
					}
				}
			}
			ListPool<int>.Release(list2);
			return list;
		}

		// Token: 0x0600AF76 RID: 44918 RVA: 0x00267633 File Offset: 0x00265A33
		public bool IsExpeditionMapEnable()
		{
			return this.mExpeditionMapNetInfo != null && this.mExpeditionMapNetInfo.mapStatus == ExpeditionStatus.EXPEDITION_STATUS_PREPARE;
		}

		// Token: 0x0600AF77 RID: 44919 RVA: 0x00267658 File Offset: 0x00265A58
		public int GetExpeditionRolesNum()
		{
			int num = 0;
			for (int i = 0; i < this.ExpeditionMapNetInfo.roles.Count; i++)
			{
				if (this.ExpeditionMapNetInfo.roles[i] != null)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600AF78 RID: 44920 RVA: 0x002676A4 File Offset: 0x00265AA4
		public List<ExpeditionMemberInfo>[] GetExpeditionRolesList()
		{
			if (this.mExpeditionMapNetInfo == null)
			{
				return new List<ExpeditionMemberInfo>[0];
			}
			List<ExpeditionMemberInfo> list = new List<ExpeditionMemberInfo>();
			List<ExpeditionMemberInfo> list2 = new List<ExpeditionMemberInfo>();
			List<ExpeditionMemberInfo> list3 = new List<ExpeditionMemberInfo>();
			if (this.mExpeditionRoles == null)
			{
				return null;
			}
			for (int i = 0; i < this.mExpeditionRoles.Length; i++)
			{
				bool flag = false;
				for (int j = 0; j < this.mExpeditionMapNetInfo.roles.Count; j++)
				{
					if (this.mExpeditionMapNetInfo.roles[j] != null && this.mExpeditionMapNetInfo.roles[j].roleid == this.mExpeditionRoles[i].roleid)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					if (this.mExpeditionRoles[i].expeditionMapId != 0)
					{
						list3.Add(this.mExpeditionRoles[i]);
					}
					else if ((int)this.mExpeditionRoles[i].level < this.mExpeditionMapBaseInfo.expeditionMapDic[(int)this.mExpeditionMapNetInfo.mapId].playerLevelLimit)
					{
						list2.Add(this.mExpeditionRoles[i]);
					}
					else
					{
						list.Add(this.mExpeditionRoles[i]);
					}
				}
			}
			return new List<ExpeditionMemberInfo>[]
			{
				list,
				list2,
				list3
			};
		}

		// Token: 0x0600AF79 RID: 44921 RVA: 0x00267804 File Offset: 0x00265C04
		public bool RemoveExpeditionRole(ExpeditionMemberInfo info)
		{
			if (this.mExpeditionMapNetInfo == null)
			{
				return false;
			}
			for (int i = 0; i < this.mExpeditionMapNetInfo.roles.Count; i++)
			{
				if (this.mExpeditionMapNetInfo.roles[i] != null && this.mExpeditionMapNetInfo.roles[i].roleid == info.roleid)
				{
					this.mExpeditionMapNetInfo.roles.RemoveAt(i);
					this.mIsChangedExpeditionRoles = true;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamExpeditionRolesSelected, null, null, null, null);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600AF7A RID: 44922 RVA: 0x002678A4 File Offset: 0x00265CA4
		public bool AddExpeditionRole(ExpeditionMemberInfo info)
		{
			if (this.mExpeditionMapNetInfo == null)
			{
				return false;
			}
			int rolesCapacity = this.mExpeditionMapBaseInfo.expeditionMapDic[(int)this.mExpeditionMapNetInfo.mapId].rolesCapacity;
			if (this.mExpeditionMapNetInfo.roles.Count == rolesCapacity)
			{
				SystemNotifyManager.SysNotifyTextAnimation(string.Format(this.tr_expedition_dispatch_fail, rolesCapacity), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return false;
			}
			for (int i = 0; i < this.mExpeditionMapNetInfo.roles.Count; i++)
			{
				if (this.mExpeditionMapNetInfo.roles[i] != null && this.mExpeditionMapNetInfo.roles[i].roleid == info.roleid)
				{
					return false;
				}
			}
			this.mExpeditionMapNetInfo.roles.Add(info);
			this.mIsChangedExpeditionRoles = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamExpeditionRolesSelected, null, null, null, null);
			return true;
		}

		// Token: 0x0600AF7B RID: 44923 RVA: 0x00267994 File Offset: 0x00265D94
		public bool IsRolesInExpeditionList(ExpeditionMemberInfo info)
		{
			if (this.mExpeditionMapNetInfo == null)
			{
				return false;
			}
			for (int i = 0; i < this.mExpeditionMapNetInfo.roles.Count; i++)
			{
				if (this.mExpeditionMapNetInfo.roles[i] != null && this.mExpeditionMapNetInfo.roles[i].roleid == info.roleid)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600AF7C RID: 44924 RVA: 0x00267A0C File Offset: 0x00265E0C
		public byte[] GetAllExpeditionMapsId()
		{
			List<byte> list = new List<byte>();
			foreach (int value in this.mExpeditionMapBaseInfo.expeditionMapDic.Keys)
			{
				list.Add(BitConverter.GetBytes(value)[0]);
			}
			return list.ToArray();
		}

		// Token: 0x0600AF7D RID: 44925 RVA: 0x00267A88 File Offset: 0x00265E88
		public void SetEpxeditionTime(byte time, bool useOnekey = false)
		{
			if (useOnekey)
			{
				if (this.mExpeditionMapBaseInfo != null && this.mExpeditionMapBaseInfo.expeditionMapDic != null)
				{
					foreach (KeyValuePair<int, ExpeditionMapModel> keyValuePair in this.mExpeditionMapBaseInfo.expeditionMapDic)
					{
						ExpeditionMapModel value = keyValuePair.Value;
						if (value != null && value.mapNetInfo != null)
						{
							if (value.playerLevelLimit <= DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv && value.mapNetInfo.mapStatus == ExpeditionStatus.EXPEDITION_STATUS_PREPARE && value.mapNetInfo.roles != null && value.mapNetInfo.roles.Count > 0)
							{
								value.mapNetInfo.durationOfExpedition = (uint)time;
								if (this.mExpeditionMapNetInfo != null && value.mapNetInfo.mapId == this.mExpeditionMapNetInfo.mapId)
								{
									this._SetEpxeditionTime(time);
								}
							}
						}
					}
				}
			}
			else
			{
				this._SetEpxeditionTime(time);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamExpeditionTimeChanged, null, null, null, null);
		}

		// Token: 0x0600AF7E RID: 44926 RVA: 0x00267BA1 File Offset: 0x00265FA1
		private void _SetEpxeditionTime(byte time)
		{
			if (this.mExpeditionMapNetInfo == null)
			{
				return;
			}
			if (this.mExpeditionMapNetInfo.durationOfExpedition == (uint)time)
			{
				return;
			}
			this.mExpeditionMapNetInfo.durationOfExpedition = (uint)time;
			this.mIsChangedExpeditionTime = true;
		}

		// Token: 0x0600AF7F RID: 44927 RVA: 0x00267BD4 File Offset: 0x00265FD4
		public void SetExpeditionMapId(byte id)
		{
			if (id > 0)
			{
				if (this.mExpeditionMapNetInfo != null)
				{
					this.mExpeditionMapNetInfo.mapId = id;
				}
				this.mIsChangedExpeditionMap = true;
			}
		}

		// Token: 0x0600AF80 RID: 44928 RVA: 0x00267BFC File Offset: 0x00265FFC
		public int ExpeditionRoleListCount()
		{
			int num = 0;
			if (this.mExpeditionMapNetInfo == null || this.mExpeditionMapNetInfo.roles == null)
			{
				return num;
			}
			for (int i = 0; i < this.mExpeditionMapNetInfo.roles.Count; i++)
			{
				if (this.mExpeditionMapNetInfo.roles[i] != null)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600AF81 RID: 44929 RVA: 0x00267C64 File Offset: 0x00266064
		public string TryGetExpeditionMapRewardConition(int flag)
		{
			string empty;
			this.tr_expedition_requires.TryGetValue(flag, out empty);
			if (empty == null)
			{
				empty = string.Empty;
			}
			return empty;
		}

		// Token: 0x0600AF82 RID: 44930 RVA: 0x00267C90 File Offset: 0x00266090
		public void TryOpenExpeditionRoleSelectFrame(ExpeditionMemberInfo tempRoleInfo)
		{
			if (this.IsExpeditionMapEnable())
			{
				if (tempRoleInfo == null)
				{
					if (this.IsChangedExpeditionMap)
					{
						this.ReqExpeditionRolesInfo();
						return;
					}
					if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AdventureTeamExpeditionCharacterSelectFrame>(null))
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdventureTeamExpeditionCharacterSelectFrame>(FrameLayer.Middle, null, string.Empty);
					}
				}
				else
				{
					this.RemoveExpeditionRole(tempRoleInfo);
				}
			}
		}

		// Token: 0x0600AF83 RID: 44931 RVA: 0x00267CF0 File Offset: 0x002660F0
		public List<ExpeditionMapModel> GetFinishedExpeditionMapModels()
		{
			List<ExpeditionMapModel> list = new List<ExpeditionMapModel>();
			if (this.mExpeditionMapBaseInfo == null || this.mExpeditionMapBaseInfo.expeditionMapDic == null)
			{
				return list;
			}
			foreach (KeyValuePair<int, ExpeditionMapModel> keyValuePair in this.mExpeditionMapBaseInfo.expeditionMapDic)
			{
				ExpeditionMapModel value = keyValuePair.Value;
				if (value != null && value.mapNetInfo != null)
				{
					if (value.playerLevelLimit <= DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv && value.mapNetInfo.mapStatus == ExpeditionStatus.EXPEDITION_STATUS_OVER && value.mapNetInfo.roles != null && value.mapNetInfo.roles.Count > 0)
					{
						list.Add(value);
					}
				}
			}
			return list;
		}

		// Token: 0x0600AF84 RID: 44932 RVA: 0x00267DBC File Offset: 0x002661BC
		public List<byte> GetExpeditionTimeList(ExpeditionMapModel tempMapModel)
		{
			List<byte> list = new List<byte>();
			if (tempMapModel == null || string.IsNullOrEmpty(tempMapModel.expeditionTime))
			{
				return list;
			}
			string[] array = tempMapModel.expeditionTime.Split(new char[]
			{
				'|'
			});
			if (array == null || array.Length <= 0)
			{
				return list;
			}
			for (int i = 0; i < array.Length; i++)
			{
				int value = 1;
				if (int.TryParse(array[i], out value))
				{
					list.Add(BitConverter.GetBytes(value)[0]);
				}
			}
			return list;
		}

		// Token: 0x0600AF85 RID: 44933 RVA: 0x00267E44 File Offset: 0x00266244
		public void ClearReadyExpeditionMapModels(List<ExpeditionMapModel> tempMapModels)
		{
			if (tempMapModels == null || tempMapModels.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < tempMapModels.Count; i++)
			{
				ExpeditionMapModel expeditionMapModel = tempMapModels[i];
				if (expeditionMapModel != null && expeditionMapModel.mapNetInfo != null && expeditionMapModel.mapNetInfo.roles != null)
				{
					if (expeditionMapModel.mapNetInfo.mapStatus != ExpeditionStatus.EXPEDITION_STATUS_IN && expeditionMapModel.mapNetInfo.mapStatus != ExpeditionStatus.EXPEDITION_STATUS_OVER)
					{
						for (int j = 0; j < expeditionMapModel.mapNetInfo.roles.Count; j++)
						{
							ExpeditionMemberInfo expeditionMemberInfo = expeditionMapModel.mapNetInfo.roles[j];
							expeditionMemberInfo.expeditionMapId = 0;
						}
						this._ResetSelectedExpedtionRoleInfos(expeditionMapModel.mapNetInfo.roles);
						expeditionMapModel.mapNetInfo.roles.Clear();
					}
				}
			}
		}

		// Token: 0x0600AF86 RID: 44934 RVA: 0x00267F2C File Offset: 0x0026632C
		private void _ResetSelectedExpedtionRoleInfos(List<ExpeditionMemberInfo> toClearRoleInfos)
		{
			if (this.mExpeditionRoles == null || this.mExpeditionRoles.Length <= 0)
			{
				return;
			}
			if (toClearRoleInfos == null || toClearRoleInfos.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < toClearRoleInfos.Count; i++)
			{
				ExpeditionMemberInfo expeditionMemberInfo = toClearRoleInfos[i];
				for (int j = 0; j < this.mExpeditionRoles.Length; j++)
				{
					ExpeditionMemberInfo expeditionMemberInfo2 = this.mExpeditionRoles[j];
					if (expeditionMemberInfo2 != null)
					{
						if (expeditionMemberInfo2.roleid == expeditionMemberInfo.roleid)
						{
							expeditionMemberInfo2.expeditionMapId = 0;
							break;
						}
					}
				}
			}
		}

		// Token: 0x0600AF87 RID: 44935 RVA: 0x00267FD4 File Offset: 0x002663D4
		public List<ExpeditionMapModel> GetReadyExpeditionMapModels()
		{
			List<ExpeditionMapModel> list = new List<ExpeditionMapModel>();
			if (this.mExpeditionMapBaseInfo == null || this.mExpeditionMapBaseInfo.expeditionMapDic == null)
			{
				return list;
			}
			foreach (KeyValuePair<int, ExpeditionMapModel> keyValuePair in this.mExpeditionMapBaseInfo.expeditionMapDic)
			{
				ExpeditionMapModel value = keyValuePair.Value;
				if (value != null && value.mapNetInfo != null)
				{
					if (value.playerLevelLimit <= DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv && value.mapNetInfo.mapStatus == ExpeditionStatus.EXPEDITION_STATUS_PREPARE)
					{
						list.Add(value);
					}
				}
			}
			list.Sort((ExpeditionMapModel x, ExpeditionMapModel y) => -x.playerLevelLimit.CompareTo(y.playerLevelLimit));
			if (list.Count <= 0)
			{
				return list;
			}
			if (this.mExpeditionRoles == null || this.mExpeditionRoles.Length <= 0)
			{
				return list;
			}
			for (int i = 0; i < list.Count; i++)
			{
				ExpeditionMapModel expeditionMapModel = list[i];
				if (expeditionMapModel != null)
				{
					if (expeditionMapModel.rewardList != null && expeditionMapModel.rewardList.Count > 0)
					{
						int playerLevelLimit = expeditionMapModel.playerLevelLimit;
						List<ExpeditionMemberInfo> list2 = this._GetExpeditionRolesByPlayerLevel(playerLevelLimit);
						if (list2 != null && list2.Count > 0)
						{
							int num = 0;
							List<ExpeditionMemberInfo> list3 = null;
							for (int j = 0; j < expeditionMapModel.rewardList.Count; j++)
							{
								ExpeditionReward reward = expeditionMapModel.rewardList[j];
								List<ExpeditionMemberInfo> tempCondRoles = this._GetExpeditionRewardCondMemberInfos(list2, reward);
								this._SetFinialExpeditionMemberInfos(ref num, ref list3, tempCondRoles, reward.rolesNum);
							}
							if (list3 != null && list3.Count > 0)
							{
								if (expeditionMapModel.mapNetInfo.roles == null)
								{
									expeditionMapModel.mapNetInfo.roles = new List<ExpeditionMemberInfo>();
								}
								else
								{
									expeditionMapModel.mapNetInfo.roles.Clear();
								}
								for (int k = 0; k < list3.Count; k++)
								{
									list3[k].expeditionMapId = expeditionMapModel.mapNetInfo.mapId;
									expeditionMapModel.mapNetInfo.roles.Add(list3[k]);
								}
							}
						}
					}
				}
			}
			for (int l = list.Count - 1; l >= 0; l--)
			{
				ExpeditionMapModel expeditionMapModel2 = list[l];
				if (expeditionMapModel2 == null || expeditionMapModel2.mapNetInfo == null)
				{
					list.RemoveAt(l);
				}
				else if (expeditionMapModel2.mapNetInfo.roles == null || expeditionMapModel2.mapNetInfo.roles.Count <= 0)
				{
					list.RemoveAt(l);
				}
			}
			return list;
		}

		// Token: 0x0600AF88 RID: 44936 RVA: 0x002682B8 File Offset: 0x002666B8
		private List<ExpeditionMemberInfo> _GetExpeditionRewardCondMemberInfos(List<ExpeditionMemberInfo> enableLevelRoles, ExpeditionReward reward)
		{
			if (enableLevelRoles == null || enableLevelRoles.Count <= 0)
			{
				return null;
			}
			List<ExpeditionMemberInfo> result = null;
			if (reward.rewardCondition == ExpeditionRewardCondition.REQUIRE_ANY_OCCU)
			{
				result = enableLevelRoles;
			}
			else if (reward.rewardCondition == ExpeditionRewardCondition.REQUIRE_ANY_SAME_BASE_OCCU)
			{
				result = this._GetMaxNumSameBaseOccuInfos(enableLevelRoles);
			}
			else if (reward.rewardCondition == ExpeditionRewardCondition.REQUIRE_ANY_DIFF_BASE_OCCU)
			{
				result = this._GetMaxNumDiffBaseOccuInfos(enableLevelRoles);
			}
			else if (reward.rewardCondition == ExpeditionRewardCondition.REQUIRE_ANY_DIFF_CHANGED_OCCU)
			{
				result = this._GetMaxNumDiffChangedOccuInfos(enableLevelRoles);
			}
			return result;
		}

		// Token: 0x0600AF89 RID: 44937 RVA: 0x00268338 File Offset: 0x00266738
		private void _SetFinialExpeditionMemberInfos(ref int finialRoleNum, ref List<ExpeditionMemberInfo> finialRoles, List<ExpeditionMemberInfo> tempCondRoles, int tempCondRoleNum)
		{
			if (tempCondRoles == null || tempCondRoles.Count <= 0)
			{
				return;
			}
			if (tempCondRoleNum <= tempCondRoles.Count && finialRoleNum < tempCondRoleNum)
			{
				finialRoleNum = tempCondRoleNum;
				finialRoles = tempCondRoles.GetRange(0, finialRoleNum);
			}
		}

		// Token: 0x0600AF8A RID: 44938 RVA: 0x00268374 File Offset: 0x00266774
		private List<ExpeditionMemberInfo> _GetExpeditionRolesByPlayerLevel(int playerLevel)
		{
			List<ExpeditionMemberInfo> list = new List<ExpeditionMemberInfo>();
			if (this.mExpeditionRoles == null || this.mExpeditionRoles.Length <= 0)
			{
				return list;
			}
			for (int i = 0; i < this.mExpeditionRoles.Length; i++)
			{
				ExpeditionMemberInfo expeditionMemberInfo = this.mExpeditionRoles[i];
				if (expeditionMemberInfo != null)
				{
					if (expeditionMemberInfo.expeditionMapId == 0)
					{
						if ((int)expeditionMemberInfo.level >= playerLevel)
						{
							list.Add(this.mExpeditionRoles[i]);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600AF8B RID: 44939 RVA: 0x002683FC File Offset: 0x002667FC
		public int GetExpeditionRewardItemTotalCount(List<ExpeditionMapModel> tempMapModels, Action<string> SetRewardIconHandler = null)
		{
			if (tempMapModels == null || tempMapModels.Count <= 0)
			{
				return 0;
			}
			int num = 0;
			bool flag = false;
			for (int i = 0; i < tempMapModels.Count; i++)
			{
				ExpeditionMapModel expeditionMapModel = tempMapModels[i];
				if (expeditionMapModel != null)
				{
					if (expeditionMapModel.rewardList != null && expeditionMapModel.rewardList.Count > 0)
					{
						for (int j = 0; j < expeditionMapModel.rewardList.Count; j++)
						{
							ExpeditionReward reward = expeditionMapModel.rewardList[j];
							if (expeditionMapModel.mapNetInfo != null && expeditionMapModel.mapNetInfo.roles != null)
							{
								List<ExpeditionMemberInfo> list = this._GetExpeditionRewardCondMemberInfos(expeditionMapModel.mapNetInfo.roles, reward);
								if (list != null && list.Count >= reward.rolesNum)
								{
									if (!string.IsNullOrEmpty(reward.rewards))
									{
										string[] array = reward.rewards.Split(new char[]
										{
											':'
										});
										if (array != null && array.Length == 2)
										{
											int id;
											if (!flag && int.TryParse(array[0], out id))
											{
												ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
												if (tableItem != null && SetRewardIconHandler != null)
												{
													SetRewardIconHandler(tableItem.Icon);
													flag = true;
												}
											}
											int num2;
											if (int.TryParse(array[1], out num2))
											{
												num2 *= (int)expeditionMapModel.mapNetInfo.durationOfExpedition;
												num += num2;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return num;
		}

		// Token: 0x0600AF8C RID: 44940 RVA: 0x002685A0 File Offset: 0x002669A0
		public uint GetLastExpeditionMaxLevelMapDurationTime(List<ExpeditionMapModel> tempMapModels)
		{
			uint result = 0U;
			if (tempMapModels == null || tempMapModels.Count <= 0)
			{
				return result;
			}
			int num = 0;
			ExpeditionMapModel expeditionMapModel = null;
			for (int i = 0; i < tempMapModels.Count; i++)
			{
				ExpeditionMapModel expeditionMapModel2 = tempMapModels[i];
				if (expeditionMapModel2 != null)
				{
					if (num < expeditionMapModel2.playerLevelLimit)
					{
						num = expeditionMapModel2.playerLevelLimit;
						expeditionMapModel = expeditionMapModel2;
					}
				}
			}
			if (expeditionMapModel != null && expeditionMapModel.mapNetInfo != null)
			{
				result = this._GetExpeditionMapIdTime((int)expeditionMapModel.mapNetInfo.mapId);
			}
			return result;
		}

		// Token: 0x0600AF8D RID: 44941 RVA: 0x00268630 File Offset: 0x00266A30
		public uint GetLastExpeditionMaxMapDurationTime(List<ExpeditionMapModel> tempMapModels)
		{
			uint result = 0U;
			if (tempMapModels == null || tempMapModels.Count <= 0)
			{
				return result;
			}
			uint num = 0U;
			ExpeditionMapModel expeditionMapModel = null;
			for (int i = 0; i < tempMapModels.Count; i++)
			{
				ExpeditionMapModel expeditionMapModel2 = tempMapModels[i];
				if (expeditionMapModel2 != null && expeditionMapModel2.mapNetInfo != null)
				{
					if (num < expeditionMapModel2.mapNetInfo.durationOfExpedition)
					{
						num = expeditionMapModel2.mapNetInfo.durationOfExpedition;
						expeditionMapModel = expeditionMapModel2;
					}
				}
			}
			if (expeditionMapModel != null && expeditionMapModel.mapNetInfo != null)
			{
				result = this._GetExpeditionMapIdTime((int)expeditionMapModel.mapNetInfo.mapId);
			}
			return result;
		}

		// Token: 0x0600AF8E RID: 44942 RVA: 0x002686D8 File Offset: 0x00266AD8
		public void ResetUiTempPassBlessModel()
		{
			if (this.uiTempInheritBlessModel == null)
			{
				this.uiTempInheritBlessModel = new InheritBlessModel();
			}
			if (this.inheritBlessModel != null)
			{
				this.uiTempInheritBlessModel.ownInheritBlessNum = this.inheritBlessModel.ownInheritBlessNum;
				this.uiTempInheritBlessModel.inheritBlessMaxNum = this.inheritBlessModel.inheritBlessMaxNum;
			}
			if (this.uiTempInheritExpModel == null)
			{
				this.uiTempInheritExpModel = new InheritExpModel();
			}
			if (this.inheritExpModel != null)
			{
				this.uiTempInheritExpModel.ownInheritBlessExp = this.inheritExpModel.ownInheritBlessExp;
				this.uiTempInheritExpModel.inheritBlessMaxExp = this.inheritExpModel.inheritBlessMaxExp;
				this.uiTempInheritExpModel.inheritBlessUnitExp = this.inheritExpModel.inheritBlessUnitExp;
			}
		}

		// Token: 0x0600AF8F RID: 44943 RVA: 0x00268798 File Offset: 0x00266B98
		public int CheckNeedFlyExpTimes()
		{
			int result = 0;
			if (this.uiTempInheritBlessModel == null || this.inheritBlessModel == null)
			{
				return result;
			}
			if (this.uiTempInheritBlessModel.ownInheritBlessNum >= this.inheritBlessModel.ownInheritBlessNum)
			{
				return result;
			}
			return (int)(this.inheritBlessModel.ownInheritBlessNum - this.uiTempInheritBlessModel.ownInheritBlessNum);
		}

		// Token: 0x0600AF90 RID: 44944 RVA: 0x002687F5 File Offset: 0x00266BF5
		public void AddupOneExpTempNum()
		{
			if (this.uiTempInheritBlessModel == null)
			{
				this.uiTempInheritBlessModel = new InheritBlessModel();
			}
			this.uiTempInheritBlessModel.ownInheritBlessNum += 1U;
		}

		// Token: 0x0600AF91 RID: 44945 RVA: 0x00268820 File Offset: 0x00266C20
		public void ReqChangeTeamName(AdventureTeamRenameModel model)
		{
			if (model == null)
			{
				return;
			}
			WorldAdventureTeamRenameReq worldAdventureTeamRenameReq = new WorldAdventureTeamRenameReq();
			worldAdventureTeamRenameReq.newName = model.newNameStr;
			worldAdventureTeamRenameReq.costItemUId = model.renameItemGUID;
			worldAdventureTeamRenameReq.costItemDataId = model.renameItemTableId;
			NetManager.Instance().SendCommand<WorldAdventureTeamRenameReq>(ServerType.GATE_SERVER, worldAdventureTeamRenameReq);
		}

		// Token: 0x0600AF92 RID: 44946 RVA: 0x0026886C File Offset: 0x00266C6C
		public void QuickChangeTeamNameByCostItem(AdventureTeamRenameModel model)
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(574, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			int value = tableItem.Value;
			MallItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<MallItemTable>(value, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			this.mRenameCardTableId = tableItem2.itemid;
			QuickBuyTable quickBuyTable = Singleton<TableManager>.GetInstance().GetTableItem<QuickBuyTable>(this.mRenameCardTableId, string.Empty, string.Empty);
			if (quickBuyTable == null)
			{
				return;
			}
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(quickBuyTable.CostItemID);
			if (commonItemTableDataByID != null)
			{
				string text = string.Format(this.tr_rename_quick_buy_ask, commonItemTableDataByID.GetColorName(string.Empty, false), quickBuyTable.CostNum);
				int multiple = quickBuyTable.multiple;
				int num = 0;
				bool flag = false;
				MallItemMultipleIntegralData mallItemMultipleIntegralData = DataManager<MallNewDataManager>.GetInstance().CheckMallItemMultipleIntegral(quickBuyTable.ID);
				if (mallItemMultipleIntegralData != null)
				{
					multiple += mallItemMultipleIntegralData.multiple;
					num = mallItemMultipleIntegralData.endTime;
				}
				if (num > 0)
				{
					flag = ((long)num - (long)((ulong)DataManager<TimeManager>.GetInstance().GetServerTime()) > 0L);
				}
				if (multiple > 0)
				{
					int num2 = MallNewUtility.GetTicketConvertIntergalNumnber(quickBuyTable.CostNum) * multiple;
					string str = string.Empty;
					if (multiple <= 1)
					{
						str = TR.Value("mall_fast_buy_intergral_single_multiple_desc", num2);
					}
					else
					{
						str = TR.Value("mall_fast_buy_intergral_many_multiple_desc", num2, multiple, string.Empty);
					}
					if (flag)
					{
						str = TR.Value("mall_fast_buy_intergral_many_multiple_desc", num2, multiple, TR.Value("mall_fast_buy_intergral_many_multiple_remain_time_desc", Function.SetShowTimeDay(num)));
					}
					text += str;
				}
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(text, delegate()
				{
					if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
					{
						return;
					}
					if (multiple > 0)
					{
						string text2 = string.Empty;
						if ((int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket == MallNewUtility.GetIntergralMallTicketUpper() && !DataManager<MallNewDataManager>.GetInstance().bItemMallIntergralMallScoreIsEqual)
						{
							text2 = TR.Value("mall_buy_intergral_mall_score_equal_upper_value_desc");
							string content = text2;
							if (AdventureTeamDataManager.<>f__mg$cache0 == null)
							{
								AdventureTeamDataManager.<>f__mg$cache0 = new OnCommonMsgBoxToggleClick(MallNewUtility.ItemMallIntergralMallScoreIsEqual);
							}
							MallNewUtility.CommonIntergralMallPopupWindow(content, AdventureTeamDataManager.<>f__mg$cache0, delegate
							{
								this.ReqChangeTeamName(model);
							});
						}
						else
						{
							int num3 = MallNewUtility.GetTicketConvertIntergalNumnber(quickBuyTable.CostNum) * multiple;
							int num4 = (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket + num3;
							if (num4 > MallNewUtility.GetIntergralMallTicketUpper() && (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket != MallNewUtility.GetIntergralMallTicketUpper() && !DataManager<MallNewDataManager>.GetInstance().bItemMallIntergralMallScoreIsExceed)
							{
								text2 = TR.Value("mall_buy_intergral_mall_score_exceed_upper_value_desc", (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket, MallNewUtility.GetIntergralMallTicketUpper(), MallNewUtility.GetIntergralMallTicketUpper() - (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket);
								string content2 = text2;
								if (AdventureTeamDataManager.<>f__mg$cache1 == null)
								{
									AdventureTeamDataManager.<>f__mg$cache1 = new OnCommonMsgBoxToggleClick(MallNewUtility.ItemMallIntergralMallScoreIsExceed);
								}
								MallNewUtility.CommonIntergralMallPopupWindow(content2, AdventureTeamDataManager.<>f__mg$cache1, delegate
								{
									this.ReqChangeTeamName(model);
								});
							}
							else
							{
								this.ReqChangeTeamName(model);
							}
						}
					}
					else
					{
						this.ReqChangeTeamName(model);
					}
				}, null, 0f, false);
			}
		}

		// Token: 0x0600AF93 RID: 44947 RVA: 0x00268AAC File Offset: 0x00266EAC
		public void ReqExtendRoleFieldUnlock(ulong costItemGUID, int costItemTableId)
		{
			WorldExtensibleRoleFieldUnlockReq worldExtensibleRoleFieldUnlockReq = new WorldExtensibleRoleFieldUnlockReq();
			worldExtensibleRoleFieldUnlockReq.costItemUId = costItemGUID;
			worldExtensibleRoleFieldUnlockReq.costItemDataId = (uint)costItemTableId;
			NetManager.Instance().SendCommand<WorldExtensibleRoleFieldUnlockReq>(ServerType.GATE_SERVER, worldExtensibleRoleFieldUnlockReq);
		}

		// Token: 0x0600AF94 RID: 44948 RVA: 0x00268ADC File Offset: 0x00266EDC
		public void ReqBlessCrystalInfo()
		{
			WorldBlessCrystalInfoReq cmd = new WorldBlessCrystalInfoReq();
			NetManager.Instance().SendCommand<WorldBlessCrystalInfoReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600AF95 RID: 44949 RVA: 0x00268AFC File Offset: 0x00266EFC
		public void ReqAdventureTeamExtraInfo()
		{
			WorldAdventureTeamExtraInfoReq cmd = new WorldAdventureTeamExtraInfoReq();
			NetManager.Instance().SendCommand<WorldAdventureTeamExtraInfoReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600AF96 RID: 44950 RVA: 0x00268B1C File Offset: 0x00266F1C
		public void ReqPassBlessInfo()
		{
			WorldInheritBlessInfoReq cmd = new WorldInheritBlessInfoReq();
			NetManager.Instance().SendCommand<WorldInheritBlessInfoReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600AF97 RID: 44951 RVA: 0x00268B3C File Offset: 0x00266F3C
		public void ReqUsePassBlessExp()
		{
			WorldInheritExpReq cmd = new WorldInheritExpReq();
			NetManager.Instance().SendCommand<WorldInheritExpReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600AF98 RID: 44952 RVA: 0x00268B5C File Offset: 0x00266F5C
		public bool IsEnableToUsePassBless()
		{
			ushort level = DataManager<PlayerBaseData>.GetInstance().Level;
			return this.mPassBlessItem != null && (int)level >= this.mPassBlessItem.NeedLevel && (int)level <= this.mPassBlessItem.MaxLevel;
		}

		// Token: 0x0600AF99 RID: 44953 RVA: 0x00268BA8 File Offset: 0x00266FA8
		public void ReqExpeditionMapInfo(byte id)
		{
			WorldQueryExpeditionMapReq worldQueryExpeditionMapReq = new WorldQueryExpeditionMapReq();
			worldQueryExpeditionMapReq.mapId = id;
			NetManager.Instance().SendCommand<WorldQueryExpeditionMapReq>(ServerType.GATE_SERVER, worldQueryExpeditionMapReq);
		}

		// Token: 0x0600AF9A RID: 44954 RVA: 0x00268BD0 File Offset: 0x00266FD0
		public void ReqExpeditionRolesInfo()
		{
			WorldQueryOptionalExpeditionRolesReq cmd = new WorldQueryOptionalExpeditionRolesReq();
			NetManager.Instance().SendCommand<WorldQueryOptionalExpeditionRolesReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600AF9B RID: 44955 RVA: 0x00268BF0 File Offset: 0x00266FF0
		public void ReqDispatchExpeditionTeam()
		{
			this.ReqDispatchExpeditionTeam(this.mExpeditionMapNetInfo);
		}

		// Token: 0x0600AF9C RID: 44956 RVA: 0x00268C00 File Offset: 0x00267000
		public void ReqDispatchExpeditionTeam(List<ExpeditionMapModel> mapModels)
		{
			if (mapModels != null && mapModels.Count > 0)
			{
				for (int i = 0; i < mapModels.Count; i++)
				{
					ExpeditionMapModel expeditionMapModel = mapModels[i];
					if (expeditionMapModel != null && expeditionMapModel.mapNetInfo != null)
					{
						this.ReqDispatchExpeditionTeam(expeditionMapModel.mapNetInfo);
					}
				}
			}
		}

		// Token: 0x0600AF9D RID: 44957 RVA: 0x00268C60 File Offset: 0x00267060
		public void ReqDispatchExpeditionTeam(ExpeditionMapNetInfo mapNetInfo)
		{
			if (mapNetInfo == null)
			{
				return;
			}
			WorldDispatchExpeditionTeamReq worldDispatchExpeditionTeamReq = new WorldDispatchExpeditionTeamReq();
			worldDispatchExpeditionTeamReq.mapId = mapNetInfo.mapId;
			if (mapNetInfo.roles != null && mapNetInfo.roles.Count > 0)
			{
				ulong[] array = new ulong[mapNetInfo.roles.Count];
				for (int i = 0; i < mapNetInfo.roles.Count; i++)
				{
					array[i] = mapNetInfo.roles[i].roleid;
				}
				worldDispatchExpeditionTeamReq.members = array;
			}
			worldDispatchExpeditionTeamReq.housOfduration = mapNetInfo.durationOfExpedition;
			if (mapNetInfo.mapStatus == ExpeditionStatus.EXPEDITION_STATUS_PREPARE)
			{
				mapNetInfo.mapStatus = ExpeditionStatus.EXPEDITION_STATUS_IN;
				NetManager.Instance().SendCommand<WorldDispatchExpeditionTeamReq>(ServerType.GATE_SERVER, worldDispatchExpeditionTeamReq);
			}
		}

		// Token: 0x0600AF9E RID: 44958 RVA: 0x00268D18 File Offset: 0x00267118
		public void ReqCancelExpeditionTeam()
		{
			if (this.ExpeditionMapNetInfo.mapStatus == ExpeditionStatus.EXPEDITION_STATUS_IN)
			{
				WorldCancelExpeditionReq worldCancelExpeditionReq = new WorldCancelExpeditionReq();
				worldCancelExpeditionReq.mapId = this.ExpeditionMapNetInfo.mapId;
				NetManager.Instance().SendCommand<WorldCancelExpeditionReq>(ServerType.GATE_SERVER, worldCancelExpeditionReq);
			}
		}

		// Token: 0x0600AF9F RID: 44959 RVA: 0x00268D5C File Offset: 0x0026715C
		public void ReqGetExpeditionRewards()
		{
			if (this.ExpeditionMapNetInfo.mapStatus == ExpeditionStatus.EXPEDITION_STATUS_OVER)
			{
				WorldGetExpeditionRewardsReq worldGetExpeditionRewardsReq = new WorldGetExpeditionRewardsReq();
				worldGetExpeditionRewardsReq.mapId = this.ExpeditionMapNetInfo.mapId;
				NetManager.Instance().SendCommand<WorldGetExpeditionRewardsReq>(ServerType.GATE_SERVER, worldGetExpeditionRewardsReq);
			}
		}

		// Token: 0x0600AFA0 RID: 44960 RVA: 0x00268DA0 File Offset: 0x002671A0
		public void ReqGetExpeditionRewards(byte mapId)
		{
			WorldGetExpeditionRewardsReq worldGetExpeditionRewardsReq = new WorldGetExpeditionRewardsReq();
			worldGetExpeditionRewardsReq.mapId = mapId;
			NetManager.Instance().SendCommand<WorldGetExpeditionRewardsReq>(ServerType.GATE_SERVER, worldGetExpeditionRewardsReq);
		}

		// Token: 0x0600AFA1 RID: 44961 RVA: 0x00268DC8 File Offset: 0x002671C8
		public void ReqGetAllExpeditionMaps()
		{
			WorldQueryAllExpeditionMapsReq worldQueryAllExpeditionMapsReq = new WorldQueryAllExpeditionMapsReq();
			worldQueryAllExpeditionMapsReq.mapIds = this.GetAllExpeditionMapsId();
			NetManager.Instance().SendCommand<WorldQueryAllExpeditionMapsReq>(ServerType.GATE_SERVER, worldQueryAllExpeditionMapsReq);
		}

		// Token: 0x0600AFA2 RID: 44962 RVA: 0x00268DF4 File Offset: 0x002671F4
		public void ReqExpeditionAllMapInfo()
		{
			byte[] allExpeditionMapsId = this.GetAllExpeditionMapsId();
			if (allExpeditionMapsId != null && allExpeditionMapsId.Length > 0)
			{
				for (int i = 0; i < allExpeditionMapsId.Length; i++)
				{
					this.ReqExpeditionMapInfo(allExpeditionMapsId[i]);
				}
			}
		}

		// Token: 0x0600AFA3 RID: 44963 RVA: 0x00268E34 File Offset: 0x00267234
		public void ReqOwnJobInfo(int[] baseJobIds)
		{
			if (baseJobIds == null || baseJobIds.Length == 0)
			{
				return;
			}
			WorldQueryOwnOccupationsReq worldQueryOwnOccupationsReq = new WorldQueryOwnOccupationsReq();
			byte[] array = new byte[baseJobIds.Length];
			for (int i = 0; i < baseJobIds.Length; i++)
			{
				array[i] = (byte)baseJobIds[i];
			}
			worldQueryOwnOccupationsReq.baseOccus = array;
			NetManager.Instance().SendCommand<WorldQueryOwnOccupationsReq>(ServerType.GATE_SERVER, worldQueryOwnOccupationsReq);
		}

		// Token: 0x0600AFA4 RID: 44964 RVA: 0x00268E90 File Offset: 0x00267290
		public void ReqClearActivatedJob(int[] transferJobIds)
		{
			if (transferJobIds == null || transferJobIds.Length == 0)
			{
				return;
			}
			WorldRemoveUnlockedNewOccupationsReq worldRemoveUnlockedNewOccupationsReq = new WorldRemoveUnlockedNewOccupationsReq();
			byte[] array = new byte[transferJobIds.Length];
			for (int i = 0; i < transferJobIds.Length; i++)
			{
				array[i] = (byte)transferJobIds[i];
			}
			worldRemoveUnlockedNewOccupationsReq.newOccus = array;
			NetManager.Instance().SendCommand<WorldRemoveUnlockedNewOccupationsReq>(ServerType.GATE_SERVER, worldRemoveUnlockedNewOccupationsReq);
		}

		// Token: 0x0600AFA5 RID: 44965 RVA: 0x00268EEA File Offset: 0x002672EA
		public void ChangeSelectJobPlayStatus(CharacterCollectionModel model, bool toPlay)
		{
			if (!this.CheckIsSelectJobSatisfyConditions(model))
			{
				return;
			}
			model.needPlay = toPlay;
			this._NotifyCharacterCollectionChanged();
		}

		// Token: 0x0600AFA6 RID: 44966 RVA: 0x00268F08 File Offset: 0x00267308
		public bool CheckIsSelectJobSatisfyConditions(CharacterCollectionModel model)
		{
			bool result = false;
			if (model != null && model.isJobOpened && model.isTransfer && model.isOwned)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600AFA7 RID: 44967 RVA: 0x00268F41 File Offset: 0x00267341
		public void _GetAdventureTeamMissions(ref List<MissionManager.SingleMissionInfo> list)
		{
			list = DataManager<MissionManager>.GetInstance().taskGroup.Values.ToList<MissionManager.SingleMissionInfo>();
			list.RemoveAll((MissionManager.SingleMissionInfo x) => !this._IsAdventureteamWeeklyMission(x));
		}

		// Token: 0x0600AFA8 RID: 44968 RVA: 0x00268F70 File Offset: 0x00267370
		public int _GetFinishedWeeklyTaskNum()
		{
			int num = 0;
			if (this.ADTMissionList != null)
			{
				for (int i = 0; i < this.ADTMissionList.Count; i++)
				{
					if (this.ADTMissionList[i].status == 5)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0600AFA9 RID: 44969 RVA: 0x00268FC2 File Offset: 0x002673C2
		public void OpenAdventureTeamInfoFrame(AdventureTeamMainTabType tabType = AdventureTeamMainTabType.BaseInformation)
		{
			AdventureTeamInformationFrame.OpenTabFrame(tabType);
		}

		// Token: 0x0600AFAA RID: 44970 RVA: 0x00268FCC File Offset: 0x002673CC
		public bool HasRedPointShow()
		{
			if (!this.BFuncOpened)
			{
				return false;
			}
			bool flag = this.IsBaseInfoTabRedPointShow();
			bool flag2 = this.IsCharacterCollectionTabRedPointShow();
			bool flag3 = this.IsCharacterExpeditionTabRedPointShow();
			bool flag4 = this.IsPassingBlessTabRedPointShow();
			bool flag5 = this.IsWeeklyTaskTabRedPointShow();
			return flag || flag2 || flag3 || flag4 || flag5;
		}

		// Token: 0x0600AFAB RID: 44971 RVA: 0x00269028 File Offset: 0x00267428
		public bool IsBaseInfoTabRedPointShow()
		{
			bool flag = this._CheckBlessCrystalIsFull();
			return this.OnAdventureTeamLevelChangedFlag || flag;
		}

		// Token: 0x0600AFAC RID: 44972 RVA: 0x0026904B File Offset: 0x0026744B
		public bool IsCharacterCollectionTabRedPointShow()
		{
			return this._CheckNewCharacterNeedPlay();
		}

		// Token: 0x0600AFAD RID: 44973 RVA: 0x00269053 File Offset: 0x00267453
		public bool IsCharacterExpeditionTabRedPointShow()
		{
			return this.mCanGetReward;
		}

		// Token: 0x0600AFAE RID: 44974 RVA: 0x0026905B File Offset: 0x0026745B
		public bool IsPassingBlessTabRedPointShow()
		{
			return this.inheritBlessModel != null && this._CheckPassBlessIsAvailable();
		}

		// Token: 0x0600AFAF RID: 44975 RVA: 0x00269070 File Offset: 0x00267470
		public bool IsWeeklyTaskTabRedPointShow()
		{
			return this._CheckWeeklyTaskCanReceiveWithinWeeklyLimit();
		}

		// Token: 0x0600AFB0 RID: 44976 RVA: 0x00269090 File Offset: 0x00267490
		private bool _CheckBlessCrystalIsFull()
		{
			bool result = false;
			if (this.blessCrystalModel != null)
			{
				result = (this.blessCrystalModel.currOwnCount >= this.blessCrystalModel.currNumMaximum);
			}
			return result;
		}

		// Token: 0x0600AFB1 RID: 44977 RVA: 0x002690C8 File Offset: 0x002674C8
		private bool _CheckPassBlessIsAvailable()
		{
			uint num = 0U;
			ulong num2 = 0UL;
			ulong num3 = 0UL;
			if (this.inheritBlessModel != null)
			{
				num = this.inheritBlessModel.ownInheritBlessNum;
			}
			if (this.inheritExpModel != null)
			{
				num2 = this.inheritExpModel.ownInheritBlessExp;
				num3 = this.inheritExpModel.inheritBlessUnitExp;
			}
			if (num > 0U && this.isPassBlessOwnCountAddup)
			{
				return true;
			}
			if (this.IsEnableToUsePassBless())
			{
				if (num > 0U || num2 >= num3)
				{
					this.isPassBlessCanUse = true;
					return this.onFirstCheckPassBlessFlag;
				}
			}
			else if (num > 0U && !this.hasPassBlessCheckedToday)
			{
				this.isPassBlessEnoughOnFirstLogin = true;
				return this.onFirstCheckPassBlessFlag;
			}
			return false;
		}

		// Token: 0x0600AFB2 RID: 44978 RVA: 0x00269178 File Offset: 0x00267578
		private bool _IsPassBlessCheckedToday()
		{
			int typeKeyIntValue = Singleton<PlayerPrefsManager>.GetInstance().GetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.ATPassBlessCheckTime, new object[0]);
			return typeKeyIntValue > Function.GetRefreshHourTimeStamp(this.weeklyTaskRefreshHour);
		}

		// Token: 0x0600AFB3 RID: 44979 RVA: 0x002691AC File Offset: 0x002675AC
		private void _SavePassBlessCheckTimestamp()
		{
			int currTimeStamp = Function.GetCurrTimeStamp();
			Singleton<PlayerPrefsManager>.GetInstance().SetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.ATPassBlessCheckTime, currTimeStamp, new object[0]);
		}

		// Token: 0x0600AFB4 RID: 44980 RVA: 0x002691D4 File Offset: 0x002675D4
		private bool _IsWeeklyTaskCheckedToday()
		{
			int typeKeyIntValue = Singleton<PlayerPrefsManager>.GetInstance().GetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.ATWeeklyTaskCheckTime, new object[0]);
			return typeKeyIntValue > Function.GetRefreshHourTimeStamp(this.weeklyTaskRefreshHour);
		}

		// Token: 0x0600AFB5 RID: 44981 RVA: 0x00269208 File Offset: 0x00267608
		private void _SaveWeeklyTaskCheckTimestamp()
		{
			int currTimeStamp = Function.GetCurrTimeStamp();
			Singleton<PlayerPrefsManager>.GetInstance().SetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.ATWeeklyTaskCheckTime, currTimeStamp, new object[0]);
		}

		// Token: 0x0600AFB6 RID: 44982 RVA: 0x00269230 File Offset: 0x00267630
		private bool _CheckNewCharacterNeedPlay()
		{
			if (this.mTotalCharacterCollection != null)
			{
				for (int i = 0; i < this.mTotalCharacterCollection.Count; i++)
				{
					CharacterCollectionModel characterCollectionModel = this.mTotalCharacterCollection[i];
					if (characterCollectionModel != null)
					{
						if (characterCollectionModel.needPlay)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600AFB7 RID: 44983 RVA: 0x0026928C File Offset: 0x0026768C
		private bool _CheckWeeklyTaskCanReceiveWithinWeeklyLimit()
		{
			bool flag = Singleton<LoginPushManager>.GetInstance().IsFirstLogin();
			int num = this._GetFinishedWeeklyTaskNum();
			int adtmissionFinishMaxNum = this.ADTMissionFinishMaxNum;
			bool flag2 = adtmissionFinishMaxNum - num > 0;
			return this.hasWeeklyTaskReceived || (this.OnFirstCheckWeeklyTaskFlag && flag2) || (flag && this.OnFirstCheckWeeklyTaskFlag && !flag2);
		}

		// Token: 0x0600AFB8 RID: 44984 RVA: 0x002692FA File Offset: 0x002676FA
		private void _NotifyLevelUp()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamLevelUp, null, null, null, null);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.AdventureTeam);
		}

		// Token: 0x0600AFB9 RID: 44985 RVA: 0x0026931E File Offset: 0x0026771E
		private void _NotifyCharacterCollectionChanged()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamCollectionInfoChanged, null, null, null, null);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.AdventureTeam);
		}

		// Token: 0x0600AFBA RID: 44986 RVA: 0x00269342 File Offset: 0x00267742
		private void _NotifyExpeditionHasRewardChanged()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamExpeditionAwardChanged, null, null, null, null);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.AdventureTeam);
		}

		// Token: 0x0600AFBB RID: 44987 RVA: 0x00269366 File Offset: 0x00267766
		private void _NotifyBlessCrystalCountChanged()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamBlessCrystalCountChanged, null, null, null, null);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.AdventureTeam);
		}

		// Token: 0x0600AFBC RID: 44988 RVA: 0x0026938A File Offset: 0x0026778A
		private void _NotifyPassBlessCountChanged()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamInheritBlessCountChanged, null, null, null, null);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.AdventureTeam);
		}

		// Token: 0x0600AFBD RID: 44989 RVA: 0x002693AE File Offset: 0x002677AE
		private void _NotifyWeeklyTaskStatusChanged()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamWeeklyTaskStatusChanged, null, null, null, null);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.AdventureTeam);
		}

		// Token: 0x0600AFBE RID: 44990 RVA: 0x002693D4 File Offset: 0x002677D4
		public static string ChangeColorByGrade(string name, string gradeString)
		{
			string result;
			try
			{
				AdventureTeamGradeTable.eGradeEnum adventureTeamGradeEnum = AdventureTeamDataManager.GetAdventureTeamGradeEnum(gradeString);
				if (adventureTeamGradeEnum == AdventureTeamGradeTable.eGradeEnum.GradeEnum_None)
				{
					result = name;
				}
				else
				{
					result = string.Format(AdventureTeamDataManager.GetAdventureNameColorByGrade(adventureTeamGradeEnum), name);
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("[AdventureTeamDataManager] - ChangeColorByGrade error ： {0}", new object[]
				{
					ex.ToString()
				});
				result = name;
			}
			return result;
		}

		// Token: 0x0600AFBF RID: 44991 RVA: 0x0026943C File Offset: 0x0026783C
		private static string GetAdventureNameColorByGrade(AdventureTeamGradeTable.eGradeEnum grade)
		{
			AdventureTeamGradeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AdventureTeamGradeTable>((int)grade, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.NameColor;
			}
			return "{0}";
		}

		// Token: 0x0600AFC0 RID: 44992 RVA: 0x00269474 File Offset: 0x00267874
		private static AdventureTeamGradeTable.eGradeEnum GetAdventureTeamGradeEnum(string gradeStr)
		{
			AdventureTeamGradeTable.eGradeEnum result;
			try
			{
				if (string.IsNullOrEmpty(gradeStr))
				{
					result = AdventureTeamGradeTable.eGradeEnum.GradeEnum_None;
				}
				else
				{
					AdventureTeamGradeTable.eGradeEnum eGradeEnum = (AdventureTeamGradeTable.eGradeEnum)Enum.Parse(typeof(AdventureTeamGradeTable.eGradeEnum), gradeStr);
					result = eGradeEnum;
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("[AdventureTeamDataManager] - GetAdventureTeamGradeEnum error ： {0}", new object[]
				{
					ex.ToString()
				});
				result = AdventureTeamGradeTable.eGradeEnum.GradeEnum_None;
			}
			return result;
		}

		// Token: 0x0600AFC1 RID: 44993 RVA: 0x002694E4 File Offset: 0x002678E4
		private void _DebugDataManagerLoggger(string methodName, string errorLog)
		{
		}

		// Token: 0x04006208 RID: 25096
		private bool bLocalDataInited;

		// Token: 0x04006209 RID: 25097
		private bool bNetInited;

		// Token: 0x0400620A RID: 25098
		private int adventureTeamLevelMinimun;

		// Token: 0x0400620B RID: 25099
		private int adventureTeamLevelMaximun = 10;

		// Token: 0x0400620C RID: 25100
		private int renameLimitCharNum = 7;

		// Token: 0x0400620D RID: 25101
		private Dictionary<int, ulong> mAdventureTeamUpLevelExpDic = new Dictionary<int, ulong>();

		// Token: 0x0400620E RID: 25102
		private int mRenameCardTableId;

		// Token: 0x0400620F RID: 25103
		private int weeklyTaskRefreshHour = 6;

		// Token: 0x04006210 RID: 25104
		private Dictionary<int, List<CharacterCollectionModel>> mCharacterCollectionDic = new Dictionary<int, List<CharacterCollectionModel>>();

		// Token: 0x04006211 RID: 25105
		private List<CharacterCollectionModel> mTotalCharacterCollection = new List<CharacterCollectionModel>();

		// Token: 0x04006212 RID: 25106
		private Dictionary<int, string> mBaseJobTableIdWithNameDic = new Dictionary<int, string>();

		// Token: 0x04006213 RID: 25107
		private BlessCrystalModel blessCrystalModel;

		// Token: 0x04006214 RID: 25108
		private ItemTable mPassBlessItem;

		// Token: 0x04006215 RID: 25109
		private InheritBlessModel inheritBlessModel;

		// Token: 0x04006216 RID: 25110
		private InheritExpModel inheritExpModel;

		// Token: 0x04006217 RID: 25111
		private InheritBlessModel uiTempInheritBlessModel;

		// Token: 0x04006218 RID: 25112
		private InheritExpModel uiTempInheritExpModel;

		// Token: 0x04006219 RID: 25113
		private BountyModle bountyModel;

		// Token: 0x0400621A RID: 25114
		private ExpeditionMapBaseInfo mExpeditionMapBaseInfo = new ExpeditionMapBaseInfo();

		// Token: 0x0400621B RID: 25115
		private ExpeditionMapNetInfo mExpeditionMapNetInfo = new ExpeditionMapNetInfo(1);

		// Token: 0x0400621C RID: 25116
		private ExpeditionMemberInfo[] mExpeditionRoles;

		// Token: 0x0400621D RID: 25117
		private bool mIsChangedExpeditionMap;

		// Token: 0x0400621E RID: 25118
		private bool mIsChangedExpeditionTime;

		// Token: 0x0400621F RID: 25119
		private bool mIsChangedExpeditionRoles;

		// Token: 0x04006220 RID: 25120
		private bool mCanGetReward;

		// Token: 0x04006221 RID: 25121
		private List<MissionManager.SingleMissionInfo> m_ADTMissionList = new List<MissionManager.SingleMissionInfo>();

		// Token: 0x04006222 RID: 25122
		private int m_ADTMissionFinishMaxNum;

		// Token: 0x04006223 RID: 25123
		private bool hasWeeklyTaskReceived;

		// Token: 0x04006224 RID: 25124
		private string tr_rename_content_empty = string.Empty;

		// Token: 0x04006225 RID: 25125
		private string tr_rename_content_beyond_max = string.Empty;

		// Token: 0x04006226 RID: 25126
		private string tr_rename_content_illegal = string.Empty;

		// Token: 0x04006227 RID: 25127
		private string tr_rename_content_be_used = string.Empty;

		// Token: 0x04006228 RID: 25128
		private string tr_rename_content_no_changed = string.Empty;

		// Token: 0x04006229 RID: 25129
		private string tr_rename_content_failed = string.Empty;

		// Token: 0x0400622A RID: 25130
		private string tr_rename_content_success = string.Empty;

		// Token: 0x0400622B RID: 25131
		private string tr_rename_quick_buy_ask = string.Empty;

		// Token: 0x0400622C RID: 25132
		private string tr_adventure_team_level_up_tip = string.Empty;

		// Token: 0x0400622D RID: 25133
		private string tr_select_role_extend_succ = string.Empty;

		// Token: 0x0400622E RID: 25134
		private string tr_select_role_field_reach_max = string.Empty;

		// Token: 0x0400622F RID: 25135
		private string tr_select_role_field_not_use_total = string.Empty;

		// Token: 0x04006230 RID: 25136
		private string tr_select_role_field_extend_failed = string.Empty;

		// Token: 0x04006231 RID: 25137
		private string tr_collection_first_tab_name = string.Empty;

		// Token: 0x04006232 RID: 25138
		private string tr_expedition_dispatch_succeed = string.Empty;

		// Token: 0x04006233 RID: 25139
		private string tr_expedition_dispatch_fail = string.Empty;

		// Token: 0x04006234 RID: 25140
		private string tr_expedition_dispatch_dup = string.Empty;

		// Token: 0x04006235 RID: 25141
		private Dictionary<int, string> tr_expedition_requires = new Dictionary<int, string>();

		// Token: 0x04006237 RID: 25143
		private bool hasWeeklyTaskCheckedToday;

		// Token: 0x04006238 RID: 25144
		private bool onFirstCheckWeeklyTaskFlag = true;

		// Token: 0x04006239 RID: 25145
		private bool onFirstCheckPassBlessFlag = true;

		// Token: 0x0400623A RID: 25146
		private bool isPassBlessOwnCountAddup;

		// Token: 0x0400623B RID: 25147
		private bool isPassBlessOwnCountInit;

		// Token: 0x0400623C RID: 25148
		private bool isPassBlessCanUse;

		// Token: 0x0400623D RID: 25149
		private bool isPassBlessEnoughOnFirstLogin;

		// Token: 0x0400623E RID: 25150
		private bool hasPassBlessCheckedToday;

		// Token: 0x04006241 RID: 25153
		[CompilerGenerated]
		private static OnCommonMsgBoxToggleClick <>f__mg$cache0;

		// Token: 0x04006242 RID: 25154
		[CompilerGenerated]
		private static OnCommonMsgBoxToggleClick <>f__mg$cache1;
	}
}
