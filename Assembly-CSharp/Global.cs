using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000131 RID: 305
public class Global
{
	// Token: 0x17000158 RID: 344
	// (get) Token: 0x06000896 RID: 2198 RVA: 0x0002DDA6 File Offset: 0x0002C1A6
	// (set) Token: 0x06000897 RID: 2199 RVA: 0x0002DDE6 File Offset: 0x0002C1E6
	public static GlobalSetting Settings
	{
		get
		{
			if (null == Global.settings)
			{
				Global.settings = Resources.Load<GlobalSetting>(PathUtil.EraseExtension("Base/GlobalSettings"));
				Global._loadSdkFromFile();
				if (Global.settings == null)
				{
				}
			}
			return Global.settings;
		}
		set
		{
			Global.settings = value;
		}
	}

	// Token: 0x06000898 RID: 2200 RVA: 0x0002DDF0 File Offset: 0x0002C1F0
	private static void _loadSdkFromFile()
	{
		if (null == Global.settings)
		{
			return;
		}
		string value = SDKChannel.NONE.ToString();
		if (FileArchiveAccessor.LoadFileInLocalFileArchive(Global.kSDKConfigFileName, out value))
		{
			try
			{
				Global.settings.sdkChannel = (SDKChannel)Enum.Parse(typeof(SDKChannel), value, true);
				Global.channelName = Global.SDKChannelName[(int)Global.Settings.sdkChannel];
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("[SDKConfig] 解析 {0} 失败, {1}", new object[]
				{
					Global.kSDKConfigFileName,
					ex.ToString()
				});
			}
		}
		else
		{
			Logger.LogErrorFormat("[SDKConfig] 加载 {0} 失败", new object[]
			{
				Global.kSDKConfigFileName
			});
		}
	}

	// Token: 0x06000899 RID: 2201 RVA: 0x0002DEC0 File Offset: 0x0002C2C0
	public static string GetAttributeString(AttributeType att)
	{
		if (Global.attributeStringMap.ContainsKey((int)att))
		{
			return Global.attributeStringMap[(int)att];
		}
		string name = Enum.GetName(typeof(AttributeType), att);
		Global.attributeStringMap[(int)att] = name;
		return name;
	}

	// Token: 0x040005B0 RID: 1456
	public const int HELP_SKILL_ID = 10000;

	// Token: 0x040005B1 RID: 1457
	public const int DUNFU_SKILL_ID = 10001;

	// Token: 0x040005B2 RID: 1458
	public const int FAKEREBORN_SKILL_ID = 10002;

	// Token: 0x040005B3 RID: 1459
	public const int GOLD_ITEM_ID = 600000001;

	// Token: 0x040005B4 RID: 1460
	public const int GOLD_ITEM_ID2 = 600000007;

	// Token: 0x040005B5 RID: 1461
	public const int CRYSTAL_ITEM_ID = 300000106;

	// Token: 0x040005B6 RID: 1462
	public const int MAX_PROFESSION = 100;

	// Token: 0x040005B7 RID: 1463
	public const int REBORN_COIN_COST_NUM = 1;

	// Token: 0x040005B8 RID: 1464
	public const int TEAM_TRANSPORT_NUM = 2;

	// Token: 0x040005B9 RID: 1465
	public const int MAX_TEAM_PLAYER_NUM = 4;

	// Token: 0x040005BA RID: 1466
	public const int SUMMON_MONSTER_OCCU_ID = 99;

	// Token: 0x040005BB RID: 1467
	public const int BODONGKEYIN_SKILL_ID = 1710;

	// Token: 0x040005BC RID: 1468
	public const int ABNORMAL_COUNT = 13;

	// Token: 0x040005BD RID: 1469
	public const int ELEMENT_COUNT = 4;

	// Token: 0x040005BE RID: 1470
	public static ScreenOrientation screenOrientation = 0;

	// Token: 0x040005BF RID: 1471
	public const string GLOBAL_SERVER_ADDRESS = "121.41.17.47";

	// Token: 0x040005C0 RID: 1472
	public static string ROLE_SAVEDATA_SERVER_ADDRESS = "ald.rdjnc.com";

	// Token: 0x040005C1 RID: 1473
	public static string ROLE_QUERY_OPENID_ADDRESS = "43.241.19.219:58004";

	// Token: 0x040005C2 RID: 1474
	public static string RECORDLOG_GET_ADDRESS = "43.241.19.219:11111";

	// Token: 0x040005C3 RID: 1475
	public static string RECORDLOG_POST_ADDRESS = "43.241.19.219:11111";

