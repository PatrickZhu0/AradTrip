using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;
using UnityEngine;

// Token: 0x02000132 RID: 306
public class GlobalSetting : ScriptableObject
{
	// Token: 0x17000159 RID: 345
	// (get) Token: 0x0600089C RID: 2204 RVA: 0x0002EEA9 File Offset: 0x0002D2A9
	public bool isUsingSDK
	{
		get
		{
			return this.sdkChannel != SDKChannel.NONE && SDKChannel.COUNT != this.sdkChannel;
		}
	}

	// Token: 0x1700015A RID: 346
	// (get) Token: 0x0600089D RID: 2205 RVA: 0x0002EEC6 File Offset: 0x0002D2C6
	// (set) Token: 0x0600089E RID: 2206 RVA: 0x0002EEDC File Offset: 0x0002D2DC
	public Vec3 walkSpeed
	{
		get
		{
			return Utility.IRepeate2Vector(Singleton<TableManager>.instance.gst.walkSpeed);
		}
		set
		{
		}
	}

	// Token: 0x1700015B RID: 347
	// (get) Token: 0x0600089F RID: 2207 RVA: 0x0002EEDE File Offset: 0x0002D2DE
	// (set) Token: 0x060008A0 RID: 2208 RVA: 0x0002EEF4 File Offset: 0x0002D2F4
	public Vec3 runSpeed
	{
		get
		{
			return Utility.IRepeate2Vector(Singleton<TableManager>.instance.gst.runSpeed);
		}
		set
		{
		}
	}

	// Token: 0x1700015C RID: 348
	// (get) Token: 0x060008A1 RID: 2209 RVA: 0x0002EEF6 File Offset: 0x0002D2F6
	// (set) Token: 0x060008A2 RID: 2210 RVA: 0x0002EF0C File Offset: 0x0002D30C
	public float switchWeaponTime
	{
		get
		{
			return Utility.I2FloatBy1000(Singleton<TableManager>.instance.gst.SwitchWeaponCD);
		}
		set
		{
		}
	}

	// Token: 0x1700015D RID: 349
	// (get) Token: 0x060008A3 RID: 2211 RVA: 0x0002EF0E File Offset: 0x0002D30E
	// (set) Token: 0x060008A4 RID: 2212 RVA: 0x0002EF24 File Offset: 0x0002D324
	public float dunFuTime
	{
		get
		{
			return Utility.I2FloatBy1000(Singleton<TableManager>.instance.gst.dunFuTime);
		}
		set
		{
		}
	}

	// Token: 0x1700015E RID: 350
	// (get) Token: 0x060008A5 RID: 2213 RVA: 0x0002EF26 File Offset: 0x0002D326
	// (set) Token: 0x060008A6 RID: 2214 RVA: 0x0002EF3C File Offset: 0x0002D33C
	public float pvpDunFuTime
	{
		get
		{
			return Utility.I2FloatBy1000(Singleton<TableManager>.instance.gst.pvpDunFuTime);
		}
		set
		{
		}
	}

	// Token: 0x1700015F RID: 351
	// (get) Token: 0x060008A7 RID: 2215 RVA: 0x0002EF3E File Offset: 0x0002D33E
	// (set) Token: 0x060008A8 RID: 2216 RVA: 0x0002EF5B File Offset: 0x0002D35B
	public VFactor monsterWalkSpeedFactor
	{
		get
		{
			return new VFactor((long)Singleton<TableManager>.instance.gst.monsterWalkSpeedFactor, (long)GlobalLogic.VALUE_1000);
		}
		set
		{
		}
	}

	// Token: 0x17000160 RID: 352
	// (get) Token: 0x060008A9 RID: 2217 RVA: 0x0002EF5D File Offset: 0x0002D35D
	// (set) Token: 0x060008AA RID: 2218 RVA: 0x0002EF73 File Offset: 0x0002D373
	public float monsterSightFactor
	{
		get
		{
			return Utility.I2FloatBy1000(Singleton<TableManager>.instance.gst.monsterSightFactor);
		}
		set
		{
		}
	}

	// Token: 0x17000161 RID: 353
	// (get) Token: 0x060008AB RID: 2219 RVA: 0x0002EF75 File Offset: 0x0002D375
	// (set) Token: 0x060008AC RID: 2220 RVA: 0x0002EF87 File Offset: 0x0002D387
	public float gravity
	{
		get
		{
			return (float)Singleton<TableManager>.instance.gst.gravity;
		}
		set
		{
		}
	}

	// Token: 0x17000162 RID: 354
	// (get) Token: 0x060008AD RID: 2221 RVA: 0x0002EF89 File Offset: 0x0002D389
	// (set) Token: 0x060008AE RID: 2222 RVA: 0x0002EF9F File Offset: 0x0002D39F
	public float fallGravityReduceFactor
	{
		get
		{
			return Utility.I2FloatBy10000(Singleton<TableManager>.instance.gst.fallGravityReduceFactor);
		}
		set
		{
		}
	}

