using System;
using System.Collections.Generic;
using System.IO;
using GamePool;
using TMEngine.Runtime;
using UnityEngine;

// Token: 0x020000B3 RID: 179
public class AssetLoader : Singleton<AssetLoader>
{
	// Token: 0x060003A5 RID: 933 RVA: 0x0001AC68 File Offset: 0x00019068
	private static ITMAssetManager _GetAssetManager()
	{
		if (AssetLoader.m_AssetManager == null)
		{
			AssetLoader.m_AssetManager = ModuleManager.GetModule<ITMAssetManager>();
		}
		return AssetLoader.m_AssetManager;
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x0001AC84 File Offset: 0x00019084
	private AssetInst _LoadRes_TMEngine(string path, Type type, bool isMustExist = true, uint flag = 0U)
	{
		ITMAssetManager itmassetManager = AssetLoader._GetAssetManager();
		object obj = null;
		if (itmassetManager != null)
		{
			obj = itmassetManager.LoadAsset(path, type, null, 0U);
		}
		return new AssetInst(obj as Object);
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x0001ACB8 File Offset: 0x000190B8
	private bool _PreLoadRes_TMEngine(string path, Type type, bool isMustExist = true, uint flag = 0U)
	{
		ITMAssetManager itmassetManager = AssetLoader._GetAssetManager();
		return itmassetManager != null && itmassetManager.PreLoadAsset(path, type, null, 0U);
	}

	// Token: 0x060003A8 RID: 936 RVA: 0x0001ACE0 File Offset: 0x000190E0
	private static int _LoadResAsync_TMEngine(string path, Type type, AssetLoadCallbacks callbacks, object userData, uint flag, uint waterMark)
	{
		ITMAssetManager itmassetManager = AssetLoader._GetAssetManager();
		if (itmassetManager != null)
		{
			return itmassetManager.LoadAssetAsync(path, type, callbacks, userData, (flag != 1U) ? 0 : 1);
		}
		return -1;
	}

	// Token: 0x060003A9 RID: 937 RVA: 0x0001AD14 File Offset: 0x00019114
	public static bool IsResExist(string path, Type type, bool loadFromPackage)
	{
		ITMAssetManager itmassetManager = AssetLoader._GetAssetManager();
		return itmassetManager != null && itmassetManager.IsAssetExist(path, type, loadFromPackage);
	}

	// Token: 0x060003AA RID: 938 RVA: 0x0001AD38 File Offset: 0x00019138
	public static void QurreyResPackage(string path, List<string> packages)
	{
		packages.Clear();
		ITMAssetManager itmassetManager = AssetLoader._GetAssetManager();
		if (itmassetManager != null)
		{
			itmassetManager.QurreyAssetPackage(path, packages);
		}
	}

	// Token: 0x060003AB RID: 939 RVA: 0x0001AD5F File Offset: 0x0001915F
	public static uint LoadResAsync(string path, Type type, AssetLoadCallbacks callbacks, object userData, uint flag = 0U, uint waterMark = 0U)
	{
		return (uint)AssetLoader._LoadResAsync_TMEngine(path, type, callbacks, userData, flag, waterMark);
	}

	// Token: 0x060003AC RID: 940 RVA: 0x0001AD6E File Offset: 0x0001916E
	public static uint LoadResAsGameObjectAsync(string path, AssetLoadCallbacks callbacks, object userData, uint flag = 0U, uint waterMark = 0U)
	{
		return (uint)AssetLoader._LoadResAsync_TMEngine(path, typeof(GameObject), callbacks, userData, flag, waterMark);
	}

	// Token: 0x060003AD RID: 941 RVA: 0x0001AD85 File Offset: 0x00019185
	public static void AbortLoadRequest(uint handle)
	{
	}

	// Token: 0x060003AE RID: 942 RVA: 0x0001AD88 File Offset: 0x00019188
	public static bool IsAssetManagerReady()
	{
		if (EngineConfig.useTMEngine)
		{
			ITMAssetManager itmassetManager = AssetLoader._GetAssetManager();
			return itmassetManager != null && itmassetManager.IsAssetLoaderReady;
		}
		return true;
	}

	// Token: 0x17000030 RID: 48
	// (get) Token: 0x060003B0 RID: 944 RVA: 0x0001ADBD File Offset: 0x000191BD
	// (set) Token: 0x060003AF RID: 943 RVA: 0x0001ADB5 File Offset: 0x000191B5
	public static bool AsyncLoadPackageRes
	{
		get
		{
			return AssetLoader.m_AsyncLoadPackageRes;
		}
		set
		{
			AssetLoader.m_AsyncLoadPackageRes = value;
		}
	}

	// Token: 0x060003B1 RID: 945 RVA: 0x0001ADC4 File Offset: 0x000191C4
	public bool PreLoadRes(string path, Type type, bool isMustExist = true, uint flag = 0U)
	{
		return EngineConfig.useTMEngine && this._PreLoadRes_TMEngine(path, type, isMustExist, flag);
	}

	// Token: 0x060003B2 RID: 946 RVA: 0x0001ADE0 File Offset: 0x000191E0
	public AssetInst LoadRes(string path, Type type, bool isMustExist = true, uint flag = 0U)
	{
		if (EngineConfig.useTMEngine)
		{
			return this._LoadRes_TMEngine(path, type, isMustExist, flag);
		}
		this._TickAutoPurgeCnt();
		global::AssetDesc assetDesc = null;
		if (this._GetCachedAssetDesc(path, type, out assetDesc))
		{
			if (assetDesc != null)
			{
				return assetDesc.CreateRefInst(0U);
			}
			this._RemoveCacheAssetDesc(path, type);
		}
		string fullPath;
		string subRes;
		this._ParseAssetPath(path, out fullPath, out subRes);
		if (Singleton<AsyncLoadTaskAllocator<ResourceRequestWrapper, Object>>.instance.IsResInAsyncLoading(path))
		{
			return null;
		}
		assetDesc = new global::AssetDesc();
		if (assetDesc.Init(fullPath, type, subRes))
		{
			this._RecordLoadFile(path);
			this._AddCachedAssetDesc(path, type, assetDesc);
			return assetDesc.CreateRefInst(0U);
		}
		if (isMustExist)
		{
			Logger.LogErrorFormat("Can not instantiate asset with path \"{0}\"!", new object[]
			{
				path
			});
		}
		return null;
	}

	// Token: 0x060003B3 RID: 947 RVA: 0x0001AE94 File Offset: 0x00019294
	public AssetInst LoadRes(string path, bool isMustExist = true, uint flag = 0U)
	{
		return this.LoadRes(path, typeof(Object), isMustExist, flag);
	}

	// Token: 0x060003B4 RID: 948 RVA: 0x0001AEAC File Offset: 0x000192AC
	public GameObject LoadResAsGameObject(string path, bool isMustExist = true, uint flag = 0U)
	{
		AssetInst assetInst = this.LoadRes(path, typeof(GameObject), isMustExist, flag);
		if (assetInst == null)
		{
			return null;
		}
		if (assetInst.obj == null)
		{
			return null;
		}
		GameObject gameObject = assetInst.obj as GameObject;
		if (gameObject == null)
		{
		}
		return gameObject;
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x0001AF04 File Offset: 0x00019304
	public uint LoadResAync(string path, Type type, bool isMustExist = true, uint flag = 0U, uint waterMark = 0U)
	{
		if (EngineConfig.useTMEngine)
		{
			throw new Exception("Method expired!");
		}
		if (string.IsNullOrEmpty(path))
		{
			return AssetLoader.INVILID_HANDLE;
		}
		IAssetInstRequest assetInstRequest = this._LoadResAync(path, type, isMustExist, flag, waterMark);
		if (assetInstRequest != null)
		{
			return this.m_AsyncRequestAllocator.AddAsyncRequest(assetInstRequest);
		}
		Logger.LogErrorFormat("Async load asset [{0}] has failed!", new object[]
		{
			path
		});
		return AssetLoader.INVILID_HANDLE;
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x0001AF71 File Offset: 0x00019371
	public uint LoadResAsyncAsGameObject(string path, bool isMustExist = true, uint flag = 0U, uint waterMark = 0U)
	{
		return this.LoadResAync(path, typeof(GameObject), isMustExist, flag, waterMark);
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x0001AF88 File Offset: 0x00019388
	public bool IsRequestDone(uint handle)
	{
		IAssetInstRequest asyncRequestByHandle = this.m_AsyncRequestAllocator.GetAsyncRequestByHandle(handle);
		if (asyncRequestByHandle != null)
		{
			return asyncRequestByHandle.IsDone();
		}
		Logger.LogErrorFormat("Asset async-load handle [0x{0}] is invalid or expired!", new object[]
		{
			handle.ToString("x")
		});
		return false;
	}

	// Token: 0x060003B8 RID: 952 RVA: 0x0001AFD0 File Offset: 0x000193D0
	public void AbortRequest(uint handle)
	{
		if (EngineConfig.useTMEngine)
		{
			return;
		}
		IAssetInstRequest asyncRequestByHandle = this.m_AsyncRequestAllocator.GetAsyncRequestByHandle(handle);
		if (asyncRequestByHandle != null)
		{
			this.m_AsyncRequestAllocator.RemoveAsyncRequest(handle);
			asyncRequestByHandle.Abort();
		}
		else
		{
			Logger.LogErrorFormat("Asset async-load handle [0x{0}] is invalid or expired!", new object[]
			{
				handle.ToString("x")
			});
		}
	}

	// Token: 0x060003B9 RID: 953 RVA: 0x0001B034 File Offset: 0x00019434
	public AssetInst Extract(uint handle)
	{
		IAssetInstRequest asyncRequestByHandle = this.m_AsyncRequestAllocator.GetAsyncRequestByHandle(handle);
		if (asyncRequestByHandle != null)
		{
			if (asyncRequestByHandle.IsDone())
			{
				this.m_AsyncRequestAllocator.RemoveAsyncRequest(handle);
				return asyncRequestByHandle.Extract();
			}
		}
		else
		{
			Logger.LogErrorFormat("Asset async-load handle [0x{0}] is invalid or expired!", new object[]
			{
				handle.ToString("x")
			});
		}
		return null;
	}

	// Token: 0x060003BA RID: 954 RVA: 0x0001B098 File Offset: 0x00019498
	public bool IsValidHandle(uint handle)
	{
		if (this.m_AsyncRequestAllocator.GetAsyncRequestByHandle(handle) == null)
		{
			Logger.LogErrorFormat("Asset async-load handle [0x{0}] is invalid or expired!", new object[]
			{
				handle.ToString("x")
			});
			return false;
		}
		return true;
	}

	// Token: 0x060003BB RID: 955 RVA: 0x0001B0DA File Offset: 0x000194DA
	public void SetAsyncLoadStep(int step)
	{
		if (0 < step && step < 8)
		{
			this.m_AsyncStep = step;
		}
		else
		{
			Logger.LogErrorFormat("Input async load step [{0}] is invalid value!", new object[]
			{
				step
			});
		}
	}

	// Token: 0x060003BC RID: 956 RVA: 0x0001B10F File Offset: 0x0001950F
	public int GetAsyncLoadStep()
	{
		return this.m_AsyncStep;
	}

	// Token: 0x060003BD RID: 957 RVA: 0x0001B117 File Offset: 0x00019517
	public void SetPurgeTime(float timeLen)
	{
		this.m_PurgeTime = timeLen;
	}

	// Token: 0x060003BE RID: 958 RVA: 0x0001B120 File Offset: 0x00019520
	public void SetAutoPurgeCount(int cnt)
	{
		this.m_AutoPurgeCnt = cnt;
	}

	// Token: 0x060003BF RID: 959 RVA: 0x0001B129 File Offset: 0x00019529
	public void ResetPurgeTick()
	{
		this.m_CurPurgeCnt = 0;
	}

	// Token: 0x060003C0 RID: 960 RVA: 0x0001B134 File Offset: 0x00019534
	public bool LockAsset(string assetName, int lockFlag)
	{
		if (EngineConfig.useTMEngine)
		{
			ITMAssetManager itmassetManager = AssetLoader._GetAssetManager();
			if (itmassetManager != null)
			{
				return itmassetManager.LockAsset(assetName, lockFlag);
			}
		}
		return false;
	}

	// Token: 0x060003C1 RID: 961 RVA: 0x0001B164 File Offset: 0x00019564
	public void PurgeUnusedRes(bool ignoreTime = false, Type type = null)
	{
		if (EngineConfig.useTMEngine)
		{
			ITMAssetManager itmassetManager = AssetLoader._GetAssetManager();
			if (itmassetManager != null)
			{
				itmassetManager.BeginClearUnusedAssets(false);
				itmassetManager.EndClearUnusedAssets();
			}
			return;
		}
		Dictionary<string, List<AssetLoader.AssetInfo>>.Enumerator enumerator = this.m_ResDescCacheTableEx.GetEnumerator();
		List<AssetLoader.AssetDelKey> list = ListPool<AssetLoader.AssetDelKey>.Get();
		while (enumerator.MoveNext())
		{
			KeyValuePair<string, List<AssetLoader.AssetInfo>> keyValuePair = enumerator.Current;
			List<AssetLoader.AssetInfo> value = keyValuePair.Value;
			if (value != null)
			{
				int i = 0;
				int count = value.Count;
				while (i < count)
				{
					AssetLoader.AssetInfo assetInfo = value[i];
					if (assetInfo == null || assetInfo.m_AssetDesc == null)
					{
						AssetLoader.AssetDelKey item = default(AssetLoader.AssetDelKey);
						KeyValuePair<string, List<AssetLoader.AssetInfo>> keyValuePair2 = enumerator.Current;
						item.path = keyValuePair2.Key;
						item.type = null;
						list.Add(item);
					}
					else if (type == null || type == assetInfo.m_AssetDesc.assetType)
					{
						if (assetInfo.m_AssetDesc.CanBeRemoved() && (ignoreTime || Time.time - assetInfo.m_AssetDesc.lastUseTime > this.m_PurgeTime))
						{
							assetInfo.m_AssetDesc.Deinit();
							AssetLoader.AssetDelKey item2 = default(AssetLoader.AssetDelKey);
							KeyValuePair<string, List<AssetLoader.AssetInfo>> keyValuePair3 = enumerator.Current;
							item2.path = keyValuePair3.Key;
							item2.type = assetInfo.m_AssetType;
							list.Add(item2);
						}
					}
					i++;
				}
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			this._RemoveCacheAssetDesc(list[j].path, list[j].type);
		}
		ListPool<AssetLoader.AssetDelKey>.Release(list);
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x0001B320 File Offset: 0x00019720
	public void ClearAll(bool force = false)
	{
		Dictionary<string, List<AssetLoader.AssetInfo>>.Enumerator enumerator = this.m_ResDescCacheTableEx.GetEnumerator();
		List<AssetLoader.AssetDelKey> list = ListPool<AssetLoader.AssetDelKey>.Get();
		while (enumerator.MoveNext())
		{
			KeyValuePair<string, List<AssetLoader.AssetInfo>> keyValuePair = enumerator.Current;
			List<AssetLoader.AssetInfo> value = keyValuePair.Value;
			if (value != null)
			{
				int i = 0;
				int count = value.Count;
				while (i < count)
				{
					AssetLoader.AssetInfo assetInfo = value[i];
					if (assetInfo != null && assetInfo.m_AssetDesc != null)
					{
						if (assetInfo.m_AssetDesc.CanBeRemoved())
						{
							assetInfo.m_AssetDesc.Deinit();
							AssetLoader.AssetDelKey item = default(AssetLoader.AssetDelKey);
							KeyValuePair<string, List<AssetLoader.AssetInfo>> keyValuePair2 = enumerator.Current;
							item.path = keyValuePair2.Key;
							item.type = assetInfo.m_AssetType;
							list.Add(item);
						}
						else if (force)
						{
							assetInfo.m_AssetDesc.Deinit();
							AssetLoader.AssetDelKey item2 = default(AssetLoader.AssetDelKey);
							KeyValuePair<string, List<AssetLoader.AssetInfo>> keyValuePair3 = enumerator.Current;
							item2.path = keyValuePair3.Key;
							item2.type = assetInfo.m_AssetType;
							list.Add(item2);
						}
					}
					i++;
				}
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			this._RemoveCacheAssetDesc(list[j].path, list[j].type);
		}
		ListPool<AssetLoader.AssetDelKey>.Release(list);
	}

	// Token: 0x060003C3 RID: 963 RVA: 0x0001B493 File Offset: 0x00019893
	public override void Init()
	{
		base.Init();
		MonoSingleton<AssetAsyncLoader>.instance.Init();
	}

	// Token: 0x060003C4 RID: 964 RVA: 0x0001B4A8 File Offset: 0x000198A8
	private void _ParseAssetPath(string assetPath, out string mainRes, out string subRes)
	{
		string[] array = assetPath.Split(new char[]
		{
			':'
		});
		if (array.Length > 1)
		{
			subRes = array[1];
			mainRes = array[0];
		}
		else
		{
			subRes = string.Empty;
			mainRes = assetPath;
		}
	}

	// Token: 0x060003C5 RID: 965 RVA: 0x0001B4EC File Offset: 0x000198EC
	private AssetInstRequest _CheckResInLoading(List<AssetLoader.AsyncLoadTaskDesc> asyncLoadTaskList, string path, Type type, uint flag = 0U, uint waterMark = 0U)
	{
		AssetInstRequest assetInstRequest = null;
		for (int i = 0; i < asyncLoadTaskList.Count; i++)
		{
			AssetLoader.AsyncLoadTaskDesc asyncLoadTaskDesc = asyncLoadTaskList[i];
			if (path == asyncLoadTaskDesc.m_ResPath && type == asyncLoadTaskDesc.m_ResType)
			{
				assetInstRequest = this._AllocAssetInstRequest();
				assetInstRequest.m_flag = flag;
				assetInstRequest.m_waterMark = waterMark;
				asyncLoadTaskDesc.m_WaitingReqList.Add(assetInstRequest);
				break;
			}
		}
		return assetInstRequest;
	}

	// Token: 0x060003C6 RID: 966 RVA: 0x0001B560 File Offset: 0x00019960
	public IAssetInstRequest _LoadResAync(string path, Type type, bool isMustExist = true, uint flag = 0U, uint waterMark = 0U)
	{
		this._TickAutoPurgeCnt();
		global::AssetDesc assetDesc = null;
		AssetInstRequest assetInstRequest;
		if (this._GetCachedAssetDesc(path, type, out assetDesc))
		{
			assetInstRequest = this._AllocAssetInstRequest();
			assetInstRequest.m_AssetInst = assetDesc.CreateRefInst(flag);
			assetInstRequest.m_IsDone = true;
			assetInstRequest.m_HasExtract = false;
			assetInstRequest.m_flag = flag;
			assetInstRequest.m_waterMark = waterMark;
			this.m_CompletedReqList.Add(assetInstRequest);
			return assetInstRequest;
		}
		string text;
		string subRes;
		this._ParseAssetPath(path, out text, out subRes);
		assetInstRequest = this._CheckResInLoading(this.m_HighPriorityAsyncLoadTaskList, path, type, flag, waterMark);
		if (assetInstRequest != null)
		{
			return assetInstRequest;
		}
		assetInstRequest = this._CheckResInLoading(this.m_AsyncLoadTaskList, path, type, flag, waterMark);
		if (assetInstRequest != null)
		{
			return assetInstRequest;
		}
		this._RecordLoadFile(path);
		assetDesc = new global::AssetDesc();
		bool highPriority = 0U != (flag & 16U);
		assetDesc.InitAsync(path, type, subRes, highPriority);
		AssetLoader.AsyncLoadTaskDesc asyncLoadTaskDesc = new AssetLoader.AsyncLoadTaskDesc();
		asyncLoadTaskDesc.m_AssetDesc = assetDesc;
		asyncLoadTaskDesc.m_ResPath = path;
		asyncLoadTaskDesc.m_SubRes = subRes;
		asyncLoadTaskDesc.m_ResType = type;
		assetInstRequest = this._AllocAssetInstRequest();
		assetInstRequest.m_flag = flag;
		assetInstRequest.m_waterMark = waterMark;
		asyncLoadTaskDesc.m_WaitingReqList.Add(assetInstRequest);
		if ((flag & 16U) != 0U)
		{
			this.m_HighPriorityAsyncLoadTaskList.Add(asyncLoadTaskDesc);
		}
		else
		{
			this.m_AsyncLoadTaskList.Add(asyncLoadTaskDesc);
		}
		return assetInstRequest;
	}

	// Token: 0x060003C7 RID: 967 RVA: 0x0001B6A4 File Offset: 0x00019AA4
	private void _AddCachedAssetDesc(string path, Type type, global::AssetDesc assetDesc)
	{
		List<AssetLoader.AssetInfo> list = null;
		if (this.m_ResDescCacheTableEx.TryGetValue(path, out list))
		{
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				AssetLoader.AssetInfo assetInfo = list[i];
				if (assetInfo != null)
				{
					if (assetInfo.m_AssetType == type)
					{
						Logger.LogErrorFormat("Multiple asset desc with path {0} and type {1}", new object[]
						{
							path,
							type.Name
						});
						return;
					}
				}
				i++;
			}
			list.Add(new AssetLoader.AssetInfo(type, assetDesc));
			return;
		}
		list = new List<AssetLoader.AssetInfo>();
		list.Add(new AssetLoader.AssetInfo(type, assetDesc));
		this.m_ResDescCacheTableEx.Add(path, list);
	}

	// Token: 0x060003C8 RID: 968 RVA: 0x0001B74C File Offset: 0x00019B4C
	private void _RemoveCacheAssetDesc(string path, Type type)
	{
		List<AssetLoader.AssetInfo> list = null;
		if (this.m_ResDescCacheTableEx.TryGetValue(path, out list))
		{
			if (type == null)
			{
				this.m_ResDescCacheTableEx.Remove(path);
				return;
			}
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				AssetLoader.AssetInfo assetInfo = list[i];
				if (assetInfo != null)
				{
					if (assetInfo.m_AssetType == type)
					{
						list.RemoveAt(i);
						if (list.Count <= 0)
						{
							this.m_ResDescCacheTableEx.Remove(path);
						}
						return;
					}
				}
				i++;
			}
		}
		Debug.LogErrorFormat("########################## Path:[{0}] Type:{1}", new object[]
		{
			path,
			type
		});
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x0001B7F4 File Offset: 0x00019BF4
	private bool _GetCachedAssetDesc(string path, Type type, out global::AssetDesc assetDesc)
	{
		assetDesc = null;
		List<AssetLoader.AssetInfo> list = null;
		if (this.m_ResDescCacheTableEx.TryGetValue(path, out list))
		{
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				AssetLoader.AssetInfo assetInfo = list[i];
				if (assetInfo != null)
				{
					if (assetInfo.m_AssetType == type)
					{
						assetDesc = assetInfo.m_AssetDesc;
						return true;
					}
				}
				i++;
			}
		}
		return false;
	}

	// Token: 0x060003CA RID: 970 RVA: 0x0001B85C File Offset: 0x00019C5C
	private void _TickAutoPurgeCnt()
	{
		Singleton<AssetGabageCollectorHelper>.instance.AddGCPurgeTick(AssetGCTickType.Asset);
	}

	// Token: 0x17000031 RID: 49
	// (get) Token: 0x060003CB RID: 971 RVA: 0x0001B869 File Offset: 0x00019C69
	public int CompleteTaskCount
	{
		get
		{
			return this.m_CompletedReqList.Count;
		}
	}

	// Token: 0x17000032 RID: 50
	// (get) Token: 0x060003CC RID: 972 RVA: 0x0001B876 File Offset: 0x00019C76
	public int LoadingTaskCount
	{
		get
		{
			return this.m_AsyncLoadTaskList.Count + this.m_HighPriorityAsyncLoadTaskList.Count;
		}
	}

	// Token: 0x060003CD RID: 973 RVA: 0x0001B890 File Offset: 0x00019C90
	protected AssetInstRequest _AllocAssetInstRequest()
	{
		AssetInstRequest assetInstRequest = null;
		if (this.m_AssetInstReqPool.Count > 0)
		{
			assetInstRequest = this.m_AssetInstReqPool[0];
			this.m_AssetInstReqPool.RemoveAt(0);
		}
		if (assetInstRequest == null)
		{
			assetInstRequest = new AssetInstRequest();
		}
		assetInstRequest.Reset();
		return assetInstRequest;
	}

	// Token: 0x060003CE RID: 974 RVA: 0x0001B8DC File Offset: 0x00019CDC
	protected void _CheckAsyncLoadTaskList(List<AssetLoader.AsyncLoadTaskDesc> asyncLoadTaskList, ref int step)
	{
		int i = 0;
		int num = asyncLoadTaskList.Count;
		while (i < num)
		{
			AssetLoader.AsyncLoadTaskDesc asyncLoadTaskDesc = asyncLoadTaskList[i];
			if (asyncLoadTaskDesc == null)
			{
				asyncLoadTaskList.RemoveAt(i);
				i--;
				num--;
			}
			else if (!asyncLoadTaskDesc.m_AssetDesc.CheckAsyncLoadComplete())
			{
				int j = 0;
				int num2 = asyncLoadTaskDesc.m_WaitingReqList.Count;
				while (j < num2)
				{
					AssetInstRequest assetInstRequest = asyncLoadTaskDesc.m_WaitingReqList[j];
					if (assetInstRequest == null || assetInstRequest.m_IsAbort)
					{
						asyncLoadTaskDesc.m_WaitingReqList.RemoveAt(j);
						j--;
						num2--;
					}
					j++;
				}
			}
			else if (asyncLoadTaskDesc.m_AssetDesc.IsDeadAsset)
			{
				asyncLoadTaskDesc.m_AssetDesc.InitAsync(asyncLoadTaskDesc.m_ResPath, asyncLoadTaskDesc.m_ResType, asyncLoadTaskDesc.m_SubRes, true);
			}
			else
			{
				global::AssetDesc assetDesc = null;
				if (!this._GetCachedAssetDesc(asyncLoadTaskDesc.m_ResPath, asyncLoadTaskDesc.m_ResType, out assetDesc))
				{
					this._AddCachedAssetDesc(asyncLoadTaskDesc.m_ResPath, asyncLoadTaskDesc.m_ResType, asyncLoadTaskDesc.m_AssetDesc);
				}
				int k = 0;
				int num3 = asyncLoadTaskDesc.m_WaitingReqList.Count;
				while (k < num3)
				{
					AssetInstRequest assetInstRequest2 = asyncLoadTaskDesc.m_WaitingReqList[k];
					if (assetInstRequest2 != null && !assetInstRequest2.m_IsAbort)
					{
						assetInstRequest2.m_AssetInst = asyncLoadTaskDesc.m_AssetDesc.CreateRefInst(assetInstRequest2.m_flag);
						assetInstRequest2.m_IsDone = true;
						this.m_ReqCompleteList.Add(assetInstRequest2);
						step--;
					}
					asyncLoadTaskDesc.m_WaitingReqList.RemoveAt(k);
					k--;
					num3--;
					if (step <= 0)
					{
						break;
					}
					k++;
				}
				if (asyncLoadTaskDesc.m_WaitingReqList.Count <= 0)
				{
					asyncLoadTaskList.RemoveAt(i);
					i--;
					num--;
				}
				if (step <= 0)
				{
					break;
				}
			}
			i++;
		}
	}

	// Token: 0x060003CF RID: 975 RVA: 0x0001BACC File Offset: 0x00019ECC
	protected void _Update()
	{
		int num = this.m_AsyncStep;
		this._CheckAsyncLoadTaskList(this.m_HighPriorityAsyncLoadTaskList, ref num);
		if (num > 0)
		{
			num = 1;
			this._CheckAsyncLoadTaskList(this.m_AsyncLoadTaskList, ref num);
		}
		int i = 0;
		int num2 = this.m_CompletedReqList.Count;
		while (i < num2)
		{
			AssetInstRequest assetInstRequest = this.m_CompletedReqList[i];
			if (assetInstRequest == null)
			{
				goto IL_D5;
			}
			if (assetInstRequest.m_IsAbort)
			{
				if (assetInstRequest.m_AssetInst != null && assetInstRequest.m_AssetInst.isGameObject)
				{
					Object.Destroy(assetInstRequest.m_AssetInst.obj);
				}
				assetInstRequest.Reset();
				this.m_AssetInstReqPool.Add(assetInstRequest);
				this.m_CompletedReqList.RemoveAt(i);
				i--;
				num2--;
			}
			else if (assetInstRequest.m_HasExtract)
			{
				assetInstRequest.Reset();
				this.m_AssetInstReqPool.Add(assetInstRequest);
				goto IL_D5;
			}
			IL_E9:
			i++;
			continue;
			IL_D5:
			this.m_CompletedReqList.RemoveAt(i);
			i--;
			num2--;
			goto IL_E9;
		}
		if (this.m_ReqCompleteList != null)
		{
			this.m_CompletedReqList.AddRange(this.m_ReqCompleteList);
			this.m_ReqCompleteList.RemoveRange(0, this.m_ReqCompleteList.Count);
		}
	}

	// Token: 0x060003D0 RID: 976 RVA: 0x0001BC00 File Offset: 0x0001A000
	public void Update()
	{
		this._Update();
	}

	// Token: 0x060003D1 RID: 977 RVA: 0x0001BC08 File Offset: 0x0001A008
	public void DumpAssetInfo(ref List<string> assetList)
	{
		assetList.Clear();
		foreach (KeyValuePair<string, List<AssetLoader.AssetInfo>> keyValuePair in this.m_ResDescCacheTableEx)
		{
			List<AssetLoader.AssetInfo> value = keyValuePair.Value;
			if (value != null)
			{
				int i = 0;
				int count = value.Count;
				while (i < count)
				{
					AssetLoader.AssetInfo assetInfo = value[i];
					if (assetInfo != null && assetInfo.m_AssetDesc != null)
					{
						global::AssetDesc assetDesc = assetInfo.m_AssetDesc;
						string format = "{0} ({1}) Ref:{2}     [Key: {3}]";
						object[] array = new object[4];
						array[0] = Path.GetFileNameWithoutExtension(assetDesc.m_FullPath);
						array[1] = assetDesc.assetType.ToString();
						array[2] = assetDesc.GetRefCount();
						int num = 3;
						Dictionary<string, List<AssetLoader.AssetInfo>>.Enumerator enumerator;
						KeyValuePair<string, List<AssetLoader.AssetInfo>> keyValuePair2 = enumerator.Current;
						array[num] = keyValuePair2.Key;
						string item = string.Format(format, array);
						assetList.Add(item);
					}
					i++;
				}
			}
		}
	}

	// Token: 0x060003D2 RID: 978 RVA: 0x0001BCF4 File Offset: 0x0001A0F4
	private void _DumpToFile()
	{
		if (this.m_DumpBuf.Count <= 0)
		{
			return;
		}
		this.m_DumpBuf.Clear();
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x0001BD13 File Offset: 0x0001A113
	private void _RecordLoadFile(string file)
	{
		if (!Global.Settings.recordResFile)
		{
			return;
		}
		if (this.m_DumpBuf.Count >= this.m_BufLineNum)
		{
			this._DumpToFile();
		}
		this.m_DumpBuf.Add(file);
	}

	// Token: 0x060003D4 RID: 980 RVA: 0x0001BD50 File Offset: 0x0001A150
	private void _ValidResPath(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return;
		}
		if (path.Length != path.TrimEnd(new char[]
		{
			' '
		}).Length)
		{
			Logger.LogErrorFormat("路径有问题：{0}！", new object[]
			{
				path
			});
		}
	}

	// Token: 0x04000381 RID: 897
	private static ITMAssetManager m_AssetManager;

	// Token: 0x04000382 RID: 898
	public static readonly uint INVILID_HANDLE = uint.MaxValue;

	// Token: 0x04000383 RID: 899
	private static bool m_AsyncLoadPackageRes = true;

	// Token: 0x04000384 RID: 900
	protected int m_QureyCnt;

	// Token: 0x04000385 RID: 901
	protected readonly int QUREY_STEP = 2;

	// Token: 0x04000386 RID: 902
	private Dictionary<string, List<AssetLoader.AssetInfo>> m_ResDescCacheTableEx = new Dictionary<string, List<AssetLoader.AssetInfo>>();

	// Token: 0x04000387 RID: 903
	private float m_PurgeTime = 30f;

	// Token: 0x04000388 RID: 904
	private int m_AutoPurgeCnt;

	// Token: 0x04000389 RID: 905
	private int m_CurPurgeCnt;

	// Token: 0x0400038A RID: 906
	protected int m_AsyncStep = 1;

	// Token: 0x0400038B RID: 907
	protected List<AssetInstRequest> m_AssetInstReqPool = new List<AssetInstRequest>();

	// Token: 0x0400038C RID: 908
	protected List<AssetInstRequest> m_CompletedReqList = new List<AssetInstRequest>();

	// Token: 0x0400038D RID: 909
	protected List<AssetLoader.AsyncLoadTaskDesc> m_AsyncLoadTaskList = new List<AssetLoader.AsyncLoadTaskDesc>();

	// Token: 0x0400038E RID: 910
	protected List<AssetLoader.AsyncLoadTaskDesc> m_HighPriorityAsyncLoadTaskList = new List<AssetLoader.AsyncLoadTaskDesc>();

	// Token: 0x0400038F RID: 911
	private List<AssetInstRequest> m_ReqCompleteList = new List<AssetInstRequest>();

	// Token: 0x04000390 RID: 912
	private AsyncRequestHandleAllocator<IAssetInstRequest> m_AsyncRequestAllocator = new AsyncRequestHandleAllocator<IAssetInstRequest>(0U);

	// Token: 0x04000391 RID: 913
	private string m_DumpFile = "ResLoadRecord/FileLoadTrace.rec";

	// Token: 0x04000392 RID: 914
	private List<string> m_DumpBuf = new List<string>();

	// Token: 0x04000393 RID: 915
	private int m_BufLineNum = 10;

	// Token: 0x020000B4 RID: 180
	public enum AssetLockFlag
	{
		// Token: 0x04000395 RID: 917
		LockGroup_Town = 1
	}

	// Token: 0x020000B5 RID: 181
	private class AssetInfo
	{
		// Token: 0x060003D6 RID: 982 RVA: 0x0001BDAC File Offset: 0x0001A1AC
		public AssetInfo(Type type, global::AssetDesc desc)
		{
			this.m_AssetDesc = desc;
			this.m_AssetType = type;
		}

		// Token: 0x04000396 RID: 918
		public Type m_AssetType;

		// Token: 0x04000397 RID: 919
		public global::AssetDesc m_AssetDesc;
	}

	// Token: 0x020000B6 RID: 182
	private struct AssetDelKey
	{
		// Token: 0x04000398 RID: 920
		public string path;

		// Token: 0x04000399 RID: 921
		public Type type;
	}

	// Token: 0x020000B7 RID: 183
	protected class AsyncLoadTaskDesc
	{
		// Token: 0x0400039A RID: 922
		public global::AssetDesc m_AssetDesc;

		// Token: 0x0400039B RID: 923
		public string m_ResPath;

		// Token: 0x0400039C RID: 924
		public string m_SubRes;

		// Token: 0x0400039D RID: 925
		public Type m_ResType;

		// Token: 0x0400039E RID: 926
		public List<AssetInstRequest> m_WaitingReqList = new List<AssetInstRequest>();
	}
}
