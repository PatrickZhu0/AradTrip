using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001309 RID: 4873
	internal class TeamCreateInfo
	{
		// Token: 0x0600BD33 RID: 48435 RVA: 0x002C41D5 File Offset: 0x002C25D5
		public void Reset()
		{
			this.DungeonType = 0;
			this.ChapterID = 0U;
			this.HardType = byte.MaxValue;
			this.TeamName = this.GetRandomTeamName();
			this.MemberCount = 4;
			this.Passward = string.Empty;
		}

		// Token: 0x0600BD34 RID: 48436 RVA: 0x002C4210 File Offset: 0x002C2610
		public string GetRandomTeamName()
		{
			TeamNameTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamNameTable>(Random.Range(5001, 5660), string.Empty, string.Empty);
			TeamNameTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<TeamNameTable>(Random.Range(1001, 2398), string.Empty, string.Empty);
			return string.Format("{0}{1}", tableItem.Name, tableItem2.Name);
		}

		// Token: 0x0600BD35 RID: 48437 RVA: 0x002C427B File Offset: 0x002C267B
		public void Debug()
		{
		}

		// Token: 0x04006A69 RID: 27241
		public byte DungeonType;

		// Token: 0x04006A6A RID: 27242
		public uint ChapterID;

		// Token: 0x04006A6B RID: 27243
		public byte HardType;

		// Token: 0x04006A6C RID: 27244
		public string TeamName;

		// Token: 0x04006A6D RID: 27245
		public byte MemberCount;

		// Token: 0x04006A6E RID: 27246
		public string Passward;
	}
}
