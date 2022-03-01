using System;
using System.Collections.Generic;
using FBSceneData;
using UnityEngine;

// Token: 0x02004B5A RID: 19290
public class BattleSceneData : ISceneData
{
	// Token: 0x0601C59B RID: 116123 RVA: 0x0089C8A4 File Offset: 0x0089ACA4
	public BattleSceneData(FBSceneData.DSceneData data)
	{
		this.mData = data;
		this._initAirBattleBornPos();
		this._initBirthPosition();
		this._initDecorators();
		this._initTransportDoors();
		this._initDestructibleInfos();
		this._initEntityInfos();
		this._initFunctionPrefabs();
		this._initMonsterInfos();
		this._initNPCInfos();
		this._initHellbirthposition();
		this._initRegionInfos();
		this._initTownDoors();
		this._initBlockLayer();
	}

	// Token: 0x0601C59C RID: 116124 RVA: 0x0089C988 File Offset: 0x0089AD88
	private void _initBlockLayer()
	{
		this.mBlockLayer = new byte[this.mData.BlocklayerLength];
		for (int i = 0; i < this.mBlockLayer.Length; i++)
		{
			this.mBlockLayer[i] = this.mData.GetBlocklayer(i);
		}
	}

	// Token: 0x0601C59D RID: 116125 RVA: 0x0089C9D8 File Offset: 0x0089ADD8
	private void _initBirthPosition()
	{
		this.mBirthPosition = new SceneEntityInfo(this.mData.Birthposition);
	}

	// Token: 0x0601C59E RID: 116126 RVA: 0x0089C9F0 File Offset: 0x0089ADF0
	private void _initDecorators()
	{
		for (int i = 0; i < this.mData.DecoratorinfoLength; i++)
		{
			this.mDecoratorInfos.Add(new SceneDecoratorInfo(this.mData.GetDecoratorinfo(i)));
		}
	}

	// Token: 0x0601C59F RID: 116127 RVA: 0x0089CA38 File Offset: 0x0089AE38
	private void _initAirBattleBornPos()
	{
		for (int i = 0; i < this.mData.FighterBornPositionLength; i++)
		{
			this.airBattleBornPos.Add(new SceneTransferInfo(this.mData.GetFighterBornPosition(i)));
		}
	}

	// Token: 0x0601C5A0 RID: 116128 RVA: 0x0089CA80 File Offset: 0x0089AE80
	private void _initTransportDoors()
	{
		for (int i = 0; i < this.mData.TransportdoorLength; i++)
		{
			this.mTransportDoors.Add(new SceneTransportDoor(this.mData.GetTransportdoor(i)));
		}
	}

	// Token: 0x0601C5A1 RID: 116129 RVA: 0x0089CAC8 File Offset: 0x0089AEC8
	private void _initDestructibleInfos()
	{
		for (int i = 0; i < this.mData.DesructibleinfoLength; i++)
		{
			this.mDestructibleInfos.Add(new SceneDestructibleInfo(this.mData.GetDesructibleinfo(i)));
		}
	}

	// Token: 0x0601C5A2 RID: 116130 RVA: 0x0089CB10 File Offset: 0x0089AF10
	private void _initEntityInfos()
	{
		for (int i = 0; i < this.mData.EntityinfoLength; i++)
		{
			this.mEntityInfos.Add(new SceneEntityInfo(this.mData.GetEntityinfo(i)));
		}
	}

	// Token: 0x0601C5A3 RID: 116131 RVA: 0x0089CB58 File Offset: 0x0089AF58
	private void _initFunctionPrefabs()
	{
		for (int i = 0; i < this.mData.FunctionPrefabLength; i++)
		{
			this.mFunctionPrefabDatas.Add(new SceneFunctionPrefab(this.mData.GetFunctionPrefab(i)));
		}
	}

	// Token: 0x0601C5A4 RID: 116132 RVA: 0x0089CBA0 File Offset: 0x0089AFA0
	private void _initMonsterInfos()
	{
		for (int i = 0; i < this.mData.MonsterinfoLength; i++)
		{
			this.mMonsterInfos.Add(new SceneMonsterInfo(this.mData.GetMonsterinfo(i)));
		}
	}

	// Token: 0x0601C5A5 RID: 116133 RVA: 0x0089CBE8 File Offset: 0x0089AFE8
	private void _initNPCInfos()
	{
		for (int i = 0; i < this.mData.NpcinfoLength; i++)
		{
			this.mNPCInfos.Add(new SceneNPCInfo(this.mData.GetNpcinfo(i)));
		}
	}

