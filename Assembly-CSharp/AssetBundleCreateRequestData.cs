using System;

// Token: 0x020000DE RID: 222
public class AssetBundleCreateRequestData : AsyncLoadData
{
	// Token: 0x060004BE RID: 1214 RVA: 0x0001FA43 File Offset: 0x0001DE43
	public AssetBundleCreateRequestData(AssetPackage assetPackage)
	{
		this.m_AssetPackage = assetPackage;
	}

	// Token: 0x0400042B RID: 1067
	public AssetPackage m_AssetPackage;
}
