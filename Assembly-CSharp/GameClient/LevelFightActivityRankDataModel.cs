using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001CEF RID: 7407
	public sealed class LevelFightActivityRankDataModel : LimitTimeActivityTaskDataModel
	{
		// Token: 0x06012309 RID: 74505 RVA: 0x0054DBC7 File Offset: 0x0054BFC7
		public LevelFightActivityRankDataModel(OpActivityTmpType tmpType, OpActTaskData taskData, OpActTask task, string desc, string name, uint rank) : base(tmpType, taskData, task, desc)
		{
			this.Name = name;
			this.Rank = rank;
		}

		// Token: 0x17001EB6 RID: 7862
		// (get) Token: 0x0601230A RID: 74506 RVA: 0x0054DBE4 File Offset: 0x0054BFE4
		// (set) Token: 0x0601230B RID: 74507 RVA: 0x0054DBEC File Offset: 0x0054BFEC
		public string Name { get; private set; }

		// Token: 0x17001EB7 RID: 7863
		// (get) Token: 0x0601230C RID: 74508 RVA: 0x0054DBF5 File Offset: 0x0054BFF5
		// (set) Token: 0x0601230D RID: 74509 RVA: 0x0054DBFD File Offset: 0x0054BFFD
		public uint Rank { get; private set; }

		// Token: 0x0601230E RID: 74510 RVA: 0x0054DC06 File Offset: 0x0054C006
		public void UpdateData(string name, uint rank)
		{
			this.Name = name;
			this.Rank = rank;
		}
	}
}
