using System;

// Token: 0x02004B7F RID: 19327
public interface ISceneTransportDoorData
{
	// Token: 0x0601C715 RID: 116501
	ISceneRegionInfoData GetRegionInfo();

	// Token: 0x0601C716 RID: 116502
	TransportDoorType GetDoortype();

	// Token: 0x0601C717 RID: 116503
	bool IsEggDoor();

	// Token: 0x0601C718 RID: 116504
	int GetNextsceneid();

	// Token: 0x0601C719 RID: 116505
	string GetTownscenepath();

	// Token: 0x0601C71A RID: 116506
	TransportDoorType GetNextdoortype();

	// Token: 0x0601C71B RID: 116507
	VInt3 GetBirthposition();

	// Token: 0x0601C71C RID: 116508
	void SetBirthposition(VInt3 pos);
}
