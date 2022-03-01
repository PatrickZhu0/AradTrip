using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012E6 RID: 4838
	public class WeekSignInAwardDataModel
	{
		// Token: 0x0600BBAE RID: 48046 RVA: 0x002B9860 File Offset: 0x002B7C60
		public void Reset()
		{
			this.WeekSignInType = WeekSignInType.None;
			this.AlreadySignInWeek = 0U;
			this.AlreadyReceiveWeekList.Clear();
			this.WeekSignSumTableList.Clear();
			this.WeekSignInBoxItemList.Clear();
		}

		// Token: 0x0600BBAF RID: 48047 RVA: 0x002B9894 File Offset: 0x002B7C94
		public bool IsTotalAwardCanReceived()
		{
			if (this.WeekSignSumTableList == null || this.WeekSignSumTableList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < this.WeekSignSumTableList.Count; i++)
			{
				WeekSignSumTable weekSignSumTable = this.WeekSignSumTableList[i];
				if (weekSignSumTable != null)
				{
					if ((long)weekSignSumTable.weekSum <= (long)((ulong)this.AlreadySignInWeek))
					{
						if (this.AlreadyReceiveWeekList == null || this.AlreadyReceiveWeekList.Count <= 0)
						{
							return true;
						}
						bool flag = false;
						for (int j = 0; j < this.AlreadyReceiveWeekList.Count; j++)
						{
							if ((ulong)this.AlreadyReceiveWeekList[j] == (ulong)((long)weekSignSumTable.weekSum))
							{
								flag = true;
							}
						}
						if (!flag)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x04006992 RID: 27026
		public WeekSignInType WeekSignInType;

		// Token: 0x04006993 RID: 27027
		public uint AlreadySignInWeek;

		// Token: 0x04006994 RID: 27028
		public List<uint> AlreadyReceiveWeekList = new List<uint>();

		// Token: 0x04006995 RID: 27029
		public List<WeekSignSumTable> WeekSignSumTableList = new List<WeekSignSumTable>();

		// Token: 0x04006996 RID: 27030
		public List<WeekSignBox> WeekSignInBoxItemList = new List<WeekSignBox>();
	}
}
