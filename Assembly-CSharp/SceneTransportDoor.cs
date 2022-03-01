using System;
using FBSceneData;

// Token: 0x02004B52 RID: 19282
public class SceneTransportDoor : SceneRegionInfo, ISceneTransportDoorData
{
	// Token: 0x0601C561 RID: 116065 RVA: 0x0089C3F8 File Offset: 0x0089A7F8
	public SceneTransportDoor(FBSceneData.DTransportDoor data) : base(data.Super)
	{
		this.mData = data;
		this.mBirthPosition = new VInt3(this.mData.Birthposition.X, this.mData.Birthposition.Y, this.mData.Birthposition.Z);
	}

	// Token: 0x0601C562 RID: 116066 RVA: 0x0089C453 File Offset: 0x0089A853
	public VInt3 GetBirthposition()
	{
		return this.mBirthPosition;
	}

	// Token: 0x0601C563 RID: 116067 RVA: 0x0089C45B File Offset: 0x0089A85B
	public global::TransportDoorType GetDoortype()
	{
		return (global::TransportDoorType)this.mData.Doortype;
	}

	// Token: 0x0601C564 RID: 116068 RVA: 0x0089C469 File Offset: 0x0089A869
	public global::TransportDoorType GetNextdoortype()
	{
		return (global::TransportDoorType)this.mData.Nextdoortype;
	}

	// Token: 0x0601C565 RID: 116069 RVA: 0x0089C477 File Offset: 0x0089A877
	public int GetNextsceneid()
	{
		return this.mData.Nextsceneid;
	}

	// Token: 0x0601C566 RID: 116070 RVA: 0x0089C484 File Offset: 0x0089A884
	public ISceneRegionInfoData GetRegionInfo()
	{
		return this;
	}

	// Token: 0x0601C567 RID: 116071 RVA: 0x0089C487 File Offset: 0x0089A887
	public string GetTownscenepath()
	{
		return this.mData.Townscenepath;
	}

	// Token: 0x0601C568 RID: 116072 RVA: 0x0089C494 File Offset: 0x0089A894
	public void SetBirthposition(VInt3 pos)
	{
		this.mBirthPosition = pos;
	}

	// Token: 0x0601C569 RID: 116073 RVA: 0x0089C49D File Offset: 0x0089A89D
	public bool IsEggDoor()
	{
		return this.mData.Iseggdoor;
	}

	// Token: 0x040137ED RID: 79853
	private FBSceneData.DTransportDoor mData;

	// Token: 0x040137EE RID: 79854
	private VInt3 mBirthPosition;
}
