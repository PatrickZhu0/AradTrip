using System;
using System.Collections.Generic;
using Battle;

namespace Protocol
{
	// Token: 0x0200064F RID: 1615
	public class SceneObject : StreamObject
	{
		// Token: 0x040020C7 RID: 8391
		public ulong id;

		// Token: 0x040020C8 RID: 8392
		public byte isNew;

		// Token: 0x040020C9 RID: 8393
		public uint sceneId;

		// Token: 0x040020CA RID: 8394
		public byte type;

		// Token: 0x040020CB RID: 8395
		[SProperty(89)]
		public uint zoneId;

		// Token: 0x040020CC RID: 8396
		[SProperty(1)]
		public string name;

		// Token: 0x040020CD RID: 8397
		[SProperty(2)]
		public ushort level;

		// Token: 0x040020CE RID: 8398
		[SProperty(3)]
		public ulong exp;

		// Token: 0x040020CF RID: 8399
		[SProperty(5)]
		public byte sex;

		// Token: 0x040020D0 RID: 8400
		[SProperty(6)]
		public byte occu;

		// Token: 0x040020D1 RID: 8401
		[SProperty(10)]
		public QQVipInfo qqinfo;

		// Token: 0x040020D2 RID: 8402
		[SProperty(29)]
		public uint hp;

		// Token: 0x040020D3 RID: 8403
		[SProperty(30)]
		public uint maxHp;

		// Token: 0x040020D4 RID: 8404
		[SProperty(32)]
		public ushort moveSpeed;

		// Token: 0x040020D5 RID: 8405
		[SProperty(33)]
		public ObjectPos __pos;

		// Token: 0x040020D6 RID: 8406
		[SProperty(34)]
		public ushort __dir;

		// Token: 0x040020D7 RID: 8407
		[SProperty(36)]
		public SkillMgr skillMgr;

		// Token: 0x040020D8 RID: 8408
		[SProperty(37)]
		public List<DungeonBuff> buffList;

		// Token: 0x040020D9 RID: 8409
		[SProperty(39)]
		public uint gold;

		// Token: 0x040020DA RID: 8410
		[SProperty(40)]
		public uint bindGold;

		// Token: 0x040020DB RID: 8411
		[SProperty(41)]
		public uint point;

		// Token: 0x040020DC RID: 8412
		[SProperty(184)]
		public uint pointex;

		// Token: 0x040020DD RID: 8413
		[SProperty(42)]
		public uint bindPoint;

		// Token: 0x040020DE RID: 8414
		[SProperty(51)]
		public byte state;

		// Token: 0x040020DF RID: 8415
		[SProperty(53)]
		public SkillBars skillBars;

		// Token: 0x040020E0 RID: 8416
		[SProperty(91)]
		public ScenePosition pos;

		// Token: 0x040020E1 RID: 8417
		[SProperty(92)]
		public SceneDir dir;

		// Token: 0x040020E2 RID: 8418
		[SProperty(93)]
		public Sp sp;

		// Token: 0x040020E3 RID: 8419
		[SProperty(94)]
		public byte awaken;

		// Token: 0x040020E4 RID: 8420
		[SProperty(44)]
		public uint honor;

		// Token: 0x040020E5 RID: 8421
		[SProperty(45)]
		public uint packSize;

		// Token: 0x040020E6 RID: 8422
		[SProperty(96)]
		public uint pkValue;

		// Token: 0x040020E7 RID: 8423
		[SProperty(97)]
		public FatigueInfo fatigue;

		// Token: 0x040020E8 RID: 8424
		[SProperty(46)]
		public byte storageSize;

		// Token: 0x040020E9 RID: 8425
		[SProperty(72)]
		public uint title;

		// Token: 0x040020EA RID: 8426
		[SProperty(86)]
		public uint dayChargeNum;

		// Token: 0x040020EB RID: 8427
		[SProperty(38)]
		public List<ItemCD> itemCd;

		// Token: 0x040020EC RID: 8428
		[SProperty(98)]
		public uint warriorSoul;

		// Token: 0x040020ED RID: 8429
		[SProperty(99)]
		public uint matchScore;

		// Token: 0x040020EE RID: 8430
		[SProperty(100)]
		public List<WarpStoneInfo> warpStone;

		// Token: 0x040020EF RID: 8431
		[SProperty(101)]
		public Dictionary<string, CounterInfo> counterMgr;

		// Token: 0x040020F0 RID: 8432
		[SProperty(102)]
		public SceneRetinue sceneRetinue;

		// Token: 0x040020F1 RID: 8433
		[SProperty(103)]
		public uint pkCoin;

