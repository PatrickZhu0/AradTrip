using System;
using System.Collections.Generic;
using Battle;
using UnityEngine;

// Token: 0x02000D1B RID: 3355
public class GeEntity
{
	// Token: 0x06008931 RID: 35121 RVA: 0x00184480 File Offset: 0x00182880
	public virtual bool Init(string entityName, GameObject entityRoot, GeSceneEx scene, bool isBattleActor = false)
	{
		if (null != entityRoot)
		{
			this.m_Scene = scene;
			this.m_EntityName = entityName;
			this.m_EntitySpaceDesc.m_IsEntityHide = false;
			if (null == this.m_EntitySpaceDesc.rootNode)
			{
				this.m_EntitySpaceDesc.rootNode = new GameObject("root");
			}
			GeUtility.AttachTo(this.m_EntitySpaceDesc.rootNode, entityRoot, false);
			if (null == this.m_EntitySpaceDesc.transformNode)
			{
				this.m_EntitySpaceDesc.transformNode = new GameObject("Transform");
			}
			if (null == this.m_EntitySpaceDesc.characterNode)
			{
				this.m_EntitySpaceDesc.characterNode = new GameObject("character");
			}
			if (null != this.m_EntitySpaceDesc.transformNode && null != this.m_EntitySpaceDesc.rootNode)
			{
				this.m_EntitySpaceDesc.transformNode.transform.SetParent(this.m_EntitySpaceDesc.rootNode.transform);
			}
			if (null != this.m_EntitySpaceDesc.characterNode && null != this.m_EntitySpaceDesc.transformNode)
			{
				this.m_EntitySpaceDesc.characterNode.transform.SetParent(this.m_EntitySpaceDesc.transformNode.transform);
			}
			if (isBattleActor)
			{
				this.m_SnapEffect.Init();
			}
			return true;
		}
		Logger.LogError("[GeActor] actorRoot is nil");
		return false;
	}

	// Token: 0x06008932 RID: 35122 RVA: 0x00184608 File Offset: 0x00182A08
	public virtual void Deinit()
	{
		if (this.m_Effect != null)
		{
			this.m_Effect.Deinit();
			this.m_Effect = null;
		}
		if (this.m_Material != null)
		{
			this.m_Material.Deinit();
			this.m_Material = null;
		}
		if (this.cachedAttachs != null)
		{
			this.ClearCached();
		}
		if (null != this.m_EntitySpaceDesc.actorModel)
		{
			if (null == this.m_Avatar.GetAvatarRoot())
			{
				Singleton<CGameObjectPool>.instance.RecycleGameObject(this.m_EntitySpaceDesc.actorModel);
			}
			this.m_EntitySpaceDesc.actorModel = null;
		}
		if (this.m_Avatar != null)
		{
			this.m_Avatar.Deinit();
			this.m_Avatar = null;
		}
		if (this.m_SnapEffect != null)
		{
			this.m_SnapEffect.Deinit();
			this.m_SnapEffect = null;
		}
		if (null != this.m_EntitySpaceDesc.rootNode)
		{
			Object.Destroy(this.m_EntitySpaceDesc.rootNode);
			this.m_EntitySpaceDesc.rootNode = null;
		}
		if (this.m_ModelDataAsset != null)
		{
			this.m_ModelData = null;
			this.m_ModelDataAsset = null;
		}
		this.m_PostLoadCommand.Clear();
		this.m_Scene = null;
		this.hasShadow = false;
		this.shadowScale = Vector3.one;
	}

	// Token: 0x06008933 RID: 35123 RVA: 0x00184756 File Offset: 0x00182B56
	public void DestroySnapEffect()
	{
		if (this.m_SnapEffect != null)
		{
			this.m_SnapEffect.Deinit();
		}
	}

	// Token: 0x06008934 RID: 35124 RVA: 0x0018476E File Offset: 0x00182B6E
	public void PushPostLoadCommand(PostLoadCommand cmdCallback)
	{
		this.m_PostLoadCommand.Add(cmdCallback);
	}

	// Token: 0x06008935 RID: 35125 RVA: 0x0018477C File Offset: 0x00182B7C
	public void ExcutePostLoadCommand()
	{
		int i = 0;
		int count = this.m_PostLoadCommand.Count;
		while (i < count)
		{
			this.m_PostLoadCommand[i]();
			i++;
		}
		this.m_PostLoadCommand.Clear();
	}

	// Token: 0x06008936 RID: 35126 RVA: 0x001847C3 File Offset: 0x00182BC3
	public bool IsAvatarLoadFinished()
	{
		if (this.m_Avatar != null)
		{
			this.m_Avatar.UpdateAsyncLoading();
			return this.m_Avatar.IsLoadFinished();
		}
		return true;
	}