	// Token: 0x17000163 RID: 355
	// (get) Token: 0x060008AF RID: 2223 RVA: 0x0002EFA1 File Offset: 0x0002D3A1
	// (set) Token: 0x060008B0 RID: 2224 RVA: 0x0002EFB7 File Offset: 0x0002D3B7
	public float defaultFloatHurt
	{
		get
		{
			return Utility.I2FloatBy10000(Singleton<TableManager>.instance.gst.defaultFloatHurt);
		}
		set
		{
		}
	}

	// Token: 0x17000164 RID: 356
	// (get) Token: 0x060008B1 RID: 2225 RVA: 0x0002EFB9 File Offset: 0x0002D3B9
	// (set) Token: 0x060008B2 RID: 2226 RVA: 0x0002EFCF File Offset: 0x0002D3CF
	public float defaultFloatLevelHurat
	{
		get
		{
			return Utility.I2FloatBy10000(Singleton<TableManager>.instance.gst.defaultFloatLevelHurat);
		}
		set
		{
		}
	}

	// Token: 0x17000165 RID: 357
	// (get) Token: 0x060008B3 RID: 2227 RVA: 0x0002EFD1 File Offset: 0x0002D3D1
	// (set) Token: 0x060008B4 RID: 2228 RVA: 0x0002EFE7 File Offset: 0x0002D3E7
	public float defaultGroundHurt
	{
		get
		{
			return Utility.I2FloatBy10000(Singleton<TableManager>.instance.gst.defaultGroundHurt);
		}
		set
		{
		}
	}

	// Token: 0x17000166 RID: 358
	// (get) Token: 0x060008B5 RID: 2229 RVA: 0x0002EFE9 File Offset: 0x0002D3E9
	// (set) Token: 0x060008B6 RID: 2230 RVA: 0x0002EFFF File Offset: 0x0002D3FF
	public float defaultStandHurt
	{
		get
		{
			return Utility.I2FloatBy10000(Singleton<TableManager>.instance.gst.defaultStandHurt);
		}
		set
		{
		}
	}

	// Token: 0x17000167 RID: 359
	// (get) Token: 0x060008B7 RID: 2231 RVA: 0x0002F001 File Offset: 0x0002D401
	// (set) Token: 0x060008B8 RID: 2232 RVA: 0x0002F017 File Offset: 0x0002D417
	public float fallProtectGravityAddFactor
	{
		get
		{
			return Utility.I2FloatBy1000(Singleton<TableManager>.instance.gst.fallProtectGravityAddFactor);
		}
		set
		{
		}
	}

	// Token: 0x17000168 RID: 360
	// (get) Token: 0x060008B9 RID: 2233 RVA: 0x0002F019 File Offset: 0x0002D419
	// (set) Token: 0x060008BA RID: 2234 RVA: 0x0002F02B File Offset: 0x0002D42B
	public float protectClearDuration
	{
		get
		{
			return (float)Singleton<TableManager>.instance.gst.protectClearDuration;
		}
		set
		{
		}
	}

	// Token: 0x17000169 RID: 361
	// (get) Token: 0x060008BB RID: 2235 RVA: 0x0002F02D File Offset: 0x0002D42D
	// (set) Token: 0x060008BC RID: 2236 RVA: 0x0002F04A File Offset: 0x0002D44A
	public VFactor zDimFactor
	{
		get
		{
			return new VFactor((long)Singleton<TableManager>.instance.gst.zDimFactor, (long)GlobalLogic.VALUE_1000);
		}
		set
		{
		}
	}

	// Token: 0x1700016A RID: 362
	// (get) Token: 0x060008BD RID: 2237 RVA: 0x0002F04C File Offset: 0x0002D44C
	// (set) Token: 0x060008BE RID: 2238 RVA: 0x0002F062 File Offset: 0x0002D462
	public float pkDamageAdjustFactor
	{
		get
		{
			return Utility.I2FloatBy1000(Singleton<TableManager>.instance.gst.pkDamageAdjustFactor);
		}
		set
		{
		}
	}

	// Token: 0x1700016B RID: 363
	// (get) Token: 0x060008BF RID: 2239 RVA: 0x0002F064 File Offset: 0x0002D464
	// (set) Token: 0x060008C0 RID: 2240 RVA: 0x0002F07A File Offset: 0x0002D47A
	public float pkHPAdjustFactor
	{
		get
		{
			return Utility.I2FloatBy1000(Singleton<TableManager>.instance.gst.pkHPAdjustFactor);
		}
		set
		{
		}
	}

	// Token: 0x1700016C RID: 364
	// (get) Token: 0x060008C1 RID: 2241 RVA: 0x0002F07C File Offset: 0x0002D47C
	public string IPAddress
	{
		get
		{
			return this.serverList[this.ipSelectedIndex].ip;
		}
	}

	// Token: 0x1700016D RID: 365
	// (get) Token: 0x060008C2 RID: 2242 RVA: 0x0002F090 File Offset: 0x0002D490
	public ushort IPPort
	{
		get
		{
			return this.serverList[this.ipSelectedIndex].port;
		}
	}

