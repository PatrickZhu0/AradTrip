using System;
using System.Collections.Generic;
using FBSceneData;
using FlatBuffers;
using UnityEngine;

// Token: 0x02004B16 RID: 19222
public class FBSceneDataTools
{
	// Token: 0x0601C080 RID: 114816 RVA: 0x0088FA0E File Offset: 0x0088DE0E
	private static T Call<T>(Func<T> func)
	{
		return func();
	}

	// Token: 0x0601C081 RID: 114817 RVA: 0x0088FA18 File Offset: 0x0088DE18
	private static StringOffset _createString(FlatBufferBuilder builder, string value)
	{
		if (value == null)
		{
			return default(StringOffset);
		}
		return builder.CreateString(value);
	}

	// Token: 0x0601C082 RID: 114818 RVA: 0x0088FA3C File Offset: 0x0088DE3C
	private static Offset<Vector2> _createVec2(FlatBufferBuilder builder, Vector2 pos)
	{
		return Vector2.CreateVector2(builder, pos.x, pos.y);
	}

	// Token: 0x0601C083 RID: 114819 RVA: 0x0088FA52 File Offset: 0x0088DE52
	private static Offset<Vector3> _createVec3(FlatBufferBuilder builder, Vector3 pos)
	{
		return Vector3.CreateVector3(builder, pos.x, pos.y, pos.z);
	}

	// Token: 0x0601C084 RID: 114820 RVA: 0x0088FA6F File Offset: 0x0088DE6F
	private static Offset<Color> _createColor(FlatBufferBuilder builder, Color color)
	{
		return Color.CreateColor(builder, color.r, color.g, color.b, color.a);
	}

	// Token: 0x0601C085 RID: 114821 RVA: 0x0088FA94 File Offset: 0x0088DE94
	private static Offset<FBSceneData.DEntityInfo> _createFBEntityInfo(FlatBufferBuilder builder, global::DEntityInfo info)
	{
		if (info == null)
		{
			return default(Offset<FBSceneData.DEntityInfo>);
		}
		StringOffset nameOffset = FBSceneDataTools._createString(builder, info.name);
		StringOffset pathOffset = FBSceneDataTools._createString(builder, info.path);
		StringOffset descriptionOffset = FBSceneDataTools._createString(builder, info.description);
		StringOffset typeNameOffset = FBSceneDataTools._createString(builder, info.typename);
		FBSceneData.DEntityInfo.StartDEntityInfo(builder);
		FBSceneData.DEntityInfo.AddGlobalid(builder, info.globalid);
		FBSceneData.DEntityInfo.AddResid(builder, info.resid);
		FBSceneData.DEntityInfo.AddType(builder, (FBSceneData.DEntityType)info.type);
		FBSceneData.DEntityInfo.AddScale(builder, info.scale);
		FBSceneData.DEntityInfo.AddColor(builder, FBSceneDataTools._createColor(builder, info.color));
		FBSceneData.DEntityInfo.AddPosition(builder, FBSceneDataTools._createVec3(builder, info.position));
		FBSceneData.DEntityInfo.AddName(builder, nameOffset);
		FBSceneData.DEntityInfo.AddPath(builder, pathOffset);
		FBSceneData.DEntityInfo.AddDescription(builder, descriptionOffset);
		FBSceneData.DEntityInfo.AddTypeName(builder, typeNameOffset);
		return FBSceneData.DEntityInfo.EndDEntityInfo(builder);
	}

