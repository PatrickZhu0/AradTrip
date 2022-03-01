using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003B8 RID: 952
	public class EffectTable : IFlatbufferObject
	{
		// Token: 0x170009C4 RID: 2500
		// (get) Token: 0x06002A8E RID: 10894 RVA: 0x0009F3F0 File Offset: 0x0009D7F0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002A8F RID: 10895 RVA: 0x0009F3FD File Offset: 0x0009D7FD
		public static EffectTable GetRootAsEffectTable(ByteBuffer _bb)
		{
			return EffectTable.GetRootAsEffectTable(_bb, new EffectTable());
		}

		// Token: 0x06002A90 RID: 10896 RVA: 0x0009F40A File Offset: 0x0009D80A
		public static EffectTable GetRootAsEffectTable(ByteBuffer _bb, EffectTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002A91 RID: 10897 RVA: 0x0009F426 File Offset: 0x0009D826
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002A92 RID: 10898 RVA: 0x0009F440 File Offset: 0x0009D840
		public EffectTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170009C5 RID: 2501
		// (get) Token: 0x06002A93 RID: 10899 RVA: 0x0009F44C File Offset: 0x0009D84C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009C6 RID: 2502
		// (get) Token: 0x06002A94 RID: 10900 RVA: 0x0009F498 File Offset: 0x0009D898
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002A95 RID: 10901 RVA: 0x0009F4DA File Offset: 0x0009D8DA
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170009C7 RID: 2503
		// (get) Token: 0x06002A96 RID: 10902 RVA: 0x0009F4E8 File Offset: 0x0009D8E8
		public int SkillID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009C8 RID: 2504
		// (get) Token: 0x06002A97 RID: 10903 RVA: 0x0009F534 File Offset: 0x0009D934
		public EffectTable.eEffectTargetType EffectTargetType
		{
			get
			{
				int num = this.__p.__offset(10);
				return (EffectTable.eEffectTargetType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009C9 RID: 2505
		// (get) Token: 0x06002A98 RID: 10904 RVA: 0x0009F578 File Offset: 0x0009D978
		public int HasDamage
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009CA RID: 2506
		// (get) Token: 0x06002A99 RID: 10905 RVA: 0x0009F5C4 File Offset: 0x0009D9C4
		public int IsFriendDamage
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009CB RID: 2507
		// (get) Token: 0x06002A9A RID: 10906 RVA: 0x0009F610 File Offset: 0x0009DA10
		public EffectTable.eAvoidDamageType AvoidDamageType
		{
			get
			{
				int num = this.__p.__offset(16);
				return (EffectTable.eAvoidDamageType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009CC RID: 2508
		// (get) Token: 0x06002A9B RID: 10907 RVA: 0x0009F654 File Offset: 0x0009DA54
		public EffectTable.eDamageType DamageType
		{
			get
			{
				int num = this.__p.__offset(18);
				return (EffectTable.eDamageType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009CD RID: 2509
		// (get) Token: 0x06002A9C RID: 10908 RVA: 0x0009F698 File Offset: 0x0009DA98
		public EffectTable.eDamageDistanceType DamageDistanceType
		{
			get
			{
				int num = this.__p.__offset(20);
				return (EffectTable.eDamageDistanceType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009CE RID: 2510
		// (get) Token: 0x06002A9D RID: 10909 RVA: 0x0009F6DC File Offset: 0x0009DADC
		public int DamageMaxCount
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009CF RID: 2511
		// (get) Token: 0x06002A9E RID: 10910 RVA: 0x0009F728 File Offset: 0x0009DB28
		public UnionCell AttachCritical
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170009D0 RID: 2512
		// (get) Token: 0x06002A9F RID: 10911 RVA: 0x0009F780 File Offset: 0x0009DB80
		public UnionCell HitThroughRate
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170009D1 RID: 2513
		// (get) Token: 0x06002AA0 RID: 10912 RVA: 0x0009F7D8 File Offset: 0x0009DBD8
		public int MagicElementType
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009D2 RID: 2514
		// (get) Token: 0x06002AA1 RID: 10913 RVA: 0x0009F824 File Offset: 0x0009DC24
		public bool MagicElementISuse
		{
			get
			{
				int num = this.__p.__offset(30);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x170009D3 RID: 2515
		// (get) Token: 0x06002AA2 RID: 10914 RVA: 0x0009F870 File Offset: 0x0009DC70
		public int HitSpreadOut
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009D4 RID: 2516
		// (get) Token: 0x06002AA3 RID: 10915 RVA: 0x0009F8BC File Offset: 0x0009DCBC
		public UnionCell DamageRateAPC
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170009D5 RID: 2517
		// (get) Token: 0x06002AA4 RID: 10916 RVA: 0x0009F914 File Offset: 0x0009DD14
		public UnionCell DamageRate
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170009D6 RID: 2518
		// (get) Token: 0x06002AA5 RID: 10917 RVA: 0x0009F96C File Offset: 0x0009DD6C
		public UnionCell DamageFixedValue
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170009D7 RID: 2519
		// (get) Token: 0x06002AA6 RID: 10918 RVA: 0x0009F9C4 File Offset: 0x0009DDC4
		public UnionCell DamageRatePVP
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170009D8 RID: 2520
		// (get) Token: 0x06002AA7 RID: 10919 RVA: 0x0009FA1C File Offset: 0x0009DE1C
		public UnionCell DamageFixedValuePVP
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x06002AA8 RID: 10920 RVA: 0x0009FA74 File Offset: 0x0009DE74
		public int AttachMonsterRaceArray(int j)
		{
			int num = this.__p.__offset(44);
			return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170009D9 RID: 2521
		// (get) Token: 0x06002AA9 RID: 10921 RVA: 0x0009FAC4 File Offset: 0x0009DEC4
		public int AttachMonsterRaceLength
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002AAA RID: 10922 RVA: 0x0009FAF7 File Offset: 0x0009DEF7
		public ArraySegment<byte>? GetAttachMonsterRaceBytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x170009DA RID: 2522
		// (get) Token: 0x06002AAB RID: 10923 RVA: 0x0009FB06 File Offset: 0x0009DF06
		public FlatBufferArray<int> AttachMonsterRace
		{
			get
			{
				if (this.AttachMonsterRaceValue == null)
				{
					this.AttachMonsterRaceValue = new FlatBufferArray<int>(new Func<int, int>(this.AttachMonsterRaceArray), this.AttachMonsterRaceLength);
				}
				return this.AttachMonsterRaceValue;
			}
		}

		// Token: 0x170009DB RID: 2523
		// (get) Token: 0x06002AAC RID: 10924 RVA: 0x0009FB38 File Offset: 0x0009DF38
		public UnionCell AttachDamageRate
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170009DC RID: 2524
		// (get) Token: 0x06002AAD RID: 10925 RVA: 0x0009FB90 File Offset: 0x0009DF90
		public bool IsCanMiss
		{
			get
			{
				int num = this.__p.__offset(48);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x170009DD RID: 2525
		// (get) Token: 0x06002AAE RID: 10926 RVA: 0x0009FBDC File Offset: 0x0009DFDC
		public bool HitGrab
		{
			get
			{
				int num = this.__p.__offset(50);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x170009DE RID: 2526
		// (get) Token: 0x06002AAF RID: 10927 RVA: 0x0009FC28 File Offset: 0x0009E028
		public UnionCell HardValue
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170009DF RID: 2527
		// (get) Token: 0x06002AB0 RID: 10928 RVA: 0x0009FC80 File Offset: 0x0009E080
		public bool UseStandardWeight
		{
			get
			{
				int num = this.__p.__offset(54);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002AB1 RID: 10929 RVA: 0x0009FCCC File Offset: 0x0009E0CC
		public int ClearTargetStateArray(int j)
		{
			int num = this.__p.__offset(56);
			return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170009E0 RID: 2528
		// (get) Token: 0x06002AB2 RID: 10930 RVA: 0x0009FD1C File Offset: 0x0009E11C
		public int ClearTargetStateLength
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002AB3 RID: 10931 RVA: 0x0009FD4F File Offset: 0x0009E14F
		public ArraySegment<byte>? GetClearTargetStateBytes()
		{
			return this.__p.__vector_as_arraysegment(56);
		}

		// Token: 0x170009E1 RID: 2529
		// (get) Token: 0x06002AB4 RID: 10932 RVA: 0x0009FD5E File Offset: 0x0009E15E
		public FlatBufferArray<int> ClearTargetState
		{
			get
			{
				if (this.ClearTargetStateValue == null)
				{
					this.ClearTargetStateValue = new FlatBufferArray<int>(new Func<int, int>(this.ClearTargetStateArray), this.ClearTargetStateLength);
				}
				return this.ClearTargetStateValue;
			}
		}

		// Token: 0x170009E2 RID: 2530
		// (get) Token: 0x06002AB5 RID: 10933 RVA: 0x0009FD90 File Offset: 0x0009E190
		public bool UseNoBlock
		{
			get
			{
				int num = this.__p.__offset(58);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x170009E3 RID: 2531
		// (get) Token: 0x06002AB6 RID: 10934 RVA: 0x0009FDDC File Offset: 0x0009E1DC
		public int FrozenDistanceMax
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009E4 RID: 2532
		// (get) Token: 0x06002AB7 RID: 10935 RVA: 0x0009FE28 File Offset: 0x0009E228
		public UnionCell Attack
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170009E5 RID: 2533
		// (get) Token: 0x06002AB8 RID: 10936 RVA: 0x0009FE80 File Offset: 0x0009E280
		public UnionCell FloatingRate
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170009E6 RID: 2534
		// (get) Token: 0x06002AB9 RID: 10937 RVA: 0x0009FED8 File Offset: 0x0009E2D8
		public UnionCell HitFloatXForce
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170009E7 RID: 2535
		// (get) Token: 0x06002ABA RID: 10938 RVA: 0x0009FF30 File Offset: 0x0009E330
		public UnionCell HitFloatYForce
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x06002ABB RID: 10939 RVA: 0x0009FF88 File Offset: 0x0009E388
		public int RepeatAttackIntervalArray(int j)
		{
			int num = this.__p.__offset(70);
			return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170009E8 RID: 2536
		// (get) Token: 0x06002ABC RID: 10940 RVA: 0x0009FFD8 File Offset: 0x0009E3D8
		public int RepeatAttackIntervalLength
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002ABD RID: 10941 RVA: 0x000A000B File Offset: 0x0009E40B
		public ArraySegment<byte>? GetRepeatAttackIntervalBytes()
		{
			return this.__p.__vector_as_arraysegment(70);
		}

		// Token: 0x170009E9 RID: 2537
		// (get) Token: 0x06002ABE RID: 10942 RVA: 0x000A001A File Offset: 0x0009E41A
		public FlatBufferArray<int> RepeatAttackInterval
		{
			get
			{
				if (this.RepeatAttackIntervalValue == null)
				{
					this.RepeatAttackIntervalValue = new FlatBufferArray<int>(new Func<int, int>(this.RepeatAttackIntervalArray), this.RepeatAttackIntervalLength);
				}
				return this.RepeatAttackIntervalValue;
			}
		}

		// Token: 0x170009EA RID: 2538
		// (get) Token: 0x06002ABF RID: 10943 RVA: 0x000A004C File Offset: 0x0009E44C
		public int HitDeadFall
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009EB RID: 2539
		// (get) Token: 0x06002AC0 RID: 10944 RVA: 0x000A0098 File Offset: 0x0009E498
		public EffectTable.eHitEffect HitEffect
		{
			get
			{
				int num = this.__p.__offset(74);
				return (EffectTable.eHitEffect)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009EC RID: 2540
		// (get) Token: 0x06002AC1 RID: 10945 RVA: 0x000A00DC File Offset: 0x0009E4DC
		public bool HitPause
		{
			get
			{
				int num = this.__p.__offset(76);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x170009ED RID: 2541
		// (get) Token: 0x06002AC2 RID: 10946 RVA: 0x000A0128 File Offset: 0x0009E528
		public int HitPauseTime
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009EE RID: 2542
		// (get) Token: 0x06002AC3 RID: 10947 RVA: 0x000A0174 File Offset: 0x0009E574
		public bool HitEffectPause
		{
			get
			{
				int num = this.__p.__offset(80);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x170009EF RID: 2543
		// (get) Token: 0x06002AC4 RID: 10948 RVA: 0x000A01C0 File Offset: 0x0009E5C0
		public int HitScreenShakeTime
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009F0 RID: 2544
		// (get) Token: 0x06002AC5 RID: 10949 RVA: 0x000A020C File Offset: 0x0009E60C
		public int HitScreenShakeSpeed
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009F1 RID: 2545
		// (get) Token: 0x06002AC6 RID: 10950 RVA: 0x000A0258 File Offset: 0x0009E658
		public int HitScreenShakeX
		{
			get
			{
				int num = this.__p.__offset(86);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009F2 RID: 2546
		// (get) Token: 0x06002AC7 RID: 10951 RVA: 0x000A02A4 File Offset: 0x0009E6A4
		public int HitScreenShakeY
		{
			get
			{
				int num = this.__p.__offset(88);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009F3 RID: 2547
		// (get) Token: 0x06002AC8 RID: 10952 RVA: 0x000A02F0 File Offset: 0x0009E6F0
		public int ScreenShakeID
		{
			get
			{
				int num = this.__p.__offset(90);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002AC9 RID: 10953 RVA: 0x000A033C File Offset: 0x0009E73C
		public int AttachEntityArray(int j)
		{
			int num = this.__p.__offset(92);
			return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170009F4 RID: 2548
		// (get) Token: 0x06002ACA RID: 10954 RVA: 0x000A038C File Offset: 0x0009E78C
		public int AttachEntityLength
		{
			get
			{
				int num = this.__p.__offset(92);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002ACB RID: 10955 RVA: 0x000A03BF File Offset: 0x0009E7BF
		public ArraySegment<byte>? GetAttachEntityBytes()
		{
			return this.__p.__vector_as_arraysegment(92);
		}

		// Token: 0x170009F5 RID: 2549
		// (get) Token: 0x06002ACC RID: 10956 RVA: 0x000A03CE File Offset: 0x0009E7CE
		public FlatBufferArray<int> AttachEntity
		{
			get
			{
				if (this.AttachEntityValue == null)
				{
					this.AttachEntityValue = new FlatBufferArray<int>(new Func<int, int>(this.AttachEntityArray), this.AttachEntityLength);
				}
				return this.AttachEntityValue;
			}
		}

		// Token: 0x170009F6 RID: 2550
		// (get) Token: 0x06002ACD RID: 10957 RVA: 0x000A0400 File Offset: 0x0009E800
		public int SummonID
		{
			get
			{
				int num = this.__p.__offset(94);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009F7 RID: 2551
		// (get) Token: 0x06002ACE RID: 10958 RVA: 0x000A044C File Offset: 0x0009E84C
		public EffectTable.eSummonPosType SummonPosType
		{
			get
			{
				int num = this.__p.__offset(96);
				return (EffectTable.eSummonPosType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002ACF RID: 10959 RVA: 0x000A0490 File Offset: 0x0009E890
		public int SummonPosType2Array(int j)
		{
			int num = this.__p.__offset(98);
			return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170009F8 RID: 2552
		// (get) Token: 0x06002AD0 RID: 10960 RVA: 0x000A04E0 File Offset: 0x0009E8E0
		public int SummonPosType2Length
		{
			get
			{
				int num = this.__p.__offset(98);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002AD1 RID: 10961 RVA: 0x000A0513 File Offset: 0x0009E913
		public ArraySegment<byte>? GetSummonPosType2Bytes()
		{
			return this.__p.__vector_as_arraysegment(98);
		}

		// Token: 0x170009F9 RID: 2553
		// (get) Token: 0x06002AD2 RID: 10962 RVA: 0x000A0522 File Offset: 0x0009E922
		public FlatBufferArray<int> SummonPosType2
		{
			get
			{
				if (this.SummonPosType2Value == null)
				{
					this.SummonPosType2Value = new FlatBufferArray<int>(new Func<int, int>(this.SummonPosType2Array), this.SummonPosType2Length);
				}
				return this.SummonPosType2Value;
			}
		}

		// Token: 0x170009FA RID: 2554
		// (get) Token: 0x06002AD3 RID: 10963 RVA: 0x000A0554 File Offset: 0x0009E954
		public int SummonDisplay
		{
			get
			{
				int num = this.__p.__offset(100);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009FB RID: 2555
		// (get) Token: 0x06002AD4 RID: 10964 RVA: 0x000A05A0 File Offset: 0x0009E9A0
		public UnionCell SummonNum
		{
			get
			{
				int num = this.__p.__offset(102);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170009FC RID: 2556
		// (get) Token: 0x06002AD5 RID: 10965 RVA: 0x000A05F8 File Offset: 0x0009E9F8
		public UnionCell SummonLevel
		{
			get
			{
				int num = this.__p.__offset(104);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170009FD RID: 2557
		// (get) Token: 0x06002AD6 RID: 10966 RVA: 0x000A0650 File Offset: 0x0009EA50
		public int SummonNumLimit
		{
			get
			{
				int num = this.__p.__offset(106);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009FE RID: 2558
		// (get) Token: 0x06002AD7 RID: 10967 RVA: 0x000A069C File Offset: 0x0009EA9C
		public UnionCell SummonGroupNumLimit
		{
			get
			{
				int num = this.__p.__offset(108);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170009FF RID: 2559
		// (get) Token: 0x06002AD8 RID: 10968 RVA: 0x000A06F4 File Offset: 0x0009EAF4
		public int SummonGroup
		{
			get
			{
				int num = this.__p.__offset(110);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A00 RID: 2560
		// (get) Token: 0x06002AD9 RID: 10969 RVA: 0x000A0740 File Offset: 0x0009EB40
		public int SummonRelation
		{
			get
			{
				int num = this.__p.__offset(112);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002ADA RID: 10970 RVA: 0x000A078C File Offset: 0x0009EB8C
		public int SummonRandListArray(int j)
		{
			int num = this.__p.__offset(114);
			return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000A01 RID: 2561
		// (get) Token: 0x06002ADB RID: 10971 RVA: 0x000A07DC File Offset: 0x0009EBDC
		public int SummonRandListLength
		{
			get
			{
				int num = this.__p.__offset(114);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002ADC RID: 10972 RVA: 0x000A080F File Offset: 0x0009EC0F
		public ArraySegment<byte>? GetSummonRandListBytes()
		{
			return this.__p.__vector_as_arraysegment(114);
		}

		// Token: 0x17000A02 RID: 2562
		// (get) Token: 0x06002ADD RID: 10973 RVA: 0x000A081E File Offset: 0x0009EC1E
		public FlatBufferArray<int> SummonRandList
		{
			get
			{
				if (this.SummonRandListValue == null)
				{
					this.SummonRandListValue = new FlatBufferArray<int>(new Func<int, int>(this.SummonRandListArray), this.SummonRandListLength);
				}
				return this.SummonRandListValue;
			}
		}

		// Token: 0x17000A03 RID: 2563
		// (get) Token: 0x06002ADE RID: 10974 RVA: 0x000A0850 File Offset: 0x0009EC50
		public int KillLastSummon
		{
			get
			{
				int num = this.__p.__offset(116);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A04 RID: 2564
		// (get) Token: 0x06002ADF RID: 10975 RVA: 0x000A089C File Offset: 0x0009EC9C
		public int BuffID
		{
			get
			{
				int num = this.__p.__offset(118);
				return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A05 RID: 2565
		// (get) Token: 0x06002AE0 RID: 10976 RVA: 0x000A08E8 File Offset: 0x0009ECE8
		public UnionCell BuffLevel
		{
			get
			{
				int num = this.__p.__offset(120);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000A06 RID: 2566
		// (get) Token: 0x06002AE1 RID: 10977 RVA: 0x000A0940 File Offset: 0x0009ED40
		public EffectTable.eBuffTarget BuffTarget
		{
			get
			{
				int num = this.__p.__offset(122);
				return (EffectTable.eBuffTarget)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A07 RID: 2567
		// (get) Token: 0x06002AE2 RID: 10978 RVA: 0x000A0984 File Offset: 0x0009ED84
		public UnionCell AttachBuffRate
		{
			get
			{
				int num = this.__p.__offset(124);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000A08 RID: 2568
		// (get) Token: 0x06002AE3 RID: 10979 RVA: 0x000A09DC File Offset: 0x0009EDDC
		public UnionCell AttachBuffTime
		{
			get
			{
				int num = this.__p.__offset(126);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000A09 RID: 2569
		// (get) Token: 0x06002AE4 RID: 10980 RVA: 0x000A0A34 File Offset: 0x0009EE34
		public UnionCell BuffAttack
		{
			get
			{
				int num = this.__p.__offset(128);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x06002AE5 RID: 10981 RVA: 0x000A0A90 File Offset: 0x0009EE90
		public int BuffInfoIDArray(int j)
		{
			int num = this.__p.__offset(130);
			return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000A0A RID: 2570
		// (get) Token: 0x06002AE6 RID: 10982 RVA: 0x000A0AE0 File Offset: 0x0009EEE0
		public int BuffInfoIDLength
		{
			get
			{
				int num = this.__p.__offset(130);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002AE7 RID: 10983 RVA: 0x000A0B16 File Offset: 0x0009EF16
		public ArraySegment<byte>? GetBuffInfoIDBytes()
		{
			return this.__p.__vector_as_arraysegment(130);
		}

		// Token: 0x17000A0B RID: 2571
		// (get) Token: 0x06002AE8 RID: 10984 RVA: 0x000A0B28 File Offset: 0x0009EF28
		public FlatBufferArray<int> BuffInfoID
		{
			get
			{
				if (this.BuffInfoIDValue == null)
				{
					this.BuffInfoIDValue = new FlatBufferArray<int>(new Func<int, int>(this.BuffInfoIDArray), this.BuffInfoIDLength);
				}
				return this.BuffInfoIDValue;
			}
		}

		// Token: 0x06002AE9 RID: 10985 RVA: 0x000A0B58 File Offset: 0x0009EF58
		public int PVPBuffInfoIDArray(int j)
		{
			int num = this.__p.__offset(132);
			return (num == 0) ? 0 : (-1867646815 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000A0C RID: 2572
		// (get) Token: 0x06002AEA RID: 10986 RVA: 0x000A0BA8 File Offset: 0x0009EFA8
		public int PVPBuffInfoIDLength
		{
			get
			{
				int num = this.__p.__offset(132);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002AEB RID: 10987 RVA: 0x000A0BDE File Offset: 0x0009EFDE
		public ArraySegment<byte>? GetPVPBuffInfoIDBytes()
		{
			return this.__p.__vector_as_arraysegment(132);
		}

		// Token: 0x17000A0D RID: 2573
		// (get) Token: 0x06002AEC RID: 10988 RVA: 0x000A0BF0 File Offset: 0x0009EFF0
		public FlatBufferArray<int> PVPBuffInfoID
		{
			get
			{
				if (this.PVPBuffInfoIDValue == null)
				{
					this.PVPBuffInfoIDValue = new FlatBufferArray<int>(new Func<int, int>(this.PVPBuffInfoIDArray), this.PVPBuffInfoIDLength);
				}
				return this.PVPBuffInfoIDValue;
			}
		}

		// Token: 0x06002AED RID: 10989 RVA: 0x000A0C20 File Offset: 0x0009F020
		public static Offset<EffectTable> CreateEffectTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int SkillID = 0, EffectTable.eEffectTargetType EffectTargetType = EffectTable.eEffectTargetType.H_NONE, int HasDamage = 0, int IsFriendDamage = 0, EffectTable.eAvoidDamageType AvoidDamageType = EffectTable.eAvoidDamageType.AV_NONE, EffectTable.eDamageType DamageType = EffectTable.eDamageType.DamageType_None, EffectTable.eDamageDistanceType DamageDistanceType = EffectTable.eDamageDistanceType.NONE, int DamageMaxCount = 0, Offset<UnionCell> AttachCriticalOffset = default(Offset<UnionCell>), Offset<UnionCell> HitThroughRateOffset = default(Offset<UnionCell>), int MagicElementType = 0, bool MagicElementISuse = false, int HitSpreadOut = 0, Offset<UnionCell> DamageRateAPCOffset = default(Offset<UnionCell>), Offset<UnionCell> DamageRateOffset = default(Offset<UnionCell>), Offset<UnionCell> DamageFixedValueOffset = default(Offset<UnionCell>), Offset<UnionCell> DamageRatePVPOffset = default(Offset<UnionCell>), Offset<UnionCell> DamageFixedValuePVPOffset = default(Offset<UnionCell>), VectorOffset AttachMonsterRaceOffset = default(VectorOffset), Offset<UnionCell> AttachDamageRateOffset = default(Offset<UnionCell>), bool IsCanMiss = false, bool HitGrab = false, Offset<UnionCell> HardValueOffset = default(Offset<UnionCell>), bool UseStandardWeight = false, VectorOffset ClearTargetStateOffset = default(VectorOffset), bool UseNoBlock = false, int FrozenDistanceMax = 0, Offset<UnionCell> AttackOffset = default(Offset<UnionCell>), Offset<UnionCell> FloatingRateOffset = default(Offset<UnionCell>), Offset<UnionCell> HitFloatXForceOffset = default(Offset<UnionCell>), Offset<UnionCell> HitFloatYForceOffset = default(Offset<UnionCell>), VectorOffset RepeatAttackIntervalOffset = default(VectorOffset), int HitDeadFall = 0, EffectTable.eHitEffect HitEffect = EffectTable.eHitEffect.HIT, bool HitPause = false, int HitPauseTime = 0, bool HitEffectPause = false, int HitScreenShakeTime = 0, int HitScreenShakeSpeed = 0, int HitScreenShakeX = 0, int HitScreenShakeY = 0, int ScreenShakeID = 0, VectorOffset AttachEntityOffset = default(VectorOffset), int SummonID = 0, EffectTable.eSummonPosType SummonPosType = EffectTable.eSummonPosType.FACE, VectorOffset SummonPosType2Offset = default(VectorOffset), int SummonDisplay = 0, Offset<UnionCell> SummonNumOffset = default(Offset<UnionCell>), Offset<UnionCell> SummonLevelOffset = default(Offset<UnionCell>), int SummonNumLimit = 0, Offset<UnionCell> SummonGroupNumLimitOffset = default(Offset<UnionCell>), int SummonGroup = 0, int SummonRelation = 0, VectorOffset SummonRandListOffset = default(VectorOffset), int KillLastSummon = 0, int BuffID = 0, Offset<UnionCell> BuffLevelOffset = default(Offset<UnionCell>), EffectTable.eBuffTarget BuffTarget = EffectTable.eBuffTarget.SELF, Offset<UnionCell> AttachBuffRateOffset = default(Offset<UnionCell>), Offset<UnionCell> AttachBuffTimeOffset = default(Offset<UnionCell>), Offset<UnionCell> BuffAttackOffset = default(Offset<UnionCell>), VectorOffset BuffInfoIDOffset = default(VectorOffset), VectorOffset PVPBuffInfoIDOffset = default(VectorOffset))
		{
			builder.StartObject(65);
			EffectTable.AddPVPBuffInfoID(builder, PVPBuffInfoIDOffset);
			EffectTable.AddBuffInfoID(builder, BuffInfoIDOffset);
			EffectTable.AddBuffAttack(builder, BuffAttackOffset);
			EffectTable.AddAttachBuffTime(builder, AttachBuffTimeOffset);
			EffectTable.AddAttachBuffRate(builder, AttachBuffRateOffset);
			EffectTable.AddBuffTarget(builder, BuffTarget);
			EffectTable.AddBuffLevel(builder, BuffLevelOffset);
			EffectTable.AddBuffID(builder, BuffID);
			EffectTable.AddKillLastSummon(builder, KillLastSummon);
			EffectTable.AddSummonRandList(builder, SummonRandListOffset);
			EffectTable.AddSummonRelation(builder, SummonRelation);
			EffectTable.AddSummonGroup(builder, SummonGroup);
			EffectTable.AddSummonGroupNumLimit(builder, SummonGroupNumLimitOffset);
			EffectTable.AddSummonNumLimit(builder, SummonNumLimit);
			EffectTable.AddSummonLevel(builder, SummonLevelOffset);
			EffectTable.AddSummonNum(builder, SummonNumOffset);
			EffectTable.AddSummonDisplay(builder, SummonDisplay);
			EffectTable.AddSummonPosType2(builder, SummonPosType2Offset);
			EffectTable.AddSummonPosType(builder, SummonPosType);
			EffectTable.AddSummonID(builder, SummonID);
			EffectTable.AddAttachEntity(builder, AttachEntityOffset);
			EffectTable.AddScreenShakeID(builder, ScreenShakeID);
			EffectTable.AddHitScreenShakeY(builder, HitScreenShakeY);
			EffectTable.AddHitScreenShakeX(builder, HitScreenShakeX);
			EffectTable.AddHitScreenShakeSpeed(builder, HitScreenShakeSpeed);
			EffectTable.AddHitScreenShakeTime(builder, HitScreenShakeTime);
			EffectTable.AddHitPauseTime(builder, HitPauseTime);
			EffectTable.AddHitEffect(builder, HitEffect);
			EffectTable.AddHitDeadFall(builder, HitDeadFall);
			EffectTable.AddRepeatAttackInterval(builder, RepeatAttackIntervalOffset);
			EffectTable.AddHitFloatYForce(builder, HitFloatYForceOffset);
			EffectTable.AddHitFloatXForce(builder, HitFloatXForceOffset);
			EffectTable.AddFloatingRate(builder, FloatingRateOffset);
			EffectTable.AddAttack(builder, AttackOffset);
			EffectTable.AddFrozenDistanceMax(builder, FrozenDistanceMax);
			EffectTable.AddClearTargetState(builder, ClearTargetStateOffset);
			EffectTable.AddHardValue(builder, HardValueOffset);
			EffectTable.AddAttachDamageRate(builder, AttachDamageRateOffset);
			EffectTable.AddAttachMonsterRace(builder, AttachMonsterRaceOffset);
			EffectTable.AddDamageFixedValuePVP(builder, DamageFixedValuePVPOffset);
			EffectTable.AddDamageRatePVP(builder, DamageRatePVPOffset);
			EffectTable.AddDamageFixedValue(builder, DamageFixedValueOffset);
			EffectTable.AddDamageRate(builder, DamageRateOffset);
			EffectTable.AddDamageRateAPC(builder, DamageRateAPCOffset);
			EffectTable.AddHitSpreadOut(builder, HitSpreadOut);
			EffectTable.AddMagicElementType(builder, MagicElementType);
			EffectTable.AddHitThroughRate(builder, HitThroughRateOffset);
			EffectTable.AddAttachCritical(builder, AttachCriticalOffset);
			EffectTable.AddDamageMaxCount(builder, DamageMaxCount);
			EffectTable.AddDamageDistanceType(builder, DamageDistanceType);
			EffectTable.AddDamageType(builder, DamageType);
			EffectTable.AddAvoidDamageType(builder, AvoidDamageType);
			EffectTable.AddIsFriendDamage(builder, IsFriendDamage);
			EffectTable.AddHasDamage(builder, HasDamage);
			EffectTable.AddEffectTargetType(builder, EffectTargetType);
			EffectTable.AddSkillID(builder, SkillID);
			EffectTable.AddName(builder, NameOffset);
			EffectTable.AddID(builder, ID);
			EffectTable.AddHitEffectPause(builder, HitEffectPause);
			EffectTable.AddHitPause(builder, HitPause);
			EffectTable.AddUseNoBlock(builder, UseNoBlock);
			EffectTable.AddUseStandardWeight(builder, UseStandardWeight);
			EffectTable.AddHitGrab(builder, HitGrab);
			EffectTable.AddIsCanMiss(builder, IsCanMiss);
			EffectTable.AddMagicElementISuse(builder, MagicElementISuse);
			return EffectTable.EndEffectTable(builder);
		}

		// Token: 0x06002AEE RID: 10990 RVA: 0x000A0E40 File Offset: 0x0009F240
		public static void StartEffectTable(FlatBufferBuilder builder)
		{
			builder.StartObject(65);
		}

		// Token: 0x06002AEF RID: 10991 RVA: 0x000A0E4A File Offset: 0x0009F24A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002AF0 RID: 10992 RVA: 0x000A0E55 File Offset: 0x0009F255
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06002AF1 RID: 10993 RVA: 0x000A0E66 File Offset: 0x0009F266
		public static void AddSkillID(FlatBufferBuilder builder, int SkillID)
		{
			builder.AddInt(2, SkillID, 0);
		}

		// Token: 0x06002AF2 RID: 10994 RVA: 0x000A0E71 File Offset: 0x0009F271
		public static void AddEffectTargetType(FlatBufferBuilder builder, EffectTable.eEffectTargetType EffectTargetType)
		{
			builder.AddInt(3, (int)EffectTargetType, 0);
		}

		// Token: 0x06002AF3 RID: 10995 RVA: 0x000A0E7C File Offset: 0x0009F27C
		public static void AddHasDamage(FlatBufferBuilder builder, int HasDamage)
		{
			builder.AddInt(4, HasDamage, 0);
		}

		// Token: 0x06002AF4 RID: 10996 RVA: 0x000A0E87 File Offset: 0x0009F287
		public static void AddIsFriendDamage(FlatBufferBuilder builder, int IsFriendDamage)
		{
			builder.AddInt(5, IsFriendDamage, 0);
		}

		// Token: 0x06002AF5 RID: 10997 RVA: 0x000A0E92 File Offset: 0x0009F292
		public static void AddAvoidDamageType(FlatBufferBuilder builder, EffectTable.eAvoidDamageType AvoidDamageType)
		{
			builder.AddInt(6, (int)AvoidDamageType, 0);
		}

		// Token: 0x06002AF6 RID: 10998 RVA: 0x000A0E9D File Offset: 0x0009F29D
		public static void AddDamageType(FlatBufferBuilder builder, EffectTable.eDamageType DamageType)
		{
			builder.AddInt(7, (int)DamageType, 0);
		}

		// Token: 0x06002AF7 RID: 10999 RVA: 0x000A0EA8 File Offset: 0x0009F2A8
		public static void AddDamageDistanceType(FlatBufferBuilder builder, EffectTable.eDamageDistanceType DamageDistanceType)
		{
			builder.AddInt(8, (int)DamageDistanceType, 0);
		}

		// Token: 0x06002AF8 RID: 11000 RVA: 0x000A0EB3 File Offset: 0x0009F2B3
		public static void AddDamageMaxCount(FlatBufferBuilder builder, int DamageMaxCount)
		{
			builder.AddInt(9, DamageMaxCount, 0);
		}

		// Token: 0x06002AF9 RID: 11001 RVA: 0x000A0EBF File Offset: 0x0009F2BF
		public static void AddAttachCritical(FlatBufferBuilder builder, Offset<UnionCell> AttachCriticalOffset)
		{
			builder.AddOffset(10, AttachCriticalOffset.Value, 0);
		}

		// Token: 0x06002AFA RID: 11002 RVA: 0x000A0ED1 File Offset: 0x0009F2D1
		public static void AddHitThroughRate(FlatBufferBuilder builder, Offset<UnionCell> HitThroughRateOffset)
		{
			builder.AddOffset(11, HitThroughRateOffset.Value, 0);
		}

		// Token: 0x06002AFB RID: 11003 RVA: 0x000A0EE3 File Offset: 0x0009F2E3
		public static void AddMagicElementType(FlatBufferBuilder builder, int MagicElementType)
		{
			builder.AddInt(12, MagicElementType, 0);
		}

		// Token: 0x06002AFC RID: 11004 RVA: 0x000A0EEF File Offset: 0x0009F2EF
		public static void AddMagicElementISuse(FlatBufferBuilder builder, bool MagicElementISuse)
		{
			builder.AddBool(13, MagicElementISuse, false);
		}

		// Token: 0x06002AFD RID: 11005 RVA: 0x000A0EFB File Offset: 0x0009F2FB
		public static void AddHitSpreadOut(FlatBufferBuilder builder, int HitSpreadOut)
		{
			builder.AddInt(14, HitSpreadOut, 0);
		}

		// Token: 0x06002AFE RID: 11006 RVA: 0x000A0F07 File Offset: 0x0009F307
		public static void AddDamageRateAPC(FlatBufferBuilder builder, Offset<UnionCell> DamageRateAPCOffset)
		{
			builder.AddOffset(15, DamageRateAPCOffset.Value, 0);
		}

		// Token: 0x06002AFF RID: 11007 RVA: 0x000A0F19 File Offset: 0x0009F319
		public static void AddDamageRate(FlatBufferBuilder builder, Offset<UnionCell> DamageRateOffset)
		{
			builder.AddOffset(16, DamageRateOffset.Value, 0);
		}

		// Token: 0x06002B00 RID: 11008 RVA: 0x000A0F2B File Offset: 0x0009F32B
		public static void AddDamageFixedValue(FlatBufferBuilder builder, Offset<UnionCell> DamageFixedValueOffset)
		{
			builder.AddOffset(17, DamageFixedValueOffset.Value, 0);
		}

		// Token: 0x06002B01 RID: 11009 RVA: 0x000A0F3D File Offset: 0x0009F33D
		public static void AddDamageRatePVP(FlatBufferBuilder builder, Offset<UnionCell> DamageRatePVPOffset)
		{
			builder.AddOffset(18, DamageRatePVPOffset.Value, 0);
		}

		// Token: 0x06002B02 RID: 11010 RVA: 0x000A0F4F File Offset: 0x0009F34F
		public static void AddDamageFixedValuePVP(FlatBufferBuilder builder, Offset<UnionCell> DamageFixedValuePVPOffset)
		{
			builder.AddOffset(19, DamageFixedValuePVPOffset.Value, 0);
		}

		// Token: 0x06002B03 RID: 11011 RVA: 0x000A0F61 File Offset: 0x0009F361
		public static void AddAttachMonsterRace(FlatBufferBuilder builder, VectorOffset AttachMonsterRaceOffset)
		{
			builder.AddOffset(20, AttachMonsterRaceOffset.Value, 0);
		}

		// Token: 0x06002B04 RID: 11012 RVA: 0x000A0F74 File Offset: 0x0009F374
		public static VectorOffset CreateAttachMonsterRaceVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002B05 RID: 11013 RVA: 0x000A0FB1 File Offset: 0x0009F3B1
		public static void StartAttachMonsterRaceVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002B06 RID: 11014 RVA: 0x000A0FBC File Offset: 0x0009F3BC
		public static void AddAttachDamageRate(FlatBufferBuilder builder, Offset<UnionCell> AttachDamageRateOffset)
		{
			builder.AddOffset(21, AttachDamageRateOffset.Value, 0);
		}

		// Token: 0x06002B07 RID: 11015 RVA: 0x000A0FCE File Offset: 0x0009F3CE
		public static void AddIsCanMiss(FlatBufferBuilder builder, bool IsCanMiss)
		{
			builder.AddBool(22, IsCanMiss, false);
		}

		// Token: 0x06002B08 RID: 11016 RVA: 0x000A0FDA File Offset: 0x0009F3DA
		public static void AddHitGrab(FlatBufferBuilder builder, bool HitGrab)
		{
			builder.AddBool(23, HitGrab, false);
		}

		// Token: 0x06002B09 RID: 11017 RVA: 0x000A0FE6 File Offset: 0x0009F3E6
		public static void AddHardValue(FlatBufferBuilder builder, Offset<UnionCell> HardValueOffset)
		{
			builder.AddOffset(24, HardValueOffset.Value, 0);
		}

		// Token: 0x06002B0A RID: 11018 RVA: 0x000A0FF8 File Offset: 0x0009F3F8
		public static void AddUseStandardWeight(FlatBufferBuilder builder, bool UseStandardWeight)
		{
			builder.AddBool(25, UseStandardWeight, false);
		}

		// Token: 0x06002B0B RID: 11019 RVA: 0x000A1004 File Offset: 0x0009F404
		public static void AddClearTargetState(FlatBufferBuilder builder, VectorOffset ClearTargetStateOffset)
		{
			builder.AddOffset(26, ClearTargetStateOffset.Value, 0);
		}

		// Token: 0x06002B0C RID: 11020 RVA: 0x000A1018 File Offset: 0x0009F418
		public static VectorOffset CreateClearTargetStateVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002B0D RID: 11021 RVA: 0x000A1055 File Offset: 0x0009F455
		public static void StartClearTargetStateVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002B0E RID: 11022 RVA: 0x000A1060 File Offset: 0x0009F460
		public static void AddUseNoBlock(FlatBufferBuilder builder, bool UseNoBlock)
		{
			builder.AddBool(27, UseNoBlock, false);
		}

		// Token: 0x06002B0F RID: 11023 RVA: 0x000A106C File Offset: 0x0009F46C
		public static void AddFrozenDistanceMax(FlatBufferBuilder builder, int FrozenDistanceMax)
		{
			builder.AddInt(28, FrozenDistanceMax, 0);
		}

		// Token: 0x06002B10 RID: 11024 RVA: 0x000A1078 File Offset: 0x0009F478
		public static void AddAttack(FlatBufferBuilder builder, Offset<UnionCell> AttackOffset)
		{
			builder.AddOffset(29, AttackOffset.Value, 0);
		}

		// Token: 0x06002B11 RID: 11025 RVA: 0x000A108A File Offset: 0x0009F48A
		public static void AddFloatingRate(FlatBufferBuilder builder, Offset<UnionCell> FloatingRateOffset)
		{
			builder.AddOffset(30, FloatingRateOffset.Value, 0);
		}

		// Token: 0x06002B12 RID: 11026 RVA: 0x000A109C File Offset: 0x0009F49C
		public static void AddHitFloatXForce(FlatBufferBuilder builder, Offset<UnionCell> HitFloatXForceOffset)
		{
			builder.AddOffset(31, HitFloatXForceOffset.Value, 0);
		}

		// Token: 0x06002B13 RID: 11027 RVA: 0x000A10AE File Offset: 0x0009F4AE
		public static void AddHitFloatYForce(FlatBufferBuilder builder, Offset<UnionCell> HitFloatYForceOffset)
		{
			builder.AddOffset(32, HitFloatYForceOffset.Value, 0);
		}

		// Token: 0x06002B14 RID: 11028 RVA: 0x000A10C0 File Offset: 0x0009F4C0
		public static void AddRepeatAttackInterval(FlatBufferBuilder builder, VectorOffset RepeatAttackIntervalOffset)
		{
			builder.AddOffset(33, RepeatAttackIntervalOffset.Value, 0);
		}

		// Token: 0x06002B15 RID: 11029 RVA: 0x000A10D4 File Offset: 0x0009F4D4
		public static VectorOffset CreateRepeatAttackIntervalVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002B16 RID: 11030 RVA: 0x000A1111 File Offset: 0x0009F511
		public static void StartRepeatAttackIntervalVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002B17 RID: 11031 RVA: 0x000A111C File Offset: 0x0009F51C
		public static void AddHitDeadFall(FlatBufferBuilder builder, int HitDeadFall)
		{
			builder.AddInt(34, HitDeadFall, 0);
		}

		// Token: 0x06002B18 RID: 11032 RVA: 0x000A1128 File Offset: 0x0009F528
		public static void AddHitEffect(FlatBufferBuilder builder, EffectTable.eHitEffect HitEffect)
		{
			builder.AddInt(35, (int)HitEffect, 0);
		}

		// Token: 0x06002B19 RID: 11033 RVA: 0x000A1134 File Offset: 0x0009F534
		public static void AddHitPause(FlatBufferBuilder builder, bool HitPause)
		{
			builder.AddBool(36, HitPause, false);
		}

		// Token: 0x06002B1A RID: 11034 RVA: 0x000A1140 File Offset: 0x0009F540
		public static void AddHitPauseTime(FlatBufferBuilder builder, int HitPauseTime)
		{
			builder.AddInt(37, HitPauseTime, 0);
		}

		// Token: 0x06002B1B RID: 11035 RVA: 0x000A114C File Offset: 0x0009F54C
		public static void AddHitEffectPause(FlatBufferBuilder builder, bool HitEffectPause)
		{
			builder.AddBool(38, HitEffectPause, false);
		}

		// Token: 0x06002B1C RID: 11036 RVA: 0x000A1158 File Offset: 0x0009F558
		public static void AddHitScreenShakeTime(FlatBufferBuilder builder, int HitScreenShakeTime)
		{
			builder.AddInt(39, HitScreenShakeTime, 0);
		}

		// Token: 0x06002B1D RID: 11037 RVA: 0x000A1164 File Offset: 0x0009F564
		public static void AddHitScreenShakeSpeed(FlatBufferBuilder builder, int HitScreenShakeSpeed)
		{
			builder.AddInt(40, HitScreenShakeSpeed, 0);
		}

		// Token: 0x06002B1E RID: 11038 RVA: 0x000A1170 File Offset: 0x0009F570
		public static void AddHitScreenShakeX(FlatBufferBuilder builder, int HitScreenShakeX)
		{
			builder.AddInt(41, HitScreenShakeX, 0);
		}

		// Token: 0x06002B1F RID: 11039 RVA: 0x000A117C File Offset: 0x0009F57C
		public static void AddHitScreenShakeY(FlatBufferBuilder builder, int HitScreenShakeY)
		{
			builder.AddInt(42, HitScreenShakeY, 0);
		}

		// Token: 0x06002B20 RID: 11040 RVA: 0x000A1188 File Offset: 0x0009F588
		public static void AddScreenShakeID(FlatBufferBuilder builder, int ScreenShakeID)
		{
			builder.AddInt(43, ScreenShakeID, 0);
		}

		// Token: 0x06002B21 RID: 11041 RVA: 0x000A1194 File Offset: 0x0009F594
		public static void AddAttachEntity(FlatBufferBuilder builder, VectorOffset AttachEntityOffset)
		{
			builder.AddOffset(44, AttachEntityOffset.Value, 0);
		}

		// Token: 0x06002B22 RID: 11042 RVA: 0x000A11A8 File Offset: 0x0009F5A8
		public static VectorOffset CreateAttachEntityVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002B23 RID: 11043 RVA: 0x000A11E5 File Offset: 0x0009F5E5
		public static void StartAttachEntityVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002B24 RID: 11044 RVA: 0x000A11F0 File Offset: 0x0009F5F0
		public static void AddSummonID(FlatBufferBuilder builder, int SummonID)
		{
			builder.AddInt(45, SummonID, 0);
		}

		// Token: 0x06002B25 RID: 11045 RVA: 0x000A11FC File Offset: 0x0009F5FC
		public static void AddSummonPosType(FlatBufferBuilder builder, EffectTable.eSummonPosType SummonPosType)
		{
			builder.AddInt(46, (int)SummonPosType, 0);
		}

		// Token: 0x06002B26 RID: 11046 RVA: 0x000A1208 File Offset: 0x0009F608
		public static void AddSummonPosType2(FlatBufferBuilder builder, VectorOffset SummonPosType2Offset)
		{
			builder.AddOffset(47, SummonPosType2Offset.Value, 0);
		}

		// Token: 0x06002B27 RID: 11047 RVA: 0x000A121C File Offset: 0x0009F61C
		public static VectorOffset CreateSummonPosType2Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002B28 RID: 11048 RVA: 0x000A1259 File Offset: 0x0009F659
		public static void StartSummonPosType2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002B29 RID: 11049 RVA: 0x000A1264 File Offset: 0x0009F664
		public static void AddSummonDisplay(FlatBufferBuilder builder, int SummonDisplay)
		{
			builder.AddInt(48, SummonDisplay, 0);
		}

		// Token: 0x06002B2A RID: 11050 RVA: 0x000A1270 File Offset: 0x0009F670
		public static void AddSummonNum(FlatBufferBuilder builder, Offset<UnionCell> SummonNumOffset)
		{
			builder.AddOffset(49, SummonNumOffset.Value, 0);
		}

		// Token: 0x06002B2B RID: 11051 RVA: 0x000A1282 File Offset: 0x0009F682
		public static void AddSummonLevel(FlatBufferBuilder builder, Offset<UnionCell> SummonLevelOffset)
		{
			builder.AddOffset(50, SummonLevelOffset.Value, 0);
		}

		// Token: 0x06002B2C RID: 11052 RVA: 0x000A1294 File Offset: 0x0009F694
		public static void AddSummonNumLimit(FlatBufferBuilder builder, int SummonNumLimit)
		{
			builder.AddInt(51, SummonNumLimit, 0);
		}

		// Token: 0x06002B2D RID: 11053 RVA: 0x000A12A0 File Offset: 0x0009F6A0
		public static void AddSummonGroupNumLimit(FlatBufferBuilder builder, Offset<UnionCell> SummonGroupNumLimitOffset)
		{
			builder.AddOffset(52, SummonGroupNumLimitOffset.Value, 0);
		}

		// Token: 0x06002B2E RID: 11054 RVA: 0x000A12B2 File Offset: 0x0009F6B2
		public static void AddSummonGroup(FlatBufferBuilder builder, int SummonGroup)
		{
			builder.AddInt(53, SummonGroup, 0);
		}

		// Token: 0x06002B2F RID: 11055 RVA: 0x000A12BE File Offset: 0x0009F6BE
		public static void AddSummonRelation(FlatBufferBuilder builder, int SummonRelation)
		{
			builder.AddInt(54, SummonRelation, 0);
		}

		// Token: 0x06002B30 RID: 11056 RVA: 0x000A12CA File Offset: 0x0009F6CA
		public static void AddSummonRandList(FlatBufferBuilder builder, VectorOffset SummonRandListOffset)
		{
			builder.AddOffset(55, SummonRandListOffset.Value, 0);
		}

		// Token: 0x06002B31 RID: 11057 RVA: 0x000A12DC File Offset: 0x0009F6DC
		public static VectorOffset CreateSummonRandListVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002B32 RID: 11058 RVA: 0x000A1319 File Offset: 0x0009F719
		public static void StartSummonRandListVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002B33 RID: 11059 RVA: 0x000A1324 File Offset: 0x0009F724
		public static void AddKillLastSummon(FlatBufferBuilder builder, int KillLastSummon)
		{
			builder.AddInt(56, KillLastSummon, 0);
		}

		// Token: 0x06002B34 RID: 11060 RVA: 0x000A1330 File Offset: 0x0009F730
		public static void AddBuffID(FlatBufferBuilder builder, int BuffID)
		{
			builder.AddInt(57, BuffID, 0);
		}

		// Token: 0x06002B35 RID: 11061 RVA: 0x000A133C File Offset: 0x0009F73C
		public static void AddBuffLevel(FlatBufferBuilder builder, Offset<UnionCell> BuffLevelOffset)
		{
			builder.AddOffset(58, BuffLevelOffset.Value, 0);
		}

		// Token: 0x06002B36 RID: 11062 RVA: 0x000A134E File Offset: 0x0009F74E
		public static void AddBuffTarget(FlatBufferBuilder builder, EffectTable.eBuffTarget BuffTarget)
		{
			builder.AddInt(59, (int)BuffTarget, 0);
		}

		// Token: 0x06002B37 RID: 11063 RVA: 0x000A135A File Offset: 0x0009F75A
		public static void AddAttachBuffRate(FlatBufferBuilder builder, Offset<UnionCell> AttachBuffRateOffset)
		{
			builder.AddOffset(60, AttachBuffRateOffset.Value, 0);
		}

		// Token: 0x06002B38 RID: 11064 RVA: 0x000A136C File Offset: 0x0009F76C
		public static void AddAttachBuffTime(FlatBufferBuilder builder, Offset<UnionCell> AttachBuffTimeOffset)
		{
			builder.AddOffset(61, AttachBuffTimeOffset.Value, 0);
		}

		// Token: 0x06002B39 RID: 11065 RVA: 0x000A137E File Offset: 0x0009F77E
		public static void AddBuffAttack(FlatBufferBuilder builder, Offset<UnionCell> BuffAttackOffset)
		{
			builder.AddOffset(62, BuffAttackOffset.Value, 0);
		}

		// Token: 0x06002B3A RID: 11066 RVA: 0x000A1390 File Offset: 0x0009F790
		public static void AddBuffInfoID(FlatBufferBuilder builder, VectorOffset BuffInfoIDOffset)
		{
			builder.AddOffset(63, BuffInfoIDOffset.Value, 0);
		}

		// Token: 0x06002B3B RID: 11067 RVA: 0x000A13A4 File Offset: 0x0009F7A4
		public static VectorOffset CreateBuffInfoIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002B3C RID: 11068 RVA: 0x000A13E1 File Offset: 0x0009F7E1
		public static void StartBuffInfoIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002B3D RID: 11069 RVA: 0x000A13EC File Offset: 0x0009F7EC
		public static void AddPVPBuffInfoID(FlatBufferBuilder builder, VectorOffset PVPBuffInfoIDOffset)
		{
			builder.AddOffset(64, PVPBuffInfoIDOffset.Value, 0);
		}

		// Token: 0x06002B3E RID: 11070 RVA: 0x000A1400 File Offset: 0x0009F800
		public static VectorOffset CreatePVPBuffInfoIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002B3F RID: 11071 RVA: 0x000A143D File Offset: 0x0009F83D
		public static void StartPVPBuffInfoIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002B40 RID: 11072 RVA: 0x000A1448 File Offset: 0x0009F848
		public static Offset<EffectTable> EndEffectTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EffectTable>(value);
		}

		// Token: 0x06002B41 RID: 11073 RVA: 0x000A1462 File Offset: 0x0009F862
		public static void FinishEffectTableBuffer(FlatBufferBuilder builder, Offset<EffectTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400125D RID: 4701
		private Table __p = new Table();

		// Token: 0x0400125E RID: 4702
		private FlatBufferArray<int> AttachMonsterRaceValue;

		// Token: 0x0400125F RID: 4703
		private FlatBufferArray<int> ClearTargetStateValue;

		// Token: 0x04001260 RID: 4704
		private FlatBufferArray<int> RepeatAttackIntervalValue;

		// Token: 0x04001261 RID: 4705
		private FlatBufferArray<int> AttachEntityValue;

		// Token: 0x04001262 RID: 4706
		private FlatBufferArray<int> SummonPosType2Value;

		// Token: 0x04001263 RID: 4707
		private FlatBufferArray<int> SummonRandListValue;

		// Token: 0x04001264 RID: 4708
		private FlatBufferArray<int> BuffInfoIDValue;

		// Token: 0x04001265 RID: 4709
		private FlatBufferArray<int> PVPBuffInfoIDValue;

		// Token: 0x020003B9 RID: 953
		public enum eEffectTargetType
		{
			// Token: 0x04001267 RID: 4711
			H_NONE,
			// Token: 0x04001268 RID: 4712
			H_ENEMY,
			// Token: 0x04001269 RID: 4713
			H_FRIEND
		}

		// Token: 0x020003BA RID: 954
		public enum eAvoidDamageType
		{
			// Token: 0x0400126B RID: 4715
			AV_NONE,
			// Token: 0x0400126C RID: 4716
			AV_AREA,
			// Token: 0x0400126D RID: 4717
			AV_FACINGAWAY
		}

		// Token: 0x020003BB RID: 955
		public enum eDamageType
		{
			// Token: 0x0400126F RID: 4719
			DamageType_None,
			// Token: 0x04001270 RID: 4720
			PHYSIC,
			// Token: 0x04001271 RID: 4721
			MAGIC
		}

		// Token: 0x020003BC RID: 956
		public enum eDamageDistanceType
		{
			// Token: 0x04001273 RID: 4723
			NONE,
			// Token: 0x04001274 RID: 4724
			NEAR,
			// Token: 0x04001275 RID: 4725
			FAR
		}

		// Token: 0x020003BD RID: 957
		public enum eHitEffect
		{
			// Token: 0x04001277 RID: 4727
			HIT,
			// Token: 0x04001278 RID: 4728
			HITFLY,
			// Token: 0x04001279 RID: 4729
			NO_EFFECT
		}

		// Token: 0x020003BE RID: 958
		public enum eSummonPosType
		{
			// Token: 0x0400127B RID: 4731
			FACE,
			// Token: 0x0400127C RID: 4732
			ORIGIN,
			// Token: 0x0400127D RID: 4733
			FACE_FORCE,
			// Token: 0x0400127E RID: 4734
			FACE_BLACK
		}

		// Token: 0x020003BF RID: 959
		public enum eBuffTarget
		{
			// Token: 0x04001280 RID: 4736
			SELF,
			// Token: 0x04001281 RID: 4737
			ENEMY
		}

		// Token: 0x020003C0 RID: 960
		public enum eCrypt
		{
			// Token: 0x04001283 RID: 4739
			code = -1867646815
		}
	}
}