	// Token: 0x1700016E RID: 366
	// (get) Token: 0x060008C3 RID: 2243 RVA: 0x0002F0A4 File Offset: 0x0002D4A4
	// (set) Token: 0x060008C4 RID: 2244 RVA: 0x0002F0B5 File Offset: 0x0002D4B5
	public int aiWanderRange
	{
		get
		{
			return Singleton<TableManager>.instance.gst.aiWanderRange;
		}
		set
		{
		}
	}

	// Token: 0x1700016F RID: 367
	// (get) Token: 0x060008C5 RID: 2245 RVA: 0x0002F0B7 File Offset: 0x0002D4B7
	// (set) Token: 0x060008C6 RID: 2246 RVA: 0x0002F0C8 File Offset: 0x0002D4C8
	public int aiWAlkBackRange
	{
		get
		{
			return Singleton<TableManager>.instance.gst.aiWAlkBackRange;
		}
		set
		{
		}
	}

	// Token: 0x17000170 RID: 368
	// (get) Token: 0x060008C7 RID: 2247 RVA: 0x0002F0CA File Offset: 0x0002D4CA
	// (set) Token: 0x060008C8 RID: 2248 RVA: 0x0002F0DB File Offset: 0x0002D4DB
	public int aiMaxWalkCmdCount
	{
		get
		{
			return Singleton<TableManager>.instance.gst.aiMaxWalkCmdCount;
		}
		set
		{
		}
	}

	// Token: 0x17000171 RID: 369
	// (get) Token: 0x060008C9 RID: 2249 RVA: 0x0002F0DD File Offset: 0x0002D4DD
	// (set) Token: 0x060008CA RID: 2250 RVA: 0x0002F0EE File Offset: 0x0002D4EE
	public int aiMaxWalkCmdCount_RANGED
	{
		get
		{
			return Singleton<TableManager>.instance.gst.aiMaxWalkCmdCount_RANGED;
		}
		set
		{
		}
	}

	// Token: 0x17000172 RID: 370
	// (get) Token: 0x060008CB RID: 2251 RVA: 0x0002F0F0 File Offset: 0x0002D4F0
	// (set) Token: 0x060008CC RID: 2252 RVA: 0x0002F101 File Offset: 0x0002D501
	public int aiMaxIdleCmdcount
	{
		get
		{
			return Singleton<TableManager>.instance.gst.aiMaxIdleCmdcount;
		}
		set
		{
		}
	}

	// Token: 0x17000173 RID: 371
	// (get) Token: 0x060008CD RID: 2253 RVA: 0x0002F103 File Offset: 0x0002D503
	// (set) Token: 0x060008CE RID: 2254 RVA: 0x0002F114 File Offset: 0x0002D514
	public int aiSkillAttackPassive
	{
		get
		{
			return Singleton<TableManager>.instance.gst.aiSkillAttackPassive;
		}
		set
		{
		}
	}

	// Token: 0x17000174 RID: 372
	// (get) Token: 0x060008CF RID: 2255 RVA: 0x0002F116 File Offset: 0x0002D516
	// (set) Token: 0x060008D0 RID: 2256 RVA: 0x0002F12C File Offset: 0x0002D52C
	public float monsterGetupBatiFactor
	{
		get
		{
			return Utility.I2FloatBy1000(Singleton<TableManager>.instance.gst.monsterGetupBatiFactor);
		}
		set
		{
		}
	}

	// Token: 0x17000175 RID: 373
	// (get) Token: 0x060008D1 RID: 2257 RVA: 0x0002F12E File Offset: 0x0002D52E
	// (set) Token: 0x060008D2 RID: 2258 RVA: 0x0002F144 File Offset: 0x0002D544
	public float degangBackDistance
	{
		get
		{
			return Utility.I2FloatBy1000(Singleton<TableManager>.instance.gst.degangBackDistance);
		}
		set
		{
		}
	}

	// Token: 0x17000176 RID: 374
	// (get) Token: 0x060008D3 RID: 2259 RVA: 0x0002F146 File Offset: 0x0002D546
	// (set) Token: 0x060008D4 RID: 2260 RVA: 0x0002F157 File Offset: 0x0002D557
	public int afThinkTerm
	{
		get
		{
			return Singleton<TableManager>.instance.gst.afThinkTerm;
		}
		set
		{
		}
	}

	// Token: 0x17000177 RID: 375
	// (get) Token: 0x060008D5 RID: 2261 RVA: 0x0002F159 File Offset: 0x0002D559
	// (set) Token: 0x060008D6 RID: 2262 RVA: 0x0002F16A File Offset: 0x0002D56A
	public int afFindTargetTerm
	{
		get
		{
			return Singleton<TableManager>.instance.gst.afFindTargetTerm;
		}
		set
		{
		}
	}

