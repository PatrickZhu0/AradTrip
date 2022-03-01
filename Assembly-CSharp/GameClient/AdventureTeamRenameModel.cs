using System;

namespace GameClient
{
	// Token: 0x020011CB RID: 4555
	public class AdventureTeamRenameModel
	{
		// Token: 0x0600AEF7 RID: 44791 RVA: 0x00263F28 File Offset: 0x00262328
		public AdventureTeamRenameModel()
		{
			this.Clear();
		}

		// Token: 0x0600AEF8 RID: 44792 RVA: 0x00263F36 File Offset: 0x00262336
		public void Clear()
		{
			this.renameItemGUID = 0UL;
			this.newNameStr = string.Empty;
		}

		// Token: 0x040061D7 RID: 25047
		public uint renameItemTableId;

		// Token: 0x040061D8 RID: 25048
		public ulong renameItemGUID;

		// Token: 0x040061D9 RID: 25049
		public string newNameStr;
	}
}
