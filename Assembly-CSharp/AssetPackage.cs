using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x020000BB RID: 187
[Serializable]
public class AssetPackage
{
	// Token: 0x060003E2 RID: 994 RVA: 0x0001C004 File Offset: 0x0001A404
	public AssetBundleRequest OnBeginLoadAssetAsync(string assetNameInPackage, Type assetType, bool subAsset)
	{
		if (!(null != this.m_AssetBundle))
		{
			return null;
		}
		this.OnBeginLoadAsset();
		if (subAsset)
		{
			return this.m_AssetBundle.LoadAssetAsync(assetNameInPackage, assetType);
		}
		return this.m_AssetBundle.LoadAssetWithSubAssetsAsync(assetNameInPackage, assetType);
	}

	// Token: 0x060003E3 RID: 995 RVA: 0x0001C040 File Offset: 0x0001A440
	public void OnBeginLoadAsset()
	{
		this.m_LoadingCount++;
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x0001C050 File Offset: 0x0001A450
	public void OnFinishLoadAsset()
	{
		this.m_LoadingCount--;
	}

	// Token: 0x060003E5 RID: 997 RVA: 0x0001C060 File Offset: 0x0001A460
	public void TryUnloadPackage()
	{
		if (this.m_LoadingCount == 0)
		{
			this.UnloadBundle(false);
		}
	}

	// Token: 0x060003E6 RID: 998 RVA: 0x0001C074 File Offset: 0x0001A474
	public void UpdateAsyncPackageLoad()
	{
		if (!this.m_LoadAsDependent)
		{
			this.m_DependentLoaded = true;
			int i = 0;
			int count = this.m_DependencyList.Count;
			while (i < count)
			{
				if (this.m_DependencyList[i] != null)
				{
					if (this != this.m_DependencyList[i] && !(this.m_BundleName == this.m_DependencyList[i].m_BundleName))
					{
						if (!this.m_DependencyList[i].IsPackageLoadFinish(true))
						{
							this.m_DependentLoaded = false;
							break;
						}
					}
				}
				i++;
			}
		}
		if (this.m_AssetBundleRequest != null && this.m_AssetBundleRequest.IsDone())
		{
			this._AssignAssetBundle(this.m_AssetBundleRequest.Extract());
			this.m_AssetBundleRequest = null;
			this.m_PackageState = AssetPackageState.Loaded;
		}
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x0001C157 File Offset: 0x0001A557
	private void _AssignAssetBundle(AssetBundle assetBundle)
	{
		if (null == assetBundle)
		{
			return;
		}
		if (null == this.m_AssetBundle)
		{
			this.m_AssetBundle = assetBundle;
		}
		else
		{
			assetBundle.Unload(false);
		}
	}

	// Token: 0x060003E8 RID: 1000 RVA: 0x0001C18C File Offset: 0x0001A58C
	public bool Init(string bundlePath, string bundleName, AssetPackage[] dependency, DPackAssetDesc[] assets, uint packageFlag)
	{
		if (string.IsNullOrEmpty(bundleName) || string.IsNullOrEmpty(bundlePath))
		{
			return false;
		}
		this.m_BundleName = bundleName.ToLower();
		this.m_PackageNameHashCode = this.m_BundleName.GetHashCode();
		this.m_BundlePath = bundlePath;
		this.m_PackageFlag = packageFlag;
		this.m_BundleFullPath = Path.Combine(this.m_BundlePath, this.m_BundleName);
		this.m_BundleHotfixPath = Path.Combine(Path.Combine(this.m_BundlePath, "hotfix"), this.m_BundleName);
		if (dependency != null)
		{
			this.m_DependencyList.AddRange(dependency);
		}
		return true;
	}

	// Token: 0x060003E9 RID: 1001 RVA: 0x0001C228 File Offset: 0x0001A628
	public bool ReloadPackage(bool isDependent = false)
	{
		if (!isDependent && !this.m_DependentLoaded)
		{
			for (int i = 0; i < this.m_DependencyList.Count; i++)
			{
				if (this.m_DependencyList[i] != null)
				{
					if (this != this.m_DependencyList[i] && !(this.m_BundleName == this.m_DependencyList[i].m_BundleName))
					{
						Singleton<AssetPackageManager>.instance.LoadPackage(this.m_DependencyList[i], true);
						this.m_DependencyList[i].AddDependentRef();
					}
				}
			}
			this.m_DependentLoaded = true;
		}
		this.m_LoadAsDependent = (isDependent & this.m_LoadAsDependent);
		if (null != this.m_AssetBundle)
		{
			this.m_PackageState = AssetPackageState.Loaded;
			return true;
		}
		if (this.m_AssetBundleRequest != null)
		{
			if (this.m_AssetBundleRequest.IsDone())
			{
				this._AssignAssetBundle(this.m_AssetBundleRequest.Extract());
				this.m_PackageState = AssetPackageState.Loaded;
				this.m_AssetBundleRequest = null;
				return true;
			}
			this.m_AssetBundleRequest.Abort();
			this.m_AssetBundleRequest = null;
		}
		this.m_PackageState = AssetPackageState.Loading;
		this._AssignAssetBundle(MonoSingleton<AssetPackageLoader>.instance.LoadPackage(this));
		if (null != this.m_AssetBundle)
		{
			this.m_PackageState = AssetPackageState.Loaded;
			return true;
		}
		this.m_PackageState = AssetPackageState.Unload;
		return false;
	}

	// Token: 0x060003EA RID: 1002 RVA: 0x0001C38B File Offset: 0x0001A78B
	public bool IsPackageNeedLoad(bool isDependent = false)
	{
		if (!isDependent)
		{
			return !this.m_DependentLoaded;
		}
		return null != this.m_AssetBundle;
	}

	// Token: 0x060003EB RID: 1003 RVA: 0x0001C3A9 File Offset: 0x0001A7A9
	public bool IsPackageInLoading()
	{
		return null != this.m_AssetBundleRequest;
	}

	// Token: 0x060003EC RID: 1004 RVA: 0x0001C3B7 File Offset: 0x0001A7B7
	public bool IsDependecyLoaded()
	{
		return this.m_LoadAsDependent || this.m_DependentLoaded;
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x0001C3CC File Offset: 0x0001A7CC
	public bool IsPackageLoadFinish(bool asDependent)
	{
		if (!asDependent)
		{
			int i = 0;
			int count = this.m_DependencyList.Count;
			while (i < count)
			{
				if (this.m_DependencyList[i] != null)
				{
					if (this != this.m_DependencyList[i] && !(this.m_BundleName == this.m_DependencyList[i].m_BundleName))
					{
						if (!this.m_DependencyList[i].IsPackageLoadFinish(true))
						{
							return false;
						}
					}
				}
				i++;
			}
		}
		return null != this.m_AssetBundle;
	}

	// Token: 0x060003EE RID: 1006 RVA: 0x0001C46C File Offset: 0x0001A86C
	public void ReloadPackageAsync(bool isDependent = false, bool highPriority = false)
	{
		if (!isDependent && !this.m_DependentLoaded)
		{
			for (int i = 0; i < this.m_DependencyList.Count; i++)
			{
				if (this.m_DependencyList[i] != null)
				{
					if (this != this.m_DependencyList[i] && !(this.m_BundleName == this.m_DependencyList[i].m_BundleName))
					{
						Singleton<AssetPackageManager>.instance.LoadPackageAsync(this.m_DependencyList[i], highPriority, true);
						this.m_DependencyList[i].AddDependentRef();
					}
				}
			}
		}
		this.m_LoadAsDependent = (isDependent & this.m_LoadAsDependent);
		if (null != this.m_AssetBundle)
		{
			this.m_PackageState = AssetPackageState.Loaded;
		}
		else if (this.m_AssetBundleRequest == null)
		{
			this.m_AssetBundleRequest = MonoSingleton<AssetPackageLoader>.instance.LoadPackageAsync(this, highPriority);
			this.m_PackageState = AssetPackageState.Loading;
		}
		else if (this.m_AssetBundleRequest.IsDone())
		{
			this._AssignAssetBundle(this.m_AssetBundleRequest.Extract());
			this.m_PackageState = AssetPackageState.Loaded;
			this.m_AssetBundleRequest = null;
		}
	}

	// Token: 0x060003EF RID: 1007 RVA: 0x0001C59C File Offset: 0x0001A99C
	public void UnloadPackage(bool bUnloadAllAsset = false)
	{
		if (!this.m_LoadAsDependent && this.m_DependentLoaded)
		{
			for (int i = 0; i < this.m_DependencyList.Count; i++)
			{
				if (this.m_DependencyList[i] != null && this != this.m_DependencyList[i])
				{
					this.m_DependencyList[i].RemoveDependentRef();
				}
			}
			this.m_DependentLoaded = false;
		}
		this.UnloadBundle(bUnloadAllAsset);
		this.m_LoadAsDependent = true;
	}

	// Token: 0x060003F0 RID: 1008 RVA: 0x0001C624 File Offset: 0x0001AA24
	public Object LoadResFromPackage(string resName, Type type, bool bAsync = false, string subRes = "")
	{
		float num = Time.realtimeSinceStartup * 1000f;
		Singleton<AssetPackageManager>.instance.LoadPackage(this, false);
		num = Time.realtimeSinceStartup * 1000f - num;
		if (null != this.m_AssetBundle)
		{
			int num2 = resName.LastIndexOf('/');
			if (0 <= num2 && num2 < resName.Length)
			{
				resName = resName.Substring(num2 + 1).ToLower();
			}
			Object @object = null;
			if (type == typeof(Sprite))
			{
				this.OnBeginLoadAsset();
				Sprite[] array = this.m_AssetBundle.LoadAssetWithSubAssets<Sprite>(CFileManager.EraseExtension(resName));
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].name == subRes)
					{
						@object = array[i];
					}
				}
				this.OnFinishLoadAsset();
			}
			if (null == @object)
			{
				this.OnBeginLoadAsset();
				num = Time.realtimeSinceStartup * 1000f;
				@object = this.m_AssetBundle.LoadAsset(resName, type);
				num = Time.realtimeSinceStartup * 1000f - num;
				this.OnFinishLoadAsset();
			}
			if (null != @object)
			{
				bool flag = @object is GameObject;
				this._AddAssetRecord(@object.GetInstanceID(), flag, resName);
				if (flag && this.m_AssetResCount == 0 && this.m_DenpendentRefCnt <= 0)
				{
					this.TryUnloadPackage();
				}
			}
			return @object;
		}
		return null;
	}

