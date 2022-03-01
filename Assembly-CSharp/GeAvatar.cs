using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMEngine.Runtime;
using UnityEngine;

// Token: 0x02000CDC RID: 3292
public class GeAvatar
{
	// Token: 0x0600870A RID: 34570 RVA: 0x0017BAD4 File Offset: 0x00179ED4
	public GeAvatar(bool enableAvatarPartFallback = false)
	{
		if (GeAvatar.<>f__mg$cache0 == null)
		{
			GeAvatar.<>f__mg$cache0 = new OnAssetLoadSuccess(GeAvatar._OnLoadAssetSuccess);
		}
		OnAssetLoadSuccess onSuccess = GeAvatar.<>f__mg$cache0;
		if (GeAvatar.<>f__mg$cache1 == null)
		{
			GeAvatar.<>f__mg$cache1 = new OnAssetLoadFailure(GeAvatar._OnLoadAssetFailure);
		}
		this.m_AssetLoadCallbacks = new AssetLoadCallbacks(onSuccess, GeAvatar.<>f__mg$cache1);
		this.savedInitAvatar = new Dictionary<int, DAssetObject>();
		this.m_bUsePool = true;
		this.m_LoadingCnt = -1;
		this.m_RenderMeshList = new List<GameObject>();
		this.m_Animation = new GeAnimationManager();
		this.m_Attachment = new GeAttachManager();
		this.m_ActorOccupation = -1;
		this.changeActionCommand = default(GeAvatar.ChangeActionCommand);
		this.changeAvatarCommand = new GeAvatar.ChangeAvatarCommand[8];
		this.changeLayerCommand = default(GeAvatar.ChangeLayerCommand);
		base..ctor();
		this._ResetAsyncCommads();
		this.m_AvatarDescList = new List<GeAvatar.GeAvatarDesc>(8);
		for (int i = 0; i < 8; i++)
		{
			this.m_AvatarDescList.Add(new GeAvatar.GeAvatarDesc((GeAvatarChannel)i));
		}
		this.m_AvatarRootDesc = new GeAvatar.GeAvatarDesc(GeAvatarChannel.AvatarRoot);
		this.m_EnableAvatarPartFallback = enableAvatarPartFallback;
	}

	// Token: 0x0600870B RID: 34571 RVA: 0x0017BBE0 File Offset: 0x00179FE0
	private static void _OnLoadAssetSuccess(string assetPath, object asset, int grpID, float duration, object userData)
	{
		if (userData == null)
		{
			TMDebug.LogErrorFormat("User data can not be null!", new object[0]);
			return;
		}
		GeAvatar geAvatar = userData as GeAvatar;
		if (geAvatar == null)
		{
			TMDebug.LogErrorFormat("User data type '{0}' is NOT GeAvatar!", new object[0]);
			return;
		}
		if (asset == null)
		{
			TMDebug.LogErrorFormat("Asset '{0}' load error!", new object[]
			{
				assetPath
			});
			return;
		}
		GameObject gameObject = asset as GameObject;
		if (null == gameObject)
		{
			TMDebug.LogErrorFormat("Asset '{0}' is nil or type '{1}' error!", new object[]
			{
				assetPath,
				asset.GetType()
			});
			return;
		}
		if (AssetLoader.INVILID_HANDLE != geAvatar.m_AvatarRootDesc.m_AsyncRequest && grpID == (int)geAvatar.m_AvatarRootDesc.m_AsyncRequest)
		{
			geAvatar.m_LoadingCnt--;
			gameObject.SetActive(false);
			geAvatar._OnAvatarRootLoaded(gameObject);
			geAvatar.m_AvatarRootDesc.m_AsyncRequest = AssetLoader.INVILID_HANDLE;
			return;
		}
		int i = 0;
		int count = geAvatar.m_AvatarDescList.Count;
		while (i < count)
		{
			GeAvatar.GeAvatarDesc geAvatarDesc = geAvatar.m_AvatarDescList[i];
			if (geAvatarDesc != null)
			{
				if (AssetLoader.INVILID_HANDLE != geAvatarDesc.m_AsyncRequest)
				{
					if (grpID == (int)geAvatarDesc.m_AsyncRequest)
					{
						geAvatar.m_LoadingCnt--;
						gameObject.SetActive(false);
						geAvatarDesc.m_MeshObject = gameObject;
						geAvatar._OnAvatarPartLoaded(geAvatarDesc);
						geAvatarDesc.m_AsyncRequest = AssetLoader.INVILID_HANDLE;
						return;
					}
				}
			}
			i++;
		}
		CGameObjectPool.RecycleGameObjectEx(gameObject);
	}

	// Token: 0x0600870C RID: 34572 RVA: 0x0017BD56 File Offset: 0x0017A156
	private static void _OnLoadAssetFailure(string assetPath, AssetLoadErrorCode errorCode, string errorMessage, object userData)
	{
	}

	// Token: 0x0600870D RID: 34573 RVA: 0x0017BD58 File Offset: 0x0017A158
	public void SetProfessionalId(int proId)
	{
		this.m_professionalId = proId;
	}

