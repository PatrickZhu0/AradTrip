using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000307 RID: 775
	public class ChangeFashionActiveMergeTable : IFlatbufferObject
	{
		// Token: 0x170005B3 RID: 1459
		// (get) Token: 0x06001E8F RID: 7823 RVA: 0x00082488 File Offset: 0x00080888
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001E90 RID: 7824 RVA: 0x00082495 File Offset: 0x00080895
		public static ChangeFashionActiveMergeTable GetRootAsChangeFashionActiveMergeTable(ByteBuffer _bb)
		{
			return ChangeFashionActiveMergeTable.GetRootAsChangeFashionActiveMergeTable(_bb, new ChangeFashionActiveMergeTable());
		}

		// Token: 0x06001E91 RID: 7825 RVA: 0x000824A2 File Offset: 0x000808A2
		public static ChangeFashionActiveMergeTable GetRootAsChangeFashionActiveMergeTable(ByteBuffer _bb, ChangeFashionActiveMergeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001E92 RID: 7826 RVA: 0x000824BE File Offset: 0x000808BE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001E93 RID: 7827 RVA: 0x000824D8 File Offset: 0x000808D8
		public ChangeFashionActiveMergeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170005B4 RID: 1460
		// (get) Token: 0x06001E94 RID: 7828 RVA: 0x000824E4 File Offset: 0x000808E4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1144610400 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005B5 RID: 1461
		// (get) Token: 0x06001E95 RID: 7829 RVA: 0x00082530 File Offset: 0x00080930
		public int AdvanceId
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1144610400 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005B6 RID: 1462
		// (get) Token: 0x06001E96 RID: 7830 RVA: 0x0008257C File Offset: 0x0008097C
		public int Prob
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1144610400 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005B7 RID: 1463
		// (get) Token: 0x06001E97 RID: 7831 RVA: 0x000825C8 File Offset: 0x000809C8
		public string GoldConsume
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E98 RID: 7832 RVA: 0x0008260B File Offset: 0x00080A0B
		public ArraySegment<byte>? GetGoldConsumeBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170005B8 RID: 1464
		// (get) Token: 0x06001E99 RID: 7833 RVA: 0x0008261C File Offset: 0x00080A1C
		public string TicketConsume
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E9A RID: 7834 RVA: 0x0008265F File Offset: 0x00080A5F
		public ArraySegment<byte>? GetTicketConsumeBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x06001E9B RID: 7835 RVA: 0x0008266E File Offset: 0x00080A6E
		public static Offset<ChangeFashionActiveMergeTable> CreateChangeFashionActiveMergeTable(FlatBufferBuilder builder, int ID = 0, int AdvanceId = 0, int Prob = 0, StringOffset GoldConsumeOffset = default(StringOffset), StringOffset TicketConsumeOffset = default(StringOffset))
		{
			builder.StartObject(5);
			ChangeFashionActiveMergeTable.AddTicketConsume(builder, TicketConsumeOffset);
			ChangeFashionActiveMergeTable.AddGoldConsume(builder, GoldConsumeOffset);
			ChangeFashionActiveMergeTable.AddProb(builder, Prob);
			ChangeFashionActiveMergeTable.AddAdvanceId(builder, AdvanceId);
			ChangeFashionActiveMergeTable.AddID(builder, ID);
			return ChangeFashionActiveMergeTable.EndChangeFashionActiveMergeTable(builder);
		}

		// Token: 0x06001E9C RID: 7836 RVA: 0x000826A2 File Offset: 0x00080AA2
		public static void StartChangeFashionActiveMergeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06001E9D RID: 7837 RVA: 0x000826AB File Offset: 0x00080AAB
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001E9E RID: 7838 RVA: 0x000826B6 File Offset: 0x00080AB6
		public static void AddAdvanceId(FlatBufferBuilder builder, int AdvanceId)
		{
			builder.AddInt(1, AdvanceId, 0);
		}

		// Token: 0x06001E9F RID: 7839 RVA: 0x000826C1 File Offset: 0x00080AC1
		public static void AddProb(FlatBufferBuilder builder, int Prob)
		{
			builder.AddInt(2, Prob, 0);
		}

		// Token: 0x06001EA0 RID: 7840 RVA: 0x000826CC File Offset: 0x00080ACC
		public static void AddGoldConsume(FlatBufferBuilder builder, StringOffset GoldConsumeOffset)
		{
			builder.AddOffset(3, GoldConsumeOffset.Value, 0);
		}

		// Token: 0x06001EA1 RID: 7841 RVA: 0x000826DD File Offset: 0x00080ADD
		public static void AddTicketConsume(FlatBufferBuilder builder, StringOffset TicketConsumeOffset)
		{
			builder.AddOffset(4, TicketConsumeOffset.Value, 0);
		}

		// Token: 0x06001EA2 RID: 7842 RVA: 0x000826F0 File Offset: 0x00080AF0
		public static Offset<ChangeFashionActiveMergeTable> EndChangeFashionActiveMergeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChangeFashionActiveMergeTable>(value);
		}

		// Token: 0x06001EA3 RID: 7843 RVA: 0x0008270A File Offset: 0x00080B0A
		public static void FinishChangeFashionActiveMergeTableBuffer(FlatBufferBuilder builder, Offset<ChangeFashionActiveMergeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F3F RID: 3903
		private Table __p = new Table();

		// Token: 0x02000308 RID: 776
		public enum eCrypt
		{
			// Token: 0x04000F41 RID: 3905
			code = 1144610400
		}
	}
}
