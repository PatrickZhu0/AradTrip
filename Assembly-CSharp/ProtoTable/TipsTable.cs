using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000604 RID: 1540
	public class TipsTable : IFlatbufferObject
	{
		// Token: 0x17001676 RID: 5750
		// (get) Token: 0x0600515B RID: 20827 RVA: 0x000FA95C File Offset: 0x000F8D5C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600515C RID: 20828 RVA: 0x000FA969 File Offset: 0x000F8D69
		public static TipsTable GetRootAsTipsTable(ByteBuffer _bb)
		{
			return TipsTable.GetRootAsTipsTable(_bb, new TipsTable());
		}

		// Token: 0x0600515D RID: 20829 RVA: 0x000FA976 File Offset: 0x000F8D76
		public static TipsTable GetRootAsTipsTable(ByteBuffer _bb, TipsTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600515E RID: 20830 RVA: 0x000FA992 File Offset: 0x000F8D92
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600515F RID: 20831 RVA: 0x000FA9AC File Offset: 0x000F8DAC
		public TipsTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001677 RID: 5751
		// (get) Token: 0x06005160 RID: 20832 RVA: 0x000FA9B8 File Offset: 0x000F8DB8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (188128128 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001678 RID: 5752
		// (get) Token: 0x06005161 RID: 20833 RVA: 0x000FAA04 File Offset: 0x000F8E04
		public string ObjectName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005162 RID: 20834 RVA: 0x000FAA46 File Offset: 0x000F8E46
		public ArraySegment<byte>? GetObjectNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x06005163 RID: 20835 RVA: 0x000FAA54 File Offset: 0x000F8E54
		public static Offset<TipsTable> CreateTipsTable(FlatBufferBuilder builder, int ID = 0, StringOffset ObjectNameOffset = default(StringOffset))
		{
			builder.StartObject(2);
			TipsTable.AddObjectName(builder, ObjectNameOffset);
			TipsTable.AddID(builder, ID);
			return TipsTable.EndTipsTable(builder);
		}

		// Token: 0x06005164 RID: 20836 RVA: 0x000FAA71 File Offset: 0x000F8E71
		public static void StartTipsTable(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x06005165 RID: 20837 RVA: 0x000FAA7A File Offset: 0x000F8E7A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06005166 RID: 20838 RVA: 0x000FAA85 File Offset: 0x000F8E85
		public static void AddObjectName(FlatBufferBuilder builder, StringOffset ObjectNameOffset)
		{
			builder.AddOffset(1, ObjectNameOffset.Value, 0);
		}

		// Token: 0x06005167 RID: 20839 RVA: 0x000FAA98 File Offset: 0x000F8E98
		public static Offset<TipsTable> EndTipsTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<TipsTable>(value);
		}

		// Token: 0x06005168 RID: 20840 RVA: 0x000FAAB2 File Offset: 0x000F8EB2
		public static void FinishTipsTableBuffer(FlatBufferBuilder builder, Offset<TipsTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001E0F RID: 7695
		private Table __p = new Table();

		// Token: 0x02000605 RID: 1541
		public enum eCrypt
		{
			// Token: 0x04001E11 RID: 7697
			code = 188128128
		}
	}
}