	// Token: 0x040005C4 RID: 1476
	public static string BATTLE_PERFORMANCE_POST_ADDRESS = "43.241.19.219:11111";

	// Token: 0x040005C5 RID: 1477
	public static string ENET_LOG_SERVER_ADDRESS = "43.241.19.219:59970";

	// Token: 0x040005C6 RID: 1478
	public static string LOGIN_SERVER_ADDRESS = "43.241.19.219:6667";

	// Token: 0x040005C7 RID: 1479
	public static string PUBLISH_SERVER_ADDRESS = "ald.rdjnc.com";

	// Token: 0x040005C8 RID: 1480
	public static string STATISTIC_SERVER_ADDRESS = "43.241.19.219:59236";

	// Token: 0x040005C9 RID: 1481
	public static string STATISTIC2_SERVER_ADDRESS = "43.241.19.219:55563";

	// Token: 0x040005CA RID: 1482
	public static string VOICE_SERVER_ADDRESS = "43.241.19.219:56563";

	// Token: 0x040005CB RID: 1483
	public static string VERIFY_BIND_PHONE_ADDRESS = "43.241.19.219:19558";

	// Token: 0x040005CC RID: 1484
	public static string ONLINE_SERVICE_ADDRESS = "43.241.19.219";

	// Token: 0x040005CD RID: 1485
	public static string ONLINE_SERVICE_REQ_ADDRESS = "43.241.19.219";

	// Token: 0x040005CE RID: 1486
	public static string ANDROID_MG_CHARGE = "43.241.19.219:58002";

	// Token: 0x040005CF RID: 1487
	public static string ROLE_SAVEDATA_SERVER_ADDRESS_HW = "43.241.19.219:58003";

	// Token: 0x040005D0 RID: 1488
	public static string IOS_ZY_CHARGE = "43.241.19.219:56352";

	// Token: 0x040005D1 RID: 1489
	public static string IOS_BANQUAN_ADDRESS = "192.168.2.95:19268";

	// Token: 0x040005D2 RID: 1490
	public static string USER_AGREEMENT_SERVER_ADDRESS = "43.241.19.219:58125";

	// Token: 0x040005D3 RID: 1491
	public static string ONLINE_SERVICE_VIP_CHECK_ADDRESS = "xxx.com/services/custom";

	// Token: 0x040005D4 RID: 1492
	public static string REDPACKRANK_SERVICE_ADDRESS = "192.168.2.50:58300";

	// Token: 0x040005D5 RID: 1493
	public static string BANGBANGEVERISK_SERVICE_ADDRESS = "43.241.19.219:58005/custom";

	// Token: 0x040005D6 RID: 1494
	public const string ATTACH_NAME_ORIGIN = "[actor]Orign";

	// Token: 0x040005D7 RID: 1495
	public const string FOOT_INDICATOR_ATTACH_NAME = "Aureole";

	// Token: 0x040005D8 RID: 1496
	public const string HALO_ATTACH_NAME = "halo";

	// Token: 0x040005D9 RID: 1497
	public const string HALO_LOCATOR_NAME = "[actor]Orign";

	// Token: 0x040005DA RID: 1498
	public const string WEAPON_ATTACH_NAME = "weapon";

	// Token: 0x040005DB RID: 1499
	public const string WING_ATTACH_NAME = "wing";

	// Token: 0x040005DC RID: 1500
	public const string WING_LOCATOR_NAME = "[actor]Back";

	// Token: 0x040005DD RID: 1501
	public const string STRENGTH_NAME = "强化1";

	// Token: 0x040005DE RID: 1502
	public const string WEAPON_SWORD_NAME = "sword";

	// Token: 0x040005DF RID: 1503
	public const string WEAPON_GUN_NAME = "gun";

	// Token: 0x040005E0 RID: 1504
	public const string WEAPON_MAGE_NAME = "magegirl";

	// Token: 0x040005E1 RID: 1505
	public const string WEAPON_FIGHTER_NAME = "fighter";

	// Token: 0x040005E2 RID: 1506
	public const string STRENGTH_SWORD_NAME = "Sword_Effect";

	// Token: 0x040005E3 RID: 1507
	public const string STRENGTH_GUN_NAME = "Gun_Effect";

	// Token: 0x040005E4 RID: 1508
	public const string STRENGTH_MAGE_NAME = "Mage_Effect";

	// Token: 0x040005E5 RID: 1509
	public const string STRENGTH_FIGHTER_NAME = "Fighter_Effect";

	// Token: 0x040005E6 RID: 1510
	public const string STRENGTH_NIANZHU_NAME = "Paladin_Nianzhu_Effect";