	// Token: 0x06008937 RID: 35127 RVA: 0x001847E8 File Offset: 0x00182BE8
	public void Pause(int Mask = 63, bool hitEffectPause = true)
	{
		if ((Mask & 4) != 0 && hitEffectPause)
		{
			this.m_Effect.Pause(GeEffectType.EffectUnique);
		}
		if ((Mask & 8) != 0 && hitEffectPause)
		{
			this.m_Effect.Pause(GeEffectType.EffectMultiple);
		}
		if ((Mask & 2) != 0)
		{
			this.m_Material.Pause();
		}
		uint num = 0U;
		if ((1 & Mask) != 0)
		{
			num |= 1U;
		}
		if ((16 & Mask) != 0)
		{
			num |= 2U;
		}
		this.m_Avatar.Pause(num);
	}

	// Token: 0x06008938 RID: 35128 RVA: 0x00184864 File Offset: 0x00182C64
	public void Resume(int Mask = 63)
	{
		if ((Mask & 4) != 0)
		{
			this.m_Effect.Resume(GeEffectType.EffectUnique);
		}
		if ((Mask & 8) != 0)
		{
			this.m_Effect.Resume(GeEffectType.EffectMultiple);
		}
		if ((Mask & 2) != 0)
		{
			this.m_Material.Resume();
		}
		uint num = 0U;
		if ((1 & Mask) != 0)
		{
			num |= 1U;
		}
		if ((16 & Mask) != 0)
		{
			num |= 2U;
		}
		this.m_Avatar.Resume(num);
	}

	// Token: 0x06008939 RID: 35129 RVA: 0x001848D4 File Offset: 0x00182CD4
	public virtual void Update(int deltaTime, int Mask = 63, float height = 0f, int accTime = 0)
	{
		if (this.m_Avatar != null)
		{
			if (this.m_Avatar.IsLoadFinished())
			{
				if (this.m_PostLoadCommand.Count > 0)
				{
					this.ExcutePostLoadCommand();
				}
				if (this.m_IsAvatarDirty)
				{
					this.m_Avatar.SetAvatarVisible(true);
					this.m_IsAvatarDirty = false;
				}
				uint num = 0U;
				if ((1 & Mask) != 0)
				{
					num |= 1U;
				}
				if ((16 & Mask) != 0)
				{
					num |= 2U;
				}
				this.m_Avatar.Update(deltaTime, num);
			}
			else
			{
				this.m_Avatar.UpdateAsyncLoading();
			}
		}
		if (this.m_ModelManager != null)
		{
			this.m_ModelManager.Update();
		}
		if (this.m_Effect != null)
		{
			this.m_Effect.UpdateTouchGround(height, 99);
			int deltaTime2 = (accTime != 0) ? accTime : deltaTime;
			if ((Mask & 4) != 0)
			{
				this.m_Effect.Update(deltaTime2, GeEffectType.EffectUnique);
			}
			if ((Mask & 8) != 0)
			{
				this.m_Effect.Update(deltaTime2, GeEffectType.EffectMultiple);
			}
			if ((Mask & 32) != 0)
			{
				this.m_Effect.Update(deltaTime2, GeEffectType.EffectGlobal);
			}
		}
		if (this.m_Material != null && (Mask & 2) != 0)
		{
			this.m_Material.Update(deltaTime, this.m_EntitySpaceDesc.actorNode);
		}
		if (this.m_SnapEffect != null)
		{
			this.m_SnapEffect.Update(deltaTime, this.m_EntitySpaceDesc.actorNode);
		}
	}

	// Token: 0x0600893A RID: 35130 RVA: 0x00184A34 File Offset: 0x00182E34
	public void AddSimpleShadow(Vector3 scale)
	{
		this.shadowScale = scale;
		this.hasShadow = true;
		this.PushPostLoadCommand(delegate
		{
			this._AddShadow();
		});
	}

	// Token: 0x0600893B RID: 35131 RVA: 0x00184A58 File Offset: 0x00182E58
	public void UpdateAttach()
	{
		if (this.m_Avatar != null)
		{
			if (this.m_Avatar.IsLoadFinished())
			{
				if (this.m_PostLoadCommand.Count > 0)
				{
					this.ExcutePostLoadCommand();
				}
				if (this.m_IsAvatarDirty)
				{
					this.m_Avatar.SetAvatarVisible(true);
					this.m_IsAvatarDirty = false;
				}
			}
			else
			{
				this.m_Avatar.UpdateAsyncLoading();
			}
		}
		if (this.m_SnapEffect != null)
		{
			this.m_SnapEffect.Update(0, this.m_EntitySpaceDesc.actorNode);
		}
		this.m_Avatar.Update(0, 2U);
	}

