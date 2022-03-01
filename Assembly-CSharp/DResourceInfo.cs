using System;

// Token: 0x02004B70 RID: 19312
[Serializable]
public class DResourceInfo : DEntityInfo
{
	// Token: 0x0601C65D RID: 116317 RVA: 0x0089DFE4 File Offset: 0x0089C3E4
	public override void Duplicate(DEntityInfo info)
	{
		base.Duplicate(info);
		DResourceInfo dresourceInfo = info as DResourceInfo;
		if (dresourceInfo != null)
		{
			this.resouceId = dresourceInfo.resouceId;
		}
	}

	// Token: 0x04013882 RID: 80002
	public int resouceId;
}
