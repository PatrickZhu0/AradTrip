using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001391 RID: 5009
	public class ActivityDungeonSub : IComparable<ActivityDungeonSub>
	{
		// Token: 0x0600C232 RID: 49714 RVA: 0x002E47C6 File Offset: 0x002E2BC6
		public ActivityDungeonSub(int id, string tabname)
		{
			this.tabname = tabname;
			this.id = id;
			this._findTableDataAndInitFromData();
			this._createMutiNodeAndInitFormData();
			this._createUpdateData();
			this.UpdateStateAndRedPoint();
		}

		// Token: 0x17001BC7 RID: 7111
		// (get) Token: 0x0600C233 RID: 49715 RVA: 0x002E47FF File Offset: 0x002E2BFF
		// (set) Token: 0x0600C234 RID: 49716 RVA: 0x002E4807 File Offset: 0x002E2C07
		public ActivityMutiInfo activityInfo { get; private set; }

		// Token: 0x17001BC8 RID: 7112
		// (get) Token: 0x0600C235 RID: 49717 RVA: 0x002E4810 File Offset: 0x002E2C10
		// (set) Token: 0x0600C236 RID: 49718 RVA: 0x002E4818 File Offset: 0x002E2C18
		public int activityId { get; private set; }

		// Token: 0x17001BC9 RID: 7113
		// (get) Token: 0x0600C237 RID: 49719 RVA: 0x002E4821 File Offset: 0x002E2C21
		// (set) Token: 0x0600C238 RID: 49720 RVA: 0x002E4829 File Offset: 0x002E2C29
		public bool isshowred { get; private set; }

		// Token: 0x17001BCA RID: 7114
		// (get) Token: 0x0600C239 RID: 49721 RVA: 0x002E4832 File Offset: 0x002E2C32
		// (set) Token: 0x0600C23A RID: 49722 RVA: 0x002E483A File Offset: 0x002E2C3A
		public bool hasleftcount { get; private set; }

		// Token: 0x17001BCB RID: 7115
		// (get) Token: 0x0600C23B RID: 49723 RVA: 0x002E4843 File Offset: 0x002E2C43
		// (set) Token: 0x0600C23C RID: 49724 RVA: 0x002E484B File Offset: 0x002E2C4B
		public bool isfinish { get; private set; }

		// Token: 0x17001BCC RID: 7116
		// (get) Token: 0x0600C23D RID: 49725 RVA: 0x002E4854 File Offset: 0x002E2C54
		// (set) Token: 0x0600C23E RID: 49726 RVA: 0x002E485C File Offset: 0x002E2C5C
		public IActivityDungeonUpdateData updateData { get; private set; }

		// Token: 0x17001BCD RID: 7117
		// (get) Token: 0x0600C23F RID: 49727 RVA: 0x002E4865 File Offset: 0x002E2C65
		// (set) Token: 0x0600C240 RID: 49728 RVA: 0x002E486D File Offset: 0x002E2C6D
		public eActivityDungeonState state { get; private set; }

		// Token: 0x17001BCE RID: 7118
		// (get) Token: 0x0600C241 RID: 49729 RVA: 0x002E4876 File Offset: 0x002E2C76
		// (set) Token: 0x0600C242 RID: 49730 RVA: 0x002E48A3 File Offset: 0x002E2CA3
		public int level
		{
			get
			{
				if (this.IsUltimateChallengeActivity())
				{
					return Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.KingTower);
				}
				if (this.dungeonTable != null)
				{
					return this.dungeonTable.MinLevel;
				}
				return 0;
			}
			private set
			{
			}
		}

		// Token: 0x17001BCF RID: 7119
		// (get) Token: 0x0600C243 RID: 49731 RVA: 0x002E48A5 File Offset: 0x002E2CA5
		// (set) Token: 0x0600C244 RID: 49732 RVA: 0x002E48AD File Offset: 0x002E2CAD
		public string servername { get; private set; }

		// Token: 0x17001BD0 RID: 7120
		// (get) Token: 0x0600C245 RID: 49733 RVA: 0x002E48B6 File Offset: 0x002E2CB6
		// (set) Token: 0x0600C246 RID: 49734 RVA: 0x002E48BE File Offset: 0x002E2CBE
		public uint pretime { get; private set; }

		// Token: 0x17001BD1 RID: 7121
		// (get) Token: 0x0600C247 RID: 49735 RVA: 0x002E48C7 File Offset: 0x002E2CC7
		// (set) Token: 0x0600C248 RID: 49736 RVA: 0x002E48CF File Offset: 0x002E2CCF
		public uint starttime { get; private set; }

		// Token: 0x17001BD2 RID: 7122
		// (get) Token: 0x0600C249 RID: 49737 RVA: 0x002E48D8 File Offset: 0x002E2CD8
		// (set) Token: 0x0600C24A RID: 49738 RVA: 0x002E48E0 File Offset: 0x002E2CE0
		public uint endtime { get; private set; }

		// Token: 0x0600C24B RID: 49739 RVA: 0x002E48E9 File Offset: 0x002E2CE9
		public void UpdateStateAndRedPoint()
		{
			if (this.table == null)
			{
				return;
			}
			this._updateRedPoint();
			this.UpdateState();
		}

		// Token: 0x0600C24C RID: 49740 RVA: 0x002E4903 File Offset: 0x002E2D03
		private void _updateRedPoint()
		{
			this.isshowred = this._isShowRed(this.table);
			this.hasleftcount = this._hasLeftCount();
			this.isfinish = this._hasFinishActivity();
		}

		// Token: 0x0600C24D RID: 49741 RVA: 0x002E4930 File Offset: 0x002E2D30
		private bool _hasFinishActivity()
		{
			if (this.hasleftcount)
			{
				return false;
			}
			if (this.IsUltimateChallengeActivity())
			{
				return DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeLeftCount() == 0;
			}
			return this.dungeonTable == null || this.dungeonTable.SubType != DungeonTable.eSubType.S_SIWANGZHITA || DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_TOWER_TOP_FLOOR) == 80;
		}

		// Token: 0x0600C24E RID: 49742 RVA: 0x002E4994 File Offset: 0x002E2D94
		public bool IsUltimateChallengeActivity()
		{
			return ActivityDungeonDataManager.IsUltimateChallengeActivity(this.table);
		}

		// Token: 0x0600C24F RID: 49743 RVA: 0x002E49A4 File Offset: 0x002E2DA4
		public void UpdateState()
		{
			if (this.state == eActivityDungeonState.Start || this.state == eActivityDungeonState.LevelLimit)
			{
				if (this.level > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					this.state = eActivityDungeonState.LevelLimit;
				}
				else
				{
					this.state = eActivityDungeonState.Start;
				}
			}
		}

		// Token: 0x0600C250 RID: 49744 RVA: 0x002E49F0 File Offset: 0x002E2DF0
		private bool _isCanUseSingle(ActivityDungeonTable table)
		{
			return table.ActivityType == ActivityDungeonTable.eActivityType.Daily;
		}

		// Token: 0x0600C251 RID: 49745 RVA: 0x002E49FC File Offset: 0x002E2DFC
		private bool _isShowRed(ActivityDungeonTable table)
		{
			if (table != null)
			{
				ActivityDungeonTable.eActivityType activityType = table.ActivityType;
				if (activityType != ActivityDungeonTable.eActivityType.Daily)
				{
					if (activityType == ActivityDungeonTable.eActivityType.TimeLimit)
					{
						return DataManager<ActivityDungeonDataManager>.GetInstance().mIsLimitActivityRedPoint && this.state == eActivityDungeonState.Start && (!DataManager<ActivityDungeonDataManager>.GetInstance().IsActivityDungeonBeAttackCityMonster(table) || !DataManager<AttackCityMonsterDataManager>.GetInstance().IsAlreadyFinishTotalBeatTimes()) && !this._isAlreadyShowRed;
					}
				}
				else
				{
					if (table.ID == 28)
					{
						return this.state == eActivityDungeonState.Start && DataManager<ActivityDataManager>.GetInstance().IsCustomsClearance() && DataManager<CountDataManager>.GetInstance().GetCount("zjsl_clear_award") == 0;
					}
					return this.state == eActivityDungeonState.Start && this.updateData.IsChanged();
				}
			}
			return false;
		}

		// Token: 0x0600C252 RID: 49746 RVA: 0x002E4ACF File Offset: 0x002E2ECF
		public void SetIsAlreadyShowRedFlag()
		{
			if (this.isshowred && !this._isAlreadyShowRed)
			{
				this._isAlreadyShowRed = true;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshLimitTimeState, null, null, null, null);
			}
		}

		// Token: 0x0600C253 RID: 49747 RVA: 0x002E4B04 File Offset: 0x002E2F04
		private bool _hasLeftCount()
		{
			if (this.dungeonTable != null)
			{
				IActivityConsumeData activityConsumeData;
				if (this.dungeonTable.SubType == DungeonTable.eSubType.S_SIWANGZHITA)
				{
					activityConsumeData = new DeadTowerActivityConsumeData(this.table.DungeonID);
				}
				else if (this.IsUltimateChallengeActivity())
				{
					activityConsumeData = new FinalTestActivityConsumeData(this.table.DungeonID);
				}
				else
				{
					activityConsumeData = new NormalActivityConsumeData(this.table.DungeonID);
				}
				return activityConsumeData.GetLeftCount() > 0L;
			}
			return false;
		}

		// Token: 0x0600C254 RID: 49748 RVA: 0x002E4B83 File Offset: 0x002E2F83
		public void Update(float delta)
		{
			if (this.updateData != null)
			{
				this.updateData.Update(delta);
			}
		}

		// Token: 0x0600C255 RID: 49749 RVA: 0x002E4B9C File Offset: 0x002E2F9C
		private void _findTableDataAndInitFromData()
		{
			this._findActivityTableData();
			this._initFromTableData();
		}

		// Token: 0x0600C256 RID: 49750 RVA: 0x002E4BAA File Offset: 0x002E2FAA
		private void _findActivityTableData()
		{
			this.table = Singleton<TableManager>.instance.GetTableItem<ActivityDungeonTable>(this.id, string.Empty, string.Empty);
		}

		// Token: 0x0600C257 RID: 49751 RVA: 0x002E4BCC File Offset: 0x002E2FCC
		private void _initFromTableData()
		{
			if (this.table == null)
			{
				return;
			}
			this.priority = this.table.SubPriority;
			this.dungeonId = this.table.DungeonID;
			this.dungeonTable = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(this.dungeonId, string.Empty, string.Empty);
			this.guidedungenId = -1;
			this.background = this.table.ImagePath;
			this.singleIcon = this.table.SingleTabIcon;
			this.extradesc = this.table.ExtraDescription;
			this.type = this.table.ActivityType;
			this.mode = this.table.Mode;
			this.desc = this._getDesc();
			this.name = this._getName();
			this.drops = this._getDrops();
			this.ishell = this._getIsHellMode();
		}

		// Token: 0x0600C258 RID: 49752 RVA: 0x002E4CB4 File Offset: 0x002E30B4
		private string _getDesc()
		{
			string result = string.Empty;
			if (this.table != null)
			{
				ActivityDungeonTable.eDescriptionType descriptionType = this.table.DescriptionType;
				if (descriptionType != ActivityDungeonTable.eDescriptionType.DungeonDescription)
				{
					if (descriptionType == ActivityDungeonTable.eDescriptionType.CustomDescription)
					{
						result = this.table.Description;
					}
				}
				else if (this._isCanUseSingle(this.table))
				{
					DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(this.table.DungeonID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						result = tableItem.Description;
					}
				}
			}
			return result;
		}

		// Token: 0x0600C259 RID: 49753 RVA: 0x002E4D48 File Offset: 0x002E3148
		private string _getName()
		{
			string result = string.Empty;
			if (this.table != null)
			{
				ActivityDungeonTable.eSubNameType subNameType = this.table.SubNameType;
				if (subNameType != ActivityDungeonTable.eSubNameType.DungeonName)
				{
					if (subNameType == ActivityDungeonTable.eSubNameType.CustomName)
					{
						result = this.table.SubName;
					}
				}
				else if (this._isCanUseSingle(this.table))
				{
					DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(this.table.DungeonID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						result = tableItem.Name;
					}
				}
			}
			return result;
		}

		// Token: 0x0600C25A RID: 49754 RVA: 0x002E4DDC File Offset: 0x002E31DC
		private bool _getIsHellMode()
		{
			if (this.table != null)
			{
				ActivityDungeonTable.eActivityType activityType = this.table.ActivityType;
				if (activityType == ActivityDungeonTable.eActivityType.Daily)
				{
					DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(this.table.DungeonID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						return tableItem.SubType == DungeonTable.eSubType.S_HELL || tableItem.SubType == DungeonTable.eSubType.S_HELL_ENTRY;
					}
				}
			}
			return false;
		}

		// Token: 0x0600C25B RID: 49755 RVA: 0x002E4E54 File Offset: 0x002E3254
		private IList<int> _getDrops()
		{
			if (this.table != null)
			{
				ActivityDungeonTable.eDropType dropType = this.table.DropType;
				if (dropType == ActivityDungeonTable.eDropType.CustomDrop)
				{
					return this.table.DropItems;
				}
				if (dropType == ActivityDungeonTable.eDropType.DungeonDrop)
				{
					if (this._isCanUseSingle(this.table))
					{
						DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(this.table.DungeonID, string.Empty, string.Empty);
						if (tableItem != null)
						{
							return tableItem.DropItems;
						}
					}
				}
			}
			return new List<int>();
		}

		// Token: 0x0600C25C RID: 49756 RVA: 0x002E4EE0 File Offset: 0x002E32E0
		private void _createMutiNodeAndInitFormData()
		{
			this.activityInfo = new ActivityMutiInfo(this.table.ActivityID);
			if (this.activityInfo != null)
			{
				this.state = this.activityInfo.state;
				this.activityId = this.activityInfo.activityId;
				this.level = this.activityInfo.level;
				this.pretime = this.activityInfo.pretime;
				this.starttime = this.activityInfo.starttime;
				this.endtime = this.activityInfo.endtime;
				this.servername = this.activityInfo.servername;
			}
		}

		// Token: 0x0600C25D RID: 49757 RVA: 0x002E4F85 File Offset: 0x002E3385
		private void _updateStateAndRedPoint()
		{
			if (this.table != null)
			{
				this.isshowred = this._isShowRed(this.table);
			}
			this.hasleftcount = this._hasLeftCount();
			this.isfinish = this._hasFinishActivity();
		}

		// Token: 0x0600C25E RID: 49758 RVA: 0x002E4FBC File Offset: 0x002E33BC
		private void _createUpdateData()
		{
			if (this._isDeadTower())
			{
				this.updateData = new ActivityDungeonDeadTowerUpdateData();
			}
			else
			{
				this.updateData = new BaseActivityDungeonUpdateData();
			}
		}

		// Token: 0x0600C25F RID: 49759 RVA: 0x002E4FE4 File Offset: 0x002E33E4
		private bool _isDeadTower()
		{
			return this.dungeonTable != null && DungeonTable.eSubType.S_SIWANGZHITA == this.dungeonTable.SubType;
		}

		// Token: 0x0600C260 RID: 49760 RVA: 0x002E5001 File Offset: 0x002E3401
		public string GetDungeonRecommendLevel()
		{
			if (this.dungeonTable != null)
			{
				return this.dungeonTable.RecommendLevel;
			}
			return string.Empty;
		}

		// Token: 0x0600C261 RID: 49761 RVA: 0x002E501F File Offset: 0x002E341F
		private int _cmpuint(uint a, uint b)
		{
			if (a > b)
			{
				return 1;
			}
			if (a == b)
			{
				return 0;
			}
			return -1;
		}

		// Token: 0x0600C262 RID: 49762 RVA: 0x002E5034 File Offset: 0x002E3434
		public int CompareTo(ActivityDungeonSub other)
		{
			if (this.state != other.state)
			{
				return this.state - other.state;
			}
			if (this.endtime != other.endtime)
			{
				return this._cmpuint(this.endtime, other.endtime);
			}
			if (this.level != other.level)
			{
				return this.level - other.level;
			}
			return this.priority - other.priority;
		}

		// Token: 0x04006E00 RID: 28160
		public string tabname;

		// Token: 0x04006E01 RID: 28161
		public int id;

		// Token: 0x04006E02 RID: 28162
		public ActivityDungeonTable table;

		// Token: 0x04006E03 RID: 28163
		public DungeonTable dungeonTable;

		// Token: 0x04006E04 RID: 28164
		public int priority;

		// Token: 0x04006E05 RID: 28165
		public int dungeonId;

		// Token: 0x04006E06 RID: 28166
		public int guidedungenId;

		// Token: 0x04006E07 RID: 28167
		public string singleIcon;

		// Token: 0x04006E08 RID: 28168
		public bool ishell;

		// Token: 0x04006E09 RID: 28169
		public string name;

		// Token: 0x04006E0A RID: 28170
		public string mode;

		// Token: 0x04006E0B RID: 28171
		public string background;

		// Token: 0x04006E0C RID: 28172
		public string desc;

		// Token: 0x04006E0D RID: 28173
		public string extradesc;

		// Token: 0x04006E0E RID: 28174
		public IList<int> drops = new List<int>();

		// Token: 0x04006E0F RID: 28175
		public ActivityDungeonTable.eActivityType type;

		// Token: 0x04006E1B RID: 28187
		private bool _isAlreadyShowRed;
	}
}
