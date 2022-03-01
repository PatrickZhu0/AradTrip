using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200130A RID: 4874
	internal class TeamChangeInfo
	{
		// Token: 0x0600BD37 RID: 48439 RVA: 0x002C4288 File Offset: 0x002C2688
		public string GetRandomTeamName()
		{
			TeamNameTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamNameTable>(Random.Range(5001, 5660), string.Empty, string.Empty);
			TeamNameTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<TeamNameTable>(Random.Range(1001, 2398), string.Empty, string.Empty);
			return string.Format("{0}{1}", tableItem.Name, tableItem2.Name);
		}

		// Token: 0x0600BD38 RID: 48440 RVA: 0x002C42F3 File Offset: 0x002C26F3
		public void Debug()
		{
		}

		// Token: 0x04006A6F RID: 27247
		public byte dungeonType;

		// Token: 0x04006A70 RID: 27248
		public uint chapterID;

		// Token: 0x04006A71 RID: 27249
		public uint dungeonID;

		// Token: 0x04006A72 RID: 27250
		public byte hardType;

		// Token: 0x04006A73 RID: 27251
		public string teamName;

		// Token: 0x04006A74 RID: 27252
		public byte memberCount;

		// Token: 0x04006A75 RID: 27253
		public bool hasPassward;

		// Token: 0x04006A76 RID: 27254
		public bool passwardChanged;

		// Token: 0x04006A77 RID: 27255
		public string passward;
	}
}
