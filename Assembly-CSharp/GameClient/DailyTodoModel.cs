using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001230 RID: 4656
	public class DailyTodoModel
	{
		// Token: 0x0600B2F5 RID: 45813 RVA: 0x0027C294 File Offset: 0x0027A694
		public DailyTodoModel()
		{
			this.Clear();
		}

		// Token: 0x0600B2F6 RID: 45814 RVA: 0x0027C2C8 File Offset: 0x0027A6C8
		public virtual void Clear()
		{
			this.tableId = 0;
			this.type = DailyTodoTable.eType.TP_NONE;
			this.subType = DailyTodoTable.eSubType.DTSTP_NONE;
			this.name = string.Empty;
			this.backgroundImgPath = string.Empty;
			this.linkinfo = string.Empty;
			if (this.isTodayOpenedHandler != null)
			{
				Delegate[] invocationList = this.isTodayOpenedHandler.GetInvocationList();
				if (invocationList != null && invocationList.Length > 0)
				{
					for (int i = 0; i < invocationList.Length; i++)
					{
						Func<DailyTodoTable.eSubType, bool> value = invocationList[i] as Func<DailyTodoTable.eSubType, bool>;
						this.isTodayOpenedHandler = (Func<DailyTodoTable.eSubType, bool>)Delegate.Remove(this.isTodayOpenedHandler, value);
					}
				}
				this.isTodayOpenedHandler = null;
			}
			if (this.openWeeks != null)
			{
				this.openWeeks.Clear();
			}
			this.openTimes = default(DailyTodoTimeStruct);
			this.refreshHour = 0;
		}

		// Token: 0x040064E1 RID: 25825
		public int tableId;

		// Token: 0x040064E2 RID: 25826
		public DailyTodoTable.eType type;

		// Token: 0x040064E3 RID: 25827
		public DailyTodoTable.eSubType subType;

		// Token: 0x040064E4 RID: 25828
		public string name;

		// Token: 0x040064E5 RID: 25829
		public string backgroundImgPath;

		// Token: 0x040064E6 RID: 25830
		public string linkinfo;

		// Token: 0x040064E7 RID: 25831
		public Func<DailyTodoTable.eSubType, bool> isTodayOpenedHandler;

		// Token: 0x040064E8 RID: 25832
		public int refreshHour;

		// Token: 0x040064E9 RID: 25833
		public List<int> openWeeks = new List<int>();

		// Token: 0x040064EA RID: 25834
		public DailyTodoTimeStruct openTimes = default(DailyTodoTimeStruct);
	}
}
