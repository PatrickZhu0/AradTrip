using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001393 RID: 5011
	public class ActivityDungeonDataManager : DataManager<ActivityDungeonDataManager>
	{
		// Token: 0x17001BD3 RID: 7123
		// (get) Token: 0x0600C267 RID: 49767 RVA: 0x002E516C File Offset: 0x002E356C
		public List<ActivityDungeonTab> tabs
		{
			get
			{
				return this.mTabs;
			}
		}

		// Token: 0x0600C268 RID: 49768 RVA: 0x002E5174 File Offset: 0x002E3574
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.ActivityDungeonDataManager;
		}

		// Token: 0x0600C269 RID: 49769 RVA: 0x002E5177 File Offset: 0x002E3577
		public override void Initialize()
		{
			this._bindEvent();
			this._loadTableData();
			this.mIsLimitActivityRedPoint = true;
		}

		// Token: 0x0600C26A RID: 49770 RVA: 0x002E518C File Offset: 0x002E358C
		public override void Clear()
		{
			this._unBindEvent();
			this._unloadTableData();
			this.mIsLimitActivityRedPoint = true;
		}

		// Token: 0x0600C26B RID: 49771 RVA: 0x002E51A4 File Offset: 0x002E35A4
		private void _loadTableData()
		{
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<ActivityDungeonTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ActivityDungeonTable activityDungeonTable = keyValuePair.Value as ActivityDungeonTable;
				this._addOne(activityDungeonTable.ID);
			}
		}

		// Token: 0x0600C26C RID: 49772 RVA: 0x002E51F8 File Offset: 0x002E35F8
		private void _unloadTableData()
		{
			for (int i = 0; i < this.mTabs.Count; i++)
			{
				this.mTabs[i].subs.Clear();
			}
			this.mTabs.Clear();
		}

		// Token: 0x0600C26D RID: 49773 RVA: 0x002E5244 File Offset: 0x002E3644
		private void _addOne(int id)
		{
			ActivityDungeonTable table = Singleton<TableManager>.instance.GetTableItem<ActivityDungeonTable>(id, string.Empty, string.Empty);
			if (table != null)
			{
				ActivityDungeonTab activityDungeonTab = this.mTabs.Find((ActivityDungeonTab x) => x.name == table.TabName);
				if (activityDungeonTab == null)
				{
					activityDungeonTab = new ActivityDungeonTab();
					activityDungeonTab.priority = table.TabPriority;
					activityDungeonTab.name = table.TabName;
					this.mTabs.Add(activityDungeonTab);
					this.mTabs.Sort();
				}
				activityDungeonTab.AddOneSub(id);
			}
		}

		// Token: 0x0600C26E RID: 49774 RVA: 0x002E52E4 File Offset: 0x002E36E4
		private void _updateActivityEvent(UIEvent ui)
		{
			uint id = (uint)ui.Param1;
			this._updateActivity(id);
		}

		// Token: 0x0600C26F RID: 49775 RVA: 0x002E5304 File Offset: 0x002E3704
		private void _updateActivity(uint id)
		{
			for (int i = 0; i < this.mTabs.Count; i++)
			{
				ActivityDungeonTab activityDungeonTab = this.mTabs[i];
				ActivityDungeonSub activityDungeonSub = activityDungeonTab.subs.Find((ActivityDungeonSub x) => x.table.ActivityID.Contains((int)id));
				if (activityDungeonSub != null)
				{
					activityDungeonTab.subs.Remove(activityDungeonSub);
					activityDungeonTab.AddOneSub(activityDungeonSub.id);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityDungeonUpdate, null, null, null, null);
					if ((ulong)id == (ulong)((long)this.iRotteneterHellActivityID))
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityDungeonStateUpdate, null, null, null, null);
					}
					break;
				}
			}
		}

		// Token: 0x0600C270 RID: 49776 RVA: 0x002E53BC File Offset: 0x002E37BC
		private void _updateStateAndRedState(UIEvent ui)
		{
			for (int i = 0; i < this.mTabs.Count; i++)
			{
				ActivityDungeonTab activityDungeonTab = this.mTabs[i];
				for (int j = 0; j < activityDungeonTab.subs.Count; j++)
				{
					activityDungeonTab.subs[j].UpdateStateAndRedPoint();
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityDungeonUpdate, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPointChanged, ERedPoint.ActivityDungeon, null, null, null);
		}

		// Token: 0x0600C271 RID: 49777 RVA: 0x002E544C File Offset: 0x002E384C
		private void _bindEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this._updateActivityEvent));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._updateStateAndRedState));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._updateStateAndRedState));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityDungeonDeadTowerWipeEnd, new ClientEventSystem.UIEventHandler(this._updateStateAndRedState));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RefreshLimitTimeState, new ClientEventSystem.UIEventHandler(this._updateStateAndRedState));
		}

		// Token: 0x0600C272 RID: 49778 RVA: 0x002E54E0 File Offset: 0x002E38E0
		private void _unBindEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this._updateActivityEvent));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._updateStateAndRedState));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._updateStateAndRedState));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityDungeonDeadTowerWipeEnd, new ClientEventSystem.UIEventHandler(this._updateStateAndRedState));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RefreshLimitTimeState, new ClientEventSystem.UIEventHandler(this._updateStateAndRedState));
		}

		// Token: 0x0600C273 RID: 49779 RVA: 0x002E5574 File Offset: 0x002E3974
		public bool IsShowRed()
		{
			for (int i = 0; i < this.mTabs.Count; i++)
			{
				if (this.IsTabShowRed(this.mTabs[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600C274 RID: 49780 RVA: 0x002E55B8 File Offset: 0x002E39B8
		public new void Update(float delta)
		{
			for (int i = 0; i < this.mTabs.Count; i++)
			{
				for (int j = 0; j < this.mTabs[i].subs.Count; j++)
				{
					this.mTabs[i].subs[j].Update(delta);
				}
			}
		}

		// Token: 0x0600C275 RID: 49781 RVA: 0x002E5625 File Offset: 0x002E3A25
		public bool IsTabShowRed(ActivityDungeonTab tab)
		{
			return this.GetTabRedCount(tab) > 0;
		}

		// Token: 0x0600C276 RID: 49782 RVA: 0x002E5634 File Offset: 0x002E3A34
		public int GetTabRedCount(ActivityDungeonTab tab)
		{
			int num = 0;
			for (int i = 0; i < tab.subs.Count; i++)
			{
				if (tab.subs[i].isshowred)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600C277 RID: 49783 RVA: 0x002E567C File Offset: 0x002E3A7C
		public ActivityDungeonSub GetSubByDungeonID(int did)
		{
			for (int i = 0; i < this.mTabs.Count; i++)
			{
				for (int j = 0; j < this.mTabs[i].subs.Count; j++)
				{
					if (did == this.mTabs[i].subs[j].dungeonId)
					{
						return this.mTabs[i].subs[j];
					}
				}
			}
			return null;
		}

		// Token: 0x0600C278 RID: 49784 RVA: 0x002E5708 File Offset: 0x002E3B08
		public ActivityDungeonSub GetSubByActivityID(int activityId)
		{
			for (int i = 0; i < this.mTabs.Count; i++)
			{
				for (int j = 0; j < this.mTabs[i].subs.Count; j++)
				{
					if (activityId == this.mTabs[i].subs[j].activityId)
					{
						return this.mTabs[i].subs[j];
					}
				}
			}
			return null;
		}

		// Token: 0x0600C279 RID: 49785 RVA: 0x002E5794 File Offset: 0x002E3B94
		public ActivityDungeonSub GetSubByActivityDungeonID(int activityDungeonId)
		{
			if (this.mTabs == null)
			{
				return null;
			}
			for (int i = 0; i < this.mTabs.Count; i++)
			{
				for (int j = 0; j < this.mTabs[i].subs.Count; j++)
				{
					if (activityDungeonId == this.mTabs[i].subs[j].id)
					{
						return this.mTabs[i].subs[j];
					}
				}
			}
			return null;
		}

		// Token: 0x0600C27A RID: 49786 RVA: 0x002E582C File Offset: 0x002E3C2C
		public ActivityDungeonTab GetDailyDungeonTab()
		{
			ActivityDungeonTable.eActivityType type = ActivityDungeonTable.eActivityType.Daily;
			List<ActivityDungeonTab> tabByActivityType = this.GetTabByActivityType(type);
			if (this._isTabsEmptyOrNull(tabByActivityType))
			{
				return null;
			}
			for (int i = 0; i < tabByActivityType.Count; i++)
			{
				if (tabByActivityType[i] != null && tabByActivityType[i].subs != null && tabByActivityType[i].subs.Count > 0)
				{
					ActivityDungeonTable table = tabByActivityType[i].subs[0].table;
					if (table != null && table.DailyActivityType == 1)
					{
						return tabByActivityType[i];
					}
				}
			}
			return null;
		}

		// Token: 0x0600C27B RID: 49787 RVA: 0x002E58D0 File Offset: 0x002E3CD0
		public ActivityDungeonTab GetTabByDungeonID(ActivityDungeonTable.eActivityType type, int dungeonId)
		{
			List<ActivityDungeonTab> tabByActivityType = this.GetTabByActivityType(type);
			if (this._isTabsEmptyOrNull(tabByActivityType))
			{
				return null;
			}
			for (int i = 0; i < tabByActivityType.Count; i++)
			{
				for (int j = 0; j < tabByActivityType[i].subs.Count; j++)
				{
					if (dungeonId == tabByActivityType[i].subs[j].dungeonId)
					{
						return tabByActivityType[i];
					}
				}
			}
			return null;
		}

		// Token: 0x0600C27C RID: 49788 RVA: 0x002E5954 File Offset: 0x002E3D54
		public ActivityDungeonTab GetTabByActivityID(ActivityDungeonTable.eActivityType type, int activityId)
		{
			List<ActivityDungeonTab> tabByActivityType = this.GetTabByActivityType(type);
			if (this._isTabsEmptyOrNull(tabByActivityType))
			{
				return null;
			}
			for (int i = 0; i < tabByActivityType.Count; i++)
			{
				for (int j = 0; j < tabByActivityType[i].subs.Count; j++)
				{
					if (activityId == tabByActivityType[i].subs[j].activityId)
					{
						return tabByActivityType[i];
					}
				}
			}
			return null;
		}

		// Token: 0x0600C27D RID: 49789 RVA: 0x002E59D8 File Offset: 0x002E3DD8
		public ActivityDungeonTab GetTabByDungeonIDDefaultFirst(ActivityDungeonTable.eActivityType type, int dungeonId)
		{
			ActivityDungeonTab tabByDungeonID = this.GetTabByDungeonID(type, dungeonId);
			if (tabByDungeonID == null)
			{
				List<ActivityDungeonTab> tabByActivityType = this.GetTabByActivityType(type);
				if (!this._isTabsEmptyOrNull(tabByActivityType))
				{
					return tabByActivityType[0];
				}
			}
			return tabByDungeonID;
		}

		// Token: 0x0600C27E RID: 49790 RVA: 0x002E5A14 File Offset: 0x002E3E14
		public ActivityDungeonTab GetTabByAcitivtyIDDefaultFirst(ActivityDungeonTable.eActivityType type, int activityId)
		{
			ActivityDungeonTab tabByActivityID = this.GetTabByActivityID(type, activityId);
			if (tabByActivityID == null)
			{
				List<ActivityDungeonTab> tabByActivityType = this.GetTabByActivityType(type);
				if (!this._isTabsEmptyOrNull(tabByActivityType))
				{
					return tabByActivityType[0];
				}
			}
			return tabByActivityID;
		}

		// Token: 0x0600C27F RID: 49791 RVA: 0x002E5A50 File Offset: 0x002E3E50
		public List<ActivityDungeonTab> GetTabByActivityType(ActivityDungeonTable.eActivityType type)
		{
			List<ActivityDungeonTab> list = new List<ActivityDungeonTab>();
			for (int i = 0; i < this.mTabs.Count; i++)
			{
				if (this.mTabs[i].subs.Count > 0 && type == this.mTabs[i].subs[0].type)
				{
					list.Add(this.mTabs[i]);
				}
			}
			list.Sort();
			return list;
		}

		// Token: 0x0600C280 RID: 49792 RVA: 0x002E5AD8 File Offset: 0x002E3ED8
		public List<ActivityDungeonSub> GetSubByActivityType(ActivityDungeonTable.eActivityType type)
		{
			List<ActivityDungeonSub> list = new List<ActivityDungeonSub>();
			List<ActivityDungeonTab> tabByActivityType = this.GetTabByActivityType(type);
			for (int i = 0; i < tabByActivityType.Count; i++)
			{
				list.AddRange(tabByActivityType[i].subs);
			}
			list.Sort();
			return list;
		}

		// Token: 0x0600C281 RID: 49793 RVA: 0x002E5B23 File Offset: 0x002E3F23
		public bool IsShowRedByActivityType(ActivityDungeonTable.eActivityType type)
		{
			return this.GetRedCountByActivityType(type) > 0;
		}

		// Token: 0x0600C282 RID: 49794 RVA: 0x002E5B30 File Offset: 0x002E3F30
		public int GetRedCountByActivityType(ActivityDungeonTable.eActivityType type)
		{
			int num = 0;
			List<ActivityDungeonTab> tabByActivityType = this.GetTabByActivityType(type);
			for (int i = 0; i < tabByActivityType.Count; i++)
			{
				num += this.GetTabRedCount(tabByActivityType[i]);
			}
			return num;
		}

		// Token: 0x0600C283 RID: 49795 RVA: 0x002E5B6F File Offset: 0x002E3F6F
		private bool _isTabsEmptyOrNull(List<ActivityDungeonTab> tabs)
		{
			return tabs == null || tabs.Count <= 0;
		}

		// Token: 0x0600C284 RID: 49796 RVA: 0x002E5B86 File Offset: 0x002E3F86
		public bool IsActivityDungeonBeAttackCityMonster(ActivityDungeonTable table)
		{
			return table != null && DataManager<AttackCityMonsterDataManager>.GetInstance().IsAttackCityMonsterStr(table.GoLinkInfo);
		}

		// Token: 0x0600C285 RID: 49797 RVA: 0x002E5BA8 File Offset: 0x002E3FA8
		public static bool IsUltimateChallengeActivity(ActivityDungeonTable table)
		{
			if (table == null)
			{
				return false;
			}
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(table.DungeonID, string.Empty, string.Empty);
			return tableItem != null && tableItem.SubType == DungeonTable.eSubType.S_FINALTEST_PVE;
		}

		// Token: 0x0600C286 RID: 49798 RVA: 0x002E5BEA File Offset: 0x002E3FEA
		public void ActivityDungeonFindAttackCityMonster()
		{
			DataManager<AttackCityMonsterDataManager>.GetInstance().EnterFindPathProcessByActivityDuplication();
		}

		// Token: 0x0600C287 RID: 49799 RVA: 0x002E5BF6 File Offset: 0x002E3FF6
		public bool IsActivityDungeonBeHonorBattleField(ActivityDungeonTable table)
		{
			return table != null && DataManager<ChijiDataManager>.GetInstance().IsHonorBattleFieldStr(table.GoLinkInfo);
		}

		// Token: 0x0600C288 RID: 49800 RVA: 0x002E5C18 File Offset: 0x002E4018
		public bool IsActivityDungeonFairDuelField(ActivityDungeonTable table)
		{
			return table != null && DataManager<FairDuelDataManager>.GetInstance().IsFairDuelFieldStr(table.GoLinkInfo);
		}

		// Token: 0x0600C289 RID: 49801 RVA: 0x002E5C3C File Offset: 0x002E403C
		public bool _judgeDungeonIDIsRotteneterHell(int dungeonId)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			return tableItem != null && (tableItem.Type == DungeonTable.eType.L_ACTIVITY && (tableItem.SubType == DungeonTable.eSubType.S_LIMIT_TIME_HELL || tableItem.SubType == DungeonTable.eSubType.S_ANNIVERSARY_HARD || tableItem.SubType == DungeonTable.eSubType.S_ANNIVERSARY_NORMAL || tableItem.SubType == DungeonTable.eSubType.S_TREASUREMAP || tableItem.SubType == DungeonTable.eSubType.S_LIMIT_TIME__FREE_HELL));
		}

		// Token: 0x04006E1F RID: 28191
		protected List<ActivityDungeonTab> mTabs = new List<ActivityDungeonTab>();

		// Token: 0x04006E20 RID: 28192
		protected bool mIsInitedTableData;

		// Token: 0x04006E21 RID: 28193
		public bool mIsLimitActivityRedPoint;

		// Token: 0x04006E22 RID: 28194
		private int iRotteneterHellActivityID = 25000;

		// Token: 0x04006E23 RID: 28195
		public static int UltimateChallengeDungeonID = 10087;
	}
}