	// Token: 0x0600893C RID: 35132 RVA: 0x00184AF4 File Offset: 0x00182EF4
	public void Clear(int Mask = 63)
	{
		if ((Mask & 4) != 0)
		{
			this.m_Effect.ClearAll(GeEffectType.EffectUnique);
		}
		if ((Mask & 8) != 0)
		{
			this.m_Effect.ClearAll(GeEffectType.EffectMultiple);
		}
		if ((Mask & 32) != 0)
		{
			this.m_Effect.ClearAll(GeEffectType.EffectGlobal);
		}
		if ((Mask & 2) != 0)
		{
			this.m_Material.ClearAll();
		}
		uint num = 0U;
		if ((1 & Mask) != 0)
		{
			num |= 1U;
		}
		if ((16 & Mask) != 0)
		{
			num |= 2U;
		}
		this.m_Avatar.Clear(num);
	}

	// Token: 0x0600893D RID: 35133 RVA: 0x00184B78 File Offset: 0x00182F78
	public void Remove()
	{
		this.m_IsRemoved = true;
	}

	// Token: 0x0600893E RID: 35134 RVA: 0x00184B81 File Offset: 0x00182F81
	public bool CanRemove()
	{
		return this.m_IsRemoved;
	}

	// Token: 0x0600893F RID: 35135 RVA: 0x00184B89 File Offset: 0x00182F89
	public void SetPosition(Vector3 pos)
	{
		this.m_EntitySpaceDesc.position = pos;
		if (this.m_EntitySpaceDesc.rootNode != null)
		{
			this.m_EntitySpaceDesc.rootNode.transform.localPosition = pos;
		}
	}

	// Token: 0x06008940 RID: 35136 RVA: 0x00184BC3 File Offset: 0x00182FC3
	public void SetScale(float scale)
	{
		this.m_EntitySpaceDesc.scale = scale;
		this.SetScaleV3(scale * Vector3.one);
	}

	// Token: 0x06008941 RID: 35137 RVA: 0x00184BE2 File Offset: 0x00182FE2
	public void SetActorPosition(Vector3 pos)
	{
		if (this.m_EntitySpaceDesc.actorNode == null)
		{
			return;
		}
		this.m_EntitySpaceDesc.actorNode.transform.localPosition = pos;
	}

	// Token: 0x06008942 RID: 35138 RVA: 0x00184C11 File Offset: 0x00183011
	public Vector3 GetActorNodeScale()
	{
		if (this.m_EntitySpaceDesc.actorNode == null)
		{
			return Vector3.one;
		}
		return this.m_EntitySpaceDesc.actorNode.transform.localScale;
	}

	// Token: 0x06008943 RID: 35139 RVA: 0x00184C44 File Offset: 0x00183044
	public void SetActorNodeScale(Vector3 scale)
	{
		if (this.m_EntitySpaceDesc.actorNode == null)
		{
			return;
		}
		this.m_EntitySpaceDesc.actorNode.transform.localScale = scale;
	}

	// Token: 0x06008944 RID: 35140 RVA: 0x00184C73 File Offset: 0x00183073
	public void SetActorNodeScale(float scale)
	{
		this.m_EntitySpaceDesc.actorNode.transform.localScale = scale * Vector3.one;
	}

	// Token: 0x06008945 RID: 35141 RVA: 0x00184C95 File Offset: 0x00183095
	public void ResetActorNodeScale()
	{
		this.m_EntitySpaceDesc.actorNode.transform.localScale = Vector3.one;
	}

	// Token: 0x06008946 RID: 35142 RVA: 0x00184CB4 File Offset: 0x001830B4
	public void SetScaleV3(Vector3 scale)
	{
		this.m_EntitySpaceDesc.localScale = scale;
		if (this.m_EntitySpaceDesc.rootNode != null)
		{
			this.m_EntitySpaceDesc.transformNode.transform.localScale = this.m_EntitySpaceDesc.localScale;
		}
	}

	// Token: 0x06008947 RID: 35143 RVA: 0x00184D04 File Offset: 0x00183104
	public void SetRotation(Quaternion rotation)
	{
		this.m_EntitySpaceDesc.rotation = rotation;
		if (this.m_EntitySpaceDesc.rootNode != null)
		{
			this.m_EntitySpaceDesc.transformNode.transform.localRotation = this.m_EntitySpaceDesc.rotation;
		}
	}

	// Token: 0x06008948 RID: 35144 RVA: 0x00184D53 File Offset: 0x00183153
	public Quaternion GetRotation()
	{
		return this.m_EntitySpaceDesc.rotation;
	}

	// Token: 0x06008949 RID: 35145 RVA: 0x00184D60 File Offset: 0x00183160
	public float GetScale()
	{
		return this.m_EntitySpaceDesc.scale;
	}

