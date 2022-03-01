using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003B6 RID: 950
	public class DungeonVerifyProbTable : IFlatbufferObject
	{
		// Token: 0x170009BF RID: 2495
		// (get) Token: 0x06002A79 RID: 10873 RVA: 0x0009F1A4 File Offset: 0x0009D5A4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002A7A RID: 10874 RVA: 0x0009F1B1 File Offset: 0x0009D5B1
		public static DungeonVerifyProbTable GetRootAsDungeonVerifyProbTable(ByteBuffer _bb)
		{
			return DungeonVerifyProbTable.GetRootAsDungeonVerifyProbTable(_bb, new DungeonVerifyProbTable());
		}

		// Token: 0x06002A7B RID: 10875 RVA: 0x0009F1BE File Offset: 0x0009D5BE
		public static DungeonVerifyProbTable GetRootAsDungeonVerifyProbTable(ByteBuffer _bb, DungeonVerifyProbTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002A7C RID: 10876 RVA: 0x0009F1DA File Offset: 0x0009D5DA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002A7D RID: 10877 RVA: 0x0009F1F4 File Offset: 0x0009D5F4
		public DungeonVerifyProbTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170009C0 RID: 2496
		// (get) Token: 0x06002A7E RID: 10878 RVA: 0x0009F200 File Offset: 0x0009D600
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-247309266 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009C1 RID: 2497
		// (get) Token: 0x06002A7F RID: 10879 RVA: 0x0009F24C File Offset: 0x0009D64C
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002A80 RID: 10880 RVA: 0x0009F28E File Offset: 0x0009D68E
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170009C2 RID: 2498
		// (get) Token: 0x06002A81 RID: 10881 RVA: 0x0009F29C File Offset: 0x0009D69C
		public string Oldname
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002A82 RID: 10882 RVA: 0x0009F2DE File Offset: 0x0009D6DE
		public ArraySegment<byte>? GetOldnameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170009C3 RID: 2499
		// (get) Token: 0x06002A83 RID: 10883 RVA: 0x0009F2EC File Offset: 0x0009D6EC
		public string Sampling
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002A84 RID: 10884 RVA: 0x0009F32F File Offset: 0x0009D72F
		public ArraySegment<byte>? GetSamplingBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x06002A85 RID: 10885 RVA: 0x0009F33E File Offset: 0x0009D73E
		public static Offset<DungeonVerifyProbTable> CreateDungeonVerifyProbTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset OldnameOffset = default(StringOffset), StringOffset SamplingOffset = default(StringOffset))
		{
			builder.StartObject(4);
			DungeonVerifyProbTable.AddSampling(builder, SamplingOffset);
			DungeonVerifyProbTable.AddOldname(builder, OldnameOffset);
			DungeonVerifyProbTable.AddName(builder, NameOffset);
			DungeonVerifyProbTable.AddID(builder, ID);
			return DungeonVerifyProbTable.EndDungeonVerifyProbTable(builder);
		}

		// Token: 0x06002A86 RID: 10886 RVA: 0x0009F36A File Offset: 0x0009D76A
		public static void StartDungeonVerifyProbTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06002A87 RID: 10887 RVA: 0x0009F373 File Offset: 0x0009D773
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002A88 RID: 10888 RVA: 0x0009F37E File Offset: 0x0009D77E
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06002A89 RID: 10889 RVA: 0x0009F38F File Offset: 0x0009D78F
		public static void AddOldname(FlatBufferBuilder builder, StringOffset OldnameOffset)
		{
			builder.AddOffset(2, OldnameOffset.Value, 0);
		}

		// Token: 0x06002A8A RID: 10890 RVA: 0x0009F3A0 File Offset: 0x0009D7A0
		public static void AddSampling(FlatBufferBuilder builder, StringOffset SamplingOffset)
		{
			builder.AddOffset(3, SamplingOffset.Value, 0);
		}

		// Token: 0x06002A8B RID: 10891 RVA: 0x0009F3B4 File Offset: 0x0009D7B4
		public static Offset<DungeonVerifyProbTable> EndDungeonVerifyProbTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DungeonVerifyProbTable>(value);
		}

		// Token: 0x06002A8C RID: 10892 RVA: 0x0009F3CE File Offset: 0x0009D7CE
		public static void FinishDungeonVerifyProbTableBuffer(FlatBufferBuilder builder, Offset<DungeonVerifyProbTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400125A RID: 4698
		private Table __p = new Table();

		// Token: 0x020003B7 RID: 951
		public enum eCrypt
		{
			// Token: 0x0400125C RID: 4700
			code = -247309266
		}
	}
}
