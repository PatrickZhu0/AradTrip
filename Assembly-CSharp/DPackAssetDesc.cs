using System;

// Token: 0x020000E7 RID: 231
[Serializable]
public class DPackAssetDesc
{
	// Token: 0x060004DD RID: 1245 RVA: 0x00021708 File Offset: 0x0001FB08
	public DPackAssetDesc(string asset, string guid)
	{
		this.packageAsset = asset;
		this.packageGUID = guid;
	}

	// Token: 0x04000466 RID: 1126
	public string packageAsset;

	// Token: 0x04000467 RID: 1127
	public string packageGUID;
}
