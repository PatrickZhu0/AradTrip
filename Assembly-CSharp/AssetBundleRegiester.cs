using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000A6 RID: 166
public class AssetBundleRegiester : Singleton<AssetBundleRegiester>
{
	// Token: 0x06000380 RID: 896 RVA: 0x0001A248 File Offset: 0x00018648
	public void RegiesterAssetBundle(string assetPackage, AssetBundle assetBundle)
	{
		if (null == assetBundle)
		{
			return;
		}
		AssetBundleRegiester.AssetBundleDesc assetBundleDesc = null;
		if (this.m_AssetBundleRegTable.TryGetValue(assetPackage, out assetBundleDesc))
		{
			if (null != assetBundleDesc.m_AssetBundle)
			{
				assetBundleDesc.m_AssetBundle.Unload(false);
			}
			assetBundleDesc.m_AssetBundle = assetBundle;
			assetBundleDesc.m_RefCount = 1;
			return;
		}
		assetBundleDesc = new AssetBundleRegiester.AssetBundleDesc(assetBundle);
		assetBundleDesc.m_RefCount = 1;
		this.m_AssetBundleRegTable.Add(assetPackage, assetBundleDesc);
	}

	// Token: 0x06000381 RID: 897 RVA: 0x0001A2C0 File Offset: 0x000186C0
	public AssetBundle AquireAssetBundle(string assetPackage)
	{
		AssetBundleRegiester.AssetBundleDesc assetBundleDesc = null;
		if (this.m_AssetBundleRegTable.TryGetValue(assetPackage, out assetBundleDesc))
		{
			assetBundleDesc.m_RefCount++;
			return assetBundleDesc.m_AssetBundle;
		}
		return null;
	}

	// Token: 0x06000382 RID: 898 RVA: 0x0001A2F8 File Offset: 0x000186F8
	public void ReleaseAssetBundle(AssetBundle assetBundle, bool forceUnload = false)
	{
		foreach (KeyValuePair<string, AssetBundleRegiester.AssetBundleDesc> keyValuePair in this.m_AssetBundleRegTable)
		{
			AssetBundleRegiester.AssetBundleDesc value = keyValuePair.Value;
			if (value.m_AssetBundle.GetInstanceID() == assetBundle.GetInstanceID())
			{
				value.m_RefCount--;
				if (value.m_RefCount <= 0)
				{
					value.m_AssetBundle.Unload(forceUnload);
					Dictionary<string, AssetBundleRegiester.AssetBundleDesc> assetBundleRegTable = this.m_AssetBundleRegTable;
					Dictionary<string, AssetBundleRegiester.AssetBundleDesc>.Enumerator enumerator;
					KeyValuePair<string, AssetBundleRegiester.AssetBundleDesc> keyValuePair2 = enumerator.Current;
					assetBundleRegTable.Remove(keyValuePair2.Key);
				}
				return;
			}
		}
	}

	// Token: 0x04000354 RID: 852
	private readonly Dictionary<string, AssetBundleRegiester.AssetBundleDesc> m_AssetBundleRegTable = new Dictionary<string, AssetBundleRegiester.AssetBundleDesc>();

	// Token: 0x020000A7 RID: 167
	private class AssetBundleDesc
	{
		// Token: 0x06000383 RID: 899 RVA: 0x0001A38A File Offset: 0x0001878A
		public AssetBundleDesc(AssetBundle assetBundle)
		{
			this.m_AssetBundle = assetBundle;
			this.m_RefCount = 0;
		}

		// Token: 0x04000355 RID: 853
		public int m_RefCount;

		// Token: 0x04000356 RID: 854
		public AssetBundle m_AssetBundle;
	}
}