	// Token: 0x0600894A RID: 35146 RVA: 0x00184D6D File Offset: 0x0018316D
	public Vector3 GetPosition()
	{
		return this.m_EntitySpaceDesc.position;
	}

	// Token: 0x0600894B RID: 35147 RVA: 0x00184D7A File Offset: 0x0018317A
	public bool IsFaceLeft()
	{
		return this.m_EntitySpaceDesc.faceLeft;
	}

	// Token: 0x0600894C RID: 35148 RVA: 0x00184D88 File Offset: 0x00183188
	public void SetFaceLeft(bool bFaceLeft)
	{
		this.m_EntitySpaceDesc.faceLeft = bFaceLeft;
		if (this.m_EntitySpaceDesc.characterNode)
		{
			Vector3 localScale = this.m_EntitySpaceDesc.characterNode.transform.localScale;
			if (this.m_EntitySpaceDesc.faceLeft)
			{
				localScale.x = -Mathf.Abs(localScale.x);
			}
			else
			{
				localScale.x = Mathf.Abs(localScale.x);
			}
			this.m_EntitySpaceDesc.characterNode.transform.localScale = localScale;
		}
	}

	// Token: 0x0600894D RID: 35149 RVA: 0x00184E1E File Offset: 0x0018321E
	public GeEffectEx FindEffect(string effectPath)
	{
		return this.m_Effect.GetEffectByName(effectPath);
	}

	// Token: 0x0600894E RID: 35150 RVA: 0x00184E2C File Offset: 0x0018322C
	public GeEffectEx CreateEffect(string effectPath, string locator, float fTime, Vec3 initPos, float initScale = 1f, float fSpeed = 1f, bool isLoop = false, bool faceLeft = false, EffectTimeType timeType = EffectTimeType.SYNC_ANIMATION, bool forceDisplay = false)
	{
		EffectsFrames effectsFrames = new EffectsFrames();
		effectsFrames.localPosition = new Vector3(0f, 0f, 0f);
		effectsFrames.attachname = locator;
		effectsFrames.timetype = timeType;
		DAssetObject effectRes;
		effectRes.m_AssetObj = null;
		effectRes.m_AssetPath = effectPath;
		return this.CreateEffect(effectRes, effectsFrames, fTime, initPos, initScale, fSpeed, isLoop, faceLeft, forceDisplay);
	}

	// Token: 0x0600894F RID: 35151 RVA: 0x00184E90 File Offset: 0x00183290
	public GeEffectEx CreateEffect(DAssetObject effectRes, EffectsFrames info, float fTime, Vec3 initPos, float initScale = 1f, float fSpeed = 1f, bool isLoop = false, bool bIgnoreFacing = false, bool forceDisplay = false)
	{
		string text = info.attachname;
		bool touchGround = false;
		if (text != null && text == "[actor]OrignTouchGround")
		{
			touchGround = true;
			text = "[actor]Orign";
		}
		if (text == null || string.Empty == text)
		{
			text = "None";
		}
		GameObject attachNode = this.m_Avatar.GetAttachNode(text);
		if (null != effectRes.m_AssetObj || (effectRes.m_AssetPath != null && string.Empty != effectRes.m_AssetPath))
		{
			Vector3 pos;
			pos..ctor(initPos.x, initPos.z, initPos.y);
			GeEffectEx geEffectEx = this.m_Effect.AddEffect(effectRes, info, fTime, pos, attachNode, !bIgnoreFacing && this.m_EntitySpaceDesc.faceLeft, forceDisplay);
			if (geEffectEx != null)
			{
				bool flag = false;
				if (info.timetype == EffectTimeType.GLOBAL_ANIMATION)
				{
					flag = true;
				}
				else if (geEffectEx.GetDefaultTimeLen() < fTime)
				{
					flag = true;
				}
				geEffectEx.SetSpeed(fSpeed);
				geEffectEx.Play(flag || isLoop);
				geEffectEx.SetTouchGround(touchGround);
				return geEffectEx;
			}
		}
		return null;
	}

	// Token: 0x06008950 RID: 35152 RVA: 0x00184FC4 File Offset: 0x001833C4
	public string GetAttachNodeName(string attachNode, out bool isTouchGround)
	{
		isTouchGround = false;
		if (attachNode != null && attachNode == "[actor]OrignTouchGround")
		{
			isTouchGround = true;
			attachNode = "[actor]Orign";
		}
		if (attachNode == null || string.Empty == attachNode)
		{
			attachNode = "None";
		}
		return attachNode;
	}