	// Token: 0x17000178 RID: 376
	// (get) Token: 0x060008D7 RID: 2263 RVA: 0x0002F16C File Offset: 0x0002D56C
	// (set) Token: 0x060008D8 RID: 2264 RVA: 0x0002F17D File Offset: 0x0002D57D
	public int afChangeDestinationTerm
	{
		get
		{
			return Singleton<TableManager>.instance.gst.afChangeDestinationTerm;
		}
		set
		{
		}
	}

	// Token: 0x17000179 RID: 377
	// (get) Token: 0x060008D9 RID: 2265 RVA: 0x0002F17F File Offset: 0x0002D57F
	// (set) Token: 0x060008DA RID: 2266 RVA: 0x0002F190 File Offset: 0x0002D590
	public int autoCheckRestoreInterval
	{
		get
		{
			return Singleton<TableManager>.instance.gst.autoCheckRestoreInterval;
		}
		set
		{
		}
	}

	// Token: 0x1700017A RID: 378
	// (get) Token: 0x060008DB RID: 2267 RVA: 0x0002F192 File Offset: 0x0002D592
	public int JumpAttackLimitHeight
	{
		get
		{
			return IntMath.Float2IntWithFixed(this.jumpAttackLimitHeight, 10000L, 100L, MidpointRounding.ToEven);
		}
	}

	// Token: 0x1700017B RID: 379
	// (get) Token: 0x060008DC RID: 2268 RVA: 0x0002F1A9 File Offset: 0x0002D5A9
	// (set) Token: 0x060008DD RID: 2269 RVA: 0x0002F1BF File Offset: 0x0002D5BF
	public Vec3 monsterWalkSpeed
	{
		get
		{
			return Utility.IRepeate2Vector(Singleton<TableManager>.instance.gst.monsterWalkSpeed);
		}
		set
		{
		}
	}

	// Token: 0x1700017C RID: 380
	// (get) Token: 0x060008DE RID: 2270 RVA: 0x0002F1C1 File Offset: 0x0002D5C1
	// (set) Token: 0x060008DF RID: 2271 RVA: 0x0002F1D7 File Offset: 0x0002D5D7
	public Vec3 monsterRunSpeed
	{
		get
		{
			return Utility.IRepeate2Vector(Singleton<TableManager>.instance.gst.monsterRunSpeed);
		}
		set
		{
		}
	}

	// Token: 0x060008E0 RID: 2272 RVA: 0x0002F1D9 File Offset: 0x0002D5D9
	public bool IsTestTeam()
	{
		return this.isDebug && this.isTestTeam;
	}

	// Token: 0x0400060D RID: 1549
	public bool isTestTeam;

	// Token: 0x0400060E RID: 1550
	public bool m_isOpenPVPFallHurtProtect = true;

	// Token: 0x0400060F RID: 1551
	public bool m_isQTESkillTest;

	// Token: 0x04000610 RID: 1552
	public SDKChannel mainSDKChannel;

	// Token: 0x04000611 RID: 1553
	public bool isPaySDKDebug;

	// Token: 0x04000612 RID: 1554
	public SDKChannel sdkChannel = SDKChannel.XY;

	// Token: 0x04000613 RID: 1555
	public bool isBanShuVersion;

	// Token: 0x04000614 RID: 1556
	public bool isDebug = true;

	// Token: 0x04000615 RID: 1557
	public bool isLogRecord;

	// Token: 0x04000616 RID: 1558
	public bool isRecordPVP;

	// Token: 0x04000617 RID: 1559
	public bool showDebugBox;

	// Token: 0x04000618 RID: 1560
	public bool isRecordAB;

	// Token: 0x04000619 RID: 1561
	public int frameLock = 60;

	// Token: 0x0400061A RID: 1562
	public float fallgroundHitFactor = 0.5f;

	// Token: 0x0400061B RID: 1563
	public float hitTime = 0.15f;

	// Token: 0x0400061C RID: 1564
	public float deadWhiteTime = 0.2f;

	// Token: 0x0400061D RID: 1565
	public string defaultHitEffect = "Effects/Common/Sfx/Hit/Prefab/Eff_hit";

	// Token: 0x0400061E RID: 1566
	public string defaultProjectileHitEffect = "Effects/Hero_Gunman/Common/Pistolbullet/Prefab/Eff_Pistol_Bullet_Hit";

	// Token: 0x0400061F RID: 1567
	public string defualtHitSfx = "Sound/kezhangoumai";

	// Token: 0x04000620 RID: 1568
	public string defualtChannel = "oppo";

	// Token: 0x04000621 RID: 1569
	public Vec3 _walkSpeed = new Vec3(2f, 4f, 0f);

	// Token: 0x04000622 RID: 1570
	public Vec3 _runSpeed = new Vec3(4f, 4f, 0f);

	// Token: 0x04000623 RID: 1571
	public Vec3 townWalkSpeed = new Vec3(2f, 4f, 0f);

	// Token: 0x04000624 RID: 1572
	public Vec3 townRunSpeed = new Vec3(4f, 4f, 0f);

	// Token: 0x04000625 RID: 1573
	public float townActionSpeed = 1f;

	// Token: 0x04000626 RID: 1574
	public bool townPlayerRun = true;

