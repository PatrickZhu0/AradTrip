using System;
using FBSceneData;
using UnityEngine;

// Token: 0x02004B51 RID: 19281
public class SceneDecoratorInfo : SceneEntityInfo, ISceneDecoratorInfoData
{
	// Token: 0x0601C55D RID: 116061 RVA: 0x0089C21C File Offset: 0x0089A61C
	public SceneDecoratorInfo(FBSceneData.DDecoratorInfo data) : base(data.Super)
	{
		this.mData = data;
	}

	// Token: 0x0601C55E RID: 116062 RVA: 0x0089C231 File Offset: 0x0089A631
	public ISceneEntityInfoData GetEntityInfo()
	{
		return this;
	}

	// Token: 0x0601C55F RID: 116063 RVA: 0x0089C234 File Offset: 0x0089A634
	public Vector3 GetLocalScale()
	{
		return new Vector3(this.mData.LocalScale.X, this.mData.LocalScale.Y, this.mData.LocalScale.Z);
	}

	// Token: 0x0601C560 RID: 116064 RVA: 0x0089C26C File Offset: 0x0089A66C
	public Quaternion GetRotation()
	{
		return new Quaternion(this.mData.Rotation.X, this.mData.Rotation.Y, this.mData.Rotation.Z, this.mData.Rotation.W);
	}

	// Token: 0x040137EC RID: 79852
	private FBSceneData.DDecoratorInfo mData;
}
