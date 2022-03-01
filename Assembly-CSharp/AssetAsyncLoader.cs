using System;
using UnityEngine;

// Token: 0x020000A4 RID: 164
public class AssetAsyncLoader : MonoSingleton<AssetAsyncLoader>
{
	// Token: 0x06000377 RID: 887 RVA: 0x0001A0FD File Offset: 0x000184FD
	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		base.gameObject.transform.position = new Vector3(0f, -1000f, 0f);
	}

	// Token: 0x06000378 RID: 888 RVA: 0x0001A12E File Offset: 0x0001852E
	public void SetLoadingLimit(int maxCount)
	{
		Singleton<AsyncLoadTaskAllocator<ResourceRequestWrapper, Object>>.instance.RunningTaskLimit = maxCount;
		Singleton<AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>>.instance.RunningTaskLimit = maxCount;
		Singleton<AsyncLoadTaskAllocator<AssetBundleResquestWrapper, Object>>.instance.RunningTaskLimit = maxCount;
	}

	// Token: 0x1700002C RID: 44
	// (get) Token: 0x06000379 RID: 889 RVA: 0x0001A151 File Offset: 0x00018551
	public GameObject root
	{
		get
		{
			return base.gameObject;
		}
	}

	// Token: 0x1700002D RID: 45
	// (get) Token: 0x0600037A RID: 890 RVA: 0x0001A159 File Offset: 0x00018559
	public bool IsAsyncInLoading
	{
		get
		{
			return Singleton<AsyncLoadTaskAllocator<ResourceRequestWrapper, Object>>.instance.IsResAsyncLoading() || Singleton<AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>>.instance.IsResAsyncLoading() || Singleton<AsyncLoadTaskAllocator<AssetBundleResquestWrapper, Object>>.instance.IsResAsyncLoading();
		}
	}

	// Token: 0x0600037B RID: 891 RVA: 0x0001A186 File Offset: 0x00018586
	public void ClearWaitingQueue()
	{
		Singleton<AsyncLoadTaskAllocator<ResourceRequestWrapper, Object>>.instance.ClearWaitingQueue();
		Singleton<AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>>.instance.ClearWaitingQueue();
		Singleton<AsyncLoadTaskAllocator<AssetBundleResquestWrapper, Object>>.instance.ClearWaitingQueue();
	}

	// Token: 0x0600037C RID: 892 RVA: 0x0001A1A6 File Offset: 0x000185A6
	public void ClearFinishQueue()
	{
		Singleton<AsyncLoadTaskAllocator<ResourceRequestWrapper, Object>>.instance.ClearFinishQueue();
		Singleton<AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>>.instance.ClearFinishQueue();
		Singleton<AsyncLoadTaskAllocator<AssetBundleResquestWrapper, Object>>.instance.ClearFinishQueue();
	}

	// Token: 0x0600037D RID: 893 RVA: 0x0001A1C8 File Offset: 0x000185C8
	private void Update()
	{
		if (MonoSingleton<AssetGabageCollector>.instance.IsUnloadingAssets)
		{
			return;
		}
		Singleton<AsyncLoadTaskAllocator<ResourceRequestWrapper, Object>>.instance.Update();
		Singleton<AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>>.instance.Update();
		Singleton<AsyncLoadTaskAllocator<AssetBundleResquestWrapper, Object>>.instance.Update();
		Singleton<AssetPackageManager>.instance.UpdateAsync();
		Singleton<AssetLoader>.instance.Update();
		Singleton<CGameObjectPool>.instance.Update();
	}
}