	// Token: 0x04000627 RID: 1575
	public int minHurtTime = 150;

	// Token: 0x04000628 RID: 1576
	public int maxHurtTime = 600;

	// Token: 0x04000629 RID: 1577
	public float frozenPercent = 0.5f;

	// Token: 0x0400062A RID: 1578
	public Vector2 jumpBackSpeed = new Vector2(-5f, 5f);

	// Token: 0x0400062B RID: 1579
	public float jumpForce = 20f;

	// Token: 0x0400062C RID: 1580
	public float clickForce = 14f;

	// Token: 0x0400062D RID: 1581
	public float snapDuration = 0.3f;

	// Token: 0x0400062E RID: 1582
	public float _dunFuTime = 3f;

	// Token: 0x0400062F RID: 1583
	public float drift = 3f;

	// Token: 0x04000630 RID: 1584
	public int logicFrameStepDelta;

	// Token: 0x04000631 RID: 1585
	public uint logicFrameStep = 2U;

	// Token: 0x04000632 RID: 1586
	public float gateReconnectTimeOut = 3.5f;

	// Token: 0x04000633 RID: 1587
	public int gateReconnectSendTryCount = 3;

	// Token: 0x04000634 RID: 1588
	public float relayReconnectTimeOut = 3.5f;

	// Token: 0x04000635 RID: 1589
	public int relayReconnectSendTryCount = 3;

	// Token: 0x04000636 RID: 1590
	public float _pvpDunFuTime = 1.5f;

	// Token: 0x04000637 RID: 1591
	public int PVPHPScale = 10;

	// Token: 0x04000638 RID: 1592
	public int TestLevel = 1;

	// Token: 0x04000639 RID: 1593
	public int testPlayerNum = 1;

	// Token: 0x0400063A RID: 1594
	public bool showBattleInfoPanel;

	// Token: 0x0400063B RID: 1595
	public int defaultMonsterID = 1000;

	// Token: 0x0400063C RID: 1596
	public float _monsterWalkSpeedFactor = 1f;

	// Token: 0x0400063D RID: 1597
	public float _monsterSightFactor = 1f;

	// Token: 0x0400063E RID: 1598
	public bool enableAssetInstPool;

	// Token: 0x0400063F RID: 1599
	public bool enemyHasAI = true;

	// Token: 0x04000640 RID: 1600
	public bool isCreateMonsterLocal;

	// Token: 0x04000641 RID: 1601
	public bool isGiveEquips;

	// Token: 0x04000642 RID: 1602
	public string equipList = string.Empty;

	// Token: 0x04000643 RID: 1603
	public string switchEquipList = string.Empty;

	// Token: 0x04000644 RID: 1604
	public bool isAnimationInto;

	// Token: 0x04000645 RID: 1605
	public bool isGuide;

	// Token: 0x04000646 RID: 1606
	public bool displayHUD;

	// Token: 0x04000647 RID: 1607
	public bool CloseTeamCondition;

	// Token: 0x04000648 RID: 1608
	public bool isLocalDungeon;

	// Token: 0x04000649 RID: 1609
	public int localDungeonID = -1;

	// Token: 0x0400064A RID: 1610
	public bool recordResFile;

	// Token: 0x0400064B RID: 1611
	public bool profileAssetLoad;

	// Token: 0x0400064C RID: 1612
	public float _gravity = 50f;

	// Token: 0x0400064D RID: 1613
	public float _fallGravityReduceFactor = 1f;

	// Token: 0x0400064E RID: 1614
	public bool skillHasCooldown = true;

	// Token: 0x0400064F RID: 1615
	public string scenePath = "Data/SceneData/Town_Aierwen";

	// Token: 0x04000650 RID: 1616
	public int ipSelectedIndex;

	// Token: 0x04000651 RID: 1617
	public int iSingleCharactorID = 1;

	// Token: 0x04000652 RID: 1618
	public Vector2 cameraInRange = new Vector2(1f, 1f);

	// Token: 0x04000653 RID: 1619
	public InputManager.ButtonMode buttonType;

	// Token: 0x04000654 RID: 1620
	public float _defaultFloatHurt = 0.2f;

	// Token: 0x04000655 RID: 1621
	public float _defaultFloatLevelHurat = 0.05f;

	// Token: 0x04000656 RID: 1622
	public float _defaultGroundHurt = 0.15f;

	// Token: 0x04000657 RID: 1623
	public float _defaultStandHurt = 0.2f;

	// Token: 0x04000658 RID: 1624
	public float _fallProtectGravityAddFactor = 2f;

	// Token: 0x04000659 RID: 1625
	public int _protectClearDuration = 1500;

	// Token: 0x0400065A RID: 1626
	public float bgmStart = 1f;

	// Token: 0x0400065B RID: 1627
	public float bgmTown = 1f;

	// Token: 0x0400065C RID: 1628
	public float bgmBattle = 1f;

	// Token: 0x0400065D RID: 1629
	public float _zDimFactor = 1f;