	// Token: 0x0600870E RID: 34574 RVA: 0x0017BD64 File Offset: 0x0017A164
	public bool Init(string avatarRes, int layer, bool usePool = true, bool asyncLoad = false, bool highPriority = false)
	{
		this._ResetAsyncCommads();
		this.m_AvatarBBox.extents = Vector3.zero;
		this.m_AvatarBBox.center = Vector3.zero;
		if (!string.IsNullOrEmpty(avatarRes))
		{
			if (null != this.m_AvatarRootDesc.m_MeshObject)
			{
				if (this.m_AvatarRootDesc.m_MeshRendererList != null)
				{
					int i = 0;
					int num = this.m_AvatarRootDesc.m_MeshRendererList.Length;
					while (i < num)
					{
						SkinnedMeshRenderer skinnedMeshRenderer = this.m_AvatarRootDesc.m_MeshRendererList[i];
						if (!(null == skinnedMeshRenderer))
						{
							skinnedMeshRenderer.gameObject.layer = this.m_AvatarRootDesc.m_OriginLayer;
						}
						i++;
					}
				}
				if (EngineConfig.useTMEngine)
				{
					CGameObjectPool.RecycleGameObjectEx(this.m_AvatarRootDesc.m_MeshObject);
				}
				else
				{
					global::AssetManager.RecycleAsset(this.m_AvatarRootDesc.m_MeshObject);
				}
				this.m_AvatarRootDesc.m_MeshObject = null;
			}
			this.m_bUsePool = usePool;
			this.m_AvatarRootDesc.m_Asset = new DAssetObject(null, avatarRes);
			this.m_RenderLayer = layer;
			this.m_IsAsyncLoad = asyncLoad;
			if (asyncLoad)
			{
				this.m_AvatarRootDesc.m_MeshObject = null;
				this.m_AvatarRootDesc.m_HasRemapSkeleton = false;
				this.m_AvatarRootDesc.m_MeshRendererList = null;
				this.m_AvatarRootDesc.m_SkeletonRoot = null;
				this.m_AvatarRootDesc.m_RendObjRoot = null;
				this.m_AvatarRootDesc.m_OriginLayer = 0;
				uint flag = (!highPriority) ? 1U : 17U;
				if (EngineConfig.useTMEngine)
				{
					if (AssetLoader.INVILID_HANDLE != this.m_AvatarRootDesc.m_AsyncRequest)
					{
						CGameObjectPool.AbortAcquireRequest(this.m_AvatarRootDesc.m_AsyncRequest);
						this.m_LoadingCnt--;
					}
					try
					{
						this.m_AvatarRootDesc.m_AsyncRequest = CGameObjectPool.GetGameObjectAsync(avatarRes, this.m_AssetLoadCallbacks, this, flag, 858049997U);
					}
					catch (Exception ex)
					{
						Logger.LogErrorFormat("Init avatar Async res {0} is error reason {1}", new object[]
						{
							avatarRes,
							ex.Message
						});
					}
				}
				else
				{
					if (AssetLoader.INVILID_HANDLE != this.m_AvatarRootDesc.m_AsyncRequest)
					{
						this.m_LoadingCnt--;
						global::AssetManager.AbortRequest(this.m_AvatarRootDesc.m_AsyncRequest);
					}
					this.m_AvatarRootDesc.m_AsyncRequest = global::AssetManager.LoadAssetRequest(avatarRes, typeof(GameObject), true, 1U, false, 858049997U);
				}
				if (AssetLoader.INVILID_HANDLE != this.m_AvatarRootDesc.m_AsyncRequest)
				{
					if (this.m_LoadingCnt == -1)
					{
						this.m_LoadingCnt = 0;
					}
					this.m_LoadingCnt++;
					return true;
				}
			}
			else
			{
				if (EngineConfig.useTMEngine)
				{
					try
					{
						this.m_AvatarRootDesc.m_MeshObject = CGameObjectPool.GetGameObject(avatarRes, 0U);
					}
					catch (Exception ex2)
					{
						Logger.LogErrorFormat("Init avatar MeshObject res {0} is error reason {1}", new object[]
						{
							avatarRes,
							ex2.Message
						});
					}
				}
				else
				{
					this.m_AvatarRootDesc.m_MeshObject = (global::AssetManager.LoadAsset(avatarRes, typeof(GameObject), true, 0U, false) as GameObject);
				}
				if (null != this.m_AvatarRootDesc.m_MeshObject)
				{
					this._OnAvatarRootLoaded(this.m_AvatarRootDesc.m_MeshObject);
					return true;
				}
			}
		}
		this.m_AvatarRootDesc.m_MeshObject = new GameObject("AvatarRoot");
		if (null != this.m_AvatarRootDesc.m_MeshObject)
		{
			this.m_SkeletonRoot = this.m_AvatarRootDesc.m_MeshObject;
			this.m_RenderLayer = layer;
			return true;
		}
		return false;
	}

	// Token: 0x0600870F RID: 34575 RVA: 0x0017C0F8 File Offset: 0x0017A4F8
	public void Deinit()
	{
		this.ClearAll();
		if (this.m_Animation != null)
		{
			this.m_Animation.Deinit();
			this.m_Animation = null;
		}
		if (this.m_Attachment != null)
		{
			this.m_Attachment.Deinit();
			this.m_Attachment = null;
		}
	}

	// Token: 0x06008710 RID: 34576 RVA: 0x0017C145 File Offset: 0x0017A545
	public bool IsLoadFinished()
	{
		return !this.m_IsAsyncLoad || 0 == this.m_LoadingCnt;
	}

	// Token: 0x06008711 RID: 34577 RVA: 0x0017C15E File Offset: 0x0017A55E
	public GameObject GetSkeletonRoot()
	{
		return this.m_SkeletonRoot;
	}

	// Token: 0x06008712 RID: 34578 RVA: 0x0017C166 File Offset: 0x0017A566
	public GameObject GetAvatarRoot()
	{
		return this.m_AvatarRootDesc.m_MeshObject;
	}

	// Token: 0x06008713 RID: 34579 RVA: 0x0017C174 File Offset: 0x0017A574
	public void ClearAll()
	{
		this.m_Attachment.ClearAll();
		if (this.m_AvatarDescList != null)
		{
			for (int i = 0; i < this.m_AvatarDescList.Count; i++)
			{
				GeAvatar.GeAvatarDesc geAvatarDesc = this.m_AvatarDescList[i];
				if (geAvatarDesc != null)
				{
					if (AssetLoader.INVILID_HANDLE != geAvatarDesc.m_AsyncRequest)
					{
						if (EngineConfig.useTMEngine)
						{
							CGameObjectPool.AbortAcquireRequest(geAvatarDesc.m_AsyncRequest);
						}
						else
						{
							global::AssetManager.AbortRequest(geAvatarDesc.m_AsyncRequest);
						}
						this.m_LoadingCnt--;
						geAvatarDesc.m_AsyncRequest = AssetLoader.INVILID_HANDLE;
					}
					if (null != geAvatarDesc.m_MeshObject)
					{
						SkinnedMeshRenderer[] meshRendererList = geAvatarDesc.m_MeshRendererList;
						if (meshRendererList != null)
						{
							for (int j = 0; j < meshRendererList.Length; j++)
							{
								if (null != meshRendererList[j])
								{
									meshRendererList[j].gameObject.SetActive(true);
									meshRendererList[j].gameObject.layer = geAvatarDesc.m_OriginLayer;
								}
							}
						}
						if (null != geAvatarDesc.m_SkeletonRoot)
						{
							geAvatarDesc.m_SkeletonRoot.SetActive(true);
						}
						if (null != geAvatarDesc.m_MeshObject)
						{
							geAvatarDesc.m_MeshObject.transform.SetParent(null, false);
							if (EngineConfig.useTMEngine)
							{
								CGameObjectPool.RecycleGameObjectEx(geAvatarDesc.m_MeshObject);
							}
							else
							{
								global::AssetManager.RecycleAsset(geAvatarDesc.m_MeshObject);
							}
							geAvatarDesc.m_MeshObject = null;
						}
						geAvatarDesc.m_MeshRendererList = null;
						geAvatarDesc.m_SkeletonRoot = null;
						geAvatarDesc.m_AvatarAttachment = null;
					}
				}
			}
		}
		if (AssetLoader.INVILID_HANDLE != this.m_AvatarRootDesc.m_AsyncRequest)
		{
			if (EngineConfig.useTMEngine)
			{
				CGameObjectPool.AbortAcquireRequest(this.m_AvatarRootDesc.m_AsyncRequest);
			}
			else
			{
				global::AssetManager.AbortRequest(this.m_AvatarRootDesc.m_AsyncRequest);
			}
			this.m_LoadingCnt--;
			this.m_AvatarRootDesc.m_AsyncRequest = AssetLoader.INVILID_HANDLE;
		}
		if (null != this.m_AvatarRootDesc.m_MeshObject)
		{
			this.m_AvatarRootDesc.m_MeshObject.layer = this.m_AvatarRootDesc.m_OriginLayer;
			if (this.m_AvatarRootDesc.m_MeshRendererList != null)
			{
				int k = 0;
				int num = this.m_AvatarRootDesc.m_MeshRendererList.Length;
				while (k < num)
				{
					SkinnedMeshRenderer skinnedMeshRenderer = this.m_AvatarRootDesc.m_MeshRendererList[k];
					if (!(null == skinnedMeshRenderer))
					{
						skinnedMeshRenderer.gameObject.layer = this.m_AvatarRootDesc.m_OriginLayer;
					}
					k++;
				}
			}
			if (EngineConfig.useTMEngine)
			{
				CGameObjectPool.RecycleGameObjectEx(this.m_AvatarRootDesc.m_MeshObject);
			}
			else
			{
				global::AssetManager.RecycleAsset(this.m_AvatarRootDesc.m_MeshObject);
			}
			this.m_AvatarRootDesc.m_MeshObject = null;
		}
		this.m_AvatarSkeleton = null;
		this.m_OnLoad = null;
		this._ResetAsyncCommads();
	}

