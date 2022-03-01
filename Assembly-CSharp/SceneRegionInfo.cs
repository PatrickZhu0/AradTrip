using System;
using FBSceneData;
using ProtoTable;
using UnityEngine;

// Token: 0x02004B58 RID: 19288
public class SceneRegionInfo : SceneEntityInfo, ISceneRegionInfoData
{
	// Token: 0x0601C589 RID: 116105 RVA: 0x0089C2BE File Offset: 0x0089A6BE
	public SceneRegionInfo(FBSceneData.DRegionInfo data) : base(data.Super)
	{
		this.mData = data;
		this.mRadius = this.mData.Radius;
		this.mRegionType = (global::DRegionInfo.RegionType)this.mData.Regiontype;
	}

	// Token: 0x0601C58A RID: 116106 RVA: 0x0089C2F8 File Offset: 0x0089A6F8
	public override string GetModelPathByResID()
	{
		SceneRegionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SceneRegionTable>(base.GetResid(), string.Empty, string.Empty);
		if (tableItem == null)
		{
			return string.Empty;
		}
		ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.ResID, string.Empty, string.Empty);
		if (tableItem2 == null)
		{
			return string.Empty;
		}
		return tableItem2.ModelPath;
	}

	// Token: 0x0601C58B RID: 116107 RVA: 0x0089C359 File Offset: 0x0089A759
	public ISceneEntityInfoData GetEntityInfo()
	{
		return this;
	}

	// Token: 0x0601C58C RID: 116108 RVA: 0x0089C35C File Offset: 0x0089A75C
	public float GetRadius()
	{
		return this.mRadius;
	}

	// Token: 0x0601C58D RID: 116109 RVA: 0x0089C364 File Offset: 0x0089A764
	public Vector2 GetRect()
	{
		return new Vector2(this.mData.Rect.X, this.mData.Rect.Y);
	}

	// Token: 0x0601C58E RID: 116110 RVA: 0x0089C38B File Offset: 0x0089A78B
	public global::DRegionInfo.RegionType GetRegiontype()
	{
		return this.mRegionType;
	}

	// Token: 0x0601C58F RID: 116111 RVA: 0x0089C394 File Offset: 0x0089A794
	public Quaternion GetRotation()
	{
		return new Quaternion(this.mData.Rotation.X, this.mData.Rotation.Y, this.mData.Rotation.Z, this.mData.Rotation.W);
	}

	// Token: 0x0601C590 RID: 116112 RVA: 0x0089C3E6 File Offset: 0x0089A7E6
	public void SetRadius(float r)
	{
		this.mRadius = r;
	}

	// Token: 0x0601C591 RID: 116113 RVA: 0x0089C3EF File Offset: 0x0089A7EF
	public void SetRegiontype(global::DRegionInfo.RegionType type)
	{
		this.mRegionType = type;
	}

	// Token: 0x040137F7 RID: 79863
	private FBSceneData.DRegionInfo mData;

	// Token: 0x040137F8 RID: 79864
	private float mRadius;

	// Token: 0x040137F9 RID: 79865
	private global::DRegionInfo.RegionType mRegionType;
}
