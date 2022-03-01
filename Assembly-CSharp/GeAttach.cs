using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using GameClient;
using GamePool;
using TMEngine.Runtime;
using UnityEngine;

// Token: 0x02000D17 RID: 3351
public class GeAttach
{
	// Token: 0x0600890B RID: 35083 RVA: 0x0018B638 File Offset: 0x00189A38
	public GeAttach(GameObject giveRoot)
	{
		if (GeAttach.<>f__mg$cache0 == null)
		{
			GeAttach.<>f__mg$cache0 = new OnAssetLoadSuccess(GeAttach._OnLoadAssetSuccess);
		}
		OnAssetLoadSuccess onSuccess = GeAttach.<>f__mg$cache0;
		if (GeAttach.<>f__mg$cache1 == null)
		{
			GeAttach.<>f__mg$cache1 = new OnAssetLoadFailure(GeAttach._OnLoadAssetFailure);
		}
		this.m_AssetLoadCallbacks = new AssetLoadCallbacks(onSuccess, GeAttach.<>f__mg$cache1);
		this.localVisible = true;
		this.m_PhaseMatSurfDescList = new List<GeAttach.PhaseMatSurfDesc>();
		this.m_PhaseCommand = default(GeAttach.PhaseCommandDesc);
		base..ctor();
		this.root = giveRoot;
		this.needDestroyRoot = false;
	}

	// Token: 0x0600890C RID: 35084 RVA: 0x0018B72C File Offset: 0x00189B2C
	public GeAttach(string name)
	{
		if (GeAttach.<>f__mg$cache2 == null)
		{
			GeAttach.<>f__mg$cache2 = new OnAssetLoadSuccess(GeAttach._OnLoadAssetSuccess);
		}
		OnAssetLoadSuccess onSuccess = GeAttach.<>f__mg$cache2;
		if (GeAttach.<>f__mg$cache3 == null)
		{
			GeAttach.<>f__mg$cache3 = new OnAssetLoadFailure(GeAttach._OnLoadAssetFailure);
		}
		this.m_AssetLoadCallbacks = new AssetLoadCallbacks(onSuccess, GeAttach.<>f__mg$cache3);
		this.localVisible = true;
		this.m_PhaseMatSurfDescList = new List<GeAttach.PhaseMatSurfDesc>();
		this.m_PhaseCommand = default(GeAttach.PhaseCommandDesc);
		base..ctor();
		this.name = name;
	}

	// Token: 0x0600890D RID: 35085 RVA: 0x0018B818 File Offset: 0x00189C18
	private static void _OnLoadAssetSuccess(string assetPath, object asset, int grpID, float duration, object userData)
	{
		if (userData == null)
		{
			TMDebug.LogErrorFormat("User data can not be null!", new object[0]);
			return;
		}
		GeAttach geAttach = userData as GeAttach;
		if (geAttach == null)
		{
			TMDebug.LogErrorFormat("User data type '{0}' is NOT GeAttach!", new object[0]);
			return;
		}
		GameObject gameObject = asset as GameObject;
		if (null == gameObject)
		{
			TMDebug.LogErrorFormat("Asset type '{0}' error!", new object[]
			{
				asset.GetType()
			});
			return;
		}
		if (AssetLoader.INVILID_HANDLE != geAttach.asyncReqHandle && grpID == (int)geAttach.asyncReqHandle)
		{
			geAttach._CreateImm(gameObject, geAttach.attachNode, geAttach.attachNodeName);
			geAttach.asyncReqHandle = AssetLoader.INVILID_HANDLE;
			return;
		}
		Object.Destroy(gameObject);
	}

	// Token: 0x0600890E RID: 35086 RVA: 0x0018B8CA File Offset: 0x00189CCA
	private static void _OnLoadAssetFailure(string assetPath, AssetLoadErrorCode errorCode, string errorMessage, object userData)
	{
		Logger.LogErrorFormat("[GeAttach]Load game object '{0}' has failed![Error:{1}]", new object[]
		{
			assetPath,
			errorMessage
		});
	}

