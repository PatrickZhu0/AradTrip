using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Battle;
using GameClient;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

// Token: 0x020041DA RID: 16858
public class DungeonDataManager : IDungeonPreloadAssets
{
	// Token: 0x0601743B RID: 95291 RVA: 0x007275C4 File Offset: 0x007259C4
	public DungeonDataManager(BattleType type, eDungeonMode mode, int dungeonID)
	{
		this.mID = new DungeonID(dungeonID);
		this.mBattleType = type;
		this.mDungeonMode = mode;
		this.mTable = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(this.mID.dungeonID, string.Empty, string.Empty);
		if (this.mTable == null)
		{
			Logger.LogErrorFormat("Dungeon Table is nil with {0}", new object[]
			{
				this.mID.dungeonID
			});
			return;
		}
		if (this.mTable != null && this.mTable.SubType == DungeonTable.eSubType.S_RAID_DUNGEON)
		{
			int num = this.mID.dungeonID / 1000;
			int num2 = num % 10;
			if (num2 == 1)
			{
				this.IsHardRaid = true;
			}
		}
		else
		{
			this.IsHardRaid = false;
		}
		this.mConfigTable = Singleton<TableManager>.instance.GetTableItem<DungeonUIConfigTable>(this.mID.dungeonID, string.Empty, string.Empty);
		if (this.mTable.SubType == DungeonTable.eSubType.S_TREASUREMAP)
		{
			return;
		}
		this.mAsset = DungeonUtility.LoadDungeonData(this.mTable.DungeonConfig);
		this._initInternalData();
	}

	// Token: 0x0601743C RID: 95292 RVA: 0x007277D4 File Offset: 0x00725BD4
	public string PreloadPath()
	{
		return this.mTable.DungeonConfig;
	}

