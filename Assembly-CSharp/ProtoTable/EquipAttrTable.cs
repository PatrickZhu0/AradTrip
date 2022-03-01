using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003D3 RID: 979
	public class EquipAttrTable : IFlatbufferObject
	{
		// Token: 0x17000A43 RID: 2627
		// (get) Token: 0x06002BF9 RID: 11257 RVA: 0x000A2C90 File Offset: 0x000A1090
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002BFA RID: 11258 RVA: 0x000A2C9D File Offset: 0x000A109D
		public static EquipAttrTable GetRootAsEquipAttrTable(ByteBuffer _bb)
		{
			return EquipAttrTable.GetRootAsEquipAttrTable(_bb, new EquipAttrTable());
		}

		// Token: 0x06002BFB RID: 11259 RVA: 0x000A2CAA File Offset: 0x000A10AA
		public static EquipAttrTable GetRootAsEquipAttrTable(ByteBuffer _bb, EquipAttrTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002BFC RID: 11260 RVA: 0x000A2CC6 File Offset: 0x000A10C6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002BFD RID: 11261 RVA: 0x000A2CE0 File Offset: 0x000A10E0
		public EquipAttrTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000A44 RID: 2628
		// (get) Token: 0x06002BFE RID: 11262 RVA: 0x000A2CEC File Offset: 0x000A10EC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A45 RID: 2629
		// (get) Token: 0x06002BFF RID: 11263 RVA: 0x000A2D38 File Offset: 0x000A1138
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002C00 RID: 11264 RVA: 0x000A2D7A File Offset: 0x000A117A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000A46 RID: 2630
		// (get) Token: 0x06002C01 RID: 11265 RVA: 0x000A2D88 File Offset: 0x000A1188
		public int Atk
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A47 RID: 2631
		// (get) Token: 0x06002C02 RID: 11266 RVA: 0x000A2DD4 File Offset: 0x000A11D4
		public int MagicAtk
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A48 RID: 2632
		// (get) Token: 0x06002C03 RID: 11267 RVA: 0x000A2E20 File Offset: 0x000A1220
		public int Independence
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A49 RID: 2633
		// (get) Token: 0x06002C04 RID: 11268 RVA: 0x000A2E6C File Offset: 0x000A126C
		public int Def
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A4A RID: 2634
		// (get) Token: 0x06002C05 RID: 11269 RVA: 0x000A2EB8 File Offset: 0x000A12B8
		public int MagicDef
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A4B RID: 2635
		// (get) Token: 0x06002C06 RID: 11270 RVA: 0x000A2F04 File Offset: 0x000A1304
		public int Strenth
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A4C RID: 2636
		// (get) Token: 0x06002C07 RID: 11271 RVA: 0x000A2F50 File Offset: 0x000A1350
		public int Intellect
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A4D RID: 2637
		// (get) Token: 0x06002C08 RID: 11272 RVA: 0x000A2F9C File Offset: 0x000A139C
		public int Spirit
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A4E RID: 2638
		// (get) Token: 0x06002C09 RID: 11273 RVA: 0x000A2FE8 File Offset: 0x000A13E8
		public int Stamina
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A4F RID: 2639
		// (get) Token: 0x06002C0A RID: 11274 RVA: 0x000A3034 File Offset: 0x000A1434
		public int PhySkillMp
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A50 RID: 2640
		// (get) Token: 0x06002C0B RID: 11275 RVA: 0x000A3080 File Offset: 0x000A1480
		public int PhySkillCd
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A51 RID: 2641
		// (get) Token: 0x06002C0C RID: 11276 RVA: 0x000A30CC File Offset: 0x000A14CC
		public int MagSkillMp
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A52 RID: 2642
		// (get) Token: 0x06002C0D RID: 11277 RVA: 0x000A3118 File Offset: 0x000A1518
		public int MagSkillCd
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A53 RID: 2643
		// (get) Token: 0x06002C0E RID: 11278 RVA: 0x000A3164 File Offset: 0x000A1564
		public int HPMax
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A54 RID: 2644
		// (get) Token: 0x06002C0F RID: 11279 RVA: 0x000A31B0 File Offset: 0x000A15B0
		public int MPMax
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A55 RID: 2645
		// (get) Token: 0x06002C10 RID: 11280 RVA: 0x000A31FC File Offset: 0x000A15FC
		public int HPRecover
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A56 RID: 2646
		// (get) Token: 0x06002C11 RID: 11281 RVA: 0x000A3248 File Offset: 0x000A1648
		public int MPRecover
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A57 RID: 2647
		// (get) Token: 0x06002C12 RID: 11282 RVA: 0x000A3294 File Offset: 0x000A1694
		public int AttackSpeedRate
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A58 RID: 2648
		// (get) Token: 0x06002C13 RID: 11283 RVA: 0x000A32E0 File Offset: 0x000A16E0
		public int FireSpeedRate
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A59 RID: 2649
		// (get) Token: 0x06002C14 RID: 11284 RVA: 0x000A332C File Offset: 0x000A172C
		public int MoveSpeedRate
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A5A RID: 2650
		// (get) Token: 0x06002C15 RID: 11285 RVA: 0x000A3378 File Offset: 0x000A1778
		public int TownMoveSpeedRate
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A5B RID: 2651
		// (get) Token: 0x06002C16 RID: 11286 RVA: 0x000A33C4 File Offset: 0x000A17C4
		public int HitRate
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A5C RID: 2652
		// (get) Token: 0x06002C17 RID: 11287 RVA: 0x000A3410 File Offset: 0x000A1810
		public int AvoidRate
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A5D RID: 2653
		// (get) Token: 0x06002C18 RID: 11288 RVA: 0x000A345C File Offset: 0x000A185C
		public int PhysicCrit
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A5E RID: 2654
		// (get) Token: 0x06002C19 RID: 11289 RVA: 0x000A34A8 File Offset: 0x000A18A8
		public int MagicCrit
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A5F RID: 2655
		// (get) Token: 0x06002C1A RID: 11290 RVA: 0x000A34F4 File Offset: 0x000A18F4
		public int Spasticity
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A60 RID: 2656
		// (get) Token: 0x06002C1B RID: 11291 RVA: 0x000A3540 File Offset: 0x000A1940
		public int Jump
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A61 RID: 2657
		// (get) Token: 0x06002C1C RID: 11292 RVA: 0x000A358C File Offset: 0x000A198C
		public int ResistMagic
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002C1D RID: 11293 RVA: 0x000A35D8 File Offset: 0x000A19D8
		public int ElementsArray(int j)
		{
			int num = this.__p.__offset(64);
			return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000A62 RID: 2658
		// (get) Token: 0x06002C1E RID: 11294 RVA: 0x000A3628 File Offset: 0x000A1A28
		public int ElementsLength
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002C1F RID: 11295 RVA: 0x000A365B File Offset: 0x000A1A5B
		public ArraySegment<byte>? GetElementsBytes()
		{
			return this.__p.__vector_as_arraysegment(64);
		}

		// Token: 0x17000A63 RID: 2659
		// (get) Token: 0x06002C20 RID: 11296 RVA: 0x000A366A File Offset: 0x000A1A6A
		public FlatBufferArray<int> Elements
		{
			get
			{
				if (this.ElementsValue == null)
				{
					this.ElementsValue = new FlatBufferArray<int>(new Func<int, int>(this.ElementsArray), this.ElementsLength);
				}
				return this.ElementsValue;
			}
		}

		// Token: 0x17000A64 RID: 2660
		// (get) Token: 0x06002C21 RID: 11297 RVA: 0x000A369C File Offset: 0x000A1A9C
		public int LightAttack
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A65 RID: 2661
		// (get) Token: 0x06002C22 RID: 11298 RVA: 0x000A36E8 File Offset: 0x000A1AE8
		public int FireAttack
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A66 RID: 2662
		// (get) Token: 0x06002C23 RID: 11299 RVA: 0x000A3734 File Offset: 0x000A1B34
		public int IceAttack
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A67 RID: 2663
		// (get) Token: 0x06002C24 RID: 11300 RVA: 0x000A3780 File Offset: 0x000A1B80
		public int DarkAttack
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A68 RID: 2664
		// (get) Token: 0x06002C25 RID: 11301 RVA: 0x000A37CC File Offset: 0x000A1BCC
		public int LightDefence
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A69 RID: 2665
		// (get) Token: 0x06002C26 RID: 11302 RVA: 0x000A3818 File Offset: 0x000A1C18
		public int FireDefence
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A6A RID: 2666
		// (get) Token: 0x06002C27 RID: 11303 RVA: 0x000A3864 File Offset: 0x000A1C64
		public int IceDefence
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A6B RID: 2667
		// (get) Token: 0x06002C28 RID: 11304 RVA: 0x000A38B0 File Offset: 0x000A1CB0
		public int DarkDefence
		{
			get
			{
				int num = this.__p.__offset(80);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A6C RID: 2668
		// (get) Token: 0x06002C29 RID: 11305 RVA: 0x000A38FC File Offset: 0x000A1CFC
		public int AbormalResist
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002C2A RID: 11306 RVA: 0x000A3948 File Offset: 0x000A1D48
		public string AbormalResistsArray(int j)
		{
			int num = this.__p.__offset(84);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000A6D RID: 2669
		// (get) Token: 0x06002C2B RID: 11307 RVA: 0x000A3990 File Offset: 0x000A1D90
		public int AbormalResistsLength
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000A6E RID: 2670
		// (get) Token: 0x06002C2C RID: 11308 RVA: 0x000A39C3 File Offset: 0x000A1DC3
		public FlatBufferArray<string> AbormalResists
		{
			get
			{
				if (this.AbormalResistsValue == null)
				{
					this.AbormalResistsValue = new FlatBufferArray<string>(new Func<int, string>(this.AbormalResistsArray), this.AbormalResistsLength);
				}
				return this.AbormalResistsValue;
			}
		}

		// Token: 0x17000A6F RID: 2671
		// (get) Token: 0x06002C2D RID: 11309 RVA: 0x000A39F4 File Offset: 0x000A1DF4
		public int abnormalResist1
		{
			get
			{
				int num = this.__p.__offset(86);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A70 RID: 2672
		// (get) Token: 0x06002C2E RID: 11310 RVA: 0x000A3A40 File Offset: 0x000A1E40
		public int abnormalResist2
		{
			get
			{
				int num = this.__p.__offset(88);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A71 RID: 2673
		// (get) Token: 0x06002C2F RID: 11311 RVA: 0x000A3A8C File Offset: 0x000A1E8C
		public int abnormalResist3
		{
			get
			{
				int num = this.__p.__offset(90);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A72 RID: 2674
		// (get) Token: 0x06002C30 RID: 11312 RVA: 0x000A3AD8 File Offset: 0x000A1ED8
		public int abnormalResist4
		{
			get
			{
				int num = this.__p.__offset(92);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A73 RID: 2675
		// (get) Token: 0x06002C31 RID: 11313 RVA: 0x000A3B24 File Offset: 0x000A1F24
		public int abnormalResist5
		{
			get
			{
				int num = this.__p.__offset(94);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A74 RID: 2676
		// (get) Token: 0x06002C32 RID: 11314 RVA: 0x000A3B70 File Offset: 0x000A1F70
		public int abnormalResist6
		{
			get
			{
				int num = this.__p.__offset(96);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A75 RID: 2677
		// (get) Token: 0x06002C33 RID: 11315 RVA: 0x000A3BBC File Offset: 0x000A1FBC
		public int abnormalResist7
		{
			get
			{
				int num = this.__p.__offset(98);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A76 RID: 2678
		// (get) Token: 0x06002C34 RID: 11316 RVA: 0x000A3C08 File Offset: 0x000A2008
		public int abnormalResist8
		{
			get
			{
				int num = this.__p.__offset(100);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A77 RID: 2679
		// (get) Token: 0x06002C35 RID: 11317 RVA: 0x000A3C54 File Offset: 0x000A2054
		public int abnormalResist9
		{
			get
			{
				int num = this.__p.__offset(102);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A78 RID: 2680
		// (get) Token: 0x06002C36 RID: 11318 RVA: 0x000A3CA0 File Offset: 0x000A20A0
		public int abnormalResist10
		{
			get
			{
				int num = this.__p.__offset(104);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A79 RID: 2681
		// (get) Token: 0x06002C37 RID: 11319 RVA: 0x000A3CEC File Offset: 0x000A20EC
		public int abnormalResist11
		{
			get
			{
				int num = this.__p.__offset(106);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A7A RID: 2682
		// (get) Token: 0x06002C38 RID: 11320 RVA: 0x000A3D38 File Offset: 0x000A2138
		public int abnormalResist12
		{
			get
			{
				int num = this.__p.__offset(108);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A7B RID: 2683
		// (get) Token: 0x06002C39 RID: 11321 RVA: 0x000A3D84 File Offset: 0x000A2184
		public int abnormalResist13
		{
			get
			{
				int num = this.__p.__offset(110);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A7C RID: 2684
		// (get) Token: 0x06002C3A RID: 11322 RVA: 0x000A3DD0 File Offset: 0x000A21D0
		public int AttachRateScore
		{
			get
			{
				int num = this.__p.__offset(112);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002C3B RID: 11323 RVA: 0x000A3E1C File Offset: 0x000A221C
		public int AttachBuffInfoIDsArray(int j)
		{
			int num = this.__p.__offset(114);
			return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000A7D RID: 2685
		// (get) Token: 0x06002C3C RID: 11324 RVA: 0x000A3E6C File Offset: 0x000A226C
		public int AttachBuffInfoIDsLength
		{
			get
			{
				int num = this.__p.__offset(114);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002C3D RID: 11325 RVA: 0x000A3E9F File Offset: 0x000A229F
		public ArraySegment<byte>? GetAttachBuffInfoIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(114);
		}

		// Token: 0x17000A7E RID: 2686
		// (get) Token: 0x06002C3E RID: 11326 RVA: 0x000A3EAE File Offset: 0x000A22AE
		public FlatBufferArray<int> AttachBuffInfoIDs
		{
			get
			{
				if (this.AttachBuffInfoIDsValue == null)
				{
					this.AttachBuffInfoIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.AttachBuffInfoIDsArray), this.AttachBuffInfoIDsLength);
				}
				return this.AttachBuffInfoIDsValue;
			}
		}

		// Token: 0x06002C3F RID: 11327 RVA: 0x000A3EE0 File Offset: 0x000A22E0
		public int AttachMechanismIDsArray(int j)
		{
			int num = this.__p.__offset(116);
			return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000A7F RID: 2687
		// (get) Token: 0x06002C40 RID: 11328 RVA: 0x000A3F30 File Offset: 0x000A2330
		public int AttachMechanismIDsLength
		{
			get
			{
				int num = this.__p.__offset(116);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002C41 RID: 11329 RVA: 0x000A3F63 File Offset: 0x000A2363
		public ArraySegment<byte>? GetAttachMechanismIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(116);
		}

		// Token: 0x17000A80 RID: 2688
		// (get) Token: 0x06002C42 RID: 11330 RVA: 0x000A3F72 File Offset: 0x000A2372
		public FlatBufferArray<int> AttachMechanismIDs
		{
			get
			{
				if (this.AttachMechanismIDsValue == null)
				{
					this.AttachMechanismIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.AttachMechanismIDsArray), this.AttachMechanismIDsLength);
				}
				return this.AttachMechanismIDsValue;
			}
		}

		// Token: 0x06002C43 RID: 11331 RVA: 0x000A3FA4 File Offset: 0x000A23A4
		public int PVPAttachBuffInfoIDsArray(int j)
		{
			int num = this.__p.__offset(118);
			return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000A81 RID: 2689
		// (get) Token: 0x06002C44 RID: 11332 RVA: 0x000A3FF4 File Offset: 0x000A23F4
		public int PVPAttachBuffInfoIDsLength
		{
			get
			{
				int num = this.__p.__offset(118);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002C45 RID: 11333 RVA: 0x000A4027 File Offset: 0x000A2427
		public ArraySegment<byte>? GetPVPAttachBuffInfoIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(118);
		}

		// Token: 0x17000A82 RID: 2690
		// (get) Token: 0x06002C46 RID: 11334 RVA: 0x000A4036 File Offset: 0x000A2436
		public FlatBufferArray<int> PVPAttachBuffInfoIDs
		{
			get
			{
				if (this.PVPAttachBuffInfoIDsValue == null)
				{
					this.PVPAttachBuffInfoIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.PVPAttachBuffInfoIDsArray), this.PVPAttachBuffInfoIDsLength);
				}
				return this.PVPAttachBuffInfoIDsValue;
			}
		}

		// Token: 0x06002C47 RID: 11335 RVA: 0x000A4068 File Offset: 0x000A2468
		public int PVPAttachMechanismIDsArray(int j)
		{
			int num = this.__p.__offset(120);
			return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000A83 RID: 2691
		// (get) Token: 0x06002C48 RID: 11336 RVA: 0x000A40B8 File Offset: 0x000A24B8
		public int PVPAttachMechanismIDsLength
		{
			get
			{
				int num = this.__p.__offset(120);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002C49 RID: 11337 RVA: 0x000A40EB File Offset: 0x000A24EB
		public ArraySegment<byte>? GetPVPAttachMechanismIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(120);
		}

		// Token: 0x17000A84 RID: 2692
		// (get) Token: 0x06002C4A RID: 11338 RVA: 0x000A40FA File Offset: 0x000A24FA
		public FlatBufferArray<int> PVPAttachMechanismIDs
		{
			get
			{
				if (this.PVPAttachMechanismIDsValue == null)
				{
					this.PVPAttachMechanismIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.PVPAttachMechanismIDsArray), this.PVPAttachMechanismIDsLength);
				}
				return this.PVPAttachMechanismIDsValue;
			}
		}

		// Token: 0x17000A85 RID: 2693
		// (get) Token: 0x06002C4B RID: 11339 RVA: 0x000A412C File Offset: 0x000A252C
		public string AttachBuffDesc
		{
			get
			{
				int num = this.__p.__offset(122);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002C4C RID: 11340 RVA: 0x000A416F File Offset: 0x000A256F
		public ArraySegment<byte>? GetAttachBuffDescBytes()
		{
			return this.__p.__vector_as_arraysegment(122);
		}

		// Token: 0x17000A86 RID: 2694
		// (get) Token: 0x06002C4D RID: 11341 RVA: 0x000A4180 File Offset: 0x000A2580
		public string AttachMechanismDesc
		{
			get
			{
				int num = this.__p.__offset(124);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002C4E RID: 11342 RVA: 0x000A41C3 File Offset: 0x000A25C3
		public ArraySegment<byte>? GetAttachMechanismDescBytes()
		{
			return this.__p.__vector_as_arraysegment(124);
		}

		// Token: 0x17000A87 RID: 2695
		// (get) Token: 0x06002C4F RID: 11343 RVA: 0x000A41D4 File Offset: 0x000A25D4
		public int DungeonEpicDropAddition
		{
			get
			{
				int num = this.__p.__offset(126);
				return (num == 0) ? 0 : (-2145302867 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002C50 RID: 11344 RVA: 0x000A4220 File Offset: 0x000A2620
		public static Offset<EquipAttrTable> CreateEquipAttrTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int Atk = 0, int MagicAtk = 0, int Independence = 0, int Def = 0, int MagicDef = 0, int Strenth = 0, int Intellect = 0, int Spirit = 0, int Stamina = 0, int PhySkillMp = 0, int PhySkillCd = 0, int MagSkillMp = 0, int MagSkillCd = 0, int HPMax = 0, int MPMax = 0, int HPRecover = 0, int MPRecover = 0, int AttackSpeedRate = 0, int FireSpeedRate = 0, int MoveSpeedRate = 0, int TownMoveSpeedRate = 0, int HitRate = 0, int AvoidRate = 0, int PhysicCrit = 0, int MagicCrit = 0, int Spasticity = 0, int Jump = 0, int ResistMagic = 0, VectorOffset ElementsOffset = default(VectorOffset), int LightAttack = 0, int FireAttack = 0, int IceAttack = 0, int DarkAttack = 0, int LightDefence = 0, int FireDefence = 0, int IceDefence = 0, int DarkDefence = 0, int AbormalResist = 0, VectorOffset AbormalResistsOffset = default(VectorOffset), int abnormalResist1 = 0, int abnormalResist2 = 0, int abnormalResist3 = 0, int abnormalResist4 = 0, int abnormalResist5 = 0, int abnormalResist6 = 0, int abnormalResist7 = 0, int abnormalResist8 = 0, int abnormalResist9 = 0, int abnormalResist10 = 0, int abnormalResist11 = 0, int abnormalResist12 = 0, int abnormalResist13 = 0, int AttachRateScore = 0, VectorOffset AttachBuffInfoIDsOffset = default(VectorOffset), VectorOffset AttachMechanismIDsOffset = default(VectorOffset), VectorOffset PVPAttachBuffInfoIDsOffset = default(VectorOffset), VectorOffset PVPAttachMechanismIDsOffset = default(VectorOffset), StringOffset AttachBuffDescOffset = default(StringOffset), StringOffset AttachMechanismDescOffset = default(StringOffset), int DungeonEpicDropAddition = 0)
		{
			builder.StartObject(62);
			EquipAttrTable.AddDungeonEpicDropAddition(builder, DungeonEpicDropAddition);
			EquipAttrTable.AddAttachMechanismDesc(builder, AttachMechanismDescOffset);
			EquipAttrTable.AddAttachBuffDesc(builder, AttachBuffDescOffset);
			EquipAttrTable.AddPVPAttachMechanismIDs(builder, PVPAttachMechanismIDsOffset);
			EquipAttrTable.AddPVPAttachBuffInfoIDs(builder, PVPAttachBuffInfoIDsOffset);
			EquipAttrTable.AddAttachMechanismIDs(builder, AttachMechanismIDsOffset);
			EquipAttrTable.AddAttachBuffInfoIDs(builder, AttachBuffInfoIDsOffset);
			EquipAttrTable.AddAttachRateScore(builder, AttachRateScore);
			EquipAttrTable.AddAbnormalResist13(builder, abnormalResist13);
			EquipAttrTable.AddAbnormalResist12(builder, abnormalResist12);
			EquipAttrTable.AddAbnormalResist11(builder, abnormalResist11);
			EquipAttrTable.AddAbnormalResist10(builder, abnormalResist10);
			EquipAttrTable.AddAbnormalResist9(builder, abnormalResist9);
			EquipAttrTable.AddAbnormalResist8(builder, abnormalResist8);
			EquipAttrTable.AddAbnormalResist7(builder, abnormalResist7);
			EquipAttrTable.AddAbnormalResist6(builder, abnormalResist6);
			EquipAttrTable.AddAbnormalResist5(builder, abnormalResist5);
			EquipAttrTable.AddAbnormalResist4(builder, abnormalResist4);
			EquipAttrTable.AddAbnormalResist3(builder, abnormalResist3);
			EquipAttrTable.AddAbnormalResist2(builder, abnormalResist2);
			EquipAttrTable.AddAbnormalResist1(builder, abnormalResist1);
			EquipAttrTable.AddAbormalResists(builder, AbormalResistsOffset);
			EquipAttrTable.AddAbormalResist(builder, AbormalResist);
			EquipAttrTable.AddDarkDefence(builder, DarkDefence);
			EquipAttrTable.AddIceDefence(builder, IceDefence);
			EquipAttrTable.AddFireDefence(builder, FireDefence);
			EquipAttrTable.AddLightDefence(builder, LightDefence);
			EquipAttrTable.AddDarkAttack(builder, DarkAttack);
			EquipAttrTable.AddIceAttack(builder, IceAttack);
			EquipAttrTable.AddFireAttack(builder, FireAttack);
			EquipAttrTable.AddLightAttack(builder, LightAttack);
			EquipAttrTable.AddElements(builder, ElementsOffset);
			EquipAttrTable.AddResistMagic(builder, ResistMagic);
			EquipAttrTable.AddJump(builder, Jump);
			EquipAttrTable.AddSpasticity(builder, Spasticity);
			EquipAttrTable.AddMagicCrit(builder, MagicCrit);
			EquipAttrTable.AddPhysicCrit(builder, PhysicCrit);
			EquipAttrTable.AddAvoidRate(builder, AvoidRate);
			EquipAttrTable.AddHitRate(builder, HitRate);
			EquipAttrTable.AddTownMoveSpeedRate(builder, TownMoveSpeedRate);
			EquipAttrTable.AddMoveSpeedRate(builder, MoveSpeedRate);
			EquipAttrTable.AddFireSpeedRate(builder, FireSpeedRate);
			EquipAttrTable.AddAttackSpeedRate(builder, AttackSpeedRate);
			EquipAttrTable.AddMPRecover(builder, MPRecover);
			EquipAttrTable.AddHPRecover(builder, HPRecover);
			EquipAttrTable.AddMPMax(builder, MPMax);
			EquipAttrTable.AddHPMax(builder, HPMax);
			EquipAttrTable.AddMagSkillCd(builder, MagSkillCd);
			EquipAttrTable.AddMagSkillMp(builder, MagSkillMp);
			EquipAttrTable.AddPhySkillCd(builder, PhySkillCd);
			EquipAttrTable.AddPhySkillMp(builder, PhySkillMp);
			EquipAttrTable.AddStamina(builder, Stamina);
			EquipAttrTable.AddSpirit(builder, Spirit);
			EquipAttrTable.AddIntellect(builder, Intellect);
			EquipAttrTable.AddStrenth(builder, Strenth);
			EquipAttrTable.AddMagicDef(builder, MagicDef);
			EquipAttrTable.AddDef(builder, Def);
			EquipAttrTable.AddIndependence(builder, Independence);
			EquipAttrTable.AddMagicAtk(builder, MagicAtk);
			EquipAttrTable.AddAtk(builder, Atk);
			EquipAttrTable.AddName(builder, NameOffset);
			EquipAttrTable.AddID(builder, ID);
			return EquipAttrTable.EndEquipAttrTable(builder);
		}

		// Token: 0x06002C51 RID: 11345 RVA: 0x000A4428 File Offset: 0x000A2828
		public static void StartEquipAttrTable(FlatBufferBuilder builder)
		{
			builder.StartObject(62);
		}

		// Token: 0x06002C52 RID: 11346 RVA: 0x000A4432 File Offset: 0x000A2832
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002C53 RID: 11347 RVA: 0x000A443D File Offset: 0x000A283D
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06002C54 RID: 11348 RVA: 0x000A444E File Offset: 0x000A284E
		public static void AddAtk(FlatBufferBuilder builder, int Atk)
		{
			builder.AddInt(2, Atk, 0);
		}

		// Token: 0x06002C55 RID: 11349 RVA: 0x000A4459 File Offset: 0x000A2859
		public static void AddMagicAtk(FlatBufferBuilder builder, int MagicAtk)
		{
			builder.AddInt(3, MagicAtk, 0);
		}

		// Token: 0x06002C56 RID: 11350 RVA: 0x000A4464 File Offset: 0x000A2864
		public static void AddIndependence(FlatBufferBuilder builder, int Independence)
		{
			builder.AddInt(4, Independence, 0);
		}

		// Token: 0x06002C57 RID: 11351 RVA: 0x000A446F File Offset: 0x000A286F
		public static void AddDef(FlatBufferBuilder builder, int Def)
		{
			builder.AddInt(5, Def, 0);
		}

		// Token: 0x06002C58 RID: 11352 RVA: 0x000A447A File Offset: 0x000A287A
		public static void AddMagicDef(FlatBufferBuilder builder, int MagicDef)
		{
			builder.AddInt(6, MagicDef, 0);
		}

		// Token: 0x06002C59 RID: 11353 RVA: 0x000A4485 File Offset: 0x000A2885
		public static void AddStrenth(FlatBufferBuilder builder, int Strenth)
		{
			builder.AddInt(7, Strenth, 0);
		}

		// Token: 0x06002C5A RID: 11354 RVA: 0x000A4490 File Offset: 0x000A2890
		public static void AddIntellect(FlatBufferBuilder builder, int Intellect)
		{
			builder.AddInt(8, Intellect, 0);
		}

		// Token: 0x06002C5B RID: 11355 RVA: 0x000A449B File Offset: 0x000A289B
		public static void AddSpirit(FlatBufferBuilder builder, int Spirit)
		{
			builder.AddInt(9, Spirit, 0);
		}

		// Token: 0x06002C5C RID: 11356 RVA: 0x000A44A7 File Offset: 0x000A28A7
		public static void AddStamina(FlatBufferBuilder builder, int Stamina)
		{
			builder.AddInt(10, Stamina, 0);
		}

		// Token: 0x06002C5D RID: 11357 RVA: 0x000A44B3 File Offset: 0x000A28B3
		public static void AddPhySkillMp(FlatBufferBuilder builder, int PhySkillMp)
		{
			builder.AddInt(11, PhySkillMp, 0);
		}

		// Token: 0x06002C5E RID: 11358 RVA: 0x000A44BF File Offset: 0x000A28BF
		public static void AddPhySkillCd(FlatBufferBuilder builder, int PhySkillCd)
		{
			builder.AddInt(12, PhySkillCd, 0);
		}

		// Token: 0x06002C5F RID: 11359 RVA: 0x000A44CB File Offset: 0x000A28CB
		public static void AddMagSkillMp(FlatBufferBuilder builder, int MagSkillMp)
		{
			builder.AddInt(13, MagSkillMp, 0);
		}

		// Token: 0x06002C60 RID: 11360 RVA: 0x000A44D7 File Offset: 0x000A28D7
		public static void AddMagSkillCd(FlatBufferBuilder builder, int MagSkillCd)
		{
			builder.AddInt(14, MagSkillCd, 0);
		}

		// Token: 0x06002C61 RID: 11361 RVA: 0x000A44E3 File Offset: 0x000A28E3
		public static void AddHPMax(FlatBufferBuilder builder, int HPMax)
		{
			builder.AddInt(15, HPMax, 0);
		}

		// Token: 0x06002C62 RID: 11362 RVA: 0x000A44EF File Offset: 0x000A28EF
		public static void AddMPMax(FlatBufferBuilder builder, int MPMax)
		{
			builder.AddInt(16, MPMax, 0);
		}

		// Token: 0x06002C63 RID: 11363 RVA: 0x000A44FB File Offset: 0x000A28FB
		public static void AddHPRecover(FlatBufferBuilder builder, int HPRecover)
		{
			builder.AddInt(17, HPRecover, 0);
		}

		// Token: 0x06002C64 RID: 11364 RVA: 0x000A4507 File Offset: 0x000A2907
		public static void AddMPRecover(FlatBufferBuilder builder, int MPRecover)
		{
			builder.AddInt(18, MPRecover, 0);
		}

		// Token: 0x06002C65 RID: 11365 RVA: 0x000A4513 File Offset: 0x000A2913
		public static void AddAttackSpeedRate(FlatBufferBuilder builder, int AttackSpeedRate)
		{
			builder.AddInt(19, AttackSpeedRate, 0);
		}

		// Token: 0x06002C66 RID: 11366 RVA: 0x000A451F File Offset: 0x000A291F
		public static void AddFireSpeedRate(FlatBufferBuilder builder, int FireSpeedRate)
		{
			builder.AddInt(20, FireSpeedRate, 0);
		}

		// Token: 0x06002C67 RID: 11367 RVA: 0x000A452B File Offset: 0x000A292B
		public static void AddMoveSpeedRate(FlatBufferBuilder builder, int MoveSpeedRate)
		{
			builder.AddInt(21, MoveSpeedRate, 0);
		}

		// Token: 0x06002C68 RID: 11368 RVA: 0x000A4537 File Offset: 0x000A2937
		public static void AddTownMoveSpeedRate(FlatBufferBuilder builder, int TownMoveSpeedRate)
		{
			builder.AddInt(22, TownMoveSpeedRate, 0);
		}

		// Token: 0x06002C69 RID: 11369 RVA: 0x000A4543 File Offset: 0x000A2943
		public static void AddHitRate(FlatBufferBuilder builder, int HitRate)
		{
			builder.AddInt(23, HitRate, 0);
		}

		// Token: 0x06002C6A RID: 11370 RVA: 0x000A454F File Offset: 0x000A294F
		public static void AddAvoidRate(FlatBufferBuilder builder, int AvoidRate)
		{
			builder.AddInt(24, AvoidRate, 0);
		}

		// Token: 0x06002C6B RID: 11371 RVA: 0x000A455B File Offset: 0x000A295B
		public static void AddPhysicCrit(FlatBufferBuilder builder, int PhysicCrit)
		{
			builder.AddInt(25, PhysicCrit, 0);
		}

		// Token: 0x06002C6C RID: 11372 RVA: 0x000A4567 File Offset: 0x000A2967
		public static void AddMagicCrit(FlatBufferBuilder builder, int MagicCrit)
		{
			builder.AddInt(26, MagicCrit, 0);
		}

		// Token: 0x06002C6D RID: 11373 RVA: 0x000A4573 File Offset: 0x000A2973
		public static void AddSpasticity(FlatBufferBuilder builder, int Spasticity)
		{
			builder.AddInt(27, Spasticity, 0);
		}

		// Token: 0x06002C6E RID: 11374 RVA: 0x000A457F File Offset: 0x000A297F
		public static void AddJump(FlatBufferBuilder builder, int Jump)
		{
			builder.AddInt(28, Jump, 0);
		}

		// Token: 0x06002C6F RID: 11375 RVA: 0x000A458B File Offset: 0x000A298B
		public static void AddResistMagic(FlatBufferBuilder builder, int ResistMagic)
		{
			builder.AddInt(29, ResistMagic, 0);
		}

		// Token: 0x06002C70 RID: 11376 RVA: 0x000A4597 File Offset: 0x000A2997
		public static void AddElements(FlatBufferBuilder builder, VectorOffset ElementsOffset)
		{
			builder.AddOffset(30, ElementsOffset.Value, 0);
		}

		// Token: 0x06002C71 RID: 11377 RVA: 0x000A45AC File Offset: 0x000A29AC
		public static VectorOffset CreateElementsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002C72 RID: 11378 RVA: 0x000A45E9 File Offset: 0x000A29E9
		public static void StartElementsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002C73 RID: 11379 RVA: 0x000A45F4 File Offset: 0x000A29F4
		public static void AddLightAttack(FlatBufferBuilder builder, int LightAttack)
		{
			builder.AddInt(31, LightAttack, 0);
		}

		// Token: 0x06002C74 RID: 11380 RVA: 0x000A4600 File Offset: 0x000A2A00
		public static void AddFireAttack(FlatBufferBuilder builder, int FireAttack)
		{
			builder.AddInt(32, FireAttack, 0);
		}

		// Token: 0x06002C75 RID: 11381 RVA: 0x000A460C File Offset: 0x000A2A0C
		public static void AddIceAttack(FlatBufferBuilder builder, int IceAttack)
		{
			builder.AddInt(33, IceAttack, 0);
		}

		// Token: 0x06002C76 RID: 11382 RVA: 0x000A4618 File Offset: 0x000A2A18
		public static void AddDarkAttack(FlatBufferBuilder builder, int DarkAttack)
		{
			builder.AddInt(34, DarkAttack, 0);
		}

		// Token: 0x06002C77 RID: 11383 RVA: 0x000A4624 File Offset: 0x000A2A24
		public static void AddLightDefence(FlatBufferBuilder builder, int LightDefence)
		{
			builder.AddInt(35, LightDefence, 0);
		}

		// Token: 0x06002C78 RID: 11384 RVA: 0x000A4630 File Offset: 0x000A2A30
		public static void AddFireDefence(FlatBufferBuilder builder, int FireDefence)
		{
			builder.AddInt(36, FireDefence, 0);
		}

		// Token: 0x06002C79 RID: 11385 RVA: 0x000A463C File Offset: 0x000A2A3C
		public static void AddIceDefence(FlatBufferBuilder builder, int IceDefence)
		{
			builder.AddInt(37, IceDefence, 0);
		}

		// Token: 0x06002C7A RID: 11386 RVA: 0x000A4648 File Offset: 0x000A2A48
		public static void AddDarkDefence(FlatBufferBuilder builder, int DarkDefence)
		{
			builder.AddInt(38, DarkDefence, 0);
		}

		// Token: 0x06002C7B RID: 11387 RVA: 0x000A4654 File Offset: 0x000A2A54
		public static void AddAbormalResist(FlatBufferBuilder builder, int AbormalResist)
		{
			builder.AddInt(39, AbormalResist, 0);
		}

		// Token: 0x06002C7C RID: 11388 RVA: 0x000A4660 File Offset: 0x000A2A60
		public static void AddAbormalResists(FlatBufferBuilder builder, VectorOffset AbormalResistsOffset)
		{
			builder.AddOffset(40, AbormalResistsOffset.Value, 0);
		}

		// Token: 0x06002C7D RID: 11389 RVA: 0x000A4674 File Offset: 0x000A2A74
		public static VectorOffset CreateAbormalResistsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06002C7E RID: 11390 RVA: 0x000A46BA File Offset: 0x000A2ABA
		public static void StartAbormalResistsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002C7F RID: 11391 RVA: 0x000A46C5 File Offset: 0x000A2AC5
		public static void AddAbnormalResist1(FlatBufferBuilder builder, int abnormalResist1)
		{
			builder.AddInt(41, abnormalResist1, 0);
		}

		// Token: 0x06002C80 RID: 11392 RVA: 0x000A46D1 File Offset: 0x000A2AD1
		public static void AddAbnormalResist2(FlatBufferBuilder builder, int abnormalResist2)
		{
			builder.AddInt(42, abnormalResist2, 0);
		}

		// Token: 0x06002C81 RID: 11393 RVA: 0x000A46DD File Offset: 0x000A2ADD
		public static void AddAbnormalResist3(FlatBufferBuilder builder, int abnormalResist3)
		{
			builder.AddInt(43, abnormalResist3, 0);
		}

		// Token: 0x06002C82 RID: 11394 RVA: 0x000A46E9 File Offset: 0x000A2AE9
		public static void AddAbnormalResist4(FlatBufferBuilder builder, int abnormalResist4)
		{
			builder.AddInt(44, abnormalResist4, 0);
		}

		// Token: 0x06002C83 RID: 11395 RVA: 0x000A46F5 File Offset: 0x000A2AF5
		public static void AddAbnormalResist5(FlatBufferBuilder builder, int abnormalResist5)
		{
			builder.AddInt(45, abnormalResist5, 0);
		}

		// Token: 0x06002C84 RID: 11396 RVA: 0x000A4701 File Offset: 0x000A2B01
		public static void AddAbnormalResist6(FlatBufferBuilder builder, int abnormalResist6)
		{
			builder.AddInt(46, abnormalResist6, 0);
		}

		// Token: 0x06002C85 RID: 11397 RVA: 0x000A470D File Offset: 0x000A2B0D
		public static void AddAbnormalResist7(FlatBufferBuilder builder, int abnormalResist7)
		{
			builder.AddInt(47, abnormalResist7, 0);
		}

		// Token: 0x06002C86 RID: 11398 RVA: 0x000A4719 File Offset: 0x000A2B19
		public static void AddAbnormalResist8(FlatBufferBuilder builder, int abnormalResist8)
		{
			builder.AddInt(48, abnormalResist8, 0);
		}

		// Token: 0x06002C87 RID: 11399 RVA: 0x000A4725 File Offset: 0x000A2B25
		public static void AddAbnormalResist9(FlatBufferBuilder builder, int abnormalResist9)
		{
			builder.AddInt(49, abnormalResist9, 0);
		}

		// Token: 0x06002C88 RID: 11400 RVA: 0x000A4731 File Offset: 0x000A2B31
		public static void AddAbnormalResist10(FlatBufferBuilder builder, int abnormalResist10)
		{
			builder.AddInt(50, abnormalResist10, 0);
		}

		// Token: 0x06002C89 RID: 11401 RVA: 0x000A473D File Offset: 0x000A2B3D
		public static void AddAbnormalResist11(FlatBufferBuilder builder, int abnormalResist11)
		{
			builder.AddInt(51, abnormalResist11, 0);
		}

		// Token: 0x06002C8A RID: 11402 RVA: 0x000A4749 File Offset: 0x000A2B49
		public static void AddAbnormalResist12(FlatBufferBuilder builder, int abnormalResist12)
		{
			builder.AddInt(52, abnormalResist12, 0);
		}

		// Token: 0x06002C8B RID: 11403 RVA: 0x000A4755 File Offset: 0x000A2B55
		public static void AddAbnormalResist13(FlatBufferBuilder builder, int abnormalResist13)
		{
			builder.AddInt(53, abnormalResist13, 0);
		}

		// Token: 0x06002C8C RID: 11404 RVA: 0x000A4761 File Offset: 0x000A2B61
		public static void AddAttachRateScore(FlatBufferBuilder builder, int AttachRateScore)
		{
			builder.AddInt(54, AttachRateScore, 0);
		}

		// Token: 0x06002C8D RID: 11405 RVA: 0x000A476D File Offset: 0x000A2B6D
		public static void AddAttachBuffInfoIDs(FlatBufferBuilder builder, VectorOffset AttachBuffInfoIDsOffset)
		{
			builder.AddOffset(55, AttachBuffInfoIDsOffset.Value, 0);
		}

		// Token: 0x06002C8E RID: 11406 RVA: 0x000A4780 File Offset: 0x000A2B80
		public static VectorOffset CreateAttachBuffInfoIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002C8F RID: 11407 RVA: 0x000A47BD File Offset: 0x000A2BBD
		public static void StartAttachBuffInfoIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002C90 RID: 11408 RVA: 0x000A47C8 File Offset: 0x000A2BC8
		public static void AddAttachMechanismIDs(FlatBufferBuilder builder, VectorOffset AttachMechanismIDsOffset)
		{
			builder.AddOffset(56, AttachMechanismIDsOffset.Value, 0);
		}

		// Token: 0x06002C91 RID: 11409 RVA: 0x000A47DC File Offset: 0x000A2BDC
		public static VectorOffset CreateAttachMechanismIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002C92 RID: 11410 RVA: 0x000A4819 File Offset: 0x000A2C19
		public static void StartAttachMechanismIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002C93 RID: 11411 RVA: 0x000A4824 File Offset: 0x000A2C24
		public static void AddPVPAttachBuffInfoIDs(FlatBufferBuilder builder, VectorOffset PVPAttachBuffInfoIDsOffset)
		{
			builder.AddOffset(57, PVPAttachBuffInfoIDsOffset.Value, 0);
		}

		// Token: 0x06002C94 RID: 11412 RVA: 0x000A4838 File Offset: 0x000A2C38
		public static VectorOffset CreatePVPAttachBuffInfoIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002C95 RID: 11413 RVA: 0x000A4875 File Offset: 0x000A2C75
		public static void StartPVPAttachBuffInfoIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002C96 RID: 11414 RVA: 0x000A4880 File Offset: 0x000A2C80
		public static void AddPVPAttachMechanismIDs(FlatBufferBuilder builder, VectorOffset PVPAttachMechanismIDsOffset)
		{
			builder.AddOffset(58, PVPAttachMechanismIDsOffset.Value, 0);
		}

		// Token: 0x06002C97 RID: 11415 RVA: 0x000A4894 File Offset: 0x000A2C94
		public static VectorOffset CreatePVPAttachMechanismIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002C98 RID: 11416 RVA: 0x000A48D1 File Offset: 0x000A2CD1
		public static void StartPVPAttachMechanismIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002C99 RID: 11417 RVA: 0x000A48DC File Offset: 0x000A2CDC
		public static void AddAttachBuffDesc(FlatBufferBuilder builder, StringOffset AttachBuffDescOffset)
		{
			builder.AddOffset(59, AttachBuffDescOffset.Value, 0);
		}

		// Token: 0x06002C9A RID: 11418 RVA: 0x000A48EE File Offset: 0x000A2CEE
		public static void AddAttachMechanismDesc(FlatBufferBuilder builder, StringOffset AttachMechanismDescOffset)
		{
			builder.AddOffset(60, AttachMechanismDescOffset.Value, 0);
		}

		// Token: 0x06002C9B RID: 11419 RVA: 0x000A4900 File Offset: 0x000A2D00
		public static void AddDungeonEpicDropAddition(FlatBufferBuilder builder, int DungeonEpicDropAddition)
		{
			builder.AddInt(61, DungeonEpicDropAddition, 0);
		}

		// Token: 0x06002C9C RID: 11420 RVA: 0x000A490C File Offset: 0x000A2D0C
		public static Offset<EquipAttrTable> EndEquipAttrTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipAttrTable>(value);
		}

		// Token: 0x06002C9D RID: 11421 RVA: 0x000A4926 File Offset: 0x000A2D26
		public static void FinishEquipAttrTableBuffer(FlatBufferBuilder builder, Offset<EquipAttrTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001307 RID: 4871
		private Table __p = new Table();

		// Token: 0x04001308 RID: 4872
		private FlatBufferArray<int> ElementsValue;

		// Token: 0x04001309 RID: 4873
		private FlatBufferArray<string> AbormalResistsValue;

		// Token: 0x0400130A RID: 4874
		private FlatBufferArray<int> AttachBuffInfoIDsValue;

		// Token: 0x0400130B RID: 4875
		private FlatBufferArray<int> AttachMechanismIDsValue;

		// Token: 0x0400130C RID: 4876
		private FlatBufferArray<int> PVPAttachBuffInfoIDsValue;

		// Token: 0x0400130D RID: 4877
		private FlatBufferArray<int> PVPAttachMechanismIDsValue;

		// Token: 0x020003D4 RID: 980
		public enum eCrypt
		{
			// Token: 0x0400130F RID: 4879
			code = -2145302867
		}
	}
}
