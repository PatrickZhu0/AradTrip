using System;

namespace Spine.Unity
{
	// Token: 0x020049F3 RID: 18931
	public interface ISkeletonAnimation
	{
		// Token: 0x1400007F RID: 127
		// (add) Token: 0x0601B523 RID: 111907
		// (remove) Token: 0x0601B524 RID: 111908
		event UpdateBonesDelegate UpdateLocal;

		// Token: 0x14000080 RID: 128
		// (add) Token: 0x0601B525 RID: 111909
		// (remove) Token: 0x0601B526 RID: 111910
		event UpdateBonesDelegate UpdateWorld;

		// Token: 0x14000081 RID: 129
		// (add) Token: 0x0601B527 RID: 111911
		// (remove) Token: 0x0601B528 RID: 111912
		event UpdateBonesDelegate UpdateComplete;

		// Token: 0x17002426 RID: 9254
		// (get) Token: 0x0601B529 RID: 111913
		Skeleton Skeleton { get; }

		// Token: 0x0601B52A RID: 111914
		void ReWind();
	}
}
