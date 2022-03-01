using System;

namespace GameClient
{
	// Token: 0x02000213 RID: 531
	public enum VersionUpdateState
	{
		// Token: 0x04000BA6 RID: 2982
		None,
		// Token: 0x04000BA7 RID: 2983
		CheckPathPermission,
		// Token: 0x04000BA8 RID: 2984
		CheckNativeVerion,
		// Token: 0x04000BA9 RID: 2985
		CheckNetwork,
		// Token: 0x04000BAA RID: 2986
		CheckVersionServer,
		// Token: 0x04000BAB RID: 2987
		CheckRemoteVersion,
		// Token: 0x04000BAC RID: 2988
		CheckExpireVersion,
		// Token: 0x04000BAD RID: 2989
		FinishCheckVersion,
		// Token: 0x04000BAE RID: 2990
		GetPatchDiffList,
		// Token: 0x04000BAF RID: 2991
		DownloadPatch,
		// Token: 0x04000BB0 RID: 2992
		CheckPatch,
		// Token: 0x04000BB1 RID: 2993
		InstallPatch,
		// Token: 0x04000BB2 RID: 2994
		FinishUpdate,
		// Token: 0x04000BB3 RID: 2995
		WaitForRestart,
		// Token: 0x04000BB4 RID: 2996
		WaitFullUpdate
	}
}
