using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000451 RID: 1105
	public class GoldConsignmentValueTable : IFlatbufferObject
	{
		// Token: 0x17000D42 RID: 3394
		// (get) Token: 0x06003534 RID: 13620 RVA: 0x000B8F9C File Offset: 0x000B739C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003535 RID: 13621 RVA: 0x000B8FA9 File Offset: 0x000B73A9
		public static GoldConsignmentValueTable GetRootAsGoldConsignmentValueTable(ByteBuffer _bb)
		{
			return GoldConsignmentValueTable.GetRootAsGoldConsignmentValueTable(_bb, new GoldConsignmentValueTable());
		}

		// Token: 0x06003536 RID: 13622 RVA: 0x000B8FB6 File Offset: 0x000B73B6
		public static GoldConsignmentValueTable GetRootAsGoldConsignmentValueTable(ByteBuffer _bb, GoldConsignmentValueTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003537 RID: 13623 RVA: 0x000B8FD2 File Offset: 0x000B73D2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003538 RID: 13624 RVA: 0x000B8FEC File Offset: 0x000B73EC
		public GoldConsignmentValueTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000D43 RID: 3395
		// (get) Token: 0x06003539 RID: 13625 RVA: 0x000B8FF8 File Offset: 0x000B73F8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1859833862 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D44 RID: 3396
		// (get) Token: 0x0600353A RID: 13626 RVA: 0x000B9044 File Offset: 0x000B7444
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600353B RID: 13627 RVA: 0x000B9086 File Offset: 0x000B7486
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000D45 RID: 3397
		// (get) Token: 0x0600353C RID: 13628 RVA: 0x000B9094 File Offset: 0x000B7494
		public int Value
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1859833862 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600353D RID: 13629 RVA: 0x000B90DD File Offset: 0x000B74DD
		public static Offset<GoldConsignmentValueTable> CreateGoldConsignmentValueTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int Value = 0)
		{
			builder.StartObject(3);
			GoldConsignmentValueTable.AddValue(builder, Value);
			GoldConsignmentValueTable.AddName(builder, NameOffset);
			GoldConsignmentValueTable.AddID(builder, ID);
			return GoldConsignmentValueTable.EndGoldConsignmentValueTable(builder);
		}

		// Token: 0x0600353E RID: 13630 RVA: 0x000B9101 File Offset: 0x000B7501
		public static void StartGoldConsignmentValueTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x0600353F RID: 13631 RVA: 0x000B910A File Offset: 0x000B750A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003540 RID: 13632 RVA: 0x000B9115 File Offset: 0x000B7515
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06003541 RID: 13633 RVA: 0x000B9126 File Offset: 0x000B7526
		public static void AddValue(FlatBufferBuilder builder, int Value)
		{
			builder.AddInt(2, Value, 0);
		}

		// Token: 0x06003542 RID: 13634 RVA: 0x000B9134 File Offset: 0x000B7534
		public static Offset<GoldConsignmentValueTable> EndGoldConsignmentValueTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GoldConsignmentValueTable>(value);
		}

		// Token: 0x06003543 RID: 13635 RVA: 0x000B914E File Offset: 0x000B754E
		public static void FinishGoldConsignmentValueTableBuffer(FlatBufferBuilder builder, Offset<GoldConsignmentValueTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001583 RID: 5507
		private Table __p = new Table();

		// Token: 0x02000452 RID: 1106
		public enum eCrypt
		{
			// Token: 0x04001585 RID: 5509
			code = 1859833862
		}
	}
}
