using System;
using System.IO;
using UnityEngine;

// Token: 0x020000BD RID: 189
public class AssetPackageLoader : MonoSingleton<AssetPackageLoader>
{
	// Token: 0x0600040A RID: 1034 RVA: 0x0001CB4C File Offset: 0x0001AF4C
	public AssetBundle LoadPackage(AssetPackage package)
	{
		if (package == null)
		{
			return null;
		}
		return this._LoadPackageSync(package);
	}

	// Token: 0x0600040B RID: 1035 RVA: 0x0001CB6C File Offset: 0x0001AF6C
	public IAsyncLoadRequest<AssetBundle> LoadPackageAsync(AssetPackage package, bool highPriority)
	{
		if (package == null)
		{
			return AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>.INVALID_LOAD_REQUEST;
		}
		return this._LoadPackageAsync(package, highPriority);
	}

	// Token: 0x0600040C RID: 1036 RVA: 0x0001CB84 File Offset: 0x0001AF84
	public AssetBundle _LoadPackageSync(AssetPackage package)
	{
		AssetBundle assetBundle = this._LoadPackageSync(package, false, true);
		if (null == assetBundle)
		{
			assetBundle = this._LoadPackageSync(package, false, false);
			if (null == assetBundle)
			{
				assetBundle = this._LoadPackageSync(package, true, false);
			}
		}
		return assetBundle;
	}

	// Token: 0x0600040D RID: 1037 RVA: 0x0001CBC8 File Offset: 0x0001AFC8
	public IAsyncLoadRequest<AssetBundle> _LoadPackageAsync(AssetPackage package, bool highPriority)
	{
		IAsyncLoadRequest<AssetBundle> asyncLoadRequest = this._LoadPackageAsync(package, false, true, highPriority);
		if (!asyncLoadRequest.IsValid())
		{
			asyncLoadRequest = this._LoadPackageAsync(package, false, false, highPriority);
			if (!asyncLoadRequest.IsValid())
			{
				asyncLoadRequest = this._LoadPackageAsync(package, true, false, highPriority);
			}
		}
		return asyncLoadRequest;
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x0001CC10 File Offset: 0x0001B010
	public AssetBundle _LoadPackageSync(AssetPackage package, bool fromNative, bool fromHotfix)
	{
		string text;
		if (fromNative)
		{
			text = Application.streamingAssetsPath;
		}
		else
		{
			text = Application.persistentDataPath;
		}
		text = Path.Combine(text, (!fromHotfix) ? package.packageFullPath : package.packageHotfixPath);
		if (!fromNative && !File.Exists(text))
		{
			return null;
		}
		AssetBundle assetBundle = Singleton<AssetBundleRegiester>.instance.AquireAssetBundle(text);
		if (null != assetBundle)
		{
			return assetBundle;
		}
		assetBundle = AssetBundle.LoadFromFile(text);
		if (null != assetBundle)
		{
			Singleton<AssetBundleRegiester>.instance.RegiesterAssetBundle(text, assetBundle);
			return assetBundle;
		}
		return null;
	}

	// Token: 0x0600040F RID: 1039 RVA: 0x0001CCA4 File Offset: 0x0001B0A4
	public IAsyncLoadRequest<AssetBundle> _LoadPackageAsync(AssetPackage package, bool fromNative, bool fromHotfix, bool highPriority)
	{
		if (fromNative)
		{
			string text = Path.Combine(Application.streamingAssetsPath, package.packageFullPath);
			AssetBundle assetBundle = Singleton<AssetBundleRegiester>.instance.AquireAssetBundle(text);
			if (null != assetBundle)
			{
				return Singleton<AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>>.instance.AllocAsyncTaskWithTarget(assetBundle, text, highPriority);
			}
			return Singleton<AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>>.instance.AllocAsyncTask(text, new AssetBundleCreateRequestData(package), highPriority);
		}
		else
		{
			string text = Path.Combine(Application.persistentDataPath, (!fromHotfix) ? package.packageFullPath : package.packageHotfixPath);
			if (!File.Exists(text))
			{
				return AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>.INVALID_LOAD_REQUEST;
			}
			AssetBundle assetBundle2 = Singleton<AssetBundleRegiester>.instance.AquireAssetBundle(text);
			if (null != assetBundle2)
			{
				return Singleton<AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>>.instance.AllocAsyncTaskWithTarget(assetBundle2, text, highPriority);
			}
			return Singleton<AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>>.instance.AllocAsyncTask(text, new AssetBundleCreateRequestData(package), highPriority);
		}
	}

	// Token: 0x06000410 RID: 1040 RVA: 0x0001CD72 File Offset: 0x0001B172
	public AssetBundle _LoadPackageFromWWW(AssetPackage package, out long packageBytes, bool bAsync = false)
	{
		packageBytes = 0L;
		return null;
	}
}
