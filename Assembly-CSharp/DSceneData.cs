using System;
using UnityEngine;

// Token: 0x02004B73 RID: 19315
public class DSceneData : ScriptableObject, ISceneData
{
	// Token: 0x0601C669 RID: 116329 RVA: 0x0089E1F3 File Offset: 0x0089C5F3
	public void LoadDynSceneSetting()
	{
		this._lightmapsetting = (Singleton<AssetLoader>.instance.LoadRes(this._LightmapsettingsPath, typeof(DynSceneSetting), true, 0U).obj as DynSceneSetting);
	}

	// Token: 0x0601C66A RID: 116330 RVA: 0x0089E221 File Offset: 0x0089C621
	public string GetName()
	{
		return this._name;
	}

	// Token: 0x0601C66B RID: 116331 RVA: 0x0089E229 File Offset: 0x0089C629
	public int GetId()
	{
		return this._id;
	}

	// Token: 0x0601C66C RID: 116332 RVA: 0x0089E231 File Offset: 0x0089C631
	public string GetPrefabPath()
	{
		return this._prefabpath;
	}

	// Token: 0x0601C66D RID: 116333 RVA: 0x0089E239 File Offset: 0x0089C639
	public float GetCameraLookHeight()
	{
		return this._CameraLookHeight;
	}

	// Token: 0x0601C66E RID: 116334 RVA: 0x0089E241 File Offset: 0x0089C641
	public float GetCameraDistance()
	{
		return this._CameraDistance;
	}

	// Token: 0x0601C66F RID: 116335 RVA: 0x0089E249 File Offset: 0x0089C649
	public float GetCameraAngle()
	{
		return this._CameraAngle;
	}

	// Token: 0x0601C670 RID: 116336 RVA: 0x0089E251 File Offset: 0x0089C651
	public float GetCameraNearClip()
	{
		return this._CameraNearClip;
	}

	// Token: 0x0601C671 RID: 116337 RVA: 0x0089E259 File Offset: 0x0089C659
	public float GetCameraFarClip()
	{
		return this._CameraFarClip;
	}

	// Token: 0x0601C672 RID: 116338 RVA: 0x0089E261 File Offset: 0x0089C661
	public Vector2 GetCameraZRange()
	{
		return this._CameraZRange;
	}

	// Token: 0x0601C673 RID: 116339 RVA: 0x0089E269 File Offset: 0x0089C669
	public Vector2 GetCameraXRange()
	{
		return this._CameraXRange;
	}

	// Token: 0x0601C674 RID: 116340 RVA: 0x0089E271 File Offset: 0x0089C671
	public bool IsCameraPersp()
	{
		return this._CameraPersp;
	}

	// Token: 0x0601C675 RID: 116341 RVA: 0x0089E279 File Offset: 0x0089C679
	public Vector3 GetCenterPostionNew()
	{
		return this._CenterPostionNew;
	}

	// Token: 0x0601C676 RID: 116342 RVA: 0x0089E281 File Offset: 0x0089C681
	public Vector3 GetScenePostion()
	{
		return this._ScenePostion;
	}

	// Token: 0x0601C677 RID: 116343 RVA: 0x0089E289 File Offset: 0x0089C689
	public float GetSceneUScale()
	{
		return this._SceneUScale;
	}

	// Token: 0x0601C678 RID: 116344 RVA: 0x0089E291 File Offset: 0x0089C691
	public Vector2 GetGridSize()
	{
		return this._GridSize;
	}

	// Token: 0x0601C679 RID: 116345 RVA: 0x0089E299 File Offset: 0x0089C699
	public Vector2 GetLogicXSize()
	{
		return this._LogicXSize;
	}

	// Token: 0x0601C67A RID: 116346 RVA: 0x0089E2A1 File Offset: 0x0089C6A1
	public Vector2 GetLogicZSize()
	{
		return this._LogicZSize;
	}

	// Token: 0x0601C67B RID: 116347 RVA: 0x0089E2A9 File Offset: 0x0089C6A9
	public Color GetObjectDyeColor()
	{
		return this._ObjectDyeColor;
	}

	// Token: 0x0601C67C RID: 116348 RVA: 0x0089E2B1 File Offset: 0x0089C6B1
	public Vector3 GetLogicPos()
	{
		return this._LogicPos;
	}