	// Token: 0x0400065E RID: 1630
	public float bullteScale = 0.2f;

	// Token: 0x0400065F RID: 1631
	public int bullteTime = 1000;

	// Token: 0x04000660 RID: 1632
	public EClientSystem startSystem;

	// Token: 0x04000661 RID: 1633
	public string[] loggerFilter = new string[]
	{
		".",
		".",
		".",
		"."
	};

	// Token: 0x04000662 RID: 1634
	public bool showDialog = true;

	// Token: 0x04000663 RID: 1635
	public Vector3 avatarLightDir = new Vector3(1f, 1f, 0f);

	// Token: 0x04000664 RID: 1636
	public Vector3 shadowLightDir = new Vector3(-0.65f, -1f, 0.5f);

	// Token: 0x04000665 RID: 1637
	public Vector3 startVel = new Vector3(10f, 20f, -20f);

	// Token: 0x04000666 RID: 1638
	public Vector3 endVel = new Vector3(0f, 0f, 0f);

	// Token: 0x04000667 RID: 1639
	public Vector3 offset = new Vector3(3f, 0f, 0f);

	// Token: 0x04000668 RID: 1640
	public float TimeAccerlate = 20f;

	// Token: 0x04000669 RID: 1641
	public int TotalTime = 2000;

	// Token: 0x0400066A RID: 1642
	public int TotalDist = 100;

	// Token: 0x0400066B RID: 1643
	public bool heightAdoption = true;

	// Token: 0x0400066C RID: 1644
	public bool debugDrawBlock;

	// Token: 0x0400066D RID: 1645
	public bool loadFromPackage;

	// Token: 0x0400066E RID: 1646
	public bool enableHotFix;

	// Token: 0x0400066F RID: 1647
	public bool hotFixUrlDebug;

	// Token: 0x04000670 RID: 1648
	public int REVIVE_SHOCK_SKILLID = 9998;

	// Token: 0x04000671 RID: 1649
	public Vector2 rollSpeed = new Vector2(7f, 0f);

	// Token: 0x04000672 RID: 1650
	public float rollRand = 0.3f;

	// Token: 0x04000673 RID: 1651
	public float normalRollRand = 0.1f;

	// Token: 0x04000674 RID: 1652
	public Texture2D globalRamp;

	// Token: 0x04000675 RID: 1653
	public float _pkDamageAdjustFactor = 0.7f;

	// Token: 0x04000676 RID: 1654
	public float _pkHPAdjustFactor = 0.7f;

	// Token: 0x04000677 RID: 1655
	public bool pkUseMaxLevel = true;

	// Token: 0x04000678 RID: 1656
	public BattleRunMode battleRunMode;

	// Token: 0x04000679 RID: 1657
	public bool hasDoubleRun;

	// Token: 0x0400067A RID: 1658
	public int playerHP;

	// Token: 0x0400067B RID: 1659
	public int playerRebornHP;

	// Token: 0x0400067C RID: 1660
	public int monsterHP;

	// Token: 0x0400067D RID: 1661
	public Vec3 playerPos = Vec3.zero;

	// Token: 0x0400067E RID: 1662
	public float transportDoorRadius = 1f;

	// Token: 0x0400067F RID: 1663
	public float petXMovingDis = 1.5f;

	// Token: 0x04000680 RID: 1664
	public float petXMovingv1 = 2f;

	// Token: 0x04000681 RID: 1665
	public float petXMovingv2 = 5f;

	// Token: 0x04000682 RID: 1666
	public float petYMovingDis = 1.5f;

	// Token: 0x04000683 RID: 1667
	public float petYMovingv1 = 1f;

	// Token: 0x04000684 RID: 1668
	public float petYMovingv2 = 3f;

	// Token: 0x04000685 RID: 1669
	public string serverListUrl = "47.97.24.110:8765";

	// Token: 0x04000686 RID: 1670
	public GlobalSetting.Address[] serverList = new GlobalSetting.Address[]
	{
		new GlobalSetting.Address
		{
			ip = "58.220.33.37",
			port = 8444
		}
	};

	// Token: 0x04000687 RID: 1671
	public bool debugNewAutofightAI;

	// Token: 0x04000688 RID: 1672
	public float charScale = 1f;

	// Token: 0x04000689 RID: 1673
	public bool damageNoRange;

	// Token: 0x0400068A RID: 1674
	public bool sceneDark;

	// Token: 0x0400068B RID: 1675
	public ShockData monsterBeHitShockData = new ShockData(0.2f, 70f, 0.03f, 0f, 0);

	// Token: 0x0400068C RID: 1676
	public ShockData playerBeHitShockData = new ShockData(0.2f, 70f, 0.03f, 0f, 0);

	// Token: 0x0400068D RID: 1677
	public ShockData playerSkillCDShockData = new ShockData(0.2f, 70f, 0.03f, 0f, 0);

	// Token: 0x0400068E RID: 1678
	public ShockData playerHighFallTouchGroundShockData = new ShockData(0.3f, 100f, 0.03f, 0f, 0);