	// Token: 0x06008714 RID: 34580 RVA: 0x0017C447 File Offset: 0x0017A847
	public void ChangeLayer(int layer)
	{
		if (null != this.m_AvatarRootDesc.m_MeshObject)
		{
			this._ChangeLayer(layer);
		}
		else
		{
			this.changeLayerCommand = new GeAvatar.ChangeLayerCommand(layer);
		}
	}

	// Token: 0x06008715 RID: 34581 RVA: 0x0017C478 File Offset: 0x0017A878
	protected void _ChangeLayer(int layer)
	{
		if (layer < 0 || layer > 31)
		{
			Debug.LogErrorFormat("Inivalid layer ID:{0}", new object[]
			{
				layer
			});
		}
		this.m_RenderLayer = layer;
		this.m_AvatarRootDesc.m_MeshObject.layer = this.m_RenderLayer;
		SkinnedMeshRenderer[] componentsInChildren = this.m_AvatarRootDesc.m_MeshObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		int i = 0;
		int num = componentsInChildren.Length;
		while (i < num)
		{
			if (null != componentsInChildren[i])
			{
				componentsInChildren[i].gameObject.SetLayer(layer);
			}
			i++;
		}
		MeshRenderer[] componentsInChildren2 = this.m_AvatarRootDesc.m_MeshObject.GetComponentsInChildren<MeshRenderer>();
		if (componentsInChildren2 != null)
		{
			int j = 0;
			int num2 = componentsInChildren2.Length;
			while (j < num2)
			{
				MeshRenderer meshRenderer = componentsInChildren2[j];
				if (!(null == meshRenderer))
				{
					meshRenderer.gameObject.layer = this.m_RenderLayer;
				}
				j++;
			}
		}
		ParticleSystem[] componentsInChildren3 = this.m_AvatarRootDesc.m_MeshObject.GetComponentsInChildren<ParticleSystem>();
		if (componentsInChildren3 != null)
		{
			int k = 0;
			int num3 = componentsInChildren3.Length;
			while (k < num3)
			{
				ParticleSystem particleSystem = componentsInChildren3[k];
				if (!(null == particleSystem))
				{
					particleSystem.gameObject.layer = this.m_RenderLayer;
				}
				k++;
			}
		}
	}

	// Token: 0x06008716 RID: 34582 RVA: 0x0017C5CC File Offset: 0x0017A9CC
	public void ChangeAvatarObject(GeAvatarChannel eChannel, DAssetObject asset, bool isAsyncLoad = true, bool highPriority = false, int prodId = 0)
	{
		if (null != this.m_AvatarRootDesc.m_MeshObject)
		{
			this._ChangeAvatarObject(eChannel, asset, isAsyncLoad, highPriority, prodId);
		}
		else
		{
			this.changeAvatarCommand[(int)eChannel] = new GeAvatar.ChangeAvatarCommand(eChannel, asset, isAsyncLoad, highPriority, prodId);
		}
	}

	// Token: 0x06008717 RID: 34583 RVA: 0x0017C620 File Offset: 0x0017AA20
	protected void _ChangeAvatarObject(GeAvatarChannel eChannel, DAssetObject asset, bool isAsyncLoad = true, bool highPriority = false, int prodId = 0)
	{
		if (this.m_professionalId != 0 && prodId != this.m_professionalId)
		{
			Logger.LogErrorFormat("try change avatar object channel {0} asset {1} curprodid {2} needprodid {3}", new object[]
			{
				eChannel,
				asset.m_AssetPath,
				this.m_professionalId,
				prodId
			});
			return;
		}
		if (!this.m_AvatarRootDesc.m_MeshObject)
		{
			return;
		}
		if (this.m_IsAsyncLoad)
		{
			isAsyncLoad = true;
		}
		if (eChannel < (GeAvatarChannel)this.m_AvatarDescList.Count)
		{
			GeAvatar.GeAvatarDesc geAvatarDesc = this.m_AvatarDescList[(int)eChannel];
			this._ClearAvatarMeshObject(geAvatarDesc);
			if (!string.IsNullOrEmpty(asset.m_AssetPath))
			{
				string text = asset.m_AssetPath;
				if (this.IsAvatarPartFallbackEnabled() && !GeAvatarFallback.IsAssetDependentAvaliable(text))
				{
					text = GeAvatarFallback.GetFallbackAvatar(this.m_ActorOccupation, eChannel, text);
					if (string.IsNullOrEmpty(text))
					{
						text = asset.m_AssetPath;
					}
				}
				if (isAsyncLoad)
				{
					geAvatarDesc.m_Asset = asset;
					geAvatarDesc.m_MeshObject = null;
					geAvatarDesc.m_HasRemapSkeleton = false;
					geAvatarDesc.m_AvatarAttachment = null;
					geAvatarDesc.m_MeshRendererList = null;
					geAvatarDesc.m_SkeletonRoot = null;
					geAvatarDesc.m_RendObjRoot = null;
					geAvatarDesc.m_OriginLayer = 0;
					if (this.m_LoadingCnt == -1)
					{
						this.m_LoadingCnt = 0;
					}
					this.m_IsAsyncLoad = true;
					this.m_LoadingCnt++;
					uint flag;
					if (this.m_bUsePool)
					{
						flag = ((!highPriority) ? 1U : 17U);
					}
					else
					{
						flag = ((!highPriority) ? 1U : 17U);
					}
					if (EngineConfig.useTMEngine)
					{
						if (AssetLoader.INVILID_HANDLE != geAvatarDesc.m_AsyncRequest)
						{
							this.m_LoadingCnt--;
							CGameObjectPool.AbortAcquireRequest(geAvatarDesc.m_AsyncRequest);
						}
						geAvatarDesc.m_AsyncRequest = CGameObjectPool.GetGameObjectAsync(text, this.m_AssetLoadCallbacks, this, 0U, 0U);
					}
					else
					{
						if (AssetLoader.INVILID_HANDLE != geAvatarDesc.m_AsyncRequest)
						{
							global::AssetManager.AbortRequest(geAvatarDesc.m_AsyncRequest);
							this.m_LoadingCnt--;
						}
						geAvatarDesc.m_AsyncRequest = global::AssetManager.LoadAssetRequest(text, typeof(GameObject), this.m_bUsePool, flag, false, 2916798995U);
					}
				}
				else
				{
					this.m_IsAsyncLoad = false;
					uint flag2 = (!this.m_bUsePool) ? 1U : 1U;
					if (EngineConfig.useTMEngine)
					{
						geAvatarDesc.m_MeshObject = CGameObjectPool.GetGameObject(text, 0U);
					}
					else
					{
						geAvatarDesc.m_MeshObject = (global::AssetManager.LoadAsset(text, typeof(GameObject), this.m_bUsePool, flag2, false) as GameObject);
					}
					if (geAvatarDesc != null && null != geAvatarDesc.m_MeshObject)
					{
						this._OnAvatarPartLoaded(geAvatarDesc);
					}
				}
			}
			else if (this.savedInitAvatar.ContainsKey((int)eChannel) && !string.IsNullOrEmpty(this.savedInitAvatar[(int)eChannel].m_AssetPath))
			{
				this.ChangeAvatarObject(eChannel, this.savedInitAvatar[(int)eChannel], isAsyncLoad, highPriority, prodId);
			}
		}
	}

