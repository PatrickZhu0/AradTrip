using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000EB RID: 235
public class DAssetPackageDependency : ScriptableObject
{
	// Token: 0x060004E0 RID: 1248 RVA: 0x000217AE File Offset: 0x0001FBAE
	public static int Comparison(DAssetPackageMapDesc x, DAssetPackageMapDesc y)
	{
		return x.assetPathKey.CompareTo(y.assetPathKey);
	}

	// Token: 0x0400047A RID: 1146
	public int patchVersion;

	// Token: 0x0400047B RID: 1147
	public DAssetPackageDescType packageDescType;

	// Token: 0x0400047C RID: 1148
	public DAssetPackageDesc[] packageDescArray = new DAssetPackageDesc[0];

	// Token: 0x0400047D RID: 1149
	public List<DAssetPackageMapDesc> assetDescPackageMap = new List<DAssetPackageMapDesc>();
}