	// Token: 0x06008951 RID: 35153 RVA: 0x00185014 File Offset: 0x00183414
	public void DestroyEffect(GeEffectEx effect)
	{
		GeEffectType effectType = GeEffectType.EffectMultiple;
		if (effect.GetTimeType() == EffectTimeType.GLOBAL_ANIMATION)
		{
			effectType = GeEffectType.EffectUnique;
		}
		else if (effect.GetTimeType() == EffectTimeType.BUFF)
		{
			effectType = GeEffectType.EffectGlobal;
		}
		this.m_Effect.RemoveEffect(effect, effectType);
	}

	// Token: 0x06008952 RID: 35154 RVA: 0x00185051 File Offset: 0x00183451
	public GeAttach GetAttachment(string name)
	{
		return this.m_Avatar.GetAttachment(name);
	}

	// Token: 0x06008953 RID: 35155 RVA: 0x0018505F File Offset: 0x0018345F
	public GameObject GetAttachNode(string name)
	{
		if (this.m_Avatar != null)
		{
			return this.m_Avatar.GetAttachNode(name);
		}
		return null;
	}

	// Token: 0x06008954 RID: 35156 RVA: 0x0018507C File Offset: 0x0018347C
	public void SetAttachmentVisible(string name, bool flag)
	{
		GeAttach attachment = this.GetAttachment(name);
		if (attachment != null)
		{
			attachment.SetVisible(flag);
		}
	}

	// Token: 0x06008955 RID: 35157 RVA: 0x001850A0 File Offset: 0x001834A0
	public void PlayAttachmentAnimation(string name, string aniName)
	{
		GeAttach attachment = this.GetAttachment(name);
		if (attachment != null)
		{
		}
	}

	// Token: 0x06008956 RID: 35158 RVA: 0x001850BC File Offset: 0x001834BC
	public GeAttach GetAttachFromCached(string attachRes, string attachNode)
	{
		for (int i = 0; i < this.cachedAttachs.Count; i++)
		{
			GeAttach geAttach = this.cachedAttachs[i];
			if (geAttach != null && geAttach.ResPath.Equals(attachRes) && geAttach.AttachNodeName.Equals(attachNode))
			{
				geAttach.Root.SetActive(true);
				this.cachedAttachs.Remove(geAttach);
				return geAttach;
			}
		}
		return null;
	}

	// Token: 0x06008957 RID: 35159 RVA: 0x00185138 File Offset: 0x00183538
	public void PutAttachToCached(GeAttach attach)
	{
		if (attach != null && attach.cached && attach.Root != null && !this.cachedAttachs.Contains(attach))
		{
			attach.Reset();
			attach.Root.SetActive(false);
			this.cachedAttachs.Add(attach);
		}
	}

	// Token: 0x06008958 RID: 35160 RVA: 0x00185198 File Offset: 0x00183598
	public void ClearCached()
	{
		if (this.cachedAttachs == null)
		{
			return;
		}
		for (int i = 0; i < this.cachedAttachs.Count; i++)
		{
			if (this.m_Avatar != null)
			{
				this.m_Avatar.DestroyAttachment(this.cachedAttachs[i]);
			}
		}
		this.cachedAttachs.Clear();
	}

	// Token: 0x06008959 RID: 35161 RVA: 0x001851FC File Offset: 0x001835FC
	public GeAttach CreateAttachment(string attachmentName, string attachRes, string attachNode, bool cached = false, bool asyncLoad = false, bool highPriority = false)
	{
		if (this.useCube)
		{
			return null;
		}
		GeAttach geAttach;
		if (cached)
		{
			geAttach = this.GetAttachFromCached(attachRes, attachNode);
			if (geAttach != null)
			{
				return geAttach;
			}
		}
		geAttach = this.m_Avatar.CreateAttachment(attachmentName, attachRes, attachNode, cached, asyncLoad, highPriority);
		if (cached)
		{
			geAttach.cached = true;
		}
		return geAttach;
	}

	// Token: 0x0600895A RID: 35162 RVA: 0x00185254 File Offset: 0x00183654
	public void DestroyAttachment(GeAttach att)
	{
		if (att != null && att.cached)
		{
			this.PutAttachToCached(att);
			return;
		}
		this.m_Avatar.DestroyAttachment(att);
	}

	// Token: 0x0600895B RID: 35163 RVA: 0x0018527B File Offset: 0x0018367B
	public uint ChangeSurface(string animate, float timeLen, bool enableAnim = true, bool needRecover = true)
	{
		if (this.useCube)
		{
			return 2147483647U;
		}
		return this.m_Material.PushAnimat(animate, timeLen, enableAnim, needRecover);
	}

	// Token: 0x0600895C RID: 35164 RVA: 0x0018529E File Offset: 0x0018369E
	public void RemoveSurface(uint handle)
	{
		if (this.useCube)
		{
			return;
		}
		if (handle == 4294967295U)
		{
			this.m_Material.ClearAll();
		}
		else
		{
			this.m_Material.RemoveAnimat(handle);
		}
	}