	// Token: 0x0601C5A6 RID: 116134 RVA: 0x0089CC2D File Offset: 0x0089B02D
	private void _initHellbirthposition()
	{
		this.mHellbirthposition = new SceneEntityInfo(this.mData.Hellbirthposition);
	}

	// Token: 0x0601C5A7 RID: 116135 RVA: 0x0089CC48 File Offset: 0x0089B048
	private void _initRegionInfos()
	{
		for (int i = 0; i < this.mData.RegioninfoLength; i++)
		{
			this.mRegionInfos.Add(new SceneRegionInfo(this.mData.GetRegioninfo(i)));
		}
	}

	// Token: 0x0601C5A8 RID: 116136 RVA: 0x0089CC90 File Offset: 0x0089B090
	private void _initTownDoors()
	{
		for (int i = 0; i < this.mData.TownDoorLength; i++)
		{
			this.mTownDoors.Add(new SceneTownDoors(this.mData.GetTownDoor(i)));
		}
	}

	// Token: 0x0601C5A9 RID: 116137 RVA: 0x0089CCD5 File Offset: 0x0089B0D5
	public ISceneEntityInfoData GetBirthPosition()
	{
		return this.mBirthPosition;
	}

	// Token: 0x0601C5AA RID: 116138 RVA: 0x0089CCDD File Offset: 0x0089B0DD
	public byte GetBlockLayer(int i)
	{
		return this.mData.GetBlocklayer(i);
	}

	// Token: 0x0601C5AB RID: 116139 RVA: 0x0089CCEB File Offset: 0x0089B0EB
	public int GetBlockLayerLength()
	{
		return this.mData.BlocklayerLength;
	}

	// Token: 0x0601C5AC RID: 116140 RVA: 0x0089CCF8 File Offset: 0x0089B0F8
	public float GetCameraAngle()
	{
		return this.mData.CameraAngle;
	}

	// Token: 0x0601C5AD RID: 116141 RVA: 0x0089CD05 File Offset: 0x0089B105
	public float GetCameraDistance()
	{
		return this.mData.CameraDistance;
	}

	// Token: 0x0601C5AE RID: 116142 RVA: 0x0089CD12 File Offset: 0x0089B112
	public float GetCameraFarClip()
	{
		return this.mData.CameraFarClip;
	}

	// Token: 0x0601C5AF RID: 116143 RVA: 0x0089CD1F File Offset: 0x0089B11F
	public float GetCameraLookHeight()
	{
		return this.mData.CameraLookHeight;
	}

	// Token: 0x0601C5B0 RID: 116144 RVA: 0x0089CD2C File Offset: 0x0089B12C
	public float GetCameraNearClip()
	{
		return this.mData.CameraNearClip;
	}

	// Token: 0x0601C5B1 RID: 116145 RVA: 0x0089CD39 File Offset: 0x0089B139
	public float GetCameraSize()
	{
		return this.mData.CameraSize;
	}

	// Token: 0x0601C5B2 RID: 116146 RVA: 0x0089CD46 File Offset: 0x0089B146
	public Vector2 GetCameraXRange()
	{
		return new Vector2(this.mData.CameraXRange.X, this.mData.CameraXRange.Y);
	}

	// Token: 0x0601C5B3 RID: 116147 RVA: 0x0089CD6D File Offset: 0x0089B16D
	public Vector2 GetCameraZRange()
	{
		return new Vector2(this.mData.CameraZRange.X, this.mData.CameraZRange.Y);
	}

	// Token: 0x0601C5B4 RID: 116148 RVA: 0x0089CD94 File Offset: 0x0089B194
	public Vector3 GetCenterPostionNew()
	{
		return new Vector3(this.mData.CenterPostionNew.X, this.mData.CenterPostionNew.Y, this.mData.CenterPostionNew.Z);
	}

	// Token: 0x0601C5B5 RID: 116149 RVA: 0x0089CDCB File Offset: 0x0089B1CB
	public ISceneDecoratorInfoData GetDecoratorInfo(int i)
	{
		if (this.mDecoratorInfos == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this.mDecoratorInfos.Count <= i)
		{
			return null;
		}
		return this.mDecoratorInfos[i];
	}

	// Token: 0x0601C5B6 RID: 116150 RVA: 0x0089CE02 File Offset: 0x0089B202
	public int GetDecoratorInfoLenth()
	{
		if (this.mDecoratorInfos == null)
		{
			return 0;
		}
		return this.mDecoratorInfos.Count;
	}

