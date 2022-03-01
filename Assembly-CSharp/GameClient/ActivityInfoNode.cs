using System;
using Protocol;

namespace GameClient
{
	// Token: 0x0200138C RID: 5004
	internal class ActivityInfoNode : IComparable<ActivityInfoNode>
	{
		// Token: 0x0600C1FE RID: 49662 RVA: 0x002E3FA7 File Offset: 0x002E23A7
		public ActivityInfoNode(int activityId)
		{
			this.activityId = activityId;
			this._findActivityInfoData();
			this._initFromActivityInfoData();
			this._updateActivityState();
		}

		// Token: 0x17001BB8 RID: 7096
		// (get) Token: 0x0600C1FF RID: 49663 RVA: 0x002E3FC8 File Offset: 0x002E23C8
		// (set) Token: 0x0600C200 RID: 49664 RVA: 0x002E3FD0 File Offset: 0x002E23D0
		public int activityId { get; private set; }

		// Token: 0x17001BB9 RID: 7097
		// (get) Token: 0x0600C201 RID: 49665 RVA: 0x002E3FD9 File Offset: 0x002E23D9
		// (set) Token: 0x0600C202 RID: 49666 RVA: 0x002E3FE1 File Offset: 0x002E23E1
		public ActivityInfo activityInfo { get; private set; }

		// Token: 0x17001BBA RID: 7098
		// (get) Token: 0x0600C203 RID: 49667 RVA: 0x002E3FEA File Offset: 0x002E23EA
		// (set) Token: 0x0600C204 RID: 49668 RVA: 0x002E3FF2 File Offset: 0x002E23F2
		public eActivityDungeonState state { get; private set; }

		// Token: 0x17001BBB RID: 7099
		// (get) Token: 0x0600C205 RID: 49669 RVA: 0x002E3FFB File Offset: 0x002E23FB
		// (set) Token: 0x0600C206 RID: 49670 RVA: 0x002E4003 File Offset: 0x002E2403
		public int level { get; private set; }

		// Token: 0x17001BBC RID: 7100
		// (get) Token: 0x0600C207 RID: 49671 RVA: 0x002E400C File Offset: 0x002E240C
		// (set) Token: 0x0600C208 RID: 49672 RVA: 0x002E4014 File Offset: 0x002E2414
		public string servername { get; private set; }

		// Token: 0x17001BBD RID: 7101
		// (get) Token: 0x0600C209 RID: 49673 RVA: 0x002E401D File Offset: 0x002E241D
		// (set) Token: 0x0600C20A RID: 49674 RVA: 0x002E4025 File Offset: 0x002E2425
		public uint pretime { get; private set; }

		// Token: 0x17001BBE RID: 7102
		// (get) Token: 0x0600C20B RID: 49675 RVA: 0x002E402E File Offset: 0x002E242E
		// (set) Token: 0x0600C20C RID: 49676 RVA: 0x002E4036 File Offset: 0x002E2436
		public uint starttime { get; private set; }

		// Token: 0x17001BBF RID: 7103
		// (get) Token: 0x0600C20D RID: 49677 RVA: 0x002E403F File Offset: 0x002E243F
		// (set) Token: 0x0600C20E RID: 49678 RVA: 0x002E4047 File Offset: 0x002E2447
		public uint endtime { get; private set; }

		// Token: 0x0600C20F RID: 49679 RVA: 0x002E4050 File Offset: 0x002E2450
		private void _findActivityInfoData()
		{
			if (DataManager<ActiveManager>.GetInstance().allActivities.ContainsKey(this.activityId))
			{
				this.activityInfo = DataManager<ActiveManager>.GetInstance().allActivities[this.activityId];
			}
		}

		// Token: 0x0600C210 RID: 49680 RVA: 0x002E408C File Offset: 0x002E248C
		private void _initFromActivityInfoData()
		{
			if (this.activityInfo == null)
			{
				return;
			}
			this.level = (int)this.activityInfo.level;
			this.pretime = this.activityInfo.preTime;
			this.starttime = this.activityInfo.startTime;
			this.endtime = this.activityInfo.dueTime;
			this.servername = this.activityInfo.name;
		}

		// Token: 0x0600C211 RID: 49681 RVA: 0x002E40FC File Offset: 0x002E24FC
		private void _updateActivityState()
		{
			this.state = eActivityDungeonState.None;
			if (this.activityInfo == null)
			{
				return;
			}
			StateType state = (StateType)this.activityInfo.state;
			if (state != StateType.End)
			{
				if (state != StateType.Ready)
				{
					if (state == StateType.Running)
					{
						this.state = eActivityDungeonState.Start;
					}
				}
				else
				{
					this.state = eActivityDungeonState.Prepare;
				}
			}
			else
			{
				this.state = eActivityDungeonState.End;
			}
			if ((this.state == eActivityDungeonState.Start || this.state == eActivityDungeonState.Prepare) && this.level > (int)DataManager<PlayerBaseData>.GetInstance().Level)
			{
				this.state = eActivityDungeonState.LevelLimit;
			}
		}

		// Token: 0x0600C212 RID: 49682 RVA: 0x002E4198 File Offset: 0x002E2598
		public void UpdateActivity()
		{
			this._findActivityInfoData();
			this._updateActivityState();
		}

		// Token: 0x0600C213 RID: 49683 RVA: 0x002E41A6 File Offset: 0x002E25A6
		public bool IsValidActivityInfo()
		{
			return eActivityDungeonState.None != this.state;
		}

		// Token: 0x0600C214 RID: 49684 RVA: 0x002E41B4 File Offset: 0x002E25B4
		public int CompareTo(ActivityInfoNode other)
		{
			if (this.pretime != other.pretime)
			{
				return this._cmpuint(this.pretime, other.pretime);
			}
			if (this.starttime != other.starttime)
			{
				return this._cmpuint(this.starttime, other.starttime);
			}
			return this._cmpuint(this.endtime, other.endtime);
		}

		// Token: 0x0600C215 RID: 49685 RVA: 0x002E421B File Offset: 0x002E261B
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
	}
}