	// Token: 0x060003F1 RID: 1009 RVA: 0x0001C784 File Offset: 0x0001AB84
	private void _AddAssetRecord(int instID, bool isGameObj, string resName)
	{
		int i = 0;
		int count = this.m_LoadedAssetList.Count;
		while (i < count)
		{
			if (this.m_LoadedAssetList[i].assetInstID == instID)
			{
				return;
			}
			i++;
		}
		AssetPackage.AssetItem item = default(AssetPackage.AssetItem);
		item.assetInstID = instID;
		item.isGameObjAsset = isGameObj;
		this.m_LoadedAssetList.Add(item);
		if (!isGameObj)
		{
			this.m_AssetResCount++;
		}
	}

	// Token: 0x060003F2 RID: 1010 RVA: 0x0001C804 File Offset: 0x0001AC04
	private void _RemoveAssetRecord(int instID)
	{
		int i = 0;
		int count = this.m_LoadedAssetList.Count;
		while (i < count)
		{
			if (this.m_LoadedAssetList[i].assetInstID == instID)
			{
				if (!this.m_LoadedAssetList[i].isGameObjAsset)
				{
					this.m_AssetResCount--;
				}
				this.m_LoadedAssetList.RemoveAt(i);
				return;
			}
			i++;
		}
	}