	// Token: 0x0601C5B7 RID: 116151 RVA: 0x0089CE1C File Offset: 0x0089B21C
	public ISceneDestructibleInfoData GetDestructibleInfo(int i)
	{
		if (this.mDestructibleInfos == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this.mDestructibleInfos.Count <= i)
		{
			return null;
		}
		return this.mDestructibleInfos[i];
	}

	// Token: 0x0601C5B8 RID: 116152 RVA: 0x0089CE53 File Offset: 0x0089B253
	public int GetDestructibleInfoLength()
	{
		if (this.mDestructibleInfos == null)
		{
			return 0;
		}
		return this.mDestructibleInfos.Count;
	}

	// Token: 0x0601C5B9 RID: 116153 RVA: 0x0089CE6D File Offset: 0x0089B26D
	public ISceneEntityInfoData GetEntityInfo(int i)
	{
		if (this.mEntityInfos == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this.mEntityInfos.Count <= i)
		{
			return null;
		}
		return this.mEntityInfos[i];
	}

	// Token: 0x0601C5BA RID: 116154 RVA: 0x0089CEA4 File Offset: 0x0089B2A4
	public int GetEntityInfoLength()
	{
		if (this.mEntityInfos == null)
		{
			return 0;
		}
		return this.mEntityInfos.Count;
	}

	// Token: 0x0601C5BB RID: 116155 RVA: 0x0089CEBE File Offset: 0x0089B2BE
	public ISceneFunctionPrefabData GetFunctionPrefab(int i)
	{
		if (this.mFunctionPrefabDatas == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this.mFunctionPrefabDatas.Count <= i)
		{
			return null;
		}
		return this.mFunctionPrefabDatas[i];
	}

	// Token: 0x0601C5BC RID: 116156 RVA: 0x0089CEF5 File Offset: 0x0089B2F5
	public int GetFunctionPrefabLength()
	{
		if (this.mFunctionPrefabDatas == null)
		{
			return 0;
		}
		return this.mFunctionPrefabDatas.Count;
	}

	// Token: 0x0601C5BD RID: 116157 RVA: 0x0089CF0F File Offset: 0x0089B30F
	public Vector2 GetGridSize()
	{
		return new Vector2(this.mData.GridSize.X, this.mData.GridSize.Y);
	}

	// Token: 0x0601C5BE RID: 116158 RVA: 0x0089CF36 File Offset: 0x0089B336
	public ISceneEntityInfoData GetAirBattleBornPos(int i)
	{
		if (this.airBattleBornPos == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this.airBattleBornPos.Count <= i)
		{
			return null;
		}
		return this.airBattleBornPos[i];
	}

	// Token: 0x0601C5BF RID: 116159 RVA: 0x0089CF6D File Offset: 0x0089B36D
	public ISceneEntityInfoData GetHellbirthposition()
	{
		return this.mHellbirthposition;
	}

	// Token: 0x0601C5C0 RID: 116160 RVA: 0x0089CF75 File Offset: 0x0089B375
	public int GetId()
	{
		return this.mData.Id;
	}

	// Token: 0x0601C5C1 RID: 116161 RVA: 0x0089CF82 File Offset: 0x0089B382
	public DynSceneSetting GetLightmapsettings()
	{
		return this.mDynSceneSetting;
	}

	// Token: 0x0601C5C2 RID: 116162 RVA: 0x0089CF8A File Offset: 0x0089B38A
	public string GetLightmapsettingsPath()
	{
		return this.mData.LightmapsettingsPath;
	}

	// Token: 0x0601C5C3 RID: 116163 RVA: 0x0089CF97 File Offset: 0x0089B397
	public Vector3 GetLogicPos()
	{
		return new Vector3(this.mData.LogicPos.X, this.mData.LogicPos.Y, this.mData.LogicPos.Z);
	}

	// Token: 0x0601C5C4 RID: 116164 RVA: 0x0089CFCE File Offset: 0x0089B3CE
	public int GetLogicX()
	{
		return this.mData.LogicXmax - this.mData.LogicXmin;
	}

	// Token: 0x0601C5C5 RID: 116165 RVA: 0x0089CFE7 File Offset: 0x0089B3E7
	public int GetLogicXmax()
	{
		return this.mData.LogicXmax;
	}

	// Token: 0x0601C5C6 RID: 116166 RVA: 0x0089CFF4 File Offset: 0x0089B3F4
	public int GetLogicXmin()
	{
		return this.mData.LogicXmin;
	}

