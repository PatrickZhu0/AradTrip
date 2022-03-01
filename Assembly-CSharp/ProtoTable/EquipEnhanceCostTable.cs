using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003DD RID: 989
	public class EquipEnhanceCostTable : IFlatbufferObject
	{
		// Token: 0x17000AAD RID: 2733
		// (get) Token: 0x06002D0A RID: 11530 RVA: 0x000A5948 File Offset: 0x000A3D48
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002D0B RID: 11531 RVA: 0x000A5955 File Offset: 0x000A3D55
		public static EquipEnhanceCostTable GetRootAsEquipEnhanceCostTable(ByteBuffer _bb)
		{
			return EquipEnhanceCostTable.GetRootAsEquipEnhanceCostTable(_bb, new EquipEnhanceCostTable());
		}

		// Token: 0x06002D0C RID: 11532 RVA: 0x000A5962 File Offset: 0x000A3D62
		public static EquipEnhanceCostTable GetRootAsEquipEnhanceCostTable(ByteBuffer _bb, EquipEnhanceCostTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002D0D RID: 11533 RVA: 0x000A597E File Offset: 0x000A3D7E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002D0E RID: 11534 RVA: 0x000A5998 File Offset: 0x000A3D98
		public EquipEnhanceCostTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000AAE RID: 2734
		// (get) Token: 0x06002D0F RID: 11535 RVA: 0x000A59A4 File Offset: 0x000A3DA4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-733794697 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AAF RID: 2735
		// (get) Token: 0x06002D10 RID: 11536 RVA: 0x000A59F0 File Offset: 0x000A3DF0
		public int Quality
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-733794697 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AB0 RID: 2736
		// (get) Token: 0x06002D11 RID: 11537 RVA: 0x000A5A3C File Offset: 0x000A3E3C
		public int EnhanceLevel
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-733794697 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AB1 RID: 2737
		// (get) Token: 0x06002D12 RID: 11538 RVA: 0x000A5A88 File Offset: 0x000A3E88
		public int Level
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-733794697 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AB2 RID: 2738
		// (get) Token: 0x06002D13 RID: 11539 RVA: 0x000A5AD4 File Offset: 0x000A3ED4
		public int NeedGold
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-733794697 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AB3 RID: 2739
		// (get) Token: 0x06002D14 RID: 11540 RVA: 0x000A5B20 File Offset: 0x000A3F20
		public int ReturnGold
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-733794697 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AB4 RID: 2740
		// (get) Token: 0x06002D15 RID: 11541 RVA: 0x000A5B6C File Offset: 0x000A3F6C
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-733794697 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AB5 RID: 2741
		// (get) Token: 0x06002D16 RID: 11542 RVA: 0x000A5BB8 File Offset: 0x000A3FB8
		public int ItemNum
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-733794697 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AB6 RID: 2742
		// (get) Token: 0x06002D17 RID: 11543 RVA: 0x000A5C04 File Offset: 0x000A4004
		public int ReturnItemID
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-733794697 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AB7 RID: 2743
		// (get) Token: 0x06002D18 RID: 11544 RVA: 0x000A5C50 File Offset: 0x000A4050
		public string ReturnItemRule
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002D19 RID: 11545 RVA: 0x000A5C93 File Offset: 0x000A4093
		public ArraySegment<byte>? GetReturnItemRuleBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17000AB8 RID: 2744
		// (get) Token: 0x06002D1A RID: 11546 RVA: 0x000A5CA4 File Offset: 0x000A40A4
		public int ReturnItemID2
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-733794697 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AB9 RID: 2745
		// (get) Token: 0x06002D1B RID: 11547 RVA: 0x000A5CF0 File Offset: 0x000A40F0
		public string ReturnItemRule2
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002D1C RID: 11548 RVA: 0x000A5D33 File Offset: 0x000A4133
		public ArraySegment<byte>? GetReturnItemRule2Bytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x06002D1D RID: 11549 RVA: 0x000A5D44 File Offset: 0x000A4144
		public static Offset<EquipEnhanceCostTable> CreateEquipEnhanceCostTable(FlatBufferBuilder builder, int ID = 0, int Quality = 0, int EnhanceLevel = 0, int Level = 0, int NeedGold = 0, int ReturnGold = 0, int ItemID = 0, int ItemNum = 0, int ReturnItemID = 0, StringOffset ReturnItemRuleOffset = default(StringOffset), int ReturnItemID2 = 0, StringOffset ReturnItemRule2Offset = default(StringOffset))
		{
			builder.StartObject(12);
			EquipEnhanceCostTable.AddReturnItemRule2(builder, ReturnItemRule2Offset);
			EquipEnhanceCostTable.AddReturnItemID2(builder, ReturnItemID2);
			EquipEnhanceCostTable.AddReturnItemRule(builder, ReturnItemRuleOffset);
			EquipEnhanceCostTable.AddReturnItemID(builder, ReturnItemID);
			EquipEnhanceCostTable.AddItemNum(builder, ItemNum);
			EquipEnhanceCostTable.AddItemID(builder, ItemID);
			EquipEnhanceCostTable.AddReturnGold(builder, ReturnGold);
			EquipEnhanceCostTable.AddNeedGold(builder, NeedGold);
			EquipEnhanceCostTable.AddLevel(builder, Level);
			EquipEnhanceCostTable.AddEnhanceLevel(builder, EnhanceLevel);
			EquipEnhanceCostTable.AddQuality(builder, Quality);
			EquipEnhanceCostTable.AddID(builder, ID);
			return EquipEnhanceCostTable.EndEquipEnhanceCostTable(builder);
		}

		// Token: 0x06002D1E RID: 11550 RVA: 0x000A5DBC File Offset: 0x000A41BC
		public static void StartEquipEnhanceCostTable(FlatBufferBuilder builder)
		{
			builder.StartObject(12);
		}

		// Token: 0x06002D1F RID: 11551 RVA: 0x000A5DC6 File Offset: 0x000A41C6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002D20 RID: 11552 RVA: 0x000A5DD1 File Offset: 0x000A41D1
		public static void AddQuality(FlatBufferBuilder builder, int Quality)
		{
			builder.AddInt(1, Quality, 0);
		}

		// Token: 0x06002D21 RID: 11553 RVA: 0x000A5DDC File Offset: 0x000A41DC
		public static void AddEnhanceLevel(FlatBufferBuilder builder, int EnhanceLevel)
		{
			builder.AddInt(2, EnhanceLevel, 0);
		}

		// Token: 0x06002D22 RID: 11554 RVA: 0x000A5DE7 File Offset: 0x000A41E7
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(3, Level, 0);
		}

		// Token: 0x06002D23 RID: 11555 RVA: 0x000A5DF2 File Offset: 0x000A41F2
		public static void AddNeedGold(FlatBufferBuilder builder, int NeedGold)
		{
			builder.AddInt(4, NeedGold, 0);
		}

		// Token: 0x06002D24 RID: 11556 RVA: 0x000A5DFD File Offset: 0x000A41FD
		public static void AddReturnGold(FlatBufferBuilder builder, int ReturnGold)
		{
			builder.AddInt(5, ReturnGold, 0);
		}

		// Token: 0x06002D25 RID: 11557 RVA: 0x000A5E08 File Offset: 0x000A4208
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(6, ItemID, 0);
		}

		// Token: 0x06002D26 RID: 11558 RVA: 0x000A5E13 File Offset: 0x000A4213
		public static void AddItemNum(FlatBufferBuilder builder, int ItemNum)
		{
			builder.AddInt(7, ItemNum, 0);
		}

		// Token: 0x06002D27 RID: 11559 RVA: 0x000A5E1E File Offset: 0x000A421E
		public static void AddReturnItemID(FlatBufferBuilder builder, int ReturnItemID)
		{
			builder.AddInt(8, ReturnItemID, 0);
		}

		// Token: 0x06002D28 RID: 11560 RVA: 0x000A5E29 File Offset: 0x000A4229
		public static void AddReturnItemRule(FlatBufferBuilder builder, StringOffset ReturnItemRuleOffset)
		{
			builder.AddOffset(9, ReturnItemRuleOffset.Value, 0);
		}

		// Token: 0x06002D29 RID: 11561 RVA: 0x000A5E3B File Offset: 0x000A423B
		public static void AddReturnItemID2(FlatBufferBuilder builder, int ReturnItemID2)
		{
			builder.AddInt(10, ReturnItemID2, 0);
		}

		// Token: 0x06002D2A RID: 11562 RVA: 0x000A5E47 File Offset: 0x000A4247
		public static void AddReturnItemRule2(FlatBufferBuilder builder, StringOffset ReturnItemRule2Offset)
		{
			builder.AddOffset(11, ReturnItemRule2Offset.Value, 0);
		}

		// Token: 0x06002D2B RID: 11563 RVA: 0x000A5E5C File Offset: 0x000A425C
		public static Offset<EquipEnhanceCostTable> EndEquipEnhanceCostTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipEnhanceCostTable>(value);
		}

		// Token: 0x06002D2C RID: 11564 RVA: 0x000A5E76 File Offset: 0x000A4276
		public static void FinishEquipEnhanceCostTableBuffer(FlatBufferBuilder builder, Offset<EquipEnhanceCostTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001332 RID: 4914
		private Table __p = new Table();

		// Token: 0x020003DE RID: 990
		public enum eCrypt
		{
			// Token: 0x04001334 RID: 4916
			code = -733794697
		}
	}
}
