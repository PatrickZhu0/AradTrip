using System;
using System.Collections.Generic;
using System.IO;
using DG.Tweening;
using TMEngine.Runtime;
using TMEngine.Runtime.Unity;
using UnityEngine;

// Token: 0x020000BE RID: 190
public class AssetPackageManager : Singleton<AssetPackageManager>
{
	// Token: 0x06000412 RID: 1042 RVA: 0x0001CE14 File Offset: 0x0001B214
	public override void Init()
	{
		this._Clear();
	}

	// Token: 0x06000413 RID: 1043 RVA: 0x0001CE1C File Offset: 0x0001B21C
	public override void UnInit()
	{
		this._Clear();
	}

	// Token: 0x06000414 RID: 1044 RVA: 0x0001CE24 File Offset: 0x0001B224
	public AssetPackage GetResPackage(string resPath, Type type, out string GUIDName)
	{
		GUIDName = null;
		if (null != this.m_PackageDependencyDesc && this.m_PackageDependencyDesc.assetDescPackageMap != null)
		{
			this.DUMMY_MAPDESC.assetPathKey = resPath.ToLower();
			int num = this.m_PackageDependencyDesc.assetDescPackageMap.BinarySearch(this.DUMMY_MAPDESC, this.SEARCH_COMPARE);
			if (0 <= num && num < this.m_PackageDependencyDesc.assetDescPackageMap.Count)
			{
				DAssetPackageMapDesc dassetPackageMapDesc = this.m_PackageDependencyDesc.assetDescPackageMap[num];
				if (0 <= dassetPackageMapDesc.packageDescIdx && dassetPackageMapDesc.packageDescIdx < this.m_PackageDependencyDesc.packageDescArray.Length)
				{
					DAssetPackageDesc dassetPackageDesc = this.m_PackageDependencyDesc.packageDescArray[dassetPackageMapDesc.packageDescIdx];
					if (dassetPackageDesc.packageAsset != null)
					{
						GUIDName = dassetPackageMapDesc.assetPackageGUID;
						return dassetPackageDesc.assetPackage;
					}
				}
			}
		}
		return null;
	}

