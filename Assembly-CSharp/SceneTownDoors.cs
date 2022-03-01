using System;
using FBSceneData;
using UnityEngine;

// Token: 0x02004B59 RID: 19289
public class SceneTownDoors : SceneRegionInfo, ISceneTownDoorData
{
	// Token: 0x0601C592 RID: 116114 RVA: 0x0089C7EA File Offset: 0x0089ABEA
	public SceneTownDoors(FBSceneData.DTownDoor data) : base(data.Super)
	{
		this.mData = data;
		this.mSuper = this;
	}

	// Token: 0x0601C593 RID: 116115 RVA: 0x0089C806 File Offset: 0x0089AC06
	public Vector3 GetBirthPos()
	{
		return this.GetLocalBirthPos() + this.GetRegionInfo().GetEntityInfo().GetPosition();
	}

	// Token: 0x0601C594 RID: 116116 RVA: 0x0089C823 File Offset: 0x0089AC23
	public int GetDoorID()
	{
		return this.mData.DoorID;
	}

	// Token: 0x0601C595 RID: 116117 RVA: 0x0089C830 File Offset: 0x0089AC30
	public Vector3 GetLocalBirthPos()
	{
		return new Vector3(this.mData.BirthPos.X, this.mData.BirthPos.Y, this.mData.BirthPos.Z);
	}

	// Token: 0x0601C596 RID: 116118 RVA: 0x0089C867 File Offset: 0x0089AC67
	public ISceneRegionInfoData GetRegionInfo()
	{
		return this.mSuper;
	}

	// Token: 0x0601C597 RID: 116119 RVA: 0x0089C86F File Offset: 0x0089AC6F
	public int GetSceneID()
	{
		return this.mData.SceneID;
	}

	// Token: 0x0601C598 RID: 116120 RVA: 0x0089C87C File Offset: 0x0089AC7C
	public int GetTargetDoorID()
	{
		return this.mData.TargetDoorID;
	}

	// Token: 0x0601C599 RID: 116121 RVA: 0x0089C889 File Offset: 0x0089AC89
	public int GetTargetSceneID()
	{
		return this.mData.TargetSceneID;
	}

	// Token: 0x0601C59A RID: 116122 RVA: 0x0089C896 File Offset: 0x0089AC96
	public global::DoorTargetType GetDoorTargetType()
	{
		return (global::DoorTargetType)this.mData.DoorType;
	}

	// Token: 0x040137FA RID: 79866
	private FBSceneData.DTownDoor mData;

	// Token: 0x040137FB RID: 79867
	private ISceneRegionInfoData mSuper;
}
