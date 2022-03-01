using System;
using UnityEngine;

namespace Spine.Unity.Playables
{
	// Token: 0x02004A1D RID: 18973
	[AddComponentMenu("Spine/Playables/SkeletonAnimation Playable Handle (Playables)")]
	public class SkeletonAnimationPlayableHandle : SpinePlayableHandleBase
	{
		// Token: 0x17002451 RID: 9297
		// (get) Token: 0x0601B663 RID: 112227 RVA: 0x00873AA7 File Offset: 0x00871EA7
		public override Skeleton Skeleton
		{
			get
			{
				return this.skeletonAnimation.Skeleton;
			}
		}

		// Token: 0x17002452 RID: 9298
		// (get) Token: 0x0601B664 RID: 112228 RVA: 0x00873AB4 File Offset: 0x00871EB4
		public override SkeletonData SkeletonData
		{
			get
			{
				return this.skeletonAnimation.Skeleton.data;
			}
		}

		// Token: 0x04013164 RID: 78180
		public SkeletonAnimation skeletonAnimation;
	}
}