	// Token: 0x06000415 RID: 1045 RVA: 0x0001CF08 File Offset: 0x0001B308
	public bool LoadPackage(AssetPackage resPackage, bool isDependent = false)
	{
		if (resPackage == null)
		{
			return false;
		}
		AssetPackageManager.AssetPackageBundle assetPackageBundle = null;
		if (this.m_AssetPackageCache.TryGetValue(resPackage.packageFullPath, out assetPackageBundle))
		{
			assetPackageBundle.m_AssetPackage.ReloadPackage(isDependent);
			assetPackageBundle.m_AccessCnt++;
			return true;
		}
		if (resPackage.ReloadPackage(isDependent))
		{
			AssetPackageManager.AssetPackageBundle assetPackageBundle2 = new AssetPackageManager.AssetPackageBundle();
			assetPackageBundle2.m_FirstAccessTime = Time.time;
			assetPackageBundle2.m_AccessCnt = 1;
			assetPackageBundle2.m_AssetPackage = resPackage;
			this.m_TotalSizeInMemory += resPackage.packageBytes;
			this.m_AssetPackageCache.Add(resPackage.packageFullPath, assetPackageBundle2);
			if (this.m_AssetPackageCacheList.Contains(assetPackageBundle2))
			{
				Logger.LogErrorFormat("Package \"{0}\" has already in manager cache, there is bug in program!", new object[0]);
			}
			this.m_AssetPackageCacheList.Add(assetPackageBundle2);
			return true;
		}
		return false;
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x0001CFD4 File Offset: 0x0001B3D4
	public bool LoadPackageAsync(AssetPackage resPackage, bool highPriority, bool isDependent = false)
	{
		if (resPackage == null)
		{
			return false;
		}
		resPackage.ReloadPackageAsync(isDependent, highPriority);
		int i = 0;
		int count = this.m_AsyncLoadPackageDescList.Count;
		while (i < count)
		{
			AssetPackageManager.AssetPackageAsyncDesc assetPackageAsyncDesc = this.m_AsyncLoadPackageDescList[i];
			if (assetPackageAsyncDesc.m_AssetPackage.packageNameHashCode == resPackage.packageNameHashCode && assetPackageAsyncDesc.m_AssetPackage.packageName == resPackage.packageName)
			{
				assetPackageAsyncDesc.m_RefCount++;
				assetPackageAsyncDesc.m_AsDependency = isDependent;
				return true;
			}
			i++;
		}
		AssetPackageManager.AssetPackageAsyncDesc assetPackageAsyncDesc2 = this._AllocPackageAsyncDesc();
		if (assetPackageAsyncDesc2 != null)
		{
			assetPackageAsyncDesc2.m_AsDependency = isDependent;
			assetPackageAsyncDesc2.m_AssetPackage = resPackage;
			assetPackageAsyncDesc2.m_RefCount = 1;
			this.m_AsyncLoadPackageDescList.Add(assetPackageAsyncDesc2);
		}
		return true;
	}

	// Token: 0x06000417 RID: 1047 RVA: 0x0001D09C File Offset: 0x0001B49C
	public void UpdateAsync()
	{
		this.m_QureyCnt++;
		if (this.m_QureyCnt >= this.QUREY_STEP)
		{
			this.m_QureyCnt = 0;
			int i = 0;
			int count = this.m_AsyncLoadPackageDescList.Count;
			while (i < count)
			{
				AssetPackageManager.AssetPackageAsyncDesc assetPackageAsyncDesc = this.m_AsyncLoadPackageDescList[i];
				if (assetPackageAsyncDesc == null)
				{
					this.m_AsyncLoadPackageDescList.RemoveAt(i);
					break;
				}
				assetPackageAsyncDesc.m_AssetPackage.UpdateAsyncPackageLoad();
				if (assetPackageAsyncDesc.m_AssetPackage.IsPackageLoadFinish(assetPackageAsyncDesc.m_AsDependency))
				{
					AssetPackageManager.AssetPackageBundle assetPackageBundle = new AssetPackageManager.AssetPackageBundle();
					assetPackageBundle.m_FirstAccessTime = Time.time;
					assetPackageBundle.m_AccessCnt = 1;
					assetPackageBundle.m_AssetPackage = assetPackageAsyncDesc.m_AssetPackage;
					this.m_TotalSizeInMemory += assetPackageAsyncDesc.m_AssetPackage.packageBytes;
					if (!this.m_AssetPackageCache.ContainsKey(assetPackageAsyncDesc.m_AssetPackage.packageFullPath))
					{
						this.m_AssetPackageCache.Add(assetPackageAsyncDesc.m_AssetPackage.packageFullPath, assetPackageBundle);
					}
					bool flag = false;
					int j = 0;
					int count2 = this.m_AssetPackageCacheList.Count;
					while (j < count2)
					{
						AssetPackageManager.AssetPackageBundle assetPackageBundle2 = this.m_AssetPackageCacheList[j];
						if (assetPackageBundle2.m_AssetPackage.packageNameHashCode == assetPackageAsyncDesc.m_AssetPackage.packageNameHashCode && assetPackageBundle2.m_AssetPackage.packageName == assetPackageAsyncDesc.m_AssetPackage.packageName)
						{
							flag = true;
							break;
						}
						j++;
					}
					if (!flag)
					{
						this.m_AssetPackageCacheList.Add(assetPackageBundle);
					}
					assetPackageAsyncDesc.m_RefCount--;
					if (assetPackageAsyncDesc.m_RefCount <= 0)
					{
						assetPackageAsyncDesc.m_AsDependency = true;
						assetPackageAsyncDesc.m_AssetPackage = null;
						assetPackageAsyncDesc.m_RefCount = 0;
						this.m_AsyncLoadPackageDescList.RemoveAt(i);
						this.m_AsyncIdlePackageDescList.Add(assetPackageAsyncDesc);
					}
					break;
				}
				i++;
			}
			return;
		}
	}

	// Token: 0x06000418 RID: 1048 RVA: 0x0001D288 File Offset: 0x0001B688
	public void UnloadPackage(AssetPackage package, bool bFroceUnload = false)
	{
		bool flag = package.CanUnload();
		if (flag || bFroceUnload)
		{
		}
		if (flag)
		{
			this.m_AssetPackageCacheList.RemoveAll(delegate(AssetPackageManager.AssetPackageBundle p)
			{
				if (p.m_AssetPackage == package && this.m_AssetPackageCache.Remove(package.packageFullPath))
				{
					p.m_AssetPackage.UnloadPackage(false);
					this.m_TotalSizeInMemory -= p.m_AssetPackage.packageBytes;
					return true;
				}
				return false;
			});
		}
	}

	// Token: 0x06000419 RID: 1049 RVA: 0x0001D2DF File Offset: 0x0001B6DF
	public void UnloadUnusedPackage(bool bForceClear = false)
	{
		this._ClearAllPackage(bForceClear, false);
	}

	// Token: 0x0600041A RID: 1050 RVA: 0x0001D2EC File Offset: 0x0001B6EC
	public void AddPackageDependency()
	{
		if (!Global.Settings.loadFromPackage)
		{
			return;
		}
		Singleton<EngineConfig>.instance.LoadConfig();
		string text;
		if (EngineConfig.useTMEngine)
		{
			text = this.m_AssetTreeDataPath;
		}
		else
		{
			text = this.m_PackageInfoPath;
		}
		text = PathUtil.EraseExtension(text);
		this._Clear();
		float num = Time.realtimeSinceStartup * 1000f;
		string text2 = Path.Combine(Path.Combine(Application.persistentDataPath, "AssetBundles"), this.m_DependencyFileName);
		if (EngineConfig.useTMEngine)
		{
			TMUnityAssetTreeData tmunityAssetTreeData = null;
			this.m_PackageDependencyBundle = AssetBundle.LoadFromFile(text2);
			if (null != this.m_PackageDependencyBundle)
			{
				tmunityAssetTreeData = (this.m_PackageDependencyBundle.LoadAsset(Path.GetFileNameWithoutExtension(text)) as TMUnityAssetTreeData);
				if (Singleton<VersionManager>.instance.m_IsLocalNewer)
				{
					Logger.LogErrorFormat("Fully package update remove hotfix caches!", new object[0]);
					tmunityAssetTreeData = null;
					this.m_PackageDependencyBundle.Unload(true);
					this.m_PackageDependencyBundle = null;
					this._ClearHotFixBundle();
				}
			}
			if (null == tmunityAssetTreeData)
			{
				string text3 = Path.Combine(Path.Combine(Application.streamingAssetsPath, "AssetBundles"), this.m_DependencyFileName);
				this.m_PackageDependencyBundle = AssetBundle.LoadFromFile(text3);
				if (null != this.m_PackageDependencyBundle)
				{
					tmunityAssetTreeData = (this.m_PackageDependencyBundle.LoadAsset(Path.GetFileNameWithoutExtension("AssetTreeData.asset")) as TMUnityAssetTreeData);
				}
			}
			num = Time.realtimeSinceStartup * 1000f - num;
			if (null != tmunityAssetTreeData)
			{
				this.m_AssetTreeData = tmunityAssetTreeData;
				ITMAssetManager module = ModuleManager.GetModule<ITMAssetManager>();
				if (module != null)
				{
					module.BuildAssetTree(tmunityAssetTreeData);
				}
			}
			else
			{
				Logger.LogErrorFormat("Load dependency file has failed!", new object[0]);
			}
		}
		else
		{
			DAssetPackageDependency dassetPackageDependency = null;
			this.m_PackageDependencyBundle = AssetBundle.LoadFromFile(text2);
			if (null != this.m_PackageDependencyBundle)
			{
				dassetPackageDependency = (this.m_PackageDependencyBundle.LoadAsset(Path.GetFileNameWithoutExtension(text)) as DAssetPackageDependency);
				if (Singleton<VersionManager>.instance.m_IsLocalNewer)
				{
					Logger.LogErrorFormat("Fully package update remove hotfix caches!", new object[0]);
					dassetPackageDependency = null;
					this.m_PackageDependencyBundle.Unload(true);
					this.m_PackageDependencyBundle = null;
					this._ClearHotFixBundle();
				}
			}
			if (null == dassetPackageDependency)
			{
				string text4 = Path.Combine(Path.Combine(Application.streamingAssetsPath, "AssetBundles"), this.m_DependencyFileName);
				this.m_PackageDependencyBundle = AssetBundle.LoadFromFile(text4);
				if (null != this.m_PackageDependencyBundle)
				{
					dassetPackageDependency = (this.m_PackageDependencyBundle.LoadAsset(Path.GetFileNameWithoutExtension(text)) as DAssetPackageDependency);
				}
			}
			num = Time.realtimeSinceStartup * 1000f - num;
			if (null != dassetPackageDependency)
			{
				this.m_PackageDependencyDesc = dassetPackageDependency;
				this._BuildPackageDependency(this.m_PackageDependencyDesc);
			}
			else
			{
				Logger.LogErrorFormat("Load dependency file has failed!", new object[0]);
			}
		}
	}

	// Token: 0x0600041B RID: 1051 RVA: 0x0001D5AC File Offset: 0x0001B9AC
	protected void _Clear()
	{
		DOTween.Clear(false);
		Singleton<AssetLoader>.instance.ClearAll(true);
		this._ClearAllPackage(true, false);
		this.m_AssetPackageCacheList.Clear();
		this.m_AssetPackageCache.Clear();
		Resources.UnloadUnusedAssets();
		if (null != this.m_PackageDependencyBundle)
		{
			this.m_PackageDependencyBundle.Unload(true);
			this.m_PackageDependencyBundle = null;
			this.m_PackageDependencyDesc = null;
			this.m_AssetTreeData = null;
		}
	}

	// Token: 0x0600041C RID: 1052 RVA: 0x0001D620 File Offset: 0x0001BA20
	protected void _BuildPackageDependency(DAssetPackageDependency dependecy)
	{
		float num = Time.realtimeSinceStartup * 1000f;
		int i = 0;
		int num2 = dependecy.packageDescArray.Length;
		while (i < num2)
		{
			dependecy.packageDescArray[i].assetPackage = new AssetPackage();
			i++;
		}
		List<AssetPackage> list = new List<AssetPackage>();
		int j = 0;
		int num3 = dependecy.packageDescArray.Length;
		while (j < num3)
		{
			list.Clear();
			DAssetPackageDesc dassetPackageDesc = dependecy.packageDescArray[j];
			for (int k = 0; k < dassetPackageDesc.packageAutoDependIdx.Length; k++)
			{
				int num4 = dassetPackageDesc.packageAutoDependIdx[k];
				if (0 <= num4 && num4 < num3)
				{
					list.Add(dependecy.packageDescArray[num4].assetPackage);
				}
			}
			dassetPackageDesc.assetPackage.Init(dassetPackageDesc.packagePath, dassetPackageDesc.packageName, list.ToArray(), dassetPackageDesc.packageAsset, dassetPackageDesc.packageFlag);
			j++;
		}
		num = Time.realtimeSinceStartup * 1000f - num;
	}

	// Token: 0x0600041D RID: 1053 RVA: 0x0001D72C File Offset: 0x0001BB2C
	protected void _ClearHotFixBundle()
	{
		Debug.LogWarning("Clean hot-fix bundles!");
		string path = Path.Combine(Application.persistentDataPath, "AssetBundles");
		if (Directory.Exists(path))
		{
			Directory.Delete(path, true);
		}
		string path2 = Path.Combine(Application.persistentDataPath, "version.config");
		if (File.Exists(path2))
		{
			File.Delete(path2);
		}
		string path3 = Path.Combine(Application.persistentDataPath, "version.json");
		if (File.Exists(path3))
		{
			File.Delete(path3);
		}
		string path4 = Path.Combine(Application.persistentDataPath, "Assembly-CSharp.dll");
		if (File.Exists(path4))
		{
			File.Delete(path4);
		}
		string path5 = Path.Combine(Application.persistentDataPath, "Assembly-CSharp-firstpass.dll");
		if (File.Exists(path5))
		{
			File.Delete(path5);
		}
	}

	// Token: 0x0600041E RID: 1054 RVA: 0x0001D7EC File Offset: 0x0001BBEC
	protected string _GetPlatformUrlHead()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			return "file://" + Application.persistentDataPath;
		}
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return "file://" + Application.persistentDataPath;
		}
		if (Application.platform == RuntimePlatform.WindowsEditor)
		{
			return "file:///" + Application.persistentDataPath;
		}
		return Application.persistentDataPath;
	}

	// Token: 0x0600041F RID: 1055 RVA: 0x0001D850 File Offset: 0x0001BC50
	public void _ClearAllPackage(bool bForceClear = false, bool bForceUnloadAsset = false)
	{
		this.m_AssetPackageCacheList.RemoveAll(delegate(AssetPackageManager.AssetPackageBundle p)
		{
			bool flag = p.m_AssetPackage.CanUnload();
			if (flag || bForceClear)
			{
			}
			if (!flag && !bForceClear)
			{
				return false;
			}
			if (p.m_AssetPackage == null)
			{
				return false;
			}
			if (this.m_AssetPackageCache.Remove(p.m_AssetPackage.packageFullPath))
			{
				p.m_AssetPackage.UnloadPackage(bForceUnloadAsset);
				this.m_TotalSizeInMemory -= p.m_AssetPackage.packageBytes;
				return true;
			}
			return false;
		});
	}

	// Token: 0x06000420 RID: 1056 RVA: 0x0001D890 File Offset: 0x0001BC90
	protected AssetPackageManager.AssetPackageAsyncDesc _AllocPackageAsyncDesc()
	{
		if (this.m_AsyncIdlePackageDescList.Count > 0)
		{
			int index = this.m_AsyncIdlePackageDescList.Count - 1;
			AssetPackageManager.AssetPackageAsyncDesc result = this.m_AsyncIdlePackageDescList[index];
			this.m_AsyncIdlePackageDescList.RemoveAt(index);
			return result;
		}
		return new AssetPackageManager.AssetPackageAsyncDesc();
	}

	// Token: 0x06000421 RID: 1057 RVA: 0x0001D8DC File Offset: 0x0001BCDC
	public void DumpAssetPackageInfo(ref List<string> assetList)
	{
		assetList.Clear();
		int i = 0;
		int count = this.m_AssetPackageCacheList.Count;
		while (i < count)
		{
			string text = string.Empty;
			AssetPackageManager.AssetPackageBundle assetPackageBundle = this.m_AssetPackageCacheList[i];
			if (assetPackageBundle != null && assetPackageBundle.m_AssetPackage != null)
			{
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					assetPackageBundle.m_AssetPackage.packageName,
					"\u3000(",
					assetPackageBundle.m_AssetPackage.denpendentRefCnt,
					")\u3000"
				});
				AssetPackage[] dependPackages = assetPackageBundle.m_AssetPackage.dependPackages;
				if (dependPackages != null && dependPackages.Length > 0)
				{
					text += "\u3000Depends\u3000[\u3000";
					int j = 0;
					int num = dependPackages.Length;
					while (j < num)
					{
						AssetPackage assetPackage = dependPackages[j];
						if (assetPackage != null)
						{
							text = text + assetPackage.packageName + "\u3000|\u3000";
						}
						j++;
					}
					text += "\u3000]\u3000";
				}
				int[] loadAssetHashes = assetPackageBundle.m_AssetPackage.loadAssetHashes;
				if (loadAssetHashes != null && loadAssetHashes.Length > 0)
				{
					text += "Asset\u3000[\u3000";
					int k = 0;
					int num2 = loadAssetHashes.Length;
					while (k < num2)
					{
						text = text + loadAssetHashes[k] + "\u3000|\u3000";
						k++;
					}
					text += "\u3000]";
				}
				assetList.Add(text);
			}
			i++;
		}
	}

	// Token: 0x06000422 RID: 1058 RVA: 0x0001DA68 File Offset: 0x0001BE68
	public int GetLoadedAssetPackageCount()
	{
		int num = 0;
		int i = 0;
		int count = this.m_AssetPackageCacheList.Count;
		while (i < count)
		{
			AssetPackageManager.AssetPackageBundle assetPackageBundle = this.m_AssetPackageCacheList[i];
			if (assetPackageBundle != null && assetPackageBundle.m_AssetPackage.packageLoaded)
			{
				num++;
			}
			i++;
		}
		return num;
	}

	// Token: 0x06000423 RID: 1059 RVA: 0x0001DABD File Offset: 0x0001BEBD
	protected void LoadAssetPackageTest()
	{
	}

	// Token: 0x040003B9 RID: 953
	protected List<AssetPackage> m_AssetPackageList = new List<AssetPackage>();

	// Token: 0x040003BA RID: 954
	protected string m_DependencyFileName = "packageinfo.pak";

	// Token: 0x040003BB RID: 955
	protected string m_PackageInfoPath = "Base/Version/PackageInfo.asset";

	// Token: 0x040003BC RID: 956
	protected string m_AssetTreeDataPath = "Base/Version/AssetTreeData.asset";

	// Token: 0x040003BD RID: 957
	private AssetPackageManager.AssetSearchCompare SEARCH_COMPARE = new AssetPackageManager.AssetSearchCompare();

	// Token: 0x040003BE RID: 958
	private DAssetPackageMapDesc DUMMY_MAPDESC = default(DAssetPackageMapDesc);

	// Token: 0x040003BF RID: 959
	private AssetBundle m_PackageDependencyBundle;

	// Token: 0x040003C0 RID: 960
	private DAssetPackageDependency m_PackageDependencyDesc;

	// Token: 0x040003C1 RID: 961
	private TMUnityAssetTreeData m_AssetTreeData;

	// Token: 0x040003C2 RID: 962
	protected int m_QureyCnt;

	// Token: 0x040003C3 RID: 963
	protected readonly int QUREY_STEP = 2;

	// Token: 0x040003C4 RID: 964
	protected Dictionary<string, AssetPackageManager.AssetPackageBundle> m_AssetPackageCache = new Dictionary<string, AssetPackageManager.AssetPackageBundle>();

	// Token: 0x040003C5 RID: 965
	protected List<AssetPackageManager.AssetPackageBundle> m_AssetPackageCacheList = new List<AssetPackageManager.AssetPackageBundle>();

	// Token: 0x040003C6 RID: 966
	protected long m_TotalSizeInMemory;

	// Token: 0x040003C7 RID: 967
	protected long m_MemoryUpperLimit = 5242880L;

	// Token: 0x040003C8 RID: 968
	protected List<AssetPackageManager.AssetPackageAsyncDesc> m_AsyncLoadPackageDescList = new List<AssetPackageManager.AssetPackageAsyncDesc>();

	// Token: 0x040003C9 RID: 969
	protected List<AssetPackageManager.AssetPackageAsyncDesc> m_AsyncIdlePackageDescList = new List<AssetPackageManager.AssetPackageAsyncDesc>();

	// Token: 0x020000BF RID: 191
	private class AssetSearchCompare : IComparer<DAssetPackageMapDesc>
	{
		// Token: 0x06000425 RID: 1061 RVA: 0x0001DAC7 File Offset: 0x0001BEC7
		public int Compare(DAssetPackageMapDesc x, DAssetPackageMapDesc y)
		{
			return x.assetPathKey.CompareTo(y.assetPathKey);
		}
	}

	// Token: 0x020000C0 RID: 192
	protected class AssetPackageBundle
	{
		// Token: 0x040003CA RID: 970
		public int m_AccessCnt;

		// Token: 0x040003CB RID: 971
		public float m_FirstAccessTime;

		// Token: 0x040003CC RID: 972
		public AssetPackage m_AssetPackage;
	}

	// Token: 0x020000C1 RID: 193
	protected class AssetPackageAsyncDesc
	{
		// Token: 0x040003CD RID: 973
		public AssetPackage m_AssetPackage;

		// Token: 0x040003CE RID: 974
		public bool m_AsDependency = true;

		// Token: 0x040003CF RID: 975
		public int m_RefCount;
	}
}