	// Token: 0x0601C67D RID: 116349 RVA: 0x0089E2B9 File Offset: 0x0089C6B9
	public EWeatherMode GetWeatherMode()
	{
		return this._WeatherMode;
	}

	// Token: 0x0601C67E RID: 116350 RVA: 0x0089E2C1 File Offset: 0x0089C6C1
	public int GetTipsID()
	{
		return this._TipsID;
	}

	// Token: 0x0601C67F RID: 116351 RVA: 0x0089E2C9 File Offset: 0x0089C6C9
	public string GetLightmapsettingsPath()
	{
		return this._LightmapsettingsPath;
	}

	// Token: 0x0601C680 RID: 116352 RVA: 0x0089E2D1 File Offset: 0x0089C6D1
	public int GetLogicXmin()
	{
		return this._LogicXmin;
	}

	// Token: 0x0601C681 RID: 116353 RVA: 0x0089E2D9 File Offset: 0x0089C6D9
	public int GetLogicXmax()
	{
		return this._LogicXmax;
	}

	// Token: 0x0601C682 RID: 116354 RVA: 0x0089E2E1 File Offset: 0x0089C6E1
	public int GetLogicZmin()
	{
		return this._LogicZmin;
	}

	// Token: 0x0601C683 RID: 116355 RVA: 0x0089E2E9 File Offset: 0x0089C6E9
	public int GetLogicZmax()
	{
		return this._LogicZmax;
	}

	// Token: 0x0601C684 RID: 116356 RVA: 0x0089E2F1 File Offset: 0x0089C6F1
	public int GetLogicX()
	{
		return this.LogicX;
	}

	// Token: 0x0601C685 RID: 116357 RVA: 0x0089E2F9 File Offset: 0x0089C6F9
	public int GetLogicZ()
	{
		return this.LogicZ;
	}

	// Token: 0x0601C686 RID: 116358 RVA: 0x0089E301 File Offset: 0x0089C701
	public int GetEntityInfoLength()
	{
		if (this._entityinfo == null)
		{
			return 0;
		}
		return this._entityinfo.Length;
	}

	// Token: 0x0601C687 RID: 116359 RVA: 0x0089E318 File Offset: 0x0089C718
	public ISceneEntityInfoData GetEntityInfo(int i)
	{
		if (this._entityinfo == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this._entityinfo.Length <= i)
		{
			return null;
		}
		return this._entityinfo[i];
	}

	// Token: 0x0601C688 RID: 116360 RVA: 0x0089E348 File Offset: 0x0089C748
	public int GetBlockLayerLength()
	{
		if (this._blocklayer == null)
		{
			return 0;
		}
		return this._blocklayer.Length;
	}

	// Token: 0x0601C689 RID: 116361 RVA: 0x0089E35F File Offset: 0x0089C75F
	public byte[] GetBlockLayer()
	{
		return this._blocklayer;
	}

	// Token: 0x0601C68A RID: 116362 RVA: 0x0089E367 File Offset: 0x0089C767
	public int GetNpcInfoLength()
	{
		if (this._npcinfo == null)
		{
			return 0;
		}
		return this._npcinfo.Length;
	}

	// Token: 0x0601C68B RID: 116363 RVA: 0x0089E37E File Offset: 0x0089C77E
	public ISceneNPCInfoData GetNpcInfo(int i)
	{
		if (this._npcinfo == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this._npcinfo.Length <= i)
		{
			return null;
		}
		return this._npcinfo[i];
	}

	// Token: 0x0601C68C RID: 116364 RVA: 0x0089E3AE File Offset: 0x0089C7AE
	public int GetMonsterInfoLength()
	{
		if (this._monsterinfo == null)
		{
			return 0;
		}
		return this._monsterinfo.Length;
	}

	// Token: 0x0601C68D RID: 116365 RVA: 0x0089E3C5 File Offset: 0x0089C7C5
	private DMonsterInfo _getMonsterInfo(int i)
	{
		if (this._monsterinfo == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this._monsterinfo.Length <= i)
		{
			return null;
		}
		return this._monsterinfo[i];
	}

