using System;

namespace GameClient
{
	// Token: 0x02001AC0 RID: 6848
	public class SaveBeadItemInfo
	{
		// Token: 0x06010D18 RID: 68888 RVA: 0x004CB2AF File Offset: 0x004C96AF
		public SaveBeadItemInfo(PrecBead hole, ComCommonBind bind, ComItem comItem)
		{
			this.mBeadMountHole = hole;
			this.mBind = bind;
			this.mComItem = comItem;
		}

		// Token: 0x0400AC76 RID: 44150
		public PrecBead mBeadMountHole;

		// Token: 0x0400AC77 RID: 44151
		public ComCommonBind mBind;

		// Token: 0x0400AC78 RID: 44152
		public ComItem mComItem;
	}
}
