using System;
using System.Collections.Generic;
using System.Text;

namespace GameClient
{
	// Token: 0x0200138D RID: 5005
	public class ActivityMutiInfo : IComparable<ActivityMutiInfo>
	{
		// Token: 0x0600C216 RID: 49686 RVA: 0x002E4230 File Offset: 0x002E2630
		public ActivityMutiInfo(IList<int> activityIds)
		{
			this.activityIds = activityIds;
			this._initActivitys();
		}

		// Token: 0x0600C217 RID: 49687 RVA: 0x002E4250 File Offset: 0x002E2650
		private void _initActivitys()
		{
			if (this.activityIds == null)
			{
				return;
			}
			for (int i = 0; i < this.activityIds.Count; i++)
			{
				this._addOneActivityAndSort(this.activityIds[i]);
			}
		}

		// Token: 0x0600C218 RID: 49688 RVA: 0x002E4298 File Offset: 0x002E2698
		private void _addOneActivityAndSort(int activityId)
		{
			ActivityInfoNode item = new ActivityInfoNode(activityId);
			this.activitys.Add(item);
			this.activitys.Sort();
		}

		// Token: 0x17001BC0 RID: 7104
		// (get) Token: 0x0600C219 RID: 49689 RVA: 0x002E42C4 File Offset: 0x002E26C4
		public int activityId
		{
			get
			{
				ActivityInfoNode activityInfoNode = this._findNearListNodeByServerTime();
				if (activityInfoNode != null)
				{
					return activityInfoNode.activityId;
				}
				return -1;
			}
		}

		// Token: 0x17001BC1 RID: 7105
		// (get) Token: 0x0600C21A RID: 49690 RVA: 0x002E42E8 File Offset: 0x002E26E8
		public eActivityDungeonState state
		{
			get
			{
				ActivityInfoNode activityInfoNode = this._findNearListNodeByServerTime();
				if (activityInfoNode != null)
				{
					return activityInfoNode.state;
				}
				return eActivityDungeonState.None;
			}
		}

		// Token: 0x17001BC2 RID: 7106
		// (get) Token: 0x0600C21B RID: 49691 RVA: 0x002E430C File Offset: 0x002E270C
		public int level
		{
			get
			{
				ActivityInfoNode activityInfoNode = this._findNearListNodeByServerTime();
				if (activityInfoNode != null)
				{
					return activityInfoNode.level;
				}
				return 0;
			}
		}

		// Token: 0x17001BC3 RID: 7107
		// (get) Token: 0x0600C21C RID: 49692 RVA: 0x002E4330 File Offset: 0x002E2730
		public string servername
		{
			get
			{
				ActivityInfoNode activityInfoNode = this._findNearListNodeByServerTime();
				if (activityInfoNode != null)
				{
					return activityInfoNode.servername;
				}
				return string.Empty;
			}
		}

		// Token: 0x17001BC4 RID: 7108
		// (get) Token: 0x0600C21D RID: 49693 RVA: 0x002E4358 File Offset: 0x002E2758
		public uint pretime
		{
			get
			{
				ActivityInfoNode activityInfoNode = this._findNearListNodeByServerTime();
				if (activityInfoNode != null)
				{
					return activityInfoNode.pretime;
				}
				return 0U;
			}
		}

		// Token: 0x17001BC5 RID: 7109
		// (get) Token: 0x0600C21E RID: 49694 RVA: 0x002E437C File Offset: 0x002E277C
		public uint starttime
		{
			get
			{
				ActivityInfoNode activityInfoNode = this._findNearListNodeByServerTime();
				if (activityInfoNode != null)
				{
					return activityInfoNode.starttime;
				}
				return 0U;
			}
		}

		// Token: 0x17001BC6 RID: 7110
		// (get) Token: 0x0600C21F RID: 49695 RVA: 0x002E43A0 File Offset: 0x002E27A0
		public uint endtime
		{
			get
			{
				ActivityInfoNode activityInfoNode = this._findNearListNodeByServerTime();
				if (activityInfoNode != null)
				{
					return activityInfoNode.endtime;
				}
				return 0U;
			}
		}

		// Token: 0x0600C220 RID: 49696 RVA: 0x002E43C4 File Offset: 0x002E27C4
		private ActivityInfoNode _findNearListNodeByServerTime()
		{
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			for (int i = 0; i < this.activitys.Count; i++)
			{
				if (serverTime < this.activitys[i].endtime)
				{
					return this.activitys[i];
				}
			}
			return null;
		}

		// Token: 0x0600C221 RID: 49697 RVA: 0x002E4420 File Offset: 0x002E2820
		public void UpdateActivityByID(int activityId)
		{
			ActivityInfoNode activityInfoNode = this._findActivityInfoByID(activityId);
			if (activityInfoNode != null)
			{
				activityInfoNode.UpdateActivity();
			}
		}

		// Token: 0x0600C222 RID: 49698 RVA: 0x002E4444 File Offset: 0x002E2844
		private ActivityInfoNode _findActivityInfoByID(int activityId)
		{
			for (int i = 0; i < this.activitys.Count; i++)
			{
				if (this.activitys[i].activityId == activityId)
				{
					return this.activitys[i];
				}
			}
			return null;
		}

		// Token: 0x0600C223 RID: 49699 RVA: 0x002E4492 File Offset: 0x002E2892
		public int CompareTo(ActivityMutiInfo other)
		{
			return 0;
		}

		// Token: 0x0600C224 RID: 49700 RVA: 0x002E4498 File Offset: 0x002E2898
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("活动ID:");
			for (int i = 0; i < this.activityIds.Count; i++)
			{
				stringBuilder.Append(this.activityIds[i]);
				stringBuilder.Append(",");
			}
			stringBuilder.AppendLine();
			stringBuilder.Append("活动详情:");
			for (int j = 0; j < this.activitys.Count; j++)
			{
				stringBuilder.AppendFormat("ID:{0} 名字{1} 等级:{2} 状态:{3} 准备时间:{4} 开始时间:{5} 结束时间:{6}", new object[]
				{
					this.activitys[j].activityId,
					this.activitys[j].servername,
					this.activitys[j].level,
					this.activitys[j].state,
					Utility.ToUtcTime2Local((long)((ulong)this.activitys[j].pretime)).ToString("tt yyMMdd hh:mm:ss", Utility.cultureInfo),
					Utility.ToUtcTime2Local((long)((ulong)this.activitys[j].starttime)).ToString("tt yyMMdd hh:mm:ss", Utility.cultureInfo),
					Utility.ToUtcTime2Local((long)((ulong)this.activitys[j].endtime)).ToString("tt yyMMdd hh:mm:ss", Utility.cultureInfo)
				});
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04006DF7 RID: 28151
		private List<ActivityInfoNode> activitys = new List<ActivityInfoNode>();

		// Token: 0x04006DF8 RID: 28152
		private IList<int> activityIds;
	}
}