	// Token: 0x0601743D RID: 95293 RVA: 0x007277E4 File Offset: 0x00725BE4
	public void Preload(string path)
	{
		IDungeonData dungeonData = this.mAsset;
		if (this.battleType == BattleType.TreasureMap)
		{
			return;
		}
		for (int i = 0; i < dungeonData.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList = dungeonData.GetAreaConnectList(i);
			if (areaConnectList != null)
			{
				ISceneData sceneData = areaConnectList.GetSceneData();
				if (sceneData == null)
				{
					areaConnectList.SetSceneData(DungeonUtility.LoadSceneData(areaConnectList.GetSceneAreaPath()));
					sceneData = areaConnectList.GetSceneData();
				}
				if (sceneData != null)
				{
					for (int j = 0; j < sceneData.GetDecoratorInfoLenth(); j++)
					{
						string modelPathByResID = sceneData.GetDecoratorInfo(j).GetEntityInfo().GetModelPathByResID();
						MonoSingleton<CResPreloader>.instance.AddRes(modelPathByResID, false, 1, null, 0, null, CResPreloader.ResType.OBJECT, null);
					}
					for (int k = 0; k < sceneData.GetDestructibleInfoLength(); k++)
					{
						string modelPathByResID2 = sceneData.GetDestructibleInfo(k).GetEntityInfo().GetModelPathByResID();
						MonoSingleton<CResPreloader>.instance.AddRes(modelPathByResID2, false, 1, null, 0, null, CResPreloader.ResType.OBJECT, null);
					}
					for (int l = 0; l < sceneData.GetTransportDoorLength(); l++)
					{
						string modelPathByResID3 = sceneData.GetTransportDoor(l).GetRegionInfo().GetEntityInfo().GetModelPathByResID();
						MonoSingleton<CResPreloader>.instance.AddRes(modelPathByResID3, false, 1, null, 0, null, CResPreloader.ResType.OBJECT, null);
					}
					for (int m = 0; m < sceneData.GetRegionInfoLength(); m++)
					{
						string modelPathByResID4 = sceneData.GetRegionInfo(m).GetEntityInfo().GetModelPathByResID();
						MonoSingleton<CResPreloader>.instance.AddRes(modelPathByResID4, false, 1, null, 0, null, CResPreloader.ResType.OBJECT, null);
					}
				}
			}
		}
		DungeonDataManager.PreloadData[] array = new DungeonDataManager.PreloadData[]
		{
			new DungeonDataManager.PreloadData("Actor/Other_ShadowPlane/p_ShadowPlane", 1),
			new DungeonDataManager.PreloadData(Global.Settings.defaultHitEffect, 1),
			new DungeonDataManager.PreloadData(Global.Settings.defaultProjectileHitEffect, 1),
			new DungeonDataManager.PreloadData(Global.Settings.critialDeadEffect, 1),
			new DungeonDataManager.PreloadData(Global.Settings.immediateDeadEffect, 1),
			new DungeonDataManager.PreloadData(Global.Settings.normalDeadEffect, 1),
			new DungeonDataManager.PreloadData("Effects/Scene_effects/BOSS/Prefab/Eff_BOSS_GH", 1),
			new DungeonDataManager.PreloadData("Effects/Scene_effects/EffectUI/EffUI_KillMark", 1),
			new DungeonDataManager.PreloadData("Effects/Scene_effects/EffectUI/EffUI_suduxian", 1),
			new DungeonDataManager.PreloadData("Effects/Hero_Zhaohuanshi/Bingnaisi/Prefab/Eff_Zhaohuanbingnaisi_zhaohuan_02", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/Jiaodi/Prefab/Eff_common_jiaodi", 1),
			new DungeonDataManager.PreloadData("Effects/Hero_Manyou/Siwangzuolun/Prefab/Eff_Siwangzuolun_fire", 1),
			new DungeonDataManager.PreloadData("Effects/Hero_Zhaohuanshi/Kaxiliyasi/Prefab/Eff_kaxiliyasi_xiaoshi", 1),
			new DungeonDataManager.PreloadData("Effects/Hero_Mage/Huzhao/Prefab/Eff_Huzhao_beiji", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/Huifu/Prefab/Eff_Common_HP", 1),
			new DungeonDataManager.PreloadData("Effects/Hero_Qiangpao/Liangzi/Prefab/Eff_Liangzi_kuang_jiguang_guo", 1),
			new DungeonDataManager.PreloadData("Effects/Scene_effects/EffectUI/Eff_Jinengfanwei_guo", 1),
			new DungeonDataManager.PreloadData("Effects/Hero_Mage/Caoren/Prefab/Eff_Jiekebaodan_yan", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/Hit/Prefab/Eff_hit_guo", 10),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/Hit/Prefab/Eff_hit_jin_newguo", 10),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/Hit/Prefab/Eff_hit_gun_newguo", 10),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/Siwang/Eff_die_baoji", 10),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/Siwang/Eff_die_yiji", 10),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/Hit/Prefab/Eff_hit_guang", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/Hit/Prefab/Eff_hit_huo", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/Hit/Prefab/Eff_hit_bing", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/Hit/Prefab/Eff_hit_an", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonBarRoot", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonCharactorHeadSn", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonCharactorHeadPn", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonCharactorBar", 1),
			new DungeonDataManager.PreloadData("Effects/Hero_Jixieshi/EZ-8Zibaozhe/Perfab/Eff_Ez-8Zibaozhe_guang", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/Hit/Prefab/Eff_hit_miss_newguo", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/Yaogan/Prefab/Eff_common_yaogan", 1),
			new DungeonDataManager.PreloadData("Effects/Scene_effects/EffectUI/EffUI_Hexue_guo", 1),
			new DungeonDataManager.PreloadData("Effects/Scene_effects/EffectUI/EffUI_dianjifankui01", 1),
			new DungeonDataManager.PreloadData("Effects/Scene_effects/EffectUI/EffUI_cd_end", 1),
			new DungeonDataManager.PreloadData("Effects/Scene_effects/EffectUI/EffUI_Autoskill_hong_guo", 1),
			new DungeonDataManager.PreloadData("Effects/Scene_effects/EffectUI/EffUI_Autoskill_chixu_guo", 1),
			new DungeonDataManager.PreloadData("Effects/Scene_effects/EffectUI/EffUI_Autoskill_chixu", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/BattleUI/DungeonButtonStateCharge", 1),
			new DungeonDataManager.PreloadData("Effects/Scene_effects/EffectUI/EffUI_Autoskill_lan_guo", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/Battle_Digit/PlayerInfo_SpecialAttack", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/Battle_Digit/PlayerInfo_BuffName", 1),
			new DungeonDataManager.PreloadData("Effects/Hero_Zhaohuanshi/Aosuo/Prefab/Eff_Zhaohuanaosuo_dimian_guo", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/Jiaodi/Prefab/Eff_toudingjiantou_guo", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/ETCInput/HGJoystick", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/CommonSystemNotify/TipGWQCAnimation", 1)
		};
		DungeonDataManager.PreloadData[] array2 = new DungeonDataManager.PreloadData[]
		{
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/Battle_Digit/PlayerInfo_GetExp", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/Battle_Digit/PlayerInfo_GetGold", 1),
			new DungeonDataManager.PreloadData("Effects/Scene_effects/EffectUI/EffUI_Autofight", 1),
			new DungeonDataManager.PreloadData("Effects/Scene_effects/EffectUI/EffUI_huoqu_guo", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/DialogParent/DialogParent_battle", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/DialogParent/DialogParent_battle_skill", 1),
			new DungeonDataManager.PreloadData("Effects/Scene_effects/EffectUI/EffUI_guaiwusiwang", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/BattleUI/DungeonBar/HPBar_White", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/Levelup/Prefab/Eff_Common_levelup", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/level_up/Prefab/Eff_fuhuo_guo", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/BattleUI/DungeonBoxText", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/DiaoLuo/Eff_jinbi_tuowei", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/DiaoLuo/Eff_jinbi_shiqu_guo", 1),
			new DungeonDataManager.PreloadData("Effects/Scene_effects/Eff_jipinzhuangbei_dimian_guo", 1),
			new DungeonDataManager.PreloadData("Effects/Scene_effects/Eff_jipinzhuangbei_dimian_guo02", 1),
			new DungeonDataManager.PreloadData("Effects/Scene_effects/Eff_fensezhuangbei_guo", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/DiaoLuo/Eff_jinbi_yuandi", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/DiaoLuo/Eff_putong_yuandi", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/DiaoLuo/Eff_jinse_yuandi", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/DiaoLuo/Eff_fense_yuandi", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/DiaoLuo/Eff_putong_tuowei", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/DiaoLuo/Eff_jinse_tuowei", 1),
			new DungeonDataManager.PreloadData("Effects/Common/Sfx/DiaoLuo/Eff_fense_tuowei", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/Battle/Finish/DungeonNormalFinish", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/BattleUI/DungeonMenu", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/Battle/Reward/DungeonReward", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/Battle/Reborn/DungeonReborn", 1),
			new DungeonDataManager.PreloadData("UIFlatten/Prefabs/Battle/Pause/DungeonPause", 1)
		};
		for (int n = 0; n < array.Length; n++)
		{
			MonoSingleton<CResPreloader>.instance.AddRes(array[n].resPath, false, array[n].num, null, 0, null, CResPreloader.ResType.OBJECT, null);
		}
		if (!BattleMain.IsModePvP(this.mBattleType) && this.mBattleType != BattleType.NewbieGuide && this.mBattleType != BattleType.TrainingSkillCombo)
		{
			for (int num = 0; num < array2.Length; num++)
			{
				MonoSingleton<CResPreloader>.instance.AddRes(array2[num].resPath, false, array2[num].num, null, 0, null, CResPreloader.ResType.OBJECT, null);
			}
		}
		Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<SoundTable>();
		foreach (KeyValuePair<int, object> keyValuePair in table)
		{
			SoundTable soundTable = keyValuePair.Value as SoundTable;
			if (soundTable.Type == 1)
			{
				MonoSingleton<AudioManager>.instance.PreloadSound(soundTable.ID);
			}
		}
		MonoSingleton<CResPreloader>.instance.AddRes("UI/Font/new_font/pic_break_action", false, 1, null, 0, null, CResPreloader.ResType.RES, typeof(Sprite));
		MonoSingleton<CResPreloader>.instance.AddRes("UI/Font/new_font/pic_back_hit", false, 1, null, 0, null, CResPreloader.ResType.RES, typeof(Sprite));
	}

	// Token: 0x17001FAC RID: 8108
	// (get) Token: 0x0601743E RID: 95294 RVA: 0x007281F9 File Offset: 0x007265F9
	private int lastIndex
	{
		get
		{
			return this.mLastIndex;
		}
	}

	// Token: 0x17001FAD RID: 8109
	// (get) Token: 0x0601743F RID: 95295 RVA: 0x00728201 File Offset: 0x00726601
	// (set) Token: 0x06017440 RID: 95296 RVA: 0x00728209 File Offset: 0x00726609
	private int currentIndex
	{
		get
		{
			return this.mCurrentIndex;
		}
		set
		{
			this.mLastIndex = this.mCurrentIndex;
			this.mCurrentIndex = value;
		}
	}

	// Token: 0x17001FAE RID: 8110
	// (get) Token: 0x06017441 RID: 95297 RVA: 0x0072821E File Offset: 0x0072661E
	public DungeonID id
	{
		get
		{
			return this.mID;
		}
	}

	// Token: 0x17001FAF RID: 8111
	// (get) Token: 0x06017442 RID: 95298 RVA: 0x00728226 File Offset: 0x00726626
	public DungeonTable table
	{
		get
		{
			return this.mTable;
		}
	}

	// Token: 0x17001FB0 RID: 8112
	// (get) Token: 0x06017443 RID: 95299 RVA: 0x0072822E File Offset: 0x0072662E
	public DungeonUIConfigTable configTable
	{
		get
		{
			return this.mConfigTable;
		}
	}

	// Token: 0x17001FB1 RID: 8113
	// (get) Token: 0x06017444 RID: 95300 RVA: 0x00728236 File Offset: 0x00726636
	public IDungeonData asset
	{
		get
		{
			return this.mAsset;
		}
	}

	// Token: 0x17001FB2 RID: 8114
	// (get) Token: 0x06017445 RID: 95301 RVA: 0x0072823E File Offset: 0x0072663E
	public BattleInfo battleInfo
	{
		get
		{
			return this.mBattleInfo;
		}
	}

	// Token: 0x17001FB3 RID: 8115
	// (get) Token: 0x06017446 RID: 95302 RVA: 0x00728246 File Offset: 0x00726646
	public eDungeonMode dungeonMode
	{
		get
		{
			return this.mDungeonMode;
		}
	}

	// Token: 0x17001FB4 RID: 8116
	// (get) Token: 0x06017447 RID: 95303 RVA: 0x0072824E File Offset: 0x0072664E
	public BattleType battleType
	{
		get
		{
			return this.mBattleType;
		}
	}

	// Token: 0x17001FB5 RID: 8117
	// (get) Token: 0x06017448 RID: 95304 RVA: 0x00728256 File Offset: 0x00726656
	// (set) Token: 0x06017449 RID: 95305 RVA: 0x0072825E File Offset: 0x0072665E
	public bool IsHardRaid { get; private set; }

	// Token: 0x0601744A RID: 95306 RVA: 0x00728268 File Offset: 0x00726668
	private void _initInternalData()
	{
		if (this.mAsset == null)
		{
			Logger.LogErrorFormat("Dungeon Asset is nil with {0}", new object[]
			{
				this.mTable.DungeonConfig
			});
			return;
		}
		this.mAsset.SetName(this.mTable.Name);
		for (int i = 0; i < this.mAsset.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList = this.mAsset.GetAreaConnectList(i);
			areaConnectList.SetSceneData(DungeonUtility.LoadSceneData(areaConnectList.GetSceneAreaPath()));
		}
		this._prepareDebugData(this.mDungeonMode);
		this.mBattleInfo = DataManager<BattleDataManager>.GetInstance().BattleInfo;
		this._initData();
		this._initPath2BossRoom();
		this._initRandData(this.mDungeonMode);
		this._bindNetMessage();
	}

	// Token: 0x0601744B RID: 95307 RVA: 0x00728329 File Offset: 0x00726729
	public void OnInitDungeonData(FrameRandomImp rand)
	{
		if (this.mTable != null && this.mTable.SubType == DungeonTable.eSubType.S_TREASUREMAP)
		{
			TreasureMapGenerator.BuildTreasureDungeonData(rand, out this.mAsset);
			this._initInternalData();
			this._initTreasureMapBattleInfo();
			return;
		}
	}

	// Token: 0x0601744C RID: 95308 RVA: 0x00728364 File Offset: 0x00726764
	private void _initTreasureMapBattleInfo()
	{
		this.mBattleInfo.areas.Clear();
		RacePlayerInfo[] playerInfo = DataManager<BattleDataManager>.GetInstance().PlayerInfo;
		if (playerInfo.Length <= 0)
		{
			return;
		}
		int level = (int)playerInfo[0].level;
		for (int i = 0; i < this.mAsset.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList = this.mAsset.GetAreaConnectList(i);
			DungeonArea dungeonArea = new DungeonArea();
			dungeonArea.id = this._getDataNodeAreaID(areaConnectList);
			if (areaConnectList.IsStart())
			{
				DataManager<BattleDataManager>.GetInstance().BattleInfo.startAreaId = dungeonArea.id;
			}
			ISceneData sceneData = areaConnectList.GetSceneData();
			if (sceneData != null)
			{
				MonsterIDData monsterIDData = new MonsterIDData(0);
				for (int j = 0; j < sceneData.GetMonsterInfoLength(); j++)
				{
					monsterIDData.SetID(sceneData.GetMonsterInfo(j).GetEntityInfo().GetResid());
					dungeonArea.monsters.Add(new DungeonMonster
					{
						id = j,
						pointId = j,
						typeId = monsterIDData.GenFullMonsterID(level)
					});
				}
				for (int k = 0; k < sceneData.GetDestructibleInfoLength(); k++)
				{
					if (sceneData.GetDestructibleInfo(k).GetFlushGroupID() > 0)
					{
						dungeonArea.destructs.Add(new DungeonMonster
						{
							id = k + sceneData.GetMonsterInfoLength(),
							pointId = k + sceneData.GetMonsterInfoLength(),
							typeId = sceneData.GetMonsterInfo(k).GetEntityInfo().GetResid()
						});
					}
				}
				dungeonArea.regions.Clear();
				this.mBattleInfo.areas.Add(dungeonArea);
			}
		}
		this._initData();
	}

	// Token: 0x0601744D RID: 95309 RVA: 0x00728538 File Offset: 0x00726938
	private void GetRoomPosByType(int roomType, ref int x, ref int y, ref int roomIndex)
	{
		for (int i = 0; i < this.mAsset.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList = this.mAsset.GetAreaConnectList(i);
			if (areaConnectList != null && areaConnectList.GetTreasureType() == (byte)roomType)
			{
				x = areaConnectList.GetPositionX();
				y = areaConnectList.GetPositionY();
				roomIndex = i;
				return;
			}
		}
	}

	// Token: 0x0601744E RID: 95310 RVA: 0x00728596 File Offset: 0x00726996
	public void GetBossRoom(ref int x, ref int y, ref int roomIndex)
	{
		this.GetRoomPosByType(2, ref x, ref y, ref roomIndex);
	}

	// Token: 0x0601744F RID: 95311 RVA: 0x007285A4 File Offset: 0x007269A4
	public void GetEndRoom(ref int x, ref int y)
	{
		int num = -1;
		this.GetRoomPosByType(3, ref x, ref y, ref num);
	}

	// Token: 0x06017450 RID: 95312 RVA: 0x007285C0 File Offset: 0x007269C0
	public bool IsRoomDefined(int x, int y)
	{
		for (int i = 0; i < this.mAsset.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList = this.mAsset.GetAreaConnectList(i);
			if (areaConnectList != null && areaConnectList.GetPositionX() == x && areaConnectList.GetPositionY() == y)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06017451 RID: 95313 RVA: 0x00728618 File Offset: 0x00726A18
	public int GetRoomCountByType(byte type)
	{
		int num = 0;
		for (int i = 0; i < this.mAsset.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList = this.mAsset.GetAreaConnectList(i);
			if (areaConnectList != null && areaConnectList.GetTreasureType() == type)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06017452 RID: 95314 RVA: 0x00728668 File Offset: 0x00726A68
	public bool CanWalkToRoom(int srcX, int srcY, int tgtX, int tgtY, ref int nextRoomIndex)
	{
		for (int i = 0; i < this.mAsset.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList = this.mAsset.GetAreaConnectList(i);
			if (areaConnectList != null)
			{
				if (areaConnectList.GetPositionX() == srcX && areaConnectList.GetPositionY() == srcY)
				{
					for (int j = 0; j < 4; j++)
					{
						if (areaConnectList.GetIsConnect(j))
						{
							IDungeonConnectData sideByType = this.mAsset.GetSideByType(areaConnectList, (TransportDoorType)j);
							if (sideByType != null)
							{
								if (sideByType.GetPositionX() == tgtX && sideByType.GetPositionY() == tgtY)
								{
									for (int k = 0; k < this.mAsset.GetAreaConnectListLength(); k++)
									{
										IDungeonConnectData areaConnectList2 = this.mAsset.GetAreaConnectList(k);
										if (areaConnectList2.GetPositionX() == tgtX && areaConnectList2.GetPositionY() == tgtY)
										{
											nextRoomIndex = k;
											break;
										}
									}
									return true;
								}
							}
						}
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06017453 RID: 95315 RVA: 0x0072877C File Offset: 0x00726B7C
	public bool GenBossNextRoom(int bossIndex, FrameRandomImp rand, ref int bossNextX, ref int bossNextY, ref int nextIndex)
	{
		if (rand == null || bossIndex < 0 || bossIndex >= this.mAsset.GetAreaConnectListLength())
		{
			return false;
		}
		IDungeonConnectData areaConnectList = this.mAsset.GetAreaConnectList(bossIndex);
		if (areaConnectList == null)
		{
			return false;
		}
		int num = 0;
		IDungeonConnectData dungeonConnectData;
		for (int i = 0; i < 4; i++)
		{
			if (areaConnectList.GetIsConnect(i))
			{
				dungeonConnectData = this.mAsset.GetSideByType(areaConnectList, (TransportDoorType)i);
				if (dungeonConnectData != null && dungeonConnectData.GetTreasureType() != 3)
				{
					num++;
				}
			}
		}
		if (num == 0)
		{
			return false;
		}
		int num2 = rand.InRange(0, num);
		int num3 = 0;
		int num4 = -1;
		dungeonConnectData = null;
		for (int j = 0; j < 4; j++)
		{
			if (areaConnectList.GetIsConnect(j))
			{
				dungeonConnectData = this.mAsset.GetSideByType(areaConnectList, (TransportDoorType)j);
				if (dungeonConnectData != null && dungeonConnectData.GetTreasureType() != 3)
				{
					if (num2 == num3)
					{
						num4 = j;
						break;
					}
					num3++;
				}
			}
		}
		if (num4 < 0)
		{
			return false;
		}
		if (dungeonConnectData == null)
		{
			return false;
		}
		bossNextX = dungeonConnectData.GetPositionX();
		bossNextY = dungeonConnectData.GetPositionY();
		this.mAsset.GetSideByType(areaConnectList, (TransportDoorType)num4, out nextIndex);
		return true;
	}

	// Token: 0x06017454 RID: 95316 RVA: 0x007288B8 File Offset: 0x00726CB8
	public void Clear()
	{
		this._unbindNetMessage();
		this._checkNoVertifyDrops();
		this.SendNoVertifyDrops();
		this.mID = null;
		this.mAsset = null;
		this.mTable = null;
		this.mConfigTable = null;
		if (this.mCacheAreaList != null)
		{
			this.mCacheAreaList.Clear();
		}
		this.mCacheAreaList = null;
	}

	// Token: 0x06017455 RID: 95317 RVA: 0x00728910 File Offset: 0x00726D10
	public bool isDeViILDdOM()
	{
		return this.mTable != null && this.mTable.SubType == DungeonTable.eSubType.S_DEVILDDOM;
	}

	// Token: 0x06017456 RID: 95318 RVA: 0x00728930 File Offset: 0x00726D30
	private void _prepareDebugData(eDungeonMode mode)
	{
		if (mode == eDungeonMode.Test)
		{
			for (int i = 0; i < this.mAsset.GetAreaConnectListLength(); i++)
			{
				IDungeonConnectData areaConnectList = this.mAsset.GetAreaConnectList(i);
				DungeonArea dungeonArea = new DungeonArea();
				dungeonArea.id = this._getDataNodeAreaID(areaConnectList);
				if (areaConnectList.IsStart())
				{
					DataManager<BattleDataManager>.GetInstance().BattleInfo.startAreaId = dungeonArea.id;
				}
				ISceneData sceneData = areaConnectList.GetSceneData();
				if (sceneData != null)
				{
					for (int j = 0; j < sceneData.GetMonsterInfoLength(); j++)
					{
						dungeonArea.monsters.Add(new DungeonMonster
						{
							id = j,
							pointId = j,
							typeId = sceneData.GetMonsterInfo(j).GetEntityInfo().GetResid()
						});
					}
					for (int k = 0; k < sceneData.GetDestructibleInfoLength(); k++)
					{
						if (sceneData.GetDestructibleInfo(k).GetFlushGroupID() > 0)
						{
							List<DungeonMonster> list = new List<DungeonMonster>();
							dungeonArea.destructs.Add(new DungeonMonster
							{
								id = k + sceneData.GetMonsterInfoLength(),
								pointId = k + sceneData.GetMonsterInfoLength(),
								typeId = sceneData.GetDestructibleInfo(k).GetEntityInfo().GetResid(),
								summonerId = 1,
								summonerMonsters = list
							});
							if (dungeonArea.monsters.Count >= 2)
							{
								list.Add(dungeonArea.monsters[0]);
								list.Add(dungeonArea.monsters[1]);
							}
						}
					}
					DataManager<BattleDataManager>.GetInstance().BattleInfo.areas.Add(dungeonArea);
					if (this.mTable.SubType == DungeonTable.eSubType.S_HELL)
					{
						List<int> list2 = new List<int>();
						for (int l = 0; l < this.mAsset.GetAreaConnectListLength(); l++)
						{
							IDungeonConnectData areaConnectList2 = this.mAsset.GetAreaConnectList(l);
							if (areaConnectList2 != null && !areaConnectList2.IsStart() && !areaConnectList2.IsBoss())
							{
								list2.Add(this._getDataNodeAreaID(areaConnectList2));
							}
						}
						int areaId = list2[Random.Range(0, list2.Count - 1)];
						DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonHealInfo.areaId = areaId;
						DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonHealInfo.mode = DungeonHellMode.Hard;
						for (int m = 0; m < 3; m++)
						{
							List<DungeonMonster> list3 = new List<DungeonMonster>();
							DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonHealInfo.waveInfos.Add(new Battle.DungeonHellWaveInfo
							{
								wave = m,
								monsters = list3
							});
							if (dungeonArea.monsters.Count >= 2)
							{
								list3.Add(dungeonArea.monsters[0]);
								list3.Add(dungeonArea.monsters[1]);
							}
						}
						DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonHealInfo.dropItems = new List<DungeonDropItem>();
						for (int n = 0; n < 3; n++)
						{
							DungeonDropItem dungeonDropItem = new DungeonDropItem();
							dungeonDropItem.id = n;
							dungeonDropItem.typeId = 600000007;
							dungeonDropItem.num = 100;
							DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonHealInfo.dropItems.Add(dungeonDropItem);
							DataManager<BattleDataManager>.GetInstance().BattleInfo.bossDropItems.Add(dungeonDropItem);
						}
					}
				}
			}
		}
	}

	// Token: 0x06017457 RID: 95319 RVA: 0x00728CC0 File Offset: 0x007270C0
	public bool FirstArea()
	{
		if (this.battleType == BattleType.ChampionMatch)
		{
			return this.NextAreaByIndexBaseOnServerData(0);
		}
		int startAreaId = this.mBattleInfo.startAreaId;
		return this._changeIndexByAreaID(startAreaId) >= 0;
	}

	// Token: 0x06017458 RID: 95320 RVA: 0x00728CFC File Offset: 0x007270FC
	public bool NextArea(TransportDoorType type)
	{
		if (this.battleType == BattleType.ChampionMatch)
		{
			Logger.LogErrorFormat("[战斗] [数据] 不支持当前模式 {0}", new object[]
			{
				type
			});
			return false;
		}
		IDungeonConnectData sideByType = this.mAsset.GetSideByType(this.currentIndex, type);
		if (sideByType == null)
		{
			Logger.LogErrorFormat("item is nil with curIdx {0}, with type {1}", new object[]
			{
				this.currentIndex,
				type
			});
			return false;
		}
		if (sideByType.GetSceneData() == null)
		{
			Logger.LogErrorFormat("item.scenedata is nil : {0} {1}", new object[]
			{
				this.currentIndex,
				type
			});
		}
		this.mLastDoorType = type;
		int areaId = this._getDataNodeAreaID(sideByType);
		return this._changeIndexByAreaID(areaId) >= 0;
	}

	// Token: 0x06017459 RID: 95321 RVA: 0x00728DC4 File Offset: 0x007271C4
	public bool IsNextAreaVisited(TransportDoorType type)
	{
		if (this.battleType == BattleType.ChampionMatch)
		{
			Logger.LogErrorFormat("[战斗] [数据] 不支持当前模式 {0}", new object[]
			{
				type
			});
			return false;
		}
		IDungeonConnectData sideByType = this.mAsset.GetSideByType(this.currentIndex, type);
		if (sideByType != null)
		{
			DungeonDataManager.CacheArea cacheArea = this._getCacheArea(sideByType);
			if (cacheArea != null)
			{
				return cacheArea.visited;
			}
		}
		return false;
	}

	// Token: 0x0601745A RID: 95322 RVA: 0x00728E28 File Offset: 0x00727228
	public bool NextArea(int index)
	{
		if (this.battleType == BattleType.ChampionMatch)
		{
			Logger.LogErrorFormat("[战斗] [数据] 不支持当前模式 {0}", new object[]
			{
				this.battleType
			});
			return false;
		}
		return this._changeIndexByAreaID(index) >= 0;
	}

	// Token: 0x0601745B RID: 95323 RVA: 0x00728E64 File Offset: 0x00727264
	public bool NextAreaByIndex(int index)
	{
		if (this.battleType == BattleType.ChampionMatch)
		{
			Logger.LogErrorFormat("[战斗] [数据] 不支持当前模式 {0}", new object[]
			{
				this.battleType
			});
			return false;
		}
		return this._changeIndex(index) >= 0;
	}

	// Token: 0x0601745C RID: 95324 RVA: 0x00728EA0 File Offset: 0x007272A0
	public bool NextAreaByIndexBaseOnServerData(int cacheAreaIndex)
	{
		if (this.battleType != BattleType.ChampionMatch)
		{
			Logger.LogErrorFormat("[战斗] [数据] 不支持当前模式 {0}", new object[]
			{
				this.battleType
			});
			return false;
		}
		return 0 <= cacheAreaIndex && cacheAreaIndex < this.mCacheAreaList.Count && this._changeIndexByAreaID(this.mCacheAreaList[cacheAreaIndex].area.id) >= 0;
	}

	// Token: 0x0601745D RID: 95325 RVA: 0x00728F18 File Offset: 0x00727318
	public bool IsNextAreaBoss(TransportDoorType type)
	{
		List<DungeonDoor> list = this.CurrentDoors();
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].doorType == type)
			{
				return list[i].isconnectwithboss;
			}
		}
		return false;
	}

	// Token: 0x0601745E RID: 95326 RVA: 0x00728F64 File Offset: 0x00727364
	public bool IsBossArea()
	{
		if (this.battleType == BattleType.ChampionMatch)
		{
			return this.mCacheAreaList.Count > 0 && this.mCacheAreaList[this.mCacheAreaList.Count - 1].area.id == this.mBattleInfo.areaId;
		}
		IDungeonConnectData dungeonConnectData = this.CurrentDataConnect();
		return dungeonConnectData != null && dungeonConnectData.IsBoss();
	}

	// Token: 0x0601745F RID: 95327 RVA: 0x00728FD8 File Offset: 0x007273D8
	public bool IsHellArea()
	{
		IDungeonConnectData dungeonConnectData = this.CurrentDataConnect();
		return dungeonConnectData != null && this._getDataNodeAreaID(dungeonConnectData) == this.mBattleInfo.dungeonHealInfo.areaId;
	}

	// Token: 0x06017460 RID: 95328 RVA: 0x00729010 File Offset: 0x00727410
	public bool IsBossAreaNearby()
	{
		List<DungeonDoor> list = this.CurrentDoors();
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].isconnectwithboss)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06017461 RID: 95329 RVA: 0x00729050 File Offset: 0x00727450
	public int IsHellAreaVisited()
	{
		if (this.mBattleInfo.dungeonHealInfo != null)
		{
			int areaId = this.mBattleInfo.dungeonHealInfo.areaId;
			DungeonDataManager.CacheArea cacheArea = this._getCacheAreaByAreaID(areaId);
			if (cacheArea != null)
			{
				return (!cacheArea.visited) ? 0 : 1;
			}
		}
		return -1;
	}

	// Token: 0x06017462 RID: 95330 RVA: 0x007290A0 File Offset: 0x007274A0
	private VInt3 GetBirthPosition(IDungeonConnectData node)
	{
		if (node == null)
		{
			return VInt3.zero;
		}
		ISceneData sceneData = node.GetSceneData();
		if (sceneData == null)
		{
			return VInt3.zero;
		}
		if (sceneData.GetBirthPosition() != null)
		{
			return new VInt3(sceneData.GetBirthPosition().GetPosition());
		}
		VInt2 vint = new VInt2(sceneData.GetLogicXSize());
		VInt2 vint2 = new VInt2(sceneData.GetLogicZSize());
		return new VInt3((vint.x + vint.y) / 2, 0, (vint2.x + vint2.y) / 2);
	}

	// Token: 0x06017463 RID: 95331 RVA: 0x0072912C File Offset: 0x0072752C
	private VInt3 _getDoorPosition(IDungeonConnectData node, TransportDoorType fromDoorType)
	{
		VInt3 zero = VInt3.zero;
		ISceneData sceneData = node.GetSceneData();
		if (sceneData == null)
		{
			return VInt3.zero;
		}
		ISceneEntityInfoData sceneEntityInfoData = null;
		for (int i = 0; i < sceneData.GetTransportDoorLength(); i++)
		{
			if (sceneData.GetTransportDoor(i).GetDoortype() == fromDoorType)
			{
				sceneEntityInfoData = sceneData.GetTransportDoor(i).GetRegionInfo().GetEntityInfo();
				break;
			}
		}
		if (sceneEntityInfoData != null)
		{
			return new VInt3(sceneEntityInfoData.GetPosition());
		}
		return zero;
	}

	// Token: 0x06017464 RID: 95332 RVA: 0x007291A8 File Offset: 0x007275A8
	private VInt3 _getDoorBirthPosition(IDungeonConnectData node, TransportDoorType fromDoorType)
	{
		VInt3 result = VInt3.zero;
		if (node == null)
		{
			return result;
		}
		ISceneData sceneData = node.GetSceneData();
		if (sceneData == null)
		{
			return result;
		}
		ISceneTransportDoorData sceneTransportDoorData = null;
		for (int i = 0; i < sceneData.GetTransportDoorLength(); i++)
		{
			if (sceneData.GetTransportDoor(i).GetDoortype() == fromDoorType)
			{
				sceneTransportDoorData = sceneData.GetTransportDoor(i);
				break;
			}
		}
		if (sceneTransportDoorData == null)
		{
			return result;
		}
		this.door = sceneTransportDoorData;
		int num = VInt.Float2VIntValue(sceneTransportDoorData.GetRegionInfo().GetRadius() + 0.4f);
		VInt3 vint = new VInt3(sceneTransportDoorData.GetRegionInfo().GetEntityInfo().GetPosition());
		if ((sceneTransportDoorData.GetBirthposition() - vint).magnitude > num * 3)
		{
			switch (this.mLastDoorType.OppositeType())
			{
			case TransportDoorType.Left:
				result = vint + new VInt3(num, 0, 0);
				break;
			case TransportDoorType.Top:
				result = vint - new VInt3(0, 0, num);
				break;
			case TransportDoorType.Right:
				result = vint - new VInt3(num, 0, 0);
				break;
			case TransportDoorType.Buttom:
				result = vint + new VInt3(0, 0, num);
				break;
			}
		}
		else
		{
			result = sceneTransportDoorData.GetBirthposition();
		}
		return result;
	}

	// Token: 0x06017465 RID: 95333 RVA: 0x007292F5 File Offset: 0x007276F5
	private VInt3 GetDoorBirthPosition(IDungeonConnectData node)
	{
		return this._getDoorBirthPosition(node, this.mLastDoorType.OppositeType());
	}

	// Token: 0x06017466 RID: 95334 RVA: 0x0072930C File Offset: 0x0072770C
	public VInt3 CurrentBirthPosition()
	{
		IDungeonConnectData node = this.CurrentDataConnect();
		return this.GetBirthPosition(node);
	}

	// Token: 0x06017467 RID: 95335 RVA: 0x00729328 File Offset: 0x00727728
	public VInt3 CurrentDoorBirthPosition(TransportDoorType type)
	{
		IDungeonConnectData node = this.CurrentDataConnect();
		return this.GetDoorBirthPosition(node);
	}

	// Token: 0x06017468 RID: 95336 RVA: 0x00729344 File Offset: 0x00727744
	public VInt3 CurrentGuidePosition(ref TransportDoorType doorType)
	{
		DungeonDataManager.CacheArea cacheArea = this._currentCacheNode();
		if (cacheArea != null && cacheArea.toboss != null && cacheArea.toboss.Count > 0)
		{
			int i = cacheArea.toboss[0];
			IDungeonConnectData areaConnectList = this.mAsset.GetAreaConnectList(i);
			IDungeonConnectData dungeonConnectData = this.CurrentDataConnect();
			int connectStatus = this.mAsset.GetConnectStatus(dungeonConnectData, areaConnectList);
			if (connectStatus >= 0)
			{
				doorType = (TransportDoorType)connectStatus;
				return this._getDoorBirthPosition(dungeonConnectData, doorType);
			}
		}
		return VInt3.zero;
	}

	// Token: 0x06017469 RID: 95337 RVA: 0x007293C8 File Offset: 0x007277C8
	public VInt3 CurrentGuideHellPosition(ref TransportDoorType doorType)
	{
		DungeonDataManager.CacheArea cacheArea = this._currentCacheNode();
		if (cacheArea != null && cacheArea.toZhuzi != null && cacheArea.toZhuzi.Count > 0)
		{
			int i = -1;
			for (int j = 0; j < cacheArea.toZhuzi.Count; j++)
			{
				i = cacheArea.toZhuzi[j];
				IDungeonConnectData areaConnectList = this.mAsset.GetAreaConnectList(i);
				if (areaConnectList != null && !areaConnectList.IsBoss())
				{
					break;
				}
			}
			IDungeonConnectData areaConnectList2 = this.mAsset.GetAreaConnectList(i);
			IDungeonConnectData dungeonConnectData = this.CurrentDataConnect();
			int connectStatus = this.mAsset.GetConnectStatus(dungeonConnectData, areaConnectList2);
			if (connectStatus >= 0)
			{
				doorType = (TransportDoorType)connectStatus;
				return this._getDoorBirthPosition(dungeonConnectData, doorType);
			}
		}
		return VInt3.zero;
	}

	// Token: 0x0601746A RID: 95338 RVA: 0x00729490 File Offset: 0x00727890
	public VInt3 CurrentGuideDoorPosition()
	{
		DungeonDataManager.CacheArea cacheArea = this._currentCacheNode();
		if (cacheArea != null && cacheArea.toboss != null && cacheArea.toboss.Count > 0)
		{
			int i = cacheArea.toboss[0];
			IDungeonConnectData areaConnectList = this.mAsset.GetAreaConnectList(i);
			IDungeonConnectData dungeonConnectData = this.CurrentDataConnect();
			int connectStatus = this.mAsset.GetConnectStatus(dungeonConnectData, areaConnectList);
			if (connectStatus >= 0)
			{
				return this._getDoorPosition(dungeonConnectData, (TransportDoorType)connectStatus);
			}
		}
		return VInt3.zero;
	}

	// Token: 0x0601746B RID: 95339 RVA: 0x00729510 File Offset: 0x00727910
	public VInt3 GetBirthPosition()
	{
		IDungeonConnectData node = this.CurrentDataConnect();
		if (this.lastIndex < 0 && this._getDataNodeAreaID(node) == this.mBattleInfo.startAreaId)
		{
			return this.GetBirthPosition(node);
		}
		return this.GetDoorBirthPosition(node);
	}

	// Token: 0x0601746C RID: 95340 RVA: 0x00729558 File Offset: 0x00727958
	public VInt3 GetAirBattleBornPos(int i)
	{
		IDungeonConnectData dungeonConnectData = this.CurrentDataConnect();
		if (dungeonConnectData == null)
		{
			return VInt3.zero;
		}
		ISceneData sceneData = dungeonConnectData.GetSceneData();
		if (sceneData == null)
		{
			return VInt3.zero;
		}
		ISceneEntityInfoData airBattleBornPos = sceneData.GetAirBattleBornPos(i);
		if (airBattleBornPos != null)
		{
			return new VInt3(airBattleBornPos.GetPosition());
		}
		Logger.LogErrorFormat("GetAirBattleBornPos is null index {0} id {1}", new object[]
		{
			i,
			this.id.dungeonID
		});
		return VInt3.zero;
	}

	// Token: 0x0601746D RID: 95341 RVA: 0x007295D8 File Offset: 0x007279D8
	public int CurrentIndex()
	{
		if (this.battleType == BattleType.ChampionMatch)
		{
			for (int i = 0; i < this.mCacheAreaList.Count; i++)
			{
				if (this.mCacheAreaList[i].area.id == this.mBattleInfo.areaId)
				{
					return i;
				}
			}
			return -1;
		}
		return this.currentIndex;
	}

	// Token: 0x0601746E RID: 95342 RVA: 0x00729640 File Offset: 0x00727A40
	public int CurrentAreaID()
	{
		if (this.battleType == BattleType.ChampionMatch)
		{
			return this.mBattleInfo.areaId;
		}
		IDungeonConnectData node = this.CurrentDataConnect();
		return this._getDataNodeAreaID(node);
	}

	// Token: 0x0601746F RID: 95343 RVA: 0x00729674 File Offset: 0x00727A74
	public int CurrentAreaIDWithoutDiff()
	{
		return this.CurrentAreaID() / 10;
	}

	// Token: 0x06017470 RID: 95344 RVA: 0x00729680 File Offset: 0x00727A80
	private void _appendDropItem(List<DungeonMonster> list)
	{
		List<DungeonAddMonsterDropItem> addMonsterDropItem = this.mBattleInfo.addMonsterDropItem;
		for (int i = 0; i < list.Count; i++)
		{
			DungeonMonster dungeonMonster = list[i];
			this.mSearchOp.monsterId = dungeonMonster.id;
			int num = addMonsterDropItem.BinarySearch(this.mSearchOp);
			if (num >= 0)
			{
				DungeonAddMonsterDropItem dungeonAddMonsterDropItem = addMonsterDropItem[num];
				for (int j = 0; j < dungeonAddMonsterDropItem.dropItems.Count; j++)
				{
					dungeonMonster.dropItems.Add(dungeonAddMonsterDropItem.dropItems[j]);
				}
				addMonsterDropItem.Remove(dungeonAddMonsterDropItem);
			}
		}
	}

	// Token: 0x06017471 RID: 95345 RVA: 0x00729730 File Offset: 0x00727B30
	private void _makeupHell()
	{
		if (this.IsHellArea())
		{
			DungeonDataManager.CacheArea cacheArea = this._currentCacheNode();
			Battle.DungeonHellInfo dungeonHealInfo = this.mBattleInfo.dungeonHealInfo;
			if (cacheArea != null)
			{
				cacheArea.hell = dungeonHealInfo.Duplicate();
			}
		}
	}

	// Token: 0x06017472 RID: 95346 RVA: 0x00729770 File Offset: 0x00727B70
	private void _makeupMonsterDestruct()
	{
		if (this.battleType == BattleType.TreasureMap)
		{
			return;
		}
		IDungeonConnectData dungeonConnectData = this.CurrentDataConnect();
		DungeonDataManager.CacheArea cacheArea = this._currentCacheNode();
		List<DungeonMonster> monsters = cacheArea.area.monsters;
		if (dungeonConnectData.GetSceneData() == null)
		{
			return;
		}
		ISceneData sceneData = dungeonConnectData.GetSceneData();
		if (sceneData == null)
		{
			return;
		}
		int i;
		for (i = 0; i < sceneData.GetMonsterInfoLength(); i++)
		{
			ISceneMonsterInfoData monsterData = sceneData.GetMonsterInfo(i);
			if (monsterData != null)
			{
				UnitTable tableItem = Singleton<TableManager>.instance.GetTableItem<UnitTable>(monsterData.GetEntityInfo().GetResid(), string.Empty, string.Empty);
				if (tableItem != null && tableItem.Type == UnitTable.eType.SKILL_MONSTER && monsters.Find((DungeonMonster x) => x.pointId % 100 == i && x.typeId / 10 == monsterData.GetEntityInfo().GetResid() / 10) == null)
				{
					monsters.Add(new DungeonMonster
					{
						pointId = i,
						typeId = monsterData.GetEntityInfo().GetResid() / 10 * 10 + this.mID.diffID + 1,
						removed = false
					});
				}
			}
		}
	}

	// Token: 0x06017473 RID: 95347 RVA: 0x007298D8 File Offset: 0x00727CD8
	private void _makeupDestructList()
	{
		DungeonDataManager.<_makeupDestructList>c__AnonStorey3 <_makeupDestructList>c__AnonStorey = new DungeonDataManager.<_makeupDestructList>c__AnonStorey3();
		<_makeupDestructList>c__AnonStorey.node = this.CurrentDataConnect();
		DungeonDataManager.CacheArea cacheArea = this._currentCacheNode();
		if (<_makeupDestructList>c__AnonStorey.node == null || cacheArea == null || cacheArea.area == null || <_makeupDestructList>c__AnonStorey.node.GetSceneData() == null)
		{
			return;
		}
		List<DungeonMonster> destructs = cacheArea.area.destructs;
		int destructibleInfoLength = <_makeupDestructList>c__AnonStorey.node.GetSceneData().GetDestructibleInfoLength();
		<_makeupDestructList>c__AnonStorey.offset = <_makeupDestructList>c__AnonStorey.node.GetSceneData().GetMonsterInfoLength();
		int i;
		for (i = 0; i < destructibleInfoLength; i++)
		{
			if (destructs.Find((DungeonMonster x) => x.pointId % 100 == <_makeupDestructList>c__AnonStorey.offset + i && x.typeId == <_makeupDestructList>c__AnonStorey.node.GetSceneData().GetDestructibleInfo(i).GetEntityInfo().GetResid()) == null)
			{
				destructs.Add(new DungeonMonster
				{
					id = int.MaxValue,
					pointId = <_makeupDestructList>c__AnonStorey.offset + i,
					typeId = <_makeupDestructList>c__AnonStorey.node.GetSceneData().GetDestructibleInfo(i).GetEntityInfo().GetResid(),
					removed = false
				});
			}
		}
	}

	// Token: 0x06017474 RID: 95348 RVA: 0x00729A18 File Offset: 0x00727E18
	public List<DungeonMonster> CurrentMonsters()
	{
		DungeonDataManager.CacheArea cacheArea = this._currentCacheNode();
		return cacheArea.area.monsters;
	}

	// Token: 0x06017475 RID: 95349 RVA: 0x00729A38 File Offset: 0x00727E38
	public List<DungeonMonster> CurrentDestructs()
	{
		DungeonDataManager.CacheArea cacheArea = this._currentCacheNode();
		return cacheArea.area.destructs;
	}

	// Token: 0x06017476 RID: 95350 RVA: 0x00729A58 File Offset: 0x00727E58
	public List<int> CurrentRegions()
	{
		DungeonDataManager.CacheArea cacheArea = this._currentCacheNode();
		if (cacheArea == null)
		{
			Logger.LogErrorFormat("cacheNode is Invalid {0} dungeonId {1}", new object[]
			{
				this.currentIndex,
				this.mID.dungeonID
			});
			return this.sDefautlRegions;
		}
		if (cacheArea.area == null)
		{
			Logger.LogErrorFormat("cacheNode.area is Invalid {0} dungeonId {1}", new object[]
			{
				this.currentIndex,
				this.mID.dungeonID
			});
			return this.sDefautlRegions;
		}
		return cacheArea.area.regions;
	}

	// Token: 0x06017477 RID: 95351 RVA: 0x00729AF8 File Offset: 0x00727EF8
	public void AddDynamicRegion(CustomSceneRegionInfo regionInfo)
	{
		DungeonDataManager.CacheArea cacheArea = this._currentCacheNode();
		if (cacheArea == null)
		{
			Logger.LogErrorFormat("cacheNode is Invalid {0} dungeonId {1}", new object[]
			{
				this.currentIndex,
				this.mID.dungeonID
			});
			return;
		}
		if (cacheArea.area == null)
		{
			Logger.LogErrorFormat("cacheNode.area is Invalid {0} dungeonId {1}", new object[]
			{
				this.currentIndex,
				this.mID.dungeonID
			});
			return;
		}
		cacheArea.dynamicRegionInfoes.Add(regionInfo);
	}

	// Token: 0x06017478 RID: 95352 RVA: 0x00729B90 File Offset: 0x00727F90
	public List<int> CurrentDynamicRegions()
	{
		DungeonDataManager.CacheArea cacheArea = this._currentCacheNode();
		if (cacheArea == null)
		{
			Logger.LogErrorFormat("cacheNode is Invalid {0} dungeonId {1}", new object[]
			{
				this.currentIndex,
				this.mID.dungeonID
			});
			return this.sDefautlRegions;
		}
		if (cacheArea.area == null)
		{
			Logger.LogErrorFormat("cacheNode.area is Invalid {0} dungeonId {1}", new object[]
			{
				this.currentIndex,
				this.mID.dungeonID
			});
			return this.sDefautlRegions;
		}
		return cacheArea.dynamicRegions;
	}

	// Token: 0x06017479 RID: 95353 RVA: 0x00729C2C File Offset: 0x0072802C
	public List<CustomSceneRegionInfo> CurrentDynamicRegionInfoes()
	{
		DungeonDataManager.CacheArea cacheArea = this._currentCacheNode();
		if (cacheArea == null)
		{
			Logger.LogErrorFormat("cacheNode is Invalid {0} dungeonId {1}", new object[]
			{
				this.currentIndex,
				this.mID.dungeonID
			});
			return null;
		}
		if (cacheArea.area == null)
		{
			Logger.LogErrorFormat("cacheNode.area is Invalid {0} dungeonId {1}", new object[]
			{
				this.currentIndex,
				this.mID.dungeonID
			});
			return null;
		}
		return cacheArea.dynamicRegionInfoes;
	}

	// Token: 0x0601747A RID: 95354 RVA: 0x00729CC0 File Offset: 0x007280C0
	public List<DungeonDoor> CurrentDoors()
	{
		this.mDoors.Clear();
		IDungeonConnectData dungeonConnectData = this.CurrentDataConnect();
		if (dungeonConnectData == null)
		{
			return this.mDoors;
		}
		ISceneData sceneData = dungeonConnectData.GetSceneData();
		if (sceneData == null)
		{
			return this.mDoors;
		}
		for (int i = 0; i < sceneData.GetTransportDoorLength(); i++)
		{
			ISceneTransportDoorData transportDoor = sceneData.GetTransportDoor(i);
			DungeonDoor dungeonDoor = new DungeonDoor();
			if (dungeonConnectData.GetIsConnect((int)transportDoor.GetDoortype()))
			{
				dungeonDoor.isconnectwithboss = this._isNearBossRoom(dungeonConnectData, transportDoor.GetDoortype());
				dungeonDoor.isvisited = this._isVisitedRoom(dungeonConnectData, transportDoor.GetDoortype());
				dungeonDoor.door = transportDoor;
				dungeonDoor.doorType = transportDoor.GetDoortype();
				dungeonDoor.isEggDoor = transportDoor.IsEggDoor();
			}
			this.mDoors.Add(dungeonDoor);
		}
		return this.mDoors;
	}

	// Token: 0x0601747B RID: 95355 RVA: 0x00729D94 File Offset: 0x00728194
	public Battle.DungeonHellInfo CurrentHellDestructs()
	{
		DungeonDataManager.CacheArea cacheArea = this._currentCacheNode();
		if (cacheArea != null && cacheArea.hell != null)
		{
			return cacheArea.hell;
		}
		return null;
	}

	// Token: 0x0601747C RID: 95356 RVA: 0x00729DC4 File Offset: 0x007281C4
	public string CurrentScenePath()
	{
		IDungeonConnectData dungeonConnectData = this.CurrentDataConnect();
		if (dungeonConnectData != null)
		{
			return dungeonConnectData.GetSceneAreaPath();
		}
		return string.Empty;
	}

	// Token: 0x0601747D RID: 95357 RVA: 0x00729DEC File Offset: 0x007281EC
	public ISceneData CurrentSceneData()
	{
		IDungeonConnectData dungeonConnectData = this.CurrentDataConnect();
		if (dungeonConnectData != null)
		{
			return dungeonConnectData.GetSceneData();
		}
		return null;
	}

	// Token: 0x0601747E RID: 95358 RVA: 0x00729E0E File Offset: 0x0072820E
	public void DeleteMonster(int id)
	{
	}

	// Token: 0x0601747F RID: 95359 RVA: 0x00729E10 File Offset: 0x00728210
	public void DeleteDropItem(int id)
	{
	}

	// Token: 0x06017480 RID: 95360 RVA: 0x00729E12 File Offset: 0x00728212
	public void DeleteDestruct(int id)
	{
	}

	// Token: 0x06017481 RID: 95361 RVA: 0x00729E14 File Offset: 0x00728214
	private bool _isNearBossRoom(IDungeonConnectData node, TransportDoorType type)
	{
		IDungeonConnectData sideByType = this.mAsset.GetSideByType(node, type);
		return sideByType != null && sideByType.IsBoss();
	}

	// Token: 0x06017482 RID: 95362 RVA: 0x00729E40 File Offset: 0x00728240
	private bool _isVisitedRoom(IDungeonConnectData node, TransportDoorType type)
	{
		IDungeonConnectData sideByType = this.mAsset.GetSideByType(node, type);
		DungeonDataManager.CacheArea cacheArea = this._getCacheArea(sideByType);
		return cacheArea != null && cacheArea.visited;
	}

	// Token: 0x06017483 RID: 95363 RVA: 0x00729E74 File Offset: 0x00728274
	private void _initData()
	{
		this.mCacheAreaList = new List<DungeonDataManager.CacheArea>();
		for (int i = 0; i < this.mBattleInfo.areas.Count; i++)
		{
			DungeonArea area = this.mBattleInfo.areas[i].Duplicate();
			DungeonDataManager.CacheArea cacheArea = new DungeonDataManager.CacheArea();
			cacheArea.area = area;
			cacheArea.visited = false;
			cacheArea.statistics = new DungeonStatistics();
			cacheArea.toboss = new List<int>();
			cacheArea.toZhuzi = new List<int>();
			cacheArea.killdMonster = new List<uint>();
			cacheArea.pickedItems = new List<uint>();
			cacheArea.dynamicRegions = new List<int>();
			cacheArea.dynamicRegionInfoes = new List<CustomSceneRegionInfo>();
			this.mCacheAreaList.Add(cacheArea);
		}
	}

	// Token: 0x06017484 RID: 95364 RVA: 0x00729F33 File Offset: 0x00728333
	private void _initRandData(eDungeonMode mode)
	{
	}

	// Token: 0x06017485 RID: 95365 RVA: 0x00729F38 File Offset: 0x00728338
	private void _initPath2BossRoom()
	{
		Queue<int> queue = new Queue<int>();
		bool[] array = new bool[this.mAsset.GetAreaConnectListLength()];
		for (int i = 0; i < this.mAsset.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList = this.mAsset.GetAreaConnectList(i);
			if (areaConnectList.IsBoss())
			{
				queue.Enqueue(i);
				break;
			}
		}
		while (queue.Count > 0)
		{
			int num = queue.Dequeue();
			IDungeonConnectData areaConnectList2 = this.mAsset.GetAreaConnectList(num);
			for (int j = 0; j < areaConnectList2.GetIsConnectLength(); j++)
			{
				if (areaConnectList2.GetIsConnect(j))
				{
					IDungeonConnectData sideByType = this.mAsset.GetSideByType(areaConnectList2, (TransportDoorType)j);
					if (!array[sideByType.GetAreaIndex()])
					{
						queue.Enqueue(sideByType.GetAreaIndex());
						DungeonDataManager.CacheArea cacheArea = this._getCacheArea(sideByType);
						if (cacheArea != null)
						{
							cacheArea.toboss.Add(areaConnectList2.GetAreaIndex());
						}
					}
				}
			}
			array[num] = true;
		}
		if (this.mBattleInfo.dungeonHealInfo.areaId <= 0)
		{
			return;
		}
		queue.Clear();
		bool flag = false;
		for (int k = 0; k < this.mAsset.GetAreaConnectListLength(); k++)
		{
			IDungeonConnectData areaConnectList3 = this.mAsset.GetAreaConnectList(k);
			array[k] = false;
			if (this._getCacheArea(areaConnectList3).area.id == this.mBattleInfo.dungeonHealInfo.areaId)
			{
				flag = true;
				queue.Enqueue(k);
			}
		}
		if (flag)
		{
			while (queue.Count > 0)
			{
				int num2 = queue.Dequeue();
				IDungeonConnectData areaConnectList4 = this.mAsset.GetAreaConnectList(num2);
				for (int l = 0; l < areaConnectList4.GetIsConnectLength(); l++)
				{
					if (areaConnectList4.GetIsConnect(l))
					{
						IDungeonConnectData sideByType2 = this.mAsset.GetSideByType(areaConnectList4, (TransportDoorType)l);
						if (!array[sideByType2.GetAreaIndex()])
						{
							queue.Enqueue(sideByType2.GetAreaIndex());
							DungeonDataManager.CacheArea cacheArea2 = this._getCacheArea(sideByType2);
							if (cacheArea2 != null)
							{
								cacheArea2.toZhuzi.Add(areaConnectList4.GetAreaIndex());
							}
						}
					}
				}
				array[num2] = true;
			}
		}
	}

	// Token: 0x06017486 RID: 95366 RVA: 0x0072A177 File Offset: 0x00728577
	public int GetIndexByAreaId()
	{
		return this._changeIndexByAreaID(this.CurrentAreaID());
	}

	// Token: 0x06017487 RID: 95367 RVA: 0x0072A188 File Offset: 0x00728588
	private int _changeIndexByAreaID(int areaId)
	{
		IDungeonConnectData dungeonConnectData = null;
		for (int i = 0; i < this.mAsset.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList = this.mAsset.GetAreaConnectList(i);
			if (this._getDataNodeAreaID(areaConnectList) == areaId)
			{
				dungeonConnectData = areaConnectList;
				break;
			}
		}
		if (dungeonConnectData != null)
		{
			this.currentIndex = dungeonConnectData.GetAreaIndex();
			this.mBattleInfo.areaId = areaId;
			this._makeupAreaDatas();
			this._doStatEnterRoom(areaId);
			return this.currentIndex;
		}
		return -1;
	}

	// Token: 0x06017488 RID: 95368 RVA: 0x0072A208 File Offset: 0x00728608
	private void _doStatEnterRoom(int areaId)
	{
		try
		{
			Singleton<GameStatisticManager>.instance.DoStatEnterPVERoom(this.id.dungeonID, areaId);
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[战斗数据] 发送统计数据出错 {0}", new object[]
			{
				ex.ToString()
			});
		}
	}

	// Token: 0x06017489 RID: 95369 RVA: 0x0072A260 File Offset: 0x00728660
	private int _changeIndex(int index)
	{
		if (index >= 0 && index < this.mAsset.GetAreaConnectListLength())
		{
			this.currentIndex = index;
			this.mBattleInfo.areaId = this._getDataNodeAreaID(this.mAsset.GetAreaConnectList(index));
			this._makeupAreaDatas();
			this._doStatEnterRoom(this.mBattleInfo.areaId);
			return this.currentIndex;
		}
		Logger.LogErrorFormat("index {0} is out of range.", new object[]
		{
			index
		});
		return -1;
	}

	// Token: 0x0601748A RID: 95370 RVA: 0x0072A2E4 File Offset: 0x007286E4
	private void _makeupAreaDatas()
	{
		DungeonDataManager.CacheArea cacheArea = this._currentCacheNode();
		if (cacheArea != null && !cacheArea.visited)
		{
			cacheArea.visited = true;
			this._appendDropItem(cacheArea.area.monsters);
			this._appendDropItem(cacheArea.area.destructs);
			this._makeupDestructList();
			this._makeupMonsterDestruct();
			this._makeupHell();
		}
	}

	// Token: 0x0601748B RID: 95371 RVA: 0x0072A344 File Offset: 0x00728744
	private int[] _makeupPath(DungeonDataManager.CacheArea from)
	{
		DungeonDataManager.CacheArea cacheArea = from;
		List<int> list = new List<int>();
		if (cacheArea == null)
		{
			return null;
		}
		while (cacheArea.toboss != null && cacheArea.toboss.Count > 0)
		{
			list.Add(this.mCacheAreaList.IndexOf(cacheArea));
			cacheArea = this.mCacheAreaList[cacheArea.toboss[0]];
		}
		return list.ToArray();
	}

	// Token: 0x0601748C RID: 95372 RVA: 0x0072A3B4 File Offset: 0x007287B4
	private DungeonDataManager.CacheArea _getCacheArea(IDungeonConnectData node)
	{
		int areaId = this._getDataNodeAreaID(node);
		return this._getCacheAreaByAreaID(areaId);
	}

	// Token: 0x0601748D RID: 95373 RVA: 0x0072A3D0 File Offset: 0x007287D0
	private DungeonDataManager.CacheArea _getCacheAreaByAreaID(int areaId)
	{
		for (int i = 0; i < this.mCacheAreaList.Count; i++)
		{
			if (this.mCacheAreaList[i].area.id == areaId)
			{
				return this.mCacheAreaList[i];
			}
		}
		return null;
	}

	// Token: 0x0601748E RID: 95374 RVA: 0x0072A423 File Offset: 0x00728823
	private int _getDataNodeAreaID(IDungeonConnectData node)
	{
		if (node != null)
		{
			return node.GetId() * 10 + this.mID.diffID + 1;
		}
		return -1;
	}

	// Token: 0x0601748F RID: 95375 RVA: 0x0072A444 File Offset: 0x00728844
	public int FindDataConnectIDByAreaID(int areaID)
	{
		for (int i = 0; i < this.mAsset.GetAreaConnectListLength(); i++)
		{
			IDungeonConnectData areaConnectList = this.mAsset.GetAreaConnectList(i);
			if (areaConnectList != null && this._getDataNodeAreaID(areaConnectList) == areaID)
			{
				return areaConnectList.GetId();
			}
		}
		return -1;
	}

	// Token: 0x06017490 RID: 95376 RVA: 0x0072A495 File Offset: 0x00728895
	public IDungeonConnectData CurrentDataConnect()
	{
		if (this.battleType == BattleType.ChampionMatch)
		{
			return this._currentDataConnectBaseOnServerData();
		}
		return this._currentDataConnectBaseOnAssetData();
	}

	// Token: 0x06017491 RID: 95377 RVA: 0x0072A4B4 File Offset: 0x007288B4
	private IDungeonConnectData _currentDataConnectBaseOnServerData()
	{
		DungeonDataManager.CacheArea cacheArea = this._getCacheAreaByAreaID(this.mBattleInfo.areaId);
		if (cacheArea == null)
		{
			Logger.LogErrorFormat("_currentDataConnectBaseOnServerData areaid {0} can't be found", new object[]
			{
				this.mBattleInfo.areaId
			});
			return null;
		}
		int num = this._getAreaIdWithNoDiff(cacheArea.area.id);
		IDungeonConnectData dungeonConnectData = this._currentDataConnectBaseOnAssetData();
		if (dungeonConnectData == null)
		{
			return null;
		}
		if (dungeonConnectData.GetId() == num)
		{
			return dungeonConnectData;
		}
		for (int i = 0; i < dungeonConnectData.GetLinkAreaIndexesLength(); i++)
		{
			int linkAreaIndex = dungeonConnectData.GetLinkAreaIndex(i);
			IDungeonConnectData areaConnectList = this.mAsset.GetAreaConnectList(linkAreaIndex);
			if (areaConnectList != null && areaConnectList.GetId() == num)
			{
				return areaConnectList;
			}
		}
		return null;
	}

	// Token: 0x06017492 RID: 95378 RVA: 0x0072A574 File Offset: 0x00728974
	private int _getAreaIdWithNoDiff(int areaId)
	{
		return areaId / 10;
	}

	// Token: 0x06017493 RID: 95379 RVA: 0x0072A57C File Offset: 0x0072897C
	private IDungeonConnectData _currentDataConnectBaseOnAssetData()
	{
		if (this.currentIndex < 0 || this.currentIndex >= this.mAsset.GetAreaConnectListLength())
		{
			Logger.LogErrorFormat("_currentDataConnectBaseOnAssetData index {0} can't be found {1}", new object[]
			{
				this.currentIndex,
				this.mAsset.GetAreaConnectListLength()
			});
			return null;
		}
		return this.mAsset.GetAreaConnectList(this.currentIndex);
	}

	// Token: 0x06017494 RID: 95380 RVA: 0x0072A5F0 File Offset: 0x007289F0
	public List<DungeonStatistics> AllDungeonStatistics()
	{
		this.mAllDungeonStatistics.Clear();
		for (int i = 0; i < this.mCacheAreaList.Count; i++)
		{
			this.mAllDungeonStatistics.Add(this.mCacheAreaList[i].statistics);
		}
		return this.mAllDungeonStatistics;
	}

	// Token: 0x06017495 RID: 95381 RVA: 0x0072A648 File Offset: 0x00728A48
	public DungeonStatistics CurrentDungeonStatistics()
	{
		DungeonDataManager.CacheArea cacheArea = this._currentCacheNode();
		if (cacheArea == null)
		{
			return null;
		}
		return cacheArea.statistics;
	}

	// Token: 0x06017496 RID: 95382 RVA: 0x0072A66C File Offset: 0x00728A6C
	public int CurrentFightTime(bool withClear)
	{
		DungeonStatistics dungeonStatistics = this.CurrentDungeonStatistics();
		if (dungeonStatistics == null)
		{
			return 0;
		}
		int num = dungeonStatistics.areaFightTime;
		if (withClear)
		{
			num += dungeonStatistics.areaClearTime;
		}
		return num;
	}

	// Token: 0x06017497 RID: 95383 RVA: 0x0072A6A0 File Offset: 0x00728AA0
	public int AllFightTime(bool withClear)
	{
		int num = 0;
		for (int i = 0; i < this.mCacheAreaList.Count; i++)
		{
			num += this.mCacheAreaList[i].statistics.areaFightTime;
			if (withClear)
			{
				num += this.mCacheAreaList[i].statistics.areaClearTime;
			}
		}
		return num;
	}

	// Token: 0x06017498 RID: 95384 RVA: 0x0072A704 File Offset: 0x00728B04
	public int LastFightTimeWithCount(bool withClear, int count)
	{
		this.mStatistics.Clear();
		for (int i = 0; i < this.mCacheAreaList.Count; i++)
		{
			if (this.mCacheAreaList[i].statistics.lastVisitFrame != 4294967295U)
			{
				this.mStatistics.Add(this.mCacheAreaList[i].statistics);
			}
		}
		this.mStatistics.Sort(delegate(DungeonStatistics a, DungeonStatistics b)
		{
			if (b.lastVisitFrame > a.lastVisitFrame)
			{
				return 1;
			}
			if (b.lastVisitFrame == a.lastVisitFrame)
			{
				return 0;
			}
			return -1;
		});
		int num = 0;
		int num2 = 0;
		while (num2 < this.mStatistics.Count && num2 < count)
		{
			num += this.mStatistics[num2].areaFightTime;
			if (withClear)
			{
				num += this.mStatistics[num2].areaClearTime;
			}
			num2++;
		}
		return num;
	}

	// Token: 0x06017499 RID: 95385 RVA: 0x0072A7EC File Offset: 0x00728BEC
	private DungeonDataManager.CacheArea _currentCacheNode()
	{
		IDungeonConnectData node = this.CurrentDataConnect();
		return this._getCacheArea(node);
	}

	// Token: 0x0601749A RID: 95386 RVA: 0x0072A808 File Offset: 0x00728C08
	private void _bindNetMessage()
	{
		NetProcess.AddMsgHandler(506810U, new Action<MsgDATA>(this._dungeonDataMsgBinder));
		NetProcess.AddMsgHandler(506820U, new Action<MsgDATA>(this._dungeonDataMsgBinder));
		NetProcess.AddMsgHandler(506808U, new Action<MsgDATA>(this._dungeonDataMsgBinder));
		NetProcess.AddMsgHandler(506824U, new Action<MsgDATA>(this._dungeonDataMsgBinder));
		NetProcess.AddMsgHandler(606810U, new Action<MsgDATA>(this._dungeonDataMsgBinder));
		NetProcess.AddMsgHandler(606812U, new Action<MsgDATA>(this._dungeonDataMsgBinder));
		NetProcess.AddMsgHandler(606820U, new Action<MsgDATA>(this._dungeonDataMsgBinder));
	}

	// Token: 0x0601749B RID: 95387 RVA: 0x0072A8B0 File Offset: 0x00728CB0
	private void _unbindNetMessage()
	{
		NetProcess.RemoveMsgHandler(506810U, new Action<MsgDATA>(this._dungeonDataMsgBinder));
		NetProcess.RemoveMsgHandler(506820U, new Action<MsgDATA>(this._dungeonDataMsgBinder));
		NetProcess.RemoveMsgHandler(506808U, new Action<MsgDATA>(this._dungeonDataMsgBinder));
		NetProcess.RemoveMsgHandler(506824U, new Action<MsgDATA>(this._dungeonDataMsgBinder));
		NetProcess.RemoveMsgHandler(606810U, new Action<MsgDATA>(this._dungeonDataMsgBinder));
		NetProcess.RemoveMsgHandler(606812U, new Action<MsgDATA>(this._dungeonDataMsgBinder));
		NetProcess.RemoveMsgHandler(606820U, new Action<MsgDATA>(this._dungeonDataMsgBinder));
	}

	// Token: 0x0601749C RID: 95388 RVA: 0x0072A958 File Offset: 0x00728D58
	private void _dungeonDataMsgBinder(MsgDATA data)
	{
		if (data.id == 506810U)
		{
			SceneDungeonRewardRes sceneDungeonRewardRes = new SceneDungeonRewardRes();
			sceneDungeonRewardRes.decode(data.bytes);
			this._onSceneDungeonRewardRes(sceneDungeonRewardRes);
		}
		else if (data.id == 506820U)
		{
			SceneDungeonKillMonsterRes sceneDungeonKillMonsterRes = new SceneDungeonKillMonsterRes();
			sceneDungeonKillMonsterRes.decode(data.bytes);
			this._onSceneDungeonKillMonsterRes(sceneDungeonKillMonsterRes);
		}
		else if (data.id == 506808U)
		{
			SceneDungeonEnterNextAreaRes sceneDungeonEnterNextAreaRes = new SceneDungeonEnterNextAreaRes();
			sceneDungeonEnterNextAreaRes.decode(data.bytes);
			this._onSceneDungeonEnterNextAreaRes(sceneDungeonEnterNextAreaRes);
		}
		else if (data.id == 506824U)
		{
			SceneDungeonEndDropRes sceneDungeonEndDropRes = new SceneDungeonEndDropRes();
			sceneDungeonEndDropRes.decode(data.bytes);
			this._onSceneDungeonEndDropRes(sceneDungeonEndDropRes);
		}
		else if (data.id == 506812U)
		{
			SceneDungeonRaceEndRes sceneDungeonRaceEndRes = new SceneDungeonRaceEndRes();
			sceneDungeonRaceEndRes.decode(data.bytes);
			this._onSceneDungeonRaceEndRes(sceneDungeonRaceEndRes);
		}
		else if (data.id == 606810U)
		{
			WorldDungeonEnterRaceRes worldDungeonEnterRaceRes = new WorldDungeonEnterRaceRes();
			worldDungeonEnterRaceRes.decode(data.bytes);
			this._onWorldDungeonEnterRaceRes(worldDungeonEnterRaceRes);
		}
		else if (data.id == 606812U)
		{
			WorldDungeonReportFrameRes worldDungeonReportFrameRes = new WorldDungeonReportFrameRes();
			worldDungeonReportFrameRes.decode(data.bytes);
			this._onWorldDungeonReportFrameRes(worldDungeonReportFrameRes);
		}
		else if (data.id == 606820U)
		{
			WorldDungeonNotifyGetYellowEquip worldDungeonNotifyGetYellowEquip = new WorldDungeonNotifyGetYellowEquip();
			worldDungeonNotifyGetYellowEquip.decode(data.bytes);
			this._onWorldDungeonReportEquipRes(worldDungeonNotifyGetYellowEquip);
		}
		else
		{
			Logger.LogErrorFormat("[战斗数据] 没处理的消息 {0}", new object[]
			{
				data.id
			});
		}
	}

	// Token: 0x0601749D RID: 95389 RVA: 0x0072AB00 File Offset: 0x00728F00
	private bool _addUniqueItem<T>(List<T> list, T item)
	{
		if (list != null)
		{
			int num = list.BinarySearch(item);
			if (num < 0)
			{
				list.Insert(~num, item);
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601749E RID: 95390 RVA: 0x0072AB30 File Offset: 0x00728F30
	private bool _isAllSendVertify(List<uint> sendList, List<uint> vertifyList)
	{
		sendList.Sort();
		vertifyList.Sort();
		int num = 0;
		int num2 = 0;
		while (num2 < sendList.Count && num < vertifyList.Count)
		{
			if (sendList[num2] != vertifyList[num])
			{
				num2++;
				break;
			}
			num2++;
			num++;
		}
		return num2 == num;
	}

	// Token: 0x0601749F RID: 95391 RVA: 0x0072AB98 File Offset: 0x00728F98
	private uint[] _getAllNoVertifyItems(List<uint> sendList, List<uint> vertifyList)
	{
		List<uint> list = new List<uint>();
		sendList.Sort();
		vertifyList.Sort();
		int i = 0;
		int num = 0;
		while (i < sendList.Count && num < vertifyList.Count)
		{
			if (sendList[i] == vertifyList[num])
			{
				i++;
				num++;
			}
			else
			{
				list.Add(sendList[i]);
				i++;
			}
		}
		while (i < sendList.Count)
		{
			list.Add(sendList[i]);
			i++;
		}
		return list.ToArray();
	}

	// Token: 0x060174A0 RID: 95392 RVA: 0x0072AC34 File Offset: 0x00729034
	private bool _sendNetMsg2Gate<T>(T req, string tag) where T : IProtocolStream, IGetMsgID
	{
		if (req != null)
		{
			this.ResendDungeonEnterRace();
			if (req.GetMsgID() != 506819U)
			{
				if (req.GetMsgID() != 506807U)
				{
					if (req.GetMsgID() == 506809U)
					{
						SceneDungeonRewardReq sceneDungeonRewardReq = req as SceneDungeonRewardReq;
						if (sceneDungeonRewardReq != null)
						{
							for (int i = 0; i < sceneDungeonRewardReq.dropItemIds.Length; i++)
							{
								this._printDropInfo("发送捡", sceneDungeonRewardReq.dropItemIds[i], false);
							}
						}
					}
					else if (req.GetMsgID() != 506823U)
					{
						if (req.GetMsgID() == 506807U)
						{
							SceneDungeonEnterNextAreaReq sceneDungeonEnterNextAreaReq = req as SceneDungeonEnterNextAreaReq;
							if (sceneDungeonEnterNextAreaReq != null)
							{
							}
						}
						else if (req.GetMsgID() == 606811U)
						{
							WorldDungeonReportFrameReq worldDungeonReportFrameReq = req as WorldDungeonReportFrameReq;
							if (worldDungeonReportFrameReq == null || worldDungeonReportFrameReq.checksums == null || worldDungeonReportFrameReq.frames != null)
							{
							}
						}
					}
				}
			}
			MonoSingleton<NetManager>.instance.SendCommand<T>(ServerType.GATE_SERVER, req);
			return true;
		}
		return false;
	}

	// Token: 0x060174A1 RID: 95393 RVA: 0x0072AD84 File Offset: 0x00729184
	public void SendKillMonsters()
	{
		SceneDungeonKillMonsterReq req = this._getDungenKillMonsterReq();
		this._sendNetMsg2Gate<SceneDungeonKillMonsterReq>(req, "KillMonster");
	}

	// Token: 0x060174A2 RID: 95394 RVA: 0x0072ADA5 File Offset: 0x007291A5
	public bool HasNoVertifyKilledMonsters()
	{
		return !this._isAllSendVertify(this.mAllKillMonster, this.mAllKillMonsterVertify);
	}

	// Token: 0x060174A3 RID: 95395 RVA: 0x0072ADBC File Offset: 0x007291BC
	public void SendNoVertifyKilledMonsters()
	{
		if (this.HasNoVertifyKilledMonsters())
		{
			this._sendNetMsg2Gate<SceneDungeonKillMonsterReq>(this._getDungenNoVertifyKillMonsterReq(), "NoVertify");
		}
	}

	// Token: 0x060174A4 RID: 95396 RVA: 0x0072ADDC File Offset: 0x007291DC
	private SceneDungeonKillMonsterReq _getDungenNoVertifyKillMonsterReq()
	{
		uint[] array = this._getAllNoVertifyItems(this.mAllKillMonster, this.mAllKillMonsterVertify);
		if (array != null && array.Length > 0)
		{
			return new SceneDungeonKillMonsterReq
			{
				monsterIds = array
			};
		}
		return null;
	}

	// Token: 0x060174A5 RID: 95397 RVA: 0x0072AE1C File Offset: 0x0072921C
	private SceneDungeonKillMonsterReq _getDungenKillMonsterReq()
	{
		List<int> killedMonsters = this.mBattleInfo.killedMonsters;
		List<uint> list = new List<uint>();
		for (int i = 0; i < killedMonsters.Count; i++)
		{
			this._addUniqueItem<uint>(this.mAllKillMonster, (uint)killedMonsters[i]);
			if (!this._addUniqueItem<uint>(list, (uint)killedMonsters[i]))
			{
				Logger.LogErrorFormat("[战斗数据] 已经杀死 {0}", new object[]
				{
					killedMonsters[i]
				});
			}
		}
		killedMonsters.Clear();
		if (list.Count > 0)
		{
			return new SceneDungeonKillMonsterReq
			{
				monsterIds = list.ToArray()
			};
		}
		return null;
	}

	// Token: 0x060174A6 RID: 95398 RVA: 0x0072AEC0 File Offset: 0x007292C0
	private void _onSceneDungeonKillMonsterRes(SceneDungeonKillMonsterRes res)
	{
		if (res != null && res.monsterIds != null)
		{
			for (int i = 0; i < res.monsterIds.Length; i++)
			{
				this._addUniqueItem<uint>(this.mAllKillMonsterVertify, res.monsterIds[i]);
			}
		}
	}

	// Token: 0x060174A7 RID: 95399 RVA: 0x0072AF0C File Offset: 0x0072930C
	public void SendSceneDungeonAreaChange(int nextAreaID)
	{
		this._pushAreaEnterIdSceneQueue((uint)nextAreaID);
		this._processAreaEnterIdSendQueue(true);
	}

	// Token: 0x060174A8 RID: 95400 RVA: 0x0072AF1C File Offset: 0x0072931C
	protected void _pushAreaEnterIdSceneQueue(uint areaID)
	{
		if (this.battleType == BattleType.TreasureMap)
		{
			return;
		}
		this.mAreaEnterIdSendQueue.Enqueue(areaID);
	}

	// Token: 0x060174A9 RID: 95401 RVA: 0x0072AF38 File Offset: 0x00729338
	protected void _processAreaEnterIdSendQueue(bool needReport = true)
	{
		if (this.battleType == BattleType.TreasureMap)
		{
			return;
		}
		uint num = this._popAreaEnterIdSendQueue();
		uint num2 = this._getFrontRecivedAreaEnterId();
		this._popRecivedAreaEnterId();
		if (num > 0U)
		{
			if (needReport)
			{
				this._processSendWorldDungeonReportFrame();
			}
			SceneDungeonEnterNextAreaReq sceneDungeonEnterNextAreaReq = new SceneDungeonEnterNextAreaReq
			{
				areaId = num,
				lastFrame = this._getFrameIndexByEnterNextAreaAreaId(num)
			};
			sceneDungeonEnterNextAreaReq.staticVal.values = this._getDungeonEnterNextAreaKeyValueArray();
			if (sceneDungeonEnterNextAreaReq != null)
			{
			}
			MonoSingleton<NetManager>.instance.SendCommand<SceneDungeonEnterNextAreaReq>(ServerType.GATE_SERVER, sceneDungeonEnterNextAreaReq);
		}
	}

	// Token: 0x060174AA RID: 95402 RVA: 0x0072AFBC File Offset: 0x007293BC
	private uint _getFrameIndexByEnterNextAreaAreaId(uint areaID)
	{
		for (int i = 0; i < this.mCacheEnterNextArea.Count; i++)
		{
			if (areaID == this.mCacheEnterNextArea[i].areaID)
			{
				return this.mCacheEnterNextArea[i].lastFrame;
			}
		}
		DungeonDataManager.CacheEnterNextArea cacheEnterNextArea = new DungeonDataManager.CacheEnterNextArea();
		cacheEnterNextArea.areaID = areaID;
		cacheEnterNextArea.lastFrame = this.mLastFrameIndexClientSended;
		this.mCacheEnterNextArea.Add(cacheEnterNextArea);
		return cacheEnterNextArea.lastFrame;
	}

	// Token: 0x060174AB RID: 95403 RVA: 0x0072B03C File Offset: 0x0072943C
	private int[] _getDungeonEnterNextAreaKeyValueArray()
	{
		return new List<int>
		{
			GlobalLogic.VALUE_1,
			GlobalLogic.VALUE_2,
			GlobalLogic.VALUE_5,
			GlobalLogic.VALUE_10,
			GlobalLogic.VALUE_50,
			GlobalLogic.VALUE_60,
			GlobalLogic.VALUE_100,
			GlobalLogic.VALUE_150,
			GlobalLogic.VALUE_200,
			GlobalLogic.VALUE_250,
			GlobalLogic.VALUE_500,
			GlobalLogic.VALUE_700,
			GlobalLogic.VALUE_1000,
			GlobalLogic.VALUE_1500,
			GlobalLogic.VALUE_2000,
			GlobalLogic.VALUE_3600,
			GlobalLogic.VALUE_5000,
			GlobalLogic.VALUE_10000,
			GlobalLogic.VALUE_100000,
			GlobalLogic.VALUE_99999,
			GlobalLogic.VALUE_20000,
			GlobalLogic.VALUE_4000,
			GlobalLogic.VALUE_3000,
			GlobalLogic.VALUE_400,
			GlobalLogic.VALUE_360,
			GlobalLogic.VALUE_300,
			GlobalLogic.VALUE_180,
			GlobalLogic.VALUE_30,
			GlobalLogic.VALUE_3
		}.ToArray();
	}

	// Token: 0x060174AC RID: 95404 RVA: 0x0072B194 File Offset: 0x00729594
	protected uint _getFrontAreaEnterIdSendQueue()
	{
		if (this.mAreaEnterIdSendQueue.Count > 0)
		{
			return this.mAreaEnterIdSendQueue.Peek();
		}
		return 0U;
	}

	// Token: 0x060174AD RID: 95405 RVA: 0x0072B1B4 File Offset: 0x007295B4
	protected uint _getFrontRecivedAreaEnterId()
	{
		if (this.mAreaEnterIdRecivedStack.Count > 0)
		{
			return this.mAreaEnterIdRecivedStack[0];
		}
		return 0U;
	}

	// Token: 0x060174AE RID: 95406 RVA: 0x0072B1D5 File Offset: 0x007295D5
	protected uint _popAreaEnterIdSendQueue()
	{
		if (this.mAreaEnterIdSendQueue.Count > 0)
		{
			return this.mAreaEnterIdSendQueue.Dequeue();
		}
		return 0U;
	}

	// Token: 0x060174AF RID: 95407 RVA: 0x0072B1F5 File Offset: 0x007295F5
	protected void _popRecivedAreaEnterId()
	{
		if (this.mAreaEnterIdRecivedStack.Count > 0)
		{
			this.mAreaEnterIdRecivedStack.RemoveAt(0);
		}
	}

	// Token: 0x060174B0 RID: 95408 RVA: 0x0072B214 File Offset: 0x00729614
	public SceneDungeonEnterNextAreaReq _getDungeonEnterNextAreaReq()
	{
		uint num = (uint)this.CurrentAreaID();
		DungeonDataManager.CacheArea cacheArea = this._currentCacheNode();
		if ((ulong)num == (ulong)((long)cacheArea.area.id))
		{
			return new SceneDungeonEnterNextAreaReq
			{
				areaId = num,
				staticVal = 
				{
					values = this._getDungeonEnterNextAreaKeyValueArray()
				},
				lastFrame = this._getFrameIndexByEnterNextAreaAreaId(num)
			};
		}
		Logger.LogErrorFormat("[战斗数据] 请求进入区域错误  服务端ID {0} 本地ID {1}", new object[]
		{
			cacheArea.area.id,
			num
		});
		return null;
	}

	// Token: 0x060174B1 RID: 95409 RVA: 0x0072B29C File Offset: 0x0072969C
	private void _onSceneDungeonEnterNextAreaRes(SceneDungeonEnterNextAreaRes res)
	{
		if (res.result == 0U)
		{
			this._pushRecivedAreaEnterId(res.areaId);
		}
		else
		{
			Logger.LogErrorFormat("[战斗数据] 无法进入区域 {0}", new object[]
			{
				res.result
			});
		}
	}

	// Token: 0x060174B2 RID: 95410 RVA: 0x0072B2D8 File Offset: 0x007296D8
	protected void _pushRecivedAreaEnterId(uint areaID)
	{
		uint num = this._getLastedRecivedAreaEnterId();
		if (num != areaID)
		{
			this.mAreaEnterIdRecivedStack.Add(areaID);
		}
	}

	// Token: 0x060174B3 RID: 95411 RVA: 0x0072B2FF File Offset: 0x007296FF
	protected uint _getLastedRecivedAreaEnterId()
	{
		if (this.mAreaEnterIdRecivedStack.Count > 0)
		{
			return this.mAreaEnterIdRecivedStack[this.mAreaEnterIdRecivedStack.Count - 1];
		}
		return 0U;
	}

	// Token: 0x060174B4 RID: 95412 RVA: 0x0072B32C File Offset: 0x0072972C
	public void Update(int delta)
	{
		this.mTickTime += delta;
		if (this.mTickTime > 5000)
		{
			this.mTickTime -= 5000;
			this._processSendWorldDungeonReportFrame();
			this._processAreaEnterIdSendQueue(false);
		}
	}

	// Token: 0x060174B5 RID: 95413 RVA: 0x0072B36C File Offset: 0x0072976C
	public void SendPickedDrops()
	{
		SceneDungeonRewardReq req = this._getDungeonRewardReqData();
		this._sendNetMsg2Gate<SceneDungeonRewardReq>(req, "Picked");
	}

	// Token: 0x060174B6 RID: 95414 RVA: 0x0072B390 File Offset: 0x00729790
	public void SendBossDrops()
	{
		SceneDungeonRewardReq req = this._getDungeonBossRewardReqData();
		this._sendNetMsg2Gate<SceneDungeonRewardReq>(req, "BOSS");
	}

	// Token: 0x060174B7 RID: 95415 RVA: 0x0072B3B4 File Offset: 0x007297B4
	public void SendNoVertifyDrops()
	{
		if (this.HasNoVertifyDrops())
		{
			SceneDungeonRewardReq req = this._getDungeonNoVertifyRewardReqData();
			this._sendNetMsg2Gate<SceneDungeonRewardReq>(req, "NoVertify");
		}
	}

	// Token: 0x060174B8 RID: 95416 RVA: 0x0072B3E0 File Offset: 0x007297E0
	public bool HasNoVertifyDrops()
	{
		return !this._isAllSendVertify(this.mAllPickedDrops, this.mAllPickedVertifyDrops);
	}

	// Token: 0x060174B9 RID: 95417 RVA: 0x0072B3F8 File Offset: 0x007297F8
	private SceneDungeonRewardReq _getDungeonNoVertifyRewardReqData()
	{
		SceneDungeonRewardReq sceneDungeonRewardReq = new SceneDungeonRewardReq();
		sceneDungeonRewardReq.dropItemIds = this._getAllNoVertifyItems(this.mAllPickedDrops, this.mAllPickedVertifyDrops);
		if (SwitchFunctionUtility.IsOpen(55))
		{
			if (!this.mBattleEndLock)
			{
				sceneDungeonRewardReq.lastFrame = this.mLastFrameIndexClientSended;
			}
			else
			{
				sceneDungeonRewardReq.lastFrame = this.mFinalFrameIndex;
			}
		}
		else
		{
			sceneDungeonRewardReq.lastFrame = this.mLastFrameIndexClientSended;
		}
		sceneDungeonRewardReq.md5 = this._getRewardRequestMd5Array(sceneDungeonRewardReq.dropItemIds, sceneDungeonRewardReq.lastFrame);
		return sceneDungeonRewardReq;
	}

	// Token: 0x060174BA RID: 95418 RVA: 0x0072B484 File Offset: 0x00729884
	private SceneDungeonRewardReq _getDungeonBossRewardReqData()
	{
		SceneDungeonRewardReq sceneDungeonRewardReq = new SceneDungeonRewardReq();
		List<uint> list = new List<uint>();
		for (int i = 0; i < this.mBattleInfo.bossDropItems.Count; i++)
		{
			uint id = (uint)this.mBattleInfo.bossDropItems[i].id;
			list.Add(id);
			this._addUniqueItem<uint>(this.mAllPickedDrops, id);
		}
		if (list.Count > 0)
		{
			sceneDungeonRewardReq.dropItemIds = list.ToArray();
			if (SwitchFunctionUtility.IsOpen(55))
			{
				if (!this.mBattleEndLock)
				{
					sceneDungeonRewardReq.lastFrame = this.mLastFrameIndexClientSended;
				}
				else
				{
					sceneDungeonRewardReq.lastFrame = this.mFinalFrameIndex;
				}
			}
			else
			{
				sceneDungeonRewardReq.lastFrame = this.mLastFrameIndexClientSended;
			}
			sceneDungeonRewardReq.md5 = this._getRewardRequestMd5Array(sceneDungeonRewardReq.dropItemIds, sceneDungeonRewardReq.lastFrame);
			return sceneDungeonRewardReq;
		}
		return null;
	}

	// Token: 0x060174BB RID: 95419 RVA: 0x0072B564 File Offset: 0x00729964
	private SceneDungeonRewardReq _getDungeonRewardReqData()
	{
		List<int> dropItemIds = this.mBattleInfo.dropItemIds;
		if (dropItemIds.Count > 0)
		{
			SceneDungeonRewardReq sceneDungeonRewardReq = new SceneDungeonRewardReq();
			sceneDungeonRewardReq.dropItemIds = new uint[dropItemIds.Count];
			for (int i = 0; i < dropItemIds.Count; i++)
			{
				uint num = (uint)dropItemIds[i];
				sceneDungeonRewardReq.dropItemIds[i] = num;
				if (!this._addUniqueItem<uint>(this.mAllPickedDrops, num))
				{
				}
			}
			if (SwitchFunctionUtility.IsOpen(55))
			{
				if (!this.mBattleEndLock)
				{
					sceneDungeonRewardReq.lastFrame = this.mLastFrameIndexClientSended;
				}
				else
				{
					sceneDungeonRewardReq.lastFrame = this.mFinalFrameIndex;
				}
			}
			else
			{
				sceneDungeonRewardReq.lastFrame = this.mLastFrameIndexClientSended;
			}
			sceneDungeonRewardReq.md5 = this._getRewardRequestMd5Array(sceneDungeonRewardReq.dropItemIds, sceneDungeonRewardReq.lastFrame);
			dropItemIds.Clear();
			return sceneDungeonRewardReq;
		}
		return null;
	}

	// Token: 0x060174BC RID: 95420 RVA: 0x0072B640 File Offset: 0x00729A40
	private byte[] _getRewardRequestMd5Array(uint[] dropItemIds, uint lastFrame)
	{
		MyExtensionMethods.Clear(this.mRequestRewardBuilder);
		this.mRequestRewardBuilder.Append(lastFrame);
		for (int i = 0; i < dropItemIds.Length; i++)
		{
			this.mRequestRewardBuilder.Append(dropItemIds[i]);
		}
		return DungeonUtility.GetBattleEncryptMD5(this.mRequestRewardBuilder.ToString());
	}

	// Token: 0x060174BD RID: 95421 RVA: 0x0072B698 File Offset: 0x00729A98
	private void _convertDungeonRewardResData(SceneDungeonRewardRes res)
	{
		foreach (uint num in res.pickedItems)
		{
			if (this._addUniqueItem<uint>(this.mAllPickedVertifyDrops, num))
			{
				this._printDropInfo("验证成功", num, false);
			}
			else
			{
				Logger.LogErrorFormat("[战斗数据] 验证捡起掉落 {0}", new object[]
				{
					num
				});
				this._printDropInfo("验证重复", num, true);
			}
		}
	}

	// Token: 0x060174BE RID: 95422 RVA: 0x0072B70E File Offset: 0x00729B0E
	private void _onSceneDungeonRewardRes(SceneDungeonRewardRes res)
	{
		this._convertDungeonRewardResData(res);
	}

	// Token: 0x060174BF RID: 95423 RVA: 0x0072B718 File Offset: 0x00729B18
	private void _checkNoVertifyDrops()
	{
		if (this.HasNoVertifyDrops())
		{
			uint[] array = this._getAllNoVertifyItems(this.mAllPickedDrops, this.mAllPickedVertifyDrops);
			for (int i = 0; i < array.Length; i++)
			{
				this._printDropInfo("!!没有捡到!!", array[i], true);
			}
		}
	}

	// Token: 0x060174C0 RID: 95424 RVA: 0x0072B768 File Offset: 0x00729B68
	public void SendEndDropsRequest(byte multi)
	{
		this._sendNetMsg2Gate<SceneDungeonEndDropReq>(new SceneDungeonEndDropReq
		{
			multi = multi
		}, "结算掉落");
	}

	// Token: 0x060174C1 RID: 95425 RVA: 0x0072B78F File Offset: 0x00729B8F
	public List<DungeonDropItem> GetRaceEndDrops()
	{
		return this.mCachedRaceEndDrops;
	}

	// Token: 0x060174C2 RID: 95426 RVA: 0x0072B797 File Offset: 0x00729B97
	public bool HasRaceDropItem()
	{
		return this.mBattleInfo != null && 0 != this.mBattleInfo.endRaceDropMulti;
	}

	// Token: 0x060174C3 RID: 95427 RVA: 0x0072B7B8 File Offset: 0x00729BB8
	private void _onSceneDungeonEndDropRes(SceneDungeonEndDropRes res)
	{
		this.mBattleInfo.endRaceDropMulti = res.multi;
		this.mCachedRaceEndDrops.Clear();
		if (res.multi != 0)
		{
			for (int i = 0; i < res.items.Length; i++)
			{
				SceneDungeonDropItem sceneDungeonDropItem = res.items[i];
				DungeonDropItem dungeonDropItem = new DungeonDropItem();
				dungeonDropItem.id = (int)sceneDungeonDropItem.id;
				dungeonDropItem.num = (int)sceneDungeonDropItem.num;
				dungeonDropItem.typeId = (int)sceneDungeonDropItem.typeId;
				dungeonDropItem.isDouble = (sceneDungeonDropItem.isDouble == 1);
				dungeonDropItem.strenthLevel = (int)sceneDungeonDropItem.strenth;
				dungeonDropItem.equipType = (EEquipType)sceneDungeonDropItem.equipType;
				this.mCachedRaceEndDrops.Add(dungeonDropItem);
			}
		}
		else
		{
			Logger.LogErrorFormat("[战斗数据] 没有结算掉落", new object[0]);
		}
	}

	// Token: 0x060174C4 RID: 95428 RVA: 0x0072B880 File Offset: 0x00729C80
	private void _onSceneDungeonRaceEndRes(SceneDungeonRaceEndRes res)
	{
	}

	// Token: 0x060174C5 RID: 95429 RVA: 0x0072B884 File Offset: 0x00729C84
	public void SendDungeonEnterRace()
	{
		if (Global.Settings.startSystem == EClientSystem.Battle)
		{
			return;
		}
		WorldDungeonEnterRaceReq cmd = new WorldDungeonEnterRaceReq();
		NetManager.Instance().SendCommand<WorldDungeonEnterRaceReq>(ServerType.GATE_SERVER, cmd);
	}

	// Token: 0x060174C6 RID: 95430 RVA: 0x0072B8B5 File Offset: 0x00729CB5
	public bool HasRecivedDungeonEnterRace()
	{
		return this.mHasRecivedEnterRaceRes;
	}

	// Token: 0x060174C7 RID: 95431 RVA: 0x0072B8BD File Offset: 0x00729CBD
	public void ResendDungeonEnterRace()
	{
		if (!this.HasRecivedDungeonEnterRace())
		{
			this.SendDungeonEnterRace();
		}
	}

	// Token: 0x060174C8 RID: 95432 RVA: 0x0072B8D0 File Offset: 0x00729CD0
	private void _onWorldDungeonEnterRaceRes(WorldDungeonEnterRaceRes res)
	{
		this.mHasRecivedEnterRaceRes = true;
	}

	// Token: 0x060174C9 RID: 95433 RVA: 0x0072B8D9 File Offset: 0x00729CD9
	public uint GetRaceEndFrameIndex()
	{
		return this.mRaceEndFrameIndex;
	}

	// Token: 0x060174CA RID: 95434 RVA: 0x0072B8E1 File Offset: 0x00729CE1
	public uint GetRaceEndRandomNum()
	{
		return this.mRaceEndFrameRandomNum;
	}

	// Token: 0x060174CB RID: 95435 RVA: 0x0072B8E9 File Offset: 0x00729CE9
	public uint GetFinalFrameDataIndex()
	{
		return this.mFinalFrameIndex;
	}

	// Token: 0x060174CC RID: 95436 RVA: 0x0072B8F1 File Offset: 0x00729CF1
	public uint GetFinalRandomNum()
	{
		return this.mFinalFrameRandomNum;
	}

	// Token: 0x060174CD RID: 95437 RVA: 0x0072B8F9 File Offset: 0x00729CF9
	public void LockBattleEnd()
	{
		this.mBattleEndLock = true;
	}

	// Token: 0x060174CE RID: 95438 RVA: 0x0072B902 File Offset: 0x00729D02
	public void FinishUpdateFrameData()
	{
		this.mIsUpdateCheck = false;
	}

	// Token: 0x060174CF RID: 95439 RVA: 0x0072B90C File Offset: 0x00729D0C
	public void PushFinalFrameData()
	{
		if (!this._canProcessDungeonReportFrame())
		{
			return;
		}
		if (this.mIsLockUpdateCheck)
		{
			return;
		}
		uint num = this._pushLastFrameNum2Queue();
		if (num == 0U)
		{
			return;
		}
		this.mIsLockUpdateCheck = true;
		this.mFinalFrameIndex = num;
		this.mFinalFrameRandomNum = 0U;
		DungeonDataManager.FrameRandomNum frameRandomNum = null;
		if (!this.mLocalFrameNumCache.TryGetValue(this.mLastFrameNumIndex, out frameRandomNum))
		{
			Logger.LogErrorFormat("[战斗数据] 找不到随机数 {0}", new object[]
			{
				this.mLastFrameNumIndex
			});
			return;
		}
		this.mFinalFrameRandomNum = frameRandomNum.randomNum;
	}

	// Token: 0x060174D0 RID: 95440 RVA: 0x0072B99C File Offset: 0x00729D9C
	private uint _pushLastFrameNum2Queue()
	{
		if (this.mLastFrameNumIndex <= 0U)
		{
			return 0U;
		}
		DungeonDataManager.FrameRandomNum frameRandomNum = null;
		if (!this.mLocalFrameNumCache.TryGetValue(this.mLastFrameNumIndex, out frameRandomNum))
		{
			Logger.LogErrorFormat("[战斗数据] 找不到随机数 {0}", new object[]
			{
				this.mLastFrameNumIndex
			});
			return 0U;
		}
		DungeonDataManager.FrameNode frameNode = this._findLocalFrameByIndex(frameRandomNum.frameIndex);
		if (frameNode != null)
		{
			if (frameNode.randomNum != frameRandomNum.randomNum)
			{
				Logger.LogErrorFormat("[战斗数据] 随机不不同 {0}->{1}", new object[]
				{
					frameNode.randomNum,
					frameRandomNum.randomNum
				});
			}
		}
		else
		{
			Frame frame = new Frame();
			frame.sequence = frameRandomNum.frameIndex;
			this._enqueuLocalFrameQueue(new DungeonDataManager.FrameNode
			{
				frame = frame,
				randomNum = frameRandomNum.randomNum
			});
		}
		return frameRandomNum.frameIndex;
	}

	// Token: 0x060174D1 RID: 95441 RVA: 0x0072BA7E File Offset: 0x00729E7E
	public void UnlockUpdateCheck()
	{
		this.mIsLockUpdateCheck = false;
	}

	// Token: 0x060174D2 RID: 95442 RVA: 0x0072BA87 File Offset: 0x00729E87
	public bool IsAllReportDataServerRecived()
	{
		return true;
	}

	// Token: 0x060174D3 RID: 95443 RVA: 0x0072BA8C File Offset: 0x00729E8C
	public void PushLocalFrameRandNum(uint frameIndex, uint num)
	{
		if (!this._canProcessDungeonReportFrame())
		{
			return;
		}
		if (this.mLocalFrameNumCache.ContainsKey(frameIndex))
		{
			if (this.mLocalFrameNumCache[frameIndex].randomNum != num)
			{
				Logger.LogErrorFormat("[战斗数据] 已有 帧{0} 随机数 {1}<->{2} 不匹配", new object[]
				{
					this.mLocalFrameNumCache[frameIndex].frameIndex,
					this.mLocalFrameNumCache[frameIndex].randomNum,
					num
				});
			}
		}
		else
		{
			this.mLastFrameNumIndex = frameIndex;
			this.mLocalFrameNumCache.Add(frameIndex, new DungeonDataManager.FrameRandomNum
			{
				frameIndex = frameIndex,
				randomNum = num
			});
		}
	}

	// Token: 0x060174D4 RID: 95444 RVA: 0x0072BB48 File Offset: 0x00729F48
	public void PushLocalFrameData(IFrameCommand frame)
	{
		if (!this._canProcessDungeonReportFrame())
		{
			return;
		}
		if (frame == null)
		{
			return;
		}
		_fighterInput fighterInput = new _fighterInput();
		fighterInput.input = frame.GetInputData();
		fighterInput.seat = frame.GetSeat();
		uint randomNum = this._findFrameRandnumByFrameIndex(frame.GetFrame());
		DungeonDataManager.FrameNode frameNode = this._findLocalFrameByIndex(frame.GetFrame());
		bool flag = false;
		if (frame.GetID() == FrameCommandID.RaceEnd)
		{
			flag = true;
			this.mRaceEndFrameIndex = frame.GetFrame();
		}
		if (frameNode != null)
		{
			if (flag)
			{
				this.mRaceEndFrameRandomNum = frameNode.randomNum;
			}
			frameNode.cacheInputData.Add(fighterInput);
		}
		else
		{
			Frame frame2 = new Frame();
			frame2.data = null;
			frame2.sequence = frame.GetFrame();
			frameNode = new DungeonDataManager.FrameNode();
			frameNode.frame = frame2;
			frameNode.randomNum = randomNum;
			frameNode.cacheInputData.Add(fighterInput);
			if (flag)
			{
				this.mRaceEndFrameRandomNum = randomNum;
			}
			this._enqueuLocalFrameQueue(frameNode);
		}
	}

	// Token: 0x060174D5 RID: 95445 RVA: 0x0072BC38 File Offset: 0x0072A038
	public void SendWorldDungeonReportFrame()
	{
		if (!this._canProcessDungeonReportFrame())
		{
			return;
		}
		WorldDungeonReportFrameReq worldDungeonReportFrameReq = this._getWorldDungeonReportFrameReq();
		if (worldDungeonReportFrameReq == null)
		{
			this._pushLastFrameNum2Queue();
		}
		else
		{
			MonoSingleton<NetManager>.instance.SendCommand<WorldDungeonReportFrameReq>(ServerType.GATE_SERVER, worldDungeonReportFrameReq);
		}
	}

	// Token: 0x060174D6 RID: 95446 RVA: 0x0072BC77 File Offset: 0x0072A077
	private bool _canProcessDungeonReportFrame()
	{
		return this.dungeonMode == eDungeonMode.LocalFrame && this.mBattleType != BattleType.TrainingPVE;
	}

	// Token: 0x060174D7 RID: 95447 RVA: 0x0072BC98 File Offset: 0x0072A098
	public IEnumerator WaitForRaceEndCmdInTime()
	{
		float timeCount = 0f;
		while (this.mRaceEndFrameIndex == 0U)
		{
			timeCount += Time.deltaTime;
			if (timeCount >= 0.1f)
			{
				Logger.LogErrorFormat("raceend超时", new object[0]);
				break;
			}
			yield return Yielders.EndOfFrame;
		}
		yield break;
	}

	// Token: 0x060174D8 RID: 95448 RVA: 0x0072BCB3 File Offset: 0x0072A0B3
	private void _processSendWorldDungeonReportFrame()
	{
		if (!this.mIsUpdateCheck)
		{
			return;
		}
		if (this.mIsLockUpdateCheck)
		{
			return;
		}
		this.SendWorldDungeonReportFrame();
	}

	// Token: 0x060174D9 RID: 95449 RVA: 0x0072BCD4 File Offset: 0x0072A0D4
	private void _removeUnUsedFrameRandeNum(uint endIndex)
	{
		this.mLastFrameReportRand = endIndex / 50U * 50U;
		List<uint> list = new List<uint>();
		Dictionary<uint, DungeonDataManager.FrameRandomNum>.Enumerator enumerator = this.mLocalFrameNumCache.GetEnumerator();
		uint num = 0U;
		while (enumerator.MoveNext())
		{
			KeyValuePair<uint, DungeonDataManager.FrameRandomNum> keyValuePair = enumerator.Current;
			if (keyValuePair.Key <= this.mLastFrameReportRand)
			{
				List<uint> list2 = list;
				KeyValuePair<uint, DungeonDataManager.FrameRandomNum> keyValuePair2 = enumerator.Current;
				list2.Add(keyValuePair2.Key);
			}
			else
			{
				uint num2 = num;
				KeyValuePair<uint, DungeonDataManager.FrameRandomNum> keyValuePair3 = enumerator.Current;
				if (num2 < keyValuePair3.Key)
				{
					KeyValuePair<uint, DungeonDataManager.FrameRandomNum> keyValuePair4 = enumerator.Current;
					num = keyValuePair4.Key;
				}
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			this.mLocalFrameNumCache.Remove(list[i]);
		}
	}

	// Token: 0x060174DA RID: 95450 RVA: 0x0072BD9E File Offset: 0x0072A19E
	private uint _findFrameRandnumByFrameIndex(uint frameIndex)
	{
		if (this.mLocalFrameNumCache.ContainsKey(frameIndex))
		{
			return this.mLocalFrameNumCache[frameIndex].randomNum;
		}
		return 0U;
	}

	// Token: 0x060174DB RID: 95451 RVA: 0x0072BDC4 File Offset: 0x0072A1C4
	private bool _removeFrameRandumByFrameIndex(uint frameIndex)
	{
		if (this.mLocalFrameNumCache.Count > 1 && this.mLocalFrameNumCache.ContainsKey(frameIndex))
		{
			this.mLocalFrameNumCache.Remove(frameIndex);
			return true;
		}
		return false;
	}

	// Token: 0x060174DC RID: 95452 RVA: 0x0072BDF8 File Offset: 0x0072A1F8
	public void ResetLastFrameIndexClientSendedToServerRecived()
	{
		this.mLastFrameIndexClientSended = this.mLastFrameIndexServerRecived;
	}

	// Token: 0x060174DD RID: 95453 RVA: 0x0072BE08 File Offset: 0x0072A208
	private WorldDungeonReportFrameReq _getWorldDungeonReportFrameReq()
	{
		this.mCacheFrameList.Clear();
		this.mCacheFrameCheckSum.Clear();
		uint num = 0U;
		bool flag = false;
		List<int> list = new List<int>();
		int num2 = 0;
		while (num2 < this.mLocalFrameQueue.Count && num2 < 128)
		{
			DungeonDataManager.FrameNode frameNode = this.mLocalFrameQueue[num2];
			if (this.mLastFrameIndexClientSended < frameNode.frame.sequence)
			{
				if (frameNode.frame.data == null)
				{
					frameNode.frame.data = frameNode.cacheInputData.ToArray();
				}
				if (!flag)
				{
					flag = true;
					uint sequence = frameNode.frame.sequence;
				}
				num = frameNode.frame.sequence;
				list.Add(num2);
				this.mCacheFrameList.Add(frameNode.frame);
			}
			num2++;
		}
		this._tryAppendCheckSum(num);
		if (this.mCacheFrameList.Count <= 0 && this.mCacheFrameCheckSum.Count <= 0)
		{
			return null;
		}
		this._removeUnUsedFrameRandeNum(num);
		for (int i = list.Count - 1; i >= 0; i--)
		{
			this.mLocalFrameQueue.RemoveAt(list[i]);
		}
		WorldDungeonReportFrameReq worldDungeonReportFrameReq = new WorldDungeonReportFrameReq();
		worldDungeonReportFrameReq.frames = this.mCacheFrameList.ToArray();
		worldDungeonReportFrameReq.checksums = this.mCacheFrameCheckSum.ToArray();
		this.mLastFrameIndexClientSended = num;
		return worldDungeonReportFrameReq;
	}

	// Token: 0x060174DE RID: 95454 RVA: 0x0072BF84 File Offset: 0x0072A384
	private void _removeServerRecivedFrame()
	{
		bool flag = false;
		while (!this._isLocalFrameQueueEmpty() && this._isLocalFrameQueueContainInvalidFrame())
		{
			DungeonDataManager.FrameNode frameNode = this._dequeuLocalFrameQueue();
			if (frameNode == null)
			{
				break;
			}
			if (!flag)
			{
				uint sequence = frameNode.frame.sequence;
			}
			uint sequence2 = frameNode.frame.sequence;
			flag = true;
		}
		if (flag)
		{
		}
	}

	// Token: 0x060174DF RID: 95455 RVA: 0x0072BFF0 File Offset: 0x0072A3F0
	private bool _isLocalFrameQueueContainInvalidFrame()
	{
		if (!this.mHasGetFrameIndexServerRecived)
		{
			return false;
		}
		DungeonDataManager.FrameNode frameNode = this._getFrontLocalFrameQueue();
		return frameNode.frame == null || frameNode.frame.sequence <= this.mLastFrameIndexServerRecived;
	}

	// Token: 0x060174E0 RID: 95456 RVA: 0x0072C034 File Offset: 0x0072A434
	private bool _isLocalFrameQueueEmpty()
	{
		return this.mLocalFrameQueue.Count <= 0;
	}

	// Token: 0x060174E1 RID: 95457 RVA: 0x0072C048 File Offset: 0x0072A448
	private DungeonDataManager.FrameNode _findLocalFrameByIndex(uint frameIndex)
	{
		for (int i = 0; i < this.mLocalFrameQueue.Count; i++)
		{
			if (frameIndex == this.mLocalFrameQueue[i].frame.sequence)
			{
				return this.mLocalFrameQueue[i];
			}
		}
		return null;
	}

	// Token: 0x060174E2 RID: 95458 RVA: 0x0072C09C File Offset: 0x0072A49C
	private DungeonDataManager.FrameNode _getFrontLocalFrameQueue()
	{
		int count = this.mLocalFrameQueue.Count;
		if (count <= 0)
		{
			Logger.LogErrorFormat("[战斗数据] 队列为空", new object[0]);
			return null;
		}
		return this.mLocalFrameQueue[0];
	}

	// Token: 0x060174E3 RID: 95459 RVA: 0x0072C0DA File Offset: 0x0072A4DA
	private void _enqueuLocalFrameQueue(DungeonDataManager.FrameNode node)
	{
		this.mLocalFrameQueue.Add(node);
	}

	// Token: 0x060174E4 RID: 95460 RVA: 0x0072C0E8 File Offset: 0x0072A4E8
	private DungeonDataManager.FrameNode _dequeuLocalFrameQueue()
	{
		int count = this.mLocalFrameQueue.Count;
		if (count <= 0)
		{
			return null;
		}
		DungeonDataManager.FrameNode result = this.mLocalFrameQueue[0];
		this.mLocalFrameQueue.RemoveAt(0);
		return result;
	}

	// Token: 0x060174E5 RID: 95461 RVA: 0x0072C124 File Offset: 0x0072A524
	private void _tryAppendCheckSum(uint end)
	{
		uint num = end / 50U * 50U;
		if (num <= 0U)
		{
			return;
		}
		uint num2 = this.mLastFrameIndexClientSended / 50U * 50U + 50U;
		bool flag = false;
		while (num2 <= end)
		{
			flag = true;
			this._addFrameCheckSum(num2);
			num2 += 50U;
		}
		if (!flag)
		{
			this._addFrameCheckSum(num);
		}
	}

	// Token: 0x060174E6 RID: 95462 RVA: 0x0072C17C File Offset: 0x0072A57C
	public void _tryRemoveCheckSum(uint end)
	{
		uint num = end / 50U * 50U;
		if (num <= 0U)
		{
			return;
		}
		uint num2 = this.mLastFrameReportRand + 50U;
		bool flag = false;
		while (num2 <= end)
		{
			flag = true;
			this._removeFrameRandumByFrameIndex(num2);
			num2 += 50U;
		}
		if (!flag)
		{
			this._removeFrameRandumByFrameIndex(num);
		}
	}

	// Token: 0x060174E7 RID: 95463 RVA: 0x0072C1D0 File Offset: 0x0072A5D0
	private void _addFrameCheckSum(uint frameIndex)
	{
		uint checksum = this._findFrameRandnumByFrameIndex(frameIndex);
		this.mCacheFrameCheckSum.Add(new FrameChecksum
		{
			frame = frameIndex,
			checksum = checksum
		});
	}

	// Token: 0x060174E8 RID: 95464 RVA: 0x0072C205 File Offset: 0x0072A605
	private void _onWorldDungeonReportFrameRes(WorldDungeonReportFrameRes res)
	{
		if (res.lastFrame == this.mLastFrameIndexClientSended || Singleton<RecordServer>.GetInstance() != null)
		{
		}
	}

	// Token: 0x060174E9 RID: 95465 RVA: 0x0072C222 File Offset: 0x0072A622
	private void _onWorldDungeonReportEquipRes(WorldDungeonNotifyGetYellowEquip res)
	{
		if (res != null)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTeamMateDropSS, res.roleId, res.itemId, null, null);
		}
	}

	// Token: 0x060174EA RID: 95466 RVA: 0x0072C254 File Offset: 0x0072A654
	private DungeonDropItem _getDungeonDropItemByID(uint dropId)
	{
		List<DungeonDropItem> dropItems = this.mBattleInfo.dropItems;
		for (int i = 0; i < dropItems.Count; i++)
		{
			if ((long)dropItems[i].id == (long)((ulong)dropId))
			{
				return dropItems[i];
			}
		}
		return null;
	}

	// Token: 0x060174EB RID: 95467 RVA: 0x0072C2A4 File Offset: 0x0072A6A4
	private void _printDropInfoByItemID(string tag, uint id, uint itemID, uint count, bool isError)
	{
		ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>((int)itemID, string.Empty, string.Empty);
		if (tableItem != null && isError)
		{
			Logger.LogErrorFormat("[战斗数据] {0} 道具 ID: {1}({2}), 名字 {3}, 数量 {4}", new object[]
			{
				tag,
				id,
				itemID,
				tableItem.Name,
				count
			});
		}
	}

	// Token: 0x060174EC RID: 95468 RVA: 0x0072C314 File Offset: 0x0072A714
	private void _printDropInfo(string tag, uint id, bool isError = false)
	{
		DungeonDropItem dungeonDropItem = this._getDungeonDropItemByID(id);
		if (dungeonDropItem != null)
		{
			this._printDropInfoByItemID(tag, (uint)dungeonDropItem.id, (uint)dungeonDropItem.typeId, (uint)dungeonDropItem.num, isError);
		}
	}

	// Token: 0x060174ED RID: 95469 RVA: 0x0072C349 File Offset: 0x0072A749
	private void _printMonsterInfo(uint id)
	{
	}

	// Token: 0x060174EE RID: 95470 RVA: 0x0072C34B File Offset: 0x0072A74B
	public bool IsYiJieCheckPoint()
	{
		return this.mTable != null && this.mTable.SubType == DungeonTable.eSubType.S_DEVILDDOM;
	}

	// Token: 0x060174EF RID: 95471 RVA: 0x0072C36C File Offset: 0x0072A76C
	public bool IsHunDunCheckPoint()
	{
		return this.mTable != null && (this.mTable.SubType == DungeonTable.eSubType.S_WEEK_HELL_PER || this.mTable.SubType == DungeonTable.eSubType.S_WEEK_HELL_ENTRY || this.mTable.SubType == DungeonTable.eSubType.S_WEEK_HELL);
	}

	// Token: 0x04010BD1 RID: 68561
	protected DungeonID mID;

	// Token: 0x04010BD2 RID: 68562
	protected eDungeonMode mDungeonMode;

	// Token: 0x04010BD3 RID: 68563
	protected BattleType mBattleType = BattleType.None;

	// Token: 0x04010BD4 RID: 68564
	protected DungeonTable mTable;

	// Token: 0x04010BD5 RID: 68565
	protected DungeonUIConfigTable mConfigTable;

	// Token: 0x04010BD6 RID: 68566
	protected IDungeonData mAsset;

	// Token: 0x04010BD7 RID: 68567
	protected BattleInfo mBattleInfo;

	// Token: 0x04010BD8 RID: 68568
	protected List<DungeonDataManager.CacheArea> mCacheAreaList = new List<DungeonDataManager.CacheArea>();

	// Token: 0x04010BD9 RID: 68569
	private int mLastIndex = -1;

	// Token: 0x04010BDA RID: 68570
	private int mCurrentIndex = -1;

	// Token: 0x04010BDB RID: 68571
	private TransportDoorType mLastDoorType;

	// Token: 0x04010BDD RID: 68573
	public ISceneTransportDoorData door;

	// Token: 0x04010BDE RID: 68574
	private DungeonAddMonsterDropItem mSearchOp = new DungeonAddMonsterDropItem();

	// Token: 0x04010BDF RID: 68575
	private List<int> sDefautlRegions = new List<int>();

	// Token: 0x04010BE0 RID: 68576
	private List<DungeonDoor> mDoors = new List<DungeonDoor>();

	// Token: 0x04010BE1 RID: 68577
	private List<DungeonStatistics> mAllDungeonStatistics = new List<DungeonStatistics>();

	// Token: 0x04010BE2 RID: 68578
	private List<DungeonStatistics> mStatistics = new List<DungeonStatistics>();

	// Token: 0x04010BE3 RID: 68579
	protected List<uint> mAllKillMonster = new List<uint>();

	// Token: 0x04010BE4 RID: 68580
	protected List<uint> mAllKillMonsterVertify = new List<uint>();

	// Token: 0x04010BE5 RID: 68581
	protected Queue<uint> mAreaEnterIdSendQueue = new Queue<uint>();

	// Token: 0x04010BE6 RID: 68582
	protected List<uint> mAreaEnterIdRecivedStack = new List<uint>();

	// Token: 0x04010BE7 RID: 68583
	protected List<DungeonDataManager.CacheEnterNextArea> mCacheEnterNextArea = new List<DungeonDataManager.CacheEnterNextArea>();

	// Token: 0x04010BE8 RID: 68584
	protected const int kTickTimeGap = 5000;

	// Token: 0x04010BE9 RID: 68585
	protected int mTickTime;

	// Token: 0x04010BEA RID: 68586
	protected List<uint> mAllPickedDrops = new List<uint>();

	// Token: 0x04010BEB RID: 68587
	protected List<uint> mAllPickedVertifyDrops = new List<uint>();

	// Token: 0x04010BEC RID: 68588
	private StringBuilder mRequestRewardBuilder = new StringBuilder();

	// Token: 0x04010BED RID: 68589
	private List<DungeonDropItem> mCachedRaceEndDrops = new List<DungeonDropItem>();

	// Token: 0x04010BEE RID: 68590
	private bool mHasRecivedEnterRaceRes;

	// Token: 0x04010BEF RID: 68591
	private const uint kInvalidFrameRandomNum = 0U;

	// Token: 0x04010BF0 RID: 68592
	private const int kMaxFrameSize = 128;

	// Token: 0x04010BF1 RID: 68593
	private const int kCheckSumSplit = 50;

	// Token: 0x04010BF2 RID: 68594
	private uint mLastFrameIndexServerRecived;

	// Token: 0x04010BF3 RID: 68595
	private uint mLastFrameIndexClientSended;

	// Token: 0x04010BF4 RID: 68596
	private bool mHasGetFrameIndexServerRecived;

	// Token: 0x04010BF5 RID: 68597
	private bool mIsUpdateCheck = true;

	// Token: 0x04010BF6 RID: 68598
	private bool mIsLockUpdateCheck;

	// Token: 0x04010BF7 RID: 68599
	private uint mLastFrameReportRand;

	// Token: 0x04010BF8 RID: 68600
	private uint mFinalFrameIndex;

	// Token: 0x04010BF9 RID: 68601
	private uint mFinalFrameRandomNum;

	// Token: 0x04010BFA RID: 68602
	private uint mRaceEndFrameIndex;

	// Token: 0x04010BFB RID: 68603
	private uint mRaceEndFrameRandomNum;

	// Token: 0x04010BFC RID: 68604
	private List<DungeonDataManager.FrameNode> mLocalFrameQueue = new List<DungeonDataManager.FrameNode>();

	// Token: 0x04010BFD RID: 68605
	private Dictionary<uint, DungeonDataManager.FrameRandomNum> mLocalFrameNumCache = new Dictionary<uint, DungeonDataManager.FrameRandomNum>();

	// Token: 0x04010BFE RID: 68606
	private uint mLastFrameNumIndex;

	// Token: 0x04010BFF RID: 68607
	private List<Frame> mCacheFrameList = new List<Frame>();

	// Token: 0x04010C00 RID: 68608
	private List<FrameChecksum> mCacheFrameCheckSum = new List<FrameChecksum>();

	// Token: 0x04010C01 RID: 68609
	private bool mBattleEndLock;

	// Token: 0x020041DB RID: 16859
	public struct PreloadData
	{
		// Token: 0x060174F1 RID: 95473 RVA: 0x0072C3E5 File Offset: 0x0072A7E5
		public PreloadData(string path, int num)
		{
			this.resPath = path;
			this.num = num;
		}

		// Token: 0x04010C03 RID: 68611
		public string resPath;

		// Token: 0x04010C04 RID: 68612
		public int num;
	}

	// Token: 0x020041DC RID: 16860
	protected class CacheArea
	{
		// Token: 0x04010C05 RID: 68613
		public bool visited;

		// Token: 0x04010C06 RID: 68614
		public List<int> toboss;

		// Token: 0x04010C07 RID: 68615
		public List<int> toZhuzi;

		// Token: 0x04010C08 RID: 68616
		public DungeonArea area;

		// Token: 0x04010C09 RID: 68617
		public Battle.DungeonHellInfo hell;

		// Token: 0x04010C0A RID: 68618
		public DungeonStatistics statistics;

		// Token: 0x04010C0B RID: 68619
		public List<uint> killdMonster;

		// Token: 0x04010C0C RID: 68620
		public List<uint> pickedItems;

		// Token: 0x04010C0D RID: 68621
		public List<CustomSceneRegionInfo> dynamicRegionInfoes;

		// Token: 0x04010C0E RID: 68622
		public List<int> dynamicRegions;
	}

	// Token: 0x020041DD RID: 16861
	protected class CacheEnterNextArea
	{
		// Token: 0x04010C0F RID: 68623
		public uint areaID;

		// Token: 0x04010C10 RID: 68624
		public uint lastFrame;
	}

	// Token: 0x020041DE RID: 16862
	private class FrameNode
	{
		// Token: 0x04010C11 RID: 68625
		public Frame frame;

		// Token: 0x04010C12 RID: 68626
		public uint randomNum;

		// Token: 0x04010C13 RID: 68627
		public List<_fighterInput> cacheInputData = new List<_fighterInput>();
	}

	// Token: 0x020041DF RID: 16863
	private class FrameRandomNum
	{
		// Token: 0x04010C14 RID: 68628
		public uint frameIndex;

		// Token: 0x04010C15 RID: 68629
		public uint randomNum;
	}
}
