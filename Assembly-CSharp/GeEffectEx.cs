using System;
using System.Collections;
using System.Collections.Generic;
using Battle;
using HGBase;
using Spine.Unity;
using UnityEngine;

// Token: 0x02000D29 RID: 3369
public class GeEffectEx
{
	// Token: 0x060089AD RID: 35245 RVA: 0x0018E8EA File Offset: 0x0018CCEA
	public float GetDefaultTimeLen()
	{
		return this._getDefaultTimeLen();
	}

	// Token: 0x060089AE RID: 35246 RVA: 0x0018E8F2 File Offset: 0x0018CCF2
	public static void ClearDefaultTimeMap()
	{
		GeEffectEx.defaultTimeMap.Clear();
	}

	// Token: 0x060089AF RID: 35247 RVA: 0x0018E900 File Offset: 0x0018CD00
	public void Reset()
	{
		this.m_PlaySpeed = 1f;
		this.m_ElapsedTimeMS = 0U;
		this.m_TimeLenMS = 0U;
		this.m_TimeType = EffectTimeType.SYNC_ANIMATION;
		if (this.m_EffectSpace.m_RootNode != null)
		{
			this.m_EffectSpace.m_RootNode.transform.SetParent(null, false);
			this.m_EffectSpace.m_RootNode.transform.position = Vector3.zero;
			this.m_EffectSpace.m_RootNode.transform.rotation = Quaternion.identity;
			this.m_EffectSpace.m_RootNode.transform.localScale = new Vector3(1f, 1f, 1f);
		}
		if (this.m_EffectSpace.m_EffectNode != null)
		{
			this.m_EffectSpace.m_EffectNode.transform.SetParent(null, false);
			this.m_EffectSpace.m_EffectNode.transform.position = Vector3.zero;
			this.m_EffectSpace.m_EffectNode.transform.rotation = Quaternion.identity;
			this.m_EffectSpace.m_EffectNode.transform.localScale = new Vector3(1f, 1f, 1f);
		}
		if (this.m_EffectSpace.m_GameObject != null)
		{
			CPooledGameObjectScript component = this.m_EffectSpace.m_GameObject.GetComponent<CPooledGameObjectScript>();
			if (component != null)
			{
				component.gameObject.transform.position = Vector3.zero;
				component.gameObject.transform.rotation = Quaternion.identity;
				component.gameObject.transform.localScale = component.m_defaultScale;
			}
		}
		if (this.m_SpineAnimations != null)
		{
			for (int i = 0; i < this.m_SpineAnimations.Count; i++)
			{
				this.m_SpineAnimations[i].ReWind();
			}
		}
	}