	// Token: 0x0600890F RID: 35087 RVA: 0x0018B8E4 File Offset: 0x00189CE4
	public void UpdateAsync()
	{
		if (EngineConfig.useTMEngine)
		{
			return;
		}
		if (this._IsLoading() && Singleton<CGameObjectPool>.instance.IsRequestDone(this.asyncReqHandle))
		{
			GameObject gameObject = Singleton<CGameObjectPool>.instance.ExtractAsset(this.asyncReqHandle) as GameObject;
			if (null != gameObject)
			{
				this._CreateImm(gameObject, this.attachNode, this.attachNodeName);
			}
			this.asyncReqHandle = CGameObjectPool.INVILID_HANDLE;
		}
	}

	// Token: 0x17001848 RID: 6216
	// (get) Token: 0x06008910 RID: 35088 RVA: 0x0018B95C File Offset: 0x00189D5C
	public GameObject Root
	{
		get
		{
			return this.root;
		}
	}

	// Token: 0x17001849 RID: 6217
	// (get) Token: 0x06008911 RID: 35089 RVA: 0x0018B964 File Offset: 0x00189D64
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	// Token: 0x06008912 RID: 35090 RVA: 0x0018B96C File Offset: 0x00189D6C
	public void Destroy()
	{
		this.needDestroy = true;
		if (this._IsLoading())
		{
			if (EngineConfig.useTMEngine)
			{
				CGameObjectPool.AbortAcquireRequest(this.asyncReqHandle);
			}
			else
			{
				Singleton<CGameObjectPool>.instance.AbortRequest(this.asyncReqHandle);
			}
			this.asyncReqHandle = CGameObjectPool.INVILID_HANDLE;
		}
	}

	// Token: 0x1700184A RID: 6218
	// (get) Token: 0x06008913 RID: 35091 RVA: 0x0018B9C0 File Offset: 0x00189DC0
	public bool NeedDestroy
	{
		get
		{
			return this.needDestroy;
		}
	}

	// Token: 0x1700184B RID: 6219
	// (get) Token: 0x06008914 RID: 35092 RVA: 0x0018B9C8 File Offset: 0x00189DC8
	public bool IsCreate
	{
		get
		{
			return this.isCreate;
		}
	}

	// Token: 0x1700184C RID: 6220
	// (get) Token: 0x06008915 RID: 35093 RVA: 0x0018B9D0 File Offset: 0x00189DD0
	public string ResPath
	{
		get
		{
			return this.attachResPath;
		}
	}

	// Token: 0x1700184D RID: 6221
	// (get) Token: 0x06008916 RID: 35094 RVA: 0x0018B9D8 File Offset: 0x00189DD8
	public string AttachNodeName
	{
		get
		{
			return this.attachNodeName;
		}
	}

	// Token: 0x1700184E RID: 6222
	// (get) Token: 0x06008917 RID: 35095 RVA: 0x0018B9E0 File Offset: 0x00189DE0
	public GeAnimationManager AnimationManager
	{
		get
		{
			return this.animation;
		}
	}

	// Token: 0x06008918 RID: 35096 RVA: 0x0018B9E8 File Offset: 0x00189DE8
	public void Reset()
	{
		if (this.animation != null)
		{
			this.animation.Stop();
		}
		this.currentActionName = string.Empty;
		this.localVisible = true;
	}

	// Token: 0x06008919 RID: 35097 RVA: 0x0018BA14 File Offset: 0x00189E14
	public void Create(string attachRes, GameObject parent, string attachName, bool copyInPool = true, bool asyncLoad = true, bool highPriority = false)
	{
		this.needDestroy = false;
		if (this.isCreate)
		{
			if (attachName == this.attachNodeName && parent == this.attachNode && this.attachResPath == attachRes)
			{
				return;
			}
			this.DestroyImm();
		}
		this.actionFrame = Time.frameCount;
		this.actionOffset = 0f;
		uint num = (!copyInPool) ? 1U : 3U;
		num |= ((!highPriority) ? 0U : 16U);
		if (asyncLoad)
		{
			if (EngineConfig.useTMEngine)
			{
				if (AssetLoader.INVILID_HANDLE != this.asyncReqHandle)
				{
					CGameObjectPool.AbortAcquireRequest(this.asyncReqHandle);
				}
				this.asyncReqHandle = CGameObjectPool.GetGameObjectAsync(attachRes, this.m_AssetLoadCallbacks, this, num, 3452814099U);
			}
			else
			{
				if (CGameObjectPool.INVILID_HANDLE != this.asyncReqHandle)
				{
					Singleton<CGameObjectPool>.instance.AbortRequest(this.asyncReqHandle);
				}
				this.asyncReqHandle = Singleton<CGameObjectPool>.instance.GetGameObjectAsync(attachRes, enResourceType.BattleScene, num, 3452814099U);
			}
			this.attachNode = parent;
			this.attachNodeName = attachName;
		}
		else
		{
			GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject(attachRes, enResourceType.BattleScene, num);
			if (gameObject == null)
			{
				return;
			}
			this._CreateImm(gameObject, parent, attachName);
		}
		this.attachResPath = attachRes;
	}

