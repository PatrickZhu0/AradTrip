using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000336 RID: 822
	public class ChiJiSwitchTable : IFlatbufferObject
	{
		// Token: 0x1700067B RID: 1659
		// (get) Token: 0x0600211F RID: 8479 RVA: 0x00087F98 File Offset: 0x00086398
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002120 RID: 8480 RVA: 0x00087FA5 File Offset: 0x000863A5
		public static ChiJiSwitchTable GetRootAsChiJiSwitchTable(ByteBuffer _bb)
		{
			return ChiJiSwitchTable.GetRootAsChiJiSwitchTable(_bb, new ChiJiSwitchTable());
		}

		// Token: 0x06002121 RID: 8481 RVA: 0x00087FB2 File Offset: 0x000863B2
		public static ChiJiSwitchTable GetRootAsChiJiSwitchTable(ByteBuffer _bb, ChiJiSwitchTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002122 RID: 8482 RVA: 0x00087FCE File Offset: 0x000863CE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002123 RID: 8483 RVA: 0x00087FE8 File Offset: 0x000863E8
		public ChiJiSwitchTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700067C RID: 1660
		// (get) Token: 0x06002124 RID: 8484 RVA: 0x00087FF4 File Offset: 0x000863F4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1802735813 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700067D RID: 1661
		// (get) Token: 0x06002125 RID: 8485 RVA: 0x00088040 File Offset: 0x00086440
		public string OpenTime
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002126 RID: 8486 RVA: 0x00088082 File Offset: 0x00086482
		public ArraySegment<byte>? GetOpenTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700067E RID: 1662
		// (get) Token: 0x06002127 RID: 8487 RVA: 0x00088090 File Offset: 0x00086490
		public string CloseTime
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002128 RID: 8488 RVA: 0x000880D2 File Offset: 0x000864D2
		public ArraySegment<byte>? GetCloseTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700067F RID: 1663
		// (get) Token: 0x06002129 RID: 8489 RVA: 0x000880E0 File Offset: 0x000864E0
		public int IsOpen
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1802735813 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600212A RID: 8490 RVA: 0x0008812A File Offset: 0x0008652A
		public static Offset<ChiJiSwitchTable> CreateChiJiSwitchTable(FlatBufferBuilder builder, int ID = 0, StringOffset OpenTimeOffset = default(StringOffset), StringOffset CloseTimeOffset = default(StringOffset), int IsOpen = 0)
		{
			builder.StartObject(4);
			ChiJiSwitchTable.AddIsOpen(builder, IsOpen);
			ChiJiSwitchTable.AddCloseTime(builder, CloseTimeOffset);
			ChiJiSwitchTable.AddOpenTime(builder, OpenTimeOffset);
			ChiJiSwitchTable.AddID(builder, ID);
			return ChiJiSwitchTable.EndChiJiSwitchTable(builder);
		}

		// Token: 0x0600212B RID: 8491 RVA: 0x00088156 File Offset: 0x00086556
		public static void StartChiJiSwitchTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x0600212C RID: 8492 RVA: 0x0008815F File Offset: 0x0008655F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600212D RID: 8493 RVA: 0x0008816A File Offset: 0x0008656A
		public static void AddOpenTime(FlatBufferBuilder builder, StringOffset OpenTimeOffset)
		{
			builder.AddOffset(1, OpenTimeOffset.Value, 0);
		}

		// Token: 0x0600212E RID: 8494 RVA: 0x0008817B File Offset: 0x0008657B
		public static void AddCloseTime(FlatBufferBuilder builder, StringOffset CloseTimeOffset)
		{
			builder.AddOffset(2, CloseTimeOffset.Value, 0);
		}

		// Token: 0x0600212F RID: 8495 RVA: 0x0008818C File Offset: 0x0008658C
		public static void AddIsOpen(FlatBufferBuilder builder, int IsOpen)
		{
			builder.AddInt(3, IsOpen, 0);
		}

		// Token: 0x06002130 RID: 8496 RVA: 0x00088198 File Offset: 0x00086598
		public static Offset<ChiJiSwitchTable> EndChiJiSwitchTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChiJiSwitchTable>(value);
		}

		// Token: 0x06002131 RID: 8497 RVA: 0x000881B2 File Offset: 0x000865B2
		public static void FinishChiJiSwitchTableBuffer(FlatBufferBuilder builder, Offset<ChiJiSwitchTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000FE3 RID: 4067
		private Table __p = new Table();

		// Token: 0x02000337 RID: 823
		public enum eCrypt
		{
			// Token: 0x04000FE5 RID: 4069
			code = 1802735813
		}
	}
}