	// Token: 0x0600895D RID: 35165 RVA: 0x001852D0 File Offset: 0x001836D0
	public void CreateSnapshot(Color32 color, float TimeLen, string materialPath = "")
	{
		if (this.m_Avatar.suitPartModel.Length <= 0 && this.snapShotCache == null)
		{
			GameObject avatarRoot = this.m_Avatar.GetAvatarRoot();
			if (null != avatarRoot)
			{
				SkinnedMeshRenderer componentInChildren = avatarRoot.GetComponentInChildren<SkinnedMeshRenderer>();
				if (null != componentInChildren)
				{
					this.snapShotCache = new GameObject[]
					{
						componentInChildren.gameObject
					};
				}
			}
		}
		GameObject[] suitPartModel;
		if (this.snapShotCache != null)
		{
			suitPartModel = this.snapShotCache;
		}
		else
		{
			suitPartModel = this.m_Avatar.suitPartModel;
		}
		this.m_SnapEffect.CreateSnapshot(suitPartModel, color, (int)(TimeLen * 1000f), materialPath);
	}

	// Token: 0x0600895E RID: 35166 RVA: 0x00185376 File Offset: 0x00183776
	public bool AddAnimPackage(string animPackage)
	{
		return false;
	}

	// Token: 0x0600895F RID: 35167 RVA: 0x00185379 File Offset: 0x00183779
	public void ProloadAction(string[] animList)
	{
		this.m_Avatar.PreloadAction(animList);
	}

	// Token: 0x06008960 RID: 35168 RVA: 0x00185387 File Offset: 0x00183787
	public void ProloadAction(string anim)
	{
		this.m_Avatar.PreloadAction(anim);
	}

	// Token: 0x06008961 RID: 35169 RVA: 0x00185398 File Offset: 0x00183798
	public bool ChangeAction(string action, float speed, bool loop = false, bool replace = true, bool force = false)
	{
		return (!force && replace && loop && this.m_Avatar.GetCurActionName() == action && Mathf.Abs(speed - this.m_Avatar.GetActionSpeed()) < 0.01f) || ((replace || this.m_Avatar.GetCurActionName() != action) && this.m_Avatar.ChangeAction(action, speed, loop));
	}

	// Token: 0x06008962 RID: 35170 RVA: 0x0018541A File Offset: 0x0018381A
	public void StopAction()
	{
		this.m_Avatar.StopAction();
	}

	// Token: 0x06008963 RID: 35171 RVA: 0x00185427 File Offset: 0x00183827
	public string GetCurActionName()
	{
		if (this.m_Avatar != null)
		{
			return this.m_Avatar.GetCurActionName();
		}
		return string.Empty;
	}

	// Token: 0x06008964 RID: 35172 RVA: 0x00185445 File Offset: 0x00183845
	public float GetActionTimeLen(string action)
	{
		return this.m_Avatar.GetActionTimeLen(action);
	}

	// Token: 0x06008965 RID: 35173 RVA: 0x00185453 File Offset: 0x00183853
	public bool IsActionLoop(string action)
	{
		return this.m_Avatar.IsActionLoop(action);
	}

	// Token: 0x06008966 RID: 35174 RVA: 0x00185461 File Offset: 0x00183861
	public float GetCurActionSpeed()
	{
		return this.m_Avatar.GetCurActionSpeed();
	}

	// Token: 0x06008967 RID: 35175 RVA: 0x0018546E File Offset: 0x0018386E
	public float GetCurActionOffset()
	{
		return this.m_Avatar.GetCurActionOffset();
	}

	// Token: 0x06008968 RID: 35176 RVA: 0x0018547B File Offset: 0x0018387B
	public bool GetCurActionLoop()
	{
		return this.m_Avatar.GetCurActionLoop();
	}

	// Token: 0x06008969 RID: 35177 RVA: 0x00185488 File Offset: 0x00183888
	public GameObject GetEntityNode(GeEntity.GeEntityNodeType nodeType)
	{
		switch (nodeType)
		{
		case GeEntity.GeEntityNodeType.Root:
			return this.m_EntitySpaceDesc.rootNode;
		case GeEntity.GeEntityNodeType.Actor:
			return this.m_EntitySpaceDesc.actorNode;
		case GeEntity.GeEntityNodeType.Child:
			return this.m_EntitySpaceDesc.childNode;
		case GeEntity.GeEntityNodeType.Charactor:
			return this.m_EntitySpaceDesc.characterNode;
		case GeEntity.GeEntityNodeType.Transform:
			return this.m_EntitySpaceDesc.transformNode;
		default:
			return null;
		}
	}

	// Token: 0x0600896A RID: 35178 RVA: 0x001854F1 File Offset: 0x001838F1
	public void SetEntityPlane(Vector4 plane)
	{
		this.m_EntityPlane = plane;
	}

