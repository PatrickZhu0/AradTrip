using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000516 RID: 1302
	public class MonsterAttributeTable : IFlatbufferObject
	{
		// Token: 0x170011BA RID: 4538
		// (get) Token: 0x060042C7 RID: 17095 RVA: 0x000D90A0 File Offset: 0x000D74A0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060042C8 RID: 17096 RVA: 0x000D90AD File Offset: 0x000D74AD
		public static MonsterAttributeTable GetRootAsMonsterAttributeTable(ByteBuffer _bb)
		{
			return MonsterAttributeTable.GetRootAsMonsterAttributeTable(_bb, new MonsterAttributeTable());
		}

		// Token: 0x060042C9 RID: 17097 RVA: 0x000D90BA File Offset: 0x000D74BA
		public static MonsterAttributeTable GetRootAsMonsterAttributeTable(ByteBuffer _bb, MonsterAttributeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060042CA RID: 17098 RVA: 0x000D90D6 File Offset: 0x000D74D6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060042CB RID: 17099 RVA: 0x000D90F0 File Offset: 0x000D74F0
		public MonsterAttributeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170011BB RID: 4539
		// (get) Token: 0x060042CC RID: 17100 RVA: 0x000D90FC File Offset: 0x000D74FC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011BC RID: 4540
		// (get) Token: 0x060042CD RID: 17101 RVA: 0x000D9148 File Offset: 0x000D7548
		public int Difficulty
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011BD RID: 4541
		// (get) Token: 0x060042CE RID: 17102 RVA: 0x000D9194 File Offset: 0x000D7594
		public int MonsterType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011BE RID: 4542
		// (get) Token: 0x060042CF RID: 17103 RVA: 0x000D91E0 File Offset: 0x000D75E0
		public int MonsterMode
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011BF RID: 4543
		// (get) Token: 0x060042D0 RID: 17104 RVA: 0x000D922C File Offset: 0x000D762C
		public int level
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011C0 RID: 4544
		// (get) Token: 0x060042D1 RID: 17105 RVA: 0x000D9278 File Offset: 0x000D7678
		public int maxHp
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011C1 RID: 4545
		// (get) Token: 0x060042D2 RID: 17106 RVA: 0x000D92C4 File Offset: 0x000D76C4
		public int maxMp
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011C2 RID: 4546
		// (get) Token: 0x060042D3 RID: 17107 RVA: 0x000D9310 File Offset: 0x000D7710
		public int hpRecover
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011C3 RID: 4547
		// (get) Token: 0x060042D4 RID: 17108 RVA: 0x000D935C File Offset: 0x000D775C
		public int mpRecover
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011C4 RID: 4548
		// (get) Token: 0x060042D5 RID: 17109 RVA: 0x000D93A8 File Offset: 0x000D77A8
		public int attack
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011C5 RID: 4549
		// (get) Token: 0x060042D6 RID: 17110 RVA: 0x000D93F4 File Offset: 0x000D77F4
		public int magicAttack
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011C6 RID: 4550
		// (get) Token: 0x060042D7 RID: 17111 RVA: 0x000D9440 File Offset: 0x000D7840
		public int defence
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011C7 RID: 4551
		// (get) Token: 0x060042D8 RID: 17112 RVA: 0x000D948C File Offset: 0x000D788C
		public int magicDefence
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011C8 RID: 4552
		// (get) Token: 0x060042D9 RID: 17113 RVA: 0x000D94D8 File Offset: 0x000D78D8
		public int attackSpeed
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011C9 RID: 4553
		// (get) Token: 0x060042DA RID: 17114 RVA: 0x000D9524 File Offset: 0x000D7924
		public int spellSpeed
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011CA RID: 4554
		// (get) Token: 0x060042DB RID: 17115 RVA: 0x000D9570 File Offset: 0x000D7970
		public int moveSpeed
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011CB RID: 4555
		// (get) Token: 0x060042DC RID: 17116 RVA: 0x000D95BC File Offset: 0x000D79BC
		public int ciriticalAttack
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011CC RID: 4556
		// (get) Token: 0x060042DD RID: 17117 RVA: 0x000D9608 File Offset: 0x000D7A08
		public int ciriticalMagicAttack
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011CD RID: 4557
		// (get) Token: 0x060042DE RID: 17118 RVA: 0x000D9654 File Offset: 0x000D7A54
		public int dex
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011CE RID: 4558
		// (get) Token: 0x060042DF RID: 17119 RVA: 0x000D96A0 File Offset: 0x000D7AA0
		public int dodge
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011CF RID: 4559
		// (get) Token: 0x060042E0 RID: 17120 RVA: 0x000D96EC File Offset: 0x000D7AEC
		public int frozen
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011D0 RID: 4560
		// (get) Token: 0x060042E1 RID: 17121 RVA: 0x000D9738 File Offset: 0x000D7B38
		public int hard
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011D1 RID: 4561
		// (get) Token: 0x060042E2 RID: 17122 RVA: 0x000D9784 File Offset: 0x000D7B84
		public int cdReduceRate
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011D2 RID: 4562
		// (get) Token: 0x060042E3 RID: 17123 RVA: 0x000D97D0 File Offset: 0x000D7BD0
		public int exp
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011D3 RID: 4563
		// (get) Token: 0x060042E4 RID: 17124 RVA: 0x000D981C File Offset: 0x000D7C1C
		public int baseAtk
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011D4 RID: 4564
		// (get) Token: 0x060042E5 RID: 17125 RVA: 0x000D9868 File Offset: 0x000D7C68
		public int baseInt
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011D5 RID: 4565
		// (get) Token: 0x060042E6 RID: 17126 RVA: 0x000D98B4 File Offset: 0x000D7CB4
		public int sta
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011D6 RID: 4566
		// (get) Token: 0x060042E7 RID: 17127 RVA: 0x000D9900 File Offset: 0x000D7D00
		public int spr
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011D7 RID: 4567
		// (get) Token: 0x060042E8 RID: 17128 RVA: 0x000D994C File Offset: 0x000D7D4C
		public int ignoreDefAttackAdd
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011D8 RID: 4568
		// (get) Token: 0x060042E9 RID: 17129 RVA: 0x000D9998 File Offset: 0x000D7D98
		public int ignoreDefMagicAttackAdd
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : (1276697354 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060042EA RID: 17130 RVA: 0x000D99E4 File Offset: 0x000D7DE4
		public static Offset<MonsterAttributeTable> CreateMonsterAttributeTable(FlatBufferBuilder builder, int ID = 0, int Difficulty = 0, int MonsterType = 0, int MonsterMode = 0, int level = 0, int maxHp = 0, int maxMp = 0, int hpRecover = 0, int mpRecover = 0, int attack = 0, int magicAttack = 0, int defence = 0, int magicDefence = 0, int attackSpeed = 0, int spellSpeed = 0, int moveSpeed = 0, int ciriticalAttack = 0, int ciriticalMagicAttack = 0, int dex = 0, int dodge = 0, int frozen = 0, int hard = 0, int cdReduceRate = 0, int exp = 0, int baseAtk = 0, int baseInt = 0, int sta = 0, int spr = 0, int ignoreDefAttackAdd = 0, int ignoreDefMagicAttackAdd = 0)
		{
			builder.StartObject(30);
			MonsterAttributeTable.AddIgnoreDefMagicAttackAdd(builder, ignoreDefMagicAttackAdd);
			MonsterAttributeTable.AddIgnoreDefAttackAdd(builder, ignoreDefAttackAdd);
			MonsterAttributeTable.AddSpr(builder, spr);
			MonsterAttributeTable.AddSta(builder, sta);
			MonsterAttributeTable.AddBaseInt(builder, baseInt);
			MonsterAttributeTable.AddBaseAtk(builder, baseAtk);
			MonsterAttributeTable.AddExp(builder, exp);
			MonsterAttributeTable.AddCdReduceRate(builder, cdReduceRate);
			MonsterAttributeTable.AddHard(builder, hard);
			MonsterAttributeTable.AddFrozen(builder, frozen);
			MonsterAttributeTable.AddDodge(builder, dodge);
			MonsterAttributeTable.AddDex(builder, dex);
			MonsterAttributeTable.AddCiriticalMagicAttack(builder, ciriticalMagicAttack);
			MonsterAttributeTable.AddCiriticalAttack(builder, ciriticalAttack);
			MonsterAttributeTable.AddMoveSpeed(builder, moveSpeed);
			MonsterAttributeTable.AddSpellSpeed(builder, spellSpeed);
			MonsterAttributeTable.AddAttackSpeed(builder, attackSpeed);
			MonsterAttributeTable.AddMagicDefence(builder, magicDefence);
			MonsterAttributeTable.AddDefence(builder, defence);
			MonsterAttributeTable.AddMagicAttack(builder, magicAttack);
			MonsterAttributeTable.AddAttack(builder, attack);
			MonsterAttributeTable.AddMpRecover(builder, mpRecover);
			MonsterAttributeTable.AddHpRecover(builder, hpRecover);
			MonsterAttributeTable.AddMaxMp(builder, maxMp);
			MonsterAttributeTable.AddMaxHp(builder, maxHp);
			MonsterAttributeTable.AddLevel(builder, level);
			MonsterAttributeTable.AddMonsterMode(builder, MonsterMode);
			MonsterAttributeTable.AddMonsterType(builder, MonsterType);
			MonsterAttributeTable.AddDifficulty(builder, Difficulty);
			MonsterAttributeTable.AddID(builder, ID);
			return MonsterAttributeTable.EndMonsterAttributeTable(builder);
		}

		// Token: 0x060042EB RID: 17131 RVA: 0x000D9AEC File Offset: 0x000D7EEC
		public static void StartMonsterAttributeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(30);
		}

		// Token: 0x060042EC RID: 17132 RVA: 0x000D9AF6 File Offset: 0x000D7EF6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060042ED RID: 17133 RVA: 0x000D9B01 File Offset: 0x000D7F01
		public static void AddDifficulty(FlatBufferBuilder builder, int Difficulty)
		{
			builder.AddInt(1, Difficulty, 0);
		}

		// Token: 0x060042EE RID: 17134 RVA: 0x000D9B0C File Offset: 0x000D7F0C
		public static void AddMonsterType(FlatBufferBuilder builder, int MonsterType)
		{
			builder.AddInt(2, MonsterType, 0);
		}

		// Token: 0x060042EF RID: 17135 RVA: 0x000D9B17 File Offset: 0x000D7F17
		public static void AddMonsterMode(FlatBufferBuilder builder, int MonsterMode)
		{
			builder.AddInt(3, MonsterMode, 0);
		}

		// Token: 0x060042F0 RID: 17136 RVA: 0x000D9B22 File Offset: 0x000D7F22
		public static void AddLevel(FlatBufferBuilder builder, int level)
		{
			builder.AddInt(4, level, 0);
		}

		// Token: 0x060042F1 RID: 17137 RVA: 0x000D9B2D File Offset: 0x000D7F2D
		public static void AddMaxHp(FlatBufferBuilder builder, int maxHp)
		{
			builder.AddInt(5, maxHp, 0);
		}

		// Token: 0x060042F2 RID: 17138 RVA: 0x000D9B38 File Offset: 0x000D7F38
		public static void AddMaxMp(FlatBufferBuilder builder, int maxMp)
		{
			builder.AddInt(6, maxMp, 0);
		}

		// Token: 0x060042F3 RID: 17139 RVA: 0x000D9B43 File Offset: 0x000D7F43
		public static void AddHpRecover(FlatBufferBuilder builder, int hpRecover)
		{
			builder.AddInt(7, hpRecover, 0);
		}

		// Token: 0x060042F4 RID: 17140 RVA: 0x000D9B4E File Offset: 0x000D7F4E
		public static void AddMpRecover(FlatBufferBuilder builder, int mpRecover)
		{
			builder.AddInt(8, mpRecover, 0);
		}

		// Token: 0x060042F5 RID: 17141 RVA: 0x000D9B59 File Offset: 0x000D7F59
		public static void AddAttack(FlatBufferBuilder builder, int attack)
		{
			builder.AddInt(9, attack, 0);
		}

		// Token: 0x060042F6 RID: 17142 RVA: 0x000D9B65 File Offset: 0x000D7F65
		public static void AddMagicAttack(FlatBufferBuilder builder, int magicAttack)
		{
			builder.AddInt(10, magicAttack, 0);
		}

		// Token: 0x060042F7 RID: 17143 RVA: 0x000D9B71 File Offset: 0x000D7F71
		public static void AddDefence(FlatBufferBuilder builder, int defence)
		{
			builder.AddInt(11, defence, 0);
		}

		// Token: 0x060042F8 RID: 17144 RVA: 0x000D9B7D File Offset: 0x000D7F7D
		public static void AddMagicDefence(FlatBufferBuilder builder, int magicDefence)
		{
			builder.AddInt(12, magicDefence, 0);
		}

		// Token: 0x060042F9 RID: 17145 RVA: 0x000D9B89 File Offset: 0x000D7F89
		public static void AddAttackSpeed(FlatBufferBuilder builder, int attackSpeed)
		{
			builder.AddInt(13, attackSpeed, 0);
		}

		// Token: 0x060042FA RID: 17146 RVA: 0x000D9B95 File Offset: 0x000D7F95
		public static void AddSpellSpeed(FlatBufferBuilder builder, int spellSpeed)
		{
			builder.AddInt(14, spellSpeed, 0);
		}

		// Token: 0x060042FB RID: 17147 RVA: 0x000D9BA1 File Offset: 0x000D7FA1
		public static void AddMoveSpeed(FlatBufferBuilder builder, int moveSpeed)
		{
			builder.AddInt(15, moveSpeed, 0);
		}

		// Token: 0x060042FC RID: 17148 RVA: 0x000D9BAD File Offset: 0x000D7FAD
		public static void AddCiriticalAttack(FlatBufferBuilder builder, int ciriticalAttack)
		{
			builder.AddInt(16, ciriticalAttack, 0);
		}

		// Token: 0x060042FD RID: 17149 RVA: 0x000D9BB9 File Offset: 0x000D7FB9
		public static void AddCiriticalMagicAttack(FlatBufferBuilder builder, int ciriticalMagicAttack)
		{
			builder.AddInt(17, ciriticalMagicAttack, 0);
		}

		// Token: 0x060042FE RID: 17150 RVA: 0x000D9BC5 File Offset: 0x000D7FC5
		public static void AddDex(FlatBufferBuilder builder, int dex)
		{
			builder.AddInt(18, dex, 0);
		}

		// Token: 0x060042FF RID: 17151 RVA: 0x000D9BD1 File Offset: 0x000D7FD1
		public static void AddDodge(FlatBufferBuilder builder, int dodge)
		{
			builder.AddInt(19, dodge, 0);
		}

		// Token: 0x06004300 RID: 17152 RVA: 0x000D9BDD File Offset: 0x000D7FDD
		public static void AddFrozen(FlatBufferBuilder builder, int frozen)
		{
			builder.AddInt(20, frozen, 0);
		}

		// Token: 0x06004301 RID: 17153 RVA: 0x000D9BE9 File Offset: 0x000D7FE9
		public static void AddHard(FlatBufferBuilder builder, int hard)
		{
			builder.AddInt(21, hard, 0);
		}

		// Token: 0x06004302 RID: 17154 RVA: 0x000D9BF5 File Offset: 0x000D7FF5
		public static void AddCdReduceRate(FlatBufferBuilder builder, int cdReduceRate)
		{
			builder.AddInt(22, cdReduceRate, 0);
		}

		// Token: 0x06004303 RID: 17155 RVA: 0x000D9C01 File Offset: 0x000D8001
		public static void AddExp(FlatBufferBuilder builder, int exp)
		{
			builder.AddInt(23, exp, 0);
		}

		// Token: 0x06004304 RID: 17156 RVA: 0x000D9C0D File Offset: 0x000D800D
		public static void AddBaseAtk(FlatBufferBuilder builder, int baseAtk)
		{
			builder.AddInt(24, baseAtk, 0);
		}

		// Token: 0x06004305 RID: 17157 RVA: 0x000D9C19 File Offset: 0x000D8019
		public static void AddBaseInt(FlatBufferBuilder builder, int baseInt)
		{
			builder.AddInt(25, baseInt, 0);
		}

		// Token: 0x06004306 RID: 17158 RVA: 0x000D9C25 File Offset: 0x000D8025
		public static void AddSta(FlatBufferBuilder builder, int sta)
		{
			builder.AddInt(26, sta, 0);
		}

		// Token: 0x06004307 RID: 17159 RVA: 0x000D9C31 File Offset: 0x000D8031
		public static void AddSpr(FlatBufferBuilder builder, int spr)
		{
			builder.AddInt(27, spr, 0);
		}

		// Token: 0x06004308 RID: 17160 RVA: 0x000D9C3D File Offset: 0x000D803D
		public static void AddIgnoreDefAttackAdd(FlatBufferBuilder builder, int ignoreDefAttackAdd)
		{
			builder.AddInt(28, ignoreDefAttackAdd, 0);
		}

		// Token: 0x06004309 RID: 17161 RVA: 0x000D9C49 File Offset: 0x000D8049
		public static void AddIgnoreDefMagicAttackAdd(FlatBufferBuilder builder, int ignoreDefMagicAttackAdd)
		{
			builder.AddInt(29, ignoreDefMagicAttackAdd, 0);
		}

		// Token: 0x0600430A RID: 17162 RVA: 0x000D9C58 File Offset: 0x000D8058
		public static Offset<MonsterAttributeTable> EndMonsterAttributeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MonsterAttributeTable>(value);
		}

		// Token: 0x0600430B RID: 17163 RVA: 0x000D9C72 File Offset: 0x000D8072
		public static void FinishMonsterAttributeTableBuffer(FlatBufferBuilder builder, Offset<MonsterAttributeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040018DC RID: 6364
		private Table __p = new Table();

		// Token: 0x02000517 RID: 1303
		public enum eCrypt
		{
			// Token: 0x040018DE RID: 6366
			code = 1276697354
		}
	}
}