	// Token: 0x0601C086 RID: 114822 RVA: 0x0088FB64 File Offset: 0x0088DF64
	private static Offset<FBSceneData.DDecoratorInfo> _createFBDDecoratorInfo(FlatBufferBuilder builder, global::DDecoratorInfo info)
	{
		if (info == null)
		{
			return default(Offset<FBSceneData.DDecoratorInfo>);
		}
		Offset<FBSceneData.DEntityInfo> superOffset = FBSceneDataTools._createFBEntityInfo(builder, info);
		FBSceneData.DDecoratorInfo.StartDDecoratorInfo(builder);
		FBSceneData.DDecoratorInfo.AddSuper(builder, superOffset);
		FBSceneData.DDecoratorInfo.AddLocalScale(builder, FBSceneDataTools._createVec3(builder, info.localScale));
		FBSceneData.DDecoratorInfo.AddRotation(builder, FBSceneDataTools._createQuaternion(builder, info.rotation));
		return FBSceneData.DDecoratorInfo.EndDDecoratorInfo(builder);
	}

	// Token: 0x0601C087 RID: 114823 RVA: 0x0088FBC0 File Offset: 0x0088DFC0
	private static Offset<Quaternion> _createQuaternion(FlatBufferBuilder builder, Quaternion quat)
	{
		return Quaternion.CreateQuaternion(builder, quat.x, quat.y, quat.z, quat.w);
	}

	// Token: 0x0601C088 RID: 114824 RVA: 0x0088FBE4 File Offset: 0x0088DFE4
	private static Offset<FBSceneData.DNPCInfo> _createFBNpcInfo(FlatBufferBuilder builder, global::DNPCInfo info)
	{
		if (info == null)
		{
			return default(Offset<FBSceneData.DNPCInfo>);
		}
		Offset<FBSceneData.DEntityInfo> superOffset = FBSceneDataTools._createFBEntityInfo(builder, info);
		FBSceneData.DNPCInfo.StartDNPCInfo(builder);
		FBSceneData.DNPCInfo.AddSuper(builder, superOffset);
		FBSceneData.DNPCInfo.AddRotation(builder, FBSceneDataTools._createQuaternion(builder, info.rotation));
		FBSceneData.DNPCInfo.AddMinFindRange(builder, FBSceneDataTools._createVec2(builder, info.minFindRange));
		FBSceneData.DNPCInfo.AddMaxFindRange(builder, FBSceneDataTools._createVec2(builder, info.maxFindRange));
		return FBSceneData.DNPCInfo.EndDNPCInfo(builder);
	}

	// Token: 0x0601C089 RID: 114825 RVA: 0x0088FC54 File Offset: 0x0088E054
	private static Offset<FBSceneData.DRegionInfo> _createRegionInfo(FlatBufferBuilder builder, global::DRegionInfo info)
	{
		if (info == null)
		{
			return default(Offset<FBSceneData.DRegionInfo>);
		}
		Offset<FBSceneData.DEntityInfo> superOffset = FBSceneDataTools._createFBEntityInfo(builder, info);
		FBSceneData.DRegionInfo.StartDRegionInfo(builder);
		FBSceneData.DRegionInfo.AddSuper(builder, superOffset);
		FBSceneData.DRegionInfo.AddRegiontype(builder, (RegionType)info.regiontype);
		FBSceneData.DRegionInfo.AddRect(builder, FBSceneDataTools._createVec2(builder, info.rect));
		FBSceneData.DRegionInfo.AddRadius(builder, info.radius);
		FBSceneData.DRegionInfo.AddRotation(builder, FBSceneDataTools._createQuaternion(builder, info.rotation));
		return FBSceneData.DRegionInfo.EndDRegionInfo(builder);
	}

	// Token: 0x0601C08A RID: 114826 RVA: 0x0088FCCC File Offset: 0x0088E0CC
	private static Offset<FBSceneData.FunctionPrefab> _createFunctionPrefab(FlatBufferBuilder builder, global::FunctionPrefab info)
	{
		if (info == null)
		{
			return default(Offset<FBSceneData.FunctionPrefab>);
		}
		Offset<FBSceneData.DEntityInfo> super = FBSceneDataTools._createFBEntityInfo(builder, info);
		return FBSceneData.FunctionPrefab.CreateFunctionPrefab(builder, super, (FunctionType)info.eFunctionType);
	}