		// Token: 0x040020F2 RID: 8434
		[SProperty(77)]
		public byte funcNotify;

		// Token: 0x040020F3 RID: 8435
		[SProperty(80)]
		public FuncMaskProperty funcFlag;

		// Token: 0x040020F4 RID: 8436
		[SProperty(104)]
		public PlayerAvatar avatar;

		// Token: 0x040020F5 RID: 8437
		[SProperty(105)]
		public uint aliveCoin;

		// Token: 0x040020F6 RID: 8438
		[SProperty(106)]
		public Vip vip;

		// Token: 0x040020F7 RID: 8439
		[SProperty(107)]
		public uint createTime;

		// Token: 0x040020F8 RID: 8440
		[SProperty(108)]
		public uint newBoot;

		// Token: 0x040020F9 RID: 8441
		[SProperty(109)]
		public uint deathTowerWipeoutEndTime;

		// Token: 0x040020FA RID: 8442
		[SProperty(110)]
		public byte guildPost;

		// Token: 0x040020FB RID: 8443
		[SProperty(111)]
		public uint guildContri;

		// Token: 0x040020FC RID: 8444
		[SProperty(112)]
		public byte guildShopId;

		// Token: 0x040020FD RID: 8445
		[SProperty(113)]
		public uint redPoint;

		// Token: 0x040020FE RID: 8446
		[SProperty(114)]
		public string guildName;

		// Token: 0x040020FF RID: 8447
		[SProperty(115)]
		public uint guildBattleNumber;

		// Token: 0x04002100 RID: 8448
		[SProperty(116)]
		public uint guildBattleScore;

		// Token: 0x04002101 RID: 8449
		[SProperty(117)]
		public GuildBattleMaskProperty guildBattleMask;

		// Token: 0x04002102 RID: 8450
		[SProperty(118)]
		public uint datilyTaskScore;

		// Token: 0x04002103 RID: 8451
		[SProperty(119)]
		public DailyTaskMaskProperty dailyTaskMask;

		// Token: 0x04002104 RID: 8452
		[SProperty(120)]
		public byte wudaoStatus;

		// Token: 0x04002105 RID: 8453
		[SProperty(121)]
		public uint monthCardExpireTime;

		// Token: 0x04002106 RID: 8454
		[SProperty(122)]
		public uint customData;

		// Token: 0x04002107 RID: 8455
		[SProperty(123)]
		public uint seasonLevel;

		// Token: 0x04002108 RID: 8456
		[SProperty(124)]
		public uint seasonStar;

		// Token: 0x04002109 RID: 8457
		[SProperty(125)]
		public List<byte> seasonUplevelRecord;

		// Token: 0x0400210A RID: 8458
		[SProperty(126)]
		public byte seasonAttr;

		// Token: 0x0400210B RID: 8459
		[SProperty(127)]
		public ushort seasonKingMarkCount;

		// Token: 0x0400210C RID: 8460
		[SProperty(128)]
		public uint auctionRefreshTime;

		// Token: 0x0400210D RID: 8461
		[SProperty(129)]
		public uint auctionAdditionBooth;

		// Token: 0x0400210E RID: 8462
		[SProperty(132)]
		public BootMaskProperty bootFlag;

		// Token: 0x0400210F RID: 8463
		[SProperty(130)]
		public uint goldJarPoint;

		// Token: 0x04002110 RID: 8464
		[SProperty(131)]
		public uint magJarPoint;

		// Token: 0x04002111 RID: 8465
		[SProperty(133)]
		public uint seasonExp;

		// Token: 0x04002112 RID: 8466
		[SProperty(134)]
		public uint followPetDataId;

		// Token: 0x04002113 RID: 8467
		[SProperty(135)]
		public List<uint> potionSets;

		// Token: 0x04002114 RID: 8468
		[SProperty(136)]
		public byte preOccu;

		// Token: 0x04002115 RID: 8469
		[SProperty(137)]
		public byte guildBattleLotteryStatus;

		// Token: 0x04002116 RID: 8470
		[SProperty(138)]
		public SkillMgr pvpSkillMgr;

		// Token: 0x04002117 RID: 8471
		[SProperty(139)]
		public SkillBars pvpSkillBars;

		// Token: 0x04002118 RID: 8472
		[SProperty(140)]
		public Sp pvpSp;

		// Token: 0x04002119 RID: 8473
		[SProperty(175)]
		public SkillMgr equalPvpSkillMgr;

		// Token: 0x0400211A RID: 8474
		[SProperty(176)]
		public SkillBars equalPvpSkillBars;