	// Token: 0x0600896B RID: 35179 RVA: 0x001854FC File Offset: 0x001838FC
	public void ChangeAvatar(GeAvatarChannel channel, string modulePath, bool asyncLoad, bool highPriority, int prodid)
	{
		DAssetObject asset = new DAssetObject(null, modulePath);
		this.m_IsAvatarDirty = true;
		if (this.isBattleActor)
		{
			this.m_Material.RemoveObject(this.m_Avatar.suitPartModel);
		}
		this.m_Avatar.ChangeAvatarObject(channel, asset, asyncLoad, highPriority, prodid);
		this.PushPostLoadCommand(delegate
		{
			if (this.isBattleActor)
			{
				this.m_Material.AppendObject(this.m_Avatar.suitPartModel);
			}
		});
	}

	// Token: 0x0600896C RID: 35180 RVA: 0x00185560 File Offset: 0x00183960
	public void SuitAvatar(bool isAsyncLoad = true, bool highPriority = false, int prodid = 0)
	{
		if (this.isBattleActor)
		{
			this.m_Material.RemoveObject(this.m_Avatar.suitPartModel);
		}
		this.m_Avatar.SuitAvatar(isAsyncLoad, highPriority, prodid);
		this.PushPostLoadCommand(delegate
		{
			this.m_Avatar.SetAvatarVisible(true);
			if (this.isBattleActor)
			{
				this.m_Material.AppendObject(this.m_Avatar.suitPartModel);
			}
		});
	}

	// Token: 0x0600896D RID: 35181 RVA: 0x001855B0 File Offset: 0x001839B0
	protected void _AddShadow()
	{
		if (!this.hasShadow)
		{
			return;
		}
		this._RemoveShadow();
		int num = 0;
		Singleton<GeGraphicSetting>.instance.GetSetting("GraphicLevel", ref num);
		this.simpleObj[0] = this.m_Avatar.GetAvatarRoot();
		if (num < 2)
		{
			Singleton<GeSimpleShadowManager>.instance.AddShadowObject(this.simpleObj, this.m_EntityPlane, this.shadowScale);
		}
	}

	// Token: 0x0600896E RID: 35182 RVA: 0x00185619 File Offset: 0x00183A19
	protected void _RemoveShadow()
	{
		this.simpleObj[0] = this.m_Avatar.GetAvatarRoot();
		Singleton<GeSimpleShadowManager>.instance.RemoveShadowObject(this.simpleObj);
	}

	// Token: 0x0600896F RID: 35183 RVA: 0x0018563E File Offset: 0x00183A3E
	public GameObject GetShadowObj()
	{
		return Singleton<GeSimpleShadowManager>.instance.GetShadowObj(this.m_Avatar.GetAvatarRoot());
	}

	// Token: 0x06008970 RID: 35184 RVA: 0x00185655 File Offset: 0x00183A55
	public void SetUseCube(bool flag)
	{
		this.useCube = flag;
		if (this.m_Effect != null)
		{
			this.m_Effect.useCube = flag;
		}
		this.m_Avatar.airMode = flag;
	}

	// Token: 0x06008971 RID: 35185 RVA: 0x00185684 File Offset: 0x00183A84
	public bool GetUseCube()
	{
		bool flag = false;
		if (this.m_Effect != null)
		{
			flag = this.m_Effect.useCube;
		}
		return this.useCube || flag;
	}

	// Token: 0x06008972 RID: 35186 RVA: 0x001856B9 File Offset: 0x00183AB9
	public GeEffectManager GetEffectManager()
	{
		return this.m_Effect;
	}

	// Token: 0x06008973 RID: 35187 RVA: 0x001856C1 File Offset: 0x00183AC1
	public int GetActorNodeLayer()
	{
		if (this.m_EntitySpaceDesc.actorNode == null)
		{
			return 0;
		}
		return this.m_EntitySpaceDesc.actorNode.layer;
	}

	// Token: 0x06008974 RID: 35188 RVA: 0x001856EB File Offset: 0x00183AEB
	public void SetActorNodeLayer(int layer)
	{
		if (this.m_EntitySpaceDesc.actorNode == null)
		{
			return;
		}
		this.m_EntitySpaceDesc.actorNode.SetLayer(layer);
	}

	// Token: 0x06008975 RID: 35189 RVA: 0x00185718 File Offset: 0x00183B18
	public byte[] GetBlockData(out int width, out int height)
	{
		if (null != this.m_ModelData && this.m_ModelData.blockGridChunk.gridBlockData != null)
		{
			width = this.m_ModelData.blockGridChunk.gridWidth;
			height = this.m_ModelData.blockGridChunk.gridHeight;
			return this.m_ModelData.blockGridChunk.gridBlockData;
		}
		width = 1;
		height = 1;
		return GeEntity.DEFAULT_BLOCK_DATA;
	}

