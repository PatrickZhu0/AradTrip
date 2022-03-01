using System;
using UnityEngine;

// Token: 0x02004B7C RID: 19324
public interface ISceneData
{
	// Token: 0x0601C6D2 RID: 116434
	string GetName();

	// Token: 0x0601C6D3 RID: 116435
	int GetId();

	// Token: 0x0601C6D4 RID: 116436
	string GetPrefabPath();

	// Token: 0x0601C6D5 RID: 116437
	float GetCameraLookHeight();

	// Token: 0x0601C6D6 RID: 116438
	float GetCameraDistance();

	// Token: 0x0601C6D7 RID: 116439
	float GetCameraAngle();

	// Token: 0x0601C6D8 RID: 116440
	float GetCameraNearClip();

	// Token: 0x0601C6D9 RID: 116441
	float GetCameraFarClip();

	// Token: 0x0601C6DA RID: 116442
	float GetCameraSize();

	// Token: 0x0601C6DB RID: 116443
	Vector2 GetCameraZRange();

	// Token: 0x0601C6DC RID: 116444
	Vector2 GetCameraXRange();

	// Token: 0x0601C6DD RID: 116445
	bool IsCameraPersp();

	// Token: 0x0601C6DE RID: 116446
	Vector3 GetCenterPostionNew();

	// Token: 0x0601C6DF RID: 116447
	Vector3 GetScenePostion();

	// Token: 0x0601C6E0 RID: 116448
	float GetSceneUScale();

	// Token: 0x0601C6E1 RID: 116449
	Vector2 GetGridSize();

	// Token: 0x0601C6E2 RID: 116450
	Vector2 GetLogicXSize();

	// Token: 0x0601C6E3 RID: 116451
	Vector2 GetLogicZSize();

	// Token: 0x0601C6E4 RID: 116452
	Color GetObjectDyeColor();

	// Token: 0x0601C6E5 RID: 116453
	Vector3 GetLogicPos();

	// Token: 0x0601C6E6 RID: 116454
	EWeatherMode GetWeatherMode();

	// Token: 0x0601C6E7 RID: 116455
	int GetTipsID();

	// Token: 0x0601C6E8 RID: 116456
	string GetLightmapsettingsPath();

	// Token: 0x0601C6E9 RID: 116457
	DynSceneSetting GetLightmapsettings();

	// Token: 0x0601C6EA RID: 116458
	void SetLightmapsettings(DynSceneSetting setting);

	// Token: 0x0601C6EB RID: 116459
	int GetLogicXmin();

	// Token: 0x0601C6EC RID: 116460
	int GetLogicXmax();

	// Token: 0x0601C6ED RID: 116461
	int GetLogicZmin();

	// Token: 0x0601C6EE RID: 116462
	int GetLogicZmax();

	// Token: 0x0601C6EF RID: 116463
	int GetLogicX();

	// Token: 0x0601C6F0 RID: 116464
	int GetLogicZ();

	// Token: 0x0601C6F1 RID: 116465
	int GetEntityInfoLength();

	// Token: 0x0601C6F2 RID: 116466
	ISceneEntityInfoData GetEntityInfo(int i);

	// Token: 0x0601C6F3 RID: 116467
	int GetBlockLayerLength();

	// Token: 0x0601C6F4 RID: 116468
	byte[] GetRawBlockLayer();

	// Token: 0x0601C6F5 RID: 116469
	ushort[] GetRawGrassLayer();

	// Token: 0x0601C6F6 RID: 116470
	ushort GetGrassId(int gridX, int gridY);

	// Token: 0x0601C6F7 RID: 116471
	byte GetBlockLayer(int i);

	// Token: 0x0601C6F8 RID: 116472
	int GetNpcInfoLength();

	// Token: 0x0601C6F9 RID: 116473
	ISceneNPCInfoData GetNpcInfo(int i);

	// Token: 0x0601C6FA RID: 116474
	int GetMonsterInfoLength();

	// Token: 0x0601C6FB RID: 116475
	ISceneMonsterInfoData GetMonsterInfo(int i);

	// Token: 0x0601C6FC RID: 116476
	int GetDecoratorInfoLenth();

	// Token: 0x0601C6FD RID: 116477
	ISceneDecoratorInfoData GetDecoratorInfo(int i);

	// Token: 0x0601C6FE RID: 116478
	int GetDestructibleInfoLength();

	// Token: 0x0601C6FF RID: 116479
	ISceneDestructibleInfoData GetDestructibleInfo(int i);

	// Token: 0x0601C700 RID: 116480
	int GetRegionInfoLength();

	// Token: 0x0601C701 RID: 116481
	ISceneRegionInfoData GetRegionInfo(int i);

	// Token: 0x0601C702 RID: 116482
	int GetTransportDoorLength();

	// Token: 0x0601C703 RID: 116483
	ISceneTransportDoorData GetTransportDoor(int i);

	// Token: 0x0601C704 RID: 116484
	ISceneEntityInfoData GetBirthPosition();

	// Token: 0x0601C705 RID: 116485
	ISceneEntityInfoData GetAirBattleBornPos(int i);

	// Token: 0x0601C706 RID: 116486
	ISceneEntityInfoData GetHellbirthposition();

	// Token: 0x0601C707 RID: 116487
	int GetTownDoorLength();

	// Token: 0x0601C708 RID: 116488
	ISceneTownDoorData GetTownDoor(int i);

	// Token: 0x0601C709 RID: 116489
	int GetFunctionPrefabLength();

	// Token: 0x0601C70A RID: 116490
	ISceneFunctionPrefabData GetFunctionPrefab(int i);
}