	// Token: 0x0600891A RID: 35098 RVA: 0x0018BB64 File Offset: 0x00189F64
	public void DestroyImm()
	{
		if (this._IsLoading())
		{
			if (EngineConfig.useTMEngine)
			{
				CGameObjectPool.AbortAcquireRequest(this.asyncReqHandle);
			}
			else if (Singleton<CGameObjectPool>.instance != null)
			{
				Singleton<CGameObjectPool>.instance.AbortRequest(this.asyncReqHandle);
			}
			this.asyncReqHandle = CGameObjectPool.INVILID_HANDLE;
		}
		if (this.animation != null)
		{
			this.animation.Deinit();
		}
		this._ClearPhase();
		if (this.root && this.needDestroyRoot)
		{
			this.root.transform.SetParent(null, false);
			this.root.transform.position = Vector3.zero;
			this.root.transform.eulerAngles = Vector3.zero;
			this.root.transform.localPosition = Vector3.zero;
			this.root.transform.localEulerAngles = Vector3.zero;
			if (this.curlayer != 9)
			{
				this.SetLayer(9);
			}
			if (EngineConfig.useTMEngine)
			{
				CGameObjectPool.RecycleGameObjectEx(this.root);
			}
			else if (Singleton<CGameObjectPool>.instance != null)
			{
				Singleton<CGameObjectPool>.instance.RecycleGameObject(this.root);
			}
			this.root = null;
			this.attachNode = null;
			this.attachNodeName = string.Empty;
		}
		this.isCreate = false;
		this.needDestroy = false;
		this.m_ClearPhase = false;
		this.m_PhaseDirty = false;
		this.layerdirty = false;
		this.curlayer = 9;
	}

	// Token: 0x0600891B RID: 35099 RVA: 0x0018BCE5 File Offset: 0x0018A0E5
	public bool Rebind(GameObject parent)
	{
		if (parent != null && this.root != null)
		{
			this.root.transform.SetParent(parent.transform, false);
			this.attachNode = parent;
			return true;
		}
		return false;
	}

	// Token: 0x0600891C RID: 35100 RVA: 0x0018BD28 File Offset: 0x0018A128
	protected void _CreateImm(GameObject go, GameObject parent, string AttachName)
	{
		this.root = go;
		if (go == null || parent == null)
		{
			this.Destroy();
			return;
		}
		if (this.animation == null)
		{
			this.animation = new GeAnimationManager();
		}
		this.animation.Init(this.root);
		this.animation.PlayAction("Anim_Idle01", 1f, true, 0f);
		this.attachNode = parent;
		this.attachNodeName = AttachName;
		if (parent != null)
		{
			this.root.transform.SetParent(this.attachNode.transform, false);
		}
		if (this.layerdirty)
		{
			this.SetLayer(this.dstLayer);
			this.layerdirty = false;
		}
		if (!this.m_ClearPhase)
		{
			if (this.m_PhaseDirty)
			{
				this._ChangePhase(this.m_PhaseCommand.phaseEffect, this.m_PhaseCommand.phaseIdx, this.m_PhaseCommand.forceAdditive);
				this.m_PhaseDirty = false;
			}
		}
		else
		{
			this._ClearPhase();
			this.m_ClearPhase = false;
			this.m_PhaseDirty = false;
		}
		if (this.actionDirty)
		{
			this.actionDirty = false;
			if (this.actionName != null)
			{
				this.actionOffset = (float)(Time.frameCount - this.actionFrame) * Time.deltaTime;
				this.animation.PlayAction(this.actionName, this.actionSpeed, this.actionLoop, this.actionOffset);
			}
			else if (this.geAvatar != null)
			{
				this.animation.PlayAction(this.geAvatar.GetCurActionName(), this.geAvatar.GetCurActionSpeed(), this.geAvatar.GetCurActionLoop(), this.actionOffset + this.geAvatar.GetCurActionOffset());
			}
			this.geAvatar = null;
		}
		this.root.SetActive(this.localVisible);
		this.isCreate = true;
	}

