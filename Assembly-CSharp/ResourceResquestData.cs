using System;

// Token: 0x020000D9 RID: 217
public class ResourceResquestData : AsyncLoadData
{
	// Token: 0x060004A6 RID: 1190 RVA: 0x0001F738 File Offset: 0x0001DB38
	public ResourceResquestData(Type type, string subRes = "")
	{
		this.m_AssetType = type;
		this.m_SubAsset = subRes;
	}

	// Token: 0x0400041F RID: 1055
	public string m_SubAsset;

	// Token: 0x04000420 RID: 1056
	public Type m_AssetType;
}