	// Token: 0x0601C68E RID: 116366 RVA: 0x0089E3F5 File Offset: 0x0089C7F5
	public ISceneMonsterInfoData GetMonsterInfo(int i)
	{
		return this._getMonsterInfo(i);
	}

	// Token: 0x0601C68F RID: 116367 RVA: 0x0089E3FE File Offset: 0x0089C7FE
	public ISceneEntityInfoData GetMonsterEntityInfo(int i)
	{
		return this._getMonsterInfo(i);
	}

	// Token: 0x0601C690 RID: 116368 RVA: 0x0089E407 File Offset: 0x0089C807
	public int GetDecoratorInfoLenth()
	{
		if (this._decoratorinfo == null)
		{
			return 0;
		}
		return this._decoratorinfo.Length;
	}

	// Token: 0x0601C691 RID: 116369 RVA: 0x0089E41E File Offset: 0x0089C81E
	public ISceneDecoratorInfoData GetDecoratorInfo(int i)
	{
		if (this._decoratorinfo == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this._decoratorinfo.Length <= i)
		{
			return null;
		}
		return this._decoratorinfo[i];
	}

	// Token: 0x0601C692 RID: 116370 RVA: 0x0089E44E File Offset: 0x0089C84E
	public int GetDestructibleInfoLength()
	{
		if (this._desructibleinfo == null)
		{
			return 0;
		}
		return this._desructibleinfo.Length;
	}

	// Token: 0x0601C693 RID: 116371 RVA: 0x0089E465 File Offset: 0x0089C865
	public ISceneDestructibleInfoData GetDestructibleInfo(int i)
	{
		if (this._desructibleinfo == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this._desructibleinfo.Length <= i)
		{
			return null;
		}
		return this._desructibleinfo[i];
	}

	// Token: 0x0601C694 RID: 116372 RVA: 0x0089E495 File Offset: 0x0089C895
	public int GetRegionInfoLength()
	{
		if (this._regioninfo == null)
		{
			return 0;
		}
		return this._regioninfo.Length;
	}

	// Token: 0x0601C695 RID: 116373 RVA: 0x0089E4AC File Offset: 0x0089C8AC
	public ISceneRegionInfoData GetRegionInfo(int i)
	{
		if (this._regioninfo == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this._regioninfo.Length <= i)
		{
			return null;
		}
		return this._regioninfo[i];
	}

	// Token: 0x0601C696 RID: 116374 RVA: 0x0089E4DC File Offset: 0x0089C8DC
	public int GetTransportDoorLength()
	{
		if (this._transportdoor == null)
		{
			return 0;
		}
		return this._transportdoor.Length;
	}

	// Token: 0x0601C697 RID: 116375 RVA: 0x0089E4F3 File Offset: 0x0089C8F3
	private DTransportDoor _getTransportDoor(int i)
	{
		if (this._transportdoor == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this._transportdoor.Length <= i)
		{
			return null;
		}
		return this._transportdoor[i];
	}

	// Token: 0x0601C698 RID: 116376 RVA: 0x0089E523 File Offset: 0x0089C923
	public ISceneTransportDoorData GetTransportDoor(int i)
	{
		return this._getTransportDoor(i);
	}

	// Token: 0x0601C699 RID: 116377 RVA: 0x0089E52C File Offset: 0x0089C92C
	public ISceneRegionInfoData GetTransportDoorRegionInfo(int i)
	{
		return this._getTransportDoor(i);
	}

	// Token: 0x0601C69A RID: 116378 RVA: 0x0089E535 File Offset: 0x0089C935
	public ISceneEntityInfoData GetTransportDoorEntityInfo(int i)
	{
		return this._getTransportDoor(i);
	}

	// Token: 0x0601C69B RID: 116379 RVA: 0x0089E53E File Offset: 0x0089C93E
	public ISceneEntityInfoData GetBirthPosition()
	{
		return this._birthposition;
	}

	// Token: 0x0601C69C RID: 116380 RVA: 0x0089E546 File Offset: 0x0089C946
	public ISceneEntityInfoData GetAirBattleBornPos(int i)
	{
		if (this._fighterBornPosition == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this._fighterBornPosition.Length <= i)
		{
			return null;
		}
		return this._fighterBornPosition[i];
	}

