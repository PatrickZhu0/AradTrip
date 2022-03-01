using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000A9 RID: 169
public class AssetGabageCollector : MonoSingleton<AssetGabageCollector>
{
	// Token: 0x06000385 RID: 901 RVA: 0x0001A3A8 File Offset: 0x000187A8
	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x1700002E RID: 46
	// (get) Token: 0x06000386 RID: 902 RVA: 0x0001A3B5 File Offset: 0x000187B5
	public bool IsUnloadingAssets
	{
		get
		{
			return this.m_LockForUnloading;
		}
	}

	// Token: 0x06000387 RID: 903 RVA: 0x0001A3C0 File Offset: 0x000187C0
	private void Update()
	{
		Singleton<AssetGabageCollectorHelper>.instance.Update();
		if (this.m_UnloadAsync != null && this.m_UnloadAsync.isDone)
		{
			GC.Collect();
			this.m_LockForUnloading = false;
			this.m_UnloadAsync = null;
		}
		if (!this.m_NeedClearAsset)
		{
			return;
		}
		if (MonoSingleton<AssetAsyncLoader>.instance.IsAsyncInLoading)
		{
			return;
		}
		this.m_LockForUnloading = true;
		Singleton<AssetLoader>.instance.ResetPurgeTick();
		if (this.m_ObjectToClear == null)
		{
			Singleton<CGameObjectPool>.instance.ExecuteClearPooledObjects();
		}
		else
		{
			Singleton<CGameObjectPool>.instance.ExecuteClearPooledObjects(this.m_ObjectToClear);
		}
		Singleton<AssetLoader>.instance.PurgeUnusedRes(true, null);
		Singleton<AssetPackageManager>.instance.UnloadUnusedPackage(false);
		this.m_FrameCntAfterGC = 0;
		ObjectLeakDitector.DumpObjectRef();
		this.m_ObjectToClear = null;
		if (this.m_UnloadAsync == null || this.m_UnloadAsync.isDone)
		{
			this.m_UnloadAsync = Resources.UnloadUnusedAssets();
			this.m_NeedClearAsset = false;
		}
	}

	// Token: 0x06000388 RID: 904 RVA: 0x0001A4B4 File Offset: 0x000188B4
	public void ClearUnusedAsset(List<string> keys = null, bool isForce = false)
	{
		int num = 0;
		Singleton<GeGraphicSetting>.instance.GetSetting("GraphicLevel", ref num);
		if (num == 2 || isForce)
		{
			BeActionFrameMgr.Clear();
		}
		this.m_NeedClearAsset = true;
		this.m_ObjectToClear = keys;
	}

	// Token: 0x06000389 RID: 905 RVA: 0x0001A4F8 File Offset: 0x000188F8
	protected IEnumerator _CleanSync()
	{
		yield return Resources.UnloadUnusedAssets();
		ObjectLeakDitector.DumpObjectRef();
		yield break;
	}

	// Token: 0x0400035E RID: 862
	private AsyncOperation m_UnloadAsync;

	// Token: 0x0400035F RID: 863
	private List<string> m_ObjectToClear;

	// Token: 0x04000360 RID: 864
	private bool m_LockForUnloading;

	// Token: 0x04000361 RID: 865
	protected int m_FrameCntAfterGC;

	// Token: 0x04000362 RID: 866
	protected bool m_NeedClearAsset;
}