	// Token: 0x0600891D RID: 35101 RVA: 0x0018BF1E File Offset: 0x0018A31E
	private bool _IsLoading()
	{
		return CGameObjectPool.INVILID_HANDLE != this.asyncReqHandle;
	}

	// Token: 0x0600891E RID: 35102 RVA: 0x0018BF30 File Offset: 0x0018A330
	public bool PlayAction(string name, float speed, bool loop = false, float offset = 0f)
	{
		this.actionFrame = Time.frameCount;
		if (this._IsLoading())
		{
			this.actionDirty = true;
			this.actionName = name;
			this.actionLoop = loop;
			this.actionSpeed = speed;
			this.actionOffset = offset;
			return true;
		}
		if (this.animation != null)
		{
			this.actionDirty = false;
			return this.animation.PlayAction(name, speed, loop, offset);
		}
		return false;
	}

	// Token: 0x0600891F RID: 35103 RVA: 0x0018BF9D File Offset: 0x0018A39D
	public void StopAction()
	{
		if (this.animation != null)
		{
			this.animation.Stop();
		}
	}

	// Token: 0x06008920 RID: 35104 RVA: 0x0018BFB5 File Offset: 0x0018A3B5
	public string GetCurActionName()
	{
		if (this.animation != null)
		{
			return this.animation.GetCurActionName();
		}
		return string.Empty;
	}

	// Token: 0x06008921 RID: 35105 RVA: 0x0018BFD3 File Offset: 0x0018A3D3
	public void SetBindingPose()
	{
	}

	// Token: 0x06008922 RID: 35106 RVA: 0x0018BFD5 File Offset: 0x0018A3D5
	public GameObject GetAttachModel()
	{
		return this.root;
	}

	// Token: 0x06008923 RID: 35107 RVA: 0x0018BFDD File Offset: 0x0018A3DD
	public void SetVisible(bool flag)
	{
		this.localVisible = flag;
		if (this.root != null)
		{
			this.root.SetActive(flag);
		}
	}

