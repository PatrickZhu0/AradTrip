using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003D5 RID: 981
	public class EquipBaseScoreModTable : IFlatbufferObject
	{
		// Token: 0x17000A88 RID: 2696
		// (get) Token: 0x06002C9F RID: 11423 RVA: 0x000A4948 File Offset: 0x000A2D48
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002CA0 RID: 11424 RVA: 0x000A4955 File Offset: 0x000A2D55
		public static EquipBaseScoreModTable GetRootAsEquipBaseScoreModTable(ByteBuffer _bb)
		{
			return EquipBaseScoreModTable.GetRootAsEquipBaseScoreModTable(_bb, new EquipBaseScoreModTable());
		}

		// Token: 0x06002CA1 RID: 11425 RVA: 0x000A4962 File Offset: 0x000A2D62
		public static EquipBaseScoreModTable GetRootAsEquipBaseScoreModTable(ByteBuffer _bb, EquipBaseScoreModTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002CA2 RID: 11426 RVA: 0x000A497E File Offset: 0x000A2D7E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002CA3 RID: 11427 RVA: 0x000A4998 File Offset: 0x000A2D98
		public EquipBaseScoreModTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000A89 RID: 2697
		// (get) Token: 0x06002CA4 RID: 11428 RVA: 0x000A49A4 File Offset: 0x000A2DA4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (669918333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A8A RID: 2698
		// (get) Token: 0x06002CA5 RID: 11429 RVA: 0x000A49F0 File Offset: 0x000A2DF0
		public EquipBaseScoreModTable.eItemSubType ItemSubType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (EquipBaseScoreModTable.eItemSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A8B RID: 2699
		// (get) Token: 0x06002CA6 RID: 11430 RVA: 0x000A4A34 File Offset: 0x000A2E34
		public EquipBaseScoreModTable.eItemQuality ItemQuality
		{
			get
			{
				int num = this.__p.__offset(8);
				return (EquipBaseScoreModTable.eItemQuality)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A8C RID: 2700
		// (get) Token: 0x06002CA7 RID: 11431 RVA: 0x000A4A78 File Offset: 0x000A2E78
		public int AttrMod1
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (669918333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A8D RID: 2701
		// (get) Token: 0x06002CA8 RID: 11432 RVA: 0x000A4AC4 File Offset: 0x000A2EC4
		public int AttrMod2
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (669918333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A8E RID: 2702
		// (get) Token: 0x06002CA9 RID: 11433 RVA: 0x000A4B10 File Offset: 0x000A2F10
		public int PowerMod1
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (669918333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A8F RID: 2703
		// (get) Token: 0x06002CAA RID: 11434 RVA: 0x000A4B5C File Offset: 0x000A2F5C
		public int PowerMod2
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (669918333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A90 RID: 2704
		// (get) Token: 0x06002CAB RID: 11435 RVA: 0x000A4BA8 File Offset: 0x000A2FA8
		public int PowerMod3
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (669918333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A91 RID: 2705
		// (get) Token: 0x06002CAC RID: 11436 RVA: 0x000A4BF4 File Offset: 0x000A2FF4
		public int DefMod1
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (669918333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A92 RID: 2706
		// (get) Token: 0x06002CAD RID: 11437 RVA: 0x000A4C40 File Offset: 0x000A3040
		public int DefMod2
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (669918333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A93 RID: 2707
		// (get) Token: 0x06002CAE RID: 11438 RVA: 0x000A4C8C File Offset: 0x000A308C
		public int StrenthQualityMod1
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (669918333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A94 RID: 2708
		// (get) Token: 0x06002CAF RID: 11439 RVA: 0x000A4CD8 File Offset: 0x000A30D8
		public int StrenthQualityMod2
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (669918333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002CB0 RID: 11440 RVA: 0x000A4D24 File Offset: 0x000A3124
		public int StrengthMod1Array(int j)
		{
			int num = this.__p.__offset(28);
			return (num == 0) ? 0 : (669918333 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000A95 RID: 2709
		// (get) Token: 0x06002CB1 RID: 11441 RVA: 0x000A4D74 File Offset: 0x000A3174
		public int StrengthMod1Length
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002CB2 RID: 11442 RVA: 0x000A4DA7 File Offset: 0x000A31A7
		public ArraySegment<byte>? GetStrengthMod1Bytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x17000A96 RID: 2710
		// (get) Token: 0x06002CB3 RID: 11443 RVA: 0x000A4DB6 File Offset: 0x000A31B6
		public FlatBufferArray<int> StrengthMod1
		{
			get
			{
				if (this.StrengthMod1Value == null)
				{
					this.StrengthMod1Value = new FlatBufferArray<int>(new Func<int, int>(this.StrengthMod1Array), this.StrengthMod1Length);
				}
				return this.StrengthMod1Value;
			}
		}

		// Token: 0x06002CB4 RID: 11444 RVA: 0x000A4DE8 File Offset: 0x000A31E8
		public int StrengthMod2Array(int j)
		{
			int num = this.__p.__offset(30);
			return (num == 0) ? 0 : (669918333 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000A97 RID: 2711
		// (get) Token: 0x06002CB5 RID: 11445 RVA: 0x000A4E38 File Offset: 0x000A3238
		public int StrengthMod2Length
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002CB6 RID: 11446 RVA: 0x000A4E6B File Offset: 0x000A326B
		public ArraySegment<byte>? GetStrengthMod2Bytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x17000A98 RID: 2712
		// (get) Token: 0x06002CB7 RID: 11447 RVA: 0x000A4E7A File Offset: 0x000A327A
		public FlatBufferArray<int> StrengthMod2
		{
			get
			{
				if (this.StrengthMod2Value == null)
				{
					this.StrengthMod2Value = new FlatBufferArray<int>(new Func<int, int>(this.StrengthMod2Array), this.StrengthMod2Length);
				}
				return this.StrengthMod2Value;
			}
		}

		// Token: 0x06002CB8 RID: 11448 RVA: 0x000A4EAC File Offset: 0x000A32AC
		public int StrengthMod3Array(int j)
		{
			int num = this.__p.__offset(32);
			return (num == 0) ? 0 : (669918333 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000A99 RID: 2713
		// (get) Token: 0x06002CB9 RID: 11449 RVA: 0x000A4EFC File Offset: 0x000A32FC
		public int StrengthMod3Length
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002CBA RID: 11450 RVA: 0x000A4F2F File Offset: 0x000A332F
		public ArraySegment<byte>? GetStrengthMod3Bytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x17000A9A RID: 2714
		// (get) Token: 0x06002CBB RID: 11451 RVA: 0x000A4F3E File Offset: 0x000A333E
		public FlatBufferArray<int> StrengthMod3
		{
			get
			{
				if (this.StrengthMod3Value == null)
				{
					this.StrengthMod3Value = new FlatBufferArray<int>(new Func<int, int>(this.StrengthMod3Array), this.StrengthMod3Length);
				}
				return this.StrengthMod3Value;
			}
		}

		// Token: 0x06002CBC RID: 11452 RVA: 0x000A4F70 File Offset: 0x000A3370
		public static Offset<EquipBaseScoreModTable> CreateEquipBaseScoreModTable(FlatBufferBuilder builder, int ID = 0, EquipBaseScoreModTable.eItemSubType ItemSubType = EquipBaseScoreModTable.eItemSubType.ST_NONE, EquipBaseScoreModTable.eItemQuality ItemQuality = EquipBaseScoreModTable.eItemQuality.CL_NONE, int AttrMod1 = 0, int AttrMod2 = 0, int PowerMod1 = 0, int PowerMod2 = 0, int PowerMod3 = 0, int DefMod1 = 0, int DefMod2 = 0, int StrenthQualityMod1 = 0, int StrenthQualityMod2 = 0, VectorOffset StrengthMod1Offset = default(VectorOffset), VectorOffset StrengthMod2Offset = default(VectorOffset), VectorOffset StrengthMod3Offset = default(VectorOffset))
		{
			builder.StartObject(15);
			EquipBaseScoreModTable.AddStrengthMod3(builder, StrengthMod3Offset);
			EquipBaseScoreModTable.AddStrengthMod2(builder, StrengthMod2Offset);
			EquipBaseScoreModTable.AddStrengthMod1(builder, StrengthMod1Offset);
			EquipBaseScoreModTable.AddStrenthQualityMod2(builder, StrenthQualityMod2);
			EquipBaseScoreModTable.AddStrenthQualityMod1(builder, StrenthQualityMod1);
			EquipBaseScoreModTable.AddDefMod2(builder, DefMod2);
			EquipBaseScoreModTable.AddDefMod1(builder, DefMod1);
			EquipBaseScoreModTable.AddPowerMod3(builder, PowerMod3);
			EquipBaseScoreModTable.AddPowerMod2(builder, PowerMod2);
			EquipBaseScoreModTable.AddPowerMod1(builder, PowerMod1);
			EquipBaseScoreModTable.AddAttrMod2(builder, AttrMod2);
			EquipBaseScoreModTable.AddAttrMod1(builder, AttrMod1);
			EquipBaseScoreModTable.AddItemQuality(builder, ItemQuality);
			EquipBaseScoreModTable.AddItemSubType(builder, ItemSubType);
			EquipBaseScoreModTable.AddID(builder, ID);
			return EquipBaseScoreModTable.EndEquipBaseScoreModTable(builder);
		}

		// Token: 0x06002CBD RID: 11453 RVA: 0x000A5000 File Offset: 0x000A3400
		public static void StartEquipBaseScoreModTable(FlatBufferBuilder builder)
		{
			builder.StartObject(15);
		}

		// Token: 0x06002CBE RID: 11454 RVA: 0x000A500A File Offset: 0x000A340A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002CBF RID: 11455 RVA: 0x000A5015 File Offset: 0x000A3415
		public static void AddItemSubType(FlatBufferBuilder builder, EquipBaseScoreModTable.eItemSubType ItemSubType)
		{
			builder.AddInt(1, (int)ItemSubType, 0);
		}

		// Token: 0x06002CC0 RID: 11456 RVA: 0x000A5020 File Offset: 0x000A3420
		public static void AddItemQuality(FlatBufferBuilder builder, EquipBaseScoreModTable.eItemQuality ItemQuality)
		{
			builder.AddInt(2, (int)ItemQuality, 0);
		}

		// Token: 0x06002CC1 RID: 11457 RVA: 0x000A502B File Offset: 0x000A342B
		public static void AddAttrMod1(FlatBufferBuilder builder, int AttrMod1)
		{
			builder.AddInt(3, AttrMod1, 0);
		}

		// Token: 0x06002CC2 RID: 11458 RVA: 0x000A5036 File Offset: 0x000A3436
		public static void AddAttrMod2(FlatBufferBuilder builder, int AttrMod2)
		{
			builder.AddInt(4, AttrMod2, 0);
		}

		// Token: 0x06002CC3 RID: 11459 RVA: 0x000A5041 File Offset: 0x000A3441
		public static void AddPowerMod1(FlatBufferBuilder builder, int PowerMod1)
		{
			builder.AddInt(5, PowerMod1, 0);
		}

		// Token: 0x06002CC4 RID: 11460 RVA: 0x000A504C File Offset: 0x000A344C
		public static void AddPowerMod2(FlatBufferBuilder builder, int PowerMod2)
		{
			builder.AddInt(6, PowerMod2, 0);
		}

		// Token: 0x06002CC5 RID: 11461 RVA: 0x000A5057 File Offset: 0x000A3457
		public static void AddPowerMod3(FlatBufferBuilder builder, int PowerMod3)
		{
			builder.AddInt(7, PowerMod3, 0);
		}

		// Token: 0x06002CC6 RID: 11462 RVA: 0x000A5062 File Offset: 0x000A3462
		public static void AddDefMod1(FlatBufferBuilder builder, int DefMod1)
		{
			builder.AddInt(8, DefMod1, 0);
		}

		// Token: 0x06002CC7 RID: 11463 RVA: 0x000A506D File Offset: 0x000A346D
		public static void AddDefMod2(FlatBufferBuilder builder, int DefMod2)
		{
			builder.AddInt(9, DefMod2, 0);
		}

		// Token: 0x06002CC8 RID: 11464 RVA: 0x000A5079 File Offset: 0x000A3479
		public static void AddStrenthQualityMod1(FlatBufferBuilder builder, int StrenthQualityMod1)
		{
			builder.AddInt(10, StrenthQualityMod1, 0);
		}

		// Token: 0x06002CC9 RID: 11465 RVA: 0x000A5085 File Offset: 0x000A3485
		public static void AddStrenthQualityMod2(FlatBufferBuilder builder, int StrenthQualityMod2)
		{
			builder.AddInt(11, StrenthQualityMod2, 0);
		}

		// Token: 0x06002CCA RID: 11466 RVA: 0x000A5091 File Offset: 0x000A3491
		public static void AddStrengthMod1(FlatBufferBuilder builder, VectorOffset StrengthMod1Offset)
		{
			builder.AddOffset(12, StrengthMod1Offset.Value, 0);
		}

		// Token: 0x06002CCB RID: 11467 RVA: 0x000A50A4 File Offset: 0x000A34A4
		public static VectorOffset CreateStrengthMod1Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002CCC RID: 11468 RVA: 0x000A50E1 File Offset: 0x000A34E1
		public static void StartStrengthMod1Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002CCD RID: 11469 RVA: 0x000A50EC File Offset: 0x000A34EC
		public static void AddStrengthMod2(FlatBufferBuilder builder, VectorOffset StrengthMod2Offset)
		{
			builder.AddOffset(13, StrengthMod2Offset.Value, 0);
		}

		// Token: 0x06002CCE RID: 11470 RVA: 0x000A5100 File Offset: 0x000A3500
		public static VectorOffset CreateStrengthMod2Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002CCF RID: 11471 RVA: 0x000A513D File Offset: 0x000A353D
		public static void StartStrengthMod2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002CD0 RID: 11472 RVA: 0x000A5148 File Offset: 0x000A3548
		public static void AddStrengthMod3(FlatBufferBuilder builder, VectorOffset StrengthMod3Offset)
		{
			builder.AddOffset(14, StrengthMod3Offset.Value, 0);
		}

		// Token: 0x06002CD1 RID: 11473 RVA: 0x000A515C File Offset: 0x000A355C
		public static VectorOffset CreateStrengthMod3Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002CD2 RID: 11474 RVA: 0x000A5199 File Offset: 0x000A3599
		public static void StartStrengthMod3Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002CD3 RID: 11475 RVA: 0x000A51A4 File Offset: 0x000A35A4
		public static Offset<EquipBaseScoreModTable> EndEquipBaseScoreModTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipBaseScoreModTable>(value);
		}

		// Token: 0x06002CD4 RID: 11476 RVA: 0x000A51BE File Offset: 0x000A35BE
		public static void FinishEquipBaseScoreModTableBuffer(FlatBufferBuilder builder, Offset<EquipBaseScoreModTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001310 RID: 4880
		private Table __p = new Table();

		// Token: 0x04001311 RID: 4881
		private FlatBufferArray<int> StrengthMod1Value;

		// Token: 0x04001312 RID: 4882
		private FlatBufferArray<int> StrengthMod2Value;

		// Token: 0x04001313 RID: 4883
		private FlatBufferArray<int> StrengthMod3Value;

		// Token: 0x020003D6 RID: 982
		public enum eItemSubType
		{
			// Token: 0x04001315 RID: 4885
			ST_NONE,
			// Token: 0x04001316 RID: 4886
			WEAPON,
			// Token: 0x04001317 RID: 4887
			SHOULDER,
			// Token: 0x04001318 RID: 4888
			CHEST,
			// Token: 0x04001319 RID: 4889
			BELT,
			// Token: 0x0400131A RID: 4890
			LEG,
			// Token: 0x0400131B RID: 4891
			BOOT,
			// Token: 0x0400131C RID: 4892
			RING,
			// Token: 0x0400131D RID: 4893
			NECKLASE,
			// Token: 0x0400131E RID: 4894
			BRACELET,
			// Token: 0x0400131F RID: 4895
			ST_ASSIST_EQUIP = 99,
			// Token: 0x04001320 RID: 4896
			ST_MAGICSTONE_EQUIP,
			// Token: 0x04001321 RID: 4897
			ST_EARRINGS_EQUIP
		}

		// Token: 0x020003D7 RID: 983
		public enum eItemQuality
		{
			// Token: 0x04001323 RID: 4899
			CL_NONE,
			// Token: 0x04001324 RID: 4900
			WHITE,
			// Token: 0x04001325 RID: 4901
			BLUE,
			// Token: 0x04001326 RID: 4902
			PURPLE,
			// Token: 0x04001327 RID: 4903
			GREEN,
			// Token: 0x04001328 RID: 4904
			PINK,
			// Token: 0x04001329 RID: 4905
			YELLOW
		}

		// Token: 0x020003D8 RID: 984
		public enum eCrypt
		{
			// Token: 0x0400132B RID: 4907
			code = 669918333
		}
	}
}