	// Token: 0x0400068F RID: 1679
	public float highFallHight = 7f;

	// Token: 0x04000690 RID: 1680
	public string critialDeadEffect = "Effects/Common/Sfx/Siwang/Eff_die_baoji";

	// Token: 0x04000691 RID: 1681
	public string immediateDeadEffect = "Effects/Common/Sfx/Siwang/Eff_die_yiji";

	// Token: 0x04000692 RID: 1682
	public string normalDeadEffect = "Effects/Common/Sfx/Siwang/Eff_Common_die_guo";

	// Token: 0x04000693 RID: 1683
	public bool enableEffectLimit = true;

	// Token: 0x04000694 RID: 1684
	public int effectLimitCount = 10;

	// Token: 0x04000695 RID: 1685
	public int immediateDeadHPPercent = 30;

	// Token: 0x04000696 RID: 1686
	public bool openBossShow;

	// Token: 0x04000697 RID: 1687
	public float shooterFitPercent = 0.5f;

	// Token: 0x04000698 RID: 1688
	public bool isTrainingAIOpen;

	// Token: 0x04000699 RID: 1689
	public int trainingAIConfigId;

	// Token: 0x0400069A RID: 1690
	public int trainingRobotId;

	// Token: 0x0400069B RID: 1691
	public Vector3 disappearDis = new Vector3(-2f, 0f, 5f);

	// Token: 0x0400069C RID: 1692
	public float keepDis = 2f;

	// Token: 0x0400069D RID: 1693
	public float accompanyRunTime = 0.5f;

	// Token: 0x0400069E RID: 1694
	public int _aiWanderRange = 2;

	// Token: 0x0400069F RID: 1695
	public int _aiWAlkBackRange = 2;

	// Token: 0x040006A0 RID: 1696
	public int _aiMaxWalkCmdCount = 2;

	// Token: 0x040006A1 RID: 1697
	public int _aiMaxWalkCmdCount_RANGED = 2;

	// Token: 0x040006A2 RID: 1698
	public int _aiMaxIdleCmdcount = 1;

	// Token: 0x040006A3 RID: 1699
	public int _aiSkillAttackPassive = 30;

	// Token: 0x040006A4 RID: 1700
	public float _monsterGetupBatiFactor = 0.3f;

	// Token: 0x040006A5 RID: 1701
	public float _degangBackDistance = 0.5f;

	// Token: 0x040006A6 RID: 1702
	public int _afThinkTerm = 100;

	// Token: 0x040006A7 RID: 1703
	public int _afFindTargetTerm = 100;

	// Token: 0x040006A8 RID: 1704
	public int _afChangeDestinationTerm = 300;

	// Token: 0x040006A9 RID: 1705
	public int _autoCheckRestoreInterval = 2000;

	// Token: 0x040006AA RID: 1706
	public bool forceUseAutoFight;

	// Token: 0x040006AB RID: 1707
	public bool canUseAutoFight = true;

	// Token: 0x040006AC RID: 1708
	public bool canUseAutoFightFirstPass;

	// Token: 0x040006AD RID: 1709
	public bool loadAutoFight;

	// Token: 0x040006AE RID: 1710
	public float jumpAttackLimitHeight = 0.7f;

	// Token: 0x040006AF RID: 1711
	public float skillCancelLimitTime = 1f;

	// Token: 0x040006B0 RID: 1712
	public int doublePressCheckDuration = 500;

	// Token: 0x040006B1 RID: 1713
	public ActionType walkAction = ActionType.ActionType_WALK;

	// Token: 0x040006B2 RID: 1714
	public ActionType runAction = ActionType.ActionType_RUN;

	// Token: 0x040006B3 RID: 1715
	public float walkAniFactor = 1f;

	// Token: 0x040006B4 RID: 1716
	public float runAniFactor = 1f;

	// Token: 0x040006B5 RID: 1717
	public bool changeFaceStop = true;

	// Token: 0x040006B6 RID: 1718
	public Vec3 _monsterWalkSpeed = new Vec3(2.2f, 4.5f, 0f);

	// Token: 0x040006B7 RID: 1719
	public Vec3 _monsterRunSpeed = new Vec3(3.8f, 6f, 0f);

	// Token: 0x040006B8 RID: 1720
	public int tableLoadStep = 3;

	// Token: 0x040006B9 RID: 1721
	public int loadingProgressStepInEditor = 100;

	// Token: 0x040006BA RID: 1722
	public int loadingProgressStep = 10;

	// Token: 0x040006BB RID: 1723
	public string pvpDefaultSesstionID = string.Empty;

	// Token: 0x040006BC RID: 1724
	public int petID;

	// Token: 0x040006BD RID: 1725
	public int petLevel = 1;

	// Token: 0x040006BE RID: 1726
	public int petHunger = 10;

	// Token: 0x040006BF RID: 1727
	public int petSkillIndex;

	// Token: 0x040006C0 RID: 1728
	public bool testFashionEquip;

	// Token: 0x040006C1 RID: 1729
	public string serverCodePath = string.Empty;