	// Token: 0x06008718 RID: 34584 RVA: 0x0017C924 File Offset: 0x0017AD24
	public void SuitAvatar(bool isAsyncLoad = true, bool highPriority = false, int prodId = 0)
	{
		for (int i = 0; i < 8; i++)
		{
			GeAvatar.GeAvatarDesc geAvatarDesc = this.m_AvatarDescList[i];
			if (null == geAvatarDesc.m_MeshObject && AssetLoader.INVILID_HANDLE == geAvatarDesc.m_AsyncRequest && this.savedInitAvatar.ContainsKey(i) && !string.IsNullOrEmpty(this.savedInitAvatar[i].m_AssetPath))
			{
				this.ChangeAvatarObject((GeAvatarChannel)i, this.savedInitAvatar[i], isAsyncLoad, highPriority, prodId);
			}
		}
	}

	// Token: 0x06008719 RID: 34585 RVA: 0x0017C9B6 File Offset: 0x0017ADB6
	public void AddDefaultAvatar(GeAvatarChannel eChannel, DAssetObject asset)
	{
		if (eChannel == GeAvatarChannel.Headwear || eChannel == GeAvatarChannel.Bracelet)
		{
			return;
		}
		if (!this.savedInitAvatar.ContainsKey((int)eChannel))
		{
			this.savedInitAvatar.Add((int)eChannel, asset);
		}
	}

	// Token: 0x0600871A RID: 34586 RVA: 0x0017C9E8 File Offset: 0x0017ADE8
	public GeAttach CreateAttachment(string attachmentName, string attachRes, string attachNode, bool cached = false, bool asyncLoad = false, bool highPriority = false)
	{
		GeAttach geAttach = this.m_Attachment.AddAttachment(attachmentName, attachRes, attachNode, true, asyncLoad, highPriority);
		if (geAttach == null)
		{
			return null;
		}
		geAttach.geAvatar = this;
		this.m_Attachment.RefreshAttachNode(this.m_SkeletonRoot, false, false);
		if (cached)
		{
			geAttach.cached = true;
		}
		return geAttach;
	}

	// Token: 0x0600871B RID: 34587 RVA: 0x0017CA3A File Offset: 0x0017AE3A
	public void DestroyAttachment(GeAttach att)
	{
		this.m_Attachment.RemoveAttachment(att);
	}

	// Token: 0x0600871C RID: 34588 RVA: 0x0017CA48 File Offset: 0x0017AE48
	public GeAttach GetAttachment(string attach)
	{
		return this.m_Attachment.GetAttachment(attach, null);
	}

	// Token: 0x0600871D RID: 34589 RVA: 0x0017CA58 File Offset: 0x0017AE58
	public GameObject GetAttachNode(string attachNode)
	{
		return this.m_Attachment.GetAttchNodeDesc(attachNode).attachNode;
	}

	// Token: 0x0600871E RID: 34590 RVA: 0x0017CA79 File Offset: 0x0017AE79
	public void ClearAttachmentOnNode(string attachNode)
	{
		if (this.m_Attachment != null)
		{
			this.m_Attachment.ClearAttachmentOnNode(attachNode);
		}
	}

	// Token: 0x0600871F RID: 34591 RVA: 0x0017CA92 File Offset: 0x0017AE92
	public bool ChangeAction(string action, float speed, bool loop = false)
	{
		if (null != this.m_AvatarRootDesc.m_MeshObject)
		{
			return this._ChangeAction(action, speed, loop);
		}
		this.changeActionCommand = new GeAvatar.ChangeActionCommand(action, speed, loop);
		return true;
	}

	// Token: 0x06008720 RID: 34592 RVA: 0x0017CAC3 File Offset: 0x0017AEC3
	protected bool _ChangeAction(string action, float speed, bool loop = false)
	{
		if (this.m_Attachment != null)
		{
			this.m_Attachment.ChangeAction(action, speed, loop);
		}
		return this.m_Animation.PlayAction(action, speed, loop, 0f);
	}

	// Token: 0x06008721 RID: 34593 RVA: 0x0017CAF1 File Offset: 0x0017AEF1
	public string GetCurActionName()
	{
		if (this.m_Animation != null)
		{
			return this.m_Animation.GetCurActionName();
		}
		return string.Empty;
	}

	// Token: 0x06008722 RID: 34594 RVA: 0x0017CB0F File Offset: 0x0017AF0F
	public float GetCurActionOffset()
	{
		if (this.m_Animation != null)
		{
			return this.m_Animation.GetCurActionOffset();
		}
		return 0f;
	}

	// Token: 0x06008723 RID: 34595 RVA: 0x0017CB2D File Offset: 0x0017AF2D
	public bool GetCurActionLoop()
	{
		return this.m_Animation != null && this.m_Animation.IsCurActionLoop();
	}

	// Token: 0x06008724 RID: 34596 RVA: 0x0017CB47 File Offset: 0x0017AF47
	public float GetActionSpeed()
	{
		if (this.m_Animation != null)
		{
			return this.m_Animation.GetCurrentAnimationSpeed();
		}
		return 1f;
	}

	// Token: 0x06008725 RID: 34597 RVA: 0x0017CB65 File Offset: 0x0017AF65
	public void StopAction()
	{
		if (this.m_Animation != null)
		{
			this.m_Animation.Stop();
		}
		if (this.m_Attachment != null)
		{
			this.m_Attachment.StopAction();
		}
	}

	// Token: 0x06008726 RID: 34598 RVA: 0x0017CB93 File Offset: 0x0017AF93
	public bool IsActionFinished()
	{
		return this.m_Animation == null || this.m_Animation.IsCurAnimFinished();
	}

	// Token: 0x06008727 RID: 34599 RVA: 0x0017CBB0 File Offset: 0x0017AFB0
	public float GetActionTimeLen(string action)
	{
		if (this.m_Animation != null)
		{
			GeAnimDesc animClipDesc = this.m_Animation.GetAnimClipDesc(action);
			if (animClipDesc != null)
			{
				return animClipDesc.timeLen;
			}
		}
		return 0f;
	}

	// Token: 0x06008728 RID: 34600 RVA: 0x0017CBE8 File Offset: 0x0017AFE8
	public bool IsActionLoop(string action)
	{
		if (this.m_Animation != null)
		{
			GeAnimDesc animClipDesc = this.m_Animation.GetAnimClipDesc(action);
			if (animClipDesc != null)
			{
				return animClipDesc.animPlayMode == GeAnimClipPlayMode.AnimPlayLoop;
			}
		}
		return false;
	}

