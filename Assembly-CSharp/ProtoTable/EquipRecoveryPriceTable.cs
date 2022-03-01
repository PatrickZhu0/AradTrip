using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000401 RID: 1025
	public class EquipRecoveryPriceTable : IFlatbufferObject
	{
		// Token: 0x17000B55 RID: 2901
		// (get) Token: 0x06002F39 RID: 12089 RVA: 0x000AAA7C File Offset: 0x000A8E7C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002F3A RID: 12090 RVA: 0x000AAA89 File Offset: 0x000A8E89
		public static EquipRecoveryPriceTable GetRootAsEquipRecoveryPriceTable(ByteBuffer _bb)
		{
			return EquipRecoveryPriceTable.GetRootAsEquipRecoveryPriceTable(_bb, new EquipRecoveryPriceTable());
		}

		// Token: 0x06002F3B RID: 12091 RVA: 0x000AAA96 File Offset: 0x000A8E96
		public static EquipRecoveryPriceTable GetRootAsEquipRecoveryPriceTable(ByteBuffer _bb, EquipRecoveryPriceTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002F3C RID: 12092 RVA: 0x000AAAB2 File Offset: 0x000A8EB2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002F3D RID: 12093 RVA: 0x000AAACC File Offset: 0x000A8ECC
		public EquipRecoveryPriceTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000B56 RID: 2902
		// (get) Token: 0x06002F3E RID: 12094 RVA: 0x000AAAD8 File Offset: 0x000A8ED8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-979817284 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B57 RID: 2903
		// (get) Token: 0x06002F3F RID: 12095 RVA: 0x000AAB24 File Offset: 0x000A8F24
		public string Blue
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002F40 RID: 12096 RVA: 0x000AAB66 File Offset: 0x000A8F66
		public ArraySegment<byte>? GetBlueBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000B58 RID: 2904
		// (get) Token: 0x06002F41 RID: 12097 RVA: 0x000AAB74 File Offset: 0x000A8F74
		public string Purple
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002F42 RID: 12098 RVA: 0x000AABB6 File Offset: 0x000A8FB6
		public ArraySegment<byte>? GetPurpleBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000B59 RID: 2905
		// (get) Token: 0x06002F43 RID: 12099 RVA: 0x000AABC4 File Offset: 0x000A8FC4
		public string Pink
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002F44 RID: 12100 RVA: 0x000AAC07 File Offset: 0x000A9007
		public ArraySegment<byte>? GetPinkBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x06002F45 RID: 12101 RVA: 0x000AAC16 File Offset: 0x000A9016
		public static Offset<EquipRecoveryPriceTable> CreateEquipRecoveryPriceTable(FlatBufferBuilder builder, int ID = 0, StringOffset BlueOffset = default(StringOffset), StringOffset PurpleOffset = default(StringOffset), StringOffset PinkOffset = default(StringOffset))
		{
			builder.StartObject(4);
			EquipRecoveryPriceTable.AddPink(builder, PinkOffset);
			EquipRecoveryPriceTable.AddPurple(builder, PurpleOffset);
			EquipRecoveryPriceTable.AddBlue(builder, BlueOffset);
			EquipRecoveryPriceTable.AddID(builder, ID);
			return EquipRecoveryPriceTable.EndEquipRecoveryPriceTable(builder);
		}

		// Token: 0x06002F46 RID: 12102 RVA: 0x000AAC42 File Offset: 0x000A9042
		public static void StartEquipRecoveryPriceTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06002F47 RID: 12103 RVA: 0x000AAC4B File Offset: 0x000A904B
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002F48 RID: 12104 RVA: 0x000AAC56 File Offset: 0x000A9056
		public static void AddBlue(FlatBufferBuilder builder, StringOffset BlueOffset)
		{
			builder.AddOffset(1, BlueOffset.Value, 0);
		}

		// Token: 0x06002F49 RID: 12105 RVA: 0x000AAC67 File Offset: 0x000A9067
		public static void AddPurple(FlatBufferBuilder builder, StringOffset PurpleOffset)
		{
			builder.AddOffset(2, PurpleOffset.Value, 0);
		}

		// Token: 0x06002F4A RID: 12106 RVA: 0x000AAC78 File Offset: 0x000A9078
		public static void AddPink(FlatBufferBuilder builder, StringOffset PinkOffset)
		{
			builder.AddOffset(3, PinkOffset.Value, 0);
		}

		// Token: 0x06002F4B RID: 12107 RVA: 0x000AAC8C File Offset: 0x000A908C
		public static Offset<EquipRecoveryPriceTable> EndEquipRecoveryPriceTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipRecoveryPriceTable>(value);
		}

		// Token: 0x06002F4C RID: 12108 RVA: 0x000AACA6 File Offset: 0x000A90A6
		public static void FinishEquipRecoveryPriceTableBuffer(FlatBufferBuilder builder, Offset<EquipRecoveryPriceTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040013B6 RID: 5046
		private Table __p = new Table();

		// Token: 0x02000402 RID: 1026
		public enum eCrypt
		{
			// Token: 0x040013B8 RID: 5048
			code = -979817284
		}
	}
}
