using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012C7 RID: 4807
	public class Pk3v3RoomSettingData
	{
		// Token: 0x0600BA0F RID: 47631 RVA: 0x002ADD90 File Offset: 0x002AC190
		public void DefaultInit()
		{
			this.bSetMinLv = false;
			this.bSetMinRankLv = false;
			this.MinLv = Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.Duel);
			this.MinRankLv = DataManager<SeasonDataManager>.GetInstance().GetMinRankID();
		}

		// Token: 0x040068A3 RID: 26787
		public bool bSetMinLv;

		// Token: 0x040068A4 RID: 26788
		public bool bSetMinRankLv;

		// Token: 0x040068A5 RID: 26789
		public int MinLv;

		// Token: 0x040068A6 RID: 26790
		public int MinRankLv;
	}
}
