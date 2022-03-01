using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000453 RID: 1107
	public class GuidanceEntranceTable : IFlatbufferObject
	{
		// Token: 0x17000D46 RID: 3398
		// (get) Token: 0x06003545 RID: 13637 RVA: 0x000B9170 File Offset: 0x000B7570
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003546 RID: 13638 RVA: 0x000B917D File Offset: 0x000B757D
		public static GuidanceEntranceTable GetRootAsGuidanceEntranceTable(ByteBuffer _bb)
		{
			return GuidanceEntranceTable.GetRootAsGuidanceEntranceTable(_bb, new GuidanceEntranceTable());
		}

		// Token: 0x06003547 RID: 13639 RVA: 0x000B918A File Offset: 0x000B758A
		public static GuidanceEntranceTable GetRootAsGuidanceEntranceTable(ByteBuffer _bb, GuidanceEntranceTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003548 RID: 13640 RVA: 0x000B91A6 File Offset: 0x000B75A6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003549 RID: 13641 RVA: 0x000B91C0 File Offset: 0x000B75C0
		public GuidanceEntranceTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000D47 RID: 3399
		// (get) Token: 0x0600354A RID: 13642 RVA: 0x000B91CC File Offset: 0x000B75CC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (477889616 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D48 RID: 3400
		// (get) Token: 0x0600354B RID: 13643 RVA: 0x000B9218 File Offset: 0x000B7618
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600354C RID: 13644 RVA: 0x000B925A File Offset: 0x000B765A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000D49 RID: 3401
		// (get) Token: 0x0600354D RID: 13645 RVA: 0x000B9268 File Offset: 0x000B7668
		public int FunctionId
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (477889616 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D4A RID: 3402
		// (get) Token: 0x0600354E RID: 13646 RVA: 0x000B92B4 File Offset: 0x000B76B4
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600354F RID: 13647 RVA: 0x000B92F7 File Offset: 0x000B76F7
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000D4B RID: 3403
		// (get) Token: 0x06003550 RID: 13648 RVA: 0x000B9308 File Offset: 0x000B7708
		public string LinkInfo
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003551 RID: 13649 RVA: 0x000B934B File Offset: 0x000B774B
		public ArraySegment<byte>? GetLinkInfoBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x06003552 RID: 13650 RVA: 0x000B935A File Offset: 0x000B775A
		public static Offset<GuidanceEntranceTable> CreateGuidanceEntranceTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int FunctionId = 0, StringOffset IconOffset = default(StringOffset), StringOffset LinkInfoOffset = default(StringOffset))
		{
			builder.StartObject(5);
			GuidanceEntranceTable.AddLinkInfo(builder, LinkInfoOffset);
			GuidanceEntranceTable.AddIcon(builder, IconOffset);
			GuidanceEntranceTable.AddFunctionId(builder, FunctionId);
			GuidanceEntranceTable.AddName(builder, NameOffset);
			GuidanceEntranceTable.AddID(builder, ID);
			return GuidanceEntranceTable.EndGuidanceEntranceTable(builder);
		}

		// Token: 0x06003553 RID: 13651 RVA: 0x000B938E File Offset: 0x000B778E
		public static void StartGuidanceEntranceTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06003554 RID: 13652 RVA: 0x000B9397 File Offset: 0x000B7797
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003555 RID: 13653 RVA: 0x000B93A2 File Offset: 0x000B77A2
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06003556 RID: 13654 RVA: 0x000B93B3 File Offset: 0x000B77B3
		public static void AddFunctionId(FlatBufferBuilder builder, int FunctionId)
		{
			builder.AddInt(2, FunctionId, 0);
		}

		// Token: 0x06003557 RID: 13655 RVA: 0x000B93BE File Offset: 0x000B77BE
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(3, IconOffset.Value, 0);
		}

		// Token: 0x06003558 RID: 13656 RVA: 0x000B93CF File Offset: 0x000B77CF
		public static void AddLinkInfo(FlatBufferBuilder builder, StringOffset LinkInfoOffset)
		{
			builder.AddOffset(4, LinkInfoOffset.Value, 0);
		}

		// Token: 0x06003559 RID: 13657 RVA: 0x000B93E0 File Offset: 0x000B77E0
		public static Offset<GuidanceEntranceTable> EndGuidanceEntranceTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuidanceEntranceTable>(value);
		}

		// Token: 0x0600355A RID: 13658 RVA: 0x000B93FA File Offset: 0x000B77FA
		public static void FinishGuidanceEntranceTableBuffer(FlatBufferBuilder builder, Offset<GuidanceEntranceTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001586 RID: 5510
		private Table __p = new Table();

		// Token: 0x02000454 RID: 1108
		public enum eCrypt
		{
			// Token: 0x04001588 RID: 5512
			code = 477889616
		}
	}
}
