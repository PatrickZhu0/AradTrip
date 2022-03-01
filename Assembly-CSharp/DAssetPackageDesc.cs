using System;

// Token: 0x020000E8 RID: 232
[Serializable]
public class DAssetPackageDesc
{
	// Token: 0x04000468 RID: 1128
	[NonSerialized]
	public string[] packageDependency = new string[0];

	// Token: 0x04000469 RID: 1129
	[NonSerialized]
	public DPackAssetDesc[] packageAsset = new DPackAssetDesc[0];

	// Token: 0x0400046A RID: 1130
	[NonSerialized]
	public AssetPackage assetPackage;

	// Token: 0x0400046B RID: 1131
	[NonSerialized]
	public string packageMD5 = string.Empty;

	// Token: 0x0400046C RID: 1132
	[NonSerialized]
	public string packageKey = string.Empty;

	// Token: 0x0400046D RID: 1133
	[NonSerialized]
	public string[] packageAutoDepend = new string[0];

	// Token: 0x0400046E RID: 1134
	public int[] packageAutoDependIdx = new int[0];

	// Token: 0x0400046F RID: 1135
	public string packagePath = string.Empty;

	// Token: 0x04000470 RID: 1136
	public string packageName = string.Empty;

	// Token: 0x04000471 RID: 1137
	public int packageVer;

	// Token: 0x04000472 RID: 1138
	public uint packageFlag;
}
