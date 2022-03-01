using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TMEngine.Runtime.Unity
{
	// Token: 0x02004733 RID: 18227
	internal sealed class UnityGameObjectPool : BaseModule, ITMUnityGameObjectPool
	{
		// Token: 0x0601A2C9 RID: 107209 RVA: 0x00821800 File Offset: 0x0081FC00
		public UnityGameObjectPool()
		{
			if (UnityGameObjectPool.<>f__mg$cache0 == null)
			{
				UnityGameObjectPool.<>f__mg$cache0 = new OnAssetLoadSuccess(UnityGameObjectPool._OnLoadAssetSuccess);
			}
			OnAssetLoadSuccess onSuccess = UnityGameObjectPool.<>f__mg$cache0;
			if (UnityGameObjectPool.<>f__mg$cache1 == null)
			{
				UnityGameObjectPool.<>f__mg$cache1 = new OnAssetLoadFailure(UnityGameObjectPool._OnLoadAssetFailure);
			}
			OnAssetLoadFailure onFailure = UnityGameObjectPool.<>f__mg$cache1;
			if (UnityGameObjectPool.<>f__mg$cache2 == null)
			{
				UnityGameObjectPool.<>f__mg$cache2 = new OnAssetLoadUpdate(UnityGameObjectPool._OnLoadAssetUpdate);
			}
			this.m_AssetLoadCallbacks = new AssetLoadCallbacks(onSuccess, onFailure, UnityGameObjectPool.<>f__mg$cache2);
			base..ctor();
			this.m_RecyclePoolManager = ModuleManager.GetModule<ITMRecyclePoolManager>();
			this.m_AssetManager = ModuleManager.GetModule<ITMAssetManager>();
		}

		// Token: 0x0601A2CA RID: 107210 RVA: 0x008218B4 File Offset: 0x0081FCB4
		private static void _OnLoadAssetSuccess(string assetPath, object asset, int grpID, float duration, object userData)
		{
			if (userData == null)
			{
				TMDebug.LogErrorFormat("User data can not be null when invoke success callback with asset '{0}'!", new object[]
				{
					assetPath
				});
				return;
			}
			UnityGameObjectPool.ObjectRequestContext objectRequestContext = userData as UnityGameObjectPool.ObjectRequestContext;
			if (objectRequestContext == null)
			{
				TMDebug.LogErrorFormat("User data type [{0}] error, expect type[{1}]!", new object[]
				{
					userData.GetType().Name,
					typeof(UnityGameObjectPool.ObjectRequestContext).Name
				});
				return;
			}
			GameObject gameObject = asset as GameObject;
			if (null == gameObject)
			{
				TMDebug.LogErrorFormat("Asset type [{0}] error, expect type[{1}]!", new object[]
				{
					userData.GetType().Name,
					typeof(GameObject).Name
				});
				return;
			}
			UnityGameObjectPool.Object @object = new UnityGameObjectPool.Object();
			@object.Fill(assetPath, gameObject);
			objectRequestContext.m_GameObjectManager._RegiestPoolObject(gameObject.GetInstanceID(), @object);
			@object.OnReuse();
			objectRequestContext.m_Callback.OnAssetLoadSuccess(assetPath, gameObject, objectRequestContext.m_RequestID, duration, objectRequestContext.m_UserData);
		}

		// Token: 0x0601A2CB RID: 107211 RVA: 0x008219A8 File Offset: 0x0081FDA8
		private static void _OnLoadAssetFailure(string assetPath, AssetLoadErrorCode errorCode, string errorMessage, object userData)
		{
			if (userData == null)
			{
				TMDebug.LogErrorFormat("User data can not be null when invoke success callback with asset '{0}'!", new object[]
				{
					assetPath
				});
				return;
			}
			UnityGameObjectPool.ObjectRequestContext objectRequestContext = userData as UnityGameObjectPool.ObjectRequestContext;
			if (objectRequestContext == null)
			{
				TMDebug.LogErrorFormat("User data type [{0}] error, expect type[{1}]!", new object[]
				{
					userData.GetType().Name,
					typeof(UnityGameObjectPool.ObjectRequestContext).Name
				});
				return;
			}
			objectRequestContext.m_Callback.OnAssetLoadFailure(assetPath, errorCode, errorMessage, objectRequestContext.m_UserData);
		}

		// Token: 0x0601A2CC RID: 107212 RVA: 0x00821A27 File Offset: 0x0081FE27
		private static void _OnLoadAssetUpdate(string path, float progress, object userData)
		{
		}

		// Token: 0x0601A2CD RID: 107213 RVA: 0x00821A29 File Offset: 0x0081FE29
		public void SetPoolRootNode(GameObject root)
		{
			this.m_GameObjectRoot = root;
		}

		// Token: 0x0601A2CE RID: 107214 RVA: 0x00821A34 File Offset: 0x0081FE34
		public void SetObjectPoolDesc(string prefabRes, GameObjectUsage objectUsage, int reserouceCount, float expireTime, int priority)
		{
			UnityGameObjectPool.ObjectPoolDesc objectPoolDesc = this._GetObjectPoolDesc(prefabRes, false);
			if (objectPoolDesc != null)
			{
				objectPoolDesc.SetGameObjectUsage(objectUsage);
				objectPoolDesc.GameObjectPool.SetExpireTime(expireTime);
				objectPoolDesc.GameObjectPool.SetPriority(priority);
				objectPoolDesc.GameObjectPool.SetReserveCount(reserouceCount);
				return;
			}
			TMDebug.LogWarningFormat("Can not find game object pool with resource-path '{0}'!", new object[0]);
		}

		// Token: 0x0601A2CF RID: 107215 RVA: 0x00821A90 File Offset: 0x0081FE90
		public GameObject AcquireGameObjectSync(string prefabRes, uint flag)
		{
			if (string.IsNullOrEmpty(prefabRes))
			{
				TMDebug.LogErrorFormat("Prefab resource path can not be null or empty!", new object[0]);
				return null;
			}
			UnityGameObjectPool.ObjectPoolDesc objectPoolDesc = this._GetObjectPoolDesc(prefabRes, true);
			UnityGameObjectPool.Object @object = objectPoolDesc.GameObjectPool.QureyInterface<ITMRecyclePool<UnityGameObjectPool.Object>>().Acquire();
			if (@object != null)
			{
				if (@object.IsValid)
				{
					@object.GameObject.transform.SetParent(null, false);
					return @object.GameObject;
				}
				@object.OnRelease();
				this._UnregiesterPoolObject(@object.InstanceID);
			}
			GameObject gameObject = this.m_AssetManager.LoadAsset(prefabRes, typeof(GameObject), null, flag) as GameObject;
			if (null == gameObject)
			{
				TMDebug.LogErrorFormat("Can not load prefab with path '{0}'!", new object[]
				{
					prefabRes
				});
				return null;
			}
			@object = new UnityGameObjectPool.Object();
			@object.Fill(prefabRes, gameObject);
			this._RegiestPoolObject(@object.InstanceID, @object);
			@object.OnReuse();
			return @object.GameObject;
		}

		// Token: 0x0601A2D0 RID: 107216 RVA: 0x00821B78 File Offset: 0x0081FF78
		public int AcquireGameObjectAsync(string prefabRes, object userData, AssetLoadCallbacks callbacks, uint flag)
		{
			if (string.IsNullOrEmpty(prefabRes))
			{
				TMDebug.LogErrorFormat("Prefab resource path can not be null or empty!", new object[0]);
				return -1;
			}
			int num = (int)this._AllocHandle();
			UnityGameObjectPool.ObjectPoolDesc objectPoolDesc = this._GetObjectPoolDesc(prefabRes, true);
			UnityGameObjectPool.Object @object = objectPoolDesc.GameObjectPool.QureyInterface<ITMRecyclePool<UnityGameObjectPool.Object>>().Acquire();
			if (@object != null)
			{
				@object.GameObject.transform.SetParent(null, false);
				this.m_RequestCacheQueue.Enqueue(new UnityGameObjectPool.ObjectRequestCache(callbacks, prefabRes, @object.GameObject, num, 0f, userData));
				return num;
			}
			UnityGameObjectPool.ObjectRequestContext userData2 = new UnityGameObjectPool.ObjectRequestContext(this, callbacks, prefabRes, num, userData);
			this.m_AssetManager.LoadAssetAsync(prefabRes, typeof(GameObject), this.m_AssetLoadCallbacks, userData2, 0);
			return num;
		}

		// Token: 0x0601A2D1 RID: 107217 RVA: 0x00821C28 File Offset: 0x00820028
		public void RecycleGameObject(GameObject gameObject)
		{
			if (null == gameObject)
			{
				return;
			}
			if (null != this.m_GameObjectRoot)
			{
				int instanceID = gameObject.GetInstanceID();
				UnityGameObjectPool.Object @object = this._GetPoolObject(instanceID);
				if (@object != null)
				{
					UnityGameObjectPool.ObjectPoolDesc objectPoolDesc = this._GetObjectPoolDesc(@object.Name, false);
					if (objectPoolDesc != null)
					{
						gameObject.transform.SetParent(this.m_GameObjectRoot.transform, false);
						objectPoolDesc.GameObjectPool.QureyInterface<ITMRecyclePool<UnityGameObjectPool.Object>>().Recycle(@object);
					}
					else
					{
						TMDebug.LogWarningFormat("Can not find pool with res path '{0}'!", new object[]
						{
							@object.Name
						});
						this._UnregiesterPoolObject(instanceID);
						@object.OnRelease();
					}
					return;
				}
				TMDebug.LogWarningFormat("Game object '{0}' is not in object pool!", new object[]
				{
					gameObject.name
				});
			}
			else
			{
				TMDebug.LogWarningFormat("Root game object can not be null!", new object[0]);
			}
			UnityEngine.Object.Destroy(gameObject);
		}

		// Token: 0x0601A2D2 RID: 107218 RVA: 0x00821D04 File Offset: 0x00820104
		public void PurgePool(bool clearAll)
		{
			List<string> list = FrameStackList<string>.Acquire();
			foreach (KeyValuePair<string, UnityGameObjectPool.ObjectPoolDesc> keyValuePair in this.m_GameObjectPoolSet)
			{
				UnityGameObjectPool.ObjectPoolDesc value = keyValuePair.Value;
				if (value == null)
				{
					List<string> list2 = list;
					Dictionary<string, UnityGameObjectPool.ObjectPoolDesc>.Enumerator enumerator;
					KeyValuePair<string, UnityGameObjectPool.ObjectPoolDesc> keyValuePair2 = enumerator.Current;
					list2.Add(keyValuePair2.Key);
				}
				else
				{
					value.GameObjectPool.PurgePool(clearAll);
				}
			}
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				this.m_GameObjectPoolSet.Remove(list[i]);
				i++;
			}
			FrameStackList<string>.Recycle(list);
			this._PurgePoolObject();
		}

		// Token: 0x0601A2D3 RID: 107219 RVA: 0x00821DB0 File Offset: 0x008201B0
		public void GetAllPoolInfo(ref List<UnityGameObjectPoolInfo> poolInfoList)
		{
			poolInfoList.Clear();
			foreach (KeyValuePair<string, UnityGameObjectPool.ObjectPoolDesc> keyValuePair in this.m_GameObjectPoolSet)
			{
				UnityGameObjectPool.ObjectPoolDesc value = keyValuePair.Value;
				if (value != null)
				{
					RecyclePoolBase gameObjectPool = value.GameObjectPool;
					List<UnityGameObjectPoolInfo> list = poolInfoList;
					Dictionary<string, UnityGameObjectPool.ObjectPoolDesc>.Enumerator enumerator;
					KeyValuePair<string, UnityGameObjectPool.ObjectPoolDesc> keyValuePair2 = enumerator.Current;
					list.Add(new UnityGameObjectPoolInfo(keyValuePair2.Key, value.GameObjectType, gameObjectPool.ReserveCount, gameObjectPool.ExpireTime, gameObjectPool.Priority, gameObjectPool.UnusedObjectCount, gameObjectPool.UsingObjectCount, gameObjectPool.AcquireCount, gameObjectPool.RecycleCount, gameObjectPool.CreateCount, gameObjectPool.ReleaseCount));
				}
			}
		}

		// Token: 0x17002248 RID: 8776
		// (get) Token: 0x0601A2D4 RID: 107220 RVA: 0x00821E5B File Offset: 0x0082025B
		public int GameObjectPoolCount
		{
			get
			{
				return this.m_GameObjectPoolSet.Count;
			}
		}

		// Token: 0x17002249 RID: 8777
		// (get) Token: 0x0601A2D5 RID: 107221 RVA: 0x00821E68 File Offset: 0x00820268
		internal override int Priority
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0601A2D6 RID: 107222 RVA: 0x00821E6C File Offset: 0x0082026C
		internal sealed override void Update(float elapseSeconds, float realElapseSeconds)
		{
			long num = Utility.Time.MicrosecondsToTicks(3f);
			long ticksNow = Utility.Time.GetTicksNow();
			while (this.m_RequestCacheQueue.Count > 0 && Utility.Time.GetTicksNow() - ticksNow < num)
			{
				UnityGameObjectPool.ObjectRequestCache objectRequestCache = this.m_RequestCacheQueue.Dequeue();
				objectRequestCache.m_Callback.OnAssetLoadSuccess(objectRequestCache.m_PrefabPath, objectRequestCache.m_GameObject, objectRequestCache.m_RequestID, 0f, objectRequestCache.m_UserData);
			}
		}

		// Token: 0x0601A2D7 RID: 107223 RVA: 0x00821EEC File Offset: 0x008202EC
		internal sealed override void Shutdown()
		{
			foreach (KeyValuePair<string, UnityGameObjectPool.ObjectPoolDesc> keyValuePair in this.m_GameObjectPoolSet)
			{
				UnityGameObjectPool.ObjectPoolDesc value = keyValuePair.Value;
				if (value != null)
				{
					this.m_RecyclePoolManager.DestroyRecyclePool(value.GameObjectPool);
				}
			}
			this.m_GameObjectPoolSet.Clear();
			this.m_ObjectRevMap.Clear();
		}

		// Token: 0x0601A2D8 RID: 107224 RVA: 0x00821F58 File Offset: 0x00820358
		private UnityGameObjectPool.ObjectPoolDesc _GetObjectPoolDesc(string resKey, bool createIfNil)
		{
			UnityGameObjectPool.ObjectPoolDesc objectPoolDesc = null;
			if (!this.m_GameObjectPoolSet.TryGetValue(resKey, out objectPoolDesc) && createIfNil)
			{
				RecyclePoolBase gameObjectPool = this.m_RecyclePoolManager.CreateRecyclePool<UnityGameObjectPool.Object>(new CreateRecyclable(this._CreateObject));
				objectPoolDesc = new UnityGameObjectPool.ObjectPoolDesc(gameObjectPool, GameObjectUsage.Default);
				this.m_GameObjectPoolSet.Add(resKey, objectPoolDesc);
			}
			return objectPoolDesc;
		}

		// Token: 0x0601A2D9 RID: 107225 RVA: 0x00821FAE File Offset: 0x008203AE
		private void _RegiestPoolObject(int instanceID, UnityGameObjectPool.Object pooledObj)
		{
			this.m_ObjectRevMap.Add(instanceID, pooledObj);
		}

		// Token: 0x0601A2DA RID: 107226 RVA: 0x00821FBD File Offset: 0x008203BD
		private void _UnregiesterPoolObject(int instanceID)
		{
			this.m_ObjectRevMap.Remove(instanceID);
		}

		// Token: 0x0601A2DB RID: 107227 RVA: 0x00821FCC File Offset: 0x008203CC
		private UnityGameObjectPool.Object _GetPoolObject(int instanceID)
		{
			UnityGameObjectPool.Object result = null;
			if (this.m_ObjectRevMap.TryGetValue(instanceID, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0601A2DC RID: 107228 RVA: 0x00821FF4 File Offset: 0x008203F4
		private void _PurgePoolObject()
		{
			List<int> list = FrameStackList<int>.Acquire();
			foreach (KeyValuePair<int, UnityGameObjectPool.Object> keyValuePair in this.m_ObjectRevMap)
			{
				UnityGameObjectPool.Object value = keyValuePair.Value;
				if (null == value.GameObject)
				{
					List<int> list2 = list;
					Dictionary<int, UnityGameObjectPool.Object>.Enumerator enumerator;
					KeyValuePair<int, UnityGameObjectPool.Object> keyValuePair2 = enumerator.Current;
					list2.Add(keyValuePair2.Key);
				}
			}
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				this.m_ObjectRevMap.Remove(list[i]);
				i++;
			}
			FrameStackList<int>.Recycle(list);
		}

		// Token: 0x0601A2DD RID: 107229 RVA: 0x00822094 File Offset: 0x00820494
		private Recyclable _CreateObject()
		{
			return null;
		}

		// Token: 0x0601A2DE RID: 107230 RVA: 0x00822098 File Offset: 0x00820498
		protected uint _AllocHandle()
		{
			if (this.m_RequestIDCount + 1U >= 1073741823U)
			{
				this.m_RequestIDCount = 0U;
			}
			return this.m_RequestIDCount++ | (this.m_RequestIDType & 3U) << 30;
		}

		// Token: 0x04012635 RID: 75317
		private readonly ITMRecyclePoolManager m_RecyclePoolManager;

		// Token: 0x04012636 RID: 75318
		private readonly ITMAssetManager m_AssetManager;

		// Token: 0x04012637 RID: 75319
		private GameObject m_GameObjectRoot;

		// Token: 0x04012638 RID: 75320
		private uint m_RequestIDCount;

		// Token: 0x04012639 RID: 75321
		private readonly uint m_RequestIDType = 1U;

		// Token: 0x0401263A RID: 75322
		private readonly Dictionary<string, UnityGameObjectPool.ObjectPoolDesc> m_GameObjectPoolSet = new Dictionary<string, UnityGameObjectPool.ObjectPoolDesc>();

		// Token: 0x0401263B RID: 75323
		private readonly Dictionary<int, UnityGameObjectPool.Object> m_ObjectRevMap = new Dictionary<int, UnityGameObjectPool.Object>();

		// Token: 0x0401263C RID: 75324
		private Queue<UnityGameObjectPool.ObjectRequestCache> m_RequestCacheQueue = new Queue<UnityGameObjectPool.ObjectRequestCache>();

		// Token: 0x0401263D RID: 75325
		private AssetLoadCallbacks m_AssetLoadCallbacks;

		// Token: 0x0401263E RID: 75326
		[CompilerGenerated]
		private static OnAssetLoadSuccess <>f__mg$cache0;

		// Token: 0x0401263F RID: 75327
		[CompilerGenerated]
		private static OnAssetLoadFailure <>f__mg$cache1;

		// Token: 0x04012640 RID: 75328
		[CompilerGenerated]
		private static OnAssetLoadUpdate <>f__mg$cache2;

		// Token: 0x02004734 RID: 18228
		internal sealed class Object : Recyclable
		{
			// Token: 0x0601A2E0 RID: 107232 RVA: 0x008220E4 File Offset: 0x008204E4
			public bool Fill(string name, GameObject go)
			{
				if (null == go)
				{
					TMDebug.LogErrorFormat("Game object can not be null!", new object[0]);
					return false;
				}
				if (string.IsNullOrEmpty(name))
				{
					TMDebug.LogErrorFormat("Name can not be null or empty string!", new object[0]);
					return false;
				}
				this.m_Name = name;
				this.m_GameObject = go;
				this.m_InstanceID = go.GetInstanceID();
				this.m_OriginScale = go.transform.localScale;
				return true;
			}

			// Token: 0x0601A2E1 RID: 107233 RVA: 0x00822158 File Offset: 0x00820558
			public sealed override void OnReuse()
			{
				base.OnReuse();
				if (null != this.m_GameObject)
				{
					this.m_GameObject.SetActive(true);
					this.m_GameObject.transform.localPosition = Vector3.zero;
					this.m_GameObject.transform.localRotation = Quaternion.identity;
					this.m_GameObject.transform.localScale = this.m_OriginScale;
				}
				else
				{
					TMDebug.LogWarningFormat("Game object named '{0}' is already be destroyed!", new object[]
					{
						this.Name
					});
				}
			}

			// Token: 0x0601A2E2 RID: 107234 RVA: 0x008221E8 File Offset: 0x008205E8
			public sealed override void OnRecycle()
			{
				base.OnRecycle();
				if (null != this.m_GameObject)
				{
					this.m_GameObject.SetActive(false);
				}
				else
				{
					TMDebug.LogWarningFormat("Game object named '{0}' is already be destroyed!", new object[]
					{
						this.Name
					});
				}
			}

			// Token: 0x0601A2E3 RID: 107235 RVA: 0x00822236 File Offset: 0x00820636
			public sealed override void OnRelease()
			{
				if (null != this.m_GameObject)
				{
					UnityEngine.Object.Destroy(this.m_GameObject);
				}
			}

			// Token: 0x1700224A RID: 8778
			// (get) Token: 0x0601A2E4 RID: 107236 RVA: 0x00822254 File Offset: 0x00820654
			public sealed override string Name
			{
				get
				{
					return this.m_Name;
				}
			}

			// Token: 0x1700224B RID: 8779
			// (get) Token: 0x0601A2E5 RID: 107237 RVA: 0x0082225C File Offset: 0x0082065C
			public GameObject GameObject
			{
				get
				{
					return this.m_GameObject;
				}
			}

			// Token: 0x1700224C RID: 8780
			// (get) Token: 0x0601A2E6 RID: 107238 RVA: 0x00822264 File Offset: 0x00820664
			public sealed override bool IsValid
			{
				get
				{
					return null != this.m_GameObject;
				}
			}

			// Token: 0x1700224D RID: 8781
			// (get) Token: 0x0601A2E7 RID: 107239 RVA: 0x00822272 File Offset: 0x00820672
			public int InstanceID
			{
				get
				{
					return this.m_InstanceID;
				}
			}

			// Token: 0x04012641 RID: 75329
			private string m_Name;

			// Token: 0x04012642 RID: 75330
			private GameObject m_GameObject;

			// Token: 0x04012643 RID: 75331
			private int m_InstanceID;

			// Token: 0x04012644 RID: 75332
			private Vector3 m_OriginScale;
		}

		// Token: 0x02004735 RID: 18229
		private class ObjectPoolDesc
		{
			// Token: 0x0601A2E8 RID: 107240 RVA: 0x0082227A File Offset: 0x0082067A
			public ObjectPoolDesc(RecyclePoolBase gameObjectPool, GameObjectUsage gameObjectUsage)
			{
				this.m_GameObjectUsage = gameObjectUsage;
				this.m_GameObjectPool = gameObjectPool;
			}

			// Token: 0x0601A2E9 RID: 107241 RVA: 0x00822290 File Offset: 0x00820690
			public void SetGameObjectUsage(GameObjectUsage gameObjectUsage)
			{
				this.m_GameObjectUsage = gameObjectUsage;
			}

			// Token: 0x1700224E RID: 8782
			// (get) Token: 0x0601A2EA RID: 107242 RVA: 0x00822299 File Offset: 0x00820699
			public GameObjectUsage GameObjectType
			{
				get
				{
					return this.m_GameObjectUsage;
				}
			}

			// Token: 0x1700224F RID: 8783
			// (get) Token: 0x0601A2EB RID: 107243 RVA: 0x008222A1 File Offset: 0x008206A1
			public RecyclePoolBase GameObjectPool
			{
				get
				{
					return this.m_GameObjectPool;
				}
			}

			// Token: 0x04012645 RID: 75333
			private GameObjectUsage m_GameObjectUsage;

			// Token: 0x04012646 RID: 75334
			private readonly RecyclePoolBase m_GameObjectPool;
		}

		// Token: 0x02004736 RID: 18230
		private struct ObjectRequestCache
		{
			// Token: 0x0601A2EC RID: 107244 RVA: 0x008222A9 File Offset: 0x008206A9
			public ObjectRequestCache(AssetLoadCallbacks callbacks, string prefabPath, GameObject go, int requestID, float duration, object userData)
			{
				this.m_Callback = callbacks;
				this.m_PrefabPath = prefabPath;
				this.m_GameObject = go;
				this.m_RequestID = requestID;
				this.m_Duration = duration;
				this.m_UserData = userData;
			}

			// Token: 0x04012647 RID: 75335
			public AssetLoadCallbacks m_Callback;

			// Token: 0x04012648 RID: 75336
			public string m_PrefabPath;

			// Token: 0x04012649 RID: 75337
			public GameObject m_GameObject;

			// Token: 0x0401264A RID: 75338
			public int m_RequestID;

			// Token: 0x0401264B RID: 75339
			public float m_Duration;

			// Token: 0x0401264C RID: 75340
			public object m_UserData;
		}

		// Token: 0x02004737 RID: 18231
		private class ObjectRequestContext
		{
			// Token: 0x0601A2ED RID: 107245 RVA: 0x008222D8 File Offset: 0x008206D8
			public ObjectRequestContext(UnityGameObjectPool gameObjectManager, AssetLoadCallbacks callbacks, string prefabPath, int requestID, object userData)
			{
				this.m_GameObjectManager = gameObjectManager;
				this.m_Callback = callbacks;
				this.m_RequestID = requestID;
				this.m_UserData = userData;
			}

			// Token: 0x0401264D RID: 75341
			public UnityGameObjectPool m_GameObjectManager;

			// Token: 0x0401264E RID: 75342
			public AssetLoadCallbacks m_Callback;

			// Token: 0x0401264F RID: 75343
			public int m_RequestID;

			// Token: 0x04012650 RID: 75344
			public object m_UserData;
		}
	}
}
