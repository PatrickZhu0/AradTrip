using System;
using FBSceneData;
using UnityEngine;

// Token: 0x02004B57 RID: 19287
public class SceneNPCInfo : SceneEntityInfo, ISceneNPCInfoData
{
	// Token: 0x0601C584 RID: 116100 RVA: 0x0089C72F File Offset: 0x0089AB2F
	public SceneNPCInfo(FBSceneData.DNPCInfo data) : base(data.Super)
	{
		this.mData = data;
	}

	// Token: 0x0601C585 RID: 116101 RVA: 0x0089C744 File Offset: 0x0089AB44
	public ISceneEntityInfoData GetEntityInfo()
	{
		return this;
	}

	// Token: 0x0601C586 RID: 116102 RVA: 0x0089C747 File Offset: 0x0089AB47
	public Vector2 GetMaxFindRange()
	{
		return new Vector2(this.mData.MaxFindRange.X, this.mData.MaxFindRange.Y);
	}

	// Token: 0x0601C587 RID: 116103 RVA: 0x0089C76E File Offset: 0x0089AB6E
	public Vector2 GetMinFindRange()
	{
		return new Vector2(this.mData.MinFindRange.X, this.mData.MinFindRange.Y);
	}

	// Token: 0x0601C588 RID: 116104 RVA: 0x0089C798 File Offset: 0x0089AB98
	public Quaternion GetRotation()
	{
		return new Quaternion(this.mData.Rotation.X, this.mData.Rotation.Y, this.mData.Rotation.Z, this.mData.Rotation.W);
	}

	// Token: 0x040137F6 RID: 79862
	private FBSceneData.DNPCInfo mData;
}
