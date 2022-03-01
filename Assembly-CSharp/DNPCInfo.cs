using System;
using UnityEngine;

// Token: 0x02004B63 RID: 19299
[Serializable]
public class DNPCInfo : DEntityInfo, ISceneNPCInfoData
{
	// Token: 0x0601C616 RID: 116246 RVA: 0x0089D90C File Offset: 0x0089BD0C
	public override void Duplicate(DEntityInfo info)
	{
		base.Duplicate(info);
		DNPCInfo dnpcinfo = info as DNPCInfo;
		if (dnpcinfo != null)
		{
			this.rotation = dnpcinfo.rotation;
			this.minFindRange = dnpcinfo.minFindRange;
			this.maxFindRange = dnpcinfo.maxFindRange;
		}
	}

	// Token: 0x0601C617 RID: 116247 RVA: 0x0089D951 File Offset: 0x0089BD51
	public Quaternion GetRotation()
	{
		return this.rotation;
	}

	// Token: 0x0601C618 RID: 116248 RVA: 0x0089D959 File Offset: 0x0089BD59
	public Vector2 GetMinFindRange()
	{
		return this.minFindRange;
	}

	// Token: 0x0601C619 RID: 116249 RVA: 0x0089D961 File Offset: 0x0089BD61
	public Vector2 GetMaxFindRange()
	{
		return this.maxFindRange;
	}

	// Token: 0x0601C61A RID: 116250 RVA: 0x0089D969 File Offset: 0x0089BD69
	public ISceneEntityInfoData GetEntityInfo()
	{
		return this;
	}

	// Token: 0x04013848 RID: 79944
	public Quaternion rotation;

	// Token: 0x04013849 RID: 79945
	public Vector2 minFindRange = new Vector2(1f, 3f);

	// Token: 0x0401384A RID: 79946
	public Vector2 maxFindRange = new Vector2(2.5f, 5f);
}
