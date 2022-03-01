using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x020049EA RID: 18922
	[RequireComponent(typeof(Animator))]
	public class SkeletonAnimator : SkeletonRenderer, ISkeletonAnimation
	{
		// Token: 0x17002420 RID: 9248
		// (get) Token: 0x0601B4E1 RID: 111841 RVA: 0x00867EFC File Offset: 0x008662FC
		public SkeletonAnimator.MecanimTranslator Translator
		{
			get
			{
				return this.translator;
			}
		}

		// Token: 0x14000075 RID: 117
		// (add) Token: 0x0601B4E2 RID: 111842 RVA: 0x00867F04 File Offset: 0x00866304
		// (remove) Token: 0x0601B4E3 RID: 111843 RVA: 0x00867F3C File Offset: 0x0086633C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected event UpdateBonesDelegate _UpdateLocal;

		// Token: 0x14000076 RID: 118
		// (add) Token: 0x0601B4E4 RID: 111844 RVA: 0x00867F74 File Offset: 0x00866374
		// (remove) Token: 0x0601B4E5 RID: 111845 RVA: 0x00867FAC File Offset: 0x008663AC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected event UpdateBonesDelegate _UpdateWorld;

		// Token: 0x14000077 RID: 119
		// (add) Token: 0x0601B4E6 RID: 111846 RVA: 0x00867FE4 File Offset: 0x008663E4
		// (remove) Token: 0x0601B4E7 RID: 111847 RVA: 0x0086801C File Offset: 0x0086641C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected event UpdateBonesDelegate _UpdateComplete;

		// Token: 0x14000078 RID: 120
		// (add) Token: 0x0601B4E8 RID: 111848 RVA: 0x00868052 File Offset: 0x00866452
		// (remove) Token: 0x0601B4E9 RID: 111849 RVA: 0x0086805B File Offset: 0x0086645B
		public event UpdateBonesDelegate UpdateLocal
		{
			add
			{
				this._UpdateLocal += value;
			}
			remove
			{
				this._UpdateLocal -= value;
			}
		}

		// Token: 0x14000079 RID: 121
		// (add) Token: 0x0601B4EA RID: 111850 RVA: 0x00868064 File Offset: 0x00866464
		// (remove) Token: 0x0601B4EB RID: 111851 RVA: 0x0086806D File Offset: 0x0086646D
		public event UpdateBonesDelegate UpdateWorld
		{
			add
			{
				this._UpdateWorld += value;
			}
			remove
			{
				this._UpdateWorld -= value;
			}
		}

		// Token: 0x1400007A RID: 122
		// (add) Token: 0x0601B4EC RID: 111852 RVA: 0x00868076 File Offset: 0x00866476
		// (remove) Token: 0x0601B4ED RID: 111853 RVA: 0x0086807F File Offset: 0x0086647F
		public event UpdateBonesDelegate UpdateComplete
		{
			add
			{
				this._UpdateComplete += value;
			}
			remove
			{
				this._UpdateComplete -= value;
			}
		}

		// Token: 0x0601B4EE RID: 111854 RVA: 0x00868088 File Offset: 0x00866488
		public override void Initialize(bool overwrite)
		{
			if (this.valid && !overwrite)
			{
				return;
			}
			base.Initialize(overwrite);
			if (!this.valid)
			{
				return;
			}
			if (this.translator == null)
			{
				this.translator = new SkeletonAnimator.MecanimTranslator();
			}
			this.translator.Initialize(base.GetComponent<Animator>(), this.skeletonDataAsset);
		}

		// Token: 0x0601B4EF RID: 111855 RVA: 0x008680E7 File Offset: 0x008664E7
		public void ReWind()
		{
			this.ClearState();
		}

		// Token: 0x0601B4F0 RID: 111856 RVA: 0x008680F0 File Offset: 0x008664F0
		public void Update()
		{
			if (!this.valid)
			{
				return;
			}
			this.translator.Apply(this.skeleton);
			if (this._UpdateLocal != null)
			{
				this._UpdateLocal(this);
			}
			this.skeleton.UpdateWorldTransform();
			if (this._UpdateWorld != null)
			{
				this._UpdateWorld(this);
				this.skeleton.UpdateWorldTransform();
			}
			if (this._UpdateComplete != null)
			{
				this._UpdateComplete(this);
			}
		}

		// Token: 0x04013044 RID: 77892
		[SerializeField]
		protected SkeletonAnimator.MecanimTranslator translator;

		// Token: 0x020049EB RID: 18923
		[Serializable]
		public class MecanimTranslator
		{
			// Token: 0x17002421 RID: 9249
			// (get) Token: 0x0601B4F2 RID: 111858 RVA: 0x008681DF File Offset: 0x008665DF
			public Animator Animator
			{
				get
				{
					return this.animator;
				}
			}

			// Token: 0x0601B4F3 RID: 111859 RVA: 0x008681E8 File Offset: 0x008665E8
			public void Initialize(Animator animator, SkeletonDataAsset skeletonDataAsset)
			{
				this.animator = animator;
				this.previousAnimations.Clear();
				this.animationTable.Clear();
				SkeletonData skeletonData = skeletonDataAsset.GetSkeletonData(true);
				foreach (Animation animation in skeletonData.Animations)
				{
					this.animationTable.Add(animation.Name.GetHashCode(), animation);
				}
				this.clipNameHashCodeTable.Clear();
				this.clipInfoCache.Clear();
				this.nextClipInfoCache.Clear();
			}

			// Token: 0x0601B4F4 RID: 111860 RVA: 0x0086829C File Offset: 0x0086669C
			public void Apply(Skeleton skeleton)
			{
				if (this.layerMixModes.Length < this.animator.layerCount)
				{
					Array.Resize<SkeletonAnimator.MecanimTranslator.MixMode>(ref this.layerMixModes, this.animator.layerCount);
				}
				if (this.autoReset)
				{
					List<Animation> list = this.previousAnimations;
					int i = 0;
					int count = list.Count;
					while (i < count)
					{
						list[i].SetKeyedItemsToSetupPose(skeleton);
						i++;
					}
					list.Clear();
					int j = 0;
					int layerCount = this.animator.layerCount;
					while (j < layerCount)
					{
						float num = (j != 0) ? this.animator.GetLayerWeight(j) : 1f;
						if (num > 0f)
						{
							bool flag = this.animator.GetNextAnimatorStateInfo(j).fullPathHash != 0;
							int num2;
							int num3;
							IList<AnimatorClipInfo> list2;
							IList<AnimatorClipInfo> list3;
							this.GetAnimatorClipInfos(j, out num2, out num3, out list2, out list3);
							for (int k = 0; k < num2; k++)
							{
								AnimatorClipInfo animatorClipInfo = list2[k];
								float num4 = animatorClipInfo.weight * num;
								if (num4 != 0f)
								{
									list.Add(this.GetAnimation(animatorClipInfo.clip));
								}
							}
							if (flag)
							{
								for (int l = 0; l < num3; l++)
								{
									AnimatorClipInfo animatorClipInfo2 = list3[l];
									float num5 = animatorClipInfo2.weight * num;
									if (num5 != 0f)
									{
										list.Add(this.GetAnimation(animatorClipInfo2.clip));
									}
								}
							}
						}
						j++;
					}
				}
				int m = 0;
				int layerCount2 = this.animator.layerCount;
				while (m < layerCount2)
				{
					float num6 = (m != 0) ? this.animator.GetLayerWeight(m) : 1f;
					AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(m);
					AnimatorStateInfo nextAnimatorStateInfo = this.animator.GetNextAnimatorStateInfo(m);
					bool flag2 = nextAnimatorStateInfo.fullPathHash != 0;
					int num7;
					int num8;
					IList<AnimatorClipInfo> list4;
					IList<AnimatorClipInfo> list5;
					this.GetAnimatorClipInfos(m, out num7, out num8, out list4, out list5);
					SkeletonAnimator.MecanimTranslator.MixMode mixMode = this.layerMixModes[m];
					if (mixMode == SkeletonAnimator.MecanimTranslator.MixMode.AlwaysMix)
					{
						for (int n = 0; n < num7; n++)
						{
							AnimatorClipInfo animatorClipInfo3 = list4[n];
							float num9 = animatorClipInfo3.weight * num6;
							if (num9 != 0f)
							{
								this.GetAnimation(animatorClipInfo3.clip).Apply(skeleton, 0f, SkeletonAnimator.MecanimTranslator.AnimationTime(currentAnimatorStateInfo.normalizedTime, animatorClipInfo3.clip.length, currentAnimatorStateInfo.loop, currentAnimatorStateInfo.speed < 0f), currentAnimatorStateInfo.loop, null, num9, MixPose.Current, MixDirection.In);
							}
						}
						if (flag2)
						{
							for (int num10 = 0; num10 < num8; num10++)
							{
								AnimatorClipInfo animatorClipInfo4 = list5[num10];
								float num11 = animatorClipInfo4.weight * num6;
								if (num11 != 0f)
								{
									this.GetAnimation(animatorClipInfo4.clip).Apply(skeleton, 0f, SkeletonAnimator.MecanimTranslator.AnimationTime(nextAnimatorStateInfo.normalizedTime, animatorClipInfo4.clip.length, nextAnimatorStateInfo.speed < 0f), nextAnimatorStateInfo.loop, null, num11, MixPose.Current, MixDirection.In);
								}
							}
						}
					}
					else
					{
						int num12;
						for (num12 = 0; num12 < num7; num12++)
						{
							AnimatorClipInfo animatorClipInfo5 = list4[num12];
							float num13 = animatorClipInfo5.weight * num6;
							if (num13 != 0f)
							{
								this.GetAnimation(animatorClipInfo5.clip).Apply(skeleton, 0f, SkeletonAnimator.MecanimTranslator.AnimationTime(currentAnimatorStateInfo.normalizedTime, animatorClipInfo5.clip.length, currentAnimatorStateInfo.loop, currentAnimatorStateInfo.speed < 0f), currentAnimatorStateInfo.loop, null, 1f, MixPose.Current, MixDirection.In);
								break;
							}
						}
						while (num12 < num7)
						{
							AnimatorClipInfo animatorClipInfo6 = list4[num12];
							float num14 = animatorClipInfo6.weight * num6;
							if (num14 != 0f)
							{
								this.GetAnimation(animatorClipInfo6.clip).Apply(skeleton, 0f, SkeletonAnimator.MecanimTranslator.AnimationTime(currentAnimatorStateInfo.normalizedTime, animatorClipInfo6.clip.length, currentAnimatorStateInfo.loop, currentAnimatorStateInfo.speed < 0f), currentAnimatorStateInfo.loop, null, num14, MixPose.Current, MixDirection.In);
							}
							num12++;
						}
						num12 = 0;
						if (flag2)
						{
							if (mixMode == SkeletonAnimator.MecanimTranslator.MixMode.SpineStyle)
							{
								while (num12 < num8)
								{
									AnimatorClipInfo animatorClipInfo7 = list5[num12];
									float num15 = animatorClipInfo7.weight * num6;
									if (num15 != 0f)
									{
										this.GetAnimation(animatorClipInfo7.clip).Apply(skeleton, 0f, SkeletonAnimator.MecanimTranslator.AnimationTime(nextAnimatorStateInfo.normalizedTime, animatorClipInfo7.clip.length, nextAnimatorStateInfo.speed < 0f), nextAnimatorStateInfo.loop, null, 1f, MixPose.Current, MixDirection.In);
										break;
									}
									num12++;
								}
							}
							while (num12 < num8)
							{
								AnimatorClipInfo animatorClipInfo8 = list5[num12];
								float num16 = animatorClipInfo8.weight * num6;
								if (num16 != 0f)
								{
									this.GetAnimation(animatorClipInfo8.clip).Apply(skeleton, 0f, SkeletonAnimator.MecanimTranslator.AnimationTime(nextAnimatorStateInfo.normalizedTime, animatorClipInfo8.clip.length, nextAnimatorStateInfo.speed < 0f), nextAnimatorStateInfo.loop, null, num16, MixPose.Current, MixDirection.In);
								}
								num12++;
							}
						}
					}
					m++;
				}
			}

			// Token: 0x0601B4F5 RID: 111861 RVA: 0x00868840 File Offset: 0x00866C40
			private static float AnimationTime(float normalizedTime, float clipLength, bool loop, bool reversed)
			{
				if (reversed)
				{
					normalizedTime = 1f - normalizedTime + (float)((int)normalizedTime) + (float)((int)normalizedTime);
				}
				float num = normalizedTime * clipLength;
				if (loop)
				{
					return num;
				}
				return (clipLength - num >= 0.033333335f) ? num : clipLength;
			}

			// Token: 0x0601B4F6 RID: 111862 RVA: 0x00868884 File Offset: 0x00866C84
			private static float AnimationTime(float normalizedTime, float clipLength, bool reversed)
			{
				if (reversed)
				{
					normalizedTime = 1f - normalizedTime + (float)((int)normalizedTime) + (float)((int)normalizedTime);
				}
				return normalizedTime * clipLength;
			}

			// Token: 0x0601B4F7 RID: 111863 RVA: 0x008688A0 File Offset: 0x00866CA0
			private void GetAnimatorClipInfos(int layer, out int clipInfoCount, out int nextClipInfoCount, out IList<AnimatorClipInfo> clipInfo, out IList<AnimatorClipInfo> nextClipInfo)
			{
				clipInfoCount = this.animator.GetCurrentAnimatorClipInfoCount(layer);
				nextClipInfoCount = this.animator.GetNextAnimatorClipInfoCount(layer);
				if (this.clipInfoCache.Capacity < clipInfoCount)
				{
					this.clipInfoCache.Capacity = clipInfoCount;
				}
				if (this.nextClipInfoCache.Capacity < nextClipInfoCount)
				{
					this.nextClipInfoCache.Capacity = nextClipInfoCount;
				}
				this.animator.GetCurrentAnimatorClipInfo(layer, this.clipInfoCache);
				this.animator.GetNextAnimatorClipInfo(layer, this.nextClipInfoCache);
				clipInfo = this.clipInfoCache;
				nextClipInfo = this.nextClipInfoCache;
			}

			// Token: 0x0601B4F8 RID: 111864 RVA: 0x00868940 File Offset: 0x00866D40
			private Animation GetAnimation(AnimationClip clip)
			{
				int hashCode;
				if (!this.clipNameHashCodeTable.TryGetValue(clip, out hashCode))
				{
					hashCode = clip.name.GetHashCode();
					this.clipNameHashCodeTable.Add(clip, hashCode);
				}
				Animation result;
				this.animationTable.TryGetValue(hashCode, out result);
				return result;
			}

			// Token: 0x04013048 RID: 77896
			public bool autoReset = true;

			// Token: 0x04013049 RID: 77897
			public SkeletonAnimator.MecanimTranslator.MixMode[] layerMixModes = new SkeletonAnimator.MecanimTranslator.MixMode[0];

			// Token: 0x0401304A RID: 77898
			private readonly Dictionary<int, Animation> animationTable = new Dictionary<int, Animation>(SkeletonAnimator.MecanimTranslator.IntEqualityComparer.Instance);

			// Token: 0x0401304B RID: 77899
			private readonly Dictionary<AnimationClip, int> clipNameHashCodeTable = new Dictionary<AnimationClip, int>(SkeletonAnimator.MecanimTranslator.AnimationClipEqualityComparer.Instance);

			// Token: 0x0401304C RID: 77900
			private readonly List<Animation> previousAnimations = new List<Animation>();

			// Token: 0x0401304D RID: 77901
			private readonly List<AnimatorClipInfo> clipInfoCache = new List<AnimatorClipInfo>();

			// Token: 0x0401304E RID: 77902
			private readonly List<AnimatorClipInfo> nextClipInfoCache = new List<AnimatorClipInfo>();

			// Token: 0x0401304F RID: 77903
			private Animator animator;

			// Token: 0x020049EC RID: 18924
			public enum MixMode
			{
				// Token: 0x04013051 RID: 77905
				AlwaysMix,
				// Token: 0x04013052 RID: 77906
				MixNext,
				// Token: 0x04013053 RID: 77907
				SpineStyle
			}

			// Token: 0x020049ED RID: 18925
			private class AnimationClipEqualityComparer : IEqualityComparer<AnimationClip>
			{
				// Token: 0x0601B4FA RID: 111866 RVA: 0x00868991 File Offset: 0x00866D91
				public bool Equals(AnimationClip x, AnimationClip y)
				{
					return x.GetInstanceID() == y.GetInstanceID();
				}

				// Token: 0x0601B4FB RID: 111867 RVA: 0x008689A1 File Offset: 0x00866DA1
				public int GetHashCode(AnimationClip o)
				{
					return o.GetInstanceID();
				}

				// Token: 0x04013054 RID: 77908
				internal static readonly IEqualityComparer<AnimationClip> Instance = new SkeletonAnimator.MecanimTranslator.AnimationClipEqualityComparer();
			}

			// Token: 0x020049EE RID: 18926
			private class IntEqualityComparer : IEqualityComparer<int>
			{
				// Token: 0x0601B4FE RID: 111870 RVA: 0x008689BD File Offset: 0x00866DBD
				public bool Equals(int x, int y)
				{
					return x == y;
				}

				// Token: 0x0601B4FF RID: 111871 RVA: 0x008689C3 File Offset: 0x00866DC3
				public int GetHashCode(int o)
				{
					return o;
				}

				// Token: 0x04013055 RID: 77909
				internal static readonly IEqualityComparer<int> Instance = new SkeletonAnimator.MecanimTranslator.IntEqualityComparer();
			}
		}
	}
}