	// Token: 0x060003F3 RID: 1011 RVA: 0x0001C880 File Offset: 0x0001AC80
	protected void _OnAsyncExtractCallback(Object asset, string resName)
	{
		if (null != asset)
		{
			bool flag = asset is GameObject;
			this._AddAssetRecord(asset.GetInstanceID(), flag, resName);
			if (flag && this.m_AssetResCount == 0 && this.m_DenpendentRefCnt <= 0)
			{
				this.TryUnloadPackage();
			}
		}
	}

	// Token: 0x060003F4 RID: 1012 RVA: 0x0001C8D4 File Offset: 0x0001ACD4
	public IAsyncLoadRequest<Object> LoadResFromPackageAsync(string resName, Type type, string subRes = "", bool highPriority = false)
	{
		if (EngineConfig.asyncPackageLoad)
		{
			if (this.m_AssetBundleRequest == null)
			{
				Singleton<AssetPackageManager>.instance.LoadPackageAsync(this, highPriority, false);
			}
			else if (this.m_AssetBundleRequest.IsDone())
			{
				this._AssignAssetBundle(this.m_AssetBundleRequest.Extract());
				this.m_AssetBundleRequest = null;
				this.m_PackageState = AssetPackageState.Loaded;
			}
			return Singleton<AsyncLoadTaskAllocator<AssetBundleResquestWrapper, Object>>.instance.AllocAsyncTask(resName, new AssetBundleResquestData(type, subRes, this, new onExtractCallback(this._OnAsyncExtractCallback)), highPriority);
		}
		Singleton<AssetPackageManager>.instance.LoadPackage(this, false);
		return Singleton<AsyncLoadTaskAllocator<AssetBundleResquestWrapper, Object>>.instance.AllocAsyncTask(resName, new AssetBundleResquestData(type, subRes, this, new onExtractCallback(this._OnAsyncExtractCallback)), highPriority);
	}