	// Token: 0x040005E7 RID: 1511
	public const string STRENGTH_COMMON_NAME = "Paladin_Liandao_Effect";

	// Token: 0x040005E8 RID: 1512
	public const string WEAPON_LIANDAO_NAME = "Paladin_liandao";

	// Token: 0x040005E9 RID: 1513
	public const string WEAPON_NIANZHU_NAME = "Paladin_nianzhu";

	// Token: 0x040005EA RID: 1514
	public const string WEAPON_ZHANFU_NAME = "Paladin_zhanfu";

	// Token: 0x040005EB RID: 1515
	public const string WEAPON_SHIZIJIA_NAME = "Paladin_shizijia";

	// Token: 0x040005EC RID: 1516
	public const string ACTION_EXPDEAD = "ExpDead";

	// Token: 0x040005ED RID: 1517
	public const string ACTION_EXPDEAD2 = "Expdead2";

	// Token: 0x040005EE RID: 1518
	public const string ACTION_EXPDEAD3 = "Expdead3";

	// Token: 0x040005EF RID: 1519
	public const string ACTION_HITGROUNDDEAD = "HitGroundDead";

	// Token: 0x040005F0 RID: 1520
	public const int PK_TOTAL_TIME = 240;

	// Token: 0x040005F1 RID: 1521
	public const int PK_COUNTDOWN_TIME = 4;

	// Token: 0x040005F2 RID: 1522
	public const int REVIVE_SHOCK_SKILLID = 9998;

	// Token: 0x040005F3 RID: 1523
	public const string COMMON_SOUND_OPEN_FRAME = "Sound/UI/ui_window_open";

	// Token: 0x040005F4 RID: 1524
	public const string COMMON_SOUND_CLOSE_FRAME = "Sound/UI/ui_window_close";

	// Token: 0x040005F5 RID: 1525
	public const PreloadMode PRELOAD_MODE = PreloadMode.PART_NO_AUDIO;

	// Token: 0x040005F6 RID: 1526
	public static string[] SDKChannelName = new string[]
	{
		"none",
		"xy",
		"i4",
		"tb",
		"mg",
		"7977",
		"mg",
		"mgyyb",
		"mg2other",
		"mg2hc",
		"hw",
		"oppo",
		"vivo",
		"lenovo",
		"kupai",
		"jinli",
		"meizu",
		"baidu",
		"xiaomi",
		"uc",
		"samsung",
		"4399",
		"360",
		"915",
		"junhai",
		"joyland",
		"zy",
		"zy",
		"zy",
		"zy",
		"zy",
		"zy",
		"zy",
		"zy",
		"zy",
		"zy",
		"zy",
		"zy",
		"zy",
		"mg",
		"cc",
		"mgdy",
		"cc",
		"mgto915",
		"zy"
	};

	// Token: 0x040005F7 RID: 1527
	public static string channelName = "none";

	// Token: 0x040005F8 RID: 1528
	public static SDKChannel[] VipAuthSDKChannel = new SDKChannel[0];

	// Token: 0x040005F9 RID: 1529
	public static SDKChannel[] RealNamePopWindowsChannel = new SDKChannel[0];

	// Token: 0x040005FA RID: 1530
	public static SDKChannel[] SDKPushChannel = new SDKChannel[0];

	// Token: 0x040005FB RID: 1531
	public static bool BuglyEnable = false;

	// Token: 0x040005FC RID: 1532
	public static SDKChannel[] openSelectChannels = new SDKChannel[0];

	// Token: 0x040005FD RID: 1533
	public static int TriggerEventStackLevelLimit = 10;

	// Token: 0x040005FE RID: 1534
	public static int TriggerSingleEventStackLevelLimit = 5;

	// Token: 0x040005FF RID: 1535
	public static int MaxStackLevelLogLimit = 30;

	// Token: 0x04000600 RID: 1536
	public const string PATH = "Base/GlobalSettings";

	// Token: 0x04000601 RID: 1537
	private static GlobalSetting settings = null;

	// Token: 0x04000602 RID: 1538
	public static string[] AbnormalNames = new string[]
	{
		"感电",
		"出血",
		"灼烧",
		"中毒",
		"失明",
		"眩晕",
		"石化",
		"冰冻",
		"睡眠",
		"混乱",
		"束缚",
		"减速",
		"诅咒"
	};