	// Token: 0x0601C08B RID: 114827 RVA: 0x0088FD00 File Offset: 0x0088E100
	private static Offset<FBSceneData.DTownDoor> _createTownDoor(FlatBufferBuilder builder, global::DTownDoor info)
	{
		if (info == null)
		{
			return default(Offset<FBSceneData.DTownDoor>);
		}
		Offset<FBSceneData.DRegionInfo> superOffset = FBSceneDataTools._createRegionInfo(builder, info);
		FBSceneData.DTownDoor.StartDTownDoor(builder);
		FBSceneData.DTownDoor.AddSuper(builder, superOffset);
		FBSceneData.DTownDoor.AddSceneID(builder, info.SceneID);
		FBSceneData.DTownDoor.AddDoorID(builder, info.DoorID);
		FBSceneData.DTownDoor.AddTargetDoorID(builder, info.TargetDoorID);
		FBSceneData.DTownDoor.AddTargetSceneID(builder, info.TargetSceneID);
		FBSceneData.DTownDoor.AddBirthPos(builder, FBSceneDataTools._createVec3(builder, info.BirthPos));
		return FBSceneData.DTownDoor.EndDTownDoor(builder);
	}

	// Token: 0x0601C08C RID: 114828 RVA: 0x0088FD7C File Offset: 0x0088E17C
	private static Offset<FBSceneData.DTransferInfo> _createAirPos(FlatBufferBuilder builder, global::DTransferInfo info)
	{
		if (info == null)
		{
			return default(Offset<FBSceneData.DTransferInfo>);
		}
		Offset<FBSceneData.DEntityInfo> super = FBSceneDataTools._createFBEntityInfo(builder, info);
		return FBSceneData.DTransferInfo.CreateDTransferInfo(builder, super, info.regionId);
	}

	// Token: 0x0601C08D RID: 114829 RVA: 0x0088FDB0 File Offset: 0x0088E1B0
	private static Offset<FBSceneData.DTransportDoor> _createTransportDoor(FlatBufferBuilder builder, global::DTransportDoor info)
	{
		if (info == null)
		{
			return default(Offset<FBSceneData.DTransportDoor>);
		}
		Offset<FBSceneData.DRegionInfo> superOffset = FBSceneDataTools._createRegionInfo(builder, info);
		StringOffset townscenepathOffset = FBSceneDataTools._createString(builder, info.townscenepath);
		FBSceneData.DTransportDoor.StartDTransportDoor(builder);
		FBSceneData.DTransportDoor.AddSuper(builder, superOffset);
		FBSceneData.DTransportDoor.AddIseggdoor(builder, info.isEggDoor);
		FBSceneData.DTransportDoor.AddDoortype(builder, (FBSceneData.TransportDoorType)info.doortype);
		FBSceneData.DTransportDoor.AddNextsceneid(builder, info.nextsceneid);
		FBSceneData.DTransportDoor.AddNextdoortype(builder, (FBSceneData.TransportDoorType)info.nextdoortype);
		FBSceneData.DTransportDoor.AddBirthposition(builder, FBSceneDataTools._createVec3(builder, info.birthposition));
		FBSceneData.DTransportDoor.AddTownscenepath(builder, townscenepathOffset);
		return FBSceneData.DTransportDoor.EndDTransportDoor(builder);
	}

	// Token: 0x0601C08E RID: 114830 RVA: 0x0088FE40 File Offset: 0x0088E240
	private static Offset<FBSceneData.DDestructibleInfo> _createDDestructibleInfo(FlatBufferBuilder builder, global::DDestructibleInfo info)
	{
		if (info == null)
		{
			return default(Offset<FBSceneData.DDestructibleInfo>);
		}
		Offset<FBSceneData.DEntityInfo> superOffset = FBSceneDataTools._createFBEntityInfo(builder, info);
		FBSceneData.DDestructibleInfo.StartDDestructibleInfo(builder);
		FBSceneData.DDestructibleInfo.AddSuper(builder, superOffset);
		FBSceneData.DDestructibleInfo.AddRotation(builder, FBSceneDataTools._createQuaternion(builder, info.rotation));
		FBSceneData.DDestructibleInfo.AddLevel(builder, info.level);
		FBSceneData.DDestructibleInfo.AddFlushGroupID(builder, info.flushGroupID);
		return FBSceneData.DDestructibleInfo.EndDDestructibleInfo(builder);
	}

