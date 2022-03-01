using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using GamePool;
using TMEngine.Runtime;
using TMEngine.Runtime.Unity;
using UnityEngine;

// Token: 0x0200024A RID: 586
public sealed class CGameObjectPool : Singleton<CGameObjectPool>
{
	// Token: 0x06001328 RID: 4904 RVA: 0x00066F30 File Offset: 0x00065330
	public CGameObjectPool()
	{
		if (CGameObjectPool.<>f__mg$cache0 == null)
		{
			CGameObjectPool.<>f__mg$cache0 = new OnAssetLoadSuccess(CGameObjectPool._OnLoadAssetSuccess);
		}
		OnAssetLoadSuccess onSuccess = CGameObjectPool.<>f__mg$cache0;
		if (CGameObjectPool.<>f__mg$cache1 == null)
		{
			CGameObjectPool.<>f__mg$cache1 = new OnAssetLoadFailure(CGameObjectPool._OnLoadAssetFailure);
		}
		this.m_AssetLoadCallbacks = new AssetLoadCallbacks(onSuccess, CGameObjectPool.<>f__mg$cache1);
		this.m_GameObjectRequestCache = new List<CGameObjectPool.GameObjectRequestCache>();
		this.m_AsyncReqList = new List<CGameObjectPool.GameObjPoolAsyncRequest>();
		this.m_HighPriorityAsyncReqList = new List<CGameObjectPool.GameObjPoolAsyncRequest>();
		this.m_IdleReqPool = new List<CGameObjectPool.GameObjPoolAsyncRequest>();
		this.m_CompleteList = new List<CGameObjectPool.GameObjPoolAsyncRequest>();
		this.m_AsyncRequestHandleAlloc = new AsyncRequestHandleAllocator<IAsyncLoadRequest<Object>>(1U);
		base..ctor();
	}

	// Token: 0x06001329 RID: 4905 RVA: 0x00066FDD File Offset: 0x000653DD
	private static ITMUnityGameObjectPool _GetGameObjectPool()
	{
		if (CGameObjectPool.m_GameObjectPool == null)
		{
			CGameObjectPool.m_GameObjectPool = ModuleManager.GetModule<ITMUnityGameObjectPool>();
		}
		return CGameObjectPool.m_GameObjectPool;
	}

	// Token: 0x0600132A RID: 4906 RVA: 0x00066FF8 File Offset: 0x000653F8
	private static GameObject _GetGameObject_TMEngine(string prefabFullPath, uint poolFlag)
	{
		ITMUnityGameObjectPool itmunityGameObjectPool = CGameObjectPool._GetGameObjectPool();
		GameObject result = null;
		if (itmunityGameObjectPool != null)
		{
			result = itmunityGameObjectPool.AcquireGameObjectSync(prefabFullPath, 0U);
		}
		return result;
	}

	// Token: 0x0600132B RID: 4907 RVA: 0x00067020 File Offset: 0x00065420
	private static uint _GetGameObjectAsync_TMEngine(string prefabFullPath, AssetLoadCallbacks callbacks, object userData, uint poolFlag, uint waterMark = 0U)
	{
		ITMUnityGameObjectPool itmunityGameObjectPool = CGameObjectPool._GetGameObjectPool();
		if (itmunityGameObjectPool != null)
		{
			return (uint)itmunityGameObjectPool.AcquireGameObjectAsync(prefabFullPath, userData, callbacks, 0U);
		}
		return uint.MaxValue;
	}

	// Token: 0x0600132C RID: 4908 RVA: 0x00067048 File Offset: 0x00065448
	private static void _RecycleGameObject_TMEngine(GameObject gameObject)
	{
		ITMUnityGameObjectPool itmunityGameObjectPool = CGameObjectPool._GetGameObjectPool();
		if (itmunityGameObjectPool != null)
		{
			itmunityGameObjectPool.RecycleGameObject(gameObject);
			return;
		}
		Object.Destroy(gameObject);
	}

	// Token: 0x0600132D RID: 4909 RVA: 0x0006706F File Offset: 0x0006546F
	public static GameObject GetGameObject(string prefabFullPath, uint poolFlag)
	{
		return CGameObjectPool._GetGameObject_TMEngine(prefabFullPath, poolFlag);
	}

	// Token: 0x0600132E RID: 4910 RVA: 0x00067078 File Offset: 0x00065478
	public static uint GetGameObjectAsync(string path, AssetLoadCallbacks callbacks, object userData, uint flag = 0U, uint waterMark = 0U)
	{
		return CGameObjectPool._GetGameObjectAsync_TMEngine(path, callbacks, userData, flag, waterMark);
	}

	// Token: 0x0600132F RID: 4911 RVA: 0x00067085 File Offset: 0x00065485
	public static void RecycleGameObjectEx(GameObject gameObject)
	{
		CGameObjectPool._RecycleGameObject_TMEngine(gameObject);
	}

	// Token: 0x06001330 RID: 4912 RVA: 0x0006708D File Offset: 0x0006548D
	public static void AbortAcquireRequest(uint handle)
	{
	}

	// Token: 0x06001331 RID: 4913 RVA: 0x00067090 File Offset: 0x00065490
	private static void _OnLoadAssetSuccess(string assetPath, object asset, int grpID, float duration, object userData)
	{
		CGameObjectPool.GameObjectLoadContext gameObjectLoadContext = userData as CGameObjectPool.GameObjectLoadContext;
		if (gameObjectLoadContext != null)
		{
			GameObject gameObject = asset as GameObject;
			if (null != gameObject)
			{
				IPooledMonoBehaviour[] pooledMonoBehaviours = gameObjectLoadContext.m_This.GetPooledMonoBehaviours(gameObject);
				CPooledGameObjectScript cpooledGameObjectScript = gameObject.GetComponent<CPooledGameObjectScript>();
				if (cpooledGameObjectScript == null)
				{
					cpooledGameObjectScript = gameObject.AddComponent<CPooledGameObjectScript>();
				}
				cpooledGameObjectScript.m_prefabKey = gameObjectLoadContext.m_PrefabKey;
				cpooledGameObjectScript.m_pooledMonoBehaviours = pooledMonoBehaviours;
				cpooledGameObjectScript.m_defaultScale = cpooledGameObjectScript.transform.localScale;
				cpooledGameObjectScript.m_isInit = true;
				cpooledGameObjectScript.m_IsRecycled = false;
				cpooledGameObjectScript.m_IsOriginInVisible = !cpooledGameObjectScript.gameObject.activeSelf;
				gameObjectLoadContext.m_This.HandlePooledMonoBehaviour(cpooledGameObjectScript.m_pooledMonoBehaviours, CGameObjectPool.enPooledMonoBehaviourAction.Create);
				if (gameObjectLoadContext.m_CallerCallbacks != null && gameObjectLoadContext.m_CallerCallbacks.OnAssetLoadSuccess != null)
				{
					gameObjectLoadContext.m_CallerCallbacks.OnAssetLoadSuccess(gameObjectLoadContext.m_AssetPath, gameObject, (int)gameObjectLoadContext.m_RequestID, duration, gameObjectLoadContext.m_UserData);
				}
			}
			else
			{
				TMDebug.LogErrorFormat("Game object is null when load game object '{0}'!", new object[]
				{
					assetPath
				});
			}
		}
		else
		{
			TMDebug.LogErrorFormat("Game object load context type error when callback with game object '{0}'!", new object[]
			{
				assetPath
			});
		}
	}

