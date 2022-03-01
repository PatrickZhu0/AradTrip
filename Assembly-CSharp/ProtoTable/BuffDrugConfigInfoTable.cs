using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002E8 RID: 744
	public class BuffDrugConfigInfoTable : IFlatbufferObject
	{
		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x06001B66 RID: 7014 RVA: 0x0007A014 File Offset: 0x00078414
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001B67 RID: 7015 RVA: 0x0007A021 File Offset: 0x00078421
		public static BuffDrugConfigInfoTable GetRootAsBuffDrugConfigInfoTable(ByteBuffer _bb)
		{
			return BuffDrugConfigInfoTable.GetRootAsBuffDrugConfigInfoTable(_bb, new BuffDrugConfigInfoTable());
		}

		// Token: 0x06001B68 RID: 7016 RVA: 0x0007A02E File Offset: 0x0007842E
		public static BuffDrugConfigInfoTable GetRootAsBuffDrugConfigInfoTable(ByteBuffer _bb, BuffDrugConfigInfoTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001B69 RID: 7017 RVA: 0x0007A04A File Offset: 0x0007844A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001B6A RID: 7018 RVA: 0x0007A064 File Offset: 0x00078464
		public BuffDrugConfigInfoTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x06001B6B RID: 7019 RVA: 0x0007A070 File Offset: 0x00078470
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1618238745 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x06001B6C RID: 7020 RVA: 0x0007A0BC File Offset: 0x000784BC
		public string Filed
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B6D RID: 7021 RVA: 0x0007A0FE File Offset: 0x000784FE
		public ArraySegment<byte>? GetFiledBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x06001B6E RID: 7022 RVA: 0x0007A10C File Offset: 0x0007850C
		public BuffDrugConfigInfoTable.eValueType ValueType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (BuffDrugConfigInfoTable.eValueType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001B6F RID: 7023 RVA: 0x0007A14F File Offset: 0x0007854F
		public static Offset<BuffDrugConfigInfoTable> CreateBuffDrugConfigInfoTable(FlatBufferBuilder builder, int ID = 0, StringOffset FiledOffset = default(StringOffset), BuffDrugConfigInfoTable.eValueType ValueType = BuffDrugConfigInfoTable.eValueType.Value)
		{
			builder.StartObject(3);
			BuffDrugConfigInfoTable.AddValueType(builder, ValueType);
			BuffDrugConfigInfoTable.AddFiled(builder, FiledOffset);
			BuffDrugConfigInfoTable.AddID(builder, ID);
			return BuffDrugConfigInfoTable.EndBuffDrugConfigInfoTable(builder);
		}

		// Token: 0x06001B70 RID: 7024 RVA: 0x0007A173 File Offset: 0x00078573
		public static void StartBuffDrugConfigInfoTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06001B71 RID: 7025 RVA: 0x0007A17C File Offset: 0x0007857C
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001B72 RID: 7026 RVA: 0x0007A187 File Offset: 0x00078587
		public static void AddFiled(FlatBufferBuilder builder, StringOffset FiledOffset)
		{
			builder.AddOffset(1, FiledOffset.Value, 0);
		}

		// Token: 0x06001B73 RID: 7027 RVA: 0x0007A198 File Offset: 0x00078598
		public static void AddValueType(FlatBufferBuilder builder, BuffDrugConfigInfoTable.eValueType ValueType)
		{
			builder.AddInt(2, (int)ValueType, 0);
		}

		// Token: 0x06001B74 RID: 7028 RVA: 0x0007A1A4 File Offset: 0x000785A4
		public static Offset<BuffDrugConfigInfoTable> EndBuffDrugConfigInfoTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BuffDrugConfigInfoTable>(value);
		}

		// Token: 0x06001B75 RID: 7029 RVA: 0x0007A1BE File Offset: 0x000785BE
		public static void FinishBuffDrugConfigInfoTableBuffer(FlatBufferBuilder builder, Offset<BuffDrugConfigInfoTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000EC4 RID: 3780
		private Table __p = new Table();

		// Token: 0x020002E9 RID: 745
		public enum eValueType
		{
			// Token: 0x04000EC6 RID: 3782
			Value,
			// Token: 0x04000EC7 RID: 3783
			Rate100,
			// Token: 0x04000EC8 RID: 3784
			Rate1000
		}

		// Token: 0x020002EA RID: 746
		public enum eCrypt
		{
			// Token: 0x04000ECA RID: 3786
			code = 1618238745
		}
	}
}
