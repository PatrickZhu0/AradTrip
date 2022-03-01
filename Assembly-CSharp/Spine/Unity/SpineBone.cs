using System;

namespace Spine.Unity
{
	// Token: 0x02004A36 RID: 18998
	public class SpineBone : SpineAttributeBase
	{
		// Token: 0x0601B6F8 RID: 112376 RVA: 0x00876656 File Offset: 0x00874A56
		public SpineBone(string startsWith = "", string dataField = "", bool includeNone = true, bool fallbackToTextField = false)
		{
			this.startsWith = startsWith;
			this.dataField = dataField;
			this.includeNone = includeNone;
			this.fallbackToTextField = fallbackToTextField;
		}

		// Token: 0x0601B6F9 RID: 112377 RVA: 0x0087667B File Offset: 0x00874A7B
		public static Bone GetBone(string boneName, SkeletonRenderer renderer)
		{
			return (renderer.skeleton != null) ? renderer.skeleton.FindBone(boneName) : null;
		}

		// Token: 0x0601B6FA RID: 112378 RVA: 0x0087669C File Offset: 0x00874A9C
		public static BoneData GetBoneData(string boneName, SkeletonDataAsset skeletonDataAsset)
		{
			SkeletonData skeletonData = skeletonDataAsset.GetSkeletonData(true);
			return skeletonData.FindBone(boneName);
		}
	}
}