	// Token: 0x060003F5 RID: 1013 RVA: 0x0001C989 File Offset: 0x0001AD89
	public void UnloadAsset(int assetInstID)
	{
		this._RemoveAssetRecord(assetInstID);
	}

	// Token: 0x060003F6 RID: 1014 RVA: 0x0001C992 File Offset: 0x0001AD92
	public bool CanUnload()
	{
		return this.m_LoadedAssetList.Count == 0 && 0 >= this.m_DenpendentRefCnt && 0 >= this.m_LoadingCount;
	}

	// Token: 0x060003F7 RID: 1015 RVA: 0x0001C9C0 File Offset: 0x0001ADC0
	public void UnloadBundle(bool unloadAllLoadedObjects = false)
	{
		if (this.m_LoadingCount > 0)
		{
			throw new Exception("You can not unload this asset-bundle while asset in loading with this bundle!");
		}
		if (this.m_AssetBundleRequest != null)
		{
			this.m_AssetBundleRequest.Abort();
			this.m_AssetBundleRequest = null;
		}
		if (null != this.m_AssetBundle)
		{
			Singleton<AssetBundleRegiester>.instance.ReleaseAssetBundle(this.m_AssetBundle, unloadAllLoadedObjects);
			this.m_AssetBundle = null;
			this.m_PackageState = AssetPackageState.Unload;
		}
	}

	// Token: 0x060003F8 RID: 1016 RVA: 0x0001CA31 File Offset: 0x0001AE31
	public void AddDependentRef()
	{
		this.m_DenpendentRefCnt++;
	}

	// Token: 0x060003F9 RID: 1017 RVA: 0x0001CA41 File Offset: 0x0001AE41
	public void RemoveDependentRef()
	{
		this.m_DenpendentRefCnt--;
		if (this.m_DenpendentRefCnt < 0)
		{
			Logger.LogErrorFormat("AssetBundle [{0}] released count is more than created count", new object[]
			{
				this.m_BundleName
			});
		}
	}

	// Token: 0x17000033 RID: 51
	// (get) Token: 0x060003FA RID: 1018 RVA: 0x0001CA76 File Offset: 0x0001AE76
	public string packageFullPath
	{
		get
		{
			return this.m_BundleFullPath;
		}
	}

	// Token: 0x17000034 RID: 52
	// (get) Token: 0x060003FB RID: 1019 RVA: 0x0001CA7E File Offset: 0x0001AE7E
	public string packageHotfixPath
	{
		get
		{
			return this.m_BundleHotfixPath;
		}
	}

	// Token: 0x17000035 RID: 53
	// (get) Token: 0x060003FC RID: 1020 RVA: 0x0001CA86 File Offset: 0x0001AE86
	public string packageName
	{
		get
		{
			return this.m_BundleName;
		}
	}

