using System;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x020049E1 RID: 18913
	[CreateAssetMenu(menuName = "Spine/Animation Reference Asset")]
	public class AnimationReferenceAsset : ScriptableObject, IHasSkeletonDataAsset
	{
		// Token: 0x17002414 RID: 9236
		// (get) Token: 0x0601B48E RID: 111758 RVA: 0x00865E47 File Offset: 0x00864247
		public SkeletonDataAsset SkeletonDataAsset
		{
			get
			{
				return this.skeletonDataAsset;
			}
		}

		// Token: 0x17002415 RID: 9237
		// (get) Token: 0x0601B48F RID: 111759 RVA: 0x00865E4F File Offset: 0x0086424F
		public Animation Animation
		{
			get
			{
				if (this.animation == null)
				{
					this.Initialize();
				}
				return this.animation;
			}
		}

		// Token: 0x0601B490 RID: 111760 RVA: 0x00865E68 File Offset: 0x00864268
		public void Initialize()
		{
			if (this.skeletonDataAsset == null)
			{
				return;
			}
			this.animation = this.skeletonDataAsset.GetSkeletonData(true).FindAnimation(this.animationName);
			if (this.animation == null)
			{
				Debug.LogWarningFormat("Animation '{0}' not found in SkeletonData : {1}.", new object[]
				{
					this.animationName,
					this.skeletonDataAsset.name
				});
			}
		}

		// Token: 0x0601B491 RID: 111761 RVA: 0x00865ED6 File Offset: 0x008642D6
		public static implicit operator Animation(AnimationReferenceAsset asset)
		{
			return asset.Animation;
		}

		// Token: 0x04013010 RID: 77840
		private const bool QuietSkeletonData = true;

		// Token: 0x04013011 RID: 77841
		[SerializeField]
		protected SkeletonDataAsset skeletonDataAsset;

		// Token: 0x04013012 RID: 77842
		[SerializeField]
		[SpineAnimation("", "", true, false)]
		protected string animationName;

		// Token: 0x04013013 RID: 77843
		private Animation animation;
	}
}
