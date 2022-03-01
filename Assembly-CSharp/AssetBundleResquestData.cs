using System;

// Token: 0x020000DC RID: 220
public class AssetBundleResquestData : AsyncLoadData
{
	// Token: 0x060004B4 RID: 1204 RVA: 0x0001F80F File Offset: 0x0001DC0F
	public AssetBundleResquestData(Type type, string subAsset, AssetPackage assetPackage, onExtractCallback callback)
	{
		this.m_SubAsset = subAsset;
		this.m_AssetType = type;
		this.m_OnExtractCallback = callback;
		this.m_AssetPackage = assetPackage;
	}

	// Token: 0x04000424 RID: 1060
	public string m_SubAsset;

	// Token: 0x04000425 RID: 1061
	public Type m_AssetType;

	// Token: 0x04000426 RID: 1062
	public onExtractCallback m_OnExtractCallback;

	// Token: 0x04000427 RID: 1063
	public AssetPackage m_AssetPackage;
}