	// Token: 0x040006C2 RID: 1730
	public Dictionary<string, float> equipPropFactors = new Dictionary<string, float>();

	// Token: 0x040006C3 RID: 1731
	public float[] equipPropFactorValues = new float[]
	{
		0.2f,
		0.2f,
		0.5f,
		0.5f,
		1f,
		1f,
		0.1f,
		0.1f,
		2f,
		2f,
		2f,
		2f,
		2f,
		2f,
		2f,
		0.5f,
		0.5f,
		0.8f,
		0.8f,
		0.8f,
		0.8f,
		2f,
		2f,
		2f,
		2f
	};

	// Token: 0x040006C4 RID: 1732
	public Dictionary<string, float> quipThirdTypeFactors = new Dictionary<string, float>();

	// Token: 0x040006C5 RID: 1733
	public float[] quipThirdTypeFactorValues = new float[]
	{
		1f,
		0.95f,
		1f,
		1f,
		1f,
		1.2f,
		1f,
		1.2f,
		1f,
		1f,
		1f,
		1f,
		1f,
		1f,
		3f,
		1.7f,
		1f,
		1f,
		1f
	};

	// Token: 0x040006C6 RID: 1734
	public GlobalSetting.QualityAdjust qualityAdjust = new GlobalSetting.QualityAdjust();

	// Token: 0x040006C7 RID: 1735
	public float petDialogLife = 5f;

	// Token: 0x040006C8 RID: 1736
	public float petDialogShowInterval = 10f;

	// Token: 0x040006C9 RID: 1737
	public float petSpecialIdleInterval = 15f;

	// Token: 0x040006CA RID: 1738
	public int notifyItemTimeLess = 172800;

	// Token: 0x02000133 RID: 307
	[Serializable]
	public class Address
	{
		// Token: 0x060008E2 RID: 2274 RVA: 0x0002F1F7 File Offset: 0x0002D5F7
		public override string ToString()
		{
			return this.name;
		}

		// Token: 0x040006CB RID: 1739
		public string name;

		// Token: 0x040006CC RID: 1740
		public string ip;

		// Token: 0x040006CD RID: 1741
		public ushort port;

		// Token: 0x040006CE RID: 1742
		public uint id;
	}

	// Token: 0x02000134 RID: 308
	[Serializable]
	public class QualityAdjust
	{
		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060008E4 RID: 2276 RVA: 0x0002F237 File Offset: 0x0002D637
		// (set) Token: 0x060008E5 RID: 2277 RVA: 0x0002F23F File Offset: 0x0002D63F
		public bool Dirty
		{
			get
			{
				return this.bDirty;
			}
			set
			{
				this.bDirty = value;
				this.OnQualityDirty(value);
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060008E6 RID: 2278 RVA: 0x0002F24F File Offset: 0x0002D64F
		public List<ItemData> Equipments
		{
			get
			{
				return this.kEquipments;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060008E7 RID: 2279 RVA: 0x0002F257 File Offset: 0x0002D657
		// (set) Token: 0x060008E8 RID: 2280 RVA: 0x0002F25F File Offset: 0x0002D65F
		public int SelectedIndex
		{
			get
			{
				return this.iSelectedIndex;
			}
			set
			{
				this.iSelectedIndex = value;
			}
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0002F268 File Offset: 0x0002D668
		public void OnQualityDirty(bool bDirty)
		{
			this.kEquipments.Clear();
			this.toggles.Clear();
			if (bDirty)
			{
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
					if (item != null)
					{
						this.kEquipments.Add(item);
						this.toggles.Add(false);
					}
				}
				itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
				for (int j = 0; j < itemsByPackageType.Count; j++)
				{
					ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[j]);
					if (item2 != null && item2.Type != ItemTable.eType.FUCKTITTLE)
					{
						this.kEquipments.Add(item2);
						this.toggles.Add(false);
					}
				}
				for (int k = 0; k < this.kEquipments.Count; k++)
				{
					if (this.kEquipments[k].SubQuality >= 100)
					{
						this.toggles.RemoveAt(k);
						this.kEquipments.RemoveAt(k);
						k--;
					}
				}
			}
		}

		// Token: 0x040006CF RID: 1743
		public bool bIsOpen;

		// Token: 0x040006D0 RID: 1744
		public float fInterval = 1f;

		// Token: 0x040006D1 RID: 1745
		public int iTimes = 50;

		// Token: 0x040006D2 RID: 1746
		[HideInInspector]
		public Vector2 mScroll;

		// Token: 0x040006D3 RID: 1747
		[NonSerialized]
		private bool bDirty;

		// Token: 0x040006D4 RID: 1748
		[NonSerialized]
		private List<ItemData> kEquipments = new List<ItemData>();

		// Token: 0x040006D5 RID: 1749
		[HideInInspector]
		[NonSerialized]
		public List<bool> toggles = new List<bool>();

		// Token: 0x040006D6 RID: 1750
		[NonSerialized]
		private int iSelectedIndex = -1;
	}
}