	// Token: 0x040042B6 RID: 17078
	protected string m_EntityName = string.Empty;

	// Token: 0x040042B7 RID: 17079
	protected DModelData m_ModelData;

	// Token: 0x040042B8 RID: 17080
	protected AssetInst m_ModelDataAsset;

	// Token: 0x040042B9 RID: 17081
	protected bool m_IsRemoved;

	// Token: 0x040042BA RID: 17082
	protected static readonly byte[] DEFAULT_BLOCK_DATA = new byte[]
	{
		1
	};

	// Token: 0x040042BB RID: 17083
	public bool charactorRootIsNull;

	// Token: 0x040042BC RID: 17084
	protected GeEntity.GeEntitySpaceDesc m_EntitySpaceDesc;

	// Token: 0x040042BD RID: 17085
	protected GeAvatar m_Avatar = new GeAvatar(true);

	// Token: 0x040042BE RID: 17086
	protected GeModelManager m_ModelManager;

	// Token: 0x040042BF RID: 17087
	protected GeAnimatManagerEx m_Material = new GeAnimatManagerEx();

	// Token: 0x040042C0 RID: 17088
	protected GeEffectManager m_Effect = new GeEffectManager();

	// Token: 0x040042C1 RID: 17089
	protected GeAfterImageMnanger m_SnapEffect = new GeAfterImageMnanger();

	// Token: 0x040042C2 RID: 17090
	protected GeSceneEx m_Scene;

	// Token: 0x040042C3 RID: 17091
	protected Vector4 m_EntityPlane = new Vector4(0f, 1f, 0f, 0.03f);

	// Token: 0x040042C4 RID: 17092
	protected List<PostLoadCommand> m_PostLoadCommand = new List<PostLoadCommand>();

	// Token: 0x040042C5 RID: 17093
	protected bool m_IsAvatarDirty;

	// Token: 0x040042C6 RID: 17094
	protected List<GeAttach> cachedAttachs = new List<GeAttach>();

	// Token: 0x040042C7 RID: 17095
	protected bool useCube;

	// Token: 0x040042C8 RID: 17096
	protected bool isBattleActor = true;

	// Token: 0x040042C9 RID: 17097
	protected bool hasShadow;

	// Token: 0x040042CA RID: 17098
	protected Vector3 shadowScale = Vector3.one;

	// Token: 0x040042CB RID: 17099
	protected GameObject[] snapShotCache;

	// Token: 0x040042CC RID: 17100
	private GameObject[] simpleObj = new GameObject[1];

	// Token: 0x02000D1C RID: 3356
	public enum GeEntityRes
	{
		// Token: 0x040042CE RID: 17102
		Action = 1,
		// Token: 0x040042CF RID: 17103
		Material,
		// Token: 0x040042D0 RID: 17104
		EffectUnique = 4,
		// Token: 0x040042D1 RID: 17105
		EffectMultiple = 8,
		// Token: 0x040042D2 RID: 17106
		Attach = 16,
		// Token: 0x040042D3 RID: 17107
		EffectGlobal = 32,
		// Token: 0x040042D4 RID: 17108
		All = 63
	}

	// Token: 0x02000D1D RID: 3357
	public enum GeEntityNodeType
	{
		// Token: 0x040042D6 RID: 17110
		Root,
		// Token: 0x040042D7 RID: 17111
		Actor,
		// Token: 0x040042D8 RID: 17112
		Child,
		// Token: 0x040042D9 RID: 17113
		Charactor,
		// Token: 0x040042DA RID: 17114
		Transform
	}

	// Token: 0x02000D1E RID: 3358
	protected struct GeEntitySpaceDesc
	{
		// Token: 0x040042DB RID: 17115
		public GameObject rootNode;

		// Token: 0x040042DC RID: 17116
		public GameObject characterNode;

		// Token: 0x040042DD RID: 17117
		public GameObject actorNode;

		// Token: 0x040042DE RID: 17118
		public GameObject transformNode;

		// Token: 0x040042DF RID: 17119
		public GameObject childNode;

		// Token: 0x040042E0 RID: 17120
		public GameObject actorModel;

		// Token: 0x040042E1 RID: 17121
		public Vector3 position;

		// Token: 0x040042E2 RID: 17122
		public Vector3 localScale;

		// Token: 0x040042E3 RID: 17123
		public Quaternion rotation;

		// Token: 0x040042E4 RID: 17124
		public float scale;

		// Token: 0x040042E5 RID: 17125
		public bool faceLeft;

		// Token: 0x040042E6 RID: 17126
		public bool m_IsEntityHide;
	}
}
