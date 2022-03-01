using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200048C RID: 1164
	public class HeadFrameCompensateTable : IFlatbufferObject
	{
		// Token: 0x17000E43 RID: 3651
		// (get) Token: 0x06003885 RID: 14469 RVA: 0x000C0534 File Offset: 0x000BE934
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003886 RID: 14470 RVA: 0x000C0541 File Offset: 0x000BE941
		public static HeadFrameCompensateTable GetRootAsHeadFrameCompensateTable(ByteBuffer _bb)
		{
			return HeadFrameCompensateTable.GetRootAsHeadFrameCompensateTable(_bb, new HeadFrameCompensateTable());
		}

		// Token: 0x06003887 RID: 14471 RVA: 0x000C054E File Offset: 0x000BE94E
		public static HeadFrameCompensateTable GetRootAsHeadFrameCompensateTable(ByteBuffer _bb, HeadFrameCompensateTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003888 RID: 14472 RVA: 0x000C056A File Offset: 0x000BE96A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003889 RID: 14473 RVA: 0x000C0584 File Offset: 0x000BE984
		public HeadFrameCompensateTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000E44 RID: 3652
		// (get) Token: 0x0600388A RID: 14474 RVA: 0x000C0590 File Offset: 0x000BE990
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (502817246 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E45 RID: 3653
		// (get) Token: 0x0600388B RID: 14475 RVA: 0x000C05DC File Offset: 0x000BE9DC
		public int Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (502817246 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E46 RID: 3654
		// (get) Token: 0x0600388C RID: 14476 RVA: 0x000C0628 File Offset: 0x000BEA28
		public int NeedVal
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (502817246 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E47 RID: 3655
		// (get) Token: 0x0600388D RID: 14477 RVA: 0x000C0674 File Offset: 0x000BEA74
		public int HeadFrameId
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (502817246 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600388E RID: 14478 RVA: 0x000C06BE File Offset: 0x000BEABE
		public static Offset<HeadFrameCompensateTable> CreateHeadFrameCompensateTable(FlatBufferBuilder builder, int ID = 0, int Type = 0, int NeedVal = 0, int HeadFrameId = 0)
		{
			builder.StartObject(4);
			HeadFrameCompensateTable.AddHeadFrameId(builder, HeadFrameId);
			HeadFrameCompensateTable.AddNeedVal(builder, NeedVal);
			HeadFrameCompensateTable.AddType(builder, Type);
			HeadFrameCompensateTable.AddID(builder, ID);
			return HeadFrameCompensateTable.EndHeadFrameCompensateTable(builder);
		}

		// Token: 0x0600388F RID: 14479 RVA: 0x000C06EA File Offset: 0x000BEAEA
		public static void StartHeadFrameCompensateTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06003890 RID: 14480 RVA: 0x000C06F3 File Offset: 0x000BEAF3
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003891 RID: 14481 RVA: 0x000C06FE File Offset: 0x000BEAFE
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(1, Type, 0);
		}

		// Token: 0x06003892 RID: 14482 RVA: 0x000C0709 File Offset: 0x000BEB09
		public static void AddNeedVal(FlatBufferBuilder builder, int NeedVal)
		{
			builder.AddInt(2, NeedVal, 0);
		}

		// Token: 0x06003893 RID: 14483 RVA: 0x000C0714 File Offset: 0x000BEB14
		public static void AddHeadFrameId(FlatBufferBuilder builder, int HeadFrameId)
		{
			builder.AddInt(3, HeadFrameId, 0);
		}

		// Token: 0x06003894 RID: 14484 RVA: 0x000C0720 File Offset: 0x000BEB20
		public static Offset<HeadFrameCompensateTable> EndHeadFrameCompensateTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<HeadFrameCompensateTable>(value);
		}

		// Token: 0x06003895 RID: 14485 RVA: 0x000C073A File Offset: 0x000BEB3A
		public static void FinishHeadFrameCompensateTableBuffer(FlatBufferBuilder builder, Offset<HeadFrameCompensateTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001608 RID: 5640
		private Table __p = new Table();

		// Token: 0x0200048D RID: 1165
		public enum eCrypt
		{
			// Token: 0x0400160A RID: 5642
			code = 502817246
		}
	}
}
