using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003F1 RID: 1009
	public class EquipInscriptionHoleTable : IFlatbufferObject
	{
		// Token: 0x17000AFA RID: 2810
		// (get) Token: 0x06002E0A RID: 11786 RVA: 0x000A7CE0 File Offset: 0x000A60E0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002E0B RID: 11787 RVA: 0x000A7CED File Offset: 0x000A60ED
		public static EquipInscriptionHoleTable GetRootAsEquipInscriptionHoleTable(ByteBuffer _bb)
		{
			return EquipInscriptionHoleTable.GetRootAsEquipInscriptionHoleTable(_bb, new EquipInscriptionHoleTable());
		}

		// Token: 0x06002E0C RID: 11788 RVA: 0x000A7CFA File Offset: 0x000A60FA
		public static EquipInscriptionHoleTable GetRootAsEquipInscriptionHoleTable(ByteBuffer _bb, EquipInscriptionHoleTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002E0D RID: 11789 RVA: 0x000A7D16 File Offset: 0x000A6116
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002E0E RID: 11790 RVA: 0x000A7D30 File Offset: 0x000A6130
		public EquipInscriptionHoleTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000AFB RID: 2811
		// (get) Token: 0x06002E0F RID: 11791 RVA: 0x000A7D3C File Offset: 0x000A613C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1881302628 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AFC RID: 2812
		// (get) Token: 0x06002E10 RID: 11792 RVA: 0x000A7D88 File Offset: 0x000A6188
		public EquipInscriptionHoleTable.eColor Color
		{
			get
			{
				int num = this.__p.__offset(6);
				return (EquipInscriptionHoleTable.eColor)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AFD RID: 2813
		// (get) Token: 0x06002E11 RID: 11793 RVA: 0x000A7DCC File Offset: 0x000A61CC
		public int Color2
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1881302628 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AFE RID: 2814
		// (get) Token: 0x06002E12 RID: 11794 RVA: 0x000A7E18 File Offset: 0x000A6218
		public EquipInscriptionHoleTable.eSubType SubType
		{
			get
			{
				int num = this.__p.__offset(10);
				return (EquipInscriptionHoleTable.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AFF RID: 2815
		// (get) Token: 0x06002E13 RID: 11795 RVA: 0x000A7E5C File Offset: 0x000A625C
		public int InscriptionHoleNum
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1881302628 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B00 RID: 2816
		// (get) Token: 0x06002E14 RID: 11796 RVA: 0x000A7EA8 File Offset: 0x000A62A8
		public string InscriptionHoleColor
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002E15 RID: 11797 RVA: 0x000A7EEB File Offset: 0x000A62EB
		public ArraySegment<byte>? GetInscriptionHoleColorBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000B01 RID: 2817
		// (get) Token: 0x06002E16 RID: 11798 RVA: 0x000A7EFC File Offset: 0x000A62FC
		public string ItemConsume
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002E17 RID: 11799 RVA: 0x000A7F3F File Offset: 0x000A633F
		public ArraySegment<byte>? GetItemConsumeBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000B02 RID: 2818
		// (get) Token: 0x06002E18 RID: 11800 RVA: 0x000A7F50 File Offset: 0x000A6350
		public string GoldConsume
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002E19 RID: 11801 RVA: 0x000A7F93 File Offset: 0x000A6393
		public ArraySegment<byte>? GetGoldConsumeBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x06002E1A RID: 11802 RVA: 0x000A7FA4 File Offset: 0x000A63A4
		public static Offset<EquipInscriptionHoleTable> CreateEquipInscriptionHoleTable(FlatBufferBuilder builder, int ID = 0, EquipInscriptionHoleTable.eColor Color = EquipInscriptionHoleTable.eColor.CL_NONE, int Color2 = 0, EquipInscriptionHoleTable.eSubType SubType = EquipInscriptionHoleTable.eSubType.SubType_None, int InscriptionHoleNum = 0, StringOffset InscriptionHoleColorOffset = default(StringOffset), StringOffset ItemConsumeOffset = default(StringOffset), StringOffset GoldConsumeOffset = default(StringOffset))
		{
			builder.StartObject(8);
			EquipInscriptionHoleTable.AddGoldConsume(builder, GoldConsumeOffset);
			EquipInscriptionHoleTable.AddItemConsume(builder, ItemConsumeOffset);
			EquipInscriptionHoleTable.AddInscriptionHoleColor(builder, InscriptionHoleColorOffset);
			EquipInscriptionHoleTable.AddInscriptionHoleNum(builder, InscriptionHoleNum);
			EquipInscriptionHoleTable.AddSubType(builder, SubType);
			EquipInscriptionHoleTable.AddColor2(builder, Color2);
			EquipInscriptionHoleTable.AddColor(builder, Color);
			EquipInscriptionHoleTable.AddID(builder, ID);
			return EquipInscriptionHoleTable.EndEquipInscriptionHoleTable(builder);
		}

		// Token: 0x06002E1B RID: 11803 RVA: 0x000A7FFB File Offset: 0x000A63FB
		public static void StartEquipInscriptionHoleTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x06002E1C RID: 11804 RVA: 0x000A8004 File Offset: 0x000A6404
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002E1D RID: 11805 RVA: 0x000A800F File Offset: 0x000A640F
		public static void AddColor(FlatBufferBuilder builder, EquipInscriptionHoleTable.eColor Color)
		{
			builder.AddInt(1, (int)Color, 0);
		}

		// Token: 0x06002E1E RID: 11806 RVA: 0x000A801A File Offset: 0x000A641A
		public static void AddColor2(FlatBufferBuilder builder, int Color2)
		{
			builder.AddInt(2, Color2, 0);
		}

		// Token: 0x06002E1F RID: 11807 RVA: 0x000A8025 File Offset: 0x000A6425
		public static void AddSubType(FlatBufferBuilder builder, EquipInscriptionHoleTable.eSubType SubType)
		{
			builder.AddInt(3, (int)SubType, 0);
		}

		// Token: 0x06002E20 RID: 11808 RVA: 0x000A8030 File Offset: 0x000A6430
		public static void AddInscriptionHoleNum(FlatBufferBuilder builder, int InscriptionHoleNum)
		{
			builder.AddInt(4, InscriptionHoleNum, 0);
		}

		// Token: 0x06002E21 RID: 11809 RVA: 0x000A803B File Offset: 0x000A643B
		public static void AddInscriptionHoleColor(FlatBufferBuilder builder, StringOffset InscriptionHoleColorOffset)
		{
			builder.AddOffset(5, InscriptionHoleColorOffset.Value, 0);
		}

		// Token: 0x06002E22 RID: 11810 RVA: 0x000A804C File Offset: 0x000A644C
		public static void AddItemConsume(FlatBufferBuilder builder, StringOffset ItemConsumeOffset)
		{
			builder.AddOffset(6, ItemConsumeOffset.Value, 0);
		}

		// Token: 0x06002E23 RID: 11811 RVA: 0x000A805D File Offset: 0x000A645D
		public static void AddGoldConsume(FlatBufferBuilder builder, StringOffset GoldConsumeOffset)
		{
			builder.AddOffset(7, GoldConsumeOffset.Value, 0);
		}

		// Token: 0x06002E24 RID: 11812 RVA: 0x000A8070 File Offset: 0x000A6470
		public static Offset<EquipInscriptionHoleTable> EndEquipInscriptionHoleTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipInscriptionHoleTable>(value);
		}

		// Token: 0x06002E25 RID: 11813 RVA: 0x000A808A File Offset: 0x000A648A
		public static void FinishEquipInscriptionHoleTableBuffer(FlatBufferBuilder builder, Offset<EquipInscriptionHoleTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001362 RID: 4962
		private Table __p = new Table();

		// Token: 0x020003F2 RID: 1010
		public enum eColor
		{
			// Token: 0x04001364 RID: 4964
			CL_NONE,
			// Token: 0x04001365 RID: 4965
			WHITE,
			// Token: 0x04001366 RID: 4966
			BLUE,
			// Token: 0x04001367 RID: 4967
			PURPLE,
			// Token: 0x04001368 RID: 4968
			GREEN,
			// Token: 0x04001369 RID: 4969
			PINK,
			// Token: 0x0400136A RID: 4970
			YELLOW
		}

		// Token: 0x020003F3 RID: 1011
		public enum eSubType
		{
			// Token: 0x0400136C RID: 4972
			SubType_None,
			// Token: 0x0400136D RID: 4973
			WEAPON,
			// Token: 0x0400136E RID: 4974
			HEAD,
			// Token: 0x0400136F RID: 4975
			CHEST,
			// Token: 0x04001370 RID: 4976
			BELT,
			// Token: 0x04001371 RID: 4977
			LEG,
			// Token: 0x04001372 RID: 4978
			BOOT,
			// Token: 0x04001373 RID: 4979
			RING,
			// Token: 0x04001374 RID: 4980
			NECKLASE,
			// Token: 0x04001375 RID: 4981
			BRACELET,
			// Token: 0x04001376 RID: 4982
			ST_ASSIST_EQUIP = 99,
			// Token: 0x04001377 RID: 4983
			ST_MAGICSTONE_EQUIP,
			// Token: 0x04001378 RID: 4984
			ST_EARRINGS_EQUIP
		}

		// Token: 0x020003F4 RID: 1012
		public enum eCrypt
		{
			// Token: 0x0400137A RID: 4986
			code = -1881302628
		}
	}
}
