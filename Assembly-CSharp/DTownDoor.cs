using System;
using UnityEngine;

// Token: 0x02004B72 RID: 19314
[Serializable]
public class DTownDoor : DRegionInfo, ISceneTownDoorData
{
	// Token: 0x0601C65F RID: 116319 RVA: 0x0089E01C File Offset: 0x0089C41C
	public override void Duplicate(DEntityInfo info)
	{
		base.Duplicate(info);
		DTownDoor dtownDoor = info as DTownDoor;
		if (dtownDoor != null)
		{
			this.SceneID = dtownDoor.SceneID;
			this.DoorID = dtownDoor.DoorID;
			this.BirthPos = dtownDoor.BirthPos;
			this.TargetSceneID = dtownDoor.TargetSceneID;
			this.TargetDoorID = dtownDoor.TargetDoorID;
			this.DoorType = dtownDoor.DoorType;
		}
	}

	// Token: 0x0601C660 RID: 116320 RVA: 0x0089E085 File Offset: 0x0089C485
	public int GetSceneID()
	{
		return this.SceneID;
	}

	// Token: 0x0601C661 RID: 116321 RVA: 0x0089E08D File Offset: 0x0089C48D
	public int GetDoorID()
	{
		return this.DoorID;
	}

	// Token: 0x0601C662 RID: 116322 RVA: 0x0089E095 File Offset: 0x0089C495
	public Vector3 GetBirthPos()
	{
		return this.GetLocalBirthPos() + base.GetPosition();
	}

	// Token: 0x0601C663 RID: 116323 RVA: 0x0089E0A8 File Offset: 0x0089C4A8
	public int GetTargetSceneID()
	{
		return this.TargetSceneID;
	}

	// Token: 0x0601C664 RID: 116324 RVA: 0x0089E0B0 File Offset: 0x0089C4B0
	public int GetTargetDoorID()
	{
		return this.TargetDoorID;
	}

	// Token: 0x0601C665 RID: 116325 RVA: 0x0089E0B8 File Offset: 0x0089C4B8
	public ISceneRegionInfoData GetRegionInfo()
	{
		return this;
	}

	// Token: 0x0601C666 RID: 116326 RVA: 0x0089E0BB File Offset: 0x0089C4BB
	public Vector3 GetLocalBirthPos()
	{
		return this.BirthPos;
	}

	// Token: 0x0601C667 RID: 116327 RVA: 0x0089E0C3 File Offset: 0x0089C4C3
	public DoorTargetType GetDoorTargetType()
	{
		return this.DoorType;
	}

	// Token: 0x04013886 RID: 80006
	public int SceneID;

	// Token: 0x04013887 RID: 80007
	public int DoorID;

	// Token: 0x04013888 RID: 80008
	public Vector3 BirthPos;

	// Token: 0x04013889 RID: 80009
	public int TargetSceneID;

	// Token: 0x0401388A RID: 80010
	public int TargetDoorID;

	// Token: 0x0401388B RID: 80011
	public DoorTargetType DoorType;
}
