using System;
using System.Collections.Generic;

namespace Spine
{
	// Token: 0x020049A4 RID: 18852
	public class AnimationStateData
	{
		// Token: 0x0601B18D RID: 110989 RVA: 0x008568BD File Offset: 0x00854CBD
		public AnimationStateData(SkeletonData skeletonData)
		{
			if (skeletonData == null)
			{
				throw new ArgumentException("skeletonData cannot be null.", "skeletonData");
			}
			this.skeletonData = skeletonData;
		}

		// Token: 0x17002312 RID: 8978
		// (get) Token: 0x0601B18E RID: 110990 RVA: 0x008568F2 File Offset: 0x00854CF2
		public SkeletonData SkeletonData
		{
			get
			{
				return this.skeletonData;
			}
		}

		// Token: 0x17002313 RID: 8979
		// (get) Token: 0x0601B18F RID: 110991 RVA: 0x008568FA File Offset: 0x00854CFA
		// (set) Token: 0x0601B190 RID: 110992 RVA: 0x00856902 File Offset: 0x00854D02
		public float DefaultMix
		{
			get
			{
				return this.defaultMix;
			}
			set
			{
				this.defaultMix = value;
			}
		}

		// Token: 0x0601B191 RID: 110993 RVA: 0x0085690C File Offset: 0x00854D0C
		public void SetMix(string fromName, string toName, float duration)
		{
			Animation animation = this.skeletonData.FindAnimation(fromName);
			if (animation == null)
			{
				throw new ArgumentException("Animation not found: " + fromName, "fromName");
			}
			Animation animation2 = this.skeletonData.FindAnimation(toName);
			if (animation2 == null)
			{
				throw new ArgumentException("Animation not found: " + toName, "toName");
			}
			this.SetMix(animation, animation2, duration);
		}

		// Token: 0x0601B192 RID: 110994 RVA: 0x00856974 File Offset: 0x00854D74
		public void SetMix(Animation from, Animation to, float duration)
		{
			if (from == null)
			{
				throw new ArgumentNullException("from", "from cannot be null.");
			}
			if (to == null)
			{
				throw new ArgumentNullException("to", "to cannot be null.");
			}
			AnimationStateData.AnimationPair key = new AnimationStateData.AnimationPair(from, to);
			this.animationToMixTime.Remove(key);
			this.animationToMixTime.Add(key, duration);
		}

		// Token: 0x0601B193 RID: 110995 RVA: 0x008569D0 File Offset: 0x00854DD0
		public float GetMix(Animation from, Animation to)
		{
			if (from == null)
			{
				throw new ArgumentNullException("from", "from cannot be null.");
			}
			if (to == null)
			{
				throw new ArgumentNullException("to", "to cannot be null.");
			}
			AnimationStateData.AnimationPair key = new AnimationStateData.AnimationPair(from, to);
			float result;
			if (this.animationToMixTime.TryGetValue(key, out result))
			{
				return result;
			}
			return this.defaultMix;
		}

		// Token: 0x04012E63 RID: 77411
		internal SkeletonData skeletonData;

		// Token: 0x04012E64 RID: 77412
		private readonly Dictionary<AnimationStateData.AnimationPair, float> animationToMixTime = new Dictionary<AnimationStateData.AnimationPair, float>(AnimationStateData.AnimationPairComparer.Instance);

		// Token: 0x04012E65 RID: 77413
		internal float defaultMix;

		// Token: 0x020049A5 RID: 18853
		public struct AnimationPair
		{
			// Token: 0x0601B194 RID: 110996 RVA: 0x00856A2D File Offset: 0x00854E2D
			public AnimationPair(Animation a1, Animation a2)
			{
				this.a1 = a1;
				this.a2 = a2;
			}

			// Token: 0x0601B195 RID: 110997 RVA: 0x00856A3D File Offset: 0x00854E3D
			public override string ToString()
			{
				return this.a1.name + "->" + this.a2.name;
			}

			// Token: 0x04012E66 RID: 77414
			public readonly Animation a1;

			// Token: 0x04012E67 RID: 77415
			public readonly Animation a2;
		}

		// Token: 0x020049A6 RID: 18854
		public class AnimationPairComparer : IEqualityComparer<AnimationStateData.AnimationPair>
		{
			// Token: 0x0601B197 RID: 110999 RVA: 0x00856A67 File Offset: 0x00854E67
			bool IEqualityComparer<AnimationStateData.AnimationPair>.Equals(AnimationStateData.AnimationPair x, AnimationStateData.AnimationPair y)
			{
				return object.ReferenceEquals(x.a1, y.a1) && object.ReferenceEquals(x.a2, y.a2);
			}

			// Token: 0x0601B198 RID: 111000 RVA: 0x00856A98 File Offset: 0x00854E98
			int IEqualityComparer<AnimationStateData.AnimationPair>.GetHashCode(AnimationStateData.AnimationPair obj)
			{
				int hashCode = obj.a1.GetHashCode();
				return (hashCode << 5) + hashCode ^ obj.a2.GetHashCode();
			}

			// Token: 0x04012E68 RID: 77416
			public static readonly AnimationStateData.AnimationPairComparer Instance = new AnimationStateData.AnimationPairComparer();
		}
	}
}