		// Token: 0x0400211B RID: 8475
		[SProperty(177)]
		public uint equalPvpSp;

		// Token: 0x0400211C RID: 8476
		[SProperty(141)]
		public uint achievementScore;

		// Token: 0x0400211D RID: 8477
		[SProperty(142)]
		public AchievementMaskProperty achievementMask;

		// Token: 0x0400211E RID: 8478
		[SProperty(143)]
		public List<ulong> weaponBar;

		// Token: 0x0400211F RID: 8479
		[SProperty(145)]
		public List<uint> packSizeAddition;

		// Token: 0x04002120 RID: 8480
		[SProperty(144)]
		public byte appointmentOccu;

		// Token: 0x04002121 RID: 8481
		[SProperty(146)]
		public byte moneyManageStatus;

		// Token: 0x04002122 RID: 8482
		[SProperty(147)]
		public MoneyManageMaskProperty moneyManageRewardMask;

		// Token: 0x04002123 RID: 8483
		[SProperty(148)]
		public uint scoreWarScore;

		// Token: 0x04002124 RID: 8484
		[SProperty(149)]
		public byte scoreWarBattleCount;

		// Token: 0x04002125 RID: 8485
		[SProperty(150)]
		public ScoreWarMaskProperty scoreWarRewardMask;

		// Token: 0x04002126 RID: 8486
		[SProperty(151)]
		public byte scoreWarWinBattleCount;

		// Token: 0x04002127 RID: 8487
		[SProperty(152)]
		public uint academicTotalGrowthValue;

		// Token: 0x04002128 RID: 8488
		[SProperty(153)]
		public uint masterDailyTaskGrowth;

		// Token: 0x04002129 RID: 8489
		[SProperty(154)]
		public uint masterAcademicTaskGrowth;

		// Token: 0x0400212A RID: 8490
		[SProperty(155)]
		public uint masterUplevelGrowth;

		// Token: 0x0400212B RID: 8491
		[SProperty(156)]
		public uint masterGiveEquipGrowth;

		// Token: 0x0400212C RID: 8492
		[SProperty(157)]
		public uint masterGiveGiftGrowth;

		// Token: 0x0400212D RID: 8493
		[SProperty(158)]
		public uint masterTeamClearDungeonGrowth;

		// Token: 0x0400212E RID: 8494
		[SProperty(159)]
		public uint goodTeacherValue;

		// Token: 0x0400212F RID: 8495
		[SProperty(161)]
		public byte showFashionWeapon;

		// Token: 0x04002130 RID: 8496
		[SProperty(162)]
		public uint weaponLeaseTickets;

		// Token: 0x04002131 RID: 8497
		[SProperty(163)]
		public string gameSets;

		// Token: 0x04002132 RID: 8498
		[SProperty(164)]
		public byte noviceGuideChooseFlag;

		// Token: 0x04002133 RID: 8499
		[SProperty(165)]
		public string adventureTeamName;

		// Token: 0x04002134 RID: 8500
		[SProperty(166)]
		public uint headFrame;

		// Token: 0x04002135 RID: 8501
		[SProperty(167)]
		public PlayerWearedTitleInfo wearedTitleInfo;

		// Token: 0x04002136 RID: 8502
		[SProperty(168)]
		public ulong newTitleGuid;

		// Token: 0x04002137 RID: 8503
		[SProperty(169)]
		public int chijiHp;

		// Token: 0x04002138 RID: 8504
		[SProperty(170)]
		public int chijiMp;

		// Token: 0x04002139 RID: 8505
		[SProperty(171)]
		public string packageTypeStr;

		// Token: 0x0400213A RID: 8506
		[SProperty(172)]
		public uint guildEmblemLvl;

		// Token: 0x0400213B RID: 8507
		[SProperty(173)]
		public byte oppoVipLevel;

		// Token: 0x0400213C RID: 8508
		[SProperty(174)]
		public uint chijiScore;

		// Token: 0x0400213D RID: 8509
		[SProperty(178)]
		public uint accountAchievementScore;

		// Token: 0x0400213E RID: 8510
		[SProperty(179)]
		public uint mallPoint;

		// Token: 0x0400213F RID: 8511
		[SProperty(180)]
		public uint equipScore;

		// Token: 0x04002140 RID: 8512
		[SProperty(181)]
		public uint adventureCoin;

		// Token: 0x04002141 RID: 8513
		[SProperty(54)]
		public uint gameOptions;

		// Token: 0x04002142 RID: 8514
		[SProperty(182)]
		public uint creditPoint;

		// Token: 0x04002143 RID: 8515
		[SProperty(183)]
		public uint creditPointMonthGet;
	}
}
