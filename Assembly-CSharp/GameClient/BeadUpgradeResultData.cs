using System;

namespace GameClient
{
	// Token: 0x02001AD0 RID: 6864
	public class BeadUpgradeResultData
	{
		// Token: 0x06010D9A RID: 69018 RVA: 0x004CE22F File Offset: 0x004CC62F
		public BeadUpgradeResultData(int mountedType, ulong equipGuid, int mBeadID, int mBuffID, ulong mBeadGUID)
		{
			this.mountedType = mountedType;
			if (this.mountedType == 1)
			{
				this.equipGuid = equipGuid;
				this.mBeadID = mBeadID;
			}
			else
			{
				this.mBeadGUID = mBeadGUID;
			}
			this.mBuffID = mBuffID;
		}

		// Token: 0x0400ACE3 RID: 44259
		public int mountedType;

		// Token: 0x0400ACE4 RID: 44260
		public ulong equipGuid;

		// Token: 0x0400ACE5 RID: 44261
		public int mBeadID;

		// Token: 0x0400ACE6 RID: 44262
		public int mBuffID;

		// Token: 0x0400ACE7 RID: 44263
		public ulong mBeadGUID;
	}
}