	// Token: 0x06008729 RID: 34601 RVA: 0x0017CC1E File Offset: 0x0017B01E
	public float GetCurActionSpeed()
	{
		if (this.m_Animation != null)
		{
			return this.m_Animation.GetCurrentAnimationSpeed();
		}
		return 1f;
	}

	// Token: 0x0600872A RID: 34602 RVA: 0x0017CC3C File Offset: 0x0017B03C
	public void PreloadAction(string anim)
	{
		if (this.m_Animation != null)
		{
			this.m_Animation.PreloadAction(anim);
		}
	}

	// Token: 0x0600872B RID: 34603 RVA: 0x0017CC55 File Offset: 0x0017B055
	public void PreloadAction(string[] animList)
	{
		if (this.m_Animation != null)
		{
			this.m_Animation.PreloadAction(animList);
		}
	}

	// Token: 0x0600872C RID: 34604 RVA: 0x0017CC6E File Offset: 0x0017B06E
	public string GetResPath()
	{
		return this.m_AvatarRootDesc.m_Asset.m_AssetPath;
	}

	// Token: 0x0600872D RID: 34605 RVA: 0x0017CC80 File Offset: 0x0017B080
	public void Update(int delta, uint mask = 4294967295U)
	{
		if (this.m_Attachment != null && (mask & 2U) != 0U)
		{
			this.m_Attachment.Update();
		}
	}

	// Token: 0x0600872E RID: 34606 RVA: 0x0017CCA0 File Offset: 0x0017B0A0
	public void Pause(uint mask = 4294967295U)
	{
		if ((mask & 1U) != 0U)
		{
			this.m_Animation.Pause();
		}
		if ((mask & 2U) != 0U)
		{
			this.m_Attachment.Pause();
		}
	}

	// Token: 0x0600872F RID: 34607 RVA: 0x0017CCC8 File Offset: 0x0017B0C8
	public void Resume(uint mask = 4294967295U)
	{
		if ((mask & 1U) != 0U)
		{
			this.m_Animation.Resume();
		}
		if ((mask & 2U) != 0U)
		{
			this.m_Attachment.Resume();
		}
	}

	// Token: 0x06008730 RID: 34608 RVA: 0x0017CCF0 File Offset: 0x0017B0F0
	public void Clear(uint mask = 3U)
	{
		if ((mask & 2U) != 0U)
		{
			this.m_Attachment.ClearAll();
		}
	}

	// Token: 0x06008731 RID: 34609 RVA: 0x0017CD08 File Offset: 0x0017B108
	public void UpdateAsyncLoading()
	{
		if (EngineConfig.useTMEngine)
		{
			return;
		}
		if (AssetLoader.INVILID_HANDLE != this.m_AvatarRootDesc.m_AsyncRequest && global::AssetManager.IsRequestDone(this.m_AvatarRootDesc.m_AsyncRequest))
		{
			this.m_LoadingCnt--;
			GameObject gameObject = global::AssetManager.ExtractAsset(this.m_AvatarRootDesc.m_AsyncRequest) as GameObject;
			this.m_AvatarRootDesc.m_AsyncRequest = AssetLoader.INVILID_HANDLE;
			if (null != gameObject)
			{
				this._OnAvatarRootLoaded(gameObject);
			}
		}
		int i = 0;
		int count = this.m_AvatarDescList.Count;
		while (i < count)
		{
			GeAvatar.GeAvatarDesc geAvatarDesc = this.m_AvatarDescList[i];
			if (geAvatarDesc != null)
			{
				if (AssetLoader.INVILID_HANDLE != geAvatarDesc.m_AsyncRequest)
				{
					if (global::AssetManager.IsRequestDone(geAvatarDesc.m_AsyncRequest))
					{
						this.m_LoadingCnt--;
						GameObject gameObject2 = global::AssetManager.ExtractAsset(geAvatarDesc.m_AsyncRequest) as GameObject;
						geAvatarDesc.m_AsyncRequest = AssetLoader.INVILID_HANDLE;
						if (null != gameObject2)
						{
							geAvatarDesc.m_MeshObject = gameObject2;
							this._OnAvatarPartLoaded(geAvatarDesc);
						}
					}
				}
			}
			i++;
		}
	}

	// Token: 0x06008732 RID: 34610 RVA: 0x0017CE34 File Offset: 0x0017B234
	public void SetAvatarVisible(bool visible)
	{
		int i = 0;
		int count = this.m_RenderMeshList.Count;
		while (i < count)
		{
			GameObject gameObject = this.m_RenderMeshList[i];
			if (!(null == gameObject))
			{
				gameObject.SetActive(visible);
			}
			i++;
		}
	}