	// Token: 0x0601C08F RID: 114831 RVA: 0x0088FEA4 File Offset: 0x0088E2A4
	private static Offset<FBSceneData.DMonsterInfo> _createMonsterInfo(FlatBufferBuilder builder, global::DMonsterInfo info)
	{
		if (info == null)
		{
			return default(Offset<FBSceneData.DMonsterInfo>);
		}
		Offset<FBSceneData.DEntityInfo> super = FBSceneDataTools._createFBEntityInfo(builder, info);
		Offset<FBSceneData.DRegionInfo> regionInfo = FBSceneDataTools._createRegionInfo(builder, info.regionInfo);
		Offset<FBSceneData.DDestructibleInfo> destructInfo = FBSceneDataTools._createDDestructibleInfo(builder, info.destructInfo);
		return FBSceneData.DMonsterInfo.CreateDMonsterInfo(builder, super, (MonsterSwapType)info.swapType, (FaceType)info.faceType, info.swapNum, info.swapDelay, info.flushGroupID, (FlowRegionType)info.flowRegionType, regionInfo, destructInfo);
	}

	// Token: 0x0601C090 RID: 114832 RVA: 0x0088FF14 File Offset: 0x0088E314
	public static Offset<FBSceneData.DSceneData> CreateFBSceneData(FlatBufferBuilder builder, global::DSceneData editorData)
	{
		if (null == editorData)
		{
			return default(Offset<FBSceneData.DSceneData>);
		}
		StringOffset nameOffset = FBSceneDataTools._createString(builder, editorData.name);
		StringOffset prefabpathOffset = FBSceneDataTools._createString(builder, editorData._prefabpath);
		StringOffset lightmapsettingsPathOffset = FBSceneDataTools._createString(builder, editorData._LightmapsettingsPath);
		List<Offset<FBSceneData.DEntityInfo>> list = new List<Offset<FBSceneData.DEntityInfo>>();
		for (int i = 0; i < editorData._entityinfo.Length; i++)
		{
			list.Add(FBSceneDataTools._createFBEntityInfo(builder, editorData._entityinfo[i]));
		}
		VectorOffset entityinfoOffset = FBSceneData.DSceneData.CreateEntityinfoVector(builder, list.ToArray());
		VectorOffset blocklayerOffset = FBSceneData.DSceneData.CreateBlocklayerVector(builder, editorData._blocklayer);
		List<Offset<FBSceneData.DNPCInfo>> list2 = new List<Offset<FBSceneData.DNPCInfo>>();
		for (int j = 0; j < editorData._npcinfo.Length; j++)
		{
			list2.Add(FBSceneDataTools._createFBNpcInfo(builder, editorData._npcinfo[j]));
		}
		VectorOffset npcinfoOffset = FBSceneData.DSceneData.CreateNpcinfoVector(builder, list2.ToArray());
		List<Offset<FBSceneData.DMonsterInfo>> list3 = new List<Offset<FBSceneData.DMonsterInfo>>();
		for (int k = 0; k < editorData._monsterinfo.Length; k++)
		{
			list3.Add(FBSceneDataTools._createMonsterInfo(builder, editorData._monsterinfo[k]));
		}
		VectorOffset monsterinfoOffset = FBSceneData.DSceneData.CreateMonsterinfoVector(builder, list3.ToArray());
		List<Offset<FBSceneData.DDecoratorInfo>> list4 = new List<Offset<FBSceneData.DDecoratorInfo>>();
		for (int l = 0; l < editorData._decoratorinfo.Length; l++)
		{
			list4.Add(FBSceneDataTools._createFBDDecoratorInfo(builder, editorData._decoratorinfo[l]));
		}
		VectorOffset decoratorinfoOffset = FBSceneData.DSceneData.CreateDecoratorinfoVector(builder, list4.ToArray());
		List<Offset<FBSceneData.DDestructibleInfo>> list5 = new List<Offset<FBSceneData.DDestructibleInfo>>();
		for (int m = 0; m < editorData._desructibleinfo.Length; m++)
		{
			list5.Add(FBSceneDataTools._createDDestructibleInfo(builder, editorData._desructibleinfo[m]));
		}
		VectorOffset desructibleinfoOffset = FBSceneData.DSceneData.CreateDesructibleinfoVector(builder, list5.ToArray());
		List<Offset<FBSceneData.DRegionInfo>> list6 = new List<Offset<FBSceneData.DRegionInfo>>();
		for (int n = 0; n < editorData._regioninfo.Length; n++)
		{
			list6.Add(FBSceneDataTools._createRegionInfo(builder, editorData._regioninfo[n]));
		}
		VectorOffset regioninfoOffset = FBSceneData.DSceneData.CreateRegioninfoVector(builder, list6.ToArray());
		List<Offset<FBSceneData.DTransportDoor>> list7 = new List<Offset<FBSceneData.DTransportDoor>>();
		for (int num = 0; num < editorData._transportdoor.Length; num++)
		{
			list7.Add(FBSceneDataTools._createTransportDoor(builder, editorData._transportdoor[num]));
		}
		VectorOffset transportdoorOffset = FBSceneData.DSceneData.CreateTransportdoorVector(builder, list7.ToArray());
		Offset<FBSceneData.DEntityInfo> birthpositionOffset = FBSceneDataTools._createFBEntityInfo(builder, editorData._birthposition);
		Offset<FBSceneData.DEntityInfo> hellbirthpositionOffset = FBSceneDataTools._createFBEntityInfo(builder, editorData._hellbirthposition);
		List<Offset<FBSceneData.DTownDoor>> list8 = new List<Offset<FBSceneData.DTownDoor>>();
		for (int num2 = 0; num2 < editorData._townDoor.Length; num2++)
		{
			list8.Add(FBSceneDataTools._createTownDoor(builder, editorData._townDoor[num2]));
		}
		VectorOffset townDoorOffset = FBSceneData.DSceneData.CreateTownDoorVector(builder, list8.ToArray());
		List<Offset<FBSceneData.DTransferInfo>> list9 = new List<Offset<FBSceneData.DTransferInfo>>();
		for (int num3 = 0; num3 < editorData._fighterBornPosition.Length; num3++)
		{
			list9.Add(FBSceneDataTools._createAirPos(builder, editorData._fighterBornPosition[num3]));
		}
		VectorOffset fighterBornPositionOffset = FBSceneData.DSceneData.CreateFighterBornPositionVector(builder, list9.ToArray());
		List<Offset<FBSceneData.FunctionPrefab>> list10 = new List<Offset<FBSceneData.FunctionPrefab>>();
		for (int num4 = 0; num4 < editorData._FunctionPrefab.Length; num4++)
		{
			list10.Add(FBSceneDataTools._createFunctionPrefab(builder, editorData._FunctionPrefab[num4]));
		}
		VectorOffset functionPrefabOffset = FBSceneData.DSceneData.CreateFunctionPrefabVector(builder, list10.ToArray());
		FBSceneData.DSceneData.StartDSceneData(builder);
		FBSceneData.DSceneData.AddName(builder, nameOffset);
		FBSceneData.DSceneData.AddPrefabpath(builder, prefabpathOffset);
		FBSceneData.DSceneData.AddLightmapsettingsPath(builder, lightmapsettingsPathOffset);
		FBSceneData.DSceneData.AddId(builder, editorData._id);
		FBSceneData.DSceneData.AddCameraLookHeight(builder, editorData._CameraLookHeight);
		FBSceneData.DSceneData.AddCameraDistance(builder, editorData._CameraDistance);
		FBSceneData.DSceneData.AddCameraAngle(builder, editorData._CameraAngle);
		FBSceneData.DSceneData.AddCameraNearClip(builder, editorData._CameraNearClip);
		FBSceneData.DSceneData.AddCameraFarClip(builder, editorData._CameraFarClip);
		FBSceneData.DSceneData.AddCameraSize(builder, editorData._CameraSize);
		FBSceneData.DSceneData.AddCameraZRange(builder, FBSceneDataTools._createVec2(builder, editorData._CameraZRange));
		FBSceneData.DSceneData.AddCameraXRange(builder, FBSceneDataTools._createVec2(builder, editorData._CameraXRange));
		FBSceneData.DSceneData.AddCameraPersp(builder, editorData._CameraPersp);
		FBSceneData.DSceneData.AddCenterPostionNew(builder, FBSceneDataTools._createVec3(builder, editorData._CenterPostionNew));
		FBSceneData.DSceneData.AddScenePostion(builder, FBSceneDataTools._createVec3(builder, editorData._ScenePostion));
		FBSceneData.DSceneData.AddSceneUScale(builder, editorData._SceneUScale);
		FBSceneData.DSceneData.AddGridSize(builder, FBSceneDataTools._createVec2(builder, editorData._GridSize));
		FBSceneData.DSceneData.AddLogicXSize(builder, FBSceneDataTools._createVec2(builder, editorData._LogicXSize));
		FBSceneData.DSceneData.AddLogicZSize(builder, FBSceneDataTools._createVec2(builder, editorData._LogicZSize));
		FBSceneData.DSceneData.AddObjectDyeColor(builder, FBSceneDataTools._createColor(builder, editorData._ObjectDyeColor));
		FBSceneData.DSceneData.AddLogicPos(builder, FBSceneDataTools._createVec3(builder, editorData._LogicPos));
		FBSceneData.DSceneData.AddWeatherMode(builder, (FBSceneData.EWeatherMode)editorData._WeatherMode);
		FBSceneData.DSceneData.AddTipsID(builder, editorData._TipsID);
		FBSceneData.DSceneData.AddLogicXmin(builder, editorData._LogicXmin);
		FBSceneData.DSceneData.AddLogicXmax(builder, editorData._LogicXmax);
		FBSceneData.DSceneData.AddLogicZmin(builder, editorData._LogicZmin);
		FBSceneData.DSceneData.AddLogicZmax(builder, editorData._LogicZmax);
		FBSceneData.DSceneData.AddEntityinfo(builder, entityinfoOffset);
		FBSceneData.DSceneData.AddBlocklayer(builder, blocklayerOffset);
		FBSceneData.DSceneData.AddNpcinfo(builder, npcinfoOffset);
		FBSceneData.DSceneData.AddMonsterinfo(builder, monsterinfoOffset);
		FBSceneData.DSceneData.AddDecoratorinfo(builder, decoratorinfoOffset);
		FBSceneData.DSceneData.AddDesructibleinfo(builder, desructibleinfoOffset);
		FBSceneData.DSceneData.AddRegioninfo(builder, regioninfoOffset);
		FBSceneData.DSceneData.AddTransportdoor(builder, transportdoorOffset);
		FBSceneData.DSceneData.AddBirthposition(builder, birthpositionOffset);
		FBSceneData.DSceneData.AddHellbirthposition(builder, hellbirthpositionOffset);
		FBSceneData.DSceneData.AddTownDoor(builder, townDoorOffset);
		FBSceneData.DSceneData.AddFunctionPrefab(builder, functionPrefabOffset);
		FBSceneData.DSceneData.AddFighterBornPosition(builder, fighterBornPositionOffset);
		return FBSceneData.DSceneData.EndDSceneData(builder);
	}
}
