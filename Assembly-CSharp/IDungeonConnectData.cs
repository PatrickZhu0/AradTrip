using System;

// Token: 0x02004B7A RID: 19322
public interface IDungeonConnectData
{
	// Token: 0x0601C6B5 RID: 116405
	void SetSceneData(ISceneData sceneData);

	// Token: 0x0601C6B6 RID: 116406
	ISceneData GetSceneData();

	// Token: 0x0601C6B7 RID: 116407
	int GetLinkAreaIndexesLength();

	// Token: 0x0601C6B8 RID: 116408
	int GetLinkAreaIndex(int i);

	// Token: 0x0601C6B9 RID: 116409
	int GetIsConnectLength();

	// Token: 0x0601C6BA RID: 116410
	bool GetIsConnect(int i);

	// Token: 0x0601C6BB RID: 116411
	int GetAreaIndex();

	// Token: 0x0601C6BC RID: 116412
	int GetId();

	// Token: 0x0601C6BD RID: 116413
	string GetSceneAreaPath();

	// Token: 0x0601C6BE RID: 116414
	void SetSceneAreaPath(string path);

	// Token: 0x0601C6BF RID: 116415
	int GetPositionX();

	// Token: 0x0601C6C0 RID: 116416
	int GetPositionY();

	// Token: 0x0601C6C1 RID: 116417
	bool IsBoss();

	// Token: 0x0601C6C2 RID: 116418
	bool IsStart();

	// Token: 0x0601C6C3 RID: 116419
	bool IsEgg();

	// Token: 0x0601C6C4 RID: 116420
	bool IsNotHell();

	// Token: 0x0601C6C5 RID: 116421
	byte GetTreasureType();
}
