using System;
using Protocol;

namespace GameClient
{
	// Token: 0x020012D6 RID: 4822
	internal struct SecurityLockData
	{
		// Token: 0x04006923 RID: 26915
		public SecurityLockState lockState;

		// Token: 0x04006924 RID: 26916
		public bool isCommonDev;

		// Token: 0x04006925 RID: 26917
		public uint freezeTime;

		// Token: 0x04006926 RID: 26918
		public uint unFreezeTime;

		// Token: 0x04006927 RID: 26919
		public bool bBindDevice;

		// Token: 0x04006928 RID: 26920
		public bool isUseLock;

		// Token: 0x04006929 RID: 26921
		public uint verifyPwdFailedCount;
	}
}