	// Token: 0x0601C69D RID: 116381 RVA: 0x0089E576 File Offset: 0x0089C976
	public ISceneEntityInfoData GetHellbirthposition()
	{
		return this._hellbirthposition;
	}

	// Token: 0x0601C69E RID: 116382 RVA: 0x0089E57E File Offset: 0x0089C97E
	public int GetTownDoorLength()
	{
		if (this._townDoor == null)
		{
			return 0;
		}
		return this._townDoor.Length;
	}

	// Token: 0x0601C69F RID: 116383 RVA: 0x0089E595 File Offset: 0x0089C995
	public ISceneTownDoorData GetTownDoor(int i)
	{
		if (this._townDoor == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this._townDoor.Length <= i)
		{
			return null;
		}
		return this._townDoor[i];
	}

	// Token: 0x0601C6A0 RID: 116384 RVA: 0x0089E5C5 File Offset: 0x0089C9C5
	public int GetFunctionPrefabLength()
	{
		if (this._FunctionPrefab == null)
		{
			return 0;
		}
		return this._FunctionPrefab.Length;
	}

	// Token: 0x0601C6A1 RID: 116385 RVA: 0x0089E5DC File Offset: 0x0089C9DC
	public ISceneFunctionPrefabData GetFunctionPrefab(int i)
	{
		if (this._FunctionPrefab == null)
		{
			return null;
		}
		if (0 > i)
		{
			return null;
		}
		if (this._FunctionPrefab.Length <= i)
		{
			return null;
		}
		return this._FunctionPrefab[i];
	}

	// Token: 0x0601C6A2 RID: 116386 RVA: 0x0089E60C File Offset: 0x0089CA0C
	public float GetCameraSize()
	{
		return this._CameraSize;
	}

	// Token: 0x0601C6A3 RID: 116387 RVA: 0x0089E614 File Offset: 0x0089CA14
	public DynSceneSetting GetLightmapsettings()
	{
		return this._lightmapsetting;
	}

	// Token: 0x0601C6A4 RID: 116388 RVA: 0x0089E61C File Offset: 0x0089CA1C
	public void SetLightmapsettings(DynSceneSetting setting)
	{
		this._lightmapsetting = setting;
	}

	// Token: 0x0601C6A5 RID: 116389 RVA: 0x0089E625 File Offset: 0x0089CA25
	public byte[] GetRawBlockLayer()
	{
		return this._blocklayer;
	}

	// Token: 0x0601C6A6 RID: 116390 RVA: 0x0089E62D File Offset: 0x0089CA2D
	public ushort[] GetRawGrassLayer()
	{
		return this._grasslayer;
	}

	// Token: 0x0601C6A7 RID: 116391 RVA: 0x0089E638 File Offset: 0x0089CA38
	public ushort GetGrassId(int gridX, int gridY)
	{
		if (this._grasslayer == null || this._grasslayer.Length <= 0)
		{
			return 0;
		}
		int num = gridY * this.LogicX + gridX;
		if (num < 0 || num >= this._grasslayer.Length)
		{
			return 0;
		}
		return this._grasslayer[gridY * this.LogicX + gridX];
	}

	// Token: 0x0601C6A8 RID: 116392 RVA: 0x0089E693 File Offset: 0x0089CA93
	public byte GetBlockLayer(int i)
	{
		if (this._blocklayer == null)
		{
			return 0;
		}
		if (0 > i)
		{
			return 0;
		}
		if (this._blocklayer.Length <= i)
		{
			return 0;
		}
		return this._blocklayer[i];
	}

	// Token: 0x170027DD RID: 10205
	// (get) Token: 0x0601C6A9 RID: 116393 RVA: 0x0089E6C3 File Offset: 0x0089CAC3
	public int LogicX
	{
		get
		{
			return this._LogicXmax - this._LogicXmin;
		}
	}

	// Token: 0x170027DE RID: 10206
	// (get) Token: 0x0601C6AA RID: 116394 RVA: 0x0089E6D2 File Offset: 0x0089CAD2
	public int LogicZ
	{
		get
		{
			return this._LogicZmax - this._LogicZmin;
		}
	}

	// Token: 0x0401388C RID: 80012
	public string _name;

	// Token: 0x0401388D RID: 80013
	public int _id;