	// Token: 0x06001332 RID: 4914 RVA: 0x000671B0 File Offset: 0x000655B0
	private static void _OnLoadAssetFailure(string assetPath, AssetLoadErrorCode errorCode, string errorMessage, object userData)
	{
	}

	// Token: 0x06001333 RID: 4915 RVA: 0x000671B4 File Offset: 0x000655B4
	public uint GetGameObjectAsync_TMEngine(string prefabFullPath, AssetLoadCallbacks callbacks, object userData, enResourceType resourceType, uint poolFlag, uint waterMark = 0U)
	{
		if (callbacks == null)
		{
			TMDebug.LogErrorFormat("Asset load callbacks can not be null on get game object '{0}'!", new object[]
			{
				prefabFullPath
			});
			return uint.MaxValue;
		}
		string text = CFileManager.EraseExtension(prefabFullPath);
		Queue<CPooledGameObjectScript> queue = null;
		if (!this.m_pooledGameObjectMap.TryGetValue(text, out queue))
		{
			queue = new Queue<CPooledGameObjectScript>();
			this.m_pooledGameObjectMap.Add(text, queue);
		}
		CPooledGameObjectScript cpooledGameObjectScript = null;
		while (queue.Count > 0)
		{
			cpooledGameObjectScript = queue.Dequeue();
			if (cpooledGameObjectScript != null && cpooledGameObjectScript.gameObject != null)
			{
				cpooledGameObjectScript.gameObject.transform.SetParent(null, true);
				cpooledGameObjectScript.gameObject.transform.localScale = cpooledGameObjectScript.m_defaultScale;
				break;
			}
			cpooledGameObjectScript = null;
		}
		uint num = this.m_PoolRequestIDCount++;
		if (cpooledGameObjectScript != null)
		{
			cpooledGameObjectScript.m_IsRecycled = false;
			this.HandlePooledMonoBehaviour(cpooledGameObjectScript.m_pooledMonoBehaviours, CGameObjectPool.enPooledMonoBehaviourAction.Get);
			this.m_GameObjectRequestCache.Add(new CGameObjectPool.GameObjectRequestCache(cpooledGameObjectScript, prefabFullPath, num, userData, callbacks));
			return num;
		}
		return this._CreateGameObjectAsync(prefabFullPath, callbacks, userData, resourceType, num, text, poolFlag);
	}

	// Token: 0x06001334 RID: 4916 RVA: 0x000672CC File Offset: 0x000656CC
	private uint _CreateGameObjectAsync(string prefabFullPath, AssetLoadCallbacks callbacks, object userData, enResourceType resourceType, uint requestID, string prefabKey, uint poolFlag)
	{
		CGameObjectPool.GameObjectLoadContext userData2 = new CGameObjectPool.GameObjectLoadContext(this, prefabKey, null, prefabFullPath, requestID, userData, callbacks);
		AssetLoader.LoadResAsGameObjectAsync(prefabFullPath, this.m_AssetLoadCallbacks, userData2, 0U, 0U);
		return requestID;
	}

	// Token: 0x06001335 RID: 4917 RVA: 0x000672FC File Offset: 0x000656FC
	private void _OnUpdate()
	{
		if (this.m_GameObjectRequestCache != null && this.m_GameObjectRequestCache.Count > 0)
		{
			int i = 0;
			int count = this.m_GameObjectRequestCache.Count;
			while (i < count)
			{
				CGameObjectPool.GameObjectRequestCache gameObjectRequestCache = this.m_GameObjectRequestCache[i];
				if (gameObjectRequestCache != null)
				{
					if (gameObjectRequestCache.m_CallerCallbacks != null && gameObjectRequestCache.m_CallerCallbacks.OnAssetLoadSuccess != null)
					{
						gameObjectRequestCache.m_CallerCallbacks.OnAssetLoadSuccess(gameObjectRequestCache.m_AssetPath, gameObjectRequestCache.m_Script.gameObject, (int)gameObjectRequestCache.m_RequestID, 0f, gameObjectRequestCache.m_UserData);
					}
				}
				i++;
			}
			this.m_GameObjectRequestCache.Clear();
		}
	}

	// Token: 0x1700021E RID: 542
	// (get) Token: 0x06001336 RID: 4918 RVA: 0x000673B3 File Offset: 0x000657B3
	public int CompleteTaskCount
	{
		get
		{
			return this.m_CompleteList.Count;
		}
	}

	// Token: 0x1700021F RID: 543
	// (get) Token: 0x06001337 RID: 4919 RVA: 0x000673C0 File Offset: 0x000657C0
	public int LoadingTaskCount
	{
		get
		{
			return this.m_HighPriorityAsyncReqList.Count + this.m_AsyncReqList.Count;
		}
	}

	// Token: 0x06001338 RID: 4920 RVA: 0x000673DC File Offset: 0x000657DC
	private CGameObjectPool.GameObjPoolAsyncRequest _AllocAsyncRequest()
	{
		CGameObjectPool.GameObjPoolAsyncRequest gameObjPoolAsyncRequest = null;
		if (this.m_IdleReqPool.Count > 0)
		{
			gameObjPoolAsyncRequest = this.m_IdleReqPool[0];
			this.m_IdleReqPool.RemoveAt(0);
		}
		if (gameObjPoolAsyncRequest == null)
		{
			gameObjPoolAsyncRequest = new CGameObjectPool.GameObjPoolAsyncRequest();
		}
		gameObjPoolAsyncRequest.Reset();
		return gameObjPoolAsyncRequest;
	}

