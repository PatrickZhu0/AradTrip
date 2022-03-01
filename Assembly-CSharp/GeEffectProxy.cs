using System;
using Spine.Unity;
using UnityEngine;

// Token: 0x02000CF0 RID: 3312
public class GeEffectProxy : MonoBehaviour
{
	// Token: 0x060087B3 RID: 34739 RVA: 0x0017F878 File Offset: 0x0017DC78
	public void DoCookData(bool ingame = false)
	{
		this.m_AudioProxy = base.gameObject.GetComponent<EffectAudioProxy>();
		this.m_Animations = base.gameObject.GetComponentsInChildren<Animation>(true);
		this.m_ParticleSys = base.gameObject.GetComponentsInChildren<ParticleSystem>(true);
		this.m_Trails = base.gameObject.GetComponentsInChildren<TrailRenderer>(true);
		this.m_SeqFrames = base.gameObject.GetComponentsInChildren<FrameMaterials>(true);
		this.m_ParticleEmitter = base.gameObject.GetComponentsInChildren<ParticleEmitter>(true);
		this.m_ParticleAnimator = base.gameObject.GetComponentsInChildren<ParticleAnimator>(true);
		this.m_Animators = base.gameObject.GetComponentsInChildren<Animator>(true);
		this.m_MeshRenderer = base.gameObject.GetComponentsInChildren<MeshRenderer>();
		this.m_SpineAnimations = base.gameObject.GetComponentsInChildren<SkeletonAnimation>();
		this.m_SpineAnimationsUI = base.gameObject.GetComponentsInChildren<SkeletonGraphic>();
		this.defaultTimeLen = GeEffectProxy.GetDefaultTimeLen(this.m_ParticleSys, this.m_Animations, this.m_SeqFrames, this.m_Animators);
		this._removeDestroyDelay(false);
		ComAnimatorAutoClose[] componentsInChildren = base.gameObject.GetComponentsInChildren<ComAnimatorAutoClose>(true);
		if (componentsInChildren != null && componentsInChildren.Length > 0 && ingame)
		{
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = false;
			}
		}
	}

	// Token: 0x060087B4 RID: 34740 RVA: 0x0017F9B0 File Offset: 0x0017DDB0
	private void _removeDestroyDelay(bool ingame = false)
	{
		DestroyDelay[] componentsInChildren = base.gameObject.GetComponentsInChildren<DestroyDelay>();
		if (componentsInChildren != null && componentsInChildren.Length > 0)
		{
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = false;
				if (ingame)
				{
					Object.Destroy(componentsInChildren[i].gameObject);
				}
			}
		}
	}

	// Token: 0x060087B5 RID: 34741 RVA: 0x0017FA08 File Offset: 0x0017DE08
	public static float GetDefaultTimeLen(ParticleSystem[] m_ParticleSys, Animation[] m_Animations, FrameMaterials[] m_SeqFrames, Animator[] m_Animators)
	{
		float num = 0f;
		if (m_ParticleSys != null)
		{
			foreach (ParticleSystem particleSystem in m_ParticleSys)
			{
				if (!(particleSystem == null))
				{
					float num2 = particleSystem.duration + particleSystem.startDelay + particleSystem.startLifetime;
					if (num2 > num)
					{
						num = num2;
					}
				}
			}
		}
		if (m_Animations != null)
		{
			foreach (Animation animation in m_Animations)
			{
				if (animation != null && animation.clip != null && num < animation.clip.length)
				{
					num = animation.clip.length;
				}
			}
		}
		if (m_SeqFrames != null)
		{
			foreach (FrameMaterials frameMaterials in m_SeqFrames)
			{
				if (frameMaterials != null && num < frameMaterials.Duration())
				{
					num = frameMaterials.Duration();
				}
			}
		}
		if (m_Animators != null)
		{
			foreach (Animator animator in m_Animators)
			{
				if (!(null == animator))
				{
					animator.Rebind();
					if (!(animator.runtimeAnimatorController == null))
					{
						AnimatorClipInfo[] currentAnimatorClipInfo = animator.GetCurrentAnimatorClipInfo(0);
						if (currentAnimatorClipInfo.Length > 0)
						{
							for (int m = 0; m < currentAnimatorClipInfo.Length; m++)
							{
								if (currentAnimatorClipInfo[m].clip != null && num < currentAnimatorClipInfo[m].clip.length)
								{
									num = currentAnimatorClipInfo[m].clip.length;
								}
							}
						}
						else
						{
							AnimationClip[] animationClips = animator.runtimeAnimatorController.animationClips;
							for (int n = 0; n < animationClips.Length; n++)
							{
								if (animationClips[n] != null && num < animationClips[n].length)
								{
									num = animationClips[n].length;
								}
							}
						}
					}
				}
			}
		}
		return num;
	}

	// Token: 0x04004160 RID: 16736
	[HideInInspector]
	public EffectAudioProxy m_AudioProxy;

	// Token: 0x04004161 RID: 16737
	[HideInInspector]
	public Animation[] m_Animations;

	// Token: 0x04004162 RID: 16738
	[HideInInspector]
	public ParticleSystem[] m_ParticleSys;

	// Token: 0x04004163 RID: 16739
	[HideInInspector]
	public TrailRenderer[] m_Trails;

	// Token: 0x04004164 RID: 16740
	[HideInInspector]
	public FrameMaterials[] m_SeqFrames;

	// Token: 0x04004165 RID: 16741
	[HideInInspector]
	public ParticleEmitter[] m_ParticleEmitter;

	// Token: 0x04004166 RID: 16742
	[HideInInspector]
	public ParticleAnimator[] m_ParticleAnimator;

	// Token: 0x04004167 RID: 16743
	[HideInInspector]
	public Animator[] m_Animators;

	// Token: 0x04004168 RID: 16744
	[HideInInspector]
	public MeshRenderer[] m_MeshRenderer;

	// Token: 0x04004169 RID: 16745
	[HideInInspector]
	public SkeletonAnimation[] m_SpineAnimations;

	// Token: 0x0400416A RID: 16746
	[HideInInspector]
	public SkeletonGraphic[] m_SpineAnimationsUI;

	// Token: 0x0400416B RID: 16747
	[HideInInspector]
	public float defaultTimeLen;

	// Token: 0x0400416C RID: 16748
	public bool m_LockLoop;
}