	// Token: 0x04000603 RID: 1539
	public static Dictionary<string, string> equipThirdTypeNames = new Dictionary<string, string>
	{
		{
			"HUGESWORD",
			"巨剑"
		},
		{
			"KATANA",
			"太刀"
		},
		{
			"SHORTSWORD",
			"短剑"
		},
		{
			"BEAMSWORD",
			"光剑"
		},
		{
			"BLUNT",
			"钝器"
		},
		{
			"REVOLVER",
			"左轮"
		},
		{
			"CROSSBOW",
			"弩"
		},
		{
			"HANDCANNON",
			"手炮"
		},
		{
			"RIFLE",
			"步枪"
		},
		{
			"PISTOL",
			"手枪"
		},
		{
			"STAFF",
			"法杖"
		},
		{
			"WAND",
			"魔杖"
		},
		{
			"SPEAR",
			"矛"
		},
		{
			"STICK",
			"棍棒"
		},
		{
			"CLOTH",
			"布甲"
		},
		{
			"SKIN",
			"皮甲"
		},
		{
			"LIGHT",
			"轻甲"
		},
		{
			"HEAVY",
			"重甲"
		},
		{
			"PLATE",
			"板甲"
		}
	};

	// Token: 0x04000604 RID: 1540
	public static List<string> equipThirdTypeNamesList = new List<string>
	{
		"HUGESWORD",
		"KATANA",
		"SHORTSWORD",
		"BEAMSWORD",
		"BLUNT",
		"REVOLVER",
		"CROSSBOW",
		"HANDCANNON",
		"RIFLE",
		"PISTOL",
		"STAFF",
		"WAND",
		"SPEAR",
		"STICK",
		"CLOTH",
		"SKIN",
		"LIGHT",
		"HEAVY",
		"PLATE"
	};

	// Token: 0x04000605 RID: 1541
	public static Dictionary<string, int> equipPropExtra = new Dictionary<string, int>
	{
		{
			"maxHp",
			1
		},
		{
			"maxMp",
			1
		},
		{
			"hpRecover",
			1
		},
		{
			"mpRecover",
			1
		},
		{
			"attack",
			1
		},
		{
			"magicAttack",
			1
		},
		{
			"defence",
			1
		},
		{
			"magicDefence",
			1
		},
		{
			"attackSpeed",
			10
		},
		{
			"spellSpeed",
			10
		},
		{
			"moveSpeed",
			10
		},
		{
			"ciriticalAttack",
			10
		},
		{
			"ciriticalMagicAttack",
			10
		},
		{
			"dex",
			10
		},
		{
			"dodge",
			10
		},
		{
			"frozen",
			1
		},
		{
			"hard",
			1
		},
		{
			"baseAtk",
			1000
		},
		{
			"baseInt",
			1000
		},
		{
			"baseSta",
			1000
		},
		{
			"baseSpr",
			1000
		},
		{
			"attackReduceFix",
			1
		},
		{
			"magicAttackReduceFix",
			1
		},
		{
			"ignoreDefAttackAdd",
			1
		},
		{
			"ignoreDefMagicAttackAdd",
			1
		}
	};

	// Token: 0x04000606 RID: 1542
	public static List<string> equipPropName = new List<string>
	{
		"maxHp",
		"maxMp",
		"hpRecover",
		"mpRecover",
		"attack",
		"magicAttack",
		"defence",
		"magicDefence",
		"attackSpeed",
		"spellSpeed",
		"moveSpeed",
		"ciriticalAttack",
		"ciriticalMagicAttack",
		"dex",
		"dodge",
		"frozen",
		"hard",
		"baseAtk",
		"baseInt",
		"baseSta",
		"baseSpr",
		"attackReduceFix",
		"magicAttackReduceFix",
		"ignoreDefAttackAdd",
		"ignoreDefMagicAttackAdd"
	};

	// Token: 0x04000607 RID: 1543
	public static List<string> magicElementsEffectMap = new List<string>
	{
		"Effects/Common/Sfx/Hit/Prefab/Eff_hit_guang",
		"Effects/Common/Sfx/Hit/Prefab/Eff_hit_huo",
		"Effects/Common/Sfx/Hit/Prefab/Eff_hit_bing",
		"Effects/Common/Sfx/Hit/Prefab/Eff_hit_an"
	};

	// Token: 0x04000608 RID: 1544
	public static List<int> magicElementsSoundMap = new List<int>
	{
		1016,
		1015,
		1017,
		1014
	};

	// Token: 0x04000609 RID: 1545
	public static int EXTRA_MODEL_MAX = 10;

	// Token: 0x0400060A RID: 1546
	private static readonly string kSDKConfigFileName = "sdk.conf";

	// Token: 0x0400060B RID: 1547
	public static int SUMMONMONSTERTYPE = 10;

	// Token: 0x0400060C RID: 1548
	private static Dictionary<int, string> attributeStringMap = new Dictionary<int, string>();
}