	// Token: 0x0401388E RID: 80014
	public GameObject _prefab;

	// Token: 0x0401388F RID: 80015
	public string _prefabpath;

	// Token: 0x04013890 RID: 80016
	public float _CameraLookHeight = 1f;

	// Token: 0x04013891 RID: 80017
	public float _CameraDistance = 10f;

	// Token: 0x04013892 RID: 80018
	public float _CameraAngle = 20f;

	// Token: 0x04013893 RID: 80019
	public float _CameraNearClip = 0.3f;

	// Token: 0x04013894 RID: 80020
	public float _CameraFarClip = 50f;

	// Token: 0x04013895 RID: 80021
	public float _CameraSize = 3.3f;

	// Token: 0x04013896 RID: 80022
	public Vector2 _CameraZRange;

	// Token: 0x04013897 RID: 80023
	public Vector2 _CameraXRange;

	// Token: 0x04013898 RID: 80024
	public bool _CameraPersp;

	// Token: 0x04013899 RID: 80025
	public Vector3 _CenterPostionNew;

	// Token: 0x0401389A RID: 80026
	public Vector3 _ScenePostion;

	// Token: 0x0401389B RID: 80027
	public float _SceneUScale = 1f;

	// Token: 0x0401389C RID: 80028
	public Vector2 _GridSize = new Vector2(0.25f, 0.25f);

	// Token: 0x0401389D RID: 80029
	public Vector2 _LogicXSize;

	// Token: 0x0401389E RID: 80030
	public Vector2 _LogicZSize;

	// Token: 0x0401389F RID: 80031
	public Color _ObjectDyeColor = Color.white;

	// Token: 0x040138A0 RID: 80032
	public Vector3 _LogicPos = Vector3.zero;

	// Token: 0x040138A1 RID: 80033
	public EWeatherMode _WeatherMode;

	// Token: 0x040138A2 RID: 80034
	public int _TipsID;

	// Token: 0x040138A3 RID: 80035
	[NonSerialized]
	public DynSceneSetting _lightmapsetting;

	// Token: 0x040138A4 RID: 80036
	public string _LightmapsettingsPath;

	// Token: 0x040138A5 RID: 80037
	public int _LogicXmin;

	// Token: 0x040138A6 RID: 80038
	public int _LogicXmax;

	// Token: 0x040138A7 RID: 80039
	public int _LogicZmin;

	// Token: 0x040138A8 RID: 80040
	public int _LogicZmax;

	// Token: 0x040138A9 RID: 80041
	public DEntityInfo[] _entityinfo = new DEntityInfo[0];

	// Token: 0x040138AA RID: 80042
	public byte[] _blocklayer = new byte[0];

	// Token: 0x040138AB RID: 80043
	public DNPCInfo[] _npcinfo = new DNPCInfo[0];

	// Token: 0x040138AC RID: 80044
	public DMonsterInfo[] _monsterinfo = new DMonsterInfo[0];

	// Token: 0x040138AD RID: 80045
	public DDecoratorInfo[] _decoratorinfo = new DDecoratorInfo[0];

	// Token: 0x040138AE RID: 80046
	public DDestructibleInfo[] _desructibleinfo = new DDestructibleInfo[0];

	// Token: 0x040138AF RID: 80047
	public DRegionInfo[] _regioninfo = new DRegionInfo[0];

	// Token: 0x040138B0 RID: 80048
	public DTransportDoor[] _transportdoor = new DTransportDoor[0];

	// Token: 0x040138B1 RID: 80049
	public DEntityInfo _birthposition;

	// Token: 0x040138B2 RID: 80050
	public DEntityInfo _hellbirthposition;

	// Token: 0x040138B3 RID: 80051
	public DTownDoor[] _townDoor = new DTownDoor[0];

	// Token: 0x040138B4 RID: 80052
	public FunctionPrefab[] _FunctionPrefab = new FunctionPrefab[0];

	// Token: 0x040138B5 RID: 80053
	public DResourceInfo[] _resourcePosition = new DResourceInfo[0];

	// Token: 0x040138B6 RID: 80054
	public DTransferInfo[] _fighterBornPosition = new DTransferInfo[0];

	// Token: 0x040138B7 RID: 80055
	public ushort[] _grasslayer = new ushort[0];
}
