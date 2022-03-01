using System;
using System.Collections.Generic;
using Battle;
using GameClient;
using ProtoTable;
using Tenmove.Runtime;
using UnityEngine;

// Token: 0x02000D8C RID: 3468
public class GeSceneEx
{
	// Token: 0x06008C7F RID: 35967 RVA: 0x001A062F File Offset: 0x0019EA2F
	public void SetDoorData(List<BeRegionBase> doorData)
	{
	}

	// Token: 0x06008C80 RID: 35968 RVA: 0x001A0634 File Offset: 0x0019EA34
	protected bool _InitScene(ISceneData sceneData, bool isChiji = false)
	{
		if (sceneData != null)
		{
			this.m_LevelData = sceneData;
			this._loadSceneLogicRoot();
			this._loadSceneRoot();
			this._loadActorRoot();
			this._updateGeCamera();
			this._loadInstance(isChiji);
			if (null != this.m_SceneRoot)
			{
				this.m_SceneRoot.AddComponent<ComLifeCycleDebug>();
			}
			if (null != this.m_SceneActorRoot)
			{
				this.m_SceneActorRoot.AddComponent<ComLifeCycleDebug>();
			}
			return true;
		}
		Logger.LogError("levelData is nil");
		return false;
	}

	// Token: 0x06008C81 RID: 35969 RVA: 0x001A06B4 File Offset: 0x0019EAB4
	private void _loadInstance(bool isChiji = false)
	{
		if (isChiji)
		{
			this.m_SceneObject = MonoSingleton<ManualPoolCollector>.instance.GetGameObject(this.m_LevelData.GetPrefabPath());
		}
		else
		{
			this.m_SceneObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.m_LevelData.GetPrefabPath(), true, 0U);
		}
		this._InitColorDescList(this.m_SceneObject);
		Singleton<GeGraphicSetting>.instance.CheckComponent(this.m_SceneObject);
		this.m_SceneObject.AddComponent<ComLifeCycleDebug>();
		this._NormalizeSceneWaterLevel(this.m_SceneObject);
		GeUtility.AttachTo(this.m_SceneObject, this.m_SceneRoot, false);
		GePlaneShadowManager.GePlaneShadowSetting gePlaneShadowSetting = new GePlaneShadowManager.GePlaneShadowSetting();
		gePlaneShadowSetting.m_AttenuatePow = 0.2f;
		gePlaneShadowSetting.m_ShadowColor.r = 0.1f;
		gePlaneShadowSetting.m_ShadowColor.g = 0.15f;
		gePlaneShadowSetting.m_ShadowColor.b = 0.11f;
		gePlaneShadowSetting.m_ShadowColor.a = 3.5f;
		gePlaneShadowSetting.m_ShadowPlane = GeSceneEx.EntityPlane;
		Singleton<GePlaneShadowManager>.instance.SetShadowSetting(gePlaneShadowSetting);
		Singleton<GeMeshRenderManager>.GetInstance().Init(this.m_MainCamera.GetCamera().gameObject);
		Singleton<GeMeshRenderManager>.GetInstance().AddMeshObject(this.m_SceneObject);
		this._InitRenderSetting();
	}

	// Token: 0x06008C82 RID: 35970 RVA: 0x001A07E2 File Offset: 0x0019EBE2
	private void _loadSceneLogicRoot()
	{
		if (this.m_SceneLogicRoot == null)
		{
			this.m_SceneLogicRoot = new GameObject("SceneLogicRoot");
		}
		this._updateSceneLogicRoot();
	}

	// Token: 0x06008C83 RID: 35971 RVA: 0x001A080B File Offset: 0x0019EC0B
	private void _updateSceneLogicRoot()
	{
		if (this.m_SceneLogicRoot != null && this.m_LevelData != null)
		{
			this.m_SceneLogicRoot.transform.localPosition = this.m_LevelData.GetLogicPos();
		}
	}

	// Token: 0x06008C84 RID: 35972 RVA: 0x001A0844 File Offset: 0x0019EC44
	private void _unloadSceneLogicRoot()
	{
		if (this.m_SceneLogicRoot != null)
		{
			Object.Destroy(this.m_SceneLogicRoot);
			this.m_SceneLogicRoot = null;
		}
	}

	// Token: 0x06008C85 RID: 35973 RVA: 0x001A086C File Offset: 0x0019EC6C
	private void _onCreateActorAsync(GeActorEx newActorEx)
	{
		if (this.mCreateGeActorExData == null)
		{
			return;
		}
		string resName = newActorEx.GetResName();
		if (resName.Contains("Hero") || resName.Contains("Monster") || resName.Contains("NPC"))
		{
			newActorEx.PushPostLoadCommand(delegate
			{
				Vector4 entityPlane = GeSceneEx.EntityPlane;
				entityPlane.w += (float)this.mCreateGeActorExData.height * 0.01f;
				newActorEx.SetEntityPlane(entityPlane);
				newActorEx.AddSimpleShadow(Vector3.one);
			});
		}
		newActorEx.PushPostLoadCommand(delegate
		{
			if (this.mCreateGeActorExData.isSceneObj)
			{
				Singleton<GeSceneObjManager>.instance.AddOccludeObject(newActorEx.renderObject);
			}
			for (int i = 0; i < newActorEx.renderObject.Length; i++)
			{
				Singleton<GeMeshRenderManager>.GetInstance().AddMeshObject(newActorEx.renderObject[i]);
			}
		});
		if (newActorEx == null)
		{
			Logger.LogErrorFormat("CreateActor is nil {0}, {1}", new object[]
			{
				this.mCreateGeActorExData.nResID,
				this.mCreateGeActorExData.iUnitId
			});
		}
		else
		{
			newActorEx.hpBarManager = this.mHPManager;
			newActorEx.stateBarManager = this.mStateManager;
		}
	}

	// Token: 0x06008C86 RID: 35974 RVA: 0x001A096B File Offset: 0x0019ED6B
	protected void _InitRenderSetting()
	{
		RenderSettings.fog = false;
		RenderSettings.ambientMode = 3;
		RenderSettings.ambientLight = new Color(0.15f, 0.18f, 0.15f, 1f);
		RenderSettings.ambientIntensity = 1f;
	}

	// Token: 0x06008C87 RID: 35975 RVA: 0x001A09A4 File Offset: 0x0019EDA4
	public void _loadActorRoot()
	{
		if (this.m_ActorRoot == null)
		{
			this.m_ActorRoot = new GameObject();
			this.m_ActorRoot.name = "ActorRoot";
		}
		this.m_ActorRoot.transform.SetParent(this.m_SceneLogicRoot.transform, false);
		if (this.m_SceneActorRoot == null)
		{
			this.m_SceneActorRoot = new GameObject();
			this.m_SceneActorRoot.name = "SceneActorRoot";
			GeUtility.AttachTo(this.m_SceneActorRoot, this.m_ActorRoot, false);
		}
		this._updateActorRoot();
	}

	// Token: 0x06008C88 RID: 35976 RVA: 0x001A0A3D File Offset: 0x0019EE3D
	public void _updateActorRoot()
	{
	}

	// Token: 0x06008C89 RID: 35977 RVA: 0x001A0A3F File Offset: 0x0019EE3F
	public void _unloadActorRoot()
	{
		if (this.m_ActorRoot != null)
		{
			Object.Destroy(this.m_ActorRoot);
			this.m_ActorRoot = null;
		}
	}

	// Token: 0x06008C8A RID: 35978 RVA: 0x001A0A64 File Offset: 0x0019EE64
	public void DestroyMaskCameraEffect()
	{
		if (this.m_MaskCameraEffect != null)
		{
			this.m_MaskCameraEffect.SetDestory();
		}
	}

	// Token: 0x06008C8B RID: 35979 RVA: 0x001A0A84 File Offset: 0x0019EE84
	public GeMaskCameraEffect CreateMaskCameraEffect()
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/Scene_effects/MaskCameraCloudEffect/MaskCameraEffect", true, 0U);
		this.m_MaskCameraEffect = gameObject.GetComponent<GeMaskCameraEffect>();
		this.m_MaskCameraEffect.Init(Camera.main, 0f);
		return this.m_MaskCameraEffect;
	}

	// Token: 0x06008C8C RID: 35980 RVA: 0x001A0ACC File Offset: 0x0019EECC
	public void _updateGeCamera()
	{
		this.m_MainCamera.InitCamera(this.m_LevelData.GetCameraSize(), this.m_LevelData.GetCameraNearClip(), this.m_LevelData.GetCameraFarClip(), this.m_LevelData.IsCameraPersp());
		this.m_MainCamera.GetController().SetMotorLimit(Global.Settings.cameraInRange.x, 0f, Global.Settings.cameraInRange.y);
		this.m_MainCamera.GetController().SetLimitRange(this.m_LevelData.GetCameraXRange().x, 0f, this.m_LevelData.GetCameraZRange().x, this.m_LevelData.GetCameraXRange().y, 0f, this.m_LevelData.GetCameraZRange().y);
	}

	// Token: 0x06008C8D RID: 35981 RVA: 0x001A0BAC File Offset: 0x0019EFAC
	public void _loadSceneRoot()
	{
		if (this.m_SceneRoot == null)
		{
			this.m_SceneRoot = new GameObject("SceneRoot");
		}
		this.m_SceneRoot.transform.SetParent(this.m_SceneLogicRoot.transform, false);
		this._updateSceneRoot();
	}

	// Token: 0x06008C8E RID: 35982 RVA: 0x001A0BFC File Offset: 0x0019EFFC
	public void _updateSceneRoot()
	{
		if (this.m_SceneRoot != null && this.m_LevelData != null)
		{
			this.m_SceneRoot.transform.localPosition = this.m_LevelData.GetScenePostion();
			this.m_SceneRoot.transform.localScale = new Vector3(this.m_LevelData.GetSceneUScale(), this.m_LevelData.GetSceneUScale(), this.m_LevelData.GetSceneUScale());
		}
		RenderSettings.ambientMode = RenderSettings.ambientMode;
		RenderSettings.ambientLight = new Color32(105, 120, 105, byte.MaxValue);
	}

	// Token: 0x06008C8F RID: 35983 RVA: 0x001A0C9A File Offset: 0x0019F09A
	public void _unloadSceneRoot()
	{
		if (this.m_SceneRoot != null)
		{
			Object.Destroy(this.m_SceneRoot);
			this.m_SceneRoot = null;
		}
	}

	// Token: 0x06008C90 RID: 35984 RVA: 0x001A0CBF File Offset: 0x0019F0BF
	public bool LoadScene(ISceneData sceneData, bool needColorDyer = true, bool isChiji = false)
	{
		this.m_EnableColorDyer = needColorDyer;
		return this._InitScene(sceneData, isChiji);
	}

	// Token: 0x06008C91 RID: 35985 RVA: 0x001A0CD0 File Offset: 0x0019F0D0
	public void UnloadScene(bool a_bNeedGC = true, bool isChiji = false)
	{
		GeEffectEx.ClearDefaultTimeMap();
		Singleton<GeSceneObjManager>.instance.ClearAll();
		Singleton<GeMeshRenderManager>.instance.Deinit();
		Singleton<GePlaneShadowManager>.instance.ClearAll();
		Singleton<GeSimpleShadowManager>.instance.ClearAll();
		MonoSingleton<AudioManager>.instance.ClearPreloadSound();
		Singleton<GeEffectPool>.GetInstance().ClearAll();
		this._ClearSceneDescList();
		if (this.m_ActorManager != null)
		{
			this.m_ActorManager.ClearAll();
			this.m_ActorManager = null;
		}
		if (this.m_EffectManager != null)
		{
			this.m_EffectManager.Deinit();
			this.m_EffectManager = null;
		}
		if (BeClientSwitch.FunctionIsOpen(ClientSwitchType.GeEffectPoolClearBug))
		{
			Singleton<GeEffectPool>.GetInstance().ClearAll();
		}
		if (this.specialSceneManager != null)
		{
			this.specialSceneManager.Deinit();
			this.specialSceneManager = null;
		}
		if (isChiji)
		{
			MonoSingleton<ManualPoolCollector>.instance.Recycle(this.m_SceneObject);
		}
		else
		{
			Object.Destroy(this.m_SceneObject);
		}
		this.m_SceneObject = null;
		this._unloadActorRoot();
		this._unloadSceneRoot();
		this._unloadSceneLogicRoot();
		if (this.mHPManager != null)
		{
			this.mHPManager.Unload();
			this.mHPManager = null;
		}
		if (this.mStateManager != null)
		{
			this.mStateManager.Unload();
			this.mStateManager = null;
		}
		this.m_LevelData = null;
		if (a_bNeedGC)
		{
			MonoSingleton<AssetGabageCollector>.instance.ClearUnusedAsset(null, false);
		}
		if (this.m_GeSpecialSceneEx != null)
		{
			this.m_GeSpecialSceneEx = null;
		}
	}

	// Token: 0x06008C92 RID: 35986 RVA: 0x001A0E38 File Offset: 0x0019F238
	public void initScrollScript()
	{
		if (this.m_SceneObject == null)
		{
			return;
		}
		XCameraScrollScript[] componentsInChildren = this.m_SceneObject.GetComponentsInChildren<XCameraScrollScript>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].ForceUpdate();
		}
	}

	// Token: 0x06008C93 RID: 35987 RVA: 0x001A0E80 File Offset: 0x0019F280
	public void ReloadSceneWithSameScene(ISceneData sceneData)
	{
		if (sceneData != null)
		{
			bool flag = false;
			if (this.m_LevelData.GetPrefabPath() != sceneData.GetPrefabPath())
			{
				this._unloadSceneRoot();
				this._loadSceneRoot();
				flag = true;
			}
			this.m_LevelData = sceneData;
			this._updateSceneLogicRoot();
			this._updateSceneRoot();
			this._updateGeCamera();
			if (flag)
			{
				this._loadInstance(false);
			}
			else
			{
				this._InitRenderSetting();
			}
		}
		else
		{
			Logger.LogError("level data is nil");
		}
	}

	// Token: 0x06008C94 RID: 35988 RVA: 0x001A0F00 File Offset: 0x0019F300
	public GeEffectEx CreateEffect(string effectPath, float fTime, Vec3 initPos, float initScale = 1f, float fSpeed = 1f, bool isLoop = false, bool faceLeft = false)
	{
		EffectsFrames dummy_HIT_EFF_FRAME = this.DUMMY_HIT_EFF_FRAME;
		dummy_HIT_EFF_FRAME.localPosition = new Vector3(0f, 0f, 0f);
		dummy_HIT_EFF_FRAME.localRotation = Quaternion.identity;
		DAssetObject effectRes;
		effectRes.m_AssetObj = null;
		effectRes.m_AssetPath = effectPath;
		return this.CreateEffect(effectRes, dummy_HIT_EFF_FRAME, fTime, initPos, initScale, fSpeed, isLoop, faceLeft);
	}

	// Token: 0x06008C95 RID: 35989 RVA: 0x001A0F5C File Offset: 0x0019F35C
	public GeEffectEx CreateEffect(DAssetObject effectRes, EffectsFrames info, float fTime, Vec3 initPos, float initScale = 1f, float fSpeed = 1f, bool isLoop = false, bool faceLeft = false)
	{
		if (null != effectRes.m_AssetObj || (effectRes.m_AssetPath != null && string.Empty != effectRes.m_AssetPath))
		{
			Vector3 pos;
			pos..ctor(initPos.x, initPos.z, initPos.y);
			GeEffectEx geEffectEx = this.m_EffectManager.AddEffect(effectRes, info, fTime, pos, null, faceLeft, false);
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
				return geEffectEx;
			}
		}
		return null;
	}

	// Token: 0x06008C96 RID: 35990 RVA: 0x001A1018 File Offset: 0x0019F418
	public void DestroyEffect(GeEffectEx effect)
	{
		GeEffectType effectType = GeEffectType.EffectMultiple;
		if (effect.GetTimeType() == EffectTimeType.GLOBAL_ANIMATION)
		{
			effectType = GeEffectType.EffectUnique;
		}
		this.m_EffectManager.RemoveEffect(effect, effectType);
	}

	// Token: 0x06008C97 RID: 35991 RVA: 0x001A1044 File Offset: 0x0019F444
	public GeActorEx CreateActorAsync(int nResID, int iUnitId = 0, int height = 0, bool isSceneObj = false, bool isBattleActor = true, bool usePool = true)
	{
		this.mCreateGeActorExData = new GeSceneEx.CreateGeActorExData(nResID, iUnitId, height, isSceneObj, isBattleActor, usePool);
		return this.m_ActorManager.AddActorAync(nResID, (!isSceneObj) ? this.m_ActorRoot : this.m_SceneActorRoot, this, iUnitId, isBattleActor, usePool, new PosLoadGeActorEx(this._onCreateActorAsync));
	}

	// Token: 0x06008C98 RID: 35992 RVA: 0x001A109C File Offset: 0x0019F49C
	public GeActorEx CreateActorAsyncEx(int nResID, int iUnitId = 0, int height = 0, bool isSceneObj = false, bool isBattleActor = true, bool usePool = true, PosLoadGeActorEx load = null)
	{
		GeActorEx newActorEx = this.m_ActorManager.AddActorAyncEx(nResID, (!isSceneObj) ? this.m_ActorRoot : this.m_SceneActorRoot, this, iUnitId, isBattleActor, usePool, load);
		if (newActorEx != null)
		{
			Vector4 entityPlane = GeSceneEx.EntityPlane;
			entityPlane.w += (float)height * 0.01f;
			newActorEx.SetEntityPlane(entityPlane);
			newActorEx.AddSimpleShadow(Vector3.one);
			newActorEx.PushPostLoadCommand(delegate
			{
				if (isSceneObj)
				{
					Singleton<GeSceneObjManager>.instance.AddOccludeObject(newActorEx.renderObject);
				}
				for (int i = 0; i < newActorEx.renderObject.Length; i++)
				{
					Singleton<GeMeshRenderManager>.GetInstance().AddMeshObject(newActorEx.renderObject[i]);
				}
			});
			newActorEx.hpBarManager = this.mHPManager;
			newActorEx.stateBarManager = this.mStateManager;
		}
		return newActorEx;
	}

	// Token: 0x06008C99 RID: 35993 RVA: 0x001A1170 File Offset: 0x0019F570
	public GeActorEx CreateActor(int nResID, int iUnitId = 0, int height = 0, bool isSceneObj = false, bool isBattleActor = true, bool usePool = true, bool useCube = false)
	{
		GeActorEx newActorEx = this.m_ActorManager.AddActor(nResID, (!isSceneObj) ? this.m_ActorRoot : this.m_SceneActorRoot, this, iUnitId, isBattleActor, usePool, useCube);
		if (newActorEx == null)
		{
			ResTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(nResID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("Create actor has failed with resID:{0} [Can not find table data with this ID]!", new object[]
				{
					nResID
				});
			}
			else
			{
				Logger.LogErrorFormat("Create actor has failed with res path:'{0}'!", new object[]
				{
					tableItem.ModelPath
				});
			}
			return null;
		}
		string resName = newActorEx.GetResName();
		if (resName.Contains("Hero") || resName.Contains("Monster") || resName.Contains("NPC"))
		{
			newActorEx.PushPostLoadCommand(delegate
			{
				Vector4 entityPlane = GeSceneEx.EntityPlane;
				entityPlane.w += (float)height * 0.01f;
				newActorEx.SetEntityPlane(entityPlane);
				newActorEx.AddSimpleShadow(Vector3.one);
			});
		}
		newActorEx.PushPostLoadCommand(delegate
		{
			if (isSceneObj)
			{
				Singleton<GeSceneObjManager>.instance.AddOccludeObject(newActorEx.renderObject);
			}
			for (int i = 0; i < newActorEx.renderObject.Length; i++)
			{
				Singleton<GeMeshRenderManager>.GetInstance().AddMeshObject(newActorEx.renderObject[i]);
			}
		});
		if (newActorEx == null)
		{
			Logger.LogErrorFormat("CreateActor is nil {0}, {1}", new object[]
			{
				nResID,
				iUnitId
			});
		}
		else
		{
			newActorEx.hpBarManager = this.mHPManager;
			newActorEx.stateBarManager = this.mStateManager;
		}
		return newActorEx;
	}

	// Token: 0x06008C9A RID: 35994 RVA: 0x001A12EC File Offset: 0x0019F6EC
	public void DestroyActor(GeActorEx actor)
	{
		if (actor != null)
		{
			Singleton<GePlaneShadowManager>.instance.RemoveShadowObject(actor.renderObject);
			Singleton<GeSimpleShadowManager>.instance.RemoveShadowObject(actor.renderObject);
			if (actor.renderObject != null)
			{
				for (int i = 0; i < actor.renderObject.Length; i++)
				{
					Singleton<GeSceneObjManager>.instance.RemoveOccludeObject(actor.renderObject[i]);
				}
			}
		}
		this.m_ActorManager.RemoveActor(actor);
	}

	// Token: 0x06008C9B RID: 35995 RVA: 0x001A1361 File Offset: 0x0019F761
	public void RecycleActor(GeActorEx actor)
	{
		actor.Clear(63);
		actor.ReleaseForProjectile(false);
	}

	// Token: 0x06008C9C RID: 35996 RVA: 0x001A1372 File Offset: 0x0019F772
	public GeCamera GetCamera()
	{
		return this.m_MainCamera;
	}

	// Token: 0x06008C9D RID: 35997 RVA: 0x001A137C File Offset: 0x0019F77C
	public void AttachCameraTo(GeEntity actor)
	{
		this.GetCamera().GetController().AttachTo(actor, this.m_LevelData.GetCameraLookHeight(), this.m_LevelData.GetCameraAngle(), this.m_LevelData.GetCameraDistance());
		Singleton<GeSceneObjManager>.instance.SetRefCamera(this.m_MainCamera.GetCamera().gameObject);
		Singleton<GeSceneObjManager>.instance.SetFocusEntity(actor.GetEntityNode(GeEntity.GeEntityNodeType.Actor));
		this.initScrollScript();
	}

	// Token: 0x06008C9E RID: 35998 RVA: 0x001A13F0 File Offset: 0x0019F7F0
	public void Update(int delta)
	{
		this._UpdateBlendSceneColor((float)delta / 1000f);
		this.m_MainCamera.Update(delta);
		this.m_EffectManager.Update(delta, GeEffectType.EffectMultiple);
		this.m_EffectManager.Update(delta, GeEffectType.EffectUnique);
		this.specialSceneManager.Update(delta);
		Singleton<GePlaneShadowManager>.instance.Update();
		Singleton<GeSimpleShadowManager>.instance.Update();
		Singleton<GeSceneObjManager>.instance.Update();
		this.m_ActorManager.Update();
		if (this.mHPManager != null)
		{
			this.mHPManager.Update(delta);
		}
		if (this.mStateManager != null && !this.isPauseLogic)
		{
			this.mStateManager.Update(delta);
		}
		if (this.m_GeSpecialSceneEx != null)
		{
			this.m_GeSpecialSceneEx.Update(delta);
		}
	}

	// Token: 0x06008C9F RID: 35999 RVA: 0x001A14B6 File Offset: 0x0019F8B6
	public void PauseLogic()
	{
		this.isPauseLogic = true;
	}

	// Token: 0x06008CA0 RID: 36000 RVA: 0x001A14BF File Offset: 0x0019F8BF
	public void ResumeLogic()
	{
		this.isPauseLogic = false;
	}

	// Token: 0x06008CA1 RID: 36001 RVA: 0x001A14C8 File Offset: 0x0019F8C8
	public Vector2 WorldPosToScreenPos(Vector3 pos)
	{
		Vector3 vector = this.m_MainCamera.GetCamera().WorldToScreenPoint(pos);
		return vector;
	}

	// Token: 0x06008CA2 RID: 36002 RVA: 0x001A14ED File Offset: 0x0019F8ED
	public Color GetObjectDyeColor()
	{
		if (this.m_LevelData != null)
		{
			return this.m_LevelData.GetObjectDyeColor();
		}
		return Color.white;
	}

	// Token: 0x06008CA3 RID: 36003 RVA: 0x001A150B File Offset: 0x0019F90B
	public void SetBlockData(ISceneData sceneData, byte[] blockData)
	{
	}

	// Token: 0x06008CA4 RID: 36004 RVA: 0x001A150D File Offset: 0x0019F90D
	public GeEffectManager GetEffectManager()
	{
		return this.m_EffectManager;
	}

	// Token: 0x06008CA5 RID: 36005 RVA: 0x001A1515 File Offset: 0x0019F915
	public void LoadMagicScene(string _scenePath, int _time, int _reversTime, float maxValue)
	{
		this.specialSceneManager.LoadMagicScene(_scenePath, _time, _reversTime, maxValue, this);
	}

	// Token: 0x06008CA6 RID: 36006 RVA: 0x001A1528 File Offset: 0x0019F928
	public void ReverseMaterialSpecialScene()
	{
		this.specialSceneManager.ReverseScene();
	}

	// Token: 0x06008CA7 RID: 36007 RVA: 0x001A1535 File Offset: 0x0019F935
	public GameObject GetSceneRoot()
	{
		return this.m_SceneRoot;
	}

	// Token: 0x06008CA8 RID: 36008 RVA: 0x001A153D File Offset: 0x0019F93D
	public GameObject GetActorRoot()
	{
		return this.m_ActorRoot;
	}

	// Token: 0x06008CA9 RID: 36009 RVA: 0x001A1545 File Offset: 0x0019F945
	public GameObject GetSceneActorRoot()
	{
		return this.m_SceneActorRoot;
	}

	// Token: 0x06008CAA RID: 36010 RVA: 0x001A154D File Offset: 0x0019F94D
	public GameObject GetSceneObject()
	{
		return this.m_SceneObject;
	}

	// Token: 0x06008CAB RID: 36011 RVA: 0x001A1558 File Offset: 0x0019F958
	public int BlendSceneSceneColor(float darkFactor, float time, bool alphaEffect = true)
	{
		if (!this.m_EnableColorDyer)
		{
			return -1;
		}
		if (time <= 0f)
		{
			return -1;
		}
		float darkWeight = Mathf.Clamp(darkFactor, 0f, 1f);
		for (int i = 0; i < this.m_ColorTimelines.Count; i++)
		{
			if (!this.m_ColorTimelines[i].m_IsPlaying)
			{
				GeSceneEx.SceneColorTimeline value = this.m_ColorTimelines[i];
				value.m_DarkWeight = darkWeight;
				value.m_TimeRemain = time;
				value.m_TimeTotal = time;
				value.m_IsRecover = false;
				value.m_IsPlaying = true;
				value.m_IsAlpha = alphaEffect;
				this.m_ColorTimelines[i] = value;
				return i;
			}
		}
		GeSceneEx.SceneColorTimeline item = new GeSceneEx.SceneColorTimeline(darkWeight, time, time, false, true, alphaEffect);
		this.m_ColorTimelines.Add(item);
		return this.m_ColorTimelines.Count - 1;
	}

	// Token: 0x06008CAC RID: 36012 RVA: 0x001A1638 File Offset: 0x0019FA38
	public void RecoverSceneColor(float time, int id)
	{
		if (!this.m_EnableColorDyer)
		{
			return;
		}
		if (time <= 0f)
		{
			return;
		}
		if (id >= 0 && id < this.m_ColorTimelines.Count)
		{
			if (this.m_ColorTimelines[id].m_IsPlaying)
			{
				GeSceneEx.SceneColorTimeline value = this.m_ColorTimelines[id];
				value.m_IsRecover = true;
				value.m_TimeRemain = time;
				value.m_TimeTotal = time;
				this.m_ColorTimelines[id] = value;
			}
		}
	}

	// Token: 0x06008CAD RID: 36013 RVA: 0x001A16C8 File Offset: 0x0019FAC8
	public void AddToColorDescList(GameObject go)
	{
		if (null != go && this.m_EnableColorDyer)
		{
			Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>();
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				Renderer renderer = componentsInChildren[i];
				if (!(null == renderer))
				{
					if (null != renderer as MeshRenderer || null != renderer as SkinnedMeshRenderer)
					{
						bool flag = false;
						int instanceID = renderer.GetInstanceID();
						int j = 0;
						int count = this.m_ColorDescList.Count;
						while (j < count)
						{
							if (this.m_ColorDescList[j].m_RenderInstanceID == instanceID)
							{
								flag = true;
								break;
							}
							j++;
						}
						if (!flag)
						{
							Color col = Color.white;
							if (null != renderer.sharedMaterial && renderer.sharedMaterial.HasProperty("_DyeColor"))
							{
								col = renderer.sharedMaterial.GetColor("_DyeColor");
							}
							this.m_ColorDescList.Add(new GeSceneEx.SceneColorDesc(renderer, instanceID, col));
						}
					}
				}
				i++;
			}
		}
	}

	// Token: 0x06008CAE RID: 36014 RVA: 0x001A17F0 File Offset: 0x0019FBF0
	public void ClearColorDesc(GameObject go)
	{
		if (!this.m_EnableColorDyer)
		{
			return;
		}
		if (null != go)
		{
			Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>();
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				Renderer cur = componentsInChildren[i];
				if (!(null == cur))
				{
					if (null != cur as MeshRenderer || null != cur as SkinnedMeshRenderer)
					{
						this.m_ColorDescList.RemoveAll((GeSceneEx.SceneColorDesc x) => x.m_Renderer.GetInstanceID() == cur.GetInstanceID());
					}
				}
				i++;
			}
		}
	}

	// Token: 0x06008CAF RID: 36015 RVA: 0x001A189B File Offset: 0x0019FC9B
	private void _InitColorDescList(GameObject sceneObj)
	{
		this._ClearSceneDescList();
		this.AddToColorDescList(sceneObj);
	}

	// Token: 0x06008CB0 RID: 36016 RVA: 0x001A18AA File Offset: 0x0019FCAA
	private void _ClearSceneDescList()
	{
		if (!this.m_EnableColorDyer)
		{
			return;
		}
		this.m_ColorDescList.Clear();
		this.m_ColorTimelines.Clear();
	}

	// Token: 0x06008CB1 RID: 36017 RVA: 0x001A18D0 File Offset: 0x0019FCD0
	private void _UpdateBlendSceneColor(float timeElapsed)
	{
		if (!this.m_EnableColorDyer)
		{
			return;
		}
		if (this.m_ColorTimelines.Count == 0)
		{
			return;
		}
		bool flag = false;
		float num = 1f;
		float num2 = 1f;
		for (int i = 0; i < this.m_ColorTimelines.Count; i++)
		{
			GeSceneEx.SceneColorTimeline value = this.m_ColorTimelines[i];
			if (value.m_IsPlaying)
			{
				flag = true;
				if (value.m_TimeRemain <= 0f && value.m_IsRecover)
				{
					value.m_IsPlaying = false;
				}
				float num3 = value.m_TimeRemain - timeElapsed;
				num3 = Mathf.Clamp(num3, 0f, value.m_TimeTotal);
				float num4 = 1f;
				float num5 = 1f - num3 / value.m_TimeTotal;
				float num6;
				if (!value.m_IsRecover)
				{
					num6 = Mathf.Lerp(1f, value.m_DarkWeight, num5);
					if (value.m_IsAlpha)
					{
						num4 = num6;
					}
				}
				else
				{
					num6 = Mathf.Lerp(value.m_DarkWeight, 1f, num5);
					if (value.m_IsAlpha)
					{
						num4 = num6;
					}
				}
				num *= num6;
				num2 *= num4;
				value.m_TimeRemain = num3;
				this.m_ColorTimelines[i] = value;
			}
		}
		if (!flag)
		{
			return;
		}
		int j = 0;
		int count = this.m_ColorDescList.Count;
		while (j < count)
		{
			if (this.m_ColorDescList[j].m_Renderer != null)
			{
				Color color = this.m_ColorDescList[j].m_OriginColor * num;
				color.a = this.m_ColorDescList[j].m_OriginColor.a * num2;
				this.m_ColorDescList[j].m_Renderer.GetPropertyBlock(this.m_ColorBlendBlock);
				this.m_ColorBlendBlock.SetColor("_DyeColor", color);
				this.m_ColorDescList[j].m_Renderer.SetPropertyBlock(this.m_ColorBlendBlock);
			}
			j++;
		}
	}

	// Token: 0x06008CB2 RID: 36018 RVA: 0x001A1B04 File Offset: 0x0019FF04
	public GameObject _GetSceneGroundObj(GameObject sceneRoot)
	{
		if (null == sceneRoot)
		{
			return null;
		}
		if (sceneRoot.CompareTag("Ground"))
		{
			return sceneRoot;
		}
		GameObject gameObject = null;
		int childCount = sceneRoot.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Transform child = sceneRoot.transform.GetChild(i);
			gameObject = this._GetSceneGroundObj(child.gameObject);
			if (null != gameObject)
			{
				return gameObject;
			}
		}
		return gameObject;
	}

	// Token: 0x06008CB3 RID: 36019 RVA: 0x001A1B7C File Offset: 0x0019FF7C
	public void _NormalizeSceneWaterLevel(GameObject sceneRoot)
	{
		GameObject gameObject = this._GetSceneGroundObj(sceneRoot);
		if (null != gameObject)
		{
			Vector3 position = sceneRoot.transform.position;
			position.y -= gameObject.transform.position.y + 0.05f;
			sceneRoot.transform.position = position;
			if (Global.Settings.isDebug && Global.Settings.sceneDark)
			{
				Renderer component = gameObject.GetComponent<Renderer>();
				if (component != null)
				{
					GameObject gameObject2 = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("Scene/Plane", true, 0U);
					GeUtility.AttachTo(gameObject2, sceneRoot, false);
					Vector3 center = component.bounds.center;
					center.z += component.bounds.size.z / 2f + 2f;
					gameObject2.transform.position = center;
					Logger.LogErrorFormat("gound,bound:{0} {1} ground:{2} goPlane:{3}", new object[]
					{
						component.bounds.min,
						component.bounds.max,
						gameObject.transform.localPosition,
						gameObject2.transform.localPosition
					});
				}
			}
		}
	}

	// Token: 0x06008CB4 RID: 36020 RVA: 0x001A1CDF File Offset: 0x001A00DF
	public GeActorEx[] GetActorList()
	{
		return this.m_ActorManager.actorList;
	}

	// Token: 0x170018A4 RID: 6308
	// (set) Token: 0x06008CB5 RID: 36021 RVA: 0x001A1CEC File Offset: 0x001A00EC
	public GeSpecialSceneEx GeSpecialSceneEx
	{
		set
		{
			this.m_GeSpecialSceneEx = value;
		}
	}

	// Token: 0x0400457F RID: 17791
	public static Vector4 EntityPlane = new Vector4(0f, 1f, 0f, 0.03f);

	// Token: 0x04004580 RID: 17792
	public GeMaskCameraEffect m_MaskCameraEffect;

	// Token: 0x04004581 RID: 17793
	private GeSceneEx.CreateGeActorExData mCreateGeActorExData;

	// Token: 0x04004582 RID: 17794
	public EffectsFrames DUMMY_HIT_EFF_FRAME = new EffectsFrames();

	// Token: 0x04004583 RID: 17795
	private MaterialPropertyBlock m_ColorBlendBlock = new MaterialPropertyBlock();

	// Token: 0x04004584 RID: 17796
	private List<GeSceneEx.SceneColorDesc> m_ColorDescList = new List<GeSceneEx.SceneColorDesc>();

	// Token: 0x04004585 RID: 17797
	private List<GeSceneEx.SceneColorTimeline> m_ColorTimelines = new List<GeSceneEx.SceneColorTimeline>();

	// Token: 0x04004586 RID: 17798
	private GeCamera m_MainCamera = new GeCamera();

	// Token: 0x04004587 RID: 17799
	private GameObject m_SceneLogicRoot;

	// Token: 0x04004588 RID: 17800
	private GameObject m_SceneRoot;

	// Token: 0x04004589 RID: 17801
	private GameObject m_ActorRoot;

	// Token: 0x0400458A RID: 17802
	private GameObject m_SceneActorRoot;

	// Token: 0x0400458B RID: 17803
	private GameObject m_SceneObject;

	// Token: 0x0400458C RID: 17804
	private GeSpecialSceneManager specialSceneManager = new GeSpecialSceneManager();

	// Token: 0x0400458D RID: 17805
	private GeEffectManager m_EffectManager = new GeEffectManager();

	// Token: 0x0400458E RID: 17806
	private GeSceneEx.GeActorManager m_ActorManager = new GeSceneEx.GeActorManager();

	// Token: 0x0400458F RID: 17807
	private Queue<GeActorEx> m_reusedActorList = new Queue<GeActorEx>();

	// Token: 0x04004590 RID: 17808
	private GeSpecialSceneEx m_GeSpecialSceneEx;

	// Token: 0x04004591 RID: 17809
	private bool m_EnableColorDyer = true;

	// Token: 0x04004592 RID: 17810
	protected HPBarManager mHPManager = new HPBarManager();

	// Token: 0x04004593 RID: 17811
	protected StateBarManager mStateManager = new StateBarManager();

	// Token: 0x04004594 RID: 17812
	private bool isPauseLogic;

	// Token: 0x04004595 RID: 17813
	private ISceneData m_LevelData;

	// Token: 0x02000D8D RID: 3469
	protected class GeActorManager
	{
		// Token: 0x06008CB8 RID: 36024 RVA: 0x001A1D28 File Offset: 0x001A0128
		public GeActorEx AddActor(int nResID, GameObject entityRoot, GeSceneEx scene, int iUnitId, bool isBattleActor = true, bool usePool = true, bool useCube = false)
		{
			GeActorEx geActorEx = new GeActorEx();
			if (geActorEx.Create(nResID, entityRoot, scene, iUnitId, isBattleActor, usePool, useCube))
			{
				this.m_ActorList.Add(geActorEx);
				return geActorEx;
			}
			return null;
		}

		// Token: 0x06008CB9 RID: 36025 RVA: 0x001A1D60 File Offset: 0x001A0160
		public GeActorEx AddActorAync(int nResID, GameObject entityRoot, GeSceneEx scene, int iUnitId, bool isBattleActor = true, bool usePool = true, PosLoadGeActorEx load = null)
		{
			GeActorEx geActorEx = new GeActorEx();
			geActorEx.CreateAsyncForTownNPC(nResID, entityRoot, scene, iUnitId, isBattleActor, usePool, load);
			this.m_ActorList.Add(geActorEx);
			return geActorEx;
		}

		// Token: 0x06008CBA RID: 36026 RVA: 0x001A1D94 File Offset: 0x001A0194
		public GeActorEx AddActorAyncEx(int nResID, GameObject entityRoot, GeSceneEx scene, int iUnitId, bool isBattleActor = true, bool usePool = true, PosLoadGeActorEx load = null)
		{
			GeActorEx geActorEx = new GeActorEx();
			if (null == entityRoot)
			{
				Logger.LogError("[GeActorEx] Entity root can not be null!");
				return null;
			}
			if (scene == null)
			{
				Logger.LogError("[GeActorEx] Entity scene can not be null!");
				return null;
			}
			if (geActorEx.CreateAsync(nResID, entityRoot, scene, iUnitId, load, isBattleActor, usePool, false))
			{
				this.m_ActorList.Add(geActorEx);
				return geActorEx;
			}
			return null;
		}

		// Token: 0x06008CBB RID: 36027 RVA: 0x001A1DF7 File Offset: 0x001A01F7
		public void RemoveActor(GeActorEx actor)
		{
			actor.Remove();
			this.bIsActorListDirty = true;
		}

		// Token: 0x06008CBC RID: 36028 RVA: 0x001A1E06 File Offset: 0x001A0206
		public void ClearAll()
		{
			this.m_ActorList.RemoveAll(delegate(GeActorEx a)
			{
				a.Destroy();
				return true;
			});
		}

		// Token: 0x06008CBD RID: 36029 RVA: 0x001A1E31 File Offset: 0x001A0231
		public void Update()
		{
			if (this.bIsActorListDirty)
			{
				this.m_ActorList.RemoveAll(delegate(GeActorEx a)
				{
					if (a.CanRemove())
					{
						a.Destroy();
						return true;
					}
					return false;
				});
				this.bIsActorListDirty = false;
			}
		}

		// Token: 0x170018A5 RID: 6309
		// (get) Token: 0x06008CBE RID: 36030 RVA: 0x001A1E6E File Offset: 0x001A026E
		public GeActorEx[] actorList
		{
			get
			{
				return this.m_ActorList.ToArray();
			}
		}

		// Token: 0x04004596 RID: 17814
		protected List<GeActorEx> m_ActorList = new List<GeActorEx>();

		// Token: 0x04004597 RID: 17815
		protected bool bIsActorListDirty;
	}

	// Token: 0x02000D8E RID: 3470
	private class CreateGeActorExData
	{
		// Token: 0x06008CC1 RID: 36033 RVA: 0x001A1E9A File Offset: 0x001A029A
		public CreateGeActorExData(int _nResID, int _iUintId, int _height, bool _isSceneObj, bool _isNeedChangeMaterial, bool _usePool)
		{
			this.nResID = _nResID;
			this.iUnitId = _iUintId;
			this.height = _height;
			this.isSceneObj = _isSceneObj;
			this.isNeedChangeMaterial = _isNeedChangeMaterial;
			this.usePool = _usePool;
		}

		// Token: 0x170018A6 RID: 6310
		// (get) Token: 0x06008CC2 RID: 36034 RVA: 0x001A1ECF File Offset: 0x001A02CF
		// (set) Token: 0x06008CC3 RID: 36035 RVA: 0x001A1ED7 File Offset: 0x001A02D7
		public int nResID { get; private set; }

		// Token: 0x170018A7 RID: 6311
		// (get) Token: 0x06008CC4 RID: 36036 RVA: 0x001A1EE0 File Offset: 0x001A02E0
		// (set) Token: 0x06008CC5 RID: 36037 RVA: 0x001A1EE8 File Offset: 0x001A02E8
		public int iUnitId { get; private set; }

		// Token: 0x170018A8 RID: 6312
		// (get) Token: 0x06008CC6 RID: 36038 RVA: 0x001A1EF1 File Offset: 0x001A02F1
		// (set) Token: 0x06008CC7 RID: 36039 RVA: 0x001A1EF9 File Offset: 0x001A02F9
		public int height { get; private set; }

		// Token: 0x170018A9 RID: 6313
		// (get) Token: 0x06008CC8 RID: 36040 RVA: 0x001A1F02 File Offset: 0x001A0302
		// (set) Token: 0x06008CC9 RID: 36041 RVA: 0x001A1F0A File Offset: 0x001A030A
		public bool isSceneObj { get; private set; }

		// Token: 0x170018AA RID: 6314
		// (get) Token: 0x06008CCA RID: 36042 RVA: 0x001A1F13 File Offset: 0x001A0313
		// (set) Token: 0x06008CCB RID: 36043 RVA: 0x001A1F1B File Offset: 0x001A031B
		public bool isNeedChangeMaterial { get; private set; }

		// Token: 0x170018AB RID: 6315
		// (get) Token: 0x06008CCC RID: 36044 RVA: 0x001A1F24 File Offset: 0x001A0324
		// (set) Token: 0x06008CCD RID: 36045 RVA: 0x001A1F2C File Offset: 0x001A032C
		public bool usePool { get; private set; }
	}

	// Token: 0x02000D8F RID: 3471
	private struct SceneColorDesc
	{
		// Token: 0x06008CCE RID: 36046 RVA: 0x001A1F35 File Offset: 0x001A0335
		public SceneColorDesc(Renderer render, int instanceID, Color col)
		{
			this.m_RenderInstanceID = instanceID;
			this.m_OriginColor = col;
			this.m_Renderer = render;
		}

		// Token: 0x040045A0 RID: 17824
		public Color m_OriginColor;

		// Token: 0x040045A1 RID: 17825
		public readonly int m_RenderInstanceID;

		// Token: 0x040045A2 RID: 17826
		public readonly Renderer m_Renderer;
	}

	// Token: 0x02000D90 RID: 3472
	private struct SceneColorTimeline
	{
		// Token: 0x06008CCF RID: 36047 RVA: 0x001A1F4C File Offset: 0x001A034C
		public SceneColorTimeline(float darkWeight, float timeTotal, float timeRemain, bool isRecover, bool isPlaying, bool isAlpha)
		{
			this.m_DarkWeight = darkWeight;
			this.m_TimeTotal = timeTotal;
			this.m_TimeRemain = timeRemain;
			this.m_IsRecover = isRecover;
			this.m_IsPlaying = isPlaying;
			this.m_IsAlpha = isAlpha;
		}

		// Token: 0x040045A3 RID: 17827
		public float m_DarkWeight;

		// Token: 0x040045A4 RID: 17828
		public float m_TimeTotal;

		// Token: 0x040045A5 RID: 17829
		public float m_TimeRemain;

		// Token: 0x040045A6 RID: 17830
		public bool m_IsRecover;

		// Token: 0x040045A7 RID: 17831
		public bool m_IsPlaying;

		// Token: 0x040045A8 RID: 17832
		public bool m_IsAlpha;
	}
}
