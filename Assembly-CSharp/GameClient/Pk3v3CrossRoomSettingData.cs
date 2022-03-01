using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012C1 RID: 4801
	public class Pk3v3CrossRoomSettingData
	{
		// Token: 0x0600B99C RID: 47516 RVA: 0x002AA871 File Offset: 0x002A8C71
		public void DefaultInit()
		{
			this.bSetMinLv = false;
			this.bSetMinRankLv = false;
			this.MinLv = Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.Duel);
			this.MinRankLv = DataManager<SeasonDataManager>.GetInstance().GetMinRankID();
		}

		// Token: 0x04006868 RID: 26728
		public bool bSetMinLv;

		// Token: 0x04006869 RID: 26729
		public bool bSetMinRankLv;

		// Token: 0x0400686A RID: 26730
		public int MinLv;

		// Token: 0x0400686B RID: 26731
		public int MinRankLv;
	}
}