	// Token: 0x0601C5C7 RID: 116167 RVA: 0x0089D001 File Offset: 0x0089B401
	public Vector2 GetLogicXSize()
	{
		return new Vector2(this.mData.LogicXSize.X, this.mData.LogicXSize.Y);
	}

	// Token: 0x0601C5C8 RID: 116168 RVA: 0x0089D028 File Offset: 0x0089B428
	public int GetLogicZ()
	{
		return this.mData.LogicZmax - this.mData.LogicZmin;
	}

	// Token: 0x0601C5C9 RID: 116169 RVA: 0x0089D041 File Offset: 0x0089B441
	public int GetLogicZmax()
	{
		return this.mData.LogicZmax;
	}

	// Token: 0x0601C5CA RID: 116170 RVA: 0x0089D04E File Offset: 0x0089B44E
	public int GetLogicZmin()
	{
		return this.mData.LogicZmin;
	}

	// Token: 0x0601C5CB RID: 116171 RVA: 0x0089D05B File Offset: 0x0089B45B
	public Vector2 GetLogicZSize()
	{
		return new Vector2(this.mData.LogicZSize.X, this.mData.LogicZSize.Y);
	}

	// Token: 0x0601C5CC RID: 116172 RVA: 0x0089D082 File Offset: 0x0089B482
	public ISceneMonsterInfoData GetMonsterInfo(int i)
	{
		if (this.mMonsterInfos == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this.mMonsterInfos.Count <= i)
		{
			return null;
		}
		return this.mMonsterInfos[i];
	}

	// Token: 0x0601C5CD RID: 116173 RVA: 0x0089D0B9 File Offset: 0x0089B4B9
	public int GetMonsterInfoLength()
	{
		if (this.mMonsterInfos == null)
		{
			return 0;
		}
		return this.mMonsterInfos.Count;
	}

	// Token: 0x0601C5CE RID: 116174 RVA: 0x0089D0D3 File Offset: 0x0089B4D3
	public string GetName()
	{
		return this.mData.Name;
	}

	// Token: 0x0601C5CF RID: 116175 RVA: 0x0089D0E0 File Offset: 0x0089B4E0
	public ISceneNPCInfoData GetNpcInfo(int i)
	{
		if (this.mNPCInfos == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this.mNPCInfos.Count <= i)
		{
			return null;
		}
		return this.mNPCInfos[i];
	}

	// Token: 0x0601C5D0 RID: 116176 RVA: 0x0089D117 File Offset: 0x0089B517
	public int GetNpcInfoLength()
	{
		if (this.mNPCInfos == null)
		{
			return 0;
		}
		return this.mNPCInfos.Count;
	}

	// Token: 0x0601C5D1 RID: 116177 RVA: 0x0089D134 File Offset: 0x0089B534
	public Color GetObjectDyeColor()
	{
		return new Color(this.mData.ObjectDyeColor.R, this.mData.ObjectDyeColor.G, this.mData.ObjectDyeColor.B, this.mData.ObjectDyeColor.A);
	}

	// Token: 0x0601C5D2 RID: 116178 RVA: 0x0089D186 File Offset: 0x0089B586
	public string GetPrefabPath()
	{
		return this.mData.Prefabpath;
	}

	// Token: 0x0601C5D3 RID: 116179 RVA: 0x0089D193 File Offset: 0x0089B593
	public byte[] GetRawBlockLayer()
	{
		return this.mBlockLayer;
	}

	// Token: 0x0601C5D4 RID: 116180 RVA: 0x0089D19B File Offset: 0x0089B59B
	public ushort[] GetRawGrassLayer()
	{
		return null;
	}

	// Token: 0x0601C5D5 RID: 116181 RVA: 0x0089D19E File Offset: 0x0089B59E
	public ushort GetGrassId(int gridX, int gridY)
	{
		return 0;
	}

	// Token: 0x0601C5D6 RID: 116182 RVA: 0x0089D1A1 File Offset: 0x0089B5A1
	public ISceneRegionInfoData GetRegionInfo(int i)
	{
		if (this.mRegionInfos == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this.mRegionInfos.Count <= i)
		{
			return null;
		}
		return this.mRegionInfos[i];
	}

	// Token: 0x0601C5D7 RID: 116183 RVA: 0x0089D1D8 File Offset: 0x0089B5D8
	public int GetRegionInfoLength()
	{
		if (this.mRegionInfos == null)
		{
			return 0;
		}
		return this.mRegionInfos.Count;
	}

	// Token: 0x0601C5D8 RID: 116184 RVA: 0x0089D1F2 File Offset: 0x0089B5F2
	public Vector3 GetScenePostion()
	{
		return new Vector3(this.mData.ScenePostion.X, this.mData.ScenePostion.Y, this.mData.ScenePostion.Z);
	}

