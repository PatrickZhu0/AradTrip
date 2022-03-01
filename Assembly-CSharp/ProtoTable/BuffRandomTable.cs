using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002F1 RID: 753
	public class BuffRandomTable : IFlatbufferObject
	{
		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x06001BF3 RID: 7155 RVA: 0x0007B5F0 File Offset: 0x000799F0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001BF4 RID: 7156 RVA: 0x0007B5FD File Offset: 0x000799FD
		public static BuffRandomTable GetRootAsBuffRandomTable(ByteBuffer _bb)
		{
			return BuffRandomTable.GetRootAsBuffRandomTable(_bb, new BuffRandomTable());
		}

		// Token: 0x06001BF5 RID: 7157 RVA: 0x0007B60A File Offset: 0x00079A0A
		public static BuffRandomTable GetRootAsBuffRandomTable(ByteBuffer _bb, BuffRandomTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001BF6 RID: 7158 RVA: 0x0007B626 File Offset: 0x00079A26
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001BF7 RID: 7159 RVA: 0x0007B640 File Offset: 0x00079A40
		public BuffRandomTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x06001BF8 RID: 7160 RVA: 0x0007B64C File Offset: 0x00079A4C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (2130836854 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06001BF9 RID: 7161 RVA: 0x0007B698 File Offset: 0x00079A98
		public int BuffId
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (2130836854 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06001BFA RID: 7162 RVA: 0x0007B6E4 File Offset: 0x00079AE4
		public int Weight
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (2130836854 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001BFB RID: 7163 RVA: 0x0007B72D File Offset: 0x00079B2D
		public static Offset<BuffRandomTable> CreateBuffRandomTable(FlatBufferBuilder builder, int ID = 0, int BuffId = 0, int Weight = 0)
		{
			builder.StartObject(3);
			BuffRandomTable.AddWeight(builder, Weight);
			BuffRandomTable.AddBuffId(builder, BuffId);
			BuffRandomTable.AddID(builder, ID);
			return BuffRandomTable.EndBuffRandomTable(builder);
		}

		// Token: 0x06001BFC RID: 7164 RVA: 0x0007B751 File Offset: 0x00079B51
		public static void StartBuffRandomTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06001BFD RID: 7165 RVA: 0x0007B75A File Offset: 0x00079B5A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001BFE RID: 7166 RVA: 0x0007B765 File Offset: 0x00079B65
		public static void AddBuffId(FlatBufferBuilder builder, int BuffId)
		{
			builder.AddInt(1, BuffId, 0);
		}

		// Token: 0x06001BFF RID: 7167 RVA: 0x0007B770 File Offset: 0x00079B70
		public static void AddWeight(FlatBufferBuilder builder, int Weight)
		{
			builder.AddInt(2, Weight, 0);
		}

		// Token: 0x06001C00 RID: 7168 RVA: 0x0007B77C File Offset: 0x00079B7C
		public static Offset<BuffRandomTable> EndBuffRandomTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BuffRandomTable>(value);
		}

		// Token: 0x06001C01 RID: 7169 RVA: 0x0007B796 File Offset: 0x00079B96
		public static void FinishBuffRandomTableBuffer(FlatBufferBuilder builder, Offset<BuffRandomTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000EDE RID: 3806
		private Table __p = new Table();

		// Token: 0x020002F2 RID: 754
		public enum eCrypt
		{
			// Token: 0x04000EE0 RID: 3808
			code = 2130836854
		}
	}
}