	// Token: 0x06008733 RID: 34611 RVA: 0x0017CE84 File Offset: 0x0017B284
	private void _OnAvatarRootLoaded(GameObject go)
	{
		this.m_AvatarRootDesc.m_MeshObject = go;
		this.m_AvatarRootDesc.m_MeshObject.layer = this.m_RenderLayer;
		SkinnedMeshRenderer[] componentsInChildren = this.m_AvatarRootDesc.m_MeshObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		if (componentsInChildren != null)
		{
			this.m_AvatarRootDesc.m_MeshRendererList = componentsInChildren;
			this.m_AvatarRootDesc.m_OriginLayer = go.layer;
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = componentsInChildren[i];
				if (!(null == skinnedMeshRenderer))
				{
					skinnedMeshRenderer.gameObject.layer = this.m_RenderLayer;
				}
				i++;
			}
		}
		MeshRenderer[] componentsInChildren2 = this.m_AvatarRootDesc.m_MeshObject.GetComponentsInChildren<MeshRenderer>();
		if (componentsInChildren2 != null)
		{
			int j = 0;
			int num2 = componentsInChildren2.Length;
			while (j < num2)
			{
				MeshRenderer meshRenderer = componentsInChildren2[j];
				if (!(null == meshRenderer))
				{
					meshRenderer.gameObject.layer = this.m_RenderLayer;
				}
				j++;
			}
		}
		ParticleSystem[] componentsInChildren3 = this.m_AvatarRootDesc.m_MeshObject.GetComponentsInChildren<ParticleSystem>();
		if (componentsInChildren3 != null)
		{
			int k = 0;
			int num3 = componentsInChildren3.Length;
			while (k < num3)
			{
				ParticleSystem particleSystem = componentsInChildren3[k];
				if (!(null == particleSystem))
				{
					particleSystem.gameObject.layer = this.m_RenderLayer;
				}
				k++;
			}
		}
		this.m_SkeletonRoot = this._FindSkeletonRoot(this.m_AvatarRootDesc.m_MeshObject);
		if (null != this.m_SkeletonRoot)
		{
			this.m_AvatarSkeleton = this.m_AvatarRootDesc.m_MeshObject.transform.GetChild(0).GetComponentsInChildren<Transform>();
		}
		this.m_Animation.Init(this.m_AvatarRootDesc.m_MeshObject);
		this.m_Attachment.RefreshAttachNode(this.m_AvatarRootDesc.m_MeshObject, false, false);
		if (this.changeActionCommand.bVilad)
		{
			this._ChangeAction(this.changeActionCommand.strAction, this.changeActionCommand.fSpeed, this.changeActionCommand.bLoop);
			this.changeActionCommand.bVilad = false;
		}
		int l = 0;
		int num4 = 8;
		while (l < num4)
		{
			if (this.changeAvatarCommand[l].bVilad)
			{
				this._ChangeAvatarObject(this.changeAvatarCommand[l].eChannel, this.changeAvatarCommand[l].sAsset, this.changeAvatarCommand[l].bIsAsyncLoad, this.changeAvatarCommand[l].bHighPriority, this.changeAvatarCommand[l].prodid);
				this.changeAvatarCommand[l].bVilad = false;
			}
			l++;
		}
		if (this.changeLayerCommand.bVilad)
		{
			this._ChangeLayer(this.changeLayerCommand.nLayer);
			this.changeLayerCommand.bVilad = false;
		}
	}

	// Token: 0x06008734 RID: 34612 RVA: 0x0017D174 File Offset: 0x0017B574
	private void _OnAvatarPartLoaded(GeAvatar.GeAvatarDesc newAvatarDesc)
	{
		if (newAvatarDesc != null && null != newAvatarDesc.m_MeshObject)
		{
			newAvatarDesc.m_MeshObject.transform.localPosition = Vector3.zero;
			newAvatarDesc.m_MeshObject.layer = this.m_RenderLayer;
			if (null != this.m_AvatarRootDesc.m_MeshObject)
			{
				newAvatarDesc.m_MeshObject.transform.SetParent(this.m_AvatarRootDesc.m_MeshObject.transform, false);
			}
			newAvatarDesc.m_MeshRendererList = newAvatarDesc.m_MeshObject.GetComponentsInChildren<SkinnedMeshRenderer>();
			if (newAvatarDesc.m_MeshRendererList != null)
			{
				int i = 0;
				int num = newAvatarDesc.m_MeshRendererList.Length;
				while (i < num)
				{
					SkinnedMeshRenderer skinnedMeshRenderer = newAvatarDesc.m_MeshRendererList[i];
					if (!(skinnedMeshRenderer == null))
					{
						skinnedMeshRenderer.localBounds = new Bounds(new Vector3(0f, 0f, 0f), new Vector3(2f, 2f, 2f));
						GameObject gameObject = skinnedMeshRenderer.gameObject;
						if (!(null == gameObject))
						{
							newAvatarDesc.m_OriginLayer = gameObject.layer;
							gameObject.layer = this.m_RenderLayer;
						}
					}
					i++;
				}
			}
			if (null == newAvatarDesc.m_SkeletonRoot)
			{
				newAvatarDesc.m_SkeletonRoot = this.m_SkeletonRoot;
			}
			this._RemapSkeleton(newAvatarDesc);
			this.m_RenderMeshList.Clear();
			this.m_AvatarBBox.extents = Vector3.zero;
			this.m_AvatarBBox.center = Vector3.zero;
			int j = 0;
			int count = this.m_AvatarDescList.Count;
			while (j < count)
			{
				GeAvatar.GeAvatarDesc geAvatarDesc = this.m_AvatarDescList[j];
				if (geAvatarDesc != null && geAvatarDesc.m_MeshObject != null)
				{
					this.m_RenderMeshList.Add(geAvatarDesc.m_MeshObject);
				}
				j++;
			}
			newAvatarDesc.m_HasRemapSkeleton = true;
			if (this.m_OnLoad != null)
			{
				this.m_OnLoad(this);
			}
		}
	}

	// Token: 0x06008735 RID: 34613 RVA: 0x0017D374 File Offset: 0x0017B774
	private void _ClearAvatarMeshObject(GeAvatar.GeAvatarDesc avatarDesc)
	{
		if (null != avatarDesc.m_MeshObject)
		{
			SkinnedMeshRenderer[] meshRendererList = avatarDesc.m_MeshRendererList;
			if (meshRendererList != null)
			{
				for (int i = 0; i < meshRendererList.Length; i++)
				{
					if (null != meshRendererList[i])
					{
						meshRendererList[i].gameObject.SetActive(true);
						meshRendererList[i].gameObject.layer = avatarDesc.m_OriginLayer;
					}
				}
			}
			if (null != avatarDesc.m_SkeletonRoot)
			{
				avatarDesc.m_SkeletonRoot.SetActive(true);
			}
			avatarDesc.m_MeshObject.transform.SetParent(null, false);
			if (EngineConfig.useTMEngine)
			{
				CGameObjectPool.RecycleGameObjectEx(avatarDesc.m_MeshObject);
			}
			else
			{
				global::AssetManager.RecycleAsset(avatarDesc.m_MeshObject);
			}
			avatarDesc.m_MeshObject = null;
			avatarDesc.m_MeshRendererList = null;
			avatarDesc.m_SkeletonRoot = null;
			avatarDesc.m_HasRemapSkeleton = false;
			avatarDesc.m_RendObjRoot = null;
			avatarDesc.m_OriginLayer = 0;
		}
		if (AssetLoader.INVILID_HANDLE != avatarDesc.m_AsyncRequest)
		{
			if (EngineConfig.useTMEngine)
			{
				CGameObjectPool.AbortAcquireRequest(avatarDesc.m_AsyncRequest);
			}
			else
			{
				global::AssetManager.AbortRequest(avatarDesc.m_AsyncRequest);
			}
			this.m_LoadingCnt--;
			avatarDesc.m_AsyncRequest = AssetLoader.INVILID_HANDLE;
		}
	}

	// Token: 0x06008736 RID: 34614 RVA: 0x0017D4B0 File Offset: 0x0017B8B0
	private Transform _FindSkeletonBone(Transform[] skeleton, Transform bone)
	{
		if (skeleton != null && null != bone)
		{
			for (int i = 0; i < skeleton.Length; i++)
			{
				if (!(null == skeleton[i]))
				{
					if (skeleton[i].name == bone.name)
					{
						return skeleton[i];
					}
				}
			}
		}
		return null;
	}

	// Token: 0x06008737 RID: 34615 RVA: 0x0017D514 File Offset: 0x0017B914
	private void _RemapSkeleton(GeAvatar.GeAvatarDesc avatarDesc)
	{
		if (this.m_AvatarSkeleton == null && this.m_AvatarRootDesc != null && null != this.m_AvatarRootDesc.m_MeshObject && null != this.m_AvatarRootDesc.m_MeshObject.transform)
		{
			Transform child = this.m_AvatarRootDesc.m_MeshObject.transform.GetChild(0);
			if (null != child)
			{
				this.m_AvatarSkeleton = child.GetComponentsInChildren<Transform>();
			}
		}
		if (this.m_AvatarSkeleton == null)
		{
			Logger.LogError("Remap skeleton has failed cause avatar root is null!");
			return;
		}
		int num = this.m_AvatarSkeleton.Length;
		GeAvatarProxy component = avatarDesc.m_MeshObject.GetComponent<GeAvatarProxy>();
		if (null != component)
		{
			for (int i = 0; i < avatarDesc.m_MeshRendererList.Length; i++)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = avatarDesc.m_MeshRendererList[i];
				if (!(null == skinnedMeshRenderer))
				{
					Transform[] bones = skinnedMeshRenderer.bones;
					if (bones != null)
					{
						Transform[] array = new Transform[bones.Length];
						int j = 0;
						while (j < bones.Length)
						{
							if (i < component.skelRemapOffset.Length)
							{
								if (component.skelRemapOffset[i] + j < component.skelRemapTable.Length)
								{
									int num2 = component.skelRemapTable[component.skelRemapOffset[i] + j];
									if (0 <= num2 && num2 < num)
									{
										array[j] = this.m_AvatarSkeleton[num2];
										goto IL_1AA;
									}
								}
								goto IL_1A4;
							}
							Logger.LogErrorFormat("Avatar [{0}] mesh render [{1}] index is out of range!(current index:{2} map size:{3})", new object[]
							{
								this.m_AvatarRootDesc.m_Asset.m_AssetPath,
								avatarDesc.m_MeshObject.name,
								i,
								component.skelRemapOffset.Length
							});
							goto IL_1A4;
							IL_1AA:
							j++;
							continue;
							IL_1A4:
							array[j] = null;
							goto IL_1AA;
						}
						skinnedMeshRenderer.bones = array;
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < avatarDesc.m_MeshRendererList.Length; k++)
			{
				SkinnedMeshRenderer skinnedMeshRenderer2 = avatarDesc.m_MeshRendererList[k];
				if (!(skinnedMeshRenderer2 == null) && !(skinnedMeshRenderer2.sharedMesh == null))
				{
					for (int l = 0; l < skinnedMeshRenderer2.sharedMesh.subMeshCount; l++)
					{
						Transform[] bones2 = skinnedMeshRenderer2.bones;
						Transform[] array2 = new Transform[bones2.Length];
						for (int m = 0; m < bones2.Length; m++)
						{
							array2[m] = this._FindSkeletonBone(this.m_AvatarSkeleton, bones2[m]);
						}
						skinnedMeshRenderer2.bones = array2;
					}
				}
			}
		}
	}

	// Token: 0x06008738 RID: 34616 RVA: 0x0017D7B8 File Offset: 0x0017BBB8
	private GameObject _FindSkeletonRoot(GameObject parent)
	{
		if (null != parent && parent.name.ToLower().Contains("boneall"))
		{
			return parent;
		}
		int childCount = parent.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			GameObject gameObject = parent.transform.GetChild(i).gameObject;
			GameObject gameObject2 = this._FindSkeletonRoot(gameObject);
			if (null != gameObject2)
			{
				return gameObject2;
			}
		}
		return null;
	}

	// Token: 0x06008739 RID: 34617 RVA: 0x0017D838 File Offset: 0x0017BC38
	public void SetAmbientColor(Color color)
	{
		int i = 0;
		int count = this.m_RenderMeshList.Count;
		while (i < count)
		{
			GeAvatar.GeAvatarDesc geAvatarDesc = this.m_AvatarDescList[i];
			if (geAvatarDesc != null && geAvatarDesc.m_MeshRendererList != null)
			{
				int j = 0;
				int num = geAvatarDesc.m_MeshRendererList.Length;
				while (j < num)
				{
					SkinnedMeshRenderer skinnedMeshRenderer = geAvatarDesc.m_MeshRendererList[j];
					if (!(null == skinnedMeshRenderer))
					{
						Material[] materials = skinnedMeshRenderer.materials;
						if (materials != null)
						{
							int k = 0;
							int num2 = materials.Length;
							while (k < num2)
							{
								Material material = materials[k];
								if (!(null == material))
								{
									if (material.HasProperty("_AmbientColor"))
									{
										material.SetColor("_AmbientColor", color);
									}
								}
								k++;
							}
						}
					}
					j++;
				}
			}
			i++;
		}
	}

	// Token: 0x0600873A RID: 34618 RVA: 0x0017D928 File Offset: 0x0017BD28
	public void SetLoadCallback(OnAvatarLoaded onLoaded)
	{
		this.m_OnLoad = onLoaded;
	}

	// Token: 0x0600873B RID: 34619 RVA: 0x0017D931 File Offset: 0x0017BD31
	public void Rebind(GameObject skeletonRoot, bool needRebind = false)
	{
		if (this.m_Attachment != null)
		{
			this.m_Attachment.RefreshAttachNode(skeletonRoot, true, needRebind);
		}
		if (this.m_Animation != null)
		{
			this.m_Animation.Init(skeletonRoot);
		}
	}

	// Token: 0x0600873C RID: 34620 RVA: 0x0017D964 File Offset: 0x0017BD64
	public void ReplayAction()
	{
		if (this.m_Animation != null)
		{
			this.m_Animation.Replay();
		}
	}

	// Token: 0x0600873D RID: 34621 RVA: 0x0017D97C File Offset: 0x0017BD7C
	public GameObject GetAttchNodeDescWithRareName(string nodeRareName)
	{
		if (this.m_Attachment != null)
		{
			return this.m_Attachment.GetAttchNodeDescWithRareName(nodeRareName);
		}
		return null;
	}

	// Token: 0x0600873E RID: 34622 RVA: 0x0017D997 File Offset: 0x0017BD97
	private bool _IsRootOK()
	{
		return this.m_AvatarRootDesc != null && null != this.m_AvatarRootDesc.m_MeshObject;
	}

	// Token: 0x1700181B RID: 6171
	// (get) Token: 0x0600873F RID: 34623 RVA: 0x0017D9B7 File Offset: 0x0017BDB7
	public Bounds boundingBox
	{
		get
		{
			return this.m_AvatarBBox;
		}
	}

	// Token: 0x1700181C RID: 6172
	// (get) Token: 0x06008740 RID: 34624 RVA: 0x0017D9BF File Offset: 0x0017BDBF
	public GameObject[] suitPartModel
	{
		get
		{
			return this.m_RenderMeshList.ToArray();
		}
	}

	// Token: 0x1700181D RID: 6173
	// (get) Token: 0x06008741 RID: 34625 RVA: 0x0017D9CC File Offset: 0x0017BDCC
	// (set) Token: 0x06008742 RID: 34626 RVA: 0x0017D9D4 File Offset: 0x0017BDD4
	public bool airMode
	{
		get
		{
			return this.m_AirMode;
		}
		set
		{
			this.m_AirMode = value;
			if (this.m_Attachment != null)
			{
				this.m_Attachment.airMode = this.m_AirMode;
			}
		}
	}

	// Token: 0x06008743 RID: 34627 RVA: 0x0017D9F9 File Offset: 0x0017BDF9
	public void SetSkeletonRoot(GameObject root)
	{
		this.m_SkeletonRoot = root;
	}

	// Token: 0x1700181E RID: 6174
	// (get) Token: 0x06008744 RID: 34628 RVA: 0x0017DA02 File Offset: 0x0017BE02
	public bool EnableAvatarPartFallback
	{
		get
		{
			return this.m_EnableAvatarPartFallback;
		}
	}

	// Token: 0x1700181F RID: 6175
	// (get) Token: 0x06008745 RID: 34629 RVA: 0x0017DA0A File Offset: 0x0017BE0A
	// (set) Token: 0x06008746 RID: 34630 RVA: 0x0017DA12 File Offset: 0x0017BE12
	public int ActorOccupation
	{
		get
		{
			return this.m_ActorOccupation;
		}
		set
		{
			this.m_ActorOccupation = value;
		}
	}

	// Token: 0x06008747 RID: 34631 RVA: 0x0017DA1B File Offset: 0x0017BE1B
	public bool IsAvatarPartFallbackEnabled()
	{
		return this.EnableAvatarPartFallback && GeAvatarFallback.IsAvatarPartFallbackEnabled();
	}

	// Token: 0x06008748 RID: 34632 RVA: 0x0017DA30 File Offset: 0x0017BE30
	protected void _ResetAsyncCommads()
	{
		this.changeActionCommand.bVilad = false;
		int i = 0;
		int num = 8;
		while (i < num)
		{
			this.changeAvatarCommand[i].bVilad = false;
			i++;
		}
		this.changeLayerCommand.bVilad = false;
	}

	// Token: 0x040040E3 RID: 16611
	private AssetLoadCallbacks m_AssetLoadCallbacks;

	// Token: 0x040040E4 RID: 16612
	private bool m_AirMode;

	// Token: 0x040040E5 RID: 16613
	private Dictionary<int, DAssetObject> savedInitAvatar;

	// Token: 0x040040E6 RID: 16614
	private bool m_IsAsyncLoad;

	// Token: 0x040040E7 RID: 16615
	private bool m_bUsePool;

	// Token: 0x040040E8 RID: 16616
	private int m_LoadingCnt;

	// Token: 0x040040E9 RID: 16617
	protected readonly GeAvatar.GeAvatarDesc m_AvatarRootDesc;

	// Token: 0x040040EA RID: 16618
	protected readonly List<GeAvatar.GeAvatarDesc> m_AvatarDescList;

	// Token: 0x040040EB RID: 16619
	protected readonly List<GameObject> m_RenderMeshList;

	// Token: 0x040040EC RID: 16620
	protected GameObject m_SkeletonRoot;

	// Token: 0x040040ED RID: 16621
	protected Transform[] m_AvatarSkeleton;

	// Token: 0x040040EE RID: 16622
	protected int m_RenderLayer;

	// Token: 0x040040EF RID: 16623
	protected GeAnimationManager m_Animation;

	// Token: 0x040040F0 RID: 16624
	protected GeAttachManager m_Attachment;

	// Token: 0x040040F1 RID: 16625
	protected Bounds m_AvatarBBox;

	// Token: 0x040040F2 RID: 16626
	protected int m_professionalId;

	// Token: 0x040040F3 RID: 16627
	protected readonly bool m_EnableAvatarPartFallback;

	// Token: 0x040040F4 RID: 16628
	protected int m_ActorOccupation;

	// Token: 0x040040F5 RID: 16629
	private OnAvatarLoaded m_OnLoad;

	// Token: 0x040040F6 RID: 16630
	private GeAvatar.ChangeActionCommand changeActionCommand;

	// Token: 0x040040F7 RID: 16631
	private GeAvatar.ChangeAvatarCommand[] changeAvatarCommand;

	// Token: 0x040040F8 RID: 16632
	private GeAvatar.ChangeLayerCommand changeLayerCommand;

	// Token: 0x040040F9 RID: 16633
	[CompilerGenerated]
	private static OnAssetLoadSuccess <>f__mg$cache0;

	// Token: 0x040040FA RID: 16634
	[CompilerGenerated]
	private static OnAssetLoadFailure <>f__mg$cache1;

	// Token: 0x02000CDD RID: 3293
	public enum EAvatarRes
	{
		// Token: 0x040040FC RID: 16636
		Action = 1,
		// Token: 0x040040FD RID: 16637
		Attach,
		// Token: 0x040040FE RID: 16638
		All
	}

	// Token: 0x02000CDE RID: 3294
	protected class GeAvatarDesc
	{
		// Token: 0x06008749 RID: 34633 RVA: 0x0017DA7B File Offset: 0x0017BE7B
		public GeAvatarDesc(GeAvatarChannel channel)
		{
			this.m_Asset.m_AssetObj = null;
			this.m_Asset.m_AssetPath = string.Empty;
		}

		// Token: 0x040040FF RID: 16639
		public uint m_AsyncRequest = AssetLoader.INVILID_HANDLE;

		// Token: 0x04004100 RID: 16640
		public DAssetObject m_Asset;

		// Token: 0x04004101 RID: 16641
		public GameObject m_MeshObject;

		// Token: 0x04004102 RID: 16642
		public GameObject m_SkeletonRoot;

		// Token: 0x04004103 RID: 16643
		public SkinnedMeshRenderer[] m_MeshRendererList;

		// Token: 0x04004104 RID: 16644
		public GeAvatarAttachment m_AvatarAttachment;

		// Token: 0x04004105 RID: 16645
		public bool m_HasRemapSkeleton;

		// Token: 0x04004106 RID: 16646
		public int m_OriginLayer;

		// Token: 0x04004107 RID: 16647
		public Transform m_RendObjRoot;
	}

	// Token: 0x02000CDF RID: 3295
	private struct ChangeActionCommand
	{
		// Token: 0x0600874A RID: 34634 RVA: 0x0017DAAA File Offset: 0x0017BEAA
		public ChangeActionCommand(string action, float speed, bool loop = false)
		{
			this.strAction = action;
			this.fSpeed = speed;
			this.bLoop = loop;
			this.bVilad = true;
		}

		// Token: 0x04004108 RID: 16648
		public string strAction;

		// Token: 0x04004109 RID: 16649
		public float fSpeed;

		// Token: 0x0400410A RID: 16650
		public bool bLoop;

		// Token: 0x0400410B RID: 16651
		public bool bVilad;
	}

	// Token: 0x02000CE0 RID: 3296
	private struct ChangeAvatarCommand
	{
		// Token: 0x0600874B RID: 34635 RVA: 0x0017DAC8 File Offset: 0x0017BEC8
		public ChangeAvatarCommand(GeAvatarChannel channel, DAssetObject asset, bool asyncLoad, bool highPriority, int prodId)
		{
			this.eChannel = channel;
			this.sAsset = asset;
			this.bIsAsyncLoad = asyncLoad;
			this.bHighPriority = highPriority;
			this.bVilad = true;
			this.prodid = prodId;
		}

		// Token: 0x0400410C RID: 16652
		public GeAvatarChannel eChannel;

		// Token: 0x0400410D RID: 16653
		public DAssetObject sAsset;

		// Token: 0x0400410E RID: 16654
		public bool bIsAsyncLoad;

		// Token: 0x0400410F RID: 16655
		public bool bHighPriority;

		// Token: 0x04004110 RID: 16656
		public bool bVilad;

		// Token: 0x04004111 RID: 16657
		public int prodid;
	}

	// Token: 0x02000CE1 RID: 3297
	private struct ChangeLayerCommand
	{
		// Token: 0x0600874C RID: 34636 RVA: 0x0017DAF6 File Offset: 0x0017BEF6
		public ChangeLayerCommand(int layer)
		{
			this.nLayer = layer;
			this.bVilad = true;
		}

		// Token: 0x04004112 RID: 16658
		public int nLayer;

		// Token: 0x04004113 RID: 16659
		public bool bVilad;
	}
}
