using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001231 RID: 4657
	public class DailyTodoActivity : DailyTodoModel, IComparable<DailyTodoActivity>
	{
		// Token: 0x0600B2F7 RID: 45815 RVA: 0x0027C398 File Offset: 0x0027A798
		public DailyTodoActivity()
		{
			this.Clear();
			this.type = DailyTodoTable.eType.TP_ACTIVITY;
		}

		// Token: 0x0600B2F8 RID: 45816 RVA: 0x0027C3C0 File Offset: 0x0027A7C0
		public override void Clear()
		{
			this.activityDungeonId = 0;
			this.timeDesc = string.Empty;
			if (this.rewardItemIds != null)
			{
				this.rewardItemIds.Clear();
			}
			if (this.gotoHandler != null)
			{
				Delegate[] invocationList = this.gotoHandler.GetInvocationList();
				if (invocationList != null && invocationList.Length > 0)
				{
					for (int i = 0; i < invocationList.Length; i++)
					{
						Action<DailyTodoActivity> value = invocationList[i] as Action<DailyTodoActivity>;
						this.gotoHandler = (Action<DailyTodoActivity>)Delegate.Remove(this.gotoHandler, value);
					}
				}
				this.gotoHandler = null;
			}
			this.activityDungeonState = eActivityDungeonState.None;
			base.Clear();
		}

		// Token: 0x0600B2F9 RID: 45817 RVA: 0x0027C463 File Offset: 0x0027A863
		public int CompareTo(DailyTodoActivity other)
		{
			if (other == null)
			{
				return 0;
			}
			return this.startTimestamp - other.startTimestamp;
		}

		// Token: 0x040064EB RID: 25835
		public int activityDungeonId;

		// Token: 0x040064EC RID: 25836
		public int startTimestamp;

		// Token: 0x040064ED RID: 25837
		public int endTimestamp;

		// Token: 0x040064EE RID: 25838
		public string timeDesc;

		// Token: 0x040064EF RID: 25839
		public List<int> rewardItemIds = new List<int>();

		// Token: 0x040064F0 RID: 25840
		public eActivityDungeonState activityDungeonState = eActivityDungeonState.None;

		// Token: 0x040064F1 RID: 25841
		public Action<DailyTodoActivity> gotoHandler;
	}
}
