using System;
using UnityEngine;

// Token: 0x02004B68 RID: 19304
[Serializable]
public class DDecoratorInfo : DEntityInfo, ISceneDecoratorInfoData
{
	// Token: 0x0601C638 RID: 116280 RVA: 0x0089DC78 File Offset: 0x0089C078
	public override void Duplicate(DEntityInfo info)
	{
		base.Duplicate(info);
		DDecoratorInfo ddecoratorInfo = info as DDecoratorInfo;
		if (ddecoratorInfo != null)
		{
			this.localScale = ddecoratorInfo.localScale;
			this.rotation = ddecoratorInfo.rotation;
		}
	}

	// Token: 0x0601C639 RID: 116281 RVA: 0x0089DCB1 File Offset: 0x0089C0B1
	public Vector3 GetLocalScale()
	{
		return this.localScale;
	}

	// Token: 0x0601C63A RID: 116282 RVA: 0x0089DCB9 File Offset: 0x0089C0B9
	public Quaternion GetRotation()
	{
		return this.rotation;
	}

	// Token: 0x0601C63B RID: 116283 RVA: 0x0089DCC1 File Offset: 0x0089C0C1
	public ISceneEntityInfoData GetEntityInfo()
	{
		return this;
	}

	// Token: 0x04013867 RID: 79975
	public Vector3 localScale = Vector3.one;

	// Token: 0x04013868 RID: 79976
	public Quaternion rotation;
}