	// Token: 0x0601C5D9 RID: 116185 RVA: 0x0089D229 File Offset: 0x0089B629
	public float GetSceneUScale()
	{
		return this.mData.SceneUScale;
	}

	// Token: 0x0601C5DA RID: 116186 RVA: 0x0089D236 File Offset: 0x0089B636
	public int GetTipsID()
	{
		return this.mData.TipsID;
	}

	// Token: 0x0601C5DB RID: 116187 RVA: 0x0089D243 File Offset: 0x0089B643
	public ISceneTownDoorData GetTownDoor(int i)
	{
		if (this.mTownDoors == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this.mTownDoors.Count <= i)
		{
			return null;
		}
		return this.mTownDoors[i];
	}

	// Token: 0x0601C5DC RID: 116188 RVA: 0x0089D27A File Offset: 0x0089B67A
	public int GetTownDoorLength()
	{
		if (this.mTownDoors == null)
		{
			return 0;
		}
		return this.mTownDoors.Count;
	}

	// Token: 0x0601C5DD RID: 116189 RVA: 0x0089D294 File Offset: 0x0089B694
	public ISceneTransportDoorData GetTransportDoor(int i)
	{
		if (this.mTransportDoors == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this.mTransportDoors.Count <= i)
		{
			return null;
		}
		return this.mTransportDoors[i];
	}

	// Token: 0x0601C5DE RID: 116190 RVA: 0x0089D2CB File Offset: 0x0089B6CB
	public int GetTransportDoorLength()
	{
		if (this.mTransportDoors == null)
		{
			return 0;
		}
		return this.mTransportDoors.Count;
	}

	// Token: 0x0601C5DF RID: 116191 RVA: 0x0089D2E5 File Offset: 0x0089B6E5
	public global::EWeatherMode GetWeatherMode()
	{
		return (global::EWeatherMode)this.mData.WeatherMode;
	}

	// Token: 0x0601C5E0 RID: 116192 RVA: 0x0089D2F3 File Offset: 0x0089B6F3
	public bool IsCameraPersp()
	{
		return this.mData.CameraPersp;
	}

	// Token: 0x0601C5E1 RID: 116193 RVA: 0x0089D300 File Offset: 0x0089B700
	public void SetLightmapsettings(DynSceneSetting setting)
	{
		this.mDynSceneSetting = setting;
	}

	// Token: 0x040137FC RID: 79868
	private FBSceneData.DSceneData mData;

	// Token: 0x040137FD RID: 79869
	private ISceneEntityInfoData mBirthPosition;

	// Token: 0x040137FE RID: 79870
	private ISceneEntityInfoData mHellbirthposition;

	// Token: 0x040137FF RID: 79871
	private DynSceneSetting mDynSceneSetting;

	// Token: 0x04013800 RID: 79872
	private List<ISceneDecoratorInfoData> mDecoratorInfos = new List<ISceneDecoratorInfoData>();

	// Token: 0x04013801 RID: 79873
	private List<ISceneTransportDoorData> mTransportDoors = new List<ISceneTransportDoorData>();

	// Token: 0x04013802 RID: 79874
	private List<ISceneDestructibleInfoData> mDestructibleInfos = new List<ISceneDestructibleInfoData>();

	// Token: 0x04013803 RID: 79875
	private List<ISceneEntityInfoData> mEntityInfos = new List<ISceneEntityInfoData>();

	// Token: 0x04013804 RID: 79876
	private List<ISceneFunctionPrefabData> mFunctionPrefabDatas = new List<ISceneFunctionPrefabData>();

	// Token: 0x04013805 RID: 79877
	private List<ISceneMonsterInfoData> mMonsterInfos = new List<ISceneMonsterInfoData>();

	// Token: 0x04013806 RID: 79878
	private List<ISceneNPCInfoData> mNPCInfos = new List<ISceneNPCInfoData>();

	// Token: 0x04013807 RID: 79879
	private List<ISceneRegionInfoData> mRegionInfos = new List<ISceneRegionInfoData>();

	// Token: 0x04013808 RID: 79880
	private List<ISceneTownDoorData> mTownDoors = new List<ISceneTownDoorData>();

	// Token: 0x04013809 RID: 79881
	private List<ISceneEntityInfoData> airBattleBornPos = new List<ISceneEntityInfoData>();

	// Token: 0x0401380A RID: 79882
	private byte[] mBlockLayer = new byte[0];
}
