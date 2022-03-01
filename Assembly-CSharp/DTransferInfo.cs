using System;

// Token: 0x02004B6F RID: 19311
[Serializable]
public class DTransferInfo : DEntityInfo
{
	// Token: 0x0601C65B RID: 116315 RVA: 0x0089DFAC File Offset: 0x0089C3AC
	public override void Duplicate(DEntityInfo info)
	{
		base.Duplicate(info);
		DTransferInfo dtransferInfo = info as DTransferInfo;
		if (dtransferInfo != null)
		{
			this.regionId = dtransferInfo.regionId;
		}
	}

	// Token: 0x04013881 RID: 80001
	public int regionId;
}