	// Token: 0x17000036 RID: 54
	// (get) Token: 0x060003FD RID: 1021 RVA: 0x0001CA8E File Offset: 0x0001AE8E
	public int packageNameHashCode
	{
		get
		{
			return this.m_PackageNameHashCode;
		}
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x0001CA96 File Offset: 0x0001AE96
	protected bool _IsResInNative(string resPath)
	{
		return false;
	}

	// Token: 0x060003FF RID: 1023 RVA: 0x0001CA99 File Offset: 0x0001AE99
	protected bool _IsResInServer(string resPath)
	{
		return false;
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x0001CA9C File Offset: 0x0001AE9C
	protected string _GetServerResourcePath()
	{
		return string.Empty;
	}

	// Token: 0x06000401 RID: 1025 RVA: 0x0001CAA3 File Offset: 0x0001AEA3
	protected string _GetNativeResourcePath()
	{
		return string.Empty;
	}

	// Token: 0x17000037 RID: 55
	// (get) Token: 0x06000402 RID: 1026 RVA: 0x0001CAAA File Offset: 0x0001AEAA
	public long packageBytes
	{
		get
		{
			return this.m_cbBytes;
		}
	}

	// Token: 0x17000038 RID: 56
	// (get) Token: 0x06000403 RID: 1027 RVA: 0x0001CAB2 File Offset: 0x0001AEB2
	public bool usingHashName
	{
		get
		{
			return (this.m_PackageFlag & 2U) != 0U;
		}
	}

	// Token: 0x17000039 RID: 57
	// (get) Token: 0x06000404 RID: 1028 RVA: 0x0001CAC2 File Offset: 0x0001AEC2
	public AssetPackage[] dependPackages
	{
		get
		{
			return this.m_DependencyList.ToArray();
		}
	}

	// Token: 0x1700003A RID: 58
	// (get) Token: 0x06000405 RID: 1029 RVA: 0x0001CAD0 File Offset: 0x0001AED0
	public int[] loadAssetHashes
	{
		get
		{
			int[] array = new int[this.m_LoadedAssetList.Count];
			int i = 0;
			int count = this.m_LoadedAssetList.Count;
			while (i < count)
			{
				array[i] = this.m_LoadedAssetList[i].assetInstID;
				i++;
			}
			return array;
		}
	}

	// Token: 0x1700003B RID: 59
	// (get) Token: 0x06000406 RID: 1030 RVA: 0x0001CB24 File Offset: 0x0001AF24
	public int denpendentRefCnt
	{
		get
		{
			return this.m_DenpendentRefCnt;
		}
	}

	// Token: 0x1700003C RID: 60
	// (get) Token: 0x06000407 RID: 1031 RVA: 0x0001CB2C File Offset: 0x0001AF2C
	public bool packageLoaded
	{
		get
		{
			return null != this.m_AssetBundle;
		}
	}

	// Token: 0x1700003D RID: 61
	// (get) Token: 0x06000408 RID: 1032 RVA: 0x0001CB3A File Offset: 0x0001AF3A
	public AssetBundle assetBundle
	{
		get
		{
			return this.m_AssetBundle;
		}
	}

	// Token: 0x040003A5 RID: 933
	[SerializeField]
	protected string m_BundlePath;

	// Token: 0x040003A6 RID: 934
	[SerializeField]
	protected string m_BundleName;

	// Token: 0x040003A7 RID: 935
	[SerializeField]
	protected string m_BundleFullPath;

	// Token: 0x040003A8 RID: 936
	[SerializeField]
	protected string m_BundleHotfixPath;

	// Token: 0x040003A9 RID: 937
	[SerializeField]
	protected List<AssetPackage> m_DependencyList = new List<AssetPackage>();

	// Token: 0x040003AA RID: 938
	[SerializeField]
	protected uint m_PackageFlag;

	// Token: 0x040003AB RID: 939
	[SerializeField]
	protected int m_PackageSize;

	// Token: 0x040003AC RID: 940
	[SerializeField]
	protected long m_cbBytes;

	// Token: 0x040003AD RID: 941
	[NonSerialized]
	protected AssetBundle m_AssetBundle;

	// Token: 0x040003AE RID: 942
	[NonSerialized]
	protected AssetPackageState m_PackageState;

	// Token: 0x040003AF RID: 943
	[NonSerialized]
	protected int m_DenpendentRefCnt;

	// Token: 0x040003B0 RID: 944
	[NonSerialized]
	protected List<AssetPackage.AssetItem> m_LoadedAssetList = new List<AssetPackage.AssetItem>();

	// Token: 0x040003B1 RID: 945
	[NonSerialized]
	protected int m_AssetResCount;

	// Token: 0x040003B2 RID: 946
	[NonSerialized]
	protected bool m_LoadAsDependent = true;

	// Token: 0x040003B3 RID: 947
	[NonSerialized]
	protected bool m_DependentLoaded;

	// Token: 0x040003B4 RID: 948
	[NonSerialized]
	protected int m_LoadingCount;

	// Token: 0x040003B5 RID: 949
	[NonSerialized]
	protected int m_PackageNameHashCode = -1;

	// Token: 0x040003B6 RID: 950
	[NonSerialized]
	protected IAsyncLoadRequest<AssetBundle> m_AssetBundleRequest;

	// Token: 0x020000BC RID: 188
	protected struct AssetItem
	{
		// Token: 0x040003B7 RID: 951
		public int assetInstID;

		// Token: 0x040003B8 RID: 952
		public bool isGameObjAsset;
	}
}
