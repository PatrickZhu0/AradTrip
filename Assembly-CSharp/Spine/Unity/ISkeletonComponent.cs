using System;

namespace Spine.Unity
{
	// Token: 0x020049F5 RID: 18933
	public interface ISkeletonComponent
	{
		// Token: 0x17002428 RID: 9256
		// (get) Token: 0x0601B52C RID: 111916
		SkeletonDataAsset SkeletonDataAsset { get; }

		// Token: 0x17002429 RID: 9257
		// (get) Token: 0x0601B52D RID: 111917
		Skeleton Skeleton { get; }
	}
}