	// Token: 0x06001339 RID: 4921 RVA: 0x00067428 File Offset: 0x00065828
	private void _OnGameObjectLoaded(CGameObjectPool.GameObjPoolAsyncRequest request, GameObject gameObject)
	{
		if (null != gameObject)
		{
			gameObject.transform.position = request.m_Pos;
			if (request.m_UseRotation)
			{
				gameObject.transform.rotation = request.m_Rot;
			}
			if (!this.m_IsRecycling)
			{
				IPooledMonoBehaviour[] pooledMonoBehaviours = this.GetPooledMonoBehaviours(gameObject);
				CPooledGameObjectScript cpooledGameObjectScript = gameObject.GetComponent<CPooledGameObjectScript>();
				if (cpooledGameObjectScript == null)
				{
					cpooledGameObjectScript = gameObject.AddComponent<CPooledGameObjectScript>();
				}
				if (null == gameObject.GetComponent<AssetProxy>())
				{
					gameObject.AddComponent<AssetProxy>();
				}
				cpooledGameObjectScript.m_prefabKey = request.m_PrefabKey;
				cpooledGameObjectScript.m_pooledMonoBehaviours = pooledMonoBehaviours;
				cpooledGameObjectScript.m_defaultScale = cpooledGameObjectScript.transform.localScale;
				cpooledGameObjectScript.m_isInit = true;
				cpooledGameObjectScript.m_IsRecycled = false;
				cpooledGameObjectScript.m_IsOriginInVisible = !cpooledGameObjectScript.gameObject.activeSelf;
				this.HandlePooledMonoBehaviour(cpooledGameObjectScript.m_pooledMonoBehaviours, CGameObjectPool.enPooledMonoBehaviourAction.Create);
			}
		}
	}

	// Token: 0x0600133A RID: 4922 RVA: 0x00067508 File Offset: 0x00065908
	private CGameObjectPool.GameObjPoolAsyncRequest _CheckAsyncRequest(List<CGameObjectPool.GameObjPoolAsyncRequest> asyncReqList)
	{
		CGameObjectPool.GameObjPoolAsyncRequest result = null;
		int i = 0;
		int num = asyncReqList.Count;
		while (i < num)
		{
			CGameObjectPool.GameObjPoolAsyncRequest gameObjPoolAsyncRequest = asyncReqList[i];
			if (gameObjPoolAsyncRequest != null)
			{
				if (!gameObjPoolAsyncRequest.m_IsAbort)
				{
					if (AssetLoader.INVILID_HANDLE != gameObjPoolAsyncRequest.m_AssetInstReq)
					{
						if (!Singleton<AssetLoader>.instance.IsValidHandle(gameObjPoolAsyncRequest.m_AssetInstReq))
						{
							gameObjPoolAsyncRequest.Reset();
							this.m_IdleReqPool.Add(gameObjPoolAsyncRequest);
							asyncReqList.RemoveAt(i);
							i--;
							num--;
							goto IL_12B;
						}
						if (!Singleton<AssetLoader>.instance.IsRequestDone(gameObjPoolAsyncRequest.m_AssetInstReq))
						{
							goto IL_12B;
						}
						AssetInst assetInst = Singleton<AssetLoader>.instance.Extract(gameObjPoolAsyncRequest.m_AssetInstReq);
						GameObject gameObject = null;
						if (assetInst != null)
						{
							gameObject = (assetInst.obj as GameObject);
							this._OnGameObjectLoaded(gameObjPoolAsyncRequest, gameObject);
						}
						gameObjPoolAsyncRequest.m_IsDone = true;
						gameObjPoolAsyncRequest.m_Extracted = false;
						gameObjPoolAsyncRequest.m_ResObject = gameObject;
						gameObjPoolAsyncRequest.m_AssetInstReq = AssetLoader.INVILID_HANDLE;
					}
					goto IL_11D;
				}
				Singleton<AssetLoader>.instance.AbortRequest(gameObjPoolAsyncRequest.m_AssetInstReq);
				gameObjPoolAsyncRequest.Reset();
				asyncReqList.RemoveAt(i);
				this.m_IdleReqPool.Add(gameObjPoolAsyncRequest);
				i--;
				num--;
				IL_12B:
				i++;
				continue;
			}
			IL_11D:
			result = gameObjPoolAsyncRequest;
			asyncReqList.RemoveAt(i);
			break;
		}
		return result;
	}

	// Token: 0x0600133B RID: 4923 RVA: 0x0006764C File Offset: 0x00065A4C
	private void _UpdateAsync()
	{
		if (EngineConfig.useTMEngine)
		{
			return;
		}
		CGameObjectPool.GameObjPoolAsyncRequest gameObjPoolAsyncRequest = this._CheckAsyncRequest(this.m_HighPriorityAsyncReqList);
		if (gameObjPoolAsyncRequest == null)
		{
			gameObjPoolAsyncRequest = this._CheckAsyncRequest(this.m_AsyncReqList);
		}
		int num = Singleton<AssetLoader>.instance.GetAsyncLoadStep();
		if (this.m_CompleteList.Count > 200)
		{
			num *= 2;
		}
		int i = 0;
		int num2 = this.m_CompleteList.Count;
		while (i < num2)
		{
			CGameObjectPool.GameObjPoolAsyncRequest gameObjPoolAsyncRequest2 = this.m_CompleteList[i];
			if (gameObjPoolAsyncRequest2 == null)
			{
				goto IL_FA;
			}
			if (gameObjPoolAsyncRequest2.m_IsAbort)
			{
				GameObject gameObject = gameObjPoolAsyncRequest2.Extract() as GameObject;
				if (null != gameObject)
				{
					this.RecycleGameObject(gameObject);
				}
				gameObjPoolAsyncRequest2.Reset();
				this.m_CompleteList.RemoveAt(i);
				this.m_IdleReqPool.Add(gameObjPoolAsyncRequest2);
				i--;
				num2--;
			}
			else if (gameObjPoolAsyncRequest2.m_Extracted)
			{
				gameObjPoolAsyncRequest2.Reset();
				this.m_IdleReqPool.Add(gameObjPoolAsyncRequest2);
				goto IL_FA;
			}
			IL_11E:
			i++;
			continue;
			IL_FA:
			this.m_CompleteList.RemoveAt(i);
			i--;
			num2--;
			num--;
			if (num <= 0)
			{
				break;
			}
			goto IL_11E;
		}
		if (gameObjPoolAsyncRequest != null)
		{
			this.m_CompleteList.Add(gameObjPoolAsyncRequest);
		}
	}

