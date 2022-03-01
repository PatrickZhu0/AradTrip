using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002EB RID: 747
	public class BuffDrugConfigTable : IFlatbufferObject
	{
		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x06001B77 RID: 7031 RVA: 0x0007A1E0 File Offset: 0x000785E0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001B78 RID: 7032 RVA: 0x0007A1ED File Offset: 0x000785ED
		public static BuffDrugConfigTable GetRootAsBuffDrugConfigTable(ByteBuffer _bb)
		{
			return BuffDrugConfigTable.GetRootAsBuffDrugConfigTable(_bb, new BuffDrugConfigTable());
		}

		// Token: 0x06001B79 RID: 7033 RVA: 0x0007A1FA File Offset: 0x000785FA
		public static BuffDrugConfigTable GetRootAsBuffDrugConfigTable(ByteBuffer _bb, BuffDrugConfigTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001B7A RID: 7034 RVA: 0x0007A216 File Offset: 0x00078616
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001B7B RID: 7035 RVA: 0x0007A230 File Offset: 0x00078630
		public BuffDrugConfigTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x06001B7C RID: 7036 RVA: 0x0007A23C File Offset: 0x0007863C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1664964467 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06001B7D RID: 7037 RVA: 0x0007A288 File Offset: 0x00078688
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B7E RID: 7038 RVA: 0x0007A2CA File Offset: 0x000786CA
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x06001B7F RID: 7039 RVA: 0x0007A2D8 File Offset: 0x000786D8
		public string Description
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B80 RID: 7040 RVA: 0x0007A31A File Offset: 0x0007871A
		public ArraySegment<byte>? GetDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x06001B81 RID: 7041 RVA: 0x0007A328 File Offset: 0x00078728
		public int FreeUseLevel
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1664964467 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001B82 RID: 7042 RVA: 0x0007A372 File Offset: 0x00078772
		public static Offset<BuffDrugConfigTable> CreateBuffDrugConfigTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset DescriptionOffset = default(StringOffset), int FreeUseLevel = 0)
		{
			builder.StartObject(4);
			BuffDrugConfigTable.AddFreeUseLevel(builder, FreeUseLevel);
			BuffDrugConfigTable.AddDescription(builder, DescriptionOffset);
			BuffDrugConfigTable.AddName(builder, NameOffset);
			BuffDrugConfigTable.AddID(builder, ID);
			return BuffDrugConfigTable.EndBuffDrugConfigTable(builder);
		}

		// Token: 0x06001B83 RID: 7043 RVA: 0x0007A39E File Offset: 0x0007879E
		public static void StartBuffDrugConfigTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06001B84 RID: 7044 RVA: 0x0007A3A7 File Offset: 0x000787A7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001B85 RID: 7045 RVA: 0x0007A3B2 File Offset: 0x000787B2
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06001B86 RID: 7046 RVA: 0x0007A3C3 File Offset: 0x000787C3
		public static void AddDescription(FlatBufferBuilder builder, StringOffset DescriptionOffset)
		{
			builder.AddOffset(2, DescriptionOffset.Value, 0);
		}

		// Token: 0x06001B87 RID: 7047 RVA: 0x0007A3D4 File Offset: 0x000787D4
		public static void AddFreeUseLevel(FlatBufferBuilder builder, int FreeUseLevel)
		{
			builder.AddInt(3, FreeUseLevel, 0);
		}

		// Token: 0x06001B88 RID: 7048 RVA: 0x0007A3E0 File Offset: 0x000787E0
		public static Offset<BuffDrugConfigTable> EndBuffDrugConfigTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BuffDrugConfigTable>(value);
		}

		// Token: 0x06001B89 RID: 7049 RVA: 0x0007A3FA File Offset: 0x000787FA
		public static void FinishBuffDrugConfigTableBuffer(FlatBufferBuilder builder, Offset<BuffDrugConfigTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000ECB RID: 3787
		private Table __p = new Table();

		// Token: 0x020002EC RID: 748
		public enum eCrypt
		{
			// Token: 0x04000ECD RID: 3789
			code = 1664964467
		}
	}
}