	// Token: 0x060089B0 RID: 35248 RVA: 0x0018EAEC File Offset: 0x0018CEEC
	public bool Init(string strResName, EffectsFrames info, float time, Vector3 initPos, bool bFaceLeft, GameObject parentObj = null, bool useCube = false)
	{
		this.useCube = useCube;
		this.m_Name = Utility.FormatString(strResName);
		this.m_EffectFrame = info;
		if (this.m_EffectFrame != null)
		{
			this.m_TimeType = this.m_EffectFrame.timetype;
		}
		this.m_EffectSpace.m_ParentNode = parentObj;
		if (string.IsNullOrEmpty(strResName) || "-" == strResName)
		{
			this.m_EffectSpace.m_GameObject = new GameObject("DummyEffect");
			return true;
		}
		if (useCube)
		{
			strResName = "Effects/DummyEffect/DummyEffect";
		}
		this.m_EffectSpace.m_GameObject = Singleton<CGameObjectPool>.instance.GetGameObject(strResName, enResourceType.BattleScene, 2U);
		if (null != this.m_EffectSpace.m_GameObject)
		{
			this.m_EffectSpace.m_GameObject.tag = "EffectModel";
			GeEffectProxy geEffectProxy = this.m_EffectSpace.m_GameObject.GetComponent<GeEffectProxy>();
			if (geEffectProxy == null)
			{
				geEffectProxy = this.m_EffectSpace.m_GameObject.AddComponent<GeEffectProxy>();
				geEffectProxy.DoCookData(true);
			}
			if ((geEffectProxy.m_SpineAnimations != null && geEffectProxy.m_SpineAnimations.Length > 0) || (geEffectProxy.m_SpineAnimationsUI != null && geEffectProxy.m_SpineAnimationsUI.Length > 0))
			{
				this.m_SpineAnimations = new List<ISkeletonAnimation>();
				if (geEffectProxy.m_SpineAnimations != null)
				{
					for (int i = 0; i < geEffectProxy.m_SpineAnimations.Length; i++)
					{
						this.m_SpineAnimations.Add(geEffectProxy.m_SpineAnimations[i]);
					}
				}
				if (geEffectProxy.m_SpineAnimationsUI != null)
				{
					for (int j = 0; j < geEffectProxy.m_SpineAnimationsUI.Length; j++)
					{
						this.m_SpineAnimations.Add(geEffectProxy.m_SpineAnimationsUI[j]);
					}
				}
			}
			this.m_AudioProxy = geEffectProxy.m_AudioProxy;
			this.m_Animations = geEffectProxy.m_Animations;
			this.m_ParticleSys = geEffectProxy.m_ParticleSys;
			this.m_Trails = geEffectProxy.m_Trails;
			this.m_SeqFrames = geEffectProxy.m_SeqFrames;
			this.m_ParticleEmitter = geEffectProxy.m_ParticleEmitter;
			this.m_ParticleAnimator = geEffectProxy.m_ParticleAnimator;
			this.m_Animators = geEffectProxy.m_Animators;
			this.defaultTimeLen = geEffectProxy.defaultTimeLen;
			this.m_LockLoop = geEffectProxy.m_LockLoop;
			if (!GeUtility.CheckArrayItems<Animation>(this.m_Animations))
			{
				Logger.LogErrorFormat("Effect {0} m_Animations Contain empty item,Pls Check!", new object[]
				{
					strResName
				});
			}
			if (!GeUtility.CheckArrayItems<ParticleSystem>(this.m_ParticleSys))
			{
				Logger.LogErrorFormat("Effect {0} m_ParticleSys Contain empty item,Pls Check!", new object[]
				{
					strResName
				});
			}
			if (!GeUtility.CheckArrayItems<TrailRenderer>(this.m_Trails))
			{
				Logger.LogErrorFormat("Effect {0} m_Trails Contain empty item,Pls Check!", new object[]
				{
					strResName
				});
			}
			if (!GeUtility.CheckArrayItems<FrameMaterials>(this.m_SeqFrames))
			{
				Logger.LogErrorFormat("Effect {0} m_SeqFrames Contain empty item,Pls Check!", new object[]
				{
					strResName
				});
			}
			if (!GeUtility.CheckArrayItems<ParticleEmitter>(this.m_ParticleEmitter))
			{
				Logger.LogErrorFormat("Effect {0} m_ParticleEmitter Contain empty item,Pls Check!", new object[]
				{
					strResName
				});
			}
			if (!GeUtility.CheckArrayItems<ParticleAnimator>(this.m_ParticleAnimator))
			{
				Logger.LogErrorFormat("Effect {0} m_ParticleAnimator Contain empty item,Pls Check!", new object[]
				{
					strResName
				});
			}
			if (!GeUtility.CheckArrayItems<Animator>(this.m_Animators))
			{
				Logger.LogErrorFormat("Effect {0} m_Animators Contain empty item,Pls Check!", new object[]
				{
					strResName
				});
			}
			if (this.m_ParticleSys == null)
			{
				Logger.LogErrorFormat("GeEffect is null path {0}", new object[]
				{
					strResName
				});
			}
			else
			{
				this.m_ParticleOrient.Resize(this.m_ParticleSys.Length);
				for (int k = 0; k < this.m_ParticleSys.Length; k++)
				{
					if (this.m_ParticleSys[k] == null)
					{
						Logger.LogErrorFormat("GeEffect m_ParticleSys is null path {0} index {1} ", new object[]
						{
							strResName,
							k
						});
					}
					else if (this.m_ParticleSys[k].transform == null)
					{
						Logger.LogErrorFormat("GeEffect m_ParticleSys transform is null path {0} index {1} ", new object[]
						{
							strResName,
							k
						});
					}
					else
					{
						this.m_ParticleOrient[k] = this.m_ParticleSys[k].transform.localEulerAngles;
					}
				}
			}
			this.m_EffectSpace.m_RootNode = new GameObject(this.m_EffectSpace.m_GameObject.name + "_EffRoot");
			if (this.m_EffectSpace.m_RootNode)
			{
				this.m_EffectSpace.m_RootNode.tag = "EffectModel";
				if (!this.m_EffectSpace.m_ParentNode)
				{
					this.m_EffectSpace.m_RootNode.transform.position = initPos;
				}
				else
				{
					this.m_EffectSpace.m_RootNode.transform.SetParent(this.m_EffectSpace.m_ParentNode.transform, false);
				}
				this.m_EffectSpace.m_EffectNode = new GameObject(this.m_EffectSpace.m_GameObject.name + "_TMNode");
				if (this.m_EffectSpace.m_EffectNode)
				{
					this.m_EffectSpace.m_EffectNode.transform.SetParent(this.m_EffectSpace.m_RootNode.transform, false);
					this.m_EffectSpace.m_GameObject.transform.SetParent(this.m_EffectSpace.m_EffectNode.transform, false);
					if (this.m_EffectSpace.m_EffectNode.transform.localScale != this.m_EffectFrame.localScale)
					{
						this._ScaleEffect(this.m_EffectFrame.localScale.x);
						this.scaled = true;
						this.scaledValue = this.m_EffectFrame.localScale.x;
					}
					this.m_EffectSpace.m_EffectNode.transform.localRotation = this.m_EffectFrame.localRotation;
					this.m_EffectSpace.m_EffectNode.transform.localScale = this.m_EffectFrame.localScale;
					this.m_EffectSpace.m_EffectNode.transform.localPosition = this.m_EffectFrame.localPosition;
					if (time > 0f)
					{
						this.m_TimeLenMS = (uint)(time * 1000f);
					}
					else
					{
						this.m_TimeLenMS = (uint)(this.defaultTimeLen * 1000f);
					}
					if (this.m_TimeLenMS <= 0U && this.m_EffectFrame != null && this.m_EffectFrame.time > 0f)
					{
						this.m_TimeLenMS = (uint)(this.m_EffectFrame.time * 1000f);
					}
					this.m_StateEnd = false;
					this.m_StatePause = true;
					this.m_StateRemoved = false;
					this._SetFacing(bFaceLeft);
					MeshRenderer[] meshRenderer = geEffectProxy.m_MeshRenderer;
					if (meshRenderer != null)
					{
						int l = 0;
						int num = meshRenderer.Length;
						while (l < num)
						{
							if (null != meshRenderer[l])
							{
								meshRenderer[l].gameObject.tag = "EffectModel";
							}
							l++;
						}
					}
					Singleton<GeMeshRenderManager>.instance.AddMeshObject(this.m_EffectSpace.m_EffectNode);
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060089B1 RID: 35249 RVA: 0x0018F1E0 File Offset: 0x0018D5E0
	public bool OnReuse(EffectsFrames info, float time, Vector3 initPos, bool bFaceLeft, GameObject parentObj = null, bool useCube = false)
	{
		try
		{
			if (this.useCube && useCube)
			{
				return true;
			}
			this.useCube = useCube;
			if (this.useCube)
			{
				return false;
			}
			this.Reset();
			this.m_EffectFrame = info;
			if (this.m_EffectFrame != null)
			{
				this.m_TimeType = this.m_EffectFrame.timetype;
			}
			this.m_EffectSpace.m_ParentNode = parentObj;
			if (this.m_EffectSpace.m_RootNode != null)
			{
				if (!this.m_EffectSpace.m_ParentNode)
				{
					this.m_EffectSpace.m_RootNode.transform.position = initPos;
				}
				else
				{
					this.m_EffectSpace.m_RootNode.transform.SetParent(this.m_EffectSpace.m_ParentNode.transform, false);
				}
			}
			if (this.m_EffectSpace.m_EffectNode != null && this.m_EffectSpace.m_GameObject != null)
			{
				this.m_EffectSpace.m_EffectNode.transform.SetParent(this.m_EffectSpace.m_RootNode.transform, false);
				this.m_EffectSpace.m_GameObject.transform.SetParent(this.m_EffectSpace.m_EffectNode.transform, false);
				if (this.m_EffectSpace.m_EffectNode.transform.localScale != this.m_EffectFrame.localScale)
				{
					this._ScaleEffect(this.m_EffectFrame.localScale.x);
					this.scaled = true;
					this.scaledValue = this.m_EffectFrame.localScale.x;
				}
				this.m_EffectSpace.m_EffectNode.transform.localRotation = this.m_EffectFrame.localRotation;
				this.m_EffectSpace.m_EffectNode.transform.localScale = this.m_EffectFrame.localScale;
				this.m_EffectSpace.m_EffectNode.transform.localPosition = this.m_EffectFrame.localPosition;
				if (time > 0f)
				{
					this.m_TimeLenMS = (uint)(time * 1000f);
				}
				else
				{
					this.m_TimeLenMS = (uint)(this.defaultTimeLen * 1000f);
				}
				if (this.m_TimeLenMS <= 0U && this.m_EffectFrame != null && this.m_EffectFrame.time > 0f)
				{
					this.m_TimeLenMS = (uint)(this.m_EffectFrame.time * 1000f);
				}
				this.m_StateEnd = false;
				this.m_StatePause = true;
				this.m_StateRemoved = false;
				this._SetFacing(bFaceLeft);
				Singleton<GeMeshRenderManager>.instance.AddMeshObject(this.m_EffectSpace.m_EffectNode);
			}
		}
		catch (Exception ex)
		{
			return false;
		}
		return true;
	}

	// Token: 0x060089B2 RID: 35250 RVA: 0x0018F4CC File Offset: 0x0018D8CC
	public void OnRecycle()
	{
		this.touchGround = false;
		if (this.m_EffectSpace.m_RootNode != null && this.m_EffectSpace.m_EffectNode != null && null != this.m_EffectSpace.m_GameObject)
		{
			this.Resume();
			this._Stop();
			if (this.scaled)
			{
				this.scaled = false;
				this._ScaleEffect(1f / this.scaledValue);
			}
			this._SetFacing(this.m_EffectSpace.m_bFaceLeft);
			for (int i = 0; i < this.m_ParticleSys.Length; i++)
			{
				if (this.m_ParticleSys[i] != null)
				{
					this.m_ParticleSys[i].transform.localEulerAngles = this.m_ParticleOrient[i];
				}
			}
		}
	}

	// Token: 0x060089B3 RID: 35251 RVA: 0x0018F5B0 File Offset: 0x0018D9B0
	public void Deinit()
	{
		this.OnRecycle();
		if (null != this.m_EffectSpace.m_GameObject)
		{
			this.m_EffectSpace.m_GameObject.transform.SetParent(null, false);
			Singleton<CGameObjectPool>.instance.RecycleGameObject(this.m_EffectSpace.m_GameObject);
			this.m_EffectSpace.m_GameObject = null;
		}
		if (null != this.m_EffectSpace.m_EffectNode)
		{
			Object.Destroy(this.m_EffectSpace.m_EffectNode);
			this.m_EffectSpace.m_EffectNode = null;
		}
		if (null != this.m_EffectSpace.m_RootNode)
		{
			Object.Destroy(this.m_EffectSpace.m_RootNode);
			this.m_EffectSpace.m_RootNode = null;
		}
		this.m_EffectSpace.m_ParentNode = null;
	}

	// Token: 0x060089B4 RID: 35252 RVA: 0x0018F684 File Offset: 0x0018DA84
	public void Play(bool bIsLoop)
	{
		if (this.m_EffectSpace.m_GameObject == null)
		{
			return;
		}
		this.m_IsLoop = bIsLoop;
		this.m_StateEnd = false;
		this.m_StatePause = false;
		if (null != this.m_AudioProxy)
		{
			this.m_AudioProxy.TriggerAudio(EffectAudioProxy.AudioTigger.OnPlay, -1);
		}
		if (this.m_ParticleSys != null)
		{
			for (int i = 0; i < this.m_ParticleSys.Length; i++)
			{
				ParticleSystem particleSystem = this.m_ParticleSys[i];
				if (particleSystem)
				{
					if (!this.m_LockLoop)
					{
						particleSystem.loop = bIsLoop;
					}
					particleSystem.Clear();
					particleSystem.Play();
				}
			}
		}
		if (this.m_Animations != null)
		{
			for (int j = 0; j < this.m_Animations.Length; j++)
			{
				Animation animation = this.m_Animations[j];
				if (animation)
				{
					if (!this.m_LockLoop)
					{
						animation.wrapMode = ((!bIsLoop) ? 1 : 2);
					}
					animation.Stop();
					animation.Rewind();
					animation.Play();
				}
			}
		}
		if (this.m_Animators != null)
		{
			for (int k = 0; k < this.m_Animators.Length; k++)
			{
				Animator animator = this.m_Animators[k];
				if (animator != null)
				{
					if (!(animator.runtimeAnimatorController == null))
					{
						AnimationClip[] animationClips = animator.runtimeAnimatorController.animationClips;
						if (!this.m_LockLoop)
						{
							for (int l = 0; l < animationClips.Length; l++)
							{
								animationClips[l].wrapMode = ((!bIsLoop) ? 1 : 2);
							}
						}
						int fullPathHash = animator.GetCurrentAnimatorStateInfo(0).fullPathHash;
						animator.Play(fullPathHash, -1, 0f);
					}
				}
			}
		}
		if (this.m_SeqFrames != null)
		{
			for (int m = 0; m < this.m_SeqFrames.Length; m++)
			{
				FrameMaterials frameMaterials = this.m_SeqFrames[m];
				if (frameMaterials != null)
				{
					frameMaterials.Start();
				}
			}
		}
		if (this.m_SpineAnimations != null)
		{
			for (int n = 0; n < this.m_SpineAnimations.Count; n++)
			{
				this.m_SpineAnimations[n].ReWind();
			}
		}
	}

	// Token: 0x060089B5 RID: 35253 RVA: 0x0018F8EC File Offset: 0x0018DCEC
	public void SetLayer(int layer)
	{
		if (this.GetRootNode() == null)
		{
			return;
		}
		Renderer[] componentsInChildren = this.GetRootNode().GetComponentsInChildren<Renderer>();
		int i = 0;
		int num = componentsInChildren.Length;
		while (i < num)
		{
			if (!(componentsInChildren[i] == null))
			{
				componentsInChildren[i].gameObject.layer = layer;
			}
			i++;
		}
	}

	// Token: 0x060089B6 RID: 35254 RVA: 0x0018F94E File Offset: 0x0018DD4E
	public void SetPosition(Vector3 Pos)
	{
		if (this.m_EffectSpace.m_RootNode != null)
		{
			this.m_EffectSpace.m_RootNode.transform.position = Pos;
		}
	}

	// Token: 0x060089B7 RID: 35255 RVA: 0x0018F97C File Offset: 0x0018DD7C
	public Vector3 GetPosition()
	{
		if (this.m_EffectSpace.m_RootNode != null)
		{
			return this.m_EffectSpace.m_RootNode.transform.position;
		}
		return Vector3.zero;
	}

	// Token: 0x060089B8 RID: 35256 RVA: 0x0018F9AF File Offset: 0x0018DDAF
	public void SetLocalPosition(Vector3 pos)
	{
		if (this.m_EffectSpace != null && this.m_EffectSpace.m_RootNode != null)
		{
			this.m_EffectSpace.m_RootNode.transform.localPosition = pos;
		}
	}

	// Token: 0x060089B9 RID: 35257 RVA: 0x0018F9E8 File Offset: 0x0018DDE8
	public void SetLocalRotation(Quaternion rotation)
	{
		if (this.m_EffectSpace != null && this.m_EffectSpace.m_RootNode != null)
		{
			this.m_EffectSpace.m_RootNode.transform.localRotation = rotation;
		}
	}

	// Token: 0x060089BA RID: 35258 RVA: 0x0018FA21 File Offset: 0x0018DE21
	public Vector3 GetLocalPosition()
	{
		if (this.m_EffectSpace != null && this.m_EffectSpace.m_RootNode != null)
		{
			return this.m_EffectSpace.m_RootNode.transform.localPosition;
		}
		return Vector3.zero;
	}

	// Token: 0x060089BB RID: 35259 RVA: 0x0018FA60 File Offset: 0x0018DE60
	public void SetSpeed(float speed)
	{
		this.m_PlaySpeed = speed;
		if (this.m_ParticleSys != null)
		{
			for (int i = 0; i < this.m_ParticleSys.Length; i++)
			{
				ParticleSystem particleSystem = this.m_ParticleSys[i];
				if (!(particleSystem == null))
				{
					particleSystem.playbackSpeed = speed;
				}
			}
		}
		if (this.m_Animations != null)
		{
			for (int j = 0; j < this.m_Animations.Length; j++)
			{
				Animation animation = this.m_Animations[j];
				if (!(animation == null))
				{
					IEnumerator enumerator = animation.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							AnimationState animationState = (AnimationState)obj;
							if (animationState != null)
							{
								animationState.speed = speed;
							}
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
		}
		if (this.m_Animators != null)
		{
			for (int k = 0; k < this.m_Animators.Length; k++)
			{
				if (this.m_Animators[k] != null)
				{
					this.m_Animators[k].speed = speed;
				}
			}
		}
	}

	// Token: 0x060089BC RID: 35260 RVA: 0x0018FBB0 File Offset: 0x0018DFB0
	protected void _SetFacing(bool faceLeft)
	{
		this.m_EffectSpace.m_bFaceLeft = faceLeft;
		if (null == this.m_EffectSpace.m_ParentNode)
		{
			Vector3 localScale = this.m_EffectSpace.m_RootNode.transform.localScale;
			localScale.x = ((!faceLeft) ? localScale.x : (-localScale.x));
			this.m_EffectSpace.m_RootNode.transform.localScale = localScale;
		}
	}

	// Token: 0x060089BD RID: 35261 RVA: 0x0018FC2C File Offset: 0x0018E02C
	public void Pause()
	{
		if (this.m_StatePause)
		{
			return;
		}
		if (null == this.m_EffectSpace.m_GameObject)
		{
			return;
		}
		if (this.m_Animators != null)
		{
			this.m_AnimatorSpeed.Resize(this.m_Animators.Length);
			for (int i = 0; i < this.m_Animators.Length; i++)
			{
				Animator animator = this.m_Animators[i];
				this.m_AnimatorSpeed[i] = 0f;
				if (animator != null)
				{
					this.m_AnimatorSpeed[i] = animator.speed;
					animator.speed = 0f;
				}
			}
		}
		if (this.m_Animations != null)
		{
			for (int j = 0; j < this.m_Animations.Length; j++)
			{
				Animation animation = this.m_Animations[j];
				if (!(animation == null))
				{
					IEnumerator enumerator = animation.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							AnimationState animationState = (AnimationState)obj;
							animationState.speed = 0f;
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
		}
		if (this.m_ParticleSys != null)
		{
			for (int k = 0; k < this.m_ParticleSys.Length; k++)
			{
				if (!(this.m_ParticleSys[k] == null))
				{
					this.m_ParticleSys[k].Pause();
				}
			}
		}
		this.m_StatePause = true;
	}

	// Token: 0x060089BE RID: 35262 RVA: 0x0018FDCC File Offset: 0x0018E1CC
	public void Resume()
	{
		if (!this.m_StatePause)
		{
			return;
		}
		if (null == this.m_EffectSpace.m_GameObject)
		{
			return;
		}
		if (this.m_Animators != null)
		{
			this.m_AnimatorSpeed.Resize(this.m_Animators.Length);
			for (int i = 0; i < this.m_Animators.Length; i++)
			{
				Animator animator = this.m_Animators[i];
				if (animator != null)
				{
					animator.speed = this.m_AnimatorSpeed[i];
				}
			}
		}
		if (this.m_Animations != null)
		{
			for (int j = 0; j < this.m_Animations.Length; j++)
			{
				Animation animation = this.m_Animations[j];
				if (!(null == animation))
				{
					IEnumerator enumerator = animation.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							AnimationState animationState = (AnimationState)obj;
							animationState.speed = this.m_PlaySpeed;
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
		}
		if (this.m_ParticleSys != null)
		{
			for (int k = 0; k < this.m_ParticleSys.Length; k++)
			{
				if (!(this.m_ParticleSys[k] == null))
				{
					this.m_ParticleSys[k].Play();
				}
			}
		}
		this.m_StatePause = false;
	}

	// Token: 0x060089BF RID: 35263 RVA: 0x0018FF50 File Offset: 0x0018E350
	public void Update(int delta)
	{
		this.m_ElapsedTimeMS += (uint)((float)delta * this.m_PlaySpeed);
		if (this.m_ElapsedTimeMS > this.m_TimeLenMS)
		{
			this.m_StateEnd = true;
		}
	}

	// Token: 0x060089C0 RID: 35264 RVA: 0x0018FF81 File Offset: 0x0018E381
	public string GetEffectName()
	{
		return this.m_Name;
	}

	// Token: 0x060089C1 RID: 35265 RVA: 0x0018FF89 File Offset: 0x0018E389
	public EffectTimeType GetTimeType()
	{
		return this.m_TimeType;
	}

	// Token: 0x060089C2 RID: 35266 RVA: 0x0018FF91 File Offset: 0x0018E391
	public float GetTimeLen()
	{
		return this.m_TimeLenMS;
	}

	// Token: 0x060089C3 RID: 35267 RVA: 0x0018FF9B File Offset: 0x0018E39B
	public void SetTimeLen(int d)
	{
		this.m_TimeLenMS = (uint)d;
	}

	// Token: 0x060089C4 RID: 35268 RVA: 0x0018FFA4 File Offset: 0x0018E3A4
	public void ResetElapsedTime()
	{
		this.m_ElapsedTimeMS = 0U;
	}

	// Token: 0x060089C5 RID: 35269 RVA: 0x0018FFAD File Offset: 0x0018E3AD
	public void SetTouchGround(bool flag)
	{
		this.touchGround = flag;
	}

	// Token: 0x060089C6 RID: 35270 RVA: 0x0018FFB6 File Offset: 0x0018E3B6
	public bool IsAlwaysTouchGround()
	{
		return this.touchGround;
	}

	// Token: 0x060089C7 RID: 35271 RVA: 0x0018FFC0 File Offset: 0x0018E3C0
	private float _getDefaultTimeLen()
	{
		float num = GeEffectProxy.GetDefaultTimeLen(this.m_ParticleSys, this.m_Animations, this.m_SeqFrames, this.m_Animators);
		return (num <= 0f) ? this.defaultTimeLen : num;
	}

	// Token: 0x060089C8 RID: 35272 RVA: 0x00190008 File Offset: 0x0018E408
	public bool IsDead()
	{
		return this.m_StateEnd || this.m_StateRemoved;
	}

	// Token: 0x060089C9 RID: 35273 RVA: 0x0019001E File Offset: 0x0018E41E
	public void Remove()
	{
		this.m_StateRemoved = true;
	}

	// Token: 0x060089CA RID: 35274 RVA: 0x00190028 File Offset: 0x0018E428
	public void SetScale(float scale)
	{
		this.scaled = true;
		this.scaledValue = scale;
		this._ScaleEffect(scale);
		Vector3 localScale;
		localScale..ctor(scale, scale, scale);
		if (this.m_EffectSpace.m_EffectNode != null)
		{
			this.m_EffectSpace.m_EffectNode.transform.localScale = localScale;
		}
		else
		{
			Logger.LogErrorFormat("SetScale effectName {0} invalid", new object[]
			{
				this.m_Name
			});
		}
	}

	// Token: 0x060089CB RID: 35275 RVA: 0x001900A0 File Offset: 0x0018E4A0
	public void SetScale(float sx, float sy, float sz)
	{
		Vector3 localScale;
		localScale..ctor(sx, sy, sz);
		if (this.m_EffectSpace.m_EffectNode != null)
		{
			this.m_EffectSpace.m_EffectNode.transform.localScale = localScale;
		}
		else
		{
			Logger.LogErrorFormat("SetScale effectName {0} invalid", new object[]
			{
				this.m_Name
			});
		}
	}

	// Token: 0x060089CC RID: 35276 RVA: 0x00190104 File Offset: 0x0018E504
	private void _MirrorRotationAxis(GeEffectEx.Axis axis, ref Vector3 eulerAngle)
	{
		if (axis == GeEffectEx.Axis.X)
		{
			eulerAngle.x = 180f - eulerAngle.x;
			return;
		}
		if (axis == GeEffectEx.Axis.Y)
		{
			eulerAngle.y = 180f - eulerAngle.y;
			return;
		}
		if (axis != GeEffectEx.Axis.Z)
		{
			return;
		}
		eulerAngle.z = 180f - eulerAngle.z;
	}

	// Token: 0x060089CD RID: 35277 RVA: 0x00190164 File Offset: 0x0018E564
	private void _Stop()
	{
		if (this.m_Animators != null)
		{
			for (int i = 0; i < this.m_Animators.Length; i++)
			{
				Animator animator = this.m_Animators[i];
				if (animator != null)
				{
					animator.StopPlayback();
				}
			}
		}
	}

	// Token: 0x060089CE RID: 35278 RVA: 0x001901B4 File Offset: 0x0018E5B4
	private void _ScaleEffect(float scale)
	{
		if (this.m_ParticleSys != null)
		{
			for (int i = 0; i < this.m_ParticleSys.Length; i++)
			{
				ParticleSystem particleSystem = this.m_ParticleSys[i];
				if (!(particleSystem == null))
				{
					particleSystem.startSpeed *= scale;
					particleSystem.startSize *= scale;
					particleSystem.gravityModifier *= scale;
				}
			}
		}
		if (this.m_Trails != null)
		{
			for (int j = 0; j < this.m_Trails.Length; j++)
			{
				TrailRenderer trailRenderer = this.m_Trails[j];
				if (!(trailRenderer == null))
				{
					trailRenderer.startWidth *= scale;
					trailRenderer.endWidth *= scale;
				}
			}
		}
		if (this.m_ParticleEmitter != null)
		{
			for (int k = 0; k < this.m_ParticleEmitter.Length; k++)
			{
				ParticleEmitter particleEmitter = this.m_ParticleEmitter[k];
				if (!(particleEmitter == null))
				{
					particleEmitter.minSize *= scale;
					particleEmitter.maxSize *= scale;
					particleEmitter.worldVelocity *= scale;
					particleEmitter.localVelocity *= scale;
					particleEmitter.rndVelocity *= scale;
				}
			}
		}
		if (this.m_ParticleAnimator != null)
		{
			for (int l = 0; l < this.m_ParticleAnimator.Length; l++)
			{
				ParticleAnimator particleAnimator = this.m_ParticleAnimator[l];
				if (!(particleAnimator == null))
				{
					particleAnimator.force *= scale;
					particleAnimator.rndForce *= scale;
				}
			}
		}
	}

	// Token: 0x060089CF RID: 35279 RVA: 0x00190394 File Offset: 0x0018E794
	public GameObject GetRootNode()
	{
		return this.m_EffectSpace.m_RootNode;
	}

	// Token: 0x060089D0 RID: 35280 RVA: 0x001903A1 File Offset: 0x0018E7A1
	public GameObject GetParentNode()
	{
		return this.m_EffectSpace.m_ParentNode;
	}

	// Token: 0x060089D1 RID: 35281 RVA: 0x001903B0 File Offset: 0x0018E7B0
	public void SetParentNode(GameObject newParent)
	{
		if (newParent == null)
		{
			return;
		}
		GameObject parentNode = this.m_EffectSpace.m_ParentNode;
		if (parentNode == null)
		{
			return;
		}
		if (this.m_EffectSpace.m_RootNode != null)
		{
			this.m_EffectSpace.m_RootNode.transform.SetParent(newParent.transform, false);
		}
		this.m_EffectSpace.m_ParentNode = newParent;
	}

	// Token: 0x060089D2 RID: 35282 RVA: 0x00190424 File Offset: 0x0018E824
	public void SetVisible(bool flag)
	{
		if (this.useCube)
		{
			return;
		}
		GameObject rootNode = this.GetRootNode();
		if (rootNode != null)
		{
			rootNode.CustomActive(flag);
		}
	}

	// Token: 0x060089D3 RID: 35283 RVA: 0x00190458 File Offset: 0x0018E858
	public bool isVisible()
	{
		GameObject rootNode = this.GetRootNode();
		return rootNode != null && rootNode.activeSelf;
	}

	// Token: 0x0400431F RID: 17183
	private bool scaled;

	// Token: 0x04004320 RID: 17184
	private float scaledValue;

	// Token: 0x04004321 RID: 17185
	private bool touchGround;

	// Token: 0x04004322 RID: 17186
	private float defaultTimeLen;

	// Token: 0x04004323 RID: 17187
	public bool useCube;

	// Token: 0x04004324 RID: 17188
	public static Dictionary<string, float> defaultTimeMap = new Dictionary<string, float>();

	// Token: 0x04004325 RID: 17189
	protected string m_Name = string.Empty;

	// Token: 0x04004326 RID: 17190
	protected EffectsFrames m_EffectFrame;

	// Token: 0x04004327 RID: 17191
	protected EffectTimeType m_TimeType;

	// Token: 0x04004328 RID: 17192
	protected float m_PlaySpeed = 1f;

	// Token: 0x04004329 RID: 17193
	protected uint m_ElapsedTimeMS;

	// Token: 0x0400432A RID: 17194
	protected uint m_TimeLenMS;

	// Token: 0x0400432B RID: 17195
	protected Animation[] m_Animations;

	// Token: 0x0400432C RID: 17196
	protected ParticleSystem[] m_ParticleSys;

	// Token: 0x0400432D RID: 17197
	protected TrailRenderer[] m_Trails;

	// Token: 0x0400432E RID: 17198
	protected FrameMaterials[] m_SeqFrames;

	// Token: 0x0400432F RID: 17199
	protected ParticleEmitter[] m_ParticleEmitter;

	// Token: 0x04004330 RID: 17200
	protected ParticleAnimator[] m_ParticleAnimator;

	// Token: 0x04004331 RID: 17201
	protected Animator[] m_Animators;

	// Token: 0x04004332 RID: 17202
	protected bool m_LockLoop;

	// Token: 0x04004333 RID: 17203
	protected List<ISkeletonAnimation> m_SpineAnimations;

	// Token: 0x04004334 RID: 17204
	protected LazyArray<float> m_AnimatorSpeed = new LazyArray<float>(4, 0f);

	// Token: 0x04004335 RID: 17205
	protected LazyArray<Vector3> m_ParticleOrient = new LazyArray<Vector3>(4, Vector3.zero);

	// Token: 0x04004336 RID: 17206
	protected bool m_StatePause;

	// Token: 0x04004337 RID: 17207
	protected bool m_StateEnd;

	// Token: 0x04004338 RID: 17208
	protected bool m_StateRemoved;

	// Token: 0x04004339 RID: 17209
	protected bool m_IsLoop;

	// Token: 0x0400433A RID: 17210
	protected GeEffectEx.GeSpaceDesc m_EffectSpace = new GeEffectEx.GeSpaceDesc();

	// Token: 0x0400433B RID: 17211
	protected EffectAudioProxy m_AudioProxy;

	// Token: 0x02000D2A RID: 3370
	private enum Axis
	{
		// Token: 0x0400433D RID: 17213
		X,
		// Token: 0x0400433E RID: 17214
		Y,
		// Token: 0x0400433F RID: 17215
		Z
	}

	// Token: 0x02000D2B RID: 3371
	protected class GeSpaceDesc
	{
		// Token: 0x04004340 RID: 17216
		public GameObject m_ParentNode;

		// Token: 0x04004341 RID: 17217
		public GameObject m_RootNode;

		// Token: 0x04004342 RID: 17218
		public GameObject m_EffectNode;

		// Token: 0x04004343 RID: 17219
		public GameObject m_GameObject;

		// Token: 0x04004344 RID: 17220
		public Vector3 m_LocalPos = Vector3.zero;

		// Token: 0x04004345 RID: 17221
		public Quaternion m_LocalRot = Quaternion.identity;

		// Token: 0x04004346 RID: 17222
		public Vector3 m_LocalScale = Vector3.one;

		// Token: 0x04004347 RID: 17223
		public bool m_bFaceLeft;
	}
}