	// Token: 0x0600133C RID: 4924 RVA: 0x00067794 File Offset: 0x00065B94
	private void _RecycleGameObject(GameObject pooledGameObject, bool setIsInit)
	{
		if (EngineConfig.useTMEngine)
		{
			CGameObjectPool.RecycleGameObjectEx(pooledGameObject);
			return;
		}
		if (pooledGameObject != null)
		{
			bool flag = false;
			List<CPooledGameObjectScript> list = ListPool<CPooledGameObjectScript>.Get();
			pooledGameObject.GetComponentsInChildren<CPooledGameObjectScript>(list);
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				CPooledGameObjectScript cpooledGameObjectScript = list[i];
				if (!(null == cpooledGameObjectScript))
				{
					if (pooledGameObject == cpooledGameObjectScript.gameObject)
					{
						flag = true;
					}
					if (!cpooledGameObjectScript.m_IsRecycled)
					{
						Queue<CPooledGameObjectScript> queue = null;
						if (!this.m_pooledGameObjectMap.TryGetValue(cpooledGameObjectScript.m_prefabKey, out queue))
						{
							queue = new Queue<CPooledGameObjectScript>();
							this.m_pooledGameObjectMap.Add(cpooledGameObjectScript.m_prefabKey, queue);
						}
						if (null == this.m_poolRoot)
						{
							Object.Destroy(pooledGameObject);
						}
						else
						{
							queue.Enqueue(cpooledGameObjectScript);
							this.HandlePooledMonoBehaviour(cpooledGameObjectScript.m_pooledMonoBehaviours, CGameObjectPool.enPooledMonoBehaviourAction.Recycle);
							cpooledGameObjectScript.gameObject.transform.SetParent(this.m_poolRoot.transform, false);
							cpooledGameObjectScript.m_isInit = setIsInit;
							cpooledGameObjectScript.gameObject.SetActive(false);
							cpooledGameObjectScript.m_IsRecycled = true;
						}
					}
				}
				i++;
			}
			ListPool<CPooledGameObjectScript>.Release(list);
			if (!flag)
			{
				Object.Destroy(pooledGameObject);
			}
		}
	}

	// Token: 0x0600133D RID: 4925 RVA: 0x000678DC File Offset: 0x00065CDC
	public void ClearPooledObjects()
	{
		this.m_clearPooledObjects = true;
		this.m_clearPooledObjectsExecuteFrame = CGameObjectPool.s_frameCounter + 1;
	}

	// Token: 0x0600133E RID: 4926 RVA: 0x000678F4 File Offset: 0x00065CF4
	private CPooledGameObjectScript _InstantiateGameObjectInst(GameObject go, enResourceType resourceType, string prefabKey, bool isOriginInVisible = false)
	{
		GameObject gameObject = Object.Instantiate<GameObject>(go);
		if (null == gameObject)
		{
			Logger.LogErrorFormat("Instantiate gameobject has failed with prefab key[{0}]!", new object[]
			{
				prefabKey
			});
			return null;
		}
		gameObject.name = go.name;
		AssetProxy component = go.GetComponent<AssetProxy>();
		AssetProxy component2 = gameObject.GetComponent<AssetProxy>();
		if (null != component && null != component2)
		{
			component2.AddResRef(component);
		}
		IPooledMonoBehaviour[] pooledMonoBehaviours = this.GetPooledMonoBehaviours(gameObject);
		CPooledGameObjectScript cpooledGameObjectScript = gameObject.GetComponent<CPooledGameObjectScript>();
		if (cpooledGameObjectScript == null)
		{
			cpooledGameObjectScript = gameObject.AddComponent<CPooledGameObjectScript>();
		}
		if (null == gameObject.GetComponent<AssetProxy>())
		{
			gameObject.AddComponent<AssetProxy>();
		}
		if (null == cpooledGameObjectScript)
		{
			Debug.LogWarning("Create CPooledGameObjectScript component has failed!");
		}
		cpooledGameObjectScript.m_prefabKey = prefabKey;
		cpooledGameObjectScript.m_pooledMonoBehaviours = pooledMonoBehaviours;
		cpooledGameObjectScript.m_defaultScale = cpooledGameObjectScript.transform.localScale;
		cpooledGameObjectScript.m_isInit = true;
		cpooledGameObjectScript.m_IsRecycled = false;
		cpooledGameObjectScript.m_IsOriginInVisible = isOriginInVisible;
		this.HandlePooledMonoBehaviour(cpooledGameObjectScript.m_pooledMonoBehaviours, CGameObjectPool.enPooledMonoBehaviourAction.Create);
		return cpooledGameObjectScript;
	}

	// Token: 0x0600133F RID: 4927 RVA: 0x000679FC File Offset: 0x00065DFC
	private CPooledGameObjectScript CreateGameObject(string prefabFullPath, Vector3 pos, Quaternion rot, bool useRotation, enResourceType resourceType, string prefabKey)
	{
		bool flag = resourceType == enResourceType.BattleScene;
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(prefabFullPath, true, 0U);
		if (null == gameObject)
		{
			return null;
		}
		gameObject.transform.position = pos;
		if (useRotation)
		{
			gameObject.transform.rotation = rot;
		}
		IPooledMonoBehaviour[] pooledMonoBehaviours = this.GetPooledMonoBehaviours(gameObject);
		CPooledGameObjectScript cpooledGameObjectScript = gameObject.GetComponent<CPooledGameObjectScript>();
		if (cpooledGameObjectScript == null)
		{
			cpooledGameObjectScript = gameObject.AddComponent<CPooledGameObjectScript>();
		}
		if (null == gameObject.GetComponent<AssetProxy>())
		{
			gameObject.AddComponent<AssetProxy>();
		}
		if (null == cpooledGameObjectScript)
		{
			Debug.LogWarning("Create CPooledGameObjectScript component has failed!");
		}
		cpooledGameObjectScript.m_prefabKey = prefabKey;
		cpooledGameObjectScript.m_pooledMonoBehaviours = pooledMonoBehaviours;
		cpooledGameObjectScript.m_defaultScale = cpooledGameObjectScript.transform.localScale;
		cpooledGameObjectScript.m_isInit = true;
		cpooledGameObjectScript.m_IsRecycled = false;
		this.HandlePooledMonoBehaviour(cpooledGameObjectScript.m_pooledMonoBehaviours, CGameObjectPool.enPooledMonoBehaviourAction.Create);
		return cpooledGameObjectScript;
	}

	// Token: 0x06001340 RID: 4928 RVA: 0x00067AD8 File Offset: 0x00065ED8
	private IAsyncLoadRequest<Object> _CreateGameObjectAsync(string prefabFullPath, Vector3 pos, Quaternion rot, bool useRotation, enResourceType resourceType, string prefabKey, uint poolFlag, uint waterMark)
	{
		CGameObjectPool.GameObjPoolAsyncRequest gameObjPoolAsyncRequest = this._AllocAsyncRequest();
		uint num = (!this._HasFlag(poolFlag, GameObjectPoolFlag.HideAfterLoad)) ? 0U : 1U;
		if (this._HasFlag(poolFlag, GameObjectPoolFlag.HighPriority))
		{
			num |= 16U;
		}
		gameObjPoolAsyncRequest.m_AssetInstReq = Singleton<AssetLoader>.instance.LoadResAsyncAsGameObject(prefabFullPath, false, num, 0U);
		gameObjPoolAsyncRequest.m_PrefabKey = prefabKey;
		gameObjPoolAsyncRequest.m_Pos = pos;
		gameObjPoolAsyncRequest.m_Rot = rot;
		gameObjPoolAsyncRequest.m_UseRotation = useRotation;
		gameObjPoolAsyncRequest.m_PoolFlag = poolFlag;
		gameObjPoolAsyncRequest.m_ResourceType = resourceType;
		gameObjPoolAsyncRequest.m_ResPath = prefabFullPath + "(From Pool By Create)";
		gameObjPoolAsyncRequest.m_WaterMark = waterMark;
		if (this._HasFlag(poolFlag, GameObjectPoolFlag.HighPriority))
		{
			this.m_HighPriorityAsyncReqList.Add(gameObjPoolAsyncRequest);
		}
		else
		{
			this.m_AsyncReqList.Add(gameObjPoolAsyncRequest);
		}
		return gameObjPoolAsyncRequest;
	}

	// Token: 0x06001341 RID: 4929 RVA: 0x00067BA0 File Offset: 0x00065FA0
	public void ExecuteClearPooledObjects()
	{
		if (EngineConfig.useTMEngine)
		{
			ITMUnityGameObjectPool itmunityGameObjectPool = CGameObjectPool._GetGameObjectPool();
			if (itmunityGameObjectPool != null)
			{
				itmunityGameObjectPool.PurgePool(true);
			}
			return;
		}
		this.m_IsRecycling = true;
		foreach (KeyValuePair<string, Queue<CPooledGameObjectScript>> keyValuePair in this.m_pooledGameObjectMap)
		{
			Queue<CPooledGameObjectScript> value = keyValuePair.Value;
			while (value.Count > 0)
			{
				CPooledGameObjectScript cpooledGameObjectScript = value.Dequeue();
				if (cpooledGameObjectScript != null && cpooledGameObjectScript.gameObject != null)
				{
					Object.Destroy(cpooledGameObjectScript.gameObject);
				}
			}
		}
		this.m_pooledGameObjectMap.Clear();
		this.m_IsRecycling = false;
	}

	// Token: 0x06001342 RID: 4930 RVA: 0x00067C58 File Offset: 0x00066058
	public void ExecuteClearPooledObjects(List<string> keyNotClear)
	{
		if (keyNotClear == null)
		{
			this.ExecuteClearPooledObjects();
		}
		this.m_IsRecycling = true;
		foreach (KeyValuePair<string, Queue<CPooledGameObjectScript>> keyValuePair in this.m_pooledGameObjectMap)
		{
			if (!keyNotClear.Contains(keyValuePair.Key))
			{
				Queue<CPooledGameObjectScript> value = keyValuePair.Value;
				while (value.Count > 0)
				{
					CPooledGameObjectScript cpooledGameObjectScript = value.Dequeue();
					if (cpooledGameObjectScript != null && cpooledGameObjectScript.gameObject != null)
					{
						Object.Destroy(cpooledGameObjectScript.gameObject);
					}
				}
				value.Clear();
			}
		}
		this.m_IsRecycling = false;
	}

	// Token: 0x06001343 RID: 4931 RVA: 0x00067D04 File Offset: 0x00066104
	[Conditional("UNITY_EDITOR")]
	private void _checkStringInListIgnoreCase(string key, List<string> strs)
	{
		if (strs == null)
		{
			return;
		}
		for (int i = 0; i < strs.Count; i++)
		{
			if (string.Equals(key, strs[i], StringComparison.OrdinalIgnoreCase))
			{
				Logger.LogErrorFormat("[字符串检查] {0} {1} 有大小写差异", new object[]
				{
					key,
					strs[i]
				});
				break;
			}
		}
	}

	// Token: 0x06001344 RID: 4932 RVA: 0x00067D68 File Offset: 0x00066168
	public GameObject GetGameObject(string prefabFullPath, enResourceType resourceType, uint poolFlag)
	{
		bool flag = false;
		return this.GetGameObject(prefabFullPath, Vector3.zero, Quaternion.identity, false, resourceType, poolFlag, out flag);
	}

	// Token: 0x06001345 RID: 4933 RVA: 0x00067D8D File Offset: 0x0006618D
	public GameObject GetGameObject(string prefabFullPath, enResourceType resourceType, uint poolFlag, out bool isInit)
	{
		return this.GetGameObject(prefabFullPath, Vector3.zero, Quaternion.identity, false, resourceType, poolFlag, out isInit);
	}

	// Token: 0x06001346 RID: 4934 RVA: 0x00067DA8 File Offset: 0x000661A8
	private GameObject GetGameObject(string prefabFullPath, Vector3 pos, Quaternion rot, bool useRotation, enResourceType resourceType, uint poolFlag, out bool isInit)
	{
		if (EngineConfig.useTMEngine)
		{
			isInit = false;
			return CGameObjectPool.GetGameObject(prefabFullPath, 0U);
		}
		if (this.m_IsRecycling)
		{
			isInit = true;
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(prefabFullPath, true, 0U);
			if (null != gameObject && !gameObject.activeSelf)
			{
				gameObject.SetActive(true);
			}
			return gameObject;
		}
		string text = CFileManager.EraseExtension(prefabFullPath);
		Queue<CPooledGameObjectScript> queue = null;
		if (!this.m_pooledGameObjectMap.TryGetValue(text, out queue))
		{
			queue = new Queue<CPooledGameObjectScript>();
			this.m_pooledGameObjectMap.Add(text, queue);
		}
		CPooledGameObjectScript cpooledGameObjectScript = null;
		while (queue.Count > 0)
		{
			cpooledGameObjectScript = queue.Dequeue();
			if (cpooledGameObjectScript != null && cpooledGameObjectScript.gameObject != null)
			{
				cpooledGameObjectScript.gameObject.transform.SetParent(null, true);
				cpooledGameObjectScript.gameObject.transform.position = pos;
				cpooledGameObjectScript.gameObject.transform.rotation = rot;
				cpooledGameObjectScript.gameObject.transform.localScale = cpooledGameObjectScript.m_defaultScale;
				break;
			}
			cpooledGameObjectScript = null;
		}
		if (cpooledGameObjectScript == null)
		{
			cpooledGameObjectScript = this.CreateGameObject(prefabFullPath, pos, rot, useRotation, resourceType, text);
		}
		if (cpooledGameObjectScript == null)
		{
			isInit = false;
			return null;
		}
		isInit = cpooledGameObjectScript.m_isInit;
		cpooledGameObjectScript.m_IsRecycled = false;
		cpooledGameObjectScript.gameObject.SetActive(true);
		this.HandlePooledMonoBehaviour(cpooledGameObjectScript.m_pooledMonoBehaviours, CGameObjectPool.enPooledMonoBehaviourAction.Get);
		return cpooledGameObjectScript.gameObject;
	}

	// Token: 0x06001347 RID: 4935 RVA: 0x00067F1B File Offset: 0x0006631B
	public uint GetGameObjectAsync(string prefabFullPath, enResourceType resourceType, uint poolFlag, uint waterMark = 0U)
	{
		return this._GetGameObjectAsyncHandle(prefabFullPath, Vector3.zero, Quaternion.identity, false, resourceType, poolFlag, waterMark);
	}

	// Token: 0x06001348 RID: 4936 RVA: 0x00067F33 File Offset: 0x00066333
	public uint GetGameObjectAsync(string prefabFullPath, Vector3 pos, enResourceType resourceType, uint poolFlag, uint waterMark = 0U)
	{
		return this._GetGameObjectAsyncHandle(prefabFullPath, pos, Quaternion.identity, false, resourceType, poolFlag, waterMark);
	}

	// Token: 0x06001349 RID: 4937 RVA: 0x00067F48 File Offset: 0x00066348
	public uint GetGameObjectAsync(string prefabFullPath, Vector3 pos, Quaternion rot, enResourceType resourceType, uint poolFlag, uint waterMark = 0U)
	{
		return this._GetGameObjectAsyncHandle(prefabFullPath, pos, rot, true, resourceType, poolFlag, waterMark);
	}

	// Token: 0x0600134A RID: 4938 RVA: 0x00067F5C File Offset: 0x0006635C
	public bool IsRequestDone(uint handle)
	{
		IAsyncLoadRequest<Object> asyncRequestByHandle = this.m_AsyncRequestHandleAlloc.GetAsyncRequestByHandle(handle);
		if (asyncRequestByHandle != null)
		{
			return asyncRequestByHandle.IsDone();
		}
		Logger.LogError("Asset async-load handle is invalid or expired!");
		return false;
	}

	// Token: 0x0600134B RID: 4939 RVA: 0x00067F90 File Offset: 0x00066390
	public Object ExtractAsset(uint handle)
	{
		IAsyncLoadRequest<Object> asyncRequestByHandle = this.m_AsyncRequestHandleAlloc.GetAsyncRequestByHandle(handle);
		if (asyncRequestByHandle != null && asyncRequestByHandle.IsDone())
		{
			this.m_AsyncRequestHandleAlloc.RemoveAsyncRequest(handle);
			return asyncRequestByHandle.Extract();
		}
		return null;
	}

	// Token: 0x0600134C RID: 4940 RVA: 0x00067FD0 File Offset: 0x000663D0
	public void AbortRequest(uint handle)
	{
		IAsyncLoadRequest<Object> asyncRequestByHandle = this.m_AsyncRequestHandleAlloc.GetAsyncRequestByHandle(handle);
		if (asyncRequestByHandle != null)
		{
			this.m_AsyncRequestHandleAlloc.RemoveAsyncRequest(handle);
			asyncRequestByHandle.Abort();
		}
	}

	// Token: 0x0600134D RID: 4941 RVA: 0x00068002 File Offset: 0x00066402
	public bool IsValidHandle(uint handle)
	{
		return null != this.m_AsyncRequestHandleAlloc.GetAsyncRequestByHandle(handle);
	}

	// Token: 0x0600134E RID: 4942 RVA: 0x00068018 File Offset: 0x00066418
	private uint _GetGameObjectAsyncHandle(string prefabFullPath, Vector3 pos, Quaternion rot, bool useRotation, enResourceType resourceType, uint poolFlag, uint waterMark)
	{
		if (EngineConfig.useTMEngine)
		{
			throw new Exception("Method expired!");
		}
		IAsyncLoadRequest<Object> asyncLoadRequest = this._GetGameObjectAsync(prefabFullPath, pos, rot, useRotation, resourceType, poolFlag, waterMark);
		if (asyncLoadRequest != null)
		{
			return this.m_AsyncRequestHandleAlloc.AddAsyncRequest(asyncLoadRequest);
		}
		Logger.LogErrorFormat("Async load asset [{0}] has failed!", new object[]
		{
			prefabFullPath
		});
		return uint.MaxValue;
	}

	// Token: 0x0600134F RID: 4943 RVA: 0x00068074 File Offset: 0x00066474
	private IAsyncLoadRequest<Object> _GetGameObjectAsync(string prefabFullPath, Vector3 pos, Quaternion rot, bool useRotation, enResourceType resourceType, uint poolFlag, uint waterMark)
	{
		string text = CFileManager.EraseExtension(prefabFullPath);
		if (this.m_IsRecycling)
		{
			return this._CreateGameObjectAsync(prefabFullPath, pos, rot, useRotation, resourceType, text, poolFlag, waterMark);
		}
		Queue<CPooledGameObjectScript> queue = null;
		if (!this.m_pooledGameObjectMap.TryGetValue(text, out queue))
		{
			queue = new Queue<CPooledGameObjectScript>();
			this.m_pooledGameObjectMap.Add(text, queue);
		}
		CPooledGameObjectScript cpooledGameObjectScript = null;
		while (queue.Count > 0)
		{
			cpooledGameObjectScript = queue.Dequeue();
			if (cpooledGameObjectScript != null && cpooledGameObjectScript.gameObject != null)
			{
				cpooledGameObjectScript.gameObject.transform.SetParent(null, true);
				cpooledGameObjectScript.gameObject.transform.position = pos;
				cpooledGameObjectScript.gameObject.transform.rotation = rot;
				cpooledGameObjectScript.gameObject.transform.localScale = cpooledGameObjectScript.m_defaultScale;
				break;
			}
			cpooledGameObjectScript = null;
		}
		if (cpooledGameObjectScript != null)
		{
			cpooledGameObjectScript.m_IsRecycled = false;
			this.HandlePooledMonoBehaviour(cpooledGameObjectScript.m_pooledMonoBehaviours, CGameObjectPool.enPooledMonoBehaviourAction.Get);
			CGameObjectPool.GameObjPoolAsyncRequest gameObjPoolAsyncRequest = this._AllocAsyncRequest();
			gameObjPoolAsyncRequest.m_AssetInstReq = AssetLoader.INVILID_HANDLE;
			gameObjPoolAsyncRequest.m_PrefabKey = prefabFullPath;
			gameObjPoolAsyncRequest.m_Pos = pos;
			gameObjPoolAsyncRequest.m_Rot = rot;
			gameObjPoolAsyncRequest.m_UseRotation = useRotation;
			gameObjPoolAsyncRequest.m_PoolFlag = (poolFlag & 4294967293U);
			gameObjPoolAsyncRequest.m_ResourceType = resourceType;
			gameObjPoolAsyncRequest.m_IsAbort = false;
			gameObjPoolAsyncRequest.m_IsDone = true;
			gameObjPoolAsyncRequest.m_ResObject = cpooledGameObjectScript.gameObject;
			gameObjPoolAsyncRequest.m_Extracted = false;
			gameObjPoolAsyncRequest.m_ResPath = prefabFullPath + "(From Pool By Get In Pool)";
			gameObjPoolAsyncRequest.m_WaterMark = 3203383023U;
			this.m_CompleteList.Add(gameObjPoolAsyncRequest);
			return gameObjPoolAsyncRequest;
		}
		return this._CreateGameObjectAsync(prefabFullPath, pos, rot, useRotation, resourceType, text, poolFlag, waterMark);
	}

	// Token: 0x06001350 RID: 4944 RVA: 0x00068218 File Offset: 0x00066618
	private IPooledMonoBehaviour[] GetPooledMonoBehaviours(GameObject gameObject)
	{
		MonoBehaviour[] componentsInChildren = gameObject.GetComponentsInChildren<MonoBehaviour>();
		if (componentsInChildren == null || componentsInChildren.Length <= 0)
		{
			return new IPooledMonoBehaviour[0];
		}
		int num = 0;
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i] is IPooledMonoBehaviour)
			{
				num++;
			}
		}
		IPooledMonoBehaviour[] array = new IPooledMonoBehaviour[num];
		num = 0;
		for (int j = 0; j < componentsInChildren.Length; j++)
		{
			IPooledMonoBehaviour pooledMonoBehaviour = componentsInChildren[j] as IPooledMonoBehaviour;
			if (pooledMonoBehaviour != null)
			{
				array[num] = pooledMonoBehaviour;
				num++;
			}
		}
		return array;
	}

	// Token: 0x06001351 RID: 4945 RVA: 0x000682A8 File Offset: 0x000666A8
	private void HandlePooledMonoBehaviour(IPooledMonoBehaviour[] pooledMonoBehaviours, CGameObjectPool.enPooledMonoBehaviourAction pooledMonoBehaviourAction)
	{
		if (pooledMonoBehaviours == null)
		{
			return;
		}
		foreach (IPooledMonoBehaviour pooledMonoBehaviour in pooledMonoBehaviours)
		{
			if (pooledMonoBehaviour != null && (pooledMonoBehaviour as MonoBehaviour).enabled)
			{
				if (pooledMonoBehaviourAction != CGameObjectPool.enPooledMonoBehaviourAction.Create)
				{
					if (pooledMonoBehaviourAction != CGameObjectPool.enPooledMonoBehaviourAction.Get)
					{
						if (pooledMonoBehaviourAction == CGameObjectPool.enPooledMonoBehaviourAction.Recycle)
						{
							pooledMonoBehaviour.OnRecycle();
						}
					}
					else
					{
						pooledMonoBehaviour.OnGet();
					}
				}
				else
				{
					pooledMonoBehaviour.OnCreate();
				}
			}
		}
	}

	// Token: 0x06001352 RID: 4946 RVA: 0x00068324 File Offset: 0x00066724
	public override void Init()
	{
		this.RebuildRoot();
	}

	// Token: 0x06001353 RID: 4947 RVA: 0x0006832C File Offset: 0x0006672C
	public void RebuildRoot()
	{
		if (null == this.m_poolRoot)
		{
			this.m_poolRoot = new GameObject("CGameObjectPool");
			this.m_poolRoot.transform.position = new Vector3(0f, -1000f, 0f);
		}
	}

	// Token: 0x06001354 RID: 4948 RVA: 0x0006837E File Offset: 0x0006677E
	public void ClearAll()
	{
		this.ExecuteClearPooledObjects();
		if (null != this.m_poolRoot)
		{
			Object.Destroy(this.m_poolRoot);
			this.m_poolRoot = null;
		}
	}

	// Token: 0x06001355 RID: 4949 RVA: 0x000683AC File Offset: 0x000667AC
	public void PrepareGameObject(string prefabFullPath, enResourceType resourceType, int amount)
	{
		if (EngineConfig.useTMEngine)
		{
			GameObject gameObject = CGameObjectPool.GetGameObject(prefabFullPath, 0U);
			CGameObjectPool.RecycleGameObjectEx(gameObject);
			return;
		}
		if (this.m_IsRecycling)
		{
			return;
		}
		string text = CFileManager.EraseExtension(prefabFullPath);
		Queue<CPooledGameObjectScript> queue = null;
		if (!this.m_pooledGameObjectMap.TryGetValue(text, out queue))
		{
			queue = new Queue<CPooledGameObjectScript>();
			this.m_pooledGameObjectMap.Add(text, queue);
		}
		if (queue.Count < amount)
		{
			amount -= queue.Count;
			for (int i = 0; i < amount; i++)
			{
				CPooledGameObjectScript cpooledGameObjectScript = this.CreateGameObject(prefabFullPath, Vector3.zero, Quaternion.identity, false, resourceType, text);
				DebugHelper.Assert(cpooledGameObjectScript != null);
				if (cpooledGameObjectScript != null)
				{
					queue.Enqueue(cpooledGameObjectScript);
					cpooledGameObjectScript.gameObject.transform.SetParent(this.m_poolRoot.transform, true);
					cpooledGameObjectScript.gameObject.SetActive(false);
					cpooledGameObjectScript.m_IsRecycled = true;
				}
			}
		}
	}

	// Token: 0x06001356 RID: 4950 RVA: 0x0006849F File Offset: 0x0006689F
	public void RecycleGameObject(GameObject pooledGameObject)
	{
		this._RecycleGameObject(pooledGameObject, false);
	}

	// Token: 0x06001357 RID: 4951 RVA: 0x000684A9 File Offset: 0x000668A9
	public void RecyclePreparedGameObject(GameObject pooledGameObject)
	{
		this._RecycleGameObject(pooledGameObject, true);
	}

	// Token: 0x06001358 RID: 4952 RVA: 0x000684B3 File Offset: 0x000668B3
	public override void UnInit()
	{
		if (this.m_poolRoot)
		{
			Object.Destroy(this.m_poolRoot);
			this.m_poolRoot = null;
		}
	}

	// Token: 0x06001359 RID: 4953 RVA: 0x000684D7 File Offset: 0x000668D7
	public void Update()
	{
		this._UpdateAsync();
		CGameObjectPool.s_frameCounter++;
		if (this.m_clearPooledObjects && this.m_clearPooledObjectsExecuteFrame == CGameObjectPool.s_frameCounter)
		{
			this.ExecuteClearPooledObjects();
			this.m_clearPooledObjects = false;
		}
	}

	// Token: 0x0600135A RID: 4954 RVA: 0x00068514 File Offset: 0x00066914
	public int GetPooledGameObjectNum()
	{
		int num = 0;
		foreach (KeyValuePair<string, Queue<CPooledGameObjectScript>> keyValuePair in this.m_pooledGameObjectMap)
		{
			Queue<CPooledGameObjectScript> value = keyValuePair.Value;
			num += value.Count;
		}
		return num;
	}

	// Token: 0x0600135B RID: 4955 RVA: 0x0006855C File Offset: 0x0006695C
	public void DumpGameObjectInfo(ref List<string> assetList)
	{
		assetList.Clear();
		foreach (KeyValuePair<string, Queue<CPooledGameObjectScript>> keyValuePair in this.m_pooledGameObjectMap)
		{
			Queue<CPooledGameObjectScript> value = keyValuePair.Value;
			string item = string.Format("Asset:{0}   (Object Count:{1})", keyValuePair.Key, value.Count);
			assetList.Add(item);
		}
	}

	// Token: 0x0600135C RID: 4956 RVA: 0x000685C2 File Offset: 0x000669C2
	private bool _HasFlag(uint flag, GameObjectPoolFlag eflag)
	{
		return 0U != (flag & (uint)eflag);
	}

	// Token: 0x04000D02 RID: 3330
	private static ITMUnityGameObjectPool m_GameObjectPool;

	// Token: 0x04000D03 RID: 3331
	public static readonly uint INVILID_HANDLE = uint.MaxValue;

	// Token: 0x04000D04 RID: 3332
	private bool m_clearPooledObjects;

	// Token: 0x04000D05 RID: 3333
	private int m_clearPooledObjectsExecuteFrame;

	// Token: 0x04000D06 RID: 3334
	private DictionaryView<string, Queue<CPooledGameObjectScript>> m_pooledGameObjectMap = new DictionaryView<string, Queue<CPooledGameObjectScript>>();

	// Token: 0x04000D07 RID: 3335
	private GameObject m_poolRoot;

	// Token: 0x04000D08 RID: 3336
	private static int s_frameCounter;

	// Token: 0x04000D09 RID: 3337
	private bool m_IsRecycling;

	// Token: 0x04000D0A RID: 3338
	private int m_QureyCnt;

	// Token: 0x04000D0B RID: 3339
	private readonly int QUREY_STEP = 1;

	// Token: 0x04000D0C RID: 3340
	private AssetLoadCallbacks m_AssetLoadCallbacks;

	// Token: 0x04000D0D RID: 3341
	private uint m_PoolRequestIDCount;

	// Token: 0x04000D0E RID: 3342
	private List<CGameObjectPool.GameObjectRequestCache> m_GameObjectRequestCache;

	// Token: 0x04000D0F RID: 3343
	private List<CGameObjectPool.GameObjPoolAsyncRequest> m_AsyncReqList;

	// Token: 0x04000D10 RID: 3344
	private List<CGameObjectPool.GameObjPoolAsyncRequest> m_HighPriorityAsyncReqList;

	// Token: 0x04000D11 RID: 3345
	private List<CGameObjectPool.GameObjPoolAsyncRequest> m_IdleReqPool;

	// Token: 0x04000D12 RID: 3346
	private List<CGameObjectPool.GameObjPoolAsyncRequest> m_CompleteList;

	// Token: 0x04000D13 RID: 3347
	private AsyncRequestHandleAllocator<IAsyncLoadRequest<Object>> m_AsyncRequestHandleAlloc;

	// Token: 0x04000D14 RID: 3348
	[CompilerGenerated]
	private static OnAssetLoadSuccess <>f__mg$cache0;

	// Token: 0x04000D15 RID: 3349
	[CompilerGenerated]
	private static OnAssetLoadFailure <>f__mg$cache1;

	// Token: 0x0200024B RID: 587
	private class GameObjectRequestCache
	{
		// Token: 0x0600135E RID: 4958 RVA: 0x000685D5 File Offset: 0x000669D5
		public GameObjectRequestCache(CPooledGameObjectScript script, string assetPath, uint requestID, object userData, AssetLoadCallbacks callbacks)
		{
			this.m_Script = script;
			this.m_AssetPath = assetPath;
			this.m_RequestID = requestID;
			this.m_UserData = userData;
			this.m_CallerCallbacks = callbacks;
		}

		// Token: 0x04000D16 RID: 3350
		public CPooledGameObjectScript m_Script;

		// Token: 0x04000D17 RID: 3351
		public string m_AssetPath;

		// Token: 0x04000D18 RID: 3352
		public object m_UserData;

		// Token: 0x04000D19 RID: 3353
		public uint m_RequestID;

		// Token: 0x04000D1A RID: 3354
		public AssetLoadCallbacks m_CallerCallbacks;
	}

	// Token: 0x0200024C RID: 588
	private class GameObjectLoadContext : CGameObjectPool.GameObjectRequestCache
	{
		// Token: 0x0600135F RID: 4959 RVA: 0x00068602 File Offset: 0x00066A02
		public GameObjectLoadContext(CGameObjectPool gameObjectPool, string prefabKey, CPooledGameObjectScript script, string assetPath, uint requestID, object userData, AssetLoadCallbacks callbacks) : base(script, assetPath, requestID, userData, callbacks)
		{
			TMDebug.Assert(null != gameObjectPool, "Game object pool object can not be null!");
			this.m_This = gameObjectPool;
			this.m_PrefabKey = prefabKey;
		}

		// Token: 0x04000D1B RID: 3355
		public string m_PrefabKey;

		// Token: 0x04000D1C RID: 3356
		public CGameObjectPool m_This;
	}

	// Token: 0x0200024D RID: 589
	private class GameObjPoolAsyncRequest : AsyncLoadRequest<Object>
	{
		// Token: 0x06001361 RID: 4961 RVA: 0x0006865B File Offset: 0x00066A5B
		public override Object Extract()
		{
			return base.Extract();
		}

		// Token: 0x06001362 RID: 4962 RVA: 0x00068663 File Offset: 0x00066A63
		public override void Abort()
		{
			if (null != this.m_ResObject)
			{
				Object.Destroy(this.m_ResObject);
			}
			base.Abort();
		}

		// Token: 0x06001363 RID: 4963 RVA: 0x00068688 File Offset: 0x00066A88
		public new void Reset()
		{
			this.m_AssetInstReq = AssetLoader.INVILID_HANDLE;
			this.m_PrefabKey = null;
			this.m_Pos = Vector3.zero;
			this.m_Rot = Quaternion.identity;
			this.m_UseRotation = false;
			this.m_ResObject = null;
			this.m_IsDone = false;
			this.m_Extracted = false;
			this.m_IsAbort = false;
			this.m_WaterMark = 0U;
		}

		// Token: 0x04000D1D RID: 3357
		public uint m_AssetInstReq = AssetLoader.INVILID_HANDLE;

		// Token: 0x04000D1E RID: 3358
		public string m_PrefabKey;

		// Token: 0x04000D1F RID: 3359
		public Vector3 m_Pos = Vector3.zero;

		// Token: 0x04000D20 RID: 3360
		public Quaternion m_Rot = Quaternion.identity;

		// Token: 0x04000D21 RID: 3361
		public bool m_UseRotation;

		// Token: 0x04000D22 RID: 3362
		public uint m_PoolFlag;

		// Token: 0x04000D23 RID: 3363
		public enResourceType m_ResourceType;
	}

	// Token: 0x0200024E RID: 590
	private enum enPooledMonoBehaviourAction
	{
		// Token: 0x04000D25 RID: 3365
		Create,
		// Token: 0x04000D26 RID: 3366
		Get,
		// Token: 0x04000D27 RID: 3367
		Recycle
	}
}