	// Token: 0x06008924 RID: 35108 RVA: 0x0018C004 File Offset: 0x0018A404
	public void SetLayer(int layer)
	{
		if (layer == this.curlayer)
		{
			return;
		}
		if (null == this.root)
		{
			if (!this._IsLoading())
			{
				return;
			}
			this.layerdirty = true;
			this.dstLayer = layer;
		}
		else
		{
			Renderer[] componentsInChildren;
			if (BeClientSwitch.FunctionIsOpen(ClientSwitchType.GeAttachSetLayerBug))
			{
				componentsInChildren = this.root.GetComponentsInChildren<Renderer>(true);
			}
			else
			{
				componentsInChildren = this.root.GetComponentsInChildren<Renderer>();
			}
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				componentsInChildren[i].gameObject.layer = layer;
				i++;
			}
			this.root.layer = layer;
			this.curlayer = layer;
			this.layerdirty = false;
			this.dstLayer = layer;
		}
	}

	// Token: 0x06008925 RID: 35109 RVA: 0x0018C0C4 File Offset: 0x0018A4C4
	public void ChangePhase(string phaseEffect, int phaseIdx, bool forceAddtive = false)
	{
		if (this.lastPhaseName.Equals(phaseEffect) && phaseIdx == this.lastPhaseLv)
		{
			return;
		}
		if (this._IsLoading())
		{
			this.m_PhaseCommand.phaseEffect = phaseEffect;
			this.m_PhaseCommand.phaseIdx = phaseIdx;
			this.m_PhaseCommand.forceAdditive = forceAddtive;
			this.m_ClearPhase = false;
			this.m_PhaseDirty = true;
		}
		else
		{
			this._ChangePhase(phaseEffect, phaseIdx, forceAddtive);
		}
	}

	// Token: 0x06008926 RID: 35110 RVA: 0x0018C13C File Offset: 0x0018A53C
	public void _FindChildren(string name, GameObject parent, ref List<GameObject> childList, bool includeInactive = false)
	{
		if (null == parent)
		{
			return;
		}
		Transform[] componentsInChildren = parent.GetComponentsInChildren<Transform>(includeInactive);
		int i = 0;
		int num = componentsInChildren.Length;
		while (i < num)
		{
			Transform transform = componentsInChildren[i];
			if (transform.name.TrimEnd(new char[0]) == name)
			{
				childList.Add(transform.gameObject);
			}
			i++;
		}
	}

	// Token: 0x06008927 RID: 35111 RVA: 0x0018C1A4 File Offset: 0x0018A5A4
	protected void _ChangePhase(string phaseEffect, int phaseIdx, bool forceAddtive = false)
	{
		if (null == this.root)
		{
			return;
		}
		MeshFilter componentInChildren = this.root.GetComponentInChildren<MeshFilter>();
		Mesh mesh = null;
		if (null != componentInChildren)
		{
			mesh = componentInChildren.mesh;
		}
		MeshRenderer meshRenderer = this.root.GetComponentInChildren<MeshRenderer>();
		if (null != meshRenderer && !meshRenderer.name.Contains("weapon", StringComparison.OrdinalIgnoreCase))
		{
			meshRenderer = null;
		}
		SkinnedMeshRenderer skinnedMeshRenderer = this.root.GetComponentInChildren<SkinnedMeshRenderer>();
		if (null != skinnedMeshRenderer && !skinnedMeshRenderer.name.Contains("weapon", StringComparison.OrdinalIgnoreCase))
		{
			skinnedMeshRenderer = null;
		}
		this.lastPhaseName = phaseEffect;
		this.lastPhaseLv = phaseIdx;
		if (!string.IsNullOrEmpty(phaseEffect) && phaseIdx > 0)
		{
			GePhaseStageDesc gePhaseStageDesc = Singleton<GePhaseEffect>.instance.CreatePhaseEffect(phaseEffect, phaseIdx - 1);
			if (gePhaseStageDesc != null)
			{
				GameObject gameObject = new GameObject("Eff");
				gameObject.layer = this.root.layer;
				gameObject.transform.SetParent(this.root.transform, false);
				List<GameObject> list = ListPool<GameObject>.Get();
				this._FindChildren("Eff_Glow", this.root, ref list, true);
				if (list.Count > 0)
				{
					int i = 0;
					int count = list.Count;
					while (i < count)
					{
						GameObject gameObject2 = list[i];
						if (gePhaseStageDesc.m_Glow)
						{
							if (!(null == gameObject2))
							{
								gameObject2.gameObject.SetActive(true);
								gePhaseStageDesc.m_GlowColor.a = 0.5f;
								List<MeshRenderer> list2 = ListPool<MeshRenderer>.Get();
								gameObject2.GetComponentsInChildren<MeshRenderer>(true, list2);
								int j = 0;
								int count2 = list2.Count;
								while (j < count2)
								{
									MeshRenderer meshRenderer2 = list2[j];
									if (!(null == meshRenderer2))
									{
										meshRenderer2.material.SetColor("_TintColor", gePhaseStageDesc.m_GlowColor);
										meshRenderer2.gameObject.layer = this.curlayer;
									}
									j++;
								}
								ListPool<MeshRenderer>.Release(list2);
								List<SkinnedMeshRenderer> list3 = ListPool<SkinnedMeshRenderer>.Get();
								gameObject2.GetComponentsInChildren<SkinnedMeshRenderer>(true, list3);
								int k = 0;
								int count3 = list3.Count;
								while (k < count3)
								{
									SkinnedMeshRenderer skinnedMeshRenderer2 = list3[k];
									if (!(null == skinnedMeshRenderer2))
									{
										skinnedMeshRenderer2.material.SetColor("_TintColor", gePhaseStageDesc.m_GlowColor);
										skinnedMeshRenderer2.gameObject.layer = this.curlayer;
									}
									k++;
								}
								ListPool<SkinnedMeshRenderer>.Release(list3);
							}
						}
						else
						{
							gameObject2.gameObject.SetActive(false);
						}
						i++;
					}
				}
				ListPool<GameObject>.Release(list);
				if (gePhaseStageDesc.m_Effectes != null)
				{
					int l = 0;
					int num = gePhaseStageDesc.m_Effectes.Length;
					while (l < num)
					{
						GameObject gameObject3 = gePhaseStageDesc.m_Effectes[l];
						if (!(null == gameObject3))
						{
							GameObject gameObject4 = Object.Instantiate<GameObject>(gameObject3);
							if (null != gameObject4)
							{
								Renderer[] componentsInChildren = gameObject4.GetComponentsInChildren<Renderer>();
								int m = 0;
								int num2 = componentsInChildren.Length;
								while (m < num2)
								{
									componentsInChildren[m].gameObject.layer = this.root.layer;
									m++;
								}
								ParticleSystem componentInChildren2 = gameObject4.GetComponentInChildren<ParticleSystem>();
								if (null != componentInChildren2)
								{
									ParticleSystem.ShapeModule shape = componentInChildren2.shape;
									if (shape.enabled && shape.shapeType == 6)
									{
										shape.mesh = mesh;
									}
									else
									{
										if (shape.enabled && null != meshRenderer)
										{
											shape.meshRenderer = meshRenderer;
											shape.shapeType = 13;
										}
										if (shape.enabled && null != skinnedMeshRenderer)
										{
											shape.skinnedMeshRenderer = skinnedMeshRenderer;
											shape.shapeType = 14;
										}
									}
									if (forceAddtive)
									{
										Renderer component = componentInChildren2.gameObject.GetComponent<Renderer>();
										Shader shader = AssetShaderLoader.Find("Particles/Additive");
										if (null != component && null != shader)
										{
											component.material.shader = shader;
										}
									}
									componentInChildren2.gameObject.layer = this.curlayer;
								}
							}
							gameObject4.SetActive(true);
							gameObject4.transform.SetParent(gameObject.transform, false);
						}
						l++;
					}
				}
				if (null != this.m_EffRoot)
				{
					this.m_EffRoot.transform.SetParent(null);
					Object.Destroy(this.m_EffRoot);
				}
				this.m_EffRoot = gameObject;
				Material material = gePhaseStageDesc.m_Material;
				if (null != material)
				{
					MeshRenderer[] componentsInChildren2 = this.root.GetComponentsInChildren<MeshRenderer>();
					for (int n = 0; n < componentsInChildren2.Length; n++)
					{
						if (!(null == componentsInChildren2[n]))
						{
							if (!componentsInChildren2[n].gameObject.CompareTag("EffectModel"))
							{
								Material[] materials = componentsInChildren2[n].materials;
								Material[] array = new Material[materials.Length];
								GeAttach.PhaseMatSurfDesc item = new GeAttach.PhaseMatSurfDesc(materials, componentsInChildren2[n]);
								for (int num3 = 0; num3 < materials.Length; num3++)
								{
									if (!(null == materials[num3]))
									{
										Material material2 = new Material(material);
										if (!(null == material2))
										{
											if (materials[num3].HasProperty("_MainTex"))
											{
												material2.SetTexture("_MainTex", materials[num3].GetTexture("_MainTex"));
											}
											if (materials[num3].HasProperty("_BumpMap"))
											{
												material2.SetTexture("_BumpMap", materials[num3].GetTexture("_BumpMap"));
											}
											if (materials[num3].HasProperty("_TintMap"))
											{
												material2.SetTexture("_TintMap", materials[num3].GetTexture("_TintMap"));
											}
											if (materials[num3].HasProperty("_Modify_Color"))
											{
												material2.SetColor("_Modify_Color", materials[num3].GetColor("_Modify_Color"));
											}
											if (materials[num3].HasProperty("_AmbientIntensity"))
											{
												material2.SetFloat("_AmbientIntensity", materials[num3].GetFloat("_AmbientIntensity"));
											}
											if (materials[num3].HasProperty("_LightIntensity"))
											{
												material2.SetFloat("_LightIntensity", materials[num3].GetFloat("_LightIntensity"));
											}
											array[num3] = material2;
										}
									}
								}
								componentsInChildren2[n].materials = array;
								this.m_PhaseMatSurfDescList.Add(item);
							}
						}
					}
					SkinnedMeshRenderer[] componentsInChildren3 = this.root.GetComponentsInChildren<SkinnedMeshRenderer>();
					for (int num4 = 0; num4 < componentsInChildren3.Length; num4++)
					{
						if (!(null == componentsInChildren3[num4]))
						{
							if (!componentsInChildren3[num4].gameObject.CompareTag("EffectModel"))
							{
								Material[] materials2 = componentsInChildren3[num4].materials;
								Material[] array2 = new Material[materials2.Length];
								GeAttach.PhaseMatSurfDesc item2 = new GeAttach.PhaseMatSurfDesc(materials2, componentsInChildren3[num4]);
								for (int num5 = 0; num5 < materials2.Length; num5++)
								{
									if (!(null == materials2[num5]))
									{
										Material material3 = new Material(material);
										if (!(null == material3))
										{
											if (materials2[num5].HasProperty("_MainTex"))
											{
												material3.SetTexture("_MainTex", materials2[num5].GetTexture("_MainTex"));
											}
											if (materials2[num5].HasProperty("_BumpMap"))
											{
												material3.SetTexture("_BumpMap", materials2[num5].GetTexture("_BumpMap"));
											}
											if (materials2[num5].HasProperty("_TintMap"))
											{
												material3.SetTexture("_TintMap", materials2[num5].GetTexture("_TintMap"));
											}
											if (materials2[num5].HasProperty("_Modify_Color"))
											{
												material3.SetColor("_Modify_Color", materials2[num5].GetColor("_Modify_Color"));
											}
											if (materials2[num5].HasProperty("_AmbientIntensity"))
											{
												material3.SetFloat("_AmbientIntensity", materials2[num5].GetFloat("_AmbientIntensity"));
											}
											if (materials2[num5].HasProperty("_LightIntensity"))
											{
												material3.SetFloat("_LightIntensity", materials2[num5].GetFloat("_LightIntensity"));
											}
											array2[num5] = material3;
										}
									}
								}
								componentsInChildren3[num4].materials = array2;
								this.m_PhaseMatSurfDescList.Add(item2);
							}
						}
					}
				}
			}
		}
		else
		{
			this._ClearPhase();
		}
	}

	// Token: 0x06008928 RID: 35112 RVA: 0x0018CA60 File Offset: 0x0018AE60
	protected void _ClearPhase()
	{
		if (this.root == null)
		{
			return;
		}
		List<GameObject> list = ListPool<GameObject>.Get();
		this._FindChildren("Eff_Glow", this.root, ref list, true);
		if (list.Count > 0)
		{
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				GameObject gameObject = list[i];
				if (!(null == gameObject))
				{
					gameObject.gameObject.SetActive(false);
				}
				i++;
			}
		}
		ListPool<GameObject>.Release(list);
		this.m_PhaseMatSurfDescList.RemoveAll(delegate(GeAttach.PhaseMatSurfDesc e)
		{
			if (null == e.m_MeshRenderer)
			{
				return true;
			}
			Material[] materials = e.m_MeshRenderer.materials;
			e.m_MeshRenderer.materials = e.m_OriginMatList;
			for (int j = 0; j < materials.Length; j++)
			{
				if (!(null == materials[j]))
				{
					Object.Destroy(materials[j]);
					materials[j] = null;
				}
			}
			return true;
		});
		if (null != this.m_EffRoot)
		{
			this.m_EffRoot.transform.SetParent(null);
			Object.Destroy(this.m_EffRoot);
			this.m_EffRoot = null;
		}
		this.lastPhaseLv = 0;
	}

	// Token: 0x06008929 RID: 35113 RVA: 0x0018CB50 File Offset: 0x0018AF50
	protected string GetGlowTexPath()
	{
		string text = this.attachResPath;
		text = Path.GetDirectoryName(text);
		int length = text.IndexOf("Prefab", StringComparison.CurrentCultureIgnoreCase);
		text = text.Substring(0, length);
		string text2 = Path.GetFileNameWithoutExtension(this.attachResPath);
		if (text2.StartsWith("P_"))
		{
			text2 = text2.Replace("P_", "T_");
		}
		else if (text2.StartsWith("p_"))
		{
			text2 = text2.Replace("p_", "T_");
		}
		else
		{
			text2 = "T_" + text2.Substring(2);
		}
		text2 = text2.Substring(0, text2.Length - 2) + "_glow";
		return text + "Textures/" + text2;
	}

	// Token: 0x0400428D RID: 17037
	public GameObject root;

	// Token: 0x0400428E RID: 17038
	public GeAvatar geAvatar;

	// Token: 0x0400428F RID: 17039
	protected string name = string.Empty;

	// Token: 0x04004290 RID: 17040
	protected string attachNodeName = string.Empty;

	// Token: 0x04004291 RID: 17041
	protected GameObject attachNode;

	// Token: 0x04004292 RID: 17042
	protected GeAnimationManager animation;

	// Token: 0x04004293 RID: 17043
	protected bool isCreate;

	// Token: 0x04004294 RID: 17044
	protected bool needDestroy;

	// Token: 0x04004295 RID: 17045
	protected string currentActionName = string.Empty;

	// Token: 0x04004296 RID: 17046
	protected string attachResPath = string.Empty;

	// Token: 0x04004297 RID: 17047
	public bool cached;

	// Token: 0x04004298 RID: 17048
	protected bool needDestroyRoot = true;

	// Token: 0x04004299 RID: 17049
	protected string lastPhaseName = string.Empty;

	// Token: 0x0400429A RID: 17050
	protected int lastPhaseLv;

	// Token: 0x0400429B RID: 17051
	protected int curlayer = 9;

	// Token: 0x0400429C RID: 17052
	protected int dstLayer = 9;

	// Token: 0x0400429D RID: 17053
	protected bool layerdirty;

	// Token: 0x0400429E RID: 17054
	protected bool actionDirty = true;

	// Token: 0x0400429F RID: 17055
	protected string actionName;

	// Token: 0x040042A0 RID: 17056
	protected bool actionLoop;

	// Token: 0x040042A1 RID: 17057
	protected float actionSpeed = 1f;

	// Token: 0x040042A2 RID: 17058
	protected float actionOffset;

	// Token: 0x040042A3 RID: 17059
	protected int actionFrame;

	// Token: 0x040042A4 RID: 17060
	protected uint asyncReqHandle = CGameObjectPool.INVILID_HANDLE;

	// Token: 0x040042A5 RID: 17061
	private AssetLoadCallbacks m_AssetLoadCallbacks;

	// Token: 0x040042A6 RID: 17062
	private bool localVisible;

	// Token: 0x040042A7 RID: 17063
	protected List<GeAttach.PhaseMatSurfDesc> m_PhaseMatSurfDescList;

	// Token: 0x040042A8 RID: 17064
	private GameObject m_EffRoot;

	// Token: 0x040042A9 RID: 17065
	private GeAttach.PhaseCommandDesc m_PhaseCommand;

	// Token: 0x040042AA RID: 17066
	private bool m_PhaseDirty;

	// Token: 0x040042AB RID: 17067
	private bool m_ClearPhase;

	// Token: 0x040042AC RID: 17068
	[CompilerGenerated]
	private static OnAssetLoadSuccess <>f__mg$cache0;

	// Token: 0x040042AD RID: 17069
	[CompilerGenerated]
	private static OnAssetLoadFailure <>f__mg$cache1;

	// Token: 0x040042AE RID: 17070
	[CompilerGenerated]
	private static OnAssetLoadSuccess <>f__mg$cache2;

	// Token: 0x040042AF RID: 17071
	[CompilerGenerated]
	private static OnAssetLoadFailure <>f__mg$cache3;

	// Token: 0x02000D18 RID: 3352
	protected class PhaseMatSurfDesc
	{
		// Token: 0x0600892B RID: 35115 RVA: 0x0018CC85 File Offset: 0x0018B085
		public PhaseMatSurfDesc(Material[] origMat, Renderer mr)
		{
			this.m_MeshRenderer = mr;
			this.m_OriginMatList = origMat;
		}

		// Token: 0x040042B1 RID: 17073
		public Renderer m_MeshRenderer;

		// Token: 0x040042B2 RID: 17074
		public Material[] m_OriginMatList;
	}

	// Token: 0x02000D19 RID: 3353
	protected struct PhaseCommandDesc
	{
		// Token: 0x040042B3 RID: 17075
		public string phaseEffect;

		// Token: 0x040042B4 RID: 17076
		public int phaseIdx;

		// Token: 0x040042B5 RID: 17077
		public bool forceAdditive;
	}
}
